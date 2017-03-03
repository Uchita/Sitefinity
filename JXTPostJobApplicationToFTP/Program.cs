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
            var logger = LogManager.GetLogger(typeof(Program));
            logger.Info("Application Started: JXTPostJobApplicationToFTP");

            var fileUploader = new FileUploader(); 
            IDataLoader dataLoader = new DataLoader(fileUploader);

            var memberIds = dataLoader.GetMemberIds(ConfigurationManager.AppSettings["SitesXML"]);

            logger.InfoFormat("Generating MemberXML for {0} members", memberIds.Count());
            MemberXMLGenerator mxg = new MemberXMLGenerator(fileUploader);
            mxg.GenerateKellyMemberXML(ConfigurationManager.AppSettings["SiteMemberXML"], memberIds);

            logger.Info("Finished generating MemberXML");
        }

        #region Utils
        /// <summary>
        /// Log the Exception and Send an email.
        /// </summary>
        /// <param name="siteXML"></param>
        /// <param name="strLastExceptionApplicationID"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected static void SaveExceptionToSiteXML(SitesXML siteXML, string strLastExceptionApplicationID)
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
        }
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

