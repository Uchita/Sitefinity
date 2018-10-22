using Jxt.Sitefinity.Jobs.Model;
using Jxt.Sitefinity.Jobs.ViewModel;
using Jxt.Sitefinity.Jobs.ViewModel.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.UI;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Web;
using Telerik.Sitefinity.Web.Utilities;

namespace Jxt.Sitefinity.Jobs.Mvc.Controllers
{
    public class JobsBackendController: Controller
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
