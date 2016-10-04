using System;
using System.Collections.Generic;
using System.Configuration;
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


public class oAuthSeek
{
    public string oAuth2GetAuthorizeToken(bool isLive, string domain, string clientId, string clientSecret, string code, out string ErrorMessage)
    {
        string authorizationToken = string.Empty;
        ErrorMessage = string.Empty;

        try
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();

            string tokenUrl = (isLive) ? "https://www.seek.com.au/api/iam/oauth2/token" : "https://www.seek.com.au.sandbox-qa/api/iam/oauth2/token";
            string grantType = "authorization_code";
            string bodyFormat = "code={0}&redirect_uri={1}&grant_type={2}";

            string redirecttUri = "https://" + domain + "/oauthcallback.aspx?cbtype=seek&cbaction=apply";

            string result;
            using (var client = new System.Net.WebClient())
            {
                client.Headers[System.Net.HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(clientId + ":" + clientSecret));
                client.Headers[System.Net.HttpRequestHeader.Authorization] = string.Format("Basic {0}", credentials);
                result = client.UploadString(tokenUrl, string.Format(bodyFormat, code, HttpUtility.UrlEncode(redirecttUri), grantType));
            }

            SeekAuthorizeContract oAuthResult = jss.Deserialize<SeekAuthorizeContract>(result);
            authorizationToken = oAuthResult.access_token;
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }

        return authorizationToken;
    }

    public string oAuth2GetPrefilled(bool isLive, string clientId, string clientSecret, string code, string advertiserid, string jobtitle, string joburl, string countrycode, string postcode, out string applicationid, out string firstname, out string lastname, out string email, out string phone, out string filename, out string ErrorMessage)
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();
        ErrorMessage = string.Empty;
        filename = string.Empty;
        applicationid = string.Empty;
        firstname = string.Empty;
        lastname = string.Empty;
        email = string.Empty;
        phone = string.Empty;

        try
        {
            // once we have our access token we can now call the Prefilled application endpoint to get our application data.
            string prefilledUrl = (isLive) ? "https://api.seek.com.au/v2/applications/prefilled" : "https://api.seek.com.au.sandbox-qa/v2/applications/prefilled";
            string result;
            using (var client = new System.Net.WebClient())
            {
                client.Headers[System.Net.HttpRequestHeader.ContentType] = "application/json";

                var credentials = code;
                client.Headers[System.Net.HttpRequestHeader.Authorization] = string.Format("Bearer {0}", credentials);
                string bodyContent = "{{ \"applicationFormUrl\" : \"" + joburl + "\", \"advertiserId\" : \"{0}\", \"positionTitle\"" +
                     ": \"{1}\", \"positionUri\" : \"{2}\", \"countryCode\" : \"{3}\", \"postalCode\" : \"{4}\"}}";
                result = client.UploadString(prefilledUrl, string.Format(bodyContent, advertiserid, jobtitle, joburl, countrycode, postcode));
            }

            SeekApplicationContract oAuthApplicantResult = jss.Deserialize<SeekApplicationContract>(result);
            applicationid = oAuthApplicantResult.id;
            firstname = oAuthApplicantResult.applicantInfo.firstName;
            lastname = oAuthApplicantResult.applicantInfo.lastName;
            email = oAuthApplicantResult.applicantInfo.emailAddress;
            phone = oAuthApplicantResult.applicantInfo.phoneNumber;
            // if resume is not empty
            if (oAuthApplicantResult.resume != null)
            {
                string resumeUrl = oAuthApplicantResult.resume.link;

                using (var client = new System.Net.WebClient())
                {
                    client.Headers[System.Net.HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[System.Net.HttpRequestHeader.Accept] = "application/octet-stream";
                    client.UseDefaultCredentials = true;
                    var credentials = code;
                    client.Headers[System.Net.HttpRequestHeader.Authorization] = string.Format("Bearer {0}", credentials);
                    string s = client.DownloadString(resumeUrl);
                    filename = client.ResponseHeaders["Content-Disposition"].Replace("attachment; filename=", string.Empty).Trim(new char[] {'"'});
                //    return s;
                }

                return resumeUrl;
            }
            else
            {
                return result;
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }

        return string.Empty;
    }

    public Stream oAuth2GetResume(string code, string resumeUrl, out string filename, out string ErrorMessage)
    {
        filename = string.Empty;
        ErrorMessage = string.Empty;

   
        try
        {
            using (var client = new System.Net.WebClient())
            {
                client.Headers[System.Net.HttpRequestHeader.ContentType] = "application/json";
                client.Headers[System.Net.HttpRequestHeader.Accept] = "application/octet-stream";
                client.UseDefaultCredentials = true;
                var credentials = code;
                client.Headers[System.Net.HttpRequestHeader.Authorization] = string.Format("Bearer {0}", credentials);
                Stream s = client.OpenRead(resumeUrl);
                filename = client.ResponseHeaders["Content-Disposition"].Replace("attachment; filename=", string.Empty).Trim(new char[] {'"'});

                return s;
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }

        return null;
    }

    public void oAuth2ApplyComplete(bool isLive, string clientId, string clientSecret, string applicationid, out string ErrorMessage)
    {
        try
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            ErrorMessage = string.Empty;

            string completeSignalUrl = (isLive) ? "https://api.seek.com.au/v2/applications/{0}/complete" : "https://api.seek.com.au.sandbox-qa/v2/applications/{0}/complete";
            string result = string.Empty;

            using (var client = new System.Net.WebClient())
            {
                client.Headers[System.Net.HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(clientId + ":" + clientSecret));
                client.Headers[System.Net.HttpRequestHeader.Authorization] = string.Format("Basic {0}", credentials);
                string tokenurl = (isLive) ? "https://www.seek.com.au/api/iam/oauth2/token" : "https://www.seek.com.au.sandbox-qa/api/iam/oauth2/token";

                result = client.UploadString(tokenurl, "grant_type=client_credentials");
            }

            SeekAuthorizeContract oAuthResult = jss.Deserialize<SeekAuthorizeContract>(result);
            string authorizationToken = oAuthResult.access_token;

            using (var client = new System.Net.WebClient())
            {
                client.Headers[System.Net.HttpRequestHeader.ContentType] = "application/json";
                var credentials = authorizationToken;
                client.Headers[System.Net.HttpRequestHeader.Authorization] = string.Format("Bearer {0}", credentials);
                const string bodyContent = "{{ \"completionDate\" : \"{0}\"}}";
                var url = string.Format(completeSignalUrl, applicationid);
                var bodyContentReplaced = string.Format(bodyContent, DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"));
                client.UploadString(url, bodyContentReplaced);
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    public string oAuth2GetProfileHTML(string profile, string logourl)
    {
        if (profile.StartsWith("Error:") || profile.StartsWith("The remote server returned an error:"))
        {
            return profile;
        }

        JavaScriptSerializer jss = new JavaScriptSerializer();
        SeekApplicationContract userinfo = jss.Deserialize<SeekApplicationContract>(profile);

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
                "Member Name -->", HttpUtility.HtmlEncode(userinfo.applicantInfo.firstName) + " " + HttpUtility.HtmlEncode(userinfo.applicantInfo.lastName))); sb.Append(Environment.NewLine);
        sb.Append(string.Format("<p style=\"font-size: 10pt;\">{0}</p><!-- Email -->", HttpUtility.HtmlEncode(userinfo.applicantInfo.emailAddress))); sb.Append(Environment.NewLine);

        if (!string.IsNullOrWhiteSpace(userinfo.applicantInfo.phoneNumber))
        {
            sb.Append(string.Format("<p style=\"font-size: 10pt;\">{0}</p><!-- phone -->", HttpUtility.HtmlEncode(userinfo.applicantInfo.phoneNumber))); sb.Append(Environment.NewLine);
        }

        if (userinfo.applicantInfo.currentLocation != null)
        {
            sb.Append(string.Format("<p style=\"font-size: 10pt;\">{0}</p><!-- Current Location -->", HttpUtility.HtmlEncode(userinfo.applicantInfo.currentLocation.description))); sb.Append(Environment.NewLine);
        }
        sb.Append("</td>"); sb.Append(Environment.NewLine);
        sb.Append("</tr>"); sb.Append(Environment.NewLine);
        sb.Append("</table>"); sb.Append(Environment.NewLine);

        if (userinfo.applicantInfo.highestQualification != null)
        {
            sb.Append("<p style=\"font-size: 16pt; font-weight:bold; color:#999;\">Highest Qualification</p>"); sb.Append(Environment.NewLine);
            sb.Append(string.Format("<p>{0}</p>", HttpUtility.HtmlEncode(userinfo.applicantInfo.highestQualification.description))); sb.Append(Environment.NewLine);
        }

        if (userinfo.applicantInfo.skills != null)
        {
            sb.Append("<p style=\"font-size: 16pt; font-weight:bold; color:#999;\">Skills</p>"); sb.Append(Environment.NewLine);
            foreach (string skill in userinfo.applicantInfo.skills)
            {
                sb.Append(string.Format("<p>{0}</p>", HttpUtility.HtmlEncode(skill))); sb.Append(Environment.NewLine);
            }
        }

        if (userinfo.applicantInfo.salaryAndVisaByCountry != null)
        {
            sb.Append("<p style=\"font-size: 16pt; font-weight:bold; color:#999;\">Salary and Visa By Country</p>"); sb.Append(Environment.NewLine);
            foreach (KeyValuePair<string, SeekSalary> seeksalary in userinfo.applicantInfo.salaryAndVisaByCountry)
            {
                SeekSalary salary = seeksalary.Value;

                sb.Append(string.Format("<p>{0}</p>", HttpUtility.HtmlEncode(salary.description))); sb.Append(Environment.NewLine);
                if (salary.hasWorkingVisa.HasValue)
                {
                    string yesno = (salary.hasWorkingVisa.Value) ? "Yes" : "No";
                    sb.Append(string.Format("<p>Has Working Visa: {0}</p>", yesno)); sb.Append(Environment.NewLine);
                }

                if (salary.minimumSalaryValue.HasValue)
                {
                    sb.Append(string.Format("<p>Minimum Salary: {0}</p>", HttpUtility.HtmlEncode(salary.minimumSalaryValue.Value))); sb.Append(Environment.NewLine);
                }

                if (salary.salaryType != null)
                {
                    sb.Append(string.Format("<p>Salary Type: {0}</p>", HttpUtility.HtmlEncode(salary.salaryType))); sb.Append(Environment.NewLine);
                }

                sb.Append(Environment.NewLine);
            }


            if (userinfo.applicantInfo.workHistory != null)
            {
                sb.Append("<p style=\"font-size: 16pt; font-weight:bold; color:#999;\">Work History</p>"); sb.Append(Environment.NewLine);
                foreach (SeekWorkHistory workhistory in userinfo.applicantInfo.workHistory)
                {
                    if (workhistory.jobTitle != null)
                    {
                        sb.Append(string.Format("<p>Job Title: {0}</p>", HttpUtility.HtmlEncode(workhistory.jobTitle))); sb.Append(Environment.NewLine);
                    }
                    if (workhistory.companyName != null)
                    {
                        sb.Append(string.Format("<p>Company Name: {0}</p>", HttpUtility.HtmlEncode(workhistory.companyName))); sb.Append(Environment.NewLine);
                    }
                    if (workhistory.industry != null)
                    {
                        sb.Append(string.Format("<p>Industry: {0}</p>", HttpUtility.HtmlEncode(workhistory.industry.description))); sb.Append(Environment.NewLine);
                    }
                    if (workhistory.achievements != null)
                    {
                        sb.Append(string.Format("<p>Achievements: {0}</p>", HttpUtility.HtmlEncode(workhistory.industry.description))); sb.Append(Environment.NewLine);
                    }

                    if (workhistory.from != null)
                    {
                        sb.Append(string.Format("<p>From: {0}</p>", HttpUtility.HtmlEncode(workhistory.from))); sb.Append(Environment.NewLine);
                    }

                    if (workhistory.to != null)
                    {
                        sb.Append(string.Format("<p>To: {0}</p>", HttpUtility.HtmlEncode(workhistory.to))); sb.Append(Environment.NewLine);
                    }

                    sb.Append(Environment.NewLine);
                }
            }
        }

        sb.Append("</font>"); sb.Append(Environment.NewLine);
        sb.Append("</body>"); sb.Append(Environment.NewLine);
        sb.Append("</html>");


        return sb.ToString();
    }

    public class SeekAuthorizeContract
    {
        public string access_token;
        public string token_type;
        public int expires_in;
    }

    public class SeekApplicationContract
    {
        public string id;
        public string created;
        public string updated;
        public SeekApplicantInfoContract applicantInfo;
        public SeekResumeContract resume;
        public string complete;
    }

    public class SeekApplicantInfoContract
    {
        public string firstName;
        public string lastName;
        public string emailAddress;
        public string phoneNumber;
        public SeekCurrentLocation currentLocation;
        public SeekHighestQualification highestQualification;
        public string[] skills;
        public Dictionary<string, SeekSalary> salaryAndVisaByCountry;
        public SeekWorkHistory[] workHistory;
    }

    public class SeekResumeContract
    {
        public string link;
    }

    public class SeekCurrentLocation
    {
        public string id;
        public string description;
    }

    public class SeekHighestQualification
    {
        public string id;
        public string description;
    }

    public class SeekWorkHistory
    {
        public string jobTitle;
        public string companyName;
        public SeekIndustry industry;
        public string achievements;
        public string from;
        public string to;
    }

    public class SeekSalary
    {
        public string description;
        public bool? hasWorkingVisa;
        public int? minimumSalaryValue;
        public string salaryType;
    }

    public class SeekIndustry
    {
        public string id;
        public string description;
    }
}