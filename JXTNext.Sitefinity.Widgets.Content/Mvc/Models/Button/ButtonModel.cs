using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Modules;
using Telerik.Sitefinity.Modules.GenericContent;
using Telerik.Sitefinity.Modules.Libraries;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Web;
using SfImage = Telerik.Sitefinity.Libraries.Model.Image;

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

        public ButtonModel()
        {
            this.LinkTo = LinkToPage;
        }

        public string ButtonLabel { get; set; }

        public string LinkTo { get; set; }

        public Guid LinkedPageId { get; set; }

        public string LinkedUrl { get; set; }

        public string LinkedAnchor { get; set; }

        public string CssClass { get; set; }

        public string ButtonStyle { get; set; }

        public string ButtonColour { get; set; }

        public string ButtonAlignment { get; set; }

        public bool Expanded { get; set; }        

        public string GetLinkedUrl()
        {
            if (this.LinkTo == LinkToPage)
            {
                if (this.LinkedPageId == Guid.Empty)
                    return null;

                var pageManager = PageManager.GetManager();
                var node = pageManager.GetPageNode(this.LinkedPageId);
                if (node != null)
                {
                    string relativeUrl;
                    if (SystemManager.CurrentContext.AppSettings.Multilingual)
                    {
                        relativeUrl = node.GetFullUrl(CultureInfo.CurrentUICulture, false);
                    }
                    else
                    {
                        relativeUrl = node.GetFullUrl(null, false, true);
                    }

                    return UrlPath.ResolveUrl(relativeUrl, Config.Get<SystemConfig>().SiteUrlSettings.GenerateAbsoluteUrls);
                }
            }
            else if (this.LinkTo == LinkToUrl)
            {
                if (!string.IsNullOrEmpty(this.LinkedUrl))
                {
                    return this.LinkedUrl;
                }
            }
            else if (this.LinkTo == LinkToAnchor)
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

            cssClasses.Add("o-btn");

            if (!string.IsNullOrWhiteSpace(ButtonStyle))
            {
                cssClasses.Add("o-btn-" + ButtonStyle);
            }

            if (!string.IsNullOrWhiteSpace(ButtonColour))
            {
                cssClasses.Add("o-btn-" + ButtonColour);
            }

            if (Expanded)
            {
                cssClasses.Add("o-btn-expanded");
            }

            if (!string.IsNullOrWhiteSpace(CssClass))
            {
                cssClasses.Add(CssClass);
            }

            return string.Join(" ", cssClasses);
        }
    }
}
