using System.Configuration;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.Configuration;

namespace JXTNext.Sitefinity.Widgets.Social.SiteSettings.AddThis
{
    [DescriptionResource(typeof(ConfigDescriptions), "AddThisConfig")]
    public class AddThisConfig : ConfigSection
    {
        [ConfigurationProperty("uiAddThisSettings")]
        [DescriptionResource(typeof(ConfigDescriptions), "UIAddThisConfigDescriptions")]
        public virtual AddThisSettingsUISettings UIAddThisSettings
        {
            get
            {
                return (AddThisSettingsUISettings)base["uiAddThisSettings"];
            }
            set
            {
                base["uiAddThisSettings"] = value;
            }
        }
    }
}
