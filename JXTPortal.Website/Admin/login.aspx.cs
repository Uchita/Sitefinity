using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using JXTPortal.Entities;

namespace JXTPortal.Website.Admin
{
    public partial class login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            ltlSiteUrl.Text = SessionData.Site.SiteUrl;

            ltErrorMessage.Visible = false;
            if (!Page.IsPostBack)
            {
                SetLogo();

                LoadPageContent();

                // If the User is logged in then redirect to Default page.
                if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId != (int)PortalEnums.Admin.AdminRole.ExternalUser)
                {
                    Response.Redirect("default.aspx");
                }
            }

            // Get the dynamic content for the right bar.
            DynamicContentService DynamicContentService = new DynamicContentService();
            using (TList<DynamicContent> dynamiccontents = DynamicContentService.GetBySiteId(Convert.ToInt32(ConfigurationManager.AppSettings["MasterSiteID"])))
            {
                if (dynamiccontents != null)
                {
                    DynamicContent dynamicContent = dynamiccontents.Where(s => s.DynamicContentType == ((int)PortalEnums.DynamicContent.DynamicContentType.AdminLoginContent)).FirstOrDefault();

                    if (dynamicContent != null)
                    {

                    }

                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string errormsg;
            if (Login(txtUserName.Text, txtPassword.Text, out errormsg))
            {
                //override the SiteID
                //SessionData.Site = SitesService.GetBySiteId(Convert.ToInt32(ddlSite.SelectedValue));
                Response.Redirect(GetReturnURL());
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(errormsg))
                {
                    ltErrorMessage.Visible = true;
                    ltErrorMessage.Text = "<div id='login-secure-error'>" + errormsg +  "</div>";
                }
            }
        }

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

        private SitesService _sitesService;

        private SitesService SitesService
        {
            get
            {
                if (_sitesService == null) _sitesService = new SitesService();
                return _sitesService;
            }
        }

        #endregion

        #region "Methods"

        private void SetLogo()
        {
            /*
            hypAdminLogo.NavigateUrl = "~/";

            if (SessionData.Site.HasAdminLogo)
            {
                hypAdminLogo.ImageUrl = "~/Admin/GetAdminLogo.aspx?SiteID=" + SessionData.Site.SiteId.ToString();
            }
            else
            {
                // Default
                hypAdminLogo.ImageUrl = "~/Admin/GetAdminLogo.aspx?SiteID=" + JXTPortal.Common.Utils.GetAppSettings("MasterSiteID");

            }
            */
        }

        private void LoadPageContent()
        {
            DynamicContentService DynamicContentService = new DynamicContentService();

            using (TList<DynamicContent> dynamiccontents = DynamicContentService.GetBySiteId(Convert.ToInt32(ConfigurationManager.AppSettings["MasterSiteID"])))
            {

                using (DynamicContent target = dynamiccontents.Where(c => c.DynamicContentType == (int)PortalEnums.DynamicContent.DynamicContentType.AdminLoginContent).FirstOrDefault())
                {
                    if (target != null)
                    {
                        ltlContent.Text = target.Description;
                    }
                }
            }

        }

        private Boolean Login(string userName, string userPassword, out string errormsg)
        {
            bool authenticated = false;
            errormsg = string.Empty;
            string strAdministratorRoleID = ConfigurationManager.AppSettings["AdministratorRoleID"];
            
            // User Login
            JXTPortal.Entities.AdminUsers adminUser = null;

            // Check the super administrator login
            using (adminUser = AdminUsersService.GetBySiteIdUserName(1, userName))
            {

            }

            if (adminUser == null)
            {
                // Check the local site
                using (adminUser = AdminUsersService.GetBySiteIdUserName(SessionData.Site.SiteId, userName))
                {
                }

                /*
                // And then check the super administrator login
                using (adminUser = AdminUsersService.GetBySiteIdUserName(1, userName))
                {

                }*/
            }
            else
            {
                // If admin login doesn't match the password.
                if (adminUser.UserPassword != userPassword)
                {
                    // Check the local site
                    using (adminUser = AdminUsersService.GetBySiteIdUserName(SessionData.Site.SiteId, userName))
                    {
                    }

                }
            }

            if (adminUser != null)
            {
                // external users not allowed to login.
                if (adminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.ExternalUser)
                {
                    errormsg = "You are not authorised to login.";
                    return false;
                }

                // if locked and attempted within 1 hour - tell user their account has been locked - return
                if (adminUser.Status == (int)PortalEnums.Admin.UserStatus.Locked || adminUser.Status == (int)PortalEnums.Admin.UserStatus.Closed)
                {
                    DateTime CurrentTime = DateTime.Now;
                    DateTime lockedDate = CurrentTime;

                    if (adminUser.LastAttemptDate.HasValue)
                    {
                        lockedDate = adminUser.LastAttemptDate.Value;
                    }
                    else
                    {
                        adminUser.LastAttemptDate = lockedDate;
                        AdminUsersService.Update(adminUser);
                    }

                    TimeSpan timespan = lockedDate.AddSeconds(3599).Subtract(CurrentTime);

                    // lock is still valid
                    if (timespan.Hours < 1 && CurrentTime < lockedDate.AddHours(1))
                    {
                        errormsg = string.Format(CommonFunction.GetResourceValue("LabelTempLocked"), (timespan.Minutes < 1) ? 1 : (int)timespan.Minutes); // TODO: Language
                        return false;
                    }
                    else
                    {
                        // if more than 1 hour, reset attempt to 0, attempt date = null and locked = 0
                        adminUser.LoginAttempts = 0;
                        adminUser.LastAttemptDate = null;

                        AdminUsersService.Update(adminUser);
                    }
                }
            }
            else
            {
                errormsg = CommonFunction.GetResourceValue("LabelAccessDenied");
                return false;
            }

            //external user should not have access to admin page
            if (adminUser != null && adminUser.UserPassword == userPassword) // && (adminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.ContentEditor || adminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Developer || adminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Contributor)
            {

                SessionService.SetAdminUser(adminUser);
                SessionData.AdminUser.isAdminUser = (adminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Administrator ? true : false);
                authenticated = true;

                // Set Attempt count = 0
                // Last Attempt date = null
                // Locked = 0

                if (adminUser.LoginAttempts > 0)
                {
                    adminUser.LoginAttempts = 0;
                }

                adminUser.Status = (int)PortalEnums.Admin.UserStatus.Valid;
                adminUser.LastAttemptDate = null;
                AdminUsersService.Update(adminUser);



                return true;
            }
            else
            {
                // Login Failed
                if (adminUser != null)
                {
                    adminUser.LoginAttempts += 1;
                    errormsg = string.Format(string.Format(CommonFunction.GetResourceValue("LabelAttemptFailed"), 5 - adminUser.LoginAttempts)); // TODO: Language

                    if (adminUser.LoginAttempts >= 5)
                    {
                        adminUser.Status = (int)PortalEnums.Admin.UserStatus.Locked;
                        adminUser.LastAttemptDate = DateTime.Now;
                        errormsg = string.Format(CommonFunction.GetResourceValue("LabelAccountLocked")); // TODO: Language
                    }

                    AdminUsersService.Update(adminUser);
                }
                else
                {
                    errormsg = CommonFunction.GetResourceValue("LabelAccessDenied");
                }
            }



            return authenticated;
        }

        /*
        private Boolean Login(string userName, string userPassword, out string errormsg)
        {
            bool authenticated = false;
            errormsg = string.Empty;

            if (true) //chkAdmin.Checked
            {
                // Super Admin User Login
                string strAdministratorRoleID = ConfigurationManager.AppSettings["AdministratorRoleID"];
                //if (SessionData.Site.SiteId == 1)
                //{
                //    strAdministratorRoleID = "0";
                //}

                // Admin User Login
                // Todo - Create a SP
                // Changed to remove password filter
                using (JXTPortal.Entities.AdminUsers adminUser = AdminUsersService.GetBySiteIdUserName(1, userName))
                {
                    if (adminUser != null)
                    {
                        // if locked and attempted within 1 hour - tell user their account has been locked - return
                        if (adminUser.Status == (int)PortalEnums.Admin.UserStatus.Locked || adminUser.Status == (int)PortalEnums.Admin.UserStatus.Closed)
                        {
                            DateTime CurrentTime = DateTime.Now;
                            DateTime lockedDate = CurrentTime;

                            if (adminUser.LastAttemptDate.HasValue)
                            {
                                lockedDate = adminUser.LastAttemptDate.Value;
                            }
                            else
                            {
                                adminUser.LastAttemptDate = lockedDate;
                                AdminUsersService.Update(adminUser);
                            }

                            TimeSpan timespan = lockedDate.AddSeconds(3599).Subtract(CurrentTime);

                            // lock is still valid
                            if (timespan.Hours < 1 && CurrentTime < lockedDate.AddHours(1))
                            {
                                errormsg = string.Format(CommonFunction.GetResourceValue("LabelTempLocked"), (timespan.Minutes < 1) ? 1 : (int)timespan.Minutes); // TODO: Language
                                return false;
                            }
                            else
                            {
                                // if more than 1 hour, reset attempt to 0, attempt date = null and locked = 0
                                adminUser.LoginAttempts = 0;
                                adminUser.LastAttemptDate = null;

                                AdminUsersService.Update(adminUser);
                            }
                        }

                        // if (adminUser.UserPassword.Equals(userPassword) == false)

                        // add attempt count, if count becomes 5, status = 1

                        //external user should not have access to admin page
                        if (adminUser.UserPassword.Equals(userPassword) && (adminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Administrator))
                        {
                            SessionService.SetAdminUser(adminUser);
                            SessionData.AdminUser.isAdminUser = true;
                            //adminUsers[0].isAdminUser = true;

                            // Set Attempt count = 0
                            // Last Attempt date = null
                            // Locked = 0

                            if (adminUser.LoginAttempts > 0)
                            {
                                adminUser.LoginAttempts = 0;        
                            }


                            adminUser.Status = (int)PortalEnums.Admin.UserStatus.Valid;
                            adminUser.LastAttemptDate = null;
                            AdminUsersService.Update(adminUser);


                            return true;
                        }
                        else
                        {
                            // Login Failed
                            adminUser.LoginAttempts += 1;
                            errormsg = string.Format(string.Format(CommonFunction.GetResourceValue("LabelAttemptFailed"), 5 - adminUser.LoginAttempts)); // TODO: Language

                            if (adminUser.LoginAttempts >= 5)
                            {
                                adminUser.Status = (int)PortalEnums.Admin.UserStatus.Locked;
                                adminUser.LastAttemptDate = DateTime.Now;
                                errormsg = string.Format(CommonFunction.GetResourceValue("LabelAccountLocked")); // TODO: Language
                            }

                            AdminUsersService.Update(adminUser);
                        }
                    }
                    else
                    {
                        errormsg = CommonFunction.GetResourceValue("LabelAccessDenied");
                        return false;
                    }
                }
            }
            else
            {
                // User Login
                JXTPortal.Entities.AdminUsers adminUser = AdminUsersService.GetBySiteIdUserName(SessionData.Site.SiteId, userName);

                if (adminUser != null)
                {
                    // if locked and attempted within 1 hour - tell user their account has been locked - return
                    if (adminUser.Status == (int)PortalEnums.Admin.UserStatus.Locked || adminUser.Status == (int)PortalEnums.Admin.UserStatus.Closed)
                    {
                        DateTime CurrentTime = DateTime.Now;
                        DateTime lockedDate = CurrentTime;

                        if (adminUser.LastAttemptDate.HasValue)
                        {
                            lockedDate = adminUser.LastAttemptDate.Value;
                        }
                        else
                        {
                            adminUser.LastAttemptDate = lockedDate;
                            AdminUsersService.Update(adminUser);
                        }

                        TimeSpan timespan = lockedDate.AddSeconds(3599).Subtract(CurrentTime);

                        // lock is still valid
                        if (timespan.Hours < 1 && CurrentTime < lockedDate.AddHours(1))
                        {
                            errormsg = string.Format(CommonFunction.GetResourceValue("LabelTempLocked"), (timespan.Minutes < 1) ? 1 : (int)timespan.Minutes); // TODO: Language
                            return false;
                        }
                        else
                        {
                            // if more than 1 hour, reset attempt to 0, attempt date = null and locked = 0
                            adminUser.LoginAttempts = 0;
                            adminUser.LastAttemptDate = null;

                            AdminUsersService.Update(adminUser);
                        }
                    }
                }
                else
                {
                    errormsg = CommonFunction.GetResourceValue("LabelAccessDenied");
                    return false;
                }

                //external user should not have access to admin page
                if (adminUser != null && adminUser.UserPassword == userPassword && (adminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.ContentEditor || adminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Developer || adminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Contributor))
                {
                    SessionService.SetAdminUser(adminUser);
                    SessionData.AdminUser.isAdminUser = false;
                    authenticated = true;

                    // Set Attempt count = 0
                    // Last Attempt date = null
                    // Locked = 0

                    if (adminUser.LoginAttempts > 0)
                    {
                        adminUser.LoginAttempts = 0;
                    }

                    adminUser.Status = (int)PortalEnums.Admin.UserStatus.Valid;
                    adminUser.LastAttemptDate = null;
                    AdminUsersService.Update(adminUser);



                    return true;
                }
                else
                {
                    // Login Failed
                    if (adminUser != null)
                    {
                        adminUser.LoginAttempts += 1;
                        errormsg = string.Format(string.Format(CommonFunction.GetResourceValue("LabelAttemptFailed"), 5 - adminUser.LoginAttempts)); // TODO: Language

                        if (adminUser.LoginAttempts >= 5)
                        {
                            adminUser.Status = (int)PortalEnums.Admin.UserStatus.Locked;
                            adminUser.LastAttemptDate = DateTime.Now;
                            errormsg = string.Format(CommonFunction.GetResourceValue("LabelAccountLocked")); // TODO: Language
                        }

                        AdminUsersService.Update(adminUser);
                    }
                    else
                    {
                        errormsg = CommonFunction.GetResourceValue("LabelAccessDenied");
                    }
                }
            }
            return authenticated;
        }*/

        private string GetReturnURL()
        {
            string returnUrl = "~/admin/default.aspx";

            if (HttpContext.Current.Request.QueryString["ReturnURL"] != null
                    && !string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["ReturnURL"]))
            {
                // only if the return url is part of the site.
                if (Uri.IsWellFormedUriString(Request.QueryString["ReturnUrl"], UriKind.Relative))
                    returnUrl = HttpContext.Current.Request.QueryString["ReturnURL"].ToLower();
            }


            return returnUrl;
        }

        #endregion
    }
}
