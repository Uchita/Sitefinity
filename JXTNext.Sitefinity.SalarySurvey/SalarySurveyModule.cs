using System;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Services;

namespace JXTNext.Sitefinity.SalarySurvey
{
    /// <summary>
    /// Custom Sitefinity module 
    /// </summary>
    public class SalarySurveyModule : ModuleBase
    {
        #region Properties

        /// <summary>
        /// Gets the landing page id for the module.
        /// </summary>
        /// <value>The landing page id.</value>
        public override Guid LandingPageId
        {
            get
            {
                return SiteInitializer.DashboardPageNodeId;
            }
        }

        /// <summary>
        /// Gets the CLR types of all data managers provided by this module.
        /// </summary>
        /// <value>An array of <see cref="T:System.Type" /> objects.</value>
        public override Type[] Managers
        {
            get
            {
                return new Type[0];
            }
        }

        #endregion

        #region Module Initialization

        /// <summary>
        /// Initializes the service with specified settings.
        /// This method is called every time the module is initializing (on application startup by default)
        /// </summary>
        /// <param name="settings">The settings.</param>
        public override void Initialize(ModuleSettings settings)
        {
            base.Initialize(settings);

            // Add your initialization logic here
            // here we register the module resources
            // but if you have you should register your module configuration or web service here

            App.WorkWith()
                .Module(settings.Name)
                    .Initialize()
                    .Localization<SalarySurveyResources>()
                    .WebService<JXTNext.Sitefinity.SalarySurvey.Web.Services.SalaryAlert>("JXTNext/Services/SalarySurvey/SalaryAlert/");

            // Here is also the place to register to some Sitefinity specific events like Bootstrapper.Initialized or subscribe for an event in with the EventHub class            
            // Please refer to the documentation for additional information http://www.sitefinity.com/documentation/documentationarticles/developers-guide/deep-dive/sitefinity-event-system/ieventservice-and-eventhub
        }

        /// <summary>
        /// Installs this module in Sitefinity system for the first time.
        /// </summary>
        /// <param name="initializer">The Site Initializer. A helper class for installing Sitefinity modules.</param>
        public override void Install(SiteInitializer initializer)
        {
            // Here you can install a virtual path to be used for this assembly
            // A virtual path is required to access the embedded resources
            //this.InstallVirtualPaths(initializer);

            // Here you can install you backend pages
            //this.InstallBackendPages(initializer);

            // Here you can also install your page/form/layout widgets
            //this.InstallPageWidgets(initializer);
        }

        /// <summary>
        /// Upgrades this module from the specified version.
        /// This method is called instead of the Install method when the module is already installed with a previous version.
        /// </summary>
        /// <param name="initializer">The Site Initializer. A helper class for installing Sitefinity modules.</param>
        /// <param name="upgradeFrom">The version this module us upgrading from.</param>
        public override void Upgrade(SiteInitializer initializer, Version upgradeFrom)
        {
            // Here you can check which one is your prevous module version and execute some code if you need to
            // See the example bolow
            //
            //if (upgradeFrom < new Version("1.0.1.0"))
            //{
            //    some upgrade code that your new version requires
            //}
        }

        /// <summary>
        /// Uninstalls the specified initializer.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        public override void Uninstall(SiteInitializer initializer)
        {
            base.Uninstall(initializer);
            // Add your uninstall logic here
        }
        
        #endregion

        #region Public and overriden methods

        /// <summary>
        /// Gets the module configuration.
        /// </summary>
        protected override ConfigSection GetModuleConfig()
        {
            // If you have a module configuration, you should return it here
            // return Config.Get<ModuleConfigurationType>();
            return null;
        }
        
        #endregion

        #region Virtual paths

        /// <summary>
        /// Installs module virtual paths.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        private void InstallVirtualPaths(SiteInitializer initializer)
        {
            // Here you can register your module virtual paths

            //var virtualPaths = initializer.Context.GetConfig<VirtualPathSettingsConfig>().VirtualPaths;
            //var moduleVirtualPath = SalarySurveyModule.ModuleVirtualPath + "*";
            //if (!virtualPaths.ContainsKey(moduleVirtualPath))
            //{
            //    virtualPaths.Add(new VirtualPathElement(virtualPaths)
            //    {
            //        VirtualPath = moduleVirtualPath,
            //        ResolverName = "EmbeddedResourceResolver",
            //        ResourceLocation = typeof(SalarySurveyModule).Assembly.GetName().Name
            //    });
            //}
        }

        #endregion

        #region Install backend pages

        /// <summary>
        /// Installs the backend pages.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        private void InstallBackendPages(SiteInitializer initializer)
        {
            // Using our Fluent Api you can add your module backend pages hierarchy in no time
            // Here is an example using resources to localize the title of the page and adding a dummy control
            // to the module page. 

            //Guid groupPageId = new Guid("3894fec1-63e2-47a7-9911-3096c5b49808");
            //Guid pageId = new Guid("8e28bc86-cd53-48e2-bc50-71372c6044e8");

            //initializer.Installer
            //    .CreateModuleGroupPage(groupPageId, "SalarySurvey group page")
            //        .PlaceUnder(SiteInitializer.SitefinityNodeId)
            //        .SetOrdinal(100)
            //        .LocalizeUsing<SalarySurveyResources>()
            //        .SetTitleLocalized("SalarySurveyGroupPageTitle")
            //        .SetUrlNameLocalized("SalarySurveyGroupPageUrlName")
            //        .SetDescriptionLocalized("SalarySurveyGroupPageDescription")
            //        .ShowInNavigation()
            //        .AddChildPage(pageId, "SalarySurvey page")
            //            .SetOrdinal(1)
            //            .LocalizeUsing<SalarySurveyResources>()
            //            .SetTitleLocalized("SalarySurveyPageTitle")
            //            .SetHtmlTitleLocalized("SalarySurveyPageTitle")
            //            .SetUrlNameLocalized("SalarySurveyPageUrlName")
            //            .SetDescriptionLocalized("SalarySurveyPageDescription")
            //            .AddControl(new System.Web.UI.WebControls.Literal()
            //            {
            //                Text = "<h1 class=\"sfBreadCrumb\">SalarySurvey module Installed</h1>",
            //                Mode = LiteralMode.PassThrough
            //            })
            //            .ShowInNavigation()
            //        .Done()
            //    .Done();
        }

        #endregion

        #region Widgets

        /// <summary>
        /// Installs the form widgets.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        private void InstallFormWidgets(SiteInitializer initializer)
        {
            // Here you can register your custom form widgets in the toolbox.
            // See the example below.

            //string moduleFormWidgetSectionName = "SalarySurvey";
            //string moduleFormWidgetSectionTitle = "SalarySurvey";
            //string moduleFormWidgetSectionDescription = "SalarySurvey";

            //initializer.Installer
            //    .Toolbox(CommonToolbox.FormWidgets)
            //        .LoadOrAddSection(moduleFormWidgetSectionName)
            //            .SetTitle(moduleFormWidgetSectionTitle)
            //            .SetDescription(moduleFormWidgetSectionDescription)
            //            .LoadOrAddWidget<WidgetType>(WidgetNameForDevelopers)
            //                .SetTitle(WidgetTitle)
            //                .SetDescription(WidgetDescription)
            //                .LocalizeUsing<SalarySurveyResources>()
            //                .SetCssClass(WidgetCssClass) // You can use a css class to add an icon (this is optional)
            //            .Done()
            //        .Done()
            //    .Done();
        }

        /// <summary>
        /// Installs the layout widgets.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        private void InstallLayoutWidgets(SiteInitializer initializer)
        {
            // Here you can register your custom layout widgets in the toolbox.
            // See the example below.

            //string moduleLayoutWidgetSectionName = "SalarySurvey";
            //string moduleLayoutWidgetSectionTitle = "SalarySurvey";
            //string moduleLayoutWidgetSectionDescription = "SalarySurvey";

            //initializer.Installer
            //    .Toolbox(CommonToolbox.Layouts)
            //        .LoadOrAddSection(moduleLayoutWidgetSectionName)
            //            .SetTitle(moduleLayoutWidgetSectionTitle)
            //            .SetDescription(moduleLayoutWidgetSectionDescription)
            //            .LoadOrAddWidget<LayoutControl>(WidgetNameForDevelopers)
            //                .SetTitle(WidgetTitle)
            //                .SetDescription(WidgetDescription)
            //                .LocalizeUsing<SalarySurveyResources>()
            //                .SetCssClass(WidgetCssClass) // You can use a css class to add an icon (Optional)
            //                .SetParameters(new NameValueCollection() 
            //                { 
            //                    { "layoutTemplate", FullPathToTheLayoutWidget },
            //                })
            //            .Done()
            //        .Done()
            //    .Done();
        }

        /// <summary>
        /// Installs the page widgets.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        private void InstallPageWidgets(SiteInitializer initializer)
        {
            // Here you can register your custom page widgets in the toolbox.
            // See the example below.

            //string modulePageWidgetSectionName = "SalarySurvey";
            //string modulePageWidgetSectionTitle = "SalarySurvey";
            //string modulePageWidgetSectionDescription = "SalarySurvey";

            //initializer.Installer
            //    .Toolbox(CommonToolbox.PageWidgets)
            //        .LoadOrAddSection(modulePageWidgetSectionName)
            //            .SetTitle(modulePageWidgetSectionTitle)
            //            .SetDescription(modulePageWidgetSectionDescription)
            //            .LoadOrAddWidget<WidgetType>(WidgetNameForDevelopers)
            //                .SetTitle(WidgetTitle)
            //                .SetDescription(WidgetDescription)
            //                .LocalizeUsing<SalarySurveyResources>()
            //                .SetCssClass(WidgetCssClass) // You can use a css class to add an icon (Optional)
            //            .Done()
            //        .Done()
            //    .Done();
        }

        #endregion

        #region Upgrade methods
        #endregion

        #region Private members & constants

        public const string ModuleName = "JXTNextSalarySurvey";
        internal const string ModuleTitle = "JXT Next Salary Survey";
        internal const string ModuleDescription = "Salary Survey module for JXT Next.";
        internal const string ModuleVirtualPath = "~/JXTNextSalarySurvey/";
        
        #endregion
    }
}
