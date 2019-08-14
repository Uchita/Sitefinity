using JXTNext.Sitefinity.Common.Helpers;
using System;
using System.Linq;
using System.Reflection;
using Telerik.Sitefinity.Frontend.Mvc.Models;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Security.Model;

namespace JXTNext.Sitefinity.Widgets.Authentication.Mvc.Models.UsersListExtended
{
    /// <summary>
    /// This class represents view model for sitefinity profile items.
    /// </summary>
    public class SitefinityProfileItemExtendedViewModel : ItemViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SitefinityProfileItemViewModel" /> class.
        /// </summary>
        /// <param name="dataItem">The data item.</param>
        public SitefinityProfileItemExtendedViewModel(IDataItem dataItem)
            : base(dataItem)
        {
            var sfProfile = dataItem as UserProfile;
            var displayNameBuilder = new SitefinityUserDisplayNameBuilder();
            Telerik.Sitefinity.Libraries.Model.Image avatarImage;
            this.AvatarImageUrl = displayNameBuilder.GetAvatarImageUrl(sfProfile.User.Id, out avatarImage);
            this.FirstName = SitefinityHelper.GetUserFirstNameById(sfProfile.User.Id);

            dynamic profile = sfProfile as dynamic;

            PropertyInfo[] pInfos = sfProfile.GetType().GetProperties();
            PropertyInfo aboutPropertyInfo = pInfos.Where(c => c.Name.ToUpper() == "ABOUT").FirstOrDefault();
            if (aboutPropertyInfo != null)
                this.About = aboutPropertyInfo.GetValue(sfProfile) as String;
        }

        /// <summary>
        /// Gets or sets the avatar image URL.
        /// </summary>
        /// <value>The avatar image URL.</value>
        public string AvatarImageUrl { get; private set; }

        /// <summary>
        /// Gets or sets the about.
        /// </summary>
        /// <value>The about.</value>
        public string About { get; private set; }

        /// <summary>
        /// Gets or sets the Firs tName.
        /// </summary>
        /// <value>The FirstName.</value>
        public string FirstName { get; private set; }
    }
}
