using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Web;

namespace JXTNext.Sitefinity.Widgets.Content.Mvc.Models.Button
{
    /// <summary>
    /// Provides API for working with button items.
    /// </summary>
    public class ButtonModel : IButtonModel
    {
        public const string LinkToPage = "page";
        public const string LinkToUrl = "url";
        public const string LinkToAnchor = "anchor";

        public string ButtonText { get; set; }

        public string LinkTo { get; set; }

        public Guid LinkedPageId { get; set; }

        public string LinkedUrl { get; set; }

        public string LinkedAnchor { get; set; }

        public string ButtonStyle { get; set; }

        public string ButtonColour { get; set; }

        public string ButtonAlignment { get; set; }

        public string Target { get; set; }

        public bool Expanded { get; set; }

        public string ButtonClassPrefix { get; set; }

        public string CssClass { get; set; }

        public string ButtonSize { get; set; }

        public string GetLinkedUrl()
        {
            var linkTo = string.IsNullOrWhiteSpace(this.LinkTo) ? LinkToPage : this.LinkTo;

            if (linkTo == LinkToPage)
            {
                if (this.LinkedPageId == Guid.Empty)
                    return null;

                var siteMap = SiteMapBase.GetCurrentProvider();
                var siteMapNode = siteMap.FindSiteMapNodeFromKey(LinkedPageId.ToString()) as PageSiteNode;

                if (siteMapNode != null)
                {
                    string relativeUrl = siteMapNode.GetUrl(CultureInfo.CurrentUICulture, true);

                    return UrlPath.ResolveUrl(relativeUrl, Config.Get<SystemConfig>().SiteUrlSettings.GenerateAbsoluteUrls);
                }
            }
            else if (linkTo == LinkToUrl)
            {
                if (!string.IsNullOrEmpty(this.LinkedUrl))
                {
                    return this.LinkedUrl;
                }
            }
            else if (linkTo == LinkToAnchor)
            {
                if (!string.IsNullOrEmpty(this.LinkedAnchor))
                {
                    return this.LinkedAnchor;
                }
            }

            return null;
        }

        public string GetCssClasses()
        {
            var cssClasses = new List<string>();

            var classPrefix = string.IsNullOrWhiteSpace(ButtonClassPrefix) ? "btn" : ButtonClassPrefix;

            cssClasses.Add(classPrefix);

            if (!string.IsNullOrWhiteSpace(ButtonStyle))
            {
                cssClasses.Add(classPrefix + "-" + ButtonStyle);
            }

            if (!string.IsNullOrWhiteSpace(ButtonColour))
            {
                cssClasses.Add(classPrefix + "-" + ButtonColour);
            }

            if (!string.IsNullOrWhiteSpace(ButtonSize))
            {
                cssClasses.Add(classPrefix + "-" + ButtonSize);
            }

            if (Expanded)
            {
                cssClasses.Add(classPrefix + "-block");
            }

            if (!string.IsNullOrWhiteSpace(CssClass))
            {
                cssClasses.Add(CssClass);
            }

            return string.Join(" ", cssClasses);
        }

        public bool IsEmpty()
        {
            return string.IsNullOrWhiteSpace(ButtonText)
                && GetLinkedUrl().IsNullOrWhitespace();
        }

        public ButtonViewModel GetViewModel()
        {
            var viewModel = new ButtonViewModel()
            {
                ButtonText = ButtonText,
                ActionUrl = GetLinkedUrl(),
                ButtonAlignment = ButtonAlignment,
                Target = Target,
                CssClass = GetCssClasses()
            };

            return viewModel;
        }
    }
}
