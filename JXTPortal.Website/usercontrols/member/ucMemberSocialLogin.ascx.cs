﻿using System;
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
            
            if (lowerURL.Contains("/member/login.aspx") || lowerURL.Contains("/member/register.aspx"))
                oauthURL = fb.OAuthMemberLoginRedirectURLGet(Request.IsSecureConnection);
            else if (Request.Url.ToString().ToLower().Contains("/applyjob"))
                oauthURL = fb.OAuthApplyLoginRedirectURLGet(Request.IsSecureConnection, Profession, JobName, JobID);

            if (!string.IsNullOrEmpty(oauthURL))
                Response.Redirect(oauthURL);
        }

        protected void lbSignInLinkedIn_Click(object sender, EventArgs e)
        {
            LinkedInMethods li = new LinkedInMethods(SessionData.Site.SiteId);

            string oauthURL = string.Empty;

            string lowerURL = Request.Url.ToString().ToLower();

            if (lowerURL.Contains("/member/login.aspx") || lowerURL.Contains("/member/register.aspx"))
                oauthURL = li.OAuthMemberLoginRedirectURLGet(Request.IsSecureConnection);
            else if (Request.Url.ToString().ToLower().Contains("/applyjob"))
                oauthURL = li.OAuthApplyLoginRedirectURLGet(Request.IsSecureConnection, HttpContext.Current.Request.RawUrl, JobID);

            if (!string.IsNullOrEmpty(oauthURL))
                Response.Redirect(oauthURL);
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
        }

        #endregion
    }
}