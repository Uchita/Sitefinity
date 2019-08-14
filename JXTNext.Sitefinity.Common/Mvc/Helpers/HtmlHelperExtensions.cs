using System;
using System.Web.Mvc;

namespace JXTNext.Sitefinity.Common.Mvc.Helpers
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Builds a HTML element to enclose the supplied text. 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="headingElement">The HTML element to use</param>
        /// <param name="innerHtml">The text or inner html</param>
        /// <param name="cssClass">The CssClass to apply to the element</param>
        /// <returns></returns>
        public static DynamicTag DynamicTag(this HtmlHelper htmlHelper, string headingElement, string innerHtml, string cssClass = null)
        {
            if(headingElement.IsNullOrWhitespace())
            {
                headingElement = "div";
            }

            return innerHtml.IsNullOrWhitespace() ? null : new DynamicTag(headingElement.ToLower(), innerHtml, cssClass);
        }
    }
}
