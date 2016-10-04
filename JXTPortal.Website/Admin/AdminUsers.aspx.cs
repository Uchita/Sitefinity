

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
using JXTPortal;
using System.Collections;
#endregion

public partial class AdminUsers : System.Web.UI.Page
{
    /*
    #region Properties

    public int CurrentPage
    {

        get
        {
            if (this.ViewState["CurrentPage"] == null)
                return 0;
            else
                return Convert.ToInt16(this.ViewState["CurrentPage"].ToString());
        }

        set
        {
            this.ViewState["CurrentPage"] = value;
        }

    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
	{
		FormUtil.RedirectAfterUpdate(GridView1, "AdminUsers.aspx?page={0}");
		FormUtil.SetPageIndex(GridView1, "page");
        //FormUtil.SetDefaultButton((Button)GridViewSearchPanel1.FindControl("cmdSearch"));

        // To display only per Site
        //AdminUsersDataSource.Parameters.Add("SiteId", SessionData.Site.SiteId.ToString());

        AdminUsersService AdminUsersService = new AdminUsersService();
        TList<JXTPortal.Entities.AdminUsers> adminUsers = AdminUsersService.GetBySiteId(SessionData.Site.SiteId);

        if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.ContentEditor)
        {
            adminUsers.Filter = "AdminRoleID > 1";
        }
        
        GridView1.DataSource = adminUsers;
        GridView1.DataBind();
        adminUsers.Dispose();

    }

	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("AdminUserId={0}", GridView1.SelectedDataKey.Values[0]);
		Response.Redirect("AdminUsersEdit.aspx?" + urlParams, true);
	}

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        CurrentPage = e.NewPageIndex;

        FormUtil.SetPageIndex(GridView1, "page");
        int intSitePaging = JXTPortal.Common.Utils.GetAppSettingsInt("SitePaging");
        int totalCount = 0;
        AdminUsersService AdminUsersService = new AdminUsersService();
        TList<JXTPortal.Entities.AdminUsers> adminUsers = AdminUsersService.GetBySiteId(SessionData.Site.SiteId, CurrentPage * intSitePaging, intSitePaging, out totalCount);

        if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.ContentEditor)
        {
            adminUsers.Filter = "AdminRoleID > 1";
        }

        GridView1.DataSource = adminUsers;
        GridView1.DataBind();
        adminUsers.Dispose();
    }
    */

    #region Properties

    private AdminUsersService _AdminUsersService;
    private AdminUsersService AdminUsersService
    {
        get
        {
            if (_AdminUsersService == null) _AdminUsersService = new AdminUsersService();

            return _AdminUsersService;
        }
    }

    public int CurrentPage
    {

        get
        {
            if (this.ViewState["CurrentPage"] == null)
                return 0;
            else
                return Convert.ToInt16(this.ViewState["CurrentPage"].ToString());
        }

        set
        {
            this.ViewState["CurrentPage"] = value;
        }

    }

    #endregion

    #region Page Event handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Load();
        }
    }

    #endregion

    #region Events

    protected void rptAdminUsers_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            JXTPortal.Entities.AdminUsers adminusers = e.Item.DataItem as JXTPortal.Entities.AdminUsers;
            Literal ltType = e.Item.FindControl("ltType") as Literal;

            ltType.Text = JXTPortal.Website.CommonFunction.GetEnumDescription((PortalEnums.Admin.AdminRole)adminusers.AdminRoleId);
            //Enum.GetName(typeof(PortalEnums.Admin.AdminRole), adminusers.AdminRoleId);

        }
    }

    protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Page")
        {
            if (e.CommandArgument.ToString() == "prev")
            {
                CurrentPage = ((CurrentPage + 1) / 10 * 10 - 1);
            }
            else if (e.CommandArgument.ToString() == "next")
            {
                CurrentPage = ((CurrentPage + 10) / 10 * 10);
            }
            else
            {
                CurrentPage = Convert.ToInt32(e.CommandArgument);
            }
            Load();
        }
    }

    protected void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lbPageNo = e.Item.FindControl("lbPageNo") as LinkButton;

            if (e.Item.DataItem.ToString() == "previous")
            {
                lbPageNo.Text = "...";
                lbPageNo.CommandArgument = "prev";
            }
            else if (e.Item.DataItem.ToString() == "next")
            {
                lbPageNo.Text = "...";
                lbPageNo.CommandArgument = "next";
            }
            else
            {
                lbPageNo.CommandArgument = (Convert.ToInt32(e.Item.DataItem)).ToString();
                lbPageNo.Text = (Convert.ToInt32(e.Item.DataItem) + 1).ToString();
            }

            if (lbPageNo.CommandArgument == CurrentPage.ToString())
            {
                lbPageNo.Enabled = false;
                lbPageNo.Font.Underline = false;
                lbPageNo.ForeColor = System.Drawing.Color.Black;
            }
        }
    }

    #endregion

    #region Method

    private void Load()
    {
        int totalCount = 0;
        int pageCount = 0;
        int sitePageCount = JXTPortal.Common.Utils.GetAppSettingsInt("SitePaging");

        string whereClause = "SiteID = " + SessionData.Site.SiteId;


        TList<JXTPortal.Entities.AdminUsers> objAdminUsers = new TList<JXTPortal.Entities.AdminUsers>();
        whereClause = "AdminRoleID > 1 AND SiteID = " + SessionData.Site.SiteId;

        if (SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.ContentEditor)
        {
            whereClause = "AdminRoleID > 1 AND AdminRoleID <> 5 AND SiteID = " + SessionData.Site.SiteId;
        }

        objAdminUsers = AdminUsersService.GetPaged(whereClause, "AdminUserID", CurrentPage, sitePageCount, out totalCount);


        if (objAdminUsers.Count > 0)
        {
            lblErrorMsg.Visible = false;

            ArrayList pagelist = new ArrayList();

            if (totalCount % sitePageCount == 0)
                pageCount = totalCount / sitePageCount;
            else
                pageCount = (totalCount / sitePageCount) + 1;

            if (CurrentPage >= 10)
            {
                pagelist.Add("previous");
            }

            int index = (CurrentPage == 0) ? 0 : (CurrentPage) / 10 * 10;
            for (int i = index; i < pageCount; i++)
            {
                pagelist.Add(i.ToString());

                if ((i % 10) == 9 && (i < pageCount - 1))
                {
                    pagelist.Add("next");
                    break;
                }

            }

            if (pagelist.Count > 1)
            {
                rptPage.DataSource = pagelist;
                rptPage.DataBind();
                rptPage.Visible = true;
            }
            else
            {
                rptPage.Visible = false;
            }

            if (pagelist.Count > 1)
            {
                rptPage.DataSource = pagelist;
                rptPage.DataBind();
                rptPage.Visible = true;
            }
            else
            {
                rptPage.Visible = false;
            }

            rptAdminUsers.DataSource = objAdminUsers;
            rptAdminUsers.DataBind();

        }
        else
        {
            lblErrorMsg.Visible = true;
            lblErrorMsg.Text = "No result Found";
            rptAdminUsers.DataSource = null;
            rptAdminUsers.DataBind();
            rptPage.DataSource = null;
            rptPage.DataBind();
        }
    }

    #endregion
}


