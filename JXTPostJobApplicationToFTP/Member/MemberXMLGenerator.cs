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
using Tamir.SharpSsh;
using System.Diagnostics;

namespace JXTPostJobApplicationToFTP
{
    public class MemberXMLGenerator
    {


        private GlobalSettingsService _GlobalSettingsService = null;
        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_GlobalSettingsService == null)
                {
                    _GlobalSettingsService = new GlobalSettingsService();
                }
                return _GlobalSettingsService;
            }
        }


        private CountriesService _countriesService = null;
        private CountriesService CountriesService
        {
            get
            {
                if (_countriesService == null)
                {
                    _countriesService = new CountriesService();
                }
                return _countriesService;
            }
        }


        public MemberXMLGenerator()
        {
        }

        public void GenerateKellyMemberXML()
        {
            IEnumerable<SitesXML> siteXMLList;
            MembersService memberservice = new MembersService();
            MemberFilesService memberfilesservice = new MemberFilesService();
            MemberFiles memberfile = null;
            DataSet ds = null;
            DataTable dtMembers = null;
            DataTable dtMemberFiles = null;
            bool blnFileUploaded = false;
            StringBuilder memberxml = new StringBuilder();
            StringBuilder membercoverletterxml = new StringBuilder();
            StringBuilder memberresumexml = new StringBuilder();
            List<FileNames> fileslist = new List<FileNames>();
            string memberfilepath = string.Empty;
            DataRow currentMember = null;

            var xml = XDocument.Load(ConfigurationManager.AppSettings["SiteMemberXML"]);

            // Query the data and write out a subset of contacts
            siteXMLList = xml.Descendants("site").Select(c => new SitesXML()
            {
                SiteId = (int)c.Element("SiteId"),
                host = (string)c.Element("host"),
                username = (string)c.Element("username"),
                password = (string)c.Element("password"),
                sftp = (bool)c.Element("sftp"),
                port = (int)c.Element("port"),
                Mode = (string)c.Element("Mode"),
                LastJobApplicationId = (string)c.Element("LastModifiedDate")            // Job application id used for getting the last modified date
            });

            foreach (SitesXML sitexml in siteXMLList)
            {

                if (string.IsNullOrWhiteSpace(sitexml.Mode))
                {
                    try
                    {
                        DateTime lastRun = (string.IsNullOrEmpty(sitexml.LastJobApplicationId) ? new DateTime(2012, 1, 1) : Convert.ToDateTime(sitexml.LastJobApplicationId));
                        fileslist = new List<FileNames>();
                        ds = memberservice.CustomGetNewValidMembers(sitexml.SiteId, lastRun);
                        dtMembers = ds.Tables[0];
                        dtMemberFiles = ds.Tables[1];

                        // Get the default country from the Site Global settings
                        string strSiteDefaultCountryCode = string.Empty;

                        // Get the Site URL 
                        SitesService sitesService = new SitesService();
                        string strDomainName = sitesService.GetBySiteId(sitexml.SiteId).SiteUrl;

                        using (TList<GlobalSettings> gslist = GlobalSettingsService.GetBySiteId(sitexml.SiteId))
                        {
                            if (gslist.Count > 0)
                            {
                                if (gslist[0].DefaultCountryId.HasValue)
                                {
                                    using (Countries countries = CountriesService.GetByCountryId(gslist[0].DefaultCountryId.Value))
                                    {
                                        // Get the default site country code
                                        if (countries != null)
                                            strSiteDefaultCountryCode = countries.Abbr;
                                    }
                                }
                            }
                        }

                        DataRow[] drValidatedMembers = null;

                        if (sitexml.Mode == "FullCandidate")
                        {
                            drValidatedMembers = dtMembers.Select("ISNULL(Title, '') <> '' AND ISNULL(FirstName, '') <> '' AND ISNULL(Surname, '') <> '' AND ISNULL(EmailAddress, '') <> '' AND ISNULL(HomePhone, '') <> '' AND ISNULL(Address1, '') <> ''");
                        }
                        else
                        {
                            drValidatedMembers = dtMembers.Select();
                        }

                        Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Number of Members: " + drValidatedMembers.Count().ToString());

                        // For each member
                        foreach (DataRow drMember in drValidatedMembers)
                        {
                            memberxml = new StringBuilder();
                            membercoverletterxml = new StringBuilder();
                            memberresumexml = new StringBuilder();
                            currentMember = drMember;

                            // Get the member XML
                            memberxml.AppendFormat(@"
<member>
    <domain>{24}</domain>
    <memberid>{0}</memberid>
    <username>{1}</username>
    <title>{2}</title>
    <firstname>{3}</firstname>
    <lastname>{4}</lastname>
    <emailaddress>{5}</emailaddress>
    <homephone>{6}</homephone>
    <workphone>{7}</workphone>
    <mobilephone>{8}</mobilephone>
    <address1><![CDATA[{9}]]></address1>
    <postcode>{10}</postcode>
    <suburb>{11}</suburb>
    <states>{12}</states>
    <emailformat>{13}</emailformat>
    <dateofbirth>{14}</dateofbirth>
    <gender>{15}</gender>
    <fax>{16}</fax>
    <countryid>{17}</countryid>
    <tags><![CDATA[{18}]]></tags>
    <lastmodifieddate>{19}</lastmodifieddate>
    <subscribed>{20}</subscribed>
    <passportno>{21}</passportno>
    <classificationid>{22}</classificationid>
    <subclassificationid>{23}</subclassificationid>
                                                ",
                                                            drMember["MemberID"].ToString().Trim(),
                                                            drMember["Username"].ToString().Trim(),
                                                            drMember["Title"].ToString().Trim(),
                                                            drMember["FirstName"].ToString().Trim(),
                                                            drMember["Surname"].ToString().Trim(),
                                                            drMember["EmailAddress"].ToString().Trim(),
                                                            drMember["HomePhone"].ToString().Trim(),
                                                            drMember["WorkPhone"].ToString().Trim(),
                                                            drMember["MobilePhone"].ToString().Trim(),
                                                            drMember["Address1"].ToString().Trim(),
                                                            drMember["PostCode"].ToString().Trim(),
                                                            drMember["Suburb"].ToString().Trim(),
                                                            drMember["States"].ToString().Trim(),
                                                            (string.IsNullOrEmpty(drMember["EmailFormat"].ToString().Trim())) ? string.Empty : ((PortalEnums.Email.EmailFormat)Convert.ToInt32(drMember["EmailFormat"])).ToString(),
                                                            drMember["DateOfBirth"].ToString().Trim(),
                                                            drMember["Gender"].ToString().Trim(),
                                                            drMember["Fax"].ToString().Trim(),
                                                            drMember["CountryID"].ToString().Trim(),
                                                            drMember["Tags"].ToString().Trim(),
                                                            drMember["LastModifiedDate"].ToString().Trim(),
                                                            drMember["Subscribed"].ToString().Trim(),
                                                            drMember["PassportNo"].ToString().Trim(),
                                                            (string.IsNullOrEmpty(drMember["PreferredCategoryID"].ToString().Trim())) ? string.Empty : drMember["PreferredCategoryID"].ToString().Trim(),
                                                            (string.IsNullOrEmpty(drMember["PreferredSubCategoryID"].ToString().Trim())) ? string.Empty : drMember["PreferredSubCategoryID"].ToString().Trim(),
                                                            strDomainName);

                            // Get the Member files
                            foreach (DataRow drMemberFile in dtMemberFiles.Rows)
                            {
                                if (drMemberFile["MemberID"].ToString() == drMember["MemberID"].ToString())
                                {
                                    string filename = string.Empty;
                                    // Saving Files
                                    if (Convert.ToInt32(drMemberFile["MemberFileTypeID"]) == (int)PortalEnums.Members.MemberFileTypes.CoverLetter)
                                    {
                                        filename = string.Format("{0}_Registration_{1}_{2}_Coverletter{3}", strSiteDefaultCountryCode, drMember["MemberID"], drMemberFile["MemberFileID"], drMemberFile["MemberFileSearchExtension"]);
                                        membercoverletterxml.AppendFormat(@"<filename>{0}</filename>", filename);

                                        memberfile = memberfilesservice.GetByMemberFileId(Convert.ToInt32(drMemberFile["MemberFileID"]));
                                        if (memberfile != null)
                                        {
                                            string savepath = ConfigurationManager.AppSettings["CoverletterFolder"] + filename;
                                        byte[] memberfilecontent = null;

                                        if (!string.IsNullOrWhiteSpace(drMemberFile["MemberFileContent"].ToString()))
                                        {
                                            string errormessage = string.Empty;

                                            FtpClient ftpclient = new FtpClient();
                                            ftpclient.Host = ConfigurationManager.AppSettings["FTPHost"];
                                            ftpclient.Username = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                                            ftpclient.Password = ConfigurationManager.AppSettings["FTPJobApplyPassword"];

                                            string filepath = string.Format("{0}{1}/{2}/{3}/{4}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["MemberRootFolder"], ConfigurationManager.AppSettings["MemberFilesFolder"], memberfile.MemberId, memberfile.MemberFileUrl);
                                            Stream ms = null;
                                            ftpclient.DownloadFileToClient(filepath, ref ms, out errormessage);
                                            ms.Position = 0;

                                            memberfilecontent = ((MemoryStream)ms).ToArray();
                                        }
                                        else
                                        {
                                            memberfilecontent = memberfile.MemberFileContent;
                                        }
                                        
                                        File.WriteAllBytes(savepath, memberfilecontent);

                                            fileslist.Add(new FileNames(drMember["MemberID"].ToString(), savepath, filename));
                                        }
                                    }

                                    if (Convert.ToInt32(drMemberFile["MemberFileTypeID"]) == (int)PortalEnums.Members.MemberFileTypes.Resume)
                                    {
                                        filename = string.Format("{0}_Registration_{1}_{2}_Resume{3}", strSiteDefaultCountryCode, drMember["MemberID"], drMemberFile["MemberFileID"], drMemberFile["MemberFileSearchExtension"]);
                                        memberresumexml.AppendFormat(@"<filename>{0}</filename>", filename);

                                        memberfile = memberfilesservice.GetByMemberFileId(Convert.ToInt32(drMemberFile["MemberFileID"]));
                                        if (memberfile != null)
                                        {
                                            string savepath = ConfigurationManager.AppSettings["ResumeFolder"] + filename;
                                        byte[] memberfilecontent = null;

                                        if (!string.IsNullOrWhiteSpace(memberfile.MemberFileUrl))
                                        {
                                            string errormessage = string.Empty;

                                            FtpClient ftpclient = new FtpClient();
                                            ftpclient.Host = ConfigurationManager.AppSettings["FTPHost"];
                                            ftpclient.Username = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                                            ftpclient.Password = ConfigurationManager.AppSettings["FTPJobApplyPassword"];

                                            string filepath = string.Format("{0}{1}/{2}/{3}/{4}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["MemberRootFolder"], ConfigurationManager.AppSettings["MemberFilesFolder"], memberfile.MemberId, memberfile.MemberFileUrl);
                                            Stream ms = null;
                                            ftpclient.DownloadFileToClient(filepath, ref ms, out errormessage);
                                            ms.Position = 0;

                                            memberfilecontent= ((MemoryStream)ms).ToArray();
                                        }
                                        else
                                        {
                                            memberfilecontent = memberfile.MemberFileContent;
                                        }

                                        File.WriteAllBytes(savepath, memberfilecontent);

                                            fileslist.Add(new FileNames(drMember["MemberID"].ToString(), savepath, filename));
                                        }
                                    }
                                }
                            }

                            // Only if the RESUME file is uploaded, then upload the Member details with the files.
                            if (!string.IsNullOrWhiteSpace(memberresumexml.ToString()))
                            {

                                Console.WriteLine(string.Format("Member ID {2} - Resume: {0}, Coverletter: {1}", memberresumexml.ToString(), membercoverletterxml.ToString(), drMember["MemberID"]));

                                membercoverletterxml = new StringBuilder(string.Format(@"
    <coverletter>
        {0}
    </coverletter>", membercoverletterxml.ToString()));
                                memberresumexml = new StringBuilder(string.Format(@"   
    <resume>
        {0}
    </resume>", memberresumexml.ToString()));

                                memberxml.Append(membercoverletterxml.ToString());
                                memberxml.Append(memberresumexml.ToString());

                                memberxml.Append(@"
</member>");

                                // Save Member XML & include it in file list. File Name:  CountryCode_Registration_MemberID.XML
                                string memberfilename = string.Format("{0}_Registration_{1}.XML", strSiteDefaultCountryCode, drMember["MemberID"]); //drMember["Abbr"]

                                memberfilepath = string.Format("{0}{1}", ConfigurationManager.AppSettings["ResumeFolder"], memberfilename);
                                File.WriteAllText(memberfilepath, memberxml.ToString());
                                fileslist.Add(new FileNames(drMember["MemberID"].ToString(), memberfilepath, memberfilename));
                            }
                            else
                            {
                                Console.WriteLine("No resume for Member - ", drMember["MemberID"]);
                            fileslist.RemoveAll(s => s.Id == drMember["MemberID"].ToString()); 
                            }

                        }

                        string errormsg = string.Empty;
                        if (sitexml.sftp)
                        {
                       blnFileUploaded =  UploadTempFilesToSFTP(sitexml, fileslist, out errormsg);
                        }
                        else
                        {
                            blnFileUploaded = UploadTempFilesToFTP(sitexml, fileslist, out errormsg);
                        }

                        // Only if successful upload then update the LastModifed Date in the XML.
                        // So that when it runs next it runs from the successful Run.
                        if (blnFileUploaded)
                        {
                            XDocument xmlFile = XDocument.Load(ConfigurationManager.AppSettings["SiteMemberXML"]);
                            var query = from c in xmlFile.Elements("sites").Elements("site")
                                        select c;
                            foreach (XElement site in query)
                            {
                                // Save the Exception ID and the application which has exception in the XML.
                                if (site.Element("SiteId").Value == sitexml.SiteId.ToString())
                                {
                                    site.Element("LastModifiedDate").Value = DateTime.Now.ToString();
                                }
                            }

                            xmlFile.Save(ConfigurationManager.AppSettings["SiteMemberXML"]);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] ERROR: " + ex.StackTrace);

                        int exceptionID = LogExceptionAndEmail(sitexml, currentMember, ex);

                    }
                }
            }
        }


        public static bool UploadTempFilesToFTP(SitesXML siteXML, List<FileNames> filesToUpload, out string errormessage)
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

                    Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Uploading File: " + fileNames.fromFilename);

                    fileInfo = new FileInfo(fileNames.fromFilename);
                    request.ContentLength = fileInfo.Length;

                    // Create buffer for file contents
                    int buffLength = 16384;
                    byte[] buff = new byte[buffLength];

                    // Upload this file
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
                    Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] File Uploaded: " + fileNames.toFilename);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] ERROR: " + ex.Message + "\n" + ex.StackTrace);
                    blnResult = false;
                }
            }

            return blnResult;
        }

        private bool UploadTempFilesToSFTP(SitesXML siteXML, List<FileNames> filesToUpload, out string errormessage)
        {
            errormessage = string.Empty;
            bool blnResult = false;
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
                        // Upload a file
                        Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Uploading File: " + fileNames.fromFilename);
                        sftp.Put(fileNames.fromFilename, fileNames.toFilename);
                        Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] File Uploaded: " + fileNames.toFilename);
                    }
                    else
                    {
                        Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] File Not Found: " + fileNames.fromFilename);
                    }
                    // Close the Sftp connection
                    //sftp.Close();
                }

                blnResult = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] ERROR: " + ex.Message + "\n" + ex.StackTrace);
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

        protected static int LogExceptionAndEmail(SitesXML siteXML, DataRow drMember, Exception ex)
        {
            ExceptionTableService serviceException = new ExceptionTableService();

            int intExceptionID = serviceException.LogException(ex.GetBaseException());

            //XDocument xmlFile = XDocument.Load(ConfigurationManager.AppSettings["SitesXML"]);
            //var query = from c in xmlFile.Elements("sites").Elements("site")
            //            select c;
            //foreach (XElement site in query)
            //{
            //    // Save the Exception ID and the application which has exception in the XML.
            //    if (site.Element("SiteId").Value == siteXML.SiteId.ToString())
            //    {
            //        site.Element("ExceptionID").Value = intExceptionID.ToString();
            //    }
            //}

            // xmlFile.Save(ConfigurationManager.AppSettings["SitesXML"]);


            // **** Send email when there is an error.
            Message message = new Message();
            message.Format = Format.Html;
            if (drMember != null)
            {
                message.Body = string.Format(@"
SiteId: {0}<br /><br />
MemberID: {1}<br /><br />
DateTime: {2}<br /><br />
Message: {3}<br /><br />
StackTrace: {4}<br /><br />
ExceptionID: {5}",
                        siteXML.SiteId,
                        drMember["MemberID"],
                        DateTime.Now,
                        ex.Message,
                        ex.StackTrace,
                        intExceptionID);
            }
            else
            {
                message.Body = string.Format(@"
SiteId: {0}<br /><br />
DateTime: {1}<br /><br />
Message: {2}<br /><br />
StackTrace: {3}<br /><br />
ExceptionID: {4}",
                        siteXML.SiteId,
                        DateTime.Now,
                        ex.Message,
                        ex.StackTrace,
                        intExceptionID);
            }

            message.From = new MailAddress("bugs@jxt.com.au", "MiniJXT Support");
            message.To = new MailAddress(ConfigurationManager.AppSettings["AdminEmail"]);
            message.Subject = "MiniJXT - Job application FTP Error";

            EmailSender().Send(message);

            return intExceptionID;
        }

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
    }
}
