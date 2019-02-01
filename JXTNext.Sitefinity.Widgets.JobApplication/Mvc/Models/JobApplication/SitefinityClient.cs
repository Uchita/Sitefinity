using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using IdentityModel.Client;
using Telerik.Sitefinity.Security.Configuration;

namespace JXTNext.Sitefinity.Widgets.JobApplication.Mvc.Models
{
    public class SitefinityClient : HttpClient
    {
        public const string SitefinityBaseAddress = "http://localhost:60876";
        private CookieContainer cookies;

        /// <summary>
        /// Initializes a new instance of the <see cref="SitefinityClient"/> class.
        /// </summary>
        public SitefinityClient()
        {
            this.BaseAddress = new Uri(SitefinityBaseAddress);
        }

        /// <summary>
        /// Gets or sets the cookies.
        /// </summary>
        /// <value>
        /// The cookies.
        /// </value>
        public CookieContainer Cookies
        {
            get
            {
                this.cookies = this.cookies ?? new CookieContainer(10);
                return this.cookies;
            }
            set
            {
                this.cookies = value;
            }
        }

        /// <summary>
        /// Requests the authenticate.
        /// Side effects: Sets the Cookie property.
        /// </summary>
        /// <param name="providerName">Name of the provider.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="rememberMe">Whether credentials should persist in a cookie.</param>
        public HttpResponseMessage RequestAuthenticate(string providerName = SitefinityClient.MembershipProvider, string username = SitefinityClient.DefaultAdminName,
            string password = SitefinityClient.DefaultAdminPass, bool rememberMe = false, bool setCookies = true, bool forceLogin = true)
        {
            HttpResponseMessage response = null;
            if (this.Mode == AuthenticationMode.Forms)
            {
                var credentials = this.GetCredentials(providerName, username, password, rememberMe);

                var baseAddress = VirtualPathUtility.RemoveTrailingSlash(this.BaseAddress.AbsoluteUri);
                Uri authenticateServiceUri = new Uri(baseAddress + SitefinityClient.UsersServiceUrl + SitefinityClient.AuthenticateMethodName);
                response = this.PostAsync(authenticateServiceUri, credentials).Result;
            }
            else if (this.Mode == AuthenticationMode.Claims)
            {
                var additionalParameters = new Dictionary<string, string>()
                {
                    { SitefinityClient.MembershipProviderParameter, providerName }
                };

                var client = new TokenClient(string.Concat(this.BaseAddress, SitefinityClient.IdentityServerTokenServiceUrl), SitefinityClient.ClientId, SitefinityClient.ClientSecret, AuthenticationStyle.PostValues);
                var tokenResponse = client.RequestResourceOwnerPasswordAsync(username, password, "openid", additionalParameters).Result;

                if (tokenResponse.IsError)
                {
                    throw new ApplicationException("Couldn't get access token. Error: " + tokenResponse.Error);
                }

                this.DefaultRequestHeaders.Add(SitefinityClient.AuthorizationHeader, "Bearer " + tokenResponse.AccessToken);
                response = this.ConfigureClientAuthCookies(forceLogin);
            }

            if (setCookies)
            {
                var cookiesToSet = response.Headers.GetValues("Set-Cookie");
                this.Cookies.SetCookies(this.BaseAddress, string.Join(", ", cookiesToSet));
            }

            return response;
        }

        /// <summary>
        /// Logs off the user first and then authenticates it.
        /// </summary>
        /// <param name="providerName">Name of the provider.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="rememberMe">Whether credentials should persist in a cookie.</param>
        /// <param name="stsToken">The STS token. If null then a new one will be requested from the SWT service.</param>
        /// <param name="needAdminRightsShouldThrowAnException">If set to true and the user doesn't have access (need admin rights screen is shown) an exception will be thrown.</param>
        /// <returns>Response of the authenticate request</returns>
        public HttpResponseMessage RequestAuthenticateSafe(string providerName = "", string username = SitefinityClient.DefaultAdminName,
            string password = SitefinityClient.DefaultAdminPass, bool rememberMe = false, string stsToken = null, bool setCookies = true, bool needAdminRightsShouldThrowAnException = false)
        {
            throw new NotImplementedException("This method is obsolete due to new Authentication mechanism. Call RequestAuthenticate directly.");
        }

        /// <summary>
        /// Requests the STS token.
        /// </summary>
        /// <param name="providerName">Name of the provider.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="rememberMe">Whether credentials should persist in a cookie.</param>
        /// <returns>The response.</returns>
        public HttpResponseMessage RequestStsToken(string providerName = "", string username = SitefinityClient.DefaultAdminName,
            string password = SitefinityClient.DefaultAdminPass, bool rememberMe = false)
        {
            var authenticateServiceUri = this.BuildUrlWithQueryString(SitefinityClient.Issuer, providerName, username, password, rememberMe);
            var response = this.GetAsync(authenticateServiceUri).Result;
            return response;
        }

        /// <summary>
        /// Logouts the current user.
        /// </summary>
        /// <returns>The response</returns>
        public HttpResponseMessage Logout()
        {
            HttpResponseMessage response = null;
            if (this.Mode == AuthenticationMode.Forms)
            {
                response = this.GetAsync(VirtualPathUtility.RemoveTrailingSlash(this.BaseAddress.AbsoluteUri) +
                                         SitefinityClient.UsersServiceUrl + "Logout").Result;
            }
            else if (this.Mode == AuthenticationMode.Claims)
            {
                response = this.GetAsync(VirtualPathUtility.RemoveTrailingSlash(this.BaseAddress.AbsoluteUri) +
                                         SitefinityClient.ClaimsLogOutServiceUrl).Result;
            }
            //This time cookies are handled automatically somehow.

            return response;
        }

        private HttpResponseMessage ConfigureClientAuthCookies(bool forceLogin)
        {
            var baseUrl = VirtualPathUtility.RemoveTrailingSlash(this.BaseAddress.AbsoluteUri);
            var cookiesResponse = this.GetAsync(new Uri(string.Concat(baseUrl, SitefinityClient.CookieAuthPath, "?forceLogin=", forceLogin))).Result;
            return cookiesResponse;
        }

        private Uri BuildUrlWithQueryString(string url, string providerName, string username, string password, bool rememberMe)
        {
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            if (!string.IsNullOrEmpty(providerName))
            {
                query["sf_domain"] = providerName;
            }
            query["wrap_name"] = username;
            query["wrap_password"] = password;
            if (rememberMe)
            {
                query["sf_persistent"] = "1";
            }
            return uriBuilder.Uri;
        }

        public HttpContent GetCredentials(string membershipProvider, string userName, string password, bool rememberMe)
        {
            // Prepare the credential data for submission.
            var jsonData = String.Format(SitefinityClient.credentialsFormat, membershipProvider, userName, password, rememberMe.ToString().ToLower());
            var credentials = new StringContent(jsonData, Encoding.UTF8);
            return credentials;
        }

        private const string ClientId = "testApp";
        private const string ClientSecret = "secret";
        private const string DefaultAdminName = "admin@jxt.com";
        private const string DefaultAdminPass = "admin@2";
        private const string AuthorizationHeader = "Authorization";
        private const string MembershipProviderParameter = "membershipProvider";
        private const string IdentityServerTokenServiceUrl = "/Sitefinity/Authenticate/OpenID/connect/token";
        private const string CookieAuthPath = "/retrieveAuthCookie";
        private const string MembershipProvider = "Default";
        public const string ServiceRequestHeader = "X-SF-Service-Request";
        public const string AuthenticateMethodName = "Authenticate";
        public const string UsersServiceUrl = "/Sitefinity/Services/Security/Users.svc/";
        public const string Issuer = SitefinityBaseAddress + "/Sitefinity/Authenticate/OpenID";
        public const string ClaimsLogOutServiceUrl = "/Sitefinity/SignOut";
        public AuthenticationMode Mode = AuthenticationMode.Claims;

        private const string credentialsFormat = @"
        {{
            ""MembershipProvider"":""{0}"",
            ""UserName"":""{1}"",
            ""Password"":""{2}"",
            ""Persistent"":{3}
        }}";
    }
}
