using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Drawing;
using JXTPortal.Common;
using System.IO;
using JXTPortal.Website;


namespace JXTPortal.Website.advertiser
{
    public partial class edit : System.Web.UI.Page
    {
        private int selectedtabindex = 0;
        public int SelectedTabIndex
        {
            get { return selectedtabindex; }
            set { selectedtabindex = value; }
        }
        

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Advertiser Account Settings");            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Entities.SessionData.AdvertiserUser == null)
                {
                    Response.Redirect("~/advertiser/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                    return;
                }

                if (Entities.SessionData.AdvertiserUser != null && !SessionData.AdvertiserUser.PrimaryAccount)
                { 
                    phSubAccountsTab.Visible = false;
                    phSubAccountsPanel.Visible = false;
                }

                if (!string.IsNullOrEmpty(Request.Params["tab"]))
                {
                    Int32.TryParse(Request.Params["tab"], out selectedtabindex);

                    //Redirect the subaccount if the advertiser is not a Primary user.
                    if (selectedtabindex == 1 && Entities.SessionData.AdvertiserUser != null && !SessionData.AdvertiserUser.PrimaryAccount)
                    {
                        Response.Redirect("/advertiser/edit.aspx");

                        //phSubAccounts.Visible = false;
                    }
                }
            }
        }

    }
}
