using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Web.Configuration;

namespace JXTNext.Sitefinity.Common.Models.Robots
{
    [ObjectInfo(typeof(ConfigDescriptions), Title = "UIRobotSettingsConfigDescriptions", Description = "UIRobotSettingsConfigDescriptions")]
    public class RobotSettingsUISettings : ConfigElement
    {
        public RobotSettingsUISettings(ConfigElement parent)
            : base(parent)
        {
        }

        /// <summary>
        /// Gets or sets the name of the time zone.
        /// </summary>
        /// <value>The name of the time zone.</value>
        [ConfigurationProperty("robotTextData")]
        [DescriptionResource(typeof(ConfigDescriptions), "RobotTextData")]

        [DataMember]
        public virtual String CurrentRobotTextData
        {
            get
            {
                return (String)this["robotTextData"];
            }
            set
            {
                this["robotTextData"] = value;
            }
        }
    }
}
