using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JXTPortal.Entities;

namespace JXTPortal.Website.BaseClasses
{
    public class AdvertiserPageBase : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          LoginCheck("~/advertiser/login.aspx", SessionData.AdvertiserUser);
        }
    }
}
