using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using SitefinityWebApp.Mvc.Models;
using System.ComponentModel;
using ServiceStack.Text;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "JobSearch_MVC", Title = "Job Search", SectionName = "Search", CssClass = JobSearchController.WidgetIconCssClass)]
    public class JobSearchController : Controller
    {
        public string CssClass { get; set; }

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
            // This is the CSS classes enter from More Options
            ViewData["CssClass"] = this.CssClass;

            var jobSearchComponents = JsonSerializer.DeserializeFromString<List<JobSearchModel>>(this.SerializedJobSearchParams);
            return View("Simple", jobSearchComponents);
        }

        public string SerializedJobSearchParams { get; set; }
        internal const string WidgetIconCssClass = "sfMvcIcn";
        private JobSearchModel model;
    }
}