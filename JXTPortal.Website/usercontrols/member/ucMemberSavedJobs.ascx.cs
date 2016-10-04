
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Data;
using System.IO;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JXTPortal.Web.UI;
using System.Collections;

namespace JXTPortal.Website.usercontrols.member
{
    public partial class ucMemberSavedJobs : System.Web.UI.UserControl
    {
        #region Declare Variables

        private int memberID = 0;
        private bool _IsBroadCast = false;

        #endregion

        #region Properties

        public bool IsBroadCast
        {
            get { return _IsBroadCast; }
            set { _IsBroadCast = value; }
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

        private string JobIDs
        {
            get
            {
                string _JobIDs = string.Empty;

                if (Request.QueryString["id"] != null && !String.IsNullOrEmpty(Request.QueryString["id"].Trim()))
                {
                    _JobIDs = Request.QueryString["id"].Trim();
                }

                return _JobIDs;
            }
        }

        private JobsSavedService _jobsSavedService;
        private JobsSavedService JobsSavedService
        {
            get
            {
                if (_jobsSavedService == null)
                {
                    _jobsSavedService = new JobsSavedService();
                }
                return _jobsSavedService;
            }
        }

        #endregion

        #region Page Event handlers
        
        public void SetFormValues()
        {
            hypSavedJobsViewLink.Text = CommonFunction.GetResourceValue("LabelViewMore");
            ltMemberNoSaveJobs.Text = CommonFunction.GetResourceValue("LabelNoSavedJob");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SaveJobs();
                loadForm();
                SetFormValues();
            }

        }

        protected void rptMemberSavedJobs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lnkSavedJobsDelete = e.Item.FindControl("lnkSavedJobsDelete") as LinkButton;
                Literal ltSavedJobsDelete = e.Item.FindControl("ltSavedJobsDelete") as Literal;
                Literal ltViewSavedJobs = e.Item.FindControl("ltViewSavedJobs") as Literal;
                HyperLink hlSavedJobsName = e.Item.FindControl("hlSavedJobsName") as HyperLink;
                Literal ltSavedJobsDate = e.Item.FindControl("ltSavedJobsDate") as Literal;
                Literal ltDatePosted = e.Item.FindControl("ltDatePosted") as Literal;
                Literal ltExpiryDate = e.Item.FindControl("ltExpiryDate") as Literal;
                Literal ltRefNo = e.Item.FindControl("ltRefNo") as Literal;
                HyperLink hlViewSavedJobs = e.Item.FindControl("hlViewSavedJobs") as HyperLink;

                lnkSavedJobsDelete.Text = CommonFunction.GetResourceValue("LinkButtonDelete");
                string message = CommonFunction.GetResourceValue("LabelConfirmDeleteRecord");
                lnkSavedJobsDelete.OnClientClick = "return confirm('" + message + "')";


                ltViewSavedJobs.Text = CommonFunction.GetResourceValue("LinkButtonView");
                DataRowView rowJobSaved = (DataRowView)e.Item.DataItem;
                hlViewSavedJobs.NavigateUrl = "~/" + JXTPortal.Common.Utils.GetJobUrl(Convert.ToInt32(rowJobSaved["JobID"]), rowJobSaved["JobFriendlyName"].ToString());
                lnkSavedJobsDelete.CommandArgument = rowJobSaved["JobSaveID"].ToString();

                hlSavedJobsName.Text = Convert.ToString(rowJobSaved["JobName"]);
                hlSavedJobsName.NavigateUrl = "~/" + JXTPortal.Common.Utils.GetJobUrl(Convert.ToInt32(rowJobSaved["JobID"]), rowJobSaved["JobFriendlyName"].ToString());
                ltRefNo.Text = rowJobSaved["RefNo"].ToString();
                ltSavedJobsDate.Text = string.Format("{0:" + SessionData.Site.DateFormat + "}", rowJobSaved["LastModified"]);
                ltDatePosted.Text = string.Format("{0:" + SessionData.Site.DateFormat + "}", rowJobSaved["DatePosted"]);
                ltExpiryDate.Text = string.Format("{0:" + SessionData.Site.DateFormat + "}", rowJobSaved["ExpiryDate"]);
            }
        }

        protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                CurrentPage = Convert.ToInt32(e.CommandArgument);
                loadForm();
            }
        }

        protected void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
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

        #endregion

        #region Methods

        protected void SaveJobs()
        {
            // ToDo - Naveen - Save Jobs 

            if (Entities.SessionData.Member != null)
            {
                if (!String.IsNullOrEmpty(JobIDs))
                {
                    JobsSavedService JobsSavedService = new JobsSavedService();

                    String strMessage = String.Empty;

                    char[] splitter = { ',' };
                    string[] strJobIdsArray = JobIDs.Trim().Split(splitter);
                    int jobid = 0;
                    bool blnSuccess = false;

                    foreach (string item in strJobIdsArray)
                    {
                        if (int.TryParse(item.Trim(), out jobid) && jobid > 0)
                        {
                            blnSuccess = JobsSavedService.SavedJobForMember(jobid, false, ref strMessage);
                        }
                    }

                    if (blnSuccess)
                        Response.Redirect("/advancedsearch.aspx?search=1&retainsearch=1");
                }

            }
        }

        protected void loadForm()
        {
            if (Entities.SessionData.Member == null)
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
                return;
            }

            memberID = Entities.SessionData.Member.MemberId;

            int totalCount = 0;
            int pageCount = 0;
            int sitePageCount = Common.Utils.GetAppSettingsInt("SitePaging");

            if (IsBroadCast)
            {
                sitePageCount = Convert.ToInt32(ConfigurationManager.AppSettings["MemberSavedJobsPaging"]);
            }

            using (DataSet dataSetJobSaved = JobsSavedService.GetJobNameByMemberID(memberID, sitePageCount, CurrentPage + 1))
            {
                if (dataSetJobSaved.Tables[0].Rows.Count > 0)
                {
                    //rptMemberSavedJobs.DataSource = dataSetJobSaved.Tables[0];

                    totalCount = Convert.ToInt32(dataSetJobSaved.Tables[0].Rows[0]["TotalCount"]);
                    ltMemberNoSaveJobs.Visible = false;
                    ArrayList pagelist = new ArrayList();

                    if (totalCount % sitePageCount == 0)
                        pageCount = totalCount / sitePageCount;
                    else
                        pageCount = (totalCount / sitePageCount) + 1;

                    for (int i = 0; i < pageCount; i++)
                    {
                        pagelist.Add(i);
                    }

                    if (pagelist.Count > 1 && !IsBroadCast)
                    {
                        rptPage.DataSource = pagelist;
                        rptPage.DataBind();
                        rptPage.Visible = true;
                    }
                    else
                    {
                        rptPage.Visible = false;
                    }

                    if (totalCount > 5 && IsBroadCast)
                    {
                        hypSavedJobsViewLink.Visible = true;
                    }

                    rptMemberSavedJobs.DataSource = dataSetJobSaved;
                    rptMemberSavedJobs.DataBind();
                }
                else
                {
                    rptMemberSavedJobs.DataSource = null;
                    rptMemberSavedJobs.DataBind();
                    rptPage.DataSource = null;
                    rptPage.DataBind();
                    ltMemberNoSaveJobs.Visible = true;

                }
            }
        }

        #endregion

        #region Click Event handlers

        protected void lnkSavedJobsDelete_Click(object sender, EventArgs e)
        {
            int JobSaveID = 0;
            memberID = Entities.SessionData.Member.MemberId;
            LinkButton lb = (LinkButton)sender;
            JobSaveID = Convert.ToInt32(lb.CommandArgument);

            using (TList<Entities.JobsSaved> objjobsaved = JobsSavedService.GetByMemberId(memberID))
            {
                JobsSavedService jobsSavedService = new JobsSavedService();
                jobsSavedService.Delete(JobSaveID);
            }

            Response.Redirect("~/member/mysavedjobs.aspx");
        }

        #endregion
    }
}