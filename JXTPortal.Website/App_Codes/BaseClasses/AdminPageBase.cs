using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JXTPortal.Entities;

namespace JXTPortal.Website.BaseClasses
{
    public class AdminPageBase : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginCheck("~/Admin/login.aspx", SessionData.AdminUser);

            if (SessionData.AdminUser != null && !AdminPagesSecurityService.CheckAccess(SessionData.AdminUser.AdminRoleId, GetCurrentPageName()))
            {
                if (SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.ExternalUser)
                {
                    Response.Redirect("~/Admin/login.aspx");
                }

                Response.Redirect("~/Admin/Default.aspx");
            }
        }
    }
}
