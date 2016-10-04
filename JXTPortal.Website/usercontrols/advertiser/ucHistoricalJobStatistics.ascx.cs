using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlTypes;
using System.Collections;
using JXTPortal.Entities;

namespace JXTPortal.Website.usercontrols.advertiser
{
    public partial class ucHistoricalJobStatistics : System.Web.UI.UserControl
    {

        #region Declarations

        private bool _isadmin = false;
        private int _advertiserid = 0;
        private JobsService _jobservice;
        private AdvertisersService _advertisersservice;
        private JobsArchiveService _jobarchiveservice;
        private JobAreaService _jobareaservice;
        private JobRolesService _jobrolesservice;
        private DynamicPagesService _dynamicPagesService;

        #endregion

        #region Properties

        public bool IsAdmin
        {
            get { return (Request.Path.ToLower().StartsWith("/admin/") ); }
            set { _isadmin = value; }
        }

        public int AdvertiserID
        {
            get { return (_advertiserid > 0) ? _advertiserid : Convert.ToInt32(hfAdvertiser.Value); }
            set { _advertiserid = value; hfAdvertiser.Value = value.ToString(); }
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

        private JobItemsTypeService _jobItemsTypeService;
        private JobItemsTypeService JobItemsTypeService
        {
            get
            {
                if (_jobItemsTypeService == null)
                    _jobItemsTypeService = new JobItemsTypeService();
                return _jobItemsTypeService;
            }
        }

        JobsService JobsService
        {
            get
            {
                if (_jobservice == null)
                {
                    _jobservice = new JobsService();
                }
                return _jobservice;
            }
        }

        AdvertisersService AdvertisersService
        {
            get
            {
                if (_advertisersservice == null)
                {
                    _advertisersservice = new AdvertisersService();
                }
                return _advertisersservice;
            }
        }

        JobsArchiveService JobsArchiveService
        {
            get
            {
                if (_jobarchiveservice == null)
                {
                    _jobarchiveservice = new JobsArchiveService();
                }
                return _jobarchiveservice;
            }
        }

        JobAreaService JobAreaService
        {
            get
            {
                if (_jobareaservice == null)
                {
                    _jobareaservice = new JobAreaService();
                }
                return _jobareaservice;
            }
        }

        JobRolesService JobRolesService
        {
            get
            {
                if (_jobrolesservice == null)
                {
                    _jobrolesservice = new JobRolesService();
                }
                return _jobrolesservice;
            }
        }

        public bool JobScreeningProcess { get; set; }

        private DynamicPagesService DynamicPagesService
        {
            get
            {
                if (_dynamicPagesService == null)
                {
                    _dynamicPagesService = new DynamicPagesService();
                }
                return _dynamicPagesService;
            }
        }

        #endregion

        #region Page

        protected void Page_Load(object sender, EventArgs e)
        {
            cal_tbFormDate.Format = SessionData.Site.DateFormat;

            if (AdvertiserID > 0)
            {
                using (Entities.Advertisers adv = AdvertisersService.GetByAdvertiserId(AdvertiserID))
                {
                    bool hasError = false;
                    if (adv != null)
                    {
                        if ((IsAdmin && SessionData.AdminUser.isAdminUser == false) && adv.SiteId != SessionData.Site.SiteId)
                        {
                            hasError = true;
                        }
                    }
                    else
                    {
                        hasError = true;
                    }

                    if (hasError)
                    {
                        if (Request.Path.ToLower().StartsWith("/admin/"))
                        {
                            Response.Redirect("/admin/advertisers.aspx");
                        }
                        else
                        {
                            Response.Redirect("/advertiser/default.aspx");
                        }
                    }
                }
            }

            //divHeader.Visible = !IsAdmin;

            phSelectHeader.Visible = !SessionData.Site.IsJobBoard;

            if ((!Page.IsPostBack && SessionData.AdvertiserUser != null) || (IsAdmin && AdvertiserID > 0))
            {
                if (string.IsNullOrEmpty(tbFromDate.Text))
                {
                    tbFromDate.Text = DateTime.Now.AddMonths(-1).ToString(SessionData.Site.DateFormat);
                }

                btnView.Text = CommonFunction.GetResourceValue("ButtonApplyFilter");
                btnDownload.Text = CommonFunction.GetResourceValue("LabelDownload");

                if (!Page.IsPostBack)
                {
                    LoadDuration();
                    LoadSortBy();
                    LoadOrder();
                }

            }

            SetFormValues();

            // Check if the job screening process is enabled - then hide the quick repost
            CheckJobScreeningProcessEnabled();
        }

        private void CheckJobScreeningProcessEnabled()
        {

            JobScreeningProcess = false;
            GlobalSettingsService _globalSettingsService = new GlobalSettingsService();
            using (TList<Entities.GlobalSettings> gs = _globalSettingsService.GetBySiteId(SessionData.Site.SiteId))
            {
                if (gs.Count > 0)
                {
                    // if Site is using Job Screening Process then disable the Respost job.
                    if (gs[0].JobScreeningProcess.HasValue && gs[0].JobScreeningProcess.Value)
                    {
                        JobScreeningProcess = true;
                    }
                }
            }

            // If in Admin or Job screening process is enabled then hide Quick repost
            if (IsAdmin || JobScreeningProcess)
                btnQuickRepost.Visible = false;

        }

        public void SetFormValues()
        {
            ReqVal_FromDate.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            cvFromDate.ErrorMessage = CommonFunction.GetResourceValue("LabelInvalidDate");
            btnQuickRepost.Text = CommonFunction.GetResourceValue("LabelQuickRepostJob");
            btnQuickRepost.OnClientClick = "return RepostJobs();";
        }

        #endregion

        #region Methods

        private void LoadSortBy()
        {
            string strJobName = CommonFunction.GetResourceValue("DDLJobTitle");
            string strRefNo = CommonFunction.GetResourceValue("DDLRefNo");
            string strDatePosted = CommonFunction.GetResourceValue("DDLDatePosted");
            string strViews = CommonFunction.GetResourceValue("DDLNumberOfViews");
            string strApplications = CommonFunction.GetResourceValue("DDLNumberOfApplications");

            ddlSortBy.Items.Add(new ListItem(strJobName, "JobName"));
            ddlSortBy.Items.Add(new ListItem(strRefNo, "RefNo"));
            ddlSortBy.Items.Add(new ListItem(strDatePosted, "DatePosted"));
            ddlSortBy.Items.Add(new ListItem(strViews, "Views"));
            ddlSortBy.Items.Add(new ListItem(strApplications, "Applications"));

            ddlSortBy.SelectedValue = "DatePosted";
        }

        private void LoadOrder()
        {
            string strAscending = CommonFunction.GetResourceValue("DDLAscending");
            string strDescending = CommonFunction.GetResourceValue("DDLDescending");

            ddlOrder.Items.Add(new ListItem(strAscending, "True"));
            ddlOrder.Items.Add(new ListItem(strDescending, "False"));
            ddlOrder.SelectedValue = "False";
        }

        private void LoadDuration()
        {
            ddlDuration.Items.Clear();

            ddlDuration.Items.Add(new ListItem(CommonFunction.GetResourceValue("DDLOneDay"), "1"));
            ddlDuration.Items.Add(new ListItem(CommonFunction.GetResourceValue("DDLOneWeek"), "7"));
            ddlDuration.Items.Add(new ListItem(CommonFunction.GetResourceValue("DDLOneMonth"), "30"));
            ddlDuration.Items.Add(new ListItem(CommonFunction.GetResourceValue("DDLThreeMonths"), "90"));
            ddlDuration.Items.Add(new ListItem(CommonFunction.GetResourceValue("DDLSixMonths"), "180"));

            ddlDuration.SelectedValue = "30";
        }

        private void LoadArchiveJobs()
        {
            DateTime Todate = DateTime.Now;
            DateTime Fromdate = DateTime.ParseExact(tbFromDate.Text, SessionData.Site.DateFormat, null);
            switch (ddlDuration.SelectedValue)
            {
                case "1":
                    Todate = Fromdate.AddDays(1);
                    break;
                case "7":
                    Todate = Fromdate.AddDays(7);
                    break;
                case "30":
                    Todate = Fromdate.AddMonths(1);
                    break;
                case "90":
                    Todate = Fromdate.AddMonths(3);
                    break;
                case "180":
                    Todate = Fromdate.AddMonths(6);
                    break;
            }

            int iAdvertiserId = (IsAdmin && AdvertiserID > 0) ? AdvertiserID : SessionData.AdvertiserUser.AdvertiserId;
            int iAdvertiserUserId = (IsAdmin && AdvertiserID > 0) ? 0 : SessionData.AdvertiserUser.AdvertiserUserId;


            DataSet ds = JobsService.GetHistoricalJobStatistics(SessionData.Site.SiteId, iAdvertiserId, iAdvertiserUserId, DateTime.ParseExact(tbFromDate.Text, SessionData.Site.DateFormat, null), Todate, ddlSortBy.SelectedValue, Convert.ToBoolean(ddlOrder.SelectedValue));

            pnlStatistics.Visible = true;

            if (ds.Tables[0].Rows.Count > 0)
            {
                plNoResultsTableRow.Visible = false;

                ArrayList pagelist = new ArrayList();
                int sitePageCount = Common.Utils.GetAppSettingsInt("SitePaging");
                int pageCount = 0;

                //if (totalCount % sitePageCount == 0)
                //    pageCount = totalCount / sitePageCount;
                //else
                //    pageCount = (totalCount / sitePageCount) + 1;

                //if (CurrentPage >= pageCount)
                //{
                //    CurrentPage = pageCount - 1;
                //    ds = JobsService.GetAdvertiserJobs(SessionData.Site.SiteId, advertiserId, advertiseruserId, "Current", "", CurrentPage, sitePageCount);
                //}

                //for (int i = 0; i < pageCount; i++)
                //{
                //    pagelist.Add(i);
                //}

                //if (pagelist.Count > 1)
                //{
                //    rptPage.DataSource = pagelist;
                //    rptPage.DataBind();
                //    rptPage.Visible = true;
                //}
                //else
                //{
                //    rptPage.Visible = false;
                //}

                rptHistoricalStatistics.DataSource = ds.Tables[0];
                rptHistoricalStatistics.DataBind();
            }
            else
            {
                rptHistoricalStatistics.DataSource = null;
                rptHistoricalStatistics.DataBind();

                plNoResultsTableRow.Visible = true;
            }

            btnQuickRepost.Visible = (ds.Tables[0].Rows.Count > 0);

            if (IsAdmin || JobScreeningProcess || SessionData.Site.IsJobBoard)
            {
                btnQuickRepost.Visible = false;
            }

            btnDownload.Visible = (ds.Tables[0].Rows.Count > 0);
            if (btnDownload.Visible)
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnDownload);
        }

        #endregion

        #region Events

        protected void btnView_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                pnlStatistics.Visible = true;

                JXTPortal.Website.advertiser.Reports pageReport = Page as JXTPortal.Website.advertiser.Reports;
                if (Page != null)
                {
                    pageReport = new JXTPortal.Website.advertiser.Reports();
                    pageReport.SelectedTabIndex = 1;
                }

                LoadArchiveJobs();
            }
            AjaxControlToolkit.ToolkitScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "FootableInit", "LoadFooTable()", true);
        }


        protected void rptHistoricalStatistics_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal litJobTitle = e.Item.FindControl("litJobTitle") as Literal;
                Literal litRefNo = e.Item.FindControl("litRefNo") as Literal;
                Literal litDatePosted = e.Item.FindControl("litDatePosted") as Literal;
                Literal litDatePostedSort = e.Item.FindControl("litDatePostedSort") as Literal;
                Literal litViewed = e.Item.FindControl("litViewed") as Literal;
                Literal litApplications = e.Item.FindControl("litApplications") as Literal;
                LinkButton lbApplication = e.Item.FindControl("lbApplication") as LinkButton;
                LinkButton lbCopyJob = e.Item.FindControl("lbCopyJob") as LinkButton;
                LinkButton lbRepostJob = e.Item.FindControl("lbRepostJob") as LinkButton;
                HiddenField hfJobID = e.Item.FindControl("hfJobID") as HiddenField;
                CheckBox cbSelect = (CheckBox)e.Item.FindControl("cbSelect");
                PlaceHolder phSelect = e.Item.FindControl("phSelect") as PlaceHolder;
                phSelect.Visible = !SessionData.Site.IsJobBoard;
                lbRepostJob.Visible = !SessionData.Site.IsJobBoard;

                lbCopyJob.Text = CommonFunction.GetResourceValue("LabelCopyJob");
                lbRepostJob.Text = CommonFunction.GetResourceValue("LabelRepostJob");

                lbCopyJob.OnClientClick = string.Format("return confirm(\"{0}\");", CommonFunction.GetResourceValue("LabelCopyJobConfirm"));
                lbRepostJob.OnClientClick = string.Format("return confirm(\"{0}\");", CommonFunction.GetResourceValue("LabelRepostJobConfirm"));

                DataRowView drw = e.Item.DataItem as DataRowView;
                hfJobID.Value = drw["JobID"].ToString();
                litJobTitle.Text = drw["JobName"].ToString();
                litRefNo.Text = drw["RefNo"].ToString();
                litDatePosted.Text = ((DateTime)drw["DatePosted"]).ToString(SessionData.Site.DateFormat);
                litDatePostedSort.Text = ((DateTime)drw["DatePosted"]).Ticks.ToString();
                litViewed.Text = drw["Views"].ToString();
                litApplications.Text = drw["Applications"].ToString();
                lbApplication.CommandArgument = drw["JobID"].ToString();
                lbCopyJob.CommandArgument = drw["JobID"].ToString();
                lbRepostJob.CommandArgument = drw["JobID"].ToString();

                if (litApplications.Text == "0")
                {
                    lbApplication.Enabled = false;
                    lbApplication.Font.Underline = false;
                    lbApplication.ForeColor = System.Drawing.Color.Black;
                }

                // In Admin - you can't copy, applications and repost jobs.
                if (IsAdmin || JobScreeningProcess)
                {
                    // Disable the functionality for admin as they dont have pages.
                    if (IsAdmin)
                    {
                        lbApplication.Enabled = false;
                        cbSelect.Visible = false;
                        lbCopyJob.Visible = false;
                        lbRepostJob.Visible = false;
                        btnQuickRepost.Visible = false;
                    }

                    // When Job Screen process is enabled then hide the Repost and select Checkbox (which is used for quick repost)
                    if (JobScreeningProcess)
                    {
                        lbRepostJob.Visible = false;
                        cbSelect.Visible = false;
                    }
                }
                else
                    btnQuickRepost.Visible = true;
            }
        }


        protected void btnDownload_Click(object sender, EventArgs e)
        {
            JXTPortal.Website.advertiser.Reports pageReport = Page as JXTPortal.Website.advertiser.Reports;
            if (Page != null)
            {
                pageReport = new JXTPortal.Website.advertiser.Reports();
                pageReport.SelectedTabIndex = 1;
            }

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=HistoricalJobStatistics.csv");
            Response.Charset = "";

            // If you want the option to open the Excel file without saving then
            // comment out the line below
            // Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "text/csv";

            Response.Write(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\n", CommonFunction.GetResourceValue("LabelJobTitle"), CommonFunction.GetResourceValue("LabelRefNo"), CommonFunction.GetResourceValue("LabelDatePosted"), CommonFunction.GetResourceValue("LabelViewed"), CommonFunction.GetResourceValue("LabelApplications")));

            foreach (RepeaterItem ri in rptHistoricalStatistics.Items)
            {
                if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                {
                    Literal litJobTitle = ri.FindControl("litJobTitle") as Literal;
                    Literal litRefNo = ri.FindControl("litRefNo") as Literal;
                    Literal litDatePosted = ri.FindControl("litDatePosted") as Literal;
                    Literal litViewed = ri.FindControl("litViewed") as Literal;
                    Literal litApplications = ri.FindControl("litApplications") as Literal;

                    Response.Write(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\n", litJobTitle.Text, litRefNo.Text, litDatePosted.Text, litViewed.Text, litApplications.Text));
                }
            }

            Response.End();
        }

        #endregion

        protected void rptHistoricalStatistics_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ViewApplication")
            {
                Response.Redirect("~/advertiser/jobtrackerapplications.aspx?jobarchiveid=" + e.CommandArgument.ToString());
            }
            // Todo - Redirect to Response.Redirect("~/advertiser/jobcreate.aspx?copyjobid=" + e.CommandArgument.ToString());
            // And a commmon function to do this .. in jobcreate page .. check the jobarchive table also.
            else if (e.CommandName == "CopyJob")
            {
                // Copy Current Job to Draft
                int jobid = Convert.ToInt32(e.CommandArgument);

                Entities.JobsArchive jobarchive = JobsArchiveService.GetByJobId(jobid);
                Entities.Jobs job = new JXTPortal.Entities.Jobs();

                job.SiteId = jobarchive.SiteId;
                job.DatePosted = jobarchive.DatePosted;
                job.WebServiceProcessed = jobarchive.WebServiceProcessed;
                job.WorkTypeId = jobarchive.WorkTypeId;
                //job.SalaryId = jobarchive.SalaryId;
                job.JobName = jobarchive.JobName;
                job.Description = jobarchive.Description;
                job.FullDescription = jobarchive.FullDescription;
                job.RefNo = jobarchive.RefNo;
                job.Visible = jobarchive.Visible;
                job.Expired = (int)PortalEnums.Jobs.JobStatus.Draft;
                job.JobItemPrice = jobarchive.JobItemPrice;
                job.Billed = false;
                job.CurrencyId = jobarchive.CurrencyId;
                job.SalaryLowerBand = jobarchive.SalaryLowerBand;
                job.SalaryUpperBand = jobarchive.SalaryUpperBand;
                job.SalaryTypeId = jobarchive.SalaryTypeId;
                job.ShowSalaryDetails = jobarchive.ShowSalaryDetails;
                job.SalaryText = jobarchive.SalaryText;
                job.JobItemTypeId = jobarchive.JobItemTypeId;
                job.ApplicationEmailAddress = jobarchive.ApplicationEmailAddress;

                job.ApplicationMethod = jobarchive.ApplicationMethod;
                job.ApplicationUrl = jobarchive.ApplicationUrl;
                job.UploadMethod = jobarchive.UploadMethod;
                job.Tags = jobarchive.Tags;
                job.JobTemplateId = jobarchive.JobTemplateId;
                job.SearchFieldExtension = jobarchive.SearchFieldExtension;
                job.AdvertiserJobTemplateLogoId = jobarchive.AdvertiserJobTemplateLogoId;

                job.RequireLogonForExternalApplications = jobarchive.RequireLogonForExternalApplications;
                job.ShowLocationDetails = jobarchive.ShowLocationDetails;
                job.PublicTransport = jobarchive.PublicTransport;
                job.Address = jobarchive.Address;
                job.ContactDetails = jobarchive.ContactDetails;
                job.JobContactPhone = jobarchive.JobContactPhone;
                job.JobContactName = jobarchive.JobContactName;
                job.QualificationsRecognised = jobarchive.QualificationsRecognised;
                job.ResidentOnly = jobarchive.ResidentOnly;
                job.DocumentLink = jobarchive.DocumentLink;
                job.BulletPoint1 = jobarchive.BulletPoint1;
                job.BulletPoint2 = jobarchive.BulletPoint2;
                job.BulletPoint3 = jobarchive.BulletPoint3;
                job.HotJob = jobarchive.HotJob;
                int daysactive = 30;

                if (job.JobItemTypeId == (int)PortalEnums.Jobs.JobItemType.Premium)
                {
                    TList<Entities.JobItemsType> jobitemtypes = JobItemsTypeService.GetBySiteId(SessionData.Site.SiteId);
                    jobitemtypes.Filter = "TotalNumberOfJobs = 1 AND JobItemTypeParentID = " + job.JobItemTypeId.ToString();
                    if (jobitemtypes.Count > 0)
                    {
                        daysactive = jobitemtypes[0].DaysActive;
                    }
                }
                job.ExpiryDate = DateTime.Now.AddDays(daysactive);

                job.JobFriendlyName = jobarchive.JobFriendlyName;

                job.AdvertiserId = jobarchive.AdvertiserId;
                job.CompanyName = jobarchive.CompanyName;
                job.LastModifiedByAdminUserId = jobarchive.LastModifiedByAdminUserId;

                if (SessionData.AdvertiserUser != null)
                    job.EnteredByAdvertiserUserId = SessionData.AdvertiserUser.AdvertiserUserId;
                else
                    job.EnteredByAdvertiserUserId = jobarchive.EnteredByAdvertiserUserId;

                job.SearchField = jobarchive.SearchField;
                if (JobsService.Insert(job))
                {
                    using (TList<Entities.JobArea> jobareas = JobAreaService.GetByJobArchiveId(jobid))
                    {
                        foreach (Entities.JobArea jobarea in jobareas)
                        {
                            jobarea.JobId = job.JobId;
                            jobarea.JobArchiveId = null;

                            JobAreaService.Insert(jobarea);
                        }
                    }

                    using (TList<Entities.JobRoles> jrs = JobRolesService.GetByJobArchiveId(jobid))
                    {
                        foreach (Entities.JobRoles jobrole in jrs)
                        {
                            jobrole.JobId = job.JobId;
                            jobrole.JobArchiveId = null;

                            JobRolesService.Insert(jobrole);
                        }
                    }

                    // If logged in as Admin or Advertiser
                    if (IsAdmin)
                    {
                        Response.Redirect(string.Format("~/admin/jobsEdit.aspx?jobid={0}&advertiserid={1}&advertiseruserid={2}", job.JobId, job.AdvertiserId, job.EnteredByAdvertiserUserId));
                    }
                    else
                    {
                        Response.Redirect("~/advertiser/jobcreate.aspx?jobid=" + job.JobId.ToString());
                    }
                }
            }
            else if (e.CommandName == "RepostJob")
            {
                // Copy Current Job to Draft
                int jobid = Convert.ToInt32(e.CommandArgument);

                Entities.JobsArchive jobarchive = JobsArchiveService.GetByJobId(jobid);
                Entities.Jobs job = new JXTPortal.Entities.Jobs();

                job.SiteId = jobarchive.SiteId;
                job.DatePosted = DateTime.Now;
                job.WebServiceProcessed = jobarchive.WebServiceProcessed;
                job.WorkTypeId = jobarchive.WorkTypeId;
                //job.SalaryId = jobarchive.SalaryId;
                job.JobName = jobarchive.JobName;
                job.Description = jobarchive.Description;
                job.FullDescription = jobarchive.FullDescription;
                job.RefNo = jobarchive.RefNo;
                job.Visible = jobarchive.Visible;
                job.Expired = (int)PortalEnums.Jobs.JobStatus.Live;
                job.JobItemPrice = jobarchive.JobItemPrice;
                job.Billed = true;
                job.CurrencyId = jobarchive.CurrencyId;
                job.SalaryLowerBand = jobarchive.SalaryLowerBand;
                job.SalaryUpperBand = jobarchive.SalaryUpperBand;
                job.SalaryTypeId = jobarchive.SalaryTypeId;
                job.ShowSalaryDetails = jobarchive.ShowSalaryDetails;
                job.SalaryText = jobarchive.SalaryText;
                job.JobItemTypeId = jobarchive.JobItemTypeId;
                job.ApplicationEmailAddress = jobarchive.ApplicationEmailAddress;

                job.ApplicationMethod = jobarchive.ApplicationMethod;
                job.ApplicationUrl = jobarchive.ApplicationUrl;
                job.UploadMethod = jobarchive.UploadMethod;
                job.Tags = jobarchive.Tags;
                job.JobTemplateId = jobarchive.JobTemplateId;
                job.SearchFieldExtension = jobarchive.SearchFieldExtension;
                job.AdvertiserJobTemplateLogoId = jobarchive.AdvertiserJobTemplateLogoId;

                job.RequireLogonForExternalApplications = jobarchive.RequireLogonForExternalApplications;
                job.ShowLocationDetails = jobarchive.ShowLocationDetails;
                job.PublicTransport = jobarchive.PublicTransport;
                job.Address = jobarchive.Address;
                job.ContactDetails = jobarchive.ContactDetails;
                job.JobContactPhone = jobarchive.JobContactPhone;
                job.JobContactName = jobarchive.JobContactName;
                job.QualificationsRecognised = jobarchive.QualificationsRecognised;
                job.ResidentOnly = jobarchive.ResidentOnly;
                job.DocumentLink = jobarchive.DocumentLink;
                job.BulletPoint1 = jobarchive.BulletPoint1;
                job.BulletPoint2 = jobarchive.BulletPoint2;
                job.BulletPoint3 = jobarchive.BulletPoint3;
                job.HotJob = jobarchive.HotJob;
                int daysactive = 30;

                if (job.JobItemTypeId == (int)PortalEnums.Jobs.JobItemType.Premium)
                {
                    TList<Entities.JobItemsType> jobitemtypes = JobItemsTypeService.GetBySiteId(SessionData.Site.SiteId);
                    jobitemtypes.Filter = "TotalNumberOfJobs = 1 AND JobItemTypeParentID = " + job.JobItemTypeId.ToString();
                    if (jobitemtypes.Count > 0)
                    {
                        daysactive = jobitemtypes[0].DaysActive;
                    }
                }
                job.ExpiryDate = DateTime.Now.AddDays(daysactive);
                job.SearchFieldExtension = "Repost";
                job.JobFriendlyName = jobarchive.JobFriendlyName;

                job.AdvertiserId = jobarchive.AdvertiserId;
                job.CompanyName = jobarchive.CompanyName;
                job.LastModifiedByAdminUserId = jobarchive.LastModifiedByAdminUserId;

                if (SessionData.AdvertiserUser != null)
                    job.EnteredByAdvertiserUserId = SessionData.AdvertiserUser.AdvertiserUserId;
                else
                    job.EnteredByAdvertiserUserId = jobarchive.EnteredByAdvertiserUserId;

                job.SearchField = jobarchive.SearchField;
                if (JobsService.Insert(job))
                {
                    using (TList<Entities.JobArea> jobareas = JobAreaService.GetByJobArchiveId(jobid))
                    {
                        foreach (Entities.JobArea jobarea in jobareas)
                        {
                            jobarea.JobId = job.JobId;
                            jobarea.JobArchiveId = null;

                            JobAreaService.Insert(jobarea);
                        }
                    }

                    using (TList<Entities.JobRoles> jrs = JobRolesService.GetByJobArchiveId(jobid))
                    {
                        foreach (Entities.JobRoles jobrole in jrs)
                        {
                            jobrole.JobId = job.JobId;
                            jobrole.JobArchiveId = null;

                            JobRolesService.Insert(jobrole);
                        }
                    }

                    if (job.Billed)
                    {
                        JobsService.CustomCalculateJobCount(job.SiteId, job.JobId, true);
                        JobsService.JobX_SubmitQueue(job.JobId);
                    }

                    if (IsAdmin)
                    {
                        Response.Redirect(string.Format("~/admin/jobsEdit.aspx?jobid={0}&advertiserid={1}&advertiseruserid={2}", job.JobId, job.AdvertiserId, job.EnteredByAdvertiserUserId));
                    }
                    else
                    {
                        Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.JOB_CREATE_SUCCESS, "", "", ""));
                        //Response.Redirect("~/advertiser/jobcreate.aspx?jobid=" + job.JobId.ToString());
                    }

                }
            }
        }

        protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                CurrentPage = Convert.ToInt32(e.CommandArgument);
                LoadArchiveJobs();
            }
        }

        protected void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Header)
            //{
            //    Literal litPage = e.Item.FindControl("litPage") as Literal;
            //    litPage.Text = CommonFunction.GetResourceValue("LabelPage") + ":";
            //}

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbPageNo = e.Item.FindControl("lbPageNo") as LinkButton;
                lbPageNo.CommandArgument = e.Item.DataItem.ToString();
                lbPageNo.Text = (Convert.ToInt32(e.Item.DataItem) + 1).ToString();

                if (lbPageNo.CommandArgument == CurrentPage.ToString())
                {
                    lbPageNo.CssClass = "active_tnt_link";
                }
            }
        }

        protected void btnQuickRepost_Click(object sender, EventArgs e)
        {
            int count = 0;

            foreach (RepeaterItem ri in rptHistoricalStatistics.Items)
            {
                if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox cbSelect = (CheckBox)ri.FindControl("cbSelect");
                    HiddenField hfJobID = (HiddenField)ri.FindControl("hfJobID");


                    if (cbSelect.Checked)
                    {
                        // Copy Current Job to Draft
                        int jobid = Convert.ToInt32(hfJobID.Value);

                        Entities.JobsArchive jobarchive = JobsArchiveService.GetByJobId(jobid);
                        Entities.Jobs job = new JXTPortal.Entities.Jobs();

                        job.SiteId = jobarchive.SiteId;
                        job.DatePosted = DateTime.Now;
                        job.WebServiceProcessed = jobarchive.WebServiceProcessed;
                        job.WorkTypeId = jobarchive.WorkTypeId;
                        //job.SalaryId = jobarchive.SalaryId;
                        job.JobName = jobarchive.JobName;
                        job.Description = jobarchive.Description;
                        job.FullDescription = jobarchive.FullDescription;
                        job.RefNo = jobarchive.RefNo;
                        job.Visible = jobarchive.Visible;
                        job.Expired = (int)PortalEnums.Jobs.JobStatus.Live;
                        job.JobItemPrice = jobarchive.JobItemPrice;
                        job.Billed = true;
                        job.CurrencyId = jobarchive.CurrencyId;
                        job.SalaryLowerBand = jobarchive.SalaryLowerBand;
                        job.SalaryUpperBand = jobarchive.SalaryUpperBand;
                        job.SalaryTypeId = jobarchive.SalaryTypeId;
                        job.ShowSalaryDetails = jobarchive.ShowSalaryDetails;
                        job.SalaryText = jobarchive.SalaryText;
                        job.JobItemTypeId = jobarchive.JobItemTypeId;
                        job.ApplicationEmailAddress = jobarchive.ApplicationEmailAddress;

                        job.ApplicationMethod = jobarchive.ApplicationMethod;
                        job.ApplicationUrl = jobarchive.ApplicationUrl;
                        job.UploadMethod = jobarchive.UploadMethod;
                        job.Tags = jobarchive.Tags;
                        job.JobTemplateId = jobarchive.JobTemplateId;
                        job.SearchFieldExtension = jobarchive.SearchFieldExtension;
                        job.AdvertiserJobTemplateLogoId = jobarchive.AdvertiserJobTemplateLogoId;

                        job.RequireLogonForExternalApplications = jobarchive.RequireLogonForExternalApplications;
                        job.ShowLocationDetails = jobarchive.ShowLocationDetails;
                        job.PublicTransport = jobarchive.PublicTransport;
                        job.Address = jobarchive.Address;
                        job.ContactDetails = jobarchive.ContactDetails;
                        job.JobContactPhone = jobarchive.JobContactPhone;
                        job.JobContactName = jobarchive.JobContactName;
                        job.QualificationsRecognised = jobarchive.QualificationsRecognised;
                        job.ResidentOnly = jobarchive.ResidentOnly;
                        job.DocumentLink = jobarchive.DocumentLink;
                        job.BulletPoint1 = jobarchive.BulletPoint1;
                        job.BulletPoint2 = jobarchive.BulletPoint2;
                        job.BulletPoint3 = jobarchive.BulletPoint3;
                        job.HotJob = jobarchive.HotJob;
                        int daysactive = 30;

                        if (job.JobItemTypeId == (int)PortalEnums.Jobs.JobItemType.Premium)
                        {
                            TList<Entities.JobItemsType> jobitemtypes = JobItemsTypeService.GetBySiteId(SessionData.Site.SiteId);
                            jobitemtypes.Filter = "TotalNumberOfJobs = 1 AND JobItemTypeParentID = " + job.JobItemTypeId.ToString();
                            if (jobitemtypes.Count > 0)
                            {
                                daysactive = jobitemtypes[0].DaysActive;
                            }
                        }
                        job.ExpiryDate = DateTime.Now.AddDays(daysactive);

                        job.JobFriendlyName = jobarchive.JobFriendlyName;

                        job.CompanyName = jobarchive.CompanyName;
                        job.LastModifiedByAdminUserId = jobarchive.LastModifiedByAdminUserId;

                        job.AdvertiserId = jobarchive.AdvertiserId;

                        if (SessionData.AdvertiserUser != null)
                            job.EnteredByAdvertiserUserId = SessionData.AdvertiserUser.AdvertiserUserId;
                        else
                            job.EnteredByAdvertiserUserId = jobarchive.EnteredByAdvertiserUserId;


                        job.SearchField = jobarchive.SearchField;
                        if (JobsService.Insert(job))
                        {
                            using (TList<Entities.JobArea> jobareas = JobAreaService.GetByJobArchiveId(jobid))
                            {
                                foreach (Entities.JobArea jobarea in jobareas)
                                {
                                    jobarea.JobId = job.JobId;
                                    jobarea.JobArchiveId = null;

                                    JobAreaService.Insert(jobarea);
                                }
                            }

                            using (TList<Entities.JobRoles> jrs = JobRolesService.GetByJobArchiveId(jobid))
                            {
                                foreach (Entities.JobRoles jobrole in jrs)
                                {
                                    jobrole.JobId = job.JobId;
                                    jobrole.JobArchiveId = null;

                                    JobRolesService.Insert(jobrole);
                                }
                            }

                            if (job.Billed)
                            {
                                JobsService.CustomCalculateJobCount(job.SiteId, job.JobId, true);
                                JobsService.JobX_SubmitQueue(job.JobId);
                            }
                            count++;
                        }
                    }

                }
            }

            if (count > 0)
            {
                if (IsAdmin)
                {
                    Response.Redirect("~/admin/advertiser/jobsbyadvertiser.aspx?advertiserid=" + AdvertiserID.ToString());
                }
                else
                {
                    Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.JOB_CREATE_SUCCESS, "", "", ""));
                }
            }
        }

        protected void cvFromDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(tbFromDate.Text))
            {
                DateTime dt;

                if (DateTime.TryParseExact(tbFromDate.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    if (dt < System.Data.SqlTypes.SqlDateTime.MinValue.Value || dt > new DateTime(DateTime.Now.Year + 100, 12, 31))
                    {
                        cvFromDate.ErrorMessage = "Date out of range.";

                        args.IsValid = false;
                    }
                }
                else
                {
                    cvFromDate.ErrorMessage = "Invalid Date.";

                    args.IsValid = false;
                }
            }
        }
    }
}
