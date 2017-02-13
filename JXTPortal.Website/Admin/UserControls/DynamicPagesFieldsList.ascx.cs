using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Web;
using JXTPortal.Entities;

namespace JXTPortal.Website.Admin.UserControls
{
    public partial class DynamicPagesFieldsList : System.Web.UI.UserControl
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
        #endregion

        #region Constructors
        #endregion

        #region Page Event handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (FTPFolderLocation.StartsWith("s3://"))
            {
                txtPageContent.CustomConfig = "s3custom_config.js";
            }
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
                Entities.DynamicPages page = DynamicPagesService.GetBySiteIdPageNameLanguageId(SessionData.Site.SiteId, "SystemPage", CommonPage.LanguageID);
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
                            lblLastModified.Text = dynamicPage.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                            txtMetaTitle.Text = dynamicPage.MetaTitle;
                            AdminUsersService aus = new AdminUsersService();
                            using (Entities.AdminUsers adminuser = aus.GetByAdminUserId(dynamicPage.LastModifiedBy))
                            {
                                lblLastModifiedBy.Text = adminuser.UserName;
                            }

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

        public bool Save(out string errormessage)
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
                    using (JXTPortal.Entities.DynamicPages dynamicPage = new JXTPortal.Entities.DynamicPages())
                    {
                        // Naveen dynamicPage.PageName = DynamicPageEntity.PageName;
                        dynamicPage.Valid = DynamicPageEntity.Valid;
                        dynamicPage.PageName = DynamicPageEntity.PageName;
                        dynamicPage.CustomUrl = DynamicPageEntity.CustomUrl;
                        dynamicPage.SiteId = SessionData.Site.SiteId;
                        dynamicPage.ParentDynamicPageId = Convert.ToInt32(ddlParentDynamicPage.SelectedValue);
                        dynamicPage.DynamicPageId = DynamicPageID;
                        dynamicPage.PageTitle = txtPageTitle.Text;
                        dynamicPage.LanguageId = LanguageID;
                        dynamicPage.HyperLink = DynamicPageEntity.HyperLink;
                        dynamicPage.OpenInNewWindow = DynamicPageEntity.OpenInNewWindow;
                        dynamicPage.Sequence = DynamicPageEntity.Sequence;
                        dynamicPage.OnTopNav = DynamicPageEntity.OnTopNav;
                        dynamicPage.OnLeftNav = DynamicPageEntity.OnLeftNav;
                        dynamicPage.OnBottomNav = DynamicPageEntity.OnBottomNav;
                        dynamicPage.OnSiteMap = DynamicPageEntity.OnSiteMap;
                        dynamicPage.Secured = DynamicPageEntity.Secured;
                        dynamicPage.GenerateBreadcrumb = DynamicPageEntity.GenerateBreadcrumb;
                        dynamicPage.PageContent = txtPageContent.Text.Replace("../", "/");
                        dynamicPage.DynamicPageWebPartTemplateId = Convert.ToInt32(ddlDynamicPageWebPartTemplate.SelectedValue);
                        dynamicPage.Searchable = cbSearchable.Checked;
                        dynamicPage.MetaTitle = txtMetaTitle.Text;
                        dynamicPage.MetaKeywords = txtMetaKeywords.Text;
                        dynamicPage.MetaDescription = txtMetaDescription.Text;
                        dynamicPage.LastModified = DateTime.Now;
                        dynamicPage.LastModifiedBy = SessionData.AdminUser.AdminUserId;

                        string strFriendlyName = string.Empty;
                        int parentdynamicpageid = dynamicPage.ParentDynamicPageId;

                        if (parentdynamicpageid != 0 && !dynamicPage.PageName.StartsWith("SystemPage"))
                        {
                            Entities.DynamicPages dp = DynamicPagesService.GetByDynamicPageId(parentdynamicpageid);
                            strFriendlyName = dp.PageFriendlyName + "/" + strFriendlyName;
                        }
                        string[] strPageNames = DynamicPageEntity.PageFriendlyName.Split(new char[] { '/' });
                        string strPageName = strPageNames[strPageNames.Length - 1];
                        strFriendlyName += JXTPortal.Common.Utils.UrlFriendlyName(strPageName);
                        dynamicPage.PageFriendlyName = strFriendlyName;

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

                                DynamicPagesService.Update(dynamicPage);
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

                                DynamicPagesService.Insert(dynamicPage);
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


        // Check if the pagename is same before saving - Server validation.
        // Parent Dynamic Page - show only of that language
    }
}