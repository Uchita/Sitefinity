using log4net;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace JXTPortal.Web.Services.Helpers
{
    /// <summary>
    /// Class contains methods to help handle xml files for the jobs post web service
    /// </summary>
    public static class Utils
    {
        //Loggly resource
        static ILog _logger = LogManager.GetLogger("PostAdsWebService");

        /// <summary>
        ///	Responsible to upload the xml JOB file in the FTP directory.
        /// </summary>
        /// <param name="jobads"><c>System.Xml.XmlDocument</c> job xml document.</param>
        /// <param name="fileName"><c>System.String</c></param>
        /// <remark>Upload xml files to the FTP server.</remark>
        /// <return>It returns whether the upload was successful or not.</return>
        public static bool SendXmlDocumentToFTP(XmlDocument jobads, string fileName)
        {
            //Get configuration from web.config to connect to a FTP server.
            string FTPHost = ConfigurationManager.AppSettings["FTPHost"];
            string FTPUsername = ConfigurationManager.AppSettings["FTPUsername"];
            string FTPPassword = ConfigurationManager.AppSettings["FTPPassword"];
            string RootFolder = ConfigurationManager.AppSettings["RootFolder"];

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(string.Format("{0}/{1}/{2}", FTPHost, RootFolder, fileName));
                request.Credentials = new NetworkCredential(FTPUsername, FTPPassword);
                request.Proxy = null;
                request.KeepAlive = true;

                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UseBinary = true;

                MemoryStream xmlStream = new MemoryStream();
                jobads.Save(xmlStream);
                xmlStream.Position = 0;

                request.ContentLength = xmlStream.Length;

                // Create buffer for file contents
                int buffLength = 16384;
                byte[] buff = new byte[buffLength];

                // Upload this file
                _logger.InfoFormat("Uploading: {0}", fileName);

                using (Stream outstream = request.GetRequestStream())
                {
                    int bytesRead = xmlStream.Read(buff, 0, buffLength);
                    while (bytesRead > 0)
                    {
                        outstream.Write(buff, 0, bytesRead);
                        bytesRead = xmlStream.Read(buff, 0, buffLength);
                    }
                    outstream.Close();
                }

                xmlStream.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();

                _logger.InfoFormat("Finished Uploading: {0}", fileName);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return false;
            }

            return true;
        }

        /// <summary>
        ///	This method create a XML document per client node.
        /// </summary>
        /// <param name="jobads"><c>System.Xml.XmlDocument</c> job xml document.</param>
        /// <param name="clientNode"><c>System.XmlNode</c> client node</param>
        /// <remark>It is use to create separate documents per client.</remark>
        /// <return>It returns the new XML document to be send via FTP.</return>
        public static XmlDocument CreateXmlDocumentPerClient(XmlDocument jobads, XmlNode clientNode)
        {
            try
            {
                //Create a separated document for each client
                XmlDocument doc = new XmlDocument();

                //Remove all children from root
                jobads.SelectSingleNode("JOBXPOSTINGS").RemoveAll();

                //Load the root element
                doc.LoadXml(jobads.SelectSingleNode("JOBXPOSTINGS").OuterXml);

                //Add the current client node to the new docunt
                XmlNode importNewsItem = doc.ImportNode(clientNode, true);
                doc.DocumentElement.AppendChild(importNewsItem);

                return doc;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw ex;
            }
        }

        /// <summary>
        ///	This method generate the default response to each request.
        /// </summary>
        /// <param name="error"><c>System.String</c> error message in case it exists.</param>
        /// <remark>This method creates a default response.</remark>
        /// <return>Return a xml document with the default response.</return>
        public static XmlDocument GenerateResponse(string error)
        {
            StringBuilder response = new StringBuilder();

            response.Append("<UPLOADRESULT ID=\"0\">");
            response.Append("<STARTTIME></STARTTIME>");
            response.Append("<ENDTIME></ENDTIME>");
            response.Append("<UPLOADERRORS>");
            response.AppendFormat("<ERROR>{0}</ERROR>", error);
            response.Append("</UPLOADERRORS>");
            response.Append("<JOBPOSTINGSSUMMARY>");
            response.Append("<SENT></SENT>");
            response.Append("<INSERTED></INSERTED>");
            response.Append("<UPDATED></UPDATED>");
            response.Append("<ARCHIVED></ARCHIVED>");
            response.Append("<FAILED></FAILED>");
            response.Append("<WARNINGS></WARNINGS>");
            response.Append("</JOBPOSTINGSSUMMARY>");
            response.Append("<WARNINGS>");
            response.Append("<WARNING></WARNING>");
            response.Append("</WARNINGS>");
            response.Append("<JOBPOSTINGRESULTS ACTIONTYPE=\"INSERTUPDATE\">");
            response.Append("<JOBPOSTING REFNO=\"0\" ID=\"0\">");
            response.Append("<ACTION>INSERT</ACTION>");
            response.Append("<DATEPOSTED></DATEPOSTED>");
            response.Append("<DATEEXPIRY></DATEEXPIRY>");
            response.Append("<URL></URL>");
            response.Append("</JOBPOSTING>");
            response.Append("</JOBPOSTINGRESULTS>");
            response.Append("<JOBPOSTINGRESULTS ACTIONTYPE=\"ARCHIVED\">");
            response.Append("<JOBPOSTING REFNO=\"0\" ID=\"0\">");
            response.Append("<ACTION>ARCHIVE</ACTION>");
            response.Append("<DATEPOSTED></DATEPOSTED>");
            response.Append("<DATEEXPIRY></DATEEXPIRY>");
            response.Append("</JOBPOSTING>");
            response.Append("</JOBPOSTINGRESULTS>");
            response.Append("<JOBPOSTINGRESULTS ACTIONTYPE=\"FAILED\">");
            response.Append("<JOBPOSTING REFNO=\"0\">");
            response.Append("<ERRORS>");
            response.Append("<ERROR></ERROR>");
            response.Append("</ERRORS>");
            response.Append("</JOBPOSTING>");
            response.Append("</JOBPOSTINGRESULTS>");
            response.Append("</UPLOADRESULT>");

            var xmlresult = new XmlDocument();
            xmlresult.LoadXml(response.ToString());

            return xmlresult;
        }
    }
}