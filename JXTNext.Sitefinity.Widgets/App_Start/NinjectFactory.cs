using JXTNext.Sitefinity.Connector;
using Ninject;
using System;
using System.Web.Mvc;
using Telerik.Sitefinity.Frontend;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers;

namespace SitefinityWebApp.App_Start
{
    public class NinjectFactory : FrontendControllerFactory
    {
        private IKernel ninjectKernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectFactory"/> class.
        /// </summary>
        public NinjectFactory()
        {
            this.ninjectKernel = new StandardKernel(
                new InterfaceMappings()
                , new ConnectorModule()
                );

        }
    }
}