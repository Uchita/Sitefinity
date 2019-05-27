using JXTNext.Sitefinity.Common.Models.CustomSiteSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.Multisite;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.SiteSettings.Web.Services;

namespace JXTNext.Sitefinity.Common.Helpers
{
    public class SiteSettingsHelper
    {
        public SiteSettingsHelper()
        {
            var basicSettingsSerivce = new BasicSettingsService();
            var multiSiteContext = new MultisiteContext();
            var currSite = multiSiteContext.CurrentSite;
            SettingsItemContext siteSetting = null;
            SystemManager.RunWithElevatedPrivilege(d => { siteSetting = basicSettingsSerivce.GetSettings(_itemType, currSite.Id.ToString()); });
            if (siteSetting != null)
                _siteSettingsContract = (CustomSiteSettingsContract)siteSetting.Item;
        }

        public string GetCurrentSiteCultureIsEnabled()
        {
            string cultureIsEnabled = "";
            if (this._siteSettingsContract != null)
                cultureIsEnabled = this._siteSettingsContract.CultureIsEnabled;

            return cultureIsEnabled;
        }

        public string GetCurrentSiteGoogleClientId()
        {
            string googleClentId = "";
            if (this._siteSettingsContract != null)
                googleClentId = this._siteSettingsContract.GoogleClientId;

            return googleClentId;
        }

        public string GetCurrentSiteGoogleClientSecret()
        {
            string googleClentSecret = "";
            if (this._siteSettingsContract != null)
                googleClentSecret = this._siteSettingsContract.GoogleClientSecret;

            return googleClentSecret;
        }

        public string GetCurrentSiteGoogleClientAPIKey()
        {
            string googleClentAPIKey = "";
            if (this._siteSettingsContract != null)
                googleClentAPIKey = this._siteSettingsContract.GoogleClientAPIKey;

            return googleClentAPIKey;
        }

        public string GetCurrentSiteGoogleMapsAPIKey()
        {
            string googleMapsAPIKey = "";
            if (this._siteSettingsContract != null)
                googleMapsAPIKey = this._siteSettingsContract.GoogleAPIKey;

            return googleMapsAPIKey;
        }

        public string GetCurrentSiteGoogleTagManagerKey()
        {
            string googleTagManagerKey = "";
            if (this._siteSettingsContract != null)
                googleTagManagerKey = this._siteSettingsContract.GoogleTagManagerKey;

            return googleTagManagerKey;
        }

        public string GetCurrentSiteDropboxAppId()
        {
            string dropboxAppId = "";
            if (this._siteSettingsContract != null)
                dropboxAppId = this._siteSettingsContract.DropboxAppId;

            return dropboxAppId;
        }

        public string GetCurrentSiteDropboxAppSecret()
        {
            string dropboxAppSecret = "";
            if (this._siteSettingsContract != null)
                dropboxAppSecret = this._siteSettingsContract.DropboxAppSecret;

            return dropboxAppSecret;
        }

        public string GetCurrentSiteDropboxClientAPIKey()
        {
            string dropboxClientAPIKey = "";
            if (this._siteSettingsContract != null)
                dropboxClientAPIKey = this._siteSettingsContract.DropboxClientAPIKey;

            return dropboxClientAPIKey;
        }

        public string GetCurrentSiteSeekClientId()
        {
            string seekClientId = "";
            if (this._siteSettingsContract != null)
                seekClientId = this._siteSettingsContract.SeekClientId;

            return seekClientId;
        }

        public string GetCurrentSiteSeekClientSecret()
        {
            string seekClientSecret = "";
            if (this._siteSettingsContract != null)
                seekClientSecret = this._siteSettingsContract.SeekClientSecret;

            return seekClientSecret;
        }

        public string GetCurrentSiteSeekClientAdvertiserId()
        {
            string seekClientAdvertiserId = "";
            if (this._siteSettingsContract != null)
                seekClientAdvertiserId = this._siteSettingsContract.SeekClientAdvertiserId;

            return seekClientAdvertiserId;
        }

        public string GetCurrentSiteSeekRedirectUri()
        {
            string seekRedirectUri = "";
            if (this._siteSettingsContract != null)
                seekRedirectUri = this._siteSettingsContract.SeekRedirectUri;

            return seekRedirectUri;
        }

        public string GetCurrentSiteIndeedClientAPIToken()
        {
            string indeedClientAPIToken = "";
            if (this._siteSettingsContract != null)
                indeedClientAPIToken = this._siteSettingsContract.IndeedClientAPIToken;

            return indeedClientAPIToken;
        }

        public string GetCurrentSiteIndeedClientSecret()
        {
            string indeedClientSecret = "";
            if (this._siteSettingsContract != null)
                indeedClientSecret = this._siteSettingsContract.IndeedClientSecret;

            return indeedClientSecret;
        }

        

        public string GetCurrentSiteInstagramClientIdToken()
        {
            string instagramClientIdToken = String.Empty;
            if (this._siteSettingsContract != null)
                instagramClientIdToken = this._siteSettingsContract.InstagramClientIdToken;

            return instagramClientIdToken;
        }

        public string GetCurrentSiteInstagramClientSecret()
        {
            string instagramClientSecret = String.Empty;
            if (this._siteSettingsContract != null)
                instagramClientSecret = this._siteSettingsContract.InstagramClientSecret;

            return instagramClientSecret;
        }

        public string GetCurrentSiteInstagramAccessToken()
        {
            string instagramAccessToken = String.Empty;
            if (this._siteSettingsContract != null)
                instagramAccessToken = this._siteSettingsContract.InstagramAccessToken;

            return instagramAccessToken;
        }

        
        public void SetCurrentSiteInstagramAccessToken(string instagramAccessToken)
        {
            if (this._siteSettingsContract != null && !string.IsNullOrEmpty(instagramAccessToken))
                 this._siteSettingsContract.InstagramAccessToken = instagramAccessToken;

        }

        public int GetCurrentSiteInstagramExpiration()
        {
            int instagramExpiration = 10;
            if (this._siteSettingsContract != null)
                instagramExpiration = this._siteSettingsContract.InstagramExpiration;

            return instagramExpiration;
        }

        public int GetCurrentSiteInstagramMaxItems()
        {
            int instagramMaxItems = 5;
            if (this._siteSettingsContract != null)
                instagramMaxItems = this._siteSettingsContract.InstagramMaxItems;

            return instagramMaxItems;
        }

        public string GetCurrentSiteLinkedInClientId()
        {
            return this._siteSettingsContract == null
                ? ""
                : this._siteSettingsContract.LinkedInClientId;
        }

        public string GetCurrentSiteLinkedInClientSecret()
        {
            return this._siteSettingsContract == null
                ? ""
                : this._siteSettingsContract.LinkedInClientSecret;
        }

        public string GetCurrentSiteLinkedInCustomerClientId()
        {
            return this._siteSettingsContract == null
                ? ""
                : this._siteSettingsContract.LinkedInCustomerClientId;
        }

        public string GetCurrentSiteLinkedInCustomerClientSecret()
        {
            return this._siteSettingsContract == null
                ? ""
                : this._siteSettingsContract.LinkedInCustomerClientSecret;
        }

        public string GetCurrentSiteLinkedInCustomerIntegrationContext()
        {
            return this._siteSettingsContract == null
                ? ""
                : this._siteSettingsContract.LinkedInCustomerIntegrationContext;
        }

        public string GetCurrentSiteLinkedInSocialHandlerUrl()
        {
            return this._siteSettingsContract == null
                ? ""
                : this._siteSettingsContract.LinkedInSocialHandlerUrl;
        }

        public string GetJobCurrencySymbol()
        {
            var currencySymbol = "$";

            if(this._siteSettingsContract != null && !this._siteSettingsContract.JobCurrencySymbol.IsNullOrEmpty())
            {
                currencySymbol = this._siteSettingsContract.JobCurrencySymbol;
            }

            return currencySymbol;
        }


        #region Amazon S3 Bucket
        public string GetAmazonS3AccessKeyId()
        {
            var amazonS3AccessKeyId = string.Empty;

            if (this._siteSettingsContract != null && !this._siteSettingsContract.AmazonS3AccessKeyId.IsNullOrEmpty())
            {
                amazonS3AccessKeyId = this._siteSettingsContract.AmazonS3AccessKeyId;
            }

            return amazonS3AccessKeyId;
        }

        public string GetAmazonS3SecretKey()
        {
            var amazonS3SecretKey = string.Empty;

            if (this._siteSettingsContract != null && !this._siteSettingsContract.AmazonS3SecretKey.IsNullOrEmpty())
            {
                amazonS3SecretKey = this._siteSettingsContract.AmazonS3SecretKey;
            }

            return amazonS3SecretKey;
        }

        public string GetAmazonS3BucketName()
        {
            var amazonS3BucketName = string.Empty;

            if (this._siteSettingsContract != null && !this._siteSettingsContract.AmazonS3BucketName.IsNullOrEmpty())
            {
                amazonS3BucketName = this._siteSettingsContract.AmazonS3BucketName;
            }

            return amazonS3BucketName;
        }

        public string GetAmazonS3RegionEndpoint()
        {
            var amazonS3RegionEndpoint = string.Empty;

            if (this._siteSettingsContract != null && !this._siteSettingsContract.AmazonS3RegionEndpoint.IsNullOrEmpty())
            {
                amazonS3RegionEndpoint = this._siteSettingsContract.AmazonS3RegionEndpoint;
            }

            return amazonS3RegionEndpoint;
        }

        public string GetAmazonS3ProviderName()
        {
            var amazonS3ProviderName = string.Empty;

            if (this._siteSettingsContract != null && !this._siteSettingsContract.AmazonS3ProviderName.IsNullOrEmpty())
            {
                amazonS3ProviderName = this._siteSettingsContract.AmazonS3ProviderName;
            }

            return amazonS3ProviderName;
        }


        public string GetAmazonS3ApplicationName()
        {
            var amazonS3ApplicationName = string.Empty;

            if (this._siteSettingsContract != null && !this._siteSettingsContract.AmazonS3ApplicationName.IsNullOrEmpty())
            {
                amazonS3ApplicationName = this._siteSettingsContract.AmazonS3ApplicationName;
            }

            return amazonS3ApplicationName;
        }

        public string GetAmazonS3UrlName()
        {
            var amazonS3UrlName = string.Empty;

            if (this._siteSettingsContract != null && !this._siteSettingsContract.AmazonS3UrlName.IsNullOrEmpty())
            {
                amazonS3UrlName = this._siteSettingsContract.AmazonS3UrlName;
            }

            return amazonS3UrlName;
        }


        #endregion




        private const string _itemType = "JXTNext.Sitefinity.Common.Models.CustomSiteSettings.CustomSiteSettingsContract";
        private CustomSiteSettingsContract _siteSettingsContract = null;
    }
}
