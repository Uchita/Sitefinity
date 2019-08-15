using System.Configuration;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.Configuration;

namespace JXTNext.Sitefinity.SalarySurvey.Admin
{
    /// <summary>
    /// See https://www.progress.com/documentation/sitefinity-cms/custom-basic-settings-create-the-configuration-class
    /// </summary>
    [DescriptionResource(typeof(ConfigDescriptions), "SalarySurveyConfig")]
    public class SalarySurveyConfig : ConfigSection
    {
        [ConfigurationProperty("uiSalarySurveySettings")]
        [DescriptionResource(typeof(ConfigDescriptions), "UISalarySurveyConfigDescriptions")]
        public virtual SalarySurveySettingsUISettings UISalarySurveySettings
        {
            get
            {
                return (SalarySurveySettingsUISettings)base["uiSalarySurveySettings"];
            }
            set
            {
                base["uiSalarySurveySettings"] = value;
            }
        }
    }
}
