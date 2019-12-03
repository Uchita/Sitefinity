using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Modules.Pages.Configuration;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "CustomError_Mvc", Title = "Custom Error", SectionName = ToolboxesConfig.ContentToolboxSectionName, CssClass = MultiCardController.WidgetIconCssClass)]
    public class CustomErrorController : Controller
    {
        // GET: CustomError
        public ActionResult Index()
        {
            Response.Status = "404 Not Found";
            Response.StatusCode = 404;
            Response.StatusDescription = "Not Found!";
            return View("Index");
        }
    }
}