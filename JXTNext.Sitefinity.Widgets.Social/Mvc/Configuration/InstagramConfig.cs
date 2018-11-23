using System;
using System.Configuration;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Web.Configuration;
using System.Runtime.Serialization;
using Telerik.Sitefinity.Abstractions;


namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Configuration
{
    [ObjectInfo(Title = "Instagram", Description = "Instagram")]
    public class InstagramConfig : ConfigSection
    {
        [ObjectInfo(Title = "Expiration", Description = "How long to cache Instagram feed data (in minutes)")]
        [ConfigurationProperty("instagramExpiration", DefaultValue = 10)]
        public int Expiration
        {
            get
            {
                return (int)this["InstagramExpiration"];
            }
            set
            {
                this["InstagramExpiration"] = value;
            }
        }

        [ObjectInfo(Title = "Max Items", Description = "Maximum number of items to show")]
        [ConfigurationProperty("instagramMaxItems", DefaultValue = 5)]
        public int MaxItems
        {
            get
            {
                return (int)this["InstagramMaxItems"];
            }
            set
            {
                this["InstagramMaxItems"] = value;
            }
        }

        [ObjectInfo(Title = "Client ID")]
        [ConfigurationProperty("instagramClientIdToken")]
        public string ClientID
        {
            get
            {
                return (string)this["InstagramClientIdToken"];
            }
            set
            {
                this["InstagramClientIdToken"] = value;
            }
        }

        [ObjectInfo(Title = "Client Secret")]
        [ConfigurationProperty("instagramClientSecret")]
        public string ClientSecret
        {
            get
            {
                return (string)this["InstagramClientSecret"];
            }
            set
            {
                this["InstagramClientSecret"] = value;
            }
        }

        [ObjectInfo(Title = "Access Token")]
        [ConfigurationProperty("instagramAccessToken")]
        public string AccessToken
        {
            get
            {
                return (string)this["InstagramAccessToken"];
            }
            set
            {
                this["InstagramAccessToken"] = value;
            }
        }
    }
}
