using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;
using JXTPortal.Entities.Models;

public class oAuthGoogle
{
    private string email_url = SocialMedia.Resource1.google_email;
    private string profile_url = SocialMedia.Resource1.google_profile;
    private string authenticate_url = SocialMedia.Resource1.google_authenticate;
    private string authenticate_url_code = SocialMedia.Resource1.google_authenticateCode;
    private string userinfo_url = SocialMedia.Resource1.google_userinfo;

    private string _clientId, _clientSecret, _redirectUri, _accesstoken;

    #region Constructor

    public oAuthGoogle() { }

    public oAuthGoogle(string GoogleAppID, string GoogleAppSecret, string RedirectURL)
    {
        this.ClientID = GoogleAppID;
        this.ClientSecret = GoogleAppSecret;
        this.RedirectURI = RedirectURL;
    }

    #endregion


    #region Properties
    public string ClientID
    {
        get { return _clientId; }
        set { _clientId = value; }
    }

    public string ClientSecret
    {
        get { return _clientSecret; }
        set { _clientSecret = value; }
    }

    public string RedirectURI
    {
        get { return _redirectUri; }
        set { _redirectUri = value; }
    }

    public string AccessToken
    {
        get { return _accesstoken; }
        set { _accesstoken = value; }
    }

    #endregion

    public string Authorize()
    {
        if (string.IsNullOrEmpty(this.ClientID) || string.IsNullOrEmpty(this.RedirectURI))
        {
            return "Error: Please provide ClientID & Redirect URI";
        }

        string url = string.Format(authenticate_url, HttpUtility.UrlEncode(email_url), HttpUtility.UrlEncode(profile_url), HttpUtility.UrlEncode(this.RedirectURI), this.ClientID);
        return url;
    }

    public string AuthorizeURLGetWithCodeType()
    {
        if (string.IsNullOrEmpty(this.ClientID) || string.IsNullOrEmpty(this.RedirectURI))
        {
            return "Error: Please provide ClientID & Redirect URI";
        }

        string url = string.Format(authenticate_url_code, HttpUtility.UrlEncode(email_url), HttpUtility.UrlEncode(profile_url), HttpUtility.UrlEncode(this.RedirectURI), this.ClientID);
        return url;
    }

    public string GetAccessTokenUsingCode(string code)
    {
        //get the access token 
        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://accounts.google.com/o/oauth2/token");
        webRequest.Method = "POST";
        string Parameters = "code=" + code + "&client_id=" + this.ClientID + "&client_secret=" + this.ClientSecret + "&redirect_uri=" + this.RedirectURI + "&grant_type=authorization_code";
        byte[] byteArray = Encoding.UTF8.GetBytes(Parameters);
        webRequest.ContentType = "application/x-www-form-urlencoded";
        webRequest.ContentLength = byteArray.Length;
        Stream postStream = webRequest.GetRequestStream();
        // Add the post data to the web request
        postStream.Write(byteArray, 0, byteArray.Length);
        postStream.Close();

        WebResponse response = webRequest.GetResponse();
        postStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(postStream);
        string responseFromServer = reader.ReadToEnd();

        GoogleToken userObj = new JavaScriptSerializer().Deserialize<GoogleToken>(responseFromServer);

        reader.Close();
        postStream.Close();
        response.Close();

        return userObj.access_token;

    }

    public GoogleUser GetUserInfoUsingAccessToken(string token)
    {
        //get the access token 
        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/oauth2/v1/userinfo?alt=json&access_token=" + token);
        webRequest.Method = "GET";

        WebResponse response = webRequest.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string responseFromServer = reader.ReadToEnd();

        GoogleUser userObj = new JavaScriptSerializer().Deserialize<GoogleUser>(responseFromServer);

        reader.Close();
        response.Close();

        return userObj;

    }

    public string GetUserInfo()
    {
        if (string.IsNullOrEmpty(this.AccessToken))
        {
            return "Error: Access Token Missing";
        }

        HttpWebResponse webresponse;
        HttpWebRequest webrequest;

        try
        {
            string url = string.Format(userinfo_url, this.AccessToken);
            webrequest = WebRequest.Create(url) as HttpWebRequest;
            webresponse = webrequest.GetResponse() as HttpWebResponse;

            if (webresponse.StatusCode.ToString() == "OK")
            {
                Stream postStream = webresponse.GetResponseStream();
                StreamReader reader = new StreamReader(postStream);

                return reader.ReadToEnd();
            }
            else
            {
                return "Error: Request Failed";
            }
        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
    }


}

