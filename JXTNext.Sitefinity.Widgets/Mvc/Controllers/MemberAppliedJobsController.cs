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
using JXTNext.Sitefinity.Widgets.User.Mvc.Models.MemberAppliedJob;

namespace JXTNext.Sitefinity.Widgets.User.Mvc.Controllers
{
    [EnhanceViewEngines]
    [ControllerToolboxItem(Name = "Member_AppliedJobs_MVC", Title = "JXT Member Applied Jobs", SectionName = "JXTNext.Member", CssClass = MemberAppliedJobsController.WidgetIconCssClass)]
    public class MemberAppliedJobsController : Controller
    {
        internal const string WidgetIconCssClass = "sfMvcIcn";
        string templateNamePrefix = "MemberAppliedJobs.";
        private string templateName = "List";

        MemberAppliedJobBC _memberAppliedJobBC;

        /// <summary>
        /// Gets or sets the name of the template that widget will be displayed.
        /// </summary>
        /// <value></value>
        public string TemplateName { get => this.templateName; set => this.templateName = value; }

        public MemberAppliedJobsController(MemberAppliedJobBC memberAppliedJobBC)
        {
            _memberAppliedJobBC = memberAppliedJobBC;
        }

        // GET: JobDetails
        public ActionResult Index()
        {
            bool GetListSuccess = _memberAppliedJobBC.GetList(out List<MemberAppliedJobItem> displayItems);

            //if (GetListSuccess)
            //{
            //    var fullTemplateName = this.templateNamePrefix + this.TemplateName;
            //    return View(fullTemplateName, displayItems);
            //}

            return null;
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }
    }
}