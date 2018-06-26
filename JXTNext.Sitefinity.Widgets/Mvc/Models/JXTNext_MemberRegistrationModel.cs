using JXTNext.Sitefinity.Common.Models;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using Telerik.Sitefinity.Frontend.Identity.Mvc.Models.Registration;

namespace JXTNext.Sitefinity.Widgets.User.Mvc.Models
{
    public class JXTNext_MemberRegistrationModel : RegistrationModel, IRegistrationModel
    {
        IBusinessLogicsConnector _businessLogicsConnector;

        public JXTNext_MemberRegistrationModel(IEnumerable<IBusinessLogicsConnector> businessLogicsConnectors) : base()
        {
            _businessLogicsConnector = businessLogicsConnectors.Where(c => c.ConnectorType == Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
        }

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
