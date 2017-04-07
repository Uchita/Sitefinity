﻿using JXTJobsExport.Helpers;
using JXTPortal;
using JXTPortal.Common;
using JXTPortal.Entities;
using JXTPortal.Entities.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;

namespace JXTJobsExport
{
    class Program
    {
        static ILog _logger = LogManager.GetLogger("JobsExport");
        static TList<GlobalSettings> globalSettingsList = new TList<GlobalSettings>();
        static int qtFilesGenerated = 0;
        static XmlConfigurationFile xmlConfigurationFile;

        static void Main(string[] args)
        {
            ILog _logger = LogManager.GetLogger("PostDataToFTP");

            if (args == null)
            {
                _logger.Warn("Cannot run application without config files passed in as a parameter");
                return;
            }

#if DEBUG
            xmlConfigurationFile = new XmlConfigurationFile("Configuration.xml");
#else
            foreach (string configFilePath in args)
            {

                if (!File.Exists(configFilePath))
                {
                    _logger.ErrorFormat("Cannot find config file. {0}", configFilePath);
                    continue;
                }
                else
                    xmlConfigurationFile = new XmlConfigurationFile(configFilePath);

        }
#endif

            GenerateJobXML();
        }

        /// <summary>
        ///	Main method to export all jobs. 
        /// </summary>
        /// <remark>Export all jobs to a .ZIP file per site.</remark>
        private static void GenerateJobXML()
        {
            _logger.InfoFormat("Started. Configuration: Jobs = {0}, Advertisers = {1}, Professions = {2}, Indeed Integration = {3}",
                xmlConfigurationFile.AllJobs, xmlConfigurationFile.JobsByAdvertiser, xmlConfigurationFile.JobsByProfession, xmlConfigurationFile.IncludeIndeedIntegration);

            try
            {
                //Get all sites from database
                List<Sites> siteList = new SitesService().GetAll()
                     .Where(s => s.Live == true)//Always true
                     .Where(s => xmlConfigurationFile.Sites.Length > 0 ? xmlConfigurationFile.Sites.Contains(s.SiteId) : s.SiteId > 0)//Retrieve only sites whereas it was informed in configuration .
                     .Where(s => xmlConfigurationFile.ExcludedSites.Length > 0 ? !xmlConfigurationFile.ExcludedSites.Contains(s.SiteId) : s.SiteId > 0)//Exclude sites whereas it was informed in configuration .
                     .ToList();

                //Get all global settings
                globalSettingsList = new GlobalSettingsService().GetAll();

                GlobalSettings globalSettings = new GlobalSettings();

                AdminIntegrations.Indeed indeedIntegration;


                foreach (Sites site in siteList)
                {
                    globalSettings = globalSettingsList.FirstOrDefault(g => g.SiteId == site.SiteId);

                    if (globalSettings != null && globalSettings.GenerateJobXml)
                    {
                        // Get Indeed integration
                        indeedIntegration = GetIndeedIntegration(site);

                        var viewJobSearchList = new ViewJobSearchService().GetBySearchFilter(string.Empty,
                                                                              site.SiteId,
                                                                              null,
                                                                              null,
                                                                              null,
                                                                              null,
                                                                              null,
                                                                              null,
                                                                              null,
                                                                              string.Empty,
                                                                              null,
                                                                              null,
                                                                              string.Empty,
                                                                              null,
                                                                              0,
                                                                              Int16.MaxValue,
                                                                              string.Empty,
                                                                              null);

                        //Generate Jobs files only if it's configured to do so in the configuration file.
                        if (xmlConfigurationFile.AllJobs)
                            GenerateXmlForJobs(xmlConfigurationFile.OutputPath, viewJobSearchList, globalSettings, indeedIntegration, site);

                        //Generate Advertisers files only if it's configured to do so in the configuration file.
                        if (xmlConfigurationFile.JobsByAdvertiser)
                            GenerateXmlForAdvertisers(xmlConfigurationFile.OutputPath, viewJobSearchList, globalSettings, indeedIntegration, site);

                        //Generate Professions files only if it's configured to do so in the configuration file.
                        if (xmlConfigurationFile.JobsByProfession)
                            GenerateXmlForProfessions(xmlConfigurationFile.OutputPath, viewJobSearchList, globalSettings, indeedIntegration, site);
                    }
                }

                // Generate the the list of all WL's index.
                GenerateWhitelabelXMLList(siteList);
            }
            catch (Exception ex)
            {
                _logger.Error("An error has occurred in main GenerateJobXML method", ex);
            }

            _logger.InfoFormat("Finished with {0} files generated.");

            //The log4net-loggly library is asynchronous so there needs to be time for the threads the complete logging before the application exits.
            //https://www.loggly.com/docs/net-logs/
            Thread.Sleep(10000);//Wait 10 seconds to wait until loggly finished
        }

        /// <summary>
        ///	This method generate a XML file which contains all jobs per site. 
        /// </summary>
        /// <param name="jobsExportFolder"><c>System.String</c> folder where xml file must be create.</param>
        /// <param name="globalSettings"><c>GlobalSettings</c> global settings.</param>
        /// <param name="indeedIntegration"><c>AdminIntegrations.Indeed</c> Indeed integration information.</param>
        /// <param name="site"><c>Sites</c> site object.</param>
        /// <remark>Generate XML jobs by Site.</remark>
        private static void GenerateXmlForJobs(string jobsExportFolder, VList<ViewJobSearch> viewJobSearchList, GlobalSettings globalSettings, AdminIntegrations.Indeed indeedIntegration, Sites site)
        {
            try
            {
                _logger.DebugFormat("Found {0} jobs for site {1} url: {2}", viewJobSearchList.Count(), site.SiteId, site.SiteUrl);

                StringBuilder sbXmlJobs = new StringBuilder();

                sbXmlJobs.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                sbXmlJobs.AppendLine("<JOBS version=\"1.0\">");
                sbXmlJobs.AppendLine(string.Format("<CLIENT SiteName=\"{0}\">", System.Security.SecurityElement.Escape(site.SiteName)));

                foreach (ViewJobSearch viewJobSearch in viewJobSearchList)
                {
                    sbXmlJobs.AppendLine(WriteJobXML(site.SiteUrl, viewJobSearch, globalSettings, indeedIntegration));
                }

                sbXmlJobs.AppendLine("</CLIENT></JOBS>");

                XmlDocument xmlDocumentSite = new XmlDocument();

                xmlDocumentSite.LoadXml(sbXmlJobs.ToString());

                ParameterizedThreadStart threadParametersSite = new ParameterizedThreadStart(Helpers.Utility.SaveXML);

                Thread jobThreadSite = new Thread(threadParametersSite);

                //Remove all caracters which are invalids for a file path
                string fileName = Utility.RemoveIvalidChars(string.Format("{0}_Jobs", site.SiteUrl));

                //Add counter
                qtFilesGenerated++;

                jobThreadSite.Start(new XmlSaveType(xmlDocumentSite, jobsExportFolder + "\\" + fileName + ".xml"));
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("An error has occurred during the generate of Jobs XML file in siteId {0}", site.SiteId), ex);
            }
        }

        /// <summary>
        ///	This method generate a XML file which contains all jobs per site. 
        /// </summary>
        /// <param name="jobsExportFolder"><c>System.String</c> folder where xml file must be create.</param>
        /// <param name="globalSettings"><c>GlobalSettings</c> global settings.</param>
        /// <param name="indeedIntegration"><c>AdminIntegrations.Indeed</c> Indeed integration information.</param>
        /// <param name="site"><c>Sites</c> site object.</param>
        /// <remark>Generate XML jobs by Advertisers.</remark>
        private static void GenerateXmlForAdvertisers(string jobsExportFolder, VList<ViewJobSearch> viewJobSearchList, GlobalSettings globalSettings, AdminIntegrations.Indeed indeedIntegration, Sites site)
        {
            try
            {
                // WL Advertiser XML's
                TList<Advertisers> advertisersList = new AdvertisersService().GetBySiteId(site.SiteId);

                advertisersList.Filter = string.Format("AdvertiserAccountStatusID = {0}", (int)PortalEnums.Advertiser.AccountStatus.Approved);

                List<string> fileNames = new List<string>();

                foreach (Advertisers advertiser in advertisersList)
                {
                    var viewJobSearchAdverList = viewJobSearchList.Where(j => j.AdvertiserId == advertiser.AdvertiserId).ToList();

                    _logger.DebugFormat("Found {0} jobs for site {1} advertiser {2} and advertiserId {3}", viewJobSearchAdverList.Count(), site.SiteId, advertiser.CompanyName, advertiser.AdvertiserId);

                    StringBuilder sbAdvertiser = new StringBuilder();

                    sbAdvertiser.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    sbAdvertiser.AppendLine("<JOBS version=\"1.0\">");
                    sbAdvertiser.AppendLine(string.Format("<CLIENT AdvertiserID=\"{0}\">", advertiser.AdvertiserId));

                    foreach (ViewJobSearch viewJobSearch in viewJobSearchAdverList)
                    {
                        sbAdvertiser.AppendLine(WriteJobXML(site.SiteUrl, viewJobSearch, globalSettings, indeedIntegration));
                    }

                    sbAdvertiser.AppendLine("</CLIENT></JOBS>");

                    XmlDocument xmlDocumentJobAdvertiser = new XmlDocument();
                    xmlDocumentJobAdvertiser.LoadXml(sbAdvertiser.ToString());

                    ParameterizedThreadStart threadParametersAdvertiser = new ParameterizedThreadStart(Helpers.Utility.SaveXML);

                    Thread jobThreadAdvertiser = new Thread(threadParametersAdvertiser);

                    //Remove all caracters which are invalids as a file path
                    string fileName = Helpers.Utility.RemoveIvalidChars(string.Format("{0}_{1}", site.SiteUrl, advertiser.CompanyName));

                    if (Utility.FindDuplicateStringPath(fileName, fileNames))
                    {
                        fileName = string.Format("{0}_{1}", fileName, advertiser.AdvertiserId);

                        fileNames.Add(fileName);
                    }
                    else
                    {
                        fileNames.Add(fileName);
                    }

                    //Add counter
                    qtFilesGenerated++;

                    jobThreadAdvertiser.Start(new Helpers.XmlSaveType(xmlDocumentJobAdvertiser, jobsExportFolder + "\\" + fileName + ".xml"));
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("An error has occurred during the generate of Advertisers XML file in siteId {0}", site.SiteId), ex);
            }
        }

        /// <summary>
        ///	This method generate a XML file which contains all jobs per site. 
        /// </summary>
        /// <param name="jobsExportFolder"><c>System.String</c> folder where xml file must be create.</param>
        /// <param name="globalSettings"><c>GlobalSettings</c> global setting.</param>
        /// <param name="indeedIntegration"><c>AdminIntegrations.Indeed</c> Indeed integration information.</param>
        /// <param name="site"><c>Sites</c> site object.</param>
        /// <remark>Generate XML jobs by Professions.</remark>
        private static void GenerateXmlForProfessions(string jobsExportFolder, VList<ViewJobSearch> viewJobSearchList, GlobalSettings globalSettings, AdminIntegrations.Indeed indeedIntegration, Sites site)
        {
            try
            {
                // Generate WL Profession XML's
                TList<SiteProfession> siteProfessionList = new SiteProfessionService().GetBySiteId(site.SiteId);
                siteProfessionList.Filter = "Valid = true";

                List<string> fileNames = new List<string>();

                foreach (SiteProfession siteProfession in siteProfessionList)
                {
                    var viewJobSearchProfessionList = viewJobSearchList.Where(j => j.ProfessionId == siteProfession.ProfessionId).ToList();

                    _logger.DebugFormat("Found {0} jobs for site {1} profession {2} and professionId {3}", viewJobSearchProfessionList.Count(), site.SiteId, siteProfession.SiteProfessionName, siteProfession.ProfessionId);

                    StringBuilder sbProfession = new StringBuilder();

                    sbProfession.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    sbProfession.AppendLine("<JOBS version=\"1.0\">");
                    sbProfession.AppendLine(string.Format("<CLIENT ProfessionID=\"{0}\">", siteProfession.ProfessionId));

                    foreach (ViewJobSearch viewJobSearch in viewJobSearchProfessionList)
                    {
                        sbProfession.AppendLine(WriteJobXML(site.SiteUrl, viewJobSearch, globalSettings, indeedIntegration));
                    }

                    sbProfession.AppendLine("</CLIENT></JOBS>");

                    XmlDocument xmlDocumentJobProfession = new XmlDocument();
                    xmlDocumentJobProfession.LoadXml(sbProfession.ToString());

                    ParameterizedThreadStart threadParametersProfession = new ParameterizedThreadStart(Helpers.Utility.SaveXML);

                    Thread jobThreadProfession = new Thread(threadParametersProfession);

                    //Remove all caracters which are invalids for a file path
                    string fileName = Helpers.Utility.RemoveIvalidChars(string.Format("{0}_{1}", site.SiteUrl, siteProfession.SiteProfessionFriendlyUrl));

                    if (Helpers.Utility.FindDuplicateStringPath(fileName, fileNames))
                    {
                        fileName = string.Format("{0}_{1}", fileName, siteProfession.ProfessionId);

                        fileNames.Add(fileName);
                    }
                    else
                    {
                        fileNames.Add(fileName);
                    }

                    //Add counter
                    qtFilesGenerated++;

                    jobThreadProfession.Start(new Helpers.XmlSaveType(xmlDocumentJobProfession, jobsExportFolder + "\\" + fileName + ".xml"));
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("An error has occurred during the generate of Profession XML file in siteId {0}", site.SiteId), ex);
            }
        }

        /// <summary>
        ///	This method gets information to integrate with Indeed. 
        /// </summary>
        /// <param name="site"><c>string</c> site object.</param>
        /// <remark>Get all information related to Indeed integration configuration.</remark>
        /// <return>Indeed object with all configurations.</return>
        private static AdminIntegrations.Indeed GetIndeedIntegration(Sites site)
        {
            AdminIntegrations.Indeed indeedIntegration = null;

            //Return null in cases where Indeed integration is not necessary
            if (xmlConfigurationFile.IncludeIndeedIntegration)
                return indeedIntegration;

            // Get all the valid Indeed Integrations
            List<Integrations> integrationList = new IntegrationsService().GetAll()
                                                                          .Where(i => i.IntegrationType == (int)PortalEnums.SocialMedia.SocialMediaType.Indeed && i.Valid == true)
                                                                          .ToList();

            if (integrationList != null && integrationList.Where(g => g.SiteId == site.SiteId).FirstOrDefault() != null)
            {
                if (!string.IsNullOrWhiteSpace(integrationList.Where(g => g.SiteId == site.SiteId).FirstOrDefault().JsonText))
                {
                    indeedIntegration = new JavaScriptSerializer().Deserialize<AdminIntegrations.Indeed>(integrationList.Where(g => g.SiteId == site.SiteId)
                                                                                                                  .FirstOrDefault()
                                                                                                                  .JsonText);
                }
            }

            return indeedIntegration;
        }

        /// <summary>
        ///	This method create a node for XML job file. 
        /// </summary>
        /// <param name="siteURL"><c>System.String</c> site url.</param>
        /// <param name="viewJobSearch"><c>ViewJobSearch</c> JOB object.</param>
        /// <param name="globalSettings"><c>GlobalSettings</c> global settings object</param>
        /// <param name="indeedIntegration"><c>AdminIntegrations.Indeed</c> Indeed Integration object.</param>
        /// <remark>Create a node for each job to be added to XML file.</remark>
        /// <return>String node to be added to the XML file.</return>
        private static string WriteJobXML(string siteURL, ViewJobSearch viewJobSearch, GlobalSettings globalSettings, AdminIntegrations.Indeed indeedIntegration = null)
        {
            string indeedtext = string.Empty;
            string posturl = string.Empty;
            bool usingssl = globalSettings.UsingSsl;
            bool wwwredirect = globalSettings.WwwRedirect;

            if (indeedIntegration != null)
            {
                posturl = string.Format("{0}://{1}{2}", (usingssl) ? "https" : "http", (wwwredirect ? "www." : string.Empty) + siteURL,
                                        "/oauthcallback.aspx?cbtype=indeed&cbaction=apply&jobid=" + viewJobSearch.JobId.ToString() +
                                        "&profession=" + Utils.UrlFriendlyName(viewJobSearch.SiteProfessionName) + "&jobname=" + HttpUtility.UrlEncode(viewJobSearch.JobName));


                indeedtext = string.Format("<indeed-apply-data>\n<![CDATA[\nindeed-apply-joburl={0}\n&indeed-apply-jobid={1}\n&indeed-apply-jobtitle={2}\n&indeed-apply-jobcompanyname={3}\n&indeed-apply-joblocation={4}\n&indeed-apply-apitoken={5}\n&indeed-apply-posturl={6} \n&indeed-apply-phone=optional\n&indeed-apply-allow-apply-on-indeed=0\n]]>\n</indeed-apply-data>",
                                            HttpUtility.UrlEncode((usingssl) ? "https" : "http" + "://" + ((wwwredirect) ? "www." : string.Empty) + siteURL + Utils.GetJobUrl(viewJobSearch.JobId, viewJobSearch.JobFriendlyName, Utils.UrlFriendlyName(viewJobSearch.SiteProfessionName))),
                                            viewJobSearch.JobId,
                                            HttpUtility.UrlEncode(viewJobSearch.JobName),
                                            HttpUtility.UrlEncode(viewJobSearch.CompanyName),
                                            HttpUtility.UrlEncode(viewJobSearch.LocationName),
                                            indeedIntegration.APIToken,
                                            HttpUtility.UrlEncode(posturl));
            }

            return string.Format(@"<JOB JobID='{0}'>
                               <REFNO><![CDATA[{1}]]></REFNO>
                               <ADVERTISERID>{2}</ADVERTISERID>
                               <ADVERTISERNAME><![CDATA[{3}]]></ADVERTISERNAME>
                               <TITLE><![CDATA[{4}]]></TITLE>
                               <DESCRIPTION><![CDATA[{5}]]></DESCRIPTION>
                               <FULLDESCRIPTION><![CDATA[{6}]]></FULLDESCRIPTION>
                               <BULLETPOINTS>
                                <BULLET1><![CDATA[{7}]]></BULLET1>
                                <BULLET2><![CDATA[{8}]]></BULLET2>
                                <BULLET3><![CDATA[{9}]]></BULLET3>
                               </BULLETPOINTS>
                               <APPLICATIONEMAILADDRESS><![CDATA[10]]></APPLICATIONEMAILADDRESS>
                               <DATEPOSTED><![CDATA[{11}]]></DATEPOSTED>
                               <DATEEXPIRY><![CDATA[{12}]]></DATEEXPIRY>
                               <SALARY>
                                       <SALARYTYPE><![CDATA[{13}]]></SALARYTYPE>
                                       <SALARYTEXT><![CDATA[{14}]]></SALARYTEXT>
                                       <SALARYLOWERBAND><![CDATA[{15}]]></SALARYLOWERBAND>
                                       <SALARYUPPERBAND><![CDATA[{16}]]></SALARYUPPERBAND>
                                       <SHOWSALARY>{17}</SHOWSALARY>
                               </SALARY>
                               <APPLICATIONURL><![CDATA[{18}]]></APPLICATIONURL>
                               <CONTACTDETAILS><![CDATA[{19}]]></CONTACTDETAILS>
                               <CATEGORIES>
                                        <CLASSIFICATION><![CDATA[{20}]]></CLASSIFICATION>
                                        <SUBCLASSIFICATION><![CDATA[{21}]]></SUBCLASSIFICATION>
                               </CATEGORIES>
                               <LISTING>
                                        <CLASSIFICATION Name='WORKTYPE'><![CDATA[{22}]]></CLASSIFICATION>
                                        <CLASSIFICATION Name='LOCATION'><![CDATA[{23}]]></CLASSIFICATION>
                                        <CLASSIFICATION Name='AREA'><![CDATA[{24}]]></CLASSIFICATION>
                               </LISTING>
                                <JOBURL>{25}</JOBURL>
                                <LATITUDE>{27}</LATITUDE>
                                <LONGITUDE>{28}</LONGITUDE>
                                <STREETADDRESS><![CDATA[{29}]]></STREETADDRESS>
                                <WORKTYPE><![CDATA[{22}]]></WORKTYPE>
                                <LOCATION><![CDATA[{23}]]></LOCATION>
                                <AREA><![CDATA[{24}]]></AREA>
                                {26}
                          </JOB>",
                                 viewJobSearch.JobId,
                                 viewJobSearch.RefNo,
                                 viewJobSearch.AdvertiserId,
                                 viewJobSearch.AdvertiserName,
                                 viewJobSearch.JobName,
                                 viewJobSearch.Description,
                                 CommonService.EncodeString(viewJobSearch.FullDescription, false, false, true), // FullDescription - Remove script tags
                                 viewJobSearch.BulletPoint1,
                                 viewJobSearch.BulletPoint2,
                                 viewJobSearch.BulletPoint3,
                                 viewJobSearch.ApplicationEmailAddress, // ApplicationEmailAddress
                                 viewJobSearch.DatePosted.ToString("dd/MM/yyyy"),
                                 viewJobSearch.ExpiryDate.ToString("dd/MM/yyyy"), // ExpiryDate
                                 viewJobSearch.SalaryTypeName,
                                 viewJobSearch.SalaryText,
                                 viewJobSearch.SalaryLowerBand,
                                 viewJobSearch.SalaryUpperBand,
                                 viewJobSearch.ShowSalaryDetails,
                                 viewJobSearch.ApplicationUrl,
                                 viewJobSearch.ContactDetails, // ContactDetails
                                 viewJobSearch.SiteProfessionName,
                                 viewJobSearch.SiteRoleName,
                                 viewJobSearch.WorkTypeName,
                                 viewJobSearch.LocationName,
                                viewJobSearch.AreaName,
                                (usingssl) ? "https" : "http" + "://" + ((wwwredirect) ? "www." : string.Empty) + siteURL + Utils.GetJobUrl(viewJobSearch.JobId, viewJobSearch.JobFriendlyName),
                                indeedtext,
                                viewJobSearch.JobLatitude.HasValue ? viewJobSearch.JobLatitude.Value : 0,
                                viewJobSearch.JobLongitude.HasValue ? viewJobSearch.JobLongitude.Value : 0,
                                viewJobSearch.Address
                            );
        }

        /// <summary>
        ///	This method generate the Index.xml file which contains a list of all zip/xml files generated. 
        /// </summary>
        /// <param name="siteList"><c>List<Sites></c> list of sites generated.</param>
        /// <remark>Use to create Index.xml file with a list of all files generated.</remark>
        private static void GenerateWhitelabelXMLList(List<Sites> siteList)
        {
            try
            {
                StringBuilder xmlWhiteList = new StringBuilder();

                xmlWhiteList.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                xmlWhiteList.Append("<WHITELABELS>");

                GlobalSettings globalSetting = new GlobalSettings();

                foreach (Sites site in siteList)
                {
                    globalSetting = globalSettingsList.FirstOrDefault(g => g.SiteId == site.SiteId);

                    // Only valid and no-mobile sites.
                    if (globalSetting != null && globalSetting.GenerateJobXml)
                    {
                        xmlWhiteList.Append(string.Format("<WHITELABEL SITEURL='{0}'>http://www.jxt.net.au/jobxml/{0}_Jobs.zip</WHITELABEL>", site.SiteUrl));
                    }
                }

                xmlWhiteList.Append("</WHITELABELS>");

                XmlDocument document = new XmlDocument();

                document.LoadXml(xmlWhiteList.ToString());
                document.Save(ConfigurationManager.AppSettings["JobsExportFolder"] + "\\index.xml");
            }
            catch (Exception ex)
            {
                _logger.Error("An error has occurred during the GenerateWhitelabelXMLList", ex);
            }
        }
    }
}
