using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using System.Web;

using ICSharpCode.SharpZipLib.Zip;

using JXTPortal.Data;
using JXTPortal.Common;
using JXTPortal.Entities;
using JXTPortal;
using System.Web.Script.Serialization;
using JXTPortal.Entities.Models;

namespace JXTJobsExport
{
    class Program
    {
        static void Main(string[] args)
        {
            int siteid = 0;

            if (args != null)
            {
                for (int i = 0; i < args.Length; i++) // Loop through array
                {
                    if (int.TryParse(args[i], out siteid))
                    {
                    }
                }
            }

            GenerateJobXML(siteid);
        }
        static TList<GlobalSettings> globalSettingsList = new TList<GlobalSettings>();

        private static void GenerateJobXML(int siteid)
        {

            // Retrieve all valid site
            string jobsexportfolder = ConfigurationManager.AppSettings["JobsExportFolder"];
            SitesService ss = new SitesService();
            TList<Sites> ls = ss.GetAll();

            if (siteid > 0)
                ls.Filter = "Live = true AND SiteId = " + siteid.ToString();
            else
                ls.Filter = "Live = true";

            GlobalSettingsService gss = new GlobalSettingsService();
            globalSettingsList = gss.GetAll();

            GlobalSettings globalSetting = new GlobalSettings();

            // Get all the valid Indeed Integrations
            IntegrationsService integrationService = new IntegrationsService();
            List<Integrations> integrationList = integrationService.GetAll().Where(s => s.IntegrationType == (int)JXTPortal.Entities.PortalEnums.SocialMedia.SocialMediaType.Indeed && s.Valid == true).ToList();
            ViewJobSearchService vjss = new ViewJobSearchService();
            AdvertisersService ads = new AdvertisersService();
            SiteProfessionService sps = new SiteProfessionService();

            JavaScriptSerializer ser = new JavaScriptSerializer();

            string siteUrl = string.Empty;
            AdminIntegrations.Indeed indeedIntegration = null;

            foreach (Sites s in ls)
            {
                try
                {
                    globalSetting = globalSettingsList.Where(g => g.SiteId == s.SiteId).FirstOrDefault();

                    VList<ViewJobSearch> lvjs = new VList<ViewJobSearch>();

                    indeedIntegration = null;


                    if (globalSetting != null)
                    {
                        siteUrl = (globalSetting.EnableSsl ? "https://" : "http://") + (globalSetting.WwwRedirect ? "www." : string.Empty);
                    }

                    // If Global settings is enabled or Indeed Integration is enabled.
                    if ((globalSetting != null && globalSetting.GenerateJobXml) ||
                            (integrationList != null && integrationList.Where(g => g.SiteId == s.SiteId).FirstOrDefault() != null))
                    {
                        // WL all jobs XML's
                        lvjs = vjss.GetBySearchFilter(string.Empty,
                                                        s.SiteId, null,
                                                        null, null, null, null, null,
                                                       null, string.Empty,
                                                        null, null, string.Empty, null,
                                                        0, Int16.MaxValue, string.Empty, null);

                    }


                    if (integrationList != null && integrationList.Where(g => g.SiteId == s.SiteId).FirstOrDefault() != null)
                    {
                        if (lvjs.Count > 0 && !string.IsNullOrWhiteSpace(integrationList.Where(g => g.SiteId == s.SiteId).FirstOrDefault().JsonText))
                        {
                            indeedIntegration = ser.Deserialize<AdminIntegrations.Indeed>(integrationList.Where(g => g.SiteId == s.SiteId).FirstOrDefault().JsonText);
                        }
                    }

                    if (globalSetting != null && globalSetting.GenerateJobXml)
                    {

                        if (lvjs.Count > 0)
                        {
                            StringBuilder sbjob = new StringBuilder();
                            sbjob.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                            sbjob.AppendLine("<JOBS version=\"1.0\">");
                            sbjob.AppendLine(string.Format("<CLIENT SiteName=\"{0}\">", s.SiteName));

                            foreach (ViewJobSearch vjs in lvjs)
                            {
                                sbjob.AppendLine(WriteJobXML(s.SiteUrl, vjs, globalSetting, indeedIntegration));
                            }

                            sbjob.AppendLine("</CLIENT></JOBS>");
                            XmlDocument xdjob = new XmlDocument();
                            xdjob.LoadXml(sbjob.ToString());

                            ParameterizedThreadStart ptsjob = new ParameterizedThreadStart(SaveXML);
                            Thread tjob = new Thread(ptsjob);
                            tjob.Start(new XmlSaveType(xdjob, string.Format("{0}\\{1}_Jobs.xml", jobsexportfolder, s.SiteUrl)));

                        }

                        // WL Advertiser XML's
                        TList<Advertisers> lad = ads.GetBySiteId(s.SiteId);

                        lad.Filter = string.Format("AdvertiserAccountStatusID = {0}", (int)PortalEnums.Advertiser.AccountStatus.Approved);
                        foreach (Advertisers adv in lad)
                        {
                            VList<ViewJobSearch> lvjsadv = vjss.GetBySearchFilter(string.Empty,
                                                           s.SiteId, adv.AdvertiserId,
                                                           null, null, null, null, null,
                                                          null, string.Empty,
                                                           null, null, string.Empty, null,
                                                           0, Int16.MaxValue, string.Empty, null);
                            if (lvjsadv.Count > 0)
                            {
                                StringBuilder sbadv = new StringBuilder();
                                sbadv.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                                sbadv.AppendLine("<JOBS version=\"1.0\">");
                                sbadv.AppendLine(string.Format("<CLIENT AdvertiserID=\"{0}\">", adv.AdvertiserId));

                                foreach (ViewJobSearch vjs in lvjsadv)
                                {
                                    sbadv.AppendLine(WriteJobXML(s.SiteUrl, vjs, globalSetting, indeedIntegration));
                                }

                                sbadv.AppendLine("</CLIENT></JOBS>");
                                XmlDocument xdjob = new XmlDocument();
                                xdjob.LoadXml(sbadv.ToString());

                                ParameterizedThreadStart ptsjob = new ParameterizedThreadStart(SaveXML);
                                Thread tjob = new Thread(ptsjob);
                                string companyname = adv.CompanyName;
                                foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                                {
                                    companyname = companyname.Replace(c.ToString(), "_");
                                }

                                tjob.Start(new XmlSaveType(xdjob, string.Format("{0}\\{1}_{2}.xml", jobsexportfolder, s.SiteUrl, companyname.Replace(" ", "_"))));
                            }
                        }

                        // Generate WL Profession XML's
                        TList<SiteProfession> lsp = sps.GetBySiteId(s.SiteId);
                        lsp.Filter = "Valid = true";

                        foreach (SiteProfession sp in lsp)
                        {
                            VList<ViewJobSearch> lvjssp = vjss.GetBySearchFilter(string.Empty,
                                                          s.SiteId, null,
                                                          null, null, null, null, null,
                                                         sp.ProfessionId, string.Empty,
                                                          null, null, string.Empty, null,
                                                          0, Int16.MaxValue, string.Empty, null);
                            if (lvjssp.Count > 0)
                            {
                                StringBuilder sbsp = new StringBuilder();
                                sbsp.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                                sbsp.AppendLine("<JOBS version=\"1.0\">");
                                sbsp.AppendLine(string.Format("<CLIENT ProfessionID=\"{0}\">", sp.ProfessionId));

                                foreach (ViewJobSearch vjs in lvjssp)
                                {
                                    sbsp.AppendLine(WriteJobXML(s.SiteUrl, vjs, globalSetting, indeedIntegration));
                                }

                                sbsp.AppendLine("</CLIENT></JOBS>");
                                XmlDocument xdjob = new XmlDocument();
                                xdjob.LoadXml(sbsp.ToString());

                                ParameterizedThreadStart ptsjob = new ParameterizedThreadStart(SaveXML);
                                Thread tjob = new Thread(ptsjob);


                                tjob.Start(new XmlSaveType(xdjob, string.Format("{0}\\{1}_{2}.xml", jobsexportfolder, s.SiteUrl, sp.SiteProfessionFriendlyUrl)));
                            }
                        }


                    }

                    // Only if the Indeed integration is enabled for the site.
                    //                    if (integrationList != null && integrationList.Where(g => g.SiteId == s.SiteId).FirstOrDefault() != null)
                    //                    {
                    //                        if (lvjs.Count > 0 && !string.IsNullOrWhiteSpace(integrationList.Where(g => g.SiteId == s.SiteId).FirstOrDefault().JsonText))
                    //                        {
                    //                            AdminIntegrations.Indeed indeedIntegration = ser.Deserialize<AdminIntegrations.Indeed>(integrationList.Where(g => g.SiteId == s.SiteId).FirstOrDefault().JsonText);
                    //                            StringBuilder sbjob = new StringBuilder();
                    //                            sbjob.AppendLine(string.Format(@"<?xml version='1.0' encoding='utf-8'?>
                    //<source>
                    //<publisher>{0}</publisher>
                    //<publisherurl>{1}</publisherurl>
                    //<lastBuildDate>{2}</lastBuildDate>", s.SiteName, s.SiteUrl, DateTime.UtcNow.ToString("R")));

                    //                            foreach (ViewJobSearch vjs in lvjs)
                    //                            {
                    //                                sbjob.AppendLine(WriteIndeedJobXML(siteUrl, vjs, indeedIntegration));
                    //                            }

                    //                            sbjob.AppendLine("</source>");
                    //                            XmlDocument xdjob = new XmlDocument();
                    //                            xdjob.LoadXml(sbjob.ToString());

                    //                            ParameterizedThreadStart ptsjob = new ParameterizedThreadStart(SaveXML);
                    //                            Thread tjob = new Thread(ptsjob);
                    //                            tjob.Start(new XmlSaveType(xdjob, string.Format("{0}\\{1}_IndeedJobs.xml", jobsexportfolder, s.SiteUrl)));

                    //                        }
                    //                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0}\n{1}", ex.Message, ex.StackTrace);
                    //Console.ReadLine();
                }
            }

            // Generate the the list of all WL's index.
            GenerateWhitelabelXMLList(ls);

            Console.WriteLine("Finished.");
        }

        private static string WriteJobXML(string siteURL, ViewJobSearch vjs, JXTPortal.Entities.GlobalSettings globalsettings, AdminIntegrations.Indeed indeedIntegration = null)
        {
            string indeedtext = string.Empty;
            string posturl = string.Empty;
            bool usingssl = globalsettings.UsingSsl;
            bool wwwredirect = globalsettings.WwwRedirect;
            if (indeedIntegration != null)
            {
                posturl = string.Format("{0}://{1}{2}", (usingssl) ? "https" : "http", (wwwredirect ? "www." : string.Empty) + siteURL,
                                        "/oauthcallback.aspx?cbtype=indeed&cbaction=apply&jobid=" + vjs.JobId.ToString() +
                                        "&profession=" + JXTPortal.Common.Utils.UrlFriendlyName(vjs.SiteProfessionName) + "&jobname=" + HttpUtility.UrlEncode(vjs.JobName));


                indeedtext = string.Format("<indeed-apply-data>\n<![CDATA[\nindeed-apply-joburl={0}\n&indeed-apply-jobid={1}\n&indeed-apply-jobtitle={2}\n&indeed-apply-jobcompanyname={3}\n&indeed-apply-joblocation={4}\n&indeed-apply-apitoken={5}\n&indeed-apply-posturl={6} \n&indeed-apply-phone=optional\n&indeed-apply-allow-apply-on-indeed=0\n]]>\n</indeed-apply-data>",
                                            HttpUtility.UrlEncode((usingssl) ? "https" : "http" + "://" + ((wwwredirect) ? "www." : string.Empty) + siteURL + Utils.GetJobUrl(vjs.JobId, vjs.JobFriendlyName, JXTPortal.Common.Utils.UrlFriendlyName(vjs.SiteProfessionName))),
                                            vjs.JobId,
                                            HttpUtility.UrlEncode(vjs.JobName),
                                            HttpUtility.UrlEncode(vjs.CompanyName),
                                            HttpUtility.UrlEncode(vjs.LocationName),
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
                                 vjs.JobId,
                                 vjs.RefNo,
                                 vjs.AdvertiserId,
                                 vjs.AdvertiserName,
                                 vjs.JobName,
                                 vjs.Description,
                                 CommonService.EncodeString(vjs.FullDescription, false, false, true), // FullDescription - Remove script tags
                                 vjs.BulletPoint1,
                                 vjs.BulletPoint2,
                                 vjs.BulletPoint3,
                                 vjs.ApplicationEmailAddress, // ApplicationEmailAddress
                                 vjs.DatePosted.ToString("dd/MM/yyyy"),
                                 vjs.ExpiryDate.ToString("dd/MM/yyyy"), // ExpiryDate
                                 vjs.SalaryTypeName,
                                 vjs.SalaryText,
                                 vjs.SalaryLowerBand,
                                 vjs.SalaryUpperBand,
                                 vjs.ShowSalaryDetails,
                                 vjs.ApplicationUrl,
                                 vjs.ContactDetails, // ContactDetails
                                 vjs.SiteProfessionName,
                                 vjs.SiteRoleName,
                                 vjs.WorkTypeName,
                                 vjs.LocationName,
                                vjs.AreaName, 
                                (usingssl) ? "https" : "http" + "://" + ((wwwredirect) ? "www." : string.Empty) + siteURL + Utils.GetJobUrl(vjs.JobId, vjs.JobFriendlyName),
                                indeedtext,
                                vjs.JobLatitude.HasValue ? vjs.JobLatitude.Value : 0,
                                vjs.JobLongitude.HasValue ? vjs.JobLongitude.Value : 0,
                                vjs.Address
                            );
        }

        #region  Expired Indeed Code
        /// <summary>
        /// For Indeed
        /// </summary>
        /// <param name="siteURL"></param>
        /// <param name="vjs"></param>
        /// <returns></returns>

        //        private static string WriteIndeedJobXML(string siteURL, ViewJobSearch vjs, AdminIntegrations.Indeed indeedIntegration)
        //        {
        //            // TODO indeed-apply-data
        //            string indeedApplyData = string.Format(@"
        //indeed-apply-onapplied=on_applied_callback&indeed-apply-apitoken={0}&indeed-apply-jobid={1}&indeed-apply-joblocation={2}&indeed-apply-jobcompanyname={3}&indeed-apply-jobtitle={4}&indeed-apply-joburl={5}&indeed-apply-jobmeta=job-meta-button+top&indeed-apply-email=no-reply%40indeed.com
        //", indeedIntegration.APIToken, vjs.JobId, vjs.LocationName, vjs.CompanyName, vjs.JobName, siteURL + Utils.GetJobUrl(vjs.JobId, vjs.JobFriendlyName));

        //            /*
        //<indeed-apply-data>
        //<![CDATA[indeed-apply-onapplied=on_applied_callback
        //&indeed-apply-apitoken=e6a8f4c007b760daab4c769f67362ba86c70884f99ee23e7e851c63cbbe974ab
        //&indeed-apply-jobid=123456&indeed-apply-joblocation=Austin+TX
        //&indeed-apply-jobcompanyname=My+Favorite+Company
        //&indeed-apply-jobtitle=Professional+Basket+Weaver+%28apply+by+email%29
        //&indeed-apply-joburl=http%3A%2F%2Fwww.indeed.com
        //&indeed-apply-jobmeta=job-meta-button+top
        //&indeed-apply-email=no-reply%40indeed.com]]></indeed-apply-data>

        //             */
        //            return string.Format(@"<job>
        //<title><![CDATA[{0}]]></title>
        //<date><![CDATA[{1}]]></date>
        //<referencenumber><![CDATA[{2}]]></referencenumber>
        //<url><![CDATA[{3}]]></url>
        //<company><![CDATA[{4}]]></company>
        //<city><![CDATA[{5}]]></city>
        //<state><![CDATA[{6}]]></state>
        //<country><![CDATA[{7}]]></country>
        //<postalcode></postalcode>
        //<description><![CDATA[{8}]]></description>
        //<salary><![CDATA[{9}]]></salary>
        //<education></education>
        //<jobtype><![CDATA[{10}]]></jobtype>
        //<category><![CDATA[{11}]]></category>
        //<experience></experience>
        //<indeed-apply-data><![CDATA[12]]></indeed-apply-data>
        //</job>",
        //                                 vjs.JobName,
        //                                 vjs.DatePosted.ToString("R"),
        //                                 vjs.RefNo,
        //                                siteURL + Utils.GetJobUrl(vjs.JobId, vjs.JobFriendlyName),
        //                                vjs.CompanyName,
        //                                vjs.AreaName,
        //                                 vjs.LocationName,
        //                                vjs.CountryName,
        //                                 vjs.FullDescription, // FullDescription
        //                                 vjs.SalaryText,
        //                                 vjs.WorkTypeName,
        //                                 vjs.SiteProfessionName,
        //                                 indeedApplyData
        //                                 /*vjs
        //                                 vjs.ApplicationEmailAddress, // ApplicationEmailAddress
        //                                 vjs.JobId,
        //                                 vjs.AdvertiserId,
        //                                 vjs.AdvertiserName,
        //                                 vjs.Description,
        //                                 vjs.BulletPoint1,
        //                                 vjs.BulletPoint2,
        //                                 vjs.BulletPoint3,
        //                                 vjs.ExpiryDate.ToString("dd/MM/yyyy"), // ExpiryDate
        //                                 vjs.SalaryTypeName,

        //                                 vjs.SalaryLowerBand,
        //                                 vjs.SalaryUpperBand,
        //                                 vjs.ShowSalaryDetails,
        //                                 vjs.ApplicationUrl,
        //                                 vjs.ContactDetails, // ContactDetails
        //                                 vjs.SiteRoleName,*/
        //                            );
        //        }
        #endregion

        private static void GenerateWhitelabelXMLList(TList<Sites> _dtWhitelabels)
        {

            try
            {
                StringBuilder strBuilder = new StringBuilder();

                strBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                strBuilder.Append("<WHITELABELS>");

                GlobalSettings globalSetting = new GlobalSettings();

                foreach (Sites drWhiteLabel in _dtWhitelabels)
                {
                    globalSetting = globalSettingsList.Where(g => g.SiteId == drWhiteLabel.SiteId).FirstOrDefault();

                    // Only valid and not mobile sites.
                    if (globalSetting != null && globalSetting.GenerateJobXml)
                    {
                        strBuilder.Append(string.Format("<WHITELABEL SITEURL='{0}'>http://www.jxt.net.au/jobxml/{0}_Jobs.zip</WHITELABEL>", drWhiteLabel.SiteUrl));
                    }
                }
                strBuilder.Append("</WHITELABELS>");

                XmlDocument document = new XmlDocument();

                document.LoadXml(strBuilder.ToString());
                document.Save(ConfigurationManager.AppSettings["JobsExportFolder"] + "\\index.xml");

            }
            catch (Exception ex)
            {
                Console.WriteLine("GenerateWhitelabelXMLList - " + ex.Message);
            }


        }

        private static void SaveXML(object obj)
        {
            try
            {
                XmlSaveType xst = (XmlSaveType)obj;
                xst.XMLDoc.Save(xst.Path);
                Console.WriteLine("Generating {0}...", xst.Path.Replace(".xml", ".zip"));

                using (ZipOutputStream s = new ZipOutputStream(File.Create(xst.Path.Replace(".xml", ".zip"))))
                {
                    s.SetLevel(9);

                    byte[] buffer = new byte[4096];

                    // Using GetFileName makes the result compatible with XP
                    // as the resulting path is not absolute.
                    ZipEntry entry = new ZipEntry(Path.GetFileName(xst.Path));

                    // Setup the entry data as required.

                    // Crc and size are handled by the library for seakable streams
                    // so no need to do them here.

                    // Could also use the last write time or similar for the file.
                    entry.DateTime = DateTime.Now;
                    s.PutNextEntry(entry);

                    using (FileStream fs = File.OpenRead(xst.Path))
                    {

                        // Using a fixed size buffer here makes no noticeable difference for output
                        // but keeps a lid on memory usage.
                        int sourceBytes;
                        do
                        {
                            sourceBytes = fs.Read(buffer, 0, buffer.Length);
                            s.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }
                }

                File.Delete(xst.Path);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}\n{1}", ex.Message, ex.StackTrace);
                //Console.ReadLine();
            }
        }

        internal class XmlSaveType
        {
            public XmlDocument XMLDoc { get; set; }
            public string Path { get; set; }

            public XmlSaveType(XmlDocument xmldoc, string path)
            {
                XMLDoc = xmldoc;
                Path = path;
            }
        }
    }
}
