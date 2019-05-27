using System.Collections.Generic;

namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Models.AddThis
{
    public class AddThisViewModel
    {
        /// <summary>
        /// Gets or sets the publisher id.
        /// </summary>
        public string PublisherId { get; set; }

        /// <summary>
        /// Gets or sets the css class.
        /// </summary>
        public string CssClass { get; set; }

        /// <summary>
        /// Gets or sets the configured services.
        /// </summary>
        public ICollection<AddThisButtonModel> ServiceButtons { get; set; }
    }
}
