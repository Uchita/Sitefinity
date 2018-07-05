using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using JXTNext.Sitefinity.Widgets.Job.Mvc.Models;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.Options;
using System.Dynamic;
using JXTNext.Sitefinity.Connector.Options.Models.Job;
using Newtonsoft.Json;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Controllers
{
    [EnhanceViewEngines]
    [ControllerToolboxItem(Name = "JobFilters_MVC", Title = "Filters Listing", SectionName = "JXTNext.Job", CssClass = JobFiltersController.WidgetIconCssClass)]
    public class JobFiltersController : Controller
    {
        /// <summary>
        /// Gets or sets the name of the template that widget will be displayed.
        /// </summary>
        /// <value></value>
        private string _templateName;
        public string TemplateName
        {
            get {
                if (string.IsNullOrEmpty(_templateName))
                    _templateName = "T_Simple";
                return _templateName;
            }
            set { _templateName = value; }
        }

        IBusinessLogicsConnector _BLConnector;
        IOptionsConnector _OConnector;

        public JobFiltersController(IEnumerable<IBusinessLogicsConnector> _bConnectors, IEnumerable<IOptionsConnector> _oConnectors)
        {
            _BLConnector = _bConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
            _OConnector = _oConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
        }

        // GET: JobFilters
        public ActionResult Index(JobSearchResultsFilterModel filterModel)
        {
            dynamic dynamicFilterResponse = null;
            JXTNext_GetJobFiltersRequest request = new JXTNext_GetJobFiltersRequest();
            IGetJobFiltersResponse filtersResponse = _OConnector.JobFilters<JXTNext_GetJobFiltersRequest, JXTNext_GetJobFiltersResponse>(request);
            if (filtersResponse != null && filtersResponse.Filters != null
                && filtersResponse.Filters.Data != null)
                dynamicFilterResponse = filtersResponse.Filters.Data as dynamic;

            ViewBag.FilterModel = JsonConvert.SerializeObject(filterModel);

            return View(this.TemplateName, dynamicFilterResponse);
        }

        internal const string WidgetIconCssClass = "sfMvcIcn";
    }
}