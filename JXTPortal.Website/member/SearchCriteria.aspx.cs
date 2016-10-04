using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.members
{
    public partial class SearchCriteria : System.Web.UI.Page
    {
        #region Page Event handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            // IMPORTANT - This PAGE IS REMOVED !!
            Response.Redirect("~/member/default.aspx");

            CommonPage.SetBrowserPageTitle(Page, "Search Criteria");

        }

        #endregion


    }
}
