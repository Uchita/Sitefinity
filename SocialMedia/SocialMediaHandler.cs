using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Entities.Models;
using JXTPortal;
using System.Web;
using JXTPortal.Entities;
using JXTPortal.Common;

namespace SocialMedia
{
    public class SocialMediaHandlerBase
    {
        #region Services
        internal GlobalSettingsService _globalSettingsService = null;

        internal GlobalSettingsService GlobalSettingsService
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

        internal IntegrationsService _integrationsService;
        internal IntegrationsService IntegrationsService
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

        internal SitesService _sitesService;
        internal SitesService SiteService
        {
            get
            {
                if (_sitesService == null)
                {
                    _sitesService = new SitesService();
                }

                return _sitesService;
            }
        }
        #endregion

        internal AdminIntegrations.Integrations integrations;

        public SocialMediaHandlerBase(int siteID)
        {
            integrations = IntegrationsService.AdminIntegrationsForSiteGet(siteID);
        }
    }

    public class FacebookMethods : SocialMediaHandlerBase
    {
        int _siteID;

        public FacebookMethods(int siteID)
            : base(siteID)
        {
            _siteID = siteID;
        }

        /// <summary>
        /// Use this method for Jobs Apply Page
        /// </summary>
        public string OAuthApplyLoginRedirectURLGet(bool isSecureConnection, string urlAuthority, string profession, string jobName, int jobID)
        {
            if (integrations.Facebook != null && !string.IsNullOrEmpty(integrations.Facebook.ApplicationID))
            {
                Sites site = SiteService.GetBySiteId(_siteID);

                string http = "http://";
                if (isSecureConnection)
                    http = "https://";

                string urlsuffix = http + site.SiteUrlAlias;

                oAuthFacebook _oauth = new oAuthFacebook();
                _oauth.ClientID = integrations.Facebook.ApplicationID;
                string p = (!string.IsNullOrWhiteSpace(profession)) ? "&profession=" + HttpUtility.UrlEncode(profession) : string.Empty;
                string jobname = (!string.IsNullOrWhiteSpace(jobName)) ? "&jobname=" + HttpUtility.UrlEncode(jobName) : string.Empty;
                _oauth.RedirectURI = urlsuffix + "/oauthcallback.aspx?cbtype=facebook&cbaction=applylogin&id=" + jobID.ToString() + p + jobname;
                string token = _oauth.GetAuthorizationUrl();
                return token;
            }
            return null;

        }

        /// <summary>
        /// Use this method for Member Login/Register page
        /// </summary>
        public string OAuthMemberLoginRedirectURLGet(bool isSecureConnection, string urlAuthority)
        {
            if (integrations.Facebook != null && !string.IsNullOrEmpty(integrations.Facebook.ApplicationID))
            {
                Sites site = SiteService.GetBySiteId(_siteID);

                string http = "http://";
                if (isSecureConnection)
                    http = "https://";

                string urlsuffix = http + site.SiteUrlAlias;

                oAuthFacebook _oauth = new oAuthFacebook();
                _oauth.ClientID = integrations.Facebook.ApplicationID;
                _oauth.RedirectURI = urlsuffix + "/oauthcallback.aspx?cbtype=facebook&cbaction=login";

                HttpContext.Current.Session["SocialRequestedURL"] = HttpUtility.UrlEncode(_oauth.RedirectURI);

                string token = _oauth.GetAuthorizationUrl();
                return token;
            }
            return null;

        }



    }

    public class LinkedInMethods : SocialMediaHandlerBase
    {
        int _siteID;

        public LinkedInMethods(int siteID)
            : base(siteID)
        {
            _siteID = siteID;
        }

        /// <summary>
        /// Use this method for Jobs Apply Page
        /// </summary>
        public string OAuthApplyLoginRedirectURLGet(bool isSecureConnection, string urlAuthority, string urlRaw, int jobID)
        {
            oAuthLinkedIn _oauth = new oAuthLinkedIn();
            string LinkedinAPI = string.Empty;
            string urlsuffix = string.Empty;

            using (TList<JXTPortal.Entities.GlobalSettings> tgs = GlobalSettingsService.GetBySiteId(_siteID))
            {
                if (tgs.Count > 0)
                {
                    JXTPortal.Entities.GlobalSettings gs = tgs[0];
                    if (!string.IsNullOrEmpty(gs.LinkedInApi))
                    {
                        LinkedinAPI = gs.LinkedInApi;

                        Sites site = SiteService.GetBySiteId(_siteID);

                        string http = "http://";
                        if (isSecureConnection)
                            http = "https://";

                        urlsuffix = http + site.SiteUrlAlias;
                    }
                }
            }

            string redirectURL = _oauth.RequestToken(LinkedinAPI, urlsuffix, jobID.ToString(), urlRaw, Utils.GetUrlReferrerDomain(), new List<string> { "cbtype=linkedin", "cbaction=ApplyLogin" });

            if (!string.IsNullOrWhiteSpace(redirectURL))
                return redirectURL;

            return null;

        }


        /// <summary>
        /// Use this method for Member Login/Register page
        /// </summary>
        public string OAuthMemberLoginRedirectURLGet(bool isSecureConnection, string urlAuthority)
        {
            oAuthLinkedIn _oauth = new oAuthLinkedIn();
            string LinkedinAPI = string.Empty;
            string urlsuffix = string.Empty;

            using (TList<JXTPortal.Entities.GlobalSettings> tgs = GlobalSettingsService.GetBySiteId(_siteID))
            {
                if (tgs.Count > 0)
                {
                    JXTPortal.Entities.GlobalSettings gs = tgs[0];
                    if (!string.IsNullOrEmpty(gs.LinkedInApi))
                    {
                        LinkedinAPI = gs.LinkedInApi;

                        Sites site = SiteService.GetBySiteId(_siteID);

                        string http = "http://";
                        if (isSecureConnection)
                            http = "https://";

                        urlsuffix = http + site.SiteUrlAlias;
                    }
                }
            }



            string redirectURLForLinkedIn = urlsuffix + "/oauthcallback.aspx?cbtype=linkedin&cbaction=login";
            HttpContext.Current.Session["SocialRequestedURL"] = redirectURLForLinkedIn;

            string redirectURL = _oauth.RequestLoginToken(LinkedinAPI, redirectURLForLinkedIn);
            //string redirectURL = _oauth.RequestToken(LinkedinAPI, urlsuffix, jobID.ToString(), urlRaw, Utils.GetUrlReferrerDomain(), new List<string> { "cbtype=linkedin", "cbaction=ApplyLogin" });

            if (!string.IsNullOrWhiteSpace(redirectURL))
                return redirectURL;

            return null;

        }

    }

    public class GoogleMethods : SocialMediaHandlerBase
    {
        int _siteID;

        public GoogleMethods(int siteID)
            : base(siteID)
        {
            _siteID = siteID;
        }

        /// <summary>
        /// Use this method for Jobs Apply Page
        /// </summary>
        public string OAuthApplyLoginRedirectURLGet(bool isSecureConnection, string urlRaw)
        {
            if (integrations.Google != null && !string.IsNullOrEmpty(integrations.Google.ClientID))
            {
                string googleappid = string.Empty;
                string googleuri = string.Empty;

                Sites site = SiteService.GetBySiteId(_siteID);

                string http = "http://";
                if (isSecureConnection)
                    http = "https://";

                string urlsuffix = http + site.SiteUrlAlias;

                googleappid = integrations.Google.ClientID;
                googleuri = string.Format("{0}/oauthcallback.aspx?cbtype=google&cbaction=applylogin", urlsuffix);

                oAuthGoogle gmodule = new oAuthGoogle(googleappid, string.Empty, googleuri);

                HttpContext.Current.Session["ApplyURL"] = urlRaw;
                HttpContext.Current.Session["SocialRequestedURL"] = googleuri;

                string googleURL = gmodule.Authorize();

                if (!string.IsNullOrWhiteSpace(googleURL))
                    return googleURL;
            }
            return null;
        }


        /// <summary>
        /// Use this method for Member Login/Register page
        /// </summary>
        public string OAuthMemberLoginRedirectURLGet(bool isSecureConnection, string urlRaw)
        {
            if (integrations.Google != null && !string.IsNullOrEmpty(integrations.Google.ClientID))
            {
                string googleappid = string.Empty;
                string googleuri = string.Empty;

                Sites site = SiteService.GetBySiteId(_siteID);

                string http = "http://";
                if (isSecureConnection)
                    http = "https://";

                string urlsuffix = http + site.SiteUrlAlias;

                googleappid = integrations.Google.ClientID;
                googleuri = string.Format("{0}/oauthcallback.aspx?cbtype=google&cbaction=login", urlsuffix);

                oAuthGoogle gmodule = new oAuthGoogle(googleappid, string.Empty, googleuri);
                HttpContext.Current.Session["ApplyURL"] = urlRaw;
                HttpContext.Current.Session["SocialRequestedURL"] = googleuri;

                string googleURL = gmodule.AuthorizeURLGetWithCodeType();

                if (!string.IsNullOrWhiteSpace(googleURL))
                    return googleURL;
            }
            return null;
        }

    }
}
