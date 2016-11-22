using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using JXTPortal;
using JXTPortal.Entities;
using System.Web.Script.Serialization;
using System.Configuration;
using JXTPortal.Entities.Models;

namespace JXTPortal.Client.Salesforce
{
    public class SalesforceIntegration : IDisposable
    {
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

        // Consumer Key from SFDC account
        private string clientID;
        // Consumer Secret from SFDC account
        private string clientSecret;

        // URL to exchange for the token
        string TokenURL;

        private string clientUsername;
        private string clientPassword;

        private string SFcandidateTypeID;
        private string SFAccountID;

        // Redirect URL configured in SFDC account
        private string redirectURL = ConfigurationManager.AppSettings["SalesForceSyncUrl"]; //"http://localhost:62564/SalesForce2.aspx"; //http://www.miningpeople-2014.com.au/SalesForce2.aspx

        // Code an token generated during authentication
        //private string code;
        private TokenResponse token;

        private AdminIntegrations.Integrations integrations;

        #region Properties

        private GlobalSettingsService _GlobalSettingsService = null;
        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_GlobalSettingsService == null)
                {
                    _GlobalSettingsService = new GlobalSettingsService();
                }
                return _GlobalSettingsService;
            }
        }

        private CountriesService _countriesService = null;
        private CountriesService CountriesService
        {
            get
            {
                if (_countriesService == null)
                {
                    _countriesService = new CountriesService();
                }
                return _countriesService;
            }
        }

        private MembersService _MembersService = null;
        private MembersService MembersService
        {
            get
            {
                if (_MembersService == null)
                {
                    _MembersService = new MembersService();
                }
                return _MembersService;
            }
        }


        private SiteWorkTypeService _siteWorkTypeService = null;
        private SiteWorkTypeService SiteWorkTypeService
        {
            get
            {
                if (_siteWorkTypeService == null)
                {
                    _siteWorkTypeService = new SiteWorkTypeService();
                }
                return _siteWorkTypeService;
            }
        }

        #endregion

        public SalesforceIntegration()
            : this(SessionData.Site.SiteId)
        {
            //Add 3072 (TLS1.2) for this application
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | (SecurityProtocolType)3072;
        }

        public SalesforceIntegration(int siteID)
        {
            //Get Integration Details
            integrations = IntegrationsService.AdminIntegrationsForSiteGet(siteID);

            if (integrations.Salesforce != null)
            {
                clientID = integrations.Salesforce.ClientID;
                clientSecret = integrations.Salesforce.ClientSecret;
                clientUsername = integrations.Salesforce.ClientUsername;
                clientPassword = integrations.Salesforce.ClientPassword;
                TokenURL = integrations.Salesforce.TokenURL;
                SFcandidateTypeID = integrations.Salesforce.RecordTypeID;
                SFAccountID = integrations.Salesforce.AccountID;
            }
        }

        private void GetTokenWithOutAuthorize()
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
                body.Append("password=" + clientPassword + "&");
                body.Append("redirect_uri=" + redirectURL);
                string result = HttpPost(TokenURL, body.ToString());

                // Convert the JSON response into a token object
                JavaScriptSerializer ser = new JavaScriptSerializer();
                token = ser.Deserialize<TokenResponse>(result);

            }

            // Read the REST resources
            //string s = HttpGet(token.instance_url + @"/services/data/v25.0/", "");

        }

        public bool PostSObjectBatchRequest(string[] sObjNames, out SObjBatchObject result, out string errorMsg)
        {
            // Get Token without authorization
            GetTokenWithOutAuthorize();

            WebRequest webRequest = null;

            string restNewUploadPostURL = token.instance_url + "/services/data/v34.0/composite/batch";
            webRequest = (HttpWebRequest)System.Net.WebRequest.Create(restNewUploadPostURL);
            webRequest.Method = "POST";

            webRequest.Headers.Add("Authorization", "Bearer " + token.access_token);
            webRequest.ContentType = "application/json; charset=utf-8";

            JavaScriptSerializer ser = new JavaScriptSerializer();

            BatchRequests newBatchRequests = new BatchRequests();
            foreach (string name in sObjNames)
            {
                newBatchRequests.batchRequests.Add(new BatchRequest
                {
                    method = "GET",
                    url = "/services/data/v34.0/query?q=" + name
                });
            }

            string batchJson = ser.Serialize(newBatchRequests);

            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                string json = batchJson;
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();

                WebResponse httpResponse = null;
                try
                {
                    string strTokenResponse = "";

                    httpResponse = (HttpWebResponse)webRequest.GetResponse();

                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        strTokenResponse = streamReader.ReadToEnd(); //{"id":"003O000000a3FZnIAM","success":true,"errors":[]}
                    }

                    httpResponse.Close();
                    webRequest = null;

                    result = ser.Deserialize<SObjBatchObject>(strTokenResponse);

                    errorMsg = null;
                    return true;
                }
                catch (WebException ex)
                {
                    webRequest = null;
                    result = null;

                    string msg = "";

                    if (ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        httpResponse = ex.Response;
                        msg = new System.IO.StreamReader(httpResponse.GetResponseStream()).ReadToEnd().Trim();

                        errorMsg = msg;
                        return false;
                    }
                    errorMsg = "WebException: " + ex.Message;
                    return false;
                }
            }
        }

        public bool PostSObjectDescribeBatchRequest(string[] sObjNames, out SObjDescribeResponse result, out string errorMsg)
        {
            // Get Token without authorization
            GetTokenWithOutAuthorize();

            WebRequest webRequest = null;

            string restNewUploadPostURL = token.instance_url + "/services/data/v34.0/composite/batch";
            webRequest = (HttpWebRequest)System.Net.WebRequest.Create(restNewUploadPostURL);
            webRequest.Method = "POST";

            webRequest.Headers.Add("Authorization", "Bearer " + token.access_token);
            webRequest.ContentType = "application/json; charset=utf-8";

            JavaScriptSerializer ser = new JavaScriptSerializer();

            BatchRequests newBatchRequests = new BatchRequests();
            foreach (string name in sObjNames)
            {
                newBatchRequests.batchRequests.Add(new BatchRequest
                {
                    method = "GET",
                    url = "v34.0/sobjects/" + name + "/describe"
                });
            }

            string batchJson = ser.Serialize(newBatchRequests);

            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                string json = batchJson;
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();

                WebResponse httpResponse = null;
                try
                {
                    SObjDescribeResponse salesForceResponse = null;
                    string strTokenResponse = "";

                    httpResponse = (HttpWebResponse)webRequest.GetResponse();

                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        strTokenResponse = streamReader.ReadToEnd(); //{"id":"003O000000a3FZnIAM","success":true,"errors":[]}
                    }

                    httpResponse.Close();
                    webRequest = null;

                    result = ser.Deserialize<SObjDescribeResponse>(strTokenResponse);

                    errorMsg = null;
                    return true;
                }
                catch (WebException ex)
                {
                    webRequest = null;
                    result = null;

                    string msg = "";

                    if (ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        httpResponse = ex.Response;
                        msg = new System.IO.StreamReader(httpResponse.GetResponseStream()).ReadToEnd().Trim();

                        errorMsg = msg;
                        return false;
                    }
                    errorMsg = "WebException: " + ex.Message;
                    return false;
                }
            }
        }

        public string EntityGet(string query)
        {
            // Get Token without authorization
            GetTokenWithOutAuthorize();

            WebRequest webRequest = null;
            StreamReader responseStreamReader = null;
            string strTokenResponse = "";


            string restContactsQuery = token.instance_url + "/services/data/v34.0/query?q=" + query; // LIMIT 1000 OFFSET 0

            webRequest = (HttpWebRequest)System.Net.WebRequest.Create(restContactsQuery);
            webRequest.Method = "GET";
            webRequest.Headers.Add("Authorization", "Bearer " + token.access_token);

            System.Net.WebResponse response = null;
            try
            {
                response = webRequest.GetResponse();
                // Get the response of the Member Profile.
                Stream postStream = response.GetResponseStream();
                responseStreamReader = new StreamReader(postStream);

                strTokenResponse = responseStreamReader.ReadToEnd();

                return strTokenResponse;

            }
            catch (WebException ex)
            {
                string msg = "";

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    response = ex.Response;
                    msg = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd().Trim();
                }
                //Literal1.Text = msg;
                Console.WriteLine(msg);
                throw ex;

            }
        }

        public bool EntityPost(string entityName, string jsonContent, out string entityID, out string errorMsg)
        {
            // Get Token without authorization
            GetTokenWithOutAuthorize();

            WebRequest webRequest = null;

            string restNewUploadPostURL = token.instance_url + "/services/data/v34.0/sobjects/" + entityName;

            if (entityName.Equals("ParseResume"))
                restNewUploadPostURL = token.instance_url + "/services/apexrest/ts2/ParseResume";

            webRequest = (HttpWebRequest)System.Net.WebRequest.Create(restNewUploadPostURL);
            webRequest.Method = "POST";

            webRequest.Headers.Add("Authorization", "Bearer " + token.access_token);
            webRequest.ContentType = "application/json; charset=utf-8";

            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                string json = jsonContent;
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();

                WebResponse httpResponse = null;
                try
                {
                    SalesForceTransactionResponse salesForceResponse = null;
                    string strTokenResponse = "";

                    httpResponse = (HttpWebResponse)webRequest.GetResponse();

                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        strTokenResponse = streamReader.ReadToEnd(); //{"id":"003O000000a3FZnIAM","success":true,"errors":[]}
                    }

                    httpResponse.Close();
                    webRequest = null;

                    salesForceResponse = new JavaScriptSerializer().Deserialize<SalesForceTransactionResponse>(strTokenResponse);

                    if (salesForceResponse.success)
                    {
                        entityID = salesForceResponse.id;
                        errorMsg = null;
                        return true;
                    }
                    else
                    {
                        entityID = null;
                        errorMsg = salesForceResponse.errors.First().ToString();
                        return false;
                    }


                }
                catch (WebException ex)
                {
                    webRequest = null;

                    string msg = ex.Message;

                    errorMsg = "WebException: " + ex.Message;
                    if (ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        httpResponse = ex.Response;
                        msg = new System.IO.StreamReader(httpResponse.GetResponseStream()).ReadToEnd().Trim();

                        entityID = null;
                        errorMsg = errorMsg + " - " + msg;
                        return false;
                    }

                    entityID = null;
                    return false;
                }
            }
        }
        public bool EntityPatch(string targetEntityID, string entityName, string jsonContent, out string entityID, out List<ErrorMessage> errorMsgs)
        {
            // Get Token without authorization
            GetTokenWithOutAuthorize();

            WebRequest webRequest = null;

            string restNewUploadPostURL = token.instance_url + "/services/data/v34.0/sobjects/" + entityName + "/" + targetEntityID;
            webRequest = (HttpWebRequest)System.Net.WebRequest.Create(restNewUploadPostURL);
            webRequest.Method = "PATCH";

            webRequest.Headers.Add("Authorization", "Bearer " + token.access_token);
            webRequest.ContentType = "application/json; charset=utf-8";

            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                string json = jsonContent;
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();

                WebResponse httpResponse = null;
                try
                {
                    string strTokenResponse = "";

                    httpResponse = (HttpWebResponse)webRequest.GetResponse();

                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        strTokenResponse = streamReader.ReadToEnd(); //{"id":"003O000000a3FZnIAM","success":true,"errors":[]}
                    }

                    httpResponse.Close();
                    webRequest = null;

                    //if success, response is empty
                    entityID = targetEntityID;
                    errorMsgs = null;
                    return true;
                }
                catch (WebException ex)
                {
                    webRequest = null;

                    string msg = "";

                    if (ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        httpResponse = ex.Response;
                        msg = new System.IO.StreamReader(httpResponse.GetResponseStream()).ReadToEnd().Trim();

                        entityID = null;

                        JavaScriptSerializer ser = new JavaScriptSerializer();
                        List<ErrorMessage> errors = ser.Deserialize<List<ErrorMessage>>(msg);

                        errorMsgs = errors;
                        return false;
                    }

                    entityID = null;
                    errorMsgs = new List<ErrorMessage> { new ErrorMessage { message = "WebException: " + ex.Message } };
                    return false;
                }
            }
        }

        public bool EntityDelete(string entityName, string sfID, out string errorMsg)
        {
            // Get Token without authorization
            GetTokenWithOutAuthorize();

            WebRequest webRequest = null;

            string restNewUploadPostURL = token.instance_url + "/services/data/v34.0/sobjects/" + entityName + "/" + sfID;
            webRequest = (HttpWebRequest)System.Net.WebRequest.Create(restNewUploadPostURL);
            webRequest.Method = "DELETE";

            webRequest.Headers.Add("Authorization", "Bearer " + token.access_token);
            webRequest.ContentType = "application/json; charset=utf-8";


            WebResponse httpResponse = null;
            try
            {
                httpResponse = (HttpWebResponse)webRequest.GetResponse();

                //delete returns no response when success

                httpResponse.Close();
                webRequest = null;

                errorMsg = null;
                return true;
            }
            catch (WebException ex)
            {
                webRequest = null;

                string msg = "";

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    httpResponse = ex.Response;
                    msg = new System.IO.StreamReader(httpResponse.GetResponseStream()).ReadToEnd().Trim();

                    errorMsg = msg;
                    return false;
                }

                errorMsg = "WebException: " + ex.Message;
                return false;
            }

        }

        public void UploadEntity(string requestingObj, string jsonContent, string fileName, byte[] binaryData)
        {
            // Get Token without authorization
            GetTokenWithOutAuthorize();

            string boundary = "boundary_string";

            WebRequest webRequest = null;
            SalesForceTransactionResponse salesForceContactResponse = null;
            string strTokenResponse = "";

            string restNewUploadPostURL = token.instance_url + "/services/data/v24.0/sobjects/" + requestingObj;
            webRequest = (HttpWebRequest)System.Net.WebRequest.Create(restNewUploadPostURL);
            webRequest.Method = "POST";

            webRequest.Headers.Add("Authorization", "Bearer " + token.access_token);
            webRequest.ContentType = "multipart/form-data; boundary=" + boundary;

            // Add header for JSON part
            string body = "";
            body += "\r\n--" + boundary + "\r\n"; ;
            body += "Content-Disposition: form-data; name='entity_attachment'\r\n";
            body += "Content-Type: application/json\r\n\r\n";

            // Add document object data in JSON
            body += jsonContent;
            body += "\r\n--" + boundary + "\r\n\r\n"; ;

            // Add header for binary part 
            body += "Content-Type: text/plain\r\n";
            body += "Content-Disposition: form-data; name='Body'; filename='" + fileName + "'\r\n\r\n";

            //sends the file 
            byte[] fileBytes = File.ReadAllBytes(@"C:\\saleforce_test\\textfile.txt");
            String file64String = Convert.ToBase64String(fileBytes);

            body += file64String;

            body += "\r\n--" + boundary + "--\r\n";

            //webRequest.ContentLength = bodyData.Length;

            using (Stream stream = webRequest.GetRequestStream())
            {
                ////sends the body data
                byte[] bodyData = System.Text.Encoding.ASCII.GetBytes(body);
                stream.Write(bodyData, 0, bodyData.Length);

                ////sends the file 
                //FileStream fileStream = new FileStream(@"C:\\saleforce_test\\JobscienceJobBoardAPI.pdf", FileMode.Open, FileAccess.Read);
                //byte[] buffer = new byte[4096];
                //int bytesRead = 0;
                //while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                //{
                //    stream.Write(buffer, 0, bytesRead);
                //}

                //fileStream.Close();

                //// Add trailer
                //byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n" + boundary + "--\r\n");
                //stream.Write(trailer, 0, trailer.Length);
                //stream.Close();


                WebResponse httpResponse = null;
                try
                {
                    httpResponse = (HttpWebResponse)webRequest.GetResponse();

                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        strTokenResponse = streamReader.ReadToEnd(); //{"id":"003O000000a3FZnIAM","success":true,"errors":[]}
                    }

                    httpResponse.Close();
                }
                catch (WebException ex)
                {
                    string msg = "";

                    if (ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        httpResponse = ex.Response;
                        msg = new System.IO.StreamReader(httpResponse.GetResponseStream()).ReadToEnd().Trim();
                    }
                    //Literal1.Text = msg;

                }


                JavaScriptSerializer jss = new JavaScriptSerializer();
                salesForceContactResponse = jss.Deserialize<SalesForceTransactionResponse>(strTokenResponse);

                //Literal1.Text = Literal1.Text + "<br><hr>" + strTokenResponse;
            }

            webRequest = null;

            //if (salesForceContactResponse != null)
            //    return salesForceContactResponse.id;
        }

        #region Generic Methods

        public string HttpPost(string URI, string Parameters)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            //req.Headers.Add("Sforce-Call-Options", "client=" + clientID);
            //req.Headers.Add("Sforce-Call-Options", "client=SampleCaseSensitiveToken/100");
            /*if (token != null)
            req.Headers.Add("Sforce-Call-Options", "client=" + token.access_token);*/
            // Sforce-Call-Options: client=SampleCaseSensitiveToken/100, defaultNamespace=battle


            // Add parameters to post
            byte[] data = System.Text.Encoding.ASCII.GetBytes(Parameters);
            req.ContentLength = data.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(data, 0, data.Length);
            os.Close();

            System.Net.WebResponse resp;
            try
            {
                // Do the post and get the response.
                resp = req.GetResponse();
                if (resp == null) return null;
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                return sr.ReadToEnd().Trim();
            }
            catch (WebException ex)
            {
                string msg = "";

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    //throw ex;
                    resp = ex.Response;
                    msg = new System.IO.StreamReader(resp.GetResponseStream()).ReadToEnd().Trim();
                    resp.Close();
                }
                return null;
            }
        }

        public string HttpGet(string URI, string Parameters)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            req.Method = "GET";
            req.Headers.Add("Authorization: OAuth " + token.access_token);

            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {

        }

        #endregion

        #region Classes

        public class ErrorMessage
        {
            public string message { get; set; }
            public string errorCode { get; set; }
            public List<string> fields { get; set; }
        }

        public class BatchRequest
        {
            public string method { get; set; }
            public string url { get; set; }
        }

        public class BatchRequests
        {
            public List<BatchRequest> batchRequests { get; set; }

            public BatchRequests()
            {
                batchRequests = new List<BatchRequest>();
            }
        }

        //public class ChildRelationship
        //{
        //    public bool cascadeDelete { get; set; }
        //    public string childSObject { get; set; }
        //    public bool deprecatedAndHidden { get; set; }
        //    public string field { get; set; }
        //    public object junctionIdListName { get; set; }
        //    public List<object> junctionReferenceTo { get; set; }
        //    public string relationshipName { get; set; }
        //    public bool restrictedDelete { get; set; }
        //}

        //public class FilteredLookupInfo
        //{
        //    public List<object> controllingFields { get; set; }
        //    public bool dependent { get; set; }
        //    public bool optionalFilter { get; set; }
        //}

        public class SObjField
        {
            //public bool autoNumber { get; set; }
            //public int byteLength { get; set; }
            //public bool calculated { get; set; }
            //public string calculatedFormula { get; set; }
            //public bool cascadeDelete { get; set; }
            //public bool caseSensitive { get; set; }
            public string controllerName { get; set; }
            //public bool createable { get; set; }
            //public bool custom { get; set; }
            //public object defaultValue { get; set; }
            //public string defaultValueFormula { get; set; }
            //public bool defaultedOnCreate { get; set; }
            public bool dependentPicklist { get; set; }
            //public bool deprecatedAndHidden { get; set; }
            //public int digits { get; set; }
            //public bool displayLocationInDecimal { get; set; }
            //public bool encrypted { get; set; }
            //public bool externalId { get; set; }
            //public string extraTypeInfo { get; set; }
            //public bool filterable { get; set; }
            //public FilteredLookupInfo filteredLookupInfo { get; set; }
            //public bool groupable { get; set; }
            //public bool highScaleNumber { get; set; }
            //public bool htmlFormatted { get; set; }
            //public bool idLookup { get; set; }
            //public string inlineHelpText { get; set; }
            public string label { get; set; }
            //public int length { get; set; }
            //public object mask { get; set; }
            //public object maskType { get; set; }
            public string name { get; set; }
            //public bool nameField { get; set; }
            //public bool namePointing { get; set; }
            //public bool nillable { get; set; }
            //public bool permissionable { get; set; }
            public SObjPickListValues[] picklistValues { get; set; }
            //public int precision { get; set; }
            //public bool queryByDistance { get; set; }
            //public object referenceTargetField { get; set; }
            //public List<object> referenceTo { get; set; }
            //public string relationshipName { get; set; }
            //public object relationshipOrder { get; set; }
            //public bool restrictedDelete { get; set; }
            //public bool restrictedPicklist { get; set; }
            //public int scale { get; set; }
            //public string soapType { get; set; }
            //public bool sortable { get; set; }
            //public string type { get; set; }
            //public bool unique { get; set; }
            //public bool updateable { get; set; }
            //public bool writeRequiresMasterRead { get; set; }

        }

        //public class Urls
        //{
        //    public string layout { get; set; }
        //}

        //public class RecordTypeInfo
        //{
        //    public bool available { get; set; }
        //    public bool defaultRecordTypeMapping { get; set; }
        //    public string name { get; set; }
        //    public string recordTypeId { get; set; }
        //    public Urls urls { get; set; }
        //}

        //public class Urls2
        //{
        //    public string compactLayouts { get; set; }
        //    public string rowTemplate { get; set; }
        //    public string approvalLayouts { get; set; }
        //    public string uiDetailTemplate { get; set; }
        //    public string uiEditTemplate { get; set; }
        //    public string listviews { get; set; }
        //    public string describe { get; set; }
        //    public string uiNewRecord { get; set; }
        //    public string quickActions { get; set; }
        //    public string layouts { get; set; }
        //    public string sobject { get; set; }
        //}

        public class SObjPickListValues
        {
            [ScriptIgnore]
            public bool active { get; set; }
            [ScriptIgnore]
            public bool defaultValue { get; set; }
            public string label { get; set; }
            public string validFor { get; set; }
            public string value { get; set; }

            //CUSTOM Fields for display
            [ScriptIgnore]
            public string FullFieldDisplay { get { return value + " - " + label; } }

        }

        public class SObjDescribe
        {
            //public List<object> actionOverrides { get; set; }
            //public bool activateable { get; set; }
            //public List<ChildRelationship> childRelationships { get; set; }
            //public bool compactLayoutable { get; set; }
            //public bool createable { get; set; }
            //public bool custom { get; set; }
            //public bool customSetting { get; set; }
            //public bool deletable { get; set; }
            //public bool deprecatedAndHidden { get; set; }
            //public bool feedEnabled { get; set; }
            public List<SObjField> fields { get; set; }
            //public string keyPrefix { get; set; }
            public string label { get; set; }
            //public string labelPlural { get; set; }
            //public bool layoutable { get; set; }
            //public object listviewable { get; set; }
            //public object lookupLayoutable { get; set; }
            //public bool mergeable { get; set; }
            public string name { get; set; }
            //public List<object> namedLayoutInfos { get; set; }
            //public bool queryable { get; set; }
            //public List<RecordTypeInfo> recordTypeInfos { get; set; }
            //public bool replicateable { get; set; }
            //public bool retrieveable { get; set; }
            //public bool searchLayoutable { get; set; }
            //public bool searchable { get; set; }
            //public bool triggerable { get; set; }
            //public bool undeletable { get; set; }
            //public bool updateable { get; set; }
            //public Urls2 urls { get; set; }
        }

        public class SObjDescribeResult
        {
            public int statusCode { get; set; }
            public SObjDescribe result { get; set; }
        }

        public class SObjDescribeResponse
        {
            public bool hasErrors { get; set; }
            public List<SObjDescribeResult> results { get; set; }
        }

        #endregion

        #region Batch Objects

        public class SObjAttributes
        {
            public string type { get; set; }
            public string url { get; set; }
        }

        public class SObjRecord
        {
            [ScriptIgnore]
            public Attributes attributes { get; set; }
            #region old (Copy of profile.aspx)
            //public string Id { get; set; }
            //public string FirstName { get; set; }
            //public string LastName { get; set; }
            //public string ts2__Job_Title__c { get; set; }
            //public string ts2__Employment_Start_Date__c { get; set; }
            //public string ts2__Employment_End_Date__c { get; set; }
            //public string ts2__Name__c { get; set; }
            //public string ts2__Location__c { get; set; }
            //public string Resume_RFL__c { get; set; }
            //public string ts2__Company__c { get; set; }
            //public string ts2__Role_Title__c { get; set; }
            //public string ts2__Phone__c { get; set; }
            //public string ts2__Email__c { get; set; }
            //public string ts2__Graduation_Year__c { get; set; }
            //public string ts2__DegreePicklist__c { get; set; }
            //public string ts2__Major__c { get; set; }
            //public string Skill__c { get; set; }
            //public string Skill_Name__c { get; set; }
            //public string Sector_Experience__c { get; set; }
            //public string Sector_Detail__c { get; set; }
            //public string Job_Function__c { get; set; }
            //public string Experience__c { get; set; }
            #endregion

            //tab1
            public string Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string First_Name_Local__c { get; set; }
            public string Last_Name_Local__c { get; set; }
            public string Email { get; set; }
            public string RecordTypeId { get; set; }
            public string ts2__EEO_Gender__c { get; set; }
            public string Birthdate { get; set; }
            public string MobilePhone { get; set; }
            public string Phone { get; set; }
            public string Secondary_Email__c { get; set; }
            public string MailingStreet { get; set; }
            public string MailingCity { get; set; }
            public string MailingPostalCode { get; set; }
            public string MailingState { get; set; }
            public string MailingCountry { get; set; }
            public string Native_Language__c { get; set; }
            public string Second_Language__c { get; set; }
            public string Second_Language_Proficiency__c { get; set; }

            //tab2
            public string Current_Company__c { get; set; }
            public string Current_Position__c { get; set; }
            public string Industry__c { get; set; }
            public string Job_Category__c { get; set; }
            public string Job_Functions__c { get; set; }
            public string Employment_Type__c { get; set; }
            public string Salary_Period__c { get; set; }
            public string Current_Fixed_Salary__c { get; set; }
            public string Annual_Variable_Salary__c { get; set; }
            public string CurrencyIsoCode { get; set; }

            //tab3
            public string Desired_Country__c { get; set; }
            public string Desired_Locations__c { get; set; }//SF returns multiple values with ';' as seperator
            public string Employment_Preference__c { get; set; }
            public string Desired_Industry__c { get; set; }
            public string Desired_Job_Category__c { get; set; }
            public string Desired_Job_Functions__c { get; set; }
            public string Desired_Other_Countries__c { get; set; } //SF returns multiple values with ';' as seperator


        }

        public class SObjResult
        {
            public int totalSize { get; set; }
            public bool done { get; set; }
            public IList<SObjRecord> records { get; set; }
        }

        public class SObjResults
        {
            public int statusCode { get; set; }
            public SObjResult result { get; set; }
        }

        public class SObjBatchObject
        {
            public bool hasErrors { get; set; }
            public IList<SObjResults> results { get; set; }
        }
        #endregion

    }



}


/*
 - Get last modified - Get a List of Updated Records Within a Given Timeframe -  http://www.salesforce.com/us/developer/docs/api_rest/index_Left.htm#StartTopic=Content/dome_get_updated.htm 
 
 
 
 */