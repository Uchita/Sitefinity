using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.member
{
    public partial class applicationTracker : System.Web.UI.Page
    {
        #region Page Event handlers

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Application Tracker");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionData.Member != null)
            {
                MembersService service = new MembersService();
                Entities.Members member = service.GetByMemberId(SessionData.Member.MemberId);

                if (member.RequiredPasswordChange.HasValue && ((bool)member.RequiredPasswordChange))
                {
                    Response.Redirect("~/member/changepassword.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                }
            }
            else
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                return;
            }

            
        }

        #endregion
    }
}
