
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
using JXTPortal.Website;
using System.Collections.Generic;
using System.Linq;
#endregion

public partial class AdvertiserUsers : System.Web.UI.Page
{
    #region Properties

    AdvertisersService _advertisersService;
    AdvertisersService AdvertisersService
    {
        get
        {
            if (_advertisersService == null)
            {
                _advertisersService = new JXTPortal.AdvertisersService();
            }
            return _advertisersService;
        }
    }

    AdvertiserUsersService _advertiserUsersService;
    AdvertiserUsersService AdvertiserUsersService
    {
        get
        {
            if (_advertiserUsersService == null)
            {
                _advertiserUsersService = new JXTPortal.AdvertiserUsersService();
            }
            return _advertiserUsersService;
        }

    }

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

    public int? _advertiserUserID
    {
        get
        {
            if (!string.IsNullOrEmpty(txtAdvertiserUserListingAdvertiserUserID.Text.Trim()))
            {
                return Convert.ToInt32(txtAdvertiserUserListingAdvertiserUserID.Text.Trim());
            }
            return null;
        }
    }

    public int? _siteID
    {
        get
        {
            if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId != (int)PortalEnums.Admin.AdminRole.Administrator)
            {
                return Convert.ToInt32(SessionData.Site.SiteId);
            }

            if (!Page.IsPostBack)
            {
                return Convert.ToInt32(SessionData.Site.SiteId);
            }

            if (ddlSite.SelectedItem != null && ddlSite.SelectedValue.Length > 0 && Convert.ToInt32(ddlSite.SelectedValue) > 0)
            {
                return Convert.ToInt32(ddlSite.SelectedValue);
            }
            return null;
        }
    }

    private int advertiserid = 0;
    public int? _advertiserID
    {
        get
        {
            if ((Request.QueryString["advertiserID"] != null))
            {
                if (int.TryParse((Request.QueryString["advertiserID"].Trim()), out advertiserid))
                {
                    advertiserid = Convert.ToInt32(Request.QueryString["advertiserID"]);
                    txtAdvertiserUserListingAdvertiserID.Text = Convert.ToString(Request.QueryString["advertiserID"]);
                    txtAdvertiserUserListingAdvertiserID.ReadOnly = true;
                }
                return advertiserid;
            }
            else
            {

                if (!string.IsNullOrEmpty(txtAdvertiserUserListingAdvertiserID.Text.Trim()))
                {
                    return Convert.ToInt32(txtAdvertiserUserListingAdvertiserID.Text.Trim());
                }

                return null;
            }
            
        }
    }

    public string _firstName
    {
        get
        {
            if (!string.IsNullOrEmpty(txtAdvertiserUserListingFirstName.Text.Trim()))
            {
                return txtAdvertiserUserListingFirstName.Text.Trim();
            }
            return null;
        }
    }

    public string _surname
    {
        get
        {
            if (!string.IsNullOrEmpty(txtAdvertiserUserListingSurname.Text.Trim()))
            {
                return txtAdvertiserUserListingSurname.Text.Trim();
            }
            return null;
        }
    }

    public string _emailAddress
    {
        get
        {
            if (!string.IsNullOrEmpty(txtAdvertiserUserListingEmail.Text.Trim()))
            {
                return txtAdvertiserUserListingEmail.Text.Trim();
            }
            return null;
        }
    }

    public string _username
    {
        get
        {
            if (!string.IsNullOrEmpty(txtAdvertiserUserListingUsername.Text.Trim()))
            {
                return txtAdvertiserUserListingUsername.Text.Trim();
            }
            return null;
        }
    }

    #endregion

    #region Page Event handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        revEmailAddress.ValidationExpression = ConfigurationManager.AppSettings["EmailValidationRegex"];

        if (!IsPostBack)
        {
            loadSites();
            
            loadForm();
        }
    }

    #endregion

    #region Events

    protected void rptAdminAdvertiserUser_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Advertiser")
        {
            Response.Redirect("~/admin/advertisersedit.aspx?AdvertiserId=" + e.CommandArgument.ToString());
        }
    }


    protected void rptAdminAdvertiserUser_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lbAdvertiser = e.Item.FindControl("lbAdvertiser") as LinkButton;
            Literal ltAdminAdvertiserUserID = e.Item.FindControl("ltAdminAdvertiserUserID") as Literal;
            Literal ltAdminAdvertiserID = e.Item.FindControl("ltAdminAdvertiserID") as Literal;
            Literal ltAdminAdvertiserUserPrimaryAccount = e.Item.FindControl("ltAdminAdvertiserUserPrimaryAccount") as Literal;
            Literal ltAdminAdvertiserUserFirstName = e.Item.FindControl("ltAdminAdvertiserUserFirstName") as Literal;
            Literal ltAdminAdvertiserUserSurname = e.Item.FindControl("ltAdminAdvertiserUserSurname") as Literal;
            Literal ltAdminAdvertiserUserUsername = e.Item.FindControl("ltAdminAdvertiserUserUsername") as Literal;
            Literal ltAdminAdvertiserUserEmail = e.Item.FindControl("ltAdminAdvertiserUserEmail") as Literal;
            //Literal ltAdminAdvertiserUserLastModified = e.Item.FindControl("ltAdminAdvertiserUserLastModified") as Literal;
            Literal ltAdminAdvertiserUserValidated = e.Item.FindControl("ltAdminAdvertiserUserValidated") as Literal;
            //Literal ltAdminAdvertiserUserLastLoginDate = e.Item.FindControl("ltAdminAdvertiserUserLastLoginDate") as Literal;
            Literal ltAdminAdvertiserUserSiteID = e.Item.FindControl("ltAdminAdvertiserUserSiteID") as Literal;
            

            DataRowView advertiserUser = (DataRowView)e.Item.DataItem;

            lbAdvertiser.CommandArgument = Convert.ToString(advertiserUser["AdvertiserID"]);
            lbAdvertiser.Text = Convert.ToString(advertiserUser["CompanyName"]);

            ltAdminAdvertiserUserID.Text = Convert.ToString(advertiserUser["AdvertiserUserID"]);
            ltAdminAdvertiserID.Text = Convert.ToString(advertiserUser["AdvertiserID"]);
            ltAdminAdvertiserUserPrimaryAccount.Text = Convert.ToString(advertiserUser["PrimaryAccount"]);
            ltAdminAdvertiserUserFirstName.Text = Convert.ToString(advertiserUser["FirstName"]);
            ltAdminAdvertiserUserSurname.Text = Convert.ToString(advertiserUser["Surname"]);
            ltAdminAdvertiserUserUsername.Text = Convert.ToString(advertiserUser["UserName"]);
            ltAdminAdvertiserUserEmail.Text = Convert.ToString(advertiserUser["Email"]);
            //ltAdminAdvertiserUserLastModified.Text = string.Format("{0:dd/MM/yyy}", advertiserUser["LastModified"]);
            ltAdminAdvertiserUserValidated.Text = Convert.ToString(advertiserUser["Validated"]);
            //ltAdminAdvertiserUserLastLoginDate.Text = string.Format("{0:dd/MM/yyy}", advertiserUser["LastLoginDate"]);
            ltAdminAdvertiserUserSiteID.Text = Convert.ToString(advertiserUser["SiteID"]);
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
            loadForm();
        }
    }

    protected void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lbPageNo = e.Item.FindControl("lbPageNo") as LinkButton;
            lbPageNo.CommandArgument = e.Item.DataItem.ToString();

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

    protected void loadForm()
    {
        //if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId != 1)
        //{
        //    pnlSiteID.Visible = false;
        //}

        int totalCount = 0;
        int pageCount = 0;
        int sitePageCount = JXTPortal.Common.Utils.GetAppSettingsInt("SitePaging");

        rptPage.DataSource = null;
        rptPage.DataBind();

        rptAdminAdvertiserUser.DataSource = null;
        rptAdminAdvertiserUser.DataBind();

        //Site drop down is pre selected as per siteID
        if (!Page.IsPostBack)
            ddlSite.SelectedValue = Convert.ToString(SessionData.Site.SiteId);

        if (_advertiserID > 0 || _advertiserID == null)
        {
            using (DataSet objAdvertiserUser = AdvertiserUsersService.AdminGetPaged(_siteID, _advertiserID, _advertiserUserID, _username, _firstName, _surname, _emailAddress,
                sitePageCount, CurrentPage + 1))
            {
                if (objAdvertiserUser.Tables[0].Rows.Count > 0)
                {
                    lblErrorMsg.Visible = false;
                    ArrayList pagelist = new ArrayList();
                    totalCount = Convert.ToInt32(objAdvertiserUser.Tables[0].Rows[0]["TotalCount"]);

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

                    rptAdminAdvertiserUser.DataSource = objAdvertiserUser;
                    rptAdminAdvertiserUser.DataBind();
                }
            }
        }
        else
        {
            lblErrorMsg.Visible = true;
            lblErrorMsg.Text = "No result Found";
            rptAdminAdvertiserUser.DataSource = null;
            rptAdminAdvertiserUser.DataBind();
            rptPage.DataSource = null;
            rptPage.DataBind();
        }

    }

    private void loadSites()
    {
        List<JXTPortal.Entities.Sites> sites = new List<JXTPortal.Entities.Sites>();
        
        if (SessionData.AdminUser != null && SessionData.AdminUser.isAdminUser)
        {
            sites = SitesService.GetAll().OrderBy(s => s.SiteName).ToList();
        }
        else
        {
            sites.Add(SitesService.GetBySiteId(SessionData.Site.SiteId));
        }

        foreach (JXTPortal.Entities.Sites siteListItems in sites)
        {
            string listItemText = string.Format("{0} ({1})", siteListItems.SiteName, siteListItems.SiteId);

            ddlSite.Items.Add(new ListItem(listItemText, siteListItems.SiteId.ToString()));
        }

        if (SessionData.AdminUser != null && SessionData.AdminUser.isAdminUser)
            ddlSite.Items.Insert(0, new ListItem("-All-", "0"));

    }

    #endregion

    #region Click Event handlers

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            CurrentPage = 0;
            loadForm();
        }
    }

    #endregion
}


