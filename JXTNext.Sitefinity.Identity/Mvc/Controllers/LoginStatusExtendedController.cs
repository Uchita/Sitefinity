using JXTNext.Sitefinity.Widgets.Authentication.Mvc.Models.LoginStatusExtended;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.Owin.Security;
using System.Web.Mvc;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Security.Claims;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Security.Configuration;
using SecConfig = Telerik.Sitefinity.Security.Configuration;
using Telerik.Sitefinity.Security;
using System.Web;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;

namespace JXTNext.Sitefinity.Widgets.Authentication.Mvc.Controllers
{
    [EnhanceViewEngines]
    [ControllerToolboxItem(Name = "LoginStatusExtended_MVC", Title = "Login Status", SectionName = "JXTNext.Authentication", CssClass = LoginStatusExtendedController.WidgetIconCssClass)]
    public class LoginStatusExtendedController : Controller
    {
        #region Properties

        /// <summary>
        /// Gets the Login Status widget model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public virtual ILoginStatusExtendedModel Model
        {
            get
            {
                if (this.model == null)
                    this.model = this.InitializeModel();

                return this.model;
            }
        }

        /// <summary>
        /// Gets or sets the name of the template that widget will be displayed.
        /// </summary>
        /// <value></value>
        public string TemplateName
        {
            get
            {
                return this.templateName;
            }

            set
            {
                this.templateName = value;
            }
        }

        /// <summary>
        /// Gets the is design mode.
        /// </summary>
        /// <value>The is design mode.</value>
        protected virtual bool IsDesignMode
        {
            get
            {
                return SystemManager.IsDesignMode;
            }
        }

        #endregion

        /// <summary>
        /// Renders appropriate list view depending on the <see cref="TemplateName" />
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult" />.
        /// </returns>
        [RelativeRoute("")]
        public ActionResult Index(bool stsLogin = false)
        {
            if (stsLogin)
            {
                var authProp = new AuthenticationProperties() { RedirectUri = this.GetCurrentPageUrl() };
                SystemManager.CurrentHttpContext.Request.GetOwinContext().Authentication.Challenge(authProp);
                return new EmptyResult();
            }

            var fullTemplateName = this.templateNamePrefix + this.TemplateName;
            var viewModel = this.Model.GetViewModel();

            this.ViewBag.IsDesignMode = SystemManager.IsDesignMode;

            return this.View(fullTemplateName, viewModel);
        }

        /// <summary>
        /// Sign out the user and redirect it to the login page.
        /// </summary>
        /// <returns>
        /// /// The <see cref="ActionResult" />.
        /// </returns>
        [RelativeRoute("SignOut")]
        public ActionResult SignOut()
        {
            var logoutUrl = this.Model.GetLogoutPageUrl() ?? this.GetCurrentPageUrl();

            if (Config.Get<SecurityConfig>().AuthenticationMode == SecConfig.AuthenticationMode.Claims)
            {
                var owinContext = SystemManager.CurrentHttpContext.Request.GetOwinContext();
                var authenticationTypes = ClaimsManager.CurrentAuthenticationModule.GetSignOutAuthenticationTypes().ToArray();

                owinContext.Authentication.SignOut(new AuthenticationProperties
                {
                    RedirectUri = logoutUrl
                }, authenticationTypes);
            }
            else
            {
                SecurityManager.Logout();
                SecurityManager.DeleteAuthCookies();
            }

            return this.Redirect(logoutUrl);
        }

        /// <summary>
        /// Returns JSON with the status of the user and his email, first and last names
        /// </summary>
        [Route("rest-api/login-status-extended")]
        public JsonResult Status()
        {
            var response = this.Model.GetStatusViewModel();

            return this.Json(response, JsonRequestBehavior.AllowGet);
        }

        /// <inheritDocs/>
        protected override void HandleUnknownAction(string actionName)
        {
            this.Index().ExecuteResult(this.ControllerContext);
        }

        #region Private methods

        /// <summary>
        /// Initializes the model.
        /// </summary>
        /// <returns>
        /// The <see cref="ILoginStatusModel"/>.
        /// </returns>
        private ILoginStatusExtendedModel InitializeModel()
        {
            var parameters = new Dictionary<string, object>()
            {
                { "currentPageUrl", this.GetCurrentPageUrl() }
            };

            return ControllerModelFactory.GetModel<ILoginStatusExtendedModel>(this.GetType(), parameters);
        }

        #endregion

        #region Private fields and constants

        internal const string WidgetIconCssClass = "sfMvcIcn";

        private string templateName = "LoginButton";
        private ILoginStatusExtendedModel model;
        private string templateNamePrefix = "LoginStatusExtended.";

        #endregion
    }
}
