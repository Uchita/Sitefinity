using JXTNext.Sitefinity.Widgets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitefinityWebApp
{
    public class SFViewEngine : VirtualPathProviderViewEngine
    {
        public SFViewEngine()
        {
            this.FileExtensions = new string[] { "cshtml", "vbhtml", "aspx", "ascx" };
            this.AreaViewLocationFormats = baseLocationFormats;
            this.AreaMasterLocationFormats = baseLocationFormats;
            this.AreaPartialViewLocationFormats = baseLocationFormats;
            this.ViewLocationFormats = baseLocationFormats;
            this.MasterLocationFormats = baseLocationFormats;
            this.PartialViewLocationFormats = baseLocationFormats;
        }

        protected override IView CreatePartialView(
       ControllerContext controllerContext, string partialPath)
        {
            if (partialPath.EndsWith(".cshtml") || partialPath.EndsWith(".vbhtml"))
            {
                return new System.Web.Mvc.RazorView(controllerContext, partialPath, null, false, null);
            }
            else
            {
                return new WebFormView(controllerContext, partialPath);
            }
        }

        protected override IView CreateView(ControllerContext controllerContext,
            string viewPath, string masterPath)
        {
            if (viewPath.EndsWith(".cshtml") || viewPath.EndsWith(".vbhtml"))
            {
                return new RazorView(controllerContext, viewPath, masterPath, false, null);
            }
            else
            {
                return new WebFormView(controllerContext, viewPath, masterPath);
            }
        }

        //protected static readonly string[] baseLocationFormats = new string[] {
        //    "~/ResourcePackages/JXTDemo/Mvc/Views/{1}/{0}.cshtml",
        //    "~/ResourcePackages/JXTDemo/Mvc/Views/Shared/{0}.cshtml"

        //};

        protected string[] baseLocationFormats {
            get {

                List<string> locationFormats = new List<string>();

                List<string> packages = GetResourcePackagesName();
                
                foreach(string p in packages)
                {
                    locationFormats.Add("~/ResourcePackages/" + p + "/Mvc/Views/{1}/{0}.cshtml");
                    locationFormats.Add("~/ResourcePackages/" + p + "/Mvc/Views/Shared/{0}.cshtml");
                }

                return locationFormats.ToArray();
            }
        }

        private List<string> GetResourcePackagesName()
        {
            List<string> packages = new List<string>();

            packages.AddRange(new ViewEngineRoutesConfig().ResoucePackages);

            return packages;
        }

    }
}