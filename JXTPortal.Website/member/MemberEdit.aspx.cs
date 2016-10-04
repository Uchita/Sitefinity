using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.members
{
    public partial class MemberEdit : System.Web.UI.Page
    {
        #region Page Event handlers

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Redirect("/member/settings.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Member Edit");

        }

        #endregion


    }
}
