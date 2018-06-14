using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Services;

namespace Jxt.Sitefinity.Jobs
{
    public static class Main
    {
        public static void PreApplicationStart()
        {
            Bootstrapper.Initialized += Bootstrapper_Initialized;
            Bootstrapper.Bootstrapped += Bootstrapper_Bootstrapped;
        }
        
        private static void Bootstrapper_Initialized(object sender, ExecutedEventArgs e)
        {
            if (e.CommandName == "RegisterRoutes")
            {
                RegisterModule();
            }
        }

        private static void Bootstrapper_Bootstrapped(object sender, EventArgs e)
        {
            //GlobalConfiguration.Configuration.Routes.MapHttpRoute(
            //      "jxtapi",
            //      "jxtapi/{controller}/{id}",
            //      new { id = RouteParameter.Optional });

            //GlobalConfiguration.Configuration.EnsureInitialized();
        }

        private static void RegisterModule()
        {
            var configManager = ConfigManager.GetManager();
            var modulesConfig = configManager.GetSection<SystemConfig>().ApplicationModules;
            if (modulesConfig != null && !modulesConfig.Elements.Any(el => el.GetKey().Equals(JobsModule.ModuleName)))
            {
                modulesConfig.Add(JobsModule.ModuleName, new AppModuleSettings(modulesConfig)
                {
                    Name = JobsModule.ModuleName,
                    Title = JobsModule.ModuleName,
                    Description = JobsModule.ModuleName,
                    Type = typeof(JobsModule).AssemblyQualifiedName,
                    StartupType = StartupType.Disabled
                });

                configManager.SaveSection(modulesConfig.Section);
            }
        }
    }
}
