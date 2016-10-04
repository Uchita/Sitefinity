using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;


namespace JXTPortal.Website.advertiser
{
    public partial class JobCreate : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Advertiser Job Create");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionData.AdvertiserUser == null)
            {
                Response.Redirect("login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
            }

            //JobsService js = new JobsService();
            //using (TList<JXTPortal.Entities.Jobs> joblist = js.GetAll())
            //{
            //    foreach (JXTPortal.Entities.Jobs j in joblist)
            //    {
            //        js.Update(j);
            //    }
            //}
        }

    }
}
