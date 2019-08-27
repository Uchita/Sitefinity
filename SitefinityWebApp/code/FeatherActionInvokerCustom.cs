using System.Web;
using JXTNext.Telemetry;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Routing;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Services;

namespace SitefinityWebApp.code
{
    /// <summary>
    /// Handles error status codes. Replaces the FeatherActionInvoker and allows the developer 
    /// to copy the Response.Status and Response.StatusCode from your controllers action to the page current HttpContext.
    /// We can then use MVC controllers where you set a response status code, and this status code will propagate to the current HttpContext. 
    /// see: https://www.progress.com/documentation/sitefinity-cms/change-the-response-status-of-the-custom-error-page-of-mvc-pages-mvc
    /// </summary>
    public class FeatherActionInvokerCustom : FeatherActionInvoker
    {

        protected override void RestoreHttpContext(string output, HttpContext initialContext)
        {
            using (new StatsDPerformanceMeasure("FeatherActionInvokerCustom.RestoreHttpContext"))
            {
                this.PopulateResponseStatus(System.Web.HttpContext.Current, initialContext);

                base.RestoreHttpContext(output, initialContext);
            }
        }

        private void PopulateResponseStatus(HttpContext httpContext, HttpContext initialContext)
        {
            using (new StatsDPerformanceMeasure("FeatherActionInvokerCustom.PopulateResponseStatus"))
            {
                if (!SystemManager.IsDesignMode && httpContext.Response.StatusCode != 200)
                {
                    initialContext.Response.Status = httpContext.Response.Status;
                    initialContext.Response.StatusCode = httpContext.Response.StatusCode;
                    initialContext.Response.StatusDescription = httpContext.Response.StatusDescription;
                }
            }
        }

        internal static void Register()
        {
            using (new StatsDPerformanceMeasure("FeatherActionInvokerCustom.Register"))
            {
                ObjectFactory.Container.RegisterType<IControllerActionInvoker, FeatherActionInvokerCustom>();
            }
        }
    }
}