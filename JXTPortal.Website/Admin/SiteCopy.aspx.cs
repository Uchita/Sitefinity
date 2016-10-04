using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal;
using JXTPortal.Entities;

namespace JXTPortal.Website.Admin
{
    public partial class SiteCopy : System.Web.UI.Page
    {

        #region "Properties"

        string parentID = string.Empty;

        private SiteLanguagesService _siteLanguageService;

        private SiteLanguagesService SiteLanguageService
        {
            get
            {
                if (_siteLanguageService == null)
                    _siteLanguageService = new SiteLanguagesService();
                return _siteLanguageService;
            }
        }

        private SitesService _sitesService;

        private SitesService SitesService
        {
            get
            {
                if (_sitesService == null)
                    _sitesService = new SitesService();

                return _sitesService;
            }
        }

        private SiteCopyClass SiteCopyObject
        {
            get
            {
                if (ViewState["SiteCopy"] == null)
                    ViewState["SiteCopy"] = new SiteCopyClass();
                return (SiteCopyClass)ViewState["SiteCopy"];
            }
            set
            {
                ViewState["SiteCopy"] = value;
            }
        }

        private FilesService _filesService;
        private FilesService FilesService
        {
            get
            {
                if (_filesService == null)
                {
                    _filesService = new FilesService();
                }
                return _filesService;
            }
        }

        private DynamicPageFilesService _dynamicPageFilesService;
        private DynamicPageFilesService DynamicPageFilesService
        {
            get
            {
                if (_dynamicPageFilesService == null)
                {
                    _dynamicPageFilesService = new DynamicPageFilesService();
                }
                return _dynamicPageFilesService;
            }
        }

        private DynamicPagesService _dynamicPagesService;
        private DynamicPagesService DynamicPagesService
        {
            get
            {
                if (_dynamicPagesService == null) _dynamicPagesService = new DynamicPagesService();
                return _dynamicPagesService;
            }
        }

        private JobTemplatesService _jobTemplatesService;
        private JobTemplatesService JobTemplatesService
        {
            get
            {
                if (_jobTemplatesService == null) _jobTemplatesService = new JobTemplatesService();
                return _jobTemplatesService;
            }
        }

        private AdminUsersService _adminUsersService;
        private AdminUsersService AdminUsersService
        {
            get
            {
                if (_adminUsersService == null) _adminUsersService = new AdminUsersService();
                return _adminUsersService;
            }
        }

        private MembersService _membersService;
        private MembersService MembersService
        {
            get
            {
                if (_membersService == null) _membersService = new MembersService();
                return _membersService;
            }
        }

        private AdvertisersService _advertisersService;
        private AdvertisersService AdvertisersService
        {
            get
            {
                if (_advertisersService == null) _advertisersService = new AdvertisersService();
                return _advertisersService;
            }
        }

        private AdvertiserUsersService _advertiserusersService;
        private AdvertiserUsersService AdvertiserUsersService
        {
            get
            {
                if (_advertiserusersService == null) _advertiserusersService = new AdvertiserUsersService();
                return _advertiserusersService;
            }
        }

        private SiteCountriesService _sitecountriesService;
        private SiteCountriesService SiteCountriesService
        {
            get
            {
                if (_sitecountriesService == null) _sitecountriesService = new SiteCountriesService();
                return _sitecountriesService;
            }
        }

        #endregion

        #region Page Events

        protected void Page_Load(object sender, EventArgs e)
        {
            Load();
        }

        #endregion

        #region Load Methods

        private void Load()
        {
            SetHandlers();

            if (!Page.IsPostBack)
            {
                ddlSites.DataSource = SitesService.GetAll().OrderBy(s => s.SiteName);
                ddlSites.DataTextField = "SiteName";
                ddlSites.DataValueField = "SiteId";
                ddlSites.DataBind();
                ddlSites.SelectedValue = "1";
            }
        }

        #endregion


        private void SetHandlers()
        {
            btnPreviousSite.Click += new EventHandler(btnPreviousSite_Click);
            btnNextDynamicPages.Click += new EventHandler(btnNextDynamicPages_Click);
            btnCopy.OnClientClick = string.Format("$(\"{0}\").css(\"visibility\", \"hidden\"); (\"{1}\").css(\"visibility\", \"hidden\")", btnCopy.ClientID, btnPreviousFileManagement.ClientID);

            CusVal_URL.ServerValidate += new ServerValidateEventHandler(CusVal_URL_ServerValidate);
            CusVal_Name.ServerValidate += new ServerValidateEventHandler(CusVal_Name_ServerValidate);
            CusValLanguage.ServerValidate += new ServerValidateEventHandler(CusValLanguage_ServerValidate);
        }

        void CusVal_Name_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int count = 0;
            using (TList<Entities.Sites> sites = SitesService.GetPaged("LOWER(SiteName) = '" + txtSiteName.Text.ToLower().Trim().Replace("'", "''") + "'", "", 0, 1, out count))
            {
                if (count > 0)
                {
                    CusVal_Name.ErrorMessage = "Site Name exists";
                    args.IsValid = false;
                }
            }
        }

        void CusVal_URL_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int count = 0;
            using (TList<Entities.Sites> sites = SitesService.GetPaged("LOWER(SiteURL) = '" + txtSiteUrl.Text.ToLower().Trim().Replace("'", "''") + "'", "", 0, 1, out count))
            {
                if (count > 0)
                {
                    CusVal_URL.ErrorMessage = "Site URL exists";
                    args.IsValid = false;
                }
            }
        }

        void CusValLanguage_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int count = 0;

            for (int i = 0; i < chkLanguages.Items.Count; i++)
            {
                if (chkLanguages.Items[i].Selected)
                {
                    count++;
                }
            }

            args.IsValid = (count > 0);
        }

        void btnPreviousSite_Click(object sender, EventArgs e)
        {
            tabPanelLanguages.Enabled = false;
            tabPanelOptions.Enabled = true;
            tabContainerSiteCopy.ActiveTab = tabPanelOptions;
        }

        void btnNextDynamicPages_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SiteCopyObject.SelectedLanguages = new List<KeyValueClass>();

                for (int i = 0; i < chkLanguages.Items.Count; i++)
                {
                    if (chkLanguages.Items[i].Selected)
                    {
                        KeyValueClass kvc = new KeyValueClass();
                        kvc.Key = Convert.ToInt32(chkLanguages.Items[i].Value);
                        kvc.Value = chkLanguages.Items[i].Text;

                        SiteCopyObject.SelectedLanguages.Add(kvc);
                    }
                }

                tabPanelSites.Enabled = false;
                tabPanelOptions.Enabled = false;
                tabPanelDataImport.Enabled = false;
                tabPanelLanguages.Enabled = false;
                tabPanelDynamicPages.Enabled = true;
                tabContainerSiteCopy.ActiveTab = tabPanelDynamicPages;

                // Bind Dynamic Pages
                BindDynamicPages();
            }
        }


        #region Sites



        protected void btnNextLanguage_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                tabPanelDataImport.Enabled = false;
                tabPanelSites.Enabled = false;
                tabPanelOptions.Enabled = false;
                tabContainerSiteCopy.ActiveTab = tabPanelLanguages;
                tabPanelLanguages.Enabled = true;
            }
        }

        protected void chkUseCustomProfessionRoles_CheckedChanged(object sender, EventArgs e)
        {
            chkProfessionRoles.Checked = !(chkUseCustomProfessionRoles.Checked);
            chkProfessionRoles.Enabled = !(chkUseCustomProfessionRoles.Checked);
        }

        protected void btnNextOptions_Click(object sender, EventArgs e)
        {
            SiteCopyObject.SiteId = Convert.ToInt32(ddlSites.SelectedValue);
            tabPanelOptions.Enabled = true;
            tabContainerSiteCopy.ActiveTab = tabPanelOptions;
            tabPanelSites.Enabled = false;
            tabPanelDataImport.Enabled = false;
            LoadJobTemplate();
        }

        private void LoadJobTemplate()
        {
            TList<Entities.JobTemplates> jobtemplates = JobTemplatesService.GetBySiteId(SiteCopyObject.SiteId);
            rptJobTemplate.DataSource = jobtemplates;
            rptJobTemplate.DataBind();
        }

        protected void cvImportAdvertiser_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (cbImportAdvertiser.Checked)
            {
                if (string.IsNullOrWhiteSpace(tbAdvertiserFirstName.Text) ||
                string.IsNullOrWhiteSpace(tbAdvertiserLastName.Text) ||
                string.IsNullOrWhiteSpace(tbAdvertiserEmail.Text) ||
                string.IsNullOrWhiteSpace(tbAdvertiserCompanyName.Text) ||
                string.IsNullOrWhiteSpace(tbAdvertiserUsername.Text) ||
                string.IsNullOrWhiteSpace(tbAdvertiserPassword.Text))
                {
                    args.IsValid = false;
                }
            }
        }

        protected void cvImportMember_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (cbImportMember.Checked)
            {
                if (cbImportAdvertiser.Checked)
                {
                    if (string.IsNullOrWhiteSpace(tbMemberFirstName.Text) ||
                    string.IsNullOrWhiteSpace(tbMemberLastName.Text) ||
                    string.IsNullOrWhiteSpace(tbMemberEmail.Text) ||
                    string.IsNullOrWhiteSpace(tbMemberUsername.Text) ||
                    string.IsNullOrWhiteSpace(tbMemberPassword.Text))
                    {
                        args.IsValid = false;
                    }
                }
            }
        }

        protected void cvImportAdminUser_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (cbImportAdminUser.Checked)
            {
                if (string.IsNullOrWhiteSpace(tbAdminFirstName.Text) ||
                    string.IsNullOrWhiteSpace(tbAdminLastName.Text) ||
                    string.IsNullOrWhiteSpace(tbAdminEmail.Text) ||
                    string.IsNullOrWhiteSpace(tbAdminUsername.Text) ||
                    string.IsNullOrWhiteSpace(tbAdminPassword.Text))
                {
                    args.IsValid = false;
                }
            }
        }

        protected void rptJobTemplate_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CheckBox chkJobTemplate = e.Item.FindControl("chkJobTemplate") as CheckBox;
                HiddenField hfJobTemplateID = e.Item.FindControl("hfJobTemplateID") as HiddenField;
                Literal ltJobTemplate = e.Item.FindControl("ltJobTemplate") as Literal;

                Entities.JobTemplates jobtemplate = e.Item.DataItem as Entities.JobTemplates;
                hfJobTemplateID.Value = jobtemplate.JobTemplateId.ToString();
                ltJobTemplate.Text = jobtemplate.JobTemplateDescription;

                chkJobTemplate.Checked = true;
            }
        }

        #endregion


        #region Dynamic Pages

        protected void BindDynamicPages()
        {
            rptLanguages.DataSource = SiteCopyObject.SelectedLanguages;
            rptLanguages.DataBind();
        }

        protected void rptLanguages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal litLanguage = e.Item.FindControl("litLanguage") as Literal;
                Repeater rptDynamicPages = e.Item.FindControl("rptDynamicPages") as Repeater;
                TreeView tvDynamicPages = e.Item.FindControl("tvDynamicPages") as TreeView;
                litLanguage.Text = ((KeyValueClass)e.Item.DataItem).Value;

                using (TList<JXTPortal.Entities.DynamicPages> DynamicPagesList =
                        DynamicPagesService.GetHierarchy(SiteCopyObject.SiteId, ((KeyValueClass)e.Item.DataItem).Key, 0, null, false, true))
                {
                    DynamicPagesList.Sort("Sequence");

                    foreach (Entities.DynamicPages dynamicpage in DynamicPagesList)
                    {
                        if (dynamicpage.ParentDynamicPageId == 0)
                        {
                            TreeNode tn = new TreeNode();
                            tn.Value = dynamicpage.DynamicPageId.ToString();
                            tn.Text = dynamicpage.PageTitle;
                            tn.SelectAction = TreeNodeSelectAction.None;
                            tn.Checked = true;
                            if (dynamicpage.PageName.StartsWith("SystemPage"))
                            {
                                tn.ShowCheckBox = false;
                                tn.Text = "<input type='checkbox' checked='true' disabled>" + tn.Text + "</input>";
                            }

                            GetSecondLevelDynamicPages(DynamicPagesList, tn);

                            tvDynamicPages.Nodes.Add(tn);
                        }
                    }

                    tvDynamicPages.ExpandAll();

                    //rptDynamicPages.DataSource = DynamicPagesList;
                    //rptDynamicPages.DataBind();                    
                }
            }
        }

        private void GetSecondLevelDynamicPages(TList<JXTPortal.Entities.DynamicPages> DynamicPagesList, TreeNode treenode)
        {
            foreach (Entities.DynamicPages dynamicpage in DynamicPagesList)
            {
                if (dynamicpage.ParentDynamicPageId == Convert.ToInt32(treenode.Value))
                {
                    TreeNode tn = new TreeNode();
                    tn.Value = dynamicpage.DynamicPageId.ToString();
                    tn.Text = dynamicpage.PageName;
                    tn.SelectAction = TreeNodeSelectAction.None;
                    tn.Checked = true;

                    if (dynamicpage.PageName.StartsWith("SystemPage"))
                    {
                        tn.Text = "<input type='checkbox' checked='true' disabled>" + tn.Text + "</input>";
                        tn.ShowCheckBox = false;
                    }

                    GetSecondLevelDynamicPages(DynamicPagesList, tn);

                    treenode.ChildNodes.Add(tn);
                }
            }
        }

        protected void rptDynamicPages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Entities.DynamicPages dynamicPage = (Entities.DynamicPages)e.Item.DataItem;

                CheckBox chkDynamicPage = (CheckBox)e.Item.FindControl("chkDynamicPage");
                Literal ltlDynamicPage = (Literal)e.Item.FindControl("ltlDynamicPage");
                Literal ltlSpacing = (Literal)e.Item.FindControl("ltlSpacing");

                chkDynamicPage.Text = dynamicPage.DynamicPageId.ToString();
                ltlDynamicPage.Text = dynamicPage.PageName;

                // All System Pages should be checked.
                if (dynamicPage.PageName.Contains("SystemPage"))
                {
                    chkDynamicPage.Enabled = false;
                    chkDynamicPage.Checked = true;
                }

                if (dynamicPage.DynamicPageWebPartTemplateId.HasValue)
                {
                    switch (dynamicPage.DynamicPageWebPartTemplateId.Value)
                    {
                        default:
                        case 0:
                            {
                                parentID = dynamicPage.DynamicPageId.ToString();
                                ltlSpacing.Text = string.Empty;
                                chkDynamicPage.InputAttributes.Add("class", "ckparent");
                                chkDynamicPage.InputAttributes.Add("parentid", dynamicPage.DynamicPageId.ToString());
                            }
                            break;
                        case 1:
                            {
                                ltlSpacing.Text = "&nbsp;&nbsp;&nbsp;&nbsp; ";
                                chkDynamicPage.InputAttributes.Add("class", "ckchild1");
                                chkDynamicPage.InputAttributes.Add("parentid", parentID);

                            }
                            break;
                        case 2:
                            {
                                ltlSpacing.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ";
                                chkDynamicPage.InputAttributes.Add("class", "ckchild2");
                                chkDynamicPage.InputAttributes.Add("parentid", parentID);
                            }
                            break;
                        case 3:
                            {
                                ltlSpacing.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ";
                                chkDynamicPage.InputAttributes.Add("class", "ckchild3");
                                chkDynamicPage.InputAttributes.Add("parentid", parentID);
                            }
                            break;
                    }

                }
            }
        }

        #endregion

        protected void btnPreviousLanguages_Click(object sender, EventArgs e)
        {
            tabPanelDynamicPages.Enabled = false;
            tabPanelSites.Enabled = false;
            tabPanelOptions.Enabled = false;
            tabPanelDataImport.Enabled = false;
            tabPanelLanguages.Enabled = true;
            tabContainerSiteCopy.ActiveTab = tabPanelLanguages;
        }

        protected void btnNextDataImport_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SiteCopyObject.SiteName = txtSiteName.Text.Trim();
                SiteCopyObject.SiteUrl = txtSiteUrl.Text.Trim();
                SiteCopyObject.SiteDescription = txtDescription.Text;
                SiteCopyObject.CopyGlobalSettings = chkGlobalSettings.Checked;
                SiteCopyObject.CopySiteLocation = chkSiteLocation.Checked;
                SiteCopyObject.UseCustomProfessionRoles = chkUseCustomProfessionRoles.Checked;
                SiteCopyObject.CopyProfessionRoles = chkProfessionRoles.Checked;
                SiteCopyObject.CopySalaryTypes = chkSalaryTypes.Checked;
                SiteCopyObject.CopyWorkTypes = chkWorkTypes.Checked;
                SiteCopyObject.CopyEducation = chkEducation.Checked;
                SiteCopyObject.CopyAvailableStatus = chkAvailableStatus.Checked;
                SiteCopyObject.CopyWidgets = chkWidgets.Checked;
                SiteCopyObject.CopyEmailTemplates = chkEmailTemplates.Checked;
                SiteCopyObject.CopyWebParts = chkWebParts.Checked;

                tabPanelSites.Enabled = false;
                tabPanelOptions.Enabled = false;
                tabContainerSiteCopy.ActiveTab = tabPanelDataImport;
                tabPanelDataImport.Enabled = true;


                chkLanguages.DataSource = SiteLanguageService.GetBySiteId(SiteCopyObject.SiteId);
                chkLanguages.DataTextField = "SiteLanguageName";
                chkLanguages.DataValueField = "LanguageId";
                chkLanguages.DataBind();

                foreach (ListItem item in chkLanguages.Items)
                {
                    if (item.Value == Convert.ToInt32(PortalConstants.DEFAULT_LANGUAGE_ID).ToString())
                    {
                        item.Selected = true;
                        item.Enabled = false;
                    }
                }
            }
        }

        protected void btnPreviousDataImport_Click(object sender, EventArgs e)
        {
            tabPanelLanguages.Enabled = false;
            tabPanelSites.Enabled = false;
            tabPanelOptions.Enabled = false;
            tabPanelDataImport.Enabled = true;
            tabContainerSiteCopy.ActiveTab = tabPanelDataImport;
        }

        protected void btnPreviousOptions_Click(object sender, EventArgs e)
        {
            tabPanelDataImport.Enabled = false;
            tabPanelSites.Enabled = false;
            tabPanelOptions.Enabled = true;
            tabContainerSiteCopy.ActiveTab = tabPanelOptions;
        }

        #region File Management

        protected void btnPreviousFileManagement_Click(object sender, EventArgs e)
        {
            tabPanelDynamicPages.Enabled = true;
            tabPanelFileManagement.Enabled = false;
            tabPanelSites.Enabled = false;
            tabPanelOptions.Enabled = false;
            tabPanelDataImport.Enabled = false;
            tabPanelLanguages.Enabled = false;
            tabContainerSiteCopy.ActiveTab = tabPanelDynamicPages;
        }

        protected void btnNextFileManagement_Click(object sender, EventArgs e)
        {
            SiteCopyObject.SelectedDynamicPages = new List<int>();
            SiteCopyObject.SelectedDynamicPagesNames = new List<string>();

            foreach (RepeaterItem langItem in rptLanguages.Items)
            {
                TreeView tvDynamicPages = langItem.FindControl("tvDynamicPages") as TreeView;
                foreach (TreeNode tn in tvDynamicPages.Nodes)
                {
                    if (tn.Checked || tn.ShowCheckBox == false)
                    {
                        SiteCopyObject.SelectedDynamicPages.Add(Convert.ToInt32(tn.Value));
                        SiteCopyObject.SelectedDynamicPagesNames.Add(tn.Text.Replace("<input type='checkbox' checked='true' disabled>", "").Replace("</input>", ""));
                    }

                    outputNodes(tn);
                }
            }

            tabPanelSites.Enabled = false;
            tabPanelOptions.Enabled = false;
            tabPanelDataImport.Enabled = false;
            tabPanelLanguages.Enabled = false;
            tabPanelDynamicPages.Enabled = false;
            tabPanelFileManagement.Enabled = true;
            tabContainerSiteCopy.ActiveTab = tabPanelFileManagement;
            LoadFileManagement();
        }

        private void outputNodes(TreeNode node)
        {
            foreach (TreeNode n in node.ChildNodes)
            {
                if (n.Checked || n.ShowCheckBox == false)
                {
                    SiteCopyObject.SelectedDynamicPages.Add(Convert.ToInt32(n.Value));
                    SiteCopyObject.SelectedDynamicPagesNames.Add(n.Text.Replace("<input type='checkbox' checked='true' disabled>", "").Replace("</input>", ""));
                }

                outputNodes(n);
            }
        }

        protected void LoadFileManagement()
        {
            using (TList<JXTPortal.Entities.Files> objFiles = FilesService.GetBySiteId(SiteCopyObject.SiteId))
            {
                objFiles.Sort("FolderId ASC");

                rptFileManagement.DataSource = objFiles;
                rptFileManagement.DataBind();
            }

            SiteCopyObject.SelectedFiles = new List<int>();
            TList<Entities.DynamicPageFiles> dpf = DynamicPageFilesService.GetBySiteId(SiteCopyObject.SiteId);

            //if (SiteCopyObject.SelectedDynamicPages.Count > 0)
            //{
            //    System.Text.StringBuilder filter = new System.Text.StringBuilder();
            //    foreach (string s in SiteCopyObject.SelectedDynamicPagesNames)
            //    {
            //        filter.Append("PageName = '" + s + "' OR");
            //    }

            //    dpf.Filter = filter.ToString().TrimEnd(new char[] {' ', 'O', 'R'});
            //}

            foreach (Entities.DynamicPageFiles dpfile in dpf)
            {
                foreach (RepeaterItem ri in rptFileManagement.Items)
                {
                    CheckBox chkFile = (CheckBox)ri.FindControl("chkFile");
                    HiddenField hfFile = (HiddenField)ri.FindControl("hfFile");

                    if (hfFile.Value == dpfile.FileId.ToString())
                    {
                        chkFile.Checked = true;
                        chkFile.Enabled = false;
                    }
                }
            }
        }

        protected string GetFolder(int folderID)
        {
            JXTPortal.FoldersService folderService = new JXTPortal.FoldersService();
            string foldername = string.Empty;

            using (JXTPortal.Entities.Folders folder = folderService.GetByFolderId(folderID))
            {
                if (folder != null && folder.FolderId > 0)
                    foldername = folder.FolderName;
            }

            return foldername;
        }

        int _folderID = 0;
        string _folderName = string.Empty;

        protected void rptFileManagement_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Entities.Files file = (Entities.Files)e.Item.DataItem;

                CheckBox chkFile = (CheckBox)e.Item.FindControl("chkFile");
                Literal ltlFile = (Literal)e.Item.FindControl("ltlFile");
                Literal ltlHeading = (Literal)e.Item.FindControl("ltlHeading");
                HiddenField hfFile = (HiddenField)e.Item.FindControl("hfFile");

                hfFile.Value = file.FileId.ToString();
                ltlFile.Text = file.FileName;
                if (!_folderID.Equals(file.FolderId))
                {
                    ltlHeading.Text = String.Format("<li class='form-line'><h3>{0}</h3></li></ul><ul class='form-section'>", GetFolder(file.FolderId));
                    _folderID = file.FolderId;
                }
            }
        }

        protected void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                btnCopy.Visible = false;
                btnPreviousFileManagement.Visible = false;
                SiteCopyObject.SelectedFiles = new List<int>();

                foreach (RepeaterItem ri in rptFileManagement.Items)
                {
                    CheckBox chkFile = (CheckBox)ri.FindControl("chkFile");
                    HiddenField hfFile = (HiddenField)ri.FindControl("hfFile");

                    if (chkFile.Checked)
                    {
                        SiteCopyObject.SelectedFiles.Add(Convert.ToInt32(hfFile.Value));
                    }
                }

                string strLanguageList = "";
                string strDynamicPageList = "";
                string strFileList = "";

                foreach (KeyValueClass kvc in SiteCopyObject.SelectedLanguages)
                {
                    strLanguageList += kvc.Key + ",";
                }
                strLanguageList.TrimEnd(new char[] { ',' });

                foreach (int id in SiteCopyObject.SelectedDynamicPages)
                {
                    strDynamicPageList += id.ToString() + ",";
                }
                strDynamicPageList.TrimEnd(new char[] { ',' });


                foreach (int id in SiteCopyObject.SelectedFiles)
                {
                    strFileList += id.ToString() + ",";
                }
                strFileList.TrimEnd(new char[] { ',' });



                System.Data.DataSet ds = SitesService.Copy(SiteCopyObject.SiteId, SiteCopyObject.SiteName, SiteCopyObject.SiteUrl, SiteCopyObject.SiteDescription, txtFtpFolderLocation.Text.Trim(), SiteCopyObject.CopyGlobalSettings,
                                    false, SiteCopyObject.CopySiteLocation, SiteCopyObject.CopyProfessionRoles, SiteCopyObject.UseCustomProfessionRoles,
                                    SiteCopyObject.CopySalaryTypes,  // Custom Profession / Roles
                                    SiteCopyObject.CopyWorkTypes, SiteCopyObject.CopyEducation, SiteCopyObject.CopyAvailableStatus, SiteCopyObject.CopyWebParts, SiteCopyObject.CopyWidgets,
                                    SiteCopyObject.CopyEmailTemplates, strLanguageList, strDynamicPageList, strFileList, SessionData.AdminUser.AdminUserId);

                int newsiteid = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                if (cbImportAdminUser.Checked)
                {
                    using (Entities.AdminUsers adminuser = new Entities.AdminUsers())
                    {
                        adminuser.AdminRoleId = (int)PortalEnums.Admin.AdminRole.ContentEditor;
                        adminuser.SiteId = newsiteid;
                        adminuser.UserName = tbAdminUsername.Text.Trim();
                        adminuser.UserPassword = tbAdminPassword.Text;
                        adminuser.FirstName = tbAdminFirstName.Text.Trim();
                        adminuser.Surname = tbAdminLastName.Text.Trim();
                        adminuser.Email = tbAdminEmail.Text.Trim();
                        adminuser.LoginAttempts = 0;
                        adminuser.LastAttemptDate = (DateTime?)null;
                        adminuser.Status = 0;

                        AdminUsersService.Insert(adminuser);
                    }
                }

                if (cbImportMember.Checked)
                {
                    using (Entities.Members member = new Entities.Members())
                    {
                        member.SiteId = newsiteid;
                        member.FirstName = tbMemberFirstName.Text;
                        member.Surname = tbMemberLastName.Text;
                        member.EmailAddress = tbMemberEmail.Text.Trim();
                        member.EmailFormat = (int)PortalEnums.Email.EmailFormat.HTML;
                        member.Username = tbMemberUsername.Text.Trim();

                        using (TList<Entities.SiteCountries> sitecountries = SiteCountriesService.GetBySiteId(newsiteid))
                        {
                            if (sitecountries.Count > 0)
                            {
                                member.CountryId = sitecountries[0].CountryId;
                            }
                        }

                        using (TList<Entities.SiteLanguages> sitelanguages = SiteLanguageService.GetBySiteId(newsiteid))
                        {
                            if (sitelanguages.Count > 0)
                            {
                                member.DefaultLanguageId = sitelanguages[0].LanguageId;
                            }
                        }

                        member.Validated = true;
                        member.Password = CommonService.EncryptMD5(tbMemberPassword.Text);

                        member.SearchField = String.Format("{0} {1}",
                                                   member.FirstName,
                                                   member.Surname);
                        member.Valid = true;
                        member.RequiredPasswordChange = false;

                        MembersService.Insert(member);
                    }
                }

                if (cbImportAdvertiser.Checked)
                {
                    using (Entities.Advertisers advertisers = new Entities.Advertisers())
                    {
                        advertisers.AdvertiserAccountTypeId = (int)PortalEnums.Advertiser.AccountType.Account;
                        advertisers.AdvertiserBusinessTypeId = 1;
                        advertisers.AdvertiserAccountStatusId = (int)Entities.PortalEnums.Advertiser.AccountStatus.Approved;

                        advertisers.CompanyName = CommonService.EncodeString(tbAdvertiserCompanyName.Text, true);
                        advertisers.RequireLogonForExternalApplication = true;
                        // Default Value
                        advertisers.LastModified = DateTime.Now;
                        advertisers.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                        advertisers.SiteId = newsiteid;


                        if (AdvertisersService.Insert(advertisers))
                        {
                            using (Entities.AdvertiserUsers user = new Entities.AdvertiserUsers())
                            {
                                user.AdvertiserId = advertisers.AdvertiserId;
                                user.PrimaryAccount = true;
                                user.UserName = CommonService.EncodeString(tbAdvertiserUsername.Text, true);
                                user.UserPassword = CommonService.EncryptMD5(tbAdvertiserPassword.Text);
                                user.FirstName = CommonService.EncodeString(tbAdvertiserFirstName.Text, true);
                                user.Surname = CommonService.EncodeString(tbAdvertiserLastName.Text, true);
                                user.Email = CommonService.EncodeString(tbAdvertiserEmail.Text, true);
                                user.EmailFormat = (int)PortalEnums.Email.EmailFormat.HTML;
                                user.ApplicationEmailAddress = CommonService.EncodeString(tbAdvertiserEmail.Text, true);
                                user.Newsletter = false;
                                user.NewsletterFormat = (int)PortalEnums.Email.EmailFormat.HTML;
                                user.Validated = true;
                                user.JobExpiryNotification = true;
                                // By default the account status for the advertiser user is always approved.
                                user.AccountStatus = (int)PortalEnums.AdvertiserUser.AccountStatus.Approved;

                                user.LastModified = DateTime.Now;
                                using (TList<Entities.SiteLanguages> sitelanguages = SiteLanguageService.GetBySiteId(newsiteid))
                                {
                                    if (sitelanguages.Count > 0)
                                    {
                                        user.DefaultLanguageId = sitelanguages[0].LanguageId;
                                    }
                                }

                                user.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                                AdvertiserUsersService.Insert(user);

                                foreach (RepeaterItem item in rptJobTemplate.Items)
                                {
                                    CheckBox chkJobTemplate = item.FindControl("chkJobTemplate") as CheckBox;
                                    HiddenField hfJobTemplateID = item.FindControl("hfJobTemplateID") as HiddenField;

                                    if (chkJobTemplate.Checked)
                                    {
                                        using (Entities.JobTemplates jobtemplate = JobTemplatesService.GetByJobTemplateId(Convert.ToInt32(hfJobTemplateID.Value)))
                                        {
                                            if (jobtemplate != null)
                                            {
                                                jobtemplate.SiteId = newsiteid;
                                                jobtemplate.AdvertiserId = advertisers.AdvertiserId;

                                                JobTemplatesService.Insert(jobtemplate);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                ltlMessage.Text = "Site copied, Please Check the New Site Settings <a href='/admin/sitesedit.aspx?SiteId=" + newsiteid.ToString() + "'>here</a>.";
            }
            catch (Exception ex)
            {
                ltlMessage.Text = ex.Message;
            }
        }
        #endregion

        [Serializable()]
        internal class SiteCopyClass
        {
            public int SiteId { get; set; }
            public string SiteName { get; set; }
            public string SiteUrl { get; set; }
            public string SiteDescription { get; set; }
            public bool CopyGlobalSettings { get; set; }
            public bool UseCustomProfessionRoles { get; set; }
            public bool CopySiteLocation { get; set; }
            public bool CopyProfessionRoles { get; set; }
            public bool CopySalaryTypes { get; set; }
            public bool CopyWorkTypes { get; set; }
            public bool CopyEducation { get; set; }
            public bool CopyAvailableStatus { get; set; }
            public bool CopyWidgets { get; set; }
            public bool CopyEmailTemplates { get; set; }
            public bool CopyWebParts { get; set; }
            public List<KeyValueClass> SelectedLanguages { get; set; }
            public List<int> SelectedDynamicPages { get; set; }
            public List<string> SelectedDynamicPagesNames { get; set; }
            public List<int> SelectedFiles { get; set; }
        }

        [Serializable()]
        internal class KeyValueClass
        {
            public int Key { get; set; }
            public string Value { get; set; }
        }


    }
}
