using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Common;
using JXTPortal.Entities;
using System.Configuration;

namespace JXTPortal.Website
{
    public partial class FTPFile : System.Web.UI.Page
    {
        #region Declaration

        private string FTPHostUrl = ConfigurationManager.AppSettings["FTPHostUrl"];
        private string HTTPHostUrl = ConfigurationManager.AppSettings["HTTPHostUrl"];
        private string username = ConfigurationManager.AppSettings["FTPUsername"];
        private string password = ConfigurationManager.AppSettings["FTPPassword"];
        private string _command = "";
        private string _filename = "";
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

        private string HTTPUrlPrefix
        {
            get { return HTTPHostUrl + GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId)[0].FtpFolderLocation + "/"; }
        }

        protected string Command
        {
            get
            {
                if ((Request.QueryString["Command"] != null))
                {
                    _command = Request.QueryString["Command"];

                    return _command;
                }

                return _command;
            }
        }

        protected string FileName
        {
            get
            {
                if ((Request.QueryString["FileName"] != null))
                {
                    _filename = Request.QueryString["FileName"];

                    return _filename;
                }

                return _filename;
            }
        }

        #endregion

        #region Page

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Command == "List")
            {
                LoadDiretory();
            }
            else if (Command == "Select")
            {
                SelectFile();
            }
            else if (Command == "Delete")
            {
                DeleteFile();
            }
        }

        #endregion

        #region Methods

        private void LoadDiretory()
        {
            Response.ClearHeaders();
            Response.Clear();
            Response.ContentType = "text/xml";
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            Response.Write("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            Response.Write("<files>");
            FileStruct[] fss = FtpHelpers.GetFileList(UrlPrefix, username, password);
            if (fss.Length > 0)
            {
                foreach (FileStruct fs in fss)
                {
                    Response.Write(string.Format("<file>{0}</file>", fs.Name));
                }
            }
            else
            {
                Response.Write("<file />");
            }

            Response.Write("</files>");
            Response.End();
        }

        private void SelectFile()
        {
            Response.ClearHeaders();
            Response.Clear();
            Response.ContentType = "text/xml";
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            Response.Write("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            Response.Write("<result>");
            string strFileName = FileName.ToLower();
            bool isImage = false;
            if (strFileName.EndsWith(".jpeg") || strFileName.EndsWith(".jpg") || strFileName.EndsWith(".gif") || strFileName.EndsWith(".png") || strFileName.EndsWith(".bmp"))
            {
                isImage = true;
            }
            if (isImage)
            {
                Response.Write(string.Format("<link><img src='{0}' /></link>", HTTPUrlPrefix + FileName));
            }
            else
            {
                Response.Write(string.Format("<link><a href='{0}' /></link>", HTTPUrlPrefix + FileName));
            }

            Response.Write("</result>");
            Response.End();
        }

        private void DeleteFile()
        {
            Response.ClearHeaders();
            Response.Clear();
            Response.ContentType = "text/xml";
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            Response.Write("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            Response.Write("<result>");
            if (!string.IsNullOrEmpty(FileName))
            {
                if (FtpHelpers.DeleteFile(UrlPrefix + FileName, username, password))
                {
                    Response.Write("<message>Success</message>");
                }
                else
                {
                    Response.Write("<message>Failed</message>");
                }
            }
            else
            {
                Response.Write("<message>Failed</message>");
            }

            Response.Write("</result>");
            Response.End();
        }

        #endregion
    }
}
