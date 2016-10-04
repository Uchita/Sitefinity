using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.members
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        #region Page Event handlers

        protected void Page_Load(object sender, EventArgs e)
        {

            CommonPage.SetBrowserPageTitle(Page, "Change Password");
        }

        #endregion


    }
}
