using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using SitefinityWebApp.Mvc.Models;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.Options;
using JXTNext.Sitefinity.Connector.Options.Models.Job;
using Newtonsoft.Json;
using System.Web.Routing;
using System.Collections;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "JobAlert_MVC", Title = "Job Alert", SectionName = "Search", CssClass = JobAlertController.WidgetIconCssClass)]
    public class JobAlertController : Controller
    {
        IBusinessLogicsConnector _testBLConnector;
        IOptionsConnector _testOConnector;
 
        public JobAlertController(IEnumerable<IBusinessLogicsConnector> _bConnectors, IEnumerable<IOptionsConnector> _oConnectors)
        {
            _testBLConnector = _bConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.Test).FirstOrDefault();
            _testOConnector = _oConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.Test).FirstOrDefault();
        }

        // GET: JobAlert
        public ActionResult Index()
        {
            List<JobAlertViewModel> jobAlertData = new List<JobAlertViewModel>();

            jobAlertData.Add(new JobAlertViewModel() { Id = "1", Name="One", EmailAlert=true,LastModified= "19/05/2017"});
            jobAlertData.Add(new JobAlertViewModel() { Id = "2", Name = "Two", EmailAlert = false, LastModified = "19/05/2018" });
            jobAlertData.Add(new JobAlertViewModel() { Id = "3", Name = "Three", EmailAlert = true, LastModified = "19/05/2016" });
           
            return View("Simple", jobAlertData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            dynamic dynamicFilterResponse = null;
            IGetJobFiltersResponse filtersResponse = _testOConnector.JobFilters<Test_GetJobFiltersRequest, Test_GetJobFiltersResponse>(new Test_GetJobFiltersRequest());
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

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View("Edit");
        }

        [HttpGet]
        public ActionResult ViewResults(string id)
        {
            JobAlertViewModel jobAlertDetails = GetJobAlertDetailsMock(id);
            return Redirect("/jobsearchresults?" + ToQueryString(jobAlertDetails));
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            // TODO: When the Backend API is ready,
            // We need to pass this job alert id to it
            return RedirectToAction("Index");
        }

        private JobAlertViewModel GetJobAlertDetailsMock(string jobAlertId)
        {
            JobAlertViewModel model = new JobAlertViewModel() { Filters = new List<JobAlertFilters>() };
            model.Id = "HD-123";
            model.Name = "Test";
            model.EmailAlert = true;
            model.LastModified = "12/05/2016";
            model.Keywords = "Job";

            model.Filters.Add(new JobAlertFilters() { RootId = "AE-1234", Values = new List<string>() { "HD-345", "AF-of34", "EH-sf355" } });

            return model;
        }

        static string ToQueryString(JobAlertViewModel jobAlertDetails)
        {
            List<string> queryParamsStringList = new List<string>();

            queryParamsStringList.Add("Keywords=" + jobAlertDetails.Keywords);
            queryParamsStringList.Add("JobDetailsPageUrl=/jobdetails");
            
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

        internal const string WidgetIconCssClass = "sfMvcIcn";
      }
}