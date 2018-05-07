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
        }

        private static void Bootstrapper_Initialized(object sender, ExecutedEventArgs e)
        {
            if (e.CommandName == "RegisterRoutes")
                RegisterModule();

            else if (e.CommandName == "Bootstrapped")
            {
                var config = GlobalConfiguration.Configuration;

                //config.MapHttpAttributeRoutes();

                //config.Routes.MapHttpRoute("jobs-jxt",
                //    "jxt/{controller}",
                //    new
                //    {
                //        controller = "JobsApi"
                //    });
            }
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
