using JXTNext.Sitefinity.Widgets.User.Mvc.Logics;
using Ninject.Modules;

namespace JXTNext.Sitefinity.Widgets.Job
{
    /// <summary>
    /// This class is used to describe the bindings which will be used by the Ninject container when resolving classes
    /// </summary>
    public class Widgets_UserModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<MemberSavedJobBC>().To<MemberSavedJobBC>();
        }
    }
}
