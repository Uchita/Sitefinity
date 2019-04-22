using JXTNext.Sitefinity.Widgets.Content.Mvc.Models.PageBanner;
using Ninject.Modules;

namespace JXTNext.Sitefinity.Widgets.Content
{
    /// <summary>
    /// This class is used to describe the bindings which will be used by the Ninject container when resolving classes
    /// </summary>
    public class InterfaceMappings : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<IPageBannerModel>().To<PageBannerModel>();
        }
    }
}
