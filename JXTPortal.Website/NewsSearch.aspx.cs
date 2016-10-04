using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace JXTPortal.Website
{
    public partial class NewsSearch : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "News Search");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
