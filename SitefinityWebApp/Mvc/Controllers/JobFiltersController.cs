﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using SitefinityWebApp.Mvc.Models;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.Options;
using System.Dynamic;
using JXTNext.Sitefinity.Connector.Options.Models.Job;
using Newtonsoft.Json;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "JobFilters_MVC", Title = "Job Filters", SectionName = "Search", CssClass = JobFiltersController.WidgetIconCssClass)]
    public class JobFiltersController : Controller
    {
        IBusinessLogicsConnector _testBLConnector;
        IOptionsConnector _testOConnector;

        public JobFiltersController(IEnumerable<IBusinessLogicsConnector> _bConnectors, IEnumerable<IOptionsConnector> _oConnectors)
        {
            _testBLConnector = _bConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.Test).FirstOrDefault();
            _testOConnector = _oConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.Test).FirstOrDefault();
        }

        // GET: JobFilters
        public ActionResult Index(JobSearchResultsFilterModel filterModel)
        {
            dynamic dynamicFilterResponse = null;
            IGetJobFiltersResponse filtersResponse = _testOConnector.JobFilters<Test_GetJobFiltersRequest, Test_GetJobFiltersResponse>(new Test_GetJobFiltersRequest());
            if (filtersResponse != null && filtersResponse.Filters != null
                && filtersResponse.Filters.Data != null)
                dynamicFilterResponse = filtersResponse.Filters.Data as dynamic;

            ViewBag.FilterModel = JsonConvert.SerializeObject(filterModel);
            return View("Simple", dynamicFilterResponse);
        }

        internal const string WidgetIconCssClass = "sfMvcIcn";
    }
}