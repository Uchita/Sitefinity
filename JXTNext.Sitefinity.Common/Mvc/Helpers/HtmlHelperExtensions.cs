using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Telerik.Sitefinity.Model;

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

        /// <summary>
        /// AddThis share options. Redirect to the AddThis control if exist else render error message
        /// </summary>
        /// <param name="helper">The HTML helper.</param>
        /// <param name="dataItem">The data item which we will be sharing</param>
        public static MvcHtmlString AddThisShareButtons(this HtmlHelper helper, IHasTitle dataItem)
        {
            MvcHtmlString mvcHtmlString;

            try
            {
                RouteValueDictionary routeValueDictionaries = new RouteValueDictionary()
                {
                    { "DataItem", dataItem }
                };

                mvcHtmlString = helper.Action("Index", "AddThis", routeValueDictionaries);
            }
            catch (HttpException httpException)
            {
                mvcHtmlString = new MvcHtmlString("The AddThis widget could not be found.");
            }

            return mvcHtmlString;
        }
    }
}
