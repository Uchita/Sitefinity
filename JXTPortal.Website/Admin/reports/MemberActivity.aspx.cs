using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal;
using System.Collections.Generic;
using System.Linq;

namespace JXTPortal.Website.Admin.reports
{
    public partial class MemberActivity : System.Web.UI.Page
    {
        #region Declarations
        MembersService _membersService;
        SitesService _sitesService;
        #endregion

        #region Properties

        private int _siteID
        {
            get
            {
                if (SessionData.AdminUser != null && SessionData.AdminUser.isAdminUser == false)
                {
                    return Convert.ToInt32(SessionData.Site.SiteId);
                }

                if (ddlSite.SelectedItem != null && ddlSite.SelectedValue.Length > 0 && Convert.ToInt32(ddlSite.SelectedValue) > 0)
                {
                    return Convert.ToInt32(ddlSite.SelectedValue);
                }
                return 0;
            }
        }

        MembersService MembersService
        {
            get
            {
                if (_membersService == null)
                {
                    _membersService = new MembersService();
                }
                return _membersService;
            }
        }

        SitesService SitesService
        {
            get
            {
                if (_sitesService == null)
                {
                    _sitesService = new SitesService();
                }
                return _sitesService;
            }
        }
        #endregion

        #region Page
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadSite();
            }

            if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId != 1)
                pnlSite.Visible = false;

            LoadMemberActivity();
        }
        #endregion

        #region Methods
        private void LoadSite()
        {
            List<JXTPortal.Entities.Sites> sites = new List<JXTPortal.Entities.Sites>();

            if (SessionData.AdminUser != null && SessionData.AdminUser.isAdminUser == true)
            {
                sites = SitesService.GetAll().OrderBy(s => s.SiteName).ToList();
            }
            else
            {
                sites.Add(SitesService.GetBySiteId(SessionData.Site.SiteId));
                pnlSite.Visible = false;
            }

            ddlSite.DataSource = sites;
            ddlSite.DataTextField = "SiteName";
            ddlSite.DataValueField = "SiteID";
            ddlSite.DataBind();

            ddlSite.Items.Insert(0, new ListItem("-All-", "0"));
            ddlSite.SelectedValue = SessionData.Site.SiteId.ToString();
        }

        private void LoadMemberActivity()
        {
            int sitePageCount = JXTPortal.Common.Utils.GetAppSettingsInt("SitePaging");
            int totalCount = 0;

            TList<Entities.Members> members = MembersService.GetPaged("SiteID = " + _siteID.ToString(), "LastModifiedDate DESC", 0, sitePageCount, out totalCount);
            rptMemberActivity.DataSource = members;
            rptMemberActivity.DataBind();
        }
        #endregion

        #region Events
        protected void rptMemberActivity_ItemDataBound1(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

            }
        }
        #endregion

        #region Events

        protected void ddlSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMemberActivity();
        }

        #endregion

    }
}