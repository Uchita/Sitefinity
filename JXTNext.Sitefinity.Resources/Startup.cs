using System;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Localization;

namespace JXTNext.Sitefinity.Resources
{
    public class Startup
    {
        public static void PreApplicationStart()
        {
            // With this method we subscribe for the Sitefinity Bootstrapper_Initialized event, which is fired after initialization of the Sitefinity application
            Bootstrapper.Bootstrapped += Bootstrapper_Bootstrapped;
        }

        private static void Bootstrapper_Bootstrapped(object sender, EventArgs e)
        {
            Res.RegisterResource<JxtAuthoringResources>();
        }
    }
}
