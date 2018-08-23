﻿using JXTNext.Sitefinity.Connector.BusinessLogics;
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

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Controllers
{
    [EnhanceViewEngines]
    [ControllerToolboxItem(Name = "JobDetails_MVC", Title = "Details", SectionName = "JXTNext.Job", CssClass = JobDetailsController.WidgetIconCssClass)]
    public class JobDetailsController : Controller
    {
        // All these properties are bind to the designer form 
        // Same will be displayed in the Advanced section of the designer form as text boxes
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public JobDetailsRolesModel Model
        {
            get
            {
                if (this.model == null)
                    this.model = new JobDetailsRolesModel();

                return this.model;
            }
        }

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

        public JobDetailsController(IEnumerable<IBusinessLogicsConnector> _bConnectors, IEnumerable<IOptionsConnector> _oConnectors)
        {
            _BLConnector = _bConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
            _OConnector = _oConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
        }

        // GET: JobDetails
        public ActionResult Index(int? jobId)
        {
            JobDetailsViewModel viewModel = new JobDetailsViewModel();
            if (jobId.HasValue)
            {
                IGetJobListingRequest jobListingRequest = new JXTNext_GetJobListingRequest { JobID = jobId.Value };
                IGetJobListingResponse jobListingResponse = _BLConnector.GuestGetJob(jobListingRequest);

                viewModel.JobDetails = jobListingResponse.Job;

                // Getting Consultant Avatar Image Url from Sitefinity 
                var user = SitefinityHelper.GetUserByEmail(jobListingResponse.Job.CustomData["ApplicationMethod.ApplicationEmail"]);
                if(user != null && user.Id != Guid.Empty)
                    viewModel.ApplicationAvatarImageUrl = SitefinityHelper.GetUserAvatarUrlById(user.Id);
          
                if (this.Model.IsJobApplyAvailable())
                    viewModel.JobApplyAvailable = true;

                // Processing Classifications
                OrderedDictionary classifOrdDict = new OrderedDictionary();
                classifOrdDict.Add(jobListingResponse.Job.CustomData["Classifications[0].Filters[0].ExternalReference"], jobListingResponse.Job.CustomData["Classifications[0].Filters[0].Value"]);
                string parentClassificationsKey = "Classifications[0].Filters[0].SubLevel[0]";
                JobDetailsViewModel.ProcessCustomData(parentClassificationsKey, jobListingResponse.Job.CustomData, classifOrdDict);
                OrderedDictionary classifParentIdsOrdDict = new OrderedDictionary();
                JobDetailsViewModel.AppendParentIds(classifOrdDict, classifParentIdsOrdDict);

                // Processing Locations
                OrderedDictionary locOrdDict = new OrderedDictionary();
                classifOrdDict.Add(jobListingResponse.Job.CustomData["CountryLocationArea[0].Filters[0].ExternalReference"], jobListingResponse.Job.CustomData["CountryLocationArea[0].Filters[0].Value"]);
                string parentLocKey = "CountryLocationArea[0].Filters[0].SubLevel[0]";
                JobDetailsViewModel.ProcessCustomData(parentLocKey, jobListingResponse.Job.CustomData, locOrdDict);
                
                viewModel.Classifications = classifParentIdsOrdDict;
                viewModel.Locations = locOrdDict;
                viewModel.ClassificationsRootName = "Classifications";
               
                ViewBag.CssClass = this.CssClass;
                ViewBag.JobApplicationPageUrl = SitefinityHelper.GetPageUrl(this.JobApplicationPageId);
                ViewBag.JobResultsPageUrl = SitefinityHelper.GetPageUrl(this.JobResultsPageId);

                var fullTemplateName = this.templateNamePrefix + this.TemplateName;
                // If it is null make sure that pass empty string , because html attrubutes will not work properly.
                viewModel.JobDetails.Address = viewModel.JobDetails.Address == null ? "" : viewModel.JobDetails.Address;
                viewModel.JobDetails.AddressLatitude = viewModel.JobDetails.AddressLatitude == null ? "" : viewModel.JobDetails.AddressLatitude;
                viewModel.JobDetails.AddressLongtitude = viewModel.JobDetails.AddressLongtitude == null ? "" : viewModel.JobDetails.AddressLongtitude;

                return View(fullTemplateName, viewModel);
            }

            return Content("No job has been selected");
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }

        internal const string WidgetIconCssClass = "sfMvcIcn";
        public string CssClass { get; set; }
        private JobDetailsRolesModel model;
        public string JobApplicationPageId { get; set; }
        public string JobResultsPageId { get; set; }
        private string templateName = "Simple";
        private string templateNamePrefix = "JobDetails.";
    }
}