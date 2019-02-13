using System;
using System.Runtime.Serialization;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.SiteSettings;

namespace JXTNext.Sitefinity.Common.Models.Robots
{
    [DataContract]
    public class RobotSettingsContract : ISettingsDataContract
    {

        [DataMember]
        public string RobotTextData
        {
            get;
            set;
        }


        public void LoadDefaults(bool forEdit = false)
        {
            RobotSettingsConfig section;
            if (forEdit)
                section = ConfigManager.GetManager().GetSection<RobotSettingsConfig>();
            else
                section = Config.Get<RobotSettingsConfig>();

            this.RobotTextData = section.UICustomSiteSettings.CurrentRobotTextData;
        }

        public void SaveDefaults()
        {
            var manager = ConfigManager.GetManager();
            var section = manager.GetSection<RobotSettingsConfig>();

            section.UICustomSiteSettings.CurrentRobotTextData = this.RobotTextData;
        }
    }
}
