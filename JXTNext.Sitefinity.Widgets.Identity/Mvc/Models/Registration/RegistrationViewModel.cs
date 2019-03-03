﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using JXTNext.Sitefinity.Widgets.Identity.Mvc.StringResources;


namespace JXTNext.Sitefinity.Widgets.Identity.Mvc.Models.Registration
{
    [Bind(Exclude = "CssClass, LoginPageUrl, MembershipProviderName, SuccessfulRegistrationPageUrl, ConfirmationPageId, EmailAddressShouldBeTheUsername")]
    public class RegistrationViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationViewModel"/> class.
        /// </summary>
        public RegistrationViewModel()
        {
            this.Profile = new Dictionary<string, string>();
        }

        /// <summary>
        /// Holds the login page to be redirected, when clicking Log in
        /// </summary>
        public string LoginPageUrl { get; set; }

        /// <summary>
        /// Gets or sets the css class that will be applied on the wrapping element of the widget.
        /// </summary>
        public string CssClass { get; set; }

        /// <summary>
        /// Gets or sets the name of the membership provider.
        /// </summary>
        /// <value>
        /// The name of the membership provider.
        /// </value>
        public string MembershipProviderName { get; set; }

        /// <summary>
        /// Gets or sets the URL of the page that will be opened on successful registration.
        /// </summary>
        /// <value>
        /// The successful registration page URL.
        /// </value>
        public string SuccessfulRegistrationPageUrl { get; set; }

        /// <summary>
        /// Gets or sets the id of the page that will be used to confirm the registration.
        /// </summary>
        /// <value>The confirmation page id.</value>
        public virtual Guid? ConfirmationPageId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the membership provider settings require question and answer for reset/retrieval password functionality.
        /// </summary>
        /// <value>
        /// <c>true</c> if the membership provider requires question and answer; otherwise, <c>false</c>.
        /// </value>
        public bool RequiresQuestionAndAnswer { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required]
        [Display(Name = "Password", ResourceType = typeof(RegistrationStaticResources))]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the question.
        /// </summary>
        /// <value>
        /// The question.
        /// </value>
        [Display(Name = "Question", ResourceType = typeof(RegistrationStaticResources))]
        public string Question { get; set; }

        /// <summary>
        /// Gets or sets the answer.
        /// </summary>
        /// <value>
        /// The answer.
        /// </value>
        [Display(Name = "Answer", ResourceType = typeof(RegistrationStaticResources))]
        public string Answer { get; set; }

        /// <summary>
        /// Gets or sets the password confirmation value.
        /// </summary>
        /// <value>
        /// The retyped password.
        /// </value>
        [System.Web.Mvc.Compare("Password")]
        [Display(Name = "ReTypePassword", ResourceType = typeof(RegistrationStaticResources))]
        public string ReTypePassword { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email", ResourceType = typeof(RegistrationStaticResources))]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the profile object.
        /// </summary>
        /// <value>
        /// The profile.
        /// </value>
        public IDictionary<string, string> Profile { get; private set; }

        /// <summary>
        /// Gets or sets the external providers.
        /// </summary>
        /// <value>
        /// External providers.
        /// </value>
        public IDictionary<string, string> ExternalProviders { get; set; }
    }
}