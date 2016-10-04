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
    public partial class ucJobsCurrent : System.Web.UI.UserControl
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
                LoadCurrentJobs();

                //LoadSortBy();
                //LoadOrder();

            }
            phRenewJob.Visible = !SessionData.Site.IsJobBoard;
            phSelectHeader.Visible = !SessionData.Site.IsJobBoard;

            btnRefresh.Text = CommonFunction.GetResourceValue("ButtonRenewJob");
            btnRefresh.OnClientClick = "return RepostJobs();";
            //btnView.Text = CommonFunction.GetResourceValue("ButtonApplyFilter");
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

        private void LoadCurrentJobs()
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

            if (advertiserId > 0)
            {
                int sitePageCount = Common.Utils.GetAppSettingsInt("SitePaging");
                int totalCount = 0;

                if (IsBroadcast)
                {
                    sitePageCount = Convert.ToInt32(ConfigurationManager.AppSettings["AdvertiserCurrentJobsPaging"]);
                }
                // , ddlSortBy.SelectedValue, Convert.ToBoolean(ddlOrder.SelectedValue)

                //DataSet ds = JobsService.GetAdvertiserJobs(SessionData.Site.SiteId, advertiserId, advertiseruserId, "Current", OrderBy, CurrentPage, sitePageCount);
                DataSet ds = JobsService.GetAdvertiserJobs(SessionData.Site.SiteId, advertiserId, advertiseruserId, "Current", "", 0, 1000); //500 hardcoded

                if (ds.Tables.Count > 1)
                {
                    totalCount = Convert.ToInt32(ds.Tables[1].Rows[0]["TotalRowCount"]);

                    if (totalCount == 0)
                    {
                        plNoResultsTableRow.Visible = true;
                        phRenewJob.Visible = false;
                    }
                    else
                    {
                        //pnlCurrentJobs.Visible = true;
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

                    // Update the Job count of the website.
                    JobsService js = new JobsService();
                    js.CustomUpdateSiteJobCount(SessionData.Site.SiteId);

                    //reload page
                    Response.Redirect(Request.RawUrl);  //Response.Redirect(Page.Request.Url.ToString(), true);

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
                LinkButton lbEdit = e.Item.FindControl("lbEdit") as LinkButton;
                LinkButton lbExpire = e.Item.FindControl("lbExpire") as LinkButton;
                Literal litRefNo = e.Item.FindControl("litRefNo") as Literal;
                HyperLink hlJobTitle = e.Item.FindControl("hlJobTitle") as HyperLink;
                Literal litViews = e.Item.FindControl("litViews") as Literal;
                CheckBox cbSelect = e.Item.FindControl("cbSelect") as CheckBox;
                Literal litPosted = e.Item.FindControl("litPosted") as Literal;
                Literal litPostedDateSort = e.Item.FindControl("litPostedDateSort") as Literal;
                Literal litExpiry = e.Item.FindControl("litExpiry") as Literal;
                Literal litExpiryDateSort = e.Item.FindControl("litExpiryDateSort") as Literal;
                Literal litRemaining = e.Item.FindControl("litRemaining") as Literal;
                //LinkButton lbApplications = e.Item.FindControl("lbApplications") as LinkButton;
                HiddenField hfJobID = e.Item.FindControl("hfJobID") as HiddenField;
                LinkButton lbCopyJob = e.Item.FindControl("lbCopyJob") as LinkButton;
                HyperLink hypViewApplication = e.Item.FindControl("hypViewApplication") as HyperLink;
                PlaceHolder phSelectHeader = e.Item.FindControl("phSelectHeader") as PlaceHolder;
                phSelectHeader.Visible = !SessionData.Site.IsJobBoard;

                if (IsBroadcast)
                {
                    LiteralControl ltEdit = (LiteralControl)e.Item.Controls[0];
                    ltEdit.Text = "\r\n                <tr>\r\n                    <td scope=\"col\">\r\n                        ";
                    for (int i = 1; i <= 10; i++)
                    {
                        e.Item.Controls[i].Visible = false;
                    }
                }

                // hide edit if site is using job screening process
                lbEdit.Visible = (hfIsJobScreeningProcess.Value != "1" && IsBroadcast == false);

                lbCopyJob.Text = CommonFunction.GetResourceValue("LabelCopyJob");
                lbEdit.Text = CommonFunction.GetResourceValue("LabelEdit");
                lbExpire.Text = CommonFunction.GetResourceValue("LabelExpire");

                string message = CommonFunction.GetResourceValue("ConfirmExpireJob");
                lbExpire.OnClientClick = "return confirm('" + message + "')";

                DataRowView dr = e.Item.DataItem as DataRowView;
                int expired = Convert.ToInt32(dr["Expired"]);
                if (hfIsJobScreeningProcess.Value == "1")
                {
                    cbSelect.Visible = false;   // they can't multi select to renew a job.

                    // Dont allow when the job is live or pending or expired or suspended.
                    if (expired == (int)PortalEnums.Jobs.JobStatus.Live ||
                            expired == (int)PortalEnums.Jobs.JobStatus.Pending ||
                            expired == (int)PortalEnums.Jobs.JobStatus.Expired ||
                            expired == (int)PortalEnums.Jobs.JobStatus.Suspended)
                    {
                        lbEdit.Visible = false;
                    }
                }

                hfJobID.Value = dr["JobID"].ToString();
                lbCopyJob.CommandArgument = dr["JobID"].ToString();
                lbEdit.CommandArgument = dr["JobID"].ToString();
                lbExpire.CommandArgument = dr["JobID"].ToString();
                litRefNo.Text = dr["RefNo"].ToString();
                hlJobTitle.Text = dr["JobName"].ToString();
                hlJobTitle.NavigateUrl = "~/" + JXTPortal.Common.Utils.GetJobUrl(Convert.ToInt32(dr["JobID"]), dr["JobFriendlyName"].ToString(), dr["SiteProfessionFriendlyUrl"].ToString());
                litViews.Text = dr["Views"].ToString();
                /*litApplications.Text = dr["Applications"].ToString();
                lbApplications.CommandArgument = dr["JobID"].ToString();
                if (litApplications.Text == "0")
                {
                    lbApplications.Enabled = false;
                    lbApplications.Font.Underline = false;
                    lbApplications.ForeColor = System.Drawing.Color.Black;
                }*/

                hypViewApplication.Text = dr["Applications"].ToString();
                if (hypViewApplication.Text != "0")
                {
                    hypViewApplication.NavigateUrl = "~/advertiser/jobtrackerapplications.aspx?JobID=" + dr["JobID"].ToString();
                }
                else
                {
                    hypViewApplication.Enabled = false;
                    hypViewApplication.Font.Underline = false;
                    hypViewApplication.ForeColor = System.Drawing.Color.Black;
                }

                litPosted.Text = ((DateTime)dr["DatePosted"]).ToString(SessionData.Site.DateFormat);
                litPostedDateSort.Text = ((DateTime)dr["DatePosted"]).Ticks.ToString();
                litExpiry.Text = ((DateTime)dr["ExpiryDate"]).ToString(SessionData.Site.DateFormat);
                litExpiryDateSort.Text = ((DateTime)dr["ExpiryDate"]).Ticks.ToString();

                TimeSpan ts = ((DateTime)dr["ExpiryDate"]).Subtract(DateTime.Now);
                litRemaining.Text = (ts.Days + 1).ToString();
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

            LoadCurrentJobs();

            if (isUpdated)
            {
                AjaxControlToolkit.ToolkitScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "RepostSuccess", string.Format("alert('{0}')", CommonFunction.GetResourceValue("LabelRepostCompleted")), true);
            }
        }
        #endregion

        protected void btnView_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            LoadCurrentJobs();
        }

    }
}