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
using log4net;

namespace JXTEnworldGaiaExport
{
    internal class SFTPProcessor
    {
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
    }
}
