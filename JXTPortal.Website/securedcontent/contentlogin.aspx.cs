using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.securedcontent
{
    public partial class contentlogin : System.Web.UI.Page
    {
        #region "Properties"

        private AdminUsersService _adminUsersService;

        private AdminUsersService AdminUsersService
        {
            get
            {
                if (_adminUsersService == null)
                {
                    _adminUsersService = new AdminUsersService();
                }

                return _adminUsersService;
            }
        }

        #endregion

        #region Page Events

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Secured Member Login");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            //SetLogo();
            SetFormValues();
        }

        #endregion

        #region Methods

        private bool LoginCheck()
        {
            bool valid = false;

            // User Login
            JXTPortal.Entities.AdminUsers adminUser = AdminUsersService.GetBySiteIdUserName(SessionData.Site.SiteId, txtUserName.Text);

            if (adminUser != null && adminUser.UserPassword == txtPassword.Text && adminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.ExternalUser)
            {
                SessionService.SetAdminUser(adminUser);
                SessionData.AdminUser.isAdminUser = false;
                valid = true;
            }

            return valid;
        }

        public void SetFormValues()
        {
            btnLogin.Text = CommonFunction.GetResourceValue("ButtonSubmit");
        }

        //private void SetLogo()
        //{

        //    hypAdminLogo.NavigateUrl = "~/";

        //    if (SessionData.Site.HasAdminLogo)
        //    {
        //        hypAdminLogo.ImageUrl = "~/Admin/GetAdminLogo.aspx?SiteID=" + SessionData.Site.SiteId.ToString();
        //    }
        //    else
        //    {
        //        // Default
        //        hypAdminLogo.ImageUrl = "~/Admin/GetAdminLogo.aspx?SiteID=" + JXTPortal.Common.Utils.GetAppSettings("MasterSiteID");

        //    }
        //}

        #endregion

        #region Click Event handlers

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (LoginCheck())
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                {
                    Response.Redirect(Server.UrlDecode(Request.QueryString["ReturnUrl"]));
                }

                Response.Redirect("~/pages/securedmain");
            }
            else
            {
                ltErrorMessage.Text = string.Format("<div id=\"login-secure-error\" >{0}</div>", CommonFunction.GetResourceValue("LabelAccessDenied"));
            }
        }

        #endregion
    }
}
