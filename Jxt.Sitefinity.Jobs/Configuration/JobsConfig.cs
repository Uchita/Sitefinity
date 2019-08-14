using Jxt.Sitefinity.Jobs.Data;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Modules.GenericContent.Configuration;
using Telerik.Sitefinity.Web.UI.ContentUI.Config;

namespace Jxt.Sitefinity.Jobs.Configuration
{
    public class JobsConfig : ContentModuleConfigBase
    {
        protected override void InitializeDefaultProviders(ConfigElementDictionary<string, DataProviderSettings> providers)
        {
            providers.Add(new DataProviderSettings(this.Providers)
            {
                Name = "OpenAccessDataProvider",
                Description = "A provider that stores jobs data in a JXT Business Layer API.",
                ProviderType = typeof(WebJobsDataProvider)
            });
        }

        protected override void InitializeDefaultViews(ConfigElementDictionary<string, ContentViewControlElement> contentViewControls)
        {
        }
    }
}