using System;
using System.Configuration;
using System.IO;
using System.Web.UI;
using JXTPortal.Common;
using log4net;
using System.Drawing;

namespace JXTPortal.Website.Admin
{
    public partial class GetAdminLogo : System.Web.UI.Page
    {
        private ILog _logger;

        public GetAdminLogo()
        {
            _logger = LogManager.GetLogger(typeof(GetAdminLogo));
        }

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
                if (site == null)
                    return;

                byte[] logo = RetrieveImage(site.SiteId, site.SiteAdminLogoUrl, site.SiteAdminLogo);

                if (logo == null)
                {
                    return;
                }

                string contentType = string.Empty;
                Image image = null;

                if (Utils.IsValidUploadImage("", logo, out image, out contentType))
                {
                    Response.ContentType = contentType;
                }
                else
                    Response.ContentType = "image/gif";

                Response.BinaryWrite(logo);
            }
        }

        private byte[] RetrieveImage(int siteId, string logoUrl, byte[] logo)
        {
            if (string.IsNullOrWhiteSpace(logoUrl))
                return logo;

            string errormessage = string.Empty;

            FtpClient ftpclient = new FtpClient();
            ftpclient.Host = ConfigurationManager.AppSettings["FTPHost"];
            ftpclient.Username = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
            ftpclient.Password = ConfigurationManager.AppSettings["FTPJobApplyPassword"];
            
            string filepath = string.Format("{0}{1}/{2}/{3}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["SitesFolder"], logoUrl);

            _logger.DebugFormat("Attempting to fetch logo for siteId {0}, from {1}", siteId, filepath);
            Stream ms = null;
            ftpclient.DownloadFileToClient(filepath, ref ms, out errormessage);
            
            if (!string.IsNullOrWhiteSpace(errormessage))
            {
                _logger.Error(errormessage);
                return null;
            }

            if (ms == null)
            {
                _logger.WarnFormat("Failed to download logo for siteId {0}", siteId);
                return null;
            }

            _logger.InfoFormat("Found logo for siteId {0}", siteId);
            ms.Position = 0;
            return ((MemoryStream)ms).ToArray();
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
