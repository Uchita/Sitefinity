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

        protected string[] baseLocationFormats {
            get {

                List<string> locationFormats = new List<string>();

                //paths for resource packages
                locationFormats.AddRange(GetResourcePackagesNameViewsRendering());

                //paths for external frontend assemblies
                locationFormats.AddRange(GetAssemblyNamesForPartialViewsRendering());

                return locationFormats.ToArray();
            }
        }

        private List<string> GetResourcePackagesNameViewsRendering()
        {
            var allDirs = System.IO.Directory.GetDirectories("ResourcePackages");
            List<string> viewPaths = new List<string>();

            foreach (string p in allDirs)
            {
                viewPaths.Add("~/ResourcePackages/" + p + "/Mvc/Views/{1}/{0}.cshtml");
                viewPaths.Add("~/ResourcePackages/" + p + "/Mvc/Views/Shared/{0}.cshtml");
            }

            return viewPaths;
        }

        /// <summary>
        /// This is required for any Partial views rendering in external frontend assemblies
        /// Reference: https://knowledgebase.progress.com/articles/Article/Cannot-find-partial-view-from-external-assembly
        /// </summary>
        /// <returns></returns>
        private List<string> GetAssemblyNamesForPartialViewsRendering()
        {
            List<string> viewPaths = new List<string>();
            List<string> assemblyNames = new List<string> { "JXTNext.Sitefinity.Widgets.Job" };

            foreach (string name in assemblyNames)
            {
                viewPaths.Add("~/Frontend-Assembly/" + name + "/Mvc/Views/{1}/{0}.cshtml");
                viewPaths.Add("~/Frontend-Assembly/" + name + "/Mvc/Views/Shared/{0}.cshtml");
            }

            return viewPaths;
        }

    }
}