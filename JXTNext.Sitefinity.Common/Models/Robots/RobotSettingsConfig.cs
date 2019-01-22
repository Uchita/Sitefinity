using System.Configuration;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.Configuration;

namespace JXTNext.Sitefinity.Common.Models.Robots
{
    [DescriptionResource(typeof(ConfigDescriptions), "RobotSettingsConfig")]
    public class RobotSettingsConfig : ConfigSection
    {
        [ConfigurationProperty("uiRobotSettings")]
        [DescriptionResource(typeof(ConfigDescriptions), "UIRobotSettingsConfigDescriptions")]
        public virtual RobotSettingsUISettings UICustomSiteSettings
        {
            get
            {
                return (RobotSettingsUISettings)base["uiRobotSettings"];
            }
            set
            {
                base["uiRobotSettings"] = value;
            }
        }
    }
}
