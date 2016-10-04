
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
#endregion

public partial class Languages : System.Web.UI.Page
{
    #region Declare variables

    private int _siteLanguageId = -1;

    #endregion

    #region Properties

    private SiteLanguagesService _siteLanguagesService;

    private SiteLanguagesService SiteLanguagesService
    {
        get
        {
            if (_siteLanguagesService == null)
            {
                _siteLanguagesService = new SiteLanguagesService();
            }
            return _siteLanguagesService;
        }
    }

    private LanguagesService _languagesService;

    private LanguagesService LanguagesService
    {
        get
        {
            if (_languagesService == null)
            {
                _languagesService = new LanguagesService();
            }
            return _languagesService;
        }
    }

    private DynamicPagesService _dynamicpagesService;

    private DynamicPagesService DynamicPagesService
    {
        get
        {
            if (_dynamicpagesService == null)
            {
                _dynamicpagesService = new DynamicPagesService();
            }
            return _dynamicpagesService;
        }
    }

    private GlobalSettingsService _globalSettingsService;

    private GlobalSettingsService GlobalSettingsService
    {
        get
        {
            if (_globalSettingsService == null)
            {
                _globalSettingsService = new GlobalSettingsService();
            }
            return _globalSettingsService;
        }
    }

    #endregion

    #region Page Event handlers

    protected void Page_Init(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(this).RegisterPostBackControl(btnEditSave);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) Load();
    }

    #endregion

    #region Click Event handlers

    protected void btnLanguage_Click(object sender, EventArgs e)
    {
        MultiViewSiteLanguagesEdit.SetActiveView(ViewEditSiteLanguage);
        btnEditSave.Text = "Insert";
    }

    protected void btnEditSave_Click(object sender, EventArgs e)
    {
        using (JXTPortal.Entities.SiteLanguages siteLanguage = new JXTPortal.Entities.SiteLanguages())
        {
            int sitelanguageid = Convert.ToInt32(hfSiteLanguageId.Value);
            siteLanguage.SiteLanguageName = txtSiteLanguageName.Text;
            siteLanguage.LanguageId = Convert.ToInt32(ddlLanguages.SelectedValue);
            siteLanguage.SiteLanguageId = sitelanguageid;
            siteLanguage.SiteId = SessionData.Site.SiteId;

            if (sitelanguageid == -1)
            {
                if (SiteLanguagesService.Insert(siteLanguage))
                {
                    // Insert Pages from default language Id
                    //Remove existing dynamicpages first despite not likely to happen
                    using (TList<JXTPortal.Entities.DynamicPages> dps = DynamicPagesService.GetByLanguageId(siteLanguage.LanguageId))
                    {
                        dps.Filter = string.Format("SiteID = {0}", SessionData.Site.SiteId);

                        if (dps.Count > 0)
                        {
                            foreach (JXTPortal.Entities.DynamicPages dp in dps)
                            {
                                DynamicPagesService.Delete(dp);
                            }
                        }
                    }

                    // default language  id
                    int defaultlanguageId = 0;
                    using (TList<JXTPortal.Entities.GlobalSettings> gss = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
                    {
                        if (gss.Count > 0)
                        {
                            defaultlanguageId = gss[0].DefaultLanguageId;
                        }

                        if (defaultlanguageId > 0)
                        {
                            // Extract All DynamicPages from DefaultLanguage
                            ArrayList mappingList = new ArrayList();

                            using (TList<JXTPortal.Entities.DynamicPages> dps = DynamicPagesService.GetBySiteId(SessionData.Site.SiteId))
                            {
                                dps.Filter = string.Format("LanguageId = {0}", defaultlanguageId);

                                foreach (JXTPortal.Entities.DynamicPages dp in dps)
                                {
                                    int oldid = dp.DynamicPageId;

                                    dp.LanguageId = siteLanguage.LanguageId;
                                    if (DynamicPagesService.Insert(dp))
                                    {
                                        mappingList.Add(new DynamicPagesMapping(oldid, dp.DynamicPageId));
                                    }
                                }


                                using (TList<JXTPortal.Entities.DynamicPages> newdps = DynamicPagesService.GetBySiteId(SessionData.Site.SiteId))
                                {
                                    newdps.Filter = string.Format("LanguageId = {0}", siteLanguage.LanguageId);

                                    foreach (JXTPortal.Entities.DynamicPages newdp in newdps)
                                    {
                                        if (newdp.ParentDynamicPageId != 0)
                                        {
                                            foreach (DynamicPagesMapping dpm in mappingList)
                                            {
                                                if (dpm.OldDynamicPageID == newdp.ParentDynamicPageId)
                                                {
                                                    newdp.ParentDynamicPageId = dpm.NewDynamicPageID;

                                                    DynamicPagesService.Update(newdp);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    //INSERT INTO DynamicPages (SiteID,LanguageID,ParentDynamicPageID,PageName,      
                    //   PageTitle,PageContent,DynamicPageWebPartTemplateID,HyperLink,      
                    //   Valid,OpenInNewWindow,Sequence,FullScreen,OnTopNav,OnLeftNav,      
                    //   OnBottomNav,OnSiteMap,Searchable,MetaKeywords,MetaDescription,      
                    //   PageFriendlyName,LastModified,LastModifiedBy,SearchField,SourceID, CustomUrl)      
                    //SELECT @NewSiteID,LanguageID,ParentDynamicPageID,PageName,      
                    //   PageTitle,PageContent,wpt.DynamicPageWebPartTemplateID,HyperLink,      
                    //   Valid,OpenInNewWindow,Sequence,FullScreen,CASE WHEN PageName LIKE 'SystemPage%' THEN 0 ELSE OnTopNav END, CASE WHEN PageName LIKE 'SystemPage%' THEN 0 ELSE OnLeftNav END,      
                    //   OnBottomNav,CASE WHEN PageName LIKE 'SystemPage%' THEN 0 ELSE OnSiteMap END,CASE WHEN PageName LIKE 'SystemPage%' THEN 0 ELSE Searchable END,MetaKeywords,MetaDescription,      
                    //   PageFriendlyName,dp.LastModified,dp.LastModifiedBy,CASE WHEN PageName LIKE 'SystemPage%' THEN '' ELSE SearchField END,DynamicPageID, CustomUrl  
                    //FROM DynamicPages dp INNER JOIN DynamicPageWebPartTemplates wpt       
                    //ON dp.DynamicPageWebPartTemplateID = wpt.SourceID AND wpt.SiteID = @NewSiteID      
                    //WHERE dp.SiteID = @SiteID AND dp.DynamicPageID IN (SELECT id FROM ParseIntCSV(@SelectedDynamicPages))  

                    //UPDATE DynamicPages SET DynamicPages.ParentDynamicPageID = DP2.DynamicPageID      
                    //  FROM DynamicPages      
                    //  INNER JOIN DynamicPages DP2 ON DynamicPages.ParentDynamicPageID = DP2.SourceID      
                    //  WHERE DynamicPages.ParentDynamicPageID > 0      
                    //  AND DynamicPages.SiteID = @NewSiteID      
                    //  AND DP2.SiteID = @NewSiteID      

                    //    --Return the new object      
                    //    SELECT SiteName, SiteUrl, SiteDescription, LastModified, LastModifiedBy      
                    //    FROM Sites (NOLOCK)      
                    //    WHERE SiteID = @NewSiteID      
                }
            }
            else
            {
                SiteLanguagesService.Update(siteLanguage);
                hfSiteLanguageId.Value = "-1";
            }

            Response.Redirect("languages.aspx");
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("languages.aspx");
    }

    protected void lnkDeleteSiteLanguages_Click(object sender, EventArgs e)
    {
        String strMessage = String.Empty;

        LinkButton lb = (LinkButton)sender;
        // Check if Any Dynamic Page being used as a default page in global settings
        int defaultdynamicpageid = 0;
        int languageid = 0;

        TList<GlobalSettings> gss = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId);
        GlobalSettings gs = gss[0];
        defaultdynamicpageid = (gs.DefaultDynamicPageId.HasValue) ? gs.DefaultDynamicPageId.Value : 0;
        languageid = SiteLanguagesService.GetBySiteLanguageId(Convert.ToInt32(lb.CommandArgument)).LanguageId;

        using (TList<JXTPortal.Entities.DynamicPages> dps = DynamicPagesService.GetByLanguageId(Convert.ToInt32(languageid)))
        { 
            dps.Filter = string.Format("SiteID = {0}", SessionData.Site.SiteId);

            if (dps.Count > 0)
            {
                foreach (JXTPortal.Entities.DynamicPages dp in dps)
                {
                    if (defaultdynamicpageid == dp.DynamicPageId)
                    {
                        ltlMessage.Text = string.Format("Error: Dynamic Page ID: {0} {1} is being used as Homepage. Please change it from Global Setting before remove this language.", dp.DynamicPageId, dp.PageTitle);
                        return;

                    }
                }
            }
        }

        if (SiteLanguagesService.DeleteSiteLanguage(Convert.ToInt32(lb.CommandArgument), ref strMessage))
        {
            Response.Redirect("languages.aspx");
        }
        else
        {
            ltlMessage.Text = "Error: " + strMessage;
        }
    }

    protected void lnkEditSiteLanguages_Click(object sender, EventArgs e)
    {

        LinkButton lb = (LinkButton)sender;
        Load(Convert.ToInt32(lb.CommandArgument));

    }

    #endregion

    #region Grid Methods

    protected void gridViewSiteLanguages_OnRowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        LinkButton ctrl = (LinkButton)gridViewSiteLanguages.Rows[e.NewEditIndex].FindControl("lnkEditSiteLanguages");
        Load(Convert.ToInt32(ctrl.CommandArgument));
    }

    #endregion


    #region "Methods"

    private void Load()
    {
        ddlLanguages.Items.Clear();
        ddlLanguages.DataSource = LanguagesService.GetAll();
        ddlLanguages.DataTextField = "LanguageName";
        ddlLanguages.DataValueField = "LanguageID";
        ddlLanguages.DataBind();

        using (TList<JXTPortal.Entities.SiteLanguages> siteLanguages = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId))
        {
            if (siteLanguages.Count == 0)
            {
                MultiViewSiteLanguagesEdit.SetActiveView(ViewEditSiteLanguage);
            }
            else
            {
                MultiViewSiteLanguagesEdit.SetActiveView(ViewSiteLanguages);
                gridViewSiteLanguages.DataSource = siteLanguages;
                gridViewSiteLanguages.DataBind();
            }
        }
    }

    private void Load(int siteLanguageID)
    {
        using (JXTPortal.Entities.SiteLanguages siteLanguage = SiteLanguagesService.GetBySiteLanguageId(siteLanguageID))
        {
            MultiViewSiteLanguagesEdit.SetActiveView(ViewEditSiteLanguage);
            _siteLanguageId = siteLanguageID;
            hfSiteLanguageId.Value = siteLanguageID.ToString();
            txtSiteLanguageName.Text = siteLanguage.SiteLanguageName;
            ddlLanguages.SelectedValue = siteLanguage.LanguageId.ToString();

        }
    }

    #endregion

    protected void gridViewSiteLanguages_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }


}

internal class DynamicPagesMapping
{
    public int OldDynamicPageID { get; set; }
    public int NewDynamicPageID { get; set; }

    public DynamicPagesMapping(int _oldId, int _newId)
    {
        OldDynamicPageID = _oldId;
        NewDynamicPageID = _newId;
    }
}


