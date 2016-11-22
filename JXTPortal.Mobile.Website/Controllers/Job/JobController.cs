using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JXTPortal.Entities;
using JXTPortal.Domain.Services;
using JXTPortal.Mobile.Website.Attributes;
using JXTPortal.Domain.ViewModel;
using System.IO;
using System.Runtime;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using System.Xml;
using System.Configuration;
using SocialMedia;
using JXTPortal.Common;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using NotesFor.HtmlToOpenXml;

namespace JXTPortal.Mobile.Website.Controllers.Job
{
    public class JobController : Controller
    {
        private SitesService _sitesService;
        private SitesService SitesService
        {
            get
            {
                if (_sitesService == null)
                    _sitesService = new SitesService();
                return _sitesService;
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

        private GlobalSettingsService _globalsettingsservice;
        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_globalsettingsservice == null)
                    _globalsettingsservice = new GlobalSettingsService();
                return _globalsettingsservice;
            }
        }
        //
        // GET: /Job/
        #region "Job Detail"

        public ActionResult Detail(int id)
        {
            JobService service = new JobService();
            return View(service.GetById(SessionData.Site.SiteId, id));
        }

        #endregion

        public ActionResult oauthcallback()
        {
            string ID = Request.Params["id"];
            string joburl = Request.Params["joburl"];
            string referrer = Request.Params["referrer"]; 
            SessionMember sessionMember = null; 
            //Linkedin In Methods

            if (string.IsNullOrWhiteSpace(Request.Params["error"]) == false && string.IsNullOrWhiteSpace(Request.Params["error_description"]) == false)
            {
                if (string.IsNullOrWhiteSpace(ID))
                {
                    RedirectToAction("account", "login");
                }
                else
                {
                    System.Int32 jobid = Convert.ToInt32(ID);
                    return RedirectToAction("Detail", "Job", new { id = jobid });
                }
            }

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

                _oauth.ConsumerKey = linkedinconsumerkey;
                _oauth.ConsumerKey = linkedinconsumersecret;
                string strId = (string.IsNullOrWhiteSpace(ID)) ? string.Empty : "?id=" + ID;
                string strJobUrl = (string.IsNullOrWhiteSpace(joburl)) ? string.Empty : "&joburl=" + HttpUtility.UrlEncode(joburl);
                string strReferrer = (string.IsNullOrWhiteSpace(referrer)) ? string.Empty : "&referrer=" + HttpUtility.UrlEncode(referrer);
                string s = _oauth.oAuth2AccessToken(code, HttpUtility.UrlEncode(String.Format("http://{0}/Job/oauthcallback{1}{2}{3}", Request.Url.Authority, strId, strJobUrl, strReferrer)), linkedinconsumerkey, linkedinconsumersecret);
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Dictionary<string, string> oAuthResult = jss.Deserialize<Dictionary<string, string>>(s);
                string accessToken = oAuthResult["access_token"];
                string profile = _oauth.oAuth2GetProfile(accessToken);
                string email = _oauth.oAuth2GetEmail(accessToken);

                if (profile.StartsWith("Error:"))
                {
                    Response.Write(profile);
                    return View();
                }

                if (email.StartsWith("Error:"))
                {
                    Response.Write(email);
                    return View();
                }

                GeneralAPIMember gam = new GeneralAPIMember();
                XmlDocument ppxml = new XmlDocument();
                ppxml.LoadXml(profile);

                XmlDocument pexml = new XmlDocument();
                pexml.LoadXml(email);

                gam.FirstName = ppxml.GetElementsByTagName("first-name")[0].InnerText;
                gam.Surname = ppxml.GetElementsByTagName("last-name")[0].InnerText;
                gam.EmailAddress = pexml.GetElementsByTagName("email-address")[0].InnerText;

                LoginMember(gam, accessToken);
                sessionMember = (SessionMember)System.Web.HttpContext.Current.Session[PortalConstants.Session.SessionMember]; 

                if (string.IsNullOrWhiteSpace(ID))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Check if member has applied for the job

                    using (TList<JXTPortal.Entities.JobApplication> jobapp = JobApplicationService.GetByJobId(Convert.ToInt32(ID)))
                    {
                        if (jobapp != null)
                        {
                            jobapp.Filter = "MemberID = " + sessionMember.MemberId.ToString();
                            if (jobapp.Count > 0)
                            {
                                // Member has applied the job
                                System.Int32 jobid = Convert.ToInt32(ID);
                                return RedirectToAction("Apply", "Job", new { id = jobid });
                            }
                        }

                        string strUrlReferral = string.Format("{0}Apply with LinkedIn", (!string.IsNullOrWhiteSpace(referrer)) ? referrer + " - " : string.Empty);

                        // [TODO] Member Apply for job sp
                        using (JXTPortal.Entities.JobApplication newjobapp = new JXTPortal.Entities.JobApplication())
                        {
                            newjobapp.ApplicationDate = DateTime.Now;
                            newjobapp.JobId = Convert.ToInt32(ID);
                            newjobapp.MemberId = sessionMember.MemberId;

                            newjobapp.JobAppValidateId = new Guid();
                            newjobapp.SiteIdReferral = SessionData.Site.SiteId;
                            newjobapp.UrlReferral = strUrlReferral;
                            newjobapp.FirstName = SessionData.Member.FirstName;
                            newjobapp.Surname = SessionData.Member.Surname;
                            newjobapp.EmailAddress = SessionData.Member.EmailAddress;
                            newjobapp.MobilePhone = SessionData.Member.Phone;
                            newjobapp.ApplicationStatus = (int)PortalEnums.JobApplications.ApplicationStatus.Applied;
                            newjobapp.Draft = false;

                            if (JobApplicationService.Insert(newjobapp))
                            {
                                string errormessage = string.Empty;

                                string ftpresumepath = string.Empty;
                                string ftpusername = string.Empty;
                                string ftppassword = string.Empty;

                                FtpClient ftpclient = new FtpClient();
                                ftpresumepath = ConfigurationManager.AppSettings["FTPJobApplyResumeUrl"];
                                ftpusername = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                                ftppassword = ConfigurationManager.AppSettings["FTPJobApplyPassword"];

                                ftpclient.Username = ftpusername;
                                ftpclient.Password = ftppassword;

                                string strUrl = string.Empty;

                                using (Entities.Sites site = SitesService.GetBySiteId(SessionData.Site.SiteId))
                                {
                                    if (!string.IsNullOrWhiteSpace(site.SiteAdminLogoUrl))
                                    {
                                        strUrl = string.Format("http://{0}/media/{1}/{2}", SessionData.Site.SiteUrl, ConfigurationManager.AppSettings["SitesFolder"], site.SiteAdminLogoUrl);
                                    }
                                    else
                                    {
                                        strUrl = "http://" + SessionData.Site.SiteUrl + "/GetAdminLogo.aspx?SiteID=" + SessionData.Site.SiteId.ToString();
                                    }
                                }
                                string strHTML = _oauth.oAuth2GetProfileHTML(accessToken, strUrl);

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
                                    string filename = string.Format("{0}_Resume_{1}", newjobapp.JobApplicationId, "LinkedIn.docx");

                                    newjobapp.MemberResumeFile = filename;
                                    ftpclient.UploadFileFromStream(generatedDocument, ftpresumepath + filename, out errormessage);

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

                                            MailService.SendMemberJobApplicationEmail(member);
                                            MailService.SendAdvertiserJobApplicationEmail(member, newjobapp, new HybridDictionary(), siteid);
                                            return RedirectToAction("ApplySuccess");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return RedirectToAction("Detail", "Job", new { id = Convert.ToInt32(ID) });
        }

        private void LoginMember(GeneralAPIMember gam, string accessToken)
        {
            Domain.Services.MembershipService mss = new Domain.Services.MembershipService();
            MemberModel.LoginModel model = new MemberModel.LoginModel();

            Entities.Members member = MembersService.GetBySiteIdEmailAddress(SessionData.Site.SiteId, gam.EmailAddress);
            if (member != null)
            {
                // Existing Member
                model.UserName = member.Username;
                model.Password = member.Password;

                Domain.ViewModel.Common.JXTMembershipStatus status = mss.Login(model, true);

                if (status == Domain.ViewModel.Common.JXTMembershipStatus.Success)
                {
                    JXTPortal.Domain.Services.MembershipService service = new JXTPortal.Domain.Services.MembershipService();
                    SessionService.RemoveAdvertiserUser();
                    SessionService.SetMember(service.Convert(model));
                    service = null;
                }
            }
            else
            {
                // New Member
                int countryid = 1;
                TList<GlobalSettings> gslist = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId);
                if (gslist.Count > 0)
                {
                    if (gslist[0].DefaultCountryId.HasValue)
                    {
                        countryid = gslist[0].DefaultCountryId.Value;
                    }
                }

                using (JXTPortal.Entities.Members objMembers = new JXTPortal.Entities.Members())
                {
                    objMembers.SiteId = SessionData.Site.SiteId;
                    objMembers.FirstName = gam.FirstName;
                    objMembers.Surname = gam.Surname;
                    objMembers.EmailAddress = gam.EmailAddress;
                    objMembers.EmailFormat = (int)PortalEnums.Email.EmailFormat.HTML;
                    objMembers.Username = gam.EmailAddress;
                    objMembers.LinkedInAccessToken = accessToken;
                    objMembers.CountryId = countryid;
                    string newpassword = System.Web.Security.Membership.GeneratePassword(10, 0);
                    objMembers.Password = CommonService.EncryptMD5(newpassword);
                    objMembers.ValidateGuid = Guid.NewGuid();
                    objMembers.SearchField = String.Format("{0} {1}",
                                               objMembers.FirstName,
                                               objMembers.Surname);
                    objMembers.Valid = true;
                    objMembers.RequiredPasswordChange = false;

                    if (MembersService.Insert(objMembers))
                    {
                        //Send confirmation email
                        MailService.SendMemberRegistration(objMembers, newpassword);

                        model.UserName = objMembers.Username;
                        model.Password = objMembers.Password;

                        Domain.ViewModel.Common.JXTMembershipStatus status = mss.Login(model, true);

                        if (status == Domain.ViewModel.Common.JXTMembershipStatus.Success)
                        {
                            JXTPortal.Domain.Services.MembershipService service = new JXTPortal.Domain.Services.MembershipService();
                            SessionService.RemoveAdvertiserUser();
                            SessionService.SetMember(service.Convert(model));
                            service = null;
                        }
                    }
                }
            }
        }

        #region "Search"

        public ActionResult Search()
        {
            SiteProfessionService _siteProfessionService = new SiteProfessionService();
            SiteLocationService _siteLocationService = new SiteLocationService();
            SiteWorkTypeService _siteWorkTypeService = new SiteWorkTypeService();
            //SalaryService _salaryService = new SalaryService();
            SiteSalaryTypeService _siteSalaryTypeService = new SiteSalaryTypeService();
            ViewSalaryService _salaryService = new ViewSalaryService();

            var model = new JobModel.Search();

            //Professions

            foreach (var profession in _siteProfessionService.GetBySiteIDWithActiveJobs(SessionData.Site.SiteId))
            {
                model.Professions.Add(profession.ProfessionId.ToString(), profession.SiteProfessionName);
            }

            //Location

            foreach (var location in _siteLocationService.GetBySiteId(SessionData.Site.SiteId))
            {
                model.Locations.Add(location.LocationId.ToString(), location.SiteLocationName);
            }

            //Worktype

            foreach (var worktype in _siteWorkTypeService.GetBySiteId(SessionData.Site.SiteId))
            {
                model.WorkTypes.Add(worktype.WorkTypeId.ToString(), worktype.SiteWorkTypeName);
            }

            //Salary Types
            List<Entities.SiteSalaryType> salaryTypeList = _siteSalaryTypeService.Get_ValidListBySiteID(SessionData.Site.SiteId);
            foreach (Entities.SiteSalaryType salaryType in salaryTypeList)
            {
                model.SalaryTypes.Add(salaryType.SalaryTypeId.ToString(), salaryType.SalaryTypeName);
            }

            // Salary
            if (salaryTypeList.Count > 0)
            {
                VList<ViewSalary> salaryFromList = _salaryService.GetCustomSalaryFrom(SessionData.Site.SiteId, salaryTypeList[0].SalaryTypeId);
                foreach (var salary in salaryFromList)
                {
                    model.SalaryFrom.Add(string.Format("{0};{1};{2}", salary.CurrencyId, salary.Amount, salary.SalaryId), salary.SalaryDisplay);
                }

                if (salaryFromList.Count > 0)
                {
                    ViewSalary vsFrom = salaryFromList[0];
                    salaryFromList.Clear();
                    salaryFromList = _salaryService.GetCustomSalaryTo(SessionData.Site.SiteId, vsFrom.CurrencyId, vsFrom.SalaryTypeId, vsFrom.Amount);
                    foreach (var salary in salaryFromList)
                    {
                        model.SalaryTo.Add(string.Format("{0};{1};{2}", salary.CurrencyId, salary.Amount, salary.SalaryId), salary.SalaryDisplay);
                    }

                }
            }

            salaryTypeList.Clear();

            _siteSalaryTypeService = null;
            _salaryService = null;

            _siteProfessionService = null;
            _siteLocationService = null;
            _siteWorkTypeService = null; ;
            return View(model);
        }

        public ActionResult Result()
        {
            JobModel.Result searchresult = SearchForJobsWithCriteria(new JobModel.Search(), 0);
            return View(searchresult);
        }

        [HttpPost]
        public ActionResult Result(JobModel.Search model)
        {
            JobModel.Result searchresult = SearchForJobsWithCriteria(model, 0);
            return View(searchresult);
        }

        public ActionResult ViewAll()
        {
            JobService JobService = new JobService();
            JobModel.Result searchresult = JobService.Search(SessionData.Site.SiteId, new JobModel.Search(), 0);
            GenerateJoblink(ref searchresult);
            return View("Result", searchresult);
        }

        public ActionResult ResultJson(string Keyword, int WorkTypeId, int ProfessionId,
                                    IEnumerable<string> RoleIds, int LocationId, IEnumerable<string> AreaIds,
                                    int SalaryTypeId, string SalaryFromId, string SalaryToId, int Pageno)
        {
            JobService JobService = new JobService();
            JobModel.Search model = new JobModel.Search()
            {
                Keyword = Keyword,
                WorkTypeId = WorkTypeId,
                ProfessionId = ProfessionId,
                RoleId = RoleIds,
                LocationId = LocationId,
                AreaId = AreaIds,
                SalaryTypeId = SalaryTypeId,
                SalaryFromId = SalaryFromId,
                SalaryToId = SalaryToId
            };
            JobModel.Result resultmodel = JobService.Search(SessionData.Site.SiteId, model, Pageno);
            GenerateJoblink(ref resultmodel);

            return Json(resultmodel.JobSearchResults, JsonRequestBehavior.AllowGet);
        }

        internal void GenerateJoblink(ref JobModel.Result results)
        {
            foreach (var result in results.JobSearchResults)
                result.UrlAction = string.Format("/Job/Detail/{0}", result.JobId.ToString());
        }

        #region "Search Criteria Helpers"

        public ActionResult Professions()
        {
            SiteProfessionService _siteProfessionService = new SiteProfessionService();
            Dictionary<string, string> professions = new Dictionary<string, string>();

            foreach (var profession in _siteProfessionService.GetBySiteIDWithActiveJobs(SessionData.Site.SiteId))
            {
                professions.Add(profession.ProfessionId.ToString(), profession.SiteProfessionName);
            }

            _siteProfessionService = null;

            return Json(professions.Select(x => new { Id = x.Key, Name = x.Value }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Locations()
        {
            SiteLocationService _siteLocationService = new SiteLocationService();
            Dictionary<string, string> locations = new Dictionary<string, string>();

            foreach (var location in _siteLocationService.GetBySiteId(SessionData.Site.SiteId))
            {
                locations.Add(location.LocationId.ToString(), location.SiteLocationName);
            }

            _siteLocationService = null;

            return Json(locations.Select(x => new { Id = x.Key, Name = x.Value }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult WorkTypes()
        {
            SiteWorkTypeService _siteWorkTypeService = new SiteWorkTypeService();
            Dictionary<string, string> worktypes = new Dictionary<string, string>();

            foreach (var worktype in _siteWorkTypeService.GetBySiteId(SessionData.Site.SiteId))
            {
                worktypes.Add(worktype.WorkTypeId.ToString(), worktype.SiteWorkTypeName);
            }

            _siteWorkTypeService = null;

            return Json(worktypes.Select(x => new { Id = x.Key, Name = x.Value }), JsonRequestBehavior.AllowGet);

        }

        public ActionResult Areas(int locationId)
        {
            SiteAreaService _siteAreaService = new SiteAreaService();
            Dictionary<string, string> areas = new Dictionary<string, string>();

            foreach (var area in _siteAreaService.GetByLocationID(SessionData.Site.SiteId, locationId))
            {
                areas.Add(area.AreaId.ToString(), area.SiteAreaName);
            }

            _siteAreaService = null;

            return Json(areas.Select(x => new { Id = x.Key, Name = x.Value }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Roles(int professionId)
        {
            SiteRolesService _siteRolesService = new SiteRolesService();
            Dictionary<string, string> roles = new Dictionary<string, string>();

            foreach (var role in _siteRolesService.GetByProfessionIDWithActiveJobs(SessionData.Site.SiteId, professionId))
            {
                roles.Add(role.RoleId.ToString(), role.SiteRoleName);
            }

            _siteRolesService = null;

            return Json(roles.Select(x => new { Id = x.Key, Name = x.Value }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSalaryRangeFrom(int salaryTypeId, string SalaryValueSet)
        {
            string[] valueset = SalaryValueSet.Split(';');
            int currencyId = Convert.ToInt32(valueset[0]);
            decimal amount = Convert.ToDecimal(valueset[1]);

            ViewSalaryService viewSalaryService = new ViewSalaryService();
            VList<ViewSalary> salaryFromList = viewSalaryService.GetCustomSalaryFrom(SessionData.Site.SiteId, salaryTypeId);
            viewSalaryService = null;

            return Json(salaryFromList.Select(x => new { Id = string.Format("{0};{1};{2}", x.CurrencyId, x.Amount, x.SalaryId), SalaryDisplay = x.SalaryDisplay }), JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetSalaryRangeTo(int salaryTypeId, string SalaryValueSet)
        {
            string[] valueset = SalaryValueSet.Split(';');
            int currencyId = Convert.ToInt32(valueset[0]);
            decimal amount = Convert.ToDecimal(valueset[1]);

            ViewSalaryService viewSalaryService = new ViewSalaryService();
            VList<ViewSalary> salaryToList = viewSalaryService.GetCustomSalaryTo(SessionData.Site.SiteId, currencyId, salaryTypeId, amount);
            viewSalaryService = null;

            return Json(salaryToList.Select(x => new { Id = string.Format("{0};{1};{2}", x.CurrencyId, x.Amount, x.SalaryId), SalaryDisplay = x.SalaryDisplay }), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #endregion

        public ActionResult SendMemberJobEmail(string jobName, string yourEmail, string yourName,
                                                int jobid, int siteid)
        {
            bool success = false;
            string errors = string.Empty;

            if (!string.IsNullOrEmpty(jobName) &&
                !string.IsNullOrEmpty(yourEmail) &&
                !string.IsNullOrEmpty(yourName))
            {
                try
                {
                    JobService jobService = new JobService();
                    jobService.SendMemberJobEmail(jobName, yourName, yourEmail, jobid, siteid);
                    success = true;
                }
                catch (Exception ex)
                {
                    errors = ex.ToString();
                }
            }

            return Json(new { success = success, errors = errors }, JsonRequestBehavior.AllowGet);
        }


        [CustomAuthorize]
        public ActionResult SaveJobJSON(int jobid)
        {
            string message = string.Empty;
            bool successful = false;

            JobsSavedService JobsSavedService = new JobsSavedService();
            successful = JobsSavedService.SavedJobForMember(jobid, false, ref message);
            JobsSavedService = null;

            return Json(new { successful = successful, message = message }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Apply(int id, string btnApply)
        {
            if (btnApply == "LinkedIn")
            {
                oAuthLinkedIn _oauth = new oAuthLinkedIn();
                GlobalSettingsService gss= new GlobalSettingsService();
                string LinkedInAPI = string.Empty;

                TList<JXTPortal.Entities.GlobalSettings> tgs = gss.GetBySiteId(SessionData.Site.SiteId);
                if (tgs.Count > 0)
                {
                    JXTPortal.Entities.GlobalSettings gs = tgs[0];
                    if (!string.IsNullOrEmpty(gs.LinkedInApi))
                    {
                        LinkedInAPI = gs.LinkedInApi;
                        string urlsuffix = string.Empty;
                        string http = "http://";

                        urlsuffix = http + Request.Url.Authority;
                        Response.Redirect(_oauth.MobileRequestToken(LinkedInAPI, urlsuffix, id.ToString(), "/Job/Detail/" + id.ToString(), Utils.GetUrlReferrerDomain()));
                    }
                }
            }

            MembershipService membershipService = new MembershipService();
            MemberModel.ApplyJobModel model = membershipService.LoadApplyJobModel(SessionData.Site.SiteId, id, (SessionData.Member != null) ? SessionData.Member.MemberId : 0);
            model.JobId = id;
            return View(model);
        }

        public ActionResult ProcessApply(MemberModel.ApplyJobModel model)
        {
            if (ModelState.IsValid)
            {
                JobService jobService = new JobService();
                model.MemberId = (SessionData.Member != null) ? SessionData.Member.MemberId : 0;
                bool success = jobService.ApplyJob(model,
                                    ConfigurationManager.AppSettings["ApplicationUploadCoverLetterPaths"],
                                    ConfigurationManager.AppSettings["ApplicationUploadResumePaths"]);

                if (success)
                {
                    return RedirectToAction("ApplySuccess", "Job");
                }
                else
                {
                    //meaning there is an error
                    return View(model);
                }
            }
            return View(model);
        }

        [CustomAuthorize]
        public ActionResult JsonApply(MemberModel.ApplyJobModel model)
        {
            List<ViewModelError> viewmodelerrors = new List<ViewModelError>();
            bool applySuccess = false;

            if (ModelState.IsValid)
            {
                JobService jobService = new JobService();
                model.MemberId = (SessionData.Member != null) ? SessionData.Member.MemberId : 0;
                applySuccess = jobService.ApplyJob(model,
                                    ConfigurationManager.AppSettings["ApplicationUploadCoverLetterPaths"],
                                    ConfigurationManager.AppSettings["ApplicationUploadResumePaths"]);
            }
            else
            {
                IEnumerable<System.Web.Mvc.ModelError> modelerrors = ModelState.SelectMany(x => x.Value.Errors);
                foreach (var modelerror in modelerrors)
                {
                    viewmodelerrors.Add(new ViewModelError() { Error = modelerror.ErrorMessage });
                }
            }
            return Json(new { success = applySuccess, errors = viewmodelerrors }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ApplySuccess()
        {
            return View();
        }

        public ActionResult ThirdPartyApply(int id)
        {
            JobService service = new JobService();
            JobModel.JobDetail model = service.GetById(SessionData.Site.SiteId, id);
            return View(model);
        }


        #region "Private Methods"

        private JobModel.Result SearchForJobsWithCriteria(JobModel.Search crit, int pageNumber)
        {
            JobService JobService = new JobService();
            JobModel.Result searchresult = JobService.Search(SessionData.Site.SiteId, crit, pageNumber);
            GenerateJoblink(ref searchresult);

            return searchresult;
        }

        #endregion

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

    [DataContract]
    public class FacebookContract
    {
        [DataMember(Name = "first_name")]
        public string GivenName;

        [DataMember(Name = "last_name")]
        public string FamilyName;

        [DataMember(Name = "email")]
        public string Email;
    }
}