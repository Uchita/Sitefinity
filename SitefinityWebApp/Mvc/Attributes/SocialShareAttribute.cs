using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Telerik.Sitefinity.Frontend.SocialShare.Mvc.Controllers;

namespace SitefinityWebApp.Mvc.Attributes
{
    public class SocialShareAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var controller = filterContext.Controller;

            if (controller.GetType().FullName == typeof(SocialShareController).FullName
                && filterContext.ActionDescriptor.ActionName == "Index")
            {
                if (filterContext.RouteData != null && filterContext.RouteData.Values.ContainsKey(SocialShareOptionsHelper.TemplateNameKey))
                {
                    var templateName = filterContext.RouteData.Values[SocialShareOptionsHelper.TemplateNameKey];
                    if (templateName != null && !string.IsNullOrEmpty(templateName.ToString()))
                    {
                        var ssController = controller as SocialShareController;
                        ssController.TemplateName = templateName.ToString();
                    }
                }
            }
        }
    }

    public static class SocialShareOptionsHelper
    {
        public static System.Web.Mvc.MvcHtmlString SocialShareOptions(this HtmlHelper helper, Telerik.Sitefinity.Model.IHasTitle dataItem, string templateName)
        {
            System.Web.Mvc.MvcHtmlString result;
            try
            {
                // Default Implementation from https://github.com/Sitefinity/feather/blob/68eb70be27d7925299002930b364088db2703f31/Telerik.Sitefinity.Frontend/Mvc/Helpers/SocialShareHelpers.cs
                RouteValueDictionary routeValues = new RouteValueDictionary();
                routeValues.Add(SocialShareOptionsHelper.DataItemKey, dataItem);
                // Add template name
                routeValues.Add(TemplateNameKey, templateName);
                result = helper.Action(ActionName, ControllerName, routeValues);
            }
            catch (HttpException)
            {
                result = new System.Web.Mvc.MvcHtmlString("The SocialShare widget could not be found.");
            }

            return result;
        }

        public const string DataItemKey = "DataItem";
        public const string TemplateNameKey = "TemplateName";

        private const string ActionName = "Index";
        private const string ControllerName = "SocialShare";
    }
}