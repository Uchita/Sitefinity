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
using JXTPortal.Entities;

namespace JXTPortal.Website.Admin.UserControls
{
    public delegate void FileManagerFilesClickedHandler(string name, bool isDirectory, string errormessage);

    public partial class FileManagerFiles : System.Web.UI.UserControl
    {

        private string FTPHostUrl = ConfigurationManager.AppSettings["FTPFileManager"];
        private string username = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
        private string password = ConfigurationManager.AppSettings["FTPJobApplyPassword"];
        private string HTTPHostUrl = ConfigurationManager.AppSettings["HTTPFileManager"];
        private string ImageFileTypes = ConfigurationManager.AppSettings["ImageFileTypes"];


        #region Properties

        public event FileManagerFilesClickedHandler FileManagerFilesClicked;

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
            get { return SessionData.Site.FileFolderLocation; }
        }

        private string SiteUrl
        {
            get { return SitesService.GetBySiteId(SessionData.Site.SiteId).SiteUrl; }
        }

        private string UrlPrefix
        {
            get { return FTPHostUrl + GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId)[0].FtpFolderLocation + "/"; }
        }

        public string CurrentPath
        {
            get { return hfCurrentPath.Value; }
        }

        public bool IsRoot
        {
            get { 
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
            string errormessage = string.Empty;
            FtpClient ftpclient = new FtpClient();
            ftpclient.Host = FTPHostUrl;
            ftpclient.Username = username;
            ftpclient.Password = password;

            ftpclient.ChangeDirectory(hfCurrentPath.Value, out errormessage);
            if (string.IsNullOrEmpty(errormessage))
            {

                string fullpath = string.Format("{0}{1}/{2}", FTPHostUrl, hfCurrentPath.Value, filename);
                ftpclient.UploadFileFromStream(stream, fullpath, out errormessage);
                if (string.IsNullOrEmpty(errormessage))
                {
                    LoadFolderFiles(hfCurrentPath.Value, Convert.ToBoolean(hfIsRoot.Value), out errormessage);
                }
            }

            if (FileManagerFilesClicked != null)
            {
                FileManagerFilesClicked(filename, Convert.ToBoolean(hfIsRoot.Value), errormessage);

                if (string.IsNullOrEmpty(errormessage))
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

        public void MoveFile(string originalfilename, string newfilename)
        {
            string errormessage = string.Empty;

            foreach (RepeaterItem item in rptFiles.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    LinkButton btnFileLink = item.FindControl("btnFileLink") as LinkButton;
                    HiddenField hfIsFolder = item.FindControl("hfIsFolder") as HiddenField;

                    string[] parts = originalfilename.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                    if (HttpUtility.HtmlDecode(btnFileLink.Text) == parts[parts.Length - 1])
                    {
                        FtpClient ftpclient = new FtpClient();
                        ftpclient.Host = FTPHostUrl;
                        ftpclient.Username = username;
                        ftpclient.Password = password;

                        Uri uri = new Uri(ftpclient.Host);

                        ftpclient.MoveFile(string.Format("{0}/{1}", uri.LocalPath, originalfilename), string.Format("{0}/{1}", uri.LocalPath, newfilename), out errormessage);
                        break;
                    }

                }
            }


            if (FileManagerFilesClicked != null)
            {
                if (string.IsNullOrEmpty(errormessage))
                {
                    LoadFolderFiles(hfCurrentPath.Value, Convert.ToBoolean(hfIsRoot.Value), out errormessage);
                }

                FileManagerFilesClicked(newfilename, Convert.ToBoolean(hfIsRoot.Value), errormessage);
            }
        }

        public void RenameFile(string originalfilename, string newfilename)
        {
            string errormessage = string.Empty;

            string extension = new FileInfo(originalfilename).Extension;

            if (originalfilename.Replace(extension, string.Empty) != newfilename)
            {

                foreach (RepeaterItem item in rptFiles.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        LinkButton btnFileLink = item.FindControl("btnFileLink") as LinkButton;
                        HiddenField hfIsFolder = item.FindControl("hfIsFolder") as HiddenField;


                        if (HttpUtility.HtmlDecode(btnFileLink.Text) == originalfilename && Convert.ToBoolean(hfIsFolder.Value) == false)
                        {
                            FtpClient ftpclient = new FtpClient();
                            ftpclient.Host = FTPHostUrl;
                            ftpclient.Username = username;
                            ftpclient.Password = password;
                            ftpclient.ChangeDirectory(hfCurrentPath.Value, out errormessage);
                            if (string.IsNullOrEmpty(errormessage))
                            {

                                ftpclient.RenameFile(originalfilename, ref newfilename, out errormessage);
                            }
                            break;
                        }
                    }
                }
            }


            if (FileManagerFilesClicked != null)
            {
                if (string.IsNullOrEmpty(errormessage))
                {
                    LoadFolderFiles(hfCurrentPath.Value, Convert.ToBoolean(hfIsRoot.Value), out errormessage);
                }

                FileManagerFilesClicked(newfilename, Convert.ToBoolean(hfIsRoot.Value), errormessage);

                if (string.IsNullOrEmpty(errormessage))
                {
                    foreach (RepeaterItem item in rptFiles.Items)
                    {
                        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        {
                            LinkButton btnFileLink = item.FindControl("btnFileLink") as LinkButton;
                            HiddenField hfIsFolder = item.FindControl("hfIsFolder") as HiddenField;

                            if (HttpUtility.HtmlDecode(btnFileLink.Text) == newfilename && Convert.ToBoolean(hfIsFolder.Value) == false)
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
            string errormessage = string.Empty;
            FtpClient ftpclient = new FtpClient();
            ftpclient.Host = FTPHostUrl;
            ftpclient.Username = username;
            ftpclient.Password = password;
            ftpclient.ChangeDirectory(FTPFolderLocation, out errormessage);
            if (string.IsNullOrEmpty(errormessage))
            {
                ftpclient.CreateDirectory(newfoldername, out errormessage);
                if (string.IsNullOrEmpty(errormessage))
                {
                    LoadFolderFiles(FTPFolderLocation, true, out errormessage);
                }
            }

            if (FileManagerFilesClicked != null)
            {
                FileManagerFilesClicked(FTPFolderLocation, true, errormessage);
            }
        }

        public void RenameFolder(string originalfoldername, string newfoldername)
        {
            string errormessage = string.Empty;

            foreach (RepeaterItem item in rptFiles.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    LinkButton btnFileLink = item.FindControl("btnFileLink") as LinkButton;
                    HiddenField hfIsFolder = item.FindControl("hfIsFolder") as HiddenField;


                    if (HttpUtility.HtmlDecode(btnFileLink.Text) == originalfoldername && Convert.ToBoolean(hfIsFolder.Value) == true)
                    {
                        FtpClient ftpclient = new FtpClient();
                        ftpclient.Host = FTPHostUrl;
                        ftpclient.Username = username;
                        ftpclient.Password = password;
                        ftpclient.ChangeDirectory(hfCurrentPath.Value, out errormessage);
                        if (string.IsNullOrEmpty(errormessage))
                        {
                            ftpclient.RenameFolder(originalfoldername, ref newfoldername, out errormessage);
                        }

                        break;
                    }
                }
            }

            if (FileManagerFilesClicked != null)
            {
                LoadFolderFiles(hfCurrentPath.Value, Convert.ToBoolean(hfIsRoot.Value), out errormessage);
                FileManagerFilesClicked(newfoldername, Convert.ToBoolean(hfIsRoot.Value), errormessage);
                if (string.IsNullOrEmpty(errormessage))
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
            string errormessage = string.Empty;

            foreach (RepeaterItem item in rptFiles.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    LinkButton btnFileLink = item.FindControl("btnFileLink") as LinkButton;
                    HiddenField hfIsFolder = item.FindControl("hfIsFolder") as HiddenField;

                    if (btnFileLink.CommandArgument == folderurl && Convert.ToBoolean(hfIsFolder.Value) == true)
                    {
                        FtpClient ftpclient = new FtpClient();
                        ftpclient.Host = FTPHostUrl;
                        ftpclient.Username = username;
                        ftpclient.Password = password;
                        ftpclient.ChangeDirectory(hfCurrentPath.Value, out errormessage);
                        if (string.IsNullOrEmpty(errormessage))
                        {
                            ftpclient.DeleteDirectory(btnFileLink.CommandArgument, out errormessage);
                            if (string.IsNullOrEmpty(errormessage))
                            {
                                LoadFolderFiles(hfCurrentPath.Value, true, out errormessage);
                            }
                        }
                        break;
                    }
                }
            }

            if (FileManagerFilesClicked != null)
            {
                FileManagerFilesClicked(folderurl, true, errormessage);
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
                        FtpClient ftpclient = new FtpClient();
                        ftpclient.Host = FTPHostUrl;
                        ftpclient.Username = username;
                        ftpclient.Password = password;
                        ftpclient.ChangeDirectory(hfCurrentPath.Value, out errormessage);
                        if (string.IsNullOrEmpty(errormessage))
                        {

                            LoadFolderFiles(FTPFolderLocation.TrimEnd(new char[] { '/' }) + "/" + btnFileLink.CommandArgument, false, out errormessage);
                        }
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
            string errormessage = string.Empty;

            foreach (RepeaterItem item in rptFiles.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hfFileURL = item.FindControl("hfFileURL") as HiddenField;
                    LinkButton btnFileLink = item.FindControl("btnFileLink") as LinkButton;
                    HiddenField hfIsFolder = item.FindControl("hfIsFolder") as HiddenField;

                    if (hfFileURL.Value == fileurl && Convert.ToBoolean(hfIsFolder.Value) == false)
                    {
                        FtpClient ftpclient = new FtpClient();
                        ftpclient.Host = FTPHostUrl;
                        ftpclient.Username = username;
                        ftpclient.Password = password;
                        ftpclient.ChangeDirectory(hfCurrentPath.Value, out errormessage);
                        if (string.IsNullOrEmpty(errormessage))
                        {
                            ftpclient.DeleteFiles(out errormessage, new string[] { HttpUtility.HtmlDecode(btnFileLink.Text) });
                            if (string.IsNullOrEmpty(errormessage))
                            {
                                LoadFolderFiles(hfCurrentPath.Value, Convert.ToBoolean(hfIsRoot.Value), out errormessage);
                            }
                        }
                        break;
                    }
                }
            }

            if (FileManagerFilesClicked != null)
            {
                FileManagerFilesClicked(string.Empty, false, errormessage);
            }
        }

        public void DownloadFile(string fileurl)
        {
            string errormessage = string.Empty;
            foreach (RepeaterItem item in rptFiles.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hfFileURL = item.FindControl("hfFileURL") as HiddenField;
                    LinkButton btnFileLink = item.FindControl("btnFileLink") as LinkButton;

                    if (hfFileURL.Value == fileurl)
                    {
                        FtpClient ftpclient = new FtpClient();
                        ftpclient.Host = FTPHostUrl;
                        ftpclient.Username = username;
                        ftpclient.Password = password;
                        ftpclient.ChangeDirectory(hfCurrentPath.Value, out errormessage);
                        if (string.IsNullOrEmpty(errormessage))
                        {
                            Stream downloadedfile = null;
                            ftpclient.DownloadFileToClient(string.Format("{0}{1}/{2}", FTPHostUrl, hfCurrentPath.Value, HttpUtility.HtmlDecode(btnFileLink.Text)), ref downloadedfile, out errormessage);
                            if (string.IsNullOrEmpty(errormessage))
                            {
                                downloadedfile.Position = 0;

                                if (downloadedfile != null && downloadedfile.Length > 0)
                                {
                                    this.Response.ContentType = "application/octet-stream";
                                    this.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.HtmlDecode(btnFileLink.Text));
                                    this.Response.BinaryWrite(((MemoryStream)downloadedfile).ToArray());
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
                FileManagerFilesClicked(string.Empty, false, errormessage);
            }
        }

        public void LoadFolderFiles(string dir, bool isRoot, out string errormessage)
        {
            errormessage = string.Empty;

            FtpClient ftpclient = new FtpClient();
            ftpclient.Host = FTPHostUrl;
            ftpclient.Username = username;
            ftpclient.Password = password;
            ftpclient.ChangeDirectory(dir, out errormessage);

            if (string.IsNullOrEmpty(errormessage))
            {
                hfCurrentPath.Value = dir;
                hfIsRoot.Value = isRoot.ToString(); ;
                List<FtpDirectoryEntry> ftpdirentrylist = ftpclient.ListDirectory(out errormessage);
                if (string.IsNullOrEmpty(errormessage))
                {
                    ArrayList dirlist = new ArrayList();

                    FtpDirectoryEntryComparer comparer = new FtpDirectoryEntryComparer();
                    ftpdirentrylist.Sort(comparer);
                    rptFiles.DataSource = null;

                    if (!isRoot)
                    {
                        // Insert Back to root level
                        FtpDirectoryEntry rootdir = new FtpDirectoryEntry();
                        rootdir.Name = "...";
                        rootdir.IsDirectory = true;

                        dirlist.Add(rootdir);
                    }

                    foreach (FtpDirectoryEntry ftpdirentry in ftpdirentrylist)
                    {
                        if (!isRoot && ftpdirentry.IsDirectory) // Only allow 1 level
                        {
                            continue;
                        }
                        else
                        {
                            if (!_isImageOnly)
                            {
                                _isImageOnly = (Request.Params["type"] == "Image");
                            }

                            if (_isImageOnly && ftpdirentry.IsDirectory == false)
                            {
                                string[] imagefiletypes = ImageFileTypes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                                bool isImage = false;
                                foreach (string imagetype in imagefiletypes)
                                {
                                    if (ftpdirentry.Name.EndsWith(imagetype, StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        isImage = true;
                                        break;
                                    }
                                }

                                if (!isImage)
                                {
                                    continue;
                                }
                            }

                            dirlist.Add(ftpdirentry);
                        }
                    }

                    if (dirlist.Count > 0)
                    {
                        rptFiles.DataSource = dirlist;
                    }
                    rptFiles.DataBind();
                }
            }
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

                FtpDirectoryEntry entry = e.Item.DataItem as FtpDirectoryEntry;
                string kind = "N/A";
                // ltlDivClass
                if (entry.IsDirectory)
                {
                    if (entry.Name != "...")
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
                        if (entry.Name.EndsWith(extension, StringComparison.CurrentCultureIgnoreCase))
                        {
                            ltlDivClass.Text = "<div class=\"droppable context1\">";
                            break;
                        }
                    }
                }

                // btnFileLink

                string linkclass = string.Empty;
                if (entry.IsDirectory && entry.Name == "...")
                {
                    btnFileLink.CommandName = "folderup";
                    linkclass = "jxt-folder-up-file";
                    kind = string.Empty;
                }
                else if (entry.IsDirectory)
                {
                    btnFileLink.CommandName = "folder";
                    btnFileLink.CommandArgument = entry.Name;
                    linkclass = "jxt-folder-file";
                    kind = "folder";
                }
                else
                {
                    linkclass = "jxt-file-default";

                    if (entry.Name.EndsWith(".jpg", StringComparison.CurrentCultureIgnoreCase) || entry.Name.EndsWith(".jpeg", StringComparison.CurrentCultureIgnoreCase))
                    {
                        linkclass = "jxt-jpg-file";
                        kind = "jpg";
                    }
                    if (entry.Name.EndsWith(".gif", StringComparison.CurrentCultureIgnoreCase))
                    {
                        linkclass = "jxt-gif-file";
                        kind = "gif";
                    }
                    else if (entry.Name.EndsWith(".png", StringComparison.CurrentCultureIgnoreCase))
                    {
                        linkclass = "jxt-png-file";
                        kind = "png";
                    }
                    else if (entry.Name.EndsWith(".doc", StringComparison.CurrentCultureIgnoreCase) || entry.Name.EndsWith(".docx", StringComparison.CurrentCultureIgnoreCase))
                    {
                        linkclass = "jxt-doc-file";
                        kind = "document";
                    }
                    else if (entry.Name.EndsWith(".xls", StringComparison.CurrentCultureIgnoreCase))
                    {
                        linkclass = "jxt-xls-file";
                        kind = "excel";
                    }
                    else if (entry.Name.EndsWith(".html", StringComparison.CurrentCultureIgnoreCase))
                    {
                        linkclass = "jxt-html-file";
                        kind = "html";
                    }
                    else if (entry.Name.EndsWith(".pdf", StringComparison.CurrentCultureIgnoreCase))
                    {
                        linkclass = "jxt-pdf-file";
                        kind = "pdf";
                    }
                    else if (entry.Name.EndsWith(".css", StringComparison.CurrentCultureIgnoreCase))
                    {
                        linkclass = "jxt-css-file";
                        kind = "css";
                    }
                    else if (entry.Name.EndsWith(".mp3", StringComparison.CurrentCultureIgnoreCase) || entry.Name.EndsWith(".wav", StringComparison.CurrentCultureIgnoreCase))
                    {
                        linkclass = "jxt-mp3-file";
                        kind = "mp3";
                    }
                    else if (entry.Name.EndsWith(".avi", StringComparison.CurrentCultureIgnoreCase))
                    {
                        linkclass = "jxt-avi-file";
                        kind = "avi";
                    }
                    else if (entry.Name.EndsWith(".xml", StringComparison.CurrentCultureIgnoreCase))
                    {
                        linkclass = "jxt-xml-file";
                        kind = "xml";
                    }

                    kind = new FileInfo(entry.Name).Extension.TrimStart(new char[] { '.' }).ToLower();
                    btnFileLink.CommandName = "file";
                    btnFileLink.CommandArgument = entry.Name;
                }

                btnFileLink.CssClass = linkclass;
                btnFileLink.Text = HttpUtility.HtmlEncode(entry.Name);
                if (!entry.IsDirectory)
                {
                    Uri uri = new Uri(FTPHostUrl);

                    hfFileURL.Value = string.Format("//{0}{1}{2}/{3}", SiteUrl, uri.AbsolutePath, hfCurrentPath.Value, entry.Name);
                }

                // ltlModified
                if (entry.Name != "..." && !entry.IsDirectory)
                {
                    string errormessage = string.Empty;
                    FtpClient ftpclient = new FtpClient();
                    ftpclient.Host = FTPHostUrl;
                    ftpclient.Username = username;
                    ftpclient.Password = password;
                    ftpclient.ChangeDirectory(hfCurrentPath.Value, out errormessage);

                    DateTime? lastmodified = ftpclient.GetDateTimestamp(btnFileLink.CommandArgument, out errormessage);

                    if (lastmodified.HasValue)
                    {
                        ltlModified.Text = string.Format("{0} {1}", lastmodified.Value.ToString(SessionData.Site.DateFormat), lastmodified.Value.ToLongTimeString());
                    }
                }
                hfIsFolder.Value = entry.IsDirectory.ToString();

                // ltlSize
                if (!entry.IsDirectory)
                {
                    // ltlSize.Text = ((double)(entry.Size / 1024)).ToString("0.000") + "kb";
                    ltlSize.Text = GetSize(entry.Size);
                }
            }
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
                LoadFolderFiles(FTPFolderLocation, true, out errormessage); //Retrieve Root Files
            }
            else if (btnFileLink.CommandName == "folder")
            {
                LoadFolderFiles(FTPFolderLocation.TrimEnd(new char[] { '/' }) + "/" + btnFileLink.CommandArgument, false, out errormessage);
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