using System.Configuration;
using System.Runtime.Serialization;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Web.Configuration;

namespace JXTNext.Sitefinity.Widgets.Social.SiteSettings.AddThis
{
    [ObjectInfo(typeof(ConfigDescriptions), Title = "UIAddThisConfigDescriptions", Description = "UIAddThisConfigDescriptions")]
    public class AddThisSettingsUISettings : ConfigElement
    {
        public AddThisSettingsUISettings(ConfigElement parent)
            : base(parent)
        {
        }

        [ConfigurationProperty("publisherId")]
        [DescriptionResource(typeof(ConfigDescriptions), "PublisherId")]
        [DataMember]
        public virtual string CurrentPublisherId
        {
            get
            {
                return (string)this["publisherId"];
            }
            set
            {
                this["publisherId"] = value;
            }
        }

        [ConfigurationProperty("facebookEnabled")]
        [DescriptionResource(typeof(ConfigDescriptions), "FacebookEnabled")]
        [DataMember]
        public virtual bool CurrentFacebookEnabled
        {
            get
            {
                return (bool)this["facebookEnabled"];
            }
            set
            {
                this["facebookEnabled"] = value;
            }
        }

        [ConfigurationProperty("facebookIcon")]
        [DescriptionResource(typeof(ConfigDescriptions), "FacebookIcon")]
        [DataMember]
        public virtual string CurrentFacebookIcon
        {
            get
            {
                return (string)this["facebookIcon"];
            }
            set
            {
                this["facebookIcon"] = value;
            }
        }

        [ConfigurationProperty("facebookImage")]
        [DescriptionResource(typeof(ConfigDescriptions), "FacebookImage")]
        [DataMember]
        public virtual string CurrentFacebookImage
        {
            get
            {
                return (string)this["facebookImage"];
            }
            set
            {
                this["facebookImage"] = value;
            }
        }

        [ConfigurationProperty("facebookPosition")]
        [DescriptionResource(typeof(ConfigDescriptions), "FacebookPosition")]
        [DataMember]
        public virtual int CurrentFacebookPosition
        {
            get
            {
                return (int)this["facebookPosition"];
            }
            set
            {
                this["facebookPosition"] = value;
            }
        }

        [ConfigurationProperty("twitterEnabled")]
        [DescriptionResource(typeof(ConfigDescriptions), "TwitterEnabled")]
        [DataMember]
        public virtual bool CurrentTwitterEnabled
        {
            get
            {
                return (bool)this["twitterEnabled"];
            }
            set
            {
                this["twitterEnabled"] = value;
            }
        }

        [ConfigurationProperty("twitterIcon")]
        [DescriptionResource(typeof(ConfigDescriptions), "TwitterIcon")]
        [DataMember]
        public virtual string CurrentTwitterIcon
        {
            get
            {
                return (string)this["twitterIcon"];
            }
            set
            {
                this["twitterIcon"] = value;
            }
        }

        [ConfigurationProperty("twitterImage")]
        [DescriptionResource(typeof(ConfigDescriptions), "TwitterImage")]
        [DataMember]
        public virtual string CurrentTwitterImage
        {
            get
            {
                return (string)this["twitterImage"];
            }
            set
            {
                this["twitterImage"] = value;
            }
        }

        [ConfigurationProperty("twitterPosition")]
        [DescriptionResource(typeof(ConfigDescriptions), "TwitterPosition")]
        [DataMember]
        public virtual int CurrentTwitterPosition
        {
            get
            {
                return (int)this["twitterPosition"];
            }
            set
            {
                this["twitterPosition"] = value;
            }
        }

        [ConfigurationProperty("linkedInEnabled")]
        [DescriptionResource(typeof(ConfigDescriptions), "LinkedInEnabled")]
        [DataMember]
        public virtual bool CurrentLinkedInEnabled
        {
            get
            {
                return (bool)this["linkedInEnabled"];
            }
            set
            {
                this["linkedInEnabled"] = value;
            }
        }

        [ConfigurationProperty("linkedInIcon")]
        [DescriptionResource(typeof(ConfigDescriptions), "LinkedInIcon")]
        [DataMember]
        public virtual string CurrentLinkedInIcon
        {
            get
            {
                return (string)this["linkedInIcon"];
            }
            set
            {
                this["linkedInIcon"] = value;
            }
        }

        [ConfigurationProperty("linkedInImage")]
        [DescriptionResource(typeof(ConfigDescriptions), "LinkedInImage")]
        [DataMember]
        public virtual string CurrentLinkedInImage
        {
            get
            {
                return (string)this["linkedInImage"];
            }
            set
            {
                this["linkedInImage"] = value;
            }
        }

        [ConfigurationProperty("linkedInPosition")]
        [DescriptionResource(typeof(ConfigDescriptions), "LinkedInPosition")]
        [DataMember]
        public virtual int CurrentLinkedInPosition
        {
            get
            {
                return (int)this["linkedInPosition"];
            }
            set
            {
                this["linkedInPosition"] = value;
            }
        }

        [ConfigurationProperty("weChatEnabled")]
        [DescriptionResource(typeof(ConfigDescriptions), "WeChatEnabled")]
        [DataMember]
        public virtual bool CurrentWeChatEnabled
        {
            get
            {
                return (bool)this["weChatEnabled"];
            }
            set
            {
                this["weChatEnabled"] = value;
            }
        }

        [ConfigurationProperty("weChatIcon")]
        [DescriptionResource(typeof(ConfigDescriptions), "WeChatIcon")]
        [DataMember]
        public virtual string CurrentWeChatIcon
        {
            get
            {
                return (string)this["weChatIcon"];
            }
            set
            {
                this["weChatIcon"] = value;
            }
        }

        [ConfigurationProperty("weChatImage")]
        [DescriptionResource(typeof(ConfigDescriptions), "WeChatImage")]
        [DataMember]
        public virtual string CurrentWeChatImage
        {
            get
            {
                return (string)this["weChatImage"];
            }
            set
            {
                this["weChatImage"] = value;
            }
        }

        [ConfigurationProperty("weChatPosition")]
        [DescriptionResource(typeof(ConfigDescriptions), "WeChatPosition")]
        [DataMember]
        public virtual int CurrentWeChatPosition
        {
            get
            {
                return (int)this["weChatPosition"];
            }
            set
            {
                this["weChatPosition"] = value;
            }
        }

        [ConfigurationProperty("cssClass")]
        [DescriptionResource(typeof(ConfigDescriptions), "CssClass")]
        [DataMember]
        public virtual string CurrentCssClass
        {
            get
            {
                return (string)this["cssClass"];
            }
            set
            {
                this["cssClass"] = value;
            }
        }
    }
}
