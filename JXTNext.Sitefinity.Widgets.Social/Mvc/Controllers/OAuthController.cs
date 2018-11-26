using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Skybrud.Social.Instagram;
using Skybrud.Social.Instagram.OAuth;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Telerik.Sitefinity.Configuration;
using JXTNext.Sitefinity.Widgets.Social.Mvc.Configuration;
using JXTNext.Sitefinity.Common.Helpers;

namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Controllers
{
    public class OAuthController : ApiController
    {
        ConfigManager manager = ConfigManager.GetManager();
        private readonly string redirectUrl = "/instagram/oauth";
        private readonly string sitefinityPath = "/Sitefinity";
        private readonly string instagramPublicScopeValue = "publiccontent";
        private readonly string instagramPublicContentValue = "public_content";
        InstagramOAuthClient client;
        private SiteSettingsHelper siteSettingsHelper;

        public OAuthController()
        {
            siteSettingsHelper = new SiteSettingsHelper();
            

            client = new InstagramOAuthClient
            {
                ClientId = siteSettingsHelper.GetCurrentSiteInstagramClientIdToken(),
                ClientSecret = siteSettingsHelper.GetCurrentSiteInstagramClientSecret(),
                RedirectUri = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + redirectUrl
            };
        }

        [Authorize]
        [HttpGet]
        public void Index()
        {
            string state = Guid.NewGuid().ToString();

            siteSettingsHelper.SetCurrentSiteInstagramAccessToken(state);
            
            string authorizationUrl = client.GetAuthorizationUrl(state, InstagramScope.PublicContent).Replace(instagramPublicScopeValue, instagramPublicContentValue);

            HttpContext.Current.Response.Redirect(authorizationUrl);
            
        }

        [HttpGet]
        public void Index(string code)
        {
            var response = client.GetAccessTokenFromAuthCode(code);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                siteSettingsHelper.SetCurrentSiteInstagramAccessToken(response.Body.AccessToken);
                

                HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + sitefinityPath);
            }
        }
    }
}
