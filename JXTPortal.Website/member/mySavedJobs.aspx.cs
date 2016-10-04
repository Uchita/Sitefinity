
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Data;
using System.IO;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JXTPortal.Web.UI;

namespace JXTPortal.Website.members
{
    public partial class mySavedJobs : System.Web.UI.Page
    {       
        #region Page Event handlers

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Saved Jobs");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Entities.SessionData.Member != null)
            {
                MembersService service = new MembersService();
                Entities.Members member = service.GetByMemberId(Entities.SessionData.Member.MemberId);

                if (member.RequiredPasswordChange.HasValue && ((bool)member.RequiredPasswordChange))
                {
                    Response.Redirect("~/member/changepassword.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
                }
            }
            else
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
                return;
            }
        }

        #endregion       
    }
}
