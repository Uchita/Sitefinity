using System;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Common;
using JXTPortal.Common.Models;
using JXTPortal.Entities;

namespace JXTPortal.Website.Admin.UserControls
{
    public delegate void S3FileManagerFilesClickedHandler(string name, bool isDirectory, string errormessage);

    public partial class S3FileManagerFiles : System.Web.UI.UserControl
    {

        private string FTPHostUrl = ConfigurationManager.AppSettings["FTPFileManager"];
        private string HTTPHostUrl = ConfigurationManager.AppSettings["HTTPFileManager"];
        private string ImageFileTypes = ConfigurationManager.AppSettings["ImageFileTypes"];
        private string clientFolder = ConfigurationManager.AppSettings["AWSS3ClientFolder"];

        #region Properties

        public event S3FileManagerFilesClickedHandler FileManagerFilesClicked;

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

        private SitesService _sitesservice;
        private SitesService SitesService
        {
            get
            {
                if (_sitesservice == null)
                {
                    _sitesservice = new SitesService();
                }
                return _sitesservice;
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

        private string SiteUrl
        {
            get { return SitesService.GetBySiteId(SessionData.Site.SiteId).SiteUrl; }
        }

        public string CurrentPath
        {
            get { return hfCurrentPath.Value; }
        }

        public bool IsRoot
        {
            get
            {
                bool _isRoot = true;
                if (!bool.TryParse(hfIsRoot.Value, out _isRoot))
                {
                    _isRoot = true;
                }
                return _isRoot;

            }
        }

        private bool _browserMode = false;
        public bool BrowserMode
        {
            get { return _browserMode; }
            set { _browserMode = value; }
        }

        private bool _isImageOnly = false;
        public bool IsImageOnly
        {
            set { _isImageOnly = value; }
        }

        public IFileManager FileManagerService { get; set; }
        static string bucketName = ConfigurationManager.AppSettings["AWSS3BucketName"];
        private static string DummyFileName = ConfigurationManager.AppSettings["AWSS3NullFileName"];
        private string _currentFolder = string.Empty;

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (BrowserMode)
            {
                file_browser1.Attributes.Remove("class");
                file_browser1.Attributes.Add("class", "span8");
            }
        }

        public void UploadFile(Stream stream, string filename)
        {
            string errorMessage = string.Empty;

            FileManagerService.UploadFile(bucketName, hfCurrentPath.Value, filename, stream, out errorMessage);
            if (string.IsNullOrEmpty(errorMessage))
            {
                LoadFolderFiles(hfCurrentPath.Value, Convert.ToBoolean(hfIsRoot.Value), out errorMessage);
            }

            if (FileManagerFilesClicked != null)
            {
                FileManagerFilesClicked(filename, Convert.ToBoolean(hfIsRoot.Value), errorMessage);

                if (string.IsNullOrEmpty(errorMessage))
                {
                    foreach (RepeaterItem item in rptFiles.Items)
                    {
                        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        {
                            LinkButton btnFileLink = item.FindControl("btnFileLink") as LinkButton;
                            HiddenField hfIsFolder = item.FindControl("hfIsFolder") as HiddenField;

                            if (HttpUtility.HtmlDecode(btnFileLink.Text) == filename && Convert.ToBoolean(hfIsFolder.Value) == false)
                            {
                                btnFileLink.Focus();
                                break;
                            }
                        }
                    }
                }

            }
        }

        public void MoveFile(string fromFolder, string fromFileName, string toFolder, string toFileName)
        {
            string errorMessage = string.Empty;

            foreach (RepeaterItem item in rptFiles.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    LinkButton btnFileLink = item.FindControl("btnFileLink") as LinkButton;
                    HiddenField hfIsFolder = item.FindControl("hfIsFolder") as HiddenField;

                    if (HttpUtility.HtmlDecode(btnFileLink.Text) == fromFileName)
                    {
                        FileManagerService.MoveObject(bucketName, fromFolder, fromFileName, toFolder, toFileName, out errorMessage);

                        break;
                    }

                }
            }


            if (FileManagerFilesClicked != null)
            {
                if (string.IsNullOrEmpty(errorMessage))
                {
                    LoadFolderFiles(hfCurrentPath.Value, Convert.ToBoolean(hfIsRoot.Value), out errorMessage);
                }

                FileManagerFilesClicked(toFileName, Convert.ToBoolean(hfIsRoot.Value), errorMessage);
            }
        }

        public void RenameFile(string fromFileName, string toFileName)
        {
            string errorMessage = string.Empty;
            string extension = new FileInfo(fromFileName).Extension;
            toFileName = toFileName + extension;

            if (fromFileName != toFileName)
            {
                foreach (RepeaterItem item in rptFiles.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        LinkButton btnFileLink = item.FindControl("btnFileLink") as LinkButton;
                        HiddenField hfIsFolder = item.FindControl("hfIsFolder") as HiddenField;


                        if (HttpUtility.HtmlDecode(btnFileLink.Text) == fromFileName && Convert.ToBoolean(hfIsFolder.Value) == false)
                        {
                            FileManagerService.MoveObject(bucketName, hfCurrentPath.Value, fromFileName, hfCurrentPath.Value, toFileName, out errorMessage);
                            if (string.IsNullOrEmpty(errorMessage))
                            {
                                LoadFolderFiles(hfCurrentPath.Value, Convert.ToBoolean(hfIsRoot.Value), out errorMessage);
                            }
                            break;
                        }
                    }
                }
            }


            if (FileManagerFilesClicked != null)
            {
                if (string.IsNullOrEmpty(errorMessage))
                {
                    LoadFolderFiles(hfCurrentPath.Value, Convert.ToBoolean(hfIsRoot.Value), out errorMessage);
                }

                FileManagerFilesClicked(toFileName, Convert.ToBoolean(hfIsRoot.Value), errorMessage);

                if (string.IsNullOrEmpty(errorMessage))
                {
                    foreach (RepeaterItem item in rptFiles.Items)
                    {
                        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        {
                            LinkButton btnFileLink = item.FindControl("btnFileLink") as LinkButton;
                            HiddenField hfIsFolder = item.FindControl("hfIsFolder") as HiddenField;

                            if (HttpUtility.HtmlDecode(btnFileLink.Text) == toFileName && Convert.ToBoolean(hfIsFolder.Value) == false)
                            {
                                btnFileLink.Focus();
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void CreateFolder(string newfoldername)
        {
            string errorMessage = string.Empty;

            FileManagerService.CreateFolder(bucketName, string.Format("{0}/{1}", hfCurrentPath.Value, newfoldername), out errorMessage);

            if (FileManagerFilesClicked != null)
            {
                FileManagerFilesClicked(FTPFolderLocation, true, errorMessage);
            }
        }

        public void RenameFolder(string originalfoldername, string newfoldername)
        {
            string errorMessage = string.Empty;

            FileManagerService.RenameFolder(bucketName, string.Format("{0}/{1}", hfCurrentPath.Value, originalfoldername), string.Format("{0}/{1}", hfCurrentPath.Value, newfoldername), out errorMessage);
            // LoadFolderFiles(hfCurrentPath.Value, Convert.ToBoolean(hfIsRoot.Value), out errorMessage);

            if (FileManagerFilesClicked != null)
            {
                if (string.IsNullOrEmpty(errorMessage))
                {
                    foreach (RepeaterItem item in rptFiles.Items)
                    {
                        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        {
                            LinkButton btnFileLink = item.FindControl("btnFileLink") as LinkButton;
                            HiddenField hfIsFolder = item.FindControl("hfIsFolder") as HiddenField;


                            if (HttpUtility.HtmlDecode(btnFileLink.Text) == newfoldername && Convert.ToBoolean(hfIsFolder.Value) == true)
                            {
                                btnFileLink.Focus();
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void DeleteFolder(string folderurl)
        {
            string errorMessage = string.Empty;

            foreach (RepeaterItem item in rptFiles.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    LinkButton btnFileLink = item.FindControl("btnFileLink") as LinkButton;
                    HiddenField hfIsFolder = item.FindControl("hfIsFolder") as HiddenField;

                    if (btnFileLink.CommandArgument == folderurl && Convert.ToBoolean(hfIsFolder.Value) == true)
                    {
                        FileManagerService.DeleteFolder(bucketName, string.Format("{0}/{1}", hfCurrentPath.Value, folderurl), out errorMessage);

                        break;
                    }
                }
            }

            if (FileManagerFilesClicked != null)
            {
                FileManagerFilesClicked(folderurl, true, errorMessage);
            }
        }

        public void OpenFolder(string folderurl)
        {
            string errormessage = string.Empty;

            foreach (RepeaterItem item in rptFiles.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    LinkButton btnFileLink = item.FindControl("btnFileLink") as LinkButton;
                    HiddenField hfIsFolder = item.FindControl("hfIsFolder") as HiddenField;

                    if (btnFileLink.CommandArgument == folderurl && Convert.ToBoolean(hfIsFolder.Value) == true)
                    {
                        LoadFolderFiles(FTPFolderLocation.TrimEnd(new char[] { '/' }) + "/" + btnFileLink.CommandArgument, false, out errormessage);

                        break;
                    }
                }
            }

            if (FileManagerFilesClicked != null)
            {
                FileManagerFilesClicked(folderurl, true, errormessage);
            }
        }

        public void DeleteFile(string fileurl)
        {
            string errorMessage = string.Empty;

            foreach (RepeaterItem item in rptFiles.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hfFileURL = item.FindControl("hfFileURL") as HiddenField;
                    LinkButton btnFileLink = item.FindControl("btnFileLink") as LinkButton;
                    HiddenField hfIsFolder = item.FindControl("hfIsFolder") as HiddenField;

                    if (hfFileURL.Value == fileurl && Convert.ToBoolean(hfIsFolder.Value) == false)
                    {
                        FileManagerService.DeleteFile(bucketName, hfCurrentPath.Value, HttpUtility.HtmlDecode(btnFileLink.Text), out errorMessage);
                        if (string.IsNullOrEmpty(errorMessage))
                        {
                            LoadFolderFiles(hfCurrentPath.Value, Convert.ToBoolean(hfIsRoot.Value), out errorMessage);
                        }
                        break;
                    }
                }
            }

            if (FileManagerFilesClicked != null)
            {
                FileManagerFilesClicked(string.Empty, false, errorMessage);
            }
        }

        public void DownloadFile(string fileurl)
        {
            string errorMessage = string.Empty;
            foreach (RepeaterItem item in rptFiles.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hfFileURL = item.FindControl("hfFileURL") as HiddenField;
                    LinkButton btnFileLink = item.FindControl("btnFileLink") as LinkButton;

                    if (hfFileURL.Value == fileurl)
                    {
                        Stream downloadedfile = FileManagerService.DownloadFile(bucketName, hfCurrentPath.Value, HttpUtility.HtmlDecode(btnFileLink.Text), out errorMessage);

                        if (string.IsNullOrEmpty(errorMessage))
                        {
                            if (downloadedfile != null && downloadedfile.Length > 0)
                            {
                                using (MemoryStream memory = new MemoryStream())
                                {
                                    downloadedfile.CopyTo(memory);
                                    byte[] bytes = memory.ToArray();
                                    this.Response.ContentType = "application/octet-stream";
                                    this.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.HtmlDecode(btnFileLink.Text));
                                    Response.OutputStream.Write(bytes, 0, bytes.Length);
                                    this.Response.End();
                                }
                            }
                        }


                        break;
                    }
                }
            }


            if (FileManagerFilesClicked != null)
            {
                FileManagerFilesClicked(string.Empty, false, errorMessage);
            }
        }

        public void LoadFolderFiles(string folder, bool isRoot, out string errorMessage)
        {
            rptFiles.DataSource = null;
            errorMessage = string.Empty;
            hfCurrentPath.Value = folder;
            hfIsRoot.Value = isRoot.ToString();

            List<FileManagerFile> files = FileManagerService.ListFiles(bucketName, folder, out errorMessage);

            var directories = files.Where(x => x.FileName.Replace(folder + "/", "").Split(new char[] { '/' }).Length > 1)
                                    .Select(x => new FileManagerFile { IsFolder = true, FolderName = x.FileName.Replace(folder + "/", "").Split(new char[] { '/' })[0], FileName = string.Empty })
                                    .Distinct(new FileManagerFileComparer());

            var folderfiles = files.Where(x => x.FileName.Replace(folder + "/", "").Split(new char[] { '/' }).Length == 1 && x.ShortFileName != DummyFileName);

            var allfiles = directories.Union(folderfiles).ToList();

            if (!isRoot)
            {
                allfiles.Insert(0, new FileManagerFile { IsFolder = true, FolderName = "..." });
            }

            if (allfiles.Count > 0)
            {
                rptFiles.DataSource = allfiles;
            }
            rptFiles.DataBind();
        }

        protected void rptFiles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltlDivClass = e.Item.FindControl("ltlDivClass") as Literal;
                LinkButton btnFileLink = e.Item.FindControl("btnFileLink") as LinkButton;

                Literal ltlModified = e.Item.FindControl("ltlModified") as Literal;
                Literal ltlSize = e.Item.FindControl("ltlSize") as Literal;
                HiddenField hfFileURL = e.Item.FindControl("hfFileURL") as HiddenField;
                HiddenField hfIsFolder = e.Item.FindControl("hfIsFolder") as HiddenField;

                Literal ltlExtension = e.Item.FindControl("ltlExtension") as Literal;

                FileManagerFile entry = e.Item.DataItem as FileManagerFile;
                string kind = "N/A";
                // ltlDivClass
                if (entry.IsFolder)
                {
                    if (entry.FolderName != "...")
                    {
                        ltlDivClass.Text = "<div class=\"non-droppable context2\">";
                    }
                    else
                    {
                        ltlDivClass.Text = "<div class=\"non-droppable\">";
                    }

                    btnFileLink.OnClientClick = "$.blockUI.defaults.blockMsgClass = 'blockUI-loading'; $.blockUI({ message: '<img src=images/ajax-loader.gif /><span>Loading...</span>' });";
                }
                else
                {
                    btnFileLink.Click -= btnFileLink_Click;
                    btnFileLink.Enabled = false;
                    ltlDivClass.Text = "<div class=\"droppable context3\">";
                    string[] extensions = ImageFileTypes.Split(new char[] { ',' });
                    foreach (string extension in extensions)
                    {
                        if (entry.ShortFileName.EndsWith(extension, StringComparison.CurrentCultureIgnoreCase))
                        {
                            ltlDivClass.Text = "<div class=\"droppable context1\">";
                            break;
                        }
                    }
                }

                // btnFileLink

                string linkclass = string.Empty;
                if (entry.IsFolder && entry.FolderName == "...")
                {
                    btnFileLink.CommandName = "folderup";
                    linkclass = "jxt-folder-up-file";
                    kind = string.Empty;
                }
                else if (entry.IsFolder)
                {
                    btnFileLink.CommandName = "folder";
                    btnFileLink.CommandArgument = entry.FolderName;
                    linkclass = "jxt-folder-file";
                    kind = "folder";
                }
                else
                {
                    linkclass = GetLinkClass(entry.ShortFileName);

                    if (entry.ShortFileName.EndsWith(".jpg", StringComparison.CurrentCultureIgnoreCase) || entry.ShortFileName.EndsWith(".jpeg", StringComparison.CurrentCultureIgnoreCase))
                    {
                        linkclass = "jxt-jpg-file";
                    }
                    if (entry.ShortFileName.EndsWith(".gif", StringComparison.CurrentCultureIgnoreCase))
                    {
                        linkclass = "jxt-gif-file";
                    }
                    else if (entry.ShortFileName.EndsWith(".png", StringComparison.CurrentCultureIgnoreCase))
                    {
                        linkclass = "jxt-png-file";
                    }
                    else if (entry.ShortFileName.EndsWith(".doc", StringComparison.CurrentCultureIgnoreCase) || entry.ShortFileName.EndsWith(".docx", StringComparison.CurrentCultureIgnoreCase))
                    {
                        linkclass = "jxt-doc-file";
                    }
                    else if (entry.ShortFileName.EndsWith(".xls", StringComparison.CurrentCultureIgnoreCase))
                    {
                        linkclass = "jxt-xls-file";
                    }
                    else if (entry.ShortFileName.EndsWith(".html", StringComparison.CurrentCultureIgnoreCase))
                    {
                        linkclass = "jxt-html-file";
                    }
                    else if (entry.ShortFileName.EndsWith(".pdf", StringComparison.CurrentCultureIgnoreCase))
                    {
                        linkclass = "jxt-pdf-file";
                    }
                    else if (entry.ShortFileName.EndsWith(".css", StringComparison.CurrentCultureIgnoreCase))
                    {
                        linkclass = "jxt-css-file";
                    }
                    else if (entry.ShortFileName.EndsWith(".mp3", StringComparison.CurrentCultureIgnoreCase) || entry.FileName.EndsWith(".wav", StringComparison.CurrentCultureIgnoreCase))
                    {
                        linkclass = "jxt-mp3-file";
                    }
                    else if (entry.ShortFileName.EndsWith(".avi", StringComparison.CurrentCultureIgnoreCase))
                    {
                        linkclass = "jxt-avi-file";
                    }
                    else if (entry.ShortFileName.EndsWith(".xml", StringComparison.CurrentCultureIgnoreCase))
                    {
                        linkclass = "jxt-xml-file";
                    }

                    btnFileLink.CommandName = "file";
                    btnFileLink.CommandArgument = entry.FileName;
                }

                btnFileLink.CssClass = linkclass;
                btnFileLink.Text = HttpUtility.HtmlEncode((entry.IsFolder) ? entry.FolderName : entry.ShortFileName);
                if (!entry.IsFolder)
                {
                    Uri uri = new Uri(FTPHostUrl);

                    hfFileURL.Value = string.Format("http://{0}{1}{2}/{3}", SiteUrl, uri.AbsolutePath, hfCurrentPath.Value, entry.ShortFileName);
                    ltlModified.Text = string.Format("{0} {1}", entry.LastModified.ToString(SessionData.Site.DateFormat), entry.LastModified.ToLongTimeString());
                }


                hfIsFolder.Value = entry.IsFolder.ToString();

                // ltlSize
                if (!entry.IsFolder)
                {
                    // ltlSize.Text = ((double)(entry.Size / 1024)).ToString("0.000") + "kb";
                    ltlSize.Text = GetSize(entry.Size);
                }
            }
        }

        private string GetLinkClass(string fileName)
        {
            string linkClass = "jxt-file-default";

            if (fileName.EndsWith(".jpg", StringComparison.CurrentCultureIgnoreCase) || fileName.EndsWith(".jpeg", StringComparison.CurrentCultureIgnoreCase))
            {
                linkClass = "jxt-jpg-file";
            }
            if (fileName.EndsWith(".gif", StringComparison.CurrentCultureIgnoreCase))
            {
                linkClass = "jxt-gif-file";
            }
            else if (fileName.EndsWith(".png", StringComparison.CurrentCultureIgnoreCase))
            {
                linkClass = "jxt-png-file";
            }
            else if (fileName.EndsWith(".doc", StringComparison.CurrentCultureIgnoreCase) || fileName.EndsWith(".docx", StringComparison.CurrentCultureIgnoreCase))
            {
                linkClass = "jxt-doc-file";
            }
            else if (fileName.EndsWith(".xls", StringComparison.CurrentCultureIgnoreCase))
            {
                linkClass = "jxt-xls-file";
            }
            else if (fileName.EndsWith(".html", StringComparison.CurrentCultureIgnoreCase))
            {
                linkClass = "jxt-html-file";
            }
            else if (fileName.EndsWith(".pdf", StringComparison.CurrentCultureIgnoreCase))
            {
                linkClass = "jxt-pdf-file";
            }
            else if (fileName.EndsWith(".css", StringComparison.CurrentCultureIgnoreCase))
            {
                linkClass = "jxt-css-file";
            }
            else if (fileName.EndsWith(".mp3", StringComparison.CurrentCultureIgnoreCase) || fileName.EndsWith(".wav", StringComparison.CurrentCultureIgnoreCase))
            {
                linkClass = "jxt-mp3-file";
            }
            else if (fileName.EndsWith(".avi", StringComparison.CurrentCultureIgnoreCase))
            {
                linkClass = "jxt-avi-file";
            }
            else if (fileName.EndsWith(".xml", StringComparison.CurrentCultureIgnoreCase))
            {
                linkClass = "jxt-xml-file";
            }

            return linkClass;
        }

        private string GetSize(long size)
        {
            double s = size;

            string[] format = new string[] { "{0} bytes", "{0} KB", "{0} MB", "{0} GB", "{0} TB", "{0} PB" };

            int i = 0;
            while (i < format.Length && s >= 1024)
            {
                s = (int)(100 * s / 1024) / 100.0;
                i++;
            }

            return string.Format(format[i], s);
        }

        protected void btnFileLink_Click(object sender, EventArgs e)
        {
            string errormessage = string.Empty;
            LinkButton btnFileLink = sender as LinkButton;

            if (btnFileLink.CommandName == "folderup")
            {
                string[] parts = hfCurrentPath.Value.Split(new char[] { '/' });

                LoadFolderFiles(string.Join("/", parts, 0, parts.Length - 1), (string.Join("/", parts.Take(parts.Length - 1)) == FTPFolderLocation), out errormessage); //Retrieve Root Files
            }
            else if (btnFileLink.CommandName == "folder")
            {
                LoadFolderFiles(hfCurrentPath.Value + "/" + btnFileLink.CommandArgument, false, out errormessage);
            }
            else if (btnFileLink.CommandName == "file")
            {

            }

            if (FileManagerFilesClicked != null)
            {
                FileManagerFilesClicked(btnFileLink.CommandArgument, (btnFileLink.CommandName != "file"), errormessage);
            }
        }
    }
}