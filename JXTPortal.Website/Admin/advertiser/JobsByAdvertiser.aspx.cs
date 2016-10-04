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

namespace JXTPortal.Website.Admin.advertiser
{
    public partial class JobsByAdvertiser : System.Web.UI.Page
    {
        #region Declarations

        private int _advertiserid = 0;
        private int _advertiseruserid = 0;
        private AdvertisersService _advertisersservice;
        private JobsService _jobsService;

        #endregion

        #region Properties

        protected int AdvertiserID
        {
            get
            {
                if ((Request.QueryString["AdvertiserID"] != null))
                {
                    if (int.TryParse((Request.QueryString["AdvertiserID"].Trim()), out _advertiserid))
                    {
                        _advertiserid = Convert.ToInt32(Request.QueryString["AdvertiserID"]);
                    }
                    return _advertiserid;
                }

                return _advertiserid;
            }
        }

        protected int AdvertiserUserID
        {
            get
            {
                if ((Request.QueryString["AdvertiserUserID"] != null))
                {
                    if (int.TryParse((Request.QueryString["AdvertiserUserID"].Trim()), out _advertiseruserid))
                    {
                        _advertiseruserid = Convert.ToInt32(Request.QueryString["AdvertiserUserID"]);
                    }
                    return _advertiseruserid;
                }

                return _advertiseruserid;
            }
        }

        private AdvertisersService AdvertisersService
        {
            get
            {
                if (_advertisersservice == null)
                {
                    _advertisersservice = new AdvertisersService();
                }
                return _advertisersservice;
            }
        }

        private JobsService JobsService
        {
            get
            {
                if (_jobsService == null)
                {
                    _jobsService = new JobsService();
                }
                return _jobsService;
            }
        }

        #endregion

        #region Page Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadJobScreeningProcessStatus();
                LoadAdvertiserJobs();
            }
        }

        // Only load status for pending declined when its enabled.
        private void LoadJobScreeningProcessStatus()
        {
            GlobalSettingsService gs = new GlobalSettingsService();
            using (TList<Entities.GlobalSettings> globalsettings = gs.GetBySiteId(SessionData.Site.SiteId))
            {
                if (globalsettings.Count > 0 && globalsettings[0].JobScreeningProcess.HasValue && !globalsettings[0].JobScreeningProcess.Value)
                {
                    ddlJobStatus.Items.Remove(ddlJobStatus.Items.FindByValue("PendingAndDeclined"));
                }
            }
        }



        protected void rptJobCurrent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {

            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltJobRefno = e.Item.FindControl("ltJobRefno") as Literal;
                Literal ltJobName = e.Item.FindControl("ltJobName") as Literal;
                Literal ltViews = e.Item.FindControl("ltViews") as Literal;
                Literal ltApplications = e.Item.FindControl("ltApplications") as Literal;
                Literal ltPosted = e.Item.FindControl("ltPosted") as Literal;
                Literal ltExpiry = e.Item.FindControl("ltExpiry") as Literal;
                Literal ltRemaining = e.Item.FindControl("ltRemaining") as Literal;

                DataRowView dr = e.Item.DataItem as DataRowView;

                ltJobRefno.Text = dr["RefNo"].ToString();
                ltJobName.Text = dr["JobName"].ToString();
                ltViews.Text = dr["Views"].ToString();
                ltApplications.Text = dr["Applications"].ToString();
                ltPosted.Text = ((DateTime)dr["DatePosted"]).ToString(SessionData.Site.DateFormat);
                ltExpiry.Text = ((DateTime)dr["ExpiryDate"]).ToString(SessionData.Site.DateFormat);
                TimeSpan ts = ((DateTime)dr["ExpiryDate"]).Subtract(DateTime.Now);
                ltRemaining.Text = (ts.Days + 1).ToString();
            }
        }

        protected void rptJobDraft_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltJobRefno = e.Item.FindControl("ltJobRefno") as Literal;
                Literal ltJobName = e.Item.FindControl("ltJobName") as Literal;
                Literal ltPosted = e.Item.FindControl("ltPosted") as Literal;
                Literal ltStatus = e.Item.FindControl("ltStatus") as Literal;

                DataRowView dr = e.Item.DataItem as DataRowView;

                ltJobRefno.Text = dr["RefNo"].ToString();
                ltJobName.Text = dr["JobName"].ToString();
                ltPosted.Text = ((DateTime)dr["DatePosted"]).ToString(SessionData.Site.DateFormat);
                int _expired = Int32.Parse(dr["Expired"].ToString());
                ltStatus.Text = ((PortalEnums.Jobs.JobStatus)_expired).ToString();
            }
        }

        protected void rptJobArchived_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltJobRefno = e.Item.FindControl("ltJobRefno") as Literal;
                Literal ltJobName = e.Item.FindControl("ltJobName") as Literal;
                Literal ltViews = e.Item.FindControl("ltViews") as Literal;
                Literal ltApplications = e.Item.FindControl("ltApplications") as Literal;
                Literal ltPosted = e.Item.FindControl("ltPosted") as Literal;
                Literal ltExpiry = e.Item.FindControl("ltExpiry") as Literal;

                DataRowView dr = e.Item.DataItem as DataRowView;

                ltJobRefno.Text = dr["RefNo"].ToString();
                ltJobName.Text = dr["JobName"].ToString();
                ltViews.Text = dr["Views"].ToString();
                ltApplications.Text = dr["Applications"].ToString();
                ltPosted.Text = ((DateTime)dr["DatePosted"]).ToString(SessionData.Site.DateFormat);
                ltExpiry.Text = ((DateTime)dr["ExpiryDate"]).ToString(SessionData.Site.DateFormat);
            }
        }

        protected void ddlJobStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAdvertiserJobs();
        }

        #endregion

        #region Methods

        private void LoadAdvertiserJobs()
        {
            lblMsg.Text = "";
            rptJobCurrent.Visible = false;
            rptJobDraft.Visible = false;
            ucHistoricalJobStatistics1.Visible = false;
            ucHistoricalJobStatistics1.IsAdmin = true;
            ucHistoricalJobStatistics1.AdvertiserID = AdvertiserID;

            if (AdvertiserID > 0)
            {
                string status = ddlJobStatus.SelectedValue;

                using (JXTPortal.Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(AdvertiserID))
                {
                    if ((SessionData.AdminUser != null && SessionData.AdminUser.isAdminUser == false) && advertiser.SiteId != SessionData.Site.SiteId)
                    {
                        Response.Redirect("~/admin/advertisers.aspx");
                    }
                    else
                    {
                        if (status != "Archived")
                        {
                            DataSet ds = JobsService.GetAdvertiserJobs(advertiser.SiteId, AdvertiserID, AdvertiserUserID, ddlJobStatus.SelectedValue, "", 0, Int32.MaxValue);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                if (status == "Current")
                                {
                                    rptJobCurrent.Visible = true;
                                    rptJobCurrent.DataSource = ds;
                                    rptJobCurrent.DataBind();
                                }
                                else if (status == "Draft" || status == "Pending" || status == "Declined") // 
                                {
                                    rptJobDraft.Visible = true;
                                    rptJobDraft.DataSource = ds;
                                    rptJobDraft.DataBind();
                                }
                            }
                            else
                            {
                                lblMsg.Text = "No jobs were found matching your search criteria";
                            }
                        }
                        else
                        {
                            ucHistoricalJobStatistics1.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("~/admin/advertisers.aspx");
            }
        }

        #endregion

       
    }
}
