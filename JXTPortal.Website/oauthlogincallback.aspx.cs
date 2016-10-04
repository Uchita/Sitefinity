using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Xml;
using System.Text;
using System.Runtime;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Configuration;
using SocialMedia;
using JXTPortal.Common;
using JXTPortal.Entities;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using NotesFor.HtmlToOpenXml;
using System.Net;
using JXTPortal.Entities.Models;

namespace JXTPortal.Website
{
    public partial class oauthlogincallback : System.Web.UI.Page
    {
        #region Properties
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

        private GlobalSettingsService _globalSettingsService;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            PortalEnums.SocialMedia.SocialMediaType callbackType;
            bool typeParseOK = Enum.TryParse<PortalEnums.SocialMedia.SocialMediaType>(Request["cbtype"], true, out callbackType);

            PortalEnums.SocialMedia.OAuthCallbackAction callbackAction;
            bool actionParseOK = Enum.TryParse<PortalEnums.SocialMedia.OAuthCallbackAction>(Request["cbaction"], true, out callbackAction);

            string lastRequestedURL = Session["SocialRequestedURL"].ToString();

            if (typeParseOK && actionParseOK && !string.IsNullOrEmpty(lastRequestedURL))
            {
                switch (callbackType)
                {
                    case PortalEnums.SocialMedia.SocialMediaType.Google:
                        OAuthCallBackGoogle(callbackAction, lastRequestedURL, Request["code"]);
                        break;
                    case PortalEnums.SocialMedia.SocialMediaType.Facebook:
                        OAuthCallBackFacebook(callbackAction, lastRequestedURL, Request["code"]);
                        break;
                    //case PortalEnums.SocialMedia.SocialMediaType.Twitter:
                    //    OAuthCallBackTwitter(callbackAction, lastRequestedURL, Request["oauth_token"], Request["oauth_verifier"]);
                    //    break;
                    case PortalEnums.SocialMedia.SocialMediaType.LinkedIn:
                        OAuthCallBackLinkedIn(callbackAction, lastRequestedURL, Request["code"]);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                //TODO: ERROR
                Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("OAuthorizationFailed"));
            }
        }

        #region Facebook Methods
        private bool OAuthCallBackFacebook(PortalEnums.SocialMedia.OAuthCallbackAction callbackAction, string requestedURL, string code)
        {
            //Get Integration Details
            AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

            string facebookappid = integrations.Facebook.ApplicationID; //TODO REMOVE "10153216502584621";
            string facebooksecret = integrations.Facebook.ApplicationSecret; //TODO REMOVE "142b0615239c220e596b64c98cb48c02";
            string facebookuri = requestedURL;

            oAuthFacebook oauthfb = new oAuthFacebook();
            //Consumer Key & redirecturi should be acquired from db
            oauthfb.ClientID = facebookappid;
            oauthfb.ClientSecret = facebooksecret;
            oauthfb.RedirectURI = facebookuri;
            oauthfb.Permissions = "email,user_work_history,user_location,user_birthday,user_education_history";
            oauthfb.Code = code;

            //get access token using code
            string access_token = oauthfb.RetreiveAccessTokenWithFBCode();

            if (string.IsNullOrEmpty(access_token))
            {
                Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("OAuthorizationFailed"));
                return false;
            }

            FacebookUserDetails fbDetails = oauthfb.RetreiveUserDetails(access_token);

            if (fbDetails == null)
            {
                Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("OAuthorizationFailed"));
                return false;
            }

            switch (callbackAction)
            {
                case PortalEnums.SocialMedia.OAuthCallbackAction.Login:
                case PortalEnums.SocialMedia.OAuthCallbackAction.Register:
                    int loginErrorCode = 0; //0 means no error

                    loginErrorCode = ProcessSocialUser(fbDetails.id, fbDetails.email, fbDetails.first_name, fbDetails.last_name);

                    if (loginErrorCode == 0)
                        Response.Redirect("~/member/default.aspx");
                    else
                        Response.Redirect("~/member/login.aspx?oautherror=" + loginErrorCode);

                    break;
                case PortalEnums.SocialMedia.OAuthCallbackAction.Apply:
                    break;
                default:
                    break;
            }
            return false;
        }

        #endregion

        #region Twitter Methods

        //private void OAuthCallBackTwitter(PortalEnums.SocialMedia.OAuthCallbackAction callbackAction, string requestedURL, string oauth_token, string oauth_verifier)
        //{
        //    //Get Integration Details
        //    AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

        //    string consumer_key = integrations.Twitter.ConsumerKey; //TODO REMOVE "Zf7nzDNHgz5ULqyLgCE54fgJV";
        //    string consumer_secret = integrations.Twitter.ConsumerSecret; //TODO REMOVE "twuq4jZ4zuUbkMZQ4kh0UfZutrPY9LHY834a9YMSJy2jJdOD8Z";

        //    oAuthTwitter twitter = new oAuthTwitter(consumer_key, consumer_secret, string.Empty);
        //    twitter.GetUserDetails(oauth_token, oauth_verifier);

        //    switch (callbackAction)
        //    {
        //        case PortalEnums.SocialMedia.OAuthCallbackAction.Login:
        //        case PortalEnums.SocialMedia.OAuthCallbackAction.Register:                                   
        //            break;
        //        case PortalEnums.SocialMedia.OAuthCallbackAction.Apply:
        //            break;
        //        default:
        //            break;
        //    }
        //}

        #endregion

        #region Google Methods

        private void OAuthCallBackGoogle(PortalEnums.SocialMedia.OAuthCallbackAction callbackAction, string requestedURL, string code)
        {
            //Get Integration Details
            AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

            string googleappid = integrations.Google.ClientID; //TODO REMOVE  "651228533452-puk89gaoaf20aoa564l462gbas3p41ve.apps.googleusercontent.com";
            string googleappsecret = integrations.Google.ClientSecret; //TODO REMOVE  "RgTeBf8fDxcAKbMS3cSaQxrh";
            string googleuri = requestedURL;

            oAuthGoogle gmodule = new oAuthGoogle(googleappid, googleappsecret, googleuri);
            string access_token = gmodule.GetAccessTokenUsingCode(code);

            GoogleUser ggUser = gmodule.GetUserInfoUsingAccessToken(access_token);

            switch (callbackAction)
            {
                case PortalEnums.SocialMedia.OAuthCallbackAction.Login:
                case PortalEnums.SocialMedia.OAuthCallbackAction.Register:
                    int loginErrorCode = 0; //0 means no error

                    loginErrorCode = ProcessSocialUser(ggUser.id, ggUser.email, ggUser.given_name, ggUser.family_name);

                    if (loginErrorCode == 0)
                        Response.Redirect("~/member/default.aspx");
                    else
                        Response.Redirect("~/member/login.aspx?oautherror=" + loginErrorCode);
                    break;
                case PortalEnums.SocialMedia.OAuthCallbackAction.Apply:
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region LinkedIn Methods

        private void OAuthCallBackLinkedIn(PortalEnums.SocialMedia.OAuthCallbackAction callbackAction, string requestedURL, string code)
        {
            string linkedinconsumerkey = string.Empty;
            string linkedinconsumersecret = string.Empty;

            GlobalSettingsService service = new GlobalSettingsService();
            using (TList<Entities.GlobalSettings> globalsettinglist = service.GetBySiteId(SessionData.Site.SiteId))
            {
                Entities.GlobalSettings globalsetting = globalsettinglist[0];
                linkedinconsumerkey = globalsetting.LinkedInApi;
                linkedinconsumersecret = globalsetting.LinkedInApiSecret;
            }

            string consumer_key = linkedinconsumerkey;
            string consumer_secret = linkedinconsumersecret;
            string googleuri = requestedURL;

            //init a linkedin module to exchange for an access token using the oauth token
            oAuthLinkedIn limodule = new oAuthLinkedIn(consumer_key, consumer_secret);

            string s = limodule.oAuth2AccessToken(code, HttpUtility.UrlEncode(requestedURL), consumer_key, consumer_secret);

            string strOAuthToken = string.Empty;
            string strOAuthTokenSecret = string.Empty;

            //extract the access token from linkedin
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Dictionary<string, string> oAuthResult = jss.Deserialize<Dictionary<string, string>>(s);
            string accessToken = oAuthResult["access_token"];

            if (string.IsNullOrEmpty(accessToken))
            {
                Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("OAuthorizationFailed"));
                return;
            }

            //use the access token to get profile and email
            string profileJson = limodule.oAuth2GetProfile(accessToken, true);
            string email = limodule.oAuth2GetEmail(accessToken, true);
            LinkedInProfile profile = jss.Deserialize<LinkedInProfile>(profileJson);

            if (profile == null || string.IsNullOrEmpty(email))
            {
                Response.Redirect("~/member/login.aspx?oautherror=" + LoginErrorCodeGet("OAuthorizationFailed"));
                return;
            }

            switch (callbackAction)
            {
                case PortalEnums.SocialMedia.OAuthCallbackAction.Login:
                case PortalEnums.SocialMedia.OAuthCallbackAction.Register:
                    int loginErrorCode = 0; //0 means no error

                    loginErrorCode = ProcessSocialUser(profile.id, email.Replace("\"", ""), profile.firstName, profile.lastName);

                    if (loginErrorCode == 0)
                        Response.Redirect("~/member/default.aspx");
                    else
                        Response.Redirect("~/member/login.aspx?oautherror=" + loginErrorCode);
                    break;
                case PortalEnums.SocialMedia.OAuthCallbackAction.Apply:
                    break;
                default:
                    break;
            }
        }

        private LinkedInProfile RetrievePeopleProfile(string linkedinconsumerkey, string linkedinconsumersecret, string token, string tokenSecret)
        {
            string stringResult = string.Empty;
            oAuthLinkedIn _oauth = new oAuthLinkedIn(linkedinconsumerkey, linkedinconsumersecret);

            _oauth.Token = token;
            _oauth.TokenSecret = tokenSecret;

            string profileJson = _oauth.GetUserInfo();

            JavaScriptSerializer ser = new JavaScriptSerializer();
            LinkedInProfile thisProfile = ser.Deserialize<LinkedInProfile>(profileJson);
            
            return thisProfile;
        }

        private string RetrievePeopleEmail(string linkedinconsumerkey, string linkedinconsumersecret, string token, string tokenSecret)
        {
            string result = string.Empty;
            oAuthLinkedIn _oauth = new oAuthLinkedIn(linkedinconsumerkey, linkedinconsumersecret);

            _oauth.Token = token;
            _oauth.TokenSecret = tokenSecret;

            return result = _oauth.GetUserEmail();
        }
        #endregion

        #region Login / Register Methods

        private int ProcessSocialUser(string externalUserID, string email, string firstName, string lastName)
        {
            int loginErrorCode = 0;
            try
            {
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                    loginErrorCode = LoginErrorCodeGet("InputError");
                else
                {
                    bool newMemberCreated = false;
                    string newMemberPassword = null;
                    using (Entities.Members member = MembersService.SocialMediaUserHandler(externalUserID, email, firstName, lastName, out newMemberCreated, out newMemberPassword))
                    {
                        //log user in
                        if (member.Valid)
                        {
                            SessionService.SetMember(member);
                            member.LastLogon = DateTime.Now;

                            MembersService.Update(member);
                        }
                        else
                            loginErrorCode = LoginErrorCodeGet("InvalidAccount");

                        if (loginErrorCode == 0 && newMemberCreated)
                        {
                            if (!string.IsNullOrEmpty(SessionData.Site.MemberRegistrationNotificationEmail))
                            {
                                //Send confirmation email to new member and site's admin
                                MailService.SendMemberRegistrationToSiteAdmin(member, null, SessionData.Site.MemberRegistrationNotificationEmail);
                            }

                            //Send confirmation email to new member
                            MailService.SendNewJobApplicationAccount(member, newMemberPassword);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                loginErrorCode = LoginErrorCodeGet("Exception");
            }
            return loginErrorCode;
        }

        private int LoginErrorCodeGet(string errorType)
        {
            switch (errorType)
            {
                case "InvalidAccount":
                    return 1;
                case "OAuthorizationFailed":
                    return 2;
                case "InputError":
                    return 3;
                case "Exception":
                    return 5;
            }
            return 99;
        }

        #endregion


    }

}
