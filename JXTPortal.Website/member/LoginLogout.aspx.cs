using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Common;

namespace JXTPortal.Website.member
{
    public partial class LoginLogout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbLoginLogout.Text = (SessionData.Member == null) ? CommonFunction.GetResourceValue("LabelLogin") : CommonFunction.GetResourceValue("LabelLogout");
        }

        protected void lbLoginLogout_Click(object sender, EventArgs e)
        {
            if (SessionData.Member == null)
            {
                Response.Redirect("~/member/login.aspx");
            }
            else
            {
                SessionService.RemoveMember();
                Response.Redirect("~/");
            }
        }
    }
}
