using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Pages.Model;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Security.Claims;
using Telerik.Sitefinity.Services;

namespace JXTNext.Sitefinity.Mvc.Helpers
{
    public class SitefinityHelper
    {
        public static TimeZoneInfo GetSitefinityTimeZoneInfo()
        {
            var sitefinityTimeZoneInfo = Telerik.Sitefinity.Configuration.Config.Get<SystemConfig>().UITimeZoneSettings.CurrentTimeZoneInfo;
            if (sitefinityTimeZoneInfo == null && UserManager.GetManager() != null)
                sitefinityTimeZoneInfo = UserManager.GetManager().GetUserTimeZone();

            return sitefinityTimeZoneInfo;
        }

        public static DateTime GetSitefinityApplicationTime()
        {
            var sitefinityAppTime = DateTime.Now;
            var sitefinityTimeZoneInfo = GetSitefinityTimeZoneInfo();
            if (sitefinityTimeZoneInfo != null)
                sitefinityAppTime = TimeZoneInfo.ConvertTime(DateTime.Now, sitefinityTimeZoneInfo);

            return sitefinityAppTime;
        }

        public static string GetPageUrl(string pageId)
        {
            string pageUrl = String.Empty;

            PageManager pageManager = PageManager.GetManager();
            if (pageManager != null)
            {
                if (!pageId.IsNullOrEmpty())
                {
                    Guid pageNodeId = new Guid(pageId);
                    PageNode pageNode = pageManager.GetPageNodes().Where(n => n.Id == pageNodeId).FirstOrDefault();
                    // We will get the url as ~/homepage
                    // So removing the first character
                    if (pageNode != null)
                        pageUrl = pageNode.GetUrl().Substring(1);
                }
            }

            return pageUrl;
        }

        public static void GetCurrentUserInfo(ref string UserName, ref List<string> Roles)
        {
            // Get the current identity 
            var identity = ClaimsManager.GetCurrentIdentity();

            // Get information about the user from the properties of the ClaimsIdentityProxy object
            if (identity != null)
            {
                UserName = identity.Name;
                foreach (var rolesInfo in identity.Roles)
                {
                    Roles.Add(rolesInfo.Name);
                }
            }
        }
    }
}