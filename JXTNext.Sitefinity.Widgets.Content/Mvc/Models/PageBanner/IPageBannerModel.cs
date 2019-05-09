using System;

namespace JXTNext.Sitefinity.Widgets.Content.Mvc.Models.PageBanner
{
    public interface IPageBannerModel
    {
        /// <summary>
        /// Gets or sets the css class.
        /// </summary>
        string CssClass { get; set; }

        /// <summary>
        /// Gets or sets the HTML description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the heading.
        /// </summary>
        string Heading { get; set; }

        /// <summary>
        /// Gets or sets the image identifier.
        /// </summary>
        Guid ImageId { get; set; }

        /// <summary>
        /// Gets or sets the name of the image provider.
        /// </summary>
        string ImageProviderName { get; set; }

        string ThumbnailName { get; set; }

        bool UsePageDescription { get; set; }

        bool UsePageTitle { get; set; }

        bool DisableHeading { get; set; }

        bool DisableDescription { get; set; }

        /// <summary>
        /// Gets or sets the heading's html element.
        /// </summary>
        string HeadingHtmlElement { get; set; }

        /// <summary>
        /// Gets or sets the heading's html element.
        /// </summary>
        string DescriptionHtmlElement { get; set; }

        /// <summary>
        /// Gets the view model.
        /// </summary>
        /// <returns></returns>
        PageBannerViewModel GetViewModel();

        /// <summary>
        /// Checks if the model is empty.
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();
    }
}