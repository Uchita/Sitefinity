
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
using System.Linq;
using JXTPortal.Web.UI;
using JXTPortal;
using JXTPortal.Entities;
using System.IO;
using System.Drawing;
using JXTPortal.Common;

using Microsoft.Win32;
using System.Runtime.InteropServices;

#endregion

namespace JXTPortal.Website.Admin.UserControls
{
    public partial class AdvertiserJobTemplateLogo : System.Web.UI.UserControl
    {
        #region Declarations

        private int _advertiserid = 0;
        private int _logoID = 0;

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

        protected int LogoID
        {
            get
            {
                if ((Request.QueryString["LogoID"] != null))
                {
                    if (int.TryParse((Request.QueryString["LogoID"].Trim()), out _logoID))
                    {
                        _logoID = Convert.ToInt32(Request.QueryString["LogoID"]);
                    }
                    return _logoID;
                }
                return _logoID;
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

        public int CurrentPage
        {
            get
            {
                if (this.ViewState["CurrentPage"] == null)
                    return 0;
                else
                    return Convert.ToInt16(this.ViewState["CurrentPage"].ToString());
            }
            set
            {
                this.ViewState["CurrentPage"] = value;
            }
        }

        #endregion

        #region "User Control Properties"

        public bool IsAdmin { get; set; }

        #endregion

        #region Page Event Handlers

        public void SetFormValues()
        {
            btnSubmit.Text = CommonFunction.GetResourceValue("ButtonSave");
            cvalFileName.ErrorMessage = CommonFunction.GetResourceValue("LabelInvalidImage");
            cvalFile.ErrorMessage = CommonFunction.GetResourceValue("LabelReInvalidImage");
            rfvAdvJobTemplateLogoName.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            rfvAdvJobTemplateLogoImage.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnSubmit);
            ltlMessage.Text = string.Empty;
            if (!Page.IsPostBack)
            {
                if (LogoID > 0)
                {
                    rfvAdvJobTemplateLogoImage.Enabled = false;
                }

                SetFormValues();
                LoadAdvertiserJobTemplateLogo();
            }
        }

        protected void rptAdvJobTemplateLogo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                Literal ltHeaderAdvJobTemplateLogoID = e.Item.FindControl("ltHeaderAdvJobTemplateLogoID") as Literal;
                Literal ltHeaderAdvJobTemplateLogoName = e.Item.FindControl("ltHeaderAdvJobTemplateLogoName") as Literal;
                Literal ltHeaderAdvJobTemplateLogoThumbnail = e.Item.FindControl("ltHeaderAdvJobTemplateLogoThumbnail") as Literal;

                ltHeaderAdvJobTemplateLogoThumbnail.Text = CommonFunction.GetResourceValue("LabelLogoImage");
                ltHeaderAdvJobTemplateLogoID.Text = CommonFunction.GetResourceValue("LabelAdvertiserJobTemplateLogoID");
                ltHeaderAdvJobTemplateLogoName.Text = CommonFunction.GetResourceValue("LabelAdvertiserJobTemplateLogoName");

            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltAdvJobTemplateLogoID = e.Item.FindControl("ltAdvJobTemplateLogoID") as Literal;
                Literal ltAdvJobTemplateLogoName = e.Item.FindControl("ltAdvJobTemplateLogoName") as Literal;
                System.Web.UI.WebControls.Image imgAdvJobTemplateLogo = e.Item.FindControl("imgAdvJobTemplateLogo") as System.Web.UI.WebControls.Image;

                DataRowView rowAdvJobTemplateLogo = (DataRowView)e.Item.DataItem;
                ltAdvJobTemplateLogoID.Text = Convert.ToString(rowAdvJobTemplateLogo["AdvertiserJobTemplateLogoId"]);
                ltAdvJobTemplateLogoName.Text = Convert.ToString(rowAdvJobTemplateLogo["JobLogoName"]);

                if (string.IsNullOrWhiteSpace(Convert.ToString(rowAdvJobTemplateLogo["JobTemplateLogoUrl"])))
                {
                    imgAdvJobTemplateLogo.ImageUrl = Page.ResolveUrl("~/getfile.aspx") + "?advertiserjobtemplatelogoid=" +
                        Convert.ToString(rowAdvJobTemplateLogo["AdvertiserJobTemplateLogoId"]);
                }
                else
                {
                    imgAdvJobTemplateLogo.ImageUrl = string.Format("/media/{0}/{1}", ConfigurationManager.AppSettings["AdvertiserJobTemplateLogoFolder"], rowAdvJobTemplateLogo["JobTemplateLogoUrl"]);
                }
            }
        }

        protected void rptAdvJobTemplateLogo_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                if (IsAdmin)
                {
                    int advertiserJobTemplateLogoId = int.Parse(e.CommandArgument.ToString());
                    Response.Redirect("~/Admin/AdvertiserJobTemplateLogo.aspx?AdvertiserID=" + AdvertiserID + "&LogoID=" + advertiserJobTemplateLogoId);
                }
                else
                {
                    int advertiserJobTemplateLogoId = int.Parse(e.CommandArgument.ToString());
                    Response.Redirect("~/advertiser/AdvertiserJobTemplateLogo.aspx?LogoID=" + advertiserJobTemplateLogoId);
                }
            }
        }

        protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                CurrentPage = Convert.ToInt32(e.CommandArgument);
                LoadAdvertiserJobTemplateLogo();
            }
        }

        protected void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbPageNo = e.Item.FindControl("lbPageNo") as LinkButton;
                lbPageNo.CommandArgument = e.Item.DataItem.ToString();
                lbPageNo.Text = (Convert.ToInt32(e.Item.DataItem) + 1).ToString();

                if (lbPageNo.CommandArgument == CurrentPage.ToString())
                {
                    lbPageNo.CssClass = "active_tnt_link";
                }
            }
        }

        #endregion

        #region Methods

        private void LoadAdvertiserJobTemplateLogo()
        {
            if (LogoID > 0)
            {
                imgAdvJobTemplateLogoEdit.Visible = true;

                JXTPortal.Entities.AdvertiserJobTemplateLogo advJobTemplateLogo =
                    AdvertiserJobTemplateLogoService.GetByAdvertiserJobTemplateLogoId(Convert.ToInt32(LogoID));
                // Make sure the logo belongs to the advertiser
                if (advJobTemplateLogo == null)
                {
                    if (IsAdmin)
                    {
                        Response.Redirect("~/admin/AdvertiserJobTemplateLogo.aspx?advertiserid=" + AdvertiserID.ToString());
                    }
                    else
                    {
                        Response.Redirect("/advertiser/advertiserjobtemplatelogo.aspx");
                    }
                }
                else
                {
                    if (IsAdmin)
                    {
                        using (Entities.Advertisers adv = AdvertisersService.GetByAdvertiserId(advJobTemplateLogo.AdvertiserId))
                        {
                            if (adv != null)
                            {
                                if (adv.SiteId != SessionData.Site.SiteId)
                                {
                                    Response.Redirect("~/admin/AdvertiserJobTemplateLogo.aspx?advertiserid=" + AdvertiserID.ToString());
                                }
                            }
                            else
                            {
                                Response.Redirect("~/admin/AdvertiserJobTemplateLogo.aspx?advertiserid=" + AdvertiserID.ToString());
                            }
                        }
                    }
                    else
                    {
                        if (SessionData.AdvertiserUser != null)
                        {
                            if (advJobTemplateLogo.AdvertiserId != SessionData.AdvertiserUser.AdvertiserId)
                            {
                                Response.Redirect("/advertiser/advertiserjobtemplatelogo.aspx");
                            }
                        }
                        else
                        {
                            Response.Redirect("/advertiser/advertiserjobtemplatelogo.aspx");
                        }
                    }
                }

                txtAdvJobTemplateLogoName.Text = advJobTemplateLogo.JobLogoName;
                imgAdvJobTemplateLogoEdit.ImageUrl = Page.ResolveUrl("~/getfile.aspx") + "?advertiserjobtemplatelogoid=" +
                        Convert.ToString(LogoID);

            }

            int totalCount = 0;
            int pageCount = 0;
            int sitePageCount = 5;

            if (IsAdmin)
            {
                using (DataSet datasetAdvJobTemplateLogo = AdvertiserJobTemplateLogoService.GetPagingByAdvertiserId(AdvertiserID, sitePageCount, CurrentPage + 1))
                {
                    if (datasetAdvJobTemplateLogo.Tables[0].Rows.Count > 0)
                    {
                        totalCount = Convert.ToInt32(datasetAdvJobTemplateLogo.Tables[0].Rows[0]["TotalCount"]);

                        ArrayList pagelist = new ArrayList();

                        if (totalCount % sitePageCount == 0)
                            pageCount = totalCount / sitePageCount;
                        else
                            pageCount = (totalCount / sitePageCount) + 1;

                        for (int i = 0; i < pageCount; i++)
                        {
                            pagelist.Add(i);
                        }

                        if (pagelist.Count > 1)
                        {
                            rptPage.DataSource = pagelist;
                            rptPage.DataBind();
                            rptPage.Visible = true;
                        }
                        else
                        {
                            rptPage.Visible = false;
                        }

                        rptAdvJobTemplateLogo.Visible = true;
                        rptAdvJobTemplateLogo.DataSource = datasetAdvJobTemplateLogo;
                        rptAdvJobTemplateLogo.DataBind();

                    }
                    else
                    {
                        rptAdvJobTemplateLogo.Visible = false;
                    }
                }
            }
            else
            {
                using (DataSet datasetAdvJobTemplateLogo = AdvertiserJobTemplateLogoService.GetPagingByAdvertiserId(SessionData.AdvertiserUser.AdvertiserId,
                        sitePageCount, CurrentPage + 1))
                {
                    if (datasetAdvJobTemplateLogo.Tables[0].Rows.Count > 0)
                    {
                        totalCount = Convert.ToInt32(datasetAdvJobTemplateLogo.Tables[0].Rows[0]["TotalCount"]);

                        ArrayList pagelist = new ArrayList();

                        if (totalCount % sitePageCount == 0)
                            pageCount = totalCount / sitePageCount;
                        else
                            pageCount = (totalCount / sitePageCount) + 1;

                        for (int i = 0; i < pageCount; i++)
                        {
                            pagelist.Add(i);
                        }

                        if (pagelist.Count > 1)
                        {
                            rptPage.DataSource = pagelist;
                            rptPage.DataBind();
                            rptPage.Visible = true;
                        }
                        else
                        {
                            rptPage.Visible = false;
                        }

                        rptAdvJobTemplateLogo.Visible = true;
                        rptAdvJobTemplateLogo.DataSource = datasetAdvJobTemplateLogo;
                        rptAdvJobTemplateLogo.DataBind();

                    }
                    else
                    {
                        rptAdvJobTemplateLogo.Visible = false;
                    }
                }
            }
        }

        protected void cvalFileName_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if ((this.docInput.PostedFile != null) && !string.IsNullOrEmpty(this.docInput.PostedFile.FileName))
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
                        if (string.IsNullOrEmpty(strExt))
                        {
                            this.cvalFileName.ErrorMessage = CommonFunction.GetResourceValue("ErrorImageNoExtension");
                            args.IsValid = false;
                        }
                        else
                        {
                            this.cvalFileName.ErrorMessage = String.Format("{0} {1} {2}", CommonFunction.GetResourceValue("ErrorImageExtension"),
                                            string.Format("<strong>{0}</strong>", strExt), CommonFunction.GetResourceValue("ErrorNotAccepted"));
                            //+ String.Format(@"<strong>{0}</strong>", strExt) +                    
                            args.IsValid = false;
                        }
                        break;
                }
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void cvalFile_ServerValidate(System.Object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {

            if ((this.docInput.PostedFile != null) && !string.IsNullOrEmpty(this.docInput.PostedFile.FileName))
            {
                if (docInput.PostedFile.ContentLength == 0)
                {
                    this.cvalFile.ErrorMessage = CommonFunction.GetResourceValue("ErrorImageInvalidSize");
                    args.IsValid = false;

                }
                else if ((docInput.PostedFile.ContentLength / (Math.Pow(1024, 2))) > 1)
                {
                    this.cvalFile.ErrorMessage = CommonFunction.GetResourceValue("ErrorImageExceed");
                    args.IsValid = false;

                }
                else
                {
                    args.IsValid = true;
                }
            }
            else if (LogoID > 0)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
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
            if (Page.IsValid)
            {
                Entities.AdvertiserJobTemplateLogo objAdvJobTemplateLogo = new JXTPortal.Entities.AdvertiserJobTemplateLogo();

                if (LogoID > 0)
                {
                    objAdvJobTemplateLogo = AdvertiserJobTemplateLogoService.GetByAdvertiserJobTemplateLogoId(LogoID);
                    // Make sure the logo belongs to the advertiser
                    if (IsAdmin)
                    {
                        using (Entities.Advertisers adv = AdvertisersService.GetByAdvertiserId(objAdvJobTemplateLogo.AdvertiserId))
                        {
                            if (adv != null)
                            {
                                if (adv.SiteId != SessionData.Site.SiteId)
                                {
                                    Response.Redirect("~/admin/AdvertiserJobTemplateLogo.aspx?advertiserid=" + AdvertiserID.ToString());
                                }
                            }
                            else
                            {
                                Response.Redirect("~/admin/AdvertiserJobTemplateLogo.aspx?advertiserid=" + AdvertiserID.ToString());
                            }
                        }
                    }
                    else
                    {
                        if (SessionData.AdvertiserUser != null)
                        {
                            if (objAdvJobTemplateLogo.AdvertiserId != SessionData.AdvertiserUser.AdvertiserId)
                            {
                                Response.Redirect("/advertiser/advertiserjobtemplatelogo.aspx");
                            }
                        }
                        else
                        {
                            Response.Redirect("/advertiser/advertiserjobtemplatelogo.aspx");
                        }
                    }
                }

                if (IsAdmin)
                {
                    objAdvJobTemplateLogo.AdvertiserId = AdvertiserID;
                }
                else
                {
                    objAdvJobTemplateLogo.AdvertiserId = SessionData.AdvertiserUser.AdvertiserId;
                }

                objAdvJobTemplateLogo.JobLogoName = txtAdvJobTemplateLogoName.Text;

                if ((docInput.PostedFile != null) && docInput.PostedFile.ContentLength > 0)
                {
                    if (this.docInput.PostedFile != null)
                    {
                        try
                        {
                            System.Drawing.Image objOriginalImage = null;
                            string contenttype = string.Empty;
                            if (!Utils.IsValidUploadImage(docInput.PostedFile.FileName, docInput.PostedFile.InputStream, out objOriginalImage, out contenttype))
                            {
                                ltlMessage.Text = "Invalid Advertiser Job Template Logo";
                                return;
                            }
                        }
                        catch
                        {
                            ltlMessage.Text = "Invalid Advertiser Job Template Logo";
                            return;
                        }
                    }
                }

                if (LogoID > 0)
                {
                    AdvertiserJobTemplateLogoService.Update(objAdvJobTemplateLogo);
                }
                else
                {
                    AdvertiserJobTemplateLogoService.Insert(objAdvJobTemplateLogo);
                }

                if ((docInput.PostedFile != null) && docInput.PostedFile.ContentLength > 0)
                {
                    if (this.docInput.PostedFile != null)
                    {
                        try
                        {
                            System.Drawing.Image objOriginalImage = null;
                            string contenttype = string.Empty;

                            Utils.IsValidUploadImage(docInput.PostedFile.FileName, docInput.PostedFile.InputStream, out objOriginalImage, out contenttype);
                            System.Drawing.Image objResizedImage = JXTPortal.Common.Utils.ResizeImage(objOriginalImage,
                                PortalConstants.THUMBNAIL_WIDTH, PortalConstants.THUMBNAIL_HEIGHT);

                            System.IO.MemoryStream objOutputMemorySTream = new System.IO.MemoryStream();
                            objResizedImage.Save(objOutputMemorySTream, objOriginalImage.RawFormat);

                            byte[] abytFile = new byte[Convert.ToInt32(objOutputMemorySTream.Length)];
                            objOutputMemorySTream.Position = 0;
                            objOutputMemorySTream.Read(abytFile, 0, abytFile.Length);

                            FtpClient ftpclient = new FtpClient();
                            string errormessage = string.Empty;
                            string extension = Utils.GetImageExtension(objOriginalImage);
                            ftpclient.Host = ConfigurationManager.AppSettings["FTPFileManager"];
                            ftpclient.Username = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                            ftpclient.Password = ConfigurationManager.AppSettings["FTPJobApplyPassword"];
                            ftpclient.UploadFileFromStream(objOutputMemorySTream, string.Format("{0}/{1}/AdvertiserJobTemplateLogo_{2}.{3}", ftpclient.Host, ConfigurationManager.AppSettings["AdvertiserJobTemplateLogoFolder"], objAdvJobTemplateLogo.AdvertiserJobTemplateLogoId, extension), out errormessage);

                            if (string.IsNullOrWhiteSpace(errormessage))
                            {
                                objAdvJobTemplateLogo.JobTemplateLogoUrl = string.Format("AdvertiserJobTemplateLogo_{0}.{1}", objAdvJobTemplateLogo.AdvertiserJobTemplateLogoId, extension);
                                AdvertiserJobTemplateLogoService.Update(objAdvJobTemplateLogo);
                            }

                        }
                        catch
                        {
                            ltlMessage.Text = "Invalid Advertiser Job Template Logo";
                            return;
                        }
                    }

                }

                if (IsAdmin)
                {
                    Response.Redirect("~/admin/AdvertiserJobTemplateLogo.aspx?advertiserid=" + AdvertiserID.ToString());
                }
                else
                {
                    Response.Redirect("~/advertiser/AdvertiserJobTemplateLogo.aspx");
                }
            }
        }

        [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
        private extern static System.UInt32 FindMimeFromData(
                System.UInt32 pBC,
                [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl,
                [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
                System.UInt32 cbSize,
                [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed,
                System.UInt32 dwMimeFlags,
                out System.UInt32 ppwzMimeOut,
                System.UInt32 dwReserverd
        );

        #endregion
    }
}