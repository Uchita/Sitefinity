using JXTNext.Sitefinity.Widgets.Social.SiteSettings.AddThis;
using System;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration.Web.UI.Basic;
using Telerik.Sitefinity.Services;

namespace JXTNext.Sitefinity.Widgets.Social
{
    public class Startup
    {
        public static void PreApplicationStart()
        {
            Bootstrapper.Bootstrapped += Bootstrapper_Bootstrapped;
        }

        private static void Bootstrapper_Bootstrapped(object sender, EventArgs e)
        {
            SystemManager.RegisterBasicSettings<GenericBasicSettingsView<AddThisSettings, AddThisSettingsContract>>("AddThisConfig", "AddThis Social Share", "", true);
        }
    }
}
