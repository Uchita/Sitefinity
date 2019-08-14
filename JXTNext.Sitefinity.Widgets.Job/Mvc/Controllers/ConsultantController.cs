using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers;
using JXTNext.Sitefinity.Connector.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using JXTNext.Sitefinity.Common.Helpers;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using JXTNext.Sitefinity.Widgets.Job.Mvc.Models;
using System.ComponentModel;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using Telerik.Sitefinity.Model;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search;
using Telerik.Sitefinity.Web;
using JXTNext.Sitefinity.Widgets.Job.Mvc.StringResources;
using Telerik.OpenAccess;
using JXTNext.Sitefinity.Connector.Options.Models.Job;
using JXTNext.Sitefinity.Services.Intefaces.Models.JobAlert;
using Telerik.Sitefinity.Abstractions;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Controllers
{
    [EnhanceViewEngines]
    [Localization(typeof(ConsultantResources))]
    [ControllerToolboxItem(Name = "ConsultantJobs_MVC", Title = "Consultant Jobs", SectionName = "JXTNext.Job", CssClass = ConsultantController.WidgetIconCssClass)]
    public class ConsultantController : Controller
    {
        IBusinessLogicsConnector _BLConnector;
        IOptionsConnector _OConnector;

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

        public ConsultantController(IEnumerable<IBusinessLogicsConnector> _bConnectors, IEnumerable<IOptionsConnector> _oConnectors)
        {
            _BLConnector = _bConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
            _OConnector = _oConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
        }

        public ActionResult Index()
        {
            return View(this.templateNamePrefix + this.TemplateName);
        }

        public ActionResult Details(Telerik.Sitefinity.DynamicModules.Model.DynamicContent item)
        {
            dynamic dynamicJobResultsList = null;
            string location = string.Empty;
            Dictionary<string, List<string>> locationDict = new Dictionary<string, List<string>>();
            if (!string.IsNullOrWhiteSpace(Request.QueryString["location"]))
            {
                location = Request.QueryString["location"];
                string[] locArr = location.Split(',');
                
                for (int i = 0; i < locArr.Length; i++)
                {
                    var locationDetails = GetLocationGuid(locArr[i].Trim(new char[] { ' '}));
                    if(locationDetails.Key != null)
                    {
                        if (locationDict.ContainsKey(locationDetails.Key))
                        {
                            locationDict[locationDetails.Key].Add(locationDetails.Value);
                        }
                        else
                        {
                            locationDict[locationDetails.Key] = new List<string>();
                            locationDict[locationDetails.Key].Add(locationDetails.Value);
                        }
                    }
                }
            }
                
            JXTNext_SearchJobsRequest request = new JXTNext_SearchJobsRequest();
            JobSearchResultsFilterModel filterModelNew = new JobSearchResultsFilterModel();
            if (item.DoesFieldExist("ConsultantName"))
            {
                
                string consultantFullName = item.GetString("ConsultantName"); 
                
                if (!string.IsNullOrEmpty(consultantFullName))
                {
                    ViewBag.ConsultantName = consultantFullName;
                    List<string> consultantNameList = consultantFullName.Split(new char[] { ' ' }).ToList();
                    filterModelNew.ConsultantSearch = new Consultant();
                    filterModelNew.ConsultantSearch.Email = null;
                    filterModelNew.ConsultantSearch.FirstName = consultantNameList.First();
                    if (consultantNameList.Count > 1)
                        filterModelNew.ConsultantSearch.LastName = consultantNameList.Last();

                    if (!this.PageSize.HasValue || this.PageSize.Value <= 0)
                        this.PageSize = PageSizeDefaultValue;

                    request = JobSearchResultsFilterModel.ProcessInputToSearchRequest(filterModelNew, this.PageSize, PageSizeDefaultValue);

                    string sortingBy = this.Sorting;
                    if (filterModelNew != null && !filterModelNew.SortBy.IsNullOrEmpty())
                        sortingBy = filterModelNew.SortBy;

                    request.SortBy = JobSearchResultsFilterModel.GetSortEnumFromString(sortingBy);
                    ViewBag.SortOrder = JobSearchResultsFilterModel.GetSortStringFromEnum(request.SortBy);
                    Log.Write($"Job Search by Consultant name request json : " + JsonConvert.SerializeObject(request), ConfigurationPolicy.ErrorLog);
                    ISearchJobsResponse response = _BLConnector.SearchJobs(request);
                    JXTNext_SearchJobsResponse jobResultsList = response as JXTNext_SearchJobsResponse;
                    dynamicJobResultsList = jobResultsList as dynamic;
                }
            }
            else if (item.DoesFieldExist("Email"))
            {
                var email = item.GetString("Email");
                if (!string.IsNullOrEmpty(email))
                {
                    filterModelNew = new JobSearchResultsFilterModel() { ConsultantSearch = new Consultant() { Email = email } };

                    if (!this.PageSize.HasValue || this.PageSize.Value <= 0)
                        this.PageSize = PageSizeDefaultValue;

                    request = JobSearchResultsFilterModel.ProcessInputToSearchRequest(filterModelNew, this.PageSize, PageSizeDefaultValue);

                    string sortingBy = this.Sorting;
                    if (filterModelNew != null && !filterModelNew.SortBy.IsNullOrEmpty())
                        sortingBy = filterModelNew.SortBy;

                    request.SortBy = JobSearchResultsFilterModel.GetSortEnumFromString(sortingBy);
                    ViewBag.SortOrder = JobSearchResultsFilterModel.GetSortStringFromEnum(request.SortBy);
                    Log.Write($"Job Search by Consultant Email request json : " + JsonConvert.SerializeObject(request), ConfigurationPolicy.ErrorLog);
                    ISearchJobsResponse response = _BLConnector.SearchJobs(request);
                    JXTNext_SearchJobsResponse jobResultsList = response as JXTNext_SearchJobsResponse;
                    dynamicJobResultsList = jobResultsList as dynamic;
                }
            }

            filterModelNew.ConsultantSearch = null;
            filterModelNew.Filters = new List<JobSearchFilterReceiver>();

            if(dynamicJobResultsList.Total == 0)
            {
                if (item.DoesFieldExist("Category"))
                {
                    JobSearchFilterReceiver classificationSearch = new JobSearchFilterReceiver();
                    classificationSearch.rootId = "Classifications";
                    classificationSearch.searchTarget = "Categories";
                    classificationSearch.values = new List<JobSearchFilterReceiverItem>();
                    TrackedList<Guid> classIds = (TrackedList<Guid>)item.GetValue("Category");
                    if (classIds != null && classIds.Count > 0)
                    {
                        foreach (var id in classIds)
                        {
                            JobSearchFilterReceiverItem filterItem = new JobSearchFilterReceiverItem();
                            filterItem.ItemID = id.ToString().ToUpper();
                            filterItem.SubTargets = null;
                            classificationSearch.values.Add(filterItem);
                        }
                    }

                    filterModelNew.Filters.Add(classificationSearch);
                }

                if (locationDict.Count > 0)
                {
                    JobSearchFilterReceiver locationSearch = new JobSearchFilterReceiver();
                    locationSearch.rootId = "CountryLocationArea";
                    locationSearch.searchTarget = "Categories";
                    locationSearch.values = new List<JobSearchFilterReceiverItem>();
                    foreach (var cnsltLocation in locationDict)
                    {
                        JobSearchFilterReceiverItem filterItem = new JobSearchFilterReceiverItem();
                        filterItem.ItemID = cnsltLocation.Key.ToString().ToUpper();
                        filterItem.SubTargets = new List<JobSearchFilterReceiverItem>();
                        var subLocations = cnsltLocation.Value;
                        foreach (string subLocation in subLocations)
                        {
                            JobSearchFilterReceiverItem jobSearchFilterReceiverItem = new JobSearchFilterReceiverItem();
                            jobSearchFilterReceiverItem.ItemID = subLocation;
                            jobSearchFilterReceiverItem.SubTargets = null;
                            filterItem.SubTargets.Add(jobSearchFilterReceiverItem);
                        }
                        locationSearch.values.Add(filterItem);
                    }
                    filterModelNew.Filters.Add(locationSearch);
                }

                
                request = JobSearchResultsFilterModel.ProcessInputToSearchRequest(filterModelNew, this.PageSize, PageSizeDefaultValue);
                
                string sortBy = this.Sorting;
                if (filterModelNew != null && !filterModelNew.SortBy.IsNullOrEmpty())
                    sortBy = filterModelNew.SortBy;

                request.SortBy = JobSearchResultsFilterModel.GetSortEnumFromString(sortBy);
                ViewBag.SortOrder = JobSearchResultsFilterModel.GetSortStringFromEnum(request.SortBy);
                Log.Write($"Job Search by Consultant related classification and location request json : " + JsonConvert.SerializeObject(request), ConfigurationPolicy.ErrorLog);
                ISearchJobsResponse searchResponse = _BLConnector.SearchJobs(request);
                JXTNext_SearchJobsResponse relatedJobResultsList = searchResponse as JXTNext_SearchJobsResponse;
                dynamicJobResultsList = relatedJobResultsList as dynamic;
            }


            ViewBag.PageSize = (int)this.PageSize;
            ViewBag.CssClass = this.CssClass;
            ViewBag.JobResultsPageUrl = SitefinityHelper.GetPageUrl(this.ResultsPageId);
            ViewBag.CurrentPageUrl = SitefinityHelper.GetPageUrl(SiteMapBase.GetActualCurrentNode().Id.ToString());
            ViewBag.JobDetailsPageUrl = SitefinityHelper.GetPageUrl(this.DetailsPageId);

            return this.View(this.templateNamePrefix + this.TemplateName, dynamicJobResultsList);
        }

        private KeyValuePair<string, string> GetLocationGuid(string location)
        {
            JXTNext_GetJobFiltersRequest request = new JXTNext_GetJobFiltersRequest();
            IGetJobFiltersResponse filtersResponse = _OConnector.JobFilters<JXTNext_GetJobFiltersRequest, JXTNext_GetJobFiltersResponse>(request);
            List<JobFilterRoot> fitersData = null;
            if (filtersResponse != null && filtersResponse.Filters != null
                && filtersResponse.Filters.Data != null)
                fitersData = filtersResponse.Filters.Data;

            var serializeFilterData = JsonConvert.SerializeObject(fitersData);
            var filtersVMList = JsonConvert.DeserializeObject<List<JobAlertEditFilterRootItem>>(serializeFilterData);
            bool found = false;
            string rootId = string.Empty;
            string guid = string.Empty;
            if (filtersVMList != null && filtersVMList.Count > 0)
            {
                foreach (var filterVMRootItem in filtersVMList)
                {
                    if (filterVMRootItem.Filters != null && filterVMRootItem.Name == "CountryLocationArea" && filterVMRootItem.Filters.Count > 0)
                    {
                        foreach (var filterItem in filterVMRootItem.Filters)
                        {
                            filterItem.Filters?.ForEach(x => {
                                if (x.Label.ToLower() == location.ToLower())
                                {
                                    found = true;
                                    guid = x.ID;
                                    rootId = filterItem.ID;
                                }
                            });
                        }
                    }
                }
            }

            KeyValuePair<string, string> key = new KeyValuePair<string, string>();
            if (found)
            {
                key = new KeyValuePair<string, string>(rootId,guid);
            }

            return key;
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }

        internal const string WidgetIconCssClass = "sfMvcIcn";
        public string CssClass { get; set; }

        private string templateName = "Simple";
        private string templateNamePrefix = "ConsultantJobs.";
        private const int PageSizeDefaultValue = 5;
        public int? PageSize { get; set; }
        public string DetailsPageId { get; set; }
        public string ResultsPageId { get; set; }
        public string Sorting { get; set; }
    }
}