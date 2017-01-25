using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Data;
using JXTPortal.Common.Extensions;
using JXTPortal.Entities;
using System.Configuration;
using System.Web.UI.HtmlControls;

namespace JXTPortal.Website.Admin
{
    public partial class SiteResourcesEdit : System.Web.UI.Page
    {
        #region Declarations

        private int _siteresourceid = 0;
        private FilesService _filesService;
        private FileTypesService _filetypesService;
        private DefaultResourcesService _defaultResourcesService;
        private SiteResourcesService _siteResourcesService;

        #endregion

        #region Properties

        private int _itemIndex=0;

        public int itemIndex
        {
            get
            {
                return _itemIndex;
            }
            set
            {
                _itemIndex = value;
            }
        }

        private int DefaultResourceId
        {
            get
            {
                if ((Request.QueryString["DefaultResourceId"] != null))
                {
                    if (int.TryParse((Request.QueryString["DefaultResourceId"].Trim()), out _siteresourceid))
                    {
                        _siteresourceid = Convert.ToInt32(Request.QueryString["DefaultResourceId"]);
                    }
                    return _siteresourceid;
                }

                return _siteresourceid;
            }
        }

        private int SiteResourceId
        {
            get
            {
                string resourcecode = DefaultResourcesService.GetByDefaultResourceId(DefaultResourceId).ResourceCode;
                TList<JXTPortal.Entities.SiteResources> siteresource = SiteResourcesService.GetByResourceCode(resourcecode);
                siteresource.Filter = "SiteID = " + SessionData.Site.SiteId.ToString();
                if (siteresource.Count > 0)
                    return siteresource[0].SiteResourceId;
                else
                    return 0;
            }
        }

        private int SelectedResourceID
        {
            get
            {
                if (ViewState["SelectedResourceID"] != null)
                    return Convert.ToInt32(ViewState["SelectedResourceID"]);
                else
                    return 0;
            }
            set
            {
                ViewState["SelectedResourceID"] = value;
            }
        }

        private int SelectedSiteResourceID
        {
            get
            {
                if (!string.IsNullOrEmpty(ViewState["SelectedSiteResourceID"].ToString()))
                    return Convert.ToInt32(ViewState["SelectedSiteResourceID"]);
                else
                    return 0;
            }
            set
            {
                ViewState["SelectedSiteResourceID"] = value;
            }
        }

        private DefaultResourcesService DefaultResourcesService
        {
            get
            {
                if (_defaultResourcesService == null)
                {
                    _defaultResourcesService = new DefaultResourcesService();
                }
                return _defaultResourcesService;
            }
        }

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

        private FileTypesService FileTypesService
        {
            get
            {
                if (_filetypesService == null)
                {
                    _filetypesService = new FileTypesService();
                }
                return _filetypesService;
            }
        }

        private SiteResourcesService SiteResourcesService
        {
            get
            {
                if (_siteResourcesService == null)
                {
                    _siteResourcesService = new SiteResourcesService();
                }
                return _siteResourcesService;
            }
        }

        #endregion

        #region Page Events

        /// <summary>
        /// Method to Load Site, Language and Site Resource
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDefaultResource();
                LoadLanguage();
            }

            LoadJavascript();
        }

        #endregion

        #region Click Events

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            //if (Page.IsValid)
            //{
            //    JXTPortal.Entities.SiteResources siteResource = new JXTPortal.Entities.SiteResources();
            //    siteResource.SiteId = SessionData.Site.SiteId;
            //    siteResource.SiteResourceId = SiteResourceId;
            //    siteResource.LanguageId = Convert.ToInt32(dataLanguage.SelectedValue);

            //    JXTPortal.Entities.DefaultResources dr = DefaultResourcesService.GetByDefaultResourceId(SelectedResourceID);
            //    siteResource.ResourceCode = dr.ResourceCode;
            //    siteResource.ResourceFileId = SelectedSiteResourceID;
            //    siteResource.ResourceText = dataResourceText.Text;

            //    if (SiteResourceId > 0)
            //        SiteResourcesService.Update(siteResource);
            //    else
            //        SiteResourcesService.Insert(siteResource);

            //    Response.Redirect("SiteResources.aspx");
            //}
        }

        protected void btnUseDefault_Click(object sender, EventArgs e)
        {
            //if (SiteResourceId > 0)
            //{
            //    JXTPortal.Entities.SiteResources siteresource = SiteResourcesService.GetBySiteResourceId(SiteResourceId);
            //    if (siteresource != null)
            //    {
            //        SiteResourcesService.Delete(siteresource);
            //        ltlMessage.Text = ltlMessage.Text = "You are now using the default resource";
            //        LoadCurrentResource();
            //        LoadSiteResource();
            //    }
            //}


        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            //Response.Redirect("SiteResources.aspx");
        }

        #endregion

        #region gridViewFiles Events

        protected void rptFolders_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
            {
                Repeater rptFiles = (Repeater)item.FindControl("rptFiles");
                JXTPortal.Entities.Folders objFolder = (JXTPortal.Entities.Folders)item.DataItem;

                int intFolderID = objFolder.FolderId;

                using (TList<JXTPortal.Entities.Files> objFiles = FilesService.GetByFolderId(intFolderID))
                {
                    rptFiles.DataSource = objFiles;
                    rptFiles.DataBind();
                }


            }
            else if (item.ItemType == ListItemType.Header)
            {
                Literal ltlHeader = item.FindControl("ltlHeader") as Literal;
                ltlHeader.Text = String.Format("<ul id='browser{0}' class='filetree'>", itemIndex.ToString());                
            }
            else if (item.ItemType == ListItemType.Footer)
            {
                //HtmlGenericControl divFooter = item.FindControl("divFooter") as HtmlGenericControl;
                //divFooter.InnerHtml = divFooter.InnerHtml.Replace("{0}", itemIndex.ToString());
                itemIndex = itemIndex + 1;

            }
        }

        protected void rptFiles_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int intFileID = int.Parse(e.CommandArgument.ToString());
                SelectedSiteResourceID = Convert.ToInt32(e.CommandArgument);

                RepeaterItem repeateritem = ((Repeater)source).Parent.Parent.Parent as RepeaterItem;
                SetSelectedFileText(intFileID, repeateritem);
                LoadSiteDisplayImage(intFileID, repeateritem);

               
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Load Javascript to Fix the bug Ajax-Javascript
        /// </summary>
        private void LoadJavascript()
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "JavascriptToWork", @"
<script type='text/javascript'  src='/admin/scripts/jquery.treeview.js'></script>
<script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.coda-slider-2.0.js'></script>
<script type='text/javascript' language='javascript' src='/admin/scripts/coda-slider/jquery.easing.1.3.js'></script>

<script type='text/javascript'>
    $().ready(function() {
        $('#coda-slider-1').codaSlider({
            dynamicArrows: false,
            autoHeight: true
        });
    });
</script>

", false);
            
            string strJavascript = string.Empty;

            for (int i = 0; i < 3; i++)
            {
                strJavascript = String.Format(@"

$(function() {{
$('#browser{0}').treeview();

$('#browser{0}').bind('contextmenu', function(event) {{
        if ($(event.target).is('li') || $(event.target).parents('li').length) {{
            $('#browser{0}').treeview({{
                remove: $(event.target).parents('li').filter(':first')
            }});
            return false;
        }}
    }});
}})", i.ToString());

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup" + i.ToString(), strJavascript, true);
                
            }
        }

        private void LoadDefaultResource()
        {
            using (JXTPortal.Entities.DefaultResources defaultresource = DefaultResourcesService.GetByDefaultResourceId(DefaultResourceId))
            {
                if (defaultresource != null)
                {
                    dataDefaultResourceCode.Text = defaultresource.ResourceCode;
                    dataDefaultResourceText.Text = defaultresource.ResourceText;
                    dataDefaultResourceDescription.Text = defaultresource.ResourceDescription;
                    JXTPortal.Entities.Files files = FilesService.GetByFileId((int)defaultresource.ResourceFileId);
                    JXTPortal.FoldersService folderService = new JXTPortal.FoldersService();
                    JXTPortal.Entities.Folders folders = folderService.GetByFolderId(files.FolderId);

                    dataDefaultFile.Text = string.Format("{0}/{1}", folders.FolderName, files.FileName);
                    LoadDefaultDisplayImage((int)defaultresource.ResourceFileId);
                }
                else
                    Response.Redirect("siteresources.aspx");
            }
        }


        private void LoadSiteDisplayImage(int SelectedFileID, RepeaterItem repeateritem)
        {
            Image imgSiteDispaly = repeateritem.FindControl("imgSiteDispaly") as Image;

            string[] imgexts = new string[] { "jpg", "png", "gif", "tif" };
            if (SelectedFileID > 0)
            {
                using (JXTPortal.Entities.Files files = FilesService.GetByFileId(SelectedFileID))
                using (JXTPortal.Entities.FileTypes filetypes = FileTypesService.GetByFileTypeId(files.FileTypeId))
                {
                    if (imgexts.Contains(filetypes.FileTypeName.ToLower()))
                    {
                        imgSiteDispaly.ImageUrl = string.Format("~/getfile.aspx?id={0}&ver={1}", files.FileId.ToString(), files.LastModified.ToEpocTimestamp());
                        imgSiteDispaly.Visible = true;
                    }
                    else
                    {
                        imgSiteDispaly.Visible = false;
                    }
                }
            }
            else
            {
                imgSiteDispaly.Visible = false;
            }
        }

        private void SetSelectedFileText(int SelectedFileID, RepeaterItem repeateritem)
        {
            TextBox txtFileID = repeateritem.FindControl("txtFileID") as TextBox;
            Label dataSelectedSiteResource = repeateritem.FindControl("dataSelectedSiteResource") as Label;

            if (SelectedFileID > 0)
            {
                using (JXTPortal.Entities.Files files = FilesService.GetByFileId(SelectedFileID))
                {
                    JXTPortal.FoldersService folderService = new JXTPortal.FoldersService();
                    using (JXTPortal.Entities.Folders folders = folderService.GetByFolderId(files.FolderId))
                    {
                        txtFileID.Text = SelectedFileID.ToString();
                        dataSelectedSiteResource.Text = string.Format("{0}/{1}", folders.FolderName, files.FileName);
                    }
                }
            }
            else
            {
                dataSelectedSiteResource.Text = "";
            }
        }

        private void LoadLanguage()
        {
            SiteLanguagesService languageService = new SiteLanguagesService();
            using (TList<JXTPortal.Entities.SiteLanguages> languages = languageService.GetBySiteId(SessionData.Site.SiteId))
            {
                rptSiteResources.DataSource = languages;
                rptSiteResources.DataBind();
            }
        }

        protected void rptSiteResources_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Save")
            {
                foreach (RepeaterItem repeateritem in rptSiteResources.Items)
                {
                    HiddenField hfLanguageId = repeateritem.FindControl("hfLanguageId") as HiddenField;
                    HiddenField hfSiteResourceId = repeateritem.FindControl("hfSiteResourceId") as HiddenField;
                    TextBox txtFileID = repeateritem.FindControl("txtFileID") as TextBox;
                    TextBox dataResourceText = repeateritem.FindControl("dataResourceText") as TextBox;

                    JXTPortal.Entities.SiteResources siteResource = new JXTPortal.Entities.SiteResources();
                    siteResource.SiteId = SessionData.Site.SiteId;
                    siteResource.SiteResourceId = Convert.ToInt32(hfSiteResourceId.Value);
                    siteResource.LanguageId = Convert.ToInt32(hfLanguageId.Value);

                    using (JXTPortal.Entities.DefaultResources dr = DefaultResourcesService.GetByDefaultResourceId(DefaultResourceId))
                    {
                        siteResource.ResourceCode = dr.ResourceCode;
                        siteResource.ResourceFileId = Convert.ToInt32(txtFileID.Text);
                        siteResource.ResourceText = dataResourceText.Text;
                    }

                    if (Convert.ToInt32(hfSiteResourceId.Value) > 0)
                        SiteResourcesService.Update(siteResource);
                    else
                        SiteResourcesService.Insert(siteResource);
                }

                Response.Redirect("siteresources.aspx");
            }
            else if (e.CommandName == "UseDefault")
            {
                foreach (RepeaterItem repeateritem in rptSiteResources.Items)
                {
                    HiddenField hfSiteResourceId = repeateritem.FindControl("hfSiteResourceId") as HiddenField;


                    JXTPortal.Entities.SiteResources siteresource = SiteResourcesService.GetBySiteResourceId(Convert.ToInt32(hfSiteResourceId.Value));
                    if (siteresource != null)
                    {
                        SiteResourcesService.Delete(siteresource);
                        ltlMessage.Text = ltlMessage.Text = "You are now using the default resource";
                    }
                }

                LoadLanguage();
            }
            else if (e.CommandName == "Return")
            {
                Response.Redirect("siteresources.aspx");
            }
        }

        protected void rptSiteResources_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                using (JXTPortal.Entities.SiteLanguages sitelanguage = e.Item.DataItem as JXTPortal.Entities.SiteLanguages)
                {
                    Literal litLanguageName = e.Item.FindControl("litLanguageName") as Literal;
                    HiddenField hfLanguageId = e.Item.FindControl("hfLanguageId") as HiddenField;

                    hfLanguageId.Value = sitelanguage.LanguageId.ToString();
                    litLanguageName.Text = sitelanguage.SiteLanguageName;

                    LoadFoldersAndFiles(e.Item);
                    LoadSiteResource(sitelanguage.LanguageId, e.Item);
                }
            }
        }

        private void LoadSiteResource(int languageid, RepeaterItem repeateritem)
        {
            using (JXTPortal.Entities.DefaultResources defaultresource = DefaultResourcesService.GetByDefaultResourceId(DefaultResourceId))
            using (TList<JXTPortal.Entities.SiteResources> siteresources = SiteResourcesService.GetBySiteId(SessionData.Site.SiteId))
            {
                TextBox dataResourceText = repeateritem.FindControl("dataResourceText") as TextBox;
                TextBox txtFileID = repeateritem.FindControl("txtFileID") as TextBox;
                HiddenField hfSiteResourceId = repeateritem.FindControl("hfSiteResourceId") as HiddenField;
                Label dataLastModified = repeateritem.FindControl("dataLastModified") as Label;
                Label dataModifiedBy = repeateritem.FindControl("dataModifiedBy") as Label;

                hfSiteResourceId.Value = "0";
                dataResourceText.Text = defaultresource.ResourceText;
                SetSelectedFileText((int)defaultresource.ResourceFileId, repeateritem);
                LoadSiteDisplayImage((int)defaultresource.ResourceFileId, repeateritem);

                siteresources.Filter = string.Format("LanguageId = {0} AND ResourceCode = {1}", languageid, defaultresource.ResourceCode);

                if (siteresources.Count > 0)
                {
                    using (JXTPortal.Entities.SiteResources siteresource = siteresources[0])
                    {
                        hfSiteResourceId.Value = siteresource.SiteResourceId.ToString();
                        dataResourceText.Text = siteresource.ResourceText;
                        dataLastModified.Text = siteresource.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                        AdminUsersService aus = new AdminUsersService();
                        using (Entities.AdminUsers adminuser = aus.GetByAdminUserId(siteresource.LastModifiedBy))
                        {
                            dataModifiedBy.Text = adminuser.UserName;
                        }

                        SetSelectedFileText((int)siteresource.ResourceFileId, repeateritem);
                        SetSelectedFileText((int)siteresource.ResourceFileId, repeateritem);
                        LoadSiteDisplayImage((int)siteresource.ResourceFileId, repeateritem);
                    }
                }
            }
        }

        protected void LoadFoldersAndFiles(RepeaterItem repeateritem)
        {
            JXTPortal.FoldersService folderService = new JXTPortal.FoldersService();

            Repeater rptFolders = repeateritem.FindControl("rptFolders") as Repeater;

            using (TList<JXTPortal.Entities.Folders> folders = folderService.GetBySiteId(SessionData.Site.SiteId))
            {
                rptFolders.DataSource = folders;
                rptFolders.DataBind();
            }
        }

        private void LoadDefaultDisplayImage(int SelectedFileID)
        {
            string[] imgexts = new string[] { "jpg", "png", "gif", "tif" };
            if (SelectedFileID > 0)
            {
                JXTPortal.Entities.Files files = FilesService.GetByFileId(SelectedFileID);
                JXTPortal.Entities.FileTypes filetypes = FileTypesService.GetByFileTypeId(files.FileTypeId);
                if (imgexts.Contains(filetypes.FileTypeName.ToLower()))
                {
                    dataDefaultFileDisplay.ImageUrl = string.Format("~/getfile.aspx?id={0}&ver={1}", files.FileId.ToString(), files.LastModified.ToEpocTimestamp());
                    dataDefaultFileDisplay.Visible = true;
                }
                else
                {
                    dataDefaultFileDisplay.Visible = false;
                }
            }
            else
            {
                dataDefaultFileDisplay.Visible = false;
            }
        }

        #endregion
    }
}
