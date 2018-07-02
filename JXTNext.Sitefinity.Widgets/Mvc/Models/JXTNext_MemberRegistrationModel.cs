using JXTNext.Sitefinity.Common.Models;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Mappers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using System.Collections.Generic;
using System.Web.Security;
using Telerik.Sitefinity.Frontend.Identity.Mvc.Models.Registration;

namespace JXTNext.Sitefinity.Widgets.User.Mvc.Models
{
    public class JXTNext_MemberRegistrationModel : RegistrationModel, IRegistrationModel
    {
        IBusinessLogicsConnector _businessLogicsConnector;

        public JXTNext_MemberRegistrationModel() : base()
        {
            DrawDependencies();
        }

        public override MembershipCreateStatus RegisterUser(RegistrationViewModel viewModel)
        {
            MembershipCreateStatus createStatus = base.RegisterUser(viewModel);

            //do your own stuff here
            if (createStatus == MembershipCreateStatus.Success)
            {
                JXTNext_MemberRegister memberReg = new JXTNext_MemberRegister
                {
                    Email = viewModel.Email,
                    FirstName = viewModel.Profile.Keys.Contains("FirstName") ? viewModel.Profile["FirstName"] : null,
                    LastName = viewModel.Profile.Keys.Contains("LastName") ? viewModel.Profile["LastName"] : null,
                    Password = viewModel.Password
                };

                bool registerSuccess = _businessLogicsConnector.MemberRegister(memberReg, out string errorMessage);

                if( !registerSuccess )
                {
                    //can we delete?
                    createStatus = MembershipCreateStatus.ProviderError;
                }
            }

            return createStatus;
        }

        private void DrawDependencies()
        {
            IJobListingMapper jobMapper = new JXTNext_JobListingMapper();
            IMemberMapper memberMapper = new JXTNext_MemberMapper();
            IRequestSession session = new SFRequestSession();

            _businessLogicsConnector = new JXTNextBusinessLogicsConnector(
                new List<IJobListingMapper> { jobMapper }, new List<IMemberMapper> { memberMapper }, session);

        }
    }
}
