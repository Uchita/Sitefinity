
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
using System.Linq;
using System.Drawing;
using JXTPortal.Common;
using JXTPortal;
using JXTPortal.Entities;

using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Xml;
using JXTPortal.Client.Bullhorn;
#endregion

public partial class AdvertisersEdit : System.Web.UI.Page
{
    #region Declarations

    private int _advertiserid = 0;
    private AdvertisersService _advertisersservice;
    private AdvertiserUsersService _advertiserusersservice;
    private AdvertiserBusinessTypeService _advertiserbusinesstypeservice;
    private IndustryService _industryservice;
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

    private AdvertiserUsersService AdvertiserUsersService
    {
        get
        {
            if (_advertiserusersservice == null)
            {
                _advertiserusersservice = new AdvertiserUsersService();
            }
            return _advertiserusersservice;
        }
    }
    private AdvertiserBusinessTypeService AdvertiserBusinessTypeService
    {
        get
        {
            if (_advertiserbusinesstypeservice == null)
            {
                _advertiserbusinesstypeservice = new AdvertiserBusinessTypeService();
            }
            return _advertiserbusinesstypeservice;
        }
    }

    private IndustryService IndustryService
    {
        get
        {
            if (_industryservice == null)
            {
                _industryservice = new IndustryService();
            }
            return _industryservice;
        }
    }


    #endregion

    #region Page

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadBusinessType();
            LoadIndustry();
            LoadContactMethod();
            if ((Request.QueryString["AdvertiserID"] != null))
            {
                LoadAdvertiser();
            }
            else //create advertiser
            {
                //if it is a recruiter board, only "account" type can be set 
                if (!SessionData.Site.IsJobBoard)
                {
                    dataAdvertiserAccountTypeId.SelectedValue = ((int)PortalEnums.Advertiser.AccountType.Account).ToString();
                    dataAdvertiserAccountTypeId.ReadOnly = true;
                }
            }
        }


        InsertButton.Visible = (AdvertiserID == 0);
        UpdateButton.Visible = (AdvertiserID > 0);

        cal_dataFreeTrialStartDate.Format = SessionData.Site.DateFormat;
        cal_dataFreeTrialEndDate.Format = SessionData.Site.DateFormat;

        //btnAdvertiserUsers.Visible = (AdvertiserID > 0);
    }

    #endregion

    #region Methods

    private void LoadBusinessType()
    {
        bool useDefault = false;

        TList<JXTPortal.Entities.AdvertiserBusinessType> advertiserbusinesstype = AdvertiserBusinessTypeService.GetSiteBusinessTypes(SessionData.Site.SiteId, out useDefault);
        dataBusinessTypeId.DataValueField = (useDefault) ? "AdvertiserBusinessTypeID" : "BusinessTypeParentID";

        dataBusinessTypeId.DataSource = advertiserbusinesstype;
        dataBusinessTypeId.DataTextField = "AdvertiserBusinessTypeName";
        dataBusinessTypeId.DataBind();
    }

    private void LoadIndustry()
    {
        ddlIndustry.Items.Clear();

        using (TList<Industry> industries = IndustryService.GetBySiteId(SessionData.Site.SiteId))
        {
            industries.Filter = "Valid = True";

            if (industries.Count > 0)
            {
                phIndustry.Visible = true;

                foreach (Industry industry in industries)
                {
                    string text = industry.IndustryName;

                    if (!string.IsNullOrWhiteSpace(industry.IndustryLanguageXml))
                    {
                        XmlDocument industryxml = new XmlDocument();
                        industryxml.LoadXml(industry.IndustryLanguageXml);

                        foreach (XmlNode langnode in industryxml.GetElementsByTagName("Language"))
                        {
                            if (langnode.ChildNodes[0].InnerXml == SessionData.Language.LanguageId.ToString())
                            {
                                text = langnode.ChildNodes[1].InnerXml;
                                break;
                            }
                        }
                    }

                    ddlIndustry.Items.Add(new ListItem(text, industry.IndustryId.ToString()));
                }

                ddlIndustry.Items.Insert(0, new ListItem(JXTPortal.Website.CommonFunction.GetResourceValue("LabelPleaseChoose"), ""));

            }
            else
            {
                phIndustry.Visible = false;
            }
        }
    }

    private void LoadContactMethod()
    {
        ddlPreferredContactMethod.Items.Clear();
        ddlPreferredContactMethod.DataValueField = "Value";
        ddlPreferredContactMethod.DataTextField = "Key";
        ddlPreferredContactMethod.DataSource = JXTPortal.Website.CommonFunction.GetEnumFormattedNames<PortalEnums.Advertiser.ContactMethod>();
        ddlPreferredContactMethod.DataBind();

        ddlPreferredContactMethod.Items.Insert(0, new ListItem(JXTPortal.Website.CommonFunction.GetResourceValue("LabelPleaseChoose"), ""));
    }

    private void LoadAdvertiser()
    {
        if (SessionData.AdminUser == null)
        {
            Response.Redirect("~/admin/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
            return;
        }

        if (AdvertiserID > 0)
        {
            phAdvertiserStatus.Visible = true;

            using (JXTPortal.Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(AdvertiserID))
            {
                if (advertiser != null)
                {
                    if (SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Administrator ||
                        ((SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.ContentEditor || SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Developer) && advertiser.SiteId == SessionData.Site.SiteId))
                    {
                        //if recruiter board, the account type is also set to be account
                        if (!SessionData.Site.IsJobBoard)
                        {
                            dataAdvertiserAccountTypeId.SelectedValue = ((int)PortalEnums.Advertiser.AccountType.Account).ToString();
                            dataAdvertiserAccountTypeId.ReadOnly = true;
                        }
                        else
                            dataAdvertiserAccountTypeId.SelectedValue = advertiser.AdvertiserAccountTypeId.ToString();

                        dataAdvertiserAccountStatusID.SelectedValue = advertiser.AdvertiserAccountStatusId.ToString();
                        dataCompanyName.Text = CommonService.DecodeString(advertiser.CompanyName);
                        dataBusinessTypeId.SelectedValue = advertiser.AdvertiserBusinessTypeId.ToString();
                        dataBusinessNumber.Text = (string.IsNullOrEmpty(advertiser.BusinessNumber)) ? "" : advertiser.BusinessNumber.ToString();
                        dataNoOfEmployees.Text = CommonService.DecodeString(advertiser.NoOfEmployees);

                        dataStreetAddress1.Text = CommonService.DecodeString(advertiser.StreetAddress1);
                        dataStreetAddress2.Text = CommonService.DecodeString(advertiser.StreetAddress2);
                        dataPostalAddress1.Text = CommonService.DecodeString(advertiser.PostalAddress1);
                        dataPostalAddress2.Text = CommonService.DecodeString(advertiser.PostalAddress2);
                        dataWebAddress.Text = CommonService.DecodeString(advertiser.WebAddress);

                        dataAccountsPayableEmail.Text = CommonService.DecodeString(advertiser.AccountsPayableEmail);

                        if (advertiser.FirstApprovedDate != null)
                        {
                            ApprovedDate.Text = "Last Approved: " + ((DateTime)advertiser.FirstApprovedDate).ToString(SessionData.Site.DateFormat);
                            ApprovedDate.Visible = true;
                        }

                        dataProfile.Text = advertiser.Profile;

                        tbVideoLink.Text = advertiser.VideoLink;
                        ddlIndustry.SelectedValue = advertiser.Industry;
                        tbNominatedCompanyRole.Text = advertiser.NominatedCompanyRole;
                        tbNominatedCompanyFirstName.Text = advertiser.NominatedCompanyFirstName;
                        tbNominatedCompanyLastName.Text = advertiser.NominatedCompanyLastName;
                        tbNominatedCompanyEmailAddress.Text = advertiser.NominatedCompanyEmailAddress;
                        tbNominatedCompanyPhone.Text = advertiser.NominatedCompanyPhone;
                        ddlPreferredContactMethod.SelectedValue = (advertiser.PreferredContactMethod.HasValue) ? advertiser.PreferredContactMethod.ToString() : string.Empty;

                        //Trial Settings and Dates
                        if (advertiser.FreeTrialStartDate != null)
                            dataFreeTrialStartDate.Text = ((DateTime)advertiser.FreeTrialStartDate).ToString(SessionData.Site.DateFormat);
                        if (advertiser.FreeTrialEndDate != null)
                            dataFreeTrialEndDate.Text = ((DateTime)advertiser.FreeTrialEndDate).ToString(SessionData.Site.DateFormat);

                        //if ((PortalEnums.Advertiser.AccountStatus)advertiser.AdvertiserAccountStatusId == PortalEnums.Advertiser.AccountStatus.Approved)
                        //{
                        //    panelTrialSettings.Visible = true;
                        //}

                        if (advertiser.FreeTrialStartDate != null || advertiser.FreeTrialEndDate != null)
                        {
                            cbTrialEnabled.Checked = true;
                            panelTrialSettingsDates.Visible = true;
                        }

                        //External ID display
                        if (!string.IsNullOrEmpty(advertiser.ExternalAdvertiserId))
                        {
                            ltExternalID.Text = advertiser.ExternalAdvertiserId;
                            phExternalID.Visible = true;
                        }

                        if (advertiser.RegisterDate.HasValue)
                            dataRegisteredDate.Text = advertiser.RegisterDate.Value.ToString(SessionData.Site.DateFormat);

                        dataLastModified.Text = advertiser.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");

                        hypAdvertiserUsers.NavigateUrl = "/admin/advertiserUsers.aspx?advertiserID=" + AdvertiserID;
                        hypAdvertiserUsers.Visible = true;

                        if (advertiser.AdvertiserLogo != null || string.IsNullOrWhiteSpace(advertiser.AdvertiserLogoUrl) == false)
                        {
                            if (string.IsNullOrWhiteSpace(advertiser.AdvertiserLogoUrl))
                            {
                                imgLogo.ImageUrl = Page.ResolveUrl("~/getfile.aspx") + "?advertiserid=" + Convert.ToString(AdvertiserID);
                                
                            }
                            else
                            {
                                imgLogo.ImageUrl = string.Format("/media/{0}/{1}", ConfigurationManager.AppSettings["AdvertisersFolder"], advertiser.AdvertiserLogoUrl);
                            }

                            imgLogo.Visible = true;
                            lblNoLogo.Visible = false;
                            lblRemoveLogo.Visible = true;
                            chkRemoveLogo.Visible = true;
                        }
                        else
                        {
                            imgLogo.Visible = false;
                            lblNoLogo.Visible = true;
                            lblRemoveLogo.Visible = false;
                            chkRemoveLogo.Visible = false;
                        }

                        AdminUsersService aus = new AdminUsersService();
                        using (JXTPortal.Entities.AdminUsers adminuser = aus.GetByAdminUserId(advertiser.LastModifiedBy))
                        {
                            dataModifiedBy.Text = adminuser.UserName;
                        }

                    }
                    else
                    {
                        Response.Redirect("Advertisers.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Advertisers.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("Advertisers.aspx");
        }
    }

    //protected void cvalDocument_ServerValidate(object source, ServerValidateEventArgs args)
    //{
    //    if (docInput.PostedFile == null || docInput.PostedFile.ContentLength == 0)
    //    {
    //        args.IsValid = false;
    //        this.cvalDocument.ErrorMessage = "Please ensure you have selected a document to upload";
    //    }
    //    else
    //    {
    //        args.IsValid = true;
    //    }

    //}

    //protected void uploadFile()
    //{
    //    if (this.IsValid)
    //    {
    //        using (JXTPortal.Entities.Advertisers objAdvertiser = new JXTPortal.Entities.Advertisers())
    //        {
    //            if ((docInput.PostedFile != null) && docInput.PostedFile.ContentLength > 0)
    //            {
    //                objAdvertiser.AdvertiserLogo = this.getArray(this.docInput.PostedFile);

    //                AdvertisersService.Insert(objAdvertiser);
    //            }
    //        }
    //    }

    //}

    private void cvalFileName_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        if (docInput.HasFile)
        {
            System.Drawing.Image img = null;
            string contenttype = string.Empty;
            args.IsValid = Utils.IsValidUploadImage(docInput.PostedFile.FileName, docInput.PostedFile.InputStream, out img, out contenttype);
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

    #region Events

    protected void InsertButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            JXTPortal.Entities.Advertisers advertiser = new JXTPortal.Entities.Advertisers();
            //advertiser.AdvertiserId = AdvertiserID;
            advertiser.AdvertiserAccountTypeId = Convert.ToInt32(dataAdvertiserAccountTypeId.SelectedValue);
            advertiser.AdvertiserAccountStatusId = Convert.ToInt32(dataAdvertiserAccountStatusID.SelectedValue);

            PortalEnums.Advertiser.AccountStatus newStatus = (PortalEnums.Advertiser.AccountStatus)Enum.Parse(typeof(PortalEnums.Advertiser.AccountStatus), dataAdvertiserAccountStatusID.SelectedValue);

            if (newStatus == PortalEnums.Advertiser.AccountStatus.Approved)
            {
                advertiser.FirstApprovedDate = DateTime.Now;
            }

            advertiser.CompanyName = CommonService.EncodeString(dataCompanyName.Text);
            advertiser.AdvertiserBusinessTypeId = Convert.ToInt32(dataBusinessTypeId.SelectedValue);
            advertiser.BusinessNumber = CommonService.EncodeString(dataBusinessNumber.Text);
            advertiser.NoOfEmployees = CommonService.EncodeString(dataNoOfEmployees.Text);

            advertiser.StreetAddress1 = CommonService.EncodeString(dataStreetAddress1.Text);
            advertiser.StreetAddress2 = CommonService.EncodeString(dataStreetAddress2.Text);
            advertiser.PostalAddress1 = CommonService.EncodeString(dataPostalAddress1.Text);
            advertiser.PostalAddress2 = CommonService.EncodeString(dataPostalAddress2.Text);
            advertiser.WebAddress = CommonService.EncodeString(dataWebAddress.Text);

            advertiser.AccountsPayableEmail = CommonService.EncodeString(dataAccountsPayableEmail.Text);
            advertiser.Profile = dataProfile.Text;

            advertiser.VideoLink = tbVideoLink.Text;
            advertiser.Industry = ddlIndustry.SelectedValue;
            advertiser.NominatedCompanyRole = tbNominatedCompanyRole.Text;
            advertiser.NominatedCompanyFirstName = tbNominatedCompanyFirstName.Text;
            advertiser.NominatedCompanyLastName = tbNominatedCompanyLastName.Text;
            advertiser.NominatedCompanyEmailAddress = tbNominatedCompanyEmailAddress.Text;
            advertiser.NominatedCompanyPhone = tbNominatedCompanyPhone.Text;
            advertiser.PreferredContactMethod = (!string.IsNullOrWhiteSpace(ddlPreferredContactMethod.SelectedValue)) ? Convert.ToInt32(ddlPreferredContactMethod.SelectedValue) : (int?)null;


            //Trial settings only available to Approved accounts, if status is not set as approved, we ignore the trial dates
            if (newStatus == PortalEnums.Advertiser.AccountStatus.Approved)
            {
                if (!string.IsNullOrEmpty(dataFreeTrialStartDate.Text))
                    advertiser.FreeTrialStartDate = DateTime.ParseExact(dataFreeTrialStartDate.Text, SessionData.Site.DateFormat, null);
                else
                    advertiser.FreeTrialStartDate = null;

                if (!string.IsNullOrEmpty(dataFreeTrialEndDate.Text))
                    advertiser.FreeTrialEndDate = DateTime.ParseExact(dataFreeTrialEndDate.Text, SessionData.Site.DateFormat, null);
                else
                    advertiser.FreeTrialEndDate = null;
            }
            else
            {
                advertiser.FreeTrialStartDate = null;
                advertiser.FreeTrialEndDate = null;
            }

            if (docInput.HasFile && docInput.PostedFile.ContentLength > 0)
            {
                try
                {
                    System.Drawing.Image objOriginalImage = null;
                    string contenttype = string.Empty;
                    if (!Utils.IsValidUploadImage(docInput.PostedFile.FileName, this.docInput.PostedFile.InputStream, out objOriginalImage, out contenttype))
                    {
                        ltlMessage.Text = ltlMessage.Text = "Invalid Advertiser Logo.";
                        return;
                    }
                }
                catch
                {
                    ltlMessage.Text = ltlMessage.Text = "Invalid Advertiser Logo.";
                    return;
                }


            }

            // Default Value
            advertiser.LastModified = DateTime.Now;
            if (SessionData.AdminUser != null)
            {
                advertiser.LastModifiedBy = SessionData.AdminUser.AdminUserId;
            }
            else
            {
                advertiser.LastModifiedBy = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["DefaultAdminID"]);
            }
            advertiser.SiteId = SessionData.Site.SiteId;

            AdvertisersService.Insert(advertiser);

            if (docInput.HasFile && docInput.PostedFile.ContentLength > 0)
            {
                try
                {
                    System.Drawing.Image objOriginalImage = null;
                    string contenttype = string.Empty;
                    Utils.IsValidUploadImage(docInput.PostedFile.FileName, this.docInput.PostedFile.InputStream, out objOriginalImage, out contenttype);

                    System.Drawing.Image objResizedImage = JXTPortal.Common.Utils.ResizeImage(objOriginalImage, PortalConstants.THUMBNAIL_WIDTH, PortalConstants.THUMBNAIL_HEIGHT);

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
                    ftpclient.UploadFileFromStream(objOutputMemorySTream, string.Format("{0}/{1}/Advertisers_{2}.{3}", ftpclient.Host, ConfigurationManager.AppSettings["AdvertisersFolder"], advertiser.AdvertiserId, extension), out errormessage);

                    if (string.IsNullOrWhiteSpace(errormessage))
                    {
                        advertiser.AdvertiserLogoUrl = string.Format("Advertisers_{0}.{1}", advertiser.AdvertiserId, extension);
                        AdvertisersService.Update(advertiser);
                    }
                }
                catch
                {
                    ltlMessage.Text = ltlMessage.Text = "Invalid Advertiser Logo.";
                    return;
                }


            }

            #region BH Advertiser/Users sync
            BullhornRESTAPI BullhornRESTAPI = new BullhornRESTAPI(SessionData.Site.SiteId);
            if (BullhornRESTAPI != null && BullhornRESTAPI.BullhornSettings != null && BullhornRESTAPI.BullhornSettings.Valid && BullhornRESTAPI.BullhornSettings.EnableAdvertiserSync)
            {
                string errorMsg = string.Empty;

                //only sync if the advertiser account is active/approved
                if ((PortalEnums.Advertiser.AccountStatus)advertiser.AdvertiserAccountStatusId == PortalEnums.Advertiser.AccountStatus.Approved)
                    BullhornRESTAPI.SyncAdvertiserAndUser(SessionData.Site.SiteId, advertiser, null, true, out errorMsg);
            }
            #endregion


            Response.Redirect("Advertisers.aspx");
        }
    }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            // Retrieve
            using (JXTPortal.Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(AdvertiserID))
            {
                if (advertiser == null || advertiser.SiteId != SessionData.Site.SiteId)
                    Response.Redirect("/admin/advertisers.aspx");

                advertiser.AdvertiserAccountTypeId = Convert.ToInt32(dataAdvertiserAccountTypeId.SelectedValue);

                //check on changed status, and if neccessary, update approved date
                PortalEnums.Advertiser.AccountStatus originalStatus = (PortalEnums.Advertiser.AccountStatus)advertiser.AdvertiserAccountStatusId;
                PortalEnums.Advertiser.AccountStatus newStatus = (PortalEnums.Advertiser.AccountStatus)Enum.Parse(typeof(PortalEnums.Advertiser.AccountStatus), dataAdvertiserAccountStatusID.SelectedValue);

                if (originalStatus != PortalEnums.Advertiser.AccountStatus.Approved && newStatus == PortalEnums.Advertiser.AccountStatus.Approved)
                {
                    advertiser.FirstApprovedDate = DateTime.Now;
                }

                advertiser.AdvertiserAccountStatusId = Convert.ToInt32(dataAdvertiserAccountStatusID.SelectedValue);
                advertiser.CompanyName = CommonService.EncodeString(dataCompanyName.Text);
                advertiser.AdvertiserBusinessTypeId = Convert.ToInt32(dataBusinessTypeId.SelectedValue);
                advertiser.BusinessNumber = CommonService.EncodeString(dataBusinessNumber.Text);
                advertiser.NoOfEmployees = CommonService.EncodeString(dataNoOfEmployees.Text);

                advertiser.StreetAddress1 = CommonService.EncodeString(dataStreetAddress1.Text);
                advertiser.StreetAddress2 = CommonService.EncodeString(dataStreetAddress2.Text);
                advertiser.PostalAddress1 = CommonService.EncodeString(dataPostalAddress1.Text);
                advertiser.PostalAddress2 = CommonService.EncodeString(dataPostalAddress2.Text);
                advertiser.WebAddress = CommonService.EncodeString(dataWebAddress.Text);

                advertiser.AccountsPayableEmail = CommonService.EncodeString(dataAccountsPayableEmail.Text);
                advertiser.Profile = dataProfile.Text;

                advertiser.VideoLink = tbVideoLink.Text;
                advertiser.Industry = ddlIndustry.SelectedValue;
                advertiser.NominatedCompanyRole = tbNominatedCompanyRole.Text;
                advertiser.NominatedCompanyFirstName = tbNominatedCompanyFirstName.Text;
                advertiser.NominatedCompanyLastName = tbNominatedCompanyLastName.Text;
                advertiser.NominatedCompanyEmailAddress = tbNominatedCompanyEmailAddress.Text;
                advertiser.NominatedCompanyPhone = tbNominatedCompanyPhone.Text;
                advertiser.PreferredContactMethod = (!string.IsNullOrWhiteSpace(ddlPreferredContactMethod.SelectedValue)) ? Convert.ToInt32(ddlPreferredContactMethod.SelectedValue) : (int?)null;

                //Trial settings only available to Approved accounts, if status is not set as approved, we ignore the trial dates
                if (newStatus == PortalEnums.Advertiser.AccountStatus.Approved)
                {
                    if (!string.IsNullOrEmpty(dataFreeTrialStartDate.Text))
                        advertiser.FreeTrialStartDate = DateTime.ParseExact(dataFreeTrialStartDate.Text, SessionData.Site.DateFormat, null);
                    else
                        advertiser.FreeTrialStartDate = null;

                    if (!string.IsNullOrEmpty(dataFreeTrialEndDate.Text))
                        advertiser.FreeTrialEndDate = DateTime.ParseExact(dataFreeTrialEndDate.Text, SessionData.Site.DateFormat, null);
                    else
                        advertiser.FreeTrialEndDate = null;
                }
                else
                {
                    advertiser.FreeTrialStartDate = null;
                    advertiser.FreeTrialEndDate = null;
                }

                //Advertiser Logo
                if (chkRemoveLogo.Checked == false)
                {
                    if (docInput.HasFile)
                    {
                        try
                        {
                            System.Drawing.Image objOriginalImage = null;
                            string contenttype = string.Empty;
                            if (!Utils.IsValidUploadImage(docInput.PostedFile.FileName, this.docInput.PostedFile.InputStream, out objOriginalImage, out contenttype))
                            {
                                ltlMessage.Text = ltlMessage.Text = "Invalid Advertiser Logo.";
                                return;
                            }

                            System.Drawing.Image objResizedImage = JXTPortal.Common.Utils.ResizeImage(objOriginalImage, PortalConstants.THUMBNAIL_WIDTH, PortalConstants.THUMBNAIL_HEIGHT);

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
                            ftpclient.UploadFileFromStream(objOutputMemorySTream, string.Format("{0}/{1}/Advertisers_{2}.{3}", ftpclient.Host, ConfigurationManager.AppSettings["AdvertisersFolder"], advertiser.AdvertiserId, extension), out errormessage);

                            if (string.IsNullOrWhiteSpace(errormessage))
                            {
                                advertiser.AdvertiserLogoUrl = string.Format("Advertisers_{0}.{1}", advertiser.AdvertiserId, extension);
                                ltlMessage.Text = "Failed to update Advertiser Logo.";
                            }
                        }
                        catch
                        {
                            ltlMessage.Text = "Invalid Advertiser Logo.";
                            return;
                        }
                    }
                }
                else
                {
                    advertiser.AdvertiserLogo = null;
                    advertiser.AdvertiserLogoUrl = string.Empty;
                }

                // Default Value
                advertiser.LastModified = DateTime.Now;
                if (SessionData.AdminUser != null)
                {
                    advertiser.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                }
                else
                {
                    advertiser.LastModifiedBy = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["DefaultAdminID"]);
                }

                if (AdvertisersService.Update(advertiser))
                {
                    #region BH Advertiser/Users sync
                    BullhornRESTAPI BullhornRESTAPI = new BullhornRESTAPI(SessionData.Site.SiteId);
                    if (BullhornRESTAPI != null && BullhornRESTAPI.BullhornSettings != null && BullhornRESTAPI.BullhornSettings.Valid && BullhornRESTAPI.BullhornSettings.EnableAdvertiserSync)
                    {
                        string errorMsg = string.Empty;

                        //only sync if the advertiser account is active/approved
                        if ((PortalEnums.Advertiser.AccountStatus)advertiser.AdvertiserAccountStatusId == PortalEnums.Advertiser.AccountStatus.Approved)
                            BullhornRESTAPI.SyncAdvertiserAndUser(SessionData.Site.SiteId, advertiser, null, true, out errorMsg);
                    }
                    #endregion

                    // When Send Advertiser Status is checked
                    if (cbSendAdvertiserStatus.Checked)
                    {
                        // Send email to first Primary advertiser user
                        TList<JXTPortal.Entities.AdvertiserUsers> advusers = AdvertiserUsersService.GetByAdvertiserId(advertiser.AdvertiserId);
                        advusers.Filter = "PrimaryAccount = true";
                        if (advusers.Count > 0)
                        {
                            JXTPortal.Entities.AdvertiserUsers advuser = advusers[0];
                            MailService.SendAdvertiserUpdateStatus(advuser, advertiser, dataAdvertiserAccountStatusID.SelectedItem.Text);
                            ltlMessage.Text = "Email has been sent to advertiser.";
                        }
                        else
                        {
                            // no advertiser
                            ltlMessage.Text = "Please add a Primary Advertiser User first.";
                        }

                        return;
                    }
                }
            }

            Response.Redirect("Advertisers.aspx");
        }
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Advertisers.aspx");
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        // Hack for the Upload funcationality to work for Ajax
        ScriptManager.GetCurrent(this).RegisterPostBackControl(InsertButton);
        ScriptManager.GetCurrent(this).RegisterPostBackControl(UpdateButton);
    }

    protected void cbTrailSettings_CheckedChange(object sender, EventArgs e)
    {
        CheckBox thisCB = (CheckBox)sender;

        if (thisCB.Checked)
            panelTrialSettingsDates.Visible = true;
        else
        {
            panelTrialSettingsDates.Visible = false;

            dataFreeTrialStartDate.Text = string.Empty;
            dataFreeTrialEndDate.Text = string.Empty;
        }
    }

    protected void cvFreeTrialStartDate_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (!string.IsNullOrWhiteSpace(dataFreeTrialStartDate.Text))
        {
            DateTime dt;

            if (DateTime.TryParseExact(dataFreeTrialStartDate.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out dt))
            {
                if (dt < System.Data.SqlTypes.SqlDateTime.MinValue.Value || dt > new DateTime(DateTime.Now.Year + 100, 12, 31))
                {
                    cvFreeTrialStartDate.ErrorMessage = "Date out of range.";

                    args.IsValid = false;
                }
            }
            else
            {
                cvFreeTrialStartDate.ErrorMessage = "Invalid Date.";

                args.IsValid = false;
            }
        }
    }

    protected void cvFreeTrialEndDate_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (!string.IsNullOrWhiteSpace(dataFreeTrialEndDate.Text))
        {
            DateTime dt;

            if (DateTime.TryParseExact(dataFreeTrialEndDate.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out dt))
            {
                if (dt < System.Data.SqlTypes.SqlDateTime.MinValue.Value || dt > new DateTime(DateTime.Now.Year + 100, 12, 31))
                {
                    cvFreeTrialEndDate.ErrorMessage = "Date out of range.";

                    args.IsValid = false;
                }
            }
            else
            {
                cvFreeTrialEndDate.ErrorMessage = "Invalid Date.";

                args.IsValid = false;
            }
        }
    }

    #endregion

    #region Grid View Events
    protected void GridViewAdvertiserUsers1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string urlParams = string.Format("AdvertiserUserId={0}", GridViewAdvertiserUsers1.SelectedDataKey.Values[0]);
        //Response.Redirect("AdvertiserUsersEdit.aspx?" + urlParams, true);
    }
    #endregion
}


