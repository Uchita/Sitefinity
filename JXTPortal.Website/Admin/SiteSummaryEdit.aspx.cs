#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using JXTPortal.Web.UI;
using JXTPortal;
using JXTPortal.Entities;
using JXTPortal.Website.Admin.UserControls;
using JXTPortal.Website;
using System.Collections.Generic;
#endregion

using System.Linq;


namespace JXTPortal.Website.Admin
{
    public partial class SiteSummaryEdit : System.Web.UI.Page
    {
        #region "Properties"

        private SiteSummaryService _siteSummaryService;

        private SiteSummaryService SiteSummaryService
        {
            get
            {
                if (_siteSummaryService == null) _siteSummaryService = new SiteSummaryService();
                return _siteSummaryService;
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

        JXTPortal.AdminUsersService _adminusersService;
        JXTPortal.AdminUsersService AdminUsersService
        {
            get
            {
                if (_adminusersService == null)
                {
                    _adminusersService = new JXTPortal.AdminUsersService();
                }
                return _adminusersService;
            }
        }

        int _sitesummaryid = 0;
        private int SiteSummaryID
        {
            get
            {
                if ((Request.QueryString["SiteSummaryID"] != null))
                {
                    if (int.TryParse((Request.QueryString["SiteSummaryID"].Trim()), out _sitesummaryid))
                    {
                        _sitesummaryid = Convert.ToInt32(Request.QueryString["SiteSummaryID"]);
                    }
                    return _sitesummaryid;
                }

                return _sitesummaryid;
            }
        }

        protected string DateFormat
        {
            get { return SessionData.Site.DateFormat.ToUpper(); }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId != (int)PortalEnums.Admin.AdminRole.Administrator)
            {
                btnAdd.Visible = false;
                btnEditSave.Visible = false;
                btnDelete.Visible = false;
            }

            if (!Page.IsPostBack)
            {
                if (SiteSummaryID > 0)
                {
                    LoadSiteSummary();
                }
                else
                {
                    btnEditSave.Visible = false;
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Entities.SiteSummary sitesummary = new Entities.SiteSummary();
                    int valid = Convert.ToInt32(ddlValid.SelectedValue);

                    sitesummary.SiteId = ((PortalEnums.Admin.SiteSummaryValid)valid == PortalEnums.Admin.SiteSummaryValid.Custom) ? SessionData.Site.SiteId : Convert.ToInt32(ConfigurationManager.AppSettings["MasterSiteID"]);
                    sitesummary.Title = tbTitle.Text;
                    sitesummary.Description = tbDescription.Text;
                    sitesummary.Url = tbURL.Text;
                    sitesummary.Valid = Convert.ToInt32(ddlValid.SelectedValue);
                    if (!string.IsNullOrWhiteSpace((txtPublishDate.Text)))
                    {
                        sitesummary.TimeStamp = DateTime.ParseExact(txtPublishDate.Text, SessionData.Site.DateFormat, null);
                    }
                    sitesummary.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                    sitesummary.LastModifiedDate = DateTime.Now;

                    SiteSummaryService.Insert(sitesummary);
                    Response.Redirect("SiteSummary.aspx");
                }
                catch (Exception ex)
                {
                    ltlMessage.Text = ex.Message;
                }
            }
        }

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Entities.SiteSummary sitesummary = SiteSummaryService.GetBySiteSummaryId(SiteSummaryID);
                    int valid = Convert.ToInt32(ddlValid.SelectedValue);

                    if (sitesummary != null)
                    {
                        sitesummary.SiteId = ((PortalEnums.Admin.SiteSummaryValid)valid == PortalEnums.Admin.SiteSummaryValid.Custom) ? SessionData.Site.SiteId : Convert.ToInt32(ConfigurationManager.AppSettings["MasterSiteID"]);
                        sitesummary.Title = tbTitle.Text;
                        sitesummary.Description = tbDescription.Text;
                        sitesummary.Url = tbURL.Text;
                        sitesummary.Valid = Convert.ToInt32(ddlValid.SelectedValue);
                        if (!string.IsNullOrWhiteSpace((txtPublishDate.Text)))
                        {
                            sitesummary.TimeStamp = DateTime.ParseExact(txtPublishDate.Text, SessionData.Site.DateFormat, null);
                        }
                        sitesummary.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                        sitesummary.LastModifiedDate = DateTime.Now;

                        SiteSummaryService.Save(sitesummary);
                        Response.Redirect("SiteSummary.aspx");
                    }
                }
                catch (Exception ex)
                {
                    ltlMessage.Text = ex.Message;
                }
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("SiteSummary.aspx");
        }

        private void LoadSiteSummary()
        {
            if (SiteSummaryID > 0)
            {
                using (Entities.SiteSummary sitesummary = SiteSummaryService.GetBySiteSummaryId(SiteSummaryID))
                {
                    if (sitesummary != null)
                    {
                        // Security Checking
                        if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId != (int)PortalEnums.Admin.AdminRole.Administrator)
                        {
                            if (sitesummary.Valid != (int)PortalEnums.Admin.SiteSummaryValid.Live && sitesummary.Valid != (int)PortalEnums.Admin.SiteSummaryValid.Prelive)
                            {
                                if (sitesummary.SiteId != SessionData.Site.SiteId)
                                {
                                    Response.Redirect("SiteSummary.aspx");
                                }
                            }
                        }
                        else
                        {
                            btnDelete.Visible = true;
                        }
                        phSite.Visible = true;

                        using (Entities.Sites site = SitesService.GetBySiteId(sitesummary.SiteId))
                        {
                            ltSite.Text = HttpUtility.HtmlEncode(site.SiteName);
                        }

                        if (sitesummary.Valid != (int)PortalEnums.Admin.SiteSummaryValid.Custom)
                        {
                            ltSite.Text = "Platform";
                        }

                        tbTitle.Text = sitesummary.Title;
                        tbDescription.Text = sitesummary.Description;
                        tbURL.Text = sitesummary.Url;
                        ddlValid.SelectedValue = sitesummary.Valid.ToString();
                        if (sitesummary.TimeStamp.HasValue)
                        {
                            txtPublishDate.Text = sitesummary.TimeStamp.Value.ToString(SessionData.Site.DateFormat);
                        }
                        ltLastModifiedDate.Text = sitesummary.LastModifiedDate.Value.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                        using (Entities.AdminUsers adminusers = AdminUsersService.GetByAdminUserId(sitesummary.LastModifiedBy.Value))
                        {
                            if (adminusers != null)
                                ltLastModifiedBy.Text = adminusers.UserName;
                        }

                        btnAdd.Visible = false;
                    }
                    else
                    {
                        btnEditSave.Visible = false;
                    }
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (SiteSummaryService.Delete(SiteSummaryID))
            {
                Response.Redirect("SiteSummary.aspx");
            }
        }

        protected void CusVal_PublishDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime result = DateTime.Now;

            if (DateTime.TryParse(txtPublishDate.Text, out result) == false)
            {
                args.IsValid = false;
            }
        }
    }
}