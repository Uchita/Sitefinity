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
using Telerik.Sitefinity.Web;
using Telerik.Sitefinity.Multisite;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.Utilities.TypeConverters;
using Telerik.Sitefinity.GenericContent.Model;
using System.Threading;
using System.Globalization;
using JXTNext.Sitefinity.Common.Models.Classifications;

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

        public static HierarchicalTaxon GetCurrentSiteTaxons(string dataSource)
        {
            var manager = TaxonomyManager.GetManager();
            var categoriesTaxonomy = manager.GetSiteTaxonomy<HierarchicalTaxonomy>(TaxonomyManager.CategoriesTaxonomyId, SystemManager.CurrentContext.CurrentSite.Id);
            var taxa = categoriesTaxonomy.Taxa.Where(t => t.Title == dataSource).FirstOrDefault() as HierarchicalTaxon;
            
            return taxa;
        }

        public static List<DynamicContent> GetCurrentSiteItems(string dynamicType, string dataSource)
        {
            Type itemType = TypeResolutionService.ResolveType(dynamicType);
            var managerArticle = TaxonomyManager.GetManager();
            
            MultisiteContext multisiteContext = SystemManager.CurrentContext as MultisiteContext;
            var providerName = multisiteContext.CurrentSite.GetProviders(dataSource).Select(p => p.ProviderName);
            
            // Set a transaction name
            var transactionName = Guid.NewGuid(); // I often using Guid.NewGuid()


            // Set the culture name for the multilingual fields
            var cultureName = "";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);

            DynamicModuleManager dynamicModuleManager = DynamicModuleManager.GetManager(providerName.FirstOrDefault(), transactionName.ToString());
            Type type = TypeResolutionService.ResolveType(dynamicType);

            // This is how we get the consultant items through filtering
            var myFilteredCollection = dynamicModuleManager.GetDataItems(type).Where(c => c.Status == ContentLifecycleStatus.Live & c.Visible);
            
            return myFilteredCollection.ToList();
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
            var categoriesTaxonomy = manager.GetSiteTaxonomy<HierarchicalTaxonomy>(TaxonomyManager.CategoriesTaxonomyId,SystemManager.CurrentContext.CurrentSite.Id);
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

        public static string GetUserFullNameById(Guid userId)
        {
            var userManager = UserManager.GetManager();
            User user = userManager.GetUser(userId);
            UserProfileManager profileManager = UserProfileManager.GetManager();
            SitefinityProfile profile = profileManager.GetUserProfile<SitefinityProfile>(user);
            string fullName = "";
            if (profile != null)
                fullName = profile.FirstName + " "+ profile.LastName;

            return fullName;
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

        public static bool IsUserLoggedIn(string roleName = null)
        {
            bool isUserLoggedIn = false;
            var currentIdentity = ClaimsManager.GetCurrentIdentity();

            if (currentIdentity.IsAuthenticated)
                isUserLoggedIn = true;

            if(!roleName.IsNullOrEmpty())
            {
                if(isUserLoggedIn)
                {
                    var currUser = SitefinityHelper.GetUserById(ClaimsManager.GetCurrentIdentity().UserId);
                    if (currUser != null)
                        isUserLoggedIn = SitefinityHelper.IsUserInRole(currUser, roleName);
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }

            return isUserLoggedIn;
        }

        public static bool IsUserInRole(User user, string roleName)
        {
            bool isUserInRole = false;
            RoleManager roleManager = RoleManager.GetManager();
            bool roleExists = roleManager.RoleExists(roleName);

            if (user != null && roleExists)
                isUserInRole = roleManager.IsUserInRole(user.Id, roleName);

            return isUserInRole;
        }

        public static string GetCurrentPageUrl()
        {
            return GetPageUrl(SiteMapBase.GetActualCurrentNode().Id.ToString());
        }

        public static void LogoutCurrentUser()
        {
            SecurityManager.Logout();
            SecurityManager.DeleteAuthCookies();
        }

        public static string GetLoggedInUserEmail()
        {
            string email = String.Empty;
            if (IsUserLoggedIn()) // User already logged in
            {
                var currUser = SitefinityHelper.GetUserById(ClaimsManager.GetCurrentIdentity().UserId);
                if (currUser != null)
                    email = currUser.Email;
            }

            return email;
        }

        
    }
}