using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search;
using JXTNext.Sitefinity.Connector.Options;
using JXTNext.Sitefinity.Connector.Options.Models.Job;
using JXTNext.Sitefinity.Widgets.Job.Mvc.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Mvc.ActionFilters;
using System;
using JXTNext.Sitefinity.Common.Helpers;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Controllers
{
    [EnhanceViewEngines]
    [ControllerToolboxItem(Name = "JobSearchResults_MVC", Title = "Search Results", SectionName = "JXTNext.Job", CssClass = JobSearchResultsController.WidgetIconCssClass)]
    public class JobSearchResultsController : Controller
    {
        IBusinessLogicsConnector _BLConnector;
        IOptionsConnector _OptionsConnector;

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
            _BLConnector = _bConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
            _OptionsConnector = _oConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
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

           return View(this.TemplateName, dynamicJobResultsList);
        }


        [HttpPost]
        public JsonResult GetSearchResults(string jobRequest, int PageNumber)
        {
            JsonResult response = new JsonResult();
            JXTNext_SearchJobsRequest request = JsonConvert.DeserializeObject<JXTNext_SearchJobsRequest>(jobRequest);
            if (request != null)
            {
                if (PageNumber <= 0)
                    PageNumber = 1;

                // Page index is starting at zero
                // So subtracting one from it
                request.Page = PageNumber - 1;
            }

            JXTNext_SearchJobsResponse jobResponse = (JXTNext_SearchJobsResponse)_BLConnector.SearchJobs(request);

            return new JsonResult { Data = jobResponse };
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
                                    if (!String.IsNullOrEmpty(filterId))
                                        filters.Add(new FiltersSearchElement { ID = filterId });
                                }

                                if (filters.Count > 0)
                                {
                                    if (!String.IsNullOrEmpty(item.rootId))
                                        filtersSearch.Add(new FiltersSearchRoot { RootID = item.rootId, Filters = filters });
                                }
                            }
                        }
                    }
                }

                //if (!String.IsNullOrEmpty(this.SerializedJobTypes))
                //{
                //    var jobTypes = JsonConvert.DeserializeObject<List<JobTypesDesignerViewModel>>(this.SerializedJobTypes);
                //    if (jobTypes != null && jobTypes.Count > 0)
                //    {
                //        var selectedJobTypes = jobTypes.Where(item => item.Selected == true).ToList();
                //        if (selectedJobTypes != null && selectedJobTypes.Count > 0)
                //        {
                //            if (filtersSearch == null)
                //                filtersSearch = new List<FiltersSearchRoot>();

                //            var filters = new List<FiltersSearchElement>();
                //            foreach (var jobType in selectedJobTypes)
                //            {
                //                if (!String.IsNullOrEmpty(jobType.ID))
                //                    filters.Add(new FiltersSearchElement { ID = jobType.ID });
                //            }
                //            if (filters.Count > 0)
                //            {
                //                if (!String.IsNullOrEmpty(_jobTypes.ID))
                //                    filtersSearch.Add(new FiltersSearchRoot { RootID = _jobTypes.ID, Filters = filters });
                //            }
                //        }
                //    }
                //}

                if (this.PageSize == null || this.PageSize <= 0)
                    this.PageSize = PageSizeDefaultValue;

                if (filterModel.Page <= 0)
                    filterModel.Page = 1;

                //Execute - Try perform search
                ISearchJobsRequest request = new JXTNext_SearchJobsRequest { Page = filterModel.Page - 1, PageSize = (int)this.PageSize, Keywords = filterModel.Keywords, FiltersSearch = filtersSearch };
                response = _BLConnector.SearchJobs(request);
                JXTNext_SearchJobsResponse jobResultsList = response as JXTNext_SearchJobsResponse;

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

        private JobFiltersData _jobFiltersData;
        private JobFiltersData JobFiltersData
        {
            get {
                if (_jobFiltersData == null)
                {
                    IGetJobFiltersResponse filtersResponse = _OptionsConnector.JobFilters<JXTNext_GetJobFiltersRequest, JXTNext_GetJobFiltersResponse>(new JXTNext_GetJobFiltersRequest());
                    if (filtersResponse.Success)
                        _jobFiltersData = filtersResponse.Filters;
                    else
                    {
                        //something is wrong, handle me!
                    }
                }
                return _jobFiltersData;
            }
        }

        public int? PageSize { get; set; }
        public string DetailsPageId { get; set; }
        public string ResultsPageId { get; set; }
        public string Sorting { get; set; }
        public bool IsAllJobs { get; set; }
        public string CssClass { get; set; }
        public string SerializedJobTypes { get; set; }
       
        public string SerializedTotalJobTypes
        {
            get
            {
                JobFilterRoot _jobTypes = JobFiltersData.Data.Where(item => item.Name == "Job Types").FirstOrDefault();
                if (_jobTypes != null)
                    return JsonConvert.SerializeObject(_jobTypes.Filters);
                else
                    return null;
            }
        }

        internal const string WidgetIconCssClass = "sfMvcIcn";
        private const int PageSizeDefaultValue = 5;
        private string templateName = "JobsAll";
    }
}