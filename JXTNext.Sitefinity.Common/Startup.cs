using JXTNext.Sitefinity.Common.Models.CustomSiteSettings;
using JXTNext.Sitefinity.Common.Models.Robots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration.Web.UI.Basic;
using Telerik.Sitefinity.Services;

namespace JXTNext.Sitefinity.Common
{
    public class Startup
    {
        public static void PreApplicationStart()
        {
            Bootstrapper.Bootstrapped += Bootstrapper_Bootstrapped;
        }

        private static void Bootstrapper_Bootstrapped(object sender, EventArgs e)
        {
            SystemManager.RegisterBasicSettings<GenericBasicSettingsView<CustomSiteSettings, CustomSiteSettingsContract>>("CustomSiteSettingsConfig", "Custom Site Settings", "", true);
            SystemManager.RegisterBasicSettings<GenericBasicSettingsView<RobotSettings, RobotSettingsContract>>("RobotSettingsConfig", "Robot Settings", "", true);
        }
    }
}
