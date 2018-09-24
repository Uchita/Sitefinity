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
using Telerik.Sitefinity.Security.Claims;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using System.Web;

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
            ViewBag.Status = TempData["StatusCode"];
            ViewBag.StatusMessage = TempData["StatusMessage"];
            
            return View("Simple", jobAlertData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            TempData["StatusMessage"] = null;
            TempData["StatusCode"] = JobAlertStatus.SUCCESS;
            dynamic dynamicFilterResponse = null;
            JXTNext_GetJobFiltersRequest request = new JXTNext_GetJobFiltersRequest();
            IGetJobFiltersResponse filtersResponse = _OConnector.JobFilters<JXTNext_GetJobFiltersRequest, JXTNext_GetJobFiltersResponse>(request);
            if (filtersResponse != null && filtersResponse.Filters != null
                && filtersResponse.Filters.Data != null)
                dynamicFilterResponse = filtersResponse.Filters.Data as dynamic;

            var isMembeUser = false;
            // Only Members can create the job alert
            if (SitefinityHelper.IsUserLoggedIn())
            {
                var currUser = SitefinityHelper.GetUserById(ClaimsManager.GetCurrentIdentity().UserId);
                if (currUser != null)
                    isMembeUser = SitefinityHelper.IsUserInRole(currUser, "Member");
            }

            ViewBag.IsMemberUser = isMembeUser;
           
            return View("Create", dynamicFilterResponse);
        }

        [HttpPost]
        public ActionResult Create(JobAlertViewModel model)
        {
            var response = GetUpsertResponse(model);
            var stausMessage = "A Job Alert has been created successfully.";
            var alertStatus = JobAlertStatus.SUCCESS;
            if (!response.Success)
            {
                stausMessage = response.Errors.First();
                alertStatus = JobAlertStatus.CREATE_FAILED;
            }

            TempData["StatusCode"] = alertStatus;
            TempData["StatusMessage"] = stausMessage;

            // Why action name is empty?
            // Here we need to call Index action, if we are providing action name as Index here
            // It is appending in the URL, but we dont want to show that in URL. So, sending it as empty
            // Will definity call defaut action i,.e Index
            return RedirectToAction("");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            TempData["StatusMessage"] = null;
            TempData["StatusCode"] = JobAlertStatus.SUCCESS;
            JobAlertViewModel jobAlertDetails = _jobAlertsBC.MemberJobAlertGet(id);
            JXTNext_GetJobFiltersRequest request = new JXTNext_GetJobFiltersRequest();
            IGetJobFiltersResponse filtersResponse = _OConnector.JobFilters<JXTNext_GetJobFiltersRequest, JXTNext_GetJobFiltersResponse>(request);

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
                                if (filterVMRootItem.Name == rootItem.RootId)
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
            editVM.Salary = jobAlertDetails.Salary;

            return View("Edit", editVM);
        }

        [HttpPost]
        public ActionResult Edit(JobAlertViewModel model)
        {
            var statusMessage = "A Job Alert has been updated successfully.";
            var alertStatus = JobAlertStatus.SUCCESS;
            var response = GetUpsertResponse(model, true);
            if (!response.Success)
            {
                statusMessage = response.Errors.First();
                alertStatus = JobAlertStatus.UPDATE_FAILED;
            }

            TempData["StatusMessage"] = statusMessage;
            TempData["StatusCode"] = alertStatus;

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
        public ActionResult Delete(int id)
        {
            // TODO: When the Backend API is ready,
            // We need to pass this job alert id to it
            var statusMessage = "A Job Alert has been deleted successfully.";
            var alertStatus = JobAlertStatus.SUCCESS;
            var response = _jobAlertsBC.MemberJobAlertDelete(id);
            if (!response.Success)
            {
                statusMessage = response.Errors.First();
                alertStatus = JobAlertStatus.DELETE_FAILED;
            }

            TempData["StatusMessage"] = statusMessage;
            TempData["StatusCode"] = alertStatus;
                       
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

        private IMemberUpsertJobAlertResponse GetUpsertResponse(JobAlertViewModel model, bool update = false)
        {
            JobAlertSalaryFilterReceiver salary = null;
            if (!model.SalaryStringify.IsNullOrEmpty())
            {
                salary = JsonConvert.DeserializeObject<JobAlertSalaryFilterReceiver>(model.SalaryStringify);
            }

            if (salary != null)
                model.Salary = salary;

            var epochTime = ConversionHelper.GetUnixTimestamp(SitefinityHelper.GetSitefinityApplicationTime(), true);
            model.LastModifiedTime = (long)epochTime;

            // Remove null value filters
            List<JobAlertFilters> Filters = new List<JobAlertFilters>();
            if (model != null && model.Filters != null && model.Filters.Count > 0)
            {
                foreach (var item in model.Filters)
                {
                    if (item.Values != null && item.Values.Count > 0)
                        Filters.Add(item);
                }
            }

            model.Filters = Filters;

            var response = _jobAlertsBC.MemberJobAlertUpsert(model, update);

            return response;
        }

        static string ToQueryString(JobAlertViewModel jobAlertDetails)
        {
            List<string> queryParamsStringList = new List<string>();
            // Encode the URL string
            // Why replacing single quote with %27?
            // To be inconsistent with JavaScript encodeURIComponent in the front end.
            string encodeKeywords = jobAlertDetails.Keywords;
            if (!encodeKeywords.IsNullOrEmpty())
                encodeKeywords = Uri.EscapeDataString(jobAlertDetails.Keywords).Replace("'", "%27");

            queryParamsStringList.Add("Keywords=" + encodeKeywords);
                       
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

            if(jobAlertDetails.Salary != null && !jobAlertDetails.Salary.TargetValue.IsNullOrEmpty())
            {
                queryParamsStringList.Add("Salary.TargetValue=" + jobAlertDetails.Salary.TargetValue);
                queryParamsStringList.Add("Salary.LowerRange=" + jobAlertDetails.Salary.LowerRange);
                queryParamsStringList.Add("Salary.UpperRange=" + jobAlertDetails.Salary.UpperRange);
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