using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "MvcLayout", Title = "MvcLayout1", SectionName = "MvcLayouts")]
    public class BaseLayoutController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


    }
}