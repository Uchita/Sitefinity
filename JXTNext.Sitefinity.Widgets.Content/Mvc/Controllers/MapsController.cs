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
using Newtonsoft.Json;
using JXTNext.Sitefinity.Widgets.Content.Mvc.StringResources;

namespace JXTNext.Sitefinity.Widgets.Content.Mvc.Controllers
{
    [EnhanceViewEngines]
    [Localization(typeof(MapsResources))]
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
            var mapsMarkersInfo = this.SerializedMapsParams == null ? null : JsonConvert.DeserializeObject<List<MapsMarkerModel>>(this.SerializedMapsParams);
            var viewModel = new MapsViewModel();
            viewModel.MapsMarkers = mapsMarkersInfo;
            viewModel.ZoomLevel = this.ZoomLevel.HasValue ? this.ZoomLevel.Value : 10;
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
        public string SerializedMapsParams { get; set; }
        public int? ZoomLevel { get; set; }
        internal const string WidgetIconCssClass = "sfMvcIcn";
        private string templateName = "Simple";
        private string templateNamePrefix = "Maps.";
    }
}
