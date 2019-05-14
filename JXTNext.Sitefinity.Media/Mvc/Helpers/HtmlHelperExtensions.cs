using System;
using System.Web.Mvc;
using Telerik.Sitefinity.Frontend.Mvc.Models;
using Telerik.Sitefinity.Libraries.Model;

namespace JXTNext.Sitefinity.Media.Mvc.Helpers
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Builds an image tag for the specified image.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper which this method is extending.</param>
        /// <param name="imagePath">The path to the image.</param>
        /// <param name="altText">The alternative text for the image.</param>
        /// <returns></returns>
        public static ImgTag ImgTag(this HtmlHelper htmlHelper, string imagePath, string altText)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);

            return imagePath.IsNullOrWhitespace() ? null : new ImgTag(imagePath, altText, urlHelper.Content);
        }

        /// <summary>
        /// Builds an image tag from the specific Sitefinity image.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper which this method is extending.</param>
        /// <param name="image">The Sitefinity image item.</param>
        /// <param name="altText">Optional: The alternative text for the image. Will used the image's alternative text field if left blank.</param>
        /// <param name="thumbnailName">Optional: The name of the thumbnail profile.</param>
        /// <returns></returns>
        public static ImgTag ImgTag(this HtmlHelper htmlHelper, Image image, string altText = null, string thumbnailName = null)
        {
            var imagePath = String.Empty;

            if(image != null)
            {
                imagePath = ImageHelper.GetImageUrl(image, thumbnailName);
                if (altText.IsNullOrWhitespace())
                {
                    altText = image.AlternativeText;
                }
            }

            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);

            return imagePath.IsNullOrWhitespace() ? null : new ImgTag(imagePath, altText, urlHelper.Content);
        }

        /// <summary>
        /// Builds an image tag from the specific Sitefinity image using a dynamic field.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper which this method is extending.</param>
        /// <param name="imageField">The ItemViewModel for the dynamic field containing the single image.</param>
        /// <param name="altText">Optional: The alternative text for the image. Will used the image's alternative text field if left blank.</param>
        /// <param name="thumbnailName">Optional: The name of the thumbnail profile.</param>
        /// <returns></returns>
        public static ImgTag ImgTag(this HtmlHelper htmlHelper, ItemViewModel imageField, string altText =  null, string thumbnailName = null)
        {
            var imagePath = String.Empty;

            if (imageField != null && imageField.DataItem.GetType() == typeof(Image))
            {
                var image = (Image)imageField.DataItem;
                imagePath = ImageHelper.GetImageUrl(image, thumbnailName);

                if(altText.IsNullOrWhitespace())
                {
                    altText = image.AlternativeText;
                }
            }

            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);

            return imagePath.IsNullOrWhitespace() ? null : new ImgTag(imagePath, altText, urlHelper.Content);
        }

    }
}
