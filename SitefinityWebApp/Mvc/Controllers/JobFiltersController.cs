using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "JobFilters_MVC", Title = "Job Filters", SectionName = "Search", CssClass = JobFiltersController.WidgetIconCssClass)]
    public class JobFiltersController : Controller
    {
        // GET: JobFilters
        public ActionResult Index()
        {
            return View("Simple");
        }

        internal const string WidgetIconCssClass = "sfMvcIcn";
    }
}