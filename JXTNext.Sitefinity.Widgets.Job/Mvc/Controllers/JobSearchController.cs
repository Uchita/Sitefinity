using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search;
using JXTNext.Sitefinity.Connector.Options;
using JXTNext.Sitefinity.Connector.Options.Models.Job;
using JXTNext.Sitefinity.Widgets.Job.Mvc.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using JXTNext.Sitefinity.Common.Helpers;
using Newtonsoft.Json;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using Telerik.Sitefinity.Taxonomies.Model;
using System;
using JXTNext.Sitefinity.Widgets.Job.Mvc.StringResources;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Controllers
{
    [EnhanceViewEngines]
    [Localization(typeof(JobSearchResources))]
    [ControllerToolboxItem(Name = "JobSearch_MVC", Title = "Search", SectionName = "Jobs", CssClass = JobSearchController.WidgetIconCssClass)]
    public class JobSearchController : Controller
    {
        IBusinessLogicsConnector _BLConnector;
        IOptionsConnector _OConnector;

        public JobSearchController(IEnumerable<IBusinessLogicsConnector> _bConnectors, IEnumerable<IOptionsConnector> _oConnectors)
        {
            _BLConnector = _bConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
            _OConnector = _oConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();

            //Execute - Get available filter options from the server
            //JXTNext_GetJobFiltersRequest request = new JXTNext_GetJobFiltersRequest { SiteId = 1 };
            //filtersResponse = _testOConnector.JobFilters<JXTNext_GetJobFiltersRequest, JXTNext_GetJobFiltersResponse>(request);
            //this.SerializedFilterData = JsonSerializer.SerializeToString(filtersResponse.Filters.Data);
        }

        public string CssClass { get; set; }
        public string ResultsPageId { get; set; }
        public string PrefixIdText { get; set; }

        public Guid AdvancedSearchPageId { get; set; }

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

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public JobSearchModel Model
        {
            get
            {
                if (this.model == null)
                    this.model = new JobSearchModel();

                return this.model;
            }
        }
        // GET: JobSearch
        public ActionResult Index()
        {

            // This is the CSS classes enter from More Options
            // this needs to me moved to a viewmodel rather than ViewData
            ViewData["CssClass"] = this.CssClass;
            ViewData["JobResultsPageUrl"] = SfPageHelper.GetPageUrlById(new Guid(ResultsPageId));
            ViewData["AdvancedSearchPageUrl"] = AdvancedSearchPageId != Guid.Empty ? SfPageHelper.GetPageUrlById(AdvancedSearchPageId) : "/advancedsearch";

            var jobSearchComponents = this.SerializedJobSearchParams == null ? null : JsonConvert.DeserializeObject<List<JobSearchModel>>(this.SerializedJobSearchParams);
            if(jobSearchComponents != null)
            {
                foreach (JobSearchModel item in jobSearchComponents)
                {
                    FilterData(item.Filters);
                    item.Filters = item.Filters.Where(d => d.Show == true || d.Filters?.Count > 0).ToList();
                }
            }

            var fullTemplateName = this.templateNamePrefix + this.TemplateName;
            AppendParentIds(jobSearchComponents);
            ViewData["PrefixIdsText"] = this.PrefixIdText == null?"":this.PrefixIdText;

            return View(fullTemplateName, jobSearchComponents);
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

        static void ProcessFiltersIds(List<JobSearchItem> filters, string parentId)
        {
            if (filters != null && filters.Count > 0)
            {
                foreach (var filter in filters)
                {
                    filter.ID = parentId + "_" + filter.ID;
                    if (filter.Filters != null && filter.Filters.Count > 0)
                    {
                        // Organiging by alphbetical order
                        filter.Filters = filter.Filters.OrderBy(x => x.Label).ToList();
                        ProcessFiltersIds(filter.Filters, filter.ID);
                    }
                }
            }
        }

        static void AppendParentIds(List<JobSearchModel> filtersVMList)
        {
            if (filtersVMList != null && filtersVMList.Count > 0)
            {
                foreach (var filterRoot in filtersVMList)
                {
                    if (filterRoot.Filters != null && filterRoot.Filters.Count > 0)
                    {
                        filterRoot.Filters = filterRoot.Filters.OrderBy(x => x.Label).ToList();
                        foreach (var filter in filterRoot.Filters)
                        {
                            if (filter.Filters != null && filter.Filters.Count > 0)
                            {
                                // Organiging by alphbetical order
                                filter.Filters = filter.Filters.OrderBy(x => x.Label).ToList();
                                ProcessFiltersIds(filter.Filters, filter.ID);
                            }
                        }
                    }
                }
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

        protected override void HandleUnknownAction(string actionName)
        {
            this.Index().ExecuteResult(this.ControllerContext);
        }

        public string SerializedJobSearchParams { get; set; }

        private string _serializedFilterData;
        public string SerializedFilterData {
            get
            {
                if( string.IsNullOrEmpty(_serializedFilterData))
                {
                    //JXTNext_GetJobFiltersRequest filterOptionRequest = new JXTNext_GetJobFiltersRequest { SiteId = 1 };
                    //IGetJobFiltersResponse filtersResponse = _OConnector.JobFilters<JXTNext_GetJobFiltersRequest, JXTNext_GetJobFiltersResponse>(filterOptionRequest);
                    var filtersData = GetFiltersData();
                    _serializedFilterData = JsonConvert.SerializeObject(filtersData.Data);
                }
                return _serializedFilterData;
            }
        }


        internal const string WidgetIconCssClass = "sfMvcIcn";
        private JobSearchModel model;
        private string templateName = "Simple";
        private string templateNamePrefix = "JobSearch.";
    }
}