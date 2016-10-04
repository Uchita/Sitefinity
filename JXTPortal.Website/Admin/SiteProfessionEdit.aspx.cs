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
using JXTPortal.Website.Admin.UserControls;
using JXTPortal.Entities;
using JXTPortal;
using JXTPortal.Common;
#endregion

public partial class SiteProfessionEdit : System.Web.UI.Page
{
    #region Declaration

    private int _professionid = 0;
    private int _siteprofessionid = 0;
    private ProfessionService _professionservice;
    private SiteProfessionService _siteprofessionservice;

    #endregion

    #region Properties

    private int ProfessionId
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

    private int SiteProfessionId
    {
        get
        {
            if ((Request.QueryString["SiteProfessionId"] != null))
            {
                if (int.TryParse((Request.QueryString["SiteProfessionId"].Trim()), out _siteprofessionid))
                {
                    _siteprofessionid = Convert.ToInt32(Request.QueryString["SiteProfessionId"]);
                }
                return _siteprofessionid;
            }

            return _siteprofessionid;
        }
    }

    private ProfessionService ProfessionService
    {
        get
        {
            if (_professionservice == null)
            {
                _professionservice = new ProfessionService();
            }
            return _professionservice;
        }
    }

    private SiteProfessionService SiteProfessionService
    {
        get
        {
            if (_siteprofessionservice == null)
            {
                _siteprofessionservice = new SiteProfessionService();
            }
            return _siteprofessionservice;
        }
    }

    #endregion

    #region Page Events

    /// <summary>
    /// Method to Load Folders and Files of the Selected Folder 
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SiteProfessionId > 0)
        {
            JXTPortal.Entities.SiteProfession siteprofession = SiteProfessionService.GetBySiteProfessionId(SiteProfessionId);
            if (siteprofession == null)
                Response.Redirect("ProfessionEdit.aspx");
            _professionid = siteprofession.ProfessionId;
        }

        if (!Page.IsPostBack)
        {
            LoadSiteProfession();
        }
    }

    #endregion

    #region Methods

    private void LoadSiteProfession()
    {
        if (ProfessionId > 0)
        {
            using (DataSet siteprofessions = ProfessionService.GetDetailWithSite(SessionData.Site.SiteId, ProfessionId))
            {
                if (siteprofessions.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = siteprofessions.Tables[0].Rows[0];

                    lbProfessionName.Text = dr["ProfessionName"].ToString();
                    lbValid.Text = dr["Valid"].ToString();
                    lbMetaTitle.Text = dr["MetaTitle"].ToString();
                    lbMetaKeywords.Text = dr["MetaKeywords"].ToString();
                    lbMetaDescription.Text = dr["MetaDescription"].ToString();

                    dataProfessionName.Text = dr["SiteProfessionName"].ToString();
                    dataMetaTitle.Text = dr["ProfessionalMetaTitle"].ToString();
                    dataMetaKeywords.Text = dr["ProfessionalMetaKeywords"].ToString();
                    dataMetaDescription.Text = dr["ProfessionalMetaDescription"].ToString();
                    dataFriendlyUrl.Text = dr["SiteProfessionFriendlyUrl"].ToString();
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

    #region Events

    protected void btnEditSave_Click(object sender, EventArgs e)
    {
        if (ProfessionId > 0)
        {
            using (TList<JXTPortal.Entities.SiteProfession> siteprofessions = SiteProfessionService.GetBySiteId(SessionData.Site.SiteId))
            {
                siteprofessions.Filter = "ProfessionId = " + ProfessionId.ToString();
                if (siteprofessions.Count > 0)
                {
                    JXTPortal.Entities.SiteProfession siteprofession = siteprofessions[0];
                    siteprofession.SiteProfessionName = dataProfessionName.Text;
                    siteprofession.Valid = true;
                    siteprofession.MetaTitle = HttpUtility.HtmlEncode(dataMetaTitle.Text);
                    siteprofession.MetaKeywords = HttpUtility.HtmlEncode(dataMetaKeywords.Text);
                    siteprofession.MetaDescription = HttpUtility.HtmlEncode(dataMetaDescription.Text);
                    siteprofession.SiteProfessionFriendlyUrl = Utils.UrlFriendlyName(dataFriendlyUrl.Text);
                    siteprofession.CanonicalUrl = HttpUtility.HtmlEncode(tbCanonicalUrl.Text);
                    siteprofession.Sequence = int.Parse(dataSequence.Text);
                    SiteProfessionService.Update(siteprofession);
                }
                else
                {
                    using (JXTPortal.Entities.SiteProfession siteprofession = new JXTPortal.Entities.SiteProfession())
                    {
                        siteprofession.SiteId = SessionData.Site.SiteId;
                        siteprofession.ProfessionId = ProfessionId;
                        siteprofession.SiteProfessionName = dataProfessionName.Text;
                        siteprofession.Valid = true;
                        siteprofession.MetaTitle = HttpUtility.HtmlEncode(dataMetaTitle.Text);
                        siteprofession.MetaKeywords = HttpUtility.HtmlEncode(dataMetaKeywords.Text);
                        siteprofession.MetaDescription = HttpUtility.HtmlEncode(dataMetaDescription.Text);
                        siteprofession.SiteProfessionFriendlyUrl = Utils.UrlFriendlyName(dataFriendlyUrl.Text);
                        siteprofession.CanonicalUrl = HttpUtility.HtmlEncode(tbCanonicalUrl.Text);
                        siteprofession.Sequence = int.Parse(dataSequence.Text);
                        siteprofession.TotalJobs = 0;
                        SiteProfessionService.Insert(siteprofession);
                    }
                }
            }

            if (SiteProfessionId > 0)
                Response.Redirect("professionedit.aspx?ProfessionId=" + ProfessionId.ToString());
            else
                Response.Redirect("siteprofession.aspx");
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        if (SiteProfessionId > 0)
            Response.Redirect("professionedit.aspx?ProfessionId=" + ProfessionId.ToString());
        else
            Response.Redirect("siteprofession.aspx");
    }

    #endregion
}
