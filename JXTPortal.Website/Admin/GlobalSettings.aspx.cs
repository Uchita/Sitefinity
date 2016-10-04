

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
using JXTPortal.Entities;
#endregion

public partial class GlobalSettings : System.Web.UI.Page
{
    #region Page

    /// <summary>
    /// Method to set GridView
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        FormUtil.RedirectAfterUpdate(GridView1, "GlobalSettings.aspx?page={0}");
        FormUtil.SetPageIndex(GridView1, "page");
        
        // To display only per Site
        GlobalSettingsDataSource.Parameters.Add("SiteId", SessionData.Site.SiteId.ToString());
    }

    #endregion

    #region GridView1 Events

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string urlParams = string.Format("GlobalSettingId={0}", GridView1.SelectedDataKey.Values[0]);
        Response.Redirect("globalsettingsedit.aspx?" + urlParams, true);
    }

    #endregion
}


