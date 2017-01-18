using System;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Web;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Text;
using System.Xml;
using System.Collections.Generic;
using log4net;

public class oAuthLinkedIn : oAuthBase2
{
    private ILog _logger;

    public enum Method { GET, POST, PUT, DELETE };

    private string request_token_url = SocialMedia.Resource1.li_oauth2_authorization;
    private string request_token_login_url = SocialMedia.Resource1.li_oauth2_authorization_login;
    private string mobile_request_token_url = SocialMedia.Resource1.li_oauth2_mobile_authorization;
    private string access_token_url = SocialMedia.Resource1.li_oauth2_accessToken;
    private string authenticate_url = SocialMedia.Resource1.li_authenticate;
    private string people_url = SocialMedia.Resource1.li_people;
    private string people_email_url = SocialMedia.Resource1.li_email_address;

    public string ConsumerKey { get; set; } 
    public string ConsumerSecret {get; set;}
    public string Token { get; set; } 
    public string TokenSecret { get; set; }

    public oAuthLinkedIn()
    {
    }

    public oAuthLinkedIn(string consumerKey, string consumerSecret)
    {
        ConsumerKey = consumerKey;
        ConsumerSecret = consumerSecret;
    }

    public string oAuth2AccessToken(string code, string redirecturi, string clientid, string clientsecret)
    {
        string url = string.Format(access_token_url, code, redirecturi, clientid, clientsecret);

        _logger.InfoFormat("WebRequest URL(access_token_url, code, redirecturi, clientid, clientsecret): {0}{0}{0}*****", access_token_url, code, redirecturi, clientid);
        return WebRequest(Method.POST, url, string.Empty);
    }

    public string oAuth2GetProfile(string accesscode)
    {
        return oAuth2GetProfile(accesscode, false);
    }

    public string oAuth2GetProfile(string accesscode, bool resultInJson)
    {
        string url = people_url + ":(first-name,last-name,headline,summary,specialties,educations,industry,positions,interests,patents,languages,skills,certifications,courses,volunteer,three-current-positions,three-past-positions,date-of-birth,phone-numbers,bound-account-types,im-accounts,main-address,twitter-accounts,primary-twitter-account,recommendations-received,projects,picture-url)?oauth2_access_token=" + accesscode;
        _logger.InfoFormat("oAuth2GetProfile URL: {0}", url);

        if (resultInJson)
            url += "&format=json";

        return WebRequest(Method.GET, url, string.Empty);
    }

    public string oAuth2GetEmail(string accesscode)
    {
        return oAuth2GetEmail(accesscode, false);
    }

    public string oAuth2GetEmail(string accesscode, bool resultInJson)
    {
        string url = people_email_url + "?oauth2_access_token=" + accesscode;
        _logger.InfoFormat("oAuth2GetEmail URL: {0}", people_email_url);

        if (resultInJson)
            url += "&format=json";

        return WebRequest(Method.GET, url, string.Empty);
    }

    public string oAuth2GetProfileHTML(string accessToken, string logourl)
    {
        string strFirstName = string.Empty;
        string strSurame = string.Empty;
        string strEmail = string.Empty;
        string strHeadline = string.Empty;
        string strPictureUrl = string.Empty;
        string strSummary = string.Empty;
        string strExperience = string.Empty;
        string strProjects = string.Empty;
        string strOrganizations = string.Empty;
        string strVolunteerExperience = string.Empty;
        string strLanguages = string.Empty;
        string strSkills = string.Empty;
        string strEducation = string.Empty;
        string strInterests = string.Empty;
        string strRecommendations = string.Empty;

        string profile = oAuth2GetProfile(accessToken);
        string email = oAuth2GetEmail(accessToken);
        string sth = String.Empty;

        if (profile.StartsWith("Error:") || profile.StartsWith("The remote server returned an error:"))
        {
            _logger.ErrorFormat("LinkedIn Profile Error");
            return profile;
        }
        if (email.StartsWith("Error:") || profile.StartsWith("The remote server returned an error:"))
        {
            _logger.ErrorFormat("LinkedIn Email Error");
            return email;
        }

        XmlDocument ppxml = new XmlDocument();
        ppxml.LoadXml(profile);

        XmlDocument pexml = new XmlDocument();
        pexml.LoadXml(email);

        strFirstName = ppxml.GetElementsByTagName("first-name")[0].InnerText;
        strSurame = ppxml.GetElementsByTagName("last-name")[0].InnerText;
        strEmail = pexml.GetElementsByTagName("email-address")[0].InnerText;

        _logger.InfoFormat("LinkedIn firstName: {0}, LastName: {1}, Email: {2}", strFirstName, strSurame, strEmail );

        if ((ppxml.GetElementsByTagName("headline").Count > 0))
        {
            strHeadline = ppxml.GetElementsByTagName("headline")[0].InnerText;
        }
        if ((ppxml.GetElementsByTagName("picture-url").Count > 0))
        {
            strPictureUrl = ppxml.GetElementsByTagName("picture-url")[0].InnerText;
        }
        if ((ppxml.GetElementsByTagName("summary").Count > 0))
        {
            strSummary = ppxml.GetElementsByTagName("summary")[0].InnerText;
        }
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
                "Member Name -->", strFirstName + " " + strSurame)); sb.Append(Environment.NewLine);
        sb.Append(string.Format("<p style=\"font-size: 12pt;\">{0}</p><!-- Headline -->", strHeadline)); sb.Append(Environment.NewLine);
        sb.Append(string.Format("<p style=\"font-size: 10pt;\">{0}</p></td><!-- Email -->", strEmail)); sb.Append(Environment.NewLine);
        sb.Append(string.Format("<td width=\"25%\" align=\"right\" valign=\"top\"><img src=\"{0}\" height=\"150\" width=\"150\"><!-- Picture URL -" +
                "-></td>", strPictureUrl)); sb.Append(Environment.NewLine);
        sb.Append("</tr>"); sb.Append(Environment.NewLine);
        sb.Append("</table>"); sb.Append(Environment.NewLine);

        if (!string.IsNullOrEmpty(strSummary))
        {
            sb.Append("<p style=\"font-size: 16pt; font-weight:bold; color:#999;\">Summary</p>"); sb.Append(Environment.NewLine);
            sb.Append(("<p>"
                            + (HttpUtility.HtmlEncode(strSummary).Replace("\n", "<br />") + "</p>"))); sb.Append(Environment.NewLine);
            sb.Append("<p>&nbsp;</p>"); sb.Append(Environment.NewLine);
        }

        if ((ppxml.GetElementsByTagName("positions").Count > 0))
        {
            string positionTitle = string.Empty;
            string positionSummary = string.Empty;
            string startYear = string.Empty;
            string startMonth = string.Empty;
            string endYear = string.Empty;
            string endMonth = string.Empty;
            string companyName = string.Empty;
            DateTimeFormatInfo formatinfo = new DateTimeFormatInfo();
            if ((ppxml.GetElementsByTagName("positions")[0].ChildNodes.Count > 0))
            {
                sb.Append("<p style=\"font-size: 16pt; font-weight:bold; color:#999;\">Experience</p>"); sb.Append(Environment.NewLine);
            }
            foreach (XmlNode node in ppxml.GetElementsByTagName("positions")[0].ChildNodes)
            {
                positionTitle = (node["title"] == null) ? string.Empty : node["title"].InnerText;
                positionSummary = (node["summary"] == null) ? string.Empty : node["summary"].InnerText;

                if (!(node["start-date"] == null))
                {

                    startYear = (node["start-date"]["year"] == null) ? string.Empty : node["start-date"]["year"].InnerText;
                    startMonth = (node["start-date"]["month"] == null) ? string.Empty : node["start-date"]["month"].InnerText;
                    if ((node["is-current"].InnerText == "true"))
                    {
                        endYear = "Present";
                    }
                    else
                    {
                        endYear = (node["end-date"]["year"] == null) ? string.Empty : node["end-date"]["year"].InnerText;
                        endMonth = (node["end-date"]["month"] == null) ? string.Empty : node["end-date"]["month"].InnerText;
                    }
                }
                companyName = (node["company"]["name"] == null) ? string.Empty : node["company"]["name"].InnerText;
                sb.Append(string.Format("<p style=\"font-weight:bold; font-size: 12pt;\">{0} at {1}</p>", positionTitle, companyName)); sb.Append(Environment.NewLine);
                DateTime? startDate = (DateTime?)null;
                DateTime? endDate = (DateTime?)null;
                if ((endYear == "Present"))
                {
                    endDate = DateTime.Now;
                    if ((!string.IsNullOrEmpty(startYear)
                                && !string.IsNullOrEmpty(startMonth)))
                    {
                        startDate = new DateTime(int.Parse(startYear), int.Parse(startMonth), 1);
                    }
                    else
                    {
                        startDate = new DateTime(int.Parse(startYear), 1, 1);
                    }
                }
                else if ((!string.IsNullOrEmpty(startMonth)
                            && !string.IsNullOrEmpty(endMonth)))
                {
                    startDate = new DateTime(int.Parse(startYear), int.Parse(startMonth), 1);
                    endDate = new DateTime(int.Parse(endYear), int.Parse(endMonth), 1);
                }
                else if ((!string.IsNullOrEmpty(startYear)
                            && !string.IsNullOrEmpty(endYear)))
                {
                    startDate = new DateTime(int.Parse(startYear), 1, 1);
                    endDate = new DateTime(int.Parse(endYear), 1, 1);
                }

                if (string.IsNullOrEmpty(startMonth))
                {
                    startMonth = "13";
                }
                if (string.IsNullOrEmpty(endMonth))
                {
                    endMonth = "13";
                }
                
                string strEndMonth = (endMonth == "Present") ? endMonth : formatinfo.GetMonthName(Convert.ToInt32(endMonth)) + " " + endYear; ;

                if (startDate.HasValue && endDate.HasValue)
                {
                    TimeSpan ts = endDate.Value.Subtract(startDate.Value);
                    sb.Append(string.Format("<p>{0} {1} - {2} ({3} years {4} months)</p>", formatinfo.GetMonthName(int.Parse(startMonth)), startYear, strEndMonth, (int)(Math.Floor((ts.Days / 365.2425))), (int)((Math.Floor((ts.Days / 30.436875)) % 12)))); sb.Append(Environment.NewLine);                
                }

                sb.Append(string.Format("<p>{0}</p><p> </p>", HttpUtility.HtmlEncode(positionSummary).Replace("\n", "<br />"))); sb.Append(Environment.NewLine);

            }
        }

        if ((ppxml.GetElementsByTagName("projects").Count > 0))
        {
            string projectTitle = string.Empty;
            string projectDescription = string.Empty;
            if (ppxml.GetElementsByTagName("projects")[0] != null && (ppxml.GetElementsByTagName("projects")[0].ChildNodes.Count > 0))
            {
                sb.Append("<p style=\"font-size: 16pt; font-weight:bold; color:#999;\">Projects</p>"); sb.Append(Environment.NewLine);

                foreach (XmlNode node in ppxml.GetElementsByTagName("projects")[0].ChildNodes)
                {
                    projectTitle = (node["name"] == null) ? string.Empty : node["name"].InnerText;
                    projectDescription = (node["description"] == null) ? string.Empty : node["description"].InnerText;
                    sb.Append(string.Format("<p style=\"font-weight:bold; font-size: 12pt;\">{0}</p>", HttpUtility.HtmlEncode(projectTitle))); sb.Append(Environment.NewLine);
                    sb.Append(string.Format("<p>{0};</p>", HttpUtility.HtmlEncode(projectDescription).Replace("\n", "<br />"))); sb.Append(Environment.NewLine);
                    sb.Append("<p>&nbsp;</p>"); sb.Append(Environment.NewLine);
                }
            }
        }
        //if ((ppxml.GetElementsByTagName("volunteer").Count > 0))
        //{
        //    string volunteerRole = string.Empty;
        //    string volunteerOrganization = string.Empty;
        //    if ((ppxml.GetElementsByTagName("volunteer-experience")[0].ChildNodes.Count > 0))
        //    {
        //        sb.Append("<p style=\"font-size: 16pt; font-weight:bold; color:#999;\">Volunteer Experience</p>"); sb.Append(Environment.NewLine);
        //    }
        //    foreach (XmlNode node in ppxml.GetElementsByTagName("volunteer-experiences")[0].ChildNodes)
        //    {
        //        volunteerRole = (node["role"] == null) ? string.Empty : node["role"].InnerText;
        //        volunteerOrganization = (node["organization"] == null) ? string.Empty : node["organization"]["name"].InnerText;

        //        sb.Append(string.Format("<p style=\"font-weight:bold; font-size: 12pt;\">{0}</p>", HttpUtility.HtmlEncode(volunteerRole))); sb.Append(Environment.NewLine);
        //        sb.Append(string.Format("<p>{0}</p>", HttpUtility.HtmlEncode(volunteerOrganization))); sb.Append(Environment.NewLine);
        //        sb.Append("<p>&nbsp;</p>"); sb.Append(Environment.NewLine);
        //    }
        //}
        if ((ppxml.GetElementsByTagName("languages").Count > 0))
        {
            string languagename = string.Empty;
            if (ppxml.GetElementsByTagName("language")[0] != null && (ppxml.GetElementsByTagName("language")[0].ChildNodes.Count > 0))
            {
                sb.Append("<p style=\"font-size: 16pt; font-weight:bold; color:#999;\">Languages</p>"); sb.Append(Environment.NewLine);
            
            foreach (XmlNode node in ppxml.GetElementsByTagName("languages")[0].ChildNodes)
            {
                languagename = (node["language"]["name"] == null) ? string.Empty : node["language"]["name"].InnerText;
                sb.Append(string.Format("<p>{0}</p>", HttpUtility.HtmlEncode(languagename))); sb.Append(Environment.NewLine);
            }}
            sb.Append("<p>&nbsp;</p>"); sb.Append(Environment.NewLine);
        }
        if ((ppxml.GetElementsByTagName("skills").Count > 0))
        {
            string skills = string.Empty;
            if (ppxml.GetElementsByTagName("skill")[0] != null && (ppxml.GetElementsByTagName("skill")[0].ChildNodes.Count > 0))
            {
                sb.Append("<p style=\"font-size: 16pt; font-weight:bold; color:#999;\">Skills Expertise</p>"); sb.Append(Environment.NewLine);
                sb.Append("<ul>"); sb.Append(Environment.NewLine);
                foreach (XmlNode node in ppxml.GetElementsByTagName("skills")[0].ChildNodes)
                {

                    skills = (node["skill"]["name"] == null) ? string.Empty : node["skill"]["name"].InnerText;
                    sb.Append(string.Format("<li>{0}</li>", HttpUtility.HtmlEncode(skills))); sb.Append(Environment.NewLine);

                }

                sb.Append("</ul>"); sb.Append(Environment.NewLine);
                sb.Append("<p>&nbsp;</p>"); sb.Append(Environment.NewLine);
            }
        }
        if ((ppxml.GetElementsByTagName("educations").Count > 0))
        {
            string schoolname = string.Empty;
            string degree = string.Empty;
            string fieldofstudy = string.Empty;
            string startyear = string.Empty;
            string endyear = string.Empty;

            if (ppxml.GetElementsByTagName("education")[0] != null && (ppxml.GetElementsByTagName("education")[0].ChildNodes.Count > 0))
            {
                sb.Append("<p style=\"font-size: 16pt; font-weight:bold; color:#999;\">Education</p>"); sb.Append(Environment.NewLine);

                foreach (XmlNode node in ppxml.GetElementsByTagName("educations")[0].ChildNodes)
                {
                    schoolname = (node["school-name"] == null) ? string.Empty : node["school-name"].InnerText;
                    degree = (node["degree"] == null) ? string.Empty : node["degree"].InnerText;
                    fieldofstudy = (node["field-of-study"] == null) ? string.Empty : node["field-of-study"].InnerText;
                    startyear = (node["start-date"] == null) ? string.Empty : node["start-date"]["year"].InnerText;
                    endyear = (node["end-date"] == null) ? string.Empty : node["end-date"]["year"].InnerText;

                    if (!string.IsNullOrEmpty(fieldofstudy))
                    {
                        fieldofstudy = (" in " + fieldofstudy);
                    }
                    if (!string.IsNullOrEmpty(endyear))
                    {
                        endyear = (" - " + endyear);
                    }
                    sb.Append(string.Format("<p style=\"font-weight:bold; font-size: 12pt;\">{0}</p>", HttpUtility.HtmlEncode(schoolname))); sb.Append(Environment.NewLine);
                    sb.Append(string.Format("<p>{0}{1}, {2}{3}</p>", degree, fieldofstudy, startyear, endyear)); sb.Append(Environment.NewLine);
                    sb.Append("<p>&nbsp;</p>"); sb.Append(Environment.NewLine);
                }
            }
        }
        if ((ppxml.GetElementsByTagName("interests").Count > 0))
        {
            sb.Append("<p style=\"font-size: 16pt; font-weight:bold; color:#999;\">Interests</p>"); sb.Append(Environment.NewLine);
            sb.Append(string.Format("<p>{0}</p>", HttpUtility.HtmlEncode(ppxml.GetElementsByTagName("interests")[0].InnerText))); sb.Append(Environment.NewLine);
            sb.Append("<p>&nbsp;</p>"); sb.Append(Environment.NewLine);
        }
        if ((ppxml.GetElementsByTagName("recommendations-received").Count > 0))
        {
            string recommendationtext = string.Empty;
            string firstname = string.Empty;
            string lastname = string.Empty;
            if (ppxml.GetElementsByTagName("recommendations-received")[0] != null && (ppxml.GetElementsByTagName("recommendations-received")[0].ChildNodes.Count > 0))
            {
                sb.Append("<p style=\"font-size: 16pt; font-weight:bold; color:#999;\">Recommendations</p>"); sb.Append(Environment.NewLine);

                foreach (XmlNode node in ppxml.GetElementsByTagName("recommendations-received")[0].ChildNodes)
                {
                    recommendationtext = (node["recommendation-text"] == null) ? string.Empty : node["recommendation-text"].InnerText;
                    firstname = (node["recommender"]["first-name"] == null) ? string.Empty : node["recommender"]["first-name"].InnerText;
                    lastname = (node["recommender"]["last-name"] == null) ? string.Empty : node["recommender"]["last-name"].InnerText;

                    sb.Append(string.Format("<p><i>{0}</i></p>", HttpUtility.HtmlEncode(recommendationtext))); sb.Append(Environment.NewLine);
                    sb.Append(string.Format("<p style=\"font-weight:bold;\">{0} {1}</p>", HttpUtility.HtmlEncode(firstname), HttpUtility.HtmlEncode(lastname))); sb.Append(Environment.NewLine);
                    sb.Append("<p>&nbsp;</p>"); sb.Append(Environment.NewLine);
                }
            }
        }
        sb.Append("</font>"); sb.Append(Environment.NewLine);
        sb.Append("</body>"); sb.Append(Environment.NewLine);
        sb.Append("</html>");

        return sb.ToString();
    }

    /// <summary>
    /// Submit a web request using oAuth.
    /// </summary>
    /// <param name="method">GET or POST</param>
    /// <param name="url">The full url, including the querystring.</param>
    /// <param name="postData">Data to post (querystring format)</param>
    /// <returns>The web server response.</returns>
    public string oAuthWebRequest(Method method, string url, string postData)
    {
        string outUrl = "";
        string querystring = "";
        string ret = "";

        _logger.Info("Submitting a oAuthWebRequest");

        //Setup postData for signing.
        //Add the postData to the querystring.
        if (method == Method.POST || method == Method.PUT)
        {
            if (postData.Length > 0)
            {
                //Decode the parameters and re-encode using the oAuth UrlEncode method.
                NameValueCollection qs = HttpUtility.ParseQueryString(postData);
                postData = "";
                foreach (string key in qs.AllKeys)
                {
                    if (postData.Length > 0)
                    {
                        postData += "&";
                    }
                    qs[key] = HttpUtility.UrlDecode(qs[key]);
                    qs[key] = this.UrlEncode(qs[key]);
                    postData += key + "=" + qs[key];

                }
                if (url.IndexOf("?") > 0)
                {
                    url += "&";
                }
                else
                {
                    url += "?";
                }
                url += postData;
            }
        }

        Uri uri = new Uri(url);

        //string nonce = this.GenerateNonce();
        //string timeStamp = this.GenerateTimeStamp();
        string nonce = GenerateNonce();
        string timeStamp = GenerateTimeStamp();


        //Generate Signature
        string sig = GenerateSignature(uri,
            ConsumerKey,
            ConsumerSecret,
            Token,
            TokenSecret,
            method.ToString(),
            timeStamp,
            nonce,
            string.Empty,
            out outUrl,
            out querystring);


        querystring += "&oauth_signature=" + HttpUtility.UrlEncode(sig);

        //Convert the querystring to postData
        if (method == Method.POST)
        {
            postData = querystring;
            querystring = "";
        }

        if (querystring.Length > 0)
        {
            outUrl += "?";
        }


        if (method == Method.POST || method == Method.GET)
        {
            ret = WebRequest(method, outUrl + querystring, postData, true);
        }

        return ret;
    }

    /// <summary>
    /// Web Request Wrapper
    /// </summary>
    /// <param name="method">Http Method</param>
    /// <param name="url">Full url to the web resource</param>
    /// <param name="postData">Data to post in querystring format</param>
    /// <returns>The web server response.</returns>
    public string WebRequest(Method method, string url, string postData, bool isJSON = false)
    {
        HttpWebRequest webRequest = null;
        StreamWriter requestWriter = null;
        string responseData = "";

        webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
        webRequest.Method = method.ToString();
        webRequest.ServicePoint.Expect100Continue = false;
        //webRequest.UserAgent  = "Identify your application please.";
        //webRequest.Timeout = 20000;

        if (method == Method.POST || method == Method.PUT)
        {
            if (method == Method.PUT)
            {
                webRequest.Method = "PUT";
            }

            webRequest.ContentType = "text/xml";
            if (isJSON)
            {
                webRequest.ContentType = "application/json";
            }

            //POST the data.
            requestWriter = new StreamWriter(webRequest.GetRequestStream());
            try
            {
                requestWriter.Write(postData);
            }
            catch
            {
                throw;
            }
            finally
            {
                requestWriter.Close();
                requestWriter = null;
            }
        }

        responseData = WebResponseGet(webRequest);

        webRequest = null;

        return responseData;
    }

    /// <summary>
    /// Process the web response.
    /// </summary>
    /// <param name="webRequest">The request object.</param>
    /// <returns>The response data.</returns>
    public string WebResponseGet(HttpWebRequest webRequest)
    {
        StreamReader responseReader = null;
        string responseData = "";

        try
        {
            responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
            responseData = responseReader.ReadToEnd();
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        finally
        {
            responseReader = null;
        }

        return responseData;
    }

    public string RequestToken(string clientkey, string urlauthority, string jobid = "", string friendlyname = "", string urlreferrerdomain = "", List<string> extraQueryParams = null)
    {
        _logger.Info("Token Request Initialised");
        List<string> queryParams = new List<string>();

        string returnString = string.Empty;

        if (!string.IsNullOrEmpty(jobid)) queryParams.Add("id=" + jobid);
        if (!string.IsNullOrWhiteSpace(friendlyname)) queryParams.Add("joburl=" + HttpUtility.UrlEncode(urlauthority + friendlyname));
        if (!string.IsNullOrWhiteSpace(urlreferrerdomain)) queryParams.Add("referrer=" + HttpUtility.UrlEncode(urlreferrerdomain));

        if (extraQueryParams != null)
        {
            foreach (string p in extraQueryParams)
                queryParams.Add(p);
        }
        _logger.DebugFormat("Extra Query params: {0} and Query Params: {1}", extraQueryParams, queryParams);

        string queryString = queryParams.Count == 0 ? string.Empty : ( "?" + String.Join("&",queryParams) );  

        if (string.IsNullOrEmpty(clientkey) == false && string.IsNullOrEmpty(urlauthority) == false)
        {
            returnString = string.Format(request_token_url + HttpUtility.UrlEncode(queryString), clientkey, HttpUtility.UrlEncode(urlauthority));
        }

        return returnString;
    }

    public string RequestLoginToken(string clientkey, string redirectURL)
    {
        _logger.InfoFormat("RequestLoginToken Initialised! ClientKey: {0} Redirect URI: {1}", clientkey, redirectURL);
        string returnString = string.Empty;

        if (string.IsNullOrEmpty(clientkey) == false)
        {
            returnString = string.Format(
                request_token_login_url,
                clientkey, HttpUtility.UrlEncode(redirectURL));
        }

        return returnString;
    }

    public string MobileRequestToken(string clientkey, string urlauthority, string jobid = "", string friendlyname = "", string urlreferrerdomain = "")
    {
        string returnString = string.Empty;
        string strfriendlyname = string.Empty;
        string strReferrer = string.Empty;
        if (!string.IsNullOrWhiteSpace(friendlyname)) strfriendlyname = "&joburl=" +  HttpUtility.UrlEncode(urlauthority + friendlyname);
        if (!string.IsNullOrWhiteSpace(urlreferrerdomain)) strReferrer = "&referrer=" + HttpUtility.UrlEncode(urlreferrerdomain);

        if (string.IsNullOrEmpty(clientkey) == false && string.IsNullOrEmpty(urlauthority) == false)
        {
            returnString = string.Format(mobile_request_token_url + (string.IsNullOrEmpty(jobid) ? string.Empty : HttpUtility.UrlEncode("?id=" + jobid)) + HttpUtility.UrlEncode(strfriendlyname) + HttpUtility.UrlEncode(strReferrer), clientkey, HttpUtility.UrlEncode(urlauthority + "/Job/oauthcallback"));
        }

        return returnString;
    }

    public string GetUserInfo()
    {
        _logger.Info("GetUserInfo() Started!");

        HttpWebResponse response = null;

        string url = people_url + ":(first-name,last-name,headline,summary,specialties,educations,industry,positions,interests,patents,languages,skills,certifications,courses,three-current-positions,three-past-positions,date-of-birth,phone-numbers,bound-account-types,im-accounts,main-address,twitter-accounts,primary-twitter-account,recommendations-received)";//":(first-name,last-name,headline,industry,positions,proposal-comments,associations,honors,interests,patents,languages,skills,certificates,educations,courses,three-current-positions,three-past-positions,date-of-birth)";

        _logger.DebugFormat("Token= " + this.Token);

        Uri uri = new Uri(url);

        string nonce = this.GenerateNonce();
        string timeStamp = this.GenerateTimeStamp();

        string outUrl, querystring;

        //Generate Signature
        string sig = GenerateSignature(
            uri,
            ConsumerKey,
            ConsumerSecret,
            Token,
            TokenSecret,
            "GET",
            timeStamp,
            nonce,
            string.Empty,
            out outUrl,
            out querystring);

        querystring += "&oauth_signature=" + HttpUtility.UrlEncode(sig);
        NameValueCollection qs = HttpUtility.ParseQueryString(querystring);

        _logger.DebugFormat("Token= " + Token);

        HttpWebRequest webRequest = null;

        webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
        webRequest.ContentType = "text/xml";
        webRequest.Method = "GET";
        string authHeader = "OAuth realm=\"\", ";
        authHeader += "oauth_nonce=\"" + nonce + "\", ";
        authHeader += "oauth_timestamp=\"" + timeStamp + "\", ";
        authHeader += "oauth_consumer_key=\"" + this.ConsumerKey + "\", ";
        authHeader += "oauth_signature_method=\"HMAC-SHA1\", ";
        authHeader += "oauth_version=\"1.0\", ";
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
                Stream postStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(postStream);

                returnString = reader.ReadToEnd();
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("500"))
            {
                WebResponseGet(url, ref response);
            }
        }


        return returnString;
    }

    public string GetUserEmail()
    {
        _logger.Info("GetUserEmail Start...");
        HttpWebResponse response = null;

        string url = people_email_url;
        _logger.InfoFormat("People Email URI: {0}", url);

        _logger.DebugFormat("Token= " + Token);

        Uri uri = new Uri(url);

        string nonce = GenerateNonce();
        string timeStamp = GenerateTimeStamp();

        string outUrl, querystring;

        //Generate Signature
        string sig = GenerateSignature(
            uri,
            ConsumerKey,
            ConsumerSecret,
            Token,
            TokenSecret,
            "GET",
            timeStamp,
            nonce,
            string.Empty,
            out outUrl,
            out querystring);

        querystring += "&oauth_signature=" + HttpUtility.UrlEncode(sig);
        NameValueCollection qs = HttpUtility.ParseQueryString(querystring);

        _logger.DebugFormat("Token= " + Token);

        HttpWebRequest webRequest = null;

        webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
        webRequest.ContentType = "text/xml";
        webRequest.Method = "GET";
        string authHeader = "OAuth realm=\"\", ";
        authHeader += "oauth_nonce=\"" + nonce + "\", ";
        authHeader += "oauth_timestamp=\"" + timeStamp + "\", ";
        authHeader += "oauth_consumer_key=\"" + this.ConsumerKey + "\", ";
        authHeader += "oauth_signature_method=\"HMAC-SHA1\", ";
        authHeader += "oauth_version=\"1.0\", ";
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
                Stream postStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(postStream);

                returnString = reader.ReadToEnd();
            }
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
            if (ex.Message.Contains("500"))
            {
                WebResponseGet(url, ref response);
            }
        }


        return returnString;
    }

    public string WebResponseGet(string url, ref HttpWebResponse response)
    {
        _logger.Info("WebResponseGet Started!");

        StreamReader responseReader = null;

        _logger.DebugFormat("Token= " + Token);

        Uri uri = new Uri(url);

        string nonce = GenerateNonce();
        string timeStamp = GenerateTimeStamp();

        string outUrl, querystring;

        //Generate Signature
        string sig = GenerateSignature(
            uri,
            ConsumerKey,
            ConsumerSecret,
            Token,
            TokenSecret,
            "GET",
            timeStamp,
            nonce,
            string.Empty,
            out outUrl,
            out querystring);

        querystring += "&oauth_signature=" + HttpUtility.UrlEncode(sig);
        NameValueCollection qs = HttpUtility.ParseQueryString(querystring);

        HttpWebRequest webRequest = null;

        webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
        webRequest.ContentType = "text/xml";
        webRequest.Method = "GET";
        string authHeader = "OAuth realm=\"\", ";
        authHeader += "oauth_nonce=\"" + nonce + "\", ";
        authHeader += "oauth_timestamp=\"" + timeStamp + "\", ";
        authHeader += "oauth_consumer_key=\"" + this.ConsumerKey + "\", ";
        authHeader += "oauth_signature_method=\"HMAC-SHA1\", ";
        authHeader += "oauth_version=\"1.0\", ";
        if (this.Token != "")
        {
            authHeader += "oauth_token=\"" + this.Token + "\", ";
        }
        if (this.TokenSecret != "")
        {
            authHeader += "oauth_secret=\"" + this.TokenSecret + "\", ";

        }
        authHeader += "oauth_signature=\"" + this.UrlEncode(sig) + "\"";
        webRequest.Headers.Add("Authorization", authHeader);
        string returnString = string.Empty;

        try
        {
            response = (HttpWebResponse)webRequest.GetResponse();
            returnString = response.StatusCode.ToString();
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
            if (ex.Message.Contains("500"))
            {
                WebResponseGet(url, ref response);
            }
        }


        return returnString;
    }

    /// <summary>
    /// Web Request Wrapper
    /// </summary>
    /// <param name="method">Http Method</param>
    /// <param name="url">Full url to the web resource</param>
    /// <param name="postData">Data to post in querystring format</param>
    /// <returns>The web server response.</returns>
    public string WebRequestWithPost(Method method, string url, string postData, ref HttpWebResponse response)
    {
        _logger.Info("Web Request with POST");

        _logger.DebugFormat("Token= " + Token);

        Uri uri = new Uri(url);

        string nonce = GenerateNonce();
        string timeStamp = GenerateTimeStamp();

        string outUrl, querystring;

        //Generate Signature
        string sig = GenerateSignature(
            uri,
            ConsumerKey,
            ConsumerSecret,
            Token,
            TokenSecret,
            "POST",
            timeStamp,
            nonce,
            string.Empty,
            out outUrl,
            out querystring);

        querystring += "&oauth_signature=" + HttpUtility.UrlEncode(sig);
        NameValueCollection qs = HttpUtility.ParseQueryString(querystring);

        HttpWebRequest webRequest = null;

        webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
        webRequest.ContentType = "text/xml";
        webRequest.Method = "POST";
        string authHeader = "OAuth realm=\"\", ";
        authHeader += "oauth_nonce=\"" + nonce + "\", ";
        authHeader += "oauth_timestamp=\"" + timeStamp + "\", ";
        authHeader += "oauth_consumer_key=\"" + ConsumerKey + "\", ";
        authHeader += "oauth_signature_method=\"HMAC-SHA1\", ";
        authHeader += "oauth_version=\"1.0\", ";
        if (Token != "")
        {
            authHeader += "oauth_token=\"" + Token + "\", ";
        }
        authHeader += "oauth_signature=\"" + UrlEncode(sig) + "\"";
        webRequest.Headers.Add("Authorization", authHeader);

        StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
        try
        {
            requestWriter.Write(postData);
        }
        catch
        {
            throw;
        }
        finally
        {
            requestWriter.Flush();
            requestWriter.Close();
            requestWriter = null;
        }


        response = (HttpWebResponse)webRequest.GetResponse();

        string returnString = response.StatusCode.ToString();
        _logger.DebugFormat("http response status code: {0}", returnString);

        webRequest = null;

        return returnString;

    }

    public string WebRequestWithPut(Method method, string url, string postData)
    {
        _logger.Info("webrequest with put");

        _logger.DebugFormat("Token= " + Token);

        Uri uri = new Uri(url);

        string nonce = GenerateNonce();
        string timeStamp = GenerateTimeStamp();

        string outUrl, querystring;

        //Generate Signature
        string sig = GenerateSignature(
            uri,
            ConsumerKey,
            ConsumerSecret,
            Token,
            TokenSecret,
            "PUT",
            timeStamp,
            nonce,
            string.Empty,
            out outUrl,
            out querystring);

        querystring += "&oauth_signature=" + HttpUtility.UrlEncode(sig);
        NameValueCollection qs = HttpUtility.ParseQueryString(querystring);

        HttpWebRequest webRequest = null;

        webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
        webRequest.ContentType = "text/xml";
        webRequest.Method = "PUT";
        string authHeader = "OAuth realm=\"\", ";
        authHeader += "oauth_nonce=\"" + nonce + "\", ";
        authHeader += "oauth_timestamp=\"" + timeStamp + "\", ";
        authHeader += "oauth_consumer_key=\"" + ConsumerKey + "\", ";
        authHeader += "oauth_signature_method=\"HMAC-SHA1\", ";
        authHeader += "oauth_version=\"1.0\", ";
        if (Token != "")
        {
            authHeader += "oauth_token=\"" + Token + "\", ";
        }
        authHeader += "oauth_signature=\"" + UrlEncode(sig) + "\"";
        webRequest.Headers.Add("Authorization", authHeader);

        StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
        try
        {
            requestWriter.Write(postData);
        }
        catch
        {
            throw;
        }
        finally
        {
            requestWriter.Flush();
            requestWriter.Close();
            requestWriter = null;
        }


        HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
        string returnString = response.StatusCode.ToString();
        _logger.DebugFormat("Return String: {0}", returnString);

        webRequest = null;

        return returnString;

    }

    public string WebRequestWithDelete(Method method, string url)
    {
        _logger.Info("Request With Delete");

        _logger.DebugFormat("Token= " + Token);

        Uri uri = new Uri(url);

        string nonce = GenerateNonce();
        string timeStamp = GenerateTimeStamp();

        string outUrl, querystring;

        //Generate Signature
        string sig = GenerateSignature(
            uri,
            ConsumerKey,
            ConsumerSecret,
            Token,
            TokenSecret,
            "DELETE",
            timeStamp,
            nonce,
            string.Empty,
            out outUrl,
            out querystring);

        querystring += "&oauth_signature=" + HttpUtility.UrlEncode(sig);
        NameValueCollection qs = HttpUtility.ParseQueryString(querystring);

        HttpWebRequest webRequest = null;

        webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
        webRequest.ContentType = "text/xml";
        webRequest.Method = "DELETE";
        string authHeader = "OAuth realm=\"\", ";
        authHeader += "oauth_nonce=\"" + nonce + "\", ";
        authHeader += "oauth_timestamp=\"" + timeStamp + "\", ";
        authHeader += "oauth_consumer_key=\"" + ConsumerKey + "\", ";
        authHeader += "oauth_signature_method=\"HMAC-SHA1\", ";
        authHeader += "oauth_version=\"1.0\", ";
        if (Token != "")
        {
            authHeader += "oauth_token=\"" + Token + "\", ";
        }
        authHeader += "oauth_signature=\"" + UrlEncode(sig) + "\"";
        webRequest.Headers.Add("Authorization", authHeader);

        StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
        try
        {
            requestWriter.Write(string.Empty);
        }
        catch
        {
            throw;
        }
        finally
        {
            requestWriter.Flush();
            requestWriter.Close();
            requestWriter = null;
        }


        HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
        string returnString = response.StatusCode.ToString();

        _logger.DebugFormat("Return String: {0}", returnString);
        webRequest = null;

        return returnString;

    }


}