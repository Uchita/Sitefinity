using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Xml.Linq;
using System.Data;
using JXTPortal;
using JXTPortal.Entities;
using System.Configuration;
using System.IO;

namespace JXTPostJobApplicationToFTP
{
    public class DataLoader : JXTPostJobApplicationToFTP.IDataLoader
    {
        ILog _logger;
        static IFileUploader _fileUploader;
        public DataLoader(IFileUploader fileUploader)
        {
            _logger = LogManager.GetLogger(typeof(DataLoader));
            _fileUploader = fileUploader;
        }

        public IEnumerable<int> GetMemberIds(string fileName, IEnumerable<int> memberIds)
        {
            var results = new List<int>();
            // Loading from a file, you can also load from a stream
           
            _logger.InfoFormat("Loading from: {0}", fileName);
            var xml = XDocument.Load(fileName);

            // Query the data and write out a subset of contacts
            var siteXMLList = xml.Descendants("site").Select(c => new SitesXML()
            {
                SiteId = (int)c.Element("SiteId"),
                host = (string)c.Element("host"),
                folderPath = (string)c.Element("FolderPath"),
                username = (string)c.Element("username"),
                password = (string)c.Element("password"),
                sftp = (bool)c.Element("sftp"),
                port = (int)c.Element("port"),
                Mode = (string)c.Element("Mode"),
                LastJobApplicationId = (string)c.Element("LastJobApplicationId"),
                LastModifiedDate = (string)c.Element("LastModifiedDate")
            });

            string errorMessage = string.Empty;
            string contents = string.Empty;

            DataTable dt = new DataTable();
            DataSet jobApplicationDS = new DataSet();
            JobApplicationService jobApplicationService = null;

            string strXMLFileName = string.Empty;
            string strResumeFileName = string.Empty;
            string strCoverLetterFileName = string.Empty;

            foreach (SitesXML siteXML in siteXMLList)
            {
                _logger.InfoFormat("Running for SiteID: {0}", siteXML.SiteId);
                jobApplicationService = new JobApplicationService();

                string dateformat = "dd/MM/yyyy";
                using (TList<GlobalSettings> gslist = new GlobalSettingsService().GetBySiteId(siteXML.SiteId))
                {
                    if (gslist.Count > 0)
                    {
                        dateformat = gslist[0].GlobalDateFormat;
                    }
                }

                DataRow[] drValidJobApplication = new DataRow[] { };
                List<DataRow> jobApplications = new List<DataRow>();

                if (siteXML.Mode == "Shortlist")
                {
                    jobApplicationDS = jobApplicationService.CustomGetNewJobApplications(siteXML.SiteId, null, null);

                    dt = jobApplicationDS.Tables[0];

                    if (!string.IsNullOrWhiteSpace(siteXML.LastModifiedDate))
                    {
                        foreach (DataRow jobApplication in dt.Rows)
                        {
                            string lastvieweddate = Convert.ToString(jobApplication["LastViewedDate"]);

                            int? applicationstatus = ((int?)jobApplication["ApplicationStatus"]);

                            if (string.IsNullOrEmpty(lastvieweddate) == false && Convert.ToDateTime(lastvieweddate) > Convert.ToDateTime(siteXML.LastModifiedDate) && applicationstatus.HasValue && applicationstatus.Value == ((int)PortalEnums.JobApplications.ApplicationStatus.ShortList))
                            {
                                jobApplications.Add(jobApplication);
                            }
                        }

                        if (jobApplications.Count > 0)
                        {
                            drValidJobApplication = jobApplications.ToArray();

                            foreach (DataRow jobapplication in drValidJobApplication)
                            {
                                memberIds.Add(Convert.ToInt32(jobapplication["MemberID"].ToString()));
                            }
                        }
                    }
                    else
                    {
                        drValidJobApplication = dt.Select("ApplicationStatus = " + ((int)PortalEnums.JobApplications.ApplicationStatus.ShortList).ToString());
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(siteXML.LastJobApplicationId))
                        jobApplicationDS = jobApplicationService.CustomGetNewJobApplications(siteXML.SiteId, int.Parse(siteXML.LastJobApplicationId), null);
                    else
                        jobApplicationDS = jobApplicationService.CustomGetNewJobApplications(siteXML.SiteId, null, null);

                    dt = jobApplicationDS.Tables[0];

                    drValidJobApplication = dt.Select();
                }

                _logger.InfoFormat("Number of Job Applications: {0}", drValidJobApplication == null ? 0 : drValidJobApplication.Length);

                // If there is an error it will stop at the Job application 
                foreach (DataRow drApplication in drValidJobApplication)
                {
                    try
                    {
                        string applicationId = drApplication["JobApplicationID"].ToString();
                        _logger.InfoFormat("Uploading applicationId {0}", applicationId);

                        List<FileNames> filesToUpload = new List<FileNames>();

                        // If there is a Resume
                        if (drApplication["MemberResumeFile"] != null && !string.IsNullOrWhiteSpace(drApplication["MemberResumeFile"].ToString()))
                        {
                            strResumeFileName = string.Format("{0}_{1}_{2}_{3}_Resume{4}",
                                                                    drApplication["Abbr"].ToString(),
                                                                    drApplication["RefNo"].ToString().Trim(),
                                                                    drApplication["JobID"].ToString(),
                                                                    drApplication["JobApplicationID"].ToString(),
                                                                    Path.GetExtension(ConfigurationManager.AppSettings["ResumeFolder"] + drApplication["MemberResumeFile"].ToString()));

                            filesToUpload.Add(new FileNames(drApplication["JobApplicationID"].ToString(), ConfigurationManager.AppSettings["ResumeFolder"] + drApplication["MemberResumeFile"].ToString(), strResumeFileName));
                        }
                        else
                            strResumeFileName = string.Empty;

                        // If there is a Coverletter
                        if (drApplication["MemberCoverLetterFile"] != null && !string.IsNullOrWhiteSpace(drApplication["MemberCoverLetterFile"].ToString()))
                        {
                            strCoverLetterFileName = string.Format("{0}_{1}_{2}_{3}_Coverletter{4}",
                                                                    drApplication["Abbr"].ToString(),
                                                                    drApplication["RefNo"].ToString().Trim(),
                                                                    drApplication["JobID"].ToString(),
                                                                    drApplication["JobApplicationID"].ToString(),
                                                                    Path.GetExtension(ConfigurationManager.AppSettings["CoverletterFolder"] + drApplication["MemberCoverLetterFile"].ToString()));

                            filesToUpload.Add(new FileNames(drApplication["JobApplicationID"].ToString(), ConfigurationManager.AppSettings["CoverletterFolder"] + drApplication["MemberCoverLetterFile"].ToString(), strCoverLetterFileName));
                        }
                        else
                            strCoverLetterFileName = string.Empty;



                        // Create the XML file
                        strXMLFileName = string.Format("{0}_{1}_{2}_{3}.XML",
                                                    drApplication["Abbr"].ToString(), drApplication["RefNo"].ToString().Trim(),
                                                    drApplication["JobID"].ToString(), drApplication["JobApplicationID"].ToString());

                        contents = string.Format(@"
<application>
    <refno>{8}</refno>
    <applicationid>{0}</applicationid>
    <date>{1}</date>
    <memberid>{11}</memberid>
    <firstname>{2}</firstname>
    <lastname>{3}</lastname>
    <email>{4}</email>
    <mobile>{5}</mobile>
    <classificationid>{9}</classificationid>
    <subclassificationid>{10}</subclassificationid>
    <resume>{6}</resume>
    <coverletter>{7}</coverletter>
</application>
",
    drApplication["JobApplicationID"].ToString(),
    ((DateTime)drApplication["ApplicationDate"]).ToString(dateformat),
    drApplication["FirstName"] != null ? drApplication["FirstName"].ToString() : string.Empty,
    drApplication["Surname"] != null ? drApplication["Surname"].ToString() : string.Empty,
    drApplication["EmailAddress"] != null ? drApplication["EmailAddress"].ToString() : string.Empty,
    drApplication["MobilePhone"] != null ? drApplication["MobilePhone"].ToString().Trim() : string.Empty,
    strResumeFileName,
    strCoverLetterFileName,
    drApplication["RefNo"] != null ? drApplication["RefNo"].ToString().Trim() : string.Empty,
    drApplication["PreferredCategoryID"] != null ? drApplication["PreferredCategoryID"].ToString().Trim() : string.Empty,
    drApplication["PreferredSubCategoryID"] != null ? drApplication["PreferredSubCategoryID"].ToString().Trim() : string.Empty,
    ((int)drApplication["MemberID"]).ToString());


                        System.IO.File.WriteAllText(ConfigurationManager.AppSettings["ApplicationXML"], contents);

                        _logger.InfoFormat("Saved the Application XML file for Application ID: {0}", applicationId);

                        filesToUpload.Add(new FileNames(applicationId, ConfigurationManager.AppSettings["ApplicationXML"], strXMLFileName));

                        // Upload files to FTP / SFTP

                        bool fileUploaded = _fileUploader.UploadFiles(siteXML, filesToUpload);
                        if (!fileUploaded)
                        {
                            _logger.InfoFormat("failed to upload files: {0}", errorMessage);
                            // Exit
                            return results;
                        }

                        _logger.InfoFormat("Successfully uploaded file: ApplicationId = {0}", applicationId);
                        // Update the XML file of the last successful Job application ID
                        UpdateXMLwithJobApplication(siteXML, applicationId);
                        UpdateXMLwithLastModifiedDate(siteXML, drApplication["LastViewedDate"].ToString());
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex);
                    }
                }
            }
            return results;

        }

        /// <summary>
        /// Update the Sites XML file with the last successful Application ID.
        /// </summary>
        /// <param name="siteXML"></param>
        /// <param name="strLastApplicationID"></param>
        private void UpdateXMLwithJobApplication(SitesXML siteXML, string strLastApplicationID)
        {
            string test = string.Empty;

            XDocument xmlFile = XDocument.Load(ConfigurationManager.AppSettings["SitesXML"]);
            var query = from c in xmlFile.Elements("sites").Elements("site")
                        select c;
            foreach (XElement site in query)
            {
                if (site.Element("SiteId").Value == siteXML.SiteId.ToString())
                    site.Element("LastJobApplicationId").Value = strLastApplicationID;
            }

            xmlFile.Save(ConfigurationManager.AppSettings["SitesXML"]);
        }

        private void UpdateXMLwithLastModifiedDate(SitesXML siteXML, string strLastModifiedDate)
        {
            string test = string.Empty;

            XDocument xmlFile = XDocument.Load(ConfigurationManager.AppSettings["SitesXML"]);
            var query = from c in xmlFile.Elements("sites").Elements("site")
                        select c;
            foreach (XElement site in query)
            {
                if (site.Element("SiteId").Value == siteXML.SiteId.ToString())
                    site.Element("LastModifiedDate").Value = strLastModifiedDate;
            }

            xmlFile.Save(ConfigurationManager.AppSettings["SitesXML"]);
        }
    }
}
