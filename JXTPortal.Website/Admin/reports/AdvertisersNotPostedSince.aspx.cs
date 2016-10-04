using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal;
using JXTPortal.Entities;

namespace JXTPortal.Website.Admin.reports
{
    public partial class AdvertisersNotPostedSince : System.Web.UI.Page
    {
        #region Declarations
        AdvertisersService _advertisersService;
        SitesService _sitesService;
        #endregion

        #region Properties

        private int _siteID
        {
            get
            {
                if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId != 1)
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

        AdvertisersService AdvertisersService
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
            if (SessionData.AdminUser != null && SessionData.AdminUser.isAdminUser == false)
                pnlSite.Visible = false;
        }
        #endregion

        #region Methods

        private void LoadSite()
        {
            List<JXTPortal.Entities.Sites> sites = new List<JXTPortal.Entities.Sites>();

            if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId == 1)
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

            ddlSite.Items.Insert(0, new ListItem("-All-", "0"));
            ddlSite.SelectedValue = SessionData.Site.SiteId.ToString();
        }

        private void LoadAdvertisersNotPostedSince()
        {
            gvAdvertiserNotPostedSince.DataSource = AdvertisersService.GetAdvertisersNotPostedSince(_siteID, Convert.ToInt32(tbDaysSinceLastPost.Text));
            gvAdvertiserNotPostedSince.DataBind();
        }
        #endregion

        protected void btnRun_Click(object sender, EventArgs e)
        {
            LoadAdvertisersNotPostedSince();
        }
    }
}
