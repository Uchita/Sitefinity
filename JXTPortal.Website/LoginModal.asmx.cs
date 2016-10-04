using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using JXTPortal.Data;
using JXTPortal.Entities;
using JXTPortal;


namespace JXTPortal.Website
{
    /// <summary>
    /// Summary description for LoginModal
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class LoginModal : System.Web.Services.WebService
    {
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


        [WebMethod(EnableSession=true)]
        public string MemberLogin(string username, string password)
        {
            bool valid = false;

            using (JXTPortal.Entities.Members member = MembersService.GetBySiteIdUsername(SessionData.Site.SiteId, username))
            {
                if (member != null && member.Valid && member.Validated && member.Password == CommonService.EncryptMD5(password))
                {
                    SessionService.RemoveAdvertiserUser();
                    SessionService.SetMember(member);
                    valid = true;
                }
            }

            return (valid) ? "success" : CommonFunction.GetResourceValue("LabelAccessDenied");
        }

        [WebMethod(EnableSession = true)]
        public bool IsMemberLoggedIn()
        {
            return (SessionData.Member != null);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true)]
        public string GetLoginWithLinkedInURL()
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

            oAuthLinkedIn limodule = new oAuthLinkedIn();
            limodule.ConsumerKey = linkedinconsumerkey;
            limodule.ConsumerSecret = linkedinconsumersecret;

            string result = string.Empty;
            string urlsuffix = string.Empty;
            string http = (HttpContext.Current.Request.IsSecureConnection) ? "https://":"http://";

            urlsuffix = http + HttpContext.Current.Request.Url.Host;
            result = limodule.RequestToken(linkedinconsumerkey, urlsuffix);

            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true)]
        public string GetLoginWithFacebookURL()
        {
            string facebookappid = string.Empty;
            string facebookuri = string.Empty;

            GlobalSettingsService service = new GlobalSettingsService();
            using (TList<Entities.GlobalSettings> globalsettinglist = service.GetBySiteId(SessionData.Site.SiteId))
            {
                Entities.GlobalSettings globalsetting = globalsettinglist[0];
                facebookappid = globalsetting.FacebookAppId;
            }

            SitesService siteservice = new SitesService();
            using (Entities.Sites site = siteservice.GetBySiteId(SessionData.Site.SiteId))
            {
                if (site != null)
                {
                    if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["SocialMediaLoginURLSuffix"]))
                    {
                        site.SiteUrl = ConfigurationManager.AppSettings["SocialMediaLoginURLSuffix"];
                    }

                    facebookuri = string.Format("http://{0}/oauthcallback.aspx", site.SiteUrl);
                }
            }

            oAuthFacebook fbmodule = new oAuthFacebook();
            fbmodule.ClientID = facebookappid;
            fbmodule.RedirectURI = facebookuri;

            return fbmodule.Authorize();
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true)]
        public string GetLoginWithGoogleURL()
        {
            string googleappid = string.Empty;
            string googleuri = string.Empty;

            GlobalSettingsService service = new GlobalSettingsService();
            using (TList<Entities.GlobalSettings> globalsettinglist = service.GetBySiteId(SessionData.Site.SiteId))
            {
                Entities.GlobalSettings globalsetting = globalsettinglist[0];
                googleappid = globalsetting.GoogleClientId;
            }

            SitesService siteservice = new SitesService();
            using (Entities.Sites site = siteservice.GetBySiteId(SessionData.Site.SiteId))
            {
                if (site != null)
                {
                    if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["SocialMediaLoginURLSuffix"]))
                    {
                        site.SiteUrl = ConfigurationManager.AppSettings["SocialMediaLoginURLSuffix"];
                    }

                    googleuri = string.Format("http://{0}/oauthcallback.aspx", site.SiteUrl);
                }
            }

            oAuthGoogle gmodule = new oAuthGoogle(googleappid, string.Empty, googleuri);

            return gmodule.Authorize();
        }
    }
}
