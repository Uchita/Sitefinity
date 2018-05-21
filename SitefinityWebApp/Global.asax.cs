using Autofac;
using JXTNext.Sitefinity.Connector;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search;
using JXTNext.Sitefinity.Connector.Options;
using JXTNext.Sitefinity.Connector.Options.Models.Job;
using SitefinityWebApp.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Bootstrapper.Bootstrapped += Bootstrapper_Bootstrapped;
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
        }

    }
}