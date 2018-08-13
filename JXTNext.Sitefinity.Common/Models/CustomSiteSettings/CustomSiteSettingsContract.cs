using System;
using System.Runtime.Serialization;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.SiteSettings;

namespace JXTNext.Sitefinity.Common.Models.CustomSiteSettings
{
    [DataContract]
    public class CustomSiteSettingsContract : ISettingsDataContract
    {
        [DataMember]
        public string GoogleAPIKey
        {
            get;
            set;
        }

        public void LoadDefaults(bool forEdit = false)
        {
            CustomSiteSettingsConfig section;
            if (forEdit)
                section = ConfigManager.GetManager().GetSection<CustomSiteSettingsConfig>();
            else
                section = Config.Get<CustomSiteSettingsConfig>();

            this.GoogleAPIKey = section.UICustomSiteSettings.CurrentGoogleAPIKey;
        }

        public void SaveDefaults()
        {
            var manager = ConfigManager.GetManager();
            var section = manager.GetSection<CustomSiteSettingsConfig>();
            section.UICustomSiteSettings.CurrentGoogleAPIKey = this.GoogleAPIKey;
            manager.SaveSection(section);
        }
    }
}