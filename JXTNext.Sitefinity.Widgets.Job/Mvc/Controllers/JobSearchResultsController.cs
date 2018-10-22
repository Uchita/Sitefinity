using JXTNext.Sitefinity.Common.Helpers;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search;
using JXTNext.Sitefinity.Connector.Options;
using JXTNext.Sitefinity.Connector.Options.Models.Job;
using JXTNext.Sitefinity.Widgets.Job.Mvc.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Mvc.ActionFilters;
using Telerik.Sitefinity.Security.Model;
using Telerik.Sitefinity.Taxonomies.Model;
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
        public ActionResult Index([ModelBinder(typeof(JobSearchResultsFilterBinder))] JobSearchResultsFilterModel filterModel, int? jobId)
        {
            dynamic dynamicJobResultsList = null;

            if (jobId.HasValue)
            {
                IGetJobListingRequest jobListingRequest = new JXTNext_GetJobListingRequest { JobID = jobId.Value };
                IGetJobListingResponse jobListingResponse = _BLConnector.GuestGetJob(jobListingRequest);
                var jobDetails = jobListingResponse.Job;
                var classificationTopLevelId = jobListingResponse.Job.CustomData["Classifications[0].Filters[0].ExternalReference"];

                JobSearchResultsFilterModel filterModelNew = new JobSearchResultsFilterModel() { Filters = new List<JobSearchFilterReceiver>() };
                JobSearchFilterReceiverItem filterReceiverItem = new JobSearchFilterReceiverItem() { ItemID = classificationTopLevelId };
                JobSearchFilterReceiver filterReceiver = new JobSearchFilterReceiver() { rootId = "Classifications", values = new List<JobSearchFilterReceiverItem>() };
                filterReceiver.values.Add(filterReceiverItem);
                filterModelNew.Filters.Add(filterReceiver);

                ISearchJobsResponse response = GetJobSearchResultsResponse(filterModelNew);
                JXTNext_SearchJobsResponse jobResultsList = response as JXTNext_SearchJobsResponse;
                jobResultsList.SearchResults.RemoveAll(item => item.JobID == jobId.Value);
                dynamicJobResultsList = jobResultsList as dynamic;
            }
            else if (filterModel != null)
            {
                ISearchJobsResponse response = GetJobSearchResultsResponse(filterModel);
                dynamicJobResultsList = response as dynamic;
            }

            return View(this.TemplateName, dynamicJobResultsList);
        }

        [HttpPost]
        public JsonResult GetSearchResults(string jobRequest, int pageNumber, string sortBy)
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
                    searchInputs = new JobSearchResultsFilterModel() { Keywords = this.KeywordsSelectedJobs, Filters = new List<JobSearchFilterReceiver>() };
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
            searchInputs.SortBy = sortBy;

            if (!this.PageSize.HasValue || this.PageSize.Value <= 0)
                this.PageSize = PageSizeDefaultValue;

            JXTNext_SearchJobsRequest searchRequest = JobSearchResultsFilterModel.ProcessInputToSearchRequest(searchInputs, this.PageSize, PageSizeDefaultValue);

            string sortingBy = this.Sorting;
            if (searchInputs != null && !searchInputs.SortBy.IsNullOrEmpty())
                sortingBy = searchInputs.SortBy;

            searchRequest.SortBy = JobSearchResultsFilterModel.GetSortEnumFromString(sortingBy);
            ViewBag.SortOrder = JobSearchResultsFilterModel.GetSortStringFromEnum(searchRequest.SortBy);

            JXTNext_SearchJobsResponse jobResponse = (JXTNext_SearchJobsResponse)_BLConnector.SearchJobs(searchRequest);

            foreach (var item in jobResponse.SearchResults)
            {
                List<OrderedDictionary> classificationItemsList = new List<OrderedDictionary>();
                item.ClassificationsRootName = "Classifications";

                // Assuming the maximum ten parents the job will be posted
                for (int i = 0; i < 10; i++)
                {
                    string key = "Classifications[0].Filters[" + i + "].ExternalReference";
                    string value = "Classifications[0].Filters[" + i + "].Value";
                    string parentClassificationsKey = "Classifications[0].Filters[" + i + "].SubLevel[0]";
                    if (item.CustomData.ContainsKey(key))
                    {
                        OrderedDictionary classifOrdDict = new OrderedDictionary();
                        classifOrdDict.Add(item.CustomData[key], item.CustomData[value]);
                        JobDetailsViewModel.ProcessCustomData(parentClassificationsKey, item.CustomData, classifOrdDict);
                        OrderedDictionary classifParentIdsOrdDict = new OrderedDictionary();
                        JobDetailsViewModel.AppendParentIds(classifOrdDict, classifParentIdsOrdDict);
                        classificationItemsList.Add(classifParentIdsOrdDict);
                        item.Classifications = classificationItemsList;
                    }
                }

                // Take the first item in the list as SEO route for Job Details page
                if (item.Classifications.Count > 0)
                {
                    List<string> seoString = new List<string>();
                    foreach (var key in item.Classifications[0].Keys)
                    {
                        string value = item.Classifications[0][key].ToString();
                        string SEOString = Regex.Replace(value, @"([^\w]+)", "-");
                        seoString.Add(SEOString);
                    }

                    item.ClassificationsSEORouteName = String.Join("/", seoString);
                }
            }

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

        [HttpPost]
        public JsonResult SaveJob(int JobId)
        {
            JXTNext_MemberSaveJobRequest request = new JXTNext_MemberSaveJobRequest() { JobId = JobId };
            JXTNext_MemberSaveJobResponse response = _BLConnector.MemberSaveJob(request) as JXTNext_MemberSaveJobResponse;

            return new JsonResult { Data = response };
        }

        [HttpPost]
        public JsonResult RemoveSavedJob(int JobId)
        {
            JXTNext_MemberSaveJobResponse response = _BLConnector.MemberDeleteSavedJob(JobId) as JXTNext_MemberSaveJobResponse;
            return new JsonResult { Data = response };
        }

        [HttpPost]
        public JsonResult GetAllSavedJobs()
        {
            JXTNext_MemberGetSavedJobResponse response = _BLConnector.MemberGetSavedJobs() as JXTNext_MemberGetSavedJobResponse;
            return new JsonResult { Data = response };
        }

        /// <summary>
        /// Renders appropriate list view depending on the <see cref="DetailTemplateName"/>
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// This is going to give the serarch results based on the User. User will come from Uses Widget
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public ActionResult Details(UserProfile user)
        {
            dynamic dynamicJobResultsList = null;

            JobSearchResultsFilterModel filterModelNew = new JobSearchResultsFilterModel() { ConsultantSearch = new Consultant() { Email = user.User.Email } };
            ISearchJobsResponse response = GetJobSearchResultsResponse(filterModelNew);
            JXTNext_SearchJobsResponse jobResultsList = response as JXTNext_SearchJobsResponse;
            dynamicJobResultsList = jobResultsList as dynamic;

            return this.View(this.TemplateName, dynamicJobResultsList);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
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
            if (!this.PageSize.HasValue || this.PageSize.Value <= 0)
                this.PageSize = PageSizeDefaultValue;

            JXTNext_SearchJobsRequest request = JobSearchResultsFilterModel.ProcessInputToSearchRequest(filterModel, this.PageSize, PageSizeDefaultValue);

            string sortingBy = this.Sorting;
            if (filterModel != null && !filterModel.SortBy.IsNullOrEmpty())
                sortingBy = filterModel.SortBy;

            request.SortBy = JobSearchResultsFilterModel.GetSortEnumFromString(sortingBy);
            ViewBag.SortOrder = JobSearchResultsFilterModel.GetSortStringFromEnum(request.SortBy);

            ISearchJobsResponse response = _BLConnector.SearchJobs(request);

            JXTNext_SearchJobsResponse jobResultsList = response as JXTNext_SearchJobsResponse;

            ViewBag.Request = JsonConvert.SerializeObject(filterModel);
            ViewBag.FilterModel = JsonConvert.SerializeObject(filterModel);
            ViewBag.PageSize = (int)this.PageSize;
            ViewBag.CssClass = this.CssClass;
            if (jobResultsList != null)
                ViewBag.TotalCount = jobResultsList.Total;

            ViewBag.JobResultsPageUrl = SitefinityHelper.GetPageUrl(this.ResultsPageId);
            ViewBag.CurrentPageUrl = SitefinityHelper.GetPageUrl(SiteMapBase.GetActualCurrentNode().Id.ToString());
            ViewBag.JobDetailsPageUrl = SitefinityHelper.GetPageUrl(this.DetailsPageId);
            ViewBag.HidePushStateUrl = this.HidePushStateUrl;
            ViewBag.PageFullUrl = SitefinityHelper.GetPageFullUrl(SiteMapBase.GetActualCurrentNode().Id);

            ViewBag.IsMember = SitefinityHelper.IsUserLoggedIn("Member");

            return response;
        }
        
        private JXTNext_SearchJobsRequest ProcessInputToSearchRequest(JobSearchResultsFilterModel filterModel)
        {
            JXTNext_SearchJobsRequest request = new JXTNext_SearchJobsRequest();
            if (filterModel != null)
            {
                if (!string.IsNullOrEmpty(filterModel.Keywords))
                    request.KeywordsSearchCriteria = new List<KeywordSearch> { new KeywordSearch { Keyword = filterModel.Keywords } };

                if (filterModel.ConsultantSearch != null && !string.IsNullOrEmpty(filterModel.ConsultantSearch.Email))
                    request.ConsultantSearchCriteria = new ConsultantSearch() { Email = filterModel.ConsultantSearch.Email, FirstName = filterModel.ConsultantSearch.FirstName, LastName = filterModel.ConsultantSearch.LastName };

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

                            foreach (var filterItem in filter.values)
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
                request.PageSize = this.PageSize == 0 ? 10 : (int)this.PageSize;
            }

            return request;
        }

        private static void ProcessFilterLevels(Classification_CategorySearchTarget catTarget, JobSearchFilterReceiverItem filterItem)
        {
            if (catTarget != null && filterItem != null)
            {
                catTarget.TargetValue = filterItem.ItemID;
                if (filterItem.SubTargets != null && filterItem.SubTargets.Count > 0)
                {
                    foreach (var subItem in filterItem.SubTargets)
                    {
                        Classification_CategorySearchTarget catSubTarget = new Classification_CategorySearchTarget() { SubTargets = new List<Classification_CategorySearchTarget>() };
                        ProcessFilterLevels(catSubTarget, subItem);
                        catTarget.SubTargets.Add(catSubTarget);
                    }
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