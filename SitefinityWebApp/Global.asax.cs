﻿using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Widgets.Authentication.Mvc.StringResources;
using JXTNext.Sitefinity.Widgets.Job.Mvc.StringResources;
using JXTNext.Sitefinity.Widgets.JobAlert.Mvc.StringResources;
using JXTNext.Sitefinity.Widgets.Social.Mvc.StringResources;
using JXTNext.Sitefinity.Widgets.User.Mvc.Models;
using SitefinityWebApp.App_Start;
using SitefinityWebApp.Mvc.Attributes;
using System;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration.Web.UI.Basic;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Frontend;
using Telerik.Sitefinity.Frontend.Identity.Mvc.Models.Registration;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Services;
using JXTNext.Sitefinity.Common.Models.CustomSiteSettings;
using JXTNext.Sitefinity.Widgets.Content.Mvc.StringResources;

namespace SitefinityWebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ViewEngines.Engines.Add(new SFViewEngine());

            Bootstrapper.Bootstrapped += Bootstrapper_Bootstrapped;
            Bootstrapper.Initialized += new EventHandler<ExecutedEventArgs>(Bootstrapper_Initialized);
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

            if (e.CommandName == "Bootstrapped")
            {
                GlobalFilters.Filters.Add(new SocialShareAttribute());
                SystemManager.RegisterBasicSettings<GenericBasicSettingsView<CustomSiteSettings, CustomSiteSettingsContract>>("CustomSiteSettingsConfig", "Custom Site Settings", "", true);
            }

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


            FrontendModule.Current.DependencyResolver.Rebind<IRegistrationModel>().To<JXTNext_MemberRegistrationModel>();
        }

    }
}