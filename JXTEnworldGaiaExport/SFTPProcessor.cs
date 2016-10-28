using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data;
using System.IO;
using Tamir.SharpSsh;
using System.Configuration;
using JXTPortal.EmailSender;
using System.Net.Configuration;
using JXTPortal;
using System.Net.Mail;

namespace JXTEnworldGaiaExport
{
    internal class SFTPProcessor
    {
        #region FTP

        internal static bool UploadJsonFilesToSFTP(FTPDetails ftpDetails, List<UploadTracker> trackers, string ftpTargetPathBase)
        {
            string targetPath = ConfigurationManager.AppSettings["FileTempPath"];

            //string[] fileNames = Directory.GetFiles(targetPath);

            bool blnResult = true;
            Sftp sftp = null;
            try
            {
                // Create instance for Sftp to upload given files using given credentials
                sftp = new Sftp(ftpDetails.host, ftpDetails.username, ftpDetails.password);
                //sftp.Port = siteXML.port;

                // Connect Sftp
                sftp.Connect();

                foreach (UploadTracker thisTracker in trackers.OrderBy(c => c.itemID))
                {
                    string thisFileName = thisTracker.fileName;
                    string sourcePath = thisTracker.filePath + thisTracker.fileName;
                    string ftpTargetPath = ftpTargetPathBase + "/" + thisFileName;

                    Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Uploading File: " + sourcePath);

                    // Upload a file
                    sftp.Put(sourcePath, ftpTargetPath);

                    //Remove Temp file
                    File.Delete(sourcePath);

                    //assign last successfully completed memberID
                    thisTracker.processed = true;

                    Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Uploading File: " + sourcePath + " Completed");
                }
                // Close the Sftp connection
                sftp.Close();
                blnResult = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] ERROR: " + ex.Message);
                blnResult = false;
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
            var query = from c in xmlFile.Elements(test).Elements(test)
                        select c;
            foreach (XElement site in query)
            {
                if (site.Element("SiteId").Value == siteXML.SiteId.ToString())
                    site.Element("LastJobApplicationId").Value = strLastApplicationID;
            }

            xmlFile.Save(ConfigurationManager.AppSettings["SitesXML"]);
        }


        #region Utils

        /// <summary>
        /// Email Sender
        /// </summary>
        /// <returns></returns>
        private static SmtpSender EmailSender()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            MailSettingsSectionGroup mailConfiguration = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

            SmtpSender mailObject = new SmtpSender(mailConfiguration.Smtp.Network.Host);

            mailObject.Port = mailConfiguration.Smtp.Network.Port;
            if (!mailConfiguration.Smtp.Network.DefaultCredentials)
            {
                mailObject.UserName = mailConfiguration.Smtp.Network.UserName;
                mailObject.Password = mailConfiguration.Smtp.Network.Password;
            }

            return mailObject;
        }

        /// <summary>
        /// Log the Exception and Send an email.
        /// </summary>
        /// <param name="siteXML"></param>
        /// <param name="strLastExceptionApplicationID"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected static int LogExceptionAndEmail(SitesXML siteXML, string strLastExceptionApplicationID, Exception ex)
        {
            ExceptionTableService serviceException = new ExceptionTableService();

            int intExceptionID = serviceException.LogException(ex.GetBaseException());

            XDocument xmlFile = XDocument.Load(ConfigurationManager.AppSettings["SitesXML"]);
            var query = from c in xmlFile.Elements("sites").Elements("site")
                        select c;
            foreach (XElement site in query)
            {
                // Save the Exception ID and the application which has exception in the XML.
                if (site.Element("SiteId").Value == siteXML.SiteId.ToString())
                {
                    site.Element("ExceptionID").Value = intExceptionID.ToString();
                    site.Element("LastExceptionApplicationID").Value = strLastExceptionApplicationID;
                }
            }

            xmlFile.Save(ConfigurationManager.AppSettings["SitesXML"]);


            // **** Send email when there is an error.
            Message message = new Message();
            message.Format = Format.Html;

            message.Body = string.Format(@"
SiteId: {0}<br /><br />
ApplicationID: {1}<br /><br />
DateTime: {2}<br /><br />
Message: {3}<br /><br />
StackTrace: {4}<br /><br />
ExceptionID: {5}",
                    siteXML.SiteId,
                    strLastExceptionApplicationID,
                    DateTime.Now,
                    ex.Message,
                    ex.StackTrace,
                    intExceptionID);

            message.From = new MailAddress("bugs@jxt.com.au", "MiniJXT Support");
            message.To = new MailAddress(ConfigurationManager.AppSettings["AdminEmail"]);
            message.Subject = "MiniJXT - Job application FTP Error";

            EmailSender().Send(message);

            return intExceptionID;
        }

        #endregion
    }


}
