
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
#endregion

public partial class AdminRolesEdit : System.Web.UI.Page
{
    #region Declare Variables

    private int adminRoleId = 0;

    #endregion

    #region Properties

    JXTPortal.AdminRolesService _adminRolesService;
    JXTPortal.AdminRolesService AdminRolesService
    {
        get
        {
            if (_adminRolesService == null)
            {
                _adminRolesService = new JXTPortal.AdminRolesService();
            }
            return _adminRolesService;
        }
    }

    private int AdminRoleID
    {
        get
        {
            if ((Request.QueryString["AdminRoleId"] != null))
            {
                if (int.TryParse((Request.QueryString["AdminRoleId"].Trim()), out adminRoleId))
                {
                    adminRoleId = Convert.ToInt32(Request.QueryString["AdminRoleId"]);
                }
                return adminRoleId;
            }
            return adminRoleId;
        }
    }

    #endregion

    #region Page Event handlers

    protected void Page_Load(object sender, EventArgs e)
	{
        if (!IsPostBack)
        {
            loadForm(); 
        }
    }

    #endregion

    #region Methods

    protected void loadForm()
    {
        if (AdminRoleID > 0)
        {
            using(JXTPortal.Entities.AdminRoles objAdminRoles = AdminRolesService.GetByAdminRoleId(AdminRoleID))
            {
                txtAdminRoleName.Text = objAdminRoles.RoleName;
            } 
        }
    }

    #endregion

    #region Click Event handlers

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            using (JXTPortal.Entities.AdminRoles objAdminRoles = new JXTPortal.Entities.AdminRoles())
            {
                objAdminRoles.AdminRoleId = AdminRoleID;
                objAdminRoles.RoleName = txtAdminRoleName.Text;

                if (AdminRoleID > 0)
                {
                    AdminRolesService.Update(objAdminRoles);
                }
                else
                {
                    AdminRolesService.Insert(objAdminRoles);
                }

                Response.Redirect("adminroles.aspx");
            }
        }
    }

    #endregion
}


