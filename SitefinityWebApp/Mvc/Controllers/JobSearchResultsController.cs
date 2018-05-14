using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Web;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "JobSearchResults_MVC", Title = "Job Search Results", SectionName = "Search", CssClass = JobSearchResultsController.WidgetIconCssClass)]
    public class JobSearchResultsController : Controller
    {
        // GET: JobSearchResults
        public ActionResult Index()
        {
            return View("Simple");
        }

        internal const string WidgetIconCssClass = "sfMvcIcn";
    }
}