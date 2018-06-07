using JXTNext.Sitefinity.Mvc.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
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
        [HttpGet]
        public ActionResult Index()
        {
            return View("Simple");
        }

        [HttpPost]
        public ActionResult ApplyJob()
        {
            Dictionary<string, byte[]> fileStreamKeyValue = new Dictionary<string, byte[]>();
            foreach (string key in Request.Files)
            {
                HttpPostedFileBase fileContent = Request.Files[key];
                if (fileContent != null && fileContent.ContentLength > 0)
                {
                    var byteArr = ConversionHelper.StreamToBytes(fileContent.InputStream);
                    //var stringStream = Encoding.Default.GetString(byteArr);
                    fileStreamKeyValue.Add(fileContent.FileName, byteArr);
                }
            }

            return View("Simple");
        }

        internal const string WidgetIconCssClass = "sfMvcIcn";
    }
}