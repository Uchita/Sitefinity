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

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "JobSearch_MVC", Title = "Job Search", SectionName = "Search", CssClass = JobSearchController.WidgetIconCssClass)]
    public class JobSearchController : Controller
    {
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
            // This is the CSS classes enter from More Options
            ViewData["CssClass"] = this.CssClass;
        
            var jobSearchComponents = JsonSerializer.DeserializeFromString<List<JobSearchModel>>(this.SerializedJobSearchParams);
            return View("Simple", jobSearchComponents);
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