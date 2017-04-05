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
using System.Timers;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;

namespace JXTJobsExport
{
    class Program
    {
        static ILog _logger = LogManager.GetLogger("JobsExport");
        static TList<GlobalSettings> globalSettingsList = new TList<GlobalSettings>();

        static void Main(string[] args)
        {
            int siteid = 0;

            if (args != null)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (int.TryParse(args[i], out siteid))
                    {
                    }
                }
            }

            //Call method to export jobs.
            GenerateJobXML(siteid);
        }

        /// <summary>
        ///	Main method to export all jobs. 
        /// </summary>
        /// <param name="siteId"><c>int</c> identify site.</param>
        /// <remark>Export all jobs to a .ZIP file per site.</remark>
        private static void GenerateJobXML(int siteId)
        {
            _logger.Info("Started");

            // Retrieve all valid site
            string jobsExportFolder = ConfigurationManager.AppSettings["JobsExportFolder"];

            //Get all sites from database
            TList<Sites> siteList = new SitesService().GetAll();

            if (siteId > 0)
                siteList.Filter = "Live = true AND SiteId = " + siteId.ToString();
            else
                siteList.Filter = "Live = true";

            //Get all global settings
            globalSettingsList = new GlobalSettingsService().GetAll();

            GlobalSettings globalSettings = new GlobalSettings();

            AdminIntegrations.Indeed indeedIntegration;

            try
            {
                foreach (Sites site in siteList)
                {
                    globalSettings = globalSettingsList.Where(g => g.SiteId == site.SiteId).FirstOrDefault();

                    if (globalSettings != null && globalSettings.GenerateJobXml)
                    {
                        // Get Indeed integration
                        indeedIntegration = GetIndeedIntegration(site);

                        GenerateXmlForJobs(jobsExportFolder, globalSettings, indeedIntegration, site);
                        GenerateXmlForAdvertisers(jobsExportFolder, globalSettings, indeedIntegration, site);
                        GenerateXmlForProfessions(jobsExportFolder, globalSettings, indeedIntegration, site);
                    }
                }

                // Generate the the list of all WL's index.
                GenerateWhitelabelXMLList(siteList);
            }
            catch (Exception ex)
            {
                _logger.Error("An error has occurred in main GenareteJobXML method", ex);
            }

            _logger.Info("Finished");

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
        private static void GenerateXmlForJobs(string jobsExportFolder, GlobalSettings globalSettings, AdminIntegrations.Indeed indeedIntegration, Sites site)
        {
            try
            {
                ViewJobSearchService viewJobSearchService = new ViewJobSearchService();

                // WL all jobs XML's
                var viewJobSearchList = viewJobSearchService.GetBySearchFilter(string.Empty,
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

                _logger.DebugFormat("Found {0} jobs for site {1} url: {2}", viewJobSearchList.Count(), site.SiteId, site.SiteUrl);

                StringBuilder sbXmlJobs = new StringBuilder();

                sbXmlJobs.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                sbXmlJobs.AppendLine("<JOBS version=\"1.0\">");
                sbXmlJobs.AppendLine(string.Format("<CLIENT SiteName=\"{0}\">", site.SiteName));

                foreach (ViewJobSearch viewJobSearch in viewJobSearchList)
                {
                    sbXmlJobs.AppendLine(WriteJobXML(site.SiteUrl, viewJobSearch, globalSettings, indeedIntegration));
                }

                sbXmlJobs.AppendLine("</CLIENT></JOBS>");

                XmlDocument xmlDocumentSite = new XmlDocument();

                xmlDocumentSite.LoadXml(sbXmlJobs.ToString());

                ParameterizedThreadStart threadParametersSite = new ParameterizedThreadStart(Helpers.Utility.SaveXML);

                Thread jobThreadSite = new Thread(threadParametersSite);

                string fileName = string.Format("{0}_Jobs.xml", site.SiteUrl);

                //Remove all caracters which are invalids for a file path
                Helpers.Utility.RemoveIvalidChars(ref fileName);

                jobThreadSite.Start(new Helpers.XmlSaveType(xmlDocumentSite, jobsExportFolder + "\\" + fileName));
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("An error has occurred during the genarete od Jobs XML file int siteId {0}", site.SiteId), ex);
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
        private static void GenerateXmlForAdvertisers(string jobsExportFolder, GlobalSettings globalSettings, AdminIntegrations.Indeed indeedIntegration, Sites site)
        {
            try
            {
                // WL Advertiser XML's
                TList<Advertisers> advertisersList = new AdvertisersService().GetBySiteId(site.SiteId);

                advertisersList.Filter = string.Format("AdvertiserAccountStatusID = {0}", (int)PortalEnums.Advertiser.AccountStatus.Approved);

                List<string> fileNames = new List<string>();
                foreach (Advertisers advertiser in advertisersList)
                {
                    var viewJobSearchList = new ViewJobSearchService().GetBySearchFilter(string.Empty,
                                                                                         site.SiteId,
                                                                                         advertiser.AdvertiserId,
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

                    _logger.DebugFormat("Found {0} jobs for site {1} Adveriser: {2}", viewJobSearchList.Count(), site.SiteId, advertiser.CompanyName);

                    StringBuilder sbAdvertiser = new StringBuilder();

                    sbAdvertiser.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    sbAdvertiser.AppendLine("<JOBS version=\"1.0\">");
                    sbAdvertiser.AppendLine(string.Format("<CLIENT AdvertiserID=\"{0}\">", advertiser.AdvertiserId));

                    foreach (ViewJobSearch viewJobSearch in viewJobSearchList)
                    {
                        sbAdvertiser.AppendLine(WriteJobXML(site.SiteUrl, viewJobSearch, globalSettings, indeedIntegration));
                    }

                    sbAdvertiser.AppendLine("</CLIENT></JOBS>");

                    XmlDocument xmlDocumentJobAdvertiser = new XmlDocument();
                    xmlDocumentJobAdvertiser.LoadXml(sbAdvertiser.ToString());

                    ParameterizedThreadStart threadParametersAdvertiser = new ParameterizedThreadStart(Helpers.Utility.SaveXML);

                    Thread jobThreadAdvertiser = new Thread(threadParametersAdvertiser);

                    string fileName = string.Format("{0}_{1}.xml", site.SiteUrl, advertiser.CompanyName);

                    //Remove all caracters which are invalids as a file path
                    Helpers.Utility.RemoveIvalidChars(ref fileName);

                    if (Helpers.Utility.FindDuplicateStringPath(fileName, fileNames))
                    {
                        fileName = string.Format("{0}_{1}_{2}.xml", site.SiteUrl, advertiser.CompanyName, advertiser.AdvertiserId);

                        //Remove all caracters which are invalids for a file path
                        Helpers.Utility.RemoveIvalidChars(ref fileName);

                        fileNames.Add(fileName);
                    }
                    else
                    {
                        fileNames.Add(fileName);
                    }

                    jobThreadAdvertiser.Start(new Helpers.XmlSaveType(xmlDocumentJobAdvertiser, jobsExportFolder + "\\" + fileName));
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("An error has occurred during the genarete od Advertisers XML file int siteId {0}", site.SiteId), ex);
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
        private static void GenerateXmlForProfessions(string jobsExportFolder, GlobalSettings globalSettings, AdminIntegrations.Indeed indeedIntegration, Sites site)
        {
            try
            {
                // Generate WL Profession XML's
                TList<SiteProfession> siteProfessionList = new SiteProfessionService().GetBySiteId(site.SiteId);
                siteProfessionList.Filter = "Valid = true";

                List<string> fileNames = new List<string>();

                foreach (SiteProfession siteProfession in siteProfessionList)
                {
                    var viewJobSearchList = new ViewJobSearchService().GetBySearchFilter(string.Empty,
                                                                                         site.SiteId,
                                                                                         null,
                                                                                         null,
                                                                                         null,
                                                                                         null,
                                                                                         null,
                                                                                         null,
                                                                                         siteProfession.ProfessionId,
                                                                                         string.Empty,
                                                                                         null,
                                                                                         null,
                                                                                         string.Empty,
                                                                                         null,
                                                                                         0,
                                                                                         Int16.MaxValue,
                                                                                         string.Empty,
                                                                                         null);

                    _logger.DebugFormat("Found {0} jobs for site {1} profession: {2}", viewJobSearchList.Count(), site.SiteId, siteProfession.SiteProfessionName);

                    StringBuilder sbProfession = new StringBuilder();

                    sbProfession.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    sbProfession.AppendLine("<JOBS version=\"1.0\">");
                    sbProfession.AppendLine(string.Format("<CLIENT ProfessionID=\"{0}\">", siteProfession.ProfessionId));

                    foreach (ViewJobSearch viewJobSearch in viewJobSearchList)
                    {
                        sbProfession.AppendLine(WriteJobXML(site.SiteUrl, viewJobSearch, globalSettings, indeedIntegration));
                    }

                    sbProfession.AppendLine("</CLIENT></JOBS>");

                    XmlDocument xmlDocumentJobProfession = new XmlDocument();
                    xmlDocumentJobProfession.LoadXml(sbProfession.ToString());

                    ParameterizedThreadStart threadParametersProfession = new ParameterizedThreadStart(Helpers.Utility.SaveXML);

                    Thread jobThreadProfession = new Thread(threadParametersProfession);

                    string fileName = string.Format("{0}_{1}.xml", site.SiteUrl, siteProfession.SiteProfessionFriendlyUrl);

                    //Remove all caracters which are invalids for a file path
                    Helpers.Utility.RemoveIvalidChars(ref fileName);

                    if (Helpers.Utility.FindDuplicateStringPath(fileName, fileNames))
                    {
                        fileName = string.Format("{0}_{1}_{2}.xml", site.SiteUrl, siteProfession.SiteProfessionFriendlyUrl, siteProfession.ProfessionId);

                        //Remove all caracters which are invalids for a file path
                        Helpers.Utility.RemoveIvalidChars(ref fileName);

                        fileNames.Add(fileName);
                    }
                    else
                    {
                        fileNames.Add(fileName);
                    }

                    jobThreadProfession.Start(new Helpers.XmlSaveType(xmlDocumentJobProfession, jobsExportFolder + "\\" + fileName));
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("An error has occurred during the genarete od Profession XML file int siteId {0}", site.SiteId), ex);
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
                                <STREETADDRESS>{29}</STREETADDRESS>
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
        /// <param name="siteList"><c>TList<Sites></c> list of sites generated.</param>
        /// <remark>Use to create Index.xml file with a list of all files generated.</remark>
        private static void GenerateWhitelabelXMLList(TList<Sites> siteList)
        {
            try
            {
                StringBuilder xmlWhiteList = new StringBuilder();

                xmlWhiteList.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                xmlWhiteList.Append("<WHITELABELS>");

                GlobalSettings globalSetting = new GlobalSettings();

                foreach (Sites site in siteList)
                {
                    globalSetting = globalSettingsList.Where(g => g.SiteId == site.SiteId).FirstOrDefault();

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
