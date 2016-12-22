﻿using System;
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

        #endregion

        static IEnumerable<SitesXML> siteXMLList;

        static void Main(string[] args)
        {

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


            Console.WriteLine(string.Format("\n[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] ************ Started {0} *****************", DateTime.Now));

            SendJobApplicationsToSalesForce();

            Console.WriteLine(string.Format("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] ************ Finished {0} *****************\n", DateTime.Now));

            Trace.Flush();

            // Todo - comment this
            //Console.ReadLine();

            //SFTPUpload("ksftptst.emeraldfield.com", "jxttst", "rZ3eA6QJHvzR", @"C:\Users\Public\Pictures\Sample Pictures\", "Chrysanthemum.jpg");

        }

        private static bool JobApplicationSyncWithSalesForce(int jxtJobApplicationID, List<FileNames> filesToUpload)
        {
            JobApplication thisApplication;
            Members thisMember;
            string strReferenceNumber = string.Empty;


            #region Data Retrieval
            thisApplication = JobApplicationService.GetByJobApplicationId(jxtJobApplicationID);
            if (thisApplication == null)
            {
                //error
                Console.WriteLine("Job Application record could not be found");
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
                Console.WriteLine("Job record could not be found or Job record has no Reference No.");
                return false;
            }

            thisMember = MembersService.GetByMemberId(thisApplication.MemberId.Value);

            if (thisMember == null)
            {
                //error
                Console.WriteLine("Member record could not be found");
                return false;
            }

            #endregion

            #region IMPORTANT - ENWORLD - CHECK if they should not be synced to Jobscience

            if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["EnworldSiteID"]) &&
                thisMember.ReferringSiteId.HasValue && !(ConfigurationManager.AppSettings["EnworldSiteID"].Contains(" " + thisMember.ReferringSiteId.Value + " ")))
            {
                Console.WriteLine("SKIP Application and Member Sync - Member is from SiteID - " + thisMember.ReferringSiteId.Value);
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
                    Console.WriteLine(query);

                    try
                    {
                        string qResult = sfInt.EntityGet(HttpUtility.UrlEncode(query));

                        if (!string.IsNullOrEmpty(qResult))
                        {
                            JavaScriptSerializer serializer = new JavaScriptSerializer();
                            dynamic json = serializer.Deserialize(qResult, typeof(object)) as dynamic;

                            if (json["totalSize"] > 0)
                            {
                                Console.WriteLine("Application already exists.");
                                return true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Failed to request for application existence.");
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("invalid ID field"))
                        {
                            Console.WriteLine("Invalid ID found for application: " + ex.Message);
                            Console.WriteLine("Sending Email...");
                            //sends email to notify invalid ID
                            string emailBody = String.Format("Site ID: {0}<br/>Job Application ID: {1}<br/>Query: {2}<br/>Error: {3}", thisMember.SiteId, thisApplication.JobApplicationId, query, ex.Message);
                            MailService.Send("naveen@jxt.com.au", "naveen@jxt.com.au", "Application Skipped due to invalid ID Field", emailBody);
                            Console.WriteLine("Email sent, continue to next application");
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
                        string filePath = fileNames.fromFilename;

                        // Check if the file exists
                        if (File.Exists(filePath))
                        {
                            // ENWORLD - condition - that when the PROFILE option is selected NOT to send to JS.
                            if (!filePath.Contains("_Resume_Profile_"))
                            {
                                Console.WriteLine("File to be uploaded: " + filePath);
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
                                            Console.WriteLine("Attachment: " + entityID);
                                        }
                                        else
                                        {
                                            Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] File Upload Failed: " + fileNames.toFilename + " - " + error);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Member used PROFILE ignoring to upload file: " + fileNames.toFilename);
                            }

                        }
                        else
                        {
                            Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] File Not Found: " + fileNames.toFilename);
                        }
                    }

                    if (!attachmentUploaded)
                        Console.WriteLine("No attachment");
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
                        Console.WriteLine("Application created successfully: " + SFApplicationID);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Failed to create application. - " + errorMsg);
                        return false;
                    }
                }
                #endregion
            }
            else
            {
                Console.WriteLine("Failed to perform Member Sync.");
                return false;
            }

        }

        protected static void SendJobApplicationsToSalesForce()
        {
            // Loading from a file, you can also load from a stream
            var xml = XDocument.Load(ConfigurationManager.AppSettings["SitesXML"]);

            // Query the data and write out a subset of contacts
            siteXMLList = xml.Descendants("site").Select(c => new SitesXML()
            {
                SiteId = (int)c.Element("SiteId"),
                LastJobApplicationId = (string)c.Element("LastJobApplicationId")
            });



            bool blnContinue = true;
            string errormessage = string.Empty;
            string strXMLContents = string.Empty;

            string strApplicationID = string.Empty;
            DataTable dt = new DataTable();
            DataSet jobApplicationDS = new DataSet();
            JobApplicationService jobApplicationService = null;


            string strResumeFileName = string.Empty;
            string strCoverLetterFileName = string.Empty;

            foreach (SitesXML siteXML in siteXMLList)
            {
                Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Running for SiteID: " + siteXML.SiteId.ToString());

                jobApplicationService = new JobApplicationService();


                if (!string.IsNullOrWhiteSpace(siteXML.LastJobApplicationId))
                    jobApplicationDS = jobApplicationService.CustomGetNewJobApplications(siteXML.SiteId, int.Parse(siteXML.LastJobApplicationId), null);
                else
                    jobApplicationDS = jobApplicationService.CustomGetNewJobApplications(siteXML.SiteId, null, null);

                dt = jobApplicationDS.Tables[0];

                if (dt.Rows != null)
                {
                    Console.WriteLine("Number of Job Applications:" + dt.Rows.Count);
                    Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Number of Job Applications: " + dt.Rows.Count.ToString());

                }
                else
                {
                    Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Number of Job Applications: None");

                }
                Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] ****************************************************\n");

                // If there is an error it will stop at the Job application 

                foreach (DataRow drApplication in dt.Rows)
                {
                    try
                    {
                        strApplicationID = drApplication["JobApplicationID"].ToString();
                        Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Application ID about to be uploaded:" + strApplicationID);


                        //string filename = "CountryCode_KellyJobReferenceNumber_JXTJobID_JXTJobApplicationID_Resume.Extension";

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

                        //// If there is a Coverletter
                        //if (drApplication["MemberCoverLetterFile"] != null && !string.IsNullOrWhiteSpace(drApplication["MemberCoverLetterFile"].ToString()))
                        //{
                        //    strCoverLetterFileName = string.Format("{0}_{1}_{2}_{3}_Coverletter{4}",
                        //                                            drApplication["Abbr"].ToString(),
                        //                                            drApplication["RefNo"].ToString().Trim(),
                        //                                            drApplication["JobID"].ToString(),
                        //                                            drApplication["JobApplicationID"].ToString(),
                        //                                            Path.GetExtension(ConfigurationManager.AppSettings["CoverletterFolder"] + drApplication["MemberCoverLetterFile"].ToString()));

                        //    filesToUpload.Add(new FileNames(drApplication["JobApplicationID"].ToString(), ConfigurationManager.AppSettings["CoverletterFolder"] + drApplication["MemberCoverLetterFile"].ToString(), strCoverLetterFileName));
                        //}
                        //else
                        //    strCoverLetterFileName = string.Empty;


                        //                        strXMLContents = string.Format(@"
                        //<application>
                        //    <refno>{8}</refno>
                        //    <applicationid>{0}</applicationid>
                        //    <date>{1}</date>
                        //    <firstname>{2}</firstname>
                        //    <lastname>{3}</lastname>
                        //    <email>{4}</email>
                        //    <mobile>{5}</mobile>
                        //    <classificationid>{9}</classificationid>
                        //    <subclassificationid>{10}</subclassificationid>
                        //    <resume>{6}</resume>
                        //    <coverletter>{7}</coverletter>
                        //</application>
                        //",
                        //    drApplication["JobApplicationID"].ToString(),
                        //    drApplication["ApplicationDate"].ToString(),
                        //    drApplication["FirstName"] != null ? drApplication["FirstName"].ToString() : string.Empty,
                        //    drApplication["Surname"] != null ? drApplication["Surname"].ToString() : string.Empty,
                        //    drApplication["EmailAddress"] != null ? drApplication["EmailAddress"].ToString() : string.Empty,
                        //    drApplication["MobilePhone"] != null ? drApplication["MobilePhone"].ToString().Trim() : string.Empty,
                        //    strResumeFileName,
                        //    strCoverLetterFileName,
                        //    drApplication["RefNo"] != null ? drApplication["RefNo"].ToString().Trim() : string.Empty,
                        //    drApplication["PreferredCategoryID"] != null ? drApplication["PreferredCategoryID"].ToString().Trim() : string.Empty,
                        //    drApplication["PreferredSubCategoryID"] != null ? drApplication["PreferredSubCategoryID"].ToString().Trim() : string.Empty);


                        //System.IO.File.WriteAllText(ConfigurationManager.AppSettings["ApplicationXML"], strXMLContents);

                        //Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Saved the Application XML file for Application ID: " + strApplicationID);

                        // Upload files to FTP / SFTP
                        blnContinue = SyncToSalesForce(siteXML, filesToUpload, drApplication["JobApplicationID"].ToString(), out errormessage);


                        if (!blnContinue)
                        {
                            Console.WriteLine("******** EXIT APPLICATION *************");
                            // Exit
                            return;
                        }
                        else
                        {
                            Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Application Completed: " + drApplication["JobApplicationID"].ToString());
                            // Update the XML file of the last successful Job application ID
                            UpdateXMLwithJobApplication(siteXML, drApplication["JobApplicationID"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        ILog logger = LogManager.GetLogger(typeof(Program));
                        logger.Error(ex);
                    }
                }
            }

        }

        protected static bool SyncToSalesForce(SitesXML siteXML, List<FileNames> filesToUpload, string JobApplicationID, out string errormessage)
        {
            errormessage = string.Empty;
            bool continueToNextApplication = true;

            try
            {
                Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Sending Application: " + JobApplicationID);

                // Upload a file
                int jobApplicationIDInt = int.Parse(JobApplicationID);
                continueToNextApplication = JobApplicationSyncWithSalesForce(jobApplicationIDInt, filesToUpload);

                Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Send Completed: " + JobApplicationID);

            }
            catch (Exception ex)
            {
                continueToNextApplication = false;
                ILog logger = LogManager.GetLogger(typeof(Program));
                logger.Error(ex);
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
