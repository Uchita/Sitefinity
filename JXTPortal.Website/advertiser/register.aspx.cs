using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using JXTPortal;
using JXTPortal.Entities;
using System.IO;
using System.Xml;

namespace JXTPortal.Website.advertiser
{
    public partial class register : System.Web.UI.Page
    {
        #region Properties

        private DynamicPagesService _dynamicPagesService = null;
        private DynamicPagesService DynamicPagesService
        {
            get
            {
                if (_dynamicPagesService == null)
                {
                    _dynamicPagesService = new DynamicPagesService();
                }
                return _dynamicPagesService;
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

        private GlobalSettingsService _globalSettingsService = null;
        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_globalSettingsService == null)
                {
                    _globalSettingsService = new GlobalSettingsService();
                }
                return _globalSettingsService;
            }
        }

        private AdvertisersService _advertisersService = null;
        private AdvertisersService AdvertisersService
        {
            get
            {
                if (_advertisersService == null)
                {
                    _advertisersService = new AdvertisersService();
                }
                return _advertisersService;
            }
        }

        private AdvertiserUsersService _advertiserusersService = null;
        private AdvertiserUsersService AdvertiserUsersService
        {
            get
            {
                if (_advertiserusersService == null)
                {
                    _advertiserusersService = new AdvertiserUsersService();
                }
                return _advertiserusersService;
            }
        }

        private DynamicContentService _dynamiccontentservice;
        private DynamicContentService DynamicContentService
        {
            get
            {
                if (_dynamiccontentservice == null)
                {
                    _dynamiccontentservice = new DynamicContentService();
                }
                return _dynamiccontentservice;
            }
        }

        private SiteLanguagesService _sitelanguagesservice;
        private SiteLanguagesService SiteLanguagesService
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

        private IndustryService _industryservice;
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
        protected void Page_Init(object sender, EventArgs e)
        {
            // Is SSL.
            // CommonPage.IsSSL();

            //CommonPage.SetBrowserPageTitle(Page, "Advertiser Register");

            //is recruiter board?
            if (!SessionData.Site.IsJobBoard)
            {
                Response.Redirect("404.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            phMessage.Visible = false;
            if (!this.IsPostBack)
            {
                phAccountType.Visible = SessionData.Site.IsJobBoard;
                LoadSiteLangauge();
                LoadIndustry();
                LoadContactMethod();

                //    PopulateAccountType();
                PopulateBusinessType();

                if (Request.QueryString["action"] == "add")
                {
                    if (SessionData.AdvertiserUser == null)
                    {
                        Response.Redirect("login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                    }

                    pnlCompanySection.Visible = false;
                    pnlCompanyDetails.Visible = false;
                    phAdvertiserFullRegister.Visible = false;
                }
            }

            SetFormValues();

        }

        private void LoadIndustry()
        {
            ddlIndustry.Items.Clear();

            using (TList<Entities.Industry> industries = IndustryService.GetBySiteId(SessionData.Site.SiteId))
            {
                industries.Filter = "Valid = True";

                if (industries.Count > 0)
                {
                    phIndustry.Visible = true;
                    phIndustrySub.Visible = false;

                    foreach (Entities.Industry industry in industries)
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

                    ddlIndustry.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), ""));

                }
                else
                {
                    phIndustry.Visible = false;
                    phIndustrySub.Visible = true;
                }
            }
        }

        private void LoadContactMethod()
        {
            ddlPreferredContactMethod.Items.Clear();
            ddlPreferredContactMethod.DataValueField = "Value";
            ddlPreferredContactMethod.DataTextField = "Key";
            ddlPreferredContactMethod.DataSource = CommonFunction.GetEnumFormattedNames<PortalEnums.Advertiser.ContactMethod>();
            ddlPreferredContactMethod.DataBind();

            ddlPreferredContactMethod.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), ""));
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
                    ddlLanguage.SelectedValue = SessionData.Language.LanguageId.ToString();
                }
            }
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

        private void InsertNewAdvertiser()
        {
            // Check if the site has Advertiser approval process
            bool isAdvertiserApprovalProcess = false;
            string redirectpage = JXTPortal.SystemPages.ADVERTISER_REGISTRATION_SUCCESS;
            using (TList<Entities.GlobalSettings> settings = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
            {
                if (settings.Count > 0)
                {
                    // Todo Naveen change this
                    if (settings[0].AdvertiserApprovalProcess.HasValue) // Change this logic from dropdown.
                    {
                        if (settings[0].AdvertiserApprovalProcess.Value == (int)PortalEnums.Admin.AdvertiserApproval.AllApprovalProcess)
                        {
                            isAdvertiserApprovalProcess = true;
                            redirectpage = JXTPortal.SystemPages.ADVERTISER_ALL_APPROVAL_PROCESS;
                        }
                        else
                        {
                            if (settings[0].AdvertiserApprovalProcess.Value == (int)PortalEnums.Admin.AdvertiserApproval.CreditCardApproved && rbAccount.Checked)
                            {
                                isAdvertiserApprovalProcess = true;
                                redirectpage = JXTPortal.SystemPages.ADVERTISER_ACC_APPROVAL_PROCESS;
                            }
                        }
                    }
                }
            }

            using (Entities.Advertisers advertisers = new Entities.Advertisers())
            {
                advertisers.AdvertiserAccountTypeId = (rbAccount.Checked) ? (int)PortalEnums.Advertiser.AccountType.Account : (int)PortalEnums.Advertiser.AccountType.Credit_Card;
                advertisers.AdvertiserBusinessTypeId = Convert.ToInt32(ddlBusinessType.SelectedValue);

                // If AdvertiserApprovalProcess is enabled for the site then pending status else approved 
                if (isAdvertiserApprovalProcess)
                    advertisers.AdvertiserAccountStatusId = (int)Entities.PortalEnums.Advertiser.AccountStatus.ApprovedPending;
                else
                    advertisers.AdvertiserAccountStatusId = (int)Entities.PortalEnums.Advertiser.AccountStatus.Approved;

                advertisers.CompanyName = CommonService.EncodeString(dataCompanyName.Text, true);
                advertisers.NoOfEmployees = CommonService.EncodeString(dataNoOfEmployees.Text, true);
                advertisers.RequireLogonForExternalApplication = true;
                advertisers.BusinessNumber = CommonService.EncodeString(txtBusinessNumber.Text, true);
                // Default Value
                advertisers.LastModified = DateTime.Now;
                if (SessionData.AdminUser != null)
                {
                    advertisers.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                }
                else
                {
                    advertisers.LastModifiedBy = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["DefaultAdminID"]);
                }
                advertisers.SiteId = SessionData.Site.SiteId;

                if (fuCompanyLogo.HasFile)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        byte[] buffer = new byte[fuCompanyLogo.PostedFile.InputStream.Length]; // Fairly arbitrary size
                        int bytesRead;
                        fuCompanyLogo.PostedFile.InputStream.Position = 0;
                        while ((bytesRead = fuCompanyLogo.PostedFile.InputStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, bytesRead);
                        }

                        advertisers.AdvertiserLogo = ms.ToArray();
                    }
                }

                advertisers.VideoLink = tbVideoLink.Text;
                advertisers.Industry = ddlIndustry.SelectedValue.ToString();
                advertisers.NominatedCompanyRole = tbNominatedCompanyRole.Text;
                advertisers.NominatedCompanyFirstName = tbNominatedCompanyFirstName.Text;
                advertisers.NominatedCompanyLastName = tbNominatedCompanyLastName.Text;
                advertisers.NominatedCompanyEmailAddress = tbNominatedCompanyEmailAddress.Text;
                advertisers.NominatedCompanyPhone = tbNominatedCompanyPhone.Text;
                if (!string.IsNullOrWhiteSpace(ddlPreferredContactMethod.SelectedValue))
                {
                    advertisers.PreferredContactMethod = Convert.ToInt32(ddlPreferredContactMethod.SelectedValue);
                }

                AdvertisersService advs = new AdvertisersService();
                if (advs.Insert(advertisers))
                {
                    using (Entities.AdvertiserUsers user = new Entities.AdvertiserUsers())
                    {
                        user.AdvertiserId = advertisers.AdvertiserId;
                        user.PrimaryAccount = true;
                        user.UserName = CommonService.EncodeString(dataUserName.Text, true);
                        user.UserPassword = CommonService.EncryptMD5(dataPassword.Text);
                        user.FirstName = CommonService.EncodeString(dataFirstName.Text, true);
                        user.Surname = CommonService.EncodeString(dataLastName.Text, true);
                        user.Email = CommonService.EncodeString(dataEmailAddress.Text, true);
                        user.EmailFormat = (int)PortalEnums.Email.EmailFormat.HTML;
                        user.ApplicationEmailAddress = CommonService.EncodeString(dataApplicationEmail.Text, true);
                        user.Phone = CommonService.EncodeString(dataPhone.Text, true);
                        user.Newsletter = false;
                        user.NewsletterFormat = (int)PortalEnums.Email.EmailFormat.HTML;
                        user.Validated = false;
                        user.ValidateGuid = Guid.NewGuid();
                        user.JobExpiryNotification = true;
                        // By default the account status for the advertiser user is always approved.
                        user.AccountStatus = (int)PortalEnums.AdvertiserUser.AccountStatus.Approved;

                        user.LastModified = DateTime.Now;
                        user.DefaultLanguageId = Convert.ToInt32(ddlLanguage.SelectedValue);
                        if (SessionData.AdminUser != null)
                        {
                            user.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                        }
                        else
                        {
                            user.LastModifiedBy = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["DefaultAdminID"]);
                        }


                        using (TList<Entities.DynamicContent> dynamiccontents = DynamicContentService.GetBySiteId(SessionData.Site.SiteId))
                        {
                            foreach (Entities.DynamicContent dynamiccontent in dynamiccontents)
                            {
                                if (dynamiccontent.DynamicContentType == ((int)PortalEnums.DynamicContent.DynamicContentType.AdvertiserTermsAndConditions) && dynamiccontent.Active)
                                {
                                    user.LastTermsAndConditionsDate = DateTime.Now;
                                }
                            }
                        }

                        AdvertiserUsersService advus = new AdvertiserUsersService();
                        if (advus.Insert(user))
                        {
                            // Send Advertiser registration email.
                            MailService.SendAdvertiserRegistration(user);

                            // Send email to administrator when Advertiser Approval Process is enabled in global settings
                            if (isAdvertiserApprovalProcess)
                            {
                                MailService.SendNewAdvertiserAlert(user, advertisers);
                            }

                            Response.Redirect(DynamicPagesService.GetDynamicPageUrl(redirectpage, "", "", ""));

                        }
                    }
                }
            }
        }

        private void InsertSubAccount()
        {
            using (Entities.Advertisers advertisers = AdvertisersService.GetByAdvertiserId(SessionData.AdvertiserUser.AdvertiserId))
            {
                using (Entities.AdvertiserUsers user = new Entities.AdvertiserUsers())
                {
                    user.AdvertiserId = advertisers.AdvertiserId;
                    user.PrimaryAccount = false;
                    user.UserName = CommonService.EncodeString(dataUserName.Text, true);
                    user.UserPassword = CommonService.EncryptMD5(dataPassword.Text);
                    user.FirstName = CommonService.EncodeString(dataFirstName.Text, true);
                    user.Surname = CommonService.EncodeString(dataLastName.Text, true);
                    user.Email = CommonService.EncodeString(dataEmailAddress.Text, true);
                    user.EmailFormat = (int)PortalEnums.Email.EmailFormat.HTML;
                    user.ApplicationEmailAddress = CommonService.EncodeString(dataApplicationEmail.Text, true);
                    user.Phone = CommonService.EncodeString(dataPhone.Text, true);
                    user.Newsletter = false;
                    user.NewsletterFormat = (int)PortalEnums.Email.EmailFormat.HTML;
                    user.Validated = false;
                    user.ValidateGuid = Guid.NewGuid();
                    user.DefaultLanguageId = Convert.ToInt32(ddlLanguage.SelectedValue);

                    // By default the account status for the advertiser user is always approved.
                    user.AccountStatus = (int)PortalEnums.AdvertiserUser.AccountStatus.Approved;

                    if (SessionData.AdminUser != null)
                    {
                        user.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                    }
                    else
                    {
                        user.LastModifiedBy = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["DefaultAdminID"]);
                    }

                    if (AdvertiserUsersService.Insert(user))
                    {
                        MailService.SendAdvertiserRegistration(user);
                        Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.ADVERTISER_REGISTRATION_SUCCESS, "", "", ""));
                    }
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                if (Request.QueryString["action"] == "add")
                {
                    InsertSubAccount();
                    litMessage.Text = string.Format(CommonFunction.GetResourceValue("LabelSubAccountCreated"));
                    phMessage.Visible = true;
                }
                else
                {
                    InsertNewAdvertiser();
                }
            }
        }

        protected void CusVal_UserName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            AdvertiserUsersService advus = new AdvertiserUsersService();
            args.IsValid = (advus.GetByUserNameSiteId(dataUserName.Text, Entities.SessionData.Site.SiteId).Count == 0);

            if (!args.IsValid)
            {
                SetFocus(dataUserName.ClientID);
            }
        }

        protected void cvalDocument_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (fuCompanyLogo.HasFile)
            {
                if (fuCompanyLogo.PostedFile == null || fuCompanyLogo.PostedFile.ContentLength == 0)
                {
                    args.IsValid = false;
                    this.cvalDocument.ErrorMessage = CommonFunction.GetResourceValue("ErrorEnsureDocumentSelected");
                    return;
                }

                // Check file name
                string fileext = fuCompanyLogo.PostedFile.FileName.Substring(fuCompanyLogo.PostedFile.FileName.Length - 4, 4).ToLower();


                if (fileext != ".jpg" && fileext != ".png" && fileext != ".gif")
                {
                    args.IsValid = false;// ErrorFileExtension
                    this.cvalDocument.ErrorMessage = CommonFunction.GetResourceValue("LabelErrorFileExtension1MB");
                    return;
                }
                // Check file size
                if (fuCompanyLogo.PostedFile.ContentLength > 1048576) // 1MB
                {
                    args.IsValid = false;// ErrorFileExtension
                    this.cvalDocument.ErrorMessage = CommonFunction.GetResourceValue("LabelErrorFileExtension1MB");
                    return;
                }

                System.Drawing.Image logo = System.Drawing.Image.FromStream(fuCompanyLogo.PostedFile.InputStream);
                if (logo.Width > 300)
                {
                    args.IsValid = false;
                    this.cvalDocument.ErrorMessage = CommonFunction.GetResourceValue("LabelErrorFileExtension1MB");
                    return;
                }
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void CusVal_EmailAddress_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!CommonFunction.VerifyEmail(dataEmailAddress.Text))
            {
                args.IsValid = false;
                SetFocus(dataEmailAddress.ClientID);
                return;
            }

            AdvertiserUsersService advus = new AdvertiserUsersService();
            using (TList<Entities.AdvertiserUsers> advusers = advus.GetByUserNameSiteId("", SessionData.Site.SiteId))
            {
                advusers.Filter = "Email = " + dataEmailAddress.Text;
                if (advusers.Count > 0)
                {
                    CusVal_EmailAddress.ErrorMessage = CommonFunction.GetResourceValue("LabelEmailExist");
                    args.IsValid = false;
                    SetFocus(dataEmailAddress.ClientID);
                    return;
                }
            }
        }

        protected void CusVal_ApplicationEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = CommonFunction.VerifyEmail(dataApplicationEmail.Text);
            if (!args.IsValid)
            {
                SetFocus(dataApplicationEmail.ClientID);
            }
        }

        protected void CusVal_NominatedCompanyEmailAddress_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(tbNominatedCompanyEmailAddress.Text))
            {
                args.IsValid = CommonFunction.VerifyEmail(tbNominatedCompanyEmailAddress.Text);
                if (!args.IsValid)
                {
                    string js = "$(document).ready(function() { $('#MemberFullRegisterHeader').click(); });\n";

                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "openFullJS", js, true);

                    SetFocus(tbNominatedCompanyEmailAddress.ClientID);
                }
            }
        }

        private void SetFocus(string clientid)
        {
            string js = "$(document).ready(function() { var el = document.getElementById(\"" + clientid + "\"); el.scrollIntoView(false); })";

            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "focusJS", js, true);
        }

        public void SetFormValues()
        {
            btnRegister.Text = CommonFunction.GetResourceValue("ButtonRegister");
            ReqVal_UserName.ErrorMessage = CommonFunction.GetResourceValue("LabelUsernameRequired");
            CusVal_UserName.ErrorMessage = CommonFunction.GetResourceValue("ErrorUsernameExist");
            ReqVal_Password.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ReqVal_ConfirmPassword.ErrorMessage = CommonFunction.GetResourceValue("ErrorConfirmPasswordNotMatch");
            ReqVal_FirstName.ErrorMessage = CommonFunction.GetResourceValue("LabelFirstnameRequired");
            ReqVal_LastName.ErrorMessage = CommonFunction.GetResourceValue("LabelSurnameRequired");
            ReqVal_Phone.ErrorMessage = CommonFunction.GetResourceValue("LabelPhoneRequired");
            ReqVal_EmailAddress.ErrorMessage = CommonFunction.GetResourceValue("LabelEmailAddressRequired");
            CusVal_EmailAddress.ErrorMessage = CommonFunction.GetResourceValue("LabelValidEmailRequired");
            ReqVal_ApplicationEmail.ErrorMessage = CommonFunction.GetResourceValue("LabelEmailAddressRequired");
            CusVal_ApplicationEmail.ErrorMessage = CommonFunction.GetResourceValue("LabelValidEmailRequired");
            CusVal_NominatedCompanyEmailAddress.ErrorMessage = CommonFunction.GetResourceValue("LabelValidEmailRequired");
            ReqVal_CompanyName.ErrorMessage = CommonFunction.GetResourceValue("LabelCompanyNameRequired");
            rfvBusinessType.ErrorMessage = CommonFunction.GetResourceValue("LabelBusinessTypeRequired");
        }
    }
}
