using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Web.UI;

namespace JXTPortal.Website.Admin
{
    public partial class DefaultResources : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FormUtil.RedirectAfterUpdate(GridView1, "defaultresources.aspx?page={0}");
            FormUtil.SetPageIndex(GridView1, "page");
            //FormUtil.SetDefaultButton((Button)GridViewSearchPanel1.FindControl("cmdSearch"));
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string urlParams = string.Format("DefaultResourceId={0}", GridView1.SelectedDataKey.Values[0]);
            Response.Redirect("defaultresourcesedit.aspx?" + urlParams, true);
        }
    }
}
