using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JXTPortal.Common;

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
                if (site != null && site.SiteAdminLogo != null)
                {
                    //try
                    //{
                    //    System.Drawing.Image logo = System.Drawing.Image.FromStream(new System.IO.MemoryStream(site.SiteAdminLogo));
                    //    System.Drawing.Imaging.ImageFormat format = logo.RawFormat;

                    //    if (format == System.Drawing.Imaging.ImageFormat.Gif)
                    //    {
                    //        Response.ContentType = "image/gif";
                    //    }
                    //    else if (format == System.Drawing.Imaging.ImageFormat.Jpeg)
                    //    {
                    //        Response.ContentType = "image/jpeg";
                    //    }
                    //    else if (format == System.Drawing.Imaging.ImageFormat.Png)
                    //    {
                    //        Response.ContentType = "image/png";
                    //    }
                    //    else if (format == System.Drawing.Imaging.ImageFormat.Bmp)
                    //    {
                    //        Response.ContentType = "image/bmp";
                    //    }
                    //    else
                    //    {
                    //        Response.ContentType = "image/gif";
                    //    } 
                    //}
                    //catch { }
                    
                    System.Drawing.Image objOriginalImage = null;
                    string contenttype = string.Empty;

                    if (Utils.IsValidUploadImage("", site.SiteAdminLogo, out objOriginalImage, out contenttype))
                    {
                        // Response.Headers.Clear();
                        Response.ContentType = contenttype;
                    }
                    else
                        Response.ContentType = "image/gif";

                    //Response.Write(contenttype);
                    //Response.End();

                    Response.BinaryWrite(site.SiteAdminLogo);
                    //Response.End();
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
