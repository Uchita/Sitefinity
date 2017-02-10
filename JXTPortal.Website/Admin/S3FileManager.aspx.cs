using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using JXTPortal.Entities;
using JXTPortal.Common;
using JXTPortal.Common.Models;

using Microsoft.Win32;
using System.Runtime.InteropServices;


namespace JXTPortal.Website.Admin
{

    public partial class S3FileManager : System.Web.UI.Page
    {
        #region Declaration

        private string FTPHostUrl = ConfigurationManager.AppSettings["FTPFileManager"];
        private string clientFolder = ConfigurationManager.AppSettings["AWSS3ClientFolder"];

        #endregion

        #region Properties
        private GlobalSettingsService _globalsettingsservice;
        private GlobalSettingsService GlobalSettingsService
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
            get
            {
                string path = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId)[0].FtpFolderLocation.Replace("s3://", "");
                if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId != (int)PortalEnums.Admin.AdminRole.Administrator)
                {
                    path = string.Format("{0}/{1}", path, clientFolder);
                }
                
                return path;

            }
        }

        #endregion

        public IFileManager FileManagerService { get; set; }
        static string bucketName = ConfigurationManager.AppSettings["AWSS3BucketName"];
        private string _currentFolder = string.Empty;
        #region Page

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientIDMode = System.Web.UI.ClientIDMode.AutoID;

            if (!Page.IsPostBack)
            {
                ScriptManager sm = AjaxControlToolkit.ToolkitScriptManager.GetCurrent(Page);
                sm.RegisterAsyncPostBackControl(btnRoot);
                _currentFolder = FTPFolderLocation;

                if (!string.IsNullOrWhiteSpace(_currentFolder))
                {
                    LoadCurrentFolders(_currentFolder);
                }
            }

            FileManagerFiles.FileManagerFilesClicked += new UserControls.S3FileManagerFilesClickedHandler(FileManagerFiles_FileManagerFilesClicked);
        }

        void FileManagerFiles_FileManagerFilesClicked(string name, bool isDirectory, string errormessage)
        {
            LoadFolderDropDownList();
            ReregisterJS();

            if (!string.IsNullOrEmpty(errormessage))
            {
                DisplayErrorMessage(errormessage);

            }

            SetCurrentSelectedFolder();
        }


        #endregion

        #region Methods

        private void SetCurrentSelectedFolder()
        {
            if (FileManagerFiles.IsRoot)
            {
                btnRoot.Style["font-weight"] = "bold";

                foreach (RepeaterItem item in rptFolders.Items)
                {
                    LinkButton btnFolder = item.FindControl("btnFolder") as LinkButton;
                    btnFolder.Style["font-weight"] = "normal";
                }
            }
            else
            {
                btnRoot.Style["font-weight"] = "normal";
                string[] parts = FileManagerFiles.CurrentPath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (RepeaterItem item in rptFolders.Items)
                {
                    LinkButton btnFolder = item.FindControl("btnFolder") as LinkButton;
                    if (btnFolder.Text == parts[parts.Length - 1])
                    {
                        btnFolder.Style["font-weight"] = "bold";
                    }
                    else
                    {
                        btnFolder.Style["font-weight"] = "normal";
                    }
                }
            }
        }

        private void LoadCurrentFolders(string folder)
        {
            string errorMessage = string.Empty;
            List<FileManagerFile> files = FileManagerService.ListFiles(bucketName, FTPFolderLocation, out errorMessage);

            if (!string.IsNullOrEmpty(errorMessage)) { DisplayErrorMessage(errorMessage); return; }

            if (files.Count == 0)
            {
                FileManagerService.CreateFolder(bucketName, folder, out errorMessage);
                if (!string.IsNullOrEmpty(errorMessage)) { DisplayErrorMessage(errorMessage); return; }

                files = FileManagerService.ListFiles(bucketName, folder, out errorMessage);
                if (!string.IsNullOrEmpty(errorMessage)) { DisplayErrorMessage(errorMessage); return; }
            }

            var directories = files.Where(x => x.FileName.Replace(FTPFolderLocation + "/", "").Split(new char[] { '/' }).Length > 1)
                                    .Select(x => x.FileName.Replace(FTPFolderLocation + "/", "").Split(new char[] { '/' })[0])
                                    .Distinct();

            rptFolders.DataSource = null;
            if (directories.ToList().Count > 0)
            {
                rptFolders.DataSource = directories;
            }
            rptFolders.DataBind();

            FileManagerFiles.LoadFolderFiles(folder, (folder.Contains("/") == false), out errorMessage);
            if (!string.IsNullOrEmpty(errorMessage)) { DisplayErrorMessage(errorMessage); return; }

            LoadFolderDropDownList();
        }

        private void LoadFolderDropDownList()
        {
            string errorMessage = string.Empty;

            List<FileManagerFile> files = FileManagerService.ListFiles(bucketName, FTPFolderLocation, out errorMessage);

            var folders = files.Select(x => string.Join("/", x.Folders)).Where(x => x != FTPFolderLocation).Distinct()
                               .Select(x => new ListItem(x.Replace(FTPFolderLocation + "/", ""), x));

            ddlFolders.Items.Clear();
            ddlFolders.Items.AddRange(folders.ToArray());
            ddlFolders.Items.Insert(0, new ListItem("Root", FTPFolderLocation));
        }

        #endregion

        protected void rptFolders_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string folderName = e.Item.DataItem as string;
                LinkButton btnFolder = e.Item.FindControl("btnFolder") as LinkButton;

                btnFolder.Click += new EventHandler(btnFolder_Click);

                btnFolder.Text = folderName;
                btnFolder.CommandName = "folder";
                btnFolder.CommandArgument = folderName;


                if (FileManagerFiles.IsRoot)
                {
                    btnRoot.Style["font-weight"] = "bold";
                    btnFolder.Style["font-weight"] = "normal";
                }
                else
                {
                    string[] paths = FileManagerFiles.CurrentPath.Split(new char[] { '/' });
                    string currentfolder = paths[paths.Length - 1];
                    if (currentfolder == folderName)
                    {
                        btnFolder.Style["font-weight"] = "bold";
                    }
                }

            }
        }

        protected void rptFolders_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            ScriptManager scriptmanager = AjaxControlToolkit.ToolkitScriptManager.GetCurrent(Page);
            LinkButton btn = e.Item.FindControl("btnFolder") as LinkButton;
            if (btn != null)
            {
                btn.Click += btnFolder_Click;
                scriptmanager.RegisterAsyncPostBackControl(btn);
            }
        }

        protected void btnFolder_Click(object sender, EventArgs e)
        {
            string errormessage = string.Empty;
            ReregisterJS();
            LinkButton btnFolder = sender as LinkButton;
            FileManagerFiles.LoadFolderFiles(FTPFolderLocation.TrimEnd(new char[] { '/' }) + "/" + btnFolder.CommandArgument, false, out errormessage);
            if (string.IsNullOrEmpty(errormessage))
            {
                LoadFolderDropDownList();
                SetCurrentSelectedFolder();
            }
            else
            {
                DisplayErrorMessage(errormessage);
            }
        }

        protected void btnRoot_Click(object sender, EventArgs e)
        {
            string errormessage = string.Empty;
            ReregisterJS();
            FileManagerFiles.LoadFolderFiles(FTPFolderLocation, true, out errormessage); //Retrieve Root Files
            if (!string.IsNullOrEmpty(errormessage))
            {
                DisplayErrorMessage(errormessage);
            }
            LoadFolderDropDownList();
            SetCurrentSelectedFolder();
        }

        private void ReregisterJS()
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "JavascriptToWork", @"
                <script type='text/javascript'>
                $.unblockUI();
                
                $(function() {
                    $('#browser').treeview({
                        control: '#treecontrol'
                    });

                    $('#browser').bind('contextmenu', function(event) {
                        if ($(event.target).is('li') || $(event.target).parents('li').length) {
                            $('#browser').treeview({
                                remove: $(event.target).parents('li').filter(':first')
                            });
                            return false;
                        }
                    });
                })

                $('.modal-backdrop').hide();

                $(document).ready(function (e) {
                            $('.droppable').click(function () {
                                $('.droppable').removeClass('active');
                                $(this).addClass('active');

                                var fileurl = $(this).find('input[type=" + "\"hidden\"" + @"]').first().val();
                                $('#footer-row').find('input[type=" + "\"text\"" + @"]').first().val(fileurl);
                            });

                });

                $(document).ready(function () {" +
            "$('.context1').each(function (i, obj) { $(obj).vscontext({ menuBlock: 'vs-context-menu1' }, $(obj).find('input[type=\"hidden\"]').first().val()); });" +
            "$('.context2').each(function (i, obj) { $(obj).vscontext({ menuBlock: 'vs-context-menu2' }, $(obj).find('a').first().text()); });" +
            "$('.context3').each(function (i, obj) { $(obj).vscontext({ menuBlock: 'vs-context-menu3' }, $(obj).find('input[type=\"hidden\"]').first().val()); });" +
        @" 

            });
                </script>
                ", false);
        }

        private void DisplayErrorMessage(string errormessage)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "JavascriptErrorMessage", @"
                <script type='text/javascript'>
                    confirmed = false;
                    $('.modal-backdrop').hide();
                    $(document).ready(function (e) {
                        $.blockUI.defaults.blockMsgClass = 'blockUI-error';

                        $.blockUI({
                            onOverlayClick: $.unblockUI,
                            message: '<span>" + errormessage.Replace("'", "") + @"</span>'
                        });
                    });
                </script>", false);
        }

        private void DisplaySuccessMessage(string successmessage)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "JavascriptErrorMessage", @"
                <script type='text/javascript'>
                    confirmed = false;
                    $('.modal-backdrop').hide();
                    $(document).ready(function (e) {
                        $.blockUI.defaults.blockMsgClass = 'blockUI-success';

                        $.blockUI({
                            onOverlayClick: $.unblockUI,
                            message: '<span>" + successmessage.Replace("'", "") + @"</span>'
                        });
                    });
                </script>", false);
        }

        protected void btnFileDelete_Click(object sender, EventArgs e)
        {
            FileManagerFiles.DeleteFile(hfFileURL.Value);
        }

        protected void btnFileDownload_Click(object sender, EventArgs e)
        {
            FileManagerFiles.DownloadFile(hfFileURL.Value);
        }

        protected void btnNonImageDownload_Click(object sender, EventArgs e)
        {
            FileManagerFiles.DownloadFile(hfNonImageFileURL.Value);
        }

        protected void btnNonImageDelete_Click(object sender, EventArgs e)
        {
            FileManagerFiles.DeleteFile(hfNonImageFileURL.Value);
        }

        protected void btnFolderOpen_Click(object sender, EventArgs e)
        {
            FileManagerFiles.OpenFolder(hfFolderName.Value);
        }

        protected void btnFolderDelete_Click(object sender, EventArgs e)
        {
            FileManagerFiles.DeleteFolder(hfFolderName.Value);
            LoadCurrentFolders(FileManagerFiles.CurrentPath);
        }

        protected void btnRenameFileConfirm_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                char[] invalidchars = ("#<$+%>!`&*'|{?\"=}/:\\@").ToString().ToCharArray();
                foreach (char c in invalidchars)
                {
                    if (tbRenameFile.Text.Contains(c))
                    {
                        string errormessage = "File name cannot contain any of the following characters # < $ + % > ! ` & * ' | { ? \" = } / : \\ @";
                        DisplayErrorMessage(errormessage);
                        return;
                    }
                }

                FileManagerFiles.RenameFile(hfOriginalFileName.Value, tbRenameFile.Text);
            }
        }

        protected void cvRenameFile_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(tbRenameFile.Text))
            {
                args.IsValid = false;
                cvRenameFile.ErrorMessage = "File Name cannot be empty";
            }

            char[] invalidchars = ("#<$+%>!`&*'|{?\"=}/:\\@").ToString().ToCharArray();
            foreach (char c in invalidchars)
            {
                if (tbRenameFile.Text.Contains(c))
                {
                    ReregisterJS();
                    DisplayErrorMessage("File name cannot contain any of the following characters # < $ + % > ! ` & * ' | { ? \" = } / : \\ @");
                    args.IsValid = false;
                    break;
                }
            }
        }

        protected void cvRenameFolder_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(tbRenameFolder.Text))
            {
                args.IsValid = false;
                cvRenameFolder.ErrorMessage = "Folder Name cannot be empty";
            }

            if (tbRenameFolder.Text.Trim() == "...")
            {
                args.IsValid = false;
                cvRenameFolder.ErrorMessage = "Invalid Folder Name";
            }

            char[] invalidchars = Path.GetInvalidFileNameChars();
            foreach (char c in invalidchars)
            {
                if (tbRenameFolder.Text.Contains(c))
                {
                    ReregisterJS();
                    DisplayErrorMessage("Folder name cannot contain any of the following characters \\ / : * ? \" < > |");
                    args.IsValid = false;
                    break;
                }
            }
        }

        protected void btnRenameFolderConfirm_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                FileManagerFiles.RenameFolder(hfOriginalFolderName.Value, tbRenameFolder.Text);
                LoadCurrentFolders(FileManagerFiles.CurrentPath);
            }
        }

        protected void cvCreateFolder_ServerValidate(object source, ServerValidateEventArgs args)
        {

            if (string.IsNullOrWhiteSpace(tbCreateFolder.Text))
            {
                args.IsValid = false;
                cvCreateFolder.ErrorMessage = "Folder Name cannot be empty";
                return;
            }

            if (cvCreateFolder.Text.Trim() == "...")
            {
                args.IsValid = false;
                cvCreateFolder.ErrorMessage = "Invalid Folder Name";
                return;
            }

            char[] invalidchars = Path.GetInvalidFileNameChars();
            foreach (char c in invalidchars)
            {
                if (tbCreateFolder.Text.Contains(c))
                {
                    args.IsValid = false;
                    break;
                }
            }
        }

        protected void btnMoveSelectedFileConfirm_Click(object sender, EventArgs e)
        {
            string toFolder = ddlFolders.Items[ddlFolders.SelectedIndex].Value;

            FileManagerFiles.MoveFile(FileManagerFiles.CurrentPath, hfMoveSelectedFileName.Value, toFolder, hfMoveSelectedFileName.Value);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                string errorMessage = string.Empty;

                string[] filenameparts = fileUpload.PostedFile.FileName.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                string filename = filenameparts.LastOrDefault();

                char[] invalidchars = ("#<$+%>!`&*'|{?\"=}/:\\@").ToString().ToCharArray();
                bool invalid = invalidchars.Any(c => filename.Contains(c));
                if (invalid)
                {
                    errorMessage = "Filename cannot contain # < $ + % > ! ` & * ' | { ? \" = } / : \\ @";
                    DisplayErrorMessage(errorMessage);
                    return;
                }

                string filepath = string.Format("{0}/{1}", FileManagerFiles.CurrentPath, filename);

                string validfiletypes = ConfigurationManager.AppSettings["ValidUploadFileTypes"];
                string[] extensions = validfiletypes.Split(new char[] { ',' });

                System.IO.FileInfo fi = new System.IO.FileInfo(filename);
                bool validfile = extensions.Any(x => x == fi.Extension.ToLower());

                if (!validfile)
                {
                    errorMessage = string.Format("Invalid file type. Valid file types are {0}", validfiletypes);
                    DisplayErrorMessage(errorMessage);
                    return;
                }

                if (fi.Extension == "jpeg" || fi.Extension == ".png" || fi.Extension == ".gif" || fi.Extension == ".jpg" || fi.Extension == ".ico")
                {
                    try
                    {
                        System.Drawing.Image img = System.Drawing.Image.FromStream(fileUpload.PostedFile.InputStream);
                    }
                    catch (Exception ex)
                    {
                        errorMessage = string.Format("Invalid image file");
                        DisplayErrorMessage(errorMessage);
                        return;
                    }
                }

                if (!Utils.IsValidUploadFile(fileUpload.PostedFile.InputStream))
                {
                    errorMessage = string.Format("Failed to validate file");
                    DisplayErrorMessage(errorMessage);
                    return;
                }

                FileManagerService.UploadFile(bucketName, FileManagerFiles.CurrentPath, filename, fileUpload.PostedFile.InputStream, out errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    DisplayErrorMessage(errorMessage);
                    return;
                }

                FileManagerFiles.LoadFolderFiles(FileManagerFiles.CurrentPath, FileManagerFiles.IsRoot, out errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    DisplayErrorMessage(errorMessage);
                }
                else
                {
                    DisplaySuccessMessage("Upload Completed");
                }

            }
        }

        protected void btnCreateFolderConfirm_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                char[] invalidchars = ("#<$+%>!`&*'|{?\"=}/:\\@").ToString().ToCharArray();
                foreach (char c in invalidchars)
                {
                    if (tbCreateFolder.Text.Contains(c))
                    {
                        string errormessage = "Folder name cannot contain any of the following characters # < $ + % > ! ` & * ' | { ? \" = } / : \\ @";
                        DisplayErrorMessage(errormessage);
                        return;
                    }
                }

                FileManagerFiles.CreateFolder(tbCreateFolder.Text);
                LoadCurrentFolders(FileManagerFiles.CurrentPath);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "JavascriptErrorMessage", @"
                <script type='text/javascript'>
                    $('#myModal5').hide();
                </script>", false);

            }
            else
            {
                ReregisterJS();
                DisplayErrorMessage("Folder name cannot contain any of the following characters # < $ + % > ! ` & * ' | { ? \" = } / : \\ @");
            }
        }


        [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
        private extern static System.UInt32 FindMimeFromData(
                System.UInt32 pBC,
                [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl,
                [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
                System.UInt32 cbSize,
                [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed,
                System.UInt32 dwMimeFlags,
                out System.UInt32 ppwzMimeOut,
                System.UInt32 dwReserverd
        );


        #region Events

        #endregion
    }
}