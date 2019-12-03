using JustEat.StatsD;
using JXTNext.Sitefinity.Common.Attributes;
using JXTNext.Sitefinity.Services.Services;
using JXTNext.Sitefinity.Widgets.Authentication.Mvc.StringResources;
using JXTNext.Sitefinity.Widgets.Content.Mvc.StringResources;
using JXTNext.Sitefinity.Widgets.Identity.Mvc.Models.LoginForm;
using JXTNext.Sitefinity.Widgets.Identity.Mvc.Models.RegistrationExtended;
using JXTNext.Sitefinity.Widgets.Job.Mvc.StringResources;
using JXTNext.Sitefinity.Widgets.JobAlert.Mvc.StringResources;
using JXTNext.Sitefinity.Widgets.Social.Mvc.StringResources;
using JXTNext.Sitefinity.Widgets.User.Mvc.Models;
using JXTNext.Sitefinity.Widgets.User.Mvc.StringResources;
using JXTNext.Telemetry;
using Ninject;
using SitefinityWebApp.App_Start;
using SitefinityWebApp.code;
using SitefinityWebApp.Mvc.Models.CustomDynamicContent;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Frontend;
using Telerik.Sitefinity.Frontend.DynamicContent.Mvc.Models;
using Telerik.Sitefinity.Frontend.Identity.Mvc.Models.LoginForm;
using Telerik.Sitefinity.Frontend.Identity.Mvc.Models.Registration;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Security.Events;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.SitemapGenerator.Abstractions.Events;
using Telerik.Sitefinity.Web.Events;

namespace SitefinityWebApp
{
    public class Global : System.Web.HttpApplication
    {
        private JXTNext_ProfileEventHandler _profileEventHandler;
        private JXTNextSiteMapService _siteMapService;

        protected void Application_Start(object sender, EventArgs e)
        {
            //Disable view engine because we are not using Common for Resource packages
            ViewEngines.Engines.Add(new SFViewEngine());
            Bootstrapper.Bootstrapped += Bootstrapper_Bootstrapped;
            Bootstrapper.Initialized += new EventHandler<ExecutedEventArgs>(Bootstrapper_Initialized);

            ////Profile created event             
            _profileEventHandler = new JXTNext_ProfileEventHandler();
            _siteMapService = new JXTNextSiteMapService();
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
                //GlobalFilters.Filters.Add(new SocialShareAttribute()); Remove because social share is no longer supported.
                FrontendModule.Current.DependencyResolver.Rebind<IDynamicContentModel>().To<CustomDynamicContentModel>();
                EventHub.Subscribe<IUnauthorizedPageAccessEvent>(new Telerik.Sitefinity.Services.Events.SitefinityEventHandler<IUnauthorizedPageAccessEvent>(OnUnauthorizedAccess));
                EventHub.Subscribe<ISitemapGeneratorBeforeWriting>(new Telerik.Sitefinity.Services.Events.SitefinityEventHandler<ISitemapGeneratorBeforeWriting>(SeoSiteMapAppender));
            }
        }

        /// <summary>
        /// Before page render if backend add css to change logos to JXT logos. If not backend 
        /// </summary>
        /// <param name="evt"></param>
        private void OnPagePreRenderCompleteEventHandler(IPagePreRenderCompleteEvent evt)
        {
            if (evt.PageSiteNode.IsBackend)
            {
                var page = evt.Page;
                var adminStyles = new HtmlLink();

                adminStyles.Attributes.Add("rel", "stylesheet");
                adminStyles.Attributes.Add("type", "text/css");
                adminStyles.Href = page.ResolveUrl("~/content/app/admin.css");

                page.Header.Controls.Add(adminStyles);
            }
        }

        void OnUnauthorizedAccess(IUnauthorizedPageAccessEvent unauthorizedEvent)
        {
            var url = unauthorizedEvent.Page.Url.TrimStart('~');
            //for this specific page redirect to CustomerLoginPage
            //if (unauthorizedEvent.Page.Title.Contains("user-dashboard"))
            unauthorizedEvent.HttpContext.Response.Redirect("~/sign-in");
            //for all other pages redirect to the Sitefinity login page
            //if you do not use the else clause you will be redirected to the Sitefinity login page in all other cases different that the above one
            //else
            //    unauthorizedEvent.HttpContext.Response.Redirect("~/sitefinity");
        }


        protected void Application_End(object sender, EventArgs e)
        {
            EventHub.Unsubscribe<ProfileCreated>(_profileEventHandler.ProfileCreated);
            EventHub.Unsubscribe<ISitemapGeneratorBeforeWriting>(_siteMapService.SEOAppendSiteMap);
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
            FrontendModule.Current.DependencyResolver.Rebind<ILoginFormModel>().To<CustomLoginFormModel>();
            FrontendModule.Current.DependencyResolver.Rebind<IRegistrationModel>().To<CustomRegistrationModel>();
            FeatherActionInvokerCustom.Register();
            HandleHttpStatusCodeAttribute.Register();
            RegisterStatsD(FrontendModule.Current.DependencyResolver);
            EventHub.Subscribe<IPagePreRenderCompleteEvent>(this.OnPagePreRenderCompleteEventHandler);
        }

        private void ApplicationStartHandler(object sender, EventArgs e)
        {
            EventHub.Subscribe<ProfileCreated>(evt => _profileEventHandler.ProfileCreated(evt));
        }

        private void SeoSiteMapAppender(ISitemapGeneratorBeforeWriting evt)
        {
            _siteMapService.SEOAppendSiteMap(evt);
        }
        
        private void RegisterStatsD(IKernel kernel)
        {
            var statsDConfiguration = StatsDConfigurator.Configure();
            kernel.Bind<StatsDConfiguration>().ToConstant(statsDConfiguration);
            kernel.Bind<IStatsDPublisher>().To<StatsDPublisher>().InSingletonScope();
        }
    }

}