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

        /// <summary>
        /// Gets or sets the Dropbox Client API Key
        /// </summary>
        /// <value>The name of the time zone.</value>
        [ConfigurationProperty("dropboxClientAPIKey")]
        [DescriptionResource(typeof(ConfigDescriptions), "DropboxClientAPIKey")]

        [DataMember]
        public virtual String CurrentDropboxClientAPIKey
        {
            get
            {
                return (String)this["dropboxClientAPIKey"];
            }
            set
            {
                this["dropboxClientAPIKey"] = value;
            }
        }

        #region Seek

        /// <summary>
        /// Gets or sets the Dropbox Client API Key
        /// </summary>
        /// <value>The name of the time zone.</value>
        [ConfigurationProperty("seekClientId")]
        [DescriptionResource(typeof(ConfigDescriptions), "SeekClientId")]

        [DataMember]
        public virtual String CurrentSeekClientId
        {
            get
            {
                return (String)this["seekClientId"];
            }
            set
            {
                this["seekClientId"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the Dropbox Client API Key
        /// </summary>
        /// <value>The name of the time zone.</value>
        [ConfigurationProperty("seekClientSecret")]
        [DescriptionResource(typeof(ConfigDescriptions), "SeekClientSecret")]

        [DataMember]
        public virtual String CurrentSeekClientSecret
        {
            get
            {
                return (String)this["seekClientSecret"];
            }
            set
            {
                this["seekClientSecret"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the Dropbox Client API Key
        /// </summary>
        /// <value>The name of the time zone.</value>
        [ConfigurationProperty("seekClientAdvertiserId")]
        [DescriptionResource(typeof(ConfigDescriptions), "SeekClientAdvertiserId")]

        [DataMember]
        public virtual String CurrentSeekClientAdvertiserId
        {
            get
            {
                return (String)this["seekClientAdvertiserId"];
            }
            set
            {
                this["seekClientAdvertiserId"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the Dropbox Client API Key
        /// </summary>
        /// <value>The name of the time zone.</value>
        [ConfigurationProperty("seekRedirectUri")]
        [DescriptionResource(typeof(ConfigDescriptions), "SeekRedirectUri")]

        [DataMember]
        public virtual String CurrentSeekRedirectUri
        {
            get
            {
                return (String)this["seekRedirectUri"];
            }
            set
            {
                this["seekRedirectUri"] = value;
            }
        }

        #endregion

        #region Indeed
        /// <summary>
        /// Gets or sets the Indeed API Token
        /// </summary>
        /// <value>The name of the time zone.</value>
        [ConfigurationProperty("indeedClientAPIToken")]
        [DescriptionResource(typeof(ConfigDescriptions), "IndeedClientAPIToken")]

        [DataMember]
        public virtual String CurrentIndeedClientAPIToken
        {
            get
            {
                return (String)this["indeedClientAPIToken"];
            }
            set
            {
                this["indeedClientAPIToken"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the Indeed Client Secret
        /// </summary>
        /// <value>The name of the time zone.</value>
        [ConfigurationProperty("indeedClientSecret")]
        [DescriptionResource(typeof(ConfigDescriptions), "IndeedClientSecret")]

        [DataMember]
        public virtual String CurrentIndeedClientSecret
        {
            get
            {
                return (String)this["indeedClientSecret"];
            }
            set
            {
                this["indeedClientSecret"] = value;
            }
        }
        #endregion

        #region Instagram
        /// <summary>
        /// Gets or sets the Instagram API Token
        /// </summary>
        /// <value>The name of the time zone.</value>
        [ConfigurationProperty("instagramClientIdToken")]
        [DescriptionResource(typeof(ConfigDescriptions), "InstagramClientIdToken")]

        [DataMember]
        public virtual String CurrentInstagramClientIdToken
        {
            get
            {
                return (String)this["instagramClientIdToken"];
            }
            set
            {
                this["instagramClientIdToken"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the Instagram Client Secret
        /// </summary>
        /// <value>The name of the time zone.</value>
        [ConfigurationProperty("instagramClientSecret")]
        [DescriptionResource(typeof(ConfigDescriptions), "InstagramClientSecret")]

        [DataMember]
        public virtual String CurrentInstagramClientSecret
        {
            get
            {
                return (String)this["instagramClientSecret"];
            }
            set
            {
                this["instagramClientSecret"] = value;
            }
        }

        [ConfigurationProperty("instagramAccessToken")]
        [DescriptionResource(typeof(ConfigDescriptions), "InstagramAccessToken")]

        [DataMember]
        public virtual String CurrentInstagramAccessToken
        {
            get
            {
                return (String)this["instagramAccessToken"];
            }
            set
            {
                this["instagramAccessToken"] = value;
            }
        }

        [ConfigurationProperty("instagramExpiration")]
        [DescriptionResource(typeof(ConfigDescriptions), "InstagramExpiration")]

        [DataMember]
        public virtual int CurrentInstagramExpiration
        {
            get
            {
                return (int)this["instagramExpiration"];
            }
            set
            {
                this["instagramExpiration"] = value;
            }
        }

        [ConfigurationProperty("instagramMaxItems")]
        [DescriptionResource(typeof(ConfigDescriptions), "InstagramMaxItems")]

        [DataMember]
        public virtual int CurrentInstagramMaxItems
        {
            get
            {
                return (int)this["instagramMaxItems"];
            }
            set
            {
                this["instagramMaxItems"] = value;
            }
        }
        #endregion
    }
}