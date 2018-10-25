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

            if (item.DoesFieldExist("Email"))
            {
                var email = item.GetString("Email");
              
                JobSearchResultsFilterModel filterModelNew = new JobSearchResultsFilterModel() { ConsultantSearch = new Consultant() { Email = email } };

                if (!this.PageSize.HasValue || this.PageSize.Value <= 0)
                    this.PageSize = PageSizeDefaultValue;

                JXTNext_SearchJobsRequest request = JobSearchResultsFilterModel.ProcessInputToSearchRequest(filterModelNew, this.PageSize, PageSizeDefaultValue);

                string sortingBy = this.Sorting;
                if (filterModelNew != null && !filterModelNew.SortBy.IsNullOrEmpty())
                    sortingBy = filterModelNew.SortBy;

                request.SortBy = JobSearchResultsFilterModel.GetSortEnumFromString(sortingBy);
                ViewBag.SortOrder = JobSearchResultsFilterModel.GetSortStringFromEnum(request.SortBy);

                ISearchJobsResponse response = _BLConnector.SearchJobs(request);
                JXTNext_SearchJobsResponse jobResultsList = response as JXTNext_SearchJobsResponse;
                dynamicJobResultsList = jobResultsList as dynamic;
            }


            if (item.DoesFieldExist("ConsultantName"))
                ViewBag.ConsultantName = item.GetString("ConsultantName");
           
            ViewBag.PageSize = (int)this.PageSize;
            ViewBag.CssClass = this.CssClass;
            ViewBag.JobResultsPageUrl = SitefinityHelper.GetPageUrl(this.ResultsPageId);
            ViewBag.CurrentPageUrl = SitefinityHelper.GetPageUrl(SiteMapBase.GetActualCurrentNode().Id.ToString());
            ViewBag.JobDetailsPageUrl = SitefinityHelper.GetPageUrl(this.DetailsPageId);

            return this.View(this.templateNamePrefix + this.TemplateName, dynamicJobResultsList);
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