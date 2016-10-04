
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
using JXTPortal;
using JXTPortal.Common;
#endregion

public partial class SiteRolesEdit : System.Web.UI.Page
{
    #region Declarations

    private int _roleid = 0;
    private int _siteroleid = 0;
    private RolesService _roleservice;
    private SiteRolesService _siterolesservice;

    #endregion

    #region Propertis

    private int RoleId
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

    private int SiteRoleId
    {
        get
        {
            if ((Request.QueryString["SiteRoleId"] != null))
            {
                if (int.TryParse((Request.QueryString["SiteRoleId"].Trim()), out _siteroleid))
                {
                    _siteroleid = Convert.ToInt32(Request.QueryString["SiteRoleId"]);
                }
                return _siteroleid;
            }

            return _siteroleid;
        }
    }

    private RolesService RolesService
    {
        get
        {
            if (_roleservice == null)
            {
                _roleservice = new RolesService();
            }
            return _roleservice;
        }
    }

    private SiteRolesService SiteRolesService
    {
        get
        {
            if (_siterolesservice == null)
            {
                _siterolesservice = new SiteRolesService();
            }
            return _siterolesservice;
        }
    }

    #endregion

    #region Page Events

    /// <summary>
    /// Method to Load Folders and Files of the Selected Folder 
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SiteRoleId > 0)
        {
            JXTPortal.Entities.SiteRoles siterole = SiteRolesService.GetBySiteRoleId(SiteRoleId);
            _roleid = siterole.RoleId;
        }

        if (!Page.IsPostBack)
        {
            LoadSiteRoles();
        }
    }

    #endregion

    #region Events

    protected void btnEditSave_Click(object sender, EventArgs e)
    {
        if (RoleId > 0)
        {
            using (TList<JXTPortal.Entities.SiteRoles> siteroles = SiteRolesService.GetBySiteId(SessionData.Site.SiteId))
            {
                siteroles.Filter = "RoleId = " + RoleId.ToString();
                SiteRolesService.Delete(siteroles);
            }

            using (JXTPortal.Entities.SiteRoles siterole = new JXTPortal.Entities.SiteRoles())
            {
                siterole.SiteId = SessionData.Site.SiteId;
                siterole.RoleId = RoleId;
                siterole.SiteRoleName = dataRoleName.Text;
                siterole.Valid = true;
                siterole.MetaTitle = HttpUtility.HtmlEncode(dataMetaTitle.Text);
                siterole.MetaKeywords = HttpUtility.HtmlEncode(dataMetaKeywords.Text);
                siterole.MetaDescription = HttpUtility.HtmlEncode(dataMetaDescription.Text);
                siterole.SiteRoleFriendlyUrl = Utils.UrlFriendlyName(dataFriendlyUrl.Text);
                siterole.CanonicalUrl = HttpUtility.HtmlEncode(tbCanonicalUrl.Text);
                siterole.Sequence = int.Parse(dataSequence.Text);
                siterole.TotalJobs = 0;
                SiteRolesService.Insert(siterole);
            }

            if (SiteRoleId > 0)
                Response.Redirect("rolesedit.aspx?RoleId=" + RoleId.ToString());
            else
                Response.Redirect("siteprofession.aspx");
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        if (SiteRoleId > 0)
            Response.Redirect("rolesedit.aspx?RoleId=" + RoleId.ToString());
        else
            Response.Redirect("siteprofession.aspx");
    }

    #endregion

    #region Method

    private void LoadSiteRoles()
    {
        if (RoleId > 0)
        {
            using (DataSet siteroles = RolesService.GetDetailWithSite(SessionData.Site.SiteId, RoleId))
            {
                if (siteroles.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = siteroles.Tables[0].Rows[0];
                    lbRoleName.Text = dr["RoleName"].ToString();
                    lbMetaTitle.Text = dr["MetaTitle"].ToString();
                    lbMetaKeywords.Text = dr["MetaKeywords"].ToString();
                    lbMetaDescription.Text = dr["MetaDescription"].ToString();

                    dataRoleName.Text = dr["SiteRoleName"].ToString();
                    dataMetaTitle.Text = dr["RoleMetaTitle"].ToString();
                    dataMetaKeywords.Text = dr["RoleMetaKeywords"].ToString();
                    dataMetaDescription.Text = dr["RoleMetaDescription"].ToString();
                    dataFriendlyUrl.Text = dr["SiteRoleFriendlyUrl"].ToString();
                    dataSequence.Text = dr["Sequence"].ToString();
                    tbCanonicalUrl.Text = dr["CanonicalUrl"].ToString();
                }
                else
                {
                    Response.Redirect("siteprofession.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("siteprofession.aspx");
        }
    }

    #endregion

}


