﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Identity.LoginStatusExtended.Mvc.Models
{
    /// <summary>
    /// This interface is used as a model for the LoginStatusController.
    /// </summary>
    public interface ILoginStatusExtendedModel
    {
        /// <summary>
        /// Gets or sets the login page identifier.
        /// </summary>
        /// <value>
        /// The login page identifier.
        /// </value>
        Guid? LoginPageId { get; set; }

        /// <summary>
        /// Gets or sets the logout page identifier.
        /// </summary>
        /// <value>
        /// The logout page identifier.
        /// </value>
        Guid? LogoutPageId { get; set; }

        /// <summary>
        /// Gets or sets the registration page identifier.
        /// </summary>
        /// <value>
        /// The registration page identifier.
        /// </value>
        Guid? RegistrationPageId { get; set; }

        /// <summary>
        /// Gets or sets the profile page identifier.
        /// </summary>
        /// <value>
        /// The profile page identifier.
        /// </value>
        Guid? ProfilePageId { get; set; }

        /// <summary>
        /// Gets or sets the profile page identifier.
        /// </summary>
        /// <value>
        /// The profile page identifier.
        /// </value>
        Guid? JobAlertPageId { get; set; }

        /// <summary>
        /// Gets or sets the external login page url.
        /// </summary>
        /// <value>
        /// The external login page url.
        /// </value>
        string ExternalLoginUrl { get; set; }

        /// <summary>
        /// Gets or sets the external logout page url.
        /// </summary>
        /// <value>
        /// The external logout page url.
        /// </value>
        string ExternalLogoutUrl { get; set; }

        /// <summary>
        /// Gets or sets the allow Windows STS login.
        /// </summary>
        ///   <c>true</c> if Windows STS login is allowed; otherwise, <c>false</c>.
        /// </value>
        bool AllowWindowsStsLogin { get; set; }

        /// <summary>
        /// Gets or sets the external registartion page url.
        /// </summary>
        /// <value>
        /// The external registration page url.
        /// </value>
        string ExternalRegistrationUrl { get; set; }

        /// <summary>
        /// Gets or sets the external profile page url.
        /// </summary>
        /// <value>
        /// The external profile page url.
        /// </value>
        string ExternalProfileUrl { get; set; }

        /// <summary>
        /// Gets or sets the css class that will be applied on the wrapping element of the widget.
        /// </summary>
        /// <value>
        /// The css class value as a string.
        /// </value>
        string CssClass { get; set; }

        /// <summary>
        /// Gets the view model.
        /// </summary>
        /// <returns>
        /// A instance of <see cref="LoginStatusViewModel"/> as view model.
        /// </returns>
        LoginStatusExtendedViewModel GetViewModel();

        /// <summary>
        /// Gets the user status view model.
        /// </summary>
        /// <returns>
        /// A instance of <see cref="StatusViewModel"/> as view model.
        /// </returns>
        StatusExtendedViewModel GetStatusViewModel();

        /// <summary>
        /// Gets the login redirect URL.
        /// </summary>
        /// <returns>
        /// The login redirect url as a string.
        /// </returns>
        string GetLoginPageUrl();

        /// <summary>
        /// Gets the redirect url to be used after logout.
        /// </summary>
        /// <returns>
        /// The logout redirect url as a string.
        /// </returns>
        string GetLogoutPageUrl();

        /// <summary>
        /// Gets the redirect url to be used for registration page.
        /// </summary>
        /// <returns>
        /// The registration page url as a string.
        /// </returns>
        string GetRegistrationPageUrl();

        /// <summary>
        /// Gets the redirect url to be used for profile page.
        /// </summary>
        /// <returns>
        /// The profile page url as a string.
        /// </returns>
        string GetProfilePageUrl();

        /// <summary>
        /// Gets the redirect url to be used for job alert page.
        /// </summary>
        /// <returns>
        /// The job alert page url as a string.
        /// </returns>
        string GetJobAlertPageUrl();
    }
}
