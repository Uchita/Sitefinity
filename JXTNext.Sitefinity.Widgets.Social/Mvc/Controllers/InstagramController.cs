using Skybrud.Social.Instagram;
using Skybrud.Social.Instagram.OAuth;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Options.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using Telerik.Microsoft.Practices.EnterpriseLibrary.Caching;
using Telerik.Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Services;
using JXTNext.Sitefinity.Widgets.Social.Mvc.Configuration;
using JXTNext.Sitefinity.Widgets.Social.Mvc.Models;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using JXTNext.Sitefinity.Common.Models.CustomSiteSettings;
using JXTNext.Sitefinity.Common.Helpers;

namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Controllers
{
    [EnhanceViewEngines]
    [ControllerToolboxItem(Name = "InstagramFeed", Title = "Instagram Feed", SectionName = "JXTNext.Social")]
    public class InstagramController : Controller
    {
        private SiteSettingsHelper siteSettingsHelper;
        public InstagramController()
        {
            siteSettingsHelper = new SiteSettingsHelper();
        }
        public string Username { get; set; }

        /// <summary>
        /// This is the default Action.
        /// </summary>
        public ActionResult Index()
        {
            if (SystemManager.IsDesignMode || SystemManager.IsPreviewMode)
            {
                
                var accessToken = siteSettingsHelper.GetCurrentSiteInstagramAccessToken();
                Guid output;
                if (Guid.TryParse(accessToken, out output) || string.IsNullOrWhiteSpace(accessToken))
                {
                    return View("Authorize");
                }
            }

            var model = new InstagramModel();

            model.Media = GetMedia();

            return View("Default", model);
        }

        private List<InstagramMedia> GetMedia()
        {
            var media = new List<InstagramMedia>();

            if (!string.IsNullOrWhiteSpace(Username))
            {
                if ((List<InstagramMedia>)CacheManager[GetCacheKey()] != null)
                {
                    media = (List<InstagramMedia>)CacheManager[GetCacheKey()];
                }
                else
                {
                    media = GetFeedDataFromInstagram();
                }
            }

            return media;
        }

        #region caching

        private List<InstagramMedia> GetFeedDataFromInstagram()
        {
            var service = InstagramService.CreateFromAccessToken(siteSettingsHelper.GetCurrentSiteInstagramAccessToken());

            var userResponse = service.Users.GetSelf();

            // Temporary list for storing the retrieved media
            var media = new List<InstagramMedia>();

            // Find the first user with the specified username
            var user = userResponse.Body.Data;

            if (user != null)
            {
                // Declare the initial search options
                var options = new InstagramUserRecentMediaOptions
                {
                    Count = siteSettingsHelper.GetCurrentSiteInstagramMaxItems(),
                };

                var mediaResponse = service.Users.GetRecentMedia(user.Id, options);

                // Add the media to the list
                media.AddRange(mediaResponse.Body.Data);
            }

            CacheManager.Add(
                GetCacheKey(),
                media,
                CacheItemPriority.Normal,
                null,
                new AbsoluteTime(TimeSpan.FromMinutes(siteSettingsHelper.GetCurrentSiteInstagramExpiration())));

            return media;
        }

        #endregion

        #region private

        private ICacheManager CacheManager
        {
            get
            {
                return SystemManager.GetCacheManager(CacheManagerInstance.Global);
            }
        }

        private string GetCacheKey()
        {
            return string.Format("{0}{1}", "instagramMedia", Username);
        }

        
        #endregion
    }
}
