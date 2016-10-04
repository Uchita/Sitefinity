
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
using JXTPortal;
#endregion

public partial class RolesEdit : System.Web.UI.Page
{
    #region Declarations

    private int _roleid = 0;
    private ProfessionService _professionService;
    private RolesService _rolesService;

    #endregion

    #region Properties

    private ProfessionService ProfessionService
    {
        get
        {
            if (_professionService == null)
            {
                _professionService = new ProfessionService();
            }
            return _professionService;
        }
    }

    private RolesService RolesService
    {
        get
        {
            if (_rolesService == null)
            {
                _rolesService = new RolesService();
            }
            return _rolesService;
        }
    }


    protected int RoleId
    {
        get
        {
            if ((Request.QueryString["RoleId"] != null))
            {
                if (int.TryParse((Request.QueryString["RoleId"].Trim()), out _roleid))
                {
                    _roleid = Convert.ToInt32(Request.QueryString["RoleId"]);
                }
                return _roleid;
            }

            return _roleid;
        }
    }

    #endregion

    #region Page

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadProfessions();
            LoadRoles();

            btnEditSave.Visible = (RoleId > 0);

            // Insert is commented out for webservice purposes - Ditto 21/02/2013
            // btnInsert.Visible = (RoleId == 0);
        }
    }

    #endregion

    #region Methods

    private void LoadProfessions()
    {
        using (JXTPortal.Entities.TList<JXTPortal.Entities.Profession> professions = ProfessionService.GetAll())
        {
            dataProfession.DataSource = professions;
            dataProfession.DataBind();
        }
    }

    private void LoadRoles()
    {
        if (RoleId > 0)
        {
            using (JXTPortal.Entities.Roles role = RolesService.GetByRoleId(RoleId))
            {
                dataProfession.SelectedValue = role.ProfessionId.ToString();
                dataRoleName.Text = role.RoleName;
                dataValid.Checked = role.Valid;
                dataMetaTitle.Text = HttpUtility.HtmlDecode(role.MetaTitle);
                dataMetaKeywords.Text = HttpUtility.HtmlDecode(role.MetaKeywords);
                dataMetaDescription.Text = HttpUtility.HtmlDecode(role.MetaDescription);
            }
        }
    }

    #endregion

    #region GridViewSiteRoles Events

    protected void GridViewSiteRoles1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string urlParams = string.Format("SiteRoleId={0}", GridViewSiteRoles1.SelectedDataKey.Values[0]);
        Response.Redirect("siterolesedit.aspx?" + urlParams, true);
    }

    #endregion

    #region Events

    // Insert is commented out for webservice purposes - Ditto 21/02/2013

    //protected void btnInsert_Click(object sender, EventArgs e)
    //{
    //    using (JXTPortal.Entities.Roles salarytype = new JXTPortal.Entities.Roles())
    //    {
    //        salarytype.ProfessionId = Convert.ToInt32(dataProfession.SelectedValue);
    //        salarytype.RoleName = dataRoleName.Text;
    //        salarytype.Valid = dataValid.Checked;
    //        salarytype.MetaTitle = HttpUtility.HtmlEncode(dataMetaTitle.Text);
    //        salarytype.MetaKeywords = HttpUtility.HtmlEncode(dataMetaKeywords.Text);
    //        salarytype.MetaDescription = HttpUtility.HtmlEncode(dataMetaDescription.Text);

    //        SiteRolesService.Insert(salarytype);
    //        Response.Redirect("roles.aspx");
    //    }
    //}

    protected void btnEditSave_Click(object sender, EventArgs e)
    {
        using (JXTPortal.Entities.Roles role = new JXTPortal.Entities.Roles())
        {
            role.RoleId = RoleId;
            role.ProfessionId = Convert.ToInt32(dataProfession.SelectedValue);
            role.RoleName = dataRoleName.Text;
            role.Valid = dataValid.Checked;
            role.MetaTitle = HttpUtility.HtmlEncode(dataMetaTitle.Text);
            role.MetaKeywords = HttpUtility.HtmlEncode(dataMetaKeywords.Text);
            role.MetaDescription = HttpUtility.HtmlEncode(dataMetaDescription.Text);

            RolesService.Update(role);
            Response.Redirect("roles.aspx");
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("roles.aspx");
    }

    #endregion
}


