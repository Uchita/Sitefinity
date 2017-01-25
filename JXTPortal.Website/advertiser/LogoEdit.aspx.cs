using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.IO;
using JXTPortal.Common;
using JXTPortal.Common.Extensions;
using System.Configuration;

namespace JXTPortal.Website.advertiser
{
    public partial class LogoEdit : System.Web.UI.Page
    {
        #region Declarations

        private byte[] _abytFile;
        AdvertisersService _AdvertisersService;

        #endregion

        #region Properties

        AdvertisersService AdvertisersService
        {
            get
            {
                if (_AdvertisersService == null)
                {
                    _AdvertisersService = new AdvertisersService();
                }

                return _AdvertisersService;
            }
        }

        #endregion

        #region Page Load

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Advertiser Logo");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionData.AdvertiserUser == null)
            {
                Response.Redirect("login.aspx?ReturnURL=logoedit.aspx");
            }

            if (!Page.IsPostBack)
            {
                LoadLogo();
            }

            SetFormValues();
        }

        #endregion

        #region Functions

        private void LoadLogo()
        {
            using (JXTPortal.Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(SessionData.AdvertiserUser.AdvertiserId))
            {
                if (string.IsNullOrWhiteSpace(advertiser.AdvertiserLogoUrl))
                {
                    if (advertiser.AdvertiserLogo != null)
                    {
                        lblNoLogo.Visible = false;

                        imgLogo.ImageUrl = string.Format("{0}?advertiserid={1}&ver={2}", Page.ResolveUrl("~/getfile.aspx"), Convert.ToString(advertiser.AdvertiserId), advertiser.LastModified.ToEpocTimestamp());

                    }
                }
                else
                {
                    lblNoLogo.Visible = false;

                    imgLogo.ImageUrl = string.Format("/media/{0}/{1}?ver={2}", ConfigurationManager.AppSettings["AdvertisersFolder"], advertiser.AdvertiserLogoUrl, advertiser.LastModified.ToEpocTimestamp());
                }
            }
        }

        private byte[] getArray(HttpPostedFile f)
        {
            int i = 0;
            byte[] b = new byte[f.ContentLength];

            f.InputStream.Read(b, 0, f.ContentLength);

            return b;
        }

        #endregion

        #region Events

        protected void cvalFileName_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            string strExt = Path.GetExtension(docInput.PostedFile.FileName).Trim();

            switch (strExt.ToUpper().Trim())
            {
                case ".GIF":
                case ".JPG":
                case ".JPEG":
                case ".PNG":
                    args.IsValid = true;
                    break;
                default:
                    args.IsValid = false;

                    break;
            }
        }

        protected void cvalFile_ServerValidate(System.Object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if ((this.docInput.PostedFile != null) && !string.IsNullOrEmpty(this.docInput.PostedFile.FileName))
            {
                if (docInput.PostedFile.ContentLength == 0)
                {
                    this.cvalFile.ErrorMessage = "The image uploaded has an invalid size. Please check the image and try again.";
                    args.IsValid = false;

                }
                else if ((docInput.PostedFile.ContentLength / (Math.Pow(1024, 2))) > 1)
                {
                    this.cvalFile.ErrorMessage = "The image uploaded exceeds the maximum 1Mb limit.";
                    args.IsValid = false;

                }
                else
                {
                    args.IsValid = true;
                }
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (JXTPortal.Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(SessionData.AdvertiserUser.AdvertiserId))
                {
                    if ((docInput.PostedFile != null) && docInput.PostedFile.ContentLength > 0)
                    {
                        System.IO.MemoryStream objInputMemoryStream = new System.IO.MemoryStream(this.getArray(this.docInput.PostedFile));
                        System.Drawing.Image objOriginalImage = System.Drawing.Image.FromStream(objInputMemoryStream);
                        //System.Drawing.Image objResizedImage = JXTPortal.Common.Utils.ResizeImage(objOriginalImage, PortalConstants.THUMBNAIL_WIDTH, PortalConstants.THUMBNAIL_HEIGHT);

                        System.IO.MemoryStream objOutputMemorySTream = new System.IO.MemoryStream();
                        objOriginalImage.Save(objOutputMemorySTream, objOriginalImage.RawFormat);

                        byte[] abytFile = new byte[Convert.ToInt32(objOutputMemorySTream.Length)];
                        objOutputMemorySTream.Position = 0;
                        objOutputMemorySTream.Read(abytFile, 0, abytFile.Length);

                        FtpClient ftpclient = new FtpClient();
                        string errormessage = string.Empty;
                        string extension = Utils.GetImageExtension(objOriginalImage);
                        ftpclient.Host = ConfigurationManager.AppSettings["FTPFileManager"];
                        ftpclient.Username = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                        ftpclient.Password = ConfigurationManager.AppSettings["FTPJobApplyPassword"];
                        ftpclient.UploadFileFromStream(objOutputMemorySTream, string.Format("{0}/{1}/Advertisers_{2}.{3}", ftpclient.Host, ConfigurationManager.AppSettings["AdvertisersFolder"], advertiser.AdvertiserId, extension), out errormessage);

                        if (string.IsNullOrWhiteSpace(errormessage))
                        {
                            advertiser.AdvertiserLogoUrl = string.Format("Advertisers_{0}.{1}", advertiser.AdvertiserId, extension);
                        }

                        AdvertisersService.Update(advertiser);
                    }
                }

                LoadLogo();
            }
        }

        #endregion


        public void SetFormValues()
        {
            btnUpdate.Text = CommonFunction.GetResourceValue("ButtonUpdate");
            cvalFileName.ErrorMessage = CommonFunction.GetResourceValue("LabelInvalidImage");
            cvalFile.ErrorMessage = CommonFunction.GetResourceValue("LabelInvalidImage");
            cvalFileType.ErrorMessage = CommonFunction.GetResourceValue("LabelReInvalidImage");
        }

    }
}
