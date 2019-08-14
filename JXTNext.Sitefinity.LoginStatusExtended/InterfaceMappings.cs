using Ninject.Modules;
//using Telerik.Sitefinity.Frontend.Identity.Mvc.Models.AccountActivation;
//using Telerik.Sitefinity.Frontend.Identity.Mvc.Models.ChangePassword;
//using Telerik.Sitefinity.Frontend.Identity.Mvc.Models.LoginForm;
//using Telerik.Sitefinity.Frontend.Identity.Mvc.Models.LoginStatus;
//using Telerik.Sitefinity.Frontend.Identity.Mvc.Models.Profile;
//using Telerik.Sitefinity.Frontend.Identity.Mvc.Models.Registration;
//using Telerik.Sitefinity.Frontend.Identity.Mvc.Models.UsersList;
using JXTNext.Sitefinity.LoginStatusExtended.Mvc.Models;

namespace JXTNext.Sitefinity.LoginStatusExtended
{
    /// <summary>
    /// This class is used to describe the bindings which will be used by the Ninject container when resolving classes
    /// </summary>
    public class InterfaceMappings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<ILoginStatusExtendedModel>().To<LoginStatusExtendedModel>();
        }
    }
}
