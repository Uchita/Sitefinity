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
        public ActionResult Index([ModelBinder(typeof(JobSearchResultsFilterBinder))] JobSearchResultsFilterModel filterModel)
        {
            dynamic dynamicFilterResponse = null;
            JXTNext_GetJobFiltersRequest request = new JXTNext_GetJobFiltersRequest();
            IGetJobFiltersResponse filtersResponse = _OConnector.JobFilters<JXTNext_GetJobFiltersRequest, JXTNext_GetJobFiltersResponse>(request);

            List<JobFilterRoot> filtersVMList = null;
            if (filtersResponse != null && filtersResponse.Filters != null
                && filtersResponse.Filters.Data != null)
            {
                filtersVMList = filtersResponse.Filters.Data;
                dynamicFilterResponse = filtersResponse.Filters.Data as dynamic;
            }

            var filtersSelected = filterModel.Filters;

            if(filtersSelected != null && filtersSelected.Count > 0)
                ProcessFilters(filtersSelected, filtersVMList);
     
            ViewBag.FilterModel = JsonConvert.SerializeObject(filterModel);
            ViewBag.Keywords = filterModel.Keywords;
    
            dynamicFilterResponse = filtersVMList as dynamic;

            return View(this.TemplateName, dynamicFilterResponse);
        }

        static void ProcessFilters(List<JobSearchFilterReceiver> selectedFilters, List<JobFilterRoot> filtersVMList)
        {
            if (selectedFilters != null && selectedFilters.Count > 0)
            {
                foreach (var rootItem in selectedFilters)
                {
                    if (rootItem != null)
                    {
                        if (filtersVMList != null && filtersVMList.Count > 0)
                        {
                            foreach (var filterVMRootItem in filtersVMList)
                            {
                                if (filterVMRootItem.Name == rootItem.rootId)
                                {
                                    if (filterVMRootItem.Filters != null && filterVMRootItem.Filters.Count > 0)
                                    {
                                        foreach (var filterItem in filterVMRootItem.Filters)
                                        {
                                            MergeFilters(filterItem, rootItem.values);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        static bool CheckSubTragets(JobSearchFilterReceiverItem filterRecItem, string Id)
        {
            if(filterRecItem != null)
            {
                if(filterRecItem.ItemID.Equals(Id, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else
                {
                    if(filterRecItem.SubTargets != null && filterRecItem.SubTargets.Count > 0)
                    {
                        foreach(var item in filterRecItem.SubTargets)
                        {
                            if (CheckSubTragets(item, Id))
                                return true;
                        }
                    }
                }
            }

            return false;
        }

        static void MergeFilters(JobFilter filterItem, List<JobSearchFilterReceiverItem> values)
        {
            if(filterItem != null)
            {
                if (values != null && values.Count > 0)
                {
                    foreach(var item in values)
                    {
                        if(item.ItemID.Equals(filterItem.ID, StringComparison.OrdinalIgnoreCase))
                        {
                            filterItem.Selected = true;
                            break;
                        }

                        if(item.SubTargets != null && item.SubTargets.Count > 0)
                        {
                            foreach(var subItem in item.SubTargets)
                            {
                                if(CheckSubTragets(item, filterItem.ID))
                                {
                                    filterItem.Selected = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (filterItem.Filters != null && filterItem.Filters.Count > 0)
                    {
                        foreach (var item in filterItem.Filters)
                        {
                            MergeFilters(item, values);
                        }
                    }
                }
            }
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }

        internal const string WidgetIconCssClass = "sfMvcIcn";
    }
}