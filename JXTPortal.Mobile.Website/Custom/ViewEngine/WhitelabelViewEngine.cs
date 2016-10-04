using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JXTPortal.Entities;
using System.Configuration;

namespace JXTPortal.Mobile.Website.ViewEngine
{
    public class WhitelabelViewEngine : RazorViewEngine
    {
        private const string WHITELABELVIEWFOLDER = "Whitelabel";
        private const string MAINFOLDER = "Main";
        private bool cachingEnabled = ConfigurationManager.AppSettings["Caching"].ToString().ToLower().Equals("true");

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            useCache = cachingEnabled;

            ViewEngineResult result = null;
            var request = controllerContext.HttpContext.Request;
            
            result = base.FindView(controllerContext, string.Format("{0}/{1}/", WHITELABELVIEWFOLDER, SessionData.Site.SiteId) + viewName, masterName, useCache);

            //Fall back to default master whitelabel view if no whitelabel view has already been set
            if (result == null || result.View == null)
            {
                result = base.FindView(controllerContext, MAINFOLDER + "/" + viewName, masterName, useCache);
            }

            return result;

        }

        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            useCache = cachingEnabled;

            ViewEngineResult result = null;
            var request = controllerContext.HttpContext.Request;

            result = base.FindPartialView(controllerContext, string.Format("{0}/{1}/", WHITELABELVIEWFOLDER, SessionData.Site.SiteId) + partialViewName, useCache);

            //Fall back to default master whitelabel view if no whitelabel view has already been set
            if (result == null || result.View == null)
            {
                result = base.FindPartialView(controllerContext, MAINFOLDER + "/" + partialViewName, useCache);
            }

            return result;
        }
        
        /// <summary>
        /// this is used to resolve the dynamic view location
        /// </summary>
        /// <param name="ViewLocation"></param>
        /// <returns></returns>
        public static string Resolve(string ViewLocation)
        {
            string DefaultViewPath = ViewLocation;

            if (SessionData.Site != null)
            {
                string WhitelabelViewPath = DefaultViewPath.Replace("/Main/", string.Format("/{0}/{1}/", "Whitelabel", SessionData.Site.SiteId.ToString()));
                if (System.IO.File.Exists(HttpContext.Current.Request.MapPath(WhitelabelViewPath)))
                {
                    DefaultViewPath = WhitelabelViewPath;
                }
            }

            return DefaultViewPath;
        }

        #region "Mobile specific logic
        /*
                 //This could be replaced with a switch statement as other advanced / device specific views are created
            if (UserAgentIs(controllerContext, "iPhone"))
            {
                result = base.FindView(controllerContext, "Mobile/iPhone/" + viewName, masterName, useCache);
            }

            // Avoid unnecessary checks if this device isn't suspected to be a mobile device
            if (request.Browser.IsMobileDevice)
            {
                //TODO: We are not doing any thing WinMobile SPECIAL yet!

                //if (UserAgentIs(controllerContext, "MSIEMobile 6"))   {
                //  result = base.FindView(controllerContext, "Mobile/MobileIE6/" + viewName, masterName, useCache);
                //}
                //else if (UserAgentIs(controllerContext, "PocketIE") && request.Browser.MajorVersion >= 4)
                //{
                //  result = base.FindView(controllerContext, "Mobile/PocketIE/" + viewName, masterName, useCache);
                //}

                //Fall back to default mobile view if no other mobile view has already been set
                if ((result == null || result.View == null) &&
                                request.Browser.IsMobileDevice)
                {
                    result = base.FindView(controllerContext, "Mobile/" + viewName, masterName, useCache);
                }
            }

            //Fall back to desktop view if no other view has been selected
            if (result == null || result.View == null)
            {
                result = base.FindView(controllerContext, viewName, masterName, useCache);
            }

          public bool UserAgentIs(ControllerContext controllerContext, string userAgentToTest)
        {
	            return (controllerContext.HttpContext.Request.UserAgent.IndexOf(userAgentToTest,
	                            StringComparison.OrdinalIgnoreCase) > 0);
	        }
         */

        #endregion
    }
}