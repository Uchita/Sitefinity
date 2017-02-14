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
using log4net;

namespace JXTPostJobApplicationToFTP
{
    public class MemberXMLGenerator
    {
        ILog _logger;
        IFileUploader _fileUploader;

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


        public MemberXMLGenerator(IFileUploader fileUploader)
        {
            _logger = LogManager.GetLogger(typeof(MemberXMLGenerator));
            _fileUploader = fileUploader;
        }

        public void GenerateKellyMemberXML(string memberFlePath, IEnumerable<int> memberIds)
        {
            MembersService memberService = new MembersService();
            MemberFilesService memberFilesService = new MemberFilesService();
            string memberFilePath = string.Empty;
           
            var xml = XDocument.Load(memberFlePath);

            // Query the data and write out a subset of contacts
            var siteXmlList = xml.Descendants("site").Select(c => new SitesXML()
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

            foreach (SitesXML siteXml in siteXmlList)
            {
                int siteId = siteXml.SiteId;
                DateTime lastRun = (string.IsNullOrEmpty(siteXml.LastJobApplicationId) ? new DateTime(2012, 1, 1) : Convert.ToDateTime(siteXml.LastJobApplicationId));
                var filesList = new List<FileNames>();
                
                try
                {
                    var dataSet = memberService.CustomGetNewValidMembers(siteId, lastRun);
                    
                    var memberFilesDataTable = dataSet.Tables[1];

                    string siteUrl = GetUrl(siteId);
                    string defaultCountryCode = GetDefaultCountryCode(siteId);

                    var members = GetValidatedMembers(dataSet, memberIds, siteXml.Mode);

                    _logger.InfoFormat("Found {0} members", members.Count());
                    
                    // For each member
                    foreach (DataRow drMember in members)
                    {
                        var memberXml = new StringBuilder();
                        var memberCoverLetterXml = new StringBuilder();
                        var memberResumeXml = new StringBuilder();
                        
                        // Get the member XML
                        memberXml.AppendFormat(@"
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
                                                        siteUrl);

                        // Get the Member files
                        foreach (DataRow memberFileRow in memberFilesDataTable.Rows)
                        {
                            if (memberFileRow["MemberID"].ToString() == drMember["MemberID"].ToString())
                            {
                                string filename = string.Empty;
                                // Saving Files
                                if (Convert.ToInt32(memberFileRow["MemberFileTypeID"]) == (int)PortalEnums.Members.MemberFileTypes.CoverLetter)
                                {
                                    filename = string.Format("{0}_Registration_{1}_{2}_Coverletter{3}", defaultCountryCode, drMember["MemberID"], memberFileRow["MemberFileID"], memberFileRow["MemberFileSearchExtension"]);
                                    memberCoverLetterXml.AppendFormat(@"<filename>{0}</filename>", filename);

                                    var memberFile = memberFilesService.GetByMemberFileId(Convert.ToInt32(memberFileRow["MemberFileID"]));
                                    if (memberFile != null)
                                    {
                                        string savepath = ConfigurationManager.AppSettings["CoverletterFolder"] + filename;
                                        byte[] memberfilecontent = null;

                                        if (!string.IsNullOrWhiteSpace(memberFile.MemberFileUrl))
                                        {
                                            string errormessage = string.Empty;

                                            FtpClient ftpclient = new FtpClient();
                                            ftpclient.Host = ConfigurationManager.AppSettings["FTPHost"];
                                            ftpclient.Username = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                                            ftpclient.Password = ConfigurationManager.AppSettings["FTPJobApplyPassword"];

                                            string filepath = string.Format("{0}{1}/{2}/{3}/{4}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["MemberRootFolder"], ConfigurationManager.AppSettings["MemberFilesFolder"], memberFile.MemberId, memberFile.MemberFileUrl);
                                            Stream ms = null;
                                            ftpclient.DownloadFileToClient(filepath, ref ms, out errormessage);
                                            if (ms != null)
                                            {
                                                ms.Position = 0;

                                                memberfilecontent = ((MemoryStream)ms).ToArray();
                                            }
                                        }
                                        else
                                        {
                                            memberfilecontent = memberFile.MemberFileContent;
                                        }

                                        if (memberfilecontent != null)
                                        {
                                            File.WriteAllBytes(savepath, memberfilecontent);

                                            filesList.Add(new FileNames(drMember["MemberID"].ToString(), savepath, filename));
                                        }
                                    }
                                }

                                if (Convert.ToInt32(memberFileRow["MemberFileTypeID"]) == (int)PortalEnums.Members.MemberFileTypes.Resume)
                                {
                                    filename = string.Format("{0}_Registration_{1}_{2}_Resume{3}", defaultCountryCode, drMember["MemberID"], memberFileRow["MemberFileID"], memberFileRow["MemberFileSearchExtension"]);
                                    memberResumeXml.AppendFormat(@"<filename>{0}</filename>", filename);

                                    var memberFile = memberFilesService.GetByMemberFileId(Convert.ToInt32(memberFileRow["MemberFileID"]));
                                    if (memberFile != null)
                                    {
                                        string savepath = ConfigurationManager.AppSettings["ResumeFolder"] + filename;
                                        byte[] memberfilecontent = null;

                                        if (!string.IsNullOrWhiteSpace(memberFile.MemberFileUrl))
                                        {
                                            string errormessage = string.Empty;

                                            FtpClient ftpclient = new FtpClient();
                                            ftpclient.Host = ConfigurationManager.AppSettings["FTPHost"];
                                            ftpclient.Username = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                                            ftpclient.Password = ConfigurationManager.AppSettings["FTPJobApplyPassword"];

                                            string filepath = string.Format("{0}{1}/{2}/{3}/{4}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["MemberRootFolder"], ConfigurationManager.AppSettings["MemberFilesFolder"], memberFile.MemberId, memberFile.MemberFileUrl);
                                            Stream ms = null;
                                            ftpclient.DownloadFileToClient(filepath, ref ms, out errormessage);

                                            if (ms != null)
                                            {
                                                ms.Position = 0;

                                                memberfilecontent = ((MemoryStream)ms).ToArray();
                                            }
                                        }
                                        else
                                        {
                                            memberfilecontent = memberFile.MemberFileContent;
                                        }

                                        if (memberfilecontent != null)
                                        {
                                            File.WriteAllBytes(savepath, memberfilecontent);

                                            filesList.Add(new FileNames(drMember["MemberID"].ToString(), savepath, filename));
                                        }
                                    }
                                }
                            }
                        }

                        // Only if the RESUME file is uploaded, then upload the Member details with the files.
                        if (!string.IsNullOrWhiteSpace(memberResumeXml.ToString()))
                        {
                            _logger.DebugFormat("Member ID {0} - Resume: {1}, Coverletter: {2}", drMember["MemberID"], memberResumeXml.ToString(), memberCoverLetterXml.ToString());

                            memberCoverLetterXml = new StringBuilder(string.Format(@"
    <coverletter>
        {0}
    </coverletter>", memberCoverLetterXml.ToString()));
                            memberResumeXml = new StringBuilder(string.Format(@"   
    <resume>
        {0}
    </resume>", memberResumeXml.ToString()));

                            memberXml.Append(memberCoverLetterXml.ToString());
                            memberXml.Append(memberResumeXml.ToString());

                            memberXml.Append(@"
</member>");

                            // Save Member XML & include it in file list. File Name:  CountryCode_Registration_MemberID.XML
                            string memberfilename = string.Format("{0}_Registration_{1}.XML", defaultCountryCode, drMember["MemberID"]); //drMember["Abbr"]

                            memberFilePath = string.Format("{0}{1}", ConfigurationManager.AppSettings["ResumeFolder"], memberfilename);
                            File.WriteAllText(memberFilePath, memberXml.ToString());
                            filesList.Add(new FileNames(drMember["MemberID"].ToString(), memberFilePath, memberfilename));
                        }
                        else
                        {
                            _logger.DebugFormat("No resume for Member Id ", drMember["MemberID"]);
                            filesList.RemoveAll(s => s.Id == drMember["MemberID"].ToString());
                        }
                    }

                    string errormsg = string.Empty;
                    bool uploaded = _fileUploader.UploadFiles(siteXml, filesList);
                    

                    // Only if successful upload then update the LastModifed Date in the XML.
                    // So that when it runs next it runs from the successful Run.
                    if (uploaded)
                    {
                        XDocument xmlFile = XDocument.Load(ConfigurationManager.AppSettings["SiteMemberXML"]);
                        var query = from c in xmlFile.Elements("sites").Elements("site")
                                    select c;
                        foreach (XElement site in query)
                        {
                            // Save the Exception ID and the application which has exception in the XML.
                            if (site.Element("SiteId").Value == siteXml.SiteId.ToString())
                            {
                                site.Element("LastModifiedDate").Value = DateTime.Now.ToString();
                            }
                        }

                        xmlFile.Save(ConfigurationManager.AppSettings["SiteMemberXML"]);
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                }
            }
        }

        private IEnumerable<DataRow> GetValidatedMembers(DataSet membersDataSet, IEnumerable<int> memberIds, string exportMode)
        {
            var membersDataTable = membersDataSet.Tables[0];

            string selectClause = string.Empty;

            if (memberIds.Count() > 0)
            {
                selectClause = string.Format("MemberID IN ({0})",string.Join(",", memberIds));
            }
            else if (exportMode == "FullCandidate")
            {
                selectClause = "ISNULL(Title, '') <> '' AND ISNULL(FirstName, '') <> '' AND ISNULL(Surname, '') <> '' AND ISNULL(EmailAddress, '') <> '' AND ISNULL(HomePhone, '') <> '' AND ISNULL(Address1, '') <> ''";
            }
               
            return string.IsNullOrWhiteSpace(selectClause) ? membersDataTable.Select() : membersDataTable.Select(selectClause);
        }

        private string GetDefaultCountryCode(int siteId)
        {
            using (TList<GlobalSettings> gslist = GlobalSettingsService.GetBySiteId(siteId))
            {
                if (gslist.Count > 0)
                {
                    if (gslist[0].DefaultCountryId.HasValue)
                    {
                        using (Countries countries = CountriesService.GetByCountryId(gslist[0].DefaultCountryId.Value))
                        {
                            // Get the default site country code
                            if (countries != null)
                            {
                                string code = countries.Abbr;
                                _logger.InfoFormat("found the default CountryCode {0} for SiteId {1}", code, siteId); 
                                return code;
                            }
                        }
                    }
                }
            }

            _logger.InfoFormat("Failed to find a default CountryCode for SiteId {1}", siteId); 
            return string.Empty;
        }

        private string GetUrl(int siteId)
        {
            SitesService sitesService = new SitesService();
            string url = sitesService.GetBySiteId(siteId).SiteUrl;
            _logger.InfoFormat("Found SiteURL: {0}, for SiteId: {1}", url, siteId);
            return url;
        }
    }
}
