using JXTNext.Sitefinity.Common.Models.CustomSiteSettings;
using JXTNext.Sitefinity.Widgets.Authentication.Mvc.StringResources;
using JXTNext.Sitefinity.Widgets.Job.Mvc.StringResources;
using JXTNext.Sitefinity.Widgets.JobAlert.Mvc.StringResources;
using JXTNext.Sitefinity.Widgets.Social.Mvc.StringResources;
using JXTNext.Sitefinity.Widgets.User.Mvc.Models;
using SitefinityWebApp.App_Start;
using SitefinityWebApp.Mvc.Attributes;
using SitefinityWebApp.Mvc.Models.CustomDynamicContent;
using System;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration.Web.UI.Basic;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Frontend;
using Telerik.Sitefinity.Frontend.DynamicContent.Mvc.Models;
using Telerik.Sitefinity.Frontend.Identity.Mvc.Models.Registration;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Services;
using JXTNext.Sitefinity.Widgets.Content.Mvc.StringResources;
using Telerik.Sitefinity.Security.Events;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using Ninject;
using JXTNext.Sitefinity.Widgets.User.Mvc.StringResources;
using Telerik.Sitefinity.Configuration;
using JXTNext.Sitefinity.Widgets.Social.Mvc.Configuration;
using JXTNext.Sitefinity.Common.Models.Robots;
using Telerik.Sitefinity.Web.Events;
using SitefinityWebApp.code;

namespace SitefinityWebApp
{
    public class Global : System.Web.HttpApplication
    {
        private JXTNext_ProfileEventHandler _profileEventHandler;

        protected void Application_Start(object sender, EventArgs e)
        {
            ViewEngines.Engines.Add(new SFViewEngine());
            Bootstrapper.Bootstrapped += Bootstrapper_Bootstrapped;
            Bootstrapper.Initialized += new EventHandler<ExecutedEventArgs>(Bootstrapper_Initialized);

            //Profile created event             
            _profileEventHandler = new JXTNext_ProfileEventHandler();
            SystemManager.ApplicationStart += new EventHandler<EventArgs>(ApplicationStartHandler);
        }

        void Bootstrapper_Initialized(object sender, ExecutedEventArgs e)
        {
            // Register any Resource classes
            Res.RegisterResource<SocialLinkResources>();
            Res.RegisterResource<JobSearchResources>();
            Res.RegisterResource<JobSearchResultsResources>();
            Res.RegisterResource<JobAlertResources>();
            Res.RegisterResource<JobDetailsResources>();
            Res.RegisterResource<LoginStatusExtendedResources>();
            Res.RegisterResource<UsersListExtendedResources>();
            Res.RegisterResource<MapsResources>();
            Res.RegisterResource<JobApplicationResources>();
            Res.RegisterResource<MemberSavedJobsResources>();
            Res.RegisterResource<MemberAppliedJobsResources>();
            Res.RegisterResource<ConsultantResources>();
            Res.RegisterResource<SocialHandlerResources>();
            Res.RegisterResource<JXTNextResumeResources>();

            if (e.CommandName == "Bootstrapped")
            {
                GlobalFilters.Filters.Add(new SocialShareAttribute());
                SystemManager.RegisterBasicSettings<GenericBasicSettingsView<CustomSiteSettings, CustomSiteSettingsContract>>("CustomSiteSettingsConfig", "Custom Site Settings", "", true);
                SystemManager.RegisterBasicSettings<GenericBasicSettingsView<RobotSettings, RobotSettingsContract>>("RobotSettingsConfig", "Robot Settings", "", true);
                FrontendModule.Current.DependencyResolver.Rebind<IDynamicContentModel>().To<CustomDynamicContentModel>();
                Config.RegisterSection<InstagramConfig>();
                EventHub.Subscribe<IUnauthorizedPageAccessEvent>(new Telerik.Sitefinity.Services.Events.SitefinityEventHandler<IUnauthorizedPageAccessEvent>(OnUnauthorizedAccess));
            }
        }

        void OnUnauthorizedAccess(IUnauthorizedPageAccessEvent unauthorizedEvent)
        {
            var url = unauthorizedEvent.Page.Url.TrimStart('~');
            //for this specific page redirect to CustomerLoginPage
            if (unauthorizedEvent.Page.Title.Contains("user-dashboard"))
                unauthorizedEvent.HttpContext.Response.Redirect("~/sign-in");
            //for all other pages redirect to the Sitefinity login page
            //if you do not use the else clause you will be redirected to the Sitefinity login page in all other cases different that the above one
            else
                unauthorizedEvent.HttpContext.Response.Redirect("~/sitefinity");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            EventHub.Unsubscribe<ProfileCreated>(_profileEventHandler.ProfileCreated);
        }

        void Bootstrapper_Bootstrapped(object sender, EventArgs e)
        {
            ObjectFactory.Container.RegisterType<ISitefinityControllerFactory, NinjectControllerFactory>(new ContainerControlledLifetimeManager());
            var factory = ObjectFactory.Resolve<ISitefinityControllerFactory>();
            ControllerBuilder.Current.SetControllerFactory(factory);
            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                "jxt",
                "jxt/{controller}/{id}",
                new { id = RouteParameter.Optional });
            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                "Instagram",
                "Instagram/{controller}/{id}",
                new { id = RouteParameter.Optional });
            //FrontendModule.Current.DependencyResolver.Rebind<IRegistrationModel>().To<JXTNext_MemberRegistrationModel>();
            FeatherActionInvokerCustom.Register();
        }

        private void ApplicationStartHandler(object sender, EventArgs e)
        {
            EventHub.Subscribe<ProfileCreated>(evt => _profileEventHandler.ProfileCreated(evt));
        }


    }

}