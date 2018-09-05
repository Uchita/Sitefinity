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
            
            JXTNext_MemberRegister memberReg = new JXTNext_MemberRegister
            {
                Email = user.Email,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Password = user.Password
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
