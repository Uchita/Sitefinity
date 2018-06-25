using JXTNext.Sitefinity.Common.Models;
using JXTNext.Sitefinity.Connector;
using JXTNext.Sitefinity.Widgets.Authentication;
using JXTNext.Sitefinity.Widgets.Job;
using Ninject;
using SitefinityWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Frontend;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers;

namespace SitefinityWebApp.App_Start
{
    public class NinjectControllerFactory : FrontendControllerFactory
    {
        private IKernel ninjectKernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectControllerFactory"/> class.
        /// </summary>
        public NinjectControllerFactory()
        {
            this.ninjectKernel = new StandardKernel(
                new InterfaceMappings()
                , new ConnectorModule()
                , new Widgets_AuthenticationModule()
                , new Widgets_JobModule()
                );

            BindInjectionModels();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return null;
            }

            var resolvedController = this.ninjectKernel.Get(controllerType);
            IController controller = resolvedController as IController;

            return controller;
        }

        private void BindInjectionModels()
        {
            ninjectKernel.Bind<IRequestSession>().To<SFRequestSession>();
        }

    }
}