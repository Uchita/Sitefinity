

#region Using directives
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JXTPortal.Web.UI;
#endregion

public partial class WidgetContainers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FormUtil.RedirectAfterUpdate(GridView1, "WidgetContainers.aspx?page={0}");
        FormUtil.SetPageIndex(GridView1, "page");


        // To display only per Site
        WidgetContainersDataSource.Parameters.Add("SiteId", JXTPortal.Entities.SessionData.Site.SiteId.ToString());
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string urlParams = string.Format("WidgetId={0}", GridView1.SelectedDataKey.Values[0]);
        Response.Redirect("WidgetContainersEdit.aspx?" + urlParams, true);
    }

    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow r in GridView1.Rows)
        {
            foreach (Control c in r.Controls)
            {
                if (c.Controls.Count > 0 && c is DataControlFieldCell)
                {
                    if (c.Controls[0] is LinkButton && ((LinkButton)c.Controls[0]).Text == "Delete")
                        ((LinkButton)c.Controls[0]).OnClientClick = "return confirm('Are you sure you want to delete this widget?')";
                }
            }
        }
    }

}


