using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "MvcLayout2", Title = "MvcLayout2", SectionName = "MvcLayouts2")]
    public class BaseLayout2Controller : Controller
    {
        public ActionResult MvcLayout2()
        {
            return View("MvcLayout2");
        }

    }
}