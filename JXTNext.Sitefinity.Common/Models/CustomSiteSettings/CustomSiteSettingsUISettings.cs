using System;
using System.Configuration;
using System.Runtime.Serialization;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Web.Configuration;

namespace JXTNext.Sitefinity.Common.Models.CustomSiteSettings
{
    [ObjectInfo(typeof(ConfigDescriptions), Title = "UICustomSiteSettingsConfigDescriptions", Description = "UICustomSiteSettingsConfigDescriptions")]
    public class CustomSiteSettingsUISettings : ConfigElement
    {
        public CustomSiteSettingsUISettings(ConfigElement parent)
            : base(parent)
        {
        }

        /// <summary>
        /// Gets or sets the name of the time zone.
        /// </summary>
        /// <value>The name of the time zone.</value>
        [ConfigurationProperty("googleAPIKey")]
        [DescriptionResource(typeof(ConfigDescriptions), "GoogleAPIKey")]

        [DataMember]
        public virtual String CurrentGoogleAPIKey
        {
            get
            {
                return (String)this["googleAPIKey"];
            }
            set
            {
                this["googleAPIKey"] = value;
            }
        }
    }
}