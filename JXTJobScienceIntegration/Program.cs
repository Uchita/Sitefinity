using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal;
using JXTPortal.Client.Salesforce;
using System.Net;
using System.Net.Mail;
using System.Xml.Linq;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.Configuration;
using System.Net.Configuration;
using JXTPortal.EmailSender;
using JXTPortal.Entities;
using System.Web;
using System.Web.Script.Serialization;
using log4net;

namespace JXTJobScienceIntegration
{
    // TODO - Check if the job exists before applying for the application.

    class Program
    {
        #region Services
        private static JobApplicationService _jobapplicationService = null;

        private static JobApplicationService JobApplicationService
        {
            get
            {
                if (_jobapplicationService == null)
                {
                    _jobapplicationService = new JobApplicationService();
                }
                return _jobapplicationService;
            }
        }

        private static MembersService _membersService = null;

        private static MembersService MembersService
        {
            get
            {
                if (_membersService == null)
                {
                    _membersService = new MembersService();
                }
                return _membersService;
            }
        }

        private static JobsService _jobsService = null;

        private static JobsService JobsService
        {
            get
            {
                if (_jobsService == null)
                {
                    _jobsService = new JobsService();
                }
                return _jobsService;
            }
        }


        private static ILog _logger;
        #endregion

        static void Main(string[] args)
        {
            _logger = LogManager.GetLogger(typeof(Program));

            //Add 3072 (TLS1.2) for this application
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | (SecurityProtocolType)3072;

            //SalesforceIntegration resumeUpload = new SalesforceIntegration(281);

            //resumeUpload.GetContactList(true);
            //resumeUpload.GetContactFromSalesForce(string.Empty, "003O000000lEymaIAC");

            // For each site which is in Web.config 


            //SalesforceMemberSync memberSync = new SalesforceMemberSync(458); // TODO

            // Get all the application which needs to be sent from last successful application

            // Send all the candidate info including screening questions get the salesforce ID

            // Use the salesforce ID to send the job application - get the application id

            // Use the application id to save the attachments.


            _logger.Info("Started");

            SendJobApplicationsToSalesForce();

            _logger.Info("end");

            Trace.Flush();
        }

        private static bool JobApplicationSyncWithSalesForce(int jxtJobApplicationID, List<FileNames> filesToUpload)
        {
            _logger.InfoFormat("Syncing application {0}, with {1}files", jxtJobApplicationID, filesToUpload.Count);

            JobApplication thisApplication;
            Members thisMember;
            string strReferenceNumber = string.Empty;
            
            #region Data Retrieval
            thisApplication = JobApplicationService.GetByJobApplicationId(jxtJobApplicationID);
            if (thisApplication == null)
            {
                //error
                _logger.Warn("Job Application record could not be found");
                return false;
            }

            // Get the reference number from the jobs or job archive table
            if (thisApplication.JobId.HasValue)
            {
                using (Jobs thisJob = JobsService.GetByJobId(thisApplication.JobId.Value))
                {
                    if (thisJob != null)
                    {
                        strReferenceNumber = thisJob.RefNo;
                    }
                }
            }
            else
            {
                JobsArchiveService JobsArchiveService = new JXTPortal.JobsArchiveService();

                using (JobsArchive thisJobArchive = JobsArchiveService.GetByJobId(thisApplication.JobArchiveId.Value))
                {
                    if (thisJobArchive != null)
                    {
                        strReferenceNumber = thisJobArchive.RefNo;
                    }
                }
            }

            if (string.IsNullOrEmpty(strReferenceNumber))
            {
                //error
                _logger.Warn("Job record could not be found or Job record has no Reference No.");
                return false;
            }

            thisMember = MembersService.GetByMemberId(thisApplication.MemberId.Value);

            if (thisMember == null)
            {
                //error
                _logger.WarnFormat("Member record could not be found");
                return false;
            }

            #endregion

            #region IMPORTANT - ENWORLD - CHECK if they should not be synced to Jobscience

            if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["EnworldSiteID"]) &&
                thisMember.ReferringSiteId.HasValue && !(ConfigurationManager.AppSettings["EnworldSiteID"].Contains(" " + thisMember.ReferringSiteId.Value + " ")))
            {
                _logger.InfoFormat("SKIP Application and Member Sync - Member is from SiteID - ", thisMember.ReferringSiteId.Value);
                return true;
            }

            #endregion
            
            string SFContactID;
            SalesforceMemberSync memberSync = new SalesforceMemberSync(thisMember.SiteId);
            //Calling this will ensure the member's record will be available on the SalesForce, true flag denotes no check on member's account is validated or not
            bool contactSyncSuccess = memberSync.CheckContactAndSaveInSalesForce(thisMember, thisMember.SiteId, true, out SFContactID);
            
            if (contactSyncSuccess && !string.IsNullOrEmpty(SFContactID))
            {
                SalesforceIntegration sfInt = new SalesforceIntegration(thisMember.SiteId);

                #region Check Application Exists
                {
                    //check if the application exist
                    string query = "SELECT ID FROM ts2__Application__c WHERE ts2__Candidate_Contact__c='" + SFContactID + "' AND ts2__Job__c='" + strReferenceNumber + "'";
                    _logger.DebugFormat("Checking Salesforce for application: {0}", query);

                    try
                    {
                        string qResult = sfInt.EntityGet(HttpUtility.UrlEncode(query));

                        if (!string.IsNullOrEmpty(qResult))
                        {
                            JavaScriptSerializer serializer = new JavaScriptSerializer();
                            dynamic json = serializer.Deserialize(qResult, typeof(object)) as dynamic;

                            if (json["totalSize"] > 0)
                            {
                                _logger.Info("Application already exists.");
                                return true;
                            }
                        }
                        else
                        {
                            _logger.Warn("Failed to request for application existence.");
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex);
                        if (ex.Message.Contains("invalid ID field"))
                        {   
                            //continue to process the next application
                            return true;
                        }
                        else
                            throw ex;
                    }
                }
                #endregion

                #region Upload Attachement to SF
                {
                    //upload attachement
                    bool attachmentUploaded = false;
                    foreach (FileNames fileNames in filesToUpload)
                    {
                        _logger.InfoFormat("Attempting to upload file {0}", fileNames.fromFilename);
                        string filePath = fileNames.fromFilename;

                        // Check if the file exists
                        if (File.Exists(filePath))
                        {
                            // ENWORLD - condition - that when the PROFILE option is selected NOT to send to JS.
                            if (!filePath.Contains("_Resume_Profile_"))
                            {
                                if (!string.IsNullOrEmpty(filePath))
                                {
                                    byte[] fileByte = File.ReadAllBytes(filePath);

                                    if (fileByte != null)
                                    {
                                        String file64String = Convert.ToBase64String(fileByte);
                                        string jsonString = @"{ ""ContactId"" : """ + SFContactID + @""", ""Name"" : """ + fileNames.toFilename + @""", ""ContentType"":""application/octet-stream"", ""Body"": """ + file64String + @""" }";
                                        string entityID, error;
                                        bool uploadFileSuccess = sfInt.EntityPost("ParseResume", jsonString, out entityID, out error);
                                        if (uploadFileSuccess)
                                        {
                                            attachmentUploaded = true;
                                           _logger.DebugFormat("Attachment: ", entityID);
                                        }
                                        else
                                        {
                                            _logger.ErrorFormat("File Upload Failed: {0} - {1}", fileNames.toFilename, error);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                _logger.InfoFormat("Member used PROFILE ignoring to upload file: ", fileNames.toFilename);
                            }
                        }
                        else
                        {
                            _logger.ErrorFormat("File Not Found: {0}", fileNames.toFilename);
                        }
                    }

                    if (!attachmentUploaded)
                        _logger.Info("No attachment");
                }
                #endregion

                #region Create Application Record in SF
                {
                    //create application
                    string jsonString = @"{ ""ts2__Candidate_Contact__c"" : """ + SFContactID + @""", ""ts2__Job__c"" : """ + strReferenceNumber + @"""}";
                    string SFApplicationID, errorMsg;
                    bool postSuccess = sfInt.EntityPost("ts2__Application__c", jsonString, out SFApplicationID, out errorMsg);
                    if (postSuccess)
                    {
                        _logger.InfoFormat("Application created successfully: ", SFApplicationID);
                        return true;
                    }
                    else
                    {
                        _logger.WarnFormat("Failed to create application. - ",errorMsg);
                        return false;
                    }
                }
                #endregion
            }
            else
            {
                _logger.Warn("Failed to perform Member Sync.");
                return false;
            }

        }

        protected static void SendJobApplicationsToSalesForce()
        {
            // Loading from a file, you can also load from a stream
            var xml = XDocument.Load(ConfigurationManager.AppSettings["SitesXML"]);

            // Query the data and write out a subset of contacts
            var siteXMLList = xml.Descendants("site").Select(c => new SitesXML()
            {
                SiteId = (int)c.Element("SiteId"),
                LastJobApplicationId = (string)c.Element("LastJobApplicationId")
            }).ToList();

            foreach (SitesXML thisSite in siteXMLList)
            {
                ProcessSite(thisSite);
            }
        }

        private static void ProcessSite(SitesXML siteXML)
        {
            _logger.InfoFormat("Running for SiteID: {0}", siteXML.SiteId);

            JobApplicationService jobApplicationService = new JobApplicationService();

            DataSet jobApplicationDS = null;
            if (!string.IsNullOrWhiteSpace(siteXML.LastJobApplicationId))
                jobApplicationDS = jobApplicationService.CustomGetNewJobApplications(siteXML.SiteId, int.Parse(siteXML.LastJobApplicationId), null);
            else
                jobApplicationDS = jobApplicationService.CustomGetNewJobApplications(siteXML.SiteId, null, null);

            DataTable dt = jobApplicationDS.Tables[0];
            
            if (dt.Rows != null)
            {
                _logger.InfoFormat("Number of Job Applications: {0}", dt.Rows.Count);
                
                // If there is an error it will stop at the Job application 
                foreach (DataRow drApplication in dt.Rows)
                {
                    string applicationID = drApplication["JobApplicationID"].ToString();
                    _logger.DebugFormat("Application ID about to be uploaded: {0}", applicationID);

                    List<FileNames> filesToUpload = new List<FileNames>();
                    string resumeFileName = string.Empty;

                    try
                    {
                        // If there is a Resume
                        if (drApplication["MemberResumeFile"] != null && !string.IsNullOrWhiteSpace(drApplication["MemberResumeFile"].ToString()))
                        {
                            resumeFileName = string.Format("{0}_{1}_{2}_{3}_Resume{4}",
                                                                    drApplication["Abbr"].ToString(),
                                                                    drApplication["RefNo"].ToString().Trim(),
                                                                    drApplication["JobID"].ToString(),
                                                                    drApplication["JobApplicationID"].ToString(),
                                                                    Path.GetExtension(ConfigurationManager.AppSettings["ResumeFolder"] + drApplication["MemberResumeFile"].ToString()));

                            filesToUpload.Add(new FileNames(drApplication["JobApplicationID"].ToString(), ConfigurationManager.AppSettings["ResumeFolder"] + drApplication["MemberResumeFile"].ToString(), resumeFileName));
                        }

                        // Upload files to FTP / SFTP
                        string errorMessage;
                        var blnContinue = SyncToSalesForce(siteXML, filesToUpload, drApplication["JobApplicationID"].ToString(), out errorMessage);

                        if (!blnContinue)
                        {
                            _logger.Info("Finished");
                            return;
                        }
                        else
                        {
                            _logger.InfoFormat("Application Completed: {0}", drApplication["JobApplicationID"]);
                            // Update the XML file of the last successful Job application ID
                            UpdateXMLwithJobApplication(siteXML, drApplication["JobApplicationID"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex);
                    }
                }
            }
            else
            {
                _logger.InfoFormat("Number of Job Applications: NONE");
            }
        }

        protected static bool SyncToSalesForce(SitesXML siteXML, List<FileNames> filesToUpload, string JobApplicationID, out string errormessage)
        {
            errormessage = string.Empty;
            bool continueToNextApplication = true;

            try
            {
                _logger.InfoFormat("Sending Application: {0}", JobApplicationID);

                // Upload a file
                int jobApplicationIDInt = int.Parse(JobApplicationID);
                continueToNextApplication = JobApplicationSyncWithSalesForce(jobApplicationIDInt, filesToUpload);

                _logger.InfoFormat("Send Completed: ", JobApplicationID);

            }
            catch (Exception ex)
            {
                continueToNextApplication = false;
                _logger.Error(ex);
            }

            return continueToNextApplication;
        }

        protected static void UpdateXMLwithJobApplication(SitesXML siteXML, string strLastApplicationID)
        {
            XDocument xmlFile = XDocument.Load(ConfigurationManager.AppSettings["SitesXML"]);
            var query = from c in xmlFile.Elements("sites").ElementAt(0).Elements("site") select c;
            foreach (XElement site in query)
            {
                if (site.Element("SiteId").Value == siteXML.SiteId.ToString())
                    site.Element("LastJobApplicationId").Value = strLastApplicationID;
            }

            xmlFile.Save(ConfigurationManager.AppSettings["SitesXML"]);
        }
    }

    #region Classes

    public class SitesXML
    {
        public int SiteId;
        public string LastJobApplicationId;
        public string LastExceptionApplicationID;
        public string ExceptionID;
    }

    public class FileNames
    {
        public string Id;
        public string fromFilename;
        public string toFilename;

        public FileNames(string _id, string _fromFilenames, string _toFilename)
        {
            Id = _id;
            fromFilename = _fromFilenames;
            toFilename = _toFilename;
        }
    }

    #endregion

}
