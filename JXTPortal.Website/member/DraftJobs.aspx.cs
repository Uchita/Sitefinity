using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JXTPortal.Website.member
{
    public partial class DraftJobs : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Draft Jobs");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}