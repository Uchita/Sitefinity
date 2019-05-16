using JXTNext.Sitefinity.Custom.Security.Sanitizers;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Security.Sanitizers;

namespace JXTNext.Sitefinity.Custom
{
    public class Start
    {
        public static void PreApplicationStart()
        {
            ObjectFactory.Initialized += RegisterCommonTypesEventHandler;
        }

        private static void RegisterCommonTypesEventHandler(object sender, ExecutedEventArgs e)
        {
            if (e.CommandName == "RegisterCommonTypes")
            {
                ObjectFactory.Container.RegisterType<IHtmlSanitizer, CustomHtmlSanitizer>(new ContainerControlledLifetimeManager());
            }
        }
    }
}
