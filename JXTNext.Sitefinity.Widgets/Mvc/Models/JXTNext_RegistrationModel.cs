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
        public override MembershipCreateStatus RegisterUser(RegistrationViewModel viewModel)
        {
            MembershipCreateStatus createStatus = base.RegisterUser(viewModel);

            //do your own stuff here

            return createStatus;
        }

    }
}
