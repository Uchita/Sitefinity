using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal;

using SocialMedia.Client.AICD;
using JXTPortal.Client.Salesforce;
using JXTPortal.Entities.Models;
using JXTPortal.Common;
using System.Web.SessionState;
using JXTPortal.Client.Bullhorn;

namespace JXTPortal.Website.members
{
    public partial class login : System.Web.UI.Page
    {
        #region "Properties"

        private MembersService _membersService;
        private MembersService MembersService
        {
            get
            {
                if (_membersService == null)
                {
                    _membersService = new MembersService();
                }

                return _membersService;
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

        #endregion

        #region Page Events

        protected void Page_Init(object sender, EventArgs e)
        {
            // Is SSL.
            // CommonPage.IsSSL();

            //CommonPage.SetBrowserPageTitle(Page, "Member Login");

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //hide register link if private site
            if (SessionData.Site != null && SessionData.Site.IsPrivateSite)
                phMemberRegisterLink.Visible = false;

            SetFormValues();

            if( !string.IsNullOrEmpty(Request["OAuthError"]) )
                ltErrorMessage.Text = SocialOAuthLoginErrorMessageGet(Convert.ToInt32(Request["OAuthError"]));

            //SetSocialMediaLoginButtons();
        }

        #endregion

        #region Methods

        private bool LoginCheck()
        {
            bool valid = false;

            JXTPortal.Entities.Members member = MembersService.GetBySiteIdUsername(SessionData.Site.MasterSiteId, txtUserName.Text);
            if (member != null)
            {
                if (member.Valid && member.Validated)
                {
                    if (member.Status == (int)PortalEnums.Admin.UserStatus.Locked || member.Status == (int)PortalEnums.Admin.UserStatus.Closed) // Closed will never hit
                    {
                        DateTime CurrentTime = DateTime.Now;
                        DateTime lockedDate = CurrentTime;


                        if (member.LastAttemptDate.HasValue)
                        {
                            lockedDate = member.LastAttemptDate.Value;
                        }
                        else
                        {
                            member.LastAttemptDate = lockedDate;
                            MembersService.Update(member);
                        }

                        TimeSpan timespan = lockedDate.AddSeconds(3599).Subtract(CurrentTime);


                        // lock is still valid
                        if (timespan.Hours < 1 && CurrentTime < lockedDate.AddHours(1))
                        {
                            ltErrorMessage.Text = string.Format(CommonFunction.GetResourceValue("LabelTempLocked"), (timespan.Minutes < 1) ? 1 : (int)timespan.Minutes); // TODO: Language
                            return false;
                        }
                        else
                        {
                            // if more than 1 hour, reset attempt to 0, attempt date = null and locked = 0
                            member.LoginAttempts = 0;
                            member.LastAttemptDate = null;

                            MembersService.Update(member);
                        }
                    }


                    if (member.Password == CommonService.EncryptMD5(txtPassword.Text))
                    {
                        // SALESFORCE - Update the details from Sales force
                        if (GetFromSalesforceAndSave(member.EmailAddress, member.ExternalMemberId))
                        {
                            member = MembersService.GetByMemberId(member.MemberId);
                        }

                        // BULLHORN Sync
                        string errorMsg = string.Empty;
                        BullhornRESTAPI bullhornRestAPI = new BullhornRESTAPI(SessionData.Site.SiteId);
                        bullhornRestAPI.SyncCandidate(member, out errorMsg);


                        SessionService.RemoveAdvertiserUser();
                        SessionService.SetMember(member);
                        valid = true;


                        // Set Attempt count = 0
                        // Last Attempt date = null
                        // Locked = 0

                        if (member.LoginAttempts > 0)
                        {
                            member.LoginAttempts = 0;
                        }

                        member.Status = (int)PortalEnums.Admin.UserStatus.Valid;
                        member.LastAttemptDate = null;

                        // Update Last Login Date of the Member
                        member.LastLogon = DateTime.Now;
                        MembersService.Update(member);
                        member.Dispose();
                    }
                    else
                    {
                        // Login Failed
                        if (member != null)
                        {
                            member.LoginAttempts += 1;
                            ltErrorMessage.Text = string.Format(string.Format(CommonFunction.GetResourceValue("LabelAttemptFailed"), 5 - member.LoginAttempts)); // TODO: Language

                            if (member.LoginAttempts >= 5)
                            {
                                member.Status = (int)PortalEnums.Admin.UserStatus.Locked;
                                member.LastAttemptDate = DateTime.Now;
                                ltErrorMessage.Text = string.Format(CommonFunction.GetResourceValue("LabelAccountLocked")); // TODO: Language
                            }

                            MembersService.Update(member);
                        }
                    }
                }
            }

            return valid;
        }


        public void SetFormValues()
        {
            btnLogin.Text = CommonFunction.GetResourceValue("ButtonSubmit");
        }

        public void SetSocialMediaLoginButtons()
        {
            //Get Integration Details
            //AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

            //Google login button
            //if (integrations.Google != null && !string.IsNullOrWhiteSpace(integrations.Google.ClientID) && !string.IsNullOrWhiteSpace(integrations.Google.ClientSecret) && integrations.Google.Valid)
            //    ggLoginBtn.Visible = true;

            ////Twitter login button
            //if (!string.IsNullOrWhiteSpace(integrations.Twitter.ConsumerKey) && !string.IsNullOrWhiteSpace(integrations.Twitter.ConsumerSecret) && integrations.Twitter.Valid)
            //    ttLoginBtn.Visible = true;

            //Facebook login button
            //if (integrations.Facebook != null && !string.IsNullOrWhiteSpace(integrations.Facebook.ApplicationID) && !string.IsNullOrWhiteSpace(integrations.Facebook.ApplicationSecret) && integrations.Facebook.Valid)
            //    fbLoginBtn.Visible = true;

            //linkedin login button
            //if (!string.IsNullOrWhiteSpace(integrations..ApplicationID) && !string.IsNullOrWhiteSpace(integrations.Google.ApplicationSecret) && integrations.Google.Valid)
            //    ggLoginBtn.Visible = true;

        }

        //RELATES to LoginErrorCodeGet() in oauthcallback.aspx.cs
        private string SocialOAuthLoginErrorMessageGet(int errorCode)
        {
            switch (errorCode)
            {
                case 1:
                    return CommonFunction.GetResourceValue("LabelAccessDenied");
                case 2:
                    return CommonFunction.GetResourceValue("LabelFullPermissionRequired"); //TODO ERROR MESSAGE
                case 3:
                    return CommonFunction.GetResourceValue("LabelAccessDenied"); //TODO ERROR MESSAGE
                case 5:
                    return CommonFunction.GetResourceValue("LabelAccessDenied"); //TODO ERROR MESSAGE
            }
            return CommonFunction.GetResourceValue("LabelAccessDenied");//TODO ERROR MESSAGE
        }

        #endregion

        #region Click Event handlers

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (LoginCheck())
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                {
                    // only if the return url is part of the site.
                    if (Uri.IsWellFormedUriString(Request.QueryString["ReturnUrl"], UriKind.Relative) ||
                        (Request.QueryString["ReturnUrl"].Contains("peopleprofilers.applyourjobs.com/"))            // Third party client Return URLs
                        )
                        Response.Redirect(Server.UrlDecode(Request.QueryString["ReturnUrl"]));
                }
                                
                Response.Redirect("~/member/default.aspx");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(ltErrorMessage.Text))
                {
                    ltErrorMessage.Text = CommonFunction.GetResourceValue("LabelAccessDenied");
                }
            }
        }

        //protected void btnLogin_Facebook(object sender, EventArgs e)
        //{
        //    string result = GetLoginWithFacebookInURL();
        //    Response.Redirect(result);
        //}

        //protected void btnLogin_Twitter(object sender, EventArgs e)
        //{
        //    string result = GetLoginWithTwitterInURL();
        //    Response.Redirect(result);
        //}

        //protected void btnLogin_Google(object sender, EventArgs e)
        //{
        //    string result = GetLoginWithGoogleInURL();
        //    Response.Redirect(result);
        //}

        //protected void btnLogin_LinkedIn(object sender, EventArgs e)
        //{
        //    string result = GetLoginWithLinkedInInURL();
        //    Response.Redirect(result);
        //}

        #endregion

        #region Social Media Login Methods 

        //public string GetLoginWithFacebookInURL()
        //{
        //    //Get Integration Details
        //    AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

        //    if (integrations.Facebook != null)
        //    {
        //        string facebookappid = integrations.Facebook.ApplicationID;

        //        string http = Request.IsSecureConnection ? "https" : "http";
        //        string domain = Request.Url.Authority;

        //        string facebookuri = HttpUtility.UrlEncode(http + "://" + domain + "/oauthcallback.aspx?cbtype=facebook&cbaction=login");

        //        Session["SocialRequestedURL"] = facebookuri;

        //        oAuthFacebook fbmodule = new oAuthFacebook();
        //        //Consumer Key & redirecturi should be acquired from db
        //        fbmodule.ClientID = facebookappid;
        //        fbmodule.RedirectURI = facebookuri;
        //        fbmodule.Permissions = "email,user_work_history,user_location,user_birthday,user_education_history";

        //        return fbmodule.AuthorizeWithoutURLEncode();
        //    }
        //    return Request.RawUrl;
        //}

        //public string GetLoginWithTwitterInURL()
        //{
        //    //Get Integration Details
        //    AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

        //    string consumer_key = integrations.Twitter.ConsumerKey; // TODO REMOVE "Zf7nzDNHgz5ULqyLgCE54fgJV";
        //    string consumer_secret = integrations.Twitter.ConsumerSecret; // TODO REMOVE "twuq4jZ4zuUbkMZQ4kh0UfZutrPY9LHY834a9YMSJy2jJdOD8Z";
        //    string twitterurl = "http://localhost:49188/oauthlogincallback.aspx?cbtype=twitter&cbaction=login";

        //    Session["SocialRequestedURL"] = twitterurl;

        //    //twitter doesn't need to have the url encoded
        //    oAuthTwitter tmodule = new oAuthTwitter(consumer_key, consumer_secret, twitterurl);

        //    return tmodule.GetAuthorizeURL();
        //}

        //public string GetLoginWithGoogleInURL()
        //{
        //    //Get Integration Details
        //    AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

        //    if (integrations.Google != null)
        //    {
        //        string googleappid = integrations.Google.ClientID; 

        //        string http = Request.IsSecureConnection ? "https" : "http";
        //        string domain = Request.Url.Authority;

        //        string googleuri = http + "://" + domain + "/oauthcallback.aspx?cbtype=google&cbaction=login";

        //        Session["SocialRequestedURL"] = googleuri;

        //        oAuthGoogle gmodule = new oAuthGoogle(googleappid, string.Empty, googleuri);

        //        return gmodule.AuthorizeURLGetWithCodeType();
        //    }
        //    return Request.RawUrl;
        //}

        //public string GetLoginWithLinkedInInURL()
        //{
        //    string linkedinconsumerkey = string.Empty;
        //    string linkedinconsumersecret = string.Empty;

        //    GlobalSettingsService service = new GlobalSettingsService();
        //    using (TList<Entities.GlobalSettings> globalsettinglist = service.GetBySiteId(SessionData.Site.SiteId))
        //    {
        //        Entities.GlobalSettings globalsetting = globalsettinglist[0];
        //        linkedinconsumerkey = globalsetting.LinkedInApi;
        //        linkedinconsumersecret = globalsetting.LinkedInApiSecret;
        //    }

        //    oAuthLinkedIn limodule = new oAuthLinkedIn();
        //    limodule.ConsumerKey = linkedinconsumerkey;
        //    limodule.ConsumerSecret = linkedinconsumersecret;

        //    linkedinconsumerkey = limodule.ConsumerKey;

        //    string http = Request.IsSecureConnection ? "https" : "http";
        //    string domain = Request.Url.Authority;

        //    string urlsuffix = http + "://" + domain + "/oauthcallback.aspx?cbtype=linkedin&cbaction=login";

        //    Session["SocialRequestedURL"] = urlsuffix;

        //    return limodule.RequestLoginToken(linkedinconsumerkey, urlsuffix);

        //}

        #endregion

        #region SALESFORCE

        /// <summary>
        /// SALESFORCE - If Member doesn't exist in Platform check if exist in SALESFORCE and grab the details from Salesforce AND send reset password email to member.
        /// </summary>
        /// <param name="strEmail"></param>
        private bool GetFromSalesforceAndSave(string strEmail, string SalesForceContactID)
        {
            SalesforceMemberSync memberSync = new SalesforceMemberSync();
            int memberid = 0; string errormsg = string.Empty;

            // Get Candidate from Salesforce by email
            // And If candidate exists in Sales force, save in Boardy platform.
            if (memberSync.GetContactFromSalesForceAndSave(strEmail, SalesForceContactID, SessionData.Site.MasterSiteId, ref memberid, ref errormsg) && memberid > 0)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
