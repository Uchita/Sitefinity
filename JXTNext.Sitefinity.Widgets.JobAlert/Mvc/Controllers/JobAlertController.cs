using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.Options;
using JXTNext.Sitefinity.Connector.Options.Models.Job;
using JXTNext.Sitefinity.Common.Helpers;
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
using System.Dynamic;
using JXTNext.Sitefinity.Services.Intefaces;
using JXTNext.Sitefinity.Services.Intefaces.Models.JobAlert;
using JXTNext.Sitefinity.Widgets.JobAlert.Mvc.Utility;
using JXTNext.Sitefinity.Services.Intefaces.Models.JobAlertJson;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.Utilities.TypeConverters;
using Telerik.Sitefinity.Model;
using JXTNext.Common.Communications.Helpers.Utility;
using Telerik.Sitefinity.Web.Mail;
using System.Net.Mail;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Common;
using JXTNext.Sitefinity.Widgets.JobAlert.Mvc.StringResources;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Controllers
{
    [EnhanceViewEngines]
    [Localization(typeof(JobAlertResources))]
    [ControllerToolboxItem(Name = "JobAlert_MVC", Title = "Job Alert", SectionName = "JXTNext.JobAlert", CssClass = JobAlertController.WidgetIconCssClass)]
    public class JobAlertController : Controller
    {
        IOptionsConnector _OConnector;
        IJobAlertService _jobAlertService;
        private Utils _utils = null;

        public JobAlertController(IEnumerable<IOptionsConnector> _oConnectors, IJobAlertService jobAlertService)
        {
            _utils = new Utils();
            _jobAlertService = jobAlertService;
            _OConnector = _oConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
        }

        // GET: JobAlert
        public ActionResult Index()
        {
            List<JobAlertViewModel> jobAlertData = _jobAlertService.MemberJobAlertsGet();

            ViewBag.CssClass = this.CssClass;
            ViewBag.Status = TempData["StatusCode"];
            ViewBag.StatusMessage = TempData["StatusMessage"];
            ViewBag.IsMemberUser = SitefinityHelper.IsUserLoggedIn("Member");

            return View("Simple", jobAlertData);
        }

        [HttpGet]
        public ActionResult Create(CreateAsJobAlertFilterModel filterModel)
        {
            TempData["StatusMessage"] = null;
            TempData["StatusCode"] = JobAlertStatus.SUCCESS;
            dynamic dynamicFilterResponse = new ExpandoObject();
            JXTNext_GetJobFiltersRequest request = new JXTNext_GetJobFiltersRequest();
            IGetJobFiltersResponse filtersResponse = _OConnector.JobFilters<JXTNext_GetJobFiltersRequest, JXTNext_GetJobFiltersResponse>(request);
            //if (filtersResponse != null && filtersResponse.Filters != null
            //    && filtersResponse.Filters.Data != null)
            //    dynamicFilterResponse = filtersResponse.Filters.Data as dynamic;


            List<JobFilterRoot> fitersData = null;
            if (filtersResponse != null && filtersResponse.Filters != null
                && filtersResponse.Filters.Data != null)
                fitersData = filtersResponse.Filters.Data;

            var serializeFilterData = JsonConvert.SerializeObject(fitersData);
            var filtersVMList = JsonConvert.DeserializeObject<List<JobAlertEditFilterRootItem>>(serializeFilterData);

            if (filterModel.Filters != null && filterModel.Filters.Count > 0)
            {
                foreach (var rootItem in filterModel.Filters)
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
                                            // Here we are coming the ids as parent child relationship and we need
                                            // Only the current id, so remove underscore and get the exact id
                                            RemoveUnderScore(rootItem.Values);
                                            MergeFilters(filterItem, rootItem.Values);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            dynamicFilterResponse.Filters = filtersVMList as dynamic;
            ViewBag.IsMemberUser = SitefinityHelper.IsUserLoggedIn("Member");
            dynamicFilterResponse.Keywords = filterModel.Keywords;
            dynamicFilterResponse.Salary = filterModel.Salary;


            return View("Create", dynamicFilterResponse);
        }



        [HttpPost]
        public ActionResult Create(JobAlertViewModel model)
        {
            List<JobAlertEditFilterRootItem> filtersVMList = GetJobFilterData();
            if (model.SalaryStringify != null)
            {
                model.Salary = JsonConvert.DeserializeObject<JobAlertSalaryFilterReceiver>(model.SalaryStringify);
            }

            if (String.IsNullOrEmpty(model.Email))
                model.Email = SitefinityHelper.GetLoggedInUserEmail();

            model.Data = JobAlertUtility.ConvertJobAlertViewModelToSearchModel(model, filtersVMList);
            // Create Email Notification
            EmailNotificationSettings jobAlertEmailNotificationSettings = null;
            if (this.JobAlertEmailTemplateId != null)
            {
                jobAlertEmailNotificationSettings = new EmailNotificationSettings(new EmailTarget(this.JobAlertEmailTemplateSenderName, this.JobAlertEmailTemplateSenderEmailAddress),
                                                                                                new EmailTarget(string.Empty, model.Email),
                                                                                                SitefinityHelper.GetCurrentSiteEmailTemplateTitle(this.JobAlertEmailTemplateId),
                                                                                                SitefinityHelper.GetCurrentSiteEmailTemplateHtmlContent(this.JobAlertEmailTemplateId), null);
                if (!this.JobAlertEmailTemplateCC.IsNullOrEmpty())
                {
                    foreach (var ccEmail in this.JobAlertEmailTemplateCC.Split(';'))
                    {
                        jobAlertEmailNotificationSettings?.AddCC(String.Empty, ccEmail);
                    }
                }

                if (!this.JobAlertEmailTemplateBCC.IsNullOrEmpty())
                {
                    foreach (var bccEmail in this.JobAlertEmailTemplateBCC.Split(';'))
                    {
                        jobAlertEmailNotificationSettings?.AddBCC(String.Empty, bccEmail);
                    }
                }
            }


            model.EmailNotifications = jobAlertEmailNotificationSettings;
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
            SearchModel jobAlertDetails = _jobAlertService.GetMemeberJobAlert(id);
            var alert = jobAlertDetails.jobAlertViewModelData;
            JXTNext_GetJobFiltersRequest request = new JXTNext_GetJobFiltersRequest();
            IGetJobFiltersResponse filtersResponse = _OConnector.JobFilters<JXTNext_GetJobFiltersRequest, JXTNext_GetJobFiltersResponse>(request);

            List<JobFilterRoot> fitersData = null;
            if (filtersResponse != null && filtersResponse.Filters != null
                && filtersResponse.Filters.Data != null)
                fitersData = filtersResponse.Filters.Data;

            var serializeFilterData = JsonConvert.SerializeObject(fitersData);
            var filtersVMList = JsonConvert.DeserializeObject<List<JobAlertEditFilterRootItem>>(serializeFilterData);

            if (alert != null && alert.Filters != null && alert.Filters.Count > 0)
            {
                foreach (var rootItem in alert.Filters)
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
            editVM.Id = id;
            editVM.Name = alert.Name;
            editVM.Keywords = alert.Keywords;
            editVM.EmailAlerts = alert.EmailAlerts;
            editVM.Salary = alert.Salary;

            return View("Edit", editVM);
        }

        [HttpPost]
        public ActionResult Edit(JobAlertViewModel model)
        {
            var statusMessage = "A Job Alert has been updated successfully.";
            var alertStatus = JobAlertStatus.SUCCESS;
            List<JobAlertEditFilterRootItem> filtersVMList = GetJobFilterData();
            model.Data = JobAlertUtility.ConvertJobAlertViewModelToSearchModel(model, filtersVMList);
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
            JobAlertViewModel jobAlertDetails = _jobAlertService.GetMemeberJobAlert(id).jobAlertViewModelData;
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
            var response = _jobAlertService.MemberJobAlertDelete(id);
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

        [HttpGet]
        public ActionResult Unsubscribe(Guid AlertId)
        {
            var response = _jobAlertService.UnsubscribeJobAlert(AlertId);

            return View("Unsubscribe", response);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }



        private List<JobAlertEditFilterRootItem> GetJobFilterData()
        {
            JXTNext_GetJobFiltersRequest request = new JXTNext_GetJobFiltersRequest();
            IGetJobFiltersResponse filtersResponse = _OConnector.JobFilters<JXTNext_GetJobFiltersRequest, JXTNext_GetJobFiltersResponse>(request);

            List<JobFilterRoot> fitersData = null;
            if (filtersResponse != null && filtersResponse.Filters != null
                && filtersResponse.Filters.Data != null)
                fitersData = filtersResponse.Filters.Data;

            var serializeFilterData = JsonConvert.SerializeObject(fitersData);
            var filtersVMList = JsonConvert.DeserializeObject<List<JobAlertEditFilterRootItem>>(serializeFilterData);

            return filtersVMList;
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

            if (model != null && model.Email.IsNullOrEmpty())
                model.Email = SitefinityHelper.GetLoggedInUserEmail();

            var response = _jobAlertService.MemberJobAlertUpsert(model, update);

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
                    if (item.Values != null)
                    {
                        foreach (var filterId in item.Values)
                        {
                            queryParamsStringList.Add("Filters[" + i + "].values=" + filterId);
                        }
                    }
                }
            }

            if (jobAlertDetails.Salary != null && !jobAlertDetails.Salary.TargetValue.IsNullOrEmpty())
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



        private static void RemoveUnderScore(List<string> values)
        {
            if (values != null && values.Count > 0)
            {
                for (int i = 0; i < values.Count; i++)
                {
                    // Parent and child ids are seprated by underscore
                    if (values[i].Contains("_"))
                        values[i] = values[i].Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries).ToList().LastOrDefault();
                }
            }
        }

        internal const string WidgetIconCssClass = "sfMvcIcn";

        public string ItemType
        {
            get { return this._itemType; }
            set { this._itemType = value; }
        }

        public string JobAlertEmailTemplateProviderName
        {
            get { return SitefinityHelper.GetCurrentSiteEmailTemplateProviderName(); }
        }
        public string JobAlertEmailTemplateId { get; set; }
        public string JobAlertEmailTemplateName { get; set; }
        public string JobAlertEmailTemplateCC { get; set; }
        public string JobAlertEmailTemplateBCC { get; set; }
        public string JobAlertEmailTemplateSenderName { get; set; }
        public string JobAlertEmailTemplateSenderEmailAddress { get; set; }
        public string JobAlertEmailTemplateEmailSubject { get; set; }


        public string CssClass { get; set; }
        public string ResultsPageId { get; set; }
        private string _emailTemplateProviderName = "OpenAccessProvider";
        private string _itemType = "Telerik.Sitefinity.DynamicTypes.Model.StandardEmailTemplate.EmailTemplate";

    }
}