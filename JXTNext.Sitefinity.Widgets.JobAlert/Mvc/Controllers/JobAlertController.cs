namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Controllers
{
    using JXTNext.Common.Communications.Helpers.Utility;
    using JXTNext.Sitefinity.Common.Helpers;
    using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Common;
    using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
    using JXTNext.Sitefinity.Connector.Options;
    using JXTNext.Sitefinity.Connector.Options.Models.Job;
    using JXTNext.Sitefinity.Services.Intefaces;
    using JXTNext.Sitefinity.Services.Intefaces.Models.JobAlert;
    using JXTNext.Sitefinity.Services.Intefaces.Models.JobAlertJson;
    using JXTNext.Sitefinity.Widgets.JobAlert.Mvc.Utility;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Web.Mvc;
    using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
    using Telerik.Sitefinity.Mvc;
    using Telerik.Sitefinity.Taxonomies.Model;

    /// <summary>
    /// Defines the <see cref="JobAlertController" />
    /// </summary>
    [EnhanceViewEngines]
    [ControllerToolboxItem(Name = "JobAlert_MVC", Title = "Job Alert", SectionName = "JXTNext.JobAlert", CssClass = JobAlertController.WidgetIconCssClass)]
    public class JobAlertController : Controller
    {
        /// <summary>
        /// Defines the _OConnector
        /// </summary>
        internal IOptionsConnector _OConnector;

        /// <summary>
        /// Defines the _jobAlertService
        /// </summary>
        internal IJobAlertService _jobAlertService;

        /// <summary>
        /// Defines the _utils
        /// </summary>
        private Utils _utils = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobAlertController"/> class.
        /// </summary>
        /// <param name="_oConnectors">The _oConnectors<see cref="IEnumerable{IOptionsConnector}"/></param>
        /// <param name="jobAlertService">The jobAlertService<see cref="IJobAlertService"/></param>
        public JobAlertController(IEnumerable<IOptionsConnector> _oConnectors, IJobAlertService jobAlertService)
        {
            _utils = new Utils();
            _jobAlertService = jobAlertService;
            _OConnector = _oConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
        }

        // GET: JobAlert
        /// <summary>
        /// The Index
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Index()
        {
            List<JobAlertViewModel> jobAlertData = _jobAlertService.MemberJobAlertsGet();

            ViewBag.CssClass = this.CssClass;
            ViewBag.Status = TempData["StatusCode"];
            ViewBag.StatusMessage = TempData["StatusMessage"];
            ViewBag.IsMemberUser = SitefinityHelper.IsUserLoggedIn("Member");
            if (Telerik.Sitefinity.Services.SystemManager.IsDesignMode || Telerik.Sitefinity.Services.SystemManager.IsPreviewMode)
            {
                return View("Simple", jobAlertData);
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Create()
        {
            TempData["StatusMessage"] = null;
            TempData["StatusCode"] = JobAlertStatus.SUCCESS;
            dynamic dynamicFilterResponse = new ExpandoObject();
            CreateAsJobAlertFilterModel filterModel = new CreateAsJobAlertFilterModel();

            List<JobFilterRoot> fitersData = null;
            JobFiltersData ClassificationfiltersData = GetFiltersData();
            fitersData = ClassificationfiltersData.Data;
            var serializeFilterData = JsonConvert.SerializeObject(fitersData);
            var filtersVMList = JsonConvert.DeserializeObject<List<JobAlertEditFilterRootItem>>(serializeFilterData);


            dynamicFilterResponse.Filters = filtersVMList as dynamic;
            ViewBag.IsMemberUser = SitefinityHelper.IsUserLoggedIn("Member");
            dynamicFilterResponse.Keywords = filterModel.Keywords;
            dynamicFilterResponse.Salary = filterModel.Salary;

            return View("Create", dynamicFilterResponse);
        }

        /// <summary>
        /// The ThankYou
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpGet]
        public ActionResult ThankYou()
        {
            return View("ThankYou");
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="model">The model<see cref="JobAlertViewModel"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpPost]
        public ActionResult Create(JobAlertViewModel model)
        {
            List<JobFilterRoot> fitersData = null;
            JobFiltersData ClassificationfiltersData = GetFiltersData();
            fitersData = ClassificationfiltersData.Data;
            var serializeFilterData = JsonConvert.SerializeObject(fitersData);
            var filtersVMList = JsonConvert.DeserializeObject<List<JobAlertEditFilterRootItem>>(serializeFilterData);


            if (model.SalaryStringify != null)
            {
                model.Salary = JsonConvert.DeserializeObject<JobAlertSalaryFilterReceiver>(model.SalaryStringify);
            }

            if (String.IsNullOrEmpty(model.Email))
                model.Email = SitefinityHelper.GetLoggedInUserEmail();

            model.Data = JobAlertUtility.ConvertJobAlertViewModelToSearchModel(model, filtersVMList);
            // Create Email Notification
            EmailNotificationSettings jobAlertEmailNotificationSettings = new EmailNotificationSettings(new EmailTarget(this.JobAlertEmailTemplateSenderName, this.JobAlertEmailTemplateSenderEmailAddress),
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
            // It is appending in the URL, but we don't want to show that in URL. So, sending it as empty
            // Will definitely call default action i,.e Index
            return View("ThankYou");
        }

        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            TempData["StatusMessage"] = null;
            TempData["StatusCode"] = JobAlertStatus.SUCCESS;
            SearchModel jobAlertDetails = _jobAlertService.GetMemeberJobAlert(id);
            var alert = jobAlertDetails.jobAlertViewModelData;

            List<JobFilterRoot> fitersData = null;
            JobFiltersData ClassificationfiltersData = GetFiltersData();
            fitersData = ClassificationfiltersData.Data;
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

        /// <summary>
        /// The GetFiltersData
        /// </summary>
        /// <returns>The <see cref="JobFiltersData"/></returns>
        public static JobFiltersData GetFiltersData()
        {
            JobFiltersData filtersData = new JobFiltersData() { Data = new List<JobFilterRoot>() };
            var topLovelCategories = SitefinityHelper.GetTopLevelCategories();

            foreach (var taxon in topLovelCategories)
            {
                if (taxon.Title.ToUpper() == "CLASSIFICATIONS" || taxon.Title.ToUpper() == "WORKTYPE" || taxon.Title.ToUpper() == "COUNTRYLOCATIONAREA" || taxon.Title.ToUpper() == "SALARY TYPE")
                {
                    JobFilterRoot filterRoot = new JobFilterRoot() { Filters = new List<JobFilter>() };
                    filterRoot.ID = taxon.Id.ToString().ToUpper();
                    filterRoot.Name = taxon.Title.ToString().Replace(" ", "_");

                    var hierarchicalTaxon = taxon as HierarchicalTaxon;
                    if (hierarchicalTaxon != null)
                    {
                        foreach (var childTaxon in hierarchicalTaxon.Subtaxa)
                        {
                            int levelcounter = 1;
                            var jobFilter = new JobFilter() { Filters = new List<JobFilter>() };
                            jobFilter = ProcessCategories(childTaxon, jobFilter, levelcounter);
                            filterRoot.Filters.Add(jobFilter);
                        }
                    }

                    filtersData.Data.Add(filterRoot);
                }
            }

            return filtersData;
        }

        /// <summary>
        /// The ProcessCategories
        /// </summary>
        /// <param name="category">The category<see cref="HierarchicalTaxon"/></param>
        /// <param name="jobFilter">The jobFilter<see cref="JobFilter"/></param>
        /// <param name="levelcounter">The levelcounter<see cref="int"/></param>
        /// <returns>The <see cref="JobFilter"/></returns>
        public static JobFilter ProcessCategories(HierarchicalTaxon category, JobFilter jobFilter, int levelcounter)
        {

            if (category != null && jobFilter != null)
            {
                jobFilter.ID = category.Id.ToString().ToUpper();
                jobFilter.Label = category.Title;

                if (category.Subtaxa != null && category.Subtaxa.Count > 0)
                {
                    foreach (var subTaxon in category.Subtaxa)
                    {

                        var subFilter = new JobFilter() { Filters = new List<JobFilter>() };
                        // subFilter = ProcessCategories(subTaxon, subFilter, levelcounter);
                        subFilter = ProcessCategoriesNextLevel(subTaxon, subFilter);
                        jobFilter.Filters.Add(subFilter);

                    }
                }
            }

            return jobFilter;
        }

        /// <summary>
        /// The ProcessCategoriesNextLevel
        /// </summary>
        /// <param name="category">The category<see cref="HierarchicalTaxon"/></param>
        /// <param name="jobFilter">The jobFilter<see cref="JobFilter"/></param>
        /// <returns>The <see cref="JobFilter"/></returns>
        public static JobFilter ProcessCategoriesNextLevel(HierarchicalTaxon category, JobFilter jobFilter)
        {

            if (category != null && jobFilter != null)
            {
                jobFilter.ID = category.Id.ToString().ToUpper();
                jobFilter.Label = category.Title;

            }

            return jobFilter;
        }

        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="model">The model<see cref="JobAlertViewModel"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
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
            // It is appending in the URL, but we don't want to show that in URL. So, sending it as empty
            // Will definitely call default action i,.e Index

            return RedirectToAction("");
        }

        /// <summary>
        /// The ViewResults
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpGet]
        public ActionResult ViewResults(int id)
        {
            JobAlertViewModel jobAlertDetails = _jobAlertService.GetMemeberJobAlert(id).jobAlertViewModelData;
            string resultsPageUrl = SitefinityHelper.GetPageUrl(this.ResultsPageId);

            return Redirect(resultsPageUrl + "?" + ToQueryString(jobAlertDetails));
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
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
            // It is appending in the URL, but we don't want to show that in URL. So, sending it as empty
            // Will definitely call default action i,.e Index
            return RedirectToAction("");
        }

        /// <summary>
        /// The Unsubscribe
        /// </summary>
        /// <param name="AlertId">The AlertId<see cref="Guid"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpGet]
        public ActionResult Unsubscribe(Guid AlertId)
        {
            var response = _jobAlertService.UnsubscribeJobAlert(AlertId);

            return View("Unsubscribe", response);
        }

        /// <summary>
        /// The HandleUnknownAction
        /// </summary>
        /// <param name="actionName">The actionName<see cref="string"/></param>
        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }

        /// <summary>
        /// The GetJobFilterData
        /// </summary>
        /// <returns>The <see cref="List{JobAlertEditFilterRootItem}"/></returns>
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

        /// <summary>
        /// The GetUpsertResponse
        /// </summary>
        /// <param name="model">The model<see cref="JobAlertViewModel"/></param>
        /// <param name="update">The update<see cref="bool"/></param>
        /// <returns>The <see cref="IMemberUpsertJobAlertResponse"/></returns>
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

        /// <summary>
        /// The ToQueryString
        /// </summary>
        /// <param name="jobAlertDetails">The jobAlertDetails<see cref="JobAlertViewModel"/></param>
        /// <returns>The <see cref="string"/></returns>
        internal static string ToQueryString(JobAlertViewModel jobAlertDetails)
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

        /// <summary>
        /// The MergeFilters
        /// </summary>
        /// <param name="filterItem">The filterItem<see cref="JobAlertEditFilterItem"/></param>
        /// <param name="values">The values<see cref="List{string}"/></param>
        internal static void MergeFilters(JobAlertEditFilterItem filterItem, List<string> values)
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

        /// <summary>
        /// The RemoveUnderScore
        /// </summary>
        /// <param name="values">The values<see cref="List{string}"/></param>
        private static void RemoveUnderScore(List<string> values)
        {
            if (values != null && values.Count > 0)
            {
                for (int i = 0; i < values.Count; i++)
                {
                    // Parent and child ids are separated by underscore
                    if (values[i].Contains("_"))
                        values[i] = values[i].Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries).ToList().LastOrDefault();
                }
            }
        }

        /// <summary>
        /// Defines the WidgetIconCssClass
        /// </summary>
        internal const string WidgetIconCssClass = "sfMvcIcn";

        /// <summary>
        /// Gets or sets the ItemType
        /// </summary>
        public string ItemType
        {
            get { return this._itemType; }
            set { this._itemType = value; }
        }

        /// <summary>
        /// Gets the JobAlertEmailTemplateProviderName
        /// </summary>
        public string JobAlertEmailTemplateProviderName
        {
            get { return SitefinityHelper.GetCurrentSiteEmailTemplateProviderName(); }
        }

        /// <summary>
        /// Gets or sets the JobAlertEmailTemplateId
        /// </summary>
        public string JobAlertEmailTemplateId { get; set; }

        /// <summary>
        /// Gets or sets the JobAlertEmailTemplateName
        /// </summary>
        public string JobAlertEmailTemplateName { get; set; }

        /// <summary>
        /// Gets or sets the JobAlertEmailTemplateCC
        /// </summary>
        public string JobAlertEmailTemplateCC { get; set; }

        /// <summary>
        /// Gets or sets the JobAlertEmailTemplateBCC
        /// </summary>
        public string JobAlertEmailTemplateBCC { get; set; }

        /// <summary>
        /// Gets or sets the JobAlertEmailTemplateSenderName
        /// </summary>
        public string JobAlertEmailTemplateSenderName { get; set; }

        /// <summary>
        /// Gets or sets the JobAlertEmailTemplateSenderEmailAddress
        /// </summary>
        public string JobAlertEmailTemplateSenderEmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the JobAlertEmailTemplateEmailSubject
        /// </summary>
        public string JobAlertEmailTemplateEmailSubject { get; set; }

        /// <summary>
        /// Gets or sets the CssClass
        /// </summary>
        public string CssClass { get; set; }

        /// <summary>
        /// Gets or sets the ResultsPageId
        /// </summary>
        public string ResultsPageId { get; set; }

        /// <summary>
        /// Defines the _emailTemplateProviderName
        /// </summary>
        private string _emailTemplateProviderName = "OpenAccessProvider";

        /// <summary>
        /// Defines the _itemType
        /// </summary>
        private string _itemType = "Telerik.Sitefinity.DynamicTypes.Model.StandardEmailTemplate.EmailTemplate";
    }
}
