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
using System.Web.Mvc;
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




            //IEnumerable<IBusinessLogicsConnector> _businessLogicsConnectors;
            //IEnumerable<IOptionsConnector> _optionsConnectors;

            //Get the current lifetime scope from Autofac container
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    _businessLogicsConnectors = scope.Resolve<IEnumerable<IBusinessLogicsConnector>>();
            //    _optionsConnectors = scope.Resolve<IEnumerable<IOptionsConnector>>();
            //}

            ////Find the connectors we wawnt
            //IBusinessLogicsConnector testBusinessLogicConnector = _businessLogicsConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.Test).FirstOrDefault();
            //IOptionsConnector testConnector = _optionsConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.Test).FirstOrDefault();

            ////Execute - Get available filter options from the server
            //IGetJobFiltersResponse filtersResponse = testConnector.JobFilters<Test_GetJobFiltersRequest, Test_GetJobFiltersResponse>(new Test_GetJobFiltersRequest());

            ////Execute - Try perform a dummy search
            //ISearchJobsRequest request = new Test_SearchJobsRequest { Page = 0, PageSize = 2, FiltersSearch = new List<FiltersSearchRoot> { new FiltersSearchRoot { RootID = "AE-1234", Filters = new List<FiltersSearchElement> { new FiltersSearchElement { ID = "DD-3123" } } } } };
            //ISearchJobsResponse response = testBusinessLogicConnector.SearchJobs(request);

        }

    }
}