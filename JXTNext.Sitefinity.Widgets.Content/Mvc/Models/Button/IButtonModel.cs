using System;

namespace JXTNext.Sitefinity.Widgets.Content.Mvc.Models.Button
{
    public interface IButtonModel
    {
        /// <summary>
        /// Gets or sets the button label.
        /// </summary>
        string ButtonLabel { get; set; }

        /// <summary>
        /// Gets or sets the link destination.
        /// </summary>
        string LinkTo { get; set; }

        /// <summary>
        /// Gets or sets the page identifier to use as link.
        /// </summary>
        Guid LinkedPageId { get; set; }

        /// <summary>
        /// Gets or sets the page url to use as link.
        /// </summary>
        string LinkedUrl { get; set; }

        /// <summary>
        /// Gets or sets the anchor to use as link.
        /// </summary>
        string LinkedAnchor { get; set; }

        /// <summary>
        /// Gets or sets the css class.
        /// </summary>
        string CssClass { get; set; }

        /// <summary>
        /// Gets the view model.
        /// </summary>
        /// <returns></returns>
        ButtonViewModel GetViewModel();
    }
}
