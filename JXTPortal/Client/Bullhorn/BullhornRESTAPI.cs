using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;
using System.Configuration;
using JXTPortal.Entities.Models;
using System.IO;
using System.Xml.Serialization;
using System.Web;
using JXTPortal.Entities;
using log4net;

namespace JXTPortal.Client.Bullhorn
{
    public class BullhornRESTAPI
    {
        ILog _logger;
        #region JXT Services
        private IntegrationsService _integrationsService;
        private IntegrationsService IntegrationsService
        {
            get
            {
                if (_integrationsService == null)
                {
                    _integrationsService = new IntegrationsService();
                }

                return _integrationsService;
            }
        }

        private AdminIntegrations.Bullhorn _bhSettings;
        public AdminIntegrations.Bullhorn BullhornSettings
        {
            get
            {
                return _bhSettings;
            }
            set
            {
                _bhSettings = value;
            }
        }

        #endregion

        //https://api.codeproject.com/Samples - https://api.codeproject.com/Samples/ClientCredCsDoc
        //http://oauth.googlecode.com/svn/code/csharp/OAuthBase.cs
        //http://www.vankeyenberg.be/?p=92

        /*         
For customer accounts:
bullhorn.rest.authorize="https://auth.bullhornstaffing.com/oauth/authorize"
bullhorn.rest.token="https://auth.bullhornstaffing.com/oauth/token"
bullhorn.rest.baseUrl="https://rest.bullhornstaffing.com/rest-services"
For your sandbox:
bullhorn.rest.authorize="https://auth9.bullhornstaffing.com/oauth/authorize"
bullhorn.rest.token="https://auth9.bullhornstaffing.com/oauth/token"
bullhorn.rest.baseUrl="https://rest9.bullhornstaffing.com/rest-services"
        
         */

        string BH_AUTHORIZE_URL = "https://auth.bullhornstaffing.com/oauth/authorize";
        string BH_TOKEN_URL = "https://auth.bullhornstaffing.com/oauth/token";
        string BH_REST_URL = "https://rest.bullhornstaffing.com/rest-services";

        // Consumer Key from SFDC account
        private string clientKey;

        // Consumer Secret from SFDC account
        private string clientSecret;

        // Redirect URL configured in SFDC account
        private string redirectURL;

        public AdminIntegrations.Integrations integrations;

        // Code an token generated during authentication
        private AuthorizeToken _AuthorizeToken;
        private BHRestToken _BHRestToken;

        private string clientUsername;
        private string clientPassword;

        //Process
        //===================
        //1. Manual user login is required for at least once using OAuth, this will callback with a Code
        //2. Get Authorize Token with the Code provided (which also comes with an Refresh Token)
        //3. Use Authorize Token to login to BH and get a BH Rest Token
        //4. Use BH Rest Token to make REST API calls
        //5. If BH Rest Token expired, try step 3.
        //  5.1 If try step 3 failed, we use Refresh Token from step 2 to get a new Authorize Token
        //  5.2 Follow step 3 

        #region Constructors

        public BullhornRESTAPI(int siteId)
        {
            _logger = LogManager.GetLogger(typeof(BullhornRESTAPI));
            BullhornRESTAPI_INIT(siteId);
        }

        private void BullhornRESTAPI_INIT(int siteId)
        {
            integrations = IntegrationsService.AdminIntegrationsForSiteGet(siteId);

            if (integrations != null && integrations.Bullhorn != null)
            {
                // Set Bullhorn settings
                BullhornSettings = integrations.Bullhorn;

                clientKey = integrations.Bullhorn.ClientKey;
                clientSecret = integrations.Bullhorn.ClientSecret;

                clientUsername = integrations.Bullhorn.ClientUsername;
                clientPassword = integrations.Bullhorn.ClientPassword;

                //use this as default redirect uri because job/bullhornintegration will handle re-authorize if failed to get token
                string _hostName = HttpContext.Current.Request.IsLocal ? HttpContext.Current.Request.Url.Authority : HttpContext.Current.Request.Url.Host;
                string _redirectURL = String.Format("{0}://{1}/{2}", (HttpContext.Current.Request.IsSecureConnection ? "https" : "http"), _hostName, "job/bullhornintegration.aspx");

                redirectURL = _redirectURL; 

                if (!integrations.Bullhorn.isLive)  // If sandbox
                {
                    BH_AUTHORIZE_URL = "https://auth9.bullhornstaffing.com/oauth/authorize";
                    BH_TOKEN_URL = "https://auth9.bullhornstaffing.com/oauth/token";
                    BH_REST_URL = "https://rest9.bullhornstaffing.com/rest-services";
                }
            }
        }

        public BullhornRESTAPI(string key, string secret, string username, string password, bool isSandbox)
            : this(key, secret, null, username, password, isSandbox)
        {
        }

        public BullhornRESTAPI(string key, string secret, string redirectLink, string username, string password, bool isSandbox)
        {
            clientKey = key;
            clientSecret = secret;
            redirectURL = redirectLink;

            clientUsername = username;
            clientPassword = password;

            if (isSandbox)
            {
                BH_AUTHORIZE_URL = "https://auth9.bullhornstaffing.com/oauth/authorize";
                BH_TOKEN_URL = "https://auth9.bullhornstaffing.com/oauth/token";
                BH_REST_URL = "https://rest9.bullhornstaffing.com/rest-services";
            }
        }
        #endregion

        #region Individual Data/Entity API Calls

        public BHJobOrderRecord BHJobGetByID(int BHJobID, BullhornRESTAPI.BHRestToken restToken)
        {
            List<string> fields = new List<string>
            {
                 "title",
                 "description",
                 "isPublic"
                //"id",
                //"address",
                //"appointments",
                //"approvedPlacements",
                //"assignedUsers",
                //"benefits",
                //"billRateCategoryID",
                //"bonusPackage",
                //"branchCode",
                //"businessSectors",
                //"categories(*)",
                //"certificationList",
                //"certifications",
                //"clientBillRate",
                //"clientContact",
                //"clientCorporation",
                //"dateAdded",
                //"dateClosed",
                //"dateEnd",
                //"dateLastExported",
                //"degreeList",
                //"description",
                //"durationWeeks",
                //"educationDegree",
                //"employmentType",   
                //"externalCategoryID",
                //"externalID",
                //"feeArrangement",
                //"hoursOfOperation",
                //"hoursPerWeek",
                //"interviews",
                //"isDeleted",
                //"isInterviewRequired",
                //"isOpen",
                //"isPublic",
                //"notes",
                //"numOpenings",
                //"onSite",
                //"opportunity",
                //"optionsPackage",
                //"owner",
                //"payRate",
                //"placements",
                //"publicDescription",
                //"publishedZip",
                //"reasonClosed",
                //"reportTo",
                //"reportToClientContact",
                //"responseUser",
                //"salary",
                //"salaryUnit",
                //"sendouts",
                //"skillList",
                //"skills",
                //"source",
                //"startDate",
                //"status",
                //"submissions",
                //"tasks",
                //"taxRate",
                //"taxStatus",
                //"title",
                //"travelRequirements",
                //"type",
                //"usersAssigned",
                //"yearsRequired"
                //"specialties(*)"
            };


            //string jsonResult = HttpGet(_BHRestToken.restUrl + "search/JobOrder?query=isOpen:1 AND isDeleted:0 AND NOT status:archive&BhRestToken=" + restToken + "&fields=" + String.Join(",", fields));
            //Console.WriteLine(jsonResult);

            //string jsonResult2 = HttpGet(_BHRestToken.restUrl + "entity/JobOrder/123233?BhRestToken=" + _BHRestToken.BhRestToken + "&fields=" + String.Join(",", fields));
            //Response.Write(jsonResult2);

            //string query = ConfigurationManager.AppSettings["query"];

            //string jsonResult3 = HttpGet(_BHRestToken.restUrl + "search/JobOrder?query=isOpen:1 AND isDeleted:0 AND NOT status:archive&BhRestToken=" + _BHRestToken.BhRestToken + query); 
            ////"&fields=*,specialties(*)&count=20&start=0");// + String.Join(",", fields));
            //Response.Write(jsonResult3);

            string jsonResult4 = HttpGet(restToken.restUrl + "entity/JobOrder/" + BHJobID + "?fields=" + String.Join(",", fields) + "&BhRestToken=" + restToken.BhRestToken);

            // Convert the JSON response into a token object
            JavaScriptSerializer ser = new JavaScriptSerializer();
            BHJobOrderRecordBase thisJobOrder = ser.Deserialize<BHJobOrderRecordBase>(jsonResult4);

            thisJobOrder.data.JobOrderID = BHJobID;

            return thisJobOrder.data;

            //string jsonResult4 = HttpGet(_BHRestToken.restUrl + "search/JobOrder?query=isOpen:1 AND isDeleted:0 AND NOT status:archive&BhRestToken=" + _BHRestToken.BhRestToken + "&fields=*&count=20&start=0");// + String.Join(",", fields));
            //Response.Write(jsonResult4);
        }

        public bool BHJobUpdateByID(int BHJobOrderID, object objToSerialize, BullhornRESTAPI.BHRestToken restToken)
        {
            // Convert the object to JSON 
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string thisJson = ser.Serialize(objToSerialize);

            string aaa = HttpPost(restToken.restUrl + "entity/JobOrder/" + BHJobOrderID + "?BhRestToken=" + restToken.BhRestToken, thisJson);

            return false;
        }

        public BullhornRESTModels.PutResponse BHClientCorporationCreate(object objToSerialize, BullhornRESTAPI.BHRestToken restToken)
        {
            // Convert the object to JSON 
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string thisJson = ser.Serialize(objToSerialize);

            string corporationPutResponse = HttpPut(restToken.restUrl + "entity/ClientCorporation?BhRestToken=" + restToken.BhRestToken, thisJson);

            BullhornRESTModels.PutResponse thisResponse = ser.Deserialize<BullhornRESTModels.PutResponse>(corporationPutResponse);

            return thisResponse;
        }

        public BullhornRESTModels.ParseToCandidateResult BHCandidateToParse(Stream fileStream, string fileName, BullhornRESTAPI.BHRestToken restToken)
        {
            //reset position before upload
            fileStream.Position = 0;

            //TODO: check the format param as well as the content type
            string parseToCandidateResult = string.Empty;

            int retryAttempt = 0; 
            int maxRetry = 10;

            bool parseSuccess = false;

            while (retryAttempt < maxRetry && !parseSuccess)
            {
                try
                {
                    switch (fileName.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last().ToLower())
                    {
                        case "doc":
                            parseToCandidateResult = HttpPostFile(restToken.restUrl + "resume/parseToCandidate?format=doc&populateDescription=html&BhRestToken=" + restToken.BhRestToken, fileStream, "FileUpload1", fileName, "application/msword");
                            break;
                        case "docx":
                            parseToCandidateResult = HttpPostFile(restToken.restUrl + "resume/parseToCandidate?format=docx&populateDescription=html&BhRestToken=" + restToken.BhRestToken, fileStream, "FileUpload1", fileName, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
                            break;
                        case "pdf":
                            parseToCandidateResult = HttpPostFile(restToken.restUrl + "resume/parseToCandidate?format=pdf&populateDescription=html&BhRestToken=" + restToken.BhRestToken, fileStream, "FileUpload1", fileName, "application/pdf");
                            break;
                        case "txt":
                            parseToCandidateResult = HttpPostFile(restToken.restUrl + "resume/parseToCandidate?format=text&populateDescription=html&BhRestToken=" + restToken.BhRestToken, fileStream, "FileUpload1", fileName, "text/plain");
                            break;
                        case "rtf":
                            parseToCandidateResult = HttpPostFile(restToken.restUrl + "resume/parseToCandidate?format=rtf&populateDescription=html&BhRestToken=" + restToken.BhRestToken, fileStream, "FileUpload1", fileName, "application/rtf");
                            break;
                        case "odt":
                            parseToCandidateResult = HttpPostFile(restToken.restUrl + "resume/parseToCandidate?format=odt&populateDescription=html&BhRestToken=" + restToken.BhRestToken, fileStream, "FileUpload1", fileName, "application/vnd.oasis.opendocument.text");
                            break;
                    }

                    if ( parseToCandidateResult != null && !string.IsNullOrEmpty(parseToCandidateResult) )
                        parseSuccess = true;
                    else
                        retryAttempt++;
                }
                catch (Exception ex)
                {
                    retryAttempt++;
                }
            }

            if (!parseSuccess)
                throw new Exception("Failed to parse candidate resume.");

            JavaScriptSerializer ser = new JavaScriptSerializer();
            BullhornRESTModels.ParseToCandidateResult thisParse = (BullhornRESTModels.ParseToCandidateResult)ser.Deserialize(parseToCandidateResult, typeof(BullhornRESTModels.ParseToCandidateResult));

            //Manual processing of the first work history which is not documented in the BH documents
            if (thisParse.candidateWorkHistory != null && thisParse.candidateWorkHistory.Count() > 0)
            {
                BullhornRESTModels.WorkHistory latestWorkHistory = thisParse.candidateWorkHistory.First();

                thisParse.candidate.companyName = latestWorkHistory.companyName;
                thisParse.candidate.occupation = latestWorkHistory.title;
            }

            return thisParse;
        }

        public BullhornRESTModels.PutResponse BHCandidateCreate(BullhornRESTModels.Candidate candObj, BullhornRESTAPI.BHRestToken restToken)
        {
            // Convert the object to JSON 
            string thisJson = candObj.GenerateJson();

            string resp = HttpPut(restToken.restUrl + "entity/Candidate?BhRestToken=" + restToken.BhRestToken, thisJson);

            if (!string.IsNullOrEmpty(resp))
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();

                BullhornRESTModels.PutResponse thisResponse = ser.Deserialize<BullhornRESTModels.PutResponse>(resp);

                return thisResponse;
            }

            return null;
        }

        public List<BullhornRESTModels.PutResponse> BHEducationsCreate(int candidateID, List<BullhornRESTModels.Education> eduObjs, BullhornRESTAPI.BHRestToken restToken)
        {
            //TODO what happens when it fails?

            List<BullhornRESTModels.PutResponse> responses = new List<BullhornRESTModels.PutResponse>();

            foreach (BullhornRESTModels.Education edu in eduObjs)
            {
                // Convert the object to JSON 
                string thisJson = edu.GenerateJson(candidateID);

                string resp = HttpPut(restToken.restUrl + "entity/CandidateEducation?BhRestToken=" + restToken.BhRestToken, thisJson);

                if (!string.IsNullOrEmpty(resp))
                {
                    JavaScriptSerializer ser = new JavaScriptSerializer();

                    BullhornRESTModels.PutResponse thisResponse = ser.Deserialize<BullhornRESTModels.PutResponse>(resp);

                    responses.Add(thisResponse);
                }
            }
            return responses;
        }

        public BullhornRESTModels.BullhornCandidateGetResponse BHCandidateGet(int candidateID, BullhornRESTAPI.BHRestToken restToken)
        {
            //TODO what happens when it fails?
            BullhornRESTModels.BullhornCandidateGetResponse responses = null;

            string resp = HttpGet(restToken.restUrl + "entity/Candidate/" + candidateID + "?fields=categoryID,specialtyCategoryID&BhRestToken=" + restToken.BhRestToken);

            if (!string.IsNullOrEmpty(resp))
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                responses = ser.Deserialize<BullhornRESTModels.BullhornCandidateGetResponse>(resp);
            }
            return responses;
        }

        public BullhornRESTModels.PutResponse BHAssociationUpdate(int candidateID, string entityName, string toAssociationName, List<int> associateIDs, BullhornRESTAPI.BHRestToken restToken)
        {
            //TODO what happens when it fails?
            BullhornRESTModels.PutResponse responses = null;
            string errorMsg;

            string resp = HttpPut(restToken.restUrl + "entity/" + entityName + "/" + candidateID + "/" + toAssociationName + "/" + String.Join(",", associateIDs) + "?BhRestToken=" + restToken.BhRestToken, null, out errorMsg);

            if (!string.IsNullOrEmpty(resp))
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                responses = ser.Deserialize<BullhornRESTModels.PutResponse>(resp);
            }
            responses.errorMsg = errorMsg;
            return responses;
        }

        public List<BullhornRESTModels.PutResponse> BHWorkHistoryCreate(int candidateID, List<BullhornRESTModels.WorkHistory> wtObjs, BullhornRESTAPI.BHRestToken restToken)
        {
            //TODO what happens when it fails?

            List<BullhornRESTModels.PutResponse> responses = new List<BullhornRESTModels.PutResponse>();

            foreach (BullhornRESTModels.WorkHistory edu in wtObjs)
            {
                // Convert the object to JSON 
                string thisJson = edu.GenerateJson(candidateID);

                string resp = HttpPut(restToken.restUrl + "entity/CandidateWorkHistory?BhRestToken=" + restToken.BhRestToken, thisJson);

                if (!string.IsNullOrEmpty(resp))
                {
                    JavaScriptSerializer ser = new JavaScriptSerializer();

                    BullhornRESTModels.PutResponse thisResponse = ser.Deserialize<BullhornRESTModels.PutResponse>(resp);

                    responses.Add(thisResponse);
                }
            }
            return responses;
        }

        public BullhornRESTModels.PostResponse BHCandidateSkillSetUpdate(int candidateID, List<string> skills, BullhornRESTAPI.BHRestToken restToken)
        {
            //TODO what happens when it fails?

            BullhornRESTModels.PostResponse response = null;
            //string joinedSkills = String.Join(", ", skills).Replace("\"", "\\\"").Replace("\'","\\\'");
            string joinedSkills = String.Join(", ", skills);
            string resp = HttpPost(restToken.restUrl + "entity/Candidate/" + candidateID + "?BhRestToken=" + restToken.BhRestToken, "{ \"skillSet\": \"" + joinedSkills + "\" }");

            if (!string.IsNullOrEmpty(resp))
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();

                response = ser.Deserialize<BullhornRESTModels.PostResponse>(resp);
            }
            return response;
        }

        public BullhornRESTModels.OptionsGetResponse BHCandidateSkillsGet(BullhornRESTAPI.BHRestToken restToken)
        {
            //TODO what happens when it fails?
            BullhornRESTModels.OptionsGetResponse responses = null;

            string resp = HttpGet(restToken.restUrl + "options/Skill?BhRestToken=" + restToken.BhRestToken);

            if (!string.IsNullOrEmpty(resp))
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                responses = ser.Deserialize<BullhornRESTModels.OptionsGetResponse>(resp);
            }
            return responses;
        }

        public BullhornRESTModels.FileResponse BHCandidateFileAttach(int BHCandidateID, int? JXTSiteID, BullhornRESTAPI.BHRestToken restToken, Stream fileStream, string fileName)
        {
            restToken = AutoRetrieveRESTToken(JXTSiteID, restToken);

            //reset position before upload
            fileStream.Position = 0;

            string uploadResumeResult = string.Empty;
            string uploadFileContentType = string.Empty;

            switch (fileName.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last().ToLower())
            {
                case "txt":
                    uploadFileContentType = "text/plain";
                    break;
                case "doc":
                    uploadFileContentType = "application/msword";
                    break;
                case "docx":
                    uploadFileContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    break;
                case "pdf":
                    uploadFileContentType = "application/pdf";
                    break;
                case "rtf":
                    uploadFileContentType = "application/rtf";
                    break;
                case "xls":
                    uploadFileContentType = "application/vnd.ms-excel";
                    break;
                case "xlsx":
                    uploadFileContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    break;
            }

            //starts upload
            uploadResumeResult = HttpPutFile(restToken.restUrl + "file/Candidate/" + BHCandidateID + "/raw?externalID=Portfolio&fileType=SAMPLE&BhRestToken=" + restToken.BhRestToken, fileStream, "FileUpload1", fileName, uploadFileContentType);

            JavaScriptSerializer ser = new JavaScriptSerializer();
            BullhornRESTModels.FileResponse response = ser.Deserialize<BullhornRESTModels.FileResponse>(uploadResumeResult);

            return response;
        }

        public BullhornRESTModels.CategoryQueryGetResponse BHCategoriesGet(BullhornRESTAPI.BHRestToken restToken)
        {
            string jsonResult = HttpGet(restToken.restUrl + "query/Category?where=enabled=true&count=500&fields=id,dateAdded,description,enabled,externalID,name,occupation,skills(*),specialties(*)&BhRestToken=" + restToken.BhRestToken);

            // Convert the JSON response into a token object
            JavaScriptSerializer ser = new JavaScriptSerializer();
            BullhornRESTModels.CategoryQueryGetResponse thisCategories = ser.Deserialize<BullhornRESTModels.CategoryQueryGetResponse>(jsonResult);

            return thisCategories;
        }

        public BullhornRESTModels.SpecialtyQueryGetResponse BHSpecialtyGet(BullhornRESTAPI.BHRestToken restToken)
        {
            string jsonResult = HttpGet(restToken.restUrl + "query/Specialty?where=enabled=true&count=500&fields=*&BhRestToken=" + restToken.BhRestToken);

            // Convert the JSON response into a token object
            JavaScriptSerializer ser = new JavaScriptSerializer();
            BullhornRESTModels.SpecialtyQueryGetResponse thisSpecialties = ser.Deserialize<BullhornRESTModels.SpecialtyQueryGetResponse>(jsonResult);

            return thisSpecialties;
        }

        #endregion

        #region Authorization / Token Methods

        public bool GetTokenWithAuthorizeCode(string code, out string jsonToken)
        {
            // Create the message used to request a token

            StringBuilder body = new StringBuilder();
            body.Append("grant_type=authorization_code&format=json&");
            body.Append("code=" + System.Web.HttpUtility.UrlDecode(code) + "&");
            body.Append("client_id=" + clientKey + "&");
            body.Append("client_secret=" + clientSecret + "&");
            body.Append("username=" + clientUsername + "&");
            body.Append("password=" + clientPassword + "&");
            if( !string.IsNullOrEmpty(redirectURL) )
                body.Append("redirect_uri=" + redirectURL);
            string result = HttpPost(BH_TOKEN_URL, body.ToString());

            // Convert the JSON response into a token object
            JavaScriptSerializer ser = new JavaScriptSerializer();
            _AuthorizeToken = ser.Deserialize<AuthorizeToken>(result);

            if (_AuthorizeToken != null && !string.IsNullOrEmpty(_AuthorizeToken.access_token) && !string.IsNullOrEmpty(_AuthorizeToken.refresh_token))
            {
                /*{
                  "access_token" : "9:b36aafba-dce5-4a65-881f-2b8b12d70de8",
                  "token_type" : "Bearer",
                  "expires_in" : 600,
                  "refresh_token" : "9:dc706822-6530-43e5-91ec-45396eb8d298"
                }*/
                jsonToken = result;
                return true;
            }
            else
            {
                jsonToken = null;
                return false;
            }

        }

        public bool BullHornAPILogin(string accessToken, out BHRestToken restToken)
        {
            string loginURL = BH_REST_URL + "/login?version=2.0&access_token=" + accessToken;

            string loginJsonResponse = HttpGet(loginURL);

            if (string.IsNullOrEmpty(loginJsonResponse))
            {
                restToken = null;
                return false;
            }

            // Convert the JSON response into a token object
            JavaScriptSerializer ser = new JavaScriptSerializer();
            restToken = ser.Deserialize<BHRestToken>(loginJsonResponse);

            if (restToken != null && string.IsNullOrEmpty(restToken.errorMessage))
                return true;

            return false;
        }

        public bool BullhornTokenRefresh(string refreshToken, out AuthorizeToken newAuthToken)
        {
            string refreshURL = BH_TOKEN_URL;
            string result = HttpPost(refreshURL, "grant_type=refresh_token&refresh_token=" + refreshToken + "&client_id=" + clientKey + "&client_secret=" + clientSecret);

            if (string.IsNullOrEmpty(result))
            {
                newAuthToken = null;
                return false;
            }

            // Convert the JSON response into a token object
            JavaScriptSerializer ser = new JavaScriptSerializer();
            newAuthToken = ser.Deserialize<AuthorizeToken>(result);

            if (newAuthToken != null && !string.IsNullOrEmpty(newAuthToken.access_token) && !string.IsNullOrEmpty(newAuthToken.refresh_token))
                return true;

            return false;
        }

        public string GetAuthorizeUrl()
        {
            // Build authorization URI
            var authURI = new StringBuilder();
            authURI.Append(BH_AUTHORIZE_URL);
            authURI.Append("?response_type=code");
            authURI.Append("&client_id=" + clientKey);

            if (!string.IsNullOrEmpty(clientUsername))
                authURI.Append("&username=" + clientUsername);

            if (!string.IsNullOrEmpty(clientPassword))
                authURI.Append("&password=" + clientPassword);

            if( !string.IsNullOrEmpty(redirectURL))
                authURI.Append("&redirect_uri=" + redirectURL);

            // Redirect the browser control the the SFDC login page
            return (authURI.ToString());
        }


        public string GetAuthorizeUrl(string redirectURI_override)
        {
            // Build authorization URI
            var authURI = new StringBuilder();
            authURI.Append(BH_AUTHORIZE_URL);
            authURI.Append("?response_type=code");
            authURI.Append("&client_id=" + clientKey);

            if (!string.IsNullOrEmpty(clientUsername))
                authURI.Append("&username=" + clientUsername);

            if (!string.IsNullOrEmpty(clientPassword))
                authURI.Append("&password=" + clientPassword);

            if (!string.IsNullOrEmpty(redirectURI_override))
                authURI.Append("&redirect_uri=" + redirectURI_override);

            // Redirect the browser control the the SFDC login page
            return (authURI.ToString());
        }

        public bool BullhornRestTokenGet(int siteID, out BullhornRESTAPI.BHRestToken RESTToken, out string errorMsg)
        {
            return BullhornRestTokenGet(siteID, null, out RESTToken, out errorMsg);
        }

        public bool BullhornRestTokenGet(int siteID, string redirectURI_override, out BullhornRESTAPI.BHRestToken RESTToken, out string errorMsg)
        {
            bool apiLoginSuccess = BullHornAPILogin(BullhornSettings.RESTAuthToken, out RESTToken);

            if (apiLoginSuccess)
            {
                _BHRestToken = RESTToken;
            }
            else
            {
                //try refresh token
                BullhornRESTAPI.AuthorizeToken newAuthToken;
                bool refreshTokenSuccess = BullhornTokenRefresh(BullhornSettings.RESTAuthRefreshToken, out newAuthToken);

                if (refreshTokenSuccess)
                {
                    IntegrationsService.BullhornRESTTokenUpdate(siteID, newAuthToken.access_token, newAuthToken.refresh_token);

                    //reset auth tokens
                    _bhSettings.RESTAuthToken = newAuthToken.access_token;
                    _bhSettings.RESTAuthRefreshToken = newAuthToken.refresh_token;

                    apiLoginSuccess = BullHornAPILogin(newAuthToken.access_token, out RESTToken);

                    if (apiLoginSuccess)
                    {
                        _BHRestToken = RESTToken;
                        errorMsg = string.Empty;
                        return true;
                    }
                    else
                    //login with new credentials failed again
                    {
                        errorMsg = "Failed to login using auth access token.";
                        RESTToken = null;
                        return false;
                    }
                }
                else
                {
                    if (HttpContext.Current.Session["BHSessionData"] == null)
                    {
                        HttpContext.Current.Session["BHSessionData"] = HttpContext.Current.Request.Url;
                        //sends to authorize again
                        string authorizeRedirectURL;
                        if (!string.IsNullOrEmpty(redirectURI_override))
                            authorizeRedirectURL = GetAuthorizeUrl(redirectURI_override);
                        else
                            authorizeRedirectURL = GetAuthorizeUrl();

                        HttpContext.Current.Response.Redirect(authorizeRedirectURL, true);
                        errorMsg = null;
                        return false;
                    }

                    //if it falls here, it means we tried to re-authorize already, but failed again
                    //clean up and throw error 
                    HttpContext.Current.Session.Remove("BHSessionData");

                    errorMsg = "Failed to refresh API token.";
                    RESTToken = null;
                    return false;
                }
            }

            errorMsg = null;
            return true;
        }

        private BullhornRESTAPI.BHRestToken AutoRetrieveRESTToken(int? JXTSiteID, BullhornRESTAPI.BHRestToken restToken)
        {
            if (
                (restToken == null || string.IsNullOrEmpty(restToken.BhRestToken))
                && (JXTSiteID == null)
                )
            {
                throw new Exception("A valid BHRestToken or JXTSiteID is required");
            }

            //only sends get token requests if no BHtoken supplied and JXTsiteID is provided in this function
            if (restToken == null || string.IsNullOrEmpty(restToken.BhRestToken))
            {
                if (JXTSiteID != null)
                {
                    //gets REST Token
                    string errorMsg;

                    if (restToken == null)
                        BullhornRESTAPI_INIT(JXTSiteID.Value);

                    bool blnSuccess = BullhornRestTokenGet(JXTSiteID.Value, out restToken, out errorMsg);
                    if (!blnSuccess)
                        throw new Exception("Failed to retreive a valid BHRestToken");
                    else
                        return restToken;

                }
            }

            return restToken;
        }

        #endregion

        #region HTTP call methods
        private string HttpPut(string URI, string Parameters)
        {
            string errorMsg = null;
            return HttpPut(URI, Parameters, out errorMsg);
        }
        private string HttpPut(string URI, string Parameters, out string errorMsg)
        {
            errorMsg = string.Empty;

            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "PUT";

            if (!string.IsNullOrEmpty(Parameters))
            {
                // Add parameters to post
                byte[] data = System.Text.Encoding.ASCII.GetBytes(Parameters);
                req.ContentLength = data.Length;
                System.IO.Stream os = req.GetRequestStream();
                os.Write(data, 0, data.Length);
                os.Close();
            }

            // Do the post and get the response.
            System.Net.WebResponse response = null;

            try
            {
                response = req.GetResponse();
            }
            catch (WebException ex)
            {
                errorMsg = "WebException: " + ex.Message;
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    //throw ex;
                    response = ex.Response;
                    errorMsg += "(" + new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd().Trim() + ")";

#if RELEASE
                    // Test - TODO REMOVE HIMMY 
                    string IndeedDataFile = ConfigurationManager.AppSettings["301RedirectUrlFolder"];

                    if (!string.IsNullOrEmpty(IndeedDataFile))
                    {
                        string fname = IndeedDataFile + "bullhornError.txt";
                        string data1 = msg + "\n" + ex.Message + "\n" + ex.StackTrace + "\n" + ex.Response + "\n";
                        System.IO.File.WriteAllText(fname, data1);
                    }
#endif
                }
            }

            if (response == null) return null;

            System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());

            return sr.ReadToEnd().Trim();
        }

        public string HttpPost(string URI, string Parameters)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";

            // Add parameters to post
            byte[] data = System.Text.Encoding.ASCII.GetBytes(Parameters);
            req.ContentLength = data.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(data, 0, data.Length);
            os.Close();

            // Do the post and get the response.
            System.Net.WebResponse response = null;

            try
            {
                response = req.GetResponse();
            }
            catch (WebException ex)
            {
                string msg = "";

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    //throw ex;
                    response = ex.Response;
                    msg = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd().Trim();

#if RELEASE
                    // Test - TODO REMOVE HIMMY 
                    string IndeedDataFile = ConfigurationManager.AppSettings["301RedirectUrlFolder"];

                    if (!string.IsNullOrEmpty(IndeedDataFile))
                    {
                        string fname = IndeedDataFile + "bullhornError.txt";
                        string data1 = msg + "\n" + ex.Message + "\n" + ex.StackTrace + "\n" + ex.Response + "\n";
                        System.IO.File.WriteAllText(fname, data1);
                    }
#endif
                }
            }

            if (response == null) return null;

            System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());

            return sr.ReadToEnd().Trim();
        }

        public string HttpPostFile(string URI, Stream fileStream, string fileNameDisplay, string fileName, string contentType)
        {
            //always 0 the file stream first
            fileStream.Position = 0;

            System.Net.WebResponse response = null;

            try
            {
                string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
                byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

                string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
                string header = string.Format(headerTemplate, fileNameDisplay, fileName, contentType);
                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);

                byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");

                HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(URI);
                wr.ContentType = "multipart/form-data; boundary=" + boundary;
                wr.Method = "POST";
                wr.KeepAlive = true;
                //wr.ContentLength = fileStream.Length + headerbytes.Length + trailer.Length;
                wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

                Stream rs = wr.GetRequestStream();

                //string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
                //foreach (string key in nvc.Keys)
                //{
                //    rs.Write(boundarybytes, 0, boundarybytes.Length);
                //    string formitem = string.Format(formdataTemplate, key, nvc[key]);
                //    byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                //    rs.Write(formitembytes, 0, formitembytes.Length);
                //}
                rs.Write(boundarybytes, 0, boundarybytes.Length);

                rs.Write(headerbytes, 0, headerbytes.Length);

                //writes the file
                byte[] buffer = new byte[4096];
                int bytesRead = 0;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    rs.Write(buffer, 0, bytesRead);
                }

                rs.Write(trailer, 0, trailer.Length);
                rs.Close();
                rs = null;

                response = wr.GetResponse();
            }
            catch (WebException ex)
            {
                string msg = "";

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    //throw ex;
                    response = ex.Response;
                    msg = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd().Trim();

#if RELEASE
                    // Test - TODO REMOVE HIMMY 
                    string IndeedDataFile = ConfigurationManager.AppSettings["301RedirectUrlFolder"];

                    if (!string.IsNullOrEmpty(IndeedDataFile))
                    {
                        string fname = IndeedDataFile + "bullhornError.txt";
                        string data1 = msg + "\n" + ex.Message + "\n" + ex.StackTrace + "\n" + ex.Response + "\n";
                        System.IO.File.WriteAllText(fname, data1);
                    }
#endif
                }
            }

            if (response == null) return null;

            System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());

            return sr.ReadToEnd().Trim();
        }

        public string HttpPutFile(string URI, Stream fileStream, string fileNameDisplay, string fileName, string contentType)
        {
            System.Net.WebResponse response = null;

            try
            {
                string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
                byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

                string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
                string header = string.Format(headerTemplate, fileNameDisplay, fileName, contentType);
                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);

                byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");

                HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(URI);
                wr.ContentType = "multipart/form-data; boundary=" + boundary;
                wr.Method = "PUT";
                wr.KeepAlive = true;
                //wr.ContentLength = fileStream.Length + headerbytes.Length + trailer.Length;
                wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

                Stream rs = wr.GetRequestStream();

                //string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
                //foreach (string key in nvc.Keys)
                //{
                //    rs.Write(boundarybytes, 0, boundarybytes.Length);
                //    string formitem = string.Format(formdataTemplate, key, nvc[key]);
                //    byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                //    rs.Write(formitembytes, 0, formitembytes.Length);
                //}
                rs.Write(boundarybytes, 0, boundarybytes.Length);

                rs.Write(headerbytes, 0, headerbytes.Length);

                //writes the file
                byte[] buffer = new byte[4096];
                int bytesRead = 0;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    rs.Write(buffer, 0, bytesRead);
                }

                rs.Write(trailer, 0, trailer.Length);
                rs.Close();
                rs = null;

                response = wr.GetResponse();
            }
            catch (WebException ex)
            {
                string msg = "";

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    //throw ex;
                    response = ex.Response;
                    msg = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd().Trim();

                    // Test - TODO REMOVE HIMMY 
                    string IndeedDataFile = ConfigurationManager.AppSettings["301RedirectUrlFolder"];

                    if (!string.IsNullOrEmpty(IndeedDataFile))
                    {
                        string fname = IndeedDataFile + "bullhornError.txt";
                        string data1 = msg + "\n" + ex.Message + "\n" + ex.StackTrace + "\n" + ex.Response + "\n";
                        System.IO.File.WriteAllText(fname, data1);
                    }

                }
            }

            if (response == null) return null;

            System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());

            return sr.ReadToEnd().Trim();
        }

        private string HttpGet(string URI)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);

            req.Method = "GET";

            //req.Headers.Add("Authorization: OAuth " + HttpUtility.UrlEncode(_AuthorizeToken.access_token));

            System.Net.WebResponse response = null;
            try
            {
                response = req.GetResponse();
            }
            catch (WebException ex)
            {
                string msg = "";

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    //throw ex;
                    response = ex.Response;
                    msg = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd().Trim();
                }
                response.Close();
                return msg;
            }

            if (response == null)
            {
                response.Close();
                return null;
            }

            System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());

            return sr.ReadToEnd().Trim();
        }

        public string HttpPostXMLData(string destinationUrl, string requestXml)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(destinationUrl);
            byte[] bytes;
            bytes = System.Text.Encoding.ASCII.GetBytes(requestXml);
            request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentLength = bytes.Length;
            request.Method = "POST";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                string responseStr = new StreamReader(responseStream).ReadToEnd();
                return responseStr;
            }
            return null;
        }

        #endregion

        #region Sync Candidate

        public bool BHCloseCandidate(int memberID, out string errorMsg)
        {
            errorMsg = string.Empty;

            if (BullhornSettings != null && BullhornSettings.Valid)
            {
                // Get the member
                MembersService MembersService = new JXTPortal.MembersService();
                Entities.Members member = MembersService.GetByMemberId(memberID);

                if (member != null && !string.IsNullOrWhiteSpace(member.ExternalMemberId))
                {
                    bool blnSuccess = true;
                    BullhornRESTAPI.BHRestToken RESTToken = null;

                    blnSuccess = BullhornRestTokenGet(member.SiteId, out RESTToken, out errorMsg);

                    if (blnSuccess)
                    {
                        // Convert the object to JSON 
                        JavaScriptSerializer ser = new JavaScriptSerializer();
                        Dictionary<string, string> candidateDelete = new Dictionary<string, string>();
                        candidateDelete.Add("isDeleted", "true");

                        string thisJson = ser.Serialize(candidateDelete);

                        string strResponse = HttpPost(RESTToken.restUrl + "entity/Candidate/" + member.ExternalMemberId + "?BhRestToken=" + RESTToken.BhRestToken, thisJson);

                        return true;
                    }
                }
            }

            return false;
        }

        public bool SyncCandidate(Entities.Members member, out string errorMsg)
        {
            return SyncCandidate(member, null, null, null, null, out errorMsg);
        }

        public bool SyncCandidate(Entities.Members member, byte[] toBeParsedResume, string toBeParsedResumeName, byte[] toBeUploadedCover, string toBeUploadedCoverName, out string errorMsg)
        {
            errorMsg = string.Empty;

            List<BullhornRESTModels.OperationStack> stacks = new List<BullhornRESTModels.OperationStack>();

            // Only if Bullhorn is enabled on the site and Candidate Sync is enabled.
            if (BullhornSettings != null && BullhornSettings.Valid && BullhornSettings.EnableCandidateSync)
            {
                BullhornRESTAPI.BHRestToken RESTToken = null;

                try
                {
                    bool blnSuccess = BullhornRestTokenGet(member.SiteId, out RESTToken, out errorMsg);
                    stacks.Add(new BullhornRESTModels.OperationStack("Authentication", "Token - " + ((RESTToken != null) ? RESTToken.BhRestToken : string.Empty), errorMsg));

                    if (blnSuccess)
                    {
                        JavaScriptSerializer ser = new JavaScriptSerializer();
                        string strResponse = string.Empty;
                        string serializedObject = string.Empty;
                        MembersService MembersService = new MembersService();
                        BullhornCandidate bullhorncandidate = new BullhornCandidate();

                        // Get the candidate from Bullhorn
                        if (!string.IsNullOrWhiteSpace(member.ExternalMemberId))
                        {
                            string getRequestURL = RESTToken.restUrl + "entity/Candidate/" + member.ExternalMemberId + "?fields=id,firstName,lastName,email,username&BhRestToken=" + RESTToken.BhRestToken;
                            stacks.Add(new BullhornRESTModels.OperationStack("HttpGet - " + getRequestURL, "PRE", null));
                            strResponse = HttpGet(getRequestURL);
                            stacks.Add(new BullhornRESTModels.OperationStack("HttpGet - " + getRequestURL, "CALLED", strResponse));

                            if (!string.IsNullOrWhiteSpace(strResponse))
                            {
                                // If found in Bullhorn update on JXT
                                BullhornDataCandidate bullhornDataCandidate = ser.Deserialize<BullhornDataCandidate>(strResponse);

                                if (bullhornDataCandidate != null && bullhornDataCandidate.data != null)
                                {
                                    bullhorncandidate = bullhornDataCandidate.data;
                                }
                            }
                        }
                        else
                        {
                            string getRequestURL = RESTToken.restUrl + "search/Candidate?count=1&query=isDeleted:0 AND email:\"" + member.EmailAddress + "\"&fields=id,firstName,lastName,email,username&BhRestToken=" + RESTToken.BhRestToken;
                            stacks.Add(new BullhornRESTModels.OperationStack("HttpGet - " + getRequestURL, "PRE", null));
                            strResponse = HttpGet(getRequestURL);
                            stacks.Add(new BullhornRESTModels.OperationStack("HttpGet - " + getRequestURL, "CALLED", strResponse));

                            if (!string.IsNullOrWhiteSpace(strResponse))
                            {
                                // If found in Bullhorn update on JXT
                                BullhornGetCandidate bullhornGetCandidateResponse = ser.Deserialize<BullhornGetCandidate>(strResponse);

                                if (bullhornGetCandidateResponse != null && bullhornGetCandidateResponse.data != null && bullhornGetCandidateResponse.data.Count > 0)
                                {
                                    bullhorncandidate = bullhornGetCandidateResponse.data[0];
                                }
                            }
                        }

                        // If the candidate is found in Bullhorn
                        if (bullhorncandidate != null && !string.IsNullOrWhiteSpace(bullhorncandidate.id))
                        {
                            // If found in Bullhorn update on JXT
                            member.FirstName = bullhorncandidate.firstName;
                            member.Surname = bullhorncandidate.lastName;
                            //member.Username = bullhorncandidate.username;         // Because Bullhorn is not unique and it throws exceptions
                            //member.Password = string.Empty;
                            //member.EmailAddress = bullhorncandidate.email;
                            member.ExternalMemberId = bullhorncandidate.id;         // Because Bullhorn is not unique and it throws exceptions

                            MembersService.Update(member);

                            return true;
                        }

                        // Create New candidate in Bullhorn
                        if (toBeParsedResume != null)
                        {
                            try
                            {
                                stacks.Add(new BullhornRESTModels.OperationStack("BHCandidateToParse", "INIT", null));
                                bool parseCandidateResult = false;
                                #region Parse Candidate Resume and Create BH Candidate
                                MemberFilesService memberFileService = new MemberFilesService();

                                Stream thisResumeStream = new MemoryStream(toBeParsedResume);
                                string thisResumeName = toBeParsedResumeName;

                                if (thisResumeStream != null && thisResumeStream.Length > 0)
                                {
                                    stacks.Add(new BullhornRESTModels.OperationStack("BHCandidateToParse - " + thisResumeName, "PRE", null));
                                    BullhornRESTModels.ParseToCandidateResult parsedProfile = BHCandidateToParse(thisResumeStream, thisResumeName, RESTToken);
                                    stacks.Add(new BullhornRESTModels.OperationStack("BHCandidateToParse - " + thisResumeName, "CALLED", parsedProfile.candidate != null ? parsedProfile.candidate.id : "null candidate object"));

                                    //before create, we assign back the inputs we took from the form for this member
                                    parsedProfile.candidate.firstName = member.FirstName;
                                    parsedProfile.candidate.lastName = member.Surname;
                                    parsedProfile.candidate.username = member.Username;
                                    parsedProfile.candidate.password = string.Empty;
                                    parsedProfile.candidate.email = member.EmailAddress;
                                    //candidate.name is auto get using first name last name in model declaration
                                    //parsedProfile.candidate.name = member.FirstName + " " + member.Surname;

                                    //Send parsed data to BH
                                    stacks.Add(new BullhornRESTModels.OperationStack("ProcessParsedCandidateProfile - " + parsedProfile.candidate.id, "PRE", null));
                                    BullhornRESTModels.PutResponse createParsedDataResponse = ProcessParsedCandidateProfile(parsedProfile, RESTToken);
                                    stacks.Add(new BullhornRESTModels.OperationStack("ProcessParsedCandidateProfile - " + parsedProfile.candidate.id, "CALLED", createParsedDataResponse.changedEntityId + " - " + createParsedDataResponse.changeType));

                                    if (createParsedDataResponse.changeType == "INSERT")
                                    {
                                        //update JXT record with BH memberID
                                        member.ExternalMemberId = createParsedDataResponse.changedEntityId.ToString();
                                        MembersService.Update(member);

                                        //Upload the Resume file
                                        stacks.Add(new BullhornRESTModels.OperationStack("BHCandidateFileAttach - Resume", "PRE", null));
                                        BHCandidateFileAttach(createParsedDataResponse.changedEntityId, member.SiteId, RESTToken, thisResumeStream, thisResumeName);
                                        stacks.Add(new BullhornRESTModels.OperationStack("BHCandidateFileAttach - Resume", "CALLED", null));

                                        //Upload the Cover letter
                                        if (toBeUploadedCover != null && toBeUploadedCover.Length > 0)
                                        {
                                            Stream thisCoverStream = new MemoryStream(toBeUploadedCover);
                                            string thisCoverName = toBeUploadedCoverName;

                                            stacks.Add(new BullhornRESTModels.OperationStack("BHCandidateFileAttach - Cover Letter", "PRE", null));
                                            BHCandidateFileAttach(createParsedDataResponse.changedEntityId, member.SiteId, RESTToken, thisCoverStream, thisCoverName);
                                            stacks.Add(new BullhornRESTModels.OperationStack("BHCandidateFileAttach - Cover Letter", "CALLED", null));
                                        }

                                        parseCandidateResult = true;
                                    }
                                    parseCandidateResult = false;
                                }
                                #endregion
                                stacks.Add(new BullhornRESTModels.OperationStack("BHCandidateToParse", "COMPLETED", parseCandidateResult.ToString()));
                                return parseCandidateResult;

                            }
                            catch (Exception ex)
                            {
                                //log exception
                                string message = String.Join("<br/>", stacks.Select(c => c.Operation + " => " + c.Status + (!string.IsNullOrEmpty(c.Data) ? "<br/>&nbsp;&nbsp;&nbsp;&nbsp;" + c.Data : string.Empty)).ToList());
                                _logger.Error(message, ex);
                                
                                //let it go through to the Simple creation instead of parsing the Resume section
                            }
                        }

                        stacks.Add(new BullhornRESTModels.OperationStack("BHCandidateCreate (SIMPLE)", "INIT", null));
                        #region Simple creation instead of parsing the Resume

                        bullhorncandidate = new BullhornCandidate();
                        bullhorncandidate.firstName = member.FirstName;
                        bullhorncandidate.lastName = member.Surname;
                        bullhorncandidate.username = member.Username;
                        bullhorncandidate.password = string.Empty;
                        bullhorncandidate.email = member.EmailAddress;
                        bullhorncandidate.name = member.FirstName + " " + member.Surname;

                        // HARDCODED
                        bullhorncandidate.category = new category(); bullhorncandidate.category.id = 45;
                        bullhorncandidate.address = new address(); bullhorncandidate.address.countryID = 2194;
                        bullhorncandidate.status = "New Lead";

                        //var jsonObj = new { isPublic = isExpired ? 0 : 1 };

                        // Convert the object to JSON 
                        serializedObject = ser.Serialize(bullhorncandidate);

                        stacks.Add(new BullhornRESTModels.OperationStack("BHCandidateCreate (SIMPLE) - HTTPPUT", "PRE", null));
                        strResponse = HttpPut(RESTToken.restUrl + "entity/Candidate" + "?BhRestToken=" + RESTToken.BhRestToken, serializedObject);
                        stacks.Add(new BullhornRESTModels.OperationStack("BHCandidateCreate (SIMPLE) - HTTPPUT - " + RESTToken.BhRestToken, "CALLED", strResponse));

                        if (!string.IsNullOrWhiteSpace(strResponse))
                        {
                            BullhornCandidateResponse bullhornCandidateResponse = ser.Deserialize<BullhornCandidateResponse>(strResponse);

                            if (bullhornCandidateResponse.messages == null)
                            {
                                member.ExternalMemberId = bullhornCandidateResponse.changedEntityId.ToString();

                                MembersService.Update(member);

                                if (toBeParsedResume != null && toBeParsedResume.Length > 0)
                                {
                                    //Upload the Resume file
                                    Stream thisResumeStream = new MemoryStream(toBeParsedResume);
                                    string thisResumeName = toBeParsedResumeName;

                                    stacks.Add(new BullhornRESTModels.OperationStack("BHCandidateFileAttach - Resume", "PRE", null));
                                    BHCandidateFileAttach(bullhornCandidateResponse.changedEntityId, member.SiteId, RESTToken, thisResumeStream, thisResumeName);
                                    stacks.Add(new BullhornRESTModels.OperationStack("BHCandidateFileAttach - Resume", "CALLED", null));
                                }

                                //Upload the Cover letter
                                if (toBeUploadedCover != null && toBeUploadedCover.Length > 0)
                                {
                                    Stream thisCoverStream = new MemoryStream(toBeUploadedCover);
                                    string thisCoverName = toBeUploadedCoverName;

                                    stacks.Add(new BullhornRESTModels.OperationStack("BHCandidateFileAttach - Cover Letter", "PRE", null));
                                    BHCandidateFileAttach(bullhornCandidateResponse.changedEntityId, member.SiteId, RESTToken, thisCoverStream, thisCoverName);
                                    stacks.Add(new BullhornRESTModels.OperationStack("BHCandidateFileAttach - Cover Letter", "CALLED", null));
                                }
                                return true;
                            }
                        }
                        #endregion
                        stacks.Add(new BullhornRESTModels.OperationStack("BHCandidateCreate (SIMPLE)", "COMPLETED", null));

                    }
                    else
                    {
                        stacks.Add(new BullhornRESTModels.OperationStack("Authentication", "Token failed", string.Empty));
                    }
                }
                catch (Exception ex)
                {
                   string message = String.Join("<br/>", stacks.Select(c => c.Operation + " => " + c.Status + (!string.IsNullOrEmpty(c.Data) ? "<br/>&nbsp;&nbsp;&nbsp;&nbsp;" + c.Data : string.Empty)).ToList());
                   _logger.Error(message, ex);

                    throw new Exception("Failed to create candidate via Bullhorn API - EntityID: " + member.EntityId);
                }
                if (stacks != null && stacks.Count > 0)
                {
                    //TODO: log exception
                    string message = String.Join("<br/>", stacks.Select(c => c.Operation + " => " + c.Status + (!string.IsNullOrEmpty(c.Data) ? "<br/>&nbsp;&nbsp;&nbsp;&nbsp;" + c.Data : string.Empty)).ToList());
                    _logger.Error(message);
                }

            }

            return false;
        }

        public BullhornRESTModels.PutResponse ProcessParsedCandidateProfile(BullhornRESTModels.ParseToCandidateResult parsedProfile, BullhornRESTAPI.BHRestToken RESTToken)
        {
            List<BullhornRESTModels.OperationStack> stacks = new List<BullhornRESTModels.OperationStack>();

            try
            {
                stacks.Add(new BullhornRESTModels.OperationStack("BHCandidateCreate - Token - " + RESTToken.BhRestToken, "PRE", null));
                BullhornRESTModels.PutResponse createCandidateResponse = BHCandidateCreate(parsedProfile.candidate, RESTToken);
                stacks.Add(new BullhornRESTModels.OperationStack("BHCandidateCreate - Token - " + RESTToken.BhRestToken, "CALLED", createCandidateResponse.changedEntityId + " " + createCandidateResponse.changeType));

                //TODO ERROR Handling
                if (createCandidateResponse != null && createCandidateResponse.changeType == "INSERT")
                {
                    //Educations
                    if (parsedProfile.candidateEducation != null && parsedProfile.candidateEducation.Count() > 0)
                    {
                        stacks.Add(new BullhornRESTModels.OperationStack("BHEducationsCreate", "PRE", null));
                        List<BullhornRESTModels.PutResponse> createEducationsResponse = BHEducationsCreate(createCandidateResponse.changedEntityId, parsedProfile.candidateEducation, RESTToken);
                        stacks.Add(new BullhornRESTModels.OperationStack("BHEducationsCreate", "CALLED", String.Join("<br/>", createEducationsResponse.Select(c => c.changedEntityId + " - " + c.changeType))));
                    }

                    //Work History
                    if (parsedProfile.candidateWorkHistory != null && parsedProfile.candidateWorkHistory.Count() > 0)
                    {
                        stacks.Add(new BullhornRESTModels.OperationStack("BHWorkHistoryCreate", "PRE", null));
                        List<BullhornRESTModels.PutResponse> createWorkHistorysResponse = BHWorkHistoryCreate(createCandidateResponse.changedEntityId, parsedProfile.candidateWorkHistory, RESTToken);
                        stacks.Add(new BullhornRESTModels.OperationStack("BHWorkHistoryCreate", "CALLED", String.Join("<br/>", createWorkHistorysResponse.Select(c => c.changedEntityId + " - " + c.changeType))));
                    }

                    //Set SkillSet
                    if (parsedProfile.skillList != null && parsedProfile.skillList.Count() > 0)
                    {
                        stacks.Add(new BullhornRESTModels.OperationStack("BHCandidateSkillSetUpdate", "PRE", null));
                        BullhornRESTModels.PostResponse linkSkillsResponse = BHCandidateSkillSetUpdate(createCandidateResponse.changedEntityId, parsedProfile.skillList, RESTToken);
                        stacks.Add(new BullhornRESTModels.OperationStack("BHCandidateSkillSetUpdate", "CALLED", linkSkillsResponse.changedEntityId + " - " + linkSkillsResponse.changeType));
                    }

                    return createCandidateResponse;
                }

                throw new Exception("Failed to create candidate, please check additional stack trace for more details");
            }
            catch (Exception ex)
            {
                //log exception
                string message = String.Join("<br/>", stacks.Select(c => c.Operation + " => " + c.Status + (!string.IsNullOrEmpty(c.Data) ? "<br/>&nbsp;&nbsp;&nbsp;&nbsp;" + c.Data : string.Empty)).ToList());
                _logger.Error(message, ex);

                throw new Exception("Failed to process candidate file via Bullhorn API - candidateId: " + parsedProfile.candidate.id);
            }
        }

        #endregion

        #region OnBoarding SSO

        public bool GetOnBoardingSSO(Entities.Members member, out string strUrl)
        {
            strUrl = string.Empty;

            if (integrations != null && integrations.BullhornOnBoardingSSO != null && integrations.BullhornOnBoardingSSO.Valid && !string.IsNullOrWhiteSpace(member.ExternalMemberId))
            {
                // Post XML data
                string strResponse = HttpPostXMLData(integrations.BullhornOnBoardingSSO.OnBoardingAPIURL,
                                                        string.Format(@"apiKey={0}&xml=<?xml version='1.0' encoding='UTF-8'?><root><username></username><integrationID>{1}</integrationID><role>employee</role><keyType>PERMANENT</keyType></root>", integrations.BullhornOnBoardingSSO.APIIntegrationKey, member.ExternalMemberId));

                try
                {
                    var serializer = new XmlSerializer(typeof(BullhornOnBoardingSSO));
                    using (var reader = new StringReader(strResponse))
                    {
                        BullhornOnBoardingSSO bullhornOnBoardingSSO = (BullhornOnBoardingSSO)serializer.Deserialize(reader);

                        //Success - <root><authenticationKey>ad3ef513ec70d3c2d391486cca7ec392</authenticationKey><googleAnalyticsPage>/api/SingleSignon</googleAnalyticsPage><errorStatus>okay</errorStatus></root>
                        //Failed - <root><googleAnalyticsPage>/api/SingleSignon</googleAnalyticsPage><errorStatus>error</errorStatus><errorMessage>Invalid User: could not find the specified integration id</errorMessage></root>
                        //Failed - <root><googleAnalyticsPage>/api/SingleSignon</googleAnalyticsPage><errorStatus>error</errorStatus><errorMessage>No Current Assignments</errorMessage></root>

                        if (bullhornOnBoardingSSO != null && !string.IsNullOrWhiteSpace(bullhornOnBoardingSSO.AuthenticationKey))
                        {
                            //example https://jobwire.bbo.bullhornstaffing.com/employee/?authenticationKey=04bd9625a1c0a297ec116bf9c2aadc83
                            strUrl = string.Format("{0}?authenticationKey={1}", integrations.BullhornOnBoardingSSO.OnBoardingRedirectURL, bullhornOnBoardingSSO.AuthenticationKey);

                            return true;
                        }
                    }

                }
                catch (Exception ex)
                {

                } // Could not be deserialized to this type.

            }



            return false;
        }


        #endregion

        #region Custom Classes

        public class AuthorizeToken
        {
            public string id { get; set; }
            public string issued_at { get; set; }
            public string refresh_token { get; set; }
            public string instance_url { get; set; }
            public string signature { get; set; }
            public string access_token { get; set; }
        }

        public class BHRestToken
        {
            public string BhRestToken { get; set; }
            public string restUrl { get; set; }
            public string errorMessage { get; set; }
        }

        public class BHJobOrderRecordBase
        {
            public BHJobOrderRecord data { get; set; }
        }

        public class BHJobOrderRecord
        {
            [ScriptIgnore]
            public int JobOrderID { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public int isPublic { get; set; }
            [ScriptIgnore]
            public bool IsPublic_Boolean { get { return isPublic == 1; } }
        }

        #endregion

        #region Candidate Custom Classes

        public class BullhornCandidate
        {
            public string id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            //public userType userType { get; set; }

            public category category { get; set; }
            public address address { get; set; }
            public string status { get; set; }

        }

        public class address
        {
            public int countryID { get; set; }

        }
        public class category
        {
            public int id { get; set; }

        }
        public class userType
        {
            public string id { get; set; }

        }

        public class BullhornDataCandidate
        {
            public BullhornCandidate data { get; set; }

        }
        public class BullhornGetCandidate
        {
            public List<BullhornCandidate> data { get; set; }

        }

        public class BullhornObject
        {
            public Dictionary<string, object> data { get; set; }

        }

        public class BullhornCandidateResponse
        {
            public string changedEntityType { get; set; }
            public int changedEntityId { get; set; }
            public string changeType { get; set; }
            public List<Message> messages { get; set; }
        }

        public class Message
        {
            public string detailMessage { get; set; }
            public string propertyName { get; set; }
            public int entityId { get; set; }
            public string severity { get; set; }
            public string type { get; set; }
        }

        [XmlRoot(ElementName = "root")]
        public class BullhornOnBoardingSSO
        {
            [XmlElement(ElementName = "authenticationKey")]
            public string AuthenticationKey { get; set; }
            [XmlElement(ElementName = "googleAnalyticsPage")]
            public string GoogleAnalyticsPage { get; set; }
            [XmlElement(ElementName = "errorStatus")]
            public string ErrorStatus { get; set; }
        }
        #endregion

        #region Meta

        /// <summary>
        /// Gets the meta for a specific Entity 
        /// </summary>
        /// <param name="siteID"></param>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public string BullhornMeta(int siteID, string entityName, List<string> fieldNames)
        {
            string errorMsg = string.Empty;

            BullhornRESTAPI.BHRestToken RESTToken = null;

            try
            {
                RESTToken = AutoRetrieveRESTToken(siteID, RESTToken);

                JavaScriptSerializer ser = new JavaScriptSerializer();
                string strResponse = string.Empty;
                string serializedObject = string.Empty;
                MembersService MembersService = new MembersService();
                BullhornCandidate bullhorncandidate = new BullhornCandidate();

                strResponse = HttpGet(RESTToken.restUrl + "meta/" + entityName + "?fields=" + String.Join(",", fieldNames) + "&meta=full&BhRestToken=" + RESTToken.BhRestToken);
                //https://rest32.bullhornstaffing.com/rest-services/1bnq21/meta/Candidate?fields=*&BhRestToken=f6e451db-aa1f-4cbe-95d1-f3afb1d0e484

                return strResponse;
            }
            catch (Exception ex)
            {
                //TODO: log exception
                _logger.Error(ex);

                throw new Exception("Failed to retreive meta data via Bullhorn API - Site ID: " + siteID);
            }
        }

        #endregion

        #region Advertiser / Advertiser User

        public bool SyncAdvertiserAndUser(int siteId, Entities.Advertisers advertiser, Entities.AdvertiserUsers advertiserUser, bool blnPushToBullhorn, out string errorMsg)
        {
            errorMsg = string.Empty;
            bool blnNewAdvertiser = true;

            List<BullhornRESTModels.OperationStack> stacks = new List<BullhornRESTModels.OperationStack>();

            try
            {
                bool blnSuccess = true;

                if (_BHRestToken == null)
                    blnSuccess = BullhornRestTokenGet(siteId, out _BHRestToken, out errorMsg);

                stacks.Add(new BullhornRESTModels.OperationStack("Authentication", "Token - " + ((_BHRestToken != null) ? _BHRestToken.BhRestToken : string.Empty), errorMsg));

                if (blnSuccess)
                {
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    string strResponse = string.Empty;
                    string serializedObject = string.Empty;
                    AdvertisersService AdvertisersService = new AdvertisersService();
                    BullhornObject bullhornAdvertiserData = null;

                    var BullhornAdvertiserObject = new Dictionary<string, object>();
                    var BullhornAdvertiserChildObject = new Dictionary<string, object>();

                    // Get the advertiser from Bullhorn
                    bool BHHasAdvertiserRecord = false;
                    if (advertiser != null && !string.IsNullOrWhiteSpace(advertiser.ExternalAdvertiserId))
                    {
                        string getRequestURL = _BHRestToken.restUrl + "entity/ClientCorporation/" + advertiser.ExternalAdvertiserId + "?fields=*&BhRestToken=" + _BHRestToken.BhRestToken;
                        stacks.Add(new BullhornRESTModels.OperationStack("HttpGet - " + getRequestURL, "PRE", null));
                        strResponse = HttpGet(getRequestURL);
                        stacks.Add(new BullhornRESTModels.OperationStack("HttpGet - " + getRequestURL, "CALLED", strResponse));

                        if (!string.IsNullOrWhiteSpace(strResponse))
                        {
                            // If found in Bullhorn update on JXT
                            /*BullhornDataCandidate bullhornDataCandidate = ser.Deserialize<BullhornDataCandidate>(strResponse);

                            if (bullhornDataCandidate != null && bullhornDataCandidate.data != null)
                            {
                                bullhorncandidate = bullhornDataCandidate.data;
                            }*/

                            bullhornAdvertiserData = ser.Deserialize<BullhornObject>(strResponse);

                            if (bullhornAdvertiserData != null && bullhornAdvertiserData.data != null)
                            {
                                BHHasAdvertiserRecord = true;

                                if (!blnPushToBullhorn)
                                    BullhornAdvertiserObject = bullhornAdvertiserData.data;                                
                            }
                        }
                    }

                    string strBHMetaThirdPartyColumnObject = string.Empty;
                    string strBHMetaThirdPartyColumnChildName = string.Empty;

                    stacks.Add(new BullhornRESTModels.OperationStack("Application - Site Mappings", "PRE", strResponse));
                    IntegrationMappingsService IntegrationMappingsService = new JXTPortal.IntegrationMappingsService();
                    using (TList<IntegrationMappings> sitemappings = IntegrationMappingsService.GetValidBySiteId(siteId, null))
                    {
                        // ADVERTISER 
                        if (sitemappings.Where(s => s.IntegrationMappingTypeId == (int)PortalEnums.Admin.IntegrationMappingType.BH_Mapping_Advertiser) != null)
                        {
                            Type type = advertiser.GetType();
                            System.Reflection.PropertyInfo JXTColumnPropertyInfo = null;

                            // If the advertiser is found in Bullhorn then update in JXT
                            if (BHHasAdvertiserRecord)
                            {
                                stacks.Add(new BullhornRESTModels.OperationStack("Application - Site Mappings", "Advertiser Data Found on BH", null));

                                if (sitemappings.Where(s => s.IntegrationMappingTypeId == (int)PortalEnums.Admin.IntegrationMappingType.BH_Mapping_Advertiser).FirstOrDefault() != null)
                                {
                                    foreach (IntegrationMappings sitemapping in sitemappings.Where(s => s.IntegrationMappingTypeId == (int)PortalEnums.Admin.IntegrationMappingType.BH_Mapping_Advertiser))
                                    {
                                        strBHMetaThirdPartyColumnObject = string.Empty;
                                        strBHMetaThirdPartyColumnChildName = string.Empty;
                                        BullhornAdvertiserChildObject = new Dictionary<string, object>();

                                        stacks.Add(new BullhornRESTModels.OperationStack("Application - Site Mappings", "Processing " + sitemapping.JxtColumn + "/" + sitemapping.ThirdPartyColumn, null));
                                        if (!string.IsNullOrWhiteSpace(sitemapping.ThirdPartyColumn))
                                        {
                                            //column contains 2 levels
                                            //example: address - address 1
                                            if (sitemapping.ThirdPartyColumn.Contains(" - "))
                                            {
                                                #region 2 Levels Processing
                                                JXTColumnPropertyInfo = type.GetProperty(sitemapping.JxtColumn);
                                                strBHMetaThirdPartyColumnObject = sitemapping.ThirdPartyColumn.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries).First();
                                                strBHMetaThirdPartyColumnChildName = sitemapping.ThirdPartyColumn.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries).Last();
                                                if (!string.IsNullOrWhiteSpace(strBHMetaThirdPartyColumnObject) && !string.IsNullOrWhiteSpace(strBHMetaThirdPartyColumnChildName)
                                                    /*&& ((System.Collections.Generic.Dictionary<string, object>)
                                                                                (BullhornAdvertiserObject[strBHMetaThirdPartyColumnObject])).ContainsKey(strBHMetaThirdPartyColumnChildName)*/)
                                                {
                                                    if (blnPushToBullhorn)
                                                    {
                                                        BullhornAdvertiserChildObject.Add(strBHMetaThirdPartyColumnChildName, JXTColumnPropertyInfo.GetValue(advertiser, null));
                                                        if (BullhornAdvertiserObject.ContainsKey(strBHMetaThirdPartyColumnObject))
                                                        {
                                                            ((System.Collections.Generic.Dictionary<string, object>)(BullhornAdvertiserObject[strBHMetaThirdPartyColumnObject]))
                                                                        [strBHMetaThirdPartyColumnChildName] = JXTColumnPropertyInfo.GetValue(advertiser, null);
                                                        }
                                                        else
                                                            BullhornAdvertiserObject.Add(strBHMetaThirdPartyColumnObject, BullhornAdvertiserChildObject);
                                                    }
                                                    else
                                                    {
                                                        Dictionary<string,object> thisBHAdvertiserObject = BullhornAdvertiserObject[strBHMetaThirdPartyColumnObject] as Dictionary<string, object>;
                                                        if( thisBHAdvertiserObject != null )
                                                        {
                                                            JXTColumnPropertyInfo.SetValue(advertiser, thisBHAdvertiserObject[strBHMetaThirdPartyColumnChildName],
                                                                            null);
                                                        }
                                                    }
                                                }
                                                #endregion
                                            }
                                            else //single levels
                                            {
                                                ProcessSingleLevelAdvertiserMappings(siteId, sitemapping.JxtColumn, sitemapping.ThirdPartyColumn, blnPushToBullhorn, advertiser, BullhornAdvertiserObject);
                                            }
                                        }
                                    }

                                    if (blnPushToBullhorn)
                                    {
                                        // Serialize adveritser and save in BH
                                        serializedObject = ser.Serialize(BullhornAdvertiserObject);
                                        string postRequestURL = _BHRestToken.restUrl + "entity/ClientCorporation/" + advertiser.ExternalAdvertiserId + "?BhRestToken=" + _BHRestToken.BhRestToken;
                                        stacks.Add(new BullhornRESTModels.OperationStack("HttpPost - " + postRequestURL, "PRE", serializedObject));
                                        strResponse = HttpPost(postRequestURL, serializedObject);
                                        stacks.Add(new BullhornRESTModels.OperationStack("HttpPost - " + postRequestURL, "CALLED", strResponse));

                                        if (!string.IsNullOrWhiteSpace(strResponse))
                                        {
                                            // TODO
                                        }
                                    }
                                    else
                                    {
                                        stacks.Add(new BullhornRESTModels.OperationStack("Application - Advertiser Update", "PRE", null));
                                        AdvertisersService.Update(advertiser);
                                        stacks.Add(new BullhornRESTModels.OperationStack("Application - Advertiser Update", "CALLED", null));
                                    }
                                }

                                blnNewAdvertiser = false;
                            }
                            else //Advertiser Data not found on BH
                            {
                                stacks.Add(new BullhornRESTModels.OperationStack("Application - Site Mappings", "Advertiser Data NOT Found on BH", null));

                                //If advertiser data not found on BH, we will have to create a record on BH, so if the command is PULL, it is still a PUSH now
                                blnPushToBullhorn = true;

                                // Create new Company in Bullhorn
                                foreach (IntegrationMappings sitemapping in sitemappings.Where(s => s.IntegrationMappingTypeId == (int)PortalEnums.Admin.IntegrationMappingType.BH_Mapping_Advertiser))
                                {
                                    stacks.Add(new BullhornRESTModels.OperationStack("Application - Site Mappings", "Processing " + sitemapping.JxtColumn + "/" + sitemapping.ThirdPartyColumn, null));
                                    BullhornAdvertiserChildObject = new Dictionary<string, object>();

                                    if (sitemapping.ThirdPartyColumn.Contains(" - "))
                                    {
                                        #region 2 Levels Processing
                                        JXTColumnPropertyInfo = type.GetProperty(sitemapping.JxtColumn);
                                        strBHMetaThirdPartyColumnObject = sitemapping.ThirdPartyColumn.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries).First();
                                        strBHMetaThirdPartyColumnChildName = sitemapping.ThirdPartyColumn.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries).Last();
                                        if (!string.IsNullOrWhiteSpace(strBHMetaThirdPartyColumnObject) && !string.IsNullOrWhiteSpace(strBHMetaThirdPartyColumnChildName))
                                        {
                                            BullhornAdvertiserChildObject.Add(strBHMetaThirdPartyColumnChildName, JXTColumnPropertyInfo.GetValue(advertiser, null));
                                            if (BullhornAdvertiserObject.ContainsKey(strBHMetaThirdPartyColumnObject))
                                            {
                                                ((System.Collections.Generic.Dictionary<string, object>)(BullhornAdvertiserObject[strBHMetaThirdPartyColumnObject]))
                                                            [strBHMetaThirdPartyColumnChildName] = JXTColumnPropertyInfo.GetValue(advertiser, null);
                                            }
                                            else
                                                BullhornAdvertiserObject.Add(strBHMetaThirdPartyColumnObject, BullhornAdvertiserChildObject);

                                            /*((System.Collections.Generic.Dictionary<string, object>)(BullhornAdvertiserObject[strBHMetaThirdPartyColumnObject]))
                                                                        [strBHMetaThirdPartyColumnChildName] = JXTColumnPropertyInfo.GetValue(advertiser, null);*/
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        ProcessSingleLevelAdvertiserMappings(siteId, sitemapping.JxtColumn, sitemapping.ThirdPartyColumn, blnPushToBullhorn, advertiser, BullhornAdvertiserObject);
                                    }
                                }

                                if (blnNewAdvertiser && BullhornAdvertiserObject != null && BullhornAdvertiserObject.Count > 0)
                                {
                                    // Serialize adveritser and save in BH
                                    serializedObject = ser.Serialize(BullhornAdvertiserObject);
                                    string putRequestURL = _BHRestToken.restUrl + "entity/ClientCorporation" + "?BhRestToken=" + _BHRestToken.BhRestToken;
                                    stacks.Add(new BullhornRESTModels.OperationStack("HttpPut - " + putRequestURL, "PRE", serializedObject));
                                    strResponse = HttpPut(_BHRestToken.restUrl + "entity/ClientCorporation" + "?BhRestToken=" + _BHRestToken.BhRestToken, serializedObject);
                                    stacks.Add(new BullhornRESTModels.OperationStack("HttpPut - " + putRequestURL, "CALLED", strResponse));

                                    if (!string.IsNullOrWhiteSpace(strResponse))
                                    {
                                        stacks.Add(new BullhornRESTModels.OperationStack("Application - Advertiser Update", "PRE", null));
                                        BullhornCandidateResponse bullhornCandidateResponse = ser.Deserialize<BullhornCandidateResponse>(strResponse);

                                        if (bullhornCandidateResponse.messages == null)
                                        {
                                            // Save the external advertiser ID from BH
                                            advertiser.ExternalAdvertiserId = bullhornCandidateResponse.changedEntityId.ToString();

                                            AdvertisersService.Update(advertiser);
                                        }
                                        stacks.Add(new BullhornRESTModels.OperationStack("Application - Advertiser Update", "CALLED", null));
                                    }
                                }

                            }
                        }
                        /*if (true)
                        {
                            BullhornChileAdvertiserObject["countryID"] = 2194;
                            BullhornAdvertiserObject["address"] = BullhornChileAdvertiserObject;
                        }*/
                    }

                    // Sync Advertiser User 
                    if (advertiserUser != null && advertiserUser.Validated != null && advertiserUser.Validated.Value && (PortalEnums.AdvertiserUser.AccountStatus) advertiserUser.AccountStatus == PortalEnums.AdvertiserUser.AccountStatus.Approved)
                    {
                        stacks.Add(new BullhornRESTModels.OperationStack("Application - SyncAdvertiserUser", "PRE", null));
                        SyncAdvertiserUser(siteId, advertiser, advertiserUser, blnPushToBullhorn, out errorMsg);
                        stacks.Add(new BullhornRESTModels.OperationStack("Application - SyncAdvertiserUser", "CALLED", null));
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                string message = String.Join("<br/>", stacks.Select(c => c.Operation + " => " + c.Status + (!string.IsNullOrEmpty(c.Data) ? "<br/>&nbsp;&nbsp;&nbsp;&nbsp;" + c.Data : string.Empty)).ToList());
                _logger.Error(message, ex);
                throw new Exception("Failed to sync advertiser via Bullhorn API - EntityID: " + advertiser.EntityId);
            }

            return false;
        }

        public bool SyncAdvertiserUser(int siteId, Entities.Advertisers advertiser, Entities.AdvertiserUsers advertiserUser, bool blnPushToBullhorn, out string errorMsg)
        {
            List<BullhornRESTModels.OperationStack> stacks = new List<BullhornRESTModels.OperationStack>();

            try
            {
                errorMsg = string.Empty;
                bool blnNewAdvertiserUser = true;

                if (!string.IsNullOrEmpty(advertiser.ExternalAdvertiserId))
                {
                    bool blnSuccess = true;

                    if (_BHRestToken == null)
                        blnSuccess = BullhornRestTokenGet(siteId, out _BHRestToken, out errorMsg);

                    stacks.Add(new BullhornRESTModels.OperationStack("Authentication", "Token - " + ((_BHRestToken != null) ? _BHRestToken.BhRestToken : string.Empty), errorMsg));

                    if (blnSuccess)
                    {
                        JavaScriptSerializer ser = new JavaScriptSerializer();
                        string strResponse = string.Empty;
                        string serializedObject = string.Empty;

                        AdvertiserUsersService AdvertiserUsersService = new AdvertiserUsersService();

                        BullhornObject bullhornAdvertiserUserData = null;

                        var BullhornAdvertiserUserObject = new Dictionary<string, object>();
                        var BullhornAdvertiserUserChildObject = new Dictionary<string, object>();

                        string strBHMetaThirdPartyColumnObject = string.Empty;
                        string strBHMetaThirdPartyColumnChildName = string.Empty;

                        // Get the advertiser user from Bullhorn
                        bool BHHasAdvertiserUserRecord = false;
                        if (advertiserUser != null && !string.IsNullOrWhiteSpace(advertiserUser.ExternalAdvertiserUserId))
                        {
                            string getRequestURL = _BHRestToken.restUrl + "entity/ClientContact/" + advertiserUser.ExternalAdvertiserUserId + "?fields=*&BhRestToken=" + _BHRestToken.BhRestToken;
                            stacks.Add(new BullhornRESTModels.OperationStack("HttpGet - " + getRequestURL, "PRE", null));
                            strResponse = HttpGet(getRequestURL);
                            stacks.Add(new BullhornRESTModels.OperationStack("HttpGet - " + getRequestURL, "CALLED", null));

                            if (!string.IsNullOrWhiteSpace(strResponse))
                            {
                                bullhornAdvertiserUserData = ser.Deserialize<BullhornObject>(strResponse);

                                if (bullhornAdvertiserUserData != null && bullhornAdvertiserUserData.data != null)
                                {
                                    BHHasAdvertiserUserRecord = true;

                                    if (!blnPushToBullhorn)
                                        BullhornAdvertiserUserObject = bullhornAdvertiserUserData.data;
                                }
                            }
                        }

                        IntegrationMappingsService IntegrationMappingsService = new JXTPortal.IntegrationMappingsService();
                        using (TList<IntegrationMappings> sitemappings = IntegrationMappingsService.GetValidBySiteId(siteId, null))
                        {
                            // ADVERTISER USER
                            if (advertiserUser != null && sitemappings.Where(s => s.IntegrationMappingTypeId == (int)PortalEnums.Admin.IntegrationMappingType.BH_Mapping_AdvertiserUser) != null)
                            {
                                Type type = advertiserUser.GetType();
                                System.Reflection.PropertyInfo propertyInfo = null;

                                // If the advertiser is found in Bullhorn then update in JXT
                                if (BHHasAdvertiserUserRecord)
                                {
                                    #region Advertiser User Sync
                                    stacks.Add(new BullhornRESTModels.OperationStack("Application - Site Mappings", "Advertiser User Data Found on BH", null));

                                    if (sitemappings.Where(s => s.IntegrationMappingTypeId == (int)PortalEnums.Admin.IntegrationMappingType.BH_Mapping_AdvertiserUser).FirstOrDefault() != null)
                                    {
                                        foreach (IntegrationMappings sitemapping in sitemappings.Where(s => s.IntegrationMappingTypeId == (int)PortalEnums.Admin.IntegrationMappingType.BH_Mapping_AdvertiserUser))
                                        {
                                            stacks.Add(new BullhornRESTModels.OperationStack("Application - Site Mappings", "Processing " + sitemapping.JxtColumn + "/" + sitemapping.ThirdPartyColumn, null));

                                            strBHMetaThirdPartyColumnObject = string.Empty;
                                            strBHMetaThirdPartyColumnChildName = string.Empty;
                                            BullhornAdvertiserUserChildObject = new Dictionary<string, object>();

                                            propertyInfo = type.GetProperty(sitemapping.JxtColumn);

                                            if (!string.IsNullOrWhiteSpace(sitemapping.ThirdPartyColumn))
                                            {

                                                if (sitemapping.ThirdPartyColumn.Contains(" - "))
                                                {
                                                    #region 2 Levels Processing
                                                    strBHMetaThirdPartyColumnObject = sitemapping.ThirdPartyColumn.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries).First();
                                                    strBHMetaThirdPartyColumnChildName = sitemapping.ThirdPartyColumn.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries).Last();
                                                    if (!string.IsNullOrWhiteSpace(strBHMetaThirdPartyColumnObject) && !string.IsNullOrWhiteSpace(strBHMetaThirdPartyColumnChildName))
                                                    {
                                                        /*if (((System.Collections.Generic.Dictionary<string, object>)
                                                                                    (BullhornAdvertiserUserObject[strBHMetaThirdPartyColumnObject])).ContainsKey(strBHMetaThirdPartyColumnChildName))*/
                                                        if (blnPushToBullhorn)
                                                        {
                                                            BullhornAdvertiserUserChildObject.Add(strBHMetaThirdPartyColumnChildName, propertyInfo.GetValue(advertiserUser, null));
                                                            if (BullhornAdvertiserUserObject.ContainsKey(strBHMetaThirdPartyColumnObject))
                                                            {
                                                                ((System.Collections.Generic.Dictionary<string, object>)(BullhornAdvertiserUserObject[strBHMetaThirdPartyColumnObject]))
                                                                            [strBHMetaThirdPartyColumnChildName] = propertyInfo.GetValue(advertiserUser, null);
                                                            }
                                                            else
                                                                BullhornAdvertiserUserObject.Add(strBHMetaThirdPartyColumnObject, BullhornAdvertiserUserChildObject);


                                                            /*((System.Collections.Generic.Dictionary<string, object>)
                                                                (BullhornAdvertiserUserObject[strBHMetaThirdPartyColumnObject])).Add(strBHMetaThirdPartyColumnChildName, propertyInfo.GetValue(advertiser, null));*/
                                                        }
                                                        else
                                                        {
                                                            Dictionary<string, object> thisBHAdvertiserUserObject = BullhornAdvertiserUserObject[strBHMetaThirdPartyColumnObject] as Dictionary<string, object>;
                                                            if (thisBHAdvertiserUserObject != null)
                                                            {
                                                                propertyInfo.SetValue(advertiserUser, thisBHAdvertiserUserObject[strBHMetaThirdPartyColumnChildName],
                                                                                null);
                                                            }
                                                        }
                                                    }
                                                    #endregion
                                                }
                                                else
                                                {

                                                    /*if (blnPushToBullhorn && 
                                                            (bullhornAdvertiserUserData != null && bullhornAdvertiserUserData.data != null && 
                                                                (bullhornAdvertiserUserData.data.ContainsKey(sitemapping.ThirdPartyColumn))))*/

                                                    //TODO: TEMP FIX
                                                    if (sitemapping.ThirdPartyColumn == "phone" || sitemapping.ThirdPartyColumn == "fax")
                                                    {
                                                        if (advertiserUser.Phone != null && advertiserUser.Phone.Length > 20)
                                                            advertiserUser.Phone = advertiserUser.Phone.Substring(0, 20);
                                                        if (advertiserUser.Fax != null && advertiserUser.Fax.Length > 20)
                                                            advertiserUser.Fax = advertiserUser.Fax.Substring(0, 20);
                                                    }

                                                    if (blnPushToBullhorn)
                                                    {
                                                        BullhornAdvertiserUserObject[sitemapping.ThirdPartyColumn] = propertyInfo.GetValue(advertiserUser, null);
                                                    }
                                                    else
                                                    {
                                                        propertyInfo.SetValue(advertiserUser, BullhornAdvertiserUserObject[sitemapping.ThirdPartyColumn], null);
                                                    }


                                                }
                                            }

                                        }
                                        if (blnPushToBullhorn)
                                        {
                                            bool hasAssignedBHNameMapping = sitemappings.Where(c => c.ThirdPartyColumn.ToLower() == "name" && c.IntegrationMappingTypeId == (int)PortalEnums.Admin.IntegrationMappingType.BH_Mapping_AdvertiserUser).Any();

                                            //assign the BH "name" as JXT "firstname" + JXT "lastname"  
                                            if (!hasAssignedBHNameMapping)
                                            {
                                                if (!BullhornAdvertiserUserObject.ContainsKey("name"))
                                                    BullhornAdvertiserUserObject.Add("name", (advertiserUser.FirstName != null ? advertiserUser.FirstName + " " : "") + (advertiserUser.Surname != null ? advertiserUser.Surname : ""));
                                                else
                                                    BullhornAdvertiserUserObject["name"] = (advertiserUser.FirstName != null ? advertiserUser.FirstName + " " : "") + (advertiserUser.Surname != null ? advertiserUser.Surname : "");
                                            }

                                            // Serialize adveritser and save in BH
                                            serializedObject = ser.Serialize(BullhornAdvertiserUserObject);
                                            string postRequestURL = _BHRestToken.restUrl + "entity/ClientContact/" + advertiserUser.ExternalAdvertiserUserId + "?BhRestToken=" + _BHRestToken.BhRestToken;
                                            stacks.Add(new BullhornRESTModels.OperationStack("HttpPost - " + postRequestURL, "PRE", serializedObject));
                                            strResponse = HttpPost(postRequestURL, serializedObject);
                                            stacks.Add(new BullhornRESTModels.OperationStack("HttpPost - " + postRequestURL, "CALLED", strResponse));

                                            if (!string.IsNullOrWhiteSpace(strResponse))
                                            {
                                                // TODO
                                            }
                                        }
                                        else
                                        {
                                            stacks.Add(new BullhornRESTModels.OperationStack("Application - Advertiser User Update", "PRE", null));
                                            AdvertiserUsersService.Update(advertiserUser);
                                            stacks.Add(new BullhornRESTModels.OperationStack("Application - Advertiser User Update", "CALLED", null));
                                        }
                                    }

                                    blnNewAdvertiserUser = false;
                                    #endregion
                                }
                                else //BH does not have advertiser user record
                                {
                                    #region Advertiser User Create on BH
                                    stacks.Add(new BullhornRESTModels.OperationStack("Application - Site Mappings", "Advertiser User Data NOT Found on BH", null));

                                    //If advertiser user data not found on BH, we will have to create a record on BH, so if the command is PULL, it is still a PUSH now
                                    blnPushToBullhorn = true;

                                    // Create new Advertiser User Contact in Bullhorn
                                    foreach (IntegrationMappings sitemapping in sitemappings.Where(s => s.IntegrationMappingTypeId == (int)PortalEnums.Admin.IntegrationMappingType.BH_Mapping_AdvertiserUser))
                                    {
                                        stacks.Add(new BullhornRESTModels.OperationStack("Application - Site Mappings", "Processing " + sitemapping.JxtColumn + "/" + sitemapping.ThirdPartyColumn, null));
                                        BullhornAdvertiserUserChildObject = new Dictionary<string, object>();

                                        strBHMetaThirdPartyColumnObject = string.Empty;
                                        strBHMetaThirdPartyColumnChildName = string.Empty;

                                        propertyInfo = type.GetProperty(sitemapping.JxtColumn);

                                        if (sitemapping.ThirdPartyColumn.Contains(" - "))
                                        {
                                            strBHMetaThirdPartyColumnObject = sitemapping.ThirdPartyColumn.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries).First();
                                            strBHMetaThirdPartyColumnChildName = sitemapping.ThirdPartyColumn.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries).Last();
                                            if (!string.IsNullOrWhiteSpace(strBHMetaThirdPartyColumnObject) && !string.IsNullOrWhiteSpace(strBHMetaThirdPartyColumnChildName)
                                                /*&& ((System.Collections.Generic.Dictionary<string, object>)
                                                                            (bullhornAdvertiserUserData.data[strBHMetaThirdPartyColumnObject])).ContainsKey(strBHMetaThirdPartyColumnChildName)*/)
                                            {
                                                BullhornAdvertiserUserChildObject.Add(strBHMetaThirdPartyColumnChildName, propertyInfo.GetValue(advertiserUser, null));
                                                if (BullhornAdvertiserUserObject.ContainsKey(strBHMetaThirdPartyColumnObject))
                                                {
                                                    ((System.Collections.Generic.Dictionary<string, object>)(BullhornAdvertiserUserObject[strBHMetaThirdPartyColumnObject]))
                                                                [strBHMetaThirdPartyColumnChildName] = propertyInfo.GetValue(advertiserUser, null);
                                                }
                                                else
                                                    BullhornAdvertiserUserObject.Add(strBHMetaThirdPartyColumnObject, BullhornAdvertiserUserChildObject);

                                                /*((System.Collections.Generic.Dictionary<string, object>)
                                                                                    (BullhornAdvertiserUserObject[strBHMetaThirdPartyColumnObject]))[strBHMetaThirdPartyColumnChildName]
                                                                                        = propertyInfo.GetValue(advertiserUser, null);*/
                                            }
                                        }
                                        else
                                        {
                                            //TODO: TEMP FIX
                                            if (sitemapping.ThirdPartyColumn == "phone" || sitemapping.ThirdPartyColumn == "fax")
                                            {
                                                if (advertiserUser.Phone != null && advertiserUser.Phone.Length > 20)
                                                    advertiserUser.Phone = advertiserUser.Phone.Substring(0, 20);
                                                if (advertiserUser.Fax != null && advertiserUser.Fax.Length > 20)
                                                    advertiserUser.Fax = advertiserUser.Fax.Substring(0, 20);
                                            }

                                            BullhornAdvertiserUserObject[sitemapping.ThirdPartyColumn] = propertyInfo.GetValue(advertiserUser, null);
                                        }
                                    }

                                    // Add the external advertiser id to the new Bullhorn contact
                                    var BullhornAdvertiserUserClientObject = new Dictionary<string, object>();
                                    BullhornAdvertiserUserClientObject.Add("id", advertiser.ExternalAdvertiserId);
                                    BullhornAdvertiserUserObject["clientCorporation"] = BullhornAdvertiserUserClientObject;


                                    if (blnNewAdvertiserUser && BullhornAdvertiserUserObject != null && BullhornAdvertiserUserObject.Count > 0)
                                    {
                                        bool hasAssignedBHNameMapping = sitemappings.Where(c => c.ThirdPartyColumn.ToLower() == "name" && c.IntegrationMappingTypeId == (int)PortalEnums.Admin.IntegrationMappingType.BH_Mapping_AdvertiserUser).Any();

                                        //assign the BH "name" as JXT "firstname" + JXT "lastname"  
                                        if (!hasAssignedBHNameMapping)
                                        {
                                            if (!BullhornAdvertiserUserObject.ContainsKey("name"))
                                                BullhornAdvertiserUserObject.Add("name", (advertiserUser.FirstName != null ? advertiserUser.FirstName + " " : "") + (advertiserUser.Surname != null ? advertiserUser.Surname : ""));
                                            else
                                                BullhornAdvertiserUserObject["name"] = (advertiserUser.FirstName != null ? advertiserUser.FirstName + " " : "") + (advertiserUser.Surname != null ? advertiserUser.Surname : "");
                                        }

                                        // Serialize adveritser user and save in BH
                                        serializedObject = ser.Serialize(BullhornAdvertiserUserObject);
                                        string putRequestURL = _BHRestToken.restUrl + "entity/ClientContact" + "?BhRestToken=" + _BHRestToken.BhRestToken;
                                        stacks.Add(new BullhornRESTModels.OperationStack("HttpPut - " + putRequestURL, "PRE", serializedObject));
                                        strResponse = HttpPut(_BHRestToken.restUrl + "entity/ClientContact" + "?BhRestToken=" + _BHRestToken.BhRestToken, serializedObject);
                                        stacks.Add(new BullhornRESTModels.OperationStack("HttpPut - " + putRequestURL, "PRE", strResponse));

                                        if (!string.IsNullOrWhiteSpace(strResponse))
                                        {
                                            BullhornCandidateResponse bullhornCandidateResponse = ser.Deserialize<BullhornCandidateResponse>(strResponse);

                                            if (bullhornCandidateResponse.messages == null)
                                            {
                                                // Save the external advertiser ID from BH
                                                advertiserUser.ExternalAdvertiserUserId = bullhornCandidateResponse.changedEntityId.ToString();

                                                stacks.Add(new BullhornRESTModels.OperationStack("Application - Advertiser User Update", "PRE", null));
                                                AdvertiserUsersService.Update(advertiserUser);
                                                stacks.Add(new BullhornRESTModels.OperationStack("Application - Advertiser User Update", "CALLED", null));
                                            }
                                        }
                                    }
                                    #endregion
                                }
                            }
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                string message = String.Join("<br/>", stacks.Select(c => c.Operation + " => " + c.Status + (!string.IsNullOrEmpty(c.Data) ? "<br/>&nbsp;&nbsp;&nbsp;&nbsp;" + c.Data : string.Empty)).ToList());
                _logger.Error(message);

                throw new Exception("Failed to sync advertiser user via Bullhorn API - Entity ID: " + advertiser.EntityId);
            }
        }

        private void ProcessSingleLevelAdvertiserMappings(int siteId, string jxtColumnName, string thirdPartyColumnName, bool blnPushToBH, Advertisers advertiserObj, Dictionary<string, object> bullhornAdvertiserObject)
        {
            Type type = advertiserObj.GetType();
            System.Reflection.PropertyInfo JXTColumnPropertyInfo = type.GetProperty(jxtColumnName); ;

            if (blnPushToBH)
            {
                #region Push To BH
                switch (jxtColumnName)
                {
                    case "Industry":
                        // check the industry for that site
                        IndustryService industryService = new IndustryService();
                        using (TList<Industry> industryList = industryService.GetBySiteIdIndustryIdList(siteId, advertiserObj.Industry))
                        {
                            if (industryList != null && industryList.Count > 0)
                            {
                                bullhornAdvertiserObject[thirdPartyColumnName] = industryList[0].IndustryName;
                            }
                        }
                        break;
                    case "AdvertiserBusinessTypeId":
                        AdvertiserBusinessTypeService abtService = new AdvertiserBusinessTypeService();
                        AdvertiserBusinessType thisBusinessType = abtService.GetByAdvertiserBusinessTypeId(advertiserObj.AdvertiserBusinessTypeId);
                        if (thisBusinessType != null)
                        {
                            bullhornAdvertiserObject[thirdPartyColumnName] = thisBusinessType.AdvertiserBusinessTypeName;
                        }
                        break;
                    case "PreferredContactMethod":
                        if (advertiserObj.PreferredContactMethod.HasValue)
                        {
                            PortalEnums.Advertiser.ContactMethod thisContactMethod = (PortalEnums.Advertiser.ContactMethod)advertiserObj.PreferredContactMethod.Value;
                            bullhornAdvertiserObject[thirdPartyColumnName] = thisContactMethod.ToString();
                        }
                        break;
                    default:
                        bullhornAdvertiserObject[thirdPartyColumnName] = JXTColumnPropertyInfo.GetValue(advertiserObj, null);
                        break;
                }
                #endregion
            }
            else
            {
                #region Pull From BH
                switch (jxtColumnName)
                {
                    case "Industry":
                        if (bullhornAdvertiserObject[thirdPartyColumnName] != null)
                        {
                            IndustryService industryService = new IndustryService();
                            string industryList = industryService.GetIndustryIDsBySiteId(siteId, bullhornAdvertiserObject[thirdPartyColumnName].ToString());
                            if (industryList != null)
                            {
                                JXTColumnPropertyInfo.SetValue(advertiserObj, industryList, null);
                            }
                        }
                        break;
                    case "AdvertiserBusinessTypeId":
                        if (bullhornAdvertiserObject[thirdPartyColumnName] != null)
                        {
                            //depending on what data type it is on BH, it can either both return a text or a number (ID)
                            int outBusinessTypeID;
                            AdvertiserBusinessTypeService abtService = new AdvertiserBusinessTypeService();
                            if (int.TryParse(bullhornAdvertiserObject[thirdPartyColumnName].ToString(), out outBusinessTypeID))
                            {
                                AdvertiserBusinessType businessTypeFromSite = abtService.GetByAdvertiserBusinessTypeId(outBusinessTypeID);
                                if (businessTypeFromSite != null)
                                {
                                    JXTColumnPropertyInfo.SetValue(advertiserObj, businessTypeFromSite.AdvertiserBusinessTypeId, null);
                                }
                            }
                            else
                            {
                                bool dunCare = false;
                                AdvertiserBusinessType businessTypeFromSite = abtService.GetSiteBusinessTypes(siteId, out dunCare).Where(c => c.AdvertiserBusinessTypeName == bullhornAdvertiserObject[thirdPartyColumnName]).FirstOrDefault();
                                if (businessTypeFromSite != null)
                                {
                                    JXTColumnPropertyInfo.SetValue(advertiserObj, businessTypeFromSite.AdvertiserBusinessTypeId, null);
                                }
                            }
                        }
                        break;
                    case "PreferredContactMethod":
                        PortalEnums.Advertiser.ContactMethod thisContactMethod;
                        if (bullhornAdvertiserObject[thirdPartyColumnName] != null && Enum.TryParse<PortalEnums.Advertiser.ContactMethod>(bullhornAdvertiserObject[thirdPartyColumnName].ToString(), out thisContactMethod))
                        {
                            if (thisContactMethod == 0)
                                JXTColumnPropertyInfo.SetValue(advertiserObj, null, null);
                            else
                                JXTColumnPropertyInfo.SetValue(advertiserObj, (int)thisContactMethod, null);
                        }
                        break;
                    default:
                        JXTColumnPropertyInfo.SetValue(advertiserObj, bullhornAdvertiserObject[thirdPartyColumnName], null);
                        break;
                }
                #endregion
            }
        }

        #endregion
    }
}
