using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.usercontrols.navigation
{
    public partial class ucMemberAdvertiserNavigation : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (MemberLoginCheck())
            {
                MemberNavigation1.Visible = true;
                advertiserNavigation.Visible = false;
            }
            else */if (AdvertiserLoginCheck())
            {
                advertiserNavigation.Visible = true;
                MemberNavigation1.Visible = false;
            }
            else
            {
                MemberNavigation1.Visible = false;
                advertiserNavigation.Visible = false;
            }
        }

        private bool MemberLoginCheck()
        {
            if (SessionData.Member != null && SessionData.Member.MemberId > 0)
            {
                return true;
            }
            return false;
        }

        private bool AdvertiserLoginCheck()
        {
            if (SessionData.AdvertiserUser != null && SessionData.AdvertiserUser.AdvertiserUserId > 0)
            {
                return true;
            }
            return false;
        }
    }
}