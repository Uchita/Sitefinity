using System;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Modules;
using Telerik.Sitefinity.Modules.Libraries;
using Telerik.Sitefinity.Services;
using SfImage = Telerik.Sitefinity.Libraries.Model.Image;

namespace SitefinityWebApp.Libraries
{
    public static class SfImageHelper
    {

        public static SfImage GetImage(Guid imageId, string imageProviderName)
        {
            var librariesManager = LibrariesManager.GetManager(imageProviderName);
            return librariesManager.GetImages().Where(i => i.Id == imageId).Where(PredefinedFilters.PublishedItemsFilter<SfImage>()).FirstOrDefault();
        }

        public static string GetSelectedSizeUrl(SfImage image)
        {
            if (image.Id == Guid.Empty)
                return string.Empty;

            var urlAsAbsolute = Config.Get<SystemConfig>().SiteUrlSettings.GenerateAbsoluteUrls;
            return image.ResolveMediaUrl(urlAsAbsolute);
        }

    }
}