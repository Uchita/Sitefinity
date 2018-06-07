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
using JXTNext.Sitefinity.Mvc.Helpers;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "JobSearchResults_MVC", Title = "Job Search Results", SectionName = "Search", CssClass = JobSearchResultsController.WidgetIconCssClass)]
    public class JobSearchResultsController : Controller
    {
        IBusinessLogicsConnector _testBLConnector;
        IOptionsConnector _testOConnector;
        IGetJobFiltersResponse _filtersResponse;
        JobFilterRoot _jobTypes;

        /// <summary>
        /// Gets or sets the name of the template that widget will be displayed.
        /// </summary>
        /// <value></value>
        public string TemplateName
        {
            get
            {
                return this.templateName;
            }

            set
            {
                this.templateName = value;
            }
        }

        public JobSearchResultsController(IEnumerable<IBusinessLogicsConnector> _bConnectors, IEnumerable<IOptionsConnector> _oConnectors)
        {
            _testBLConnector = _bConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.Test).FirstOrDefault();
            _testOConnector = _oConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.Test).FirstOrDefault();

            //Execute - Get available filter options from the server
            _filtersResponse = _testOConnector.JobFilters<Test_GetJobFiltersRequest, Test_GetJobFiltersResponse>(new Test_GetJobFiltersRequest());
            _jobTypes = _filtersResponse.Filters.Data.Where(item => item.Name == "Job Types").FirstOrDefault();
            if (_jobTypes != null)
                this.SerializedTotalJobTypes = JsonConvert.SerializeObject(_jobTypes.Filters);
        }

        // GET: JobSearchResults
        public ActionResult Index(JobSearchResultsFilterModel filterModel)
        {
            _filtersResponse = _testOConnector.JobFilters<Test_GetJobFiltersRequest, Test_GetJobFiltersResponse>(new Test_GetJobFiltersRequest());
            _jobTypes = _filtersResponse.Filters.Data.Where(item => item.Name == "Job Types").FirstOrDefault();
            if (_jobTypes != null)
                this.SerializedTotalJobTypes = JsonConvert.SerializeObject(_jobTypes.Filters);

            dynamic dynamicJobResultsList = null;

            if(filterModel != null)
            {
                ISearchJobsResponse response = GetJobSearchResultsResponse(filterModel);
                dynamicJobResultsList = response as dynamic;
            }

           return View(this.TemplateName, dynamicJobResultsList);
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
                        if (item != null)
                        {
                            if (item.values != null && item.values.Count() > 0)
                            {
                                var filters = new List<FiltersSearchElement>();
                                foreach (var filterId in item.values)
                                {
                                    if (!filterId.IsNullOrEmpty())
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
                }

                if (!this.SerializedJobTypes.IsNullOrEmpty())
                {
                    var jobTypes = JsonConvert.DeserializeObject<List<JobTypesDesignerViewModel>>(this.SerializedJobTypes);
                    if (jobTypes != null && jobTypes.Count > 0)
                    {
                        var selectedJobTypes = jobTypes.Where(item => item.Selected == true).ToList();
                        if (selectedJobTypes != null && selectedJobTypes.Count > 0)
                        {
                            if (filtersSearch == null)
                                filtersSearch = new List<FiltersSearchRoot>();

                            var filters = new List<FiltersSearchElement>();
                            foreach (var jobType in selectedJobTypes)
                            {
                                if (!jobType.ID.IsNullOrEmpty())
                                    filters.Add(new FiltersSearchElement { ID = jobType.ID });
                            }
                            if (filters.Count > 0)
                            {
                                if (!_jobTypes.ID.IsNullOrEmpty())
                                    filtersSearch.Add(new FiltersSearchRoot { RootID = _jobTypes.ID, Filters = filters });
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
                ViewBag.CssClass = this.CssClass;
                if (jobResultsList != null)
                    ViewBag.TotalCount = jobResultsList.Total;

                ViewBag.JobResultsPageUrl = SitefinityHelper.GetPageUrl(this.ResultsPageId);
                ViewBag.JobDetailsPageUrl = SitefinityHelper.GetPageUrl(this.DetailsPageId);
            }

            return response;
        }

        public int? PageSize { get; set; }
        public string DetailsPageId { get; set; }
        public string ResultsPageId { get; set; }
        public string Sorting { get; set; }
        public bool IsAllJobs { get; set; }
        public string CssClass { get; set; }
        public string SerializedJobTypes { get; set; }
        public string SerializedTotalJobTypes { get; set; }
        internal const string WidgetIconCssClass = "sfMvcIcn";
        private const int PageSizeDefaultValue = 5;
        private string templateName = "JobsAll";
    }
}