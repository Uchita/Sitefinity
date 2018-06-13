﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.Options;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Search;
using JXTNext.Sitefinity.Connector.Options.Models.Job;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;
using Newtonsoft.Json;
using JXTNext.Sitefinity.Mvc.Helpers;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "JobDetails_MVC", Title = "Job Details", SectionName = "Search", CssClass = JobDetailsController.WidgetIconCssClass)]
    public class JobDetailsController : Controller
    {
        IBusinessLogicsConnector _testBLConnector;
        IOptionsConnector _testOConnector;

        public JobDetailsController(IEnumerable<IBusinessLogicsConnector> _bConnectors, IEnumerable<IOptionsConnector> _oConnectors)
        {
            _testBLConnector = _bConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.Test).FirstOrDefault();
            _testOConnector = _oConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.Test).FirstOrDefault();
        }

        // GET: JobDetails
        public ActionResult Index(string jobId)
        {
            dynamic dynamicJobDetails = null;
            IGetJobListingRequest jobListingRequest = new Test_GetJobListingRequest { JobID = jobId };
            IGetJobListingResponse jobListingResponse = _testBLConnector.AdvertiserGetJob(jobListingRequest);

            if(jobListingRequest != null)
                dynamicJobDetails = jobListingResponse as dynamic;

            string userName = String.Empty;
            List<string> roles = new List<string>();
            SitefinityHelper.GetCurrentUserInfo(ref userName, ref roles);
   
            ViewBag.UserName = userName;
            ViewBag.Roles = JsonConvert.SerializeObject(roles);
            ViewBag.CssClass = this.CssClass;
            ViewBag.JobApplicationPageUrl = SitefinityHelper.GetPageUrl(this.JobApplicationPageId);

            return View("Simple", dynamicJobDetails);
        }

        internal const string WidgetIconCssClass = "sfMvcIcn";
        public string CssClass { get; set; }
        public string JobApplicationPageId { get; set; }
    }
}