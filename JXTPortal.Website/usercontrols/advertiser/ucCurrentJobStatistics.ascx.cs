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
    public partial class ucCurrentJobStatistics : System.Web.UI.UserControl
    {
        #region Declarations

        private JobsService _jobservice;

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

        #endregion

        #region Page

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                btnView.Text = CommonFunction.GetResourceValue("LabelView");
                btnDownload.Text = CommonFunction.GetResourceValue("LabelDownload");
                LoadSortBy();
                LoadOrder();
            }
        }

        #endregion

        #region Methods



        private void LoadSortBy()
        {
            string strJobName = CommonFunction.GetResourceValue("DDLJobTitle");
            string strRefNo = CommonFunction.GetResourceValue("DDLRefNo");
            string strDatePosted = CommonFunction.GetResourceValue("DDLDatePosted");
            string strDaysTillExpiry = CommonFunction.GetResourceValue("DDLDaysTillExpiry");
            string strViews = CommonFunction.GetResourceValue("DDLNumberOfViews");
            string strApplications = CommonFunction.GetResourceValue("DDLNumberOfApplications");

            ddlSortBy.Items.Add(new ListItem(strJobName, "JobName"));
            ddlSortBy.Items.Add(new ListItem(strRefNo, "RefNo"));
            ddlSortBy.Items.Add(new ListItem(strDatePosted, "DatePosted"));
            ddlSortBy.Items.Add(new ListItem(strDaysTillExpiry, "DaysTillExpiry"));
            ddlSortBy.Items.Add(new ListItem(strViews, "Views"));
            ddlSortBy.Items.Add(new ListItem(strApplications, "Applications"));
        }

        private void LoadOrder()
        {
            string strAscending = CommonFunction.GetResourceValue("DDLAscending");
            string strDescending = CommonFunction.GetResourceValue("DDLDescending");

            ddlOrder.Items.Add(new ListItem(strAscending, "True"));
            ddlOrder.Items.Add(new ListItem(strDescending, "False"));
        }

        #endregion

        #region Events

        protected void btnView_Click(object sender, EventArgs e)
        {
            pnlStatistics.Visible = true;
            JXTPortal.Website.advertiser.Reports pageReport = Page as JXTPortal.Website.advertiser.Reports;
            if (Page != null)
            {
                pageReport = new JXTPortal.Website.advertiser.Reports();
                pageReport.SelectedTabIndex = 0;
            }

            DataSet ds = JobsService.GetCurrentJobStatistics(SessionData.Site.SiteId, SessionData.AdvertiserUser.AdvertiserId, SessionData.AdvertiserUser.AdvertiserUserId, ddlSortBy.SelectedValue, Convert.ToBoolean(ddlOrder.SelectedValue));
            if (ds.Tables[0].Rows.Count > 0)
            {
                rptCurrentJobStatistics.DataSource = ds.Tables[0];
                rptCurrentJobStatistics.DataBind();
            }
            else
            {
                rptCurrentJobStatistics.DataSource = null;
                rptCurrentJobStatistics.DataBind();
            }

            ltNoResult.Visible = (ds.Tables[0].Rows.Count == 0);
            btnDownload.Visible = (ds.Tables[0].Rows.Count > 0);
        }

        protected void rptCurrentJobStatistics_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal litJobTitle = e.Item.FindControl("litJobTitle") as Literal;
                Literal litRefNo = e.Item.FindControl("litRefNo") as Literal;
                Literal litDatePosted = e.Item.FindControl("litDatePosted") as Literal;
                Literal litDaysTillExpiry = e.Item.FindControl("litDaysTillExpiry") as Literal;
                Literal litViewed = e.Item.FindControl("litViewed") as Literal;
                Literal litApplications = e.Item.FindControl("litApplications") as Literal;

                DataRowView drw = e.Item.DataItem as DataRowView;

                litJobTitle.Text = drw["JobName"].ToString();
                litRefNo.Text = drw["RefNo"].ToString();
                litDatePosted.Text = ((DateTime)drw["DatePosted"]).ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                litDaysTillExpiry.Text = drw["DaysTillExpiry"].ToString();
                litViewed.Text = drw["Views"].ToString();
                litApplications.Text = drw["Applications"].ToString();
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            JXTPortal.Website.advertiser.Reports pageReport = Page as JXTPortal.Website.advertiser.Reports;
            if (Page != null)
            {
                pageReport = new JXTPortal.Website.advertiser.Reports();
                pageReport.SelectedTabIndex = 0;
            }

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=CurrentJobStatistics.csv");
            Response.Charset = "";

            // If you want the option to open the Excel file without saving then
            // comment out the line below
            // Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "text/csv";
            Response.Write("Test");
            
            Response.End();
        }

        #endregion
    }
}