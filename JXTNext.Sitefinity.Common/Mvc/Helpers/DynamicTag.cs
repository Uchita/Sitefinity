using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Web.UI;

namespace JXTNext.Sitefinity.Common.Mvc.Helpers
{
    public class DynamicTag : IHtmlString
    {
        private readonly string _innerHtml;
        private readonly string _htmlElement;
        private readonly IDictionary<string, string> _htmlAttributes;

        public DynamicTag(string htmlElement, string innerHtml, string cssClass)
        {
            _innerHtml = innerHtml;
            _htmlElement = htmlElement;
            _htmlAttributes = new Dictionary<string, string>();

            if(!cssClass.IsNullOrWhitespace())
            {
                _htmlAttributes["class"] = cssClass;
            }
        }

        public string ToHtmlString()
        {
            var htmlTag = new TagBuilder(_htmlElement);

            foreach (KeyValuePair<string, string> attribute in _htmlAttributes)
            {
               htmlTag.Attributes[attribute.Key] = attribute.Value;
            }

            htmlTag.InnerHtml = ControlUtilities.Sanitize(_innerHtml);

            return htmlTag.ToString(TagRenderMode.Normal);
        }
    }
}
