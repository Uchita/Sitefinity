
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

public partial class ProfessionEdit : System.Web.UI.Page
{
    #region Declarations

    private int _professionid = 0;
    private ProfessionService _professionService;

    #endregion

    #region Properties

    protected int ProfessionId
    {
        get
        {
            if ((Request.QueryString["ProfessionId"] != null))
            {
                if (int.TryParse((Request.QueryString["ProfessionId"].Trim()), out _professionid))
                {
                    _professionid = Convert.ToInt32(Request.QueryString["ProfessionId"]);
                }
                return _professionid;
            }

            return _professionid;
        }
    }

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

    #endregion

    #region Page

    /// <summary>
    /// Method to Load Profession and setting buttons visibility 
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadProfession();

            btnEditSave.Visible = (ProfessionId > 0);

            // Insert is commented out for webservice purposes - Ditto 21/02/2013
            // btnInsert.Visible = (ProfessionId == 0);
        }
    }

    #endregion

    #region Methods

    private void LoadProfession()
    {
        if (ProfessionId > 0)
        {
            using (JXTPortal.Entities.Profession profession = ProfessionService.GetByProfessionId(ProfessionId))
            {
                dataProfessionName.Text = profession.ProfessionName;
                dataValid.Checked = profession.Valid;
                dataMetaTitle.Text = HttpUtility.HtmlDecode(profession.MetaTitle);
                dataMetaKeywords.Text = HttpUtility.HtmlDecode(profession.MetaKeywords);
                dataMetaDescription.Text = HttpUtility.HtmlDecode(profession.MetaDescription);
            }
        }
    }

    #endregion

    #region Events

    // Insert is commented out for webservice purposes - Ditto 21/02/2013

    //protected void btnInsert_Click(object sender, EventArgs e)
    //{
    //    using (JXTPortal.Entities.Profession profession = new JXTPortal.Entities.Profession())
    //    {
    //        profession.ProfessionId = ProfessionId;
    //        profession.ProfessionName = dataProfessionName.Text;
    //        profession.Valid = dataValid.Checked;
    //        profession.MetaTitle = HttpUtility.HtmlEncode(dataMetaTitle.Text);
    //        profession.MetaKeywords = HttpUtility.HtmlEncode(dataMetaKeywords.Text);
    //        profession.MetaDescription = HttpUtility.HtmlEncode(dataMetaDescription.Text);

    //        SiteProfessionService.Insert(profession);
    //        Response.Redirect("profession.aspx");
    //    }
    //}

    protected void btnEditSave_Click(object sender, EventArgs e)
    {
        using (JXTPortal.Entities.Profession profession = new JXTPortal.Entities.Profession())
        {
            profession.ProfessionId = ProfessionId;
            profession.ProfessionName = dataProfessionName.Text;
            profession.Valid = dataValid.Checked;
            profession.MetaTitle = HttpUtility.HtmlEncode(dataMetaTitle.Text);
            profession.MetaKeywords = HttpUtility.HtmlEncode(dataMetaKeywords.Text);
            profession.MetaDescription = HttpUtility.HtmlEncode(dataMetaDescription.Text);

            ProfessionService.Update(profession);
            Response.Redirect("profession.aspx");
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("profession.aspx");
    }

    #endregion

    #region GridViewRoles1 Events

    protected void GridViewRoles1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string urlParams = string.Format("RoleId={0}", GridViewRoles1.SelectedDataKey.Values[0]);
        Response.Redirect("rolesedit.aspx?" + urlParams, true);
    }

    #endregion

    //#region GridViewSiteProfession2 Events

    //protected void GridViewSiteProfession2_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string urlParams = string.Format("SiteProfessionId={0}", GridViewSiteProfession2.SelectedDataKey.Values[0]);
    //    Response.Redirect("siteprofessionedit.aspx?" + urlParams, true);
    //}

    //#endregion
}


