using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.advertiser
{
    public partial class Reports : System.Web.UI.Page
    {
        private int selectedtabindex = 0;
        public int SelectedTabIndex
        {
            get { return selectedtabindex; }
            set { selectedtabindex = value; }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Advertiser Reports");

            ScriptManager.GetCurrent(this).RegisterPostBackControl(ucHistoricalJobStatistics1.FindControl("btnDownload"));
            ScriptManager.GetCurrent(this).RegisterPostBackControl(ucCurrentJobStatistics1.FindControl("btnDownload"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionData.AdvertiserUser == null)
            {
                Response.Redirect("~/advertiser/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
            }

            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["tab"]))
                {
                    Int32.TryParse(Request.Params["tab"], out selectedtabindex);
                }
            }
        }
    }
}
