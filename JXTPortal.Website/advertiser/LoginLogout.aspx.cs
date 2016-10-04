using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.advertiser
{
    public partial class LoginLogout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbLoginLogout.Text = (SessionData.AdvertiserUser == null) ? CommonFunction.GetResourceValue("LabelLogin") : CommonFunction.GetResourceValue("LabelLogout");
        }

        protected void lbLoginLogout_Click(object sender, EventArgs e)
        {
            if (SessionData.AdvertiserUser == null)
            {
                Response.Redirect("~/advertiser/login.aspx");
            }
            else
            {
                SessionService.RemoveAdvertiserUser();
                Response.Redirect("~/");
            }
        }
    }
}
