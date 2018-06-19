using Ninject.Modules;
using JXTNext.Sitefinity.Widgets.Authentication.Mvc.Models.LoginStatusExtended;

namespace JXTNext.Sitefinity.Widgets.Authentication
{
    /// <summary>
    /// This class is used to describe the bindings which will be used by the Ninject container when resolving classes
    /// </summary>
    public class Widgets_AuthenticationModule : NinjectModule
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
