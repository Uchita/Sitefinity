using JXTNext.Sitefinity.Common.Helpers;
using JXTNext.Sitefinity.Widgets.Social.Mvc.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Telerik.Sitefinity.Abstractions;

namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Helpers
{
    public class LinkedInHelper
    {
        public const string ActionJobApply = "job-apply";

        public const string AuthorisationUrl = "https://www.linkedin.com/oauth/v2/authorization";
        public const string AccessTokenUrl = "https://www.linkedin.com/oauth/v2/accessToken";
        public const string ProfileUrl = "https://api.linkedin.com/v2/me";
        public const string ProfileEmailAddressUrl = "https://api.linkedin.com/v2/emailAddress?q=members&projection=(elements*(handle~))";

        private static SiteSettingsHelper _siteSettingsHelper = new SiteSettingsHelper();

        public static string CustomerClientId
        {
            get
            {
                return _siteSettingsHelper.GetCurrentSiteLinkedInCustomerClientId();
            }
        }

        public static string CustomerClientSecret
        {
            get
            {
                return _siteSettingsHelper.GetCurrentSiteLinkedInCustomerClientSecret();
            }
        }

        public static string CustomerIntegrationContext
        {
            get
            {
                return _siteSettingsHelper.GetCurrentSiteLinkedInCustomerIntegrationContext();
            }
        }

        public static string ClientId
        {
            get
            {
                return _siteSettingsHelper.GetCurrentSiteLinkedInClientId();
            }
        }

        public static string ClientSecret
        {
            get
            {
                return _siteSettingsHelper.GetCurrentSiteLinkedInClientSecret();
            }
        }

        public static string SocialHandlerUrl
        {
            get
            {
                var url = _siteSettingsHelper.GetCurrentSiteLinkedInSocialHandlerUrl();

                return url.TrimEnd('/');
            }
        }

        /// <summary>
        /// Create redirect url for signin.
        /// </summary>
        /// <param name="action">Custom data.</param>
        /// <param name="data">Custom data.</param>
        /// <returns></returns>
        public static string CreateSignInRedirectUrl(string action, string data)
        {
            return string.Format(
                "{0}?liaction={1}&data={2}",
                SocialHandlerUrl + "/linkedinsignin",
                HttpUtility.UrlEncode(action),
                HttpUtility.UrlEncode(data)
            );
        }

        /// <summary>
        /// Create a signin URL.
        /// </summary>
        /// <param name="action">Custom data.</param>
        /// <param name="data">Custom data.</param>
        /// <returns></returns>
        public static string CreateSignInUrl(string action, string data)
        {
            var redirectUrl = CreateSignInRedirectUrl(action, data);

            return string.Format(
                "{0}?redirect_uri={1}&client_id={2}&scope={3}&state={4}&response_type=code",
                AuthorisationUrl,
                HttpUtility.UrlEncode(redirectUrl),
                HttpUtility.UrlEncode(ClientId),
                HttpUtility.UrlEncode("r_liteprofile r_emailaddress"),
                HttpUtility.UrlEncode(Guid.NewGuid().ToString())
            );
        }

        /// <summary>
        /// Create a apply URL.
        /// </summary>
        /// <param name="action">Custom data.</param>
        /// <param name="data">Custom data.</param>
        /// <returns></returns>
        public static string CreateApplyUrl()
        {
            return SocialHandlerUrl + "/linkedinapply";
        }

        /// <summary>
        /// Get an access token from authorisation code.
        /// </summary>
        /// <param name="code">Authorisation code received after signin.</param>
        /// <param name="redirectUrl">This must be same as what was used for Signin.</param>
        /// <returns></returns>
        public static LinkedInAccessTokenResponse GetAccessTokenFromAuthorisationCode(string code, string redirectUrl)
        {
            var data = new Dictionary<string, string>();
            data.Add("grant_type", "authorization_code");
            data.Add("code", code);
            data.Add("redirect_uri", redirectUrl);
            data.Add("client_id", ClientId);
            data.Add("client_secret", ClientSecret);

            var response = new LinkedInAccessTokenResponse();

            try
            {
                var webResponse = DoPostRequest(AccessTokenUrl, CreateQueryString(data), "application/x-www-form-urlencoded");

                var jObject = JObject.Parse(webResponse);

                response.AccessToken = jObject.Value<string>("access_token");
                response.ExpiresIn = jObject.Value<int>("expires_in");
            }
            catch (Exception err)
            {
                response.Error = "There was some problem during authentication with LinkedIn. Please go back and try again.";

                Log.Write(err);
            }

            return response;
        }

        /// <summary>
        /// Check whether LinkedIn state matches the one expected.
        /// 
        /// Todo - Logic pending
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static bool IsValidState(string state)
        {
            if (string.IsNullOrEmpty(state))
            {
                return false;
            }

            // todo - validate the state

            return true;
        }

        /// <summary>
        /// Get email address from the profile.
        /// </summary>f
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static string GetProfileEmailAddress(string accessToken)
        {
            var response = DoGetRequest(ProfileEmailAddressUrl, accessToken);

            var jObject = JObject.Parse(response);

            return jObject["elements"][0]["handle~"]["emailAddress"].Value<string>();
        }

        /// <summary>
        /// Get profile.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static LinkedInProfileModel GetProfile(string accessToken)
        {
            var response = DoGetRequest(ProfileUrl, accessToken);

            var jObject = JObject.Parse(response);

            var profile = new LinkedInProfileModel
            {
                FirstName = jObject["firstName"]["localized"]["en_US"].Value<string>(),
                LastName = jObject["lastName"]["localized"]["en_US"].Value<string>()
            };

            return profile;
        }

        /// <summary>
        /// Do a get request to LinkedIn.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        private static string DoGetRequest(string url, string accessToken = null)
        {
            var request = WebRequest.Create(url);
            request.Method = "GET";

            if (accessToken != null)
            {
                request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + accessToken);
            }

            var response = request.GetResponse();

            var dataStream = response.GetResponseStream();

            var reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }

        /// <summary>
        /// Do a post request to LinkedIn.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="contentType"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        private static string DoPostRequest(string url, string data, string contentType, string accessToken = null)
        {
            var request = WebRequest.Create(url);
            request.Method = "POST";

            if (accessToken != null)
            {
                request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + accessToken);
            }

            byte[] byteArray = Encoding.UTF8.GetBytes(data);

            request.ContentType = contentType;
            request.ContentLength = byteArray.Length;

            var dataStream = request.GetRequestStream();

            dataStream.Write(byteArray, 0, byteArray.Length);

            dataStream.Close();

            var response = request.GetResponse();

            dataStream = response.GetResponseStream();

            var reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }

        /// <summary>
        /// Create query string from passed dictionary.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static string CreateQueryString(Dictionary<string, string> data)
        {
            var list = new List<string>();

            foreach (var item in data)
            {
                list.Add(item.Key + "=" + HttpUtility.UrlEncode(item.Value));
            }

            return string.Join("&", list);
        }
    }
}
