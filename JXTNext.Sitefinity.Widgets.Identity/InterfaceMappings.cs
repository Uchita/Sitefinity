using JXTNext.Sitefinity.Widgets.Identity.Mvc.Models.ChangePassword;
using JXTNext.Sitefinity.Widgets.Identity.Mvc.Models.LoginForm;
using JXTNext.Sitefinity.Widgets.Identity.Mvc.Models.Registration;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.Identity
{
    public class InterfaceMappings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<IRegistrationModel>().To<RegistrationModel>();
            Bind<ILoginFormModel>().To<LoginFormModel>();
            Bind<IChangePasswordModel>().To<ChangePasswordModel>();
        }
    }
}
