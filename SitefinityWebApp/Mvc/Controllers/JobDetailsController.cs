using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "JobDetails_MVC", Title = "Job Details", SectionName = "Search", CssClass = JobDetailsController.WidgetIconCssClass)]
    public class JobDetailsController : Controller
    {
        // GET: JobDetails
        public ActionResult Index()
        {
            return View("Simple");
        }

        internal const string WidgetIconCssClass = "sfMvcIcn";
    }
}