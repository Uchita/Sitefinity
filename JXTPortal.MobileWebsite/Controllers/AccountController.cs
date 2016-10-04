using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using JXTPortal.Domain.ViewModel;
using JXTPortal.Entities;
using JXTPortal.MobileWebsite.Custom.Attributes;

namespace JXTPortal.MobileWebsite.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {

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
        public ActionResult JsonRegister(string username, string password, string confirmpassword, string email, string confirmemail)
        {
            MemberModel.RegistrationModel model = new MemberModel.RegistrationModel() { UserName = username, Password = password, ConfirmPassword = confirmpassword, Email = email, ConfirmEmail = confirmemail };
            string error = string.Empty;

            if (ModelState.IsValid)
            {
                JXTPortal.Domain.Services.MembershipService MembershipService = new Domain.Services.MembershipService();
                JXTPortal.Domain.ViewModel.Common.JXTMembershipStatus status = MembershipService.Register(model);
                
                if (status == Domain.ViewModel.Common.JXTMembershipStatus.Success)
                {
                    SessionService.SetMember(MembershipService.Convert(model));
                    return Json(new { success = true, errors = "" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    error = JXTPortal.Domain.ViewModel.Common.GetStatus(status);
                    ModelState.AddModelError("", JXTPortal.Domain.ViewModel.Common.GetStatus(status));
                }
            }

            // If we got this far, something failed
            return Json(new { success = false, errors = error }, JsonRequestBehavior.AllowGet);
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

        //
        // GET: /Account/ChangePassword
        public ActionResult ChangePassword()
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
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, userIsOnline: true);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
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
