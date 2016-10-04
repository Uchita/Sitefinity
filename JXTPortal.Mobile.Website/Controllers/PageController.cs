using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using JXTPortal.Entities;
using JXTPortal.Domain.ViewModel;

namespace JXTPortal.Mobile.Website.Controllers
{
    public class PageController : Controller
    {
        //
        // GET: /Page/

        public ActionResult Index(string id)
        {
            string PageFile = string.Format("~/Views/Shared/Whitelabel/{0}/Pages/{1}.htm", SessionData.Site.SiteId, id);
            string AlternatePageFile = string.Format("~/Views/Shared/Whitelabel/{0}/Pages/{1}.html", SessionData.Site.SiteId, id);
            string PageFileLocation = Server.MapPath(PageFile);
            string AlternatePageFileLocation = Server.MapPath(AlternatePageFile);
            PageModel model = new PageModel() { FileLocation = "" };

            //check the htm extension
            if (System.IO.File.Exists(PageFileLocation))
            {
                model.FileLocation = PageFile;
                
                using (var stream = new StreamReader(PageFileLocation))
                {
                    model.Content = stream.ReadToEnd();
                }
                
            }//check the html extension
            else if (System.IO.File.Exists(AlternatePageFileLocation))
            {
                model.FileLocation = AlternatePageFile;
                
                using (var stream = new StreamReader(AlternatePageFileLocation))
                {
                    model.Content = stream.ReadToEnd();
                }
                
            }
            else
            {
                 model.Content = string.Empty;
            }

            //Use Content/Code below if you want to render all the HTML without the master page
            //return Content(model.Content);
            return View(model);
        }
    }
}
