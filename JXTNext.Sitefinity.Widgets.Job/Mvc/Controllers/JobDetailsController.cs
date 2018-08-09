using JXTNext.Sitefinity.Connector.BusinessLogics;
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

                ViewBag.CssClass = this.CssClass;
                ViewBag.JobApplicationPageUrl = SitefinityHelper.GetPageUrl(this.JobApplicationPageId);

                var fullTemplateName = this.templateNamePrefix + this.TemplateName;
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
        private string templateName = "Simple";
        private string templateNamePrefix = "JobDetails.";
    }
}