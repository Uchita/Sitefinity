using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "LinkedInCustomerConfiguration_AdminWidget", Title = "LinkedIn Customer Configuration", SectionName = "JXTNext.Social")]
    public class LinkedInCustomerConfigurationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }
    }
}
