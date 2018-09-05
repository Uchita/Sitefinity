using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.Options;
using JXTNext.Sitefinity.Connector.Options.Models.Job;
using JXTNext.Sitefinity.Common.Helpers;
using JXTNext.Sitefinity.Widgets.JobAlert.Mvc.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using JXTNext.Sitefinity.Widgets.JobAlert.Mvc.Logics;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Controllers
{
    [EnhanceViewEngines]
    [ControllerToolboxItem(Name = "JobAlert_MVC", Title = "Job Alert", SectionName = "JXTNext.JobAlert", CssClass = JobAlertController.WidgetIconCssClass)]
    public class JobAlertController : Controller
    {
        JobAlertsBC _jobAlertsBC;
        IOptionsConnector _OConnector;
       
        public JobAlertController(IEnumerable<IOptionsConnector> _oConnectors, JobAlertsBC jobAlertsBC)
        {
            _jobAlertsBC = jobAlertsBC;
            _OConnector = _oConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
        }

        // GET: JobAlert
        public ActionResult Index()
        {
            List<JobAlertViewModel> jobAlertData = _jobAlertsBC.MemberJobAlertsGet();

            ViewBag.CssClass = this.CssClass;
            ViewBag.CreateMessage = TempData["CreateMessage"];
            ViewBag.DeleteMessage = TempData["DeleteMessage"];

            return View("Simple", jobAlertData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            dynamic dynamicFilterResponse = null;
            IGetJobFiltersResponse filtersResponse = _OConnector.JobFilters<Test_GetJobFiltersRequest, Test_GetJobFiltersResponse>(new Test_GetJobFiltersRequest());
            if (filtersResponse != null && filtersResponse.Filters != null
                && filtersResponse.Filters.Data != null)
                dynamicFilterResponse = filtersResponse.Filters.Data as dynamic;

             return View("Create", dynamicFilterResponse);
        }

        [HttpPost]
        public ActionResult Create(JobAlertViewModel model)
        {
            // TODO: When the Backend API is ready,
            // We need to pass this model to it
            
            var epochTime = ConversionHelper.GetUnixTimestamp(SitefinityHelper.GetSitefinityApplicationTime(), true);

            TempData["DeleteMessage"] = null;
            TempData["CreateMessage"] = "A Job Alert has been created successfully.";

            // Why action name is empty?
            // Here we need to call Index action, if we are providing action name as Index here
            // It is appending in the URL, but we dont want to show that in URL. So, sending it as empty
            // Will definity call defaut action i,.e Index
            return RedirectToAction("");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            JobAlertViewModel jobAlertDetails = _jobAlertsBC.MemberJobAlertGet(id);
            IGetJobFiltersResponse filtersResponse = _OConnector.JobFilters<Test_GetJobFiltersRequest, Test_GetJobFiltersResponse>(new Test_GetJobFiltersRequest());

            List<JobFilterRoot> fitersData = null;
            if (filtersResponse != null && filtersResponse.Filters != null
                && filtersResponse.Filters.Data != null)
                fitersData = filtersResponse.Filters.Data;

            var serializeFilterData = JsonConvert.SerializeObject(fitersData);
            var filtersVMList = JsonConvert.DeserializeObject<List<JobAlertEditFilterRootItem>>(serializeFilterData);

            if (jobAlertDetails.Filters != null && jobAlertDetails.Filters.Count > 0)
            {
                foreach (var rootItem in jobAlertDetails.Filters)
                {
                    if (rootItem != null)
                    {
                        if (filtersVMList != null && filtersVMList.Count > 0)
                        {
                            foreach (var filterVMRootItem in filtersVMList)
                            {
                                if (filterVMRootItem.ID == rootItem.RootId)
                                {
                                    if (filterVMRootItem.Filters != null && filterVMRootItem.Filters.Count > 0)
                                    {
                                        foreach (var filterItem in filterVMRootItem.Filters)
                                        {
                                            MergeFilters(filterItem, rootItem.Values);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            JobAlertEditViewModel editVM = new JobAlertEditViewModel() { Data = filtersVMList };
            editVM.Id = jobAlertDetails.Id;
            editVM.Name = jobAlertDetails.Name;
            editVM.Keywords = jobAlertDetails.Keywords;
            editVM.EmailAlerts = jobAlertDetails.EmailAlerts;

            return View("Edit", editVM);
        }

        [HttpPost]
        public ActionResult Edit(JobAlertViewModel model)
        {
            // TODO: When the Backend API is ready,
            // We need to pass this model to it

            // Why action name is empty?
            // Here we need to call Index action, if we are providing action name as Index here
            // It is appending in the URL, but we dont want to show that in URL. So, sending it as empty
            // Will definity call defaut action i,.e Index
            return RedirectToAction("");
        }

        [HttpGet]
        public ActionResult ViewResults(int id)
        {
            JobAlertViewModel jobAlertDetails = _jobAlertsBC.MemberJobAlertGet(id);
            string resultsPageUrl = SitefinityHelper.GetPageUrl(this.ResultsPageId);

            return Redirect(resultsPageUrl + "?" + ToQueryString(jobAlertDetails));
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            // TODO: When the Backend API is ready,
            // We need to pass this job alert id to it

            TempData["CreateMessage"] = null;
            TempData["DeleteMessage"] = "A Job Alert has been deleted successfully.";
            
            // Why action name is empty?
            // Here we need to call Index action, if we are providing action name as Index here
            // It is appending in the URL, but we dont want to show that in URL. So, sending it as empty
            // Will definity call defaut action i,.e Index
            return RedirectToAction("");
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }

        static string ToQueryString(JobAlertViewModel jobAlertDetails)
        {
            List<string> queryParamsStringList = new List<string>();
            queryParamsStringList.Add("Keywords=" + jobAlertDetails.Keywords);
                       
            if (jobAlertDetails.Filters != null)
            {
                for (int i = 0; i < jobAlertDetails.Filters.Count; i++)
                {
                    var item = jobAlertDetails.Filters[i];
                    queryParamsStringList.Add("Filters[" + i + "].rootId=" + item.RootId);
                    foreach (var filterId in item.Values)
                    {
                        queryParamsStringList.Add("Filters[" + i + "].values=" + filterId);
                    }
                }
            }

           return String.Join("&", queryParamsStringList);
        }

        static void MergeFilters(JobAlertEditFilterItem filterItem, List<string> values)
        {
            if (filterItem != null)
            {
                if (values != null && values.Count > 0)
                {
                    if (values.Contains(filterItem.ID))
                    {
                        filterItem.Selected = true;
                        values.Remove(filterItem.ID);
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

        internal const string WidgetIconCssClass = "sfMvcIcn";
        public string CssClass { get; set; }
        public string ResultsPageId { get; set; }
    }
}