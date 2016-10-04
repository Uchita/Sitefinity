using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Data;
using System.Configuration;

namespace JXTPortal.Website.Admin
{
    public partial class DefaultResourcesEdit : System.Web.UI.Page
    {
        #region Declarations

        private int _defaultresourceid = 0;

        private FilesService _filesService;
        private FileTypesService _filetypesService;
        private DefaultResourcesService _defaultResourceService;

        #endregion

        #region Properties

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


        private DefaultResourcesService DefaultResourceService
        {
            get
            {
                if (_defaultResourceService == null)
                {
                    _defaultResourceService = new DefaultResourcesService();
                }
                return _defaultResourceService;
            }
        }

        private int DefaultResourceId
        {
            get
            {
                if ((Request.QueryString["DefaultResourceId"] != null))
                {
                    if (int.TryParse((Request.QueryString["DefaultResourceId"].Trim()), out _defaultresourceid))
                    {
                        _defaultresourceid = Convert.ToInt32(Request.QueryString["DefaultResourceId"]);
                    }
                    return _defaultresourceid;
                }

                return _defaultresourceid;
            }
        }

        #endregion

        #region Page Events

        /// <summary>
        /// Method to Load Folders and Files of the Selected Folder 
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadFoldersAndFiles();
            }


            LoadDefaultResource();
        }

        #endregion

        #region Click Events

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                JXTPortal.Entities.DefaultResources defaultResource = new JXTPortal.Entities.DefaultResources();
                defaultResource.DefaultResourceId = DefaultResourceId;
                defaultResource.ResourceCode = dataResourceCode.Text;
                defaultResource.ResourceFileId = int.Parse(txtFileID.Text);
                defaultResource.ResourceDescription = dataResourceDescription.Text;

                if (DefaultResourceId > 0)
                    DefaultResourceService.Update(defaultResource);
                else
                    DefaultResourceService.Insert(defaultResource);

                Response.Redirect("defaultresources.aspx");
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("defaultresources.aspx");
        }

        #endregion

        #region Folder Repeater Events

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
        }

        #endregion

        #region File Repeater Events

        protected void rptFiles_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int intFileID = int.Parse(e.CommandArgument.ToString());
                txtFileID.Text = e.CommandArgument.ToString();
                SetSelectedFileText(intFileID);
                LoadDisplayImage(intFileID);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "$('#browser').treeview();", true);
               

            }
        }


        #endregion


        #region Methods

        protected void LoadFoldersAndFiles()
        {
            JXTPortal.FoldersService folderService = new JXTPortal.FoldersService();

            using (TList<JXTPortal.Entities.Folders> folders = folderService.GetBySiteId(SessionData.Site.SiteId))
            {
                rptFolders.DataSource = folders;
                rptFolders.DataBind();
            }
        }

        /// <summary>
        /// Method to Load Default Resource
        /// </summary>
        protected void LoadDefaultResource()
        {
            if (DefaultResourceId > 0 && !Page.IsPostBack)
            {
                JXTPortal.Entities.DefaultResources defaultresource = DefaultResourceService.GetByDefaultResourceId(DefaultResourceId);
                dataResourceCode.Text = defaultresource.ResourceCode;
                dataResourceDescription.Text = defaultresource.ResourceDescription;

                if (defaultresource.ResourceFileId.HasValue)
                {
                    SetSelectedFileText((int)defaultresource.ResourceFileId);
                    LoadDisplayImage((int)defaultresource.ResourceFileId);
                    txtFileID.Text = defaultresource.ResourceFileId.Value.ToString();
                }

                dataLastModified.Text = defaultresource.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");

                AdminUsersService aus = new AdminUsersService();
                using (JXTPortal.Entities.AdminUsers adminuser = aus.GetByAdminUserId(defaultresource.LastModifiedBy))
                {
                    dataModifiedBy.Text = adminuser.UserName;
                }
            }
        }

        private void SetSelectedFileText(int SelectedFileID)
        {
            if (SelectedFileID > 0)
            {
                JXTPortal.Entities.Files files = FilesService.GetByFileId(SelectedFileID);
                JXTPortal.FoldersService folderService = new JXTPortal.FoldersService();
                JXTPortal.Entities.Folders folders = folderService.GetByFolderId(files.FolderId);

                dataSelectedFile.Text = string.Format("{0}/{1}", folders.FolderName, files.FileName);
            }
            else
            {
                dataSelectedFile.Text = "";
            }
        }

        private void LoadDisplayImage(int SelectedFileID)
        {
            string[] imgexts = new string[] { "jpg", "png", "gif", "tif" };
            if (SelectedFileID > 0)
            {
                JXTPortal.Entities.Files files = FilesService.GetByFileId(SelectedFileID);
                JXTPortal.Entities.FileTypes filetypes = FileTypesService.GetByFileTypeId(files.FileTypeId);
                if (imgexts.Contains(filetypes.FileTypeName.ToLower()))
                {
                    imgDispaly.ImageUrl = "~/getfile.aspx?id=" + files.FileId.ToString();
                    imgDispaly.Visible = true;
                }
                else
                {
                    imgDispaly.Visible = false;
                }
            }
            else
            {
                imgDispaly.Visible = false;
            }
        }

        #endregion
    }
}
