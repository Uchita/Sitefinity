using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal;
using JXTPortal.Entities;
using JXTPortal.Client.Bullhorn;

namespace JXTPortal.Website.advertiser
{
    public partial class login : DefaultBase
    {
        #region "Properties"

        private int _msg = 0;
        protected int Msg
        {
            get
            {
                if ((Request.QueryString["msg"] != null))
                {
                    if (int.TryParse((Request.QueryString["msg"].Trim()), out _msg))
                    {
                        _msg = Convert.ToInt32(Request.QueryString["msg"]);
                    }
                    return _msg;
                }

                return _msg;
            }
        }

        private AdvertiserUsersService _advertiserUsersService;

        private AdvertiserUsersService AdvertiserUsersService
        {
            get
            {
                if (_advertiserUsersService == null)
                {
                    _advertiserUsersService = new AdvertiserUsersService();
                }

                return _advertiserUsersService;
            }
        }

        private AdvertisersService _advertisersService;
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

        private IntegrationsService _integrationsService;
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

        #region Page Events

        protected void Page_Init(object sender, EventArgs e)
        {
            // Is SSL.
            // CommonPage.IsSSL();

            //CommonPage.SetBrowserPageTitle(Page, "Advertiser Login");

            //is recruiter board?
            /*if (!SessionData.Site.IsJobBoard)
            {
                Response.Redirect("404.aspx");
            }*/

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            phPasswordChanged.Visible = false;
            if (!Page.IsPostBack && Msg == 1)
            {
                ltLoginError.SetLanguageCode = "LabelPwdChanged";
                phPasswordChanged.Visible = true;
            }

            SetFormValues();

            /*
            //hide register link if private site
            if (SessionData.Site != null && SessionData.Site.IsPrivateSite)
                phRegisterLink.Visible = false;*/

        }

        #endregion

        #region Methods

        private bool LoginCheck()
        {
            bool valid = false;
            ucLoginError.SetLanguageCode = "LabelAccessDenied";

            using (TList<JXTPortal.Entities.AdvertiserUsers> advertiserusers = AdvertiserUsersService.GetByUserNameSiteId(txtUserName.Text, SessionData.Site.SiteId))
            {

                if (advertiserusers.Count() > 0 && advertiserusers[0].Validated == true && (advertiserusers[0].AccountStatus.HasValue && advertiserusers[0].AccountStatus == (int)PortalEnums.Advertiser.AccountStatus.Approved))
                {
                    JXTPortal.Entities.AdvertiserUsers advuser = advertiserusers[0];
                    JXTPortal.Entities.Advertisers adv = AdvertisersService.GetByAdvertiserId(advuser.AdvertiserId);

                    // if locked and attempted within 1 hour - tell user their account has been locked - return
                    if (advuser.Status == (int)PortalEnums.Admin.UserStatus.Locked || advuser.Status == (int)PortalEnums.Admin.UserStatus.Closed)
                    {
                        DateTime CurrentTime = DateTime.Now;
                        DateTime lockedDate = CurrentTime;

                        if (advuser.LastAttemptDate.HasValue)
                        {
                            lockedDate = advuser.LastAttemptDate.Value;
                        }
                        else
                        {
                            advuser.LastAttemptDate = lockedDate;
                            AdvertiserUsersService.Update(advuser);
                        }

                        TimeSpan timespan = lockedDate.AddSeconds(3599).Subtract(CurrentTime);

                        // lock is still valid
                        if (timespan.Hours < 1 && CurrentTime < lockedDate.AddHours(1))
                        {
                            ucLoginError.SetLanguageCode = string.Format(CommonFunction.GetResourceValue("LabelTempLocked"), (timespan.Minutes < 1) ? 1 : (int)timespan.Minutes); // TODO: Language
                            return false;
                        }
                        else
                        {
                            // if more than 1 hour, reset attempt to 0, attempt date = null and locked = 0
                            advuser.LoginAttempts = 0;
                            advuser.LastAttemptDate = null;

                            AdvertiserUsersService.Update(advuser);
                        }
                    }



                    if (advuser.UserPassword == CommonFunction.EncryptMD5(txtPassword.Text))
                    {
                        if (adv != null && adv.AdvertiserAccountStatusId == (int)PortalEnums.Advertiser.AccountStatus.Approved)
                        {
                            SessionService.RemoveMember();
                            SessionService.SetAdvertiserUser(advuser);
                            valid = true;

                            // Set Attempt count = 0
                            // Last Attempt date = null
                            // Locked = 0

                            if (advuser.LoginAttempts > 0)
                            {
                                advuser.LoginAttempts = 0;
                            }

                            advuser.Status = (int)PortalEnums.Admin.UserStatus.Valid;
                            advuser.LastAttemptDate = null;
                            AdvertiserUsersService.Update(advuser);

                            //Bullhorn Integration
                            //- When advertiser user logins, we pull from BH
                            #region BH Advertiser/Users sync
                            BullhornRESTAPI BullhornRESTAPI = new BullhornRESTAPI(SessionData.Site.SiteId);
                            if (BullhornRESTAPI != null && BullhornRESTAPI.BullhornSettings != null && BullhornRESTAPI.BullhornSettings.Valid && BullhornRESTAPI.BullhornSettings.EnableAdvertiserSync)
                            {
                                string errorMsg = string.Empty;

                                using (JXTPortal.Entities.Advertisers Advertisers = AdvertisersService.GetBySiteId(SessionData.Site.SiteId).Where(s => s.AdvertiserId == advuser.AdvertiserId).FirstOrDefault())
                                {
                                    if (Advertisers != null)
                                    {
                                        BullhornRESTAPI.SyncAdvertiserAndUser(SessionData.Site.SiteId, Advertisers, advuser, !string.IsNullOrWhiteSpace(Advertisers.ExternalAdvertiserId) ? false : true, out errorMsg);
                                    }
                                }
                            }               
                            #endregion

                        }
                    }
                    else
                    {
                        // Login Failed
                        if (advuser != null)
                        {
                            advuser.LoginAttempts += 1;
                            ltLoginError.SetLanguageCode = string.Format(string.Format(CommonFunction.GetResourceValue("LabelAttemptFailed"), 5 - advuser.LoginAttempts)); // TODO: Language

                            if (advuser.LoginAttempts >= 5)
                            {
                                advuser.Status = (int)PortalEnums.Admin.UserStatus.Locked;
                                advuser.LastAttemptDate = DateTime.Now;
                                ltLoginError.SetLanguageCode = string.Format(CommonFunction.GetResourceValue("LabelAccountLocked")); // TODO: Language
                            }

                            AdvertiserUsersService.Update(advuser);
                        }
                    }
                }
            }

            phLoginError.Visible = !valid;
            return valid;
        }

        public void SetFormValues()
        {
            btnLogin.Text = CommonFunction.GetResourceValue("LabelLogin");
            rvUserName.ErrorMessage = CommonFunction.GetResourceValue("LabelUsernameRequired");
            rvPassword.ErrorMessage = CommonFunction.GetResourceValue("labellPasswordRequired");
        }

        private void UpdateLastLoginDate()
        {
            using (Entities.AdvertiserUsers advertiseruser = AdvertiserUsersService.GetByAdvertiserUserId(SessionData.AdvertiserUser.AdvertiserUserId))
            {
                advertiseruser.LastLoginDate = DateTime.Now;
                AdvertiserUsersService.Update(advertiseruser);
            }
        }

        #endregion

        #region Click Event handlers

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (LoginCheck())
            {

                if (cbRememberMe.Checked)
                {
                    HttpCookie advertiserCookie = new HttpCookie(PortalConstants.SiteCookie.AdvertiserUserCookie);

                    advertiserCookie.Value = Common.Utils.Encrypt( SessionData.AdvertiserUser.AdvertiserUserId.ToString() + "-" + SessionData.Site.AuthToken, true);
                    advertiserCookie.HttpOnly = true;

                    // If SSL then secure the cookie
                    if (Request.IsSecureConnection)
                        advertiserCookie.Secure = true;

                    //advertiserCookie["user"] = Common.Utils.Encrypt(SessionData.AdvertiserUser.AdvertiserUserId.ToString(), true);
                    advertiserCookie.Expires = DateTime.Now.AddDays(7); //last for 1 week
                    Response.Cookies.Add(advertiserCookie);

                    SessionService.RemoveMember();
                }

                //Update Last Login date
                UpdateLastLoginDate();

                if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                {
                    // only if the return url is part of the site.
                    if (Uri.IsWellFormedUriString(Request.QueryString["ReturnUrl"], UriKind.Relative))
                        Response.Redirect(Server.UrlDecode(Request.QueryString["ReturnUrl"]));
                }

                Response.Redirect("~/advertiser/default.aspx");
            }
        }

        #endregion

    }
}
