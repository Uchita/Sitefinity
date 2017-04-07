using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using JXTPortal.Mobile.Website.ViewEngine;
using Autofac;
using Autofac.Integration.Web;
using JXTPortal.Website.App_Codes;
using JXTPortal.Custom;

namespace JXTPortal.Mobile.Website
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        // Provider that holds the application container.
        static IContainerProvider _containerProvider;

        // Instance property that will be used by Autofac HttpModules
        // to resolve and inject dependencies.
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Job",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Job", action = "Index", id = UrlParameter.Optional }
                );

            routes.MapHttpRoute(
                "Page", // Route name
                "{id}", // URL with parameters
                new { controller = "Page", action = "Index", id = UrlParameter.Optional } // Parameter defaults
                );
        }

        protected void Application_Start()
        {
            _containerProvider = new ContainerProvider(IoCHelper.CreateContainer());

            SessionService.InnerService = ContainerProvider.ApplicationContainer.Resolve<ISessionService>();

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            BundleTable.Bundles.RegisterTemplateBundles();

            /*Register Whitelabel View Engine logic*/
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new WhitelabelViewEngine());

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            SessionService.SessionMobileSetup();
        }
    }
}