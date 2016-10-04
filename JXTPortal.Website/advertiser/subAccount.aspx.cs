using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.advertiser
{
    public partial class subAccount : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Advertiser Sub Account");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Entities.SessionData.AdvertiserUser == null)
            {
                Response.Redirect("/advertiser/login.aspx?ReturnUrl=" + Server.UrlEncode(Request.Url.OriginalString));
                return;
            }

            AdvertiserUsersService aus = new AdvertiserUsersService();
            TList<Entities.AdvertiserUsers> au = aus.GetByAdvertiserId(SessionData.AdvertiserUser.AdvertiserId);
            au.ApplyFilter(delegate(Entities.AdvertiserUsers auser) { return auser.PrimaryAccount == false; });

            GridView1.DataSource = au;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string urlParams = string.Format("AdvertiserUserId={0}", GridView1.SelectedDataKey.Values[0]);
            Response.Redirect("edit.aspx?" + urlParams, true);
        }
    }
}
