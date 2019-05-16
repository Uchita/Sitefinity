using System;
using System.Globalization;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Web;

namespace JXTNext.Sitefinity.Common.Helpers
{
    public class SfPageHelper
    {
        public static string GetPageUrlById(Guid pageId, bool fallbackToAnyLanguage = false, bool localizeUrl = true)
        {
            if (pageId != Guid.Empty)
            {
                var pageManager = PageManager.GetManager();
                var node = pageManager.GetPageNode(pageId);

                if (node != null)
                {
                    string relativeUrl;
                    if (SystemManager.CurrentContext.AppSettings.Multilingual)
                    {
                        relativeUrl = node.GetFullUrl(CultureInfo.CurrentUICulture, fallbackToAnyLanguage, localizeUrl);
                    }
                    else
                    {
                        relativeUrl = node.GetFullUrl(null, fallbackToAnyLanguage, localizeUrl);
                    }
                    return UrlPath.ResolveUrl(relativeUrl, Config.Get<SystemConfig>().SiteUrlSettings.GenerateAbsoluteUrls);
                }
            }

            return null;
        }
    }
}
