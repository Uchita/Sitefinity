using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using log4net;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;
using JXTPortal.Entities;
using JXTPortal.Common.Extensions;
using System.Text.RegularExpressions;
using System.Configuration;
using JXTPortal.Client.Salesforce;
using System.IO;
using JXTPortal.Common;
using System.Xml;
using System.Text;
using JXTPortal.Entities.Models;
using SocialMedia;

namespace JXTPortal.Website
{
    /// <summary>
    /// Summary description for jxtMethods
    /// </summary>
    [WebService(Namespace = "http://www.jobx.com.au/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class jxtMethods : System.Web.Services.WebService
    {
        private string bucketName = ConfigurationManager.AppSettings["AWSS3BucketName"];
        private string privateBucketName = ConfigurationManager.AppSettings["AWSS3PrivateBucketName"];
        private string memberFileFolder;
        private string memberFileFolderFormat;

        ILog _logger;
        public IFileManager FileManagerService { get; set; }

        #region Properties
        private MembersService _membersService = null;
        private MembersService MembersService
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

        private MemberFilesService _memberFilesService = null;
        private MemberFilesService MemberFilesService
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

        private GlobalSettingsService _globalSettingsService = null;
        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_globalSettingsService == null)
                {
                    _globalSettingsService = new GlobalSettingsService();
                }
                return _globalSettingsService;
            }
        }

        private SiteLanguagesService _siteLanguagesService = null;
        private SiteLanguagesService SiteLanguagesService
        {
            get
            {
                if (_siteLanguagesService == null)
                {
                    _siteLanguagesService = new SiteLanguagesService();
                }
                return _siteLanguagesService;
            }
        }

        private CountriesService _countriesService;
        private CountriesService CountriesService
        {
            get
            {
                if (_countriesService == null)
                    _countriesService = new CountriesService();
                return _countriesService;
            }
        }

        private SiteProfessionService _siteProfessionService;
        private SiteProfessionService SiteProfessionService
        {
            get
            {
                if (_siteProfessionService == null)
                {
                    _siteProfessionService = new SiteProfessionService();
                }
                return _siteProfessionService;
            }
        }

        private SiteRolesService _siteRolesService;
        private SiteRolesService SiteRolesService
        {
            get
            {
                if (_siteRolesService == null)
                {
                    _siteRolesService = new SiteRolesService();
                }
                return _siteRolesService;
            }
        }

        private MemberWizardService _memberWizardService;
        private MemberWizardService MemberWizardService
        {
            get
            {
                if (_memberWizardService == null)
                {
                    _memberWizardService = new MemberWizardService();
                }
                return _memberWizardService;
            }
        }

        private JobApplicationService _jobApplicationService;
        private JobApplicationService JobApplicationService
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

        private JobsService _jobsService;
        private JobsService JobsService
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

        private ViewJobsService _viewJobsService;
        private ViewJobsService ViewJobsService
        {
            get
            {
                if (_viewJobsService == null)
                {
                    _viewJobsService = new ViewJobsService();
                }
                return _viewJobsService;
            }
        }

        private IntegrationsService _integrationsService;
        private IntegrationsService IntegrationsService
        {
            get
            {
                if (_integrationsService == null)
                {
                    _integrationsService = new IntegrationsService();
                }

                return _integrationsService;
            }
        }
        #endregion 

        public jxtMethods()
        {
            _logger = LogManager.GetLogger(typeof(jxtMethods));

            if (!SessionData.Site.IsUsingS3)
            {
                memberFileFolder = ConfigurationManager.AppSettings["FTPHost"] + ConfigurationManager.AppSettings["MemberRootFolder"] + "/" + ConfigurationManager.AppSettings["MemberFilesFolder"];
                memberFileFolderFormat = "{0}/{1}/";

                string ftphosturl = ConfigurationManager.AppSettings["FTPHost"];
                string ftpusername = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                string ftppassword = ConfigurationManager.AppSettings["FTPJobApplyPassword"];
                FileManagerService = new FTPClientFileManager(ftphosturl, ftpusername, ftppassword);
            }
            else
            {
                memberFileFolderFormat = "{0}/{1}";
                memberFileFolder = ConfigurationManager.AppSettings["AWSS3MemberRootFolder"] + ConfigurationManager.AppSettings["AWSS3MemberFilesFolder"];
            }
        }

        private int MemberFileTypeID(string filename)
        {
            int _memberFileTypeID = 0;

            MemberFileTypesService MemberFileTypesService = new MemberFileTypesService();
            using (TList<Entities.MemberFileTypes> objMemberFileTypes = MemberFileTypesService.GetAll())
            {

                Entities.MemberFileTypes objMemberFileType = objMemberFileTypes.Find("MemberFileExtensions", System.IO.Path.GetExtension(filename).Trim());

                if (objMemberFileType != null)
                {
                    _memberFileTypeID = objMemberFileType.MemberFileTypeId;
                }

            }
            return _memberFileTypeID;
        }

        protected bool uploadFile(int memberID, HttpPostedFile file, out int memberFileId)
        {
            _logger.Debug("Start uploading Member File");
            bool hasUploadedFile = false;
            memberFileId = 0;

            using (Entities.MemberFiles objMemberFiles = new Entities.MemberFiles())
            {
                int memberFileTypeID = MemberFileTypeID(file.FileName);
                if (memberFileTypeID > 0)
                {
                    foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                    {
                        objMemberFiles.MemberFileName = System.IO.Path.GetFileName(file.FileName).Trim().Replace(c.ToString(), "");
                    }
                    objMemberFiles.MemberFileSearchExtension = System.IO.Path.GetExtension(file.FileName).Trim();

                    objMemberFiles.MemberFileTitle = objMemberFiles.MemberFileName;
                    objMemberFiles.MemberId = memberID;
                    objMemberFiles.MemberFileTypeId = memberFileTypeID;
                    objMemberFiles.DocumentTypeId = (int)PortalEnums.Members.MemberFileTypes.Resume;  // Document type is Resume 

                    MemberFilesService.Insert(objMemberFiles);
                    memberFileId = objMemberFiles.MemberFileId;

                    string extension = string.Empty;

                    extension = Path.GetExtension(file.FileName);
                    string filepath = string.Format("MemberFiles_{0}{1}", objMemberFiles.MemberFileId, extension);
                    string errormessage = string.Empty;

                    FileManagerService.UploadFile(bucketName, string.Format(memberFileFolderFormat, memberFileFolder, memberID), filepath, file.InputStream, out errormessage);
                    _logger.DebugFormat("{0} Upload Reponse: {1}", filepath, errormessage);

                    if (string.IsNullOrEmpty(errormessage))
                    {
                        objMemberFiles.MemberFileUrl = string.Format("MemberFiles_{0}{1}", objMemberFiles.MemberFileId, extension);

                        MemberFilesService.Update(objMemberFiles);

                        hasUploadedFile = true;
                    }
                }
            }

            return hasUploadedFile;
        }

        private void MemberRegisterErrorCheck(WebResponse response)
        {
            _logger.Debug("Start Member Register Error Checking");

            DateTime dob = DateTime.Now;
            string emailRegex = ConfigurationManager.AppSettings["EmailValidationRegex"];
            string phoneRegex = @"^[ \+\(\)\d]*$";
            string passwordRegex = @"^(?=.{8,}$)(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).*$";

            string title = HttpContext.Current.Request["title"];
            string emailFormat = HttpContext.Current.Request["emailformat"];
            string dateOfBirth = HttpContext.Current.Request["dateofbirth"];
            string firstName = HttpContext.Current.Request["firstname"];
            string surname = HttpContext.Current.Request["surname"];
            string multilingualFirstName = HttpContext.Current.Request["multilingualfirstname"];
            string multilingualSurname = HttpContext.Current.Request["multilingualsurname"];
            string userName = HttpContext.Current.Request["username"];
            string password = HttpContext.Current.Request["password"];
            string confirmPassword = HttpContext.Current.Request["confirmpassword"];
            string email = HttpContext.Current.Request["email"];
            string confirmEmail = HttpContext.Current.Request["confirmemail"];
            string homePhone = HttpContext.Current.Request["homephone"];
            string workPhone = HttpContext.Current.Request["workphone"];
            string mobilePhone = HttpContext.Current.Request["mobilephone"];
            string address = HttpContext.Current.Request["address"];
            string suburb = HttpContext.Current.Request["suburb"];
            string postcode = HttpContext.Current.Request["postcode"];
            string state = HttpContext.Current.Request["state"];
            string country = HttpContext.Current.Request["country"];
            string mailingAddress = HttpContext.Current.Request["mailingaddress"];
            string mailingPostcode = HttpContext.Current.Request["mailingpostcode"];
            string mailingState = HttpContext.Current.Request["mailingstate"];
            string mailingSuburb = HttpContext.Current.Request["mailingsuburb"];
            string mailingCountry = HttpContext.Current.Request["mailingcountry"];
            string profession = HttpContext.Current.Request["profession"];
            string role = HttpContext.Current.Request["role"];
            string passport = HttpContext.Current.Request["passport"];
            string language = HttpContext.Current.Request["language"];
            HttpPostedFile coverletter = HttpContext.Current.Request.Files["coverletter"];
            HttpPostedFile resume = HttpContext.Current.Request.Files["resume"];

            if (string.IsNullOrWhiteSpace(title))
            {
                response.Error.Add(new WebResponseError { Name = "title", Message = CommonFunction.GetResourceValue("LabelTitleRequired") });
            }
            else
            {
                if (title != "Mr" && title != "Mrs" && title != "Ms" && title != "Miss" && title != "Dr" && title != "Professor" && title != "Other")
                {
                    response.Error.Add(new WebResponseError { Name = "title", Message = CommonFunction.GetResourceValue("LabelInvalidTitle") });
                }
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                response.Error.Add(new WebResponseError { Name = "firstname", Message = CommonFunction.GetResourceValue("LabelFirstnameRequired") });
            }
            else
            {
                if (!firstName.IsValidContent())
                {
                    response.Error.Add(new WebResponseError { Name = "firstname", Message = CommonFunction.GetResourceValue("ValidateNoHTMLContent") });
                }
            }

            if (string.IsNullOrWhiteSpace(surname))
            {
                response.Error.Add(new WebResponseError { Name = "surname", Message = CommonFunction.GetResourceValue("LabelSurnameRequired") });
            }
            else
            {
                if (!surname.IsValidContent())
                {
                    response.Error.Add(new WebResponseError { Name = "surname", Message = CommonFunction.GetResourceValue("ValidateNoHTMLContent") });
                }
            }

            if (string.IsNullOrWhiteSpace(userName))
            {
                response.Error.Add(new WebResponseError { Name = "username", Message = CommonFunction.GetResourceValue("LabelUsernameRequired") });
            }
            else
            {
                if (!userName.IsValidContent())
                {
                    response.Error.Add(new WebResponseError { Name = "username", Message = CommonFunction.GetResourceValue("ValidateNoHTMLContent") });
                }
            }

            if (string.IsNullOrEmpty(password))
            {
                response.Error.Add(new WebResponseError { Name = "password", Message = CommonFunction.GetResourceValue("labellPasswordRequired") });
            }
            else
            {
                Regex regex = new Regex(passwordRegex);

                if (!regex.IsMatch(password))
                {
                    response.Error.Add(new WebResponseError { Name = "password", Message = CommonFunction.GetResourceValue("LabelPasswordPrompt") });
                }
            }

            if (string.IsNullOrEmpty(confirmPassword))
            {
                response.Error.Add(new WebResponseError { Name = "confirmpassword", Message = CommonFunction.GetResourceValue("LabelPasswordNotMatch") });
            }

            if (string.IsNullOrEmpty(password) == false && string.IsNullOrEmpty(confirmPassword) == false && password != confirmPassword)
            {
                response.Error.Add(new WebResponseError { Name = "confirmpassword", Message = CommonFunction.GetResourceValue("LabelPasswordNotMatch") });
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                response.Error.Add(new WebResponseError { Name = "email", Message = CommonFunction.GetResourceValue("LabelValidEmailRequired") });
            }
            else
            {
                Regex regex = new Regex(emailRegex);
                if (!regex.IsMatch(email))
                {
                    response.Error.Add(new WebResponseError { Name = "email", Message = CommonFunction.GetResourceValue("LabelValidEmailRequired") });
                }
                else
                {
                    if (email != confirmEmail)
                    {
                        response.Error.Add(new WebResponseError { Name = "confirmemail", Message = CommonFunction.GetResourceValue("LabelEmalAddressNotMatch") });
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(emailFormat))
            {
                response.Error.Add(new WebResponseError { Name = "emailformat", Message = CommonFunction.GetResourceValue("LabelRequiredField1") });
            }
            else
            {
                if (emailFormat != ((int)PortalEnums.Email.EmailFormat.HTML).ToString() && emailFormat != ((int)PortalEnums.Email.EmailFormat.Text).ToString())
                {
                    response.Error.Add(new WebResponseError { Name = "emailformat", Message = CommonFunction.GetResourceValue("LabelInvalidEmailFormat") });
                }
            }

            if (!string.IsNullOrWhiteSpace(dateOfBirth) && !DateTime.TryParseExact(dateOfBirth, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out dob))
            {
                response.Error.Add(new WebResponseError { Name = "dateofbirth", Message = CommonFunction.GetResourceValue("LabelInvalidDate") });
            }

            if (!multilingualFirstName.IsValidContent(true))
            {
                response.Error.Add(new WebResponseError { Name = "multilingualfirstname", Message = CommonFunction.GetResourceValue("ValidateNoHTMLContent") });
            }

            if (!multilingualSurname.IsValidContent(true))
            {
                response.Error.Add(new WebResponseError { Name = "multilingualsurname", Message = CommonFunction.GetResourceValue("ValidateNoHTMLContent") });
            }

            if (!address.IsValidContent(true))
            {
                response.Error.Add(new WebResponseError { Name = "address", Message = CommonFunction.GetResourceValue("ValidateNoHTMLContent") });
            }
            else
            {
                if (address.Length > 1500)
                {
                    response.Error.Add(new WebResponseError { Name = "address", Message = CommonFunction.GetResourceValue("LabelEnterMaxAddress") });
                }
            }

            if (!suburb.IsValidContent(true))
            {
                response.Error.Add(new WebResponseError { Name = "suburb", Message = CommonFunction.GetResourceValue("ValidateNoHTMLContent") });
            }
            else
            {
                if (suburb.Length > 20)
                {
                    response.Error.Add(new WebResponseError { Name = "suburb", Message = CommonFunction.GetResourceValue("LabelEnterMaxSuburb") });
                }
            }

            if (!postcode.IsValidContent(true))
            {
                response.Error.Add(new WebResponseError { Name = "postcode", Message = CommonFunction.GetResourceValue("ValidateNoHTMLContent") });
            }
            else
            {
                if (postcode.Length > 10)
                {
                    response.Error.Add(new WebResponseError { Name = "postcode", Message = CommonFunction.GetResourceValue("LabelEnterMaxPostcode") });
                }
            }

            if (!state.IsValidContent(true))
            {
                response.Error.Add(new WebResponseError { Name = "state", Message = CommonFunction.GetResourceValue("ValidateNoHTMLContent") });
            }
            else
            {
                if (state.Length > 10)
                {
                    response.Error.Add(new WebResponseError { Name = "state", Message = CommonFunction.GetResourceValue("LabelEnterMaxState") });
                }
            }

            if (!mailingAddress.IsValidContent(true))
            {
                response.Error.Add(new WebResponseError { Name = "mailingaddress", Message = CommonFunction.GetResourceValue("ValidateNoHTMLContent") });
            }
            else
            {
                if (mailingAddress.Length > 1500)
                {
                    response.Error.Add(new WebResponseError { Name = "mailingaddress", Message = CommonFunction.GetResourceValue("LabelEnterMaxMailingAddress") });
                }
            }

            if (!mailingPostcode.IsValidContent())
            {
                response.Error.Add(new WebResponseError { Name = "mailingpostcode", Message = CommonFunction.GetResourceValue("ValidateNoHTMLContent") });
            }
            else
            {
                if (mailingPostcode.Length > 10)
                {
                    response.Error.Add(new WebResponseError { Name = "mailingpostcode", Message = CommonFunction.GetResourceValue("LabelEnterMaxPostcode") });
                }
            }

            if (!mailingState.IsValidContent())
            {
                response.Error.Add(new WebResponseError { Name = "mailingstate", Message = CommonFunction.GetResourceValue("ValidateNoHTMLContent") });
            }
            else
            {
                if (mailingState.Length > 10)
                {
                    response.Error.Add(new WebResponseError { Name = "mailingstate", Message = CommonFunction.GetResourceValue("LabelEnterMaxMailingState") });
                }
            }

            if (!mailingSuburb.IsValidContent())
            {
                response.Error.Add(new WebResponseError { Name = "mailingsuburb", Message = CommonFunction.GetResourceValue("ValidateNoHTMLContent") });
            }
            else
            {
                if (mailingSuburb.Length > 20)
                {
                    response.Error.Add(new WebResponseError { Name = "mailingsuburb", Message = CommonFunction.GetResourceValue("LabelEnterMaxMailingSuburb") });
                }
            }

            SiteLanguages sitelanguage = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId).Where(x => x.LanguageId.ToString() == language).FirstOrDefault();
            if (sitelanguage == null)
            {
                response.Error.Add(new WebResponseError { Name = "language", Message = CommonFunction.GetResourceValue("LabelInvalidLanguage") });
            }

            if (!string.IsNullOrEmpty(country))
            {
                Countries selectedCountry = CountriesService.GetTranslatedCountries(SessionData.Language.LanguageId).Where(c => c.Sequence != -1 && c.CountryId.ToString() == country).FirstOrDefault();
                if (selectedCountry == null)
                {
                    response.Error.Add(new WebResponseError { Name = "country", Message = CommonFunction.GetResourceValue("LabelInvalidCountry") });
                }
            }

            if (!string.IsNullOrEmpty(profession))
            {
                Entities.SiteProfession selectedProfession = SiteProfessionService.GetTranslatedProfessions(SessionData.Site.SiteId, SessionData.Site.UseCustomProfessionRole).Where(p => p.ProfessionId.ToString() == profession).FirstOrDefault();
                if (selectedProfession == null)
                {
                    response.Error.Add(new WebResponseError { Name = "profession", Message = CommonFunction.GetResourceValue("LabelInvalidProfession") });
                }
                else
                {
                    if (!string.IsNullOrEmpty(role))
                    {
                        Entities.SiteRoles selectedRole = SiteRolesService.GetTranslatedByProfessionID(Convert.ToInt32(profession), SessionData.Site.UseCustomProfessionRole).Where(p => p.RoleId.ToString() == role).FirstOrDefault();
                        if (selectedRole == null)
                        {
                            response.Error.Add(new WebResponseError { Name = "role", Message = CommonFunction.GetResourceValue("LabelInvalidRole") });
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(homePhone))
            {
                Regex regex = new Regex(phoneRegex);
                if (!regex.IsMatch(homePhone))
                {
                    response.Error.Add(new WebResponseError { Name = "homephone", Message = CommonFunction.GetResourceValue("ValidationPhoneNumbers") });
                }
            }

            if (!string.IsNullOrEmpty(workPhone))
            {
                Regex regex = new Regex(phoneRegex);
                if (!regex.IsMatch(workPhone))
                {
                    response.Error.Add(new WebResponseError { Name = "workphone", Message = CommonFunction.GetResourceValue("ValidationPhoneNumbers") });
                }
            }

            if (!string.IsNullOrEmpty(mobilePhone))
            {
                Regex regex = new Regex(phoneRegex);
                if (!regex.IsMatch(mobilePhone))
                {
                    response.Error.Add(new WebResponseError { Name = "mobilephone", Message = CommonFunction.GetResourceValue("ValidationPhoneNumbers") });
                }
            }


            // Resume

            if (resume != null)
            {
                if (!CommonFunction.CheckExtension(resume.FileName))
                {
                    response.Error.Add(new WebResponseError { Name = "resume", Message = CommonFunction.GetResourceValue("ErrorFileExtension") });
                }
            }

            // Cover Letter
            if (coverletter != null)
            {
                if (!CommonFunction.CheckExtension(coverletter.FileName))
                {
                    response.Error.Add(new WebResponseError { Name = "coverletter", Message = CommonFunction.GetResourceValue("ErrorFileExtension") });
                }
            }

            // Shouldn't go further if error already exisits
            _logger.DebugFormat("Error Count on Frontend: {0}", response.Error.Count);

            if (response.Error.Count > 0) return;

            try
            {
                // Username

                if (MembersService.GetBySiteIdUsername(SessionData.Site.MasterSiteId, userName) != null)
                {
                    response.Error.Add(new WebResponseError { Name = "username", Message = CommonFunction.GetResourceValue("ErrorUsernameExist") });
                }

                // Email
                if (MembersService.GetBySiteIdEmailAddress(SessionData.Site.MasterSiteId, email) != null)
                {
                    response.Error.Add(new WebResponseError { Name = "email", Message = CommonFunction.GetResourceValue("LabelEmailAddressExist") });
                }
                else
                {
                    // If Enworld then ignore checking Salesforce
                    if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["EnworldSiteID"]) && !(ConfigurationManager.AppSettings["EnworldSiteID"].Contains(" " + SessionData.Site.MasterSiteId + " ")))
                    {
                        // Sites which has SALESFORCE enabled - If exists from Sales force then save in the platform then alert the email already exists.
                        int memberid = 0; string errormsg = string.Empty;
                        SalesforceMemberSync memberSync = new SalesforceMemberSync();
                        if (memberSync.GetContactFromSalesForceAndSave(email, string.Empty, SessionData.Site.MasterSiteId, ref memberid, ref errormsg))
                        {
                            response.Error.Add(new WebResponseError { Name = "email", Message = CommonFunction.GetResourceValue("LabelEmailAddressExist") });
                        }
                    }
                }

                // Custom Questions
                List<CustomQuestionsData> customQuestions = new List<CustomQuestionsData>();
                Entities.MemberWizard memberWizard = MemberWizardService.GetBySiteId(SessionData.Site.SiteId).Where(m => m.GlobalTemplate == false).FirstOrDefault();
                if (memberWizard != null)
                {
                    string customQuestionXml = memberWizard.CustomQuestionsXml;


                    XmlDocument customquestions = new XmlDocument();
                    customquestions.LoadXml(customQuestionXml);

                    foreach (XmlNode questionNode in customquestions.SelectNodes("CustomQuestions/Question"))
                    {
                        if (questionNode["Status"].InnerXml == "1")
                        {
                            customQuestions.Add(new CustomQuestionsData { Id = questionNode["Id"].InnerXml, Type = questionNode["Type"].InnerXml, Mandatory = Convert.ToBoolean(questionNode["Mandatory"].InnerXml) });
                        }
                    }
                }

                if (customQuestions.Count > 0)
                {
                    foreach (string key in HttpContext.Current.Request.Params.AllKeys)
                    {
                        if (key != null && key.Contains("customquestion_"))
                        {
                            string answer = HttpContext.Current.Request.Params[key];
                            string[] keysplit = key.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                            string questionid = keysplit[keysplit.Length - 1];

                            CustomQuestionsData customQuestionData = customQuestions.Where(c => c.Id.ToString() == questionid).FirstOrDefault();
                            if (customQuestionData != null)
                            {
                                if (!answer.IsValidContent())
                                {
                                    response.Error.Add(new WebResponseError { Name = key, Message = CommonFunction.GetResourceValue("ValidateNoHTMLContent") });
                                }
                                else
                                {
                                    if (customQuestionData.Mandatory && string.IsNullOrWhiteSpace(answer))
                                    {
                                        response.Error.Add(new WebResponseError { Name = key, Message = CommonFunction.GetResourceValue("LabelRequiredField1") });
                                    }
                                }
                            }
                            else
                            {
                                response.Error.Add(new WebResponseError { Name = key, Message = CommonFunction.GetResourceValue("LabelInvalidCustomQuestion") });
                            }
                        }
                    }
                }

                _logger.DebugFormat("Error Count on Backend: {0}", response.Error.Count);
            }
            catch (Exception ex)
            {
                response.Error.Add(new WebResponseError { Name = "exception", Message = ex.Message });
                _logger.Debug("Error in Registration Backend Checking", ex);
            }
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void MemberRegister()
        {
            _logger.Debug("Start Member Register");
            DateTime dob = DateTime.Now;

            string title = HttpContext.Current.Request["title"];
            string emailFormat = HttpContext.Current.Request["emailformat"];
            string dateOfBirth = HttpContext.Current.Request["dateofbirth"];
            string firstName = HttpContext.Current.Request["firstname"];
            string surname = HttpContext.Current.Request["surname"];
            string multilingualFirstName = HttpContext.Current.Request["multilingualfirstname"];
            string multilingualSurname = HttpContext.Current.Request["multilingualsurname"];
            string userName = HttpContext.Current.Request["username"];
            string password = HttpContext.Current.Request["password"];
            string confirmPassword = HttpContext.Current.Request["confirmpassword"];
            string homePhone = HttpContext.Current.Request["homephone"];
            string workPhone = HttpContext.Current.Request["workphone"];
            string mobilePhone = HttpContext.Current.Request["mobilephone"];
            string email = HttpContext.Current.Request["email"];
            string confirmEmail = HttpContext.Current.Request["confirmemail"];
            string address = HttpContext.Current.Request["address"];
            string suburb = HttpContext.Current.Request["suburb"];
            string postcode = HttpContext.Current.Request["postcode"];
            string state = HttpContext.Current.Request["state"];
            string country = HttpContext.Current.Request["country"];
            string mailingAddress = HttpContext.Current.Request["mailingaddress"];
            string mailingPostcode = HttpContext.Current.Request["mailingpostcode"];
            string mailingState = HttpContext.Current.Request["mailingstate"];
            string mailingSuburb = HttpContext.Current.Request["mailingsuburb"];
            string mailingCountry = HttpContext.Current.Request["mailingcountry"];
            string profession = HttpContext.Current.Request["profession"];
            string role = HttpContext.Current.Request["role"];
            string professionText = HttpContext.Current.Request["professiontext"];
            string roleText = HttpContext.Current.Request["roletext"];
            string passport = HttpContext.Current.Request["passport"];
            string language = HttpContext.Current.Request["language"];
            HttpPostedFile coverletter = HttpContext.Current.Request.Files["coverletter"];
            HttpPostedFile resume = HttpContext.Current.Request.Files["resume"];

            WebResponse response = new WebResponse { Success = false, Data = new List<WebResponseData>(), Error = new List<WebResponseError>() };
            MemberRegisterErrorCheck(response);
            if (response.Error.Count == 0)
            {
                _logger.Debug("No Error on Error Checking");

                JXTPortal.Entities.Members member = new JXTPortal.Entities.Members();
                int resumeFileId = 0, coverletterFileId = 0;
                try
                {
                    if (!string.IsNullOrWhiteSpace(dateOfBirth))
                    {
                        DateTime.TryParseExact(dateOfBirth, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out dob);
                    }
                    _logger.Debug("Start assigning value into member entity");
                    member.SiteId = SessionData.Site.MasterSiteId;
                    member.Username = userName;
                    member.Password = CommonService.EncryptMD5(password);
                    member.EmailAddress = email;
                    member.Title = title;
                    member.FirstName = firstName;
                    member.Surname = surname;
                    member.MultiLingualFirstName = multilingualFirstName;
                    member.MultiLingualSurame = multilingualSurname;
                    member.DateOfBirth = (!string.IsNullOrWhiteSpace(dateOfBirth)) ? dob : (DateTime?)null;
                    member.HomePhone = homePhone;
                    member.WorkPhone = workPhone;
                    member.MobilePhone = mobilePhone;
                    member.Address1 = address;
                    member.Suburb = suburb;
                    member.PostCode = postcode;
                    member.States = state;

                    member.PreferredCategoryId = profession;
                    member.PreferredSubCategoryId = role;
                    member.PassportNo = passport;
                    member.DefaultLanguageId = Convert.ToInt32(language);
                    //Set default country to Australia if nothing is selected
                    if (country != "")
                    {
                        member.CountryId = Convert.ToInt32(country);
                    }
                    else
                    {
                        using (TList<GlobalSettings> gslist = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
                        {
                            if (gslist[0].DefaultCountryId.HasValue)
                                member.CountryId = gslist[0].DefaultCountryId.Value;
                        }
                    }

                    member.MailingAddress1 = mailingAddress;
                    member.MailingSuburb = mailingSuburb;
                    member.MailingPostCode = mailingPostcode;
                    member.MailingStates = mailingState;
                    member.MailingCountryId = 1;
                    //Set default country to Australia if nothing is selected
                    if (mailingCountry != "")
                    {
                        member.MailingCountryId = Convert.ToInt32(mailingCountry);
                    }
                    else
                    {
                        member.MailingCountryId = (int?)null;
                    }

                    member.EmailFormat = Convert.ToInt32(emailFormat);
                    member.ValidateGuid = Guid.NewGuid();
                    member.SearchField = String.Format("{0} {1}",
                                               member.FirstName,
                                               member.Surname);
                    member.ReferringSiteId = SessionData.Site.SiteId;

                    // Custom Question
                    List<CustomQuestionAnswer> customquestionanswers = new List<CustomQuestionAnswer>();

                    foreach (string key in HttpContext.Current.Request.Params.AllKeys)
                    {
                        if (key != null && key.Contains("customquestion_"))
                        {
                            CustomQuestionAnswer customquestionanswer = new CustomQuestionAnswer();
                            string type = "";

                            string answer = HttpContext.Current.Request.Params[key];
                            string[] keysplit = key.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                            string questionid = keysplit[keysplit.Length - 1];

                            if (key.Contains("textbox")) type = "textbox";
                            if (key.Contains("textarea")) type = "textarea";
                            if (key.Contains("dropdown")) type = "dropdown";
                            if (key.Contains("multiselect")) type = "multiselect";
                            if (key.Contains("radio")) type = "radio";

                            customquestionanswer.Id = Convert.ToInt32(questionid);
                            customquestionanswer.Type = type;
                            customquestionanswer.Value = answer;

                            customquestionanswers.Add(customquestionanswer);
                        }
                    }

                    // Construct Answer XML
                    StringBuilder sbAnswer = new StringBuilder();

                    if (customquestionanswers.Count > 0)
                    {
                        sbAnswer.AppendLine("<Answers>");

                        foreach (CustomQuestionAnswer answer in customquestionanswers)
                        {
                            sbAnswer.AppendFormat(@"<Answer>
                                                <Id>{0}</Id>
                                                <Type>{1}</Type>
                                                <Value>{2}</Value>
                                            </Answer>", answer.Id, answer.Type, Utils.XmlEncode(answer.Value));
                        }

                        sbAnswer.AppendLine("</Answers>");
                    }

                    member.ProfileDataXml = sbAnswer.ToString();
                    //Insert into Members
                    MembersService.Insert(member);
                    _logger.DebugFormat("Member Inserted. MemberId: {0}", member.MemberId);


                    // If user uploaded Resume then Upload file.
                    List<HttpPostedFile> filesposted = new List<HttpPostedFile>();

                    if (resume != null)
                    {
                        if (uploadFile(member.MemberId, resume, out resumeFileId))
                        {
                            filesposted.Add(resume);
                        }
                        else
                        {
                            _logger.DebugFormat("Resume Upload Failed");
                            response.Error.Add(new WebResponseError { Name = "resume", Message = "Failed to upload resume" });
                            MembersService.Delete(member);
                            _logger.DebugFormat("Member Deleted");
                            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(response));

                            return;
                        }
                    }

                    if (coverletter != null)
                    {
                        if (uploadFile(member.MemberId, coverletter, out coverletterFileId))
                        {
                            filesposted.Add(coverletter);
                        }
                        else
                        {
                            _logger.Debug("Cover Letter Upload Failed");
                            response.Error.Add(new WebResponseError { Name = "coverletter", Message = "Failed to upload coverletter" });

                            if (resumeFileId > 0)
                            {
                                MemberFilesService.Delete(resumeFileId);
                                _logger.Debug("Resume Deleted");
                            }

                            MembersService.Delete(member);
                            _logger.Debug("Member Deleted");
                            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(response));

                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(SessionData.Site.MemberRegistrationNotificationEmail))
                    {
                        //Send confirmation email to new member and site's admin
                        MailService.SendMemberRegistrationToSiteAdmin(member, ((profession == "0") ? string.Empty : professionText), ((role == "0") ? string.Empty : roleText), filesposted, SessionData.Site.MemberRegistrationNotificationEmail);
                        _logger.Debug("Email sent to Site Admin");
                    }

                    //Send confirmation email to new member
                    MailService.SendMemberRegistration(member, password);
                    _logger.Debug("Email sent to Member");

                    response.Success = true;
                    response.Data.Add(new WebResponseData { Value = "memberid", Text = member.MemberId.ToString() });
                }
                catch (Exception ex)
                {
                    _logger.Debug("Exception thrown in Member Registration", ex);

                    if (resumeFileId > 0)
                    {
                        MemberFilesService.Delete(resumeFileId);
                        _logger.Debug("Resume Deleted");
                    }

                    if (coverletterFileId > 0)
                    {
                        MemberFilesService.Delete(coverletterFileId);
                        _logger.Debug("Coverletter Deleted");
                    }

                    if (member.MemberId > 0)
                    {
                        MembersService.Delete(member);
                        _logger.Debug("Member Deleted");
                    }

                    response.Success = false;

                    response.Error.Add(new WebResponseError { Name = "exception", Message = ex.Message });
                }
            }

            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(response));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetSiteCountries()
        {
            WebResponse response = new WebResponse { Success = false, Data = new List<WebResponseData>(), Error = new List<WebResponseError>() };
            try
            {
                List<Countries> countries = CountriesService.GetTranslatedCountries(SessionData.Language.LanguageId);

                if (countries != null && countries.Count > 0)
                {
                    countries = countries.Where(c => c.Sequence != -1).OrderBy(c => c.CountryName).ToList();
                    if (countries.Count > 0)
                    {
                        response.Success = true;
                        foreach (Countries country in countries)
                        {
                            response.Data.Add(new WebResponseData { Value = country.CountryId.ToString(), Text = country.CountryName });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Debug("Error getting site countries", ex);
                response.Error.Add(new WebResponseError { Name = "exception", Message = ex.Message });
            }

            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(response));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetSiteProfession()
        {
            WebResponse response = new WebResponse { Success = false, Data = new List<WebResponseData>(), Error = new List<WebResponseError>() };

            try
            {
                List<Entities.SiteProfession> siteProfessions = SiteProfessionService.GetTranslatedProfessions(SessionData.Site.SiteId, SessionData.Site.UseCustomProfessionRole);
                if (siteProfessions != null && siteProfessions.Count > 0)
                {
                    response.Success = true;
                    foreach (Entities.SiteProfession siteProfession in siteProfessions)
                    {
                        response.Data.Add(new WebResponseData { Value = siteProfession.ProfessionId.ToString(), Text = siteProfession.SiteProfessionName });
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Debug("Error getting site profession", ex);
                response.Error.Add(new WebResponseError { Name = "exception", Message = ex.Message });
            }

            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(response));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void GetSiteRole(string professionid)
        {
            WebResponse response = new WebResponse { Success = false, Data = new List<WebResponseData>(), Error = new List<WebResponseError>() };

            try
            {
                List<Entities.SiteRoles> siteRoles = SiteRolesService.GetTranslatedByProfessionID(Convert.ToInt32(professionid), SessionData.Site.UseCustomProfessionRole);
                if (siteRoles != null && siteRoles.Count > 0)
                {
                    response.Success = true;
                    foreach (Entities.SiteRoles siteRole in siteRoles)
                    {
                        response.Data.Add(new WebResponseData { Value = siteRole.RoleId.ToString(), Text = siteRole.SiteRoleName });
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Debug("Error getting site role", ex);
                response.Error.Add(new WebResponseError { Name = "exception", Message = ex.Message });
            }

            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(response));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetSiteLanguage()
        {
            WebResponse response = new WebResponse { Success = false, Data = new List<WebResponseData>(), Error = new List<WebResponseError>() };
            try
            {
                TList<SiteLanguages> siteLanguages = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId);

                if (siteLanguages != null && siteLanguages.Count > 0)
                {
                    response.Success = true;
                    foreach (Entities.SiteLanguages siteLanguage in siteLanguages)
                    {
                        response.Data.Add(new WebResponseData { Value = siteLanguage.LanguageId.ToString(), Text = siteLanguage.SiteLanguageName });
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Debug("Error getting site language", ex);
                response.Error.Add(new WebResponseError { Name = "exception", Message = ex.Message });
            }

            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(response));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetTitle()
        {
            WebResponse response = new WebResponse { Success = false, Data = new List<WebResponseData>(), Error = new List<WebResponseError>() };
            try
            {
                response.Data.Add(new WebResponseData { Value = "Mr", Text = CommonFunction.GetResourceValue("LabelMr") });
                response.Data.Add(new WebResponseData { Value = "Mrs", Text = CommonFunction.GetResourceValue("LabelMrs") });
                response.Data.Add(new WebResponseData { Value = "Ms", Text = CommonFunction.GetResourceValue("LabelMs") });
                response.Data.Add(new WebResponseData { Value = "Miss", Text = CommonFunction.GetResourceValue("LabelMiss") });
                response.Data.Add(new WebResponseData { Value = "Dr", Text = CommonFunction.GetResourceValue("LabelDr") });
                response.Data.Add(new WebResponseData { Value = "Professor", Text = CommonFunction.GetResourceValue("LabelProfessor") });
                response.Data.Add(new WebResponseData { Value = "Other", Text = CommonFunction.GetResourceValue("LabelOther") });

                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Debug("Error getting title", ex);
                response.Error.Add(new WebResponseError { Name = "exception", Message = ex.Message });
            }

            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(response));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetEmailFormat()
        {
            WebResponse response = new WebResponse { Success = false, Data = new List<WebResponseData>(), Error = new List<WebResponseError>() };
            try
            {
                response.Data.Add(new WebResponseData { Value = ((int)PortalEnums.Email.EmailFormat.HTML).ToString(), Text = CommonFunction.GetResourceValue("LabelHTML") });
                response.Data.Add(new WebResponseData { Value = ((int)PortalEnums.Email.EmailFormat.Text).ToString(), Text = CommonFunction.GetResourceValue("LabelText") });

                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Debug("Error getting email format", ex);
                response.Error.Add(new WebResponseError { Name = "exception", Message = ex.Message });
            }

            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(response));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetCustomQuestions()
        {
            WebResponse response = new WebResponse { Success = false, Data = new List<WebResponseData>(), Error = new List<WebResponseError>() };
            try
            {
                Entities.MemberWizard memberWizard = MemberWizardService.GetBySiteId(SessionData.Site.SiteId).Where(m => m.GlobalTemplate == false).FirstOrDefault();
                if (memberWizard != null)
                {
                    string customQuestionXml = memberWizard.CustomQuestionsXml;

                    XmlDocument customquestions = new XmlDocument();
                    customquestions.LoadXml(customQuestionXml);

                    foreach (XmlNode questionNode in customquestions.SelectNodes("CustomQuestions/Question"))
                    {
                        if (questionNode["Status"].InnerXml == "1")
                        {
                            CustomQuestionsData customQuestionsData = new CustomQuestionsData();
                            customQuestionsData.Parameters = new List<string>();
                            customQuestionsData.Id = string.Format("customquestion_{0}_{1}", questionNode["Type"].InnerXml, questionNode["Id"].InnerXml);

                            XmlNode languagesnode = questionNode["Languages"];
                            foreach (XmlNode languagenode in languagesnode.SelectNodes("Language"))
                            {
                                if (languagenode["Id"].InnerXml == SessionData.Language.LanguageId.ToString())
                                {
                                    customQuestionsData.Title = languagenode["Title"].InnerXml;
                                    XmlNode paramsnode = languagenode.SelectSingleNode("Parameters");

                                    if (!string.IsNullOrWhiteSpace(paramsnode.InnerXml))
                                    {
                                        foreach (XmlNode itemnode in paramsnode.SelectNodes("Item"))
                                        {
                                            customQuestionsData.Parameters.Add(itemnode.InnerXml);
                                        }
                                    }
                                }
                            }

                            customQuestionsData.Type = questionNode["Type"].InnerXml;
                            customQuestionsData.Sequence = Convert.ToInt32(questionNode["Sequence"].InnerXml);
                            customQuestionsData.Mandatory = Convert.ToBoolean(questionNode["Mandatory"].InnerXml);

                            response.Data.Add(new WebResponseData { Value = customQuestionsData.Id, Text = new JavaScriptSerializer().Serialize(customQuestionsData) });
                        }

                    }

                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                _logger.Debug("Error getting custom questions", ex);
                response.Error.Add(new WebResponseError { Name = "exception", Message = ex.Message });
            }

            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(response));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void IsMemberLoggedIn()
        {
            _logger.Debug("Start Is Member Logged In");

            WebResponse response = new WebResponse { Success = false, Data = new List<WebResponseData>(), Error = new List<WebResponseError>() };
            if (SessionData.Member != null)
            {
                _logger.Debug("Member logged In");
                try
                {
                    response.Success = true;
                    response.Data.Add(new WebResponseData { Value = "memberid", Text = SessionData.Member.MemberId.ToString() });
                    response.Data.Add(new WebResponseData { Value = "firstname", Text = SessionData.Member.FirstName });
                    response.Data.Add(new WebResponseData { Value = "surname", Text = SessionData.Member.Surname });
                }
                catch (Exception ex)
                {
                    _logger.Debug("Exception thrown in Member Login", ex);

                    response.Error.Add(new WebResponseError { Name = "exception", Message = ex.Message });
                }
            }
            else
            {
                response.Error.Add(new WebResponseError { Name = "member", Message = "Member is not logged in" });
            }
            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(response));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void MemberLogin()
        {
            _logger.Debug("Start Member Login");

            string username = HttpContext.Current.Request["username"];
            string password = HttpContext.Current.Request["password"];

            WebResponse response = new WebResponse { Success = false, Data = new List<WebResponseData>(), Error = new List<WebResponseError>() };
            try
            {
                JXTPortal.Entities.Members member = MembersService.GetBySiteIdUsername(SessionData.Site.MasterSiteId, username);
                if (member != null && member.Valid && member.Validated && member.Password == CommonService.EncryptMD5(password))
                {
                    _logger.Debug("Credentials Correct. Start Retrieving info from SalesForce");
                    // SALESFORCE - Update the details from Sales force
                    if (GetFromSalesforceAndSave(member.EmailAddress, member.ExternalMemberId))
                    {
                        member = MembersService.GetByMemberId(member.MemberId);
                    }

                    SessionService.RemoveAdvertiserUser();
                    SessionService.SetMember(member);

                    // Update Last Login Date of the Member
                    _logger.Debug("Updating Member Last Login");
                    member.LastLogon = DateTime.Now;
                    MembersService.Update(member);

                    response.Success = true;
                    response.Data.Add(new WebResponseData { Value = "memberid", Text = SessionData.Member.MemberId.ToString() });
                    response.Data.Add(new WebResponseData { Value = "firstname", Text = SessionData.Member.FirstName });
                    response.Data.Add(new WebResponseData { Value = "surname", Text = SessionData.Member.Surname });
                    response.Data.Add(new WebResponseData { Value = "cname", Text = PortalConstants.SiteCookie.MemberCookie });
                    response.Data.Add(new WebResponseData { Value = "cvalue", Text = Common.Utils.Encrypt(SessionData.Member.MemberId.ToString() + "-" + SessionData.Site.AuthToken, true) });

                    _logger.Debug("Login Succeed");
                }
                else
                {
                    response.Error.Add(new WebResponseError { Name = "memberlogin", Message = CommonFunction.GetResourceValue("LabelAccessDenied") });
                }
            }
            catch (Exception ex)
            {
                _logger.Debug("Error in member login", ex);
                response.Error.Add(new WebResponseError { Name = "exception", Message = ex.Message });
            }

            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(response));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void CanApplyJob()
        {
            int memberId = 0;
            int jobId = 0;

            WebResponse response = new WebResponse { Success = false, Data = new List<WebResponseData>(), Error = new List<WebResponseError>() };

            int.TryParse(HttpContext.Current.Request["jobid"], out jobId);
            try
            {
                if (jobId <= 0)
                {
                    response.Error.Add(new WebResponseError { Name = "jobid", Message = CommonFunction.GetResourceValue("LabelRequiredField1") });

                    HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(response));
                    return;
                }
                else
                {
                    Entities.Jobs job = JobsService.GetByJobId(jobId);
                    if (job == null || job.SiteId != SessionData.Site.SiteId)
                    {
                        response.Error.Add(new WebResponseError { Name = "jobid", Message = CommonFunction.GetResourceValue("Invalid Job Id") });

                        HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(response));
                        return;
                    }
                }

                if (SessionData.Member != null)
                {
                    memberId = SessionData.Member.MemberId;
                }

                if (CheckMemberApplied(jobId, memberId))
                {
                    response.Error.Add(new WebResponseError { Name = "member", Message = CommonFunction.GetResourceValue("LabelJobApplied") });
                }
                else
                {
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                _logger.Debug("Error in checking member can ApplyJob", ex);
                response.Error.Add(new WebResponseError { Name = "exception", Message = ex.Message });
            }

            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(response));
        }

        private bool CheckMemberApplied(int jobId, int memberId)
        {
            if (memberId == 0) return false;

            using (TList<JobApplication> jobApplicationList = JobApplicationService.CustomGetByJobIdMemberId(jobId, memberId))
            {
                if (jobApplicationList != null && jobApplicationList.Count > 0 &&
                        memberId == jobApplicationList[0].MemberId &&
                        jobApplicationList[0].Draft == false)
                {
                    return true;
                }
            }

            return false;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetApplicationSocialMediaLogin()
        {
            _logger.Debug("Start Getting Application Social Media Details");

            WebResponse response = new WebResponse { Success = false, Data = new List<WebResponseData>(), Error = new List<WebResponseError>() };

            string profession = HttpContext.Current.Request["profession"];
            string jobName = HttpContext.Current.Request["jobname"];
            int jobId = 0;

            if (string.IsNullOrWhiteSpace(profession))
            {
                response.Error.Add(new WebResponseError { Name = "profession", Message = CommonFunction.GetResourceValue("LabelRequiredField1") });
            }

            if (string.IsNullOrWhiteSpace(jobName))
            {
                response.Error.Add(new WebResponseError { Name = "jobname", Message = CommonFunction.GetResourceValue("LabelRequiredField1") });
            }

            int.TryParse(HttpContext.Current.Request["jobid"], out jobId);

            if (jobId <= 0)
            {
                response.Error.Add(new WebResponseError { Name = "jobid", Message = CommonFunction.GetResourceValue("LabelRequiredField1") });
            }
            else
            {
                Entities.Jobs job = JobsService.GetByJobId(jobId);
                if (job == null || job.SiteId != SessionData.Site.SiteId)
                {
                    response.Error.Add(new WebResponseError { Name = "jobid", Message = CommonFunction.GetResourceValue("Invalid Job Id") });
                }
            }

            if (response.Error.Count == 0)
            {
                string domainToPassToRedirectURI = HttpContext.Current.Request.Url.Host;
                if (HttpContext.Current.Request.IsLocal)
                    domainToPassToRedirectURI += ":" + HttpContext.Current.Request.Url.Port;

                string rawUrl = string.Format("/applyjob/{0}/{1}/{2}", profession, jobName, jobId);

                //Get Integration Details
                AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);
                if (integrations != null)
                {
                    //Google login button
                    if (integrations.Google != null && !string.IsNullOrWhiteSpace(integrations.Google.ClientID) && !string.IsNullOrWhiteSpace(integrations.Google.ClientSecret) && integrations.Google.Valid)
                    {
                        GoogleMethods gg = new GoogleMethods(SessionData.Site.SiteId);

                        string oauthURL = string.Empty;

                        oauthURL = gg.OAuthApplyLoginRedirectURLGet(HttpContext.Current.Request.IsSecureConnection, domainToPassToRedirectURI, rawUrl);

                        response.Data.Add(new WebResponseData { Value = "google", Text = oauthURL });
                    }

                    //Facebook login button
                    if (integrations.Facebook != null && !string.IsNullOrWhiteSpace(integrations.Facebook.ApplicationID) && !string.IsNullOrWhiteSpace(integrations.Facebook.ApplicationSecret) && integrations.Facebook.Valid)
                    {
                        FacebookMethods fb = new FacebookMethods(SessionData.Site.SiteId);

                        string oauthURL = string.Empty;
                        string lowerURL = HttpContext.Current.Request.Url.ToString().ToLower();

                        oauthURL = fb.OAuthApplyLoginRedirectURLGet(HttpContext.Current.Request.IsSecureConnection, domainToPassToRedirectURI, profession, jobName, jobId);

                        response.Data.Add(new WebResponseData { Value = "facebook", Text = oauthURL });
                    }
                }

                //linkedin login button
                string linkedinapi = string.Empty;
                using (TList<JXTPortal.Entities.GlobalSettings> tgs = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
                {
                    if (tgs.Count > 0)
                    {
                        JXTPortal.Entities.GlobalSettings gs = tgs[0];
                        if (!string.IsNullOrEmpty(gs.LinkedInApi))
                        {
                            LinkedInMethods li = new LinkedInMethods(SessionData.Site.SiteId);

                            string oauthURL = li.OAuthApplyLoginRedirectURLGet(HttpContext.Current.Request.IsSecureConnection, domainToPassToRedirectURI, rawUrl, jobId);

                            response.Data.Add(new WebResponseData { Value = "linkedin", Text = oauthURL });
                        }
                    }
                }

                response.Success = (response.Data.Count > 0);
            }

            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(response));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetSocialMediaApplyWith()
        {
            _logger.Debug("Start Getting Social Media Apply With");

            WebResponse response = new WebResponse { Success = false, Data = new List<WebResponseData>(), Error = new List<WebResponseError>() };
            JXTPortal.Entities.ViewJobs job = null;

            string profession = HttpContext.Current.Request["profession"];
            string jobName = HttpContext.Current.Request["jobname"];
            int jobId = 0;

            if (string.IsNullOrWhiteSpace(profession))
            {
                response.Error.Add(new WebResponseError { Name = "profession", Message = CommonFunction.GetResourceValue("LabelRequiredField1") });
            }

            if (string.IsNullOrWhiteSpace(jobName))
            {
                response.Error.Add(new WebResponseError { Name = "jobname", Message = CommonFunction.GetResourceValue("LabelRequiredField1") });
            }

            int.TryParse(HttpContext.Current.Request["jobid"], out jobId);

            if (jobId <= 0)
            {
                response.Error.Add(new WebResponseError { Name = "jobid", Message = CommonFunction.GetResourceValue("LabelRequiredField1") });
            }
            else
            {
                job = ViewJobsService.GetByID(jobId, SessionData.Site.SiteId).FirstOrDefault();
                if (job == null || job.SiteId != SessionData.Site.SiteId)
                {
                    response.Error.Add(new WebResponseError { Name = "jobid", Message = CommonFunction.GetResourceValue("Invalid Job Id") });
                }
            }

            if (response.Error.Count == 0)
            {
                string domainToPassToRedirectURI = HttpContext.Current.Request.Url.Host;
                if (HttpContext.Current.Request.IsLocal)
                    domainToPassToRedirectURI += ":" + HttpContext.Current.Request.Url.Port;

                string rawUrl = string.Format("/applyjob/{0}/{1}/{2}", profession, jobName, jobId);
                string host = ((HttpContext.Current.Request.IsSecureConnection) ? "https://" : "http://") + domainToPassToRedirectURI;

                //Get Integration Details
                AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);
                if (integrations != null)
                {
                    if (integrations != null && integrations.Seek != null)
                    {
                        AdminIntegrations.Seek seek = integrations.Seek;
                        if (seek.Valid)
                        {
                            string seekurl = (ConfigurationManager.AppSettings["IsSeekLive"].ToString() == "1") ? "https://www.seek.com.au" : "https://www.seek.com.au.sandbox-qa";

                            if (seek.Valid)
                            {
                                string jobUrl = string.Format("{0}{1}", host, rawUrl);

                                string seekUrl = string.Format("{0}/api/iam/oauth2/authorize?client_id={1}&redirect_uri={2}oauthcallback.aspx%3Fcbtype%3Dseek%26cbaction%3Dapply&scope=r_profile_apply&response_type=code&state={3}",
                                                                seekurl, seek.ClientID, Server.UrlEncode(host + "/"), Server.UrlEncode(string.Format("{0}|{1}", jobId, jobUrl)));

                                response.Data.Add(new WebResponseData { Value = "seek", Text = seekUrl });
                            }
                        }
                    }

                    if (integrations != null && integrations.Indeed != null)
                    {
                        AdminIntegrations.Indeed indeed = integrations.Indeed;
                        if (indeed.Valid)
                        {
                            string indeedSpan = string.Format(@"<span class=""indeed-apply-widget""
                             data-indeed-apply-apiToken=""{0}""
                             data-indeed-apply-jobId=""{1}""
                             data-indeed-apply-jobLocation=""{2}""
                             data-indeed-apply-jobCompanyName=""{3}""
                             data-indeed-apply-jobTitle=""{4}""
                             data-indeed-apply-jobUrl=""{5}""
                             data-indeed-apply-postUrl=""{5}""
                             data-indeed-apply-onapplied=""OnIndeedCompleted""
                             ></span>", indeed.APIToken, jobId, job.SiteAreaName + ", " + job.SiteLocationName, job.CompanyName,
                             string.Format("{0}://{1}{2}", (HttpContext.Current.Request.IsSecureConnection) ? "https" : "http", domainToPassToRedirectURI, JobsService.GetJobUrl(profession, jobName, jobId)),
                             string.Format("{0}://{1}{2}", (HttpContext.Current.Request.IsSecureConnection) ? "https" : "http", domainToPassToRedirectURI,
                                "/oauthcallback.aspx?cbtype=indeed&cbaction=apply&jobid=" + jobId.ToString() +
                                "&profession=" + profession + "&jobname=" + jobName)
                             );

                            response.Data.Add(new WebResponseData { Value = "indeed", Text = indeedSpan });
                        }
                    }
                }

                //linkedin login button
                oAuthLinkedIn _oauth = new oAuthLinkedIn();
                string linkedinapi = string.Empty;
                using (TList<JXTPortal.Entities.GlobalSettings> tgs = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
                {
                    if (tgs.Count > 0)
                    {
                        JXTPortal.Entities.GlobalSettings gs = tgs[0];
                        if (!string.IsNullOrEmpty(gs.LinkedInApi))
                        {
                            string linkedinUrl =  _oauth.RequestToken(gs.LinkedInApi, host, jobId.ToString(), HttpContext.Current.Request.RawUrl, Utils.GetUrlReferrerDomain(), new List<string> { "cbtype=linkedin", "cbaction=Apply" });
                            response.Data.Add(new WebResponseData { Value = "linkedin", Text = linkedinUrl });
                        }
                    }
                }

                response.Success = (response.Data.Count > 0);
            }

            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(response));
        }

        #region SALESFORCE

        /// <summary>
        /// SALESFORCE - If Member doesn't exist in Platform check if exist in SALESFORCE and grab the details from Salesforce AND send reset password email to member.
        /// </summary>
        /// <param name="strEmail"></param>
        private bool GetFromSalesforceAndSave(string strEmail, string SalesForceContactID)
        {
            SalesforceMemberSync memberSync = new SalesforceMemberSync();
            int memberid = 0; string errormsg = string.Empty;

            // Get Candidate from Salesforce by email
            // And If candidate exists in Sales force, save in Boardy platform.
            if (memberSync.GetContactFromSalesForceAndSave(strEmail, SalesForceContactID, SessionData.Site.MasterSiteId, ref memberid, ref errormsg) && memberid > 0)
            {
                return true;
            }

            return false;
        }

        #endregion

        [DataContract]
        private class WebResponse
        {
            public bool Success { get; set; }
            public List<WebResponseData> Data { get; set; }
            public List<WebResponseError> Error { get; set; }
        }

        [DataContract]
        private class WebResponseData
        {
            public string Value { get; set; }
            public string Text { get; set; }
        }

        [DataContract]
        private class WebResponseError
        {
            public string Name { get; set; }
            public string Message { get; set; }
        }

        [DataContract]
        private class CustomQuestionsData
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Type { get; set; }
            public int Sequence { get; set; }
            public bool Mandatory { get; set; }
            public List<string> Parameters { get; set; }
        }

        internal class CustomQuestionAnswer
        {
            public int Id { get; set; }
            public string Type { get; set; }
            public string Value { get; set; }
        }
    }
}
