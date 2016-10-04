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
    public partial class FileUpload : System.Web.UI.Page
    {
        #region Declaration

        private string FTPHostUrl = ConfigurationManager.AppSettings["FTPHostUrl"];
        private string HTTPHostUrl = ConfigurationManager.AppSettings["HTTPHostUrl"];
        private string username = ConfigurationManager.AppSettings["FTPUsername"];
        private string password = ConfigurationManager.AppSettings["FTPPassword"];
        private GlobalSettingsService _globalsettingsservice;

        #endregion

        #region Properties
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

        private string UrlPrefix
        {
            get { return FTPHostUrl + GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId)[0].FtpFolderLocation + "/"; }
        }
        #endregion

        #region Page

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.GetCurrent(this).RegisterPostBackControl(btnUpload);
            litMessage.Text = "";

            if (!Page.IsPostBack)
            {
                LoadCurrentFiles();
            }
        }

        #endregion

        #region Methods

        private void LoadCurrentFiles()
        {
            lbFile.Items.Clear();
            string errormsg = string.Empty;


            if (UrlPrefix == FTPHostUrl + "/")
            {
                errormsg = " File upload folder path has not been. Please update path and folder to fix the problem in <a href='GlobalSettingsEdit.aspx'>Site Global Settings</a>.";

                lblErrorMsg.Text = errormsg;
                lblErrorMsg.Visible = true;

                return;
            }
            FtpClient ftpclient = new FtpClient();
            ftpclient.Host = FTPHostUrl;
            ftpclient.Username = username;
            ftpclient.Password = password;

            List<FtpDirectoryEntry> dirs = ftpclient.ListDirectory(out errormsg);


            foreach (FtpDirectoryEntry fde in dirs)
            {
                if (!fde.IsDirectory)
                {
                    lbFile.Items.Add(new ListItem(fde.Name, fde.Name));
                }
            }

            if (!string.IsNullOrEmpty(errormsg))
            {
                lblErrorMsg.Text = errormsg;
                lblErrorMsg.Visible = true;
            }
            else
            {
                lblErrorMsg.Text = errormsg;
                lblErrorMsg.Visible = false;
            }
        }

        #endregion


        #region Events

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string[] fileparts = fuFile.PostedFile.FileName.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                string filename = fileparts[fileparts.Length - 1];

                string errormessage = string.Empty;
                FtpClient ftpclient = new FtpClient();
                ftpclient.Host = UrlPrefix;
                ftpclient.Username = username;
                ftpclient.Password = password;
                ftpclient.UploadFileFromStream(fuFile.PostedFile.InputStream, UrlPrefix + filename, out errormessage);
                if (string.IsNullOrEmpty(errormessage))
                    litMessage.Text = filename + " uploaded successfully";
                else
                    litMessage.Text = errormessage;
                LoadCurrentFiles();
            }
        }

        protected void cvalDocument_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (fuFile.PostedFile == null || fuFile.PostedFile.ContentLength == 0)
            {
                args.IsValid = false;
                this.cvalDocument.ErrorMessage = " Please ensure you have selected a document to upload";
            }
            else
            {
                args.IsValid = true;
            }

        }

        #endregion
    }
}
