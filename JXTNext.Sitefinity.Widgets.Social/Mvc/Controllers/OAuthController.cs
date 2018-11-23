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
        InstagramConfig instagramConfig;
        InstagramOAuthClient client;
        private SiteSettingsHelper siteSettingsHelper;

        public OAuthController()
        {
            siteSettingsHelper = new SiteSettingsHelper();
            instagramConfig = manager.GetSection<InstagramConfig>();

            client = new InstagramOAuthClient
            {
                ClientId = siteSettingsHelper.GetCurrentSiteInstagramClientIdToken(),
                ClientSecret = siteSettingsHelper.GetCurrentSiteInstagramClientSecret(),
                RedirectUri = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority)
            };
        }

        [Authorize]
        [HttpGet]
        public void Index()
        {
            string state = Guid.NewGuid().ToString();

            instagramConfig.AccessToken = state;
            manager.SaveSection(instagramConfig);

            string authorizationUrl = client.GetAuthorizationUrl(state, InstagramScope.PublicContent).Replace("publiccontent", "public_content");

            HttpContext.Current.Response.Redirect(authorizationUrl);
        }

        [HttpGet]
        public void Index(string code)
        {
            var response = client.GetAccessTokenFromAuthCode(code);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                instagramConfig.AccessToken = response.Body.AccessToken;
                manager.SaveSection(instagramConfig);

                HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/Sitefinity");
            }
        }
    }
}
