using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using JXTPortal.Entities;
using JXTPortal;

namespace JXTPortal.Website.usercontrols.member
{
    public partial class ucMemberApplicationTracker : System.Web.UI.UserControl
    {
        #region Declare Variables

        private int memberID = 0;
        private bool _IsBroadCast = false;

        #endregion

        #region "Properties"

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

        MembersService _membersService;
        MembersService MembersService
        {
            get
            {
                if (_membersService == null)
                {
                    _membersService = new MembersService();
                }
                return _membersService;
            }
        }

        JobApplicationService _jobApplicationService;
        JobApplicationService JobApplicationService
        {
            get
            {
                if (_jobApplicationService == null)
                {
                    _jobApplicationService = new JobApplicationService();
                }
                return _jobApplicationService;
            }
        }

        #endregion

        #region Page Event handlers

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Member Application Tracker");
        }

        public void SetFormValues()
        {
            hypApplicationTrackerViewLink.Text = CommonFunction.GetResourceValue("LabelViewMore");
            ltMemberNoJobTracker.Text = CommonFunction.GetResourceValue("LabelNoJobTracked");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadForm();
                SetFormValues();
            }
        }

        protected void rptMemberApplicationTracker_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {

            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Literal ltMemberApplicationJobView = e.Item.FindControl("ltMemberApplicationJobView") as Literal;
                Literal ltAdvertiserName = e.Item.FindControl("ltAdvertiserName") as Literal;
                Literal ltDateApplied = e.Item.FindControl("ltDateApplied") as Literal;
                HyperLink hypJobUrl = e.Item.FindControl("hypJobUrl") as HyperLink;

                DataRowView rowJobSaved = (DataRowView)e.Item.DataItem;
                //ltMemberApplicationJobView.Text = rowJobSaved["JobName"].ToString();
                ltDateApplied.Text = string.Format("{0:" + SessionData.Site.DateFormat + "}", rowJobSaved["ApplicationDate"]);
                //ltMemberApplicationJobView.Text = rowJobSaved["JobName"].ToString();
                ltAdvertiserName.Text = rowJobSaved["CompanyName"].ToString();
                hypJobUrl.NavigateUrl = JXTPortal.Common.Utils.GetJobUrl(Convert.ToInt32(rowJobSaved["JobId"].ToString()), rowJobSaved["JobFriendlyName"].ToString());
                hypJobUrl.Text = rowJobSaved["JobName"].ToString();
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

            using (DataSet datasetJobApplication = JobApplicationService.GetJobsNameByMemberId(memberID, sitePageCount, CurrentPage + 1))
            {
                if (datasetJobApplication.Tables[0].Rows.Count > 0)
                {
                    //rptMemberApplicationTracker.DataSource = datasetJobApplication.Tables[0];

                    totalCount = Convert.ToInt32(datasetJobApplication.Tables[0].Rows[0]["TotalCount"]);
                    ltMemberNoJobTracker.Visible = false;

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
                        hypApplicationTrackerViewLink.Visible = true;
                    }

                    rptMemberApplicationTracker.DataSource = datasetJobApplication;
                    rptMemberApplicationTracker.DataBind();
                }
                else
                {
                    rptMemberApplicationTracker.DataSource = null;
                    rptMemberApplicationTracker.DataBind();
                    rptPage.DataSource = null;
                    rptPage.DataBind();
                    ltMemberNoJobTracker.Visible = true;
                }
            }

        }
        #endregion

    }
}