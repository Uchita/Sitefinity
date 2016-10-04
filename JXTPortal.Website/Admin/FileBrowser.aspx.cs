using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

namespace JXTPortal.Website.Admin
{
    public partial class FileBrowser : System.Web.UI.Page
    {
        #region Declaration

        private string FTPHostUrl = ConfigurationManager.AppSettings["FTPFileManager"];
        private string username = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
        private string password = ConfigurationManager.AppSettings["FTPJobApplyPassword"];

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
            get { return GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId)[0].FtpFolderLocation; }
        }

        private string UrlPrefix
        {
            get { return FTPHostUrl + GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId)[0].FtpFolderLocation + "/"; }
        }

        public string ImageFileTypes
        {
            get { return ConfigurationManager.AppSettings["ImageFileTypes"]; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionData.AdminUser == null)
            {
                Response.Redirect("/default.aspx");
            }

            if (!Page.IsPostBack)
            {
                LoadCurrentFolders();
            }

            bool isImageOnly = (Request.Params["type"] == "Image");
            FileManagerFiles.IsImageOnly = isImageOnly;
            FileManagerFiles.FileManagerFilesClicked += new UserControls.FileManagerFilesClickedHandler(FileManagerFiles_FileManagerFilesClicked);
        }

        void FileManagerFiles_FileManagerFilesClicked(string name, bool isDirectory, string errormessage)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "JavascriptUnblockUI", @"
               <script type='text/javascript'>
                    $(document).ready(function (e) {
            
            $('#image-browser div').hide();

            $('.droppable').click(function () {
                $('.droppable').removeClass('active');
                $(this).addClass('active');

                var fileurl = $(this).find('input[type=" + "\"hidden\"" + @"]').first().val();
                var parts = fileurl.split('/');
                $('#footer-row').find('input[type=" + "\"text\"" + @"]').first().val(fileurl);
                $('#file-display-info').val(parts[parts.length - 1]);
                $('#sidebar-insert').find('button').first().click(function () {
                    OpenFile(fileurl);
                });

                var extensions = imagefiletypes.split(',');
                var isImage = false;
                for (var i = 0; i < extensions.length; i++) {
                    var extension = extensions[i];

                    if (fileurl.length >= extension.length && fileurl.substr(fileurl.length - extension.length) == extension) {
                        isImage = true;
                        break;
                    }
                }

                if (isImage) {
                    $('#file-display-thumb').attr('src', fileurl);
                    $('#file-display-thumb').show();
                }
                else {
                    $('#file-display-thumb').hide();
                }

                $('#image-browser div').show();
            });
        });

                    $.unblockUI();
                </script>", false);
        }

        private void DisplayErrorMessage(string errormessage)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "JavascriptErrorMessage", string.Format(@"
                $.blockUI.defaults.blockMsgClass = 'blockUI-error';

                $('.modal-backdrop').hide();
                    $(document).ready(function (e) {

                        $.blockUI.defaults.blockMsgClass = 'blockUI-error';
                
                        $.blockUI({
                            onOverlayClick: $.unblockUI,
                            message: '<span>{0}</span>'
                        });
                    });
                </script>
                ", errormessage.Replace("'", "")), false);
        }

        private void LoadCurrentFolders()
        {
            string errormessage = string.Empty;
            FtpClient ftpclient = new FtpClient();
            ftpclient.Host = FTPHostUrl;
            ftpclient.Username = username;
            ftpclient.Password = password;


            if (ftpclient.DirectoryExists(FTPFolderLocation, out errormessage)) //Check if root directory exists
            {
                if (!string.IsNullOrEmpty(errormessage)) { DisplayErrorMessage(errormessage); return; }

                ftpclient.ChangeDirectory(FTPFolderLocation, out errormessage);
                List<FtpDirectoryEntry> filedirentrylist = ftpclient.ListDirectory(out errormessage);

                if (!string.IsNullOrEmpty(errormessage)) { DisplayErrorMessage(errormessage); return;  }

                ArrayList directorylist = new ArrayList();

                foreach (FtpDirectoryEntry entry in filedirentrylist)
                {
                    if (entry.IsDirectory)
                    {
                        directorylist.Add(entry);
                    }
                }


                FileManagerFiles.LoadFolderFiles(FTPFolderLocation, true, out errormessage); //Retrieve Root Files
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(FTPFolderLocation))
                {
                    // Create Directory
                    ftpclient.CreateDirectory(FTPFolderLocation, out errormessage);
                    if (!string.IsNullOrEmpty(errormessage)) { DisplayErrorMessage(errormessage); return; }
                    LoadCurrentFolders();
                }
                else
                {
                    // Display Error and disable everything
                }
            }
        }
    }
}