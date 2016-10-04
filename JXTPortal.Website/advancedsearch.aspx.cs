using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Common;

namespace JXTPortal.Website
{
    public partial class advancedsearch : DefaultBase
    {
        #region Properties

        public int JobAlertID
        {
            get
            {
                int _id = -1;

                if (Request.QueryString["searchid"] != null &&
                    !string.IsNullOrEmpty(Request.QueryString["searchid"]) &&
                    Int32.TryParse(Request.QueryString["searchid"], out _id))
                {
                    _id = Convert.ToInt32(Request.QueryString["searchid"]);
                }

                return _id;

            }
        }

        #endregion

        #region Page Events

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Advanced Search");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["search"]))
            {
                if (!Page.IsPostBack)
                {
                    // Clear the fields
                    // Only if Retain Search is empty
                    if (String.IsNullOrEmpty(Request.QueryString["retainsearch"]))
                    {
                        SetSessionFields();
                    }

                    // Job Alert
                    if (!String.IsNullOrEmpty(Request.QueryString["searchid"]))
                    {
                        SetJobAlertSessionFields();
                    }

                    pnlJobSearchFilter.Visible = true;
                }

                ucAdvancedSearch1.Dispose();

                MultiViewSearch.SetActiveView(ViewSearchResults);
            }
            else
            {
                // Clear the Session
                SessionData.JobSearch.ClearAllValues();

                ucSearchResults1.Dispose();
                ucJobSearchFilter1.Dispose();

                // Show Advanced Search
                MultiViewSearch.SetActiveView(ViewAdvancedSearch);

                pnlJobSearchFilter.Visible = false;
            }
        }

        #endregion

        #region Methods

        public void SetSessionFields()
        {
            // ToDo - Clean up the keywords, and special characters etc, encode
            SessionData.JobSearch.Keywords = Utils.StripHTML(Request.QueryString["keywords"]);

            SessionData.JobSearch.PageIndex = 0;
            SessionData.JobSearch.ProfessionID = Request.QueryString["professionid"];

            SessionData.JobSearch.RoleIDs = null;
            if (!String.IsNullOrEmpty(Request.QueryString["roleIDs"]))
                SessionData.JobSearch.RoleIDs = (Utils.CheckIDArray(Request.QueryString["roleIDs"])) ? Request.QueryString["roleIDs"] : string.Empty;

            SessionData.JobSearch.CountryID = CommonFunction.GetInt(Request.QueryString["countryID"]);
            SessionData.JobSearch.LocationID = Request.QueryString["locationID"];

            SessionData.JobSearch.AreaIDs = null;
            if (!String.IsNullOrEmpty(Request.QueryString["areaIDs"]))
                SessionData.JobSearch.AreaIDs = (Utils.CheckIDArray(Request.QueryString["areaIDs"])) ? Request.QueryString["areaIDs"] : string.Empty;
            SessionData.JobSearch.CurrencyID = CommonFunction.GetSalaryCurrencyID(Request.QueryString["salarylowerband"]);
            SessionData.JobSearch.SalaryTypeID = CommonFunction.GetInt(Request.QueryString["salaryID"]);
            SessionData.JobSearch.SalaryLowerBand = CommonFunction.GetSalaryAmount(Request.QueryString["salarylowerband"]);
            SessionData.JobSearch.SalaryUpperBand = CommonFunction.GetSalaryAmount(Request.QueryString["salaryupperband"]);
            SessionData.JobSearch.WorkTypeID = CommonFunction.GetInt(Request.QueryString["workTypeID"]);
            SessionData.JobSearch.AdvertiserID = CommonFunction.GetInt(Request.QueryString["AdvertiserID"]);
        }

        /// <summary>
        /// Set the Job Alert Sessions Fields
        /// </summary>
        public void SetJobAlertSessionFields()
        {
            if (JobAlertID > 0)
            {
                JobAlertsService JobAlertsService = new JobAlertsService();

                using (Entities.JobAlerts jobAlert = JobAlertsService.GetByJobAlertId(JobAlertID))
                {
                    if (SessionData.Member == null)
                    {
                        Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                    }

                    if (jobAlert != null && jobAlert.JobAlertId > 0 && jobAlert.MemberId == SessionData.Member.MemberId)
                    {

                        // ToDo - Clean up the keywords, and special characters etc, encode
                        SessionData.JobSearch.Keywords = jobAlert.SearchKeywords;

                        SessionData.JobSearch.PageIndex = 0;
                        SessionData.JobSearch.ProfessionID = jobAlert.ProfessionId;

                        SessionData.JobSearch.RoleIDs = null;
                        if (!String.IsNullOrEmpty(jobAlert.SearchRoleIds))
                            SessionData.JobSearch.RoleIDs = jobAlert.SearchRoleIds;

                        SessionData.JobSearch.LocationID = jobAlert.LocationId;

                        SessionData.JobSearch.AreaIDs = null;
                        if (!String.IsNullOrEmpty(jobAlert.AreaIds))
                            SessionData.JobSearch.AreaIDs = jobAlert.AreaIds;

                        if (!String.IsNullOrEmpty(jobAlert.SalaryIds))
                            SessionData.JobSearch.CurrencyID = CommonFunction.GetInt(jobAlert.SalaryIds);

                        if (!String.IsNullOrEmpty(jobAlert.WorkTypeIds))
                            SessionData.JobSearch.WorkTypeID = CommonFunction.GetInt(jobAlert.WorkTypeIds);

                        SessionData.JobSearch.CurrencyID = (jobAlert.CurrencyId.HasValue) ? jobAlert.CurrencyId.Value : (int?)null;
                        SessionData.JobSearch.SalaryTypeID = (jobAlert.SalaryTypeId.HasValue) ? jobAlert.SalaryTypeId.Value : (int?)null;
                        SessionData.JobSearch.SalaryLowerBand = (jobAlert.SalaryLowerBand.HasValue) ? jobAlert.SalaryLowerBand.Value : (decimal?)null;
                        SessionData.JobSearch.SalaryUpperBand = (jobAlert.SalaryUpperBand.HasValue) ? jobAlert.SalaryUpperBand.Value : (decimal?)null;
                    }
                }
            }
        }

        #endregion

    }
}
