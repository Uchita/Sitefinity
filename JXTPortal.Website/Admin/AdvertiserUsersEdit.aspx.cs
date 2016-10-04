
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
using JXTPortal.Website;
using JXTPortal;
using JXTPortal.Entities;
using System.Linq;
using JXTPortal.Client.Bullhorn;
#endregion

public partial class AdvertiserUsersEdit : System.Web.UI.Page
{
    #region Declarations

    private int _advertiseruserid = 0;
    private int _advertiserid = 0;
    private AdvertiserUsersService _advertiserusersservice;
    private AdvertisersService _advertisersservice;
    private AdvertiserAccountStatusService _avertiseraccountstatusservice;
    private DynamicContentService _dynamicContentService;
    private SiteLanguagesService _sitelanguagesservice;
    private IntegrationsService _integrationsService;

    #endregion

    #region Properties

    protected int AdvertiserUserID
    {
        get
        {
            if ((Request.QueryString["AdvertiserUserID"] != null))
            {
                if (int.TryParse((Request.QueryString["AdvertiserUserID"].Trim()), out _advertiseruserid))
                {
                    _advertiseruserid = Convert.ToInt32(Request.QueryString["AdvertiserUserID"]);
                }
                return _advertiseruserid;
            }

            return _advertiseruserid;
        }
    }

    protected int AdvertiserID
    {
        get
        {
            if ((Request.QueryString["AdvertiserId"] != null))
            {
                if (int.TryParse((Request.QueryString["AdvertiserId"].Trim()), out _advertiserid))
                {
                    _advertiserid = Convert.ToInt32(Request.QueryString["AdvertiserId"]);
                }
                return _advertiserid;
            }
            return _advertiserid;
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

    private AdvertiserAccountStatusService AdvertiserAccountStatusService
    {
        get
        {
            if (_avertiseraccountstatusservice == null)
            {
                _avertiseraccountstatusservice = new AdvertiserAccountStatusService();
            }
            return _avertiseraccountstatusservice;
        }
    }

    private DynamicContentService DynamicContentService
    {
        get
        {
            if (_dynamicContentService == null)
            {
                _dynamicContentService = new DynamicContentService();
            }
            return _dynamicContentService;
        }
    }

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

    private IntegrationsService IntegrationsService
    {
        get
        {
            if (_integrationsService == null)
            {
                _integrationsService = new IntegrationsService();
            }

            return _integrationsService;
        }
    }

    #endregion

    #region Page

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadSiteLangauge();
            //edit existing advertiser user
            if ((Request.QueryString["AdvertiserUserID"] != null))
            {
                LoadAccountStatus();
                LoadAdvertiserUser();

            }
            //create new advertiser user for this advertiser
            else if ((Request.QueryString["AdvertiserId"] != null))
            {
                LoadPrimaryAccountSetting(AdvertiserID);
                LoadAdvertisers();

                //show "Send Validation Email" option
                plValidationEmail.Visible = true;

                bool blnFound = false;

                using (JXTPortal.Entities.Advertisers advertisers = AdvertisersService.GetByAdvertiserId(AdvertiserID))
                {
                    if (advertisers != null)
                    {
                        dataAdvertiserId.SelectedValue = AdvertiserID.ToString();
                        LoadAccountStatus();
                        blnFound = true;
                    }
                }

                if (!blnFound)
                    Response.Redirect("~/admin/advertiserusers.aspx");

            }
            else
            {
                Response.Redirect("advertiserusers.aspx");
            }
        }

        if (AdvertiserUserID > 0 && SessionData.AdminUser != null)
        {
            using (JXTPortal.Entities.AdvertiserUsers advertiseruser = AdvertiserUsersService.GetByAdvertiserUserId(AdvertiserUserID))
            {

                if (advertiseruser != null)
                {
                    using (JXTPortal.Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(advertiseruser.AdvertiserId))
                    {
                        bool isAdminUser = SessionData.AdminUser.isAdminUser;
                        bool isAdminContentEditor = SessionData.AdminUser.AdminRoleId == (int)SessionData.AdminUser.AdminRoleId;

                        bool advertiserAccountApproved = (PortalEnums.Advertiser.AccountStatus)advertiser.AdvertiserAccountStatusId == PortalEnums.Advertiser.AccountStatus.Approved;
                        bool advertiserUserValidatedApproved = advertiseruser.Validated.HasValue && advertiseruser.Validated.Value == true
                                                                && (PortalEnums.AdvertiserUser.AccountStatus)advertiseruser.AccountStatus == PortalEnums.AdvertiserUser.AccountStatus.Approved;

                        btnLoginAsAdvertiserUser.Visible =
                            ((isAdminUser || isAdminContentEditor) && (advertiser.SiteId == SessionData.Site.SiteId) && advertiserAccountApproved && advertiserUserValidatedApproved);
                    }

                    //Password locked panel
                    if (advertiseruser.Status == (int)PortalEnums.Members.UserStatus.Locked &&
                        advertiseruser.LastAttemptDate.HasValue &&
                        DateTime.Now <= advertiseruser.LastAttemptDate.Value.AddHours(1))
                    {
                        btnLoginAsAdvertiserUser.Visible = false;
                        PasswordLockedForm.Visible = true;
                        PasswordLockedTime.Text = advertiseruser.LastAttemptDate.HasValue ? advertiseruser.LastAttemptDate.Value.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt") : string.Empty;
                    }

                }
                else
                {
                    btnLoginAsAdvertiserUser.Visible = false;
                }
            }

        }
        else
        {
            btnLoginAsAdvertiserUser.Visible = false;
        }

        if (AdvertiserUserID > 0)
            UpdateButton.Visible = true;
        else
            InsertButton.Visible = true;

        ReqVal_dataUserPassword.Enabled = (AdvertiserUserID == 0);

        using (TList<JXTPortal.Entities.DynamicContent> dynamiccontents = DynamicContentService.GetBySiteId(SessionData.Site.SiteId))
        {
            foreach (JXTPortal.Entities.DynamicContent dynamiccontent in dynamiccontents)
            {
                if (dynamiccontent.DynamicContentType == ((int)PortalEnums.DynamicContent.DynamicContentType.AdvertiserTermsAndConditions) && dynamiccontent.Active)
                {
                    phLastTCDate.Visible = true;
                }
            }
        }

        //ModeSetting();
    }

    #endregion

    #region Method

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

    private void LoadAdvertisers()
    {
        dataAdvertiserId.Items.Clear();

        using (TList<JXTPortal.Entities.Advertisers> advertisers = AdvertisersService.GetBySiteId(SessionData.Site.SiteId))
        {
            dataAdvertiserId.DataSource = advertisers;
            dataAdvertiserId.DataBind();

            dataAdvertiserId.Items.Insert(0, new ListItem(CommonFunction.GetResourceValue("LabelPleaseChoose"), "0"));
        }
    }

    private void LoadPrimaryAccountSetting(int advertiserID)
    {
        bool hasAdvertiserUsers = AdvertiserUsersService.GetByAdvertiserId(advertiserID).Count > 0;

        if (!hasAdvertiserUsers)
        {
            dataPrimaryAccount.Enabled = false;
            dataPrimaryAccount.Checked = true;
        }

    }

    private void LoadAccountStatus()
    {
        using (TList<JXTPortal.Entities.AdvertiserAccountStatus> accountstatus = AdvertiserAccountStatusService.GetAll())
        {
            dataAccountStatus.DataSource = accountstatus;
            dataAccountStatus.DataBind();
        }

        dataAccountStatus.Items.Insert(0, new ListItem(" Please Choose ...", "0"));

    }

    private void LoadAdvertiserUser()
    {
        if (SessionData.AdminUser == null)
        {
            Response.Redirect("~/admin/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
            return;
        }

        if (AdvertiserUserID > 0)
        {
            JXTPortal.Entities.AdvertiserUsers advertiseruser = AdvertiserUsersService.GetByAdvertiserUserId(AdvertiserUserID);

            if (advertiseruser != null)
            {
                JXTPortal.Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(advertiseruser.AdvertiserId);

                if (SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Administrator ||
                        ((SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.ContentEditor || SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Developer) && advertiser.SiteId == SessionData.Site.SiteId))
                {
                    hfAdvertiser.Value = advertiseruser.AdvertiserId.ToString();
                    dataAdvertiserId.SelectedValue = advertiseruser.AdvertiserId.ToString();
                    dataAdvertiserId.Visible = false;
                    lbAdvertiser.Text = CommonService.DecodeString(advertiser.CompanyName);
                    lbAdvertiser.Visible = true;
                    dataPrimaryAccount.Checked = advertiseruser.PrimaryAccount;
                    dataUserName.Text = CommonService.DecodeString(advertiseruser.UserName);
                    //hfUserPassword.Value = advertiseruser.UserPassword;
                    dataFirstName.Text = CommonService.DecodeString(advertiseruser.FirstName);
                    dataSurname.Text = CommonService.DecodeString(advertiseruser.Surname);
                    dataEmail.Text = CommonService.DecodeString(advertiseruser.Email);
                    dataApplicationEmailAddress.Text = CommonService.DecodeString(advertiseruser.ApplicationEmailAddress);
                    dataPhone.Text = CommonService.DecodeString(advertiseruser.Phone);
                    dataFax.Text = CommonService.DecodeString(advertiseruser.Fax);
                    dataAccountStatus.SelectedValue = advertiseruser.AccountStatus.ToString();
                    dataNewsletter.Checked = advertiseruser.Newsletter;
                    dataNewsletterFormat.SelectedValue = advertiseruser.NewsletterFormat.ToString();
                    dataEmailFormat.SelectedValue = advertiseruser.EmailFormat.ToString();
                    dataValidated.Checked = (advertiseruser.Validated == null) ? false : (bool)advertiseruser.Validated;
                    cbJobExpiryNofification.Checked = advertiseruser.JobExpiryNotification;
                    if (advertiseruser.DefaultLanguageId.HasValue)
                    {
                        ddlLanguage.SelectedValue = advertiseruser.DefaultLanguageId.Value.ToString();
                    }
                    if (advertiseruser.LastLoginDate != null)
                        dataLastLoginDate.Text = ((DateTime)advertiseruser.LastLoginDate).ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                    if (advertiseruser.LastModified != null)
                        dataLastModified.Text = ((DateTime)advertiseruser.LastModified).ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                    if (advertiseruser.LastTermsAndConditionsDate.HasValue)
                    {
                        lbLastTermsAndConditionsDate.Text = advertiseruser.LastTermsAndConditionsDate.Value.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                    }
                    AdminUsersService aus = new AdminUsersService();
                    using (JXTPortal.Entities.AdminUsers adminuser = aus.GetByAdminUserId(advertiseruser.LastModifiedBy))
                    {
                        dataModifiedBy.Text = adminuser.UserName;
                    }

                    phExternalAdvertiserUserID.Visible = (!string.IsNullOrWhiteSpace(advertiseruser.ExternalAdvertiserUserId));
                    lbExternalAdvertiserUserID.Text = advertiseruser.ExternalAdvertiserUserId;
                }
                else
                {
                    Response.Redirect("AdvertiserUsers.aspx");
                }
            }
            else
            {
                Response.Redirect("AdvertiserUsers.aspx");
            }
        }
        else
        {
            Response.Redirect("AdvertiserUsers.aspx");
        }
    }

    private bool HasValidPrimaryUserExists(int advertiserID)
    {
        bool hasOtherPrimaryUser = false;
        using (TList<JXTPortal.Entities.AdvertiserUsers> advUsers = AdvertiserUsersService.GetByAdvertiserId(advertiserID))
        {
            foreach (JXTPortal.Entities.AdvertiserUsers thisAdvUser in advUsers)
            {
                //we want to find any primary account OTHER THAN this user
                if (AdvertiserUserID != thisAdvUser.AdvertiserUserId
                    && thisAdvUser.PrimaryAccount
                    && thisAdvUser.Validated.HasValue && thisAdvUser.Validated.Value
                    && thisAdvUser.AccountStatus.HasValue && thisAdvUser.AccountStatus.Value == (int)JXTPortal.Entities.PortalEnums.AdvertiserUser.AccountStatus.Approved)
                {
                    hasOtherPrimaryUser = true;
                    break;
                }
            }
        }
        return hasOtherPrimaryUser;
    }

    #endregion

    #region Events

    protected void CusVal_dataConfirmPassword_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (!string.IsNullOrEmpty(dataUserPassword.Text))
        {
            args.IsValid = (dataUserPassword.Text == dataConfirmPassword.Text);
        }
        else
        {
            args.IsValid = true;
        }
    }


    protected void PrimaryAccountCB_Changed(object sender, EventArgs e)
    {
        primaryAccountError.Visible = false;
        //this querystring simply represents is an EDIT of user (ie NOT a create user)
        if (Request.QueryString["AdvertiserUserID"] != null)
        {
            int thisAdvUserAdvID = Convert.ToInt32(hfAdvertiser.Value);

            bool hasOtherPrimaryUser = HasValidPrimaryUserExists(thisAdvUserAdvID);

            //at this point
            //if hasOtherPrimaryUser is true, there is at least another advertiseruser under this advertiser has the primary account flag
            //otherwise either the current advertiseruser is the only primary account or there are no primary accounts at all under this advertiser
            if (!hasOtherPrimaryUser)
            {
                //we won't allow any advertiser account to have NONE primary account at anytime
                //however, at the current discussion, multiple is allowed (may change in the future)
                if (!dataPrimaryAccount.Checked)
                {
                    primaryAccountError.Text = "At least one advertiser user account must be a 'Primary Account'";
                    primaryAccountError.Visible = true;
                }
            }
        }
    }


    protected void CusVal_dataUserName_ServerValidate(object source, ServerValidateEventArgs args)
    {
        TList<JXTPortal.Entities.AdvertiserUsers> advertiserusers = AdvertiserUsersService.GetByUserNameSiteId(dataUserName.Text, SessionData.Site.SiteId);

        if (AdvertiserUserID > 0)
        {
            if (advertiserusers.Count > 0)
            {
                if (advertiserusers[0].UserName == dataUserName.Text)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
        }
        else
        {
            args.IsValid = (advertiserusers.Count == 0);
        }

    }

    protected void btnLoginAsAdvertiserUser_Click(object sender, EventArgs e)
    {
        if (AdvertiserUserID > 0)
        {
            bool blnValid = false;
            JXTPortal.Entities.AdvertiserUsers advertiseruser = null;
            using (advertiseruser = AdvertiserUsersService.GetByAdvertiserUserId(AdvertiserUserID))
            {
                // Secruity check also
                if (advertiseruser != null
                        && Secruity_isAdvertiserPartOfTheSite(advertiseruser.AdvertiserId)
                        && advertiseruser.AccountStatus == (int)PortalEnums.Advertiser.AccountStatus.Approved
                        && (advertiseruser.Validated.HasValue && advertiseruser.Validated.Value))
                {
                    blnValid = true;
                }

            }

            if (advertiseruser != null && blnValid)
            {
                SessionService.RemoveMember();
                SessionService.SetAdvertiserUser(advertiseruser);

                //Bullhorn Integration
                //- When advertiser user logins, we pull from BH
                #region BH Advertiser/Users sync
                BullhornRESTAPI BullhornRESTAPI = new BullhornRESTAPI(SessionData.Site.SiteId);
                if (BullhornRESTAPI != null && BullhornRESTAPI.BullhornSettings != null && BullhornRESTAPI.BullhornSettings.Valid && BullhornRESTAPI.BullhornSettings.EnableAdvertiserSync)
                {
                    string errorMsg = string.Empty;

                    using (JXTPortal.Entities.Advertisers Advertisers = AdvertisersService.GetBySiteId(SessionData.Site.SiteId).Where(s => s.AdvertiserId == advertiseruser.AdvertiserId).FirstOrDefault())
                    {
                        if (Advertisers != null)
                        {
                            bool hasExternalID = !string.IsNullOrWhiteSpace(Advertisers.ExternalAdvertiserId);
                            //only sync if the advertiser account is active/approved
                            if ((PortalEnums.Advertiser.AccountStatus)Advertisers.AdvertiserAccountStatusId == PortalEnums.Advertiser.AccountStatus.Approved)
                                BullhornRESTAPI.SyncAdvertiserAndUser(SessionData.Site.SiteId, Advertisers, advertiseruser, hasExternalID ? false : true, out errorMsg);
                        }
                    }
                }               
                #endregion

                Response.Redirect("~/advertiser/default.aspx", true);
            }
            else
                AjaxControlToolkit.ToolkitScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "AdvertiserLoginError", "alert('This advertiser user has to be validated and approved first.')", true);


        }
    }

    protected bool Secruity_isAdvertiserPartOfTheSite(int _advertiserId)
    {
        // SECRUITY - ONLY valid Advertisers of that site
        bool blnValid = false;
        using (JXTPortal.Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(_advertiserId))
        {
            if (SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Administrator ||
                ((SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.ContentEditor || SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Developer) && advertiser.SiteId == SessionData.Site.SiteId))
            {
                blnValid = true;
            }
        }

        return blnValid;
    }

    protected void InsertButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid && AdvertiserID > 0)
        {
            //check the primary account flag
            primaryAccountError.Visible = false;

            int thisAdvUserAdvID = Convert.ToInt32(dataAdvertiserId.SelectedValue);

            bool hasOtherPrimaryUser = HasValidPrimaryUserExists(thisAdvUserAdvID);

            // SECRUITY - ONLY valid Advertisers of that site
            if (Secruity_isAdvertiserPartOfTheSite(AdvertiserID))
            {

                //we won't allow any advertiser account to have NONE primary account at anytime
                //however, at the current discussion, multiple is allowed (may change in the future)
                if (!hasOtherPrimaryUser && !dataPrimaryAccount.Checked)
                {
                    primaryAccountError.Text = "At least one advertiser user account must be a 'Primary Account'";
                    primaryAccountError.Visible = true;
                }
                else
                {
                    JXTPortal.Entities.AdvertiserUsers advertiseruser = new JXTPortal.Entities.AdvertiserUsers();

                    //advertiseruser.AdvertiserId = Convert.ToInt32(dataAdvertiserId.SelectedValue);
                    advertiseruser.AdvertiserId = AdvertiserID;
                    advertiseruser.AdvertiserUserId = AdvertiserUserID;
                    advertiseruser.PrimaryAccount = dataPrimaryAccount.Checked;
                    advertiseruser.UserName = CommonService.EncodeString(dataUserName.Text);
                    advertiseruser.UserPassword = CommonService.EncryptMD5(dataUserPassword.Text);
                    advertiseruser.FirstName = CommonService.EncodeString(dataFirstName.Text);
                    advertiseruser.Surname = CommonService.EncodeString(dataSurname.Text);
                    advertiseruser.Email = CommonService.EncodeString(dataEmail.Text);
                    advertiseruser.ApplicationEmailAddress = CommonService.EncodeString(dataApplicationEmailAddress.Text);
                    advertiseruser.Phone = CommonService.EncodeString(dataPhone.Text);
                    advertiseruser.Fax = CommonService.EncodeString(dataFax.Text);
                    advertiseruser.AccountStatus = (string.IsNullOrEmpty(dataAccountStatus.SelectedValue)) ? (int?)null : Convert.ToInt32(dataAccountStatus.SelectedValue);
                    advertiseruser.Newsletter = dataNewsletter.Checked;
                    advertiseruser.NewsletterFormat = Convert.ToInt32(dataNewsletterFormat.SelectedValue);
                    advertiseruser.EmailFormat = Convert.ToInt32(dataEmailFormat.SelectedValue);
                    advertiseruser.Validated = dataValidated.Checked;
                    advertiseruser.ValidateGuid = Guid.NewGuid();
                    advertiseruser.DefaultLanguageId = Convert.ToInt32(ddlLanguage.SelectedValue);

                    advertiseruser.LastModified = DateTime.Now;
                    if (SessionData.AdminUser != null)
                    {
                        advertiseruser.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                    }
                    else
                    {
                        advertiseruser.LastModifiedBy = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["DefaultAdminID"]);
                    }

                    //LOGIC for validation email sending (ONLY for create, updates uses a seperate function)
                    //if current user is JXT admin: NO email
                    //if current user is client's admin:
                    //           - if checkbox ticked: YES email
                    //           - if checkbox not ticked: NO email

                    if (plValidationEmail.Visible == true && cbValidationEmail.Checked)
                    {
                        MailService.SendAdvertiserRegistration(advertiseruser);
                    }

                    AdvertiserUsersService.Insert(advertiseruser);
                    
                        #region BH Advertiser/Users sync
                        BullhornRESTAPI BullhornRESTAPI = new BullhornRESTAPI(SessionData.Site.SiteId);
                        if (BullhornRESTAPI != null && BullhornRESTAPI.BullhornSettings != null && BullhornRESTAPI.BullhornSettings.Valid && BullhornRESTAPI.BullhornSettings.EnableAdvertiserSync)
                        {
                            string errorMsg = string.Empty;

                            using (JXTPortal.Entities.Advertisers Advertisers = AdvertisersService.GetBySiteId(SessionData.Site.SiteId).Where(s => s.AdvertiserId == advertiseruser.AdvertiserId).FirstOrDefault())
                            {
                                if (Advertisers != null)
                                {
                                    //only sync if the advertiser account is active/approved
                                    if ((PortalEnums.Advertiser.AccountStatus)Advertisers.AdvertiserAccountStatusId == PortalEnums.Advertiser.AccountStatus.Approved)
                                        BullhornRESTAPI.SyncAdvertiserAndUser(SessionData.Site.SiteId, Advertisers, advertiseruser, true, out errorMsg);
                                }
                            }
                        }
                        #endregion


                    Response.Redirect("AdvertiserUsers.aspx");
                }

            }

        }
    }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            //check the primary account flag
            primaryAccountError.Visible = false;

            int thisAdvUserAdvID = Convert.ToInt32(hfAdvertiser.Value);

            bool hasOtherPrimaryUser = HasValidPrimaryUserExists(thisAdvUserAdvID);
            //we won't allow any advertiser account to have NONE primary account at anytime
            //however, at the current discussion, multiple is allowed (may change in the future)
            if (!hasOtherPrimaryUser && !dataPrimaryAccount.Checked)
            {
                primaryAccountError.Text = "At least one advertiser user account must be a 'Primary Account'";
                primaryAccountError.Visible = true;
            }
            else
            {
                //JXTPortal.Entities.AdvertiserUsers advertiseruser = new JXTPortal.Entities.AdvertiserUsers();
                using (JXTPortal.Entities.AdvertiserUsers advertiseruser = AdvertiserUsersService.GetByAdvertiserUserId(AdvertiserUserID))
                {
                    if (advertiseruser != null && Secruity_isAdvertiserPartOfTheSite(advertiseruser.AdvertiserId))
                    {
                        //advertiseruser.AdvertiserUserId = AdvertiserUserID;
                        //advertiseruser.AdvertiserId = Convert.ToInt32(hfAdvertiser.Value);
                        advertiseruser.PrimaryAccount = dataPrimaryAccount.Checked;
                        advertiseruser.UserName = dataUserName.Text;
                        //advertiseruser.UserPassword = hfUserPassword.Value;
                        if (!string.IsNullOrEmpty(dataUserPassword.Text))
                        {
                            advertiseruser.UserPassword = CommonService.EncryptMD5(dataUserPassword.Text);
                        }

                        advertiseruser.FirstName = dataFirstName.Text;
                        advertiseruser.Surname = dataSurname.Text;
                        advertiseruser.Email = dataEmail.Text;
                        advertiseruser.ApplicationEmailAddress = dataApplicationEmailAddress.Text;
                        advertiseruser.Phone = dataPhone.Text;
                        advertiseruser.Fax = dataFax.Text;
                        advertiseruser.AccountStatus = (string.IsNullOrEmpty(dataAccountStatus.SelectedValue)) ? (int?)null : Convert.ToInt32(dataAccountStatus.SelectedValue);
                        advertiseruser.Newsletter = dataNewsletter.Checked;
                        advertiseruser.NewsletterFormat = Convert.ToInt32(dataNewsletterFormat.SelectedValue);
                        advertiseruser.EmailFormat = Convert.ToInt32(dataEmailFormat.SelectedValue);
                        advertiseruser.Validated = dataValidated.Checked;
                        advertiseruser.LastModified = DateTime.Now;
                        advertiseruser.JobExpiryNotification = cbJobExpiryNofification.Checked;
                        advertiseruser.DefaultLanguageId = Convert.ToInt32(ddlLanguage.SelectedValue);

                        if (SessionData.AdminUser != null)
                        {
                            advertiseruser.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                        }
                        else
                        {
                            advertiseruser.LastModifiedBy = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["DefaultAdminID"]);
                        }

                        AdvertiserUsersService.Update(advertiseruser);

                        #region BH Advertiser/Users sync
                        BullhornRESTAPI BullhornRESTAPI = new BullhornRESTAPI(SessionData.Site.SiteId);
                        if (BullhornRESTAPI != null && BullhornRESTAPI.BullhornSettings != null && BullhornRESTAPI.BullhornSettings.Valid && BullhornRESTAPI.BullhornSettings.EnableAdvertiserSync)
                        {
                            string errorMsg = string.Empty;

                            using (JXTPortal.Entities.Advertisers Advertisers = AdvertisersService.GetBySiteId(SessionData.Site.SiteId).Where(s => s.AdvertiserId == advertiseruser.AdvertiserId).FirstOrDefault())
                            {
                                if (Advertisers != null)
                                {
                                    //only sync if the advertiser account is active/approved
                                    if ((PortalEnums.Advertiser.AccountStatus)Advertisers.AdvertiserAccountStatusId == PortalEnums.Advertiser.AccountStatus.Approved)
                                        BullhornRESTAPI.SyncAdvertiserAndUser(SessionData.Site.SiteId, Advertisers, advertiseruser, true, out errorMsg);
                                }
                            }
                        }
                        #endregion
                    }
                }

                Response.Redirect("AdvertiserUsers.aspx");
            }
        }
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdvertiserUsers.aspx");

    }

    protected void btnPasswordUnlock_Click(object sender, EventArgs e)
    {
        if (AdvertiserUserID > 0)
        {
            using (JXTPortal.Entities.AdvertiserUsers advertiseruser = AdvertiserUsersService.GetByAdvertiserUserId(AdvertiserUserID))
            {
                if (advertiseruser != null && advertiseruser.Status == (int)PortalEnums.Members.UserStatus.Locked)
                {
                    advertiseruser.Status = (int)PortalEnums.Members.UserStatus.Valid;
                    advertiseruser.LastAttemptDate = null;
                    advertiseruser.LoginAttempts = 0;

                    AdvertiserUsersService.Update(advertiseruser);
                }
            }
            Response.Redirect(Request.RawUrl);
        }
    }


    #endregion

    protected void CusVal_EmailAddress_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (!CommonFunction.VerifyEmail(dataEmail.Text))
        {
            args.IsValid = false;
            SetFocus(dataEmail.ClientID);
            return;
        }

        AdvertiserUsersService advus = new AdvertiserUsersService();
        using (TList<JXTPortal.Entities.AdvertiserUsers> advusers = advus.GetByUserNameSiteId("", SessionData.Site.SiteId))
        {
            advusers.Filter = "Email = " + dataEmail.Text;
            if (InsertButton.Visible)
            {
                if (advusers.Count > 0)
                {
                    CusVal_EmailAddress.ErrorMessage = CommonFunction.GetResourceValue("LabelEmailExist");
                    args.IsValid = false;
                    SetFocus(dataEmail.ClientID);
                    return;
                }
            }
            else
            {
                if (advusers.Count > 0)
                {
                    foreach (JXTPortal.Entities.AdvertiserUsers advuser in advusers)
                    {
                        if (advuser.AdvertiserUserId != AdvertiserUserID)
                        {
                            CusVal_EmailAddress.ErrorMessage = CommonFunction.GetResourceValue("LabelEmailExist");
                            args.IsValid = false;
                            SetFocus(dataEmail.ClientID);
                            return;
                        }
                    }
                }
            }
        }
    }

}


