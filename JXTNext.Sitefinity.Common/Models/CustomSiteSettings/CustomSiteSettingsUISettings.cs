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

        /// <summary>
        /// Gets or sets the Google Client ID
        /// </summary>
        /// <value>The name of the time zone.</value>
        [ConfigurationProperty("googleClientId")]
        [DescriptionResource(typeof(ConfigDescriptions), "GoogleClientId")]

        [DataMember]
        public virtual String CurrentGoogleClientId
        {
            get
            {
                return (String)this["googleClientId"];
            }
            set
            {
                this["googleClientId"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the Google Client Secret
        /// </summary>
        /// <value>The name of the time zone.</value>
        [ConfigurationProperty("googleClientSecret")]
        [DescriptionResource(typeof(ConfigDescriptions), "GoogleClientSecret")]

        [DataMember]
        public virtual String CurrentGoogleClientSecret
        {
            get
            {
                return (String)this["googleClientSecret"];
            }
            set
            {
                this["googleClientSecret"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the Google Client API Key
        /// </summary>
        /// <value>The name of the time zone.</value>
        [ConfigurationProperty("googleClientAPIKey")]
        [DescriptionResource(typeof(ConfigDescriptions), "GoogleClientAPIKey")]

        [DataMember]
        public virtual String CurrentGoogleClientAPIKey
        {
            get
            {
                return (String)this["googleClientAPIKey"];
            }
            set
            {
                this["googleClientAPIKey"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the Google TagManager Key
        /// </summary>
        /// <value>The name of the time zone.</value>
        [ConfigurationProperty("googleTagManagerKey")]
        [DescriptionResource(typeof(ConfigDescriptions), "GoogleTagManagerKey")]

        [DataMember]
        public virtual String CurrentGoogleTagManagerKey
        {
            get
            {
                return (String)this["googleTagManagerKey"];
            }
            set
            {
                this["googleTagManagerKey"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the Dropbox Client ID
        /// </summary>
        /// <value>The name of the time zone.</value>
        [ConfigurationProperty("dropboxAppId")]
        [DescriptionResource(typeof(ConfigDescriptions), "DropboxAppId")]

        [DataMember]
        public virtual String CurrentDropboxAppId
        {
            get
            {
                return (String)this["dropboxAppId"];
            }
            set
            {
                this["dropboxAppId"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the Google Client Secret
        /// </summary>
        /// <value>The name of the time zone.</value>
        [ConfigurationProperty("dropboxAppSecret")]
        [DescriptionResource(typeof(ConfigDescriptions), "DropboxAppSecret")]

        [DataMember]
        public virtual String CurrentDropboxAppSecret
        {
            get
            {
                return (String)this["dropboxAppSecret"];
            }
            set
            {
                this["dropboxAppSecret"] = value;
            }
        }
    }
}