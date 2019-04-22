using SfImage = Telerik.Sitefinity.Libraries.Model.Image;

namespace JXTNext.Sitefinity.Widgets.Content.Mvc.Models.PageBanner
{
    public class PageBannerViewModel
    {
        /// <summary>
        /// Gets or sets the heading.
        /// </summary>
        public string Heading { get; set; }

        /// <summary>
        /// Gets or sets the HTML description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the selected image.
        /// </summary>
        public SfImage Image { get; set; }

        /// <summary>
        /// Gets or sets the selected size image URL.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets whether the current page is the homepage.
        /// </summary>
        public bool IsHomepage { get; set; }

        /// <summary>
        /// Gets or sets the css classes.
        /// </summary>
        public string CssClass { get; set; }

        /// <summary>
        /// Gets or sets the widget's css class.
        /// </summary>
        public string DefaultCssClass { get; set; }
    }
}
