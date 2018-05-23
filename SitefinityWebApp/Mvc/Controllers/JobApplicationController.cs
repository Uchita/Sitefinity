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
                    var byteArr = ReadAllBytes(fileContent.InputStream);
                    //var stringStream = Encoding.Default.GetString(byteArr);
                    fileStreamKeyValue.Add(fileContent.FileName, byteArr);
                }
            }

            return View("Simple");
        }

        static byte[] ReadAllBytes(Stream inStream)
        {
            if (inStream is MemoryStream)
                return ((MemoryStream)inStream).ToArray();

            using (var memoryStream = new MemoryStream())
            {
                inStream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        internal const string WidgetIconCssClass = "sfMvcIcn";
    }
}