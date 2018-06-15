﻿using System;
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
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers;
using JXTNext.Sitefinity.Mvc.Helpers;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "JobSearch_MVC", Title = "Job Search", SectionName = "Search", CssClass = JobSearchController.WidgetIconCssClass)]
    public class JobSearchController : Controller
    {
        IBusinessLogicsConnector _testBLConnector;
        IOptionsConnector _testOConnector;
        IGetJobFiltersResponse filtersResponse;

        public JobSearchController(IEnumerable<IBusinessLogicsConnector> _bConnectors, IEnumerable<IOptionsConnector> _oConnectors)
        {
            _testBLConnector = _bConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.Test).FirstOrDefault();
            _testOConnector = _oConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.Test).FirstOrDefault();
          
            //Execute - Get available filter options from the server
            filtersResponse = _testOConnector.JobFilters<Test_GetJobFiltersRequest, Test_GetJobFiltersResponse>(new Test_GetJobFiltersRequest());
            this.SerializedFilterData = JsonSerializer.SerializeToString(filtersResponse.Filters.Data);
        }

        public string CssClass { get; set; }
        public string ResultsPageId { get; set; }

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
            filtersResponse = _testOConnector.JobFilters<Test_GetJobFiltersRequest, Test_GetJobFiltersResponse>(new Test_GetJobFiltersRequest());
            this.SerializedFilterData = JsonSerializer.SerializeToString(filtersResponse.Filters.Data);

            //Execute - Try perform a dummy search
            ISearchJobsRequest request = new Test_SearchJobsRequest { Page = 0, PageSize = 2, FiltersSearch = new List<FiltersSearchRoot> { new FiltersSearchRoot { RootID = "AE-1234", Filters = new List<FiltersSearchElement> { new FiltersSearchElement { ID = "DD-3123" } } } } };
            ISearchJobsResponse response = _testBLConnector.SearchJobs(request);

            IGetJobListingRequest jobListingRequest = new Test_GetJobListingRequest { JobID = "8A" };
            IGetJobListingResponse jobListingResponse = _testBLConnector.AdvertiserGetJob(jobListingRequest);

            // This is the CSS classes enter from More Options
            ViewData["CssClass"] = this.CssClass;
            ViewData["JobResultsPageUrl"] = SitefinityHelper.GetPageUrl(this.ResultsPageId);

            var jobSearchComponents = JsonSerializer.DeserializeFromString<List<JobSearchModel>>(this.SerializedJobSearchParams);
            if(jobSearchComponents != null)
            {
                foreach (JobSearchModel item in jobSearchComponents)
                {
                    FilterData(item.Filters);
                    item.Filters = item.Filters.Where(d => d.Show == true || d.Filters?.Count > 0).ToList();
                }
            }

            var fullTemplateName = this.templateNamePrefix + this.TemplateName;

            return View(fullTemplateName, jobSearchComponents);
        }

        static void FilterData(List<JobSearchItem> data)
        {
            if (data == null || data.Count == 0)
                return;

            foreach (JobSearchItem item in data)
            {
                if (item.Filters != null && item.Filters.Count > 0)
                {
                    FilterData(item.Filters);
                    item.Filters = item.Filters.Where(d => d.Show == true || d.Filters?.Count > 0).ToList();
                }
            }

            data = data.Where(d => d.Show == true || d.Filters?.Count > 0).ToList();
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.Index().ExecuteResult(this.ControllerContext);
        }

        public string SerializedJobSearchParams { get; set; }
        public string SerializedFilterData { get; set; }
        internal const string WidgetIconCssClass = "sfMvcIcn";
        private JobSearchModel model;
        private string templateName = "Simple";
        private string templateNamePrefix = "JobSearch.";
    }
}