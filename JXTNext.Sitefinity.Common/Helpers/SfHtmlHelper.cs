using System;

namespace JXTNext.Sitefinity.Common.Helpers
{

    /// <summary>
    /// Helepr method for HTML markup generation.
    /// </summary>
    public static class SfHtmlHelper
    {

        public static string BgImageCss(string imageUrl)
        {
            var style = string.Empty;
            if(!imageUrl.IsNullOrWhitespace())
            {
                 style = "background-image: url('" + imageUrl + "');";
            }

            return style;
        }

        public static string BgImageStyle(string imageUrl)
        {
            var style = string.Empty;
            if (!imageUrl.IsNullOrWhitespace())
            {
                style = string.Format("style=\"{0}\"", BgImageCss(imageUrl));
            }

            return style;
        }

        public static string CreateCssClass(string prefix, string suffix, bool requiresBothValues = true)
        {
            var cssClass = string.Empty;
            if(!requiresBothValues)
            {
                cssClass = prefix.Trim() + suffix.Trim();
            }
            else if(!prefix.IsNullOrWhitespace() && !suffix.IsNullOrWhitespace())
            {
                cssClass = prefix.Trim() + suffix.Trim();
            }

            return cssClass;
        }
    }
}
