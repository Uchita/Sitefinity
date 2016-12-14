using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using JXTPortal.Entities;
using JXTPortal.Data;
using System.Xml.Linq;
using JXTPortal.Common;
using JXTPortal;
using System.Data;
using System.IO;
using System.Net;
using JXTPortal.EmailSender;
using System.Net.Mail;
using System.Net.Configuration;
using System.Diagnostics;
using Tamir.SharpSsh;
using log4net;

namespace JXTPostJobApplicationToFTP
{
    class Program
    {

        static IEnumerable<SitesXML> siteXMLList;

        static void Main(string[] args)
        {
            Console.WriteLine(string.Format("\n[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] ************ Started {0} *****************", DateTime.Now));

            List<int> memberids = null;
            GetLoad(out memberids);

            Console.WriteLine(string.Format("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] ************ Finished {0} *****************\n", DateTime.Now));

            Console.WriteLine(string.Format("\n[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] ************ Started Member {0} *****************", DateTime.Now));
            MemberXMLGenerator mxg = new MemberXMLGenerator();
            mxg.GenerateKellyMemberXML(memberids);

            Console.WriteLine(string.Format("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] ************ Finished Member {0} *****************\n", DateTime.Now));
            Trace.Flush();
            // Todo - comment this
            //Console.ReadLine();

            //SFTPUpload("ksftptst.emeraldfield.com", "jxttst", "rZ3eA6QJHvzR", @"C:\Users\Public\Pictures\Sample Pictures\", "Chrysanthemum.jpg");

        }

        protected static void GetLoad(out List<int> memberIds)
        {
            memberIds = new List<int>();
            // Loading from a file, you can also load from a stream
            var xml = XDocument.Load(ConfigurationManager.AppSettings["SitesXML"]);

            // Query the data and write out a subset of contacts
            siteXMLList = xml.Descendants("site").Select(c => new SitesXML()
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



            bool blnFileUploaded = false;
            string errormessage = string.Empty;
            string strXMLContents = string.Empty;

            string strApplicationID = string.Empty;
            DataTable dt = new DataTable();
            DataSet jobApplicationDS = new DataSet();
            JobApplicationService jobApplicationService = null;

            string strXMLFileName = string.Empty;
            string strResumeFileName = string.Empty;
            string strCoverLetterFileName = string.Empty;

            foreach (SitesXML siteXML in siteXMLList)
            {
                Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Running for SiteID: " + siteXML.SiteId.ToString());

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

                if (dt.Rows != null)
                {
                    Console.WriteLine("Number of Job Applications:" + drValidJobApplication.Length);
                    Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Number of Job Applications: " + drValidJobApplication.Length.ToString());

                }
                else
                {
                    Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Number of Job Applications: None");

                }
                Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] ****************************************************\n");

                // If there is an error it will stop at the Job application 

                foreach (DataRow drApplication in drValidJobApplication)
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

                        strXMLContents = string.Format(@"
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


                        System.IO.File.WriteAllText(ConfigurationManager.AppSettings["ApplicationXML"], strXMLContents);

                        Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Saved the Application XML file for Application ID: " + strApplicationID);


                        filesToUpload.Add(new FileNames(drApplication["JobApplicationID"].ToString(), ConfigurationManager.AppSettings["ApplicationXML"], strXMLFileName));

                        // Upload files to FTP / SFTP
                        if (siteXML.sftp)
                            blnFileUploaded = UploadTempFilesToSFTP(siteXML, filesToUpload, drApplication["JobApplicationID"].ToString(), out errormessage);
                        else
                            blnFileUploaded = UploadTempFilesToFTP(siteXML, filesToUpload, drApplication["JobApplicationID"].ToString(), out errormessage);

                        if (!blnFileUploaded)
                        {
                            Console.WriteLine("******** EXIT APPLICATION *************");
                            // Exit
                            return;
                        }
                        else
                        {
                            Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] File Uploaded: " + drApplication["JobApplicationID"].ToString());
                            // Update the XML file of the last successful Job application ID
                            UpdateXMLwithJobApplication(siteXML, drApplication["JobApplicationID"].ToString());
                            UpdateXMLwithLastModifiedDate(siteXML, drApplication["LastViewedDate"].ToString());
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

        #region FTP

        /// <summary>
        /// Upload xml and applications to FTP.
        /// </summary>
        /// <param name="siteXML"></param>
        /// <param name="filesToUpload"></param>
        /// <param name="JobApplicationID"></param>
        /// <param name="errormessage"></param>
        /// <returns></returns>
        public static bool UploadTempFilesToFTP(SitesXML siteXML, List<FileNames> filesToUpload, string JobApplicationID, out string errormessage)
        {
            errormessage = string.Empty;
            bool blnResult = true;

            FtpWebRequest request = null;
            FileInfo fileInfo = null;
            foreach (FileNames fileNames in filesToUpload)
            {
                try
                {
                    request = (FtpWebRequest)WebRequest.Create(string.Format("{0}/{1}", siteXML.host, fileNames.toFilename));
                    request.Credentials = new NetworkCredential(siteXML.username, siteXML.password);
                    request.Proxy = null;
                    request.KeepAlive = true;

                    //FtpWebRequest request = GetRequest(Path.GetFileName(path));
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.UseBinary = true;

                    fileInfo = new FileInfo(fileNames.fromFilename);
                    request.ContentLength = fileInfo.Length;

                    // Create buffer for file contents
                    int buffLength = 16384;
                    byte[] buff = new byte[buffLength];

                    // Upload this file
                    Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Uploading: " + fileNames.toFilename);


                    using (FileStream instream = fileInfo.OpenRead())
                    {
                        using (Stream outstream = request.GetRequestStream())
                        {
                            int bytesRead = instream.Read(buff, 0, buffLength);
                            while (bytesRead > 0)
                            {
                                outstream.Write(buff, 0, bytesRead);
                                bytesRead = instream.Read(buff, 0, buffLength);
                            }
                            outstream.Close();
                        }
                        instream.Close();
                    }

                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    response.Close();

                    Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Finished Uploading: " + fileNames.toFilename);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] ERROR: " + ex.Message);
                    blnResult = false;
                }

            }


            return blnResult;
        }


        protected static bool UploadTempFilesToSFTP(SitesXML siteXML, List<FileNames> filesToUpload, string JobApplicationID, out string errormessage)
        {
            errormessage = string.Empty;
            bool blnResult = true;
            Sftp sftp = null;
            try
            {

                // Create instance for Sftp to upload given files using given credentials
                sftp = new Sftp(siteXML.host, siteXML.username, siteXML.password);
                //sftp.Port = siteXML.port;

                // Connect Sftp
                sftp.Connect();

                foreach (FileNames fileNames in filesToUpload)
                {

                    if (File.Exists(fileNames.fromFilename))
                    {
                        Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Uploading: " + fileNames.toFilename);


                        // Upload a file
                        sftp.Put(fileNames.fromFilename, (siteXML.folderPath != null ? siteXML.folderPath : string.Empty) + fileNames.toFilename);

                        Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Finished Uploading: " + fileNames.toFilename);
                    }
                    else
                    {
                        Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] File Not Found: " + fileNames.toFilename);

                    }
                    // Close the Sftp connection
                    //sftp.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] ERROR: " + ex.Message);
                blnResult = false;
            }
            finally
            {
                if (sftp != null)
                {
                    // Close the Sftp connection
                    sftp.Close();
                }
            }

            return blnResult;

        }

        #endregion

        /// <summary>
        /// Update the Sites XML file with the last successful Application ID.
        /// </summary>
        /// <param name="siteXML"></param>
        /// <param name="strLastApplicationID"></param>
        protected static void UpdateXMLwithJobApplication(SitesXML siteXML, string strLastApplicationID)
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
        protected static void UpdateXMLwithLastModifiedDate(SitesXML siteXML, string strLastModifiedDate)
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



        #region Utils
        /// <summary>
        /// Log the Exception and Send an email.
        /// </summary>
        /// <param name="siteXML"></param>
        /// <param name="strLastExceptionApplicationID"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected static int SaveExceptionToSiteXML(SitesXML siteXML, string strLastExceptionApplicationID)
        {
            XDocument xmlFile = XDocument.Load(ConfigurationManager.AppSettings["SitesXML"]);
            var query = from c in xmlFile.Elements("sites").Elements("site")
                        select c;
            foreach (XElement site in query)
            {
                // Save the Exception ID and the application which has exception in the XML.
                if (site.Element("SiteId").Value == siteXML.SiteId.ToString())
                {
                    
                    site.Element("LastExceptionApplicationID").Value = strLastExceptionApplicationID;
                }
            }

            xmlFile.Save(ConfigurationManager.AppSettings["SitesXML"]);

        #endregion
    }

    #region Classes

    public class SitesXML
    {
        public int SiteId;
        public string host;
        public string username;
        public string password;
        public bool sftp;
        public int port;
        public string Mode;
        public string folderPath;
        public string LastJobApplicationId;
        public string LastModifiedDate;

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
