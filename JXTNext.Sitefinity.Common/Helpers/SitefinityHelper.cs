using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Modules.UserProfiles;
using Telerik.Sitefinity.Pages.Model;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Security.Claims;
using Telerik.Sitefinity.Security.Model;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Taxonomies;
using Telerik.Sitefinity.Taxonomies.Model;
using JXTNext.Sitefinity.Common.Models.CustomSiteSettings;
using Telerik.Sitefinity.SiteSettings.Web.Services;
using Telerik.Sitefinity.Multisite;

namespace JXTNext.Sitefinity.Common.Helpers
{
    public class SitefinityHelper
    {
        public static TimeZoneInfo GetSitefinityTimeZoneInfo()
        {
            var sitefinityTimeZoneInfo = Telerik.Sitefinity.Configuration.Config.Get<SystemConfig>().UITimeZoneSettings.CurrentTimeZoneInfo;
            if (sitefinityTimeZoneInfo == null && UserManager.GetManager() != null)
                sitefinityTimeZoneInfo = UserManager.GetManager().GetUserTimeZone();

            return sitefinityTimeZoneInfo;
        }

        public static DateTime GetSitefinityApplicationTime()
        {
            var sitefinityAppTime = DateTime.Now;
            var sitefinityTimeZoneInfo = GetSitefinityTimeZoneInfo();
            if (sitefinityTimeZoneInfo != null)
                sitefinityAppTime = TimeZoneInfo.ConvertTime(DateTime.Now, sitefinityTimeZoneInfo);

            return sitefinityAppTime;
        }

        public static string GetPageUrl(string pageId)
        {
            string pageUrl = String.Empty;

            PageManager pageManager = PageManager.GetManager();
            if (pageManager != null)
            {
                if (!pageId.IsNullOrEmpty())
                {
                    Guid pageNodeId = new Guid(pageId);
                    PageNode pageNode = pageManager.GetPageNodes().Where(n => n.Id == pageNodeId).FirstOrDefault();
                    // We will get the url as ~/homepage
                    // So removing the first character
                    if (pageNode != null)
                        pageUrl = pageNode.GetUrl().Substring(1);
                }
            }

            return pageUrl;
        }

        public static string GetPageFullUrl(Guid pageId)
        {
            string pageFullUrl = String.Empty;

            PageManager pageManager = PageManager.GetManager();
            if (pageManager != null)
            {
                PageNode pageNode = pageManager.GetPageNodes().Where(n => n.Id == pageId).FirstOrDefault();
                // We will get the url as ~/homepage
                // So removing the first character
                if (pageNode != null)
                    pageFullUrl = pageNode.GetFullUrl().Substring(1);
            }

            return pageFullUrl;
        }

        public static List<string> GetCurrentUserRoles()
        {
            List<string> roles = new List<string>();

            // Get the current identity 
            var identity = ClaimsManager.GetCurrentIdentity();

            // Get information about the user from the properties of the ClaimsIdentityProxy object
            if (identity != null)
            {
                foreach (var rolesInfo in identity.Roles)
                {
                    roles.Add(rolesInfo.Name);
                }
            }
            return roles;
        }

        public static List<string> GetAllRoleNames()
        {
            RoleManager roleManager = RoleManager.GetManager();
            List<string> roleNames = new List<string>();
            foreach (var provider in roleManager.Providers)
            {
                roleManager = RoleManager.GetManager(provider.Name);
                foreach (var role in roleManager.GetRoleNames())
                {
                    roleNames.Add(role);
                }
            }

            return roleNames;
        }

        public static List<Taxon> GetTopLevelCategories()
        {
            var manager = TaxonomyManager.GetManager();
            var categoriesTaxonomy = manager.GetTaxonomy<HierarchicalTaxonomy>(TaxonomyManager.CategoriesTaxonomyId);
            var ind = categoriesTaxonomy.Taxa.Where(t => t.Name == "Inustry").FirstOrDefault() as HierarchicalTaxon;
            List<Taxon> topLovelTaxa = new List<Taxon>();
            foreach (var taxon in categoriesTaxonomy.Taxa)
            {
                if (taxon.Parent == null)
                    topLovelTaxa.Add(taxon);
            }

            return topLovelTaxa;
        }

        public static User GetUserByEmail(string Email)
        {
            var userManager = UserManager.GetManager();
            var user = userManager.GetUsers().FirstOrDefault(u => u.Email == Email);
            return user;
        }

        public static string GetUserAvatarUrlById(Guid userId)
        {
            Telerik.Sitefinity.Libraries.Model.Image image;
            var imageUrl = UserProfilesHelper.GetAvatarImageUrl(userId, out image);
            return imageUrl;
        }

        public static string GetUserFirstNameById(Guid userId )
        {
            var userManager = UserManager.GetManager();
            User user = userManager.GetUser(userId);
            UserProfileManager profileManager = UserProfileManager.GetManager();
            SitefinityProfile profile = profileManager.GetUserProfile<SitefinityProfile>(user);
            string firstName = "";
            if (profile != null)
                firstName = profile.FirstName;

            return firstName;
        }

        public static string GetCurrentSiteGoogleMapsAPIKey()
        {
            var basicSettingsSerivce = new BasicSettingsService();
            var itemType = "JXTNext.Sitefinity.Common.Models.CustomSiteSettings.CustomSiteSettingsContract";
            var multiSiteContext = new MultisiteContext();
            var currSite = multiSiteContext.CurrentSite;
            SettingsItemContext siteSetting = null;
            SystemManager.RunWithElevatedPrivilege(d => { siteSetting = basicSettingsSerivce.GetSettings(itemType, currSite.Id.ToString()); });
            string googleMapsAPIKey = "";
            if (siteSetting != null)
            {
                var siteSettingsContract = (CustomSiteSettingsContract)siteSetting.Item;
                if (siteSettingsContract != null)
                    googleMapsAPIKey = siteSettingsContract.GoogleAPIKey;
            }

            return googleMapsAPIKey;
        }
    }
}