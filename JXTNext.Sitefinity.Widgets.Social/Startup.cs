using JXTNext.Sitefinity.Widgets.Social.SiteSettings.AddThis;
using System;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Abstractions.VirtualPath.Configuration;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Configuration.Web.UI.Basic;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Services;

namespace JXTNext.Sitefinity.Widgets.Social
{
    public class Startup
    {
        public static void PreApplicationStart()
        {
            Bootstrapper.Bootstrapped += Bootstrapper_Bootstrapped;
            Bootstrapper.Initialized += Bootstrapper_Initialized;
        }

        private static void Bootstrapper_Bootstrapped(object sender, EventArgs e)
        {
            SystemManager.RegisterBasicSettings<GenericBasicSettingsView<AddThisSettings, AddThisSettingsContract>>("AddThisConfig", "AddThis Social Share", "", true);
        }

        private static void Bootstrapper_Initialized(object sender, ExecutedEventArgs e)
        {
            if (e.CommandName == "RegisterRoutes")
            {
                var virtualPathConfig = Config.Get<VirtualPathSettingsConfig>();

                if (!virtualPathConfig.VirtualPaths.Contains("~/JXTNext/Social/*"))
                {
                    var virtaulPathElement = new VirtualPathElement(virtualPathConfig.VirtualPaths)
                    {
                        ResourceLocation = "JXTNext.Sitefinity.Widgets.Social",
                        ResolverName = "EmbeddedResourceResolver",
                        VirtualPath = "~/JXTNext/Social/*"
                    };

                    virtualPathConfig.VirtualPaths.Add(virtaulPathElement);
                }
            }
        }
    }
}
