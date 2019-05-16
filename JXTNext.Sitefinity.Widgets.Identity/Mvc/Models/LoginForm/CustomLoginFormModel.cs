using System.Collections.Generic;
using System.Web;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Security.Model;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using Telerik.Sitefinity.Frontend.Identity.Mvc.Models.LoginForm;
using JXTNext.Sitefinity.Connector.BusinessLogics.Mappers;
using JXTNext.Sitefinity.Common.Models;
using JXTNext.Sitefinity.Widgets.User.Mvc.Models;

namespace JXTNext.Sitefinity.Widgets.Identity.Mvc.Models.LoginForm
{
    public class CustomLoginFormModel : LoginFormModel
    {
        //IBusinessLogicsConnector _blConnector;
        //public CustomLoginFormModel(IBusinessLogicsConnector blConnector) : base()
        //{
        //    _blConnector = blConnector;
        //}
        public override LoginFormViewModel Authenticate(LoginFormViewModel input, HttpContextBase context)
        {
            input.LoginError = false;

            var cmsUser = JXTNext.Sitefinity.Common.Helpers.SitefinityHelper.GetUserByEmail(input.UserName);
            if (cmsUser != null)
            {
                IEnumerable<IJobListingMapper> jobListingMappers = new List<IJobListingMapper> { new JXTNext_JobListingMapper() };
                IEnumerable<IMemberMapper> memberMappers = new List<IMemberMapper> { new JXTNext_MemberMapper() };
                IRequestSession requestSession = new SFEventRequestSession { UserEmail = input.UserName };

                IBusinessLogicsConnector connector = new JXTNextBusinessLogicsConnector(jobListingMappers, memberMappers, requestSession);

                var memberResponse = connector.GetMemberByEmail(input.UserName);
                if (memberResponse.Member == null)
                {
                    UserProfileManager userProfileManager = UserProfileManager.GetManager();
                    UserProfile profile = userProfileManager.GetUserProfile(cmsUser.Id, typeof(SitefinityProfile).FullName);
                    var fName = Telerik.Sitefinity.Model.DataExtensions.GetValue(profile, "FirstName");
                    var lName = Telerik.Sitefinity.Model.DataExtensions.GetValue(profile, "LastName");
                    JXTNext_MemberRegister memberReg = new JXTNext_MemberRegister
                    {
                        Email = input.UserName,
                        FirstName = fName.ToString(),
                        LastName = lName.ToString(),
                        Password = input.UserName
                    };

                    if (connector.MemberRegister(memberReg, out string errorMessage))
                    {
                        Log.Write($"User created in the JXT DB ", ConfigurationPolicy.ErrorLog);
                    }
                }
            }


            var result = base.Authenticate(input, context);

            return input;
        }
        
    }
}
