﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Security.Model;

namespace JXTNext.Sitefinity.Widgets.Authentication.Mvc.Models.JXTNextProfile
{
    /// <summary>
    /// This class represents view model for Profile widget.
    /// </summary>
    public class JXTNextProfilePreviewViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProfilePreviewViewModel"/> class.
        /// </summary>
        public JXTNextProfilePreviewViewModel()
        {
            this.SelectedUserProfiles = new List<CustomJXTNextProfileViewModel>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfilePreviewViewModel"/> class.
        /// </summary>
        /// <param name="userProfile">The user profile.</param>
        public JXTNextProfilePreviewViewModel(IList<UserProfile> userProfiles)
        {
            if (userProfiles != null && userProfiles.Count() > 0)
            {
                this.InitializeUserRelatedData(userProfiles.First().User);
            }

            this.SelectedUserProfiles = new List<CustomJXTNextProfileViewModel>();
            foreach (var item in userProfiles)
            {
                this.SelectedUserProfiles.Add(new CustomJXTNextProfileViewModel(item));
            }
        }

        /// <summary>
        /// Gets the selected user profiles.
        /// </summary>
        /// <value>
        /// The selected user profiles.
        /// </value>
        public IList<CustomJXTNextProfileViewModel> SelectedUserProfiles { get; private set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the profile can be edited.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [can edit]; otherwise, <c>false</c>.
        /// </value>
        public bool CanEdit { get; set; }

        /// <summary>
        /// Gets or sets the css class that will be applied on the wrapping element of the widget.
        /// </summary>
        /// <value>
        /// The css class value as a string.
        /// </value>
        public string CssClass { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        /// <value>
        /// The user name.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the avatar image URL.
        /// </summary>
        /// <value>
        /// The avatar image URL.
        /// </value>
        public string AvatarImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the about field.
        /// </summary>
        /// <value>
        /// The avatar image URL.
        /// </value>
        public string About { get; set; }

        /// <summary>
        /// Gets or sets the nickname.
        /// </summary>
        /// <value>
        /// The avatar image URL.
        /// </value>
        public string Nickname { get; set; }

        /// <summary>
        /// Initializes the user related data.
        /// </summary>
        /// <param name="user">The user.</param>
        private void InitializeUserRelatedData(User user)
        {
            this.User = user;
            this.Email = this.User.Email;
            this.UserName = this.User.UserName;
            Telerik.Sitefinity.Libraries.Model.Image avatarImage;
            var displayNameBuilder = new SitefinityUserDisplayNameBuilder();
            this.DisplayName = displayNameBuilder.GetUserDisplayName(this.User.Id);
            this.AvatarImageUrl = displayNameBuilder.GetAvatarImageUrl(this.User.Id, out avatarImage);
            this.Nickname = displayNameBuilder.GetUserNickname(this.User.Id);
            this.About = displayNameBuilder.GetAboutInfo(this.User.Id);
        }
    }
}
