using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Web;
using SitefinityWebApp.Mvc.Models;
using System.ComponentModel;
using ServiceStack.Text;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.Options;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search;
using JXTNext.Sitefinity.Connector.Options.Models.Job;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "JobSearch_MVC", Title = "Job Search", SectionName = "Search", CssClass = JobSearchController.WidgetIconCssClass)]
    public class JobSearchController : Controller
    {
        IBusinessLogicsConnector _testBLConnector;
        IOptionsConnector _testOConnector;
        public JobSearchController(IEnumerable<IBusinessLogicsConnector> _bConnectors, IEnumerable<IOptionsConnector> _oConnectors)
        {
            _testBLConnector = _bConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.Test).FirstOrDefault();
            _testOConnector = _oConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.Test).FirstOrDefault();
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

            //Execute - Get available filter options from the server
            IGetJobFiltersResponse filtersResponse = _testOConnector.JobFilters<Test_GetJobFiltersRequest, Test_GetJobFiltersResponse>(new Test_GetJobFiltersRequest());

            //Execute - Try perform a dummy search
            ISearchJobsRequest request = new Test_SearchJobsRequest { Page = 0, PageSize = 2, FiltersSearch = new List<FiltersSearchRoot> { new FiltersSearchRoot { RootID = "AE-1234", Filters = new List<FiltersSearchElement> { new FiltersSearchElement { ID = "DD-3123" } } } } };
            ISearchJobsResponse response = _testBLConnector.SearchJobs(request);




            // This is the CSS classes enter from More Options
            ViewData["CssClass"] = this.CssClass;
        
            var jobSearchComponents = JsonSerializer.DeserializeFromString<List<JobSearchModel>>(this.SerializedJobSearchParams);
            if(jobSearchComponents != null)
            {
                foreach (JobSearchModel item in jobSearchComponents)
                {
                    FilterData(item.Data);
                    item.Data = item.Data.Where(d => d.Selected == true || d.Data?.Count > 0).ToList();
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
                if (item.Data != null && item.Data.Count > 0)
                {
                    FilterData(item.Data);
                    item.Data = item.Data.Where(d => d.Selected == true || d.Data?.Count > 0).ToList();
                }
            }

            data = data.Where(d => d.Selected == true || d.Data?.Count > 0).ToList();
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.Index().ExecuteResult(this.ControllerContext);
        }

        #region Private methods
        private SiteMapProvider GetSiteMapProvider()
        {
            SiteMapProvider provider;
            try
            {
                if (string.IsNullOrEmpty(this.SiteRootName))
                    provider = SiteMapBase.GetSiteMapProvider(SiteMapBase.DefaultSiteMapProviderName);
                else
                    provider = SiteMapBase.GetSiteMapProvider(this.SiteRootName);

                return provider;
            }
            catch (Exception)
            {
                provider = null;
            }
            return provider;
        }

        private string GetResultsUrl(string resultsPageId)
        {
            var resultsUrl = string.Empty;

            if (resultsPageId.IsGuid())
            {
                var provider = this.GetSiteMapProvider();
                if (provider != null)
                {
                    var node = provider.FindSiteMapNodeFromKey(resultsPageId);
                    if (node != null)
                    {
                        resultsUrl = node.Url;
                    }
                }
            }

            if (string.IsNullOrEmpty(resultsUrl))
            {
                var node = SiteMapBase.GetActualCurrentNode();
                if (node != null)
                    resultsUrl = node.Url;
            }

            // If ML is using different domains, the url does not need to be resolved
            if (!RouteHelper.IsCompleteUrl(resultsUrl))
            {
                return RouteHelper.ResolveUrl(resultsUrl, UrlResolveOptions.Rooted);
            }
            else
            {
                return resultsUrl;
            }
        }
        #endregion

        public string SerializedJobSearchParams { get; set; }
        internal const string WidgetIconCssClass = "sfMvcIcn";
        private JobSearchModel model;

        private string resultsUrl;
        public string SiteRootName { get; set; }
        public string ResultsUrl
        {
            get
            {
                if (String.IsNullOrEmpty(this.resultsUrl))
                {
                    this.resultsUrl = this.GetResultsUrl(this.ResultsPageId);
                }

                return this.resultsUrl;
            }
            set
            {
            }
        }
    }
}