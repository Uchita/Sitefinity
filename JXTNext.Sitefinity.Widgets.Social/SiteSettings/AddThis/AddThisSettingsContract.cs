using System.Runtime.Serialization;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.SiteSettings;
using Telerik.Sitefinity.SiteSettings.Basic;

namespace JXTNext.Sitefinity.Widgets.Social.SiteSettings.AddThis
{
    [DataContract]
    public class AddThisSettingsContract : ConfigSettingsContractBase, ISettingsDataContract, IAddThisSettings
    {
        [DataMember]
        public string PublisherId { get; set; }

        [DataMember]
        public bool FacebookEnabled { get; set; }
        [DataMember]
        public string FacebookIcon { get; set; }
        [DataMember]
        public string FacebookImage { get; set; }
        [DataMember]
        public int FacebookPosition { get; set; }

        [DataMember]
        public bool TwitterEnabled { get; set; }
        [DataMember]
        public string TwitterIcon { get; set; }
        [DataMember]
        public string TwitterImage { get; set; }
        [DataMember]
        public int TwitterPosition { get; set; }

        [DataMember]
        public bool LinkedInEnabled { get; set; }
        [DataMember]
        public string LinkedInIcon { get; set; }
        [DataMember]
        public string LinkedInImage { get; set; }
        [DataMember]
        public int LinkedInPosition { get; set; }

        [DataMember]
        public bool WeChatEnabled { get; set; }
        [DataMember]
        public string WeChatIcon { get; set; }
        [DataMember]
        public string WeChatImage { get; set; }
        [DataMember]
        public int WeChatPosition { get; set; }

        [DataMember]
        public string CssClass { get; set; }

        public void LoadDefaults(bool forEdit = false)
        {
            AddThisConfig section;

            if (forEdit)
            {
                section = ConfigManager.GetManager().GetSection<AddThisConfig>();
            }
            else
            {
                section = Config.Get<AddThisConfig>();
            }

            var settings = section.UIAddThisSettings;

            PublisherId = settings.CurrentPublisherId;

            FacebookEnabled = settings.CurrentFacebookEnabled;
            FacebookIcon = settings.CurrentFacebookIcon;
            FacebookImage = settings.CurrentFacebookImage;
            FacebookPosition = settings.CurrentFacebookPosition;

            TwitterEnabled = settings.CurrentTwitterEnabled;
            TwitterIcon = settings.CurrentTwitterIcon;
            TwitterImage = settings.CurrentTwitterImage;
            TwitterPosition = settings.CurrentTwitterPosition;

            LinkedInEnabled = settings.CurrentLinkedInEnabled;
            LinkedInIcon = settings.CurrentLinkedInIcon;
            LinkedInImage = settings.CurrentLinkedInImage;
            LinkedInPosition = settings.CurrentLinkedInPosition;

            WeChatEnabled = settings.CurrentWeChatEnabled;
            WeChatIcon = settings.CurrentWeChatIcon;
            WeChatImage = settings.CurrentWeChatImage;
            WeChatPosition = settings.CurrentWeChatPosition;

            CssClass = settings.CurrentCssClass;
        }

        public void SaveDefaults()
        {
            var manager = ConfigManager.GetManager();
            var section = manager.GetSection<AddThisConfig>();

            var settings = section.UIAddThisSettings;

            settings.CurrentPublisherId = PublisherId;

            settings.CurrentFacebookEnabled = FacebookEnabled;
            settings.CurrentFacebookIcon = FacebookIcon;
            settings.CurrentFacebookImage = FacebookImage;
            settings.CurrentFacebookPosition = FacebookPosition;

            settings.CurrentTwitterEnabled = TwitterEnabled;
            settings.CurrentTwitterIcon = TwitterIcon;
            settings.CurrentTwitterImage = TwitterImage;
            settings.CurrentTwitterPosition = TwitterPosition;

            settings.CurrentLinkedInEnabled = LinkedInEnabled;
            settings.CurrentLinkedInIcon = LinkedInIcon;
            settings.CurrentLinkedInImage = LinkedInImage;
            settings.CurrentLinkedInPosition = LinkedInPosition;

            settings.CurrentWeChatEnabled = WeChatEnabled;
            settings.CurrentWeChatIcon = WeChatIcon;
            settings.CurrentWeChatImage = WeChatImage;
            settings.CurrentWeChatPosition = WeChatPosition;

            settings.CurrentCssClass = CssClass;

            manager.SaveSection(section);
        }

        protected override ConfigElement GetConfigElement(bool forEdit, out ConfigManager manager)
        {
            if (!forEdit)
            {
                manager = null;
                return Config.Get<AddThisConfig>();
            }

            manager = ConfigManager.GetManager();
            return manager.GetSection<AddThisConfig>();
        }
    }
}
