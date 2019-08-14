using System.Configuration;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.Configuration;

namespace JXTNext.Sitefinity.Common.Models.CustomSiteSettings
{
    [DescriptionResource(typeof(ConfigDescriptions), "CustomSiteSettingsConfig")]
    public class CustomSiteSettingsConfig : ConfigSection
    {
        [ConfigurationProperty("uiCustomSiteSettings")]
        [DescriptionResource(typeof(ConfigDescriptions), "UICustomSiteSettingsConfigDescriptions")]
        public virtual CustomSiteSettingsUISettings UICustomSiteSettings
        {
            get
            {
                return (CustomSiteSettingsUISettings)base["uiCustomSiteSettings"];
            }
            set
            {
                base["uiCustomSiteSettings"] = value;
            }
        }
    }
}