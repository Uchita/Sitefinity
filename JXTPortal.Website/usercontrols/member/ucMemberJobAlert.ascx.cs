using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Collections;
using System.Configuration;
using System.Text;

namespace JXTPortal.Website.usercontrols.member
{
    public partial class ucMemberJobAlert : System.Web.UI.UserControl
    {
        #region Declare variables

        private JobAlertsService _jobAlertsService;
        private bool _isBroadCast = false;

        private string strEdit = CommonFunction.GetResourceValue("LinkButtonEdit");
        private string strViewResults = CommonFunction.GetResourceValue("LinkButtonView");
        private string strDelete = CommonFunction.GetResourceValue("LinkButtonDelete");

        #endregion

        #region Properties

        public bool IsBroadCast
        {
            get { return _isBroadCast; }
            set { _isBroadCast = value; }
        }

        private JobAlertsService JobAlertsService
        {
            get
            {
                if (_jobAlertsService == null)
                {
                    _jobAlertsService = new JobAlertsService();
                }
                return _jobAlertsService;
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

        #region Page Event handlers

        protected void Page_Init(object sender, EventArgs e)
        {
            if (SessionData.Member == null)
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
                return;
            }
        }

        public void SetFormValues()
        {
            hypJobAlertsViewLink.Text = CommonFunction.GetResourceValue("LabelViewMore");
            ltMemberNoJobAlerts.Text = CommonFunction.GetResourceValue("LabelNoJobAlerts");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadJobAlerts();
                SetFormValues();
            }
        }

        protected void rptJobAlerts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                string urlParams = string.Format("id={0}", e.CommandArgument);
                Response.Redirect("CreateJobAlert.aspx?" + urlParams, true);
            }
            else if (e.CommandName == "View")
            {
                string url = string.Format("/advancedsearch.aspx?search=1&searchid={0}", e.CommandArgument);
                Response.Redirect(url, true);
            }
            else if (e.CommandName == "Delete")
            {
                JobAlertsService.Delete(Convert.ToInt32(string.Format("{0}", e.CommandArgument)));
                Response.Redirect("~/member/myjobalerts.aspx");
            }

        }

        protected void rptJobAlerts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Entities.JobAlerts jobalert = e.Item.DataItem as Entities.JobAlerts;

                Literal ltlSendEmail = e.Item.FindControl("ltlSendEmail") as Literal;
                LinkButton lbEdit = e.Item.FindControl("lbEdit") as LinkButton;
                LinkButton lbViewResults = e.Item.FindControl("lbViewResults") as LinkButton;
                LinkButton lbDelete = e.Item.FindControl("lbDelete") as LinkButton;
                Literal ltLastModified = e.Item.FindControl("ltLastModified") as Literal;

                lbEdit.Text = strEdit;
                lbViewResults.Text = strViewResults;
                lbDelete.Text = strDelete;

                ltLastModified.Text = jobalert.LastModified.ToString(SessionData.Site.DateFormat);
                if (jobalert.AlertActive.HasValue && jobalert.AlertActive.Value)
                    ltlSendEmail.Text = CommonFunction.GetResourceValue("LabelYes");
                else
                    ltlSendEmail.Text = CommonFunction.GetResourceValue("LabelNo");
            }
        }

        protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                CurrentPage = Convert.ToInt32(e.CommandArgument);
                LoadJobAlerts();
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

        protected void LoadJobAlerts()
        {
            int totalCount = 0;
            int pageCount = 0;
            int sitePageCount = Common.Utils.GetAppSettingsInt("SitePaging");

            if (IsBroadCast)
            {
                sitePageCount = Convert.ToInt32(ConfigurationManager.AppSettings["MemberJobAlertPaging"]);
            }

            JobAlertsService aus = new JobAlertsService();
            using (TList<Entities.JobAlerts> JobAlerts = aus.GetByMemberId(SessionData.Member.MemberId, CurrentPage * sitePageCount, sitePageCount, out totalCount))
            {

                if (JobAlerts.Count > 0)
                {
                    ArrayList pagelist = new ArrayList();
                    ltMemberNoJobAlerts.Visible = false;

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
                        hypJobAlertsViewLink.Visible = true;
                    }

                    rptJobAlerts.DataSource = JobAlerts;
                    rptJobAlerts.DataBind();
                }
                else
                {
                    rptJobAlerts.DataSource = null;
                    rptJobAlerts.DataBind();
                    rptPage.DataSource = null;
                    rptPage.DataBind();
                    ltMemberNoJobAlerts.Visible = true;
                }
            }
        }


        #endregion
    }
}