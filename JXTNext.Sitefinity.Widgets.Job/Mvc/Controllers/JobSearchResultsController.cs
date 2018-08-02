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
using Telerik.Sitefinity.Taxonomies.Model;
using System.ComponentModel;

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

            if (this.UseConfigFilters)
            {
                var jobFilterComponents = this.SerializedJobSearchParams == null ? null : JsonConvert.DeserializeObject<List<JobSearchModel>>(this.SerializedJobSearchParams);

                if (jobFilterComponents != null)
                {
                    searchInputs = new JobSearchResultsFilterModel() {Keywords =this.KeywordsSelectedJobs, Filters = new List<JobSearchFilterReceiver>() };
                    foreach (JobSearchModel item in jobFilterComponents)
                    {
                        FilterData(item.Filters);
                        item.Filters = item.Filters.Where(d => d.Show == true || d.Filters?.Count > 0).ToList();
                    }

                    foreach (var configItem in jobFilterComponents)
                    {
                        var rootFilterItem = new JobSearchFilterReceiver() { values = new List<JobSearchFilterReceiverItem>() };
                        rootFilterItem.rootId = configItem.FilterType;

                        foreach (var subFilItem in configItem.Filters)
                        {
                            var targetFilterItem = new JobSearchFilterReceiverItem() { SubTargets = new List<JobSearchFilterReceiverItem>() };
                            ProcessConfigFilterItems(targetFilterItem, subFilItem);
                            rootFilterItem.values.Add(targetFilterItem);
                        }

                        searchInputs.Filters.Add(rootFilterItem);
                    }
                }
            }

            searchInputs.Page = pageNumber;

            JXTNext_SearchJobsRequest searchRequest = ProcessInputToSearchRequest(searchInputs);

            JXTNext_SearchJobsResponse jobResponse = (JXTNext_SearchJobsResponse)_BLConnector.SearchJobs(searchRequest);

            return new JsonResult { Data = jobResponse };
        }

        [HttpPost]
        [StandaloneResponseFilter]
        public PartialViewResult GetFilterSearchResultsPartial([ModelBinder(typeof(JobSearchResultsFilterBinder))] JobSearchResultsFilterModel filterModel)
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
            this.Index(null).ExecuteResult(this.ControllerContext);
        }

        static void ProcessConfigFilterItems(JobSearchFilterReceiverItem targetFilterItem, JobSearchItem sourceFilterItem)
        {
            if (targetFilterItem != null && sourceFilterItem != null)
            {
                targetFilterItem.ItemID = sourceFilterItem.ID;

                foreach (var subFilterItem in sourceFilterItem.Filters)
                {
                    var subTargetFilter = new JobSearchFilterReceiverItem() { SubTargets = new List<JobSearchFilterReceiverItem>() };
                    ProcessConfigFilterItems(subTargetFilter, subFilterItem);
                    targetFilterItem.SubTargets.Add(subTargetFilter);
                }
            }
        }


        static void FilterData(List<JobSearchItem> data)
        {
            if (data == null || data.Count == 0)
                return;

            foreach (JobSearchItem item in data)
            {
                if (item.Filters != null && item.Filters.Count > 0)
                {
                    FilterData(item.Filters);
                    item.Filters = item.Filters.Where(d => d.Show == true || d.Filters?.Count > 0).ToList();
                }
            }

            data = data.Where(d => d.Show == true || d.Filters?.Count > 0).ToList();
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

        public static void ProcessCategories(HierarchicalTaxon category, JobFilter jobFilter)
        {
            if (category != null && jobFilter != null)
            {
                jobFilter.ID = category.Id.ToString().ToUpper();
                jobFilter.Label = category.Title;
                if (category.Subtaxa != null && category.Subtaxa.Count > 0)
                {
                    foreach (var subTaxon in category.Subtaxa)
                    {
                        var subFilter = new JobFilter() { Filters = new List<JobFilter>() };
                        ProcessCategories(subTaxon, subFilter);
                        jobFilter.Filters.Add(subFilter);
                    }
                }
            }
        }

        public static JobFiltersData GetFiltersData()
        {
            JobFiltersData filtersData = new JobFiltersData() { Data = new List<JobFilterRoot>() };
            var topLovelCategories = SitefinityHelper.GetTopLevelCategories();

            foreach (var taxon in topLovelCategories)
            {
                JobFilterRoot filterRoot = new JobFilterRoot() { Filters = new List<JobFilter>() };
                filterRoot.ID = taxon.Id.ToString().ToUpper();
                filterRoot.Name = taxon.Title;

                var hierarchicalTaxon = taxon as HierarchicalTaxon;
                if (hierarchicalTaxon != null)
                {
                    foreach (var childTaxon in hierarchicalTaxon.Subtaxa)
                    {
                        var jobFilter = new JobFilter() { Filters = new List<JobFilter>() };
                        ProcessCategories(childTaxon, jobFilter);
                        filterRoot.Filters.Add(jobFilter);
                    }
                }

                filtersData.Data.Add(filterRoot);
            }

            return filtersData;
        }

        private string _serializedFilterData;
        public string SerializedFilterData
        {
            get
            {
                if (string.IsNullOrEmpty(_serializedFilterData))
                {
                    var filtersData = GetFiltersData();
                    _serializedFilterData = JsonConvert.SerializeObject(filtersData.Data);
                }
                return _serializedFilterData;
            }
        }

        public int? PageSize { get; set; }
        public string DetailsPageId { get; set; }
        public string ResultsPageId { get; set; }
        public string Sorting { get; set; }
        public bool IsAllJobs { get; set; }
        public string CssClass { get; set; }
        public string SerializedJobTypes { get; set; }
        public string SerializedTotalJobTypes { get; set; }
        public bool HidePushStateUrl { get; set; }
        public string SearchConfig { get; set; }
        public string SerializedJobSearchParams { get; set; }
        public string KeywordsSelectedJobs { get; set; }
        public bool UseConfigFilters { get; set; }

        internal const string WidgetIconCssClass = "sfMvcIcn";
        private const int PageSizeDefaultValue = 5;
        private string templateName = "JobsAll";
    }
}