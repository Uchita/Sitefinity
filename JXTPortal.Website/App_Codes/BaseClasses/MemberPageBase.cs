using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JXTPortal.Entities;

namespace JXTPortal.Website.BaseClasses
{
    public class MemberPageBase : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginCheck("~/member/login.aspx", SessionData.Member);
        }
    }
}
