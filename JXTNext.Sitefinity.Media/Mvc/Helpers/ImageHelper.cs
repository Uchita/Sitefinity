using System;
using System.Collections.Generic;
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
            var resolveAsAbsoluteUrl = Config.Get<SystemConfig>().SiteUrlSettings.GenerateAbsoluteUrls;
            if (thumbnailName.IsNullOrWhitespace())
            {
                return image.ResolveMediaUrl(resolveAsAbsoluteUrl);
            }
            else
            {
                return image.ResolveThumbnailUrl(thumbnailName, resolveAsAbsoluteUrl);
            }
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
