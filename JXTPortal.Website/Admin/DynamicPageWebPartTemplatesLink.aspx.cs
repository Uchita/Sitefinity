

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

public partial class DynamicPageWebPartTemplatesLink : System.Web.UI.Page
{	
    protected void Page_Load(object sender, EventArgs e)
	{
		FormUtil.RedirectAfterUpdate(GridView1, "DynamicPageWebPartTemplatesLink.aspx?page={0}");
		FormUtil.SetPageIndex(GridView1, "page");
        FormUtil.SetDefaultButton((Button)GridViewSearchPanel1.FindControl("cmdSearch"));

        // To display only per Site
        DynamicPageWebPartTemplatesLinkDataSource.Parameters.Add("SiteId", JXTPortal.Entities.SessionData.Site.SiteId.ToString());

    }

	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("DynamicPageWebPartTemplatesLinkId={0}", GridView1.SelectedDataKey.Values[0]);
		Response.Redirect("DynamicPageWebPartTemplatesLinkEdit.aspx?" + urlParams, true);
	}
	
}


