using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Security.Events;
using Telerik.Sitefinity.Security.Model;

namespace JXTNext.Sitefinity.Widgets.User.Mvc.Models
{
    public class JXTNext_UserEventHandler
    {
        public void UserCreating(UserCreating eventinfo)
        {
            UserProfileManager userProfileManager = UserProfileManager.GetManager();
            SitefinityProfile profile = userProfileManager.GetUserProfile(eventinfo.User.Id, typeof(SitefinityProfile).FullName) as SitefinityProfile;
            

            JXTNext_MemberRegister memberReg = new JXTNext_MemberRegister
            {
                Email = eventinfo.Email,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Password = eventinfo.User.Password
            };

            bool registerSuccess = _businessLogicsConnector.MemberRegister(memberReg, out string errorMessage);

            if (!registerSuccess)
            {
                eventinfo.IsApproved = false;
            }
        }
    }
}
