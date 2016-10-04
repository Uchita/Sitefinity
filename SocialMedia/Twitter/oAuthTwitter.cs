using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Text;
//using TweetSharp;
//using Newtonsoft.Json;
using System.Runtime.Serialization;

public class oAuthTwitter : oAuthBase2
{
    public enum Method { GET, POST, PUT, DELETE };

    private string _consumerKey = "";
    private string _consumerSecret = "";
    private string _token = "";
    private string _tokenSecret = "";
    private string _redirecturl = string.Empty;
    private string request_token_url = SocialMedia.Resource1.twitter_request_token;
    private string access_token_url = SocialMedia.Resource1.twitter_access_token;
    private string authenticate_url = SocialMedia.Resource1.twitter_authenticate;
    private string people_url = SocialMedia.Resource1.twitter_people_url;

        #region Constructor

    public oAuthTwitter(string TwitterKey, string TwitterSecret, string RedirectURL)
    {
        this.ConsumerKey = TwitterKey;
        this.ConsumerSecret = TwitterSecret;
        this.RedirectURL = RedirectURL;
    }

    #endregion

    #region Properties
    public string ConsumerKey
    {
        get
        {
            return _consumerKey;
        }
        set { _consumerKey = value; }
    }

    public string ConsumerSecret
    {
        get
        {
            return _consumerSecret;
        }
        set { _consumerSecret = value; }
    }
    public string Token { get { return _token; } set { _token = value; } }
    public string TokenSecret { get { return _tokenSecret; } set { _tokenSecret = value; } }

    public string RedirectURL { get { return _redirecturl; } set { _redirecturl = value; } }

    #endregion


    public string RequestToken(string callbackUrl, out string oauth_token, out string oauth_token_secret)
    {
        HttpWebResponse response;
        string url = request_token_url;
        oauth_token = string.Empty;
        oauth_token_secret = string.Empty;
        Uri uri = new Uri(url);

        string nonce = this.GenerateNonce();
        string timeStamp = this.GenerateTimeStamp();

        string outUrl, querystring;
        string returnString = string.Empty;

        //Generate Signature
        string sig = this.GenerateSignature(
            uri,
            this.ConsumerKey,
            this.ConsumerSecret,
            this.Token,
            this.TokenSecret,
            "POST",
            timeStamp,
            nonce,
            callbackUrl,
            out outUrl,
            out querystring);

        querystring += "&oauth_signature=" + HttpUtility.UrlEncode(sig);
        NameValueCollection qs = HttpUtility.ParseQueryString(querystring);

        HttpWebRequest webRequest = null;
        try
        {
            webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            webRequest.ContentType = "text/xml";
            webRequest.Method = "POST";

            string authHeader = "OAuth oauth_nonce=\"" + nonce + "\", ";
            authHeader += "oauth_timestamp=\"" + timeStamp + "\", ";
            authHeader += "oauth_consumer_key=\"" + this.ConsumerKey + "\", ";

            if (!string.IsNullOrEmpty(callbackUrl))
            {
                authHeader += "oauth_callback=\"" + UrlEncode(callbackUrl) + "\", ";
            }

            authHeader += "oauth_signature_method=\"HMAC-SHA1\", ";
            authHeader += "oauth_version=\"1.0\", ";
            if (this.Token != "")
            {
                authHeader += "oauth_token=\"" + this.Token + "\", ";

            }

            if (this.TokenSecret != "")
            {
                authHeader += "oauth_token_secret=\"" + UrlEncode(this.TokenSecret) + "\", ";

            }
            authHeader += "oauth_signature=\"" + this.UrlEncode(sig) + "\"";
            webRequest.Headers.Add("Authorization", authHeader);

            response = (HttpWebResponse)webRequest.GetResponse();

            if (response.StatusCode.ToString() == "OK")
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string result = reader.ReadToEnd();

                // Retrieving Token
                string oauth_callback_confirmed = string.Empty;
                string[] strs = result.Split(new char[] { '&' });
                foreach (string s in strs)
                {
                    if (s.StartsWith("oauth_token="))
                    {
                        oauth_token = s.Replace("oauth_token=", string.Empty);
                    }

                    if (s.StartsWith("oauth_token_secret="))
                    {
                        oauth_token_secret = s.Replace("oauth_token_secret=", string.Empty);
                    }

                    if (s.StartsWith("oauth_callback_confirmed="))
                    {
                        oauth_callback_confirmed = s.Replace("oauth_callback_confirmed=", string.Empty);
                    }

                }

                if (string.IsNullOrEmpty(oauth_token) == false && oauth_callback_confirmed == "true")
                {
                    returnString = string.Format("{0}?oauth_token={1}", authenticate_url, oauth_token);
                }
            }
        }
        catch (Exception ex)
        {
            returnString = ex.Message;
        }
        finally
        {
            webRequest = null;
        }

        return returnString;
    }

    public string AccessToken(out string oauth_token, out string oauth_token_secret, out string user_id, out string screen_name)
    {
        HttpWebResponse response;
        string url = access_token_url;
        oauth_token = string.Empty;
        oauth_token_secret = string.Empty;
        user_id = string.Empty;
        screen_name = string.Empty;

        Uri uri = new Uri(url);

        string nonce = this.GenerateNonce();
        string timeStamp = this.GenerateTimeStamp();

        string outUrl, querystring;
        string returnString = string.Empty;

        //Generate Signature
        string sig = this.GenerateSignature(
            uri,
            this.ConsumerKey,
            this.ConsumerSecret,
            this.Token,
            this.TokenSecret,
            "POST",
            timeStamp,
            nonce,
            string.Empty,
            out outUrl,
            out querystring);

        querystring += "&oauth_signature=" + HttpUtility.UrlEncode(sig);
        NameValueCollection qs = HttpUtility.ParseQueryString(querystring);

        Debug.WriteLine("Token= " + this.Token);

        HttpWebRequest webRequest = null;
        try
        {
            webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            webRequest.ContentType = "text/xml";
            webRequest.Method = "POST";

            string authHeader = "OAuth oauth_nonce=\"" + nonce + "\", ";
            authHeader += "oauth_timestamp=\"" + timeStamp + "\", ";
            authHeader += "oauth_consumer_key=\"" + this.ConsumerKey + "\", ";

            //if (!string.IsNullOrEmpty(Verifier))
            //{
            //    authHeader += "oauth_verifier=\"" + Verifier + "\", ";
            //}

            authHeader += "oauth_signature_method=\"HMAC-SHA1\", ";
            authHeader += "oauth_version=\"1.0\", ";
            if (this.Token != "")
            {
                authHeader += "oauth_token=\"" + this.Token + "\", ";

            }

            authHeader += "oauth_signature=\"" + this.UrlEncode(sig) + "\"";
            webRequest.Headers.Add("Authorization", authHeader);

            response = (HttpWebResponse)webRequest.GetResponse();

            if (response.StatusCode.ToString() == "OK")
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string result = reader.ReadToEnd();

                // Retrieving Token
                string xoauth_request_auth_url = string.Empty;
                string[] strs = result.Split(new char[] { '&' });
                foreach (string s in strs)
                {
                    if (s.StartsWith("oauth_token="))
                    {
                        oauth_token = s.Replace("oauth_token=", string.Empty);
                    }

                    if (s.StartsWith("oauth_token_secret="))
                    {
                        oauth_token_secret = s.Replace("oauth_token_secret=", string.Empty);
                    }

                    if (s.StartsWith("user_id="))
                    {
                        user_id = s.Replace("user_id=", string.Empty);
                    }

                    if (s.StartsWith("screen_name="))
                    {
                        screen_name = s.Replace("screen_name=", string.Empty);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            returnString = ex.Message;
        }
        finally
        {
            webRequest = null;
        }

        return returnString;
    }

    public string GetUserInfo()
    {
        HttpWebResponse response = null;

        string url = people_url;

        Debug.WriteLine("Token= " + this.Token);

        Uri uri = new Uri(url);

        string nonce = this.GenerateNonce();
        string timeStamp = this.GenerateTimeStamp();

        string outUrl, querystring;

        //Generate Signature
        string sig = this.GenerateSignature(
            uri,
            this.ConsumerKey,
            this.ConsumerSecret,
            this.Token,
            this.TokenSecret,
            "GET",
            timeStamp,
            nonce,
            string.Empty,
            out outUrl,
            out querystring);

        querystring += "&oauth_signature=" + HttpUtility.UrlEncode(sig);
        NameValueCollection qs = HttpUtility.ParseQueryString(querystring);

        Debug.WriteLine("Token= " + this.Token);

        HttpWebRequest webRequest = null;

        webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
        webRequest.ContentType = "text/xml";
        webRequest.Method = "GET";
        string authHeader = "OAuth realm=\"\", ";
        authHeader += "oauth_nonce=\"" + nonce + "\", ";
        authHeader += "oauth_timestamp=\"" + timeStamp + "\", ";
        authHeader += "oauth_consumer_key=\"" + this.ConsumerKey + "\", ";
        authHeader += "oauth_signature_method=\"HMAC-SHA1\", ";
        //authHeader += "oauth_version=\"1.0\", ";
        if (this.Token != "")
        {
            authHeader += "oauth_token=\"" + this.Token + "\", ";
        }
        if (this.TokenSecret != "")
        {
            authHeader += "oauth_token_secret=\"" + this.TokenSecret + "\", ";

        }
        authHeader += "oauth_signature=\"" + this.UrlEncode(sig) + "\"";
        webRequest.Headers.Add("Authorization", authHeader);
        string returnString = string.Empty;

        try
        {
            response = (HttpWebResponse)webRequest.GetResponse();
            if (response.StatusCode.ToString() == "OK")
            {
                System.IO.Stream postStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(postStream);

                returnString = reader.ReadToEnd();

                returnString = returnString.Replace(@"u0040", "@");

                returnString = Regex.Unescape(returnString);
            }
        }
        catch (Exception ex)
        {
            returnString = ex.Message;
        }


        return returnString;
    }


    //public string GetAuthorizeURL()
    //{
    //    TwitterService service = new TwitterService(this.ConsumerKey, this.ConsumerSecret);

    //    // Step 1 - Retrieve an OAuth Request Token
    //    OAuthRequestToken requestToken = service.GetRequestToken(this.RedirectURL);

    //    // Step 2 - Redirect to the OAuth Authorization URL
    //    Uri uri = service.GetAuthorizationUri(requestToken);
    //    return uri.ToString();
    //}

    //public void GetUserDetails(string token, string verifier)
    //{

    //    var requestToken = new OAuthRequestToken { Token = token };

    //    // Step 3 - Exchange the Request Token for an Access Token
    //    TwitterService service = new TwitterService(this.ConsumerKey, this.ConsumerSecret);
    //    OAuthAccessToken accessToken = service.GetAccessToken(requestToken, verifier);

    //    // Step 4 - User authenticates using the Access Token
    //    service.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);
    //    TwitterUser user = service.VerifyCredentials(new VerifyCredentialsOptions());

    //    TwitterUser user2 = service.GetUserProfile(new GetUserProfileOptions());


    //    string name = user.Name;
    //    string screen_name = user.ScreenName;
    //    //OAuthRequestToken requestToken = (OAuthRequestToken)HttpContext.Current.Session["TwitterReqToken"];

    //    //if( requestToken != null )
    //    //{
    //    //    TwitterService service = new TwitterService(consumer_key, consumer_secret);
    
    //    //    // Step 3 - Exchange the Request Token for an Access Token
    //    //    //string verifier = "123456"; // <-- This is input into your application by your user
    //    //    OAuthAccessToken access = service.GetAccessToken(requestToken, verifier);

    //    //    // Step 4 - User authenticates using the Access Token
    //    //    service.AuthenticateWith(access.Token, access.TokenSecret);
    //    //}

    //}

}

