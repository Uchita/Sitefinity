using JXTNext.Sitefinity.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Security.Claims;
using Telerik.Sitefinity.Security.Model;

namespace SitefinityWebApp.Models
{
    public class SFRequestSession : IRequestSession
    {
        private bool _userEmailChecked = false;
        private string _userEmail = null;

        public string Domain => HttpContext.Current.Request.Url.Host;
        public string UserEmail
        {
            get
            {
                //prevent multiple processing of null
                if (!_userEmailChecked)
                {
                    var identity = ClaimsManager.GetCurrentIdentity();
                    var currentUserGuid = identity.UserId;

                    if (currentUserGuid != Guid.Empty)
                    {
                        UserProfileManager profileManager = UserProfileManager.GetManager();
                        UserManager userManager = UserManager.GetManager("Default");
                        User user = userManager.GetUser(currentUserGuid);

                        if (user != null)
                            _userEmail = user.Email;
                    }

                    _userEmailChecked = true;
                }

                return _userEmail;
            }
        }

    }
}
