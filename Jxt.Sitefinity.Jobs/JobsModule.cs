using Jxt.Sitefinity.Jobs.Configuration;
using Jxt.Sitefinity.Jobs.Localization;
using Jxt.Sitefinity.Jobs.Mvc.Controllers;
using System;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Fluent.Modules;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Modules.GenericContent;
using Telerik.Sitefinity.Mvc.Proxy;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace Jxt.Sitefinity.Jobs
{
    public class JobsModule : ContentModuleBase
    {
        public const string ModuleName = "Jobs";

        public override Type[] Managers
        {
            get
            {
                return new[] { typeof(JobsManager) };
            }
        }

        public override Guid LandingPageId
        {
            get
            {
                return JobsModule.JobsModuleLandingPage;
            }
        }

        public Guid SubPageId
        {
            get
            {
                return JobsModule.JobsPageGroupId;
            }
        }

        public override void Initialize(ModuleSettings settings)
        {
            base.Initialize(settings);
            Config.RegisterSection<JobsConfig>();
            Res.RegisterResource<JobsResources>();

            TypeResolutionService.RegisterAssembly(typeof(JobsModule).Assembly.GetName());

            Bootstrapper.Bootstrapped -= Bootstrapper_Bootstrapped;
            Bootstrapper.Bootstrapped += Bootstrapper_Bootstrapped;
        }

        private void Bootstrapper_Bootstrapped(object sender, EventArgs e)
        {
        }

        public override void Install(SiteInitializer initializer)
        {
            base.Install(initializer);
        }

        public override void Upgrade(SiteInitializer initializer, Version upgradeFrom)
        {
        }

        protected override ConfigSection GetModuleConfig()
        {
            return Config.Get<JobsConfig>();
        }

        protected override void InstallPages(SiteInitializer initializer)
        {
            initializer.Installer
                .CreateModuleGroupPage(JobsModule.JobsPageGroupId, JobsModule.ModuleName)
                .PlaceUnder(CommonNode.TypesOfContent)
                .LocalizeUsing<JobsResources>()
                .SetTitleLocalized("JobsTitle")
                .SetUrlNameLocalized("JobsTitle")
                .SetDescriptionLocalized("JobsTitle")
                .AddChildPage(JobsModule.JobsModuleLandingPage, JobsModule.ModuleName)
                    .LocalizeUsing<JobsResources>()
                    .SetTitleLocalized("JobsTitle")
                    .SetHtmlTitleLocalized("JobsTitle")
                    .SetUrlName("JobsTitle")
                    .SetDescriptionLocalized("JobsDescription")
                    .SetTemplate(SiteInitializer.BackendHtml5TemplateId)
                    .AddControl(new MvcControllerProxy()
                    {
                        ControllerName = typeof(JobsBackendController).FullName
                    })
                    .Done();
        }

        protected override void InstallTaxonomies(SiteInitializer initializer)
        { }


        protected override void InstallConfiguration(SiteInitializer initializer)
        {
        }

        public static readonly Guid JobsPageGroupId = new Guid("13FA3CB0-6F00-4DFB-A534-28EA60252A16");
        public static readonly Guid JobsModuleLandingPage = new Guid("A52C36E1-3D29-4F39-BB8D-BB1F064E556A");
        public const string JobsVirtualPath = "~/SFJobs/";
    }
}