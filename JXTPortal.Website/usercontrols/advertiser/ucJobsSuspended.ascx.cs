using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using JXTPortal.Entities;

namespace JXTPortal.Website.usercontrols.advertiser
{
    public partial class ucJobsSuspended : System.Web.UI.UserControl
    {
        #region Declarations

        private JobsService _jobsService;
        private GlobalSettingsService _GlobalSettingsService;
        private bool _isBroadcast = false;

        #endregion

        #region Properties

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

        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_GlobalSettingsService == null)
                    _GlobalSettingsService = new GlobalSettingsService();
                return _GlobalSettingsService;
            }
        }

        private JobsService JobsService
        {
            get
            {
                if (_jobsService == null)
                    _jobsService = new JobsService();
                return _jobsService;
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

        public bool IsBroadcast
        {
            get { return _isBroadcast; }
            set { _isBroadcast = value; }
        }

        #endregion

        #region Page

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetJobScreeningProcess();
                LoadSuspendedJobs();

                LoadSortBy();
                LoadOrder();

            }

            btnRefresh.Text = CommonFunction.GetResourceValue("ButtonRenewJob");
            btnRefresh.OnClientClick = "return RepostJobs();";
            btnView.Text = CommonFunction.GetResourceValue("ButtonApplyFilter");
        }

        #endregion

        #region Methods

        private void SetJobScreeningProcess()
        {
            // Save if the site is using Job Screening Process
            using (TList<Entities.GlobalSettings> globalsettings = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
            {
                if (globalsettings.Count > 0)
                {
                    Entities.GlobalSettings globalsetting = globalsettings[0];

                    if (globalsetting.JobScreeningProcess.HasValue)
                    {
                        if (globalsetting.JobScreeningProcess.Value)
                        {
                            hfIsJobScreeningProcess.Value = "1";
                            phRenewJob.Visible = false;
                        }
                    }
                }
            }

        }

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
            ddlSortBy.Items.Add(new ListItem(strViews, "[Views]"));
            ddlSortBy.Items.Add(new ListItem(strApplications, "[Applications]"));

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

        private void LoadSuspendedJobs()
        {
            int advertiserId = 0;

            if (SessionData.AdvertiserUser != null)
            {
                advertiserId = SessionData.AdvertiserUser.AdvertiserId;
            }
            else
            {
                if (!string.IsNullOrEmpty(Request.Params["AdvertiserId"]))
                {
                    Int32.TryParse(Request.Params["AdvertiserId"], out advertiserId);
                }
            }

            int advertiseruserId = 0;

            if (SessionData.AdvertiserUser != null)
            {
                advertiseruserId = SessionData.AdvertiserUser.AdvertiserUserId;
            }
            else
            {
                if (!string.IsNullOrEmpty(Request.Params["AdvertiserUserId"]))
                {
                    Int32.TryParse(Request.Params["AdvertiserUserId"], out advertiseruserId);
                }
            }

            pnlCurrentJobs.Visible = false;

            if (advertiserId > 0)
            {
                int sitePageCount = Common.Utils.GetAppSettingsInt("SitePaging");
                int totalCount = 0;

                if (IsBroadcast)
                {
                    sitePageCount = Convert.ToInt32(ConfigurationManager.AppSettings["AdvertiserCurrentJobsPaging"]);
                    phSortBy.Visible = false;
                }
                // , ddlSortBy.SelectedValue, Convert.ToBoolean(ddlOrder.SelectedValue)

                string OrderBy = string.Format("{0} {1}", ddlSortBy.SelectedValue, (ddlOrder.SelectedValue == "False") ? "DESC" : string.Empty);
                //DataSet ds = JobsService.GetAdvertiserJobs(SessionData.Site.SiteId, advertiserId, advertiseruserId, "Current", OrderBy, CurrentPage, sitePageCount);
                DataSet ds = JobsService.GetAdvertiserJobs(SessionData.Site.SiteId, advertiserId, advertiseruserId, "Suspended", "", 0, 500); //500 hardcoded

                if (ds.Tables.Count > 1)
                {
                    totalCount = Convert.ToInt32(ds.Tables[1].Rows[0]["TotalRowCount"]);
                    if (totalCount > 0)
                    {
                        pnlCurrentJobs.Visible = true;
                    }

                    //ArrayList pagelist = new ArrayList();

                    //int pageCount = 0;

                    //if (totalCount % sitePageCount == 0)
                    //    pageCount = totalCount / sitePageCount;
                    //else
                    //    pageCount = (totalCount / sitePageCount) + 1;

                    //// Todo -check why this SP runs again - same for draft, pending, archive
                    //if (CurrentPage >= pageCount)
                    //{
                    //    CurrentPage = pageCount - 1;
                    //    ds = JobsService.GetAdvertiserJobs(SessionData.Site.SiteId, advertiserId, advertiseruserId, "Current", "", CurrentPage, sitePageCount);
                    //}

                    //for (int i = 0; i < pageCount; i++)
                    //{
                    //    pagelist.Add(i);
                    //}

                    //if (pagelist.Count > 1 && !IsBroadcast)
                    //{
                    //    rptPage.DataSource = pagelist;
                    //    rptPage.DataBind();
                    //    rptPage.Visible = true;
                    //}
                    //else
                    //{
                    //    rptPage.Visible = false;
                    //}
                }

                rptCurrentJobs.DataSource = ds.Tables[0];
                rptCurrentJobs.DataBind();
            }
        }

        #endregion

        #region Events

        protected void rptCurrentJobs_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("~/advertiser/jobcreate.aspx?jobid=" + e.CommandArgument.ToString());
            }
            else if (e.CommandName == "ViewApplication")
            {
                Response.Redirect("~/advertiser/jobtrackerapplications.aspx?jobid=" + e.CommandArgument.ToString());
            }
            else if (e.CommandName == "Copy")
            {
                Response.Redirect("~/advertiser/jobcreate.aspx?copyjobid=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "Expire")
            {
                using (JXTPortal.Entities.Jobs job = JobsService.GetByJobId(Convert.ToInt32(e.CommandArgument)))
                {
                    job.Expired = (int)PortalEnums.Jobs.JobStatus.Expired;

                    if (SessionData.AdvertiserUser != null)
                    {
                        job.LastModifiedByAdvertiserUserId = SessionData.AdvertiserUser.AdvertiserUserId;
                    }

                    if (SessionData.AdminUser != null)
                    {
                        job.LastModifiedByAdminUserId = SessionData.AdminUser.AdminUserId;
                    }

                    JobsService.Update(job);

                    LoadSuspendedJobs();


                    // Update the Job count of the website.
                    JobsService js = new JobsService();
                    js.CustomUpdateSiteJobCount(SessionData.Site.SiteId);
                }
            }
        }

        protected void rptCurrentJobs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                if (IsBroadcast)
                {
                    LiteralControl ltEdit = (LiteralControl)e.Item.Controls[0];

                    ltEdit.Text = ltEdit.Text.Replace("\r\n                                    <th scope=\"col\">\r\n                                        &nbsp;\r\n                                    </th>\r\n                                    <th scope=\"col\">\r\n                                        &nbsp;\r\n                                    </th>\r\n                                    ", "");

                }
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                Literal litTotalCount = e.Item.FindControl("litTotalCount") as Literal;
                DataTable dt = (DataTable)rptCurrentJobs.DataSource;

                litTotalCount.Text = dt.Rows.Count.ToString();

            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal litRefNo = e.Item.FindControl("litRefNo") as Literal;
                Literal litJobTitle = e.Item.FindControl("litJobTitle") as Literal;
                Literal litExpiry = e.Item.FindControl("litExpiry") as Literal;
                Literal litExpiryDateSort = e.Item.FindControl("litExpiryDateSort") as Literal;

                if (IsBroadcast)
                {
                    LiteralControl ltEdit = (LiteralControl)e.Item.Controls[0];
                    ltEdit.Text = "\r\n                <tr>\r\n                    <td scope=\"col\">\r\n                        ";
                    for (int i = 1; i <= 10; i++)
                    {
                        e.Item.Controls[i].Visible = false;
                    }
                }

                DataRowView dr = e.Item.DataItem as DataRowView;
                int expired = Convert.ToInt32(dr["Expired"]);

                litRefNo.Text = dr["RefNo"].ToString();
                litJobTitle.Text = dr["JobName"].ToString();
                litExpiry.Text = ((DateTime)dr["ExpiryDate"]).ToString(SessionData.Site.DateFormat);
                litExpiryDateSort.Text = ((DateTime)dr["ExpiryDate"]).Ticks.ToString();
            }
        }

        //protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    if (e.CommandName == "Page")
        //    {
        //        CurrentPage = Convert.ToInt32(e.CommandArgument);
        //        LoadCurrentJobs();
        //    }
        //}

        //protected void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    //if (e.Item.ItemType == ListItemType.Header)
        //    //{
        //    //    Literal litPage = e.Item.FindControl("litPage") as Literal;
        //    //    litPage.Text = CommonFunction.GetResourceValue("LabelPage") + ":";
        //    //}

        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        LinkButton lbPageNo = e.Item.FindControl("lbPageNo") as LinkButton;
        //        lbPageNo.CommandArgument = e.Item.DataItem.ToString();
        //        lbPageNo.Text = (Convert.ToInt32(e.Item.DataItem) + 1).ToString();

        //        if (lbPageNo.CommandArgument == CurrentPage.ToString())
        //        {
        //            lbPageNo.CssClass = "active_tnt_link";
        //        }
        //    }
        //}

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            bool isUpdated = false;
            foreach (RepeaterItem ri in rptCurrentJobs.Items)
            {
                if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox cbSelect = (CheckBox)ri.FindControl("cbSelect");
                    HiddenField hfJobID = (HiddenField)ri.FindControl("hfJobID");
                    if (cbSelect.Checked)
                    {
                        JobsService service = new JobsService();
                        Entities.Jobs job = service.GetByJobId(Convert.ToInt32(hfJobID.Value));
                        if (job != null)
                        {
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
                            service.Update(job);
                            isUpdated = true;
                        }
                    }
                }
            }

            LoadSuspendedJobs();

            if (isUpdated)
            {
                AjaxControlToolkit.ToolkitScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "RepostSuccess", string.Format("alert('{0}')", CommonFunction.GetResourceValue("LabelRepostCompleted")), true);
            }
        }
        #endregion

        protected void btnView_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            LoadSuspendedJobs();
        }

    }
}