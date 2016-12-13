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
using JXTPostDataToFTP.Models;
using System.Xml.Serialization;
using System.Xml;

namespace JXTPostDataToFTP
{
    public class MemberXMLGenerator
    {

        #region Properties

        MembersService _membersService;
        MembersService MembersService
        {
            get
            {
                if (_membersService == null)
                {
                    _membersService = new JXTPortal.MembersService();
                }
                return _membersService;
            }
        }

        MemberFilesService _membersFilesService;
        MemberFilesService MembersFilesService
        {
            get
            {
                if (_membersFilesService == null)
                {
                    _membersFilesService = new JXTPortal.MemberFilesService();
                }
                return _membersFilesService;
            }
        }

        MemberWizardService _memberWizardService;
        MemberWizardService MemberWizardService
        {
            get
            {
                if (_memberWizardService == null)
                {
                    _memberWizardService = new JXTPortal.MemberWizardService();
                }
                return _memberWizardService;
            }
        }

        MemberPositionsService _memberpositionsService;
        MemberPositionsService MemberPositionsService
        {
            get
            {
                if (_memberpositionsService == null)
                    _memberpositionsService = new MemberPositionsService();

                return _memberpositionsService;
            }
        }

        GlobalSettingsService _GlobalSettingsService = null;
        GlobalSettingsService GlobalSettingsService
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

        CountriesService _countriesService = null;
        CountriesService CountriesService
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

        LocationService _locationService = null;
        LocationService LocationService
        {
            get
            {
                if (_locationService == null)
                {
                    _locationService = new LocationService();
                }
                return _locationService;
            }
        }

        AreaService _areaService = null;
        AreaService AreaService
        {
            get
            {
                if (_areaService == null)
                {
                    _areaService = new AreaService();
                }
                return _areaService;
            }
        }

        ProfessionService _professionService = null;
        ProfessionService ProfessionService
        {
            get
            {
                if (_professionService == null)
                {
                    _professionService = new ProfessionService();
                }
                return _professionService;
            }
        }

        RolesService _rolesService = null;
        RolesService RolesService
        {
            get
            {
                if (_rolesService == null)
                {
                    _rolesService = new RolesService();
                }
                return _rolesService;
            }
        }

        SiteWorkTypeService _siteworktypeService = null;
        SiteWorkTypeService SiteWorkTypeService
        {
            get
            {
                if (_siteworktypeService == null)
                {
                    _siteworktypeService = new SiteWorkTypeService();
                }
                return _siteworktypeService;
            }
        }

        SiteSalaryTypeService _siteSalaryTypeService = null;
        SiteSalaryTypeService SiteSalaryTypeService
        {
            get
            {
                if (_siteSalaryTypeService == null)
                {
                    _siteSalaryTypeService = new SiteSalaryTypeService();
                }
                return _siteSalaryTypeService;
            }
        }

        JobApplicationService _jobApplicationService = null;
        JobApplicationService JobApplicationService
        {
            get
            {
                if (_jobApplicationService == null)
                {
                    _jobApplicationService = new JobApplicationService();
                }
                return _jobApplicationService;
            }
        }

        MemberFilesService _memberFilesService = null;
        MemberFilesService MemberFilesService
        {
            get
            {
                if (_memberFilesService == null)
                {
                    _memberFilesService = new MemberFilesService();
                }
                return _memberFilesService;
            }
        }

        MemberQualificationService _memberQualificationService = null;
        MemberQualificationService MemberQualificationService
        {
            get
            {
                if (_memberQualificationService == null)
                {
                    _memberQualificationService = new MemberQualificationService();
                }
                return _memberQualificationService;
            }
        }

        MemberCertificateMembershipsService _memberCertificateMembershipService = null;
        MemberCertificateMembershipsService MemberCertificateMembershipsService
        {
            get
            {
                if (_memberCertificateMembershipService == null)
                {
                    _memberCertificateMembershipService = new MemberCertificateMembershipsService();
                }
                return _memberCertificateMembershipService;
            }
        }

        MemberLicensesService _memberLicensesService = null;
        MemberLicensesService MemberLicensesService
        {
            get
            {
                if (_memberLicensesService == null)
                {
                    _memberLicensesService = new MemberLicensesService();
                }
                return _memberLicensesService;
            }
        }

        MemberLanguagesService _memberLanguagesService = null;
        MemberLanguagesService MemberLanguagesService
        {
            get
            {
                if (_memberLanguagesService == null)
                {
                    _memberLanguagesService = new MemberLanguagesService();
                }
                return _memberLanguagesService;
            }
        }

        MemberReferencesService _memberReferencesService = null;
        MemberReferencesService MemberReferencesService
        {
            get
            {
                if (_memberReferencesService == null)
                {
                    _memberReferencesService = new MemberReferencesService();
                }
                return _memberReferencesService;
            }
        }
        #endregion

        #region Constructor

        public MemberXMLGenerator()
        {
        }

        #endregion

        #region FTP / SFTP Methods

        public static bool UploadTempFilesToFTP(SitesXML siteXML, List<FileNames> filesToUpload, out string errormessage)
        {

            Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Files Upload Begin");

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

                    // Delete file
                    File.Delete(fileNames.fromFilename);
                    Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] File Deleted: " + fileNames.fromFilename);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] ERROR: " + ex.Message + "\n" + ex.StackTrace);
                    blnResult = false;
                }
            }

            Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Files Upload Ends");

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
                        sftp.Put(fileNames.fromFilename, (siteXML.folderPath != null ? siteXML.folderPath : string.Empty) + fileNames.toFilename);
                        Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] File Uploaded: " + fileNames.toFilename);

                        // Delete file
                        File.Delete(fileNames.fromFilename);
                        Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] File Deleted: " + fileNames.fromFilename);
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

        #endregion

        #region Log exception and email
        protected static int LogExceptionAndEmail(SitesXML siteXML, int? memberID, Exception ex)
        {
            ExceptionTableService serviceException = new ExceptionTableService();

            int intExceptionID = serviceException.LogException(ex.GetBaseException());

            // Save the exception id
            XDocument xmlFile = XDocument.Load(ConfigurationManager.AppSettings["SiteMemberXML"]);
            var query = from c in xmlFile.Elements("sites").Elements("site")
                        select c;
            foreach (XElement site in query)
            {
                // Save the Exception ID and the application which has exception in the XML.
                if (site.Element("SiteId").Value == siteXML.SiteId.ToString())
                {
                    site.Element("ExceptionID").Value = intExceptionID.ToString();
                }
            }
            xmlFile.Save(ConfigurationManager.AppSettings["SiteXML"]);


            // **** Send email when there is an error.
            Message message = new Message();
            message.Format = Format.Html;
            if (memberID != null)
            {
                message.Body = string.Format(@"
SiteId: {0}<br /><br />
MemberID: {1}<br /><br />
DateTime: {2}<br /><br />
Message: {3}<br /><br />
StackTrace: {4}<br /><br />
ExceptionID: {5}",
                        siteXML.SiteId,
                        memberID.Value,
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

        #endregion

        public void GenerateMemberXML()
        {
            var xml = XDocument.Load(ConfigurationManager.AppSettings["SiteMemberXML"]);

            // Query the data and write out a subset of contacts
            IEnumerable<SitesXML> siteXMLList = xml.Descendants("site").Select(c => new SitesXML()
            {
                SiteId = (int)c.Element("SiteId"),
                host = (string)c.Element("host"),
                folderPath = (string)c.Element("FolderPath"),
                username = (string)c.Element("username"),
                password = (string)c.Element("password"),
                sftp = (bool)c.Element("sftp"),
                port = (int)c.Element("port"),
                mode = (string)c.Element("Mode"),
                LastModifiedDate = (string)c.Element("LastModifiedDate")            // Job application id used for getting the last modified date
            });


            foreach (SitesXML sitexml in siteXMLList)
            {
                try
                {
                    int siteID = sitexml.SiteId;
                    DateTime lastRun = (string.IsNullOrEmpty(sitexml.LastModifiedDate) ? new DateTime(2012, 1, 1) : Convert.ToDateTime(sitexml.LastModifiedDate));

                    string dateformat = "dd/MM/yyyy";
                    using (TList<GlobalSettings> gslist = new GlobalSettingsService().GetBySiteId(siteID))
                    {
                        if (gslist.Count > 0)
                        {
                            dateformat = gslist[0].GlobalDateFormat;
                        }
                    }

                    //load references
                    SiteSettingReferences siteRefs = SiteSettingReferencesGet(siteID);
                    JXTPostDataToFTP.Models.MemberXMLModel.StaticSiteReference.SetRefData(siteRefs);
                    DataSet ds = MembersService.CustomGetNewValidProfiles(siteID, lastRun);
                    DataTable dtMembers = ds.Tables[0];
                    DataTable dtMemberFiles = ds.Tables[1];
                    DataTable dtMemberDirectorships = ds.Tables[2];
                    DataTable dtMemberExperiences = ds.Tables[3];
                    DataTable dtMemberEducations = ds.Tables[4];
                    DataTable dtMemberCerts = ds.Tables[5];
                    DataTable dtMemberLicenses = ds.Tables[6];
                    DataTable dtMemberRolePreferences = ds.Tables[7];
                    DataTable dtMemberLanguages = ds.Tables[8];
                    DataTable dtMemberReferences = ds.Tables[9];

                    DataRow[] drValidatedMembers = null;

                    if (sitexml.mode == "JobApplication")
                    {
                        dtMembers.Rows.Clear();
                        dtMemberFiles.Rows.Clear();
                        dtMemberDirectorships.Rows.Clear();
                        dtMemberExperiences.Rows.Clear();
                        dtMemberEducations.Rows.Clear();
                        dtMemberCerts.Rows.Clear();
                        dtMemberLicenses.Rows.Clear();
                        dtMemberRolePreferences.Rows.Clear();
                        dtMemberLanguages.Rows.Clear();
                        dtMemberReferences.Rows.Clear();

                        TList<JobApplication> jobapplications = JobApplicationService.GetBySiteIdReferral(sitexml.SiteId);

                        foreach (JobApplication jobapplication in jobapplications)
                        {
                            if (jobapplication.LastViewedDate.HasValue && jobapplication.LastViewedDate.Value > lastRun && jobapplication.ApplicationStatus == (int)PortalEnums.JobApplications.ApplicationStatus.ShortList && jobapplication.MemberId.HasValue)
                            {
                                Members member = MembersService.GetByMemberId(jobapplication.MemberId.Value);
                                TList<MemberFiles> memberFiles = MemberFilesService.GetByMemberId(jobapplication.MemberId.Value);
                                TList<MemberPositions> memberPositions = MemberPositionsService.GetByMemberId(jobapplication.MemberId.Value);
                                TList<MemberQualification> memberQualifications = MemberQualificationService.GetByMemberId(jobapplication.MemberId.Value);
                                TList<MemberCertificateMemberships> memberCertificates = MemberCertificateMembershipsService.GetByMemberId(jobapplication.MemberId.Value);
                                TList<MemberLicenses> memberLicenses = MemberLicensesService.GetByMemberId(jobapplication.MemberId.Value);
                                TList<MemberLanguages> memberLanguages = MemberLanguagesService.GetByMemberId(jobapplication.MemberId.Value);
                                TList<MemberReferences> memberReferences = MemberReferencesService.GetByMemberId(jobapplication.MemberId.Value);

                                dtMembers.Rows.Add(member.MemberId,
                                                     member.SiteId,
                                                     member.Username,
                                                     member.Password,
                                                     member.Title,
                                                     member.FirstName,
                                                     member.Surname,
                                                     member.EmailAddress,
                                                     member.Company,
                                                     member.Position,
                                                     member.HomePhone,
                                                     member.WorkPhone,
                                                     member.MobilePhone,
                                                     member.Fax,
                                                     member.Address1,
                                                     member.Address2,
                                                     member.LocationId,
                                                     member.AreaId,
                                                     member.CountryId,
                                                     member.PreferredCategoryId,
                                                     member.PreferredSubCategoryId,
                                                     member.PreferredSalaryId,
                                                     member.Subscribed,
                                                     member.MonthlyUpdate,
                                                     member.ReferringMemberId,
                                                     member.LastModifiedDate,
                                                     member.Valid,
                                                     member.EmailFormat,
                                                     member.LastLogon,
                                                     member.DateOfBirth,
                                                     member.Gender,
                                                     member.Tags,
                                                     member.Validated,
                                                     member.ValidateGuid,
                                                     member.MemberUrlExtension,
                                                     member.WebsiteUrl,
                                                     member.AvailabilityId,
                                                     member.AvailabilityFromDate,
                                                     member.MySpaceHeading,
                                                     member.MySpaceContent,
                                                     member.UrlReferrer,
                                                     member.RequiredPasswordChange,
                                                     member.PreferredJobTitle,
                                                     member.PreferredAvailability,
                                                     member.PreferredAvailabilityType,
                                                     member.PreferredSalaryFrom,
                                                     member.PreferredSalaryTo,
                                                     member.CurrentSalaryFrom,
                                                     member.CurrentSalaryTo,
                                                     member.LookingFor,
                                                     member.Experience,
                                                     member.Skills,
                                                     member.Reasons,
                                                     member.Comments,
                                                     member.ProfileType,
                                                     member.EducationId,
                                                     member.SearchField,
                                                     member.RegisteredDate,
                                                     member.States,
                                                     member.Suburb,
                                                     member.PostCode,
                                                     member.ProfilePicture,
                                                     member.ShortBio,
                                                     member.WorkTypeId,
                                                     member.Memberships,
                                                     member.MemberStatusId,
                                                     member.LinkedInAccessToken,
                                                     member.ExternalMemberId,
                                                     member.PassportNo,
                                                     member.MailingAddress1,
                                                     member.MailingAddress2,
                                                     member.MailingStates,
                                                     member.MailingSuburb,
                                                     member.MailingPostCode,
                                                     member.MailingCountryId,
                                                     member.CountryName,
                                                     member.MailingCountryName,
                                                     member.LoginAttempts,
                                                     member.LastAttemptDate,
                                                     member.Status,
                                                     member.LastTermsAndConditionsDate,
                                                     member.DefaultLanguageId,
                                                     member.ReferringSiteId,
                                                     member.MultiLingualFirstName,
                                                     member.MultiLingualSurame,
                                                     member.SecondaryEmail,
                                                     member.CandidateData,
                                                     member.PreferredLine,
                                                     member.EligibleToWorkIn,
                                                     member.ReferenceUponRequest,
                                                     member.VideoUrl,
                                                     member.ProfileDataXml,
                                                     member.LastProfileSubmittedDate,
                                                     "SK",
                                                     member.CountryName,
                                                    memberFiles.Count);

                                foreach (MemberFiles memberFile in memberFiles)
                                {
                                    dtMemberFiles.Rows.Add(memberFile.MemberFileId,
                                                            memberFile.MemberId,
                                                            memberFile.MemberFileTypeId,
                                                            memberFile.MemberFileName,
                                                            memberFile.MemberFileSearchExtension,
                                                            memberFile.MemberFileTitle,
                                                            memberFile.LastModifiedDate);
                                }

                                foreach (MemberPositions memberPosition in memberPositions)
                                {
                                    dtMemberExperiences.Rows.Add(memberPosition.MemberPositionId,
                                                                memberPosition.LinkedInInternalPositionId,
                                                                memberPosition.Title,
                                                                memberPosition.Summary,
                                                                memberPosition.CompanyId,
                                                                memberPosition.CompanyName,
                                                                memberPosition.CompanyIndustry,
                                                                memberPosition.StartMonth,
                                                                memberPosition.StartYear,
                                                                memberPosition.EndMonth,
                                                                memberPosition.EndYear,
                                                                memberPosition.IsCurrent,
                                                                memberPosition.MemberId,
                                                                memberPosition.OrganisationWebsite,
                                                                memberPosition.ResponsibilitiesAndAchievements,
                                                                memberPosition.TypeOfDirectorship,
                                                                memberPosition.AdditionalRolesAndResponsibilities,
                                                                memberPosition.IsDirectorship,
                                                                memberPosition.City,
                                                                memberPosition.CountryId,
                                                                memberPosition.State);
                                }

                                foreach (MemberQualification memberQualification in memberQualifications)
                                {
                                    dtMemberEducations.Rows.Add(memberQualification.MemberQualificationId,
                                                                memberQualification.LinkedInInternalEducationId,
                                                                memberQualification.SchoolName,
                                                                memberQualification.FieldOfStudy,
                                                                memberQualification.StartYear,
                                                                memberQualification.EndYear,
                                                                memberQualification.Degree,
                                                                memberQualification.Activities,
                                                                memberQualification.Notes,
                                                                memberQualification.MemberId,
                                                                memberQualification.City,
                                                                memberQualification.CountryId,
                                                                memberQualification.QualificationLevelId,
                                                                memberQualification.QualificationLevelOther,
                                                                memberQualification.Major,
                                                                memberQualification.Present,
                                                                memberQualification.StartMonth,
                                                                memberQualification.EndMonth,
                                                                memberQualification.Graduated,
                                                                memberQualification.NonGraduatedCredits);
                                }

                                foreach (MemberCertificateMemberships memberCertificate in memberCertificates)
                                {
                                    dtMemberCerts.Rows.Add(memberCertificate.MemberCertificateMembershipId,
                                                            memberCertificate.MemberId,
                                                            memberCertificate.MemberCertificateMembershipName,
                                                            memberCertificate.CertificationAuthority,
                                                            memberCertificate.LicenseNumber,
                                                            memberCertificate.CertificationUrl,
                                                            memberCertificate.StartMonth,
                                                            memberCertificate.StartYear,
                                                            memberCertificate.EndMonth,
                                                            memberCertificate.EndYear,
                                                            memberCertificate.DoesnotExpire,
                                                            memberCertificate.LastModifiedDate);
                                }

                                foreach (MemberLicenses memberLicense in memberLicenses)
                                {
                                    dtMemberLicenses.Rows.Add(memberLicense.MemberLicenseId,
                                                            memberLicense.MemberId,
                                                            memberLicense.MemberLicenseName,
                                                            memberLicense.LicenseType,
                                                            memberLicense.IssueDate,
                                                            memberLicense.ExpiryDate,
                                                            memberLicense.CountryId,
                                                            memberLicense.State,
                                                            memberLicense.DoesNotExpire,
                                                            memberLicense.LastModifiedDate);
                                }

                                dtMemberRolePreferences.Rows.Add(member.MemberId,
                                                                 member.WorkTypeId,
                                                                 null,
                                                                 member.PreferredSalaryId,
                                                                 null,
                                                                 member.PreferredSalaryFrom,
                                                                 member.PreferredSalaryTo,
                                                                 member.PreferredCategoryId,
                                                                 null,
                                                                 member.PreferredSubCategoryId,
                                                                 null,
                                                                 member.LocationId,
                                                                 null,
                                                                 member.AreaId,
                                                                 null,
                                                                 member.EligibleToWorkIn,
                                                                 null);

                                foreach (MemberLanguages memberLanguage in memberLanguages)
                                {
                                    dtMemberLanguages.Rows.Add(memberLanguage.MemberLanguageId,
                                                                             memberLanguage.MemberId,
                                                                             memberLanguage.Langauges,
                                                                             memberLanguage.Profieciency,
                                                                             memberLanguage.LastModifiedDate);
                                }

                                foreach (MemberReferences memberReference in memberReferences)
                                {
                                    dtMemberReferences.Rows.Add(memberReference.MemberReferenceId,
                                                            memberReference.MemberId,
                                                            memberReference.MemberReferenceName,
                                                            memberReference.JobTitle,
                                                            memberReference.Company,
                                                            memberReference.Phone,
                                                            memberReference.Relationship,
                                                            memberReference.LastModifiedDate,
                                                            memberReference.ReferenceEmail);
                                }
                            }
                        }

                        drValidatedMembers = dtMembers.Select();
                    }
                    else
                    {
                        if (sitexml.mode == "FullCandidate")
                        {
                            drValidatedMembers = dtMembers.Select("Validated=1 AND ISNULL(Title, '') <> '' AND ISNULL(FirstName, '') <> '' AND ISNULL(Surname, '') <> '' AND ISNULL(EmailAddress, '') <> '' AND ISNULL(HomePhone, '') <> '' AND ISNULL(Address1, '') <> ''");
                        }
                        else
                        {
                            drValidatedMembers = dtMembers.Select("Validated=1");
                        }
                    }

                    Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Number of Members: " + drValidatedMembers.Count().ToString());

                    List<MemberXMLModel> MembersXML = new List<MemberXMLModel>();
                    List<MemberFiles> MembersFilesList = new List<MemberFiles>();

                    // For each member
                    foreach (DataRow drMember in drValidatedMembers)
                    {
                        int thisMemberID = int.Parse(drMember["MemberID"].ToString());

                        Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Processing Member XML: " + thisMemberID.ToString());

                        DataRow[] thisMemberFiles = dtMemberFiles.Select("MemberID=" + thisMemberID);
                        DataRow[] thisMemberDirectorships = dtMemberDirectorships.Select("MemberID=" + thisMemberID);
                        DataRow[] thisMemberExperiences = dtMemberExperiences.Select("MemberID=" + thisMemberID);
                        DataRow[] thisMemberEducations = dtMemberEducations.Select("MemberID=" + thisMemberID);
                        DataRow[] thisMemberCerts = dtMemberCerts.Select("MemberID=" + thisMemberID);
                        DataRow[] thisMemberLicenses = dtMemberLicenses.Select("MemberID=" + thisMemberID);
                        DataRow[] thisMemberRolePreference = dtMemberRolePreferences.Select("MemberID=" + thisMemberID);
                        DataRow[] thisMemberLanguages = dtMemberLanguages.Select("MemberID=" + thisMemberID);
                        DataRow[] thisMemberReferences = dtMemberReferences.Select("MemberID=" + thisMemberID);

                        int? memberPoints = 0;
                        MemberWizardService.CustomGetMemberPoints(siteID, thisMemberID, ref memberPoints);

                        //TODO: Assign to model


                        //Empty memberfiles if it is PhysicalFile mode
                        if (sitexml.mode == "PhysicalFile" || sitexml.mode == "FullCandidate")
                        {
                            foreach (DataRow drmemberfile in thisMemberFiles)
                            {
                                MemberFiles memberfile = new MemberFiles();
                                memberfile.MemberFileId = Convert.ToInt32(drmemberfile["MemberFileID"]);
                                memberfile.MemberId = Convert.ToInt32(drmemberfile["MemberID"]);
                                memberfile.MemberFileName = drmemberfile["MemberFileName"].ToString();

                                MembersFilesList.Add(memberfile);
                            }
                        }

                        MemberXMLModel thisMemberXML = new MemberXMLModel(siteRefs, drMember, thisMemberFiles, thisMemberDirectorships, thisMemberExperiences, thisMemberEducations, thisMemberCerts, thisMemberLicenses, thisMemberRolePreference, thisMemberLanguages, thisMemberReferences, memberPoints, dateformat);

                        //TODO: Get File Contents to Base64
                        if (string.IsNullOrEmpty(sitexml.mode))
                        {
                            SetFileContentsForMemberXML(siteID, thisMemberXML);
                        }

                        //TODO: Get Custom Questions and Answers
                        thisMemberXML.CustomQuestions = GetCustomQuestions(siteID, thisMemberID);

                        MembersXML.Add(thisMemberXML);

                        Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] Member XML Processed: " + thisMemberID.ToString());
                    }

                    //Finally, xml serialize
                    //string xmlString;
                    //XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<MemberXMLModel>));
                    //using (StringWriter textWriter = new StringWriter())
                    //{
                    //    xmlSerializer.Serialize(textWriter, MembersXML);
                    //    xmlString = textWriter.ToString();
                    //}

                    try
                    {
                        List<FileNames> fileslist = new List<FileNames>();

                        foreach (MemberXMLModel thisXML in MembersXML)
                        {
                            Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] About to Write Member ID: " + thisXML.Profile.MemberID.ToString());
                            string thisMemberXML = string.Empty;
                            XmlSerializer xmlSerializer = new XmlSerializer(typeof(MemberXMLModel));
                            /*try
                            {*/
                            using (StringWriter textWriter = new StringWriter())
                            {
                                xmlSerializer.Serialize(textWriter, thisXML);
                                thisMemberXML = textWriter.ToString(); // Memory exception here.
                            }
                            /*}
                            catch (Exception ex)
                            {
                                Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] ERROR: " + ex.StackTrace);

                                int exceptionID = LogExceptionAndEmail(sitexml, 0, ex);
                            }*/

                            // Save Member XML & include it in file list. File Name:  CountryCode_Registration_MemberID.XML
                            string memberfilename = string.Format("Member_{0}.XML", thisXML.Profile.MemberID);

                            string memberfilepath = string.Format("{0}{1}", ConfigurationManager.AppSettings["MemberXMLExportFolder"], memberfilename);
                            File.WriteAllText(memberfilepath, thisMemberXML.ToString());

                            fileslist.Add(new FileNames(thisXML.Profile.MemberID.ToString(), memberfilepath, memberfilename));
                        }

                        foreach (MemberFiles memberfile in MembersFilesList)
                        {
                            Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] About to Write Member File: " + memberfile.MemberFileId.ToString());


                            string memberfilename = string.Format("MemberFile_{0}_{1}_{2}", memberfile.MemberId, memberfile.MemberFileId, memberfile.MemberFileName);

                            string memberfilepath = string.Format("{0}{1}", ConfigurationManager.AppSettings["MemberXMLExportFolder"], memberfilename);

                            MemberFiles mf = MembersFilesService.GetByMemberFileId(memberfile.MemberFileId);
                            if (mf != null && mf.MemberFileContent != null)
                            {
                                File.WriteAllBytes(memberfilepath, mf.MemberFileContent);

                                fileslist.Add(new FileNames(memberfile.MemberFileId.ToString(), memberfilepath, memberfilename));
                            }
                        }

                        string errormsg = string.Empty;
                        bool blnFileUploaded = false;
                        if (sitexml.sftp)
                        {
                            blnFileUploaded = UploadTempFilesToSFTP(sitexml, fileslist, out errormsg);
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

                        int exceptionID = LogExceptionAndEmail(sitexml, 0, ex);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] ERROR: " + ex.Message + "\n" + ex.StackTrace);

                    int exceptionID = LogExceptionAndEmail(sitexml, 0, ex);

                }


            }
        }


        private SiteSettingReferences SiteSettingReferencesGet(int siteID)
        {
            int languageID = (int)PortalEnums.Languages.Language.English;
            bool isCustomClassification = false;
            string xmlFilesPath = ConfigurationManager.AppSettings["XMLFilesPath"];

            SiteSettingReferences ssr = new SiteSettingReferences();

            #region Countries

            List<Countries> CountryList = CountriesService.GetTranslatedCountries(languageID, xmlFilesPath);

            if (CountryList != null)
            {
                CountryList = CountryList.Where(c => c.Sequence != -1 && c.Abbr != "CC").OrderBy(c => c.CountryName).ToList();

                ssr.countries = (from c in CountryList select new ReferenceItem { id = c.CountryId, name = c.CountryName }).ToList();
            }

            #endregion

            #region Locations

            List<Location> LocationList = LocationService.GetTranslatedLocations(languageID, ssr.countries.Select(c => c.id).ToList(), xmlFilesPath);

            if (LocationList != null)
            {
                LocationList = LocationList.Where(c => c.Sequence != -1).OrderBy(c => c.LocationName).ToList();

                ssr.locations = (from c in LocationList select new ReferenceItem { id = c.LocationId, name = c.LocationName }).ToList();
            }

            #endregion

            #region Areas

            List<Area> AreaList = AreaService.GetTranslatedAreas(languageID, ssr.locations.Select(c => c.id).ToList(), xmlFilesPath);

            if (AreaList != null)
            {
                AreaList = AreaList.Where(c => c.Sequence != -1).OrderBy(c => c.AreaName).ToList();

                ssr.areas = (from c in AreaList select new ReferenceItem { id = c.AreaId, name = c.AreaName }).ToList();
            }

            #endregion

            #region CategoryID (Classification)

            List<Profession> ProfessionList = ProfessionService.GetTranslatedProfessions(languageID, siteID, xmlFilesPath, isCustomClassification);

            if (ProfessionList != null)
            {
                ProfessionList = ProfessionList.OrderBy(c => c.ProfessionName).ToList();

                ssr.professions = (from c in ProfessionList select new ReferenceItem { id = c.ProfessionId, name = c.ProfessionName }).ToList();
            }

            #endregion

            #region SubCategoryID (Sub-Classification)

            List<Roles> RoleList = RolesService.GetTranslatedRoles(languageID, ssr.professions.Select(c => c.id).ToList(), xmlFilesPath, isCustomClassification);

            if (RoleList != null)
            {
                RoleList = RoleList.OrderBy(c => c.RoleName).ToList();

                ssr.roles = (from c in RoleList select new ReferenceItem { id = c.RoleId, name = c.RoleName }).ToList();
            }

            #endregion

            #region Site Salary

            List<SiteSalaryType> SalaryList = SiteSalaryTypeService.Get_TranslatedSalaryType(languageID, siteID, xmlFilesPath);

            if (SalaryList != null)
            {
                SalaryList = SalaryList.OrderBy(c => c.SalaryTypeName).ToList();

                ssr.salary_type = (from c in SalaryList select new ReferenceItem { id = c.SalaryTypeId, name = c.SalaryTypeName }).ToList();
            }

            #endregion

            #region Work Type

            List<SiteWorkType> SiteWorkTypeList = SiteWorkTypeService.GetTranslatedWorkTypes(languageID, siteID, xmlFilesPath);

            if (SiteWorkTypeList != null)
            {
                SiteWorkTypeList = SiteWorkTypeList.OrderBy(c => c.SiteWorkTypeName).ToList();

                ssr.work_type = (from c in SiteWorkTypeList select new ReferenceItem { id = c.WorkTypeId, name = c.SiteWorkTypeName }).ToList();
            }

            #endregion

            #region Site URL

            // Get the default country from the Site Global settings
            string strSiteDefaultCountryCode = string.Empty;

            // Get the Site URL 
            SitesService sitesService = new SitesService();
            string strDomainName = sitesService.GetBySiteId(siteID).SiteUrl;

            using (TList<GlobalSettings> gslist = new GlobalSettingsService().GetBySiteId(siteID))
            {
                if (gslist.Count > 0)
                {

                    strDomainName = (gslist[0].EnableSsl ? "https://" : "http://") + strDomainName;

                    if (gslist[0].DefaultCountryId.HasValue)
                    {
                        using (Countries countries = new CountriesService().GetByCountryId(gslist[0].DefaultCountryId.Value))
                        {
                            // Get the default site country code
                            if (countries != null)
                                strSiteDefaultCountryCode = countries.Abbr;
                        }
                    }
                }
            }

            ssr.siteURL = strDomainName;
            ssr.siteCountryCode = strSiteDefaultCountryCode;

            #endregion

            return ssr;
        }

        private void SetFileContentsForMemberXML(int siteID, MemberXMLModel memberXML)
        {
            foreach (MemberXMLModel.MemberFile file in memberXML.Files)
            {
                using (JXTPortal.Entities.MemberFiles memberFile = MembersFilesService.GetByMemberFileId(int.Parse(file.MemberFileID)))
                {
                    if (memberFile != null)
                    {
                        int membersiteid = siteID;

                        string errormessage = string.Empty;
                        byte[] memberfilecontent = null;

                        if (!string.IsNullOrWhiteSpace(memberFile.MemberFileUrl))
                        {

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
                            file.Base64FileContent = Convert.ToBase64String(memberfilecontent, 0, memberfilecontent.Length);
                        }
                    }
                }
            }
        }

        private List<MemberXMLModel.MemberCustomQuestion> GetCustomQuestions(int siteID, int memberID)
        {
            // MemberWizard
            TList<JXTPortal.Entities.MemberWizard> memberwizardlist = null;
            List<MemberXMLModel.MemberCustomQuestion> customquestionlist;
            using (memberwizardlist = MemberWizardService.GetBySiteId(siteID))
            {

                memberwizardlist.Filter = "GlobalTemplate = false";
                customquestionlist = new List<MemberXMLModel.MemberCustomQuestion>();

                if (memberwizardlist.Count > 0)
                {
                    JXTPortal.Entities.MemberWizard memberwizard = memberwizardlist[0];
                    string customquestionxml = memberwizard.CustomQuestionsXml;

                    string customquestionanswer = string.Empty;

                    using (JXTPortal.Entities.Members member = MembersService.GetByMemberId(memberID))
                    {
                        if (member != null)
                        {
                            customquestionanswer = member.ProfileDataXml;
                        }
                    }


                    try
                    {
                        if (!string.IsNullOrWhiteSpace(customquestionxml))
                        {
                            XmlDocument customquestions = new XmlDocument();
                            customquestions.LoadXml(customquestionxml);

                            foreach (XmlNode questionnode in customquestions.SelectNodes("CustomQuestions/Question"))
                            {
                                if (questionnode["Status"].InnerXml == "1")
                                {
                                    MemberXMLModel.MemberCustomQuestion question = new MemberXMLModel.MemberCustomQuestion();

                                    question.Id = Convert.ToInt32(questionnode["Id"].InnerXml);
                                    XmlNode languagesnode = questionnode["Languages"];
                                    foreach (XmlNode languagenode in languagesnode.SelectNodes("Language"))
                                    {
                                        if (languagenode["Id"].InnerXml == "1") //hardcoded to 1 as English
                                        {
                                            List<string> parameters = new List<string>();

                                            question.Title = WebUtility.HtmlDecode(languagenode["Title"].InnerXml);
                                            string parametersstring = string.Empty;

                                            XmlNode paramsnode = languagenode.SelectSingleNode("Parameters");
                                            if (!string.IsNullOrWhiteSpace(paramsnode.InnerXml))
                                            {
                                                question.Parameters = new List<string>();

                                                foreach (XmlNode itemnode in paramsnode.SelectNodes("Item"))
                                                {
                                                    question.Parameters.Add(WebUtility.HtmlDecode(itemnode.InnerXml));
                                                }
                                            }
                                        }
                                    }

                                    question.MemberID = memberID;
                                    question.Type = questionnode["Type"].InnerXml;
                                    question.Sequence = Convert.ToInt32(questionnode["Sequence"].InnerXml);
                                    question.Mandatory = Convert.ToBoolean(questionnode["Mandatory"].InnerXml);
                                    question._Answers = GetCustomQuestionAnswer(customquestionanswer, Convert.ToInt32(question.Id));
                                    question.TempAnswer = GetCustomQuestionAnswer(customquestionanswer, Convert.ToInt32(question.Id));
                                    question.IsError = false;

                                    customquestionlist.Add(question);
                                }

                            }

                            customquestionlist = customquestionlist.OrderBy(q => q.Sequence).ToList();


                        }
                    }
                    catch { }

                }
            }
            return customquestionlist;
        }

        private string GetCustomQuestionAnswer(string xml, int questionid)
        {
            string value = string.Empty;

            if (!string.IsNullOrWhiteSpace(xml))
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(xml);

                foreach (XmlNode answernode in xmldoc.GetElementsByTagName("Answer"))
                {
                    if (answernode["Id"].InnerText == questionid.ToString())
                    {
                        value = answernode["Value"].InnerText;
                        break;
                    }
                }
            }

            return value;
        }

    }
}
