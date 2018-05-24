using System;
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
using ServiceStack.Text;
using Newtonsoft.Json;
using Telerik.Sitefinity.Mvc.ActionFilters;

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

            if(filterModel != null)
            {
                ISearchJobsResponse response = GetJobSearchResultsResponse(filterModel);
                dynamicJobResultsList = response as dynamic;
            }

           return View("Simple", dynamicJobResultsList);
        }


        [HttpPost]
        public JsonResult GetSearchResults(string jobRequest, int PageNumber)
        {
            JsonResult response = new JsonResult();
            Test_SearchJobsRequest request = JsonConvert.DeserializeObject<Test_SearchJobsRequest>(jobRequest);
            if (request != null)
            {
                if (PageNumber <= 0)
                    PageNumber = 1;

                // Page index is starting at zero
                // So subtracting one from it
                request.Page = PageNumber - 1;
            }

            Test_SearchJobsResponse jobResponse = (Test_SearchJobsResponse)_testBLConnector.SearchJobs(request);

            if (jobResponse != null)
                response.Data = JsonConvert.SerializeObject(jobResponse.SearchResults);

            return response;
        }

        [HttpPost]
        [StandaloneResponseFilter]
        public PartialViewResult GetFilterSearchResultsPartial(JobSearchResultsFilterModel filterModel)
        {
            dynamic dynamicJobResultsList = null;

            if (filterModel != null)
            {
                ISearchJobsResponse response = GetJobSearchResultsResponse(filterModel);
                dynamicJobResultsList = response as dynamic;
            }

           return PartialView("_JobSearchResults", dynamicJobResultsList);
        }

        private ISearchJobsResponse GetJobSearchResultsResponse(JobSearchResultsFilterModel filterModel)
        {
            ISearchJobsResponse response = null;

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
                                if(!filterId.IsNullOrEmpty())
                                    filters.Add(new FiltersSearchElement { ID = filterId });
                            }

                            if (filters.Count > 0)
                            {
                                if (!item.rootId.IsNullOrEmpty())
                                    filtersSearch.Add(new FiltersSearchRoot { RootID = item.rootId, Filters = filters });
                            }
                        }
                    }
                }

                if (this.PageSize == null || this.PageSize <= 0)
                    this.PageSize = PageSizeDefaultValue;

                if (filterModel.Page <= 0)
                    filterModel.Page = 1;

                //Execute - Try perform search
                ISearchJobsRequest request = new Test_SearchJobsRequest { Page = filterModel.Page - 1, PageSize = (int)this.PageSize, Keywords = filterModel.Keywords, FiltersSearch = filtersSearch };
                response = _testBLConnector.SearchJobs(request);
                Test_SearchJobsResponse jobResultsList = response as Test_SearchJobsResponse;

                ViewBag.Request = JsonConvert.SerializeObject(request);
                ViewBag.FilterModel = JsonConvert.SerializeObject(filterModel);
                ViewBag.PageSize = (int)this.PageSize;
                ViewBag.SortOrder = this.Sorting;
                ViewBag.JobDetailsPageUrl = filterModel.JobDetailsPageUrl;
                ViewBag.CssClass = this.CssClass;
                if (jobResultsList != null)
                    ViewBag.TotalCount = jobResultsList.Total;
            }

            return response;
        }

        public int? PageSize { get; set; }
        public string Sorting { get; set; }
        public string CssClass { get; set; }
        internal const string WidgetIconCssClass = "sfMvcIcn";
        private const int PageSizeDefaultValue = 5;
    }
}