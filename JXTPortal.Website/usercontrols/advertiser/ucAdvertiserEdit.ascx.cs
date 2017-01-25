using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Drawing;
using JXTPortal.Common;
using JXTPortal.Common.Extensions
;
using System.IO;
using JXTPortal.Website;
using System.Xml;
using JXTPortal.Client.Bullhorn;
using System.Configuration;

namespace JXTPortal.Website.usercontrols.advertiser
{
    public partial class ucAdvertiserEdit : System.Web.UI.UserControl
    {
        #region Declarations

        private int AdvertiserUserId = 0;
        private int AdvertiserId = 0;
        private byte[] _abytFile;

        #endregion

        #region Properties

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Advertiser Edit");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Entities.SessionData.AdvertiserUser == null)
            {
                Response.Redirect("~/advertiser/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
                return;
            }

            AdvertiserId = Entities.SessionData.AdvertiserUser.AdvertiserId;
            AdvertiserUserId = Entities.SessionData.AdvertiserUser.AdvertiserUserId;

            if (!string.IsNullOrEmpty(Request.QueryString["AdvertiserUserId"]))
            {
                int.TryParse(Request.QueryString["AdvertiserUserId"], out AdvertiserUserId);
            }

            if (!Page.IsPostBack)
            {
                LoadContactMethod();
                LoadSiteLangauge();
                LoadDetail();
                
                LoadIndustry();
            }

            SetFormValues();
        }

        AdvertiserUsersService _AdvertiserUsersService;
        AdvertiserUsersService AdvUserService
        {
            get
            {
                if (_AdvertiserUsersService == null)
                {
                    _AdvertiserUsersService = new AdvertiserUsersService();
                }

                return _AdvertiserUsersService;
            }
        }

        AdvertisersService _AdvertiserService;
        AdvertisersService AdvService
        {
            get
            {
                if (_AdvertiserService == null)
                {
                    _AdvertiserService = new AdvertisersService();
                }

                return _AdvertiserService;
            }
        }

        private AdvertiserBusinessTypeService _advertiserBusinessTypeService = null;
        private AdvertiserBusinessTypeService AdvertiserBusinessTypeService
        {
            get
            {
                if (_advertiserBusinessTypeService == null)
                {
                    _advertiserBusinessTypeService = new AdvertiserBusinessTypeService();
                }
                return _advertiserBusinessTypeService;
            }
        }

        private AdvertiserAccountTypeService _advertiserAccountTypeService = null;
        private AdvertiserAccountTypeService AdvertiserAccountTypeService
        {
            get
            {
                if (_advertiserAccountTypeService == null)
                {
                    _advertiserAccountTypeService = new AdvertiserAccountTypeService();
                }
                return _advertiserAccountTypeService;
            }
        }

        private GlobalSettingsService _globalsettingsservice = null;
        public GlobalSettingsService GlobalSettingsService
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

        private SiteLanguagesService _sitelanguagesservice = null;
        public SiteLanguagesService SiteLanguagesService
        {
            get
            {
                if (_sitelanguagesservice == null)
                {
                    _sitelanguagesservice = new SiteLanguagesService();
                }
                return _sitelanguagesservice;
            }
        }

        private IndustryService _industryservice = null;
        public IndustryService IndustryService
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

        private void LoadDetail()
        {
            LoadEmailFormat();
            PopulateBusinessType();

            using (GlobalSettings gs = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId).FirstOrDefault())
            {
                phJobExpiryNotification.Visible = !gs.JobExpiryNotification;
            }

            using (Entities.AdvertiserUsers advu = AdvUserService.GetByAdvertiserUserId(AdvertiserUserId))
            {
                if (advu != null)
                {
                    pnlCompanyDetails.Visible = advu.PrimaryAccount;
                    pnlAdvertiserLogo.Visible = advu.PrimaryAccount;

                    if (SessionData.AdvertiserUser.AdvertiserId != advu.AdvertiserId)
                    {
                        Response.Redirect("~/advertiser/login.aspx");
                        return;
                    }

                    using (Entities.Advertisers adv = AdvService.GetByAdvertiserId(advu.AdvertiserId))
                    {
                        AdvertiserId = adv.AdvertiserId;

                        //PortalEnums.Advertiser.AccountType accountType = (PortalEnums.Advertiser.AccountType)adv.AdvertiserAccountTypeId;
                        //dataAccountType.Text = accountType.ToString().Replace("_", " ");

                        dataCompanyName.Text = CommonService.DecodeString(adv.CompanyName);
                        dataWebAddress.Text = CommonService.DecodeString(adv.WebAddress);
                        dataAccountsPayableEmail.Text = CommonService.DecodeString(adv.AccountsPayableEmail);

                        dataStreetAddress1.Text = CommonService.DecodeString(adv.StreetAddress1);
                        dataStreetAddress2.Text = CommonService.DecodeString(adv.StreetAddress2);

                        dataPostalAddress1.Text = CommonService.DecodeString(adv.PostalAddress1);
                        dataPostalAddress2.Text = CommonService.DecodeString(adv.PostalAddress2);

                        dataBusinessNumber.Text = CommonService.DecodeString(adv.BusinessNumber);
                        dataNoOfEmployees.Text = CommonService.DecodeString(adv.NoOfEmployees);

                        ddlBusinessType.SelectedValue = adv.AdvertiserBusinessTypeId.ToString();
                        txtContent.Text = adv.Profile;

                        dataFirstName.Text = CommonService.DecodeString(advu.FirstName);
                        dataLastName.Text = CommonService.DecodeString(advu.Surname);
                        dataPhone.Text = CommonService.DecodeString(advu.Phone);
                        dataFax.Text = CommonService.DecodeString(advu.Fax);
                        dataEmailAddress.Text = CommonService.DecodeString(advu.Email);
                        dataFax.Text = CommonService.DecodeString(advu.Fax);
                        dataApplicationEmail.Text = CommonService.DecodeString(advu.ApplicationEmailAddress);
                        dataEmailFormat.SelectedValue = advu.EmailFormat.ToString();

                        tbVideoLink.Text = adv.VideoLink;
                        ddlIndustry.SelectedValue = adv.Industry;
                        tbNominatedCompanyRole.Text = adv.NominatedCompanyRole;
                        tbNominatedCompanyFirstName.Text = adv.NominatedCompanyFirstName;
                        tbNominatedCompanyLastName.Text = adv.NominatedCompanyLastName;
                        tbNominatedCompanyEmailAddress.Text = adv.NominatedCompanyEmailAddress;
                        tbNominatedCompanyPhone.Text = adv.NominatedCompanyPhone;
                        ddlPreferredContactMethod.SelectedValue = (adv.PreferredContactMethod.HasValue) ? adv.PreferredContactMethod.ToString() : string.Empty;

                        dataUserName.Text = advu.UserName;
                        cbJobExpiryNofification.Checked = advu.JobExpiryNotification;
                        if (advu.DefaultLanguageId.HasValue)
                        {
                            ddlLanguage.SelectedValue = advu.DefaultLanguageId.Value.ToString();
                        }


                        if (adv.AdvertiserLogo != null || string.IsNullOrWhiteSpace(adv.AdvertiserLogoUrl) == false)
                        {
                            if (!string.IsNullOrWhiteSpace(adv.AdvertiserLogoUrl))
                            {
                                imgLogo.ImageUrl = string.Format(@"/media/{0}/{1}?ver={2}", ConfigurationManager.AppSettings["AdvertisersFolder"], adv.AdvertiserLogoUrl,adv.LastModified.ToEpocTimestamp());
                            }
                            else
                            {
                                imgLogo.ImageUrl = string.Format("{0}?advertiserid={1}&ver={2}",Page.ResolveUrl("~/getfile.aspx"), Convert.ToString(advu.AdvertiserId),adv.LastModified.ToEpocTimestamp());
                            }
                            lblNoLogo.Visible = false;
                            lblRemoveLogo.Visible = true;
                            chkRemoveLogo.Visible = true;
                            imgLogo.Visible = true;
                        }
                        else
                        {
                            lblNoLogo.Visible = true;
                            imgLogo.Visible = false;
                            lblRemoveLogo.Visible = false;
                            chkRemoveLogo.Visible = false;
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/advertiser/");
                }
            }
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

        private void LoadSiteLangauge()
        {
            using (TList<SiteLanguages> sitelanguages = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId))
            {
                phLanguage.Visible = (sitelanguages.Count > 1);
                ddlLanguage.Items.Clear();
                foreach (SiteLanguages sitelang in sitelanguages)
                {
                    ddlLanguage.Items.Add(new ListItem(sitelang.SiteLanguageName, sitelang.LanguageId.ToString()));
                }
            }
        }


        private void LoadEmailFormat()
        {
            EmailFormatsService efs = new EmailFormatsService();
            dataEmailFormat.DataSource = efs.GetAll();
            dataEmailFormat.DataBind();
        }

        private void PopulateBusinessType()
        {
            bool useDefault = false;

            TList<Entities.AdvertiserBusinessType> advertiserbusinesstype = AdvertiserBusinessTypeService.GetSiteBusinessTypes(SessionData.Site.SiteId, out useDefault);
            ddlBusinessType.DataValueField = (useDefault) ? "AdvertiserBusinessTypeID" : "BusinessTypeParentID";

            ddlBusinessType.DataSource = advertiserbusinesstype;
            ddlBusinessType.DataTextField = "AdvertiserBusinessTypeName";
            ddlBusinessType.DataBind();

            ddlBusinessType.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelSelectBusinessType"), "0"));
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                using (Entities.Advertisers advertiser = AdvService.GetByAdvertiserId(AdvertiserId))
                {
                    advertiser.AdvertiserId = AdvertiserId;
                    advertiser.CompanyName = CommonService.EncodeString(dataCompanyName.Text, true);
                    advertiser.WebAddress = CommonService.EncodeString(dataWebAddress.Text, true);
                    advertiser.AccountsPayableEmail = CommonService.EncodeString(dataAccountsPayableEmail.Text, true);
                    advertiser.StreetAddress1 = CommonService.EncodeString(dataStreetAddress1.Text, true);
                    advertiser.StreetAddress2 = CommonService.EncodeString(dataStreetAddress2.Text, true);
                    advertiser.PostalAddress1 = CommonService.EncodeString(dataPostalAddress1.Text, true);
                    advertiser.PostalAddress2 = CommonService.EncodeString(dataPostalAddress2.Text, true);
                    advertiser.BusinessNumber = CommonService.EncodeString(dataBusinessNumber.Text, true);
                    advertiser.NoOfEmployees = CommonService.EncodeString(dataNoOfEmployees.Text, true);
                    if (ddlBusinessType.Visible)
                    {
                        advertiser.AdvertiserBusinessTypeId = Convert.ToInt32(ddlBusinessType.SelectedValue);
                    }

                    advertiser.VideoLink = tbVideoLink.Text;
                    advertiser.Industry = ddlIndustry.SelectedValue;
                    advertiser.NominatedCompanyRole = tbNominatedCompanyRole.Text;
                    advertiser.NominatedCompanyFirstName = tbNominatedCompanyFirstName.Text;
                    advertiser.NominatedCompanyLastName = tbNominatedCompanyLastName.Text;
                    advertiser.NominatedCompanyEmailAddress = tbNominatedCompanyEmailAddress.Text;
                    advertiser.NominatedCompanyPhone = tbNominatedCompanyPhone.Text;
                    advertiser.PreferredContactMethod = (!string.IsNullOrWhiteSpace(ddlPreferredContactMethod.SelectedValue)) ? Convert.ToInt32(ddlPreferredContactMethod.SelectedValue) : (int?)null;

                    advertiser.Profile = txtContent.Text;

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

                        advertiser.AdvertiserLogo = abytFile;
                    }

                    AdvService.Update(advertiser);
                    litMessage.Text = CommonFunction.GetResourceValue("LabelAdvertiserEditSuccess");
                }

                using (Entities.AdvertiserUsers advertiseruser = AdvUserService.GetByAdvertiserUserId(AdvertiserUserId))
                {
                    advertiseruser.AdvertiserId = AdvertiserId;
                    advertiseruser.AdvertiserUserId = AdvertiserUserId;
                    advertiseruser.FirstName = CommonService.EncodeString(dataFirstName.Text, true);
                    advertiseruser.Surname = CommonService.EncodeString(dataLastName.Text, true);
                    advertiseruser.Phone = CommonService.EncodeString(dataPhone.Text, true);
                    advertiseruser.Fax = CommonService.EncodeString(dataFax.Text, true);
                    advertiseruser.ApplicationEmailAddress = CommonService.EncodeString(dataApplicationEmail.Text, true);
                    advertiseruser.EmailFormat = Convert.ToInt32(dataEmailFormat.SelectedValue);
                    advertiseruser.NewsletterFormat = Convert.ToInt32(dataEmailFormat.SelectedValue);
                    advertiseruser.UserName = CommonService.EncodeString(dataUserName.Text, true);
                    advertiseruser.JobExpiryNotification = cbJobExpiryNofification.Checked;
                    advertiseruser.DefaultLanguageId = Convert.ToInt32(ddlLanguage.SelectedValue);
                    AdvUserService.Update(advertiseruser);

                    //while we have the advertiser user object, run the BH sync
                    //Bullhorn Integration
                    //- When advertiser user validates, we push account to BH
                    #region BH Advertiser/Users sync
                    BullhornRESTAPI BullhornRESTAPI = new BullhornRESTAPI(JXTPortal.Entities.SessionData.Site.SiteId);
                    if (BullhornRESTAPI != null && BullhornRESTAPI.BullhornSettings != null && BullhornRESTAPI.BullhornSettings.Valid && BullhornRESTAPI.BullhornSettings.EnableAdvertiserSync)
                    {
                        string errorMsg = string.Empty;

                        using (JXTPortal.Entities.Advertisers Advertisers = new AdvertisersService().GetBySiteId(JXTPortal.Entities.SessionData.Site.SiteId).Where(s => s.AdvertiserId == AdvertiserId).FirstOrDefault())
                        {
                            if (Advertisers != null)
                            {
                                //only sync if the advertiser account is active/approved
                                if ((PortalEnums.Advertiser.AccountStatus)Advertisers.AdvertiserAccountStatusId == PortalEnums.Advertiser.AccountStatus.Approved)
                                    BullhornRESTAPI.SyncAdvertiserAndUser(JXTPortal.Entities.SessionData.Site.SiteId, Advertisers, advertiseruser, true, out errorMsg);
                            }
                        }
                    }

                }

            }
            #endregion


        }

        public void SetFormValues()
        {
            btnUpdate.Text = CommonFunction.GetResourceValue("ButtonUpdate");
            dataNewsletter.Text = CommonFunction.GetResourceValue("LabelSubscribeToNewsLetter");
            ReqVal_CompanyName.ErrorMessage = CommonFunction.GetResourceValue("LabelCompanyNameRequired");
            ReqVal_AccountsPayableEmail.ErrorMessage = CommonFunction.GetResourceValue("LabelEmailAddressRequired");
            rfvBusinessType.ErrorMessage = CommonFunction.GetResourceValue("LabelBusinessTypeRequired");
            ReqVal_FirstName.ErrorMessage = CommonFunction.GetResourceValue("LabelFirstnameRequired");
            ReqVal_LastName.ErrorMessage = CommonFunction.GetResourceValue("LabelSurnameRequired");
            ReqVal_EmailAddress.ErrorMessage = CommonFunction.GetResourceValue("LabelValidEmailRequired");
            ReqVal_ApplicationEmail.ErrorMessage = CommonFunction.GetResourceValue("LabelValidEmailRequired");
            cvalFileName.ErrorMessage = CommonFunction.GetResourceValue("LabelInvalidImage");
            cvalFileType.ErrorMessage = CommonFunction.GetResourceValue("LabelReInvalidImage");
            CusVal_NominatedCompanyEmailAddress.ErrorMessage = CommonFunction.GetResourceValue("LabelValidEmailRequired");
        }

        private void SetFocus(string clientid)
        {
            string js = "$(document).ready(function() { var el = document.getElementById(\"" + clientid + "\"); el.scrollIntoView(false); })";

            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "focusJS", js, true);
        }

        protected void CusVal_NominatedCompanyEmailAddress_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(tbNominatedCompanyEmailAddress.Text))
            {
                args.IsValid = CommonFunction.VerifyEmail(tbNominatedCompanyEmailAddress.Text);
                if (!args.IsValid)
                {
                    SetFocus(btnUpdate.ClientID);
                }
            }
        }


    }
}