using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.Text.RegularExpressions;
using System.IO;
using System.Web.Script.Serialization;
using JXTPortal.Entities.Models;
using System.Xml;
using System.Globalization;
using log4net;

public class oAuthFacebook
{
    private ILog _logger;
   
    private string _jobapplyurl;

private string authorize_url = SocialMedia.Resource1.fb_authroize_with_permissions;
    private string access_token_url = SocialMedia.Resource1.fb_access_token;
    private string userinfo_url = SocialMedia.Resource1.fb_userinfo;
    private string checkpermission_url = SocialMedia.Resource1.fb_checkpermission;


    public string ClientID
    {
        get;
        set;
    }

    public string ClientSecret
    {
        get;
        set;
    }

    public string RedirectURI
    {
        get;
        set;
    }

    public string Code
    {
        get;
        set;
    }

    public string Permissions
    {
        get;
        set;
    }

    public oAuthFacebook()
    {
        _logger = LogManager.GetLogger(typeof(oAuthFacebook));
        Permissions = SocialMedia.Resource1.default_FBRequestPermissions;
    }

    private string getBaseAutorizationUrl(string redirectURI)
    {
        if (string.IsNullOrWhiteSpace(ClientID) || string.IsNullOrWhiteSpace(RedirectURI) || string.IsNullOrWhiteSpace(Permissions))
        {
            _logger.WarnFormat("Cannot FB Authorize clientId: {0}, Redirect: {1}, Permissions: {2}", ClientID, RedirectURI, Permissions);
            return "Error: Please provide ClientID, Redirect URI & Permissions required";
        }

        string url = string.Format(authorize_url, ClientID, redirectURI, Permissions);
        _logger.DebugFormat("Authorisation URL is: {0}", url);
        return url;
    }

    public string GetAuthorizationUrl()
    {
        return getBaseAutorizationUrl(System.Web.HttpUtility.UrlEncode(RedirectURI));
    }

    public string GetAuthorizeURLWithoutEncode()
    {
        return getBaseAutorizationUrl(RedirectURI);
    }

    public string HasFullPermission(string userid, string accesstoken)
    {
        _logger.Info("Has Full Permission Started");

        string url = string.Format(checkpermission_url, userid, accesstoken);
        _logger.InfoFormat("Permission URL: {0}", url);

        try
        {
            HttpWebRequest webrequest = WebRequest.Create(url) as HttpWebRequest;
            webrequest.Method = "GET";
            HttpWebResponse webresponse = webrequest.GetResponse() as HttpWebResponse;
            _logger.InfoFormat("Webresponse Status Code: {0}", webresponse.StatusDescription);

            if (webresponse.StatusCode.ToString() == "OK")
            {
                Stream stream = webresponse.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string result = reader.ReadToEnd();

                JavaScriptSerializer jss = new JavaScriptSerializer();
                FBDataPermission permissions = jss.Deserialize<FBDataPermission>(result);
                _logger.DebugFormat("FB data Permission: {0}", permissions);

                bool hasEducation = false, hasWork = false, hasWebsite = false, hasEmail = false, hasPublicProfile = false;

                foreach (FBPermission permission in permissions.data)
                {
                    if (permission.permission == "user_education_history" && permission.status == "granted")
                    {
                        hasEducation = true;
                    }
                    if (permission.permission == "user_work_history" && permission.status == "granted")
                    {
                        hasWork = true;
                    }
                    if (permission.permission == "user_website" && permission.status == "granted")
                    {
                        hasWebsite = true;
                    }
                    if (permission.permission == "email" && permission.status == "granted")
                    {
                        hasEmail = true;
                    }
                    if (permission.permission == "public_profile" && permission.status == "granted")
                    {
                        hasPublicProfile = true;
                    }

                    _logger.DebugFormat("Permission Type: {0} and Permission Status: {1}", permission.permission, permission.status);
                }

                if (hasEducation && hasWork && hasWebsite && hasEmail && hasPublicProfile)
                {
                    return "";
                }
                else
                {
                    return "missing";
                }
                
            }
            else
            {
                return "Facebook Error";
            }
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
            return "Facebook Error: " + ex.Message + "<br />";
        }
    }

    public string oAuth2GetProfileHTML(string profile, string logourl)
    {
        _logger.Info("oAuth2GetProfileHTML() Started");

        if (profile.StartsWith("Error:") || profile.StartsWith("The remote server returned an error:"))
        {
            return profile;
        }

        JavaScriptSerializer jss = new JavaScriptSerializer();
        FBUserInfo userinfo = jss.Deserialize<FBUserInfo>(profile);

        StringBuilder sb = new StringBuilder();
        sb.Append("<html>"); sb.Append(Environment.NewLine);
        sb.Append("<head>"); sb.Append(Environment.NewLine);
        sb.Append("</head>"); sb.Append(Environment.NewLine);
        sb.Append("<body>"); sb.Append(Environment.NewLine);
        sb.Append(string.Format("<div align=\"center\" style=\"width:100%\"><img alt=\"\" src=\"{0}\" style=\"border-style: none;\" height=\"200\"width=\"327\" /><!-- Logo URL --></div>", logourl)); sb.Append(Environment.NewLine);
        sb.Append("<font face=\"Arial\" size=\"1\">"); sb.Append(Environment.NewLine);
        sb.Append("<table width=\"100%\" border=\"0\">"); sb.Append(Environment.NewLine);
        sb.Append("<tr>"); sb.Append(Environment.NewLine);
        sb.Append(string.Format("<td width=\"75%\" align=\"left\" valign=\"top\"><p style=\"font-weight: bold; font-size: 16pt;\">{0}</p><!-- " +
                "Member Name -->", userinfo.first_name + " " + userinfo.last_name)); sb.Append(Environment.NewLine);
        sb.Append(string.Format("<p style=\"font-size: 10pt;\">{0}</p></td><!-- Email -->", userinfo.email)); sb.Append(Environment.NewLine);

        if (!string.IsNullOrWhiteSpace(userinfo.website ))
        {
            sb.Append(string.Format("<p style=\"font-size: 10pt;\">{0}</p></td><!-- Email -->", userinfo.website)); sb.Append(Environment.NewLine);
        }

        sb.Append("</tr>"); sb.Append(Environment.NewLine);
        sb.Append("</table>"); sb.Append(Environment.NewLine);

        if (userinfo.work != null && userinfo.work.Length > 0)
        {
            sb.Append("<p style=\"font-size: 16pt; font-weight:bold; color:#999;\">Experience</p>"); sb.Append(Environment.NewLine);

            foreach (FBWorkType worktype in userinfo.work)
            {
                sb.Append(string.Format("<p style=\"font-weight:bold; font-size: 12pt;\">{0}{1}</p>", (worktype.position != null) ? worktype.position.name + " at " : string.Empty, worktype.employer.name)); sb.Append(Environment.NewLine);

                sb.Append(string.Format("<p>{0}{1}</p>", worktype.start_date, string.IsNullOrWhiteSpace(worktype.end_date) ? string.Empty : " - " + worktype.end_date)); sb.Append(Environment.NewLine);

            }
        }

        if (userinfo.education != null && userinfo.education.Length > 0)
        {
            sb.Append("<p style=\"font-size: 16pt; font-weight:bold; color:#999;\">Education</p>"); sb.Append(Environment.NewLine);

            foreach (FBEducationType education in userinfo.education)
            {
                string schoolname = education.school.name;
                string degree = (education.degree != null) ? education.degree.name : string.Empty;
                string startyear = (education.year != null) ? education.year.name : string.Empty;

                sb.Append(string.Format("<p style=\"font-weight:bold; font-size: 12pt;\">{0}</p>", HttpUtility.HtmlEncode(schoolname))); sb.Append(Environment.NewLine);

                string comma = string.Empty;
                if (!string.IsNullOrEmpty(degree) && !string.IsNullOrEmpty(startyear))
                {
                    comma = ", ";
                }
                sb.Append(string.Format("<p>{0}{1}{2}</p>", degree, comma, startyear)); sb.Append(Environment.NewLine);


                sb.Append("<p>&nbsp;</p>"); sb.Append(Environment.NewLine);
            }
        }

        sb.Append("</font>"); sb.Append(Environment.NewLine);
        sb.Append("</body>"); sb.Append(Environment.NewLine);
        sb.Append("</html>");


        return sb.ToString();
    }

    public string GetUserInfo(out string accesstoken)
    {
        _logger.Info("GetUserInfo() Started!");

        accesstoken = string.Empty;

        if (string.IsNullOrEmpty(ClientID) || string.IsNullOrEmpty(RedirectURI) || string.IsNullOrEmpty(ClientSecret) || string.IsNullOrEmpty(Code))
        {
            _logger.WarnFormat("Cannot retrieve user info: {0}, Redirect: {1}, Code: {2}", ClientID, RedirectURI, Code);
            return "Error: Please provide ClientID, Redirect URI, ClientSecret & Code";
        }

        string url = string.Format(access_token_url, ClientID, HttpUtility.UrlEncode(RedirectURI), ClientSecret, Code);
        _logger.DebugFormat("Get User Info URL: Token URL: {0}, ClientID: (1}, RedirectURL: {2}, Secret:{3}, Code: {4}", access_token_url, ClientID, HttpUtility.UrlEncode(RedirectURI), "*****", "****");

        try
        {
            HttpWebRequest webrequest = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse webresponse = webrequest.GetResponse() as HttpWebResponse;

            if (webresponse.StatusCode.ToString() == "OK")
            {
                Stream stream = webresponse.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string result = reader.ReadToEnd();
                _logger.DebugFormat("GetUserInfo webresponse result: {0}", result);

                if (!string.IsNullOrWhiteSpace(result))
                {
                    string[] strs = result.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string s in strs)
                    {
                        if (s.StartsWith("access_token="))
                        {
                            accesstoken = s.Replace("access_token=", string.Empty);
                            break;
                        }
                    }

                    if (!string.IsNullOrEmpty(accesstoken))
                    {
                        return RetrieveUserInfo(accesstoken);
                    }
                    else
                    {
                        _logger.Error("Access Token Request Failed: Access Token Null or Empty");
                        return "Error: Request Failed";              
                    }
                }
                else
                {
                    _logger.Error("GetUserInfo Request Failed: Webresponse is Null or empty");
                    return "Error: Request Failed";
                }
            }
            else
            {
                _logger.Error("Webresponse returned 404");
                return "Error: Request Failed";
            }
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
            return " GetUserInfoError: " + ex.Message + "<br />";
        }
    }

    private string RetrieveUserInfo(string access_token)
    {
        _logger.Info("Retrieving User Info\n");

        string url = string.Format(userinfo_url, access_token);
        _logger.InfoFormat("Request URL: {0}", url);

        HttpWebRequest webrequest = WebRequest.Create(url) as HttpWebRequest;

        HttpWebResponse webresponse = webrequest.GetResponse() as HttpWebResponse;
        _logger.DebugFormat("Http Response Status: {0}", webresponse.StatusDescription);

        string result = string.Empty;

        if (webresponse.StatusCode.ToString() == "OK")
        {
            Stream stream = webresponse.GetResponseStream();
            StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
       
            result = reader.ReadToEnd();
            _logger.DebugFormat("RetrieveUserInfo Weresponse JSON: {0}", result);
            
            result = result.Replace(@"u0040", "@");

            result = Regex.Unescape(result);

            _logger.DebugFormat("Unescaped Http Response: {0}", result);
        }

        return (string.IsNullOrEmpty(result) ? "Error: Request Failed" : result);
    }

    public string RetreiveAccessTokenWithFBCode()
    {
        _logger.Info("Retrieving facebook Access Token");
        if (string.IsNullOrEmpty(ClientID) || string.IsNullOrEmpty(RedirectURI) || string.IsNullOrEmpty(ClientSecret) || string.IsNullOrEmpty(Code))
        {
            _logger.WarnFormat("ClientId, RedirectURI, ClientSecret and Code are all required to Retrieve access token: ClientId {0}, Redirect: {1}, Code: {2}, ClientSecret: (no Im not logging it)", ClientID, RedirectURI, Code);
            return null;
        }

        WebResponse response;
        string tokenGetURL = "https://graph.facebook.com/v2.3/oauth/access_token?client_id=" + this.ClientID + "&redirect_uri=" + this.RedirectURI + "&code=" + this.Code + "&client_secret=";
        _logger.InfoFormat("oAuth Token URL {0}******", tokenGetURL);
        tokenGetURL += this.ClientSecret;

        try
        {
            WebRequest request = WebRequest.Create(tokenGetURL);
            response = request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());

            string tokenJsonObj = sr.ReadToEnd();
            _logger.DebugFormat("RetreiveAccessTokenWithFBCode() responsed Json: {0}", tokenJsonObj);

            FacebookToken tokenObj = new JavaScriptSerializer().Deserialize<FacebookToken>(tokenJsonObj);
            string token = tokenObj.access_token;

            sr.Close();
            response.Close();

            return token;
        }
        catch (WebException ex)
        {
            _logger.Error(ex);
            string msg = "";

            if (ex.Status == WebExceptionStatus.ProtocolError)
            {
                //throw ex;
                response = ex.Response;
                msg = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd().Trim();
                response.Close();
            }
            return null;
        }
    }

    public FacebookUserDetails RetreiveUserDetails(string token)
    {
        _logger.Info("Retrieving Facebook User Details\n");

        string url = string.Format(SocialMedia.Resource1.fb_userdetails_url, token);
        _logger.InfoFormat("Request url: {0}", url);

        WebRequest request = WebRequest.Create(url);
        WebResponse response = request.GetResponse();
        
        StreamReader sr = new StreamReader(response.GetResponseStream());

        string userJsonObj = sr.ReadToEnd();
        _logger.DebugFormat("Stream JSON Object: {0}", userJsonObj);

        FacebookUserDetails userObj = new JavaScriptSerializer().Deserialize<FacebookUserDetails>(userJsonObj);

        sr.Close();
        response.Close();

        return userObj;
    }

    class FBUserInfo
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public FBWorkType[] work { get; set; }
        public FBEducationType[] education { get; set; }
        public string id { get; set; }
        public string website { get; set; } 
    }

    class FBWorkType
    {
        public string end_date { get; set; }
        public FBPageType employer { get; set; }
        public string start_date { get; set; }
        public FBPageType position { get; set; }
    }

    class FBEducationType
    {
        public FBPageType school { get; set; }
        public string type { get; set; }
        public FBPageType year { get; set; }
        public FBPageType degree { get; set; }
    }

    class FBPageType
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    class FBDataPermission
    {
        public FBPermission[] data { get; set; }
    }

    class FBPermission
    {
        public string permission { get; set; }
        public string status { get; set; }
    }

}


