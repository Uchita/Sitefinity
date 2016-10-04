using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Xml;
using JXTPosterTransform.Library.Common;
using JXTPosterTransform.Library.Models;
using System.Configuration;
using System.Reflection;
using System.Web;

namespace JXTPosterTransform.Library.Methods.Client
{
    public class PullJsonFromRGF
    {
        #region Common Functions

        // Consumer Key from SFDC account
        private string clientID;
        // Consumer Secret from SFDC account
        private string clientSecret;

        // URL to exchange for the token
        string TokenURL;

        private string clientUsername;
        private string clientPassword;

        private string redirectURL = ""; 
        // Code an token generated during authentication
        //private string code;
        private TokenResponse token;

        public PullJsonFromRGF(ClientSetupModels.PullXmlFromSalesforceRGF rgfDetails)
        {
            clientID = rgfDetails.SFClientID;
            clientSecret = rgfDetails.SFClientSecret;
            clientUsername = rgfDetails.Username;
            clientPassword = rgfDetails.Password;
            TokenURL = rgfDetails.SFTokenReqURL;
        }


        private bool GetTokenWithOutAuthorize(out string errorMsg)
        {
            // Todo check token
            if (token == null)
            {
                // Create the message used to request a token

                StringBuilder body = new StringBuilder();
                body.Append("grant_type=password&format=json&");
                body.Append("client_id=" + clientID + "&");
                body.Append("client_secret=" + clientSecret + "&");
                body.Append("username=" + System.Web.HttpUtility.UrlEncode(clientUsername) + "&");
                body.Append("password=" + clientPassword);
                if (!string.IsNullOrEmpty(redirectURL))
                    body.Append("&redirect_uri=" + redirectURL);


                string result = Utils.HttpPost(TokenURL, body.ToString());

                if (string.IsNullOrEmpty(result))
                {
                    errorMsg = "Failed to authenticate with SalesForce credentials.";
                    return false;
                }

                // Convert the JSON response into a token object
                JavaScriptSerializer ser = new JavaScriptSerializer();
                token = ser.Deserialize<TokenResponse>(result);

                errorMsg = null;
                return true;
            }

            errorMsg = null;
            return true;
            // Read the REST resources
            //string s = HttpGet(token.instance_url + @"/services/data/v25.0/", "");

        }

        #endregion

        #region RGF

        public RGFJobBoardDataRoot ProcessXML(string jobBoardName, string requestHost, long epochTimestampInSeconds, string jobApplicationURL, bool stripJobTitle)
        {
            RGFJobBoardDataRoot rgfData = null;

            WebRequest webRequest = null;
            StreamReader responseStreamReader = null;
            string strTokenResponse = "";

            // Contacts https://www.salesforce.com/developer/docs/api/Content/sforce_api_objects_contact.htm
            string restContactsQuery = string.Empty;

            //int epochTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            long epochTime = epochTimestampInSeconds * 1000; //SF takes milliseconds

            // Get Token without authorization
            string tokenGetError;
            bool tokenGetSuccess = GetTokenWithOutAuthorize(out tokenGetError);

            if (!tokenGetSuccess)
                throw new Exception(tokenGetError);

            restContactsQuery = token.instance_url + string.Format(requestHost + "?jobBoardNames={0}&timestamp={1}", jobBoardName, epochTime);

            // 4. Use the access token to Request for the Member profile 
            webRequest = (HttpWebRequest)System.Net.WebRequest.Create(restContactsQuery);
            webRequest.Method = "GET";
            webRequest.Headers.Add("Authorization", "Bearer " + token.access_token);
            //webRequest.Headers.(new MediaTypeWithQualityHeaderValue("application/json"));


            System.Net.WebResponse response = null;
            try
            {
                response = webRequest.GetResponse();
                // Get the response of the Member Profile.
                Stream postStream = response.GetResponseStream();
                responseStreamReader = new StreamReader(postStream);

                strTokenResponse = responseStreamReader.ReadToEnd();

                //replace the job board name returned in the json to a generic string 
                //this allows a generic serialization/deserialization of the data @ the model level
                string newString = "jobboardlisting";  //jobBoardName.Replace(" ", "_");
                strTokenResponse = strTokenResponse.Replace(jobBoardName, newString);

                JavaScriptSerializer jss = new JavaScriptSerializer();
                jss.MaxJsonLength = Int32.MaxValue; //allow maximum count
                rgfData = jss.Deserialize<RGFJobBoardDataRoot>(strTokenResponse);

                // CUSTOM 
                if (rgfData != null && rgfData.jobBoards != null && rgfData.jobBoards.jobboardlisting != null)
                {
                    int trimLength = 1000; // Short Description maximum 1000 characters

                    String strContent = string.Empty;

                    foreach (Upserted d in rgfData.jobBoards.jobboardlisting.upserted)
                    {
                        #region Application URL replace
                        if (!string.IsNullOrEmpty(jobApplicationURL))
                        {
                            string thisJobAppURL = jobApplicationURL;

                            if (thisJobAppURL.Contains("{jobNumber}"))
                                thisJobAppURL = thisJobAppURL.Replace("{jobNumber}", d.jobNumber);

                            if (thisJobAppURL.Contains("{id}"))
                                thisJobAppURL = thisJobAppURL.Replace("{id}", d.id);

                            if (thisJobAppURL.Contains("{subIndustry}") && d.industries.Any())
                                thisJobAppURL = thisJobAppURL.Replace("{subIndustry}", HttpUtility.UrlEncode(d.industries.First().subIndustry));

                            if (thisJobAppURL.Contains("{jobTitle}"))
                                thisJobAppURL = thisJobAppURL.Replace("{jobTitle}", HttpUtility.UrlEncode(d.title));

                            d.jobApplicationURL = thisJobAppURL;    // New tag
                        }
                        #endregion

                        #region Short Description

                        strContent = string.Empty;
                        strContent = Common.Utils.StripHTML(d.jobAdvertisement);
                        if (strContent.Length > trimLength)
                        {
                            strContent = strContent.Substring(0, trimLength - 3) + "...";
                        }
                        d.shortDescription = strContent; // New tag

                        #endregion

                        #region Job Title

                        if (stripJobTitle)
                        {
                            string newJobTitle = d.title;

                            //remove all from close bracket first
                            int closeBracketIndex = newJobTitle.IndexOf(']');                            
                            if (closeBracketIndex > 0)
                                newJobTitle = newJobTitle.Remove(0, closeBracketIndex + 1);

                            int closeBracketIndex2 = newJobTitle.IndexOf('】');
                            if (closeBracketIndex2 > 0)
                                newJobTitle = newJobTitle.Remove(0, closeBracketIndex2 + 1);

                            //remove anything after ||
                            int doubleBarIndex = newJobTitle.IndexOf("||");

                            if (doubleBarIndex > 0)
                                newJobTitle = newJobTitle.Remove(doubleBarIndex);

                            d.title = newJobTitle.Trim();
                        }
                        
                        #endregion

                        // If the Work location is EMPTY
                        if (string.IsNullOrWhiteSpace(d.workLocation))
                        {
                            d.workLocation = "Others - All";
                        }

                        // If the job function is empty
                        if (d.jobFunctions == null || d.jobFunctions.Count() == 0 )
                        {
                            d.jobFunctions = new List<JobFunction>();
                            d.jobFunctions.Add(new JobFunction() { category = "None", function = "None" });
                        }
                        else if (d.jobFunctions != null && 
                                    (string.IsNullOrWhiteSpace(d.jobFunctions[0].category) || string.IsNullOrWhiteSpace(d.jobFunctions[0].function)) )
                        {
                            d.jobFunctions = new List<JobFunction>();
                            d.jobFunctions[0] = new JobFunction() { category = "None", function = "None" };
                        }
                    }
                }
                response.Close();
                webRequest = null;

            }
            catch (WebException ex)
            {
                string msg = "";

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    response = ex.Response;
                    msg = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd().Trim();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error - " + ex.Message); // TODO
                Console.WriteLine("Error - " + ex.StackTrace); // TODO
                Console.WriteLine("Error - " + ex.InnerException); // TODO
            }


            //if (salesForceContact != null && salesForceContact.records != null && salesForceContact.records.Count > 0)
            //{
            //    return salesForceContact;
            //}

            return rgfData;
        }

        public ResponseClass ProcessRGFModelToXML(RGFJobBoardDataRoot rgfData, string fileName)
        {
            ResponseClass responseClass = new ResponseClass();

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(RGFJobBoardDataRoot));

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UnicodeEncoding(false, false); // no BOM in a .NET string
            settings.Indent = false;
            settings.OmitXmlDeclaration = false;
            using (StringWriter textWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.Serialize(xmlWriter, rgfData);
                }
                responseClass.ResponseXML = textWriter.ToString();

                // Save the Raw XML
                System.IO.File.WriteAllText(ConfigurationManager.AppSettings["FTPTempStorage"] + fileName + "_Raw.xml", responseClass.ResponseXML);

                // Success to get the XML.
                responseClass.blnSuccess = true;

                /*else
                {
                    responseClass.strMessage = "Can't find the file from URL - " + XMLwithAuth.Host;
                    Console.WriteLine(responseClass.strMessage);
                }*/
            }
            return responseClass;
        }

        #region RGF Models

        public class TokenResponse
        {

            public string id { get; set; }
            public string issued_at { get; set; }
            public string refresh_token { get; set; }
            public string instance_url { get; set; }
            public string signature { get; set; }
            public string access_token { get; set; }

        }

        [Serializable]
        public class Language
        {
            public string level { get; set; }
            public string language { get; set; }
        }

        [Serializable]
        public class JobFunction
        {
            public string function { get; set; }
            public string category { get; set; }
        }

        [Serializable]
        public class Industry
        {
            public string subIndustry { get; set; }
            public string industry { get; set; }
        }

        [Serializable]
        public class Upserted
        {
            public string workLocation { get; set; }
            public string title { get; set; }
            public string status { get; set; }
            public string salaryCurrency { get; set; }
            public decimal? minSalary { get; set; }
            public decimal? maxSalary { get; set; }
            public List<Language> languages { get; set; }
            public string jobNumber { get; set; }
            public List<JobFunction> jobFunctions { get; set; }
            public string jobAdvertisement { get; set; }
            public List<Industry> industries { get; set; }
            public string id { get; set; }
            public string companyName { get; set; }
            public string companyId { get; set; }
            public string jobApplicationURL { get; set; }
            public string shortDescription { get; set; }
        }

        [Serializable]
        public class JobBoardRoot
        {
            public List<Upserted> upserted { get; set; }
            public List<string> removedIds { get; set; }
        }

        [Serializable]
        public class JobBoards
        {
            public JobBoardRoot jobboardlisting { get; set; }
        }

        [Serializable]
        public class RGFJobBoardDataRoot
        {
            public bool success { get; set; }
            public JobBoards jobBoards { get; set; }
        }

        #endregion

        #endregion
    }
}
