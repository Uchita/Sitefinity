using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JXTPortal.Website.members
{
    public partial class PublicProfile : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Member Profile");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Entities.SessionData.AdvertiserUser == null)
            {
                Response.Redirect("~/advertiser/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
                return;
            }
        }
    }
}
