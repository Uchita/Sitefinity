using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Telerik.Sitefinity.Frontend.Identity.Mvc.Models.Registration;

namespace JXTNext.Sitefinity.Widgets.User.Mvc.Models
{
    public class JXTNext_RegistrationModel : RegistrationModel, IRegistrationModel
    {
        IBusinessLogicsConnector _businessLogicsConnector;

        public override MembershipCreateStatus RegisterUser(RegistrationViewModel viewModel)
        {
            MembershipCreateStatus createStatus = base.RegisterUser(viewModel);

            //do your own stuff here
            JXTNext_MemberRegister memberReg = new JXTNext_MemberRegister
            {
                SiteDomain = "",
                Email = viewModel.Email,
                FirstName = viewModel.Profile.Keys.Contains("FirstName") ? viewModel.Profile["FirstName"] : null,
                LastName = viewModel.Profile.Keys.Contains("LastName") ? viewModel.Profile["LastName"] : null,
                Password = viewModel.Password
            };
            _businessLogicsConnector.MemberRegister(memberReg);

            return createStatus;
        }

    }
}
