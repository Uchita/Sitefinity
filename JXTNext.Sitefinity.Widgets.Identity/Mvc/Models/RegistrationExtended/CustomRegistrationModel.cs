using JXTNext.Sitefinity.Common.Models;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Mappers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using JXTNext.Sitefinity.Widgets.User.Mvc.Models;
using System.Collections.Generic;
using System.Web.Security;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Frontend.Identity.Mvc.Models.Registration;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Security.Model;

namespace JXTNext.Sitefinity.Widgets.Identity.Mvc.Models.RegistrationExtended
{
    public class CustomRegistrationModel : RegistrationModel
    {
        public override MembershipCreateStatus RegisterUser(RegistrationViewModel viewModel)
        {
            var userManager = UserManager.GetManager(this.MembershipProviderName);
            Telerik.Sitefinity.Security.Model.User user;
            MembershipCreateStatus status;
            using (new ElevatedModeRegion(userManager))
            {
                if (this.TryCreateUser(userManager, viewModel, out user, out status))
                {
                    userManager.SaveChanges();

                    this.CreateUserProfiles(user, viewModel.Profile);

                    this.AssignRolesToUser(user);

                    this.ConfirmRegistration(userManager, user);
                    //this.ExecuteUserProfileSuccessfullUpdateActions();
                }

                if (status == MembershipCreateStatus.DuplicateUserName)
                {
                    IEnumerable<IJobListingMapper> jobListingMappers = new List<IJobListingMapper> { new JXTNext_JobListingMapper() };
                    IEnumerable<IMemberMapper> memberMappers = new List<IMemberMapper> { new JXTNext_MemberMapper() };
                    IRequestSession requestSession = new SFEventRequestSession { UserEmail = viewModel.Email };

                    IBusinessLogicsConnector blConnector = new JXTNextBusinessLogicsConnector(jobListingMappers, memberMappers, requestSession);
                    var res = blConnector.GetMemberByEmail(viewModel.Email);
                    if (res.Member == null)
                    {
                        Telerik.Sitefinity.Security.Model.User existingUser = JXTNext.Sitefinity.Common.Helpers.SitefinityHelper.GetUserByEmail(viewModel.Email);
                        UserProfileManager userProfileManager = UserProfileManager.GetManager();
                        UserProfile profile = userProfileManager.GetUserProfile(existingUser.Id, typeof(SitefinityProfile).FullName);
                        var fName = Telerik.Sitefinity.Model.DataExtensions.GetValue(profile, "FirstName");
                        var lName = Telerik.Sitefinity.Model.DataExtensions.GetValue(profile, "LastName");
                        JXTNext_MemberRegister memberReg = new JXTNext_MemberRegister
                        {
                            Email = existingUser.Email,
                            FirstName = fName.ToString(),
                            LastName = lName.ToString(),
                            Password = existingUser.Password
                        };

                        blConnector.MemberRegister(memberReg, out string errorMessage);
                    }

                }
            }

            return status;
        }
    }
}
