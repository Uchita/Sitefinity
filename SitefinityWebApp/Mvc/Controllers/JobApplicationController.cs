using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "JobApplication_MVC", Title = "Job Application", SectionName = "Search", CssClass = JobApplicationController.WidgetIconCssClass)]
    public class JobApplicationController : Controller
    {
        // GET: JobApplication
        public ActionResult Index()
        {
            return View("Simple");
        }

        internal const string WidgetIconCssClass = "sfMvcIcn";
    }
}