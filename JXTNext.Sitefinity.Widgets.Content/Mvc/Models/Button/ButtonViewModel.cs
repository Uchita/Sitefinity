using Telerik.Sitefinity.Frontend.Mvc.Models;

namespace JXTNext.Sitefinity.Widgets.Content.Mvc.Models.Button
{
    /// <summary>
    /// The view model for the detail page of <see cref="ButtonController"/>
    /// </summary>
    public class ButtonViewModel : ContentDetailsViewModel
    {
        /// <summary>
        /// Gets or sets the heading.
        /// </summary>
        public string Heading { get; set; }

        /// <summary>
        /// Gets or sets the HTML.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the action name.
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// Gets or sets the action url.
        /// </summary>
        public string ActionUrl { get; set; }

        /// <summary>
        /// Gets or sets the image title.
        /// </summary>
        public string ImageTitle { get; set; }

        /// <summary>
        /// Gets or sets the image alternative text.
        /// </summary>
        public string ImageAlternativeText { get; set; }

        /// <summary>
        /// Gets or sets the selected size image URL.
        /// </summary>
        public string SelectedSizeUrl { get; set; }
    }
}
