using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "JobAlert_MVC", Title = "Job Alert", SectionName = "Search", CssClass = JobAlertController.WidgetIconCssClass)]
    public class JobAlertController : Controller
    {
        // GET: JobAlert
        public ActionResult Index()
        {
            return View("Simple");
        }

        internal const string WidgetIconCssClass = "sfMvcIcn";
    }
}