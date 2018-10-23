using System.Web.Mvc;
using System.Web.UI;
using Telerik.Sitefinity.Web;

namespace Jxt.Sitefinity.Jobs.Mvc.Controllers
{
    public class JobsBackendController : Controller
    {
        public ActionResult Index()
        {
            var absUrl = UrlPath.ResolveUrl("~/Sitefinity/Content/Jobs", true);
            var page = this.ControllerContext.RequestContext.HttpContext.Handler as System.Web.UI.Page;

            if (page != null)
                page.Header.Controls.Add(new LiteralControl("<base href='" + absUrl + "'/>"));

            return this.View("Index");
        }
    }
}