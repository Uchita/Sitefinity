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
    public partial class JobAlerts : System.Web.UI.Page
    {
        #region Declarations
        JobAlertsService _jobAlertsService;
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

        JobAlertsService JobAlertsService
        {
            get
            {
                if (_jobAlertsService == null)
                {
                    _jobAlertsService = new JobAlertsService();
                }
                return _jobAlertsService;
            }
        }


        #endregion

        #region Page
        protected void Page_Load(object sender, EventArgs e)
        {
            cal_tbDateFrom.Format = SessionData.Site.DateFormat;
            cal_tbDateTo.Format = SessionData.Site.DateFormat;

            if (!Page.IsPostBack)
            {
                LoadSite();
            }

            ScriptManager sm = AjaxControlToolkit.ToolkitScriptManager.GetCurrent(Page);
            sm.RegisterPostBackControl(btnRun);
            
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

            ddlSite.SelectedValue = SessionData.Site.SiteId.ToString();
        }

        private void LoadJobAlerts()
        {
            int siteIDToRequest = 0;
            //don't think this is neccessary, but just for safe pre-caution
            if (SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Administrator)
                siteIDToRequest = Convert.ToInt32(ddlSite.SelectedValue);
            else
                siteIDToRequest = SessionData.Site.SiteId;

            using (DataSet ds = JobAlertsService.CustomGetMemberReport(siteIDToRequest, DateTime.ParseExact(tbDateFrom.Text, SessionData.Site.DateFormat, null), DateTime.ParseExact(tbDateTo.Text, SessionData.Site.DateFormat, null)))
            {
                Response.Clear();
                Response.ContentType = "application/CSV";
                Response.AddHeader("content-disposition", "attachment;filename=JobAlerts.csv");
                Response.Charset = "";

                Response.ContentType = "text/csv";

                Response.Write(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\n", 
                    CommonFunction.GetResourceValue("LabelFirstName"), 
                    CommonFunction.GetResourceValue("LabelSurname"),
                    CommonFunction.GetResourceValue("LabelEmailAddress"),
                    CommonFunction.GetResourceValue("LabelJobAlertName"), 
                    CommonFunction.GetResourceValue("LabelSearchKeyword"), 
                    CommonFunction.GetResourceValue("LabelSiteProfessionName"),
                    CommonFunction.GetResourceValue("LabelSearchRoleIDs"),
                    CommonFunction.GetResourceValue("LabelSiteLocationName"),
                    CommonFunction.GetResourceValue("LabelAreaIDs"),
                    CommonFunction.GetResourceValue("LabelWorkTypeIDs"),
                    CommonFunction.GetResourceValue("LabelSalaryTypeID"), 
                    CommonFunction.GetResourceValue("LabelDaysPosted"), 
                    CommonFunction.GetResourceValue("LabelLastModified")));

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Response.Write(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\n",
                    dr["FirstName"],
                    dr["Surname"],
                    dr["EmailAddress"],
                    dr["JobAlertName"],
                    dr["SearchKeywords"],
                    dr["SiteProfessionName"],
                    dr["SearchRoleIDs"],
                    dr["SiteLocationName"],
                    dr["AreaIDs"],
                    dr["WorkTypeIDs"],
                    dr["SalaryTypeID"],
                    dr["DaysPosted"],
                    ((DateTime)dr["LastModified"]).ToString(SessionData.Site.DateFormat + " hh:mm:ss tt")));    
                }
                Response.Flush();
                Response.End();
            }

        }
        #endregion

        #region Events


        #endregion

        protected void btnRun_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                LoadJobAlerts();
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

        protected void cvDateTo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(tbDateTo.Text))
            {
                DateTime dt;

                if (DateTime.TryParseExact(tbDateTo.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    if (dt < System.Data.SqlTypes.SqlDateTime.MinValue.Value || dt > new DateTime(DateTime.Now.Year + 100, 12, 31))
                    {
                        cvDateTo.ErrorMessage = "Date out of range.";

                        args.IsValid = false;
                    }
                }
                else
                {
                    cvDateTo.ErrorMessage = "Invalid Date.";

                    args.IsValid = false;
                }
            }
        }
    }
}