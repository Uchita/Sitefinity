
#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JXTPortal.Web.UI;
using JXTPortal;
using JXTPortal.Entities;
using System.IO;
using System.Drawing;
using JXTPortal.Common;
#endregion

namespace JXTPortal.Website.Admin.UserControls
{
    public partial class AdvertiserJobTemplateLogo : System.Web.UI.UserControl
    {
        #region Declarations

        private int _advertiserid = 0;
        private int _advertiserJobTemplateLogoID = 0;

        private AdvertisersService _advertisersservice;
        private AdvertiserJobTemplateLogoService _advertiserJobTemplateLogoService;
        private byte[] _abytFile;

        #endregion

        #region Properties

        protected int AdvertiserID
        {
            get
            {
                if ((Request.QueryString["AdvertiserID"] != null))
                {
                    if (int.TryParse((Request.QueryString["AdvertiserID"].Trim()), out _advertiserid))
                    {
                        _advertiserid = Convert.ToInt32(Request.QueryString["AdvertiserID"]);
                    }
                    return _advertiserid;
                }

                return _advertiserid;
            }
        }

        private AdvertisersService AdvertisersService
        {
            get
            {
                if (_advertisersservice == null)
                {
                    _advertisersservice = new AdvertisersService();
                }
                return _advertisersservice;
            }
        }

        private AdvertiserJobTemplateLogoService AdvertiserJobTemplateLogoService
        {
            get
            {
                if (_advertiserJobTemplateLogoService == null)
                {
                    _advertiserJobTemplateLogoService = new AdvertiserJobTemplateLogoService();
                }
                return _advertiserJobTemplateLogoService;
            }
        }

        #endregion

        #region "User Control Properties"

        public bool IsAdmin { get; set; }

        #endregion

        #region Page Event Handlers

        public void SetFormValues()
        {
            ltAdvJobTemplateLogoName.Text = CommonFunction.GetResourceValue("LabelAdvertiserJobTemplateLogoName");
            ltAdvJobTemplateLogoSelectDoc.Text = CommonFunction.GetResourceValue("LabelAdvertiserJobTemplateLogoSelectDoc");
            ltHeaderAdvJobTemplateLogoID.Text = CommonFunction.GetResourceValue("LabelAdvertiserJobTemplateLogoID");
            ltHeaderAdvJobTemplateLogoName.Text = CommonFunction.GetResourceValue("LabelAdvertiserJobTemplateLogoName");

            btnSubmit.Text = CommonFunction.GetResourceValue("ButtonSave");
        }

        //protected void Page_Init(object sender, EventArgs e)
        //{
            
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnSubmit);

            if (!Page.IsPostBack)
            {
                SetFormValues();
                LoadAdvertiserJobTemplateLogo();
            }
        }

        protected void rptAdvJobTemplateLogo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltAdvJobTemplateLogoID = e.Item.FindControl("ltAdvJobTemplateLogoID") as Literal;
                Literal ltAdvJobTemplateLogoName = e.Item.FindControl("ltAdvJobTemplateLogoName") as Literal;
                System.Web.UI.WebControls.Image imgAdvJobTemplateLogo = e.Item.FindControl("imgAdvJobTemplateLogo") as System.Web.UI.WebControls.Image;

                //ltAdvJobTemplateLogoID.Text = CommonFunction.GetResourceValue("");
                //ltAdvJobTemplateLogoName.Text = CommonFunction.GetResourceValue("LabelAdvertiserJobTemplateLogoName");

                using (JXTPortal.Entities.AdvertiserJobTemplateLogo advTemplateLogo = e.Item.DataItem as JXTPortal.Entities.AdvertiserJobTemplateLogo)
                {
                    ltAdvJobTemplateLogoID.Text = Convert.ToString(advTemplateLogo.AdvertiserJobTemplateLogoId);
                    ltAdvJobTemplateLogoName.Text = advTemplateLogo.JobLogoName;
                    imgAdvJobTemplateLogo.ImageUrl = Page.ResolveUrl("~/GetFile.aspx") + "?AdvertiserJobTemplateLogoID=" +
                        Convert.ToString(advTemplateLogo.AdvertiserJobTemplateLogoId);

                }
            }
        }

        #endregion

        #region Methods

        private void LoadAdvertiserJobTemplateLogo()
        {
            //if (AdvertiserID > 0)
            //{
                //using (JXTPortal.Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(AdvertiserID))
                //{
                    //if (advertiser.SiteId != SessionData.Site.SiteId)
                    //    Response.Redirect("Advertiser.aspx");

            if (IsAdmin)
            {
                using (TList<Entities.AdvertiserJobTemplateLogo> advertiserJobTemplateLogo = AdvertiserJobTemplateLogoService.GetByAdvertiserId(AdvertiserID))
                {
                    rptAdvJobTemplateLogo.DataSource = advertiserJobTemplateLogo;
                    rptAdvJobTemplateLogo.DataBind();
                }
            }
            else
            {
                using (TList<Entities.AdvertiserJobTemplateLogo> advertiserJobTemplateLogo = 
                    AdvertiserJobTemplateLogoService.GetByAdvertiserId(SessionData.AdvertiserUser.AdvertiserId))
                {
                    rptAdvJobTemplateLogo.DataSource = advertiserJobTemplateLogo;
                    rptAdvJobTemplateLogo.DataBind();
                }
            }
                //}
            //}
            //else
            //{
            //    Response.Redirect("/admin/advertisers.aspx");
            //}
        }

        private void cvalFileName_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if ((_abytFile != null))
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

                try
                {
                    System.IO.MemoryStream objInputMemoryStream = new System.IO.MemoryStream(this.getArray(this.docInput.PostedFile));
                    System.Drawing.Image objOriginalImage = System.Drawing.Image.FromStream(objInputMemoryStream);
                    if (objOriginalImage.RawFormat != System.Drawing.Imaging.ImageFormat.Jpeg && objOriginalImage.RawFormat != System.Drawing.Imaging.ImageFormat.Png
                                && objOriginalImage.RawFormat != System.Drawing.Imaging.ImageFormat.Gif)
                    {
                        args.IsValid = false;
                    }
                }
                catch
                {
                    args.IsValid = false;
                }
            }
            else
            {
                args.IsValid = true;
            }
        }

        private void cvalFile_ServerValidate(System.Object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
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

        private byte[] getArray(HttpPostedFile f)
        {
            int i = 0;
            byte[] b = new byte[f.ContentLength];

            f.InputStream.Read(b, 0, f.ContentLength);

            return b;
        }

        #endregion

        #region Click Events

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Entities.AdvertiserJobTemplateLogo objAdvJobTemplateLogo = new JXTPortal.Entities.AdvertiserJobTemplateLogo();

            if ((docInput.PostedFile != null) && docInput.PostedFile.ContentLength > 0)
            {
                System.IO.MemoryStream objInputMemoryStream = new System.IO.MemoryStream(this.getArray(this.docInput.PostedFile));
                System.Drawing.Image objOriginalImage = System.Drawing.Image.FromStream(objInputMemoryStream);
                System.Drawing.Image objResizedImage = JXTPortal.Common.Utils.ResizeImage(objOriginalImage, Constants.THUMBNAIL_WIDTH, Constants.THUMBNAIL_HEIGHT);

                System.IO.MemoryStream objOutputMemorySTream = new System.IO.MemoryStream();
                objResizedImage.Save(objOutputMemorySTream, System.Drawing.Imaging.ImageFormat.Jpeg);

                byte[] abytFile = new byte[Convert.ToInt32(objOutputMemorySTream.Length)];
                objOutputMemorySTream.Position = 0;
                objOutputMemorySTream.Read(abytFile, 0, abytFile.Length);

                objAdvJobTemplateLogo.JobTemplateLogo = abytFile;

                if (IsAdmin)
                {
                    objAdvJobTemplateLogo.AdvertiserId = AdvertiserID;
                }
                else
                {
                    objAdvJobTemplateLogo.AdvertiserId = SessionData.AdvertiserUser.AdvertiserId;
                }

                objAdvJobTemplateLogo.JobLogoName = txtAdvJobTemplateLogoName.Text;
            }

            AdvertiserJobTemplateLogoService.Insert(objAdvJobTemplateLogo);
            LoadAdvertiserJobTemplateLogo();
        }
        
        #endregion
    }
}