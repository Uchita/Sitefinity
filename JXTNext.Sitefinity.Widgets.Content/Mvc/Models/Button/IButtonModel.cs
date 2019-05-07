using System;

namespace JXTNext.Sitefinity.Widgets.Content.Mvc.Models.Button
{
    public interface IButtonModel
    {
        /// <summary>
        /// Gets or sets the button label.
        /// </summary>
        string ButtonText { get; set; }

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
        /// Gets or sets the button alignment.
        /// </summary>
        string ButtonAlignment { get; set; }

        /// <summary>
        /// Gets or sets the button style.
        /// </summary>
        string ButtonStyle { get; set; }

        /// <summary>
        /// Gets or sets the button colour.
        /// </summary>
        string ButtonColour { get; set; }

        /// <summary>
        /// Gets or sets the button target.
        /// </summary>
        string Target { get; set; }

        /// <summary>
        /// Gets or sets whether the button is expanded or not.
        /// </summary>
        bool Expanded { get; set; }

        /// <summary>
        /// Gets or sets the custom css classes.
        /// </summary>
        string CssClass { get; set; }

        /// <summary>
        /// Gets the linked page URL.
        /// </summary>
        /// <returns></returns>
        string GetLinkedUrl();

        /// <summary>
        /// Gets the space separated list of css classes depending on various selections.
        /// </summary>
        /// <returns></returns>
        string GetCssClasses();

        /// <summary>
        /// Checks if the model is empty.
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// Gets the view model.
        /// </summary>
        /// <returns></returns>
        ButtonViewModel GetViewModel();
    }
}
