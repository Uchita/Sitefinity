using System;
using System.Globalization;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Web;

namespace SitefinityWebApp.Pages
{
    public class SfPagesHelper
    {
        public static string GetLinkedUrl(Guid linkedPageId, string linkedUrl, bool isPageSelectMode)
        {
            if (isPageSelectMode)
                return GetLinkedUrlByPageId(linkedPageId);

            if (!string.IsNullOrEmpty(linkedUrl))
                return linkedUrl;

            return null;
        }

        private static string GetLinkedUrlByPageId(Guid linkedPageId)
        {
            if (linkedPageId != Guid.Empty)
            {
                var pageManager = PageManager.GetManager();
                var node = pageManager.GetPageNode(linkedPageId);
                if (node != null)
                {
                    string relativeUrl;
                    if (SystemManager.CurrentContext.AppSettings.Multilingual)
                    {
                        relativeUrl = node.GetFullUrl(CultureInfo.CurrentUICulture, false);
                    }
                    else
                    {
                        relativeUrl = node.GetFullUrl();
                    }

                    return UrlPath.ResolveUrl(relativeUrl, true);
                }
            }

            return null;
        }
    }
}