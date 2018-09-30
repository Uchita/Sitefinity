using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using System.ComponentModel;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using JXTNext.Sitefinity.Widgets.Social.Mvc.Logics;

namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Controllers
{
    [EnhanceViewEngines]
    [ControllerToolboxItem(Name = "SocialHandler_MVC", Title = "Social handler", SectionName = "JXTNext.Social", CssClass = SocialHandlerController.WidgetIconCssClass)]
    public class SocialHandlerController : Controller
    {
        SocialHandlerLogics _socialHandlerLogics;
        public string CssClass { get; set; }
        public string TemplateName { get; set; }

        public SocialHandlerController(SocialHandlerLogics socialHandlerLogics)
        {
            _socialHandlerLogics = socialHandlerLogics;
        }

        public ActionResult Index()
        {
            // This is the CSS classes enter from More Options
            ViewData["CssClass"] = this.CssClass;

            if (string.IsNullOrWhiteSpace(this.TemplateName))
            {
                this.TemplateName = "SocialHandler.Simple";
            }

            if (_socialHandlerLogics != null)
                _socialHandlerLogics.ProcessSocialHandlerData(null);

            return View(this.TemplateName, null);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }

        internal const string WidgetIconCssClass = "sfMvcIcn";
    }
}