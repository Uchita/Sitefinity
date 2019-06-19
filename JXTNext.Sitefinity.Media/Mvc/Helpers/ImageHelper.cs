using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Frontend.Mvc.Models;
using Telerik.Sitefinity.Libraries.Model;
using Telerik.Sitefinity.Modules.Libraries;
using Telerik.Sitefinity.Services;

namespace JXTNext.Sitefinity.Media.Mvc.Helpers
{
    public static class ImageHelper
    {
        /// <summary>
        /// Gets the URL of a Sitefinity image.
        /// </summary>
        /// <param name="image">The Sitefinity image item.</param>
        /// <param name="thumbnailName">Optional: The name of the thumbnail profile.</param>
        /// <returns></returns>
        public static string GetImageUrl(Image image, string thumbnailName = null)
        {
            if (image != null)
            {

                var resolveAsAbsoluteUrl = Config.Get<SystemConfig>().SiteUrlSettings.GenerateAbsoluteUrls;
                CultureInfo culture = null;

                if (SystemManager.CurrentContext.AppSettings.Multilingual && CultureInfo.CurrentUICulture != CultureInfo.InvariantCulture)
                {
                    culture = CultureInfo.CurrentUICulture;
                }

                return MediaContentExtensions.ResolveThumbnailUrl(image, thumbnailName, resolveAsAbsoluteUrl, culture);
            }

            return null;
        }

        /// <summary>
        /// Gets the URL of a Sitefinity image.
        /// </summary>
        /// <param name="imageField">The dynamic field containing the single image.</param>
        /// <param name="thumbnailName">Optional: The name of the thumbnail profile.</param>
        /// <returns></returns>
        public static string GetImageUrl(dynamic imageField, string thumbnailName = null)
        {
            if (imageField != null && imageField.GetType() == typeof(ItemViewModel))
            {
                return GetImageUrl((ItemViewModel)imageField, thumbnailName);
            }

            return null;
        }

        /// <summary>
        /// Gets the URL of an image.
        /// </summary>
        /// <param name="imageField">The ItemViewModel for the dynamic field containing the single image.</param>
        /// <param name="thumbnailName">Optional: The name of the thumbnail profile.</param>
        /// <returns></returns>
        public static string GetImageUrl(ItemViewModel imageField, string thumbnailName = null)
        {
            if (imageField != null && imageField.DataItem.GetType() == typeof(Image))
            {
                var image = (Image)imageField.DataItem;
                return GetImageUrl(image, thumbnailName);
            }

            return null;
        }
    }
}
