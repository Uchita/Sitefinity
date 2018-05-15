﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Web;
using SitefinityWebApp.Mvc.Models;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.Options;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search;
using JXTNext.Sitefinity.Connector.Options.Models.Job;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "JobSearchResults_MVC", Title = "Job Search Results", SectionName = "Search", CssClass = JobSearchResultsController.WidgetIconCssClass)]
    public class JobSearchResultsController : Controller
    {
        IBusinessLogicsConnector _testBLConnector;
        IOptionsConnector _testOConnector;

        public JobSearchResultsController(IEnumerable<IBusinessLogicsConnector> _bConnectors, IEnumerable<IOptionsConnector> _oConnectors)
        {
            _testBLConnector = _bConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.Test).FirstOrDefault();
            _testOConnector = _oConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.Test).FirstOrDefault();
        }

        // GET: JobSearchResults
        public ActionResult Index(JobSearchResultsFilterModel filterModel)
        {
            dynamic dynamicJobResultsList = null;
            if (filterModel != null)
            {
                List<FiltersSearchRoot> filtersSearch = null;
                // Loop through all the filters and form a filters search request
                if (filterModel.Filters != null && filterModel.Filters.Count > 0)
                {
                    filtersSearch = new List<FiltersSearchRoot>();
                    foreach (var item in filterModel.Filters)
                    {
                        if (item.values != null && item.values.Count() > 0)
                        {
                            var filters = new List<FiltersSearchElement>();
                            foreach (var filterId in item.values)
                            {
                                filters.Add(new FiltersSearchElement { ID = filterId });
                            }

                            if (filters.Count > 0)
                                filtersSearch.Add(new FiltersSearchRoot { RootID = item.rootId, Filters = filters });
                        }
                    }
                }

                //Execute - Try perform search
                ISearchJobsRequest request = new Test_SearchJobsRequest { Page = 0, PageSize = 20, Keywords = filterModel.Keywords, FiltersSearch = filtersSearch };
                ISearchJobsResponse response = _testBLConnector.SearchJobs(request);
                dynamicJobResultsList = response as dynamic;

                ViewData["JobDetailsPageUrl"] = filterModel.JobDetailsPageUrl;
            }

            return View("Simple", dynamicJobResultsList);
        }

        internal const string WidgetIconCssClass = "sfMvcIcn";
    }
}