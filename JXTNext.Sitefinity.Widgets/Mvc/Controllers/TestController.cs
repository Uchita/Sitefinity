using JXTNext.Sitefinity.Common.Models;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using Ninject;
using System.Collections.Generic;
using System.Web.Mvc;
using Telerik.Sitefinity.Frontend.Identity.Mvc.Models.Registration;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using Telerik.Sitefinity.Mvc;

namespace JXTNext.Sitefinity.Widgets.Authentication.Mvc.Controllers
{
    [EnhanceViewEngines]
    [ControllerToolboxItem(Name = "Test", Title = "Test", SectionName = "Remove")]
    public class TestController : Controller
    {
        public TestController(IEnumerable<IBusinessLogicsConnector> requestSession)
        {
            var abc = "Adgda";
        }


        /// <summary>
        /// Renders appropriate list view depending on the <see cref="TemplateName" />
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult" />.
        /// </returns>
        [RelativeRoute("")]
        public ActionResult Index(bool stsLogin = false)
        {
            return View();
        }
        
    }
}
