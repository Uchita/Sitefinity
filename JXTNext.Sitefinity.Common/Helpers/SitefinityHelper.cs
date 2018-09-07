using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Modules.UserProfiles;
using Telerik.Sitefinity.Pages.Model;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Security.Claims;
using Telerik.Sitefinity.Security.Model;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Taxonomies;
using Telerik.Sitefinity.Taxonomies.Model;

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
            User user = null;
            if (!String.IsNullOrEmpty(Email))
            {
                var userManager = UserManager.GetManager();
                user = userManager.GetUsers().FirstOrDefault(u => u.Email.ToUpper() == Email.ToUpper());
            }
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

        public static User GetUserById(Guid userId)
        {
            var userManager = UserManager.GetManager();
            return userManager.GetUser(userId);
        }

        public static MembershipCreateStatus CreateUser(string username, string password, string firstName, string lastName, string mail, string phoneNumber, string secretQuestion, string secretAnswer, bool isApproved, bool assignMemberRole = false)
        {
            UserManager userManager = UserManager.GetManager();
            UserProfileManager profileManager = UserProfileManager.GetManager();
            var userMangagerSecurityChek = userManager.Provider.SuppressSecurityChecks;
            var profileMangagerSecurityChek = profileManager.Provider.SuppressSecurityChecks;
            MembershipCreateStatus status;

            try
            {
                userManager.Provider.SuppressSecurityChecks = true;
                profileManager.Provider.SuppressSecurityChecks = true;
                User user = userManager.CreateUser(username, password, mail, secretQuestion, secretAnswer, isApproved, null, out status);

                if (status == MembershipCreateStatus.Success)
                {
                    SitefinityProfile sfProfile = profileManager.CreateProfile(user, Guid.NewGuid(), typeof(SitefinityProfile)) as SitefinityProfile;

                    if (sfProfile != null)
                    {
                        sfProfile.FirstName = firstName;
                        sfProfile.LastName = lastName;
                        sfProfile.SetValue("PhoneNumber", phoneNumber);
                    }

                    userManager.SaveChanges();
                    profileManager.RecompileItemUrls(sfProfile);
                    profileManager.SaveChanges();

                    if (assignMemberRole)
                        AssisgnUserRole(user, "Member");
                }
            }
            finally // Reset the security check
            {
                userManager.Provider.SuppressSecurityChecks = userMangagerSecurityChek;
                profileManager.Provider.SuppressSecurityChecks = profileMangagerSecurityChek;
            }

            return status;
        }

       public static void AssisgnUserRole(User user, string roleName)
        {
            if(user != null && !String.IsNullOrEmpty(roleName))
            {
                var roleManager = RoleManager.GetManager();
                var securityCheck = roleManager.Provider.SuppressSecurityChecks;
                try
                {
                    roleManager.Provider.SuppressSecurityChecks = true;
                    var role = roleManager.GetRole(roleName);
                    if (role != null)
                    {
                        roleManager.AddUserToRole(user, role);
                        roleManager.SaveChanges();
                    }
                    
                }

                finally // Reset the security check
                {
                    roleManager.Provider.SuppressSecurityChecks = securityCheck;
                }
            }
        }

        public static bool IsUserVerified(string email, string password)
        {
            bool isVerified = false;

            UserManager userManager = UserManager.GetManager();
            if (userManager.ValidateUser(email, password))
                isVerified = true;
            return isVerified;
        }

        public static bool IsUserLoggedIn()
        {
            bool isUserLoggedIn = false;
            var currentIdentity = ClaimsManager.GetCurrentIdentity();

            if (currentIdentity.IsAuthenticated)
                isUserLoggedIn = true;

            return isUserLoggedIn;
        }
    }
}