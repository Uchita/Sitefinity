using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JXTPortal.Entities;

namespace JXTPortal.Website.usercontrols.advertiser
{
    public partial class ucStatistics : System.Web.UI.UserControl
    {
        #region Declarations

        private JobsService _jobservice;
        private bool _showtitle = true;

        #endregion

        #region Properties

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

        public bool ShowTitle
        {
            get { return _showtitle; }
            set { _showtitle = value; }
        }

        #endregion

        #region Page

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlTitle.Visible = ShowTitle;
            if (!Page.IsPostBack)
            {
                LoadStatistics();
            }
        }

        #endregion

        #region Methods

        private void LoadStatistics()
        {
            DataSet ds = JobsService.GetStatistics(SessionData.Site.SiteId, SessionData.AdvertiserUser.AdvertiserId, SessionData.AdvertiserUser.AdvertiserUserId);
            rptStatistics.DataSource = ds.Tables[0];
            rptStatistics.DataBind();
        }

        #endregion

        #region Events

        protected void rptStatistics_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink hlJobType = e.Item.FindControl("hlJobType") as HyperLink;
                Literal litJobType = e.Item.FindControl("litJobType") as Literal;
                Literal litNumber = e.Item.FindControl("litNumber") as Literal;
                Literal litApplications = e.Item.FindControl("litApplications") as Literal;
                Literal litViewed = e.Item.FindControl("litViewed") as Literal;

                DataRowView drw = e.Item.DataItem as DataRowView;
                hlJobType.Text = CommonFunction.GetResourceValue(drw["ReportName"].ToString());
                litJobType.Text = CommonFunction.GetResourceValue(drw["ReportName"].ToString());

                if (!string.IsNullOrEmpty(drw["ReportURL"].ToString()))
                {
                    hlJobType.NavigateUrl = "~/advertiser/" + drw["ReportURL"].ToString();
                }

                if (string.IsNullOrEmpty(hlJobType.NavigateUrl))
                {
                    hlJobType.Visible = false;
                    litJobType.Visible = true;
                }

                litNumber.Text = drw["Number"].ToString();
                litApplications.Text = drw["Applications"].ToString();
                litViewed.Text = drw["Viewed"].ToString();
            }
        }

        #endregion
    }
}