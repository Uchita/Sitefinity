using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Xml;
using System.Text;
using System.Runtime;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Configuration;

using SocialMedia;
using JXTPortal.Common;
using JXTPortal.Entities;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using NotesFor.HtmlToOpenXml;
using JXTPortal.Entities.Models;
using log4net;
using JXTPortal.Service.Dapper;

namespace JXTPortal.Website
{
    public partial class oauthcallback : System.Web.UI.Page
    {
        ILog _logger;
        private string bucketName = ConfigurationManager.AppSettings["AWSS3BucketName"];
        private string resumeFolder;
        #region Properties
        public IJobApplicationScreeningAnswersService JobApplicationScreeningAnswersService { get; set; }
        public IFileManager FileManagerService { get; set; }

        public string ID
        {
            get { return Request.Params["id"]; }
        }

        public string State
        {
            get { return Request.Params["state"]; }
        }

        public string joburl
        {
            get { return Request.Params["joburl"]; }
        }

        public string profession
        {
            get { return Request.Params["profession"]; }
        }


        public string jobname
        {
            get { return Request.Params["jobname"]; }
        }

        public string Referrer
        {
            get { return Request.Params["referrer"]; }
        }

        private string HostUrl
        {
            get
            {
                string hostUrl = Request.Url.Host;
                if (Request.IsLocal) hostUrl = string.Format("{0}:{1}", Request.Url.Host, Request.Url.Port);

                return hostUrl;
            }
        }

        private JobsService _jobService;
        private JobsService JobsService
        {
            get
            {
                if (_jobService == null)
                    _jobService = new JobsService();
                return _jobService;
            }
        }

        private JobApplicationService _jobApplicationService;
        private JobApplicationService JobApplicationService
        {
            get
            {
                if (_jobApplicationService == null)
                    _jobApplicationService = new JobApplicationService();
                return _jobApplicationService;
            }
        }

        private DynamicPagesService _dynamicpagesservice;
        private DynamicPagesService DynamicPagesService
        {
            get
            {
                if (_dynamicpagesservice == null)
                    _dynamicpagesservice = new DynamicPagesService();
                return _dynamicpagesservice;
            }
        }

        private MembersService _membersservice;
        private MembersService MembersService
        {
            get
            {
                if (_membersservice == null)
                    _membersservice = new MembersService();
                return _membersservice;
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

        private SitesService _sitesService;
        private SitesService SitesService
        {
            get
            {
                if (_sitesService == null)
                {
                    _sitesService = new SitesService();
                }

                return _sitesService;
            }
        }
        #endregion

        public oauthcallback()
        {
            _logger = LogManager.GetLogger(typeof(oauthcallback));
        }

        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _logger.Debug("onPageLoad()");

            if (!SessionData.Site.IsUsingS3)
            {
                resumeFolder = ConfigurationManager.AppSettings["FTPJobApplyResumeUrl"];

                string ftphosturl = ConfigurationManager.AppSettings["FTPHost"];
                string ftpusername = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                string ftppassword = ConfigurationManager.AppSettings["FTPJobApplyPassword"];
                FileManagerService = new FTPClientFileManager(ftphosturl, ftpusername, ftppassword);
            }
            else
            {
                resumeFolder = ConfigurationManager.AppSettings["AWSS3ResumePath"];
            }

            System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            OAuthErrorCheck();
            _logger.Debug("onErrorCheck success");
            PortalEnums.SocialMedia.SocialMediaType callbackType;
            bool typeParseOK = Enum.TryParse<PortalEnums.SocialMedia.SocialMediaType>(Request["cbtype"], true, out callbackType);
            _logger.Debug(string.Format("typeParseOk = {0}, callbackType = {1}", typeParseOK, callbackType));

            if (!string.IsNullOrEmpty(hfGoogleAccessDenied.Value))
            {
                _logger.Debug(string.Format("hfGoogleAccessDenied.Value = {0}", hfGoogleAccessDenied.Value));

                if (Session["ApplyURL"] != null)
                {
                    var url = Session["ApplyURL"].ToString();
                    _logger.Debug(string.Format("Redirecting back to {0}", url));
                    Response.Redirect(url, false);
                    return;
                }
                return;
            }

            //other special cases due to restriction on callback urls
            if (!typeParseOK && !string.IsNullOrEmpty(hfGoogleAccessToken.Value))
            {
                _logger.Debug("Setting TryparseOK to true and Callbacktype to Google");
                typeParseOK = true;
                callbackType = PortalEnums.SocialMedia.SocialMediaType.Google;
            }

            PortalEnums.SocialMedia.OAuthCallbackAction callbackAction;
            bool actionParseOK = Enum.TryParse<PortalEnums.SocialMedia.OAuthCallbackAction>(Request["cbaction"], true, out callbackAction);
            _logger.Debug(string.Format("typeParseOk = {0}, callbackAction = {1}", actionParseOK, callbackAction));

            //other special cases due to restriction on callback urls
            if (!actionParseOK)
            {
                if (!string.IsNullOrEmpty(hfGoogleAccessToken.Value))
                {
                    _logger.Debug("Setting actionParseOK to true and callbackAction to ApplyLogin");
                    actionParseOK = true;
                    callbackAction = PortalEnums.SocialMedia.OAuthCallbackAction.ApplyLogin;
                }
            }

            if (typeParseOK && actionParseOK)
            {
                switch (callbackType)
                {
                    case PortalEnums.SocialMedia.SocialMediaType.Google:
                        if (!string.IsNullOrEmpty(hfGoogleAccessToken.Value))
                            callbackAction = PortalEnums.SocialMedia.OAuthCallbackAction.ApplyLogin;

                        OAuthCallBackGoogle(callbackAction, Request["code"]);
                        break;
                    case PortalEnums.SocialMedia.SocialMediaType.Facebook:
                        OAuthCallBackFacebook(callbackAction, Request["code"]);
                        break;
                    //case PortalEnums.SocialMedia.SocialMediaType.Twitter:
                    //    OAuthCallBackTwitter(callbackAction, lastRequestedURL, Request["oauth_token"], Request["oauth_verifier"]);
                    //    break;
                    case PortalEnums.SocialMedia.SocialMediaType.LinkedIn:
                        OAuthCallBackLinkedIn(callbackAction, Request["code"]);
                        break;
                    case PortalEnums.SocialMedia.SocialMediaType.Indeed:
                        OAuthCallBackIndeed(callbackAction, Request["code"]);
                        break;
                    case PortalEnums.SocialMedia.SocialMediaType.Seek:
                        OAuthCallBackSeek(callbackAction, Request["code"]);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                //TODO: ERROR
                int oAuthError = LoginErrorCodeGet("OAuthorizationFailed");

                _logger.Error(string.Format("OAuthFailure {0}", oAuthError));
                Response.Redirect("~/member/login.aspx?oautherror=" + oAuthError, false);
                return;
            }
        }

        private bool SeekApplyJob(int jobid, string url, string DocumentName, string data, bool isHTML, out string errormsg)
        {
            // Check if member has applied for the job
            bool success = false;
            errormsg = string.Empty;

            try
            {
                using (TList<JXTPortal.Entities.JobApplication> jobapp = JobApplicationService.GetByJobId(jobid))
                {
                    if (jobapp != null)
                    {
                        jobapp.Filter = "MemberID = " + SessionData.Member.MemberId.ToString();
                        if (jobapp.Count > 0)
                        {
                            errormsg = "applied";
                            return false;
                        }
                    }

                    string strUrlReferral = "Seek";
                    string jobapplicationemail = string.Empty;

                    // [TODO] Member Apply for job sp
                    using (JXTPortal.Entities.JobApplication newjobapp = new JXTPortal.Entities.JobApplication())
                    {
                        newjobapp.ApplicationDate = DateTime.Now;
                        newjobapp.JobId = Convert.ToInt32(jobid);
                        newjobapp.MemberId = SessionData.Member.MemberId;

                        newjobapp.JobAppValidateId = new Guid();
                        newjobapp.SiteIdReferral = SessionData.Site.MasterSiteId;
                        newjobapp.UrlReferral = strUrlReferral;
                        newjobapp.AppliedWith = "Seek";
                        newjobapp.FirstName = SessionData.Member.FirstName;
                        newjobapp.Surname = SessionData.Member.Surname;
                        newjobapp.EmailAddress = SessionData.Member.EmailAddress;
                        newjobapp.MobilePhone = SessionData.Member.Phone;
                        newjobapp.ApplicationStatus = (int)PortalEnums.JobApplications.ApplicationStatus.Applied;
                        newjobapp.Draft = false;

                        if (JobApplicationService.Insert(newjobapp))
                        {
                            string errormessage = string.Empty;

                            // Retrieve value from JobsViewed Cookie, the format is {JobID}|{Domain},...
                            string domain = Utils.GetCookieDomain(Request.Cookies["JobsViewed"], newjobapp.JobId.Value);

                            using (Entities.Jobs job = JobsService.GetByJobId(jobid))
                            {
                                if (job != null)
                                {
                                    jobapplicationemail = job.ApplicationEmailAddress;
                                    // call JobClientTracking to retrieve job application email if matches criteria (for Broadbean atm) 
                                    JobClientTracking tracking = new JobClientTracking(jobapplicationemail);
                                    jobapplicationemail = tracking.RetrieveEmail(domain);
                                }
                            }

                            Regex r = new Regex("(?:[^a-z0-9.]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);

                            MemoryStream generatedDocument = new MemoryStream();
                            if (isHTML)
                            {
                                using (WordprocessingDocument package = WordprocessingDocument.Create(generatedDocument, WordprocessingDocumentType.Document))
                                {
                                    MainDocumentPart mainPart = package.MainDocumentPart;
                                    if (mainPart == null)
                                    {
                                        mainPart = package.AddMainDocumentPart();
                                        new Document(new Body()).Save(mainPart);
                                    }

                                    HtmlConverter converter = new HtmlConverter(mainPart);
                                    Body body = mainPart.Document.Body;

                                    var paragraphs = converter.Parse(data);
                                    for (int i = 0; i < paragraphs.Count; i++)
                                    {
                                        body.Append(paragraphs[i]);
                                    }

                                    mainPart.Document.Save();
                                }
                                string filename = string.Format("{0}_Resume_{1}", newjobapp.JobApplicationId, DocumentName);

                                newjobapp.MemberResumeFile = filename;

                                FileManagerService.UploadFile(bucketName, resumeFolder, filename, generatedDocument, out errormessage);
                            }
                            else
                            {
                                generatedDocument = new MemoryStream(ASCIIEncoding.Default.GetBytes(data));

                                string filename = string.Format("{0}_Resume_{1}", newjobapp.JobApplicationId, DocumentName);

                                newjobapp.MemberResumeFile = filename;

                                FileManagerService.UploadFile(bucketName, resumeFolder, filename, generatedDocument, out errormessage);
                            }

                            if (string.IsNullOrEmpty(errormessage))
                            {
                                if (JobApplicationService.Update(newjobapp))
                                {
                                    Entities.Members member = MembersService.GetByMemberId(SessionData.Member.MemberId);

                                    int siteid = SessionData.Site.SiteId;
                                    using (Entities.Jobs job = JobsService.GetByJobId(Convert.ToInt32(ID)))
                                    {
                                        if (job != null)
                                        {
                                            siteid = job.SiteId;
                                        }
                                    }

                                    MailService.SetJobApplicationScreeningAnswers(JobApplicationScreeningAnswersService);
                                    MailService.SetFileManager(FileManagerService);
                                    MailService.SendMemberJobApplicationEmail(member);
                                    MailService.SendAdvertiserJobApplicationEmail(member, newjobapp, new HybridDictionary(), siteid, jobapplicationemail);
                                    success = true;
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                errormsg = ex.Message;
                return false;
            }

            return success;
        }

        private void IndeedApplyJob(int jobid, string url, string DocumentName, string data)
        {
            // Check if member has applied for the job
            _logger.DebugFormat("IndeedApplyJob: jobId - {0}", jobid);
            using (TList<JXTPortal.Entities.JobApplication> jobapp = JobApplicationService.GetByJobId(jobid))
            {
                if (jobapp != null)
                {
                    jobapp.Filter = "MemberID = " + SessionData.Member.MemberId.ToString();
                    if (jobapp.Count > 0)
                    {
                        _logger.Debug("Member has already applied for job");
                        Response.Redirect(url, false);
                        return;
                    }
                }

                string strUrlReferral = "Indeed";
                string jobapplicationemail = string.Empty;

                // [TODO] Member Apply for job sp
                using (JXTPortal.Entities.JobApplication newjobapp = new JXTPortal.Entities.JobApplication())
                {
                    _logger.Debug(string.Format("Creating new application for member({0}", SessionData.Member.MemberId));
                    newjobapp.ApplicationDate = DateTime.Now;
                    newjobapp.JobId = Convert.ToInt32(jobid);
                    newjobapp.MemberId = SessionData.Member.MemberId;

                    newjobapp.JobAppValidateId = new Guid();
                    newjobapp.SiteIdReferral = SessionData.Site.MasterSiteId;
                    newjobapp.UrlReferral = strUrlReferral;
                    newjobapp.AppliedWith = "Indeed";
                    newjobapp.FirstName = SessionData.Member.FirstName;
                    newjobapp.Surname = SessionData.Member.Surname;
                    newjobapp.EmailAddress = SessionData.Member.EmailAddress;
                    newjobapp.MobilePhone = SessionData.Member.Phone;
                    newjobapp.ApplicationStatus = (int)PortalEnums.JobApplications.ApplicationStatus.Applied;
                    newjobapp.Draft = false;

                    if (JobApplicationService.Insert(newjobapp))
                    {
                        _logger.Debug("Job application successfully added");
                        string errormessage = string.Empty;

                        // Retrieve value from JobsViewed Cookie, the format is {JobID}|{Domain},...
                        string domain = Utils.GetCookieDomain(Request.Cookies["JobsViewed"], newjobapp.JobId.Value);

                        using (Entities.Jobs job = JobsService.GetByJobId(jobid))
                        {
                            if (job != null)
                            {
                                jobapplicationemail = job.ApplicationEmailAddress;
                                // call JobClientTracking to retrieve job application email if matches criteria (for Broadbean atm) 
                                JobClientTracking tracking = new JobClientTracking(jobapplicationemail);
                                jobapplicationemail = tracking.RetrieveEmail(domain);
                            }
                        }

                        Regex r = new Regex("(?:[^a-z0-9.]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);

                        byte[] bytes = System.Convert.FromBase64String(data);
                        MemoryStream generatedDocument = new MemoryStream(bytes);

                        string filename = string.Format("{0}_Resume_{1}", newjobapp.JobApplicationId, DocumentName);

                        newjobapp.MemberResumeFile = filename;
                        _logger.Debug(string.Format("FTPing the resume filename {0}", filename));
                        FileManagerService.UploadFile(bucketName, resumeFolder, filename, generatedDocument, out errormessage);

                        if (string.IsNullOrEmpty(errormessage))
                        {
                            _logger.Debug("Successfully uploaded resume");
                            if (JobApplicationService.Update(newjobapp))
                            {
                                Entities.Members member = MembersService.GetByMemberId(SessionData.Member.MemberId);

                                int siteid = SessionData.Site.SiteId;
                                using (Entities.Jobs job = JobsService.GetByJobId(Convert.ToInt32(ID)))
                                {
                                    if (job != null)
                                    {
                                        siteid = job.SiteId;
                                    }
                                }

                                MailService.SetJobApplicationScreeningAnswers(JobApplicationScreeningAnswersService);
                                MailService.SetFileManager(FileManagerService);
                                MailService.SendMemberJobApplicationEmail(member);
                                MailService.SendAdvertiserJobApplicationEmail(member, newjobapp, new HybridDictionary(), siteid, jobapplicationemail);
                                // Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.JOBAPPLY_SUCCESS, "", "", ""), false);
                                return;
                            }
                            else
                            {
                                _logger.Warn("Failed to update the job application");
                            }
                        }
                        else
                        {
                            _logger.Warn(string.Format("Error sending resume: {0}", errormessage));
                        }

                    }
                    else
                    {
                        _logger.Warn("Failed to insert job application");
                    }
                }
            }
        }

        private void ApplyJob(string strHTML, string AppliedWith, string DocumentName)
        {
            // Check if member has applied for the job
            using (TList<JXTPortal.Entities.JobApplication> jobapp = JobApplicationService.GetByJobId(Convert.ToInt32(ID)))
            {
                if (jobapp != null)
                {
                    jobapp.Filter = "MemberID = " + SessionData.Member.MemberId.ToString();
                    if (jobapp.Count > 0)
                    {
                        // Member has applied the job
                        if (string.IsNullOrWhiteSpace(joburl))
                            Response.Redirect(Utils.GetJobUrl(Convert.ToInt32(ID), jobname, profession), false);
                        else
                            Response.Redirect(joburl, false);
                        return;
                    }
                }

                string strUrlReferral = Referrer;
                string jobapplicationemail = string.Empty;

                // [TODO] Member Apply for job sp
                using (JXTPortal.Entities.JobApplication newjobapp = new JXTPortal.Entities.JobApplication())
                {
                    newjobapp.ApplicationDate = DateTime.Now;
                    newjobapp.JobId = Convert.ToInt32(ID);
                    newjobapp.MemberId = SessionData.Member.MemberId;

                    newjobapp.JobAppValidateId = new Guid();
                    newjobapp.SiteIdReferral = SessionData.Site.MasterSiteId;
                    newjobapp.UrlReferral = strUrlReferral;
                    newjobapp.AppliedWith = AppliedWith;
                    newjobapp.FirstName = SessionData.Member.FirstName;
                    newjobapp.Surname = SessionData.Member.Surname;
                    newjobapp.EmailAddress = SessionData.Member.EmailAddress;
                    newjobapp.MobilePhone = SessionData.Member.Phone;
                    newjobapp.ApplicationStatus = (int)PortalEnums.JobApplications.ApplicationStatus.Applied;
                    newjobapp.Draft = false;

                    if (JobApplicationService.Insert(newjobapp))
                    {
                        string errormessage = string.Empty;

                        // Retrieve value from JobsViewed Cookie, the format is {JobID}|{Domain},...
                        string domain = Utils.GetCookieDomain(Request.Cookies["JobsViewed"], newjobapp.JobId.Value);

                        using (Entities.Jobs job = JobsService.GetByJobId(newjobapp.JobId.Value))
                        {
                            if (job != null)
                            {
                                jobapplicationemail = job.ApplicationEmailAddress;
                                // call JobClientTracking to retrieve job application email if matches criteria (for Broadbean atm) 
                                JobClientTracking tracking = new JobClientTracking(jobapplicationemail);
                                jobapplicationemail = tracking.RetrieveEmail(domain);
                            }
                        }

                        Regex r = new Regex("(?:[^a-z0-9.]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);

                        using (MemoryStream generatedDocument = new MemoryStream())
                        {
                            using (WordprocessingDocument package = WordprocessingDocument.Create(generatedDocument, WordprocessingDocumentType.Document))
                            {
                                MainDocumentPart mainPart = package.MainDocumentPart;
                                if (mainPart == null)
                                {
                                    mainPart = package.AddMainDocumentPart();
                                    new Document(new Body()).Save(mainPart);
                                }

                                HtmlConverter converter = new HtmlConverter(mainPart);
                                Body body = mainPart.Document.Body;

                                var paragraphs = converter.Parse(strHTML);
                                for (int i = 0; i < paragraphs.Count; i++)
                                {
                                    body.Append(paragraphs[i]);
                                }

                                mainPart.Document.Save();
                            }
                            string filename = string.Format("{0}_Resume_{1}", newjobapp.JobApplicationId, DocumentName);

                            newjobapp.MemberResumeFile = filename;
                            FileManagerService.UploadFile(bucketName, resumeFolder, filename, generatedDocument, out errormessage);

                            if (string.IsNullOrEmpty(errormessage))
                            {
                                if (JobApplicationService.Update(newjobapp))
                                {
                                    Entities.Members member = MembersService.GetByMemberId(SessionData.Member.MemberId);

                                    int siteid = SessionData.Site.SiteId;
                                    using (Entities.Jobs job = JobsService.GetByJobId(Convert.ToInt32(ID)))
                                    {
                                        if (job != null)
                                        {
                                            siteid = job.SiteId;
                                        }
                                    }
                                    MailService.SetJobApplicationScreeningAnswers(JobApplicationScreeningAnswersService);
                                    MailService.SetFileManager(FileManagerService);
                                    MailService.SendMemberJobApplicationEmail(member);
                                    MailService.SendAdvertiserJobApplicationEmail(member, newjobapp, new HybridDictionary(), siteid, jobapplicationemail);
                                    Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.JOBAPPLY_SUCCESS, "", "", ""), false);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void LoginFromAPI(GeneralAPIMember gam, string source, bool redirectToMemberHome = true, string accessToken = "", bool validated = true)
        {
            _logger.Debug(string.Format("LoginFromAPI: source = {0}", source));
            string memberHome = "~/member/default.aspx";
            SocialMedia.API.MemberAPIService s = new SocialMedia.API.MemberAPIService();
            int memberid = 0;
            string errormsg = string.Empty;

            if (s.MemberSocialMediaLogin(SessionData.Site.MasterSiteId, gam.FirstName, gam.Surname, gam.EmailAddress, source, ref memberid, ref errormsg, accessToken, validated))
            {
                if (redirectToMemberHome)
                {
                    _logger.Debug("redirecting member back to home");
                    MembersService service = new MembersService();
                    using (Entities.Members m = service.GetByMemberId(memberid))
                    {
                        if (m != null)
                        {
                            Response.Redirect(memberHome, true);
                            return;
                        }
                    }
                }
            }
        }

        #region Facebook Methods
        private void OAuthCallBackFacebook(PortalEnums.SocialMedia.OAuthCallbackAction callbackAction, string code)
        {
            _logger.InfoFormat("OAuthCallBack option: {0}", callbackAction);
            switch (callbackAction)
            {
                case PortalEnums.SocialMedia.OAuthCallbackAction.Login:
                case PortalEnums.SocialMedia.OAuthCallbackAction.Register:
                    LoginWithFacebook(code);
                    break;
                case PortalEnums.SocialMedia.OAuthCallbackAction.Apply:
                case PortalEnums.SocialMedia.OAuthCallbackAction.ApplyLogin:
                    ApplyWithFacebook();
                    break;
                default:
                    break;
            }
        }

        private void LoginWithFacebook(string code)
        {
            _logger.DebugFormat("Attempting login with facebook with: {0}", code);

            //Get Integration Details
            AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

            string facebookappid = integrations.Facebook.ApplicationID;
            string facebooksecret = integrations.Facebook.ApplicationSecret;
            string facebookuri = Session["SocialRequestedURL"].ToString();

            oAuthFacebook oauthfb = new oAuthFacebook();
            //Consumer Key & redirecturi should be acquired from db
            oauthfb.ClientID = facebookappid;
            oauthfb.ClientSecret = facebooksecret;
            oauthfb.RedirectURI = facebookuri;
            oauthfb.Code = code;

            //get access token using code
            string access_token = oauthfb.RetreiveAccessTokenWithFBCode();

            if (string.IsNullOrEmpty(access_token))
            {
                _logger.Warn("facebook login failed");
                Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("OAuthorizationFailed"), false);
                return;
            }

            FacebookUserDetails fbDetails = oauthfb.RetreiveUserDetails(access_token);

            if (fbDetails == null)
            {
                _logger.Warn("failed to retrieve use details");
                Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("OAuthorizationFailed"), false);
                return;
            }
            //finally process the user
            int loginErrorCode = 0; //0 means no error

            loginErrorCode = ProcessSocialUser(fbDetails.id, fbDetails.email, fbDetails.first_name, fbDetails.last_name);

            if (loginErrorCode == 0)
            {
                _logger.Info("successfully logged in with facebook");
                Response.Redirect("~/member/default.aspx", false);
            }
            else
            {
                _logger.WarnFormat("Could not process social user. errorCode = {0}", loginErrorCode);
                Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("OAuthorizationFailed"), false);
            }
            return;
        }

        private void ApplyWithFacebook()
        {
            // Facebook

            if (string.IsNullOrEmpty(Request.Params["cbtype"]) == false && Request.Params["cbtype"].ToLower() == "facebook")
            {
                // Retrieve facebook profile
                string code = Request.Params["code"];
                oAuthFacebook _oauth = new oAuthFacebook();

                //Get Integration Details
                AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

                if (integrations.Facebook != null && !string.IsNullOrEmpty(integrations.Facebook.ApplicationID))
                {
                    _oauth.Code = code;
                    // Response.Write(code);
                    _oauth.ClientID = integrations.Facebook.ApplicationID;
                    _oauth.ClientSecret = integrations.Facebook.ApplicationSecret;
                    string http = (Request.IsSecureConnection) ? "https://" : "http://";
                    string urlsuffix = http + HostUrl;
                    _oauth.RedirectURI = urlsuffix + "/oauthcallback.aspx?cbtype=" + Request.Params["cbtype"] + "&cbaction=" + Request.Params["cbaction"] + "&id=" + ID;
                    if (!string.IsNullOrEmpty(profession))
                    {
                        _oauth.RedirectURI += "&profession=" + HttpUtility.UrlEncode(profession);
                    }
                    if (!string.IsNullOrEmpty(jobname))
                    {
                        _oauth.RedirectURI += "&jobname=" + HttpUtility.UrlEncode(jobname);
                    }
                    string accesstoken = string.Empty;
                    string userinfo = _oauth.GetUserInfo(out accesstoken);

                    if (userinfo.StartsWith("Error:"))
                    {
                        Response.Write(userinfo);
                        Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("OAuthorizationFailed"), false);
                        return;
                    }

                    try
                    {
                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        FacebookContract oAuthResult = jss.Deserialize<FacebookContract>(userinfo);

                        string result = _oauth.HasFullPermission(oAuthResult.id, accesstoken);
                        if (!string.IsNullOrEmpty(result))
                        {
                            if (Request.Params["cbaction"].ToLower() == "applylogin" || Request.Params["cbaction"].ToLower() == "apply")
                            {
                                Response.Redirect(http + HostUrl + "/applyjob/" + profession + "-jobs/" + jobname + "/" + ID + "#error=permission", false);
                            }
                            else
                            {
                                Response.Redirect("~/member/login.aspx?oautherror=2", false);
                            }

                            return;
                        }

                        GeneralAPIMember gam = new GeneralAPIMember();
                        gam.FirstName = oAuthResult.first_name;
                        gam.Surname = oAuthResult.last_name;
                        gam.EmailAddress = oAuthResult.email;

                        //if (string.IsNullOrWhiteSpace(gam.EmailAddress))
                        //{
                        //    if (integrations.Facebook != null && !string.IsNullOrEmpty(integrations.Facebook.ApplicationID))
                        //    {
                        //        string strhttp = "http://";
                        //        if (Request.IsSecureConnection)
                        //            strhttp = "https://";

                        //        string strurlsuffix = strhttp + HttpContext.Current.Request.Url.Authority;

                        //        _oauth.ClientID = integrations.Facebook.ApplicationID;
                        //        string p = (!string.IsNullOrWhiteSpace(profession)) ? "&profession=" + HttpUtility.UrlEncode(profession) : string.Empty;
                        //        string strjobname = (!string.IsNullOrWhiteSpace(jobname)) ? "&jobname=" + HttpUtility.UrlEncode(jobname) : string.Empty;
                        //        _oauth.RedirectURI = strurlsuffix + "/oauthcallback.aspx?cbtype=facebook&cbaction=" + Request["cbaction"] + "&id=" + ID.ToString() + p + strjobname;
                        //        string token = _oauth.Authorize();
                        //        Response.Redirect(token);
                        //        return;
                        //    }
                        //}

                        if (string.IsNullOrWhiteSpace(ID))
                        {
                            LoginFromAPI(gam, "Facebook", true, string.Empty);
                        }
                        else
                        {
                            LoginFromAPI(gam, "Facebook", false, string.Empty);
                            if (Request.Params["cbaction"].ToLower() == "applylogin")
                            {
                                Response.Redirect(http + HostUrl + "/applyjob/" + profession + "-jobs/" + jobname + "/" + ID, false);
                                return;
                            }
                            else if (Request.Params["cbaction"].ToLower() == "apply")
                            {
                                string strUrl = string.Empty;
                                using (Entities.Sites site = SitesService.GetBySiteId(SessionData.Site.SiteId))
                                {
                                    if (!string.IsNullOrWhiteSpace(site.SiteAdminLogoUrl))
                                    {
                                        strUrl = string.Format("/media/{0}/{1}", ConfigurationManager.AppSettings["SitesFolder"], site.SiteAdminLogoUrl);
                                    }
                                    else
                                    {
                                        strUrl = Page.ResolveUrl("~/GetAdminLogo.aspx?SiteID=" + SessionData.Site.SiteId.ToString());
                                    }
                                }

                                string strHTML = _oauth.oAuth2GetProfileHTML(userinfo, strUrl); // TODO: Construct HTML for facebook resume

                                ApplyJob(strHTML, "Facebook", "Facebook.docx");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(userinfo);
                        Response.Write("<br />");
                        Response.Write(ex.Message + "<br />");
                        Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("Exception"), false);
                        return;
                    }
                }
            }
        }

        #endregion

        #region Twitter Methods

        //private void OAuthCallBackTwitter(PortalEnums.SocialMedia.OAuthCallbackAction callbackAction, string requestedURL, string oauth_token, string oauth_verifier)
        //{
        //    //Get Integration Details
        //    AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

        //    string consumer_key = integrations.Twitter.ConsumerKey; //TODO REMOVE "Zf7nzDNHgz5ULqyLgCE54fgJV";
        //    string consumer_secret = integrations.Twitter.ConsumerSecret; //TODO REMOVE "twuq4jZ4zuUbkMZQ4kh0UfZutrPY9LHY834a9YMSJy2jJdOD8Z";

        //    oAuthTwitter twitter = new oAuthTwitter(consumer_key, consumer_secret, string.Empty);
        //    twitter.GetUserDetails(oauth_token, oauth_verifier);

        //    switch (callbackAction)
        //    {
        //        case PortalEnums.SocialMedia.OAuthCallbackAction.Login:
        //        case PortalEnums.SocialMedia.OAuthCallbackAction.Register:                                   
        //            break;
        //        case PortalEnums.SocialMedia.OAuthCallbackAction.Apply:
        //            break;
        //        default:
        //            break;
        //    }
        //}

        #endregion

        #region Google Methods

        private void OAuthCallBackGoogle(PortalEnums.SocialMedia.OAuthCallbackAction callbackAction, string code)
        {
            switch (callbackAction)
            {
                case PortalEnums.SocialMedia.OAuthCallbackAction.Login:
                case PortalEnums.SocialMedia.OAuthCallbackAction.Register:
                    LoginWithGoogle(code);
                    break;
                case PortalEnums.SocialMedia.OAuthCallbackAction.Apply:
                case PortalEnums.SocialMedia.OAuthCallbackAction.ApplyLogin:
                    ApplyWithGoogle();
                    break;
                default:
                    break;
            }
        }

        private void LoginWithGoogle(string code)
        {
            //Get Integration Details
            AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

            if (integrations.Google != null)
            {
                string googleappid = integrations.Google.ClientID;
                string googleappsecret = integrations.Google.ClientSecret;
                string googleuri = HttpUtility.UrlEncode(Session["SocialRequestedURL"].ToString());

                oAuthGoogle gmodule = new oAuthGoogle(googleappid, googleappsecret, googleuri);
                string access_token = gmodule.GetAccessTokenUsingCode(code);

                GoogleUser ggUser = gmodule.GetUserInfoUsingAccessToken(access_token);

                int loginErrorCode = 0; //0 means no error

                loginErrorCode = ProcessSocialUser(ggUser.id, ggUser.email, ggUser.given_name, ggUser.family_name);

                if (loginErrorCode == 0)
                    Response.Redirect("~/member/default.aspx", false);
                else
                    Response.Redirect("~/member/login.aspx?oautherror=" + loginErrorCode, false);
                return;
            }
            Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("Exception"), false);
            return;
        }

        private void ApplyWithGoogle()
        {
            if (!string.IsNullOrEmpty(hfGoogleAccessToken.Value))
            {
                string userinfo = string.Empty;

                try
                {
                    string token = hfGoogleAccessToken.Value;
                    oAuthGoogle _oauth = new oAuthGoogle();
                    _oauth.AccessToken = token;

                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(GoogleContract));

                    userinfo = _oauth.GetUserInfo();

                    if (userinfo.StartsWith("Error:"))
                    {
                        Response.Write(userinfo);
                        Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("OAuthorizationFailed"), false);
                        return;
                    }

                    object gobj = jsonSerializer.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(userinfo)));
                    GoogleContract gcontract = gobj as GoogleContract;

                    GeneralAPIMember gam = new GeneralAPIMember();

                    gam.FirstName = gcontract.GivenName;
                    gam.Surname = gcontract.FamilyName;
                    gam.EmailAddress = gcontract.Email;

                    if (Request.Params["cbaction"] == "applylogin" && string.IsNullOrWhiteSpace(Session["ApplyURL"].ToString()) == false)
                    {
                        LoginFromAPI(gam, "Google", false);
                        string redirecturl = Session["ApplyURL"].ToString();
                        Session.Remove("ApplyURL");
                        Response.Redirect(redirecturl, false);
                        return;
                    }
                    else
                    {
                        LoginFromAPI(gam, "Google");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(String.Format("Google Login Failed:<br />{0}<br /><pre>{1}</pre>", ex.Message, userinfo));
                    Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("Exception"), false);
                    return;
                }

            }
        }

        #endregion

        #region LinkedIn Methods

        private void OAuthCallBackLinkedIn(PortalEnums.SocialMedia.OAuthCallbackAction callbackAction, string code)
        {
            if (string.IsNullOrEmpty(Request["error"]) == false || string.IsNullOrEmpty(Request["error_description"]) == false)
            {
                Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("OAuthorizationFailed"), false);
            }

            switch (callbackAction)
            {
                case PortalEnums.SocialMedia.OAuthCallbackAction.Login:
                case PortalEnums.SocialMedia.OAuthCallbackAction.Register:
                    LoginWithLinkedIn(code);
                    break;
                case PortalEnums.SocialMedia.OAuthCallbackAction.Apply:
                case PortalEnums.SocialMedia.OAuthCallbackAction.ApplyLogin:
                    ApplyWithLinkedIn();
                    break;
                default:
                    break;
            }
        }

        private void LoginWithLinkedIn(string code)
        {
            string linkedinconsumerkey = string.Empty;
            string linkedinconsumersecret = string.Empty;

            GlobalSettingsService service = new GlobalSettingsService();
            using (TList<Entities.GlobalSettings> globalsettinglist = service.GetBySiteId(SessionData.Site.SiteId))
            {
                Entities.GlobalSettings globalsetting = globalsettinglist[0];
                linkedinconsumerkey = globalsetting.LinkedInApi;
                linkedinconsumersecret = globalsetting.LinkedInApiSecret;
            }

            string consumer_key = linkedinconsumerkey;
            string consumer_secret = linkedinconsumersecret;
            string googleuri = Session["SocialRequestedURL"].ToString();

            //init a linkedin module to exchange for an access token using the oauth token
            oAuthLinkedIn limodule = new oAuthLinkedIn(consumer_key, consumer_secret);

            string s = limodule.oAuth2AccessToken(code, HttpUtility.UrlEncode(googleuri), consumer_key, consumer_secret);

            string strOAuthToken = string.Empty;
            string strOAuthTokenSecret = string.Empty;

            //extract the access token from linkedin
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Dictionary<string, string> oAuthResult = jss.Deserialize<Dictionary<string, string>>(s);
            string accessToken = oAuthResult["access_token"];

            if (string.IsNullOrEmpty(accessToken))
            {
                Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("OAuthorizationFailed"), false);
                return;
            }

            //use the access token to get profile and email
            string profileJson = limodule.oAuth2GetProfile(accessToken, true);
            string email = limodule.oAuth2GetEmail(accessToken, true);
            LinkedInProfile profile = jss.Deserialize<LinkedInProfile>(profileJson);

            if (profile == null || string.IsNullOrEmpty(email))
            {
                Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("OAuthorizationFailed"), false);
                return;
            }

            //finally process the profile for login
            int loginErrorCode = 0; //0 means no error

            loginErrorCode = ProcessSocialUser(profile.id, email.Replace("\"", ""), profile.firstName, profile.lastName);

            if (loginErrorCode == 0)
                Response.Redirect("~/member/default.aspx", false);
            else
                Response.Redirect("~/member/login.aspx?oautherror=" + loginErrorCode, false);
        }

        private void ApplyWithLinkedIn()
        {
            //Linkedin In Methods
            if (Request.Params["state"] == "DCEEFWF45453sdffef424" && Request.Params["code"] != string.Empty)
            {
                string code = Request.Params["code"];
                oAuthLinkedIn _oauth = new oAuthLinkedIn();
                string linkedinconsumerkey = string.Empty;
                string linkedinconsumersecret = string.Empty;

                GlobalSettingsService service = new GlobalSettingsService();
                using (TList<Entities.GlobalSettings> globalsettinglist = service.GetBySiteId(SessionData.Site.SiteId))
                {
                    Entities.GlobalSettings globalsetting = globalsettinglist[0];
                    linkedinconsumerkey = globalsetting.LinkedInApi;
                    linkedinconsumersecret = globalsetting.LinkedInApiSecret;
                }
                string http = (Request.IsSecureConnection) ? "https" : "http";

                _oauth.ConsumerKey = linkedinconsumerkey;
                _oauth.ConsumerKey = linkedinconsumersecret;
                string strId = (string.IsNullOrWhiteSpace(ID)) ? string.Empty : HttpUtility.UrlEncode("?id=" + ID);
                string strJobUrl = (string.IsNullOrWhiteSpace(joburl)) ? string.Empty : HttpUtility.UrlEncode("&joburl=" + HttpUtility.UrlEncode(joburl));
                string strReferrer = (string.IsNullOrWhiteSpace(Referrer)) ? string.Empty : HttpUtility.UrlEncode("&referrer=" + HttpUtility.UrlEncode(Referrer));
                strReferrer += (string.IsNullOrWhiteSpace(profession)) ? string.Empty : HttpUtility.UrlEncode("&profession=" + HttpUtility.UrlEncode(profession));
                strReferrer += (string.IsNullOrWhiteSpace(jobname)) ? string.Empty : HttpUtility.UrlEncode("&jobname=" + HttpUtility.UrlEncode(jobname));
                strReferrer += HttpUtility.UrlEncode("&cbtype=linkedin&cbaction=" + Request["cbaction"]);
                string s = _oauth.oAuth2AccessToken(code, String.Format("{4}%3a%2f%2f{0}%2foauthcallback.aspx{1}{2}{3}", HttpUtility.UrlEncode(HostUrl), strId, strJobUrl, strReferrer, http), linkedinconsumerkey, linkedinconsumersecret);
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Dictionary<string, string> oAuthResult = jss.Deserialize<Dictionary<string, string>>(s);
                string accessToken = oAuthResult["access_token"];
                string profile = _oauth.oAuth2GetProfile(accessToken);
                string email = _oauth.oAuth2GetEmail(accessToken);

                if (profile.StartsWith("Error:"))
                {
                    Response.Write(profile);
                    Response.Redirect("/member/login.aspx?oautherror=1", false);
                    return;
                }

                if (email.StartsWith("Error:"))
                {
                    Response.Write(email);
                    Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("OAuthorizationFailed"), false);
                    return;
                }

                GeneralAPIMember gam = new GeneralAPIMember();
                XmlDocument ppxml = new XmlDocument();
                ppxml.LoadXml(profile);

                XmlDocument pexml = new XmlDocument();
                pexml.LoadXml(email);

                gam.FirstName = ppxml.GetElementsByTagName("first-name")[0].InnerText;
                gam.Surname = ppxml.GetElementsByTagName("last-name")[0].InnerText;
                gam.EmailAddress = pexml.GetElementsByTagName("email-address")[0].InnerText;

                if (string.IsNullOrWhiteSpace(ID))
                {
                    LoginFromAPI(gam, "LinkedIn", true, accessToken);
                }
                else
                {
                    LoginFromAPI(gam, "LinkedIn", false, accessToken);

                    PortalEnums.SocialMedia.OAuthCallbackAction callbackAction;
                    if (Enum.TryParse<PortalEnums.SocialMedia.OAuthCallbackAction>(Request["cbaction"], true, out callbackAction))
                    {
                        if (callbackAction == PortalEnums.SocialMedia.OAuthCallbackAction.ApplyLogin)
                        {
                            Response.Redirect(joburl, false);
                        }
                        else if (callbackAction == PortalEnums.SocialMedia.OAuthCallbackAction.Apply)
                        {
                            string strUrl = string.Empty;
                            using (Entities.Sites site = SitesService.GetBySiteId(SessionData.Site.SiteId))
                            {
                                if (!string.IsNullOrWhiteSpace(site.SiteAdminLogoUrl))
                                {
                                    strUrl = string.Format("/media/{0}/{1}", ConfigurationManager.AppSettings["SitesFolder"], site.SiteAdminLogoUrl);
                                }
                                else
                                {
                                    strUrl = Page.ResolveUrl("~/GetAdminLogo.aspx?SiteID=" + SessionData.Site.SiteId.ToString());
                                }
                            }

                            string strHTML = _oauth.oAuth2GetProfileHTML(accessToken, strUrl);

                            ApplyJob(strHTML, "LinkedIn", "LinkedIn.docx");
                        }
                    }
                }
            }
        }

        private LinkedInProfile RetrieveLinkedInProfile(string linkedinconsumerkey, string linkedinconsumersecret, string token, string tokenSecret)
        {
            string stringResult = string.Empty;
            oAuthLinkedIn _oauth = new oAuthLinkedIn(linkedinconsumerkey, linkedinconsumersecret);

            _oauth.Token = token;
            _oauth.TokenSecret = tokenSecret;

            string profileJson = _oauth.GetUserInfo();

            JavaScriptSerializer ser = new JavaScriptSerializer();
            LinkedInProfile thisProfile = ser.Deserialize<LinkedInProfile>(profileJson);

            return thisProfile;
        }

        private string RetrieveLinkedInEmail(string linkedinconsumerkey, string linkedinconsumersecret, string token, string tokenSecret)
        {
            string result = string.Empty;
            oAuthLinkedIn _oauth = new oAuthLinkedIn(linkedinconsumerkey, linkedinconsumersecret);

            _oauth.Token = token;
            _oauth.TokenSecret = tokenSecret;

            return result = _oauth.GetUserEmail();
        }
        #endregion
        #region Indeed Methods

        private void OAuthCallBackIndeed(PortalEnums.SocialMedia.OAuthCallbackAction callbackAction, string code)
        {

            switch (callbackAction)
            {
                case PortalEnums.SocialMedia.OAuthCallbackAction.Apply:
                    ApplyWithIndeed();
                    break;
                default:
                    break;
            }
        }

        private void ApplyWithIndeed()
        {
            _logger.Debug("Handling apply with Indeed Callback");
            //Indeed Methods
            string IndeedDataFile = ConfigurationManager.AppSettings["IndeedDataFile"];

            string data = string.Empty;
            try
            {
                StreamReader reader = new StreamReader(Request.InputStream);
                data = reader.ReadToEnd();

                oAuthIndeed _oauth = new oAuthIndeed();

                if (!string.IsNullOrEmpty(IndeedDataFile))
                {
                    string fname = Server.MapPath(IndeedDataFile);

                    File.WriteAllText(fname, data);
                }

                JavaScriptSerializer jss = new JavaScriptSerializer();

                oAuthIndeed.IndeedContract indeeddata = jss.Deserialize<oAuthIndeed.IndeedContract>(data);
                if (indeeddata == null)
                {
                    _logger.WarnFormat("Failed to deserialize the indeed data: \r\n{0}", data);
                    Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("Exception"), false);
                    return;
                }

                _logger.Debug(string.Format("Application: {0}; Resume: {1}; file: {2}", indeeddata.applicant != null, (indeeddata.applicant != null && indeeddata.applicant.resume != null), (indeeddata.applicant != null && indeeddata.applicant.resume != null && indeeddata.applicant.resume.file != null)));
                if (indeeddata.applicant == null || indeeddata.applicant.resume == null || indeeddata.applicant.resume.file == null)
                {
                    _logger.Debug("Applicant, resume or file missing");
                    if (!string.IsNullOrEmpty(IndeedDataFile))
                    {
                        string fname = Server.MapPath(IndeedDataFile);

                        File.AppendAllText(fname, "Resume missing");
                    }

                    Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("OAuthorizationFailed"), false);
                    return;
                }

                // Insert Job Application
                GeneralAPIMember gam = new GeneralAPIMember();
                bool validated = false;
                if (indeeddata.applicant.resume.json == null)
                {
                    _logger.Debug("applicant resume json is null, finding name based on full name");

                    string[] names = indeeddata.applicant.fullName.Split(new char[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);

                    gam.FirstName = names[0];
                    gam.Surname = string.Empty;
                    if (names.Length == 2)
                    {
                        gam.FirstName = names[0];
                        gam.Surname = names[1];
                    }
                }
                else
                {
                    _logger.Debug("found applicant resume json, Determining full name");
                    gam.FirstName = indeeddata.applicant.resume.json.firstName;
                    gam.Surname = indeeddata.applicant.resume.json.lastName;
                    validated = true;
                }
                gam.EmailAddress = indeeddata.applicant.email;


                LoginFromAPI(gam, "Indeed", false, string.Empty, validated);
                if (Request.Params["cbaction"].ToLower() == "apply")
                {
                    IndeedApplyJob(Convert.ToInt32(indeeddata.job.jobId), indeeddata.job.jobUrl, indeeddata.applicant.resume.file.fileName, indeeddata.applicant.resume.file.data);
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                if (!string.IsNullOrEmpty(IndeedDataFile))
                {
                    string fname = Server.MapPath(IndeedDataFile);

                    File.AppendAllText(fname, data + "\n" + ex.Message + "\n" + ex.StackTrace);
                }

                //Response.Write(ex.Message);
                Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("Exception"), false);
            }
        }

        private void OAuthCallBackSeek(PortalEnums.SocialMedia.OAuthCallbackAction callbackAction, string code)
        {
            switch (callbackAction)
            {
                case PortalEnums.SocialMedia.OAuthCallbackAction.Apply:
                    ApplyWithSeek(code);
                    break;
                default:
                    break;
            }
        }


        private void ApplyWithSeek(string authorizationCode)
        {

            //Seek Methods
            try
            {
                // now that we have been authorized, we need to exchanged our authorization code for a Bearer access token from SEEK. This will allow us
                // to access the profile data of the user.
                JavaScriptSerializer jss = new JavaScriptSerializer();
                oAuthSeek _oauth = new oAuthSeek();

                const string grantType = "authorization_code";
                const string bodyFormat = "code={0}&redirect_uri={1}&grant_type={2}";

                string clientId = string.Empty;
                string clientSecret = string.Empty;
                string errormsg = string.Empty;
                string filename = string.Empty;
                string applicationid = string.Empty;
                string firstname = string.Empty;
                string lastname = string.Empty;
                string email = string.Empty;
                AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);
                if (integrations.Seek != null && integrations.Seek.Valid)
                {
                    clientId = integrations.Seek.ClientID;
                    clientSecret = integrations.Seek.ClientSecret;

                    if (!string.IsNullOrWhiteSpace(State))
                    {
                        string[] splits = State.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                        string jobid = splits[0];
                        string url = splits[1];

                        if (Request.Params["error"] == "access_denied")
                        {
                            Response.Redirect(url, false);
                            return;
                        }
                        else
                        {
                            HttpCookie seekCookie = new HttpCookie("Seek");
                            seekCookie.Value = authorizationCode;
                            seekCookie.Expires = DateTime.Now.AddMinutes(20);

                            Response.Cookies.Add(seekCookie);

                            Response.Redirect(url + "#applywith", false);
                            return;

                            //using (Entities.Jobs job = JobsService.GetByJobId(Convert.ToInt32(jobid)))
                            //{
                            //    if (job != null)
                            //    {
                            //        string authorizationToken = _oauth.oAuth2GetAuthorizeToken((ConfigurationManager.AppSettings["IsSeekLive"] == "1"), Request.Url.Host, clientId, clientSecret, authorizationCode, out errormsg);
                            //        if (string.IsNullOrEmpty(errormsg))
                            //        {
                            //            string result = _oauth.oAuth2GetPrefilled((ConfigurationManager.AppSettings["IsSeekLive"] == "1"), clientId, clientSecret, authorizationToken, integrations.Seek.AdvertiserID, job.JobName, url, "", "", out applicationid, out firstname, out lastname, out email, out filename, out errormsg);
                            //            GeneralAPIMember gam = new GeneralAPIMember();
                            //            gam.FirstName = firstname;
                            //            gam.Surname = lastname;
                            //            gam.EmailAddress = email;

                            //            LoginFromAPI(gam, "Seek", false, string.Empty);
                            //            // If filename is empty, resume is empty, build html according to returned data
                            //            bool success = false;

                            //            if (string.IsNullOrWhiteSpace(filename))
                            //            {
                            //                string strUrl = Page.ResolveUrl("~/GetAdminLogo.aspx?SiteID=" + SessionData.Site.SiteId.ToString());
                            //                string strHTML = _oauth.oAuth2GetProfileHTML(result, strUrl);

                            //                success = SeekApplyJob(Convert.ToInt32(jobid), url, "Seek.docx", strHTML, true, out errormsg);
                            //            }
                            //            else
                            //            {
                            //                // resume exists
                            //                success = SeekApplyJob(Convert.ToInt32(jobid), url, filename, result, false, out errormsg);
                            //            }

                            //            if (errormsg == "applied")
                            //            {
                            //                Response.Redirect(url, false);
                            //            }
                            //            else
                            //            {
                            //                if (string.IsNullOrEmpty(errormsg) && success)
                            //                {
                            //                    _oauth.oAuth2ApplyComplete((ConfigurationManager.AppSettings["IsSeekLive"] == "1"), clientId, clientSecret, applicationid, out errormsg);
                            //                    if (!string.IsNullOrEmpty(errormsg))
                            //                    {
                            //                        Response.Write(errormsg);
                            //                        Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("OAuthorizationFailed"), false);
                            //                    }
                            //                    else
                            //                    {
                            //                        Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.JOBAPPLY_SUCCESS, "", "", ""), false);
                            //                    }
                            //                }
                            //                else
                            //                {
                            //                    Response.Write(errormsg);
                            //                    Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("OAuthorizationFailed"), false);
                            //                }
                            //            }
                            //        }
                            //        else
                            //        {
                            //            Response.Write(errormsg);
                            //            Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("OAuthorizationFailed"), false);
                            //        }
                            //    }
                            //}
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message + "<br />" + ex.StackTrace);
                Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("Exception"), false);
            }
        }

        #endregion

        #region Login / Register Methods

        private int ProcessSocialUser(string externalUserID, string email, string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                _logger.WarnFormat("User requires Email, firstname and lastname. email: {0}, Firstname:{1}, lastname:{2}", email, firstName, lastName);
                return LoginErrorCodeGet("InputError");
            }
            int loginErrorCode = 0;

            try
            {
                bool newMemberCreated = false;
                string newMemberPassword = null;
                using (Entities.Members member = MembersService.SocialMediaUserHandler(externalUserID, email, firstName, lastName, out newMemberCreated, out newMemberPassword))
                {
                    //log user in
                    if (member.Valid)
                    {
                        SessionService.SetMember(member);
                        member.LastLogon = DateTime.Now;

                        MembersService.Update(member);
                    }
                    else
                        loginErrorCode = LoginErrorCodeGet("InvalidAccount");

                    if (loginErrorCode == 0 && newMemberCreated)
                    {
                        if (!string.IsNullOrEmpty(SessionData.Site.MemberRegistrationNotificationEmail))
                        {
                            //Send confirmation email to new member and site's admin
                            MailService.SendMemberRegistrationToSiteAdmin(member, string.Empty, string.Empty, null, SessionData.Site.MemberRegistrationNotificationEmail);
                        }

                        //Send confirmation email to new member
                        MailService.SendNewJobApplicationAccount(member, newMemberPassword);
                    }

                }
            }
            catch (Exception e)
            {
                loginErrorCode = LoginErrorCodeGet("Exception");
            }
            return loginErrorCode;
        }

        private int LoginErrorCodeGet(string errorType)
        {
            switch (errorType)
            {
                case "InvalidAccount":
                    return 1;
                case "OAuthorizationFailed":
                    return 2;
                case "InputError":
                    return 3;
                case "Exception":
                    return 5;
            }
            return 99;
        }

        #endregion

        private void OAuthErrorCheck()
        {
            bool hasError = false;
            if (!string.IsNullOrWhiteSpace(Request.Params["error"]))
            {
                _logger.Debug(string.Format("oAuthError: {0}", Request.Params["error"]));
                hasError = true;
            }

            if (!string.IsNullOrWhiteSpace(Request.Params["error_description"]))
            {
                _logger.Debug(string.Format("oAuthError_description: {0}", Request.Params["error_description"]));
                hasError = true;
            }

            if (hasError)
            {
                if (string.IsNullOrWhiteSpace(ID))
                {
                    Response.Redirect("~/member/login.aspx", false);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(joburl))
                        Response.Redirect(Utils.GetApplyJobUrl(Convert.ToInt32(ID), jobname, profession), false);
                    else
                        Response.Redirect(joburl, false);
                }
            }
        }
    }

    public class GeneralAPIMember
    {
        public string FirstName;
        public string Surname;
        public string EmailAddress;

        public GeneralAPIMember() { }
    }

    [DataContract]
    public class GoogleContract
    {
        [DataMember(Name = "given_name")]
        public string GivenName;

        [DataMember(Name = "family_name")]
        public string FamilyName;

        [DataMember(Name = "email")]
        public string Email;
    }

    public class FacebookContract
    {
        public string first_name;

        public string last_name;

        public string email;

        public string id;
    }
}