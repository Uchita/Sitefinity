using System.Collections.Generic;

namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Models.AddThis
{
    public interface IAddThisModel
    {
        /// <summary>
        /// Gets or sets the css class.
        /// </summary>
        string CssClass { get; set; }

        /// <summary>
        /// Gets or sets the publisher id.
        /// </summary>
        string PublisherId { get; set; }

        /// <summary>
        /// Gets the service buttons
        /// </summary>
        ICollection<AddThisButtonModel> ServiceButtons { get; }

        /// <summary>
        /// Gets the view model.
        /// </summary>
        /// <returns></returns>
        AddThisViewModel GetViewModel();

        /// <summary>
        /// Initialize the selected service options.
        /// </summary>
        void InitializeServiceButtons();

        /// <summary>
        /// Checks if the model is empty.
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();
    }
}
