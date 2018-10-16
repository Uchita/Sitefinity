﻿using JXTNext.Sitefinity.Common.Models.CustomSiteSettings;
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

        private const string _itemType = "JXTNext.Sitefinity.Common.Models.CustomSiteSettings.CustomSiteSettingsContract";
        private CustomSiteSettingsContract _siteSettingsContract = null;
    }
}
