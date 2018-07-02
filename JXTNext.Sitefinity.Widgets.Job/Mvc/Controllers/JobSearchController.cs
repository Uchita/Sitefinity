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

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Controllers
{
    [EnhanceViewEngines]
    [ControllerToolboxItem(Name = "JobSearch_MVC", Title = "Search", SectionName = "JXTNext.Job", CssClass = JobSearchController.WidgetIconCssClass)]
    public class JobSearchController : Controller
    {
        IBusinessLogicsConnector _testBLConnector;
        IOptionsConnector _testOConnector;

        public JobSearchController(IEnumerable<IBusinessLogicsConnector> _bConnectors, IEnumerable<IOptionsConnector> _oConnectors)
        {
            _testBLConnector = _bConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.Test).FirstOrDefault();
            _testOConnector = _oConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();

            //Execute - Get available filter options from the server
            //JXTNext_GetJobFiltersRequest request = new JXTNext_GetJobFiltersRequest { SiteId = 1 };
            //filtersResponse = _testOConnector.JobFilters<JXTNext_GetJobFiltersRequest, JXTNext_GetJobFiltersResponse>(request);
            //this.SerializedFilterData = JsonSerializer.SerializeToString(filtersResponse.Filters.Data);
        }

        public string CssClass { get; set; }
        public string ResultsPageId { get; set; }

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
            


            //Execute - Try perform a dummy search
            ISearchJobsRequest request = new Test_SearchJobsRequest { Page = 0, PageSize = 2, FiltersSearch = new List<FiltersSearchRoot> { new FiltersSearchRoot { RootID = "AE-1234", Filters = new List<FiltersSearchElement> { new FiltersSearchElement { ID = "DD-3123" } } } } };
            ISearchJobsResponse response = _testBLConnector.SearchJobs(request);

            IGetJobListingRequest jobListingRequest = new Test_GetJobListingRequest { JobID = 85 };
            IGetJobListingResponse jobListingResponse = _testBLConnector.AdvertiserGetJob(jobListingRequest);

            // This is the CSS classes enter from More Options
            ViewData["CssClass"] = this.CssClass;
            ViewData["JobResultsPageUrl"] = SitefinityHelper.GetPageUrl(this.ResultsPageId);

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
                    JXTNext_GetJobFiltersRequest filterOptionRequest = new JXTNext_GetJobFiltersRequest { SiteId = 1 };
                    IGetJobFiltersResponse filtersResponse = _testOConnector.JobFilters<JXTNext_GetJobFiltersRequest, JXTNext_GetJobFiltersResponse>(filterOptionRequest);
                    _serializedFilterData = JsonConvert.SerializeObject(filtersResponse.Filters.Data);
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