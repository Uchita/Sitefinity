using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.Authentication.Mvc.Models.LoginStatusExtended
{
    /// <summary>
    /// This class represents view model for status
    /// </summary>
    public class StatusExtendedViewModel
    {
        /// <summary>
        /// Gets or sets if the user is currently logged in.
        /// </summary>
        /// <value>
        /// The redirect url.
        /// </value>
        public bool IsLoggedIn { get; set; }

        /// <summary>
        /// Gets or sets the user email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the display name of the user.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the avatar image url of the user.
        /// </summary>
        /// <value>
        /// The avatar image url.
        /// </value>
        public string AvatarImageUrl { get; set; }
    }
}
