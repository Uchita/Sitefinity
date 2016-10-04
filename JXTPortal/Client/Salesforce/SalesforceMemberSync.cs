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
using System.Xml;
using System.Text.RegularExpressions;

namespace JXTPortal.Client.Salesforce
{
    public class SalesforceMemberSync : IDisposable
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

        public AdminIntegrations.Integrations integrations;

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

        public SalesforceMemberSync() : this(SessionData.Site.SiteId)
        {
            //Add 3072 (TLS1.2) for this application
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | (SecurityProtocolType)3072;
        }

        public SalesforceMemberSync(int siteID)
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

        public SalesforceMemberSync(JXTPortal.Entities.Members member) : this(member, false)
        {

        }
        
        /// <summary>
        ///  Check if the contact exists in Sales force and create/update the contact in Salesforce.
        /// </summary>
        /// <param name="member"></param>
        public SalesforceMemberSync(JXTPortal.Entities.Members member, bool excludeMemberValidatedCheck)
        {
            //Get Integration Details
            integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

            if (integrations.Salesforce != null)
            {
                clientID = integrations.Salesforce.ClientID;
                clientSecret = integrations.Salesforce.ClientSecret;
                clientUsername = integrations.Salesforce.ClientUsername;
                clientPassword = integrations.Salesforce.ClientPassword;
                TokenURL = integrations.Salesforce.TokenURL;
                SFcandidateTypeID = integrations.Salesforce.RecordTypeID;
                SFAccountID = integrations.Salesforce.AccountID;

                //  Check if the contact exists in Sales force and create/update the contact in Salesforce.
                CheckContactAndSaveInSalesForce(member, member.SiteId);
            }
        }

        /*
        public SalesforceMemberSync(string emailaddress)
        {
            // Sandbox
            if (true)
            {
                clientID = "3MVG9Nvmjd9lcjRlcuzJkdPFZb4E3wNqS8F2DMgkVOWdBEf3emzmcU810aRxYnPzQBPpk7UWTvxmX0R6qBXYx";
                clientSecret = "2557040439498542465";
                clientUsername = "administrator@miningpeople.com.au.dev";
                clientPassword = "[Chumzilla15]";
                TokenURL = "https://test.salesforce.com/services/oauth2/token";
            }

            GetTokenWithOutAuthorize();
            
            SalesForceContactObject contact = GetContactFromSalesForce(emailaddress);

            if (contact != null && contact.records != null && contact.records.Count > 0)
            {
                // Insert new
                CreateOrUpdateContactInSalesForce(contact.records[0], contact.records[0].ID);
            }
            else
            {

            }

        }*/


        /*
        public string GetAuthorizeUrl()
        {
            // Build authorization URI
            var authURI = new StringBuilder();
            authURI.Append("https://login.salesforce.com/services/oauth2/authorize?");
            authURI.Append("response_type=code");
            authURI.Append("&client_id=" + clientID);
            authURI.Append("&redirect_uri=" + redirectURL);

            // Redirect the browser control the the SFDC login page
            return (authURI.ToString());
        }*/

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
                if( !string.IsNullOrEmpty(redirectURL) )
                    body.Append("&redirect_uri=" + redirectURL);

                string result = HttpPost(TokenURL, body.ToString());

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


        public SalesForceContactObject GetContactList(bool blnAll)
        {
            // Get Token without authorization
            string tokenGetError;
            bool tokenGetSuccess = GetTokenWithOutAuthorize(out tokenGetError);

            if (!tokenGetSuccess)
                throw new Exception(tokenGetError);

            SalesForceContactObject salesForceContactObject = null;
            WebRequest webRequest = null;
            StreamReader responseStreamReader = null;
            string strTokenResponse = "";

            // Contacts https://www.salesforce.com/developer/docs/api/Content/sforce_api_objects_contact.htm
            // Original: string restContactsQuery = token.instance_url + "/services/data/v25.0/query?q=SELECT+ID,RecordTypeId,LastModifiedDate,FirstName,LastName,Email,Phone,MobilePhone,HomePhone,PreferredWorkType__c,Candidate_Types__c,MailingCity,MailingCountry,MailingPostalCode,MailingState,MailingStreet,OtherCity,OtherCountry,OtherPostalCode,OtherState,OtherStreet+from+Contact+WHERE+Email<>'' AND RecordTypeId='" + SFcandidateTypeID + "' "; // LIMIT 1000 OFFSET 0
            string restContactsQuery = token.instance_url + "/services/data/v25.0/query?q=SELECT+ID,RecordTypeId,LastModifiedDate,FirstName,LastName,Email,Phone,MobilePhone,HomePhone,MailingCity,MailingCountry,MailingPostalCode,MailingState,MailingStreet,OtherCity,OtherCountry,OtherPostalCode,OtherState,OtherStreet+from+Contact+WHERE+Email<>'' AND RecordTypeId='" + SFcandidateTypeID + "' "; // LIMIT 1000 OFFSET 0

            if (!blnAll)
                restContactsQuery = restContactsQuery + " AND LastModifiedDate = LAST_N_DAYS:1";
            //LAST_N_DAYS:7
            //Using LAST_N_DAYS:7 in SOQL will return all records where the date starts from 12:00:00 AM (user Local Time Zone) of the current day and continues for the last 7 days.
            //SELECT Id, Name, CreatedDate FROM Account WHERE CreatedDate = LAST_N_DAYS:7 ORDER BY CreatedDate DESC
            //If today is Friday, 22 Nov 2013, using LAST_N_DAYS:7 will return account created between 16 - 22 Nov 2013, while LAST_WEEK will return account created between 10 - 16 Nov 2013.

            // 4. Use the access token to Request for the Member profile 
            webRequest = (HttpWebRequest)System.Net.WebRequest.Create(restContactsQuery);
            webRequest.Method = "GET";
            webRequest.Headers.Add("Authorization", "Bearer " + token.access_token);
            //webRequest.Headers.Add("Sforce-Call-Options", "client=" + token.access_token);


            System.Net.WebResponse response = null;
            try
            {
                response = webRequest.GetResponse();
                // Get the response of the Member Profile.
                Stream postStream = response.GetResponseStream();
                responseStreamReader = new StreamReader(postStream);

                strTokenResponse = responseStreamReader.ReadToEnd();

                //Literal1.Text = Literal1.Text + "<br>" + strTokenResponse;

                // Serializer
                JavaScriptSerializer jss = new JavaScriptSerializer();
                salesForceContactObject = jss.Deserialize<SalesForceContactObject>(strTokenResponse);

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

                throw ex;
                
            }

            return salesForceContactObject;
        }

        /// <summary>
        /// Get Contact from Salesforce by email address
        /// </summary>
        /// <param name="emailaddress"></param>
        /// <returns></returns>
        private SalesForceContactObject GetContactFromSalesForce(string emailaddress, string SalesForceContactID)
        {
            SalesForceContactObject salesForceContact = null;

            WebRequest webRequest = null;
            StreamReader responseStreamReader = null;
            string strTokenResponse = "";

            // Contacts https://www.salesforce.com/developer/docs/api/Content/sforce_api_objects_contact.htm
            string restContactsQuery = string.Empty;

            //ORIGINAL with CUSTOM FIELDS (ie blahblah__c)
            //TODO Phase 2
            //if (!string.IsNullOrWhiteSpace(SalesForceContactID))
            //    restContactsQuery = token.instance_url + string.Format(@"/services/data/v25.0/query?q=SELECT+ID,RecordTypeId,LastModifiedDate,FirstName,LastName,Email,Phone,MobilePhone,HomePhone,PreferredWorkType__c,Candidate_Types__c,MailingCity,MailingCountry,MailingPostalCode,MailingState,MailingStreet,OtherCity,OtherCountry,OtherPostalCode,OtherState,OtherStreet+from+Contact+WHERE+ID='{0}' AND RecordTypeId='01290000000ewCxAAI'", SalesForceContactID);
            //else
            //    restContactsQuery = token.instance_url + string.Format(@"/services/data/v25.0/query?q=SELECT+ID,RecordTypeId,LastModifiedDate,FirstName,LastName,Email,Phone,MobilePhone,HomePhone,PreferredWorkType__c,Candidate_Types__c,MailingCity,MailingCountry,MailingPostalCode,MailingState,MailingStreet,OtherCity,OtherCountry,OtherPostalCode,OtherState,OtherStreet+from+Contact+WHERE+Email='{0}' AND RecordTypeId='01290000000ewCxAAI'", System.Web.HttpUtility.UrlEncode(emailaddress));
            
            if (!string.IsNullOrWhiteSpace(SalesForceContactID))
                restContactsQuery = token.instance_url + string.Format(@"/services/data/v25.0/query?q=SELECT+ID,RecordTypeId,LastModifiedDate,FirstName,LastName,Email,Phone,MobilePhone,HomePhone,MailingCity,MailingCountry,MailingPostalCode,MailingState,MailingStreet,OtherCity,OtherCountry,OtherPostalCode,OtherState,OtherStreet+from+Contact+WHERE+ID='{0}' AND RecordTypeId='{1}'", SalesForceContactID, SFcandidateTypeID);
            else
                restContactsQuery = token.instance_url + string.Format(@"/services/data/v25.0/query?q=SELECT+ID,RecordTypeId,LastModifiedDate,FirstName,LastName,Email,Phone,MobilePhone,HomePhone,MailingCity,MailingCountry,MailingPostalCode,MailingState,MailingStreet,OtherCity,OtherCountry,OtherPostalCode,OtherState,OtherStreet+from+Contact+WHERE+Email='{0}' AND RecordTypeId='{1}'", System.Web.HttpUtility.UrlEncode(emailaddress), SFcandidateTypeID);

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

                //Literal1.Text = Literal1.Text + "<br>" + strTokenResponse;

                // Get Member details
                JavaScriptSerializer jss = new JavaScriptSerializer();
                salesForceContact = jss.Deserialize<SalesForceContactObject>(strTokenResponse);

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


            if (salesForceContact != null && salesForceContact.records != null && salesForceContact.records.Count > 0)
            {
                return salesForceContact;
            }

            return null;
        }

        /// <summary>
        /// If Member doesn't exist in Platform check if exist in SALESFORCE and grab the details from Salesforce.
        /// </summary>
        /// <param name="emailaddress"></param>
        /// <param name="memberid"></param>
        /// <param name="errormsg"></param>
        /// <returns></returns>
        public bool GetContactFromSalesForceAndSave(string emailaddress, string SalesForceContactID, int SiteId, ref int memberid, ref string errormsg)
        {
            /*if (ConfigurationManager.AppSettings["SalesForceSyncSiteIDs"] != null &&
                    ConfigurationManager.AppSettings["SalesForceSyncSiteIDs"].Contains(string.Format(" {0} ", SiteId)))*/

            if (integrations.Salesforce != null && integrations.Salesforce.Valid)
            {
                // Get Token without authorization
                string tokenGetError;
                bool tokenGetSuccess = GetTokenWithOutAuthorize(out tokenGetError);

                if (!tokenGetSuccess)
                    throw new Exception(tokenGetError);

                SalesForceContactObject salesforceObject = GetContactFromSalesForce(emailaddress, SalesForceContactID);

                if (salesforceObject != null)
                {
                    // Save the member but don't send registration email.
                    return SaveMember(salesforceObject.records[0], false, SiteId, ref memberid, ref errormsg);
                }
            }

            return false;
        }


        public bool CheckContactAndSaveInSalesForce(Members member, int SiteId)
        {
            string _NotUsed;
            bool _NotUsed2;
            return CheckContactAndSaveInSalesForce(member, SiteId, false, out _NotUsed, out _NotUsed2);
        }


        public bool CheckContactAndSaveInSalesForce(Members member, int SiteId, bool excludeMemberValidatedCheck, out string SFID)
        {
            bool _NotUsed2;
            return CheckContactAndSaveInSalesForce(member, SiteId, excludeMemberValidatedCheck, out SFID, out _NotUsed2);
        }

        /// <summary>
        /// Check if the contact exists in Sales force and create/update the contact in Salesforce.
        /// </summary>
        /// <param name="emailaddress"></param>
        /// <param name="member"></param>
        /// <param name="memberid"></param>
        /// <param name="errormsg"></param>
        /// <returns></returns>
        public bool CheckContactAndSaveInSalesForce(Members member, int SiteId, bool excludeMemberValidatedCheck, out string SFID, out bool newSFRecordCreated)
        {
            /*if (ConfigurationManager.AppSettings["SalesForceSyncSiteIDs"] != null &&
                    ConfigurationManager.AppSettings["SalesForceSyncSiteIDs"].Contains(string.Format(" {0} ", SiteId)))*/

            newSFRecordCreated = false;

            if (integrations.Salesforce != null && integrations.Salesforce.Valid)
            {
                // Get Token without authorization
                string tokenGetError;
                bool tokenGetSuccess = GetTokenWithOutAuthorize(out tokenGetError);

                if (!tokenGetSuccess)
                    throw new Exception(tokenGetError);

                // Only valid users to be Synced.
                if (member != null && (excludeMemberValidatedCheck || member.Validated) )
                {
                    
                    // Check if the contact exists in Salesforce.
                    SalesForceContactObject salesforceObject = GetContactFromSalesForce(member.EmailAddress, member.ExternalMemberId);
                    SalesForceContact contact = null;

                    if (salesforceObject != null)
                    {
                        contact = salesforceObject.records[0];
                    }
                    else
                    {
                        contact = new SalesForceContact();
                        contact.ID = string.Empty;
                    }

                    contact.FirstName = member.FirstName;
                    contact.LastName = member.Surname;
                    contact.Email = member.EmailAddress;

                    // DON'T UPDATE BELOW FIELDS FOR ENWORLD
                    if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["EnworldSiteID"]) &&
                        !(ConfigurationManager.AppSettings["EnworldSiteID"].Contains(" " + SiteId + " ")))
                    {
                        contact.Phone = member.WorkPhone;
                        contact.MobilePhone = member.MobilePhone;
                        contact.HomePhone = member.HomePhone;

                        contact.Candidate_Types__c = string.Empty;

                        if (!String.IsNullOrWhiteSpace(member.WorkTypeId))
                        {
                            List<int> workTypeIntValues = member.WorkTypeId.Split(',').Select(n => int.Parse(n)).ToList();

                            using (TList<JXTPortal.Entities.SiteWorkType> siteWorkTypeList = SiteWorkTypeService.GetBySiteId(SiteId))
                            {
                                IEnumerable<SiteWorkType> workTypeList = from list in siteWorkTypeList join intList in workTypeIntValues on list.WorkTypeId equals intList where list.Valid == true select list;

                                if (workTypeList != null)
                                {
                                    foreach (var item in workTypeList)
                                    {
                                        contact.Candidate_Types__c = contact.Candidate_Types__c + (!string.IsNullOrWhiteSpace(contact.Candidate_Types__c) ? ";" : string.Empty) + item.SiteWorkTypeName;
                                    }
                                }
                            }
                        }

                        // Set the Country and Mailing Country 
                        using (TList<Countries> siteCountries = CountriesService.GetAll())
                        {
                            //.Where(s => s.CountryId == member.CountryId).FirstOrDefault()
                            if (!string.IsNullOrWhiteSpace(member.CountryName))
                                contact.OtherCountry = member.CountryName;
                            else
                            {
                                using (Countries country = siteCountries.Where(s => s.CountryId == member.CountryId).FirstOrDefault())
                                {
                                    if (country != null)
                                    {
                                        contact.OtherCountry = country.CountryName;
                                    }
                                }
                            }

                            if (!string.IsNullOrWhiteSpace(member.MailingCountryName))
                                contact.MailingCountry = member.MailingCountryName;
                            else
                            {
                                if (member.MailingCountryId.HasValue)
                                {
                                    using (Countries country = siteCountries.Where(s => s.CountryId == member.MailingCountryId).FirstOrDefault())
                                    {
                                        if (country != null)
                                        {
                                            contact.MailingCountry = country.CountryName;
                                        }
                                    }
                                }
                            }
                        }

                        contact.OtherStreet = member.Address1;
                        contact.OtherCity = member.Suburb;
                        contact.OtherPostalCode = member.PostCode;
                        contact.OtherState = member.States;

                        contact.MailingStreet = member.MailingAddress1;
                        contact.MailingCity = member.MailingSuburb;
                        contact.MailingPostalCode = member.MailingPostCode;
                        contact.MailingState = member.MailingStates;
                        
                    }

                    // Save the contact in Salesforce
                    string ID;

                    //update
                    if (!string.IsNullOrEmpty(contact.ID))
                    {
                        ID = contact.ID;
                        CreateOrUpdateContactInSalesForce(SiteId, contact, contact.ID);
                    }
                    //create
                    else
                    {
                        ID = CreateOrUpdateContactInSalesForce(SiteId, contact, string.Empty);
                        newSFRecordCreated = true;
                    }

                    // Update the external member ID.
                    if (!string.IsNullOrWhiteSpace(ID) && member != null && member.MemberId > 0)
                    {
                        using (Members memberSave = MembersService.GetByMemberId(member.MemberId))
                        {
                            memberSave.ExternalMemberId = ID;
                            MembersService.Update(memberSave);
                        }
                    }


                    SFID = ID;

                    #region ENWORLD Custom Fields

                    string sfEntityID; List<SalesforceIntegration.ErrorMessage> errorMsgs;

                    if (!string.IsNullOrEmpty(SFID) && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["EnworldSiteID"]) &&
                        ConfigurationManager.AppSettings["EnworldSiteID"].Contains(" " + SiteId + " "))
                    {
                        //Registering Site ID for Enworld
                        string registerSiteCountryName = null;
                        List<string> rCountries = new List<string>();

                        if (System.Web.HttpContext.Current != null)
                        {
                            rCountries = XMLPullValue("~/xml/enworld.xml", "registercountry");
                        }
                        else
                        {
                            rCountries = XMLPullValue(ConfigurationManager.AppSettings["EnworldXML"], "registercountry");
                        }

                        foreach(string xmlCountry in rCountries)
                        {
                            string[] thisSplit = xmlCountry.Split(new string[] { "|"}, StringSplitOptions.RemoveEmptyEntries);
                            int siteIDToUse = member.ReferringSiteId ?? SiteId;

                            if (int.Parse(thisSplit[0]) == siteIDToUse)
                            {
                                registerSiteCountryName = thisSplit[1];
                                break;
                            }
                        }


                        object jsonObj;  
                        if (newSFRecordCreated)
                        {
                            jsonObj = new
                            {
                                First_Name_Local__c = member.MultiLingualFirstName,
                                Last_Name_Local__c = member.MultiLingualSurame,
                                PIPL_Agreed__c = true,
                                PIPL_Agreed_Date__c = String.Format("{0:yyyy-MM-dd}", member.RegisteredDate),
                                Secondary_Email__c = member.SecondaryEmail,
                                Registration_Country__c = registerSiteCountryName
                            };
                        }
                        else
                        {
                            jsonObj = new
                            {
                                First_Name_Local__c = member.MultiLingualFirstName,
                                Last_Name_Local__c = member.MultiLingualSurame,
                                Secondary_Email__c = member.SecondaryEmail,
                                Registration_Country__c = registerSiteCountryName
                            };
                        }

                        JavaScriptSerializer ser = new JavaScriptSerializer();
                        string jsonObjString = ser.Serialize(jsonObj);

                        SalesforceIntegration sfInt = new SalesforceIntegration(SiteId);
                        bool postSuccess = sfInt.EntityPatch(SFID, "Contact", jsonObjString, out sfEntityID, out errorMsgs);
                    }
                    #endregion


                    return true;
                }
            }
            SFID = null;
            return false;
        }


        
        //#region RGF

        //public RGFJobBoardDataRoot GetRGFJobs(List<string> jobBoardNames)
        //{
        //    RGFJobBoardDataRoot rgfData = null;


        //    WebRequest webRequest = null;
        //    StreamReader responseStreamReader = null;
        //    string strTokenResponse = "";

        //    // Contacts https://www.salesforce.com/developer/docs/api/Content/sforce_api_objects_contact.htm
        //    string restContactsQuery = string.Empty;

        //    int epochTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

        //    // Get Token without authorization
        //    string tokenGetError;
        //    bool tokenGetSuccess = GetTokenWithOutAuthorize(out tokenGetError);

        //    if (!tokenGetSuccess)
        //        throw new Exception(tokenGetError);

        //    restContactsQuery = token.instance_url + string.Format(@"/services/apexrest/JobBoardConnector?jobBoardNames={0}&timestamp={1}", String.Join(",", jobBoardNames), epochTime);

        //    // 4. Use the access token to Request for the Member profile 
        //    webRequest = (HttpWebRequest)System.Net.WebRequest.Create(restContactsQuery);
        //    webRequest.Method = "GET";
        //    webRequest.Headers.Add("Authorization", "Bearer " + token.access_token);
        //    //webRequest.Headers.(new MediaTypeWithQualityHeaderValue("application/json"));


        //    System.Net.WebResponse response = null;
        //    try
        //    {
        //        response = webRequest.GetResponse();
        //        // Get the response of the Member Profile.
        //        Stream postStream = response.GetResponseStream();
        //        responseStreamReader = new StreamReader(postStream);

        //        strTokenResponse = responseStreamReader.ReadToEnd();

        //        foreach (string boardName in jobBoardNames)
        //        {
        //            string newString = boardName.Replace(" ", "_");

        //            strTokenResponse = strTokenResponse.Replace(boardName, newString);
        //        }

        //        JavaScriptSerializer jss = new JavaScriptSerializer();
        //        rgfData = jss.Deserialize<RGFJobBoardDataRoot>(strTokenResponse);

        //        response.Close();
        //        webRequest = null;

        //        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(RGFJobBoardDataRoot));

        //        XmlWriterSettings settings = new XmlWriterSettings();
        //        settings.Encoding = new UnicodeEncoding(false, false); // no BOM in a .NET string
        //        settings.Indent = false;
        //        settings.OmitXmlDeclaration = false; 
        //        using (StringWriter textWriter = new StringWriter())
        //        {
        //            using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
        //            {
        //                serializer.Serialize(xmlWriter, rgfData);
        //            }
        //            string xmlText = textWriter.ToString();
        //        }
        //    }
        //    catch (WebException ex)
        //    {
        //        string msg = "";

        //        if (ex.Status == WebExceptionStatus.ProtocolError)
        //        {
        //            response = ex.Response;
        //            msg = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd().Trim();
        //        }
        //    }


        //    //if (salesForceContact != null && salesForceContact.records != null && salesForceContact.records.Count > 0)
        //    //{
        //    //    return salesForceContact;
        //    //}

        //    return rgfData;
        //}


        //#region RGF Models

        //public class Language
        //{
        //    public string level { get; set; }
        //    public string language { get; set; }
        //}

        //public class JobFunction
        //{
        //    public string function { get; set; }
        //    public string category { get; set; }
        //}

        //public class Industry
        //{
        //    public string subIndustry { get; set; }
        //    public string industry { get; set; }
        //}

        //public class Upserted
        //{
        //    public string workLocation { get; set; }
        //    public string title { get; set; }
        //    public string status { get; set; }
        //    public string salaryCurrency { get; set; }
        //    public decimal? minSalary { get; set; }
        //    public decimal? maxSalary { get; set; }
        //    public List<Language> languages { get; set; }
        //    public string jobNumber { get; set; }
        //    public List<JobFunction> jobFunctions { get; set; }
        //    public string jobAdvertisement { get; set; }
        //    public List<Industry> industries { get; set; }
        //    public string id { get; set; }
        //    public string companyName { get; set; }
        //    public string companyId { get; set; }
        //}

        //public class JobBoardRoot
        //{
        //    public List<Upserted> upserted { get; set; }
        //}

        //public class JobBoards
        //{
        //    public JobBoardRoot JP_Selection_HK_in_English { get; set; }
        //}

        //public class RGFJobBoardDataRoot
        //{
        //    public bool success { get; set; }
        //    public JobBoards jobBoards { get; set; }
        //}

        //#endregion

        //#endregion

        





        /// <summary>
        /// Create or Update Contact in Salesforce
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        private string CreateOrUpdateContactInSalesForce(int SiteId, SalesForceContact contact, [Optional] string ID)
        {

            if (contact != null && !string.IsNullOrWhiteSpace(contact.Email))
            {
                WebRequest webRequest = null;
                SalesForceTransactionResponse salesForceContactResponse = null;
                string strTokenResponse = "";

                string restNewContactQuery = token.instance_url + "/services/data/v25.0/sobjects/Contact/" + ID;
                webRequest = (HttpWebRequest)System.Net.WebRequest.Create(restNewContactQuery);

                // Create or Update contact
                if (!string.IsNullOrWhiteSpace(ID))
                    webRequest.Method = "PATCH";
                else
                    webRequest.Method = "POST";

                webRequest.Headers.Add("Authorization", "Bearer " + token.access_token);
                webRequest.ContentType = "application/json; charset=utf-8";

                using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    string json = string.Empty;

                    // Only for ENWORLD
                    if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["EnworldSiteID"]) &&
                        ConfigurationManager.AppSettings["EnworldSiteID"].Contains(" " + SiteId + " "))
                    {
                        json = new JavaScriptSerializer().Serialize(new
                        {
                            AccountId = SFAccountID,        // AccountId is only for specific clients - like Enworld
                            RecordTypeId = SFcandidateTypeID,
                            FirstName = contact.FirstName,
                            LastName = contact.LastName,
                            Email = contact.Email
                        });
                    }
                    else
                    {
                        // FOR ALL THE OTHER Salesforce clients
                        json = new JavaScriptSerializer().Serialize(new
                        {
                            RecordTypeId = SFcandidateTypeID,
                            FirstName = contact.FirstName,
                            LastName = contact.LastName,
                            Email = contact.Email,
                            Phone = contact.Phone,
                            MobilePhone = contact.MobilePhone,
                            HomePhone = contact.HomePhone,
                            //Candidate_Types__c = contact.Candidate_Types__c, // Contract/Permanent;Contract/Temporary;Permanent
                            //OtherCity,OtherCountry,OtherPostalCode,OtherState,OtherStreet
                            OtherCity = contact.OtherCity,
                            OtherCountry = contact.OtherCountry,
                            OtherPostalCode = contact.OtherPostalCode,
                            OtherState = contact.OtherState,
                            OtherStreet = contact.OtherStreet,

                            MailingCity = contact.MailingCity,
                            MailingCountry = contact.MailingCountry,
                            MailingPostalCode = contact.MailingPostalCode,
                            MailingState = contact.MailingState,
                            MailingStreet = contact.MailingStreet
                        });
                    }

                    /*string json = new JavaScriptSerializer().Serialize(new
                    {
                        RecordTypeId = "01290000000ewCxAAI",
                        FirstName = "Naveen",
                        LastName = "WHY",
                        Email = "nav@jxt.com.au",
                        Phone = "123",
                        MobilePhone = "040",
                        HomePhone = "02",
                        PreferredWorkType__c = "Both", // Contract/Temp  Permanent  Both
                        MailingCity = "City",
                        MailingCountry = "Country",
                        MailingPostalCode = "2100",
                        MailingState = "NSW",
                        MailingStreet = "Street"
                    });*/

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();

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

                        Console.WriteLine(msg);
                    }


                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    salesForceContactResponse = jss.Deserialize<SalesForceTransactionResponse>(strTokenResponse);

                    //Literal1.Text = Literal1.Text + "<br><hr>" + strTokenResponse;
                }

                webRequest = null;

                if (salesForceContactResponse != null)
                    return salesForceContactResponse.id;
            }

            return string.Empty;
        }


        #region Save Member

        public bool SaveMember(SalesForceContact salesForceContact, bool blnSendEmail, int SiteId, ref int memberid, ref string errormsg)
        {

            MembersService service = new MembersService();
            
            bool blnNewMember = false;
            bool blnValid = true;

            JXTPortal.Entities.Members member = null;

            // If the member has an external id then get from the ID
            if (!string.IsNullOrWhiteSpace(salesForceContact.ID))
                member = service.GetBySiteId(SiteId).Where(s => s.ExternalMemberId == salesForceContact.ID).FirstOrDefault();

            // Else get from Site Email address
            if (member == null)
                member = service.GetBySiteIdEmailAddress(SiteId, salesForceContact.Email);
            
            try
            {
                // Update the Member
                if (member == null)
                {
                    // Create a new Member
                    blnNewMember = true;

                    member = new Members();
                    member.RegisteredDate = DateTime.Now;
                }
                


                member.ExternalMemberId = salesForceContact.ID; // Save the external memberid
                member.SiteId = SiteId;
                member.FirstName = salesForceContact.FirstName;
                member.Surname = salesForceContact.LastName;
                member.EmailAddress = salesForceContact.Email;

                if (blnNewMember)
                    member.Username = salesForceContact.Email; // Only new users update the username
                else
                {
                    if (member.Username.Contains("@"))
                        member.Username = salesForceContact.Email; // Update the Boardy username only if the username is not Email address.
                }


                member.EmailFormat = (int)PortalEnums.Email.EmailFormat.HTML;


                member.Address1 = salesForceContact.OtherStreet;
                member.Suburb = salesForceContact.OtherCity;
                member.States = salesForceContact.OtherState;
                member.PostCode = salesForceContact.OtherPostalCode;

                member.MailingAddress1 = salesForceContact.MailingStreet;
                member.MailingSuburb = salesForceContact.MailingCity;
                member.MailingStates = salesForceContact.MailingState;
                member.MailingPostCode = salesForceContact.MailingPostalCode;

                // Get the country and mailing country
                using (TList<Countries> siteCountries = CountriesService.GetAll())
                {
                    Countries country = null;

                    if (!string.IsNullOrWhiteSpace(salesForceContact.OtherCountry))
                    {
                        country = siteCountries.Where(s => s.CountryName.ToLower() == salesForceContact.OtherCountry.ToLower()).FirstOrDefault();
                        if (country != null)
                        {
                            member.CountryId = country.CountryId;
                            member.CountryName = string.Empty;
                        }
                        else
                            member.CountryName = salesForceContact.OtherCountry;
                    }

                    if (!string.IsNullOrWhiteSpace(salesForceContact.MailingCountry))
                    {
                        country = siteCountries.Where(s => s.CountryName.ToLower() == salesForceContact.MailingCountry.ToLower()).FirstOrDefault();
                        if (country != null)
                        {
                            member.MailingCountryId = country.CountryId;
                            member.MailingCountryName = string.Empty;
                        }
                        else
                            member.MailingCountryName = salesForceContact.MailingCountry;
                    }
                }

                // If country id doesn't exists then get the default country from Global settings - As country is compulsory.
                // If not set the Global default country set for the site.
                using (TList<GlobalSettings> gslist = GlobalSettingsService.GetBySiteId(SiteId))
                {
                    if (gslist.Count > 0)
                    {
                        if (gslist[0].DefaultCountryId.HasValue)
                        {
                            if (member.CountryId < 1)
                                member.CountryId = gslist[0].DefaultCountryId.Value;

                            // Mailing country is not compulsory so set only when there is a value in Salesforce.
                            if (!string.IsNullOrWhiteSpace(member.MailingCountryName))
                            {
                                if (!member.MailingCountryId.HasValue || (member.MailingCountryId.HasValue && member.MailingCountryId.Value < 1))
                                    member.MailingCountryId = gslist[0].DefaultCountryId.Value;
                            }
                        }
                    }
                }


                // Get the worktype
                if (!string.IsNullOrWhiteSpace(salesForceContact.Candidate_Types__c))
                {
                    using (TList<JXTPortal.Entities.SiteWorkType> siteWorkTypeList = SiteWorkTypeService.GetBySiteId(SiteId))
                    {
                        string[] words = salesForceContact.Candidate_Types__c.Split(';');

                        SiteWorkType workType = null;

                        member.WorkTypeId = string.Empty;
                        foreach (string word in words)
                        {
                            workType = siteWorkTypeList.Where(s => s.SiteWorkTypeName.ToLower() == word.ToLower()).FirstOrDefault();

                            if (workType != null)
                                member.WorkTypeId = member.WorkTypeId + (!string.IsNullOrWhiteSpace(member.WorkTypeId) ? "," : "") + workType.WorkTypeId.ToString();
                        }

                    }
                }

                member.MobilePhone = salesForceContact.MobilePhone;
                member.HomePhone = salesForceContact.HomePhone;
                member.WorkPhone = salesForceContact.Phone;


                // Only create the password only when a new member
                string newpassword = string.Empty;
                if (blnNewMember)
                {
                    newpassword = System.Web.Security.Membership.GeneratePassword(10, 0);
                    member.Password = CommonService.EncryptMD5(newpassword);
                    member.ValidateGuid = Guid.NewGuid();
                    member.Validated = false;
                }

                member.SearchField = String.Format("{0} {1}",
                                                       member.FirstName,
                                                       member.Surname);
                member.Valid = true;
                member.LastModifiedDate = DateTime.Now; // Last Updated
                member.RequiredPasswordChange = false; // Don't change the password when you login.

                // Save the user
                if (blnNewMember)
                    service.Insert(member);
                else
                    service.Update(member);

                memberid = member.MemberId;


                // Only New members and only when you want to send registration emails
                if (blnNewMember && blnSendEmail)
                {
                    //Send confirmation email to new member
                    MailService.SendMemberRegistration(member, newpassword);
                }

            }
            catch (Exception ex)
            {
                // Save to exception
                ExceptionTableService exceptionTableService = new ExceptionTableService();
                exceptionTableService.LogException(ex);

                blnValid = false;
                errormsg = ex.Message;
            }
            finally
            {
                member.Dispose();
            }

            return blnValid;
        }

        #endregion


        #region Generic Methods

        public string HttpPost(string URI, string Parameters)
        {
            HttpWebRequest req = System.Net.WebRequest.Create(URI) as HttpWebRequest;
            req.Accept = "application/json";
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


        private List<string> XMLPullValue(string xmlFilePath, string tagname)
        {
            List<string> values = new List<string>();

            XmlDocument xmldoc = new System.Xml.XmlDocument();
            
            if (System.Web.HttpContext.Current != null)
                xmldoc.Load(System.Web.HttpContext.Current.Server.MapPath(xmlFilePath));
            else
                xmldoc.Load(xmlFilePath);

            XmlNodeList list = xmldoc.GetElementsByTagName(tagname);

            foreach (XmlNode node in list)
            {
                values.Add(node.InnerText);
            }

            return values;
        }


        #region IDisposable Members

        public void Dispose()
        {

        }

        #endregion
    }

}



/*
 - Get last modified - Get a List of Updated Records Within a Given Timeframe -  http://www.salesforce.com/us/developer/docs/api_rest/index_Left.htm#StartTopic=Content/dome_get_updated.htm 
 
 
 
 */