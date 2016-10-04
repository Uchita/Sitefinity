
#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JXTPortal.Web.UI;
using JXTPortal.Entities;
using JXTPortal.Website;
using JXTPortal;
using System.Text.RegularExpressions;
using System.Collections.Generic;
#endregion

public partial class AdminUsersEdit : System.Web.UI.Page
{
    #region Declare Variables

    private int adminUserID = 0;

    #endregion

    #region Properties

    JXTPortal.AdminUsersService _adminUsersService;
    JXTPortal.AdminUsersService AdminUsersService
    {
        get
        {
            if (_adminUsersService == null)
            {
                _adminUsersService = new JXTPortal.AdminUsersService();
            }
            return _adminUsersService;

        }
    }

    private int AdminUserID
    {
        get
        {
            if ((Request.QueryString["AdminUserId"] != null))
            {
                if (int.TryParse((Request.QueryString["AdminUserId"].Trim()), out adminUserID))
                {
                    adminUserID = Convert.ToInt32(Request.QueryString["AdminUserId"]);
                }
                return adminUserID;
            }
            return adminUserID;
        }
    }

    #endregion

    #region Page Event handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        if (SessionData.AdminUser == null)
        {
            Response.Redirect("~/admin/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
            return;
        }

        if (!IsPostBack)
        {
            loadForm();
        }
    }

    #endregion

    #region Methods

    protected void loadForm()
    {

        populateAdminRoles();

        if (AdminUserID > 0)
        {
            using (JXTPortal.Entities.AdminUsers objAdminUser = AdminUsersService.GetByAdminUserId(AdminUserID))
            {
                if (objAdminUser != null && objAdminUser.SiteId == SessionData.Site.SiteId)
                {
                    if (objAdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Administrator)
                    {
                        Response.Redirect("adminusers.aspx");
                    }

                    if (objAdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Developer &&
                        SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.ContentEditor)
                    {
                        Response.Redirect("adminusers.aspx");
                    }

                    if (objAdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Administrator &&
                        SessionData.AdminUser.AdminRoleId != objAdminUser.AdminRoleId)
                    {
                        Response.Redirect("adminusers.aspx");
                    }

                    //Password locked panel
                    if (objAdminUser.Status == (int)PortalEnums.Members.UserStatus.Locked &&
                        objAdminUser.LastAttemptDate.HasValue &&
                        DateTime.Now <= objAdminUser.LastAttemptDate.Value.AddHours(1))
                    {
                        PasswordLockedForm.Visible = true;
                        PasswordLockedTime.Text = objAdminUser.LastAttemptDate.HasValue ? objAdminUser.LastAttemptDate.Value.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt") : string.Empty;
                    }

                    ReqVal_AdminUserPassword.Enabled = false;
                    ddlAdminRoleID.SelectedValue = Convert.ToString(objAdminUser.AdminRoleId);
                    txtAdminUserUsername.Text = objAdminUser.UserName;
                    txtAdminUserPassword.Text = objAdminUser.UserPassword;
                    txtAdminUserFirstName.Text = objAdminUser.FirstName;
                    txtAdminUserSurname.Text = objAdminUser.Surname;
                    txtAdminUserEmail.Text = objAdminUser.Email;
                    lblAdminuserSiteID.Text = Convert.ToString(objAdminUser.SiteId);

                }
                else
                {
                    Response.Redirect("adminusers.aspx");
                }
            }
        }
    }

    protected void populateAdminRoles()
    {
        JXTPortal.AdminRolesService adminRoles = new JXTPortal.AdminRolesService();

        TList<AdminRoles> availableRoles = new TList<AdminRoles>();

        List<PortalEnums.Admin.AdminRole> rolesForCurrentRole = CurrentUserAvailableTargetRolesGet();

        foreach (AdminRoles r in adminRoles.GetAll())
        {
            if (rolesForCurrentRole.Contains((PortalEnums.Admin.AdminRole)r.AdminRoleId))
                availableRoles.Add(r);
        }

        ddlAdminRoleID.DataSource = availableRoles;
        ddlAdminRoleID.DataTextField = "RoleName";
        ddlAdminRoleID.DataValueField = "AdminRoleID";
        ddlAdminRoleID.DataBind();
        ddlAdminRoleID.Items.Insert(0, new ListItem(" Please Choose ...", "0"));
        //ddlAdminRoleID.Items.RemoveAt(1);

        if (SessionData.AdminUser != null && !SessionData.AdminUser.isAdminUser)
        {

            ddlAdminRoleID.SelectedValue = ((int)PortalEnums.Admin.AdminRole.ContentEditor).ToString();

        }
    }

    private List<PortalEnums.Admin.AdminRole> CurrentUserAvailableTargetRolesGet()
    {
        switch ((PortalEnums.Admin.AdminRole)SessionData.AdminUser.AdminRoleId)
        {
            case PortalEnums.Admin.AdminRole.Administrator:
                //case PortalEnums.Admin.AdminRole.SuperAdministrator:
                return new List<PortalEnums.Admin.AdminRole> { PortalEnums.Admin.AdminRole.ContentEditor, PortalEnums.Admin.AdminRole.Developer, PortalEnums.Admin.AdminRole.ExternalUser, PortalEnums.Admin.AdminRole.Contributor };
            case PortalEnums.Admin.AdminRole.ContentEditor:
                return new List<PortalEnums.Admin.AdminRole> { PortalEnums.Admin.AdminRole.ContentEditor, PortalEnums.Admin.AdminRole.ExternalUser, PortalEnums.Admin.AdminRole.Contributor };
            case PortalEnums.Admin.AdminRole.Developer:
            case PortalEnums.Admin.AdminRole.ExternalUser:
                return new List<PortalEnums.Admin.AdminRole> { };
            default:
                return new List<PortalEnums.Admin.AdminRole> { };
        }
    }

    #endregion

    #region Click Event handlers

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            JXTPortal.Entities.AdminUsers objAdminUsers = new JXTPortal.Entities.AdminUsers();

            try
            {
                if (AdminUserID > 0)
                {
                    objAdminUsers = AdminUsersService.GetByAdminUserId(AdminUserID);
                    if (objAdminUsers != null)
                    {
                        if (objAdminUsers.SiteId != SessionData.Site.SiteId)
                        {
                            Response.Redirect("adminusers.aspx");
                        }
                    }
                }

                //validation check for admin role ID selected
                List<PortalEnums.Admin.AdminRole> rolesForCurrentRole = CurrentUserAvailableTargetRolesGet();
                PortalEnums.Admin.AdminRole selectedTargetUpdateToRole = 0;
                if (
                    Enum.TryParse(ddlAdminRoleID.SelectedValue, out selectedTargetUpdateToRole)
                    && rolesForCurrentRole.Contains(selectedTargetUpdateToRole)
                    )
                {
                    objAdminUsers.SiteId = SessionData.Site.SiteId;
                    objAdminUsers.AdminRoleId = Convert.ToInt32((int)selectedTargetUpdateToRole);
                    objAdminUsers.UserName = CommonService.EncodeString(txtAdminUserUsername.Text);
                    if (!string.IsNullOrEmpty(txtAdminUserPassword.Text))
                    {
                        objAdminUsers.UserPassword = txtAdminUserPassword.Text;
                    }
                    objAdminUsers.FirstName = CommonService.EncodeString(txtAdminUserFirstName.Text);
                    objAdminUsers.Surname = CommonService.EncodeString(txtAdminUserSurname.Text);
                    objAdminUsers.Email = CommonService.EncodeString(txtAdminUserEmail.Text);

                    if (AdminUserID > 0)
                    {
                        //Update Admin user
                        AdminUsersService.Update(objAdminUsers);
                    }
                    else
                    {
                        //Insert New Admin user
                        AdminUsersService.Insert(objAdminUsers);
                    }

                }
                else
                {
                    //failed to parse role
                    Response.Write(Request.RawUrl.ToString()); // redirect on itself
                }

            }
            catch (Exception ex)
            {
                ltlMessage.Text = ex.Message;
            }
            finally
            {
                objAdminUsers.Dispose();
            }
            Response.Redirect("adminusers.aspx");

        }
    }

    protected void btnPasswordUnlock_Click(object sender, EventArgs e)
    {
        JXTPortal.Entities.AdminUsers objAdminUsers = new JXTPortal.Entities.AdminUsers();

        if (AdminUserID > 0)
        {
            objAdminUsers = AdminUsersService.GetByAdminUserId(AdminUserID);

            if (objAdminUsers != null && objAdminUsers.Status == (int)PortalEnums.Members.UserStatus.Locked)
            {
                objAdminUsers.Status = (int)PortalEnums.Members.UserStatus.Valid;
                objAdminUsers.LastAttemptDate = null;
                objAdminUsers.LoginAttempts = 0;

                AdminUsersService.Update(objAdminUsers);
            }

            Response.Redirect(Request.RawUrl);
        }
    }


    #endregion

    protected void CusVal_AdminUserUserName_ServerValidate(object source, ServerValidateEventArgs args)
    {
        using (TList<JXTPortal.Entities.AdminUsers> adminUsers = AdminUsersService.Find(String.Format("UserName='{0}' AND AdminRoleID = {1}",
                                                                                                    CommonService.EncodeString(txtAdminUserUsername.Text, true),
                                                                                                    ddlAdminRoleID.SelectedValue)))
        {
            if (ddlAdminRoleID.SelectedValue != ConfigurationManager.AppSettings["AdministratorRoleID"])
            {
                adminUsers.Filter = "SiteID = " + SessionData.Site.SiteId.ToString();
            }

            if (adminUsers.Count > 0)
            {
                JXTPortal.Entities.AdminUsers adminUser = adminUsers[0];

                if (AdminUserID <= 0)
                {
                    args.IsValid = false;
                }
                else
                {
                    if (AdminUserID > 0 && adminUser.AdminUserId != AdminUserID)
                    {
                        args.IsValid = false;
                    }
                }
            }
        }
    }

    protected void CusVal_AdminUserPassword_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (!string.IsNullOrEmpty(txtAdminUserPassword.Text))
        {
            Regex r = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?\{\}\[\]\(\)~\`\<\>\,\.\:\""\;\'\/\\_\+\=\^\| &-])[A-Za-z\d$@$!%*#?\{\}\[\]\(\)~\`\<\>\,\.\:\""\;\'\/\\_\+\=\^\| &-]{8,}$", RegexOptions.IgnoreCase);
            Match m = r.Match(txtAdminUserPassword.Text);

            args.IsValid = m.Success;
        }
    }
}


