using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JXTPortal.Common;
using System.Configuration;
using System.IO;

namespace JXTPortal.Website.Admin
{
    public partial class GetAdminLogo : System.Web.UI.Page
    {
        // ToDo - Move to Root - And do caching
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CreateImage();
        }

        
        private int SiteID
        {
            get { 
                int _siteID = 1;

                // IMPORTANT = For the PDF's to work
                if (Request.QueryString["SiteID"] != null && !JXTPortal.Entities.SessionData.Site.SiteUrl.Contains(".jxt1.com"))
                {
                    if (int.TryParse(Request.QueryString["SiteID"], out _siteID))
                    {
                        _siteID = Convert.ToInt32(Request.QueryString["SiteID"]);
                    }
                    else
                        Response.End();
                }
                else
                    _siteID = JXTPortal.Entities.SessionData.Site.SiteId;
                return _siteID;
            }
        }

        private void CreateImage()
        {
            using (JXTPortal.Entities.Sites site = SitesService.GetBySiteId(SiteID)) //SiteID
            {
                if (site != null && (string.IsNullOrWhiteSpace(site.SiteAdminLogoUrl) == false || site.SiteAdminLogo != null))
                {
                    
                    System.Drawing.Image objOriginalImage = null;
                    string contenttype = string.Empty;

                    byte[] siteadminlogo = null;

                    if (!string.IsNullOrWhiteSpace(site.SiteAdminLogoUrl))
                    {
                        string errormessage = string.Empty;

                        FtpClient ftpclient = new FtpClient();
                        ftpclient.Host = ConfigurationManager.AppSettings["FTPHost"];
                        ftpclient.Username = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                        ftpclient.Password = ConfigurationManager.AppSettings["FTPJobApplyPassword"];

                        string filepath = string.Format("{0}{1}/{2}/{3}/{4}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["SitesFolder"], site.SiteId, site.SiteAdminLogoUrl);
                        Stream ms = null;
                        ftpclient.DownloadFileToClient(filepath, ref ms, out errormessage);
                        ms.Position = 0;

                        siteadminlogo = ((MemoryStream)ms).ToArray();
                    }
                    else
                    {
                        siteadminlogo = site.SiteAdminLogo;
                    }

                    if (Utils.IsValidUploadImage("", siteadminlogo, out objOriginalImage, out contenttype))
                    {
                        Response.ContentType = contenttype;
                    }
                    else
                        Response.ContentType = "image/gif";


                    Response.BinaryWrite(siteadminlogo);
                }
            }

        }

        #region Properties

        private SitesService _sitesService;

        private SitesService SitesService
        {
            get
            {
                if (_sitesService == null)
                {
                    _sitesService = new SitesService();
                }
                return _sitesService;
            }
        }


        #endregion
    }
}
