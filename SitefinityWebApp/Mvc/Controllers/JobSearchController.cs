using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Web;
using SitefinityWebApp.Mvc.Models;
using System.ComponentModel;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Pages.Model;
using ServiceStack.Text;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.Options;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search;
using JXTNext.Sitefinity.Connector.Options.Models.Job;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "JobSearch_MVC", Title = "Job Search", SectionName = "Search", CssClass = JobSearchController.WidgetIconCssClass)]
    public class JobSearchController : Controller
    {
        IBusinessLogicsConnector _testBLConnector;
        IOptionsConnector _testOConnector;
        IGetJobFiltersResponse filtersResponse;

        public JobSearchController(IEnumerable<IBusinessLogicsConnector> _bConnectors, IEnumerable<IOptionsConnector> _oConnectors)
        {
            _testBLConnector = _bConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.Test).FirstOrDefault();
            _testOConnector = _oConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.Test).FirstOrDefault();
          
            //Execute - Get available filter options from the server
            filtersResponse = _testOConnector.JobFilters<Test_GetJobFiltersRequest, Test_GetJobFiltersResponse>(new Test_GetJobFiltersRequest());
            this.SerializedFilterData = JsonSerializer.SerializeToString(filtersResponse.Filters.Data);
        }

        public string CssClass { get; set; }
        public string ResultsPageId { get; set; }
        
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
            filtersResponse = _testOConnector.JobFilters<Test_GetJobFiltersRequest, Test_GetJobFiltersResponse>(new Test_GetJobFiltersRequest());
            this.SerializedFilterData = JsonSerializer.SerializeToString(filtersResponse.Filters.Data);

            //Execute - Try perform a dummy search
            ISearchJobsRequest request = new Test_SearchJobsRequest { Page = 0, PageSize = 2, FiltersSearch = new List<FiltersSearchRoot> { new FiltersSearchRoot { RootID = "AE-1234", Filters = new List<FiltersSearchElement> { new FiltersSearchElement { ID = "DD-3123" } } } } };
            ISearchJobsResponse response = _testBLConnector.SearchJobs(request);

            IGetJobListingRequest jobListingRequest = new Test_GetJobListingRequest { JobID = "8A" };
            IGetJobListingResponse jobListingResponse = _testBLConnector.AdvertiserGetJob(jobListingRequest);

            // This is the CSS classes enter from More Options
            ViewData["CssClass"] = this.CssClass;

            PageManager pageManager = PageManager.GetManager();
            if (pageManager != null)
            {
                if (!this.ResultsPageId.IsNullOrEmpty())
                {
                    Guid resultsPageNodeId = new Guid(this.ResultsPageId);
                    PageNode resultsPageNode = pageManager.GetPageNodes().Where(n => n.Id == resultsPageNodeId).FirstOrDefault();
                    // we will get the url as ~/resultspage
                    // So removing the first character
                    if (resultsPageNode != null)
                        ViewData["JobResultsPageUrl"] = resultsPageNode.GetUrl().Substring(1);
                }
            }

            var jobSearchComponents = JsonSerializer.DeserializeFromString<List<JobSearchModel>>(this.SerializedJobSearchParams);
            if(jobSearchComponents != null)
            {
                foreach (JobSearchModel item in jobSearchComponents)
                {
                    FilterData(item.Filters);
                    item.Filters = item.Filters.Where(d => d.Show == true || d.Filters?.Count > 0).ToList();
                }
            }
            return View("Simple", jobSearchComponents);
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
        public string SerializedFilterData { get; set; }
        internal const string WidgetIconCssClass = "sfMvcIcn";
        private JobSearchModel model;
    }
}