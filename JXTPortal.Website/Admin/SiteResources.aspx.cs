using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Web.UI;

namespace JXTPortal.Website.Admin
{
    public partial class SiteResources : System.Web.UI.Page
    {
        #region Page
        /// <summary>
        /// Method to set GridView
        /// </summary>
        /// 
        protected void Page_Load(object sender, EventArgs e)
        {
            FormUtil.RedirectAfterUpdate(GridView1, "SiteResources.aspx?page={0}");
            FormUtil.SetPageIndex(GridView1, "page");
            FormUtil.SetDefaultButton((Button)GridViewSearchPanel1.FindControl("cmdSearch"));
        }
        #endregion

        #region GridView events

        protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Overwrite")
            {
                Response.Redirect("siteresourcesedit.aspx?DefaultResourceId=" + e.CommandArgument);
            }
        }

        #endregion
    }
}
