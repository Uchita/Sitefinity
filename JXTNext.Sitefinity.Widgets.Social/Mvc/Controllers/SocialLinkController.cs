using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using JXTNext.Sitefinity.Widgets.Social.Mvc.Models;
using System.ComponentModel;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Controllers
{
    [EnhanceViewEngines]
    [ControllerToolboxItem(Name = "SocialLink_MVC", Title = "Social link", SectionName = "JXTNext.Social", CssClass = SocialLinkController.WidgetIconCssClass)]
    public class SocialLinkController : Controller
    {
        // All these properties are bind to the designer form 
        // Same will be displayed in the Advanced section of the designer form as text boxes
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public SocialLinkModel Model
        {
            get
            {
                if (this.model == null)
                    this.model = new SocialLinkModel();

                return this.model;
            }
        }

        [Category("CSS Class")]
        public string CssClass { get; set; }

        // GET: SocialLink
        public ActionResult Index()
        {
            // This is the CSS classes enter from More Options
            ViewData["CssClass"] = this.CssClass;

            return View("Simple", this.Model.GetViewModel());
        }

        private SocialLinkModel model;
        internal const string WidgetIconCssClass = "sfMvcIcn";
    }
}