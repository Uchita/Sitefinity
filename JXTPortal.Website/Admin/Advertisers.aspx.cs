

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
using JXTPortal.Website;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
#endregion

public partial class Advertisers : System.Web.UI.Page
{
    #region Declarations

    private SitesService _sitesService;
    private AdvertisersService _advertisersService;
    private AdvertiserAccountTypeService _advertiseraccounttypeservice;
    private AdvertiserAccountStatusService _advertiseraccountstatusservice;
    private AdvertiserBusinessTypeService _advertiserbusinesstypeservice;
    private TList<JXTPortal.Entities.AdvertiserAccountType> advertiseraccounttype;
    private TList<JXTPortal.Entities.AdvertiserAccountStatus> advertiseraccountstatus;
    private TList<JXTPortal.Entities.AdvertiserBusinessType> advertiserbusinesstype;

    #endregion

    #region Properties

    private AdvertisersService AdvertisersService
    {
        get
        {
            if (_advertisersService == null)
            {
                _advertisersService = new AdvertisersService();
            }
            return _advertisersService;
        }
    }

    private AdvertiserAccountTypeService AdvertiserAccountTypeService
    {
        get
        {
            if (_advertiseraccounttypeservice == null)
            {
                _advertiseraccounttypeservice = new AdvertiserAccountTypeService();
            }
            return _advertiseraccounttypeservice;
        }
    }

    private AdvertiserAccountStatusService AdvertiserAccountStatusService
    {
        get
        {
            if (_advertiseraccountstatusservice == null)
            {
                _advertiseraccountstatusservice = new AdvertiserAccountStatusService();
            }
            return _advertiseraccountstatusservice;
        }
    }

    private AdvertiserBusinessTypeService AdvertiserBusinessTypeService
    {
        get
        {
            if (_advertiserbusinesstypeservice == null)
            {
                _advertiserbusinesstypeservice = new AdvertiserBusinessTypeService();
            }
            return _advertiserbusinesstypeservice;
        }
    }
        
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

    public int? _advertiserID
    {
        get
        {
            if (!string.IsNullOrEmpty(txtAdvertiserListingAdvertiserID.Text.Trim()))
            {
                return Convert.ToInt32(txtAdvertiserListingAdvertiserID.Text.Trim());
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

    public int? _advertiserAccountTypeID
    {
        get
        {
            if (ddlAccountType.SelectedItem != null && ddlAccountType.SelectedValue.Length > 0 && Convert.ToInt32(ddlAccountType.SelectedValue) > 0)
            {
                return Convert.ToInt32(ddlAccountType.SelectedValue);
            }
            return null;
        }
    }

    public int? _advertiserAccountStatusID
    {
        get
        {
            if (ddlAccountStatus.SelectedItem != null && ddlAccountStatus.SelectedValue.Length > 0 && Convert.ToInt32(ddlAccountStatus.SelectedValue) > 0)
            {
                return Convert.ToInt32(ddlAccountStatus.SelectedValue);
            }
            return null;
        }
    }

    public int? _advertiserBusinessTypeID
    {
        get
        {
            if (ddlBusinessType.SelectedItem != null && ddlBusinessType.SelectedValue.Length > 0 && Convert.ToInt32(ddlBusinessType.SelectedValue) > 0)
            {
                return Convert.ToInt32(ddlBusinessType.SelectedValue);
            }
            return null;
        }
    }

    public string _companyName
    {
        get
        {
            if (!string.IsNullOrEmpty(txtAdvertiserListingCommpanyName.Text.Trim()))
            {
                return txtAdvertiserListingCommpanyName.Text.Trim();
            }
            return null;
        }
    }


    #endregion

    #region Page Event handlers

    protected void Page_Load(object sender, EventArgs e)
	{
        if (!IsPostBack)
        {
            loadSites();
            loadAdvertiserAccountType();
            loadAdvertiserAccountStatus();
            loadAdvertiserBusinessType();
            loadForm();
        }
    }

    #endregion

    #region Event

    protected void rptAdminAdvertiser_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal ltViewAdvertiser = e.Item.FindControl("ltViewAdvertiser") as Literal;
            Literal ltAdminAdvertiserID = e.Item.FindControl("ltAdminAdvertiserID") as Literal;
            Literal ltAdminAdvAccType = e.Item.FindControl("ltAdminAdvAccType") as Literal;
            Literal ltAdminAdvAccStatus = e.Item.FindControl("ltAdminAdvAccStatus") as Literal;
            //Literal ltAdminAdvBusinessType = e.Item.FindControl("ltAdminAdvBusinessType") as Literal;
            Literal ltAdminAdvCompanyName = e.Item.FindControl("ltAdminAdvCompanyName") as Literal;
            //Literal ltAdminAdvAccPayableEmail = e.Item.FindControl("ltAdminAdvAccPayableEmail") as Literal;
            //Literal ltAdminAdvNoOfEmployees = e.Item.FindControl("ltAdminAdvNoOfEmployees") as Literal;
            Literal ltAdminAdvRegisteredDate = e.Item.FindControl("ltAdminAdvRegisteredDate") as Literal;
            Literal ltAdminAdvLastModified = e.Item.FindControl("ltAdminAdvLastModified") as Literal;

            DataRowView advertiser = (DataRowView)e.Item.DataItem;

            ltAdminAdvertiserID.Text = Convert.ToString(advertiser["AdvertiserID"]);
            ltAdminAdvAccType.Text = Convert.ToString(advertiser["AdvertiserAccountTypeName"]);
            ltAdminAdvAccStatus.Text = Convert.ToString(advertiser["AdvertiserAccountStatusName"]);
            //ltAdminAdvBusinessType.Text = Convert.ToString(advertiser["AdvertiserBusinessTypeName"]);
            ltAdminAdvCompanyName.Text = Convert.ToString(advertiser["CompanyName"]);
            //ltAdminAdvAccPayableEmail.Text = Convert.ToString(advertiser["AccountsPayableEmail"]);
            //ltAdminAdvNoOfEmployees.Text = Convert.ToString(advertiser["NoOfEmployees"]);
            if (advertiser["RegisterDate"] != DBNull.Value)
            {
                ltAdminAdvRegisteredDate.Text = Convert.ToDateTime(advertiser["RegisterDate"]).ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
            }

            if (advertiser["LastModified"] != DBNull.Value)
            {
                ltAdminAdvLastModified.Text = Convert.ToDateTime(advertiser["LastModified"]).ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
            }
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

    protected void loadForm()
    {
        //if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId != 1)
        //{
        //    pnlSiteID.Visible = false;
        //}  

        int totalCount = 0;
        int pageCount = 0;
        int sitePageCount = JXTPortal.Common.Utils.GetAppSettingsInt("SitePaging");

        //Site drop down is pre selected as per siteID
        if (!Page.IsPostBack)
            ddlSite.SelectedValue = Convert.ToString(SessionData.Site.SiteId);

        using (DataSet objAdvertiser = AdvertisersService.AdminGetPaged(_advertiserID, _siteID, _advertiserAccountTypeID, _advertiserBusinessTypeID, _advertiserAccountStatusID,
            _companyName, sitePageCount, CurrentPage + 1))
        {
            if (objAdvertiser.Tables[0].Rows.Count > 0)
            {

                lblErrorMsg.Visible = false;
                ArrayList pagelist = new ArrayList();
                totalCount = Convert.ToInt32(objAdvertiser.Tables[0].Rows[0]["TotalCount"]);

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

                rptAdminAdvertiser.DataSource = objAdvertiser;
                rptAdminAdvertiser.DataBind();
            }
            else
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "No result Found";
                rptAdminAdvertiser.DataSource = null;
                rptAdminAdvertiser.DataBind();
                rptPage.DataSource = null;
                rptPage.DataBind();
            }
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

        ddlSite.DataSource = sites;
        ddlSite.DataTextField = "SiteName";
        ddlSite.DataValueField = "SiteID";
        ddlSite.DataBind();

        if (SessionData.AdminUser != null && SessionData.AdminUser.isAdminUser)
            ddlSite.Items.Insert(0, new ListItem("-All-", "0"));

    }

    private void loadAdvertiserAccountType()
    {
        advertiseraccounttype = AdvertiserAccountTypeService.GetAll();

        ddlAccountType.DataSource = advertiseraccounttype;
        ddlAccountType.DataTextField = "AdvertiserAccountTypeName";
        ddlAccountType.DataValueField = "AdvertiserAccountTypeID";
        ddlAccountType.DataBind();

        ddlAccountType.Items.Insert(0, new ListItem("-All-", "0"));
    }

    private void loadAdvertiserAccountStatus()
    {
        advertiseraccountstatus = AdvertiserAccountStatusService.GetAll();

        ddlAccountStatus.DataSource = advertiseraccountstatus;
        ddlAccountStatus.DataTextField = "AdvertiserAccountStatusName";
        ddlAccountStatus.DataValueField = "AdvertiserAccountStatusID";
        ddlAccountStatus.DataBind();

        ddlAccountStatus.Items.Insert(0, new ListItem("-All-", "0"));
    }

    private void loadAdvertiserBusinessType()
    {
        bool useDefault = false;
        advertiserbusinesstype = AdvertiserBusinessTypeService.GetSiteBusinessTypes(SessionData.Site.SiteId, out useDefault);
        ddlBusinessType.DataValueField = (useDefault) ? "AdvertiserBusinessTypeID" : "BusinessTypeParentID";
        
        ddlBusinessType.DataSource = advertiserbusinesstype;
        ddlBusinessType.DataTextField = "AdvertiserBusinessTypeName";
        
        ddlBusinessType.DataBind();

        ddlBusinessType.Items.Insert(0, new ListItem("-All-", "0"));
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

    protected void btnCreateNewAdv_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/advertisersEdit.aspx");
    }

    #endregion

}


