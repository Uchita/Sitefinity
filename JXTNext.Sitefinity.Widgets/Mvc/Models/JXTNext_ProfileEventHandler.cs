using JXTNext.Sitefinity.Common.Helpers;
using JXTNext.Sitefinity.Common.Models;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Mappers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Security.Events;
using Telerik.Sitefinity.Security.Model;

namespace JXTNext.Sitefinity.Widgets.User.Mvc.Models
{
    public class JXTNext_ProfileEventHandler
    {
        public void ProfileCreated(ProfileCreated eventinfo)
        {
            UserManager userManager = UserManager.GetManager();
            Telerik.Sitefinity.Security.Model.User user = userManager.GetUser(eventinfo.UserId);

            UserProfileManager userProfileManager = UserProfileManager.GetManager();
            SitefinityProfile profile = userProfileManager.GetUserProfile(user, eventinfo.ProfileType) as SitefinityProfile;

            // user.ExternalProviderName is null means registrating through normal registration
            // Otherwise registring through External provider like LinkedIn, Facebook, etc...
            // In case external provider, we will recieve the password as null but JXTNext Member database table requires
            // password should not be empty, so generating some random password of 8 characters length.
            JXTNext_MemberRegister memberReg = new JXTNext_MemberRegister
            {
                Email = user.Email,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Password = user.ExternalProviderName.IsNullOrEmpty() ? user.Password : GeneralHelper.GeneratePassword(8)
            };

            IEnumerable<IJobListingMapper> jobListingMappers = new List<IJobListingMapper> { new JXTNext_JobListingMapper() };
            IEnumerable<IMemberMapper> memberMappers = new List<IMemberMapper> { new JXTNext_MemberMapper() };
            IRequestSession requestSession = new SFEventRequestSession { UserEmail = user.Email };

            IBusinessLogicsConnector connector = new JXTNextBusinessLogicsConnector(jobListingMappers, memberMappers, requestSession);
            bool registerSuccess = connector.MemberRegister(memberReg, out string errorMessage);

            if (!registerSuccess)
            {
                //eventinfo.IsApproved = false;
            }
        }
    }
}
