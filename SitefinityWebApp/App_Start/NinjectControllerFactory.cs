using JXTNext.Sitefinity.Common.Models;
using JXTNext.Sitefinity.Connector;
using JXTNext.Sitefinity.Services.Services;
using JXTNext.Sitefinity.Widgets.Authentication;
using JXTNext.Sitefinity.Widgets.Job;
using JXTNext.Sitefinity.Widgets.Social;
using JXTNext.Sitefinity.Widgets.User;
using Ninject;
using SitefinityWebApp.Models;
using System;
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
                , new Widgets_UserModule()
                , new SocialModule()
                , new ServiceInterfacesModule()
                , new Widgets_JobModule()
                , new JXTNext.Sitefinity.Modules.Setup.Bindings()
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