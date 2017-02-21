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
using JXTPortal.Common.Models;


namespace JXTPortal.Website.Admin
{
    public partial class S3FileBrowser : System.Web.UI.Page
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

        private string UrlPrefix
        {
            get { return FTPHostUrl + GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId)[0].FtpFolderLocation + "/"; }
        }

        public string ImageFileTypes
        {
            get { return ConfigurationManager.AppSettings["ImageFileTypes"]; }
        }

        public IFileManager FileManagerService { get; set; }
        static string bucketName = ConfigurationManager.AppSettings["AWSS3BucketName"];
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionData.AdminUser == null)
            {
                Response.Redirect("/default.aspx");
            }

            if (!Page.IsPostBack)
            {
                LoadCurrentFolders(FTPFolderLocation);
            }

            bool isImageOnly = (Request.Params["type"] == "Image");
            FileManagerFiles.IsImageOnly = isImageOnly;
            FileManagerFiles.FileManagerFilesClicked += new UserControls.S3FileManagerFilesClickedHandler(FileManagerFiles_FileManagerFilesClicked);
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

        private void LoadCurrentFolders(string folder)
        {
            string errorMessage = string.Empty;
            IEnumerable<FileManagerFile> files = FileManagerService.ListFiles(bucketName, FTPFolderLocation, out errorMessage);

            if (!string.IsNullOrEmpty(errorMessage)) { DisplayErrorMessage(errorMessage); return; }

            if (files.Count() == 0)
            {
                FileManagerService.CreateFolder(bucketName, FTPFolderLocation, out errorMessage);

                files = FileManagerService.ListFiles(bucketName, FTPFolderLocation, out errorMessage);
                if (!string.IsNullOrEmpty(errorMessage)) { DisplayErrorMessage(errorMessage); return; }
            }

            var directories = files.Where(x => x.FileName.Replace(FTPFolderLocation + "/", "").Split(new char[] { '/' }).Length > 1)
                                    .Select(x => x.FileName.Replace(FTPFolderLocation + "/", "").Split(new char[] { '/' })[0])
                                    .Distinct();

            FileManagerFiles.LoadFolderFiles(FTPFolderLocation, (folder == FTPFolderLocation), out errorMessage);
        }
    }
}