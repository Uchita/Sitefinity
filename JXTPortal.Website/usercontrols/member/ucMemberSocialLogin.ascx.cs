using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SocialMedia;
using JXTPortal.Entities;
using JXTPortal.Entities.Models;

namespace JXTPortal.Website.usercontrols.member
{
    public partial class ucMemberSocialLogin : System.Web.UI.UserControl
    {
        #region Declarations

        #region Services
        private int _jobid = 0;
        private string _profession = "";

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

        #region Variables
        protected int JobID
        {
            get
            {
                if ((Request.QueryString["JobID"] != null))
                {
                    if (int.TryParse((Request.QueryString["JobID"].Trim()), out _jobid))
                    {
                        _jobid = Convert.ToInt32(Request.QueryString["JobID"]);
                    }
                    return _jobid;
                }

                return _jobid;
            }
        }

        protected string Profession
        {
            get
            {
                return Request.Params["profession"];
            }
        }

        protected string JobName
        {
            get
            {
                return Request.Params["jobname"];
            }
        }
        #endregion

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SetSocialMediaLoginButtons();
        }

        private void SetSocialMediaLoginButtons()
        {
            //Get Integration Details
            AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

            //Google login button
            if (integrations.Google != null && !string.IsNullOrWhiteSpace(integrations.Google.ClientID) && !string.IsNullOrWhiteSpace(integrations.Google.ClientSecret) && integrations.Google.Valid)
                lbSignInGoogle.Visible = true;

            ////Twitter login button
            //if (!string.IsNullOrWhiteSpace(integrations.Twitter.ConsumerKey) && !string.IsNullOrWhiteSpace(integrations.Twitter.ConsumerSecret) && integrations.Twitter.Valid)
            //    ttLoginBtn.Visible = true;

            //Facebook login button
            if (integrations.Facebook != null && !string.IsNullOrWhiteSpace(integrations.Facebook.ApplicationID) && !string.IsNullOrWhiteSpace(integrations.Facebook.ApplicationSecret) && integrations.Facebook.Valid)
            {
                lbSignInFacebook.Visible = true;
            }

            //linkedin login button
            //if (!string.IsNullOrWhiteSpace(integrations..ApplicationID) && !string.IsNullOrWhiteSpace(integrations.Google.ApplicationSecret) && integrations.Google.Valid)
            //    ggLoginBtn.Visible = true;
            string linkedinapi = string.Empty;
            using (TList<JXTPortal.Entities.GlobalSettings> tgs = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
            {
                if (tgs.Count > 0)
                {
                    JXTPortal.Entities.GlobalSettings gs = tgs[0];
                    if (!string.IsNullOrEmpty(gs.LinkedInApi))
                    {
                        lbSignInLinkedIn.Visible = true;
                        linkedinapi = gs.LinkedInApi;
                    }
                }
            }

            if (lbSignInGoogle.Visible == false && lbSignInFacebook.Visible == false && lbSignInLinkedIn.Visible == false)
            {
                phSocialMedia.Visible = false;
            }
        }


        #region Events

        protected void lbSignInFacebook_Click(object sender, EventArgs e)
        {
            FacebookMethods fb = new FacebookMethods(SessionData.Site.SiteId);

            string oauthURL = string.Empty;
            string lowerURL = Request.Url.ToString().ToLower();

            string domainToPassToRedirectURI = Request.Url.Host;
            if (Request.IsLocal)
                domainToPassToRedirectURI += ":" + Request.Url.Port;

            if (lowerURL.Contains("/member/login.aspx") || lowerURL.Contains("/member/register.aspx"))
                oauthURL = fb.OAuthMemberLoginRedirectURLGet(Request.IsSecureConnection, domainToPassToRedirectURI);
            else if (Request.Url.ToString().ToLower().Contains("/applyjob"))
                oauthURL = fb.OAuthApplyLoginRedirectURLGet(Request.IsSecureConnection, domainToPassToRedirectURI, Profession, JobName, JobID);


            if (!string.IsNullOrEmpty(oauthURL))
                Response.Redirect(oauthURL);

            ////Get Integration Details
            //AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

            //if (integrations.Facebook != null && !string.IsNullOrEmpty(integrations.Facebook.ApplicationID))
            //{
            //    string http = "http://";
            //    if (Request.IsSecureConnection)
            //        http = "https://";

            //    string urlsuffix = http + HttpContext.Current.Request.Url.Authority;

            //    oAuthFacebook _oauth = new oAuthFacebook();
            //    _oauth.ClientID = integrations.Facebook.ApplicationID;
            //    string p = (!string.IsNullOrWhiteSpace(Profession)) ? "&profession=" + HttpUtility.UrlEncode(Profession) : string.Empty;
            //    string jobname = (!string.IsNullOrWhiteSpace(JobName)) ? "&jobname=" + HttpUtility.UrlEncode(JobName) : string.Empty;
            //    _oauth.RedirectURI = urlsuffix + "/oauthcallback.aspx?cbtype=facebook&cbaction=applylogin&id=" + JobID.ToString() + p + jobname;
            //    string token = _oauth.Authorize();
            //    Response.Redirect(token);

            //}
        }

        protected void lbSignInLinkedIn_Click(object sender, EventArgs e)
        {
            LinkedInMethods li = new LinkedInMethods(SessionData.Site.SiteId);

            string oauthURL = string.Empty;

            string lowerURL = Request.Url.ToString().ToLower();

            if (lowerURL.Contains("/member/login.aspx") || lowerURL.Contains("/member/register.aspx"))
                oauthURL = li.OAuthMemberLoginRedirectURLGet(Request.IsSecureConnection, HttpContext.Current.Request.Url.Host);
            else if (Request.Url.ToString().ToLower().Contains("/applyjob"))
                oauthURL = li.OAuthApplyLoginRedirectURLGet(Request.IsSecureConnection, HttpContext.Current.Request.Url.Host, HttpContext.Current.Request.RawUrl, JobID);

            if (!string.IsNullOrEmpty(oauthURL))
                Response.Redirect(oauthURL);

            //oAuthLinkedIn _oauth = new oAuthLinkedIn();
            //string LinkedInAPI = string.Empty;
            //string urlsuffix = string.Empty;

            //using (TList<JXTPortal.Entities.GlobalSettings> tgs = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
            //{
            //    if (tgs.Count > 0)
            //    {
            //        JXTPortal.Entities.GlobalSettings gs = tgs[0];
            //        if (!string.IsNullOrEmpty(gs.LinkedInApi))
            //        {
            //            LinkedInAPI = gs.LinkedInApi;
            //            string http = "http://";
            //            if (Request.IsSecureConnection)
            //                http = "https://";
            //            urlsuffix = http + HttpContext.Current.Request.Url.Authority;
            //        }
            //    }
            //}

            //if (!string.IsNullOrWhiteSpace(LinkedInAPI))
            //    Response.Redirect(_oauth.RequestToken(LinkedInAPI, urlsuffix, JobID.ToString(), HttpContext.Current.Request.RawUrl, Utils.GetUrlReferrerDomain(), new List<string> { "cbtype=linkedin", "cbaction=ApplyLogin" }));
        }

        protected void lbSignInGoogle_Click(object sender, EventArgs e)
        {
            GoogleMethods gg = new GoogleMethods(SessionData.Site.SiteId);

            string oauthURL = string.Empty;
            string lowerURL = Request.Url.ToString().ToLower();

            if (lowerURL.Contains("/member/login.aspx") || lowerURL.Contains("/member/register.aspx"))
                oauthURL = gg.OAuthMemberLoginRedirectURLGet(Request.IsSecureConnection, HttpContext.Current.Request.RawUrl);
            else if (Request.Url.ToString().ToLower().Contains("/applyjob"))
                oauthURL = gg.OAuthApplyLoginRedirectURLGet(Request.IsSecureConnection, HttpContext.Current.Request.RawUrl);



            if (!string.IsNullOrEmpty(oauthURL))
                Response.Redirect(oauthURL);

            //string googleappid = string.Empty;
            //string googleuri = string.Empty;

            ////Get Integration Details
            //AdminIntegrations.Integrations integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

            //if (integrations.Google != null && !string.IsNullOrEmpty(integrations.Google.ClientID))
            //{
            //    googleappid = integrations.Google.ClientID;
            //}

            //googleuri = string.Format("{1}://{0}/oauthcallback.aspx?cbtype=google&cbaction=applylogin", Request.Url.Authority, (Request.IsSecureConnection) ? "https" : "http");

            //oAuthGoogle gmodule = new oAuthGoogle(googleappid, string.Empty, googleuri);
            //Session["ApplyURL"] = Request.RawUrl;
            //Response.Redirect(gmodule.Authorize());
        }

        #endregion
    }
}