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
    public partial class ucJobsDeclined : System.Web.UI.UserControl
    {
        #region Declarations

        private JobsService _jobsService;
        private AdvertiserUsersService _advertiserUsersService;
        private bool _isBroadcast = false;
        private bool _isAdmin = false;

        #endregion

        #region Properties

        private AdvertiserUsersService AdvertiserUsersService
        {
            get
            {
                if (_advertiserUsersService == null)
                    _advertiserUsersService = new AdvertiserUsersService();
                return _advertiserUsersService;
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

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }

        #endregion

        #region Page

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadPendingJobs();

                LoadSortBy();
                LoadOrder();
            }

            btnView.Text = CommonFunction.GetResourceValue("ButtonApplyFilter");
        }

        #endregion

        #region Methods


        private void LoadSortBy()
        {
            string strJobName = CommonFunction.GetResourceValue("DDLJobTitle");
            string strRefNo = CommonFunction.GetResourceValue("DDLRefNo");
            string strDatePosted = CommonFunction.GetResourceValue("DDLDatePosted");
            string strStatus = CommonFunction.GetResourceValue("LabelStatus");

            ddlSortBy.Items.Add(new ListItem(strJobName, "JobName"));
            ddlSortBy.Items.Add(new ListItem(strRefNo, "RefNo"));
            ddlSortBy.Items.Add(new ListItem(strDatePosted, "DatePosted"));
            ddlSortBy.Items.Add(new ListItem(strStatus, "Expired"));

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

        private void LoadPendingJobs()
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

            //show/hide table columns accordingly
            phSelectHeader.Visible = IsAdmin;

            if (advertiserId > 0 || IsAdmin)
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
                DataSet ds = null;
                if (IsAdmin)
                {
//                    ds = JobsService.CustomGetBySiteIdStatusIDs(SessionData.Site.SiteId, ((int)PortalEnums.Jobs.JobStatus.Pending).ToString(), OrderBy.Trim(), CurrentPage, sitePageCount);
                    ds = JobsService.CustomGetBySiteIdStatusIDs(SessionData.Site.SiteId, ((int)PortalEnums.Jobs.JobStatus.Pending).ToString(), OrderBy.Trim(), 0, 5); //500 hardcoded
                }
                else
                {
//                    ds = JobsService.GetAdvertiserJobs(SessionData.Site.SiteId, (IsAdmin) ? (int?)null : advertiserId, advertiseruserId, "Declined", OrderBy.Trim(), CurrentPage, sitePageCount);
                    ds = JobsService.GetAdvertiserJobs(SessionData.Site.SiteId, (IsAdmin) ? (int?)null : advertiserId, advertiseruserId, "Declined", OrderBy.Trim(), 0, 5); //500 hardcoded
                }

                if (ds.Tables.Count > 1)
                {
                    totalCount = Convert.ToInt32(ds.Tables[1].Rows[0]["TotalRowCount"]);

                    if (totalCount > 0)
                    {
                        rptCurrentJobs.Visible = true;
                    }
                    else
                    {
                        rptCurrentJobs.Visible = false;
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
                    //    ds = JobsService.GetAdvertiserJobs(SessionData.Site.SiteId, advertiserId, advertiseruserId, "Declined", "", CurrentPage, sitePageCount);
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
        }

        protected void rptCurrentJobs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbEdit = e.Item.FindControl("lbEdit") as LinkButton;
                Literal litRefNo = e.Item.FindControl("litRefNo") as Literal;
                HyperLink hlJobTitle = e.Item.FindControl("hlJobTitle") as HyperLink;
                Literal litPosted = e.Item.FindControl("litPosted") as Literal;
                Literal litPostedSort = e.Item.FindControl("litPostedSort") as Literal;
                Literal litStatus = e.Item.FindControl("litStatus") as Literal;
                HiddenField hfJobID = e.Item.FindControl("hfJobID") as HiddenField;
                Literal ltAdvertiser = e.Item.FindControl("ltAdvertiser") as Literal;
                PlaceHolder phEdit = e.Item.FindControl("phEdit") as PlaceHolder;
                
                phEdit.Visible = !IsAdmin;

                PlaceHolder phSelect = e.Item.FindControl("phSelect") as PlaceHolder;
                phSelect.Visible = IsAdmin;

                lbEdit.Text = CommonFunction.GetResourceValue("LabelEdit");

                DataRowView dr = e.Item.DataItem as DataRowView;
                hfJobID.Value = dr["JobID"].ToString();
                lbEdit.CommandArgument = dr["JobID"].ToString();
                litRefNo.Text = dr["RefNo"].ToString();
                hlJobTitle.Text = dr["JobName"].ToString();
                hlJobTitle.NavigateUrl = string.Format("~/advertiser/jobpreview.aspx?jobid={0}", dr["JobID"]);

                if (IsAdmin)
                {
                    ltAdvertiser.Text = dr["CompanyName"].ToString();
                    hlJobTitle.NavigateUrl = string.Format("~/admin/jobsedit.aspx?jobid={0}&advertiserid={1}&advertiseruserid={2}&pending=1", dr["JobID"], dr["AdvertiserID"], dr["EnteredByAdvertiserUserID"]);
                }


                if (Convert.ToInt32(dr["Expired"]) != (int)PortalEnums.Jobs.JobStatus.Declined)
                {
                    lbEdit.Visible = false;
                }

                litPosted.Text = ((DateTime)dr["DatePosted"]).ToString(SessionData.Site.DateFormat);
                litPostedSort.Text = ((DateTime)dr["DatePosted"]).Ticks.ToString();
                litStatus.Text = Enum.GetName(typeof(PortalEnums.Jobs.JobStatus), Convert.ToInt32(dr["Expired"]));
                TimeSpan ts = ((DateTime)dr["ExpiryDate"]).Subtract(DateTime.Now);

            }
        }

        //protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    if (e.CommandName == "Page")
        //    {
        //        CurrentPage = Convert.ToInt32(e.CommandArgument);
        //        LoadPendingJobs();
        //    }
        //}

        //protected void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{

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
            LoadPendingJobs();
        }
        #endregion

        protected void btnView_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            LoadPendingJobs();
        }
        
    }
}