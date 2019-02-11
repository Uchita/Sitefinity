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
using System.ComponentModel;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using JXTNext.Sitefinity.Widgets.User.Mvc.Logics;
using JXTNext.Sitefinity.Widgets.User.Mvc.Models.MemberSavedJob;
using JXTNext.Sitefinity.Widgets.User.Mvc.StringResources;

namespace JXTNext.Sitefinity.Widgets.User.Mvc.Controllers
{
    [EnhanceViewEngines]
    [Localization(typeof(MemberSavedJobsResources))]
    [ControllerToolboxItem(Name = "Member_SavedJobs_MVC", Title = "JXT Member Saved Jobs", SectionName = "JXTNext.Member", CssClass = MemberSavedJobsController.WidgetIconCssClass)]
    public class MemberSavedJobsController : Controller
    {
        internal const string WidgetIconCssClass = "sfMvcIcn";
        string templateNamePrefix = "MemberSavedJobs.";
        private string templateName = "List";
        IBusinessLogicsConnector _blConnector;
        MemberSavedJobBC _memberSavedJobBC;

        /// <summary>
        /// Gets or sets the name of the template that widget will be displayed.
        /// </summary>
        /// <value></value>
        public string TemplateName { get => this.templateName; set => this.templateName = value; }

        public MemberSavedJobsController(MemberSavedJobBC memberSavedJobBC, IBusinessLogicsConnector blConnector)
        {
            _memberSavedJobBC = memberSavedJobBC;
            _blConnector = blConnector;
        }

        // GET: JobDetails
        public ActionResult Index()
        {
            bool GetListSuccess = _memberSavedJobBC.GetList(out List<MemberSavedJobDisplayItem> displayItems);

            foreach (var job in displayItems)
            {
                IGetJobListingRequest jobListingRequest = new JXTNext_GetJobListingRequest { JobID = job.JobId };
                IGetJobListingResponse jobListingResponse = _blConnector.GuestGetJob(jobListingRequest);
                // Processing Classifications
                OrderedDictionary classifOrdDict = new OrderedDictionary();
                classifOrdDict.Add(jobListingResponse.Job.CustomData["Classifications[0].Filters[0].ExternalReference"], jobListingResponse.Job.CustomData["Classifications[0].Filters[0].Value"]);
                string parentClassificationsKey = "Classifications[0].Filters[0].SubLevel[0]";
                ProcessCustomData(parentClassificationsKey, jobListingResponse.Job.CustomData, classifOrdDict);
                OrderedDictionary classifParentIdsOrdDict = new OrderedDictionary();
                AppendParentIds(classifOrdDict, classifParentIdsOrdDict);

                // Getting the SEO route name for classifications
                List<string> seoString = new List<string>();
                foreach (var key in classifParentIdsOrdDict.Keys)
                {
                    string value = classifParentIdsOrdDict[key].ToString();
                    string SEOString = Regex.Replace(value, @"([^\w]+)", "-");
                    seoString.Add(SEOString);
                }
                job.ClassificationURL = String.Join("/", seoString);
            }

            ViewBag.JobDetailsPageUrl = SitefinityHelper.GetPageUrl(this.JobDetailsPageId);
            ViewBag.DeleteMessage = TempData["DeleteMessage"];
            ViewBag.Status = TempData["Status"];

            if (GetListSuccess)
            {
                var fullTemplateName = this.templateNamePrefix + this.TemplateName;
                return View(fullTemplateName, displayItems);
            }

            return null;
        }

        [HttpGet]
        public ActionResult DeleteSavedJob(int savedJobId)
        {
            bool deleteSuccess = _memberSavedJobBC.Delete(savedJobId);
            var savedStatus = MemberSavedJobStatus.SUCCESS;
            TempData["DeleteMessage"] = "Saved job successfully deleted.";

            if (!deleteSuccess)
            {
                TempData["DeleteMessage"] = "Unable to process your previous request, please try again.";
                savedStatus = MemberSavedJobStatus.DELETE_FAILED;
            }
            TempData["Status"] = savedStatus;

            // Why action name is empty?
            // Here we need to call Index action, if we are providing action name as Index here
            // It is appending in the URL, but we dont want to show that in URL. So, sending it as empty
            // Will definity call defaut action i,.e Index
            return RedirectToAction("");
        }


        public static void AppendParentIds(OrderedDictionary srcDict, OrderedDictionary destDict)
        {
            if (srcDict != null && destDict != null)
            {
                int i = 1;
                string concatKey = String.Empty;
                foreach (var key in srcDict.Keys)
                {
                    if (i == 1)
                    {
                        destDict.Add(key, srcDict[key]);
                        concatKey = key.ToString();
                    }
                    else
                    {
                        concatKey += "_" + key.ToString();
                        destDict.Add(concatKey, srcDict[key]);
                    }

                    i++;
                }
            }
        }


        public void ProcessCustomData(string key, Dictionary<string, string> customData, OrderedDictionary ordDict)
        {
            if (!customData.ContainsKey(key + ".Value"))
                return;

            string addOrRemoveText = ".Sublevel[0]";
            string parentKey = key.Remove(key.Length - addOrRemoveText.Length, addOrRemoveText.Length);

            //string childId = customData[parentKey + ".ExternalReference"] + "_" + customData[key + ".ExternalReference"];
            ordDict.Add(customData[key + ".ExternalReference"], customData[key + ".Value"]);
            string nextKey = key + ".SubLevel[0]";

            ProcessCustomData(nextKey, customData, ordDict);
        }


        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }

        public string JobDetailsPageId { get; set; }
    }
}