using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Web;
using JXTPortal.Entities;
using JXTPortal.Common;
using JXTPortal.Website.ckeditor.Extensions;

namespace JXTPortal.Website.Admin.UserControls
{
    public partial class DynamicPageRevisionsFields : System.Web.UI.UserControl
    {
        #region Declare variables
        #endregion

        #region Properties

        public int LanguageID
        {
            get
            {
                int _languageID = -1;

                if (int.TryParse(hiddenFieldLanguageID.Value, out _languageID))
                {
                    return _languageID;
                }

                return _languageID;
            }
            set
            {
                hiddenFieldLanguageID.Value = value.ToString();
            }
        }

        public string PageCode { get; set; }

        public JXTPortal.Entities.DynamicPages DynamicPageEntity { get; set; }
        public JXTPortal.Entities.DynamicPageRevisions PageRevisionEntity { get; set; }

        public int DynamicPageID
        {

            get
            {
                int _dynamicPageID = 0;

                if (int.TryParse(txtDynamicPageID.Text, out _dynamicPageID))
                {
                    return _dynamicPageID;
                }

                return _dynamicPageID;
            }
            set
            {
                txtDynamicPageID.Text = value.ToString();
            }
        }

        public Guid RevisionCode
        {
            get
            {
                Guid strRevisionCode = Guid.Empty;

                if (!string.IsNullOrWhiteSpace(Request.Params["RevisionCode"]))
                {
                    Guid.TryParse(Request.Params["RevisionCode"], out strRevisionCode);
                }

                return strRevisionCode;
            }
        }

        private DynamicPagesService _dynamicPagesService;

        public DynamicPagesService DynamicPagesService
        {
            get
            {
                if (_dynamicPagesService == null)
                {
                    _dynamicPagesService = new DynamicPagesService();
                }
                return _dynamicPagesService;
            }
        }

        private DynamicPageRevisionsService _dynamicpagerevisionsService;

        public DynamicPageRevisionsService DynamicPageRevisionsService
        {
            get
            {
                if (_dynamicpagerevisionsService == null)
                {
                    _dynamicpagerevisionsService = new DynamicPageRevisionsService();
                }
                return _dynamicpagerevisionsService;
            }
        }

        private DynamicPageWebPartTemplatesService _DynamicPageWebPartTemplatesService;

        public DynamicPageWebPartTemplatesService DynamicPageWebPartTemplatesService
        {
            get
            {
                if (_DynamicPageWebPartTemplatesService == null)
                {
                    _DynamicPageWebPartTemplatesService = new DynamicPageWebPartTemplatesService();
                }
                return _DynamicPageWebPartTemplatesService;
            }
        }

        private SiteLanguagesService _siteLanguagesService;

        public SiteLanguagesService SiteLanguagesService
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

        private GlobalSettingsService _globalsettingsservice = null;
        public GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_globalsettingsservice == null)
                {
                    _globalsettingsservice = new GlobalSettingsService();
                }
                return _globalsettingsservice;
            }
        }

        private string FTPFolderLocation
        {
            get { return GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId)[0].FtpFolderLocation; }
        }

        public string StrPageName
        {
            get
            {
                string strPageName = "";

                if (!String.IsNullOrEmpty(CommonPage.PageName))
                {
                    string[] strPageNames = CommonPage.PageName.Split(new char[] { '/' });
                    strPageName = strPageNames[strPageNames.Length - 1];
                }

                return strPageName;
            }
        }

        #endregion

        #region Constructors
        #endregion

        #region Page Event handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            txtPageContent.SetConfigForFTPFolder(FTPFolderLocation);
            // To Enable CkFinder
            //txtPageContent.FileBrowserImageBrowseUrl = "/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images"; //&currentFolder=/files/images/
        }

        #endregion

        //#region Click Event handlers

        //protected void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    Save();
        //}

        //#endregion

        #region Validate Events

        protected void CusVal_DynamicPageWebPartTemplate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlDynamicPageWebPartTemplate.SelectedValue == "0" || string.IsNullOrEmpty(ddlDynamicPageWebPartTemplate.SelectedValue))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }

        }

        #endregion

        #region Methods

        public void LoadListAndDynamicPage()
        {
            if (!Page.IsPostBack)
            {
                // By default searchable is ticked.
                cbSearchable.Checked = true;

                PopulateList();
                LoadDynamicPage();
            }
        }

        private void PopulateList()
        {
            ddlDynamicPageWebPartTemplate.AppendDataBoundItems = true;
            ddlDynamicPageWebPartTemplate.Items.Add(new ListItem("-No Template-", "0"));
            ddlDynamicPageWebPartTemplate.DataSource = DynamicPageWebPartTemplatesService.GetBySiteId(SessionData.Site.SiteId);
            ddlDynamicPageWebPartTemplate.DataTextField = "DynamicPageWebPartName";
            ddlDynamicPageWebPartTemplate.DataValueField = "DynamicPageWebPartTemplateId";
            ddlDynamicPageWebPartTemplate.DataBind();

            TList<JXTPortal.Entities.DynamicPages> siteDynamicPages = DynamicPagesService.GetHierarchy(SessionData.Site.SiteId, LanguageID, 0, null, true, true);
            DataView viewDynamicPages = new DataView(siteDynamicPages.ToDataSet(true).Tables[0]);

            if (DynamicPageID > 0)
            {
                TList<JXTPortal.Entities.DynamicPages> familyDynamicPages = DynamicPagesService.GetHierarchy(SessionData.Site.SiteId, LanguageID, DynamicPageID, null, true, true);
                DataView viewFamilyDynamicPages = new DataView(familyDynamicPages.ToDataSet(true).Tables[0]);

                string strFilter = "";

                foreach (DataRowView drv in viewFamilyDynamicPages)
                {
                    strFilter += drv["DynamicPageID"].ToString() + ",";
                }

                if (!string.IsNullOrEmpty(strFilter))
                {
                    viewDynamicPages.RowFilter = string.Format("DynamicPageID NOT IN ({0})", strFilter.Trim(new char[] { ',' }));
                }
            }

            if (string.IsNullOrEmpty(viewDynamicPages.RowFilter))
            {
                viewDynamicPages.RowFilter = string.Format("Sequence <> {0}", JXTPortal.Website.CommonPage.CampaignSequenceNumber);
            }
            else
            {
                viewDynamicPages.RowFilter = string.Format(" AND Sequence <> {0}", JXTPortal.Website.CommonPage.CampaignSequenceNumber);
            }

            // DynamicPagesList[i].Sequence != JXTPortal.Website.CommonPage.CampaignSequenceNumber

            ddlParentDynamicPage.AppendDataBoundItems = true;
            if (StrPageName.StartsWith("SystemPage_", StringComparison.CurrentCultureIgnoreCase))
            {
                Entities.DynamicPages page = DynamicPagesService.GetBySiteIdPageNameLanguageId(SessionData.Site.SiteId, "SystemPage", LanguageID);
                if (page != null)
                {
                    ddlParentDynamicPage.Items.Add(new ListItem(page.PageName, page.DynamicPageId.ToString()));
                }
                else
                {
                    ddlParentDynamicPage.Items.Add(new ListItem("-Top Parent-", "0"));
                }

            }
            else
            {
                ddlParentDynamicPage.Items.Add(new ListItem("-Top Parent-", "0"));


                foreach (DataRowView dr in viewDynamicPages)
                {
                    int dynamicpageid = Convert.ToInt32(dr["DynamicPageID"]);
                    string pagename = dr["PageName"].ToString();
                    string pagefriendlyname = dr["PageFriendlyName"].ToString();
                    int parentdynamicpageid = Convert.ToInt32(dr["ParentDynamicPageID"]);
                    bool isLvl3Item = false;

                    if (parentdynamicpageid != 0)
                    {
                        int lvlcount = pagefriendlyname.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Length - 1;

                        for (int i = 0; i < lvlcount; i++)
                        {
                            if (i == 2) //starts from 0
                                isLvl3Item = true;

                            pagename = string.Format(" - {0}", pagename);
                        }
                    }

                    ListItem li = new ListItem(pagename, dynamicpageid.ToString());

                    if (isLvl3Item)
                        li.Attributes.Add("disabled", "disabled");

                    ddlParentDynamicPage.Items.Add(li);
                }
            }

            //ddlParentDynamicPage.DataSource = viewDynamicPages;
            //ddlParentDynamicPage.DataTextField = "PageName";
            //ddlParentDynamicPage.DataValueField = "DynamicPageID";
            //ddlParentDynamicPage.DataBind();
            /*
            ddlLanguages.DataSource = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId);
            ddlLanguages.DataTextField = "SiteLanguageName";
            ddlLanguages.DataValueField = "LanguageID";
            ddlLanguages.DataBind();
            */
        }

        private void LoadDynamicPage()
        {
            txtMetaTitle.Attributes["onkeyup"] = "CharaterCount('" + txtMetaTitle.ClientID + "', 'spTitleCount', 69);";
            txtMetaTitle.Attributes["onmouseup"] = "CharaterCount('" + txtMetaTitle.ClientID + "', 'spTitleCount', 69);";

            txtMetaKeywords.Attributes["onkeyup"] = "CharaterCount('" + txtMetaKeywords.ClientID + "', 'spKeywordsCount', 256);";
            txtMetaKeywords.Attributes["onmouseup"] = "CharaterCount('" + txtMetaKeywords.ClientID + "', 'spKeywordsCount', 256);";

            txtMetaDescription.Attributes["onkeyup"] = "CharaterCount('" + txtMetaDescription.ClientID + "', 'spDescriptionCount', 160);";
            txtMetaDescription.Attributes["onmouseup"] = "CharaterCount('" + txtMetaDescription.ClientID + "', 'spDescriptionCount', 160);";

            AjaxControlToolkit.ToolkitScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "CharaterCount", "$( document ).ready(function() { CharaterCount(\"" + txtMetaTitle.ClientID + "\", \"spTitleCount\", 69); CharaterCount(\"" + txtMetaKeywords.ClientID + "\", \"spKeywordsCount\", 256); CharaterCount(\"" + txtMetaDescription.ClientID + "\", \"spDescriptionCount\", 160); });", true);

            if (RevisionCode != Guid.Empty)
            {
                using (TList<JXTPortal.Entities.DynamicPageRevisions> dynamicPages = DynamicPageRevisionsService.CustomGetBySiteIDMappingID(SessionData.Site.SiteId, RevisionCode))
                {
                    if (dynamicPages.Count > 0)
                    {
                        Entities.DynamicPageRevisions dynamicPage = dynamicPages[0];
                        foreach (JXTPortal.Entities.DynamicPageRevisions dp in dynamicPages)
                        {
                            if (dp.LanguageId == LanguageID)
                            {
                                dynamicPage = dp;
                                break;
                            }
                        }

                        if (dynamicPage.SiteId == SessionData.Site.SiteId && dynamicPage.LanguageId == LanguageID)
                        {
                            //txtPageFriendlyName.Text = dynamicPage.PageFriendlyName;
                            //txtPageName.Text = dynamicPage.PageName;
                            //rbValid.SelectedValue = dynamicPage.Valid.ToString();

                            //load
                            PortalEnums.Admin.AdminRole currentRole = (PortalEnums.Admin.AdminRole) SessionData.AdminUser.AdminRoleId;
                            if( currentRole == PortalEnums.Admin.AdminRole.Administrator || currentRole == PortalEnums.Admin.AdminRole.Developer )
                                ddlParentDynamicPage.Enabled = true;
                            else
                                ddlParentDynamicPage.Enabled = false;

                            if (dynamicPage.PageName.StartsWith("SystemPage"))
                            {
                                cbSearchable.Checked = false;
                                cbSearchable.Enabled = false;
                            }

                            txtDynamicPageID.Text = dynamicPage.DynamicPageId.ToString();
                            hfRevisionID.Value = dynamicPage.DynamicPageRevisionId.ToString();
                            ddlParentDynamicPage.SelectedValue = dynamicPage.ParentDynamicPageId.ToString();
                            txtPageTitle.Text = dynamicPage.PageTitle;
                            hiddenFieldLanguageID.Value = dynamicPage.LanguageId.ToString();
                            txtPageContent.Text = dynamicPage.PageContent.Replace("../", "/");
                            ddlDynamicPageWebPartTemplate.SelectedValue = dynamicPage.DynamicPageWebPartTemplateId.ToString();
                            cbSearchable.Checked = dynamicPage.Searchable;
                            txtMetaKeywords.Text = dynamicPage.MetaKeywords;
                            txtMetaDescription.Text = dynamicPage.MetaDescription;
                            txtMetaTitle.Text = dynamicPage.MetaTitle;

                        }
                    }
                    else
                    {
                        //throw exception
                    }
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(CommonPage.PageName))
                {
                    using (TList<JXTPortal.Entities.DynamicPages> dynamicPages = DynamicPagesService.GetBySiteIdPageNameLanguageIdWithRoot(SessionData.Site.SiteId, StrPageName, LanguageID))
                    {
                        if (dynamicPages.Count > 0)
                        {
                            Entities.DynamicPages dynamicPage = dynamicPages[0];

                            if (dynamicPage.SiteId == SessionData.Site.SiteId && dynamicPage.LanguageId == LanguageID)
                            {
                                //txtPageFriendlyName.Text = dynamicPage.PageFriendlyName;
                                //txtPageName.Text = dynamicPage.PageName;
                                //rbValid.SelectedValue = dynamicPage.Valid.ToString();

                                //load
                                //PortalEnums.Admin.AdminRole currentRole = (PortalEnums.Admin.AdminRole)SessionData.AdminUser.AdminRoleId;
                                //if (currentRole == PortalEnums.Admin.AdminRole.Contributor || currentRole == PortalEnums.Admin.AdminRole.ExternalUser)
                                    //ddlParentDynamicPage.Enabled = false;

                                PortalEnums.Admin.AdminRole currentRole = (PortalEnums.Admin.AdminRole)SessionData.AdminUser.AdminRoleId;
                                if (currentRole == PortalEnums.Admin.AdminRole.Administrator || currentRole == PortalEnums.Admin.AdminRole.Developer)
                                    ddlParentDynamicPage.Enabled = true;
                                else
                                    ddlParentDynamicPage.Enabled = false;

                                if (dynamicPage.PageName.StartsWith("SystemPage"))
                                {
                                    cbSearchable.Checked = false;
                                    cbSearchable.Enabled = false;
                                }

                                txtDynamicPageID.Text = dynamicPage.DynamicPageId.ToString();
                                ddlParentDynamicPage.SelectedValue = dynamicPage.ParentDynamicPageId.ToString();
                                txtPageTitle.Text = dynamicPage.PageTitle;
                                hiddenFieldLanguageID.Value = dynamicPage.LanguageId.ToString();
                                txtPageContent.Text = dynamicPage.PageContent.Replace("../", "/");
                                ddlDynamicPageWebPartTemplate.SelectedValue = dynamicPage.DynamicPageWebPartTemplateId.ToString();
                                cbSearchable.Checked = dynamicPage.Searchable;
                                txtMetaKeywords.Text = dynamicPage.MetaKeywords;
                                txtMetaDescription.Text = dynamicPage.MetaDescription;
                               
                                txtMetaTitle.Text = dynamicPage.MetaTitle;

                            }
                        }
                        else
                        {
                            //throw exception
                        }
                    }
                }
                else
                {
                    // redirect or new dynamic page
                }
            }
        }

        public bool Validate()
        {
            phPageTitleError.Visible = false;
            phDynamicPageWebPartTemplateError.Visible = false;

            if (string.IsNullOrWhiteSpace(txtPageTitle.Text) || ddlDynamicPageWebPartTemplate.SelectedValue == "0")
            {
                phPageTitleError.Visible = string.IsNullOrWhiteSpace(txtPageTitle.Text);
                phDynamicPageWebPartTemplateError.Visible = (ddlDynamicPageWebPartTemplate.SelectedValue == "0");

                return false;
            }


            return true;
        }


        public bool SaveRevision(out string errormessage)
        {
            bool valid = false;
            errormessage = string.Empty;

            phPageTitleError.Visible = false;
            phDynamicPageWebPartTemplateError.Visible = false;

            if (string.IsNullOrWhiteSpace(txtPageTitle.Text) || ddlDynamicPageWebPartTemplate.SelectedValue == "0")
            {
                phPageTitleError.Visible = string.IsNullOrWhiteSpace(txtPageTitle.Text);
                phDynamicPageWebPartTemplateError.Visible = (ddlDynamicPageWebPartTemplate.SelectedValue == "0");

                return false;
            }

            if (Page.IsValid)
            {
                try
                {
                    int revisionID; 
                    bool hasHFRevisionID = int.TryParse(hfRevisionID.Value, out revisionID);

                    using (JXTPortal.Entities.DynamicPageRevisions dynamicPage =
                        hasHFRevisionID ? DynamicPageRevisionsService.GetByDynamicPageRevisionId(revisionID) : new JXTPortal.Entities.DynamicPageRevisions())
                    //using (JXTPortal.Entities.DynamicPageRevisions dynamicPage = new JXTPortal.Entities.DynamicPageRevisions())
                    {
                        // Naveen dynamicPage.PageName = DynamicPageEntity.PageName;
                        dynamicPage.Valid = PageRevisionEntity.Valid;
                        dynamicPage.PageName = PageRevisionEntity.PageName;
                        dynamicPage.CustomUrl = PageRevisionEntity.CustomUrl;
                        dynamicPage.SiteId = SessionData.Site.SiteId;
                        dynamicPage.ParentDynamicPageId = Convert.ToInt32(ddlParentDynamicPage.SelectedValue);
                        dynamicPage.DynamicPageId = (string.IsNullOrWhiteSpace(txtDynamicPageID.Text) ? 0 : Convert.ToInt32(txtDynamicPageID.Text));
                        dynamicPage.PageTitle = txtPageTitle.Text;
                        dynamicPage.LanguageId = LanguageID;
                        dynamicPage.HyperLink = PageRevisionEntity.HyperLink;
                        dynamicPage.OpenInNewWindow = PageRevisionEntity.OpenInNewWindow;
                        dynamicPage.Sequence = PageRevisionEntity.Sequence;
                        dynamicPage.OnTopNav = PageRevisionEntity.OnTopNav;
                        dynamicPage.OnLeftNav = PageRevisionEntity.OnLeftNav;
                        dynamicPage.OnBottomNav = PageRevisionEntity.OnBottomNav;
                        dynamicPage.OnSiteMap = PageRevisionEntity.OnSiteMap;
                        dynamicPage.Secured = PageRevisionEntity.Secured;
                        dynamicPage.GenerateBreadcrumb = PageRevisionEntity.GenerateBreadcrumb;
                        dynamicPage.PageContent = txtPageContent.Text.Replace("../", "/");
                        dynamicPage.DynamicPageWebPartTemplateId = Convert.ToInt32(ddlDynamicPageWebPartTemplate.SelectedValue);
                        dynamicPage.Searchable = cbSearchable.Checked;
                        dynamicPage.MetaTitle = txtMetaTitle.Text;
                        dynamicPage.MetaKeywords = txtMetaKeywords.Text;
                        dynamicPage.MetaDescription = txtMetaDescription.Text;
                        dynamicPage.LastModified = DateTime.Now;
                        dynamicPage.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                        dynamicPage.MappingId = PageRevisionEntity.MappingId;
                        dynamicPage.Status = PageRevisionEntity.Status;
                        dynamicPage.Visible = PageRevisionEntity.Visible;
                        dynamicPage.PublishOn = PageRevisionEntity.PublishOn;

                        //only change the comments if it is an admin & there is value in comments
                        if (
                            ((PortalEnums.Admin.AdminRole)SessionData.AdminUser.AdminRoleId == PortalEnums.Admin.AdminRole.Administrator
                            || (PortalEnums.Admin.AdminRole)SessionData.AdminUser.AdminRoleId == PortalEnums.Admin.AdminRole.ContentEditor)
                            && !string.IsNullOrEmpty(PageRevisionEntity.Comment))
                        {
                            dynamicPage.Comment = PageRevisionEntity.Comment;
                        }

                        string strFriendlyName = string.Empty;
                        int parentdynamicpageid = dynamicPage.ParentDynamicPageId;

                        if (parentdynamicpageid != 0 && !dynamicPage.PageName.StartsWith("SystemPage"))
                        {
                            Entities.DynamicPages dp = DynamicPagesService.GetByDynamicPageId(parentdynamicpageid);
                            strFriendlyName = dp.PageFriendlyName + "/" + strFriendlyName;
                        }
                        string[] strPageNames = PageRevisionEntity.PageFriendlyName.Split(new char[] { '/' });
                        string strPageName = strPageNames[strPageNames.Length - 1];
                        strFriendlyName += JXTPortal.Common.Utils.UrlFriendlyName(strPageName);
                        dynamicPage.PageFriendlyName = strFriendlyName;

                        // Update the searchable field
                        if (dynamicPage.Searchable)
                        {
                            //Todo - Remove Special characters - Decode the html and remove special characters
                            dynamicPage.SearchField = String.Format("{0} {1} {2} {3}",
                                                                Utils.CleanStringSpaces(Utils.StripHTML(Utils.CleanScriptStyleTags(Utils.SpecialCharsSearchField(dynamicPage.PageContent)))),
                                                                Utils.SpecialCharsSearchField(dynamicPage.PageTitle),
                                                                Utils.SpecialCharsSearchField(dynamicPage.PageName),
                                                                Utils.SpecialCharsSearchField(dynamicPage.MetaKeywords).Trim());
                        }

                        using (DataSet ds = DynamicPagesService.GetBySiteIdPageFriendlyName(SessionData.Site.SiteId, dynamicPage.PageFriendlyName))
                        {
                            if (DynamicPageID > 0)
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow dr in ds.Tables[0].Rows)
                                    {
                                        if (dr["PageName"].ToString() != dynamicPage.PageName)
                                        {
                                            errormessage = "Page Friendly Name already exists, Please try a different Page Friendly Name";
                                            return false;
                                        }
                                    }
                                }

                                DynamicPageRevisionsService.CustomSaveRevision(dynamicPage.DynamicPageId, dynamicPage.SiteId, dynamicPage.LanguageId, dynamicPage.ParentDynamicPageId
                                    , dynamicPage.PageName, dynamicPage.PageTitle, dynamicPage.PageContent, dynamicPage.DynamicPageWebPartTemplateId, dynamicPage.HyperLink
                                    , dynamicPage.Valid, dynamicPage.OpenInNewWindow, dynamicPage.Sequence
                                    , dynamicPage.FullScreen, dynamicPage.OnTopNav, dynamicPage.OnLeftNav, dynamicPage.OnBottomNav, dynamicPage.OnSiteMap
                                    , dynamicPage.Searchable, dynamicPage.MetaKeywords, dynamicPage.MetaDescription, dynamicPage.PageFriendlyName
                                    , dynamicPage.LastModified, dynamicPage.LastModifiedBy, dynamicPage.SearchField, dynamicPage.SourceId
                                    , dynamicPage.Secured, dynamicPage.CustomUrl, dynamicPage.MetaTitle, dynamicPage.GenerateBreadcrumb
                                    , dynamicPage.Status, dynamicPage.Visible, dynamicPage.PublishOn, dynamicPage.MappingId, dynamicPage.Comment, "");
                                DynamicPagesService.UpdateWebPartTemplate(dynamicPage.SiteId, dynamicPage.LanguageId, dynamicPage.DynamicPageId, dynamicPage.DynamicPageWebPartTemplateId, cbUpdateChildPages.Checked);
                                valid = true;
                            }
                            else
                            {
                                // Check if Dynamic Page has existing Friendly Name

                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow dr in ds.Tables[0].Rows)
                                    {
                                        if (Convert.ToInt32(dr["LanguageID"]) == LanguageID)
                                        {
                                            errormessage = "Page Friendly Name already exists, Please try a different Page Friendly Name";
                                            return false;
                                        }
                                    }
                                }

                                if (dynamicPage.PageName.StartsWith("SystemPage"))
                                {
                                    dynamicPage.Searchable = false;
                                    dynamicPage.OnTopNav = false;
                                    dynamicPage.OnLeftNav = false;
                                    dynamicPage.OnSiteMap = false;
                                }


                                DynamicPageRevisionsService.CustomSaveRevision(dynamicPage.DynamicPageId, dynamicPage.SiteId, dynamicPage.LanguageId, dynamicPage.ParentDynamicPageId
                                    , dynamicPage.PageName, dynamicPage.PageTitle, dynamicPage.PageContent, dynamicPage.DynamicPageWebPartTemplateId, dynamicPage.HyperLink
                                    , dynamicPage.Valid, dynamicPage.OpenInNewWindow, dynamicPage.Sequence
                                    , dynamicPage.FullScreen, dynamicPage.OnTopNav, dynamicPage.OnLeftNav, dynamicPage.OnBottomNav, dynamicPage.OnSiteMap
                                    , dynamicPage.Searchable, dynamicPage.MetaKeywords, dynamicPage.MetaDescription, dynamicPage.PageFriendlyName
                                    , dynamicPage.LastModified, dynamicPage.LastModifiedBy, dynamicPage.SearchField, dynamicPage.SourceId
                                    , dynamicPage.Secured, dynamicPage.CustomUrl, dynamicPage.MetaTitle, dynamicPage.GenerateBreadcrumb
                                    , dynamicPage.Status, dynamicPage.Visible, dynamicPage.PublishOn, dynamicPage.MappingId, dynamicPage.Comment, "");
                                txtDynamicPageID.Text = dynamicPage.DynamicPageId.ToString();
                                valid = true;
                            }
                        }

                        cbUpdateChildPages.Checked = false;

                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return valid;
        }


        #endregion
    }
}