namespace JXTNext.Sitefinity.Widgets.Content.Mvc.Models.Button
{
    /// <summary>
    /// The view model for the detail page of <see cref="ButtonController"/>
    /// </summary>
    public class ButtonViewModel
    {
        /// <summary>
        /// Gets or sets the button label.
        /// </summary>
        public string ButtonText { get; set; }

        /// <summary>
        /// Gets or sets the button alignment.
        /// </summary>
        public string ButtonAlignment { get; set; }

        /// <summary>
        /// Gets or sets the button css class.
        /// </summary>
        public string CssClass { get; set; }

        /// <summary>
        /// Gets or sets the button target.
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// Gets or sets the action url.
        /// </summary>
        public string ActionUrl { get; set; }
    }
}
