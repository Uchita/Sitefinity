using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Collections;
using System.Data;
using System.Xml;
using System.IO;

namespace JXTPortal.Website.advertiser
{
    public partial class JobTracker : System.Web.UI.Page
    {
        #region Declaration

        private JobApplicationService _jobApplicationService;
        private JobsService _jobsService;
        private JobsArchiveService _jobsarchiveservice;
        private const int page_size = 10;
        private int _jobid = 0;
        private int _jobarchvieid = 0;

        #endregion

        #region Properties

        protected int JobID
        {
            get
            {
                if ((Request.QueryString["JobID"] != null))
                {
                    if (int.TryParse((Request.QueryString["JobID"].Trim()), out _jobid))
                    {
                        _jobid = Convert.ToInt32(Request.QueryString["JobID"]);
                    }
                    return _jobid;
                }

                return _jobid;
            }
        }


        protected int JobArchiveID
        {
            get
            {
                if ((Request.QueryString["JobArchiveID"] != null))
                {
                    if (int.TryParse((Request.QueryString["JobArchiveID"].Trim()), out _jobarchvieid))
                    {
                        _jobarchvieid = Convert.ToInt32(Request.QueryString["JobArchiveID"]);
                    }
                    return _jobarchvieid;
                }

                return _jobarchvieid;
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

        private JobApplicationService JobApplicationService
        {
            get
            {
                if (_jobApplicationService == null)
                    _jobApplicationService = new JobApplicationService();
                return _jobApplicationService;
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

        private JobsArchiveService JobsArchiveService
        {
            get
            {
                if (_jobsarchiveservice == null)
                    _jobsarchiveservice = new JobsArchiveService();
                return _jobsarchiveservice;
            }
        }


        #endregion

        #region Page

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Job Tracker");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //hypLinkDownload.Text = CommonFunction.GetResourceValue("Download");

            if (SessionData.AdvertiserUser == null)
            {
                Response.Redirect("~/advertiser/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
            }
            if (!Page.IsPostBack)
            {
                if (JobID == 0 && JobArchiveID == 0)
                {
                    LoadCurrentJobs();
                }
                else
                {
                    if (JobID > 0)
                        Response.Redirect("~/advertiser/jobtrackerapplications.aspx?jobid=" + JobID);
                    if (JobArchiveID > 0)
                        Response.Redirect("~/advertiser/jobtrackerapplications.aspx?jobarchiveid=" + JobArchiveID);
                    //LoadJobApplications();
                }
            }
        }

        #endregion

        #region Method

        private void LoadCurrentJobs()
        {
            int advertiserId = SessionData.AdvertiserUser.AdvertiserId;

            //litMessage.Text = CommonFunction.GetResourceValue("LabelNoData");

            if (advertiserId > 0)
            {
                int sitePageCount = Common.Utils.GetAppSettingsInt("SitePaging");
                int totalCount = 0;

//                DataSet ds = JobsService.GetAdvertiserJobs(SessionData.Site.SiteId, advertiserId, SessionData.AdvertiserUser.AdvertiserUserId, "Current", "", CurrentPage, sitePageCount);
                DataSet ds = JobsService.GetAdvertiserJobs(SessionData.Site.SiteId, advertiserId, SessionData.AdvertiserUser.AdvertiserUserId, "Current", "", 0, 500); //hardcoded 500

                if (ds.Tables.Count > 1)
                {
                    totalCount = Convert.ToInt32(ds.Tables[1].Rows[0]["TotalRowCount"]);
                    if (totalCount == 0)
                    {
                        plNoResultsTableRow.Visible = true;
                    }

                    //ArrayList pagelist = new ArrayList();

                    //int pageCount = 0;

                    //if (totalCount % sitePageCount == 0)
                    //    pageCount = totalCount / sitePageCount;
                    //else
                    //    pageCount = (totalCount / sitePageCount) + 1;

                    //if (CurrentPage >= pageCount)
                    //{
                    //    CurrentPage = pageCount - 1;
                    //    ds = JobsService.GetAdvertiserJobs(SessionData.Site.SiteId, advertiserId, SessionData.AdvertiserUser.AdvertiserUserId, "Current", "", CurrentPage, sitePageCount);
                    //}

                    //for (int i = 0; i < pageCount; i++)
                    //{
                    //    pagelist.Add(i);
                    //}

                    //if (pagelist.Count > 1)
                    //{
                    //    rptCurrentPage.DataSource = pagelist;
                    //    rptCurrentPage.DataBind();
                    //    rptCurrentPage.Visible = true;
                    //}
                    //else
                    //{
                    //    rptCurrentPage.Visible = false;
                    //}
                }

                rptCurrentJobs.DataSource = ds.Tables[0];
                rptCurrentJobs.DataBind();
            }
        }
        /*
        private DataSet LoadJobApplications()
        {
            int sitePageCount = Common.Utils.GetAppSettingsInt("SitePaging");
            int totalCount = 0;

            DataSet jobapps = null;
            string jobname = string.Empty;

            if (JobID > 0)
            {
                hypLinkDownload.NavigateUrl = "jobtrackerexcel.aspx?jobid=" + JobID;

                Entities.Jobs job = JobsService.GetByJobId(JobID);
                if (job != null)
                {
                    litJobName.Text = job.JobName;
                }

                jobapps = JobApplicationService.GetByAdvertiserIdJobId(SessionData.AdvertiserUser.AdvertiserId, JobID, CurrentPage, sitePageCount);
            }
            else if (JobArchiveID > 0)
            {
                hypLinkDownload.NavigateUrl = "jobtrackerexcel.aspx?jobarchiveid=" + JobArchiveID;

                Entities.JobsArchive job = JobsArchiveService.GetByJobId(JobArchiveID);
                if (job != null)
                {
                    litJobName.Text = job.JobName;
                }
                jobapps = JobApplicationService.GetByAdvertiserIdJobArchiveId(SessionData.AdvertiserUser.AdvertiserId, JobArchiveID, CurrentPage, sitePageCount);
            }

            if (jobapps.Tables[0].Rows.Count > 0)
            {
                hypLinkDownload.Visible = true;

                totalCount = Convert.ToInt32(jobapps.Tables[0].Rows[0]["TotalCount"]);

                rptJobApplication.DataSource = jobapps;
                rptJobApplication.DataBind();
                pnlApplications.Visible = true;

                if (totalCount > 0)
                {
                    ArrayList pagelist = new ArrayList();
                    int noofpages = totalCount / page_size;
                    if ((totalCount % page_size) != 0)
                        noofpages += 1;

                    for (int i = 0; i < noofpages; i++)
                    {
                        pagelist.Add(i);
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
                }
            }
            else
            {
                ltNoResult.Visible = true;
                hypLinkDownload.Visible = false;
            }
            

            return jobapps;

        }
        */
        #endregion

        #region Events
        /*
        protected void rptJobApplication_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Response.Redirect("~/advertiser/jobapplicationedit.aspx?JobApplicationID=" + e.CommandArgument.ToString());
            }
            else if (e.CommandName == "Note")
            {
                Response.Redirect("advertiserapplicationnote.aspx?jobappid=" + e.CommandArgument.ToString());
            }
            else if (e.CommandName == "EditNote")
            {
                using (JXTPortal.Entities.JobApplication jobapp = JobApplicationService.GetByJobApplicationId(Convert.ToInt32(e.CommandArgument)))
                {

                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "EditNote", "$(document).ready(function() {$(\"#dialog\").dialog({ modal: true, resizable: false, open: function(type, data) {$(this).parent().appendTo(\"form\");} }); });", true);

                    tbEditNote.Text = jobapp.AdvertiserNote;
                    hfJobAppId.Value = jobapp.JobApplicationId.ToString();
                }
            }
        }

        protected void rptJobApplication_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView jobapp = (DataRowView)e.Item.DataItem;

                LinkButton lbSelect = e.Item.FindControl("lbSelect") as LinkButton;
                Literal litApplicationDate = e.Item.FindControl("litApplicationDate") as Literal;
                Literal litApplicationStatus = e.Item.FindControl("litApplicationStatus") as Literal;
                Literal litFirstName = e.Item.FindControl("litFirstName") as Literal;
                Literal litSurname = e.Item.FindControl("litSurname") as Literal;
                HyperLink hlEmailAddress = e.Item.FindControl("hlEmailAddress") as HyperLink;
                LinkButton lbNote = e.Item.FindControl("lbNote") as LinkButton;

                lbSelect.CommandArgument = jobapp["JobApplicationId"].ToString();
                litApplicationDate.Text = (jobapp["ApplicationDate"] == DBNull.Value) ? "" : (Convert.ToDateTime(jobapp["ApplicationDate"])).ToShortDateString();
                litApplicationStatus.Text = (jobapp["ApplicationStatus"] == DBNull.Value) ? "" : ((PortalEnums.JobApplications.ApplicationStatus)Convert.ToInt32(jobapp["ApplicationStatus"])).ToString();
                litFirstName.Text = jobapp["FirstName"].ToString();
                litSurname.Text = jobapp["Surname"].ToString();
                hlEmailAddress.Text = CommonFunction.GetResourceValue("ButtonSend");
                hlEmailAddress.NavigateUrl = "mailto:" + jobapp["EmailAddress"].ToString();

                if (jobapp["AdvertiserNote"] != null)
                {
                    //lbNote.Text = "Edit";
                    lbNote.Text = CommonFunction.GetResourceValue("LinkButtonEdit");
                    lbNote.CommandName = "EditNote";
                    lbNote.CommandArgument = jobapp["JobApplicationId"].ToString();
                }
                else
                {
                    lbNote.CommandArgument = jobapp["JobApplicationId"].ToString();
                }
            }
        }
        */
        protected void rptCurrentJobs_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ViewApplication")
            {
                Response.Redirect("~/advertiser/jobtrackerapplications.aspx?JobID=" + e.CommandArgument.ToString());
            }
        }

        protected void rptCurrentJobs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal litRefNo = e.Item.FindControl("litRefNo") as Literal;
                Literal litJobTitle = e.Item.FindControl("litJobTitle") as Literal;
                Literal litViews = e.Item.FindControl("litViews") as Literal;
                //Literal litApplications = e.Item.FindControl("litApplications") as Literal;
                Literal litPosted = e.Item.FindControl("litPosted") as Literal;
                Literal litPostedDateSort = e.Item.FindControl("litPostedDateSort") as Literal;
                Literal litExpiry = e.Item.FindControl("litExpiry") as Literal;
                Literal litExpiryDateSort = e.Item.FindControl("litExpiryDateSort") as Literal;
                Literal litRemaining = e.Item.FindControl("litRemaining") as Literal;
                //LinkButton lbViewApplication = e.Item.FindControl("lbViewApplication") as LinkButton;
                HyperLink hypViewApplication = e.Item.FindControl("hypViewApplication") as HyperLink;

                DataRowView dr = e.Item.DataItem as DataRowView;

                litRefNo.Text = dr["RefNo"].ToString();
                litJobTitle.Text = dr["JobName"].ToString();
                litViews.Text = dr["Views"].ToString();
                //litApplications.Text = dr["Applications"].ToString();
                litPosted.Text = ((DateTime)dr["DatePosted"]).ToString(SessionData.Site.DateFormat);
                litPostedDateSort.Text = ((DateTime)dr["DatePosted"]).Ticks.ToString();
                litExpiry.Text = ((DateTime)dr["ExpiryDate"]).ToString(SessionData.Site.DateFormat);
                litExpiryDateSort.Text = ((DateTime)dr["ExpiryDate"]).Ticks.ToString();

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

                /*
                if (litApplications.Text != "0")
                {
                    lbViewApplication.CommandArgument = dr["JobID"].ToString();
                }
                else
                {
                    lbViewApplication.Enabled = false;
                    lbViewApplication.Font.Underline = false;
                    lbViewApplication.ForeColor = System.Drawing.Color.Black;
                }*/

                TimeSpan ts = ((DateTime)dr["ExpiryDate"]).Subtract(DateTime.Now);
                litRemaining.Text = (ts.Days + 1).ToString();
            }
        }

        /*
        protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                CurrentPage = Convert.ToInt32(e.CommandArgument);
                //LoadJobApplications();
            }
        }

        protected void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbPageNo = e.Item.FindControl("lbPageNo") as LinkButton;
                lbPageNo.CommandArgument = (Convert.ToInt32(e.Item.DataItem) + 1).ToString();
                lbPageNo.Text = (Convert.ToInt32(e.Item.DataItem) + 1).ToString();

                if (lbPageNo.CommandArgument == CurrentPage.ToString())
                {
                    lbPageNo.CssClass = "active_tnt_link";
                }
            }
        }*/

        protected void rptCurrentPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                CurrentPage = Convert.ToInt32(e.CommandArgument);
                LoadCurrentJobs();
            }
        }

        protected void rptCurrentPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbPageNo = e.Item.FindControl("lbPageNo") as LinkButton;
                lbPageNo.CommandArgument = (Convert.ToInt32(e.Item.DataItem)).ToString();
                lbPageNo.Text = (Convert.ToInt32(e.Item.DataItem) + 1).ToString();

                if (lbPageNo.CommandArgument == CurrentPage.ToString())
                {
                    lbPageNo.CssClass = "active_tnt_link";
                }
            }
        }

        #endregion

        protected void btnSaveNote_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hfJobAppId.Value))
            {
                using (JXTPortal.Entities.JobApplication jobapp = JobApplicationService.GetByJobApplicationId(Convert.ToInt32(hfJobAppId.Value)))
                {
                    if (jobapp != null)
                    {
                        jobapp.AdvertiserNote = tbEditNote.Text;
                        JobApplicationService.Update(jobapp);
                    }
                }
            }
        }

        public void SetFormValues()
        {
            btnSaveNote.Text = CommonFunction.GetResourceValue("ButtonSave");
        }

    }
}
