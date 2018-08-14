using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using Telerik.Sitefinity.Web;
using JXTNext.Sitefinity.Widgets.Content.Mvc.Models;
using JXTNext.Sitefinity.Common.Helpers;

namespace JXTNext.Sitefinity.Widgets.Content.Mvc.Controllers
{
    [EnhanceViewEngines]
    [ControllerToolboxItem(Name = "Maps_MVC", Title = "Maps", SectionName = "JXTNext.Content", CssClass = MapsController.WidgetIconCssClass)]
    public class MapsController : Controller
    {

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

        public ActionResult Index()
        {
            var viewModel = new MapsViewModel();
            viewModel.Address = this.Address;
            viewModel.GoogleMapsAPIKey = new SiteSettingsHelper().GetCurrentSiteGoogleMapsAPIKey();
            var fullTemplateName = this.templateNamePrefix + this.TemplateName;
            ViewBag.CssClass = CssClass;
            return View(fullTemplateName, viewModel);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }

        public string CssClass { get; set; }
        public string Address { get; set; }
        internal const string WidgetIconCssClass = "sfMvcIcn";
        private string templateName = "Simple";
        private string templateNamePrefix = "Maps.";
    }
}
