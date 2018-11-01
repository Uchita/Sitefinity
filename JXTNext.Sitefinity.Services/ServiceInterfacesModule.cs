using JXTNext.Sitefinity.Services.Intefaces;
using JXTNext.Sitefinity.Services.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Services.Services
{
    public class ServiceInterfacesModule : NinjectModule
    {
        public ServiceInterfacesModule()
        {

        }

        public override void Load()
        {
             Bind<IJobApplicationService>().To<JXTNextJobApplicationService>();
             Bind<IJobAlertService>().To<JXTNextJobAlertService>();
        }
    }
}
