﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace JXTNext.Sitefinity.Widgets.Identity.Mvc.StringResources
{
    /// <summary>
    /// Localizable strings for the Change Password widget
    /// </summary>
    [ObjectInfo(typeof(ChangePasswordResources), ResourceClassId = "ChangePasswordResources", Title = "ChangePasswordResourcesTitle", Description = "ChangePasswordResourcesDescription")]
    public class ChangePasswordResources : Resource
    {
        #region Constructors

        /// <summary>
        /// Initializes new instance of <see cref="ChangePasswordResources"/> class with the default <see cref="ResourceDataProvider"/>.
        /// </summary>
        public ChangePasswordResources()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePasswordResources"/> class.
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public ChangePasswordResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        {
        }

        #endregion

        #region Class Description

        /// <summary>
        /// Gets Title for the Change password widget resources class.
        /// </summary>
        [ResourceEntry("ChangePasswordResourcesTitle",
            Value = "Change password widget resources",
            Description = "Title for the Change password widget resources class.",
            LastModified = "2015/03/30")]
        public string ChangePasswordResourcesTitle
        {
            get
            {
                return this["ChangePasswordResourcesTitle"];
            }
        }

        /// <summary>
        /// Gets Description for the Change password widget resources class.
        /// </summary>
        [ResourceEntry("ChangePasswordResourcesDescription",
            Value = "Localizable strings for the Change password widget.",
            Description = "Description for the Change password widget resources class.",
            LastModified = "2015/03/30")]
        public string ChangePasswordResourcesDescription
        {
            get
            {
                return this["ChangePasswordResourcesDescription"];
            }
        }

        #endregion

        #region Index

        /// <summary>
        /// Gets phrase : You need to be logged in to change your password
        /// </summary>
        [ResourceEntry("LogInFirst",
            Value = "You need to be logged in to change your password",
            Description = "phrase : You need to be logged in to change your password",
            LastModified = "2015/03/02")]
        public string LogInFirst
        {
            get
            {
                return this["LogInFirst"];
            }
        }

        /// <summary>
        /// Gets phrase : Your password is successfully changed
        /// </summary>
        [ResourceEntry("ChangePasswordSuccess",
            Value = "Your password is successfully changed",
            Description = "phrase : Your password is successfully changed",
            LastModified = "2015/03/02")]
        public string ChangePasswordSuccess
        {
            get
            {
                return this["ChangePasswordSuccess"];
            }
        }

        /// <summary>
        /// Gets phrase : Change Password
        /// </summary>
        [ResourceEntry("ChangePasswordHeader",
            Value = "Change Password",
            Description = "phrase : Change Password",
            LastModified = "2015/03/02")]
        public string ChangePasswordHeader
        {
            get
            {
                return this["ChangePasswordHeader"];
            }
        }

        /// <summary>
        /// Gets phrase : Current password
        /// </summary>
        [ResourceEntry("ChangePasswordOldPassword",
            Value = "Current password",
            Description = "phrase : Current password",
            LastModified = "2016/12/23")]
        public string ChangePasswordOldPassword
        {
            get
            {
                return this["ChangePasswordOldPassword"];
            }
        }

        /// <summary>
        /// Gets phrase : New password
        /// </summary>
        [ResourceEntry("ChangePasswordNewPassword",
            Value = "New password",
            Description = "phrase : New password",
            LastModified = "2015/03/02")]
        public string ChangePasswordNewPassword
        {
            get
            {
                return this["ChangePasswordNewPassword"];
            }
        }
        
        /// <summary>
        /// Gets phrase : Repeat new Password
        /// </summary>
        [ResourceEntry("ChangePasswordRepeatPassword",
            Value = "Repeat new password",
            Description = "phrase : Repeat new password",
            LastModified = "2015/03/10")]
        public string ChangePasswordRepeatPassword
        {
            get
            {
                return this["ChangePasswordRepeatPassword"];
            }
        }

        /// <summary>
        /// Gets phrase : Save
        /// </summary>
        [ResourceEntry("ChangePasswordSaveButton",
            Value = "Save",
            Description = "phrase : Save",
            LastModified = "2015/03/02")]
        public string ChangePasswordSaveButton
        {
            get
            {
                return this["ChangePasswordSaveButton"];
            }
        }

        #endregion

        #region SetChangePassword



        /// </summary>
        /// Gets phrase : Both passwords must match.
        /// </summary>
        [ResourceEntry("ChangePasswordNonMatchingPasswordsMessage",
            Value = "Both passwords must match.",
            Description = "phrase : Both passwords must match.",
            LastModified = "2015/03/02")]
        public string ChangePasswordNonMatchingPasswordsMessage
        {
            get
            {
                return this["ChangePasswordNonMatchingPasswordsMessage"];
            }
        }

        /// </summary>
        /// Gets phrase : This field is required.
        /// </summary>
        [ResourceEntry("ChangePasswordRequiredErrorMessage",
            Value = "This field is required.",
            Description = "phrase : This field is required.",
            LastModified = "2015/03/03")]
        public string ChangePasswordRequiredErrorMessage
        {
            get
            {
                return this["ChangePasswordRequiredErrorMessage"];
            }
        }

        /// </summary>
        /// Gets phrase : Invalid data.
        /// </summary>
        [ResourceEntry("ChangePasswordGeneralErrorMessage",
            Value = "Invalid data.",
            Description = "phrase : Invalid data.",
            LastModified = "2015/03/02")]
        public string ChangePasswordGeneralErrorMessage
        {
            get
            {
                return this["ChangePasswordGeneralErrorMessage"];
            }
        }

        #endregion

        #region DesignerView

        /// <summary>
        /// Gets phrase : CSS classes
        /// </summary>
        [ResourceEntry("CssClasses",
            Value = "CSS classes",
            Description = "phrase : CSS classes",
            LastModified = "2015/03/02")]
        public string CssClasses
        {
            get
            {
                return this["CssClasses"];
            }
        }

        /// <summary>
        /// Gets phrase : More options
        /// </summary>
        [ResourceEntry("MoreOptions",
            Value = "More options",
            Description = "phrase : More options",
            LastModified = "2015/03/03")]
        public string MoreOptions
        {
            get
            {
                return this["MoreOptions"];
            }
        }

        /// <summary>
        /// Gets phrase : Template
        /// </summary>
        [ResourceEntry("Template",
            Value = "Template",
            Description = "phrase : Template",
            LastModified = "2015/03/03")]
        public string Template
        {
            get
            {
                return this["Template"];
            }
        }

        /// <summary>
        /// Gets phrase : After change users will be redirected to...
        /// </summary>
        [ResourceEntry("PasswordChangeCompleteAction",
            Value = "After change users will be redirected to...",
            Description = "phrase : After change users will be redirected to...",
            LastModified = "2015/03/03")]
        public string PasswordChangeCompleteAction
        {
            get
            {
                return this["PasswordChangeCompleteAction"];
            }
        }

        /// <summary>
        /// Gets phrase : Show message
        /// </summary>
        [ResourceEntry("PasswordChangeShowMessage",
            Value = "Show message",
            Description = "phrase : Show message",
            LastModified = "2015/03/03")]
        public string PasswordChangeShowMessage
        {
            get
            {
                return this["PasswordChangeShowMessage"];
            }
        }

        /// <summary>
        /// Gets phrase : Open a specially prepared page...
        /// </summary>
        [ResourceEntry("PasswordChangeRedirectToPage",
            Value = "Open a specially prepared page...",
            Description = "phrase : Open a specially prepared page...",
            LastModified = "2015/03/03")]
        public string PasswordChangeRedirectToPage
        {
            get
            {
                return this["PasswordChangeRedirectToPage"];
            }
        }

        /// <summary>
        /// Gets phrase : Your profile do not store any passwords, because you're registered with {0}
        /// </summary>
        [ResourceEntry("ExternalProviderMessage",
            Value = "Your profile do not store any passwords, because you're registered with {0}",
            Description = "phrase : Your profile do not store any passwords, because you're registered with {0}",
            LastModified = "2016/12/16")]
        public string ExternalProviderMessage
        {
            get
            {
                return this["ExternalProviderMessage"];
            }
        }

        #endregion
    }
}
