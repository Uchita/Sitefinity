using System.Linq;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Services;


namespace JXTNext.Sitefinity.SalarySurvey
{
    /// <summary>
    /// Module installer class
    /// </summary>
    public static class SalarySurveyInstaller
    {
        #region Public methods

        /// <summary>
        /// Called before the application start.
        /// </summary>
        public static void PreApplicationStart()
        {
            Bootstrapper.Initialized += SalarySurveyInstaller.OnBootstrapperInitialized;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Called when the Bootstrapper is initialized.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Telerik.Sitefinity.Data.ExecutedEventArgs" /> instance containing the event data.</param>
        private static void OnBootstrapperInitialized(object sender, ExecutedEventArgs e)
        {
            if (e.CommandName == "RegisterRoutes")
            {
                // We have to register the module at a very early stage when sitefinity is initializing
                SalarySurveyInstaller.RegisterModule();
            }
        }

        /// <summary>
        /// Registers the module.
        /// </summary>
        private static void RegisterModule()
        {
            var configManager = ConfigManager.GetManager();
            var modulesConfig = configManager.GetSection<SystemConfig>().ApplicationModules;
            if (!modulesConfig.Elements.Any(el => el.GetKey().Equals(SalarySurveyModule.ModuleName)))
            {
                modulesConfig.Add(SalarySurveyModule.ModuleName, new AppModuleSettings(modulesConfig)
                {
                    Name = SalarySurveyModule.ModuleName,
                    Title = SalarySurveyModule.ModuleTitle,
                    Description = SalarySurveyModule.ModuleDescription,
                    Type = typeof(SalarySurveyModule).AssemblyQualifiedName,
                    // Change to StartupType.OnApplicationStart if you wish to have the module automatically installed.
                    StartupType = StartupType.Disabled
                });

                configManager.SaveSection(modulesConfig.Section);

                // Uncomment if you change the StartupType to OnApplicationStart
                //SystemManager.RestartApplication(false);
            }
        }

        #endregion
    }
}
