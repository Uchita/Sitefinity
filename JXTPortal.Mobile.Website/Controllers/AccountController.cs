using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using JXTPortal.Domain.ViewModel;
using JXTPortal.Entities;
using JXTPortal.Mobile.Website;
using JXTPortal.Mobile.Website.Attributes;
using JXTPortal.Domain.ViewModel;
using JXTPortal.Domain.Services;
using JXTPortal.Common;
using System.Configuration;
using System.IO;

namespace JXTPortal.Mobile.Website.Controllers
{

    [CustomAuthorize]
    public class AccountController : Controller
    {
        private string bucketName = ConfigurationManager.AppSettings["AWSS3BucketName"];

        private string memberFileFolder, memberFileFolderFormat;
        public IFileManager FileManagerService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login()
        {
            return ContextDependentView();
        }

        //
        // POST: /Account/JsonLogin

        [AllowAnonymous]
        [HttpPost]
        public JsonResult JsonLogin(MemberModel.LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Domain.Services.MembershipService service = new Domain.Services.MembershipService();
                Domain.ViewModel.Common.JXTMembershipStatus status = service.Login(model);
                service = null;

                if (status == Domain.ViewModel.Common.JXTMembershipStatus.Success)
                {
                    SetMemberSession(model);
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    return Json(new { success = true, redirect = returnUrl });
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed
            return Json(new { errors = GetErrorsFromModelState() });
        }

        //
        // POST: /Account/Login

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(MemberModel.LoginModel model, string returnUrl)
        {
            //LoginModel model = new JXTPortal.Domain.ViewModel() { UserName = UserName, Password = Password, RememberMe = true };
            if (ModelState.IsValid)
            {
                Domain.Services.MembershipService service = new Domain.Services.MembershipService();
                Domain.ViewModel.Common.JXTMembershipStatus status = service.Login(model);
                service = null;

                if (status == Domain.ViewModel.Common.JXTMembershipStatus.Success)
                {
                    SetMemberSession(model);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private void SetMemberSession(MemberModel.LoginModel model)
        {
            JXTPortal.Domain.Services.MembershipService service = new JXTPortal.Domain.Services.MembershipService();
            SessionService.RemoveAdvertiserUser();
            SessionService.SetMember(service.Convert(model));
            service = null;
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            SessionService.RemoveMember();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            MemberModel.RegistrationModel model = new MemberModel.RegistrationModel();
            return View(model);
        }

        //
        // POST: /Account/JsonRegister

        [AllowAnonymous]
        public ActionResult JsonRegister(MemberModel.RegistrationModel model)
        {
            List<ViewModelError> viewmodelerrors = new List<ViewModelError>();
            bool registrationsuccess = false;

            if (ModelState.IsValid)
            {
                JXTPortal.Domain.Services.MembershipService MembershipService = new Domain.Services.MembershipService();
                JXTPortal.Domain.ViewModel.Common.JXTMembershipStatus status = MembershipService.Register(model);

                if (status == Domain.ViewModel.Common.JXTMembershipStatus.Success)
                {
                    SessionService.SetMember(MembershipService.Convert(model));
                    registrationsuccess = true;
                }
                else
                {
                    viewmodelerrors.Add(new ViewModelError() { Error = JXTPortal.Domain.ViewModel.Common.GetStatus(status) });
                }
            }
            else
            {
                IEnumerable<System.Web.Mvc.ModelError> modelerrors = ModelState.SelectMany(x => x.Value.Errors);
                foreach (var modelerror in modelerrors)
                {
                    viewmodelerrors.Add(new ViewModelError() { Error = modelerror.ErrorMessage });
                }
            }

            return Json(new { success = registrationsuccess, errors = viewmodelerrors }, JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Account/Register

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(MemberModel.RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                JXTPortal.Domain.Services.MembershipService MembershipService = new Domain.Services.MembershipService();
                JXTPortal.Domain.ViewModel.Common.JXTMembershipStatus status = MembershipService.Register(model);

                if (status == Domain.ViewModel.Common.JXTMembershipStatus.Success)
                {
                    SessionService.SetMember(MembershipService.Convert(model));
                    return RedirectToAction("RegistrationSuccess");
                }
                else
                {
                    ModelState.AddModelError("", JXTPortal.Domain.ViewModel.Common.GetStatus(status));
                }

                MembershipService = null;
            }


            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ForgetPassword(MemberModel.ForgetPasswordModel model)
        {
            if (ModelState.IsValid)
            { 
                bool success = false;

                try
                {
                    JXTPortal.Domain.Services.MembershipService MembershipService = new Domain.Services.MembershipService();
                    success = MembershipService.ForgetPassword(model);
                    
                    if (success)
                    {
                        return RedirectToAction("ForgetPasswordSuccess");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email or username does not exists.");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }  
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess
        [AllowAnonymous]
        public ActionResult ForgetPasswordSuccess()
        {
            return View();
        }

        //
        // GET: /Account/ChangePassword
        public ActionResult ChangePassword(string emailAddressOrUserName)
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword
        [HttpPost]
        public ActionResult ChangePassword(MemberModel.ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded = false;
                try
                {
                    JXTPortal.Domain.Services.MembershipService MembershipService = new Domain.Services.MembershipService();
                    if (MembershipService.VerifyPassword(model))
                    {
                        MembershipService.ChangePassword(model);
                        changePasswordSucceeded = true;
                    }
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess
        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        public ActionResult RegistrationSuccess()
        {
            return View();
        }

        private ActionResult ContextDependentView()
        {
            string actionName = ControllerContext.RouteData.GetRequiredString("action");
            if (Request.QueryString["content"] != null)
            {
                ViewBag.FormAction = "Json" + actionName;
                return PartialView();
            }
            else
            {
                ViewBag.FormAction = actionName;
                return View();
            }
        }

        private IEnumerable<string> GetErrorsFromModelState()
        {
            return ModelState.SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage));
        }

        [CustomAuthorize]
        public ActionResult Update()
        {
            return View();
        }

        #region "Saved Jobs"

        public ActionResult SavedJobs()
        {
            JobService service = new JobService();
            return View(service.SavedJobsForMember(SessionData.Member.MemberId, 0));
        }

        public ActionResult SavedJobsJsonLoad(int PageNo)
        {
            JobService service = new JobService();
            return View(service.SavedJobsForMember(SessionData.Member.MemberId, PageNo));
        }

        #endregion

        #region "Job Alert"

        [CustomAuthorize]
        public ActionResult MyAlerts()
        {
            JobService service = new JobService();
            return View(service.JobAlertForMember(SessionData.Member.MemberId));
        }

        [CustomAuthorize]
        public ActionResult JobAlert(int? ID)
        {
            JobService service = new JobService();
            SiteProfessionService _siteProfessionService = new SiteProfessionService();
            SiteLocationService _siteLocationService = new SiteLocationService();
            Domain.ViewModel.JobModel.JobAlertDetail model = new Domain.ViewModel.JobModel.JobAlertDetail();
            
            if (ID.HasValue)
            {
                 model = service.JobAlert(ID.Value);

                 if (model.ProfessionId == null) model.ProfessionId = 0;
                 if (model.SearchRoleIds == null) model.SearchRoleIds = string.Empty;
                 if (model.LocationId == null) model.LocationId = 0;
                 if (model.AreaIds == null) model.AreaIds = string.Empty;
                 if (model.SearchKeywords == null) model.SearchKeywords = string.Empty;
            }
            
            model.Professions = new Dictionary<string, string>();

            foreach (var profession in _siteProfessionService.GetBySiteIDWithActiveJobs(SessionData.Site.SiteId))
            {
                model.Professions.Add(profession.ProfessionId.ToString(), profession.SiteProfessionName);
            }

            foreach (var location in _siteLocationService.GetBySiteId(SessionData.Site.SiteId))
            {
                model.Locations.Add(location.LocationId.ToString(), location.SiteLocationName);
            }

            
            return View(model);
        }

        [CustomAuthorize]
        [HttpPost]
        public ActionResult JobAlertSave(JobModel.JobAlertDetail jobalert)
        {
            JobService service = new JobService();
            service.JobAlertSave(jobalert);
            return MyAlerts();
        }
        
        #endregion

        #region "Documents"

        /// <summary>
        /// Documents page
        /// </summary>
        /// <returns></returns>
        public ActionResult Documents()
        {
            MembershipService membershipService = new MembershipService();
            return View(membershipService.MemberFiles(SessionData.Member.MemberId));
        }

        /// <summary>
        /// this is used to download file
        /// </summary>
        /// <param name="MemberFileID"></param>
        /// <returns></returns>
        public ActionResult Download(int MemberFileID)
        {
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
                memberFileFolder = ConfigurationManager.AppSettings["AWSS3MemberRootFolder"] + ConfigurationManager.AppSettings["AWSS3MemberFilesFolder"];
                memberFileFolderFormat = "{0}/{1}";
            }

            MemberFilesService memberFileService = new MemberFilesService();
            Entities.MemberFiles memberFile = memberFileService.GetByMemberFileId(MemberFileID);

            //make sure this File is belong to that member
            if (SessionData.Member.MemberId == memberFile.MemberId)
            {
                string errormessage = string.Empty;
                byte[] memberfilecontent = null;

                if (!string.IsNullOrWhiteSpace(memberFile.MemberFileUrl))
                {              
                    Stream ms = null;
                    ms = FileManagerService.DownloadFile(bucketName, string.Format(memberFileFolderFormat, memberFileFolder, memberFile.MemberId), memberFile.MemberFileUrl, out errormessage);

                    ms.Position = 0;

                    memberfilecontent = ((MemoryStream)ms).ToArray();
                }
                else
                {
                    memberfilecontent = memberFile.MemberFileContent;
                }

                return File(memberFile.MemberFileContent, "application/octet-stream", memberFile.MemberFileName);
            }

            return View();
        }

        #endregion

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
