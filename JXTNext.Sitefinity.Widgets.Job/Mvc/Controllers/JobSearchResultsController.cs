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
using Telerik.Sitefinity.Web;

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
        public ActionResult Index([ModelBinder(typeof(JobSearchResultsFilterBinder))] JobSearchResultsFilterModel filterModel)
        {
            dynamic dynamicJobResultsList = null;

            if (filterModel != null)
            {
                ISearchJobsResponse response = GetJobSearchResultsResponse(filterModel);
                dynamicJobResultsList = response as dynamic;
            }

            return View(this.TemplateName, dynamicJobResultsList);
        }


        [HttpPost]
        public JsonResult GetSearchResults(string jobRequest, int pageNumber)
        {
            //Use preconfigured search config from widget settings if available
            JobSearchResultsFilterModel searchInputs;

            if (SearchConfig != null)
                searchInputs = JsonConvert.DeserializeObject<JobSearchResultsFilterModel>(SearchConfig);
            else
                searchInputs = JsonConvert.DeserializeObject<JobSearchResultsFilterModel>(jobRequest);

            JXTNext_SearchJobsRequest searchRequest = ProcessInputToSearchRequest(searchInputs);

            JXTNext_SearchJobsResponse jobResponse = (JXTNext_SearchJobsResponse)_BLConnector.SearchJobs(searchRequest);

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

        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }

        private ISearchJobsResponse GetJobSearchResultsResponse(JobSearchResultsFilterModel filterModel)
        {
            JXTNext_SearchJobsRequest request = ProcessInputToSearchRequest(filterModel);
            ISearchJobsResponse response = _BLConnector.SearchJobs(request);

            JXTNext_SearchJobsResponse jobResultsList = response as JXTNext_SearchJobsResponse;

            ViewBag.Request = JsonConvert.SerializeObject(filterModel);
            ViewBag.FilterModel = JsonConvert.SerializeObject(filterModel);
            ViewBag.PageSize = (int)this.PageSize;
            ViewBag.SortOrder = this.Sorting;
            ViewBag.CssClass = this.CssClass;
            if (jobResultsList != null)
                ViewBag.TotalCount = jobResultsList.Total;

            ViewBag.JobResultsPageUrl = SitefinityHelper.GetPageUrl(this.ResultsPageId);
            ViewBag.JobDetailsPageUrl = SitefinityHelper.GetPageUrl(this.DetailsPageId);
            ViewBag.HidePushStateUrl = this.HidePushStateUrl;
            ViewBag.PageFullUrl = SitefinityHelper.GetPageFullUrl(SiteMapBase.GetActualCurrentNode().Id);

            return response;
        }

        private JXTNext_SearchJobsRequest ProcessInputToSearchRequest(JobSearchResultsFilterModel filterModel)
        {
            JXTNext_SearchJobsRequest request = new JXTNext_SearchJobsRequest();
            if (filterModel != null)
            {
                if (!string.IsNullOrEmpty(filterModel.Keywords))
                    request.KeywordsSearchCriteria = new List<KeywordSearch> { new KeywordSearch { Keyword = filterModel.Keywords } };

                if (filterModel.Filters != null && filterModel.Filters.Count() > 0)
                {
                    List<IClassificationSearch> classificationSearches = new List<IClassificationSearch>();
                    for (int i = 0; i < filterModel.Filters.Count(); i++)
                    {
                        var filter = filterModel.Filters[i];
                        if (filter != null && filter.values != null && filter.values.Count > 0)
                        {
                            Classification_CategorySearch cateSearch = new Classification_CategorySearch
                            {
                                ClassificationRootName = filter.rootId,
                                TargetClassifications = new List<Classification_CategorySearchTarget>()
                            };

                            foreach(var filterItem in filter.values)
                            {
                                var targetCategory = new Classification_CategorySearchTarget() { SubTargets = new List<Classification_CategorySearchTarget>() };
                                ProcessFilterLevels(targetCategory, filterItem);
                                cateSearch.TargetClassifications.Add(targetCategory);
                            }

                            classificationSearches.Add(cateSearch);
                        }
                    }
                    request.ClassificationsSearchCriteria = classificationSearches;
                }

                if (this.PageSize == null || this.PageSize <= 0)
                    this.PageSize = PageSizeDefaultValue;

                if (filterModel.Page <= 0)
                    filterModel.Page = 1;

                request.PageNumber = filterModel.Page - 1;
                request.PageSize = (int)this.PageSize;
            }

            return request;
        }

        private static void ProcessFilterLevels(Classification_CategorySearchTarget catTarget, JobSearchFilterReceiverItem filterItem)
        {
            if (catTarget != null && filterItem != null)
            {
                catTarget.TargetValue = filterItem.ItemID;
                if(filterItem.SubTargets != null && filterItem.SubTargets.Count > 0)
                {
                    Classification_CategorySearchTarget catSubTarget = new Classification_CategorySearchTarget() { SubTargets = new List<Classification_CategorySearchTarget>() };
                    foreach (var subItem in filterItem.SubTargets)
                    {
                        ProcessFilterLevels(catSubTarget, subItem);
                    }
                    catTarget.SubTargets.Add(catSubTarget);
                }
            }
        }

        private JobFiltersData _jobFiltersData;
        private JobFiltersData JobFiltersData
        {
            get
            {
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
        public bool HidePushStateUrl { get; set; }
        public string SearchConfig { get; set; }

        internal const string WidgetIconCssClass = "sfMvcIcn";
        private const int PageSizeDefaultValue = 5;
        private string templateName = "JobsAll";
    }
}