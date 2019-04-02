using System;
using System.Runtime.Serialization;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.SiteSettings;

namespace JXTNext.Sitefinity.Common.Models.CustomSiteSettings
{
    [DataContract]
    public class CustomSiteSettingsContract : ISettingsDataContract
    {
        #region DataMembers
        [DataMember]
        public string GoogleAPIKey
        {
            get;
            set;
        }

        [DataMember]
        public string GoogleClientId
        {
            get;
            set;
        }

        [DataMember]
        public string GoogleClientSecret
        {
            get;
            set;
        }

        [DataMember]
        public string GoogleClientAPIKey
        {
            get;
            set;
        }

        [DataMember]
        public string GoogleTagManagerKey
        {
            get;
            set;
        }

        [DataMember]
        public string DropboxAppId
        {
            get;
            set;
        }

        [DataMember]
        public string DropboxAppSecret
        {
            get;
            set;
        }

        [DataMember]
        public string DropboxClientAPIKey
        {
            get;
            set;
        }

        #region Seek
        [DataMember]
        public string SeekClientId
        {
            get;
            set;
        }

        [DataMember]
        public string SeekClientSecret
        {
            get;
            set;
        }

        [DataMember]
        public string SeekClientAdvertiserId
        {
            get;
            set;
        }

        [DataMember]
        public string SeekRedirectUri
        {
            get;
            set;
        }
        #endregion

        #region Indeed
        [DataMember]
        public string IndeedClientAPIToken
        {
            get;
            set;
        }

        [DataMember]
        public string IndeedClientSecret
        {
            get;
            set;
        }
        #endregion

        #region Instagram
        [DataMember]
        public string InstagramClientIdToken
        {
            get;
            set;
        }

        [DataMember]
        public string InstagramClientSecret
        {
            get;
            set;
        }

        [DataMember]
        public string InstagramAccessToken
        {
            get;
            set;
        }

        [DataMember]
        public int InstagramExpiration
        {
            get;
            set;
        }

        [DataMember]
        public int InstagramMaxItems
        {
            get;
            set;
        }
        #endregion

        #region LinkedIn
        [DataMember]
        public string LinkedInClientId
        {
            get;
            set;
        }

        [DataMember]
        public string LinkedInClientSecret
        {
            get;
            set;
        }

        [DataMember]
        public string LinkedInCustomerClientId
        {
            get;
            set;
        }

        [DataMember]
        public string LinkedInCustomerClientSecret
        {
            get;
            set;
        }

        [DataMember]
        public string LinkedInCustomerIntegrationContext
        {
            get;
            set;
        }

        [DataMember]
        public string LinkedInSocialHandlerUrl
        {
            get;
            set;
        }
        #endregion

        #endregion

        #region LoadDefaults
        public void LoadDefaults(bool forEdit = false)
        {
            CustomSiteSettingsConfig section;
            if (forEdit)
                section = ConfigManager.GetManager().GetSection<CustomSiteSettingsConfig>();
            else
                section = Config.Get<CustomSiteSettingsConfig>();

            this.GoogleAPIKey = section.UICustomSiteSettings.CurrentGoogleAPIKey;
            this.GoogleClientId = section.UICustomSiteSettings.CurrentGoogleClientId;
            this.GoogleClientSecret = section.UICustomSiteSettings.CurrentGoogleClientSecret;
            this.GoogleClientAPIKey = section.UICustomSiteSettings.CurrentGoogleClientAPIKey;
            this.GoogleTagManagerKey = section.UICustomSiteSettings.CurrentGoogleTagManagerKey;

            this.DropboxAppId = section.UICustomSiteSettings.CurrentDropboxAppId;
            this.DropboxAppSecret = section.UICustomSiteSettings.CurrentDropboxAppSecret;
            this.DropboxClientAPIKey = section.UICustomSiteSettings.CurrentDropboxClientAPIKey;

            // Seek
            this.SeekClientId = section.UICustomSiteSettings.CurrentSeekClientId;
            this.SeekClientSecret = section.UICustomSiteSettings.CurrentSeekClientSecret;
            this.SeekClientAdvertiserId = section.UICustomSiteSettings.CurrentSeekClientAdvertiserId;
            this.SeekRedirectUri = section.UICustomSiteSettings.CurrentSeekRedirectUri;

            // Indeed
            this.IndeedClientAPIToken = section.UICustomSiteSettings.CurrentIndeedClientAPIToken;
            this.IndeedClientSecret = section.UICustomSiteSettings.CurrentIndeedClientSecret;

            // Instagram
            this.InstagramClientIdToken = section.UICustomSiteSettings.CurrentInstagramClientIdToken;
            this.InstagramClientSecret = section.UICustomSiteSettings.CurrentInstagramClientSecret;
            this.InstagramAccessToken = section.UICustomSiteSettings.CurrentInstagramAccessToken;
            this.InstagramExpiration = section.UICustomSiteSettings.CurrentInstagramExpiration;
            this.InstagramMaxItems = section.UICustomSiteSettings.CurrentInstagramMaxItems;

            // LinkedIn
            this.LinkedInClientId = section.UICustomSiteSettings.CurrentLinkedInClientId;
            this.LinkedInClientSecret = section.UICustomSiteSettings.CurrentLinkedInClientSecret;
            this.LinkedInCustomerClientId = section.UICustomSiteSettings.CurrentLinkedInCustomerClientId;
            this.LinkedInCustomerClientSecret = section.UICustomSiteSettings.CurrentLinkedInCustomerClientSecret;
            this.LinkedInCustomerIntegrationContext = section.UICustomSiteSettings.CurrentLinkedInCustomerIntegrationContext;
            this.LinkedInSocialHandlerUrl = section.UICustomSiteSettings.CurrentLinkedInSocialHandlerUrl;
        }

        public void SaveDefaults()
        {
            var manager = ConfigManager.GetManager();
            var section = manager.GetSection<CustomSiteSettingsConfig>();

            section.UICustomSiteSettings.CurrentGoogleAPIKey = this.GoogleAPIKey;
            section.UICustomSiteSettings.CurrentGoogleClientId = this.GoogleClientId;
            section.UICustomSiteSettings.CurrentGoogleClientSecret = this.GoogleClientSecret;
            section.UICustomSiteSettings.CurrentGoogleClientAPIKey = this.GoogleClientAPIKey;
            section.UICustomSiteSettings.CurrentGoogleTagManagerKey = this.GoogleTagManagerKey;

            section.UICustomSiteSettings.CurrentDropboxAppId = this.DropboxAppId;
            section.UICustomSiteSettings.CurrentDropboxAppSecret = this.DropboxAppSecret;
            section.UICustomSiteSettings.CurrentDropboxClientAPIKey = this.DropboxClientAPIKey;

            // Seek
            section.UICustomSiteSettings.CurrentSeekClientId = this.SeekClientId;
            section.UICustomSiteSettings.CurrentSeekClientSecret = this.SeekClientSecret;
            section.UICustomSiteSettings.CurrentSeekClientAdvertiserId = this.SeekClientAdvertiserId;
            section.UICustomSiteSettings.CurrentSeekRedirectUri = this.SeekRedirectUri;
            
            // Indeed
            section.UICustomSiteSettings.CurrentIndeedClientAPIToken = this.IndeedClientAPIToken;
            section.UICustomSiteSettings.CurrentIndeedClientSecret = this.IndeedClientSecret;


            // Instagram
            section.UICustomSiteSettings.CurrentInstagramClientIdToken = this.InstagramClientIdToken;
            section.UICustomSiteSettings.CurrentInstagramClientSecret = this.InstagramClientSecret;
            section.UICustomSiteSettings.CurrentInstagramAccessToken = this.InstagramAccessToken;
            section.UICustomSiteSettings.CurrentInstagramExpiration = this.InstagramExpiration;
            section.UICustomSiteSettings.CurrentInstagramMaxItems = this.InstagramMaxItems;

            // LInkedIn
            section.UICustomSiteSettings.CurrentLinkedInClientId = this.LinkedInClientId;
            section.UICustomSiteSettings.CurrentLinkedInClientSecret = this.LinkedInClientSecret;
            section.UICustomSiteSettings.CurrentLinkedInCustomerClientId = this.LinkedInCustomerClientId;
            section.UICustomSiteSettings.CurrentLinkedInCustomerClientSecret = this.LinkedInCustomerClientSecret;
            section.UICustomSiteSettings.CurrentLinkedInCustomerIntegrationContext = this.LinkedInCustomerIntegrationContext;
            section.UICustomSiteSettings.CurrentLinkedInSocialHandlerUrl = this.LinkedInSocialHandlerUrl;

            manager.SaveSection(section);
        }
        #endregion
    }
}