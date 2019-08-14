using System.Web;
using JXTNext.Sitefinity.Widgets.Authentication.Mvc.Models.UsersListExtended;
using Telerik.Sitefinity.Frontend.Mvc.Models;
using Telerik.Sitefinity.Security.Model;

namespace JXTNext.Sitefinity.Widgets.Authentication.Mvc.HelpersExtended
{
    /// <summary>
    /// This class contains helper method for working with users.
    /// </summary>
    public static class UsersHelperExtended
    {
        /// <summary>
        /// Encode username in the url
        /// </summary>
        /// <param name="url">Input URL</param>
        /// <param name="user">User profile data</param>
        /// <returns></returns>
        public static string EncodeUrlUsername(string url, SitefinityProfileItemExtendedViewModel user)
        {
            if (user == null || user.DataItem == null)
            {
                return url;
            }
           
            var username = (user.DataItem as UserProfile).User.UserName;
            return url.Replace(username, HttpUtility.UrlEncode(username));
        }
    }
}
