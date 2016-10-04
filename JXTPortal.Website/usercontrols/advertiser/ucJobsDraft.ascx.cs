using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JXTPortal.Entities;

namespace JXTPortal.Website.usercontrols.advertiser
{
    public partial class ucJobsDraft : System.Web.UI.UserControl
    {
        #region Declarations

        private JobsService _jobsService;
        private JobAreaService _jobAreaService;
        private JobRolesService _jobRolesService;

        #endregion

        #region Properties

        private JobsService JobsService
        {
            get
            {
                if (_jobsService == null)
                    _jobsService = new JobsService();
                return _jobsService;
            }
        }

        private JobAreaService JobAreaService
        {
            get
            {
                if (_jobAreaService == null)
                    _jobAreaService = new JobAreaService();
                return _jobAreaService;
            }
        }

        private JobRolesService JobRolesService
        {
            get
            {
                if (_jobRolesService == null)
                    _jobRolesService = new JobRolesService();
                return _jobRolesService;
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

        #endregion

        #region Page

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDraftJobs();
            }
        }

        #endregion

        #region Methods

        private void LoadDraftJobs()
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

//                DataSet ds = JobsService.GetAdvertiserJobs(SessionData.Site.SiteId, advertiserId, advertiseruserId, "Draft", "", CurrentPage, sitePageCount);
                DataSet ds = JobsService.GetAdvertiserJobs(SessionData.Site.SiteId, advertiserId, advertiseruserId, "Draft", "", 0, 500); //500 hardcoded

                if (ds.Tables.Count > 1)
                {
                    totalCount = Convert.ToInt32(ds.Tables[1].Rows[0]["TotalRowCount"]);

                    if (totalCount > 0)
                    {
                        pnlDraftJobs.Visible = true;
                    }
                    else
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
                    //    ds = JobsService.GetAdvertiserJobs(SessionData.Site.SiteId, advertiserId, advertiseruserId, "Draft", "", CurrentPage, sitePageCount);
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
                }

                rptDraftJobs.DataSource = ds.Tables[0];
                rptDraftJobs.DataBind();
            }
        }

        #endregion

        #region Events

     
        protected void rptDraftJobs_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("~/advertiser/jobcreate.aspx?JobId=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "Delete")
            {
                using (TList<JXTPortal.Entities.JobArea> jobareas = JobAreaService.GetByJobId(Convert.ToInt32(e.CommandArgument)))
                {
                    JobAreaService.Delete(jobareas);
                }

                using (TList<JXTPortal.Entities.JobRoles> jobroles = JobRolesService.GetByJobId(Convert.ToInt32(e.CommandArgument)))
                {
                    JobRolesService.Delete(jobroles);
                }

                using (JXTPortal.Entities.Jobs job = JobsService.GetByJobId(Convert.ToInt32(e.CommandArgument)))
                {
                    JobsService.Delete(job);
                    LoadDraftJobs();
                }
            }
        }

        protected void rptDraftJobs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbEdit = e.Item.FindControl("lbEdit") as LinkButton;
                LinkButton lbDelete = e.Item.FindControl("lbDelete") as LinkButton;
                Literal litRefNo = e.Item.FindControl("litRefNo") as Literal;
                Literal litJobTitle = e.Item.FindControl("litJobTitle") as Literal;
                Literal litPosted = e.Item.FindControl("litPosted") as Literal;
                Literal litPostedDateSort = e.Item.FindControl("litPostedDateSort") as Literal;

                lbEdit.Text = CommonFunction.GetResourceValue("LabelEdit");
                lbDelete.Text = CommonFunction.GetResourceValue("LabelDelete");

                string message = CommonFunction.GetResourceValue("ConfirmDeleteJob");
                lbDelete.OnClientClick = "return confirm('" + message + "')";

                DataRowView dr = e.Item.DataItem as DataRowView;

                lbEdit.CommandArgument = dr["JobID"].ToString();
                lbDelete.CommandArgument = dr["JobID"].ToString();
                litRefNo.Text = dr["RefNo"].ToString();
                litJobTitle.Text = dr["JobName"].ToString();
                litPosted.Text = ((DateTime)dr["DatePosted"]).ToString(SessionData.Site.DateFormat);
                litPostedDateSort.Text = ((DateTime)dr["DatePosted"]).Ticks.ToString();
            }
        }

        protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                CurrentPage = Convert.ToInt32(e.CommandArgument);
                LoadDraftJobs();
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
                    lbPageNo.Enabled = false;
                    lbPageNo.Font.Underline = false;
                    lbPageNo.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        #endregion
    }
}