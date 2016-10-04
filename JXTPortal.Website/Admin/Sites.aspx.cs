

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
using JXTPortal;
using JXTPortal.Entities;
using System.Collections;
#endregion

public partial class Sites : System.Web.UI.Page
{
    #region Properties

    private SitesService _sitesService;
    private SitesService SitesService
    {
        get
        {
            if (_sitesService == null) _sitesService = new SitesService();

            return _sitesService;
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

    #region Return Properties

    public int? _siteID
    {
        get
        {
            if (Request.QueryString["all"] != null)
            {
                if (!string.IsNullOrEmpty(txtAdminSitesListingSiteID.Text.Trim()))
                {
                    return Convert.ToInt32(txtAdminSitesListingSiteID.Text.Trim());
                }
            }
            else
            {
                return SessionData.Site.SiteId;
            }
            return null;
        }
    }

    public string _siteName
    {
        get
        {
            if (!string.IsNullOrEmpty(txtAdminSitesListingSiteName.Text.Trim()))
            {
                return txtAdminSitesListingSiteName.Text.Trim();
            }
            return null;
        }
    }

    public string _siteURL
    {
        get
        {
            if (!string.IsNullOrEmpty(txtAdminSitesListingSiteURL.Text.Trim()))
            {
                return txtAdminSitesListingSiteURL.Text.Trim();
            }
            return null;
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

    protected void rptAdminSites_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal ltViewSite = e.Item.FindControl("ltViewSite") as Literal;
            Literal ltViewGlobalSetting = e.Item.FindControl("ltViewGlobalSetting") as Literal;
            Literal ltAdminSiteName = e.Item.FindControl("ltAdminSiteName") as Literal;
            Literal ltAdminSiteURL = e.Item.FindControl("ltAdminSiteURL") as Literal;
            Literal ltAdminSiteDesc = e.Item.FindControl("ltAdminSiteDesc") as Literal;
            Literal ltAdminSiteLastModifiedDate = e.Item.FindControl("ltAdminSiteLastModifiedDate") as Literal;
            Literal ltIsLive = e.Item.FindControl("ltIsLive") as Literal;

            DataRowView sites = (DataRowView)e.Item.DataItem;

            ltViewSite.Text = "Edit";
            ltViewGlobalSetting.Text = "Global Settings";
            ltAdminSiteName.Text = Convert.ToString(sites["SiteName"]);
            ltAdminSiteURL.Text = Convert.ToString(sites["SiteURL"]);
            ltAdminSiteDesc.Text = Convert.ToString(sites["SiteDescription"]);
            ltAdminSiteLastModifiedDate.Text = Convert.ToDateTime(sites["LastModified"]).ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
            ltIsLive.Text = (Convert.ToBoolean(sites["Live"])) ? "Yes" : "No";
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
                lbPageNo.CommandArgument = e.Item.DataItem.ToString();
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

        using (DataSet objSites = SitesService.GetPaging(_siteID, _siteName, _siteURL, sitePageCount, CurrentPage + 1))
        {
            if (SessionData.AdminUser != null && SessionData.AdminUser.isAdminUser)
            {

                if (objSites.Tables[0].Rows.Count > 0)
                {

                    if (Request.QueryString["all"] != null)
                    {

                        lblErrorMsg.Visible = false;

                        ArrayList pagelist = new ArrayList();
                        totalCount = Convert.ToInt32(objSites.Tables[0].Rows[0]["TotalCount"]);

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

                        rptAdminSites.DataSource = objSites;
                        rptAdminSites.DataBind();
                    }
                    else
                    {
                        pnlAdminSiteSearch.Visible = false;
                        rptAdminSites.DataSource = objSites;
                        rptAdminSites.DataBind();
                        rptPage.DataSource = null;
                        rptPage.DataBind();

                    }
                }
                else
                {
                    lblErrorMsg.Visible = true;
                    lblErrorMsg.Text = "No result Found";
                    rptAdminSites.DataSource = null;
                    rptAdminSites.DataBind();
                    rptPage.DataSource = null;
                    rptPage.DataBind();
                }

            }

        }
        //gvSites.DataBind();
    }

    #endregion

    #region Click Event handlers

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            CurrentPage = 0;
            Load();
        }
    }

    #endregion
}


