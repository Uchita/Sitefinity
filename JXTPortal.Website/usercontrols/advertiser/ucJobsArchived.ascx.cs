using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

using JXTPortal.Entities;

namespace JXTPortal.Website.usercontrols.advertiser
{
	public partial class ucJobsArchived : System.Web.UI.UserControl
	{
        #region Declarations

        private JobsService _jobsService;

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

                LoadArchivedJobs();
            }
        }

        #endregion

        #region Methods

        private void LoadArchivedJobs()
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

            pnlArchivedJobs.Visible = false;
            litMessage.Text = CommonFunction.GetResourceValue("LabelNoResultFound");
            if (advertiserId > 0)
            {
                int sitePageCount = Common.Utils.GetAppSettingsInt("SitePaging");
                int totalCount = 0;
                
                DataSet ds = JobsService.GetArchivedJobs(SessionData.Site.SiteId, advertiserId, "", CurrentPage, sitePageCount);

                if (ds.Tables.Count > 1)
                {
                    totalCount = Convert.ToInt32(ds.Tables[1].Rows[0]["TotalRowCount"]);
                    if (totalCount > 0)
                    {
                        pnlArchivedJobs.Visible = true;
                        litMessage.Visible = false;
                    }

                    ArrayList pagelist = new ArrayList();

                    int pageCount = 0;

                    if (totalCount % sitePageCount == 0)
                        pageCount = totalCount / sitePageCount;
                    else
                        pageCount = (totalCount / sitePageCount) + 1;

                    if (CurrentPage >= pageCount)
                    {
                        CurrentPage = pageCount - 1;
                        ds = JobsService.GetArchivedJobs(SessionData.Site.SiteId, advertiserId, "", CurrentPage, sitePageCount);
                    }

                    for (int i = 0; i < pageCount; i++)
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

                rptArchivedJobs.DataSource = ds.Tables[0];
                rptArchivedJobs.DataBind();
            }
        }

        #endregion

        protected void rptArchivedJobs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal litRefNo = e.Item.FindControl("litRefNo") as Literal;
                Literal litJobTitle = e.Item.FindControl("litJobTitle") as Literal;
                Literal litViews = e.Item.FindControl("litViews") as Literal;
                Literal litApplications = e.Item.FindControl("litApplications") as Literal;
                Literal litPosted = e.Item.FindControl("litPosted") as Literal;
                Literal litExpiry = e.Item.FindControl("litExpiry") as Literal;

                string message = CommonFunction.GetResourceValue("ConfirmExpireJob");

                DataRowView dr = e.Item.DataItem as DataRowView;

                litRefNo.Text = dr["RefNo"].ToString();
                litJobTitle.Text = dr["JobName"].ToString();
                litViews.Text = dr["Views"].ToString();
                litApplications.Text = dr["Applications"].ToString();
                litPosted.Text = ((DateTime)dr["DatePosted"]).ToString(SessionData.Site.DateFormat);
                litExpiry.Text = ((DateTime)dr["ExpiryDate"]).ToString(SessionData.Site.DateFormat);
            }
        }

        protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                CurrentPage = Convert.ToInt32(e.CommandArgument);
                LoadArchivedJobs();
            }
        }

        protected void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                Literal litPage = e.Item.FindControl("litPage") as Literal;
                litPage.Text = CommonFunction.GetResourceValue("LabelPage") + ":";
            }

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
	}
}