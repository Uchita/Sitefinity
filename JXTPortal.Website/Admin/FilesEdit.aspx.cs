
#region Imports...
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
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

public partial class FilesEdit : System.Web.UI.Page
{
    #region Declare variables

    private int _fileid = -1;

    // Show Image
    string[] imgexts = new string[] { "jpg", "png", "gif", "tif" };

    #endregion

    #region Properties
    
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

    private int FileId
    {
        get
        {

            if ((Request.QueryString["FileId"] != null))
            {
                if (int.TryParse((Request.QueryString["FileId"].Trim()), out _fileid))
                {
                    _fileid = Convert.ToInt32(Request.QueryString["FileId"]);
                }
                return _fileid;
            }

            return _fileid;
        }
    }

    #endregion

    #region Page Event handlers

    protected void Page_Init(object sender, EventArgs e)
    {
        // Hack for the Upload funcationality to work for Ajax
        ScriptManager.GetCurrent(this).RegisterPostBackControl(btnEditSave);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadFolders();

            if (FileId > 0 || Request.QueryString["add"] != null)
            {
                ShowEditFile();
            }
        }

        LoadFolderFiles();
    }
    
    #endregion

    #region Click Event handlers

    /// <summary>
    /// Save the edited file
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEditSave_Click(object sender, EventArgs e)
    {
        ltlMessage.Text = String.Empty;

        Files files = null;

        if (FileId > 0)
        {
            files = FilesService.GetByFileId(FileId);
        }
        else
        {
            files = new Files();
        }

        string strExtension = System.IO.Path.GetExtension(txtSystemName.Text.Trim());
        if (!string.IsNullOrEmpty(strExtension))
        {
            int intFileType = FilesService.GetFileType(strExtension);
            if (intFileType > 0)
            {

                files.FileName = txtFileName.Text.Trim();
                files.FileSystemName = txtSystemName.Text.Trim();
                files.FileTypeId = intFileType;
                files.FolderId = int.Parse(lstBoxFolders.SelectedValue);


                FilesService.Save(files);

                ltlMessage.Text = "File Saved";


                if (imgexts.Contains(strExtension.Replace(".","").ToLower()))
                {
                    imgDisplay.ImageUrl = files.FileSystemName;
                    imgDisplay.Visible = true;
                }
                else
                {
                    imgDisplay.Visible = false;
                }

            }
            else
            {
                ltlMessage.Text = "Error - File Type not found";
            }

        }




    }

    /// <summary>
    /// Return to the list of files
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("filesedit.aspx");
    }
    
    #endregion

    #region Grid Method

    protected void gridViewFiles_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {        
        int fileid = 0;
        
        fileid = Convert.ToInt32(gridViewFiles.Rows[e.RowIndex].Cells[2].Text);

        try
        {
            FilesService.Delete(fileid);

            ltlMessage.Text = "File Deleted";

            LoadFolderFiles();
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("REFERENCE constraint"))
                ltlMessage.Text = "Error - The File is been used in one of the dynamic pages. Please uncheck the option in the Dynamic Page to delete the file.";
            else
                ltlMessage.Text = ex.Message;
        }
    }


    #endregion

    #region Methods

    /// <summary>
    /// Method to Load the 
    /// </summary>
    protected void LoadFolders()
    {
        JXTPortal.FoldersService folderService = new JXTPortal.FoldersService();

        using (TList<JXTPortal.Entities.Folders> folders = folderService.GetBySiteId(SessionData.Site.SiteId))
        {
            lstBoxFolders.DataSource = folders;
            lstBoxFolders.DataTextField = "FolderName";
            lstBoxFolders.DataValueField = "FolderID";
            lstBoxFolders.DataBind();

            if (folders.Count > 0)
                lstBoxFolders.SelectedIndex = 0;
        }

    }

    /// <summary>
    /// Method to Load Folders and Files of the Selected Folder 
    /// </summary>
    protected void LoadFolderFiles()
    {
        if (lstBoxFolders.SelectedItem != null)
        {
            int intFolderID = int.Parse(lstBoxFolders.SelectedValue);
            
            using (TList<JXTPortal.Entities.Files> objFiles = FilesService.GetBySiteId(SessionData.Site.SiteId))
            {
                if (objFiles.Count > 0)
                {                 
                    // ToDO - Create a SP - searches by siteid, folderid
                    objFiles.Filter = "FolderID = " + intFolderID.ToString();
                    gridViewFiles.DataSource = objFiles;
                    gridViewFiles.DataBind();
                }
            }
        }
    }

    /// <summary>
    /// Show the File Edit View, Get the File Details
    /// </summary>
    protected void ShowEditFile()
    {
        MultiViewFileEdit.SetActiveView(ViewEditFile);

        if (FileId > 0)
        {
            using (JXTPortal.Entities.Files objFile = FilesService.GetByFileId(FileId))
            {
                if (objFile != null && objFile.SiteId == SessionData.Site.SiteId)
                {
                    txtFileName.Text = objFile.FileName.Trim();

                    txtSystemName.Text = objFile.FileSystemName.Trim();

                    if (objFile.LastModified != null)
                        ltlLastModified.Text = ((DateTime)objFile.LastModified).ToString(SessionData.Site.DateFormat +" hh:mm:ss tt");

                    if (objFile.FolderId > 0)
                    {
                        FoldersService objFolders = new FoldersService();
                        using (JXTPortal.Entities.Folders folder = objFolders.GetByFolderId(objFile.FolderId))
                        {
                            ltlFolderName.Text = folder.FolderName;
                        }
                    }

                    if (objFile.FileTypeId > 0)
                    {
                        FileTypesService objFileType = new FileTypesService();
                        using (JXTPortal.Entities.FileTypes fileType = objFileType.GetByFileTypeId(objFile.FileTypeId))
                        {
                            ltlFileType.Text = fileType.FileTypeName;


                            if (imgexts.Contains(fileType.FileTypeName.ToLower()))
                            {
                                imgDisplay.ImageUrl = objFile.FileSystemName.Trim();
                                imgDisplay.Visible = true;
                            }
                            else
                            {
                                imgDisplay.Visible = false;
                            }

                        }
                    }

                    if (objFile.LastModifiedBy > 0)
                    {
                        AdminUsersService aus = new AdminUsersService();
                        using (JXTPortal.Entities.AdminUsers adminuser = aus.GetByAdminUserId(objFile.LastModifiedBy))
                        {
                            ltlLastModifiedBy.Text = adminuser.UserName;
                        }
                    }



                }
                else
                {
                    Response.Redirect("filesedit.aspx");
                }
            }
        }



    }

    #endregion


    

}


