using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal;
using JXTPortal.Entities;

namespace JXTPortal.Website.Admin.reports
{
    public partial class JobApplicationAndViewsDetail : System.Web.UI.Page
    {
        #region Declarations
        JobsService _jobsService;
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

        JobsService JobsService
        {
            get
            {
                if (_jobsService == null)
                {
                    _jobsService = new JobsService();
                }
                return _jobsService;
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
            cal_tbDateFrom.Format = SessionData.Site.DateFormat;
            ((BoundField)gvViewsDetail.Columns[0]).DataFormatString = "{0:" + SessionData.Site.DateFormat + "}";
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

        private void LoadJobApplicationAndViewsDetail()
        {
            DataSet dataSet = JobsService.GetJobApplicationAndViewsDetail(_siteID, DateTime.ParseExact(tbDateFrom.Text, SessionData.Site.DateFormat, null),
                Convert.ToInt32(tbDuration.Text));

            gvViewsDetail.DataSource = dataSet.Tables[0];
            gvViewsDetail.DataBind();

            gvJobApplicationDetail.DataSource = dataSet.Tables[1];
            gvJobApplicationDetail.DataBind();

        }
        #endregion

        protected void gvJobApplicationDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink hl = (HyperLink)e.Row.FindControl("link");
                if (hl != null)
                {
                    DataRowView drv = (DataRowView)e.Row.DataItem;

                    string ApplicationDate = string.Format("{0:"+ SessionData.Site.DateFormat +"}", DateTime.Parse(drv["ApplicationDate"].ToString()));

                    hl.NavigateUrl = "JobApplicationDetail.aspx?date=" + ApplicationDate;
                }
            }
        }

        protected void btnRun_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                LoadJobApplicationAndViewsDetail();
            }
        }

        protected void cvDateFrom_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(tbDateFrom.Text))
            {
                DateTime dt;

                if (DateTime.TryParseExact(tbDateFrom.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    if (dt < System.Data.SqlTypes.SqlDateTime.MinValue.Value || dt > new DateTime(DateTime.Now.Year + 100, 12, 31))
                    {
                        cvDateFrom.ErrorMessage = "Date out of range.";

                        args.IsValid = false;
                    }
                }
                else
                {
                    cvDateFrom.ErrorMessage = "Invalid Date.";

                    args.IsValid = false;
                }
            }
        }
    }
}
