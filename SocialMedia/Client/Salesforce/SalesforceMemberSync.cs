using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using JXTPortal;
using JXTPortal.Entities;

namespace SocialMedia.Client.Salesforce
{
    public class SalesforceMemberSync
    {

        // Consumer Key from SFDC account
        private string clientID = "3MVG9Y6d_Btp4xp7iTzOGrsL3l_6ZyV_nhm8KmVEWns3E7jIn1rLgyuQY.lf91_9da3oQhqviQE6SEGGmnMRb";

        // Consumer Secret from SFDC account
        private string clientSecret = "7360098520472512276";

        string TokenURL = "https://login.salesforce.com/services/oauth2/token";

        // Redirect URL configured in SFDC account
        private string redirectURL = "http://localhost:62564/SalesForce2.aspx";

        private string clientUsername = "administrator@miningpeople.com.au";
        private string clientPassword = "[Chumzilla15]";

        // Code an token generated during authentication
        //private string code;
        private TokenResponse token;

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

        private SiteCountriesService _siteCountriesService = null;
        private SiteCountriesService SiteCountriesService
        {
            get
            {
                if (_siteCountriesService == null)
                {
                    _siteCountriesService = new SiteCountriesService();
                }
                return _siteCountriesService;
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

        public SalesforceMemberSync()
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

            //GetContactList();

        }


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

            //GetContactList();

            SalesForceContactObject contact = GetContactFromSalesForce(emailaddress);

            if (contact != null && contact.records != null && contact.records.Count > 0)
            {
                // Insert new
                CreateOrUpdateContactInSalesForce(contact.records[0], contact.records[0].ID);
            }
            else
            {

            }

        }


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

        public void GetTokenWithOutAuthorize()
        {
            // Create the message used to request a token

            StringBuilder body = new StringBuilder();
            body.Append("grant_type=password&format=json&");
            body.Append("client_id=" + clientID + "&");
            body.Append("client_secret=" + clientSecret + "&");
            body.Append("username=" + clientUsername + "&");
            body.Append("password=" + clientPassword + "&");
            body.Append("redirect_uri=" + redirectURL);
            string result = HttpPost(TokenURL, body.ToString());

            // Convert the JSON response into a token object
            JavaScriptSerializer ser = new JavaScriptSerializer();
            token = ser.Deserialize<TokenResponse>(result);

            // Read the REST resources
            string s = HttpGet(token.instance_url + @"/services/data/v25.0/", "");
            
        }


        public void GetContactList()
        {
            SalesForceContactObject salesForceContactObject = null;
            WebRequest webRequest = null;
            StreamReader responseStreamReader = null;
            string strTokenResponse = "";

            // Contacts https://www.salesforce.com/developer/docs/api/Content/sforce_api_objects_contact.htm
            string restContactsQuery = token.instance_url + "/services/data/v25.0/query?q=SELECT+ID,RecordTypeId,LastModifiedDate,FirstName,LastName,Email,Phone,MobilePhone,HomePhone,PreferredWorkType__c,MailingCity,MailingCountry,MailingPostalCode,MailingState,MailingStreet+from+Contact+WHERE+Email<>'' AND RecordTypeId='01290000000ewCxAAI' "; // LIMIT 1000 OFFSET 0
            //N_DAYS_AGO:7


            // 4. Use the access token to Request for the Member profile 
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

                
            }

        }

        /// <summary>
        /// Get Contact from Salesforce by email address
        /// </summary>
        /// <param name="emailaddress"></param>
        /// <returns></returns>
        public SalesForceContactObject GetContactFromSalesForce(string emailaddress)
        {
            SalesForceContactObject salesForceContact = null;

            WebRequest webRequest = null;
            StreamReader responseStreamReader = null;
            string strTokenResponse = "";

            // Contacts https://www.salesforce.com/developer/docs/api/Content/sforce_api_objects_contact.htm
            string restContactsQuery = token.instance_url +
                                        string.Format(@"/services/data/v25.0/query?q=SELECT+ID,RecordTypeId,LastModifiedDate,FirstName,LastName,Email,Phone,MobilePhone,HomePhone,PreferredWorkType__c,Candidate_Types__c,MailingCity,MailingCountry,MailingPostalCode,MailingState,MailingStreet+from+Contact+WHERE+Email='{0}' AND RecordTypeId='01290000000ewCxAAI'", emailaddress);

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

            }


            if (salesForceContact != null && salesForceContact.records != null && salesForceContact.records.Count > 0)
            {
                return salesForceContact;
            }

            return null;
        }

        /// <summary>
        /// Get contact from salesforce and save in platform
        /// </summary>
        /// <param name="emailaddress"></param>
        /// <param name="memberid"></param>
        /// <param name="errormsg"></param>
        /// <returns></returns>
        public bool GetContactFromSalesForceAndSave(string emailaddress, ref int memberid, ref string errormsg)
        {
            SalesForceContactObject salesforceObject = GetContactFromSalesForce(emailaddress);

            if (salesforceObject != null)
            {
                return SaveMember(salesforceObject.records[0], ref memberid, ref errormsg);
            }

            return false;
        }

        /// <summary>
        /// Check if the contact exists in Sales force and create/update the contact in Salesforce.
        /// </summary>
        /// <param name="emailaddress"></param>
        /// <param name="member"></param>
        /// <param name="memberid"></param>
        /// <param name="errormsg"></param>
        /// <returns></returns>
        public bool CheckContactAndSaveInSalesForce(Members member)
        {
            if (member != null)
            {
                // Check if the contact exists in Salesforce.
                SalesForceContactObject salesforceObject = GetContactFromSalesForce(member.EmailAddress);
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
                contact.Phone = member.WorkPhone;
                contact.MobilePhone = member.MobilePhone;
                contact.HomePhone = member.HomePhone;

                /*
                using (TList<JXTPortal.Entities.SiteWorkType> siteWorkTypeList = SiteWorkTypeService.GetBySiteId(SessionData.Site.SiteId))
                {
                    SiteWorkType workType = siteWorkTypeList.Where(s => s.SiteWorkTypeName.ToLower() == salesForceContact.PreferredWorkType__c).FirstOrDefault();

                    if (workType != null)
                        member.WorkTypeId = workType.WorkTypeId.ToString();
                }
                */

                contact.PreferredWorkType__c = "Both"; // TODO  Contract/Temp  Permanent  Both
                using (SiteCountries siteCountry = SiteCountriesService.GetBySiteId(SessionData.Site.SiteId)
                                                                .Where(s => s.CountryId == member.CountryId).FirstOrDefault())
                {
                    if (siteCountry != null)
                    {
                        contact.MailingCountry = siteCountry.SiteCountryName;
                    }
                }

                contact.MailingCity = member.Suburb;
                contact.MailingPostalCode = member.PostCode;
                contact.MailingState = member.States;
                contact.MailingStreet = member.Suburb;

                // Save the contact in Salesforce
                string ID = CreateOrUpdateContactInSalesForce(contact, contact.ID);

                // Update the external member ID.
                if (!string.IsNullOrWhiteSpace(ID) && member != null && member.MemberId > 0)
                {
                    using (Members memberSave = MembersService.GetByMemberId(member.MemberId))
                    {
                        memberSave.ExternalMemberId = ID;
                        MembersService.Update(memberSave);
                    }
                }

                return true;
            }

            return false;
        }

        public string CreateOrUpdateContactInSalesForce(SalesForceContact contact, [Optional] string ID)
        {

            if (contact != null && !string.IsNullOrWhiteSpace(contact.Email))
            {
                WebRequest webRequest = null;
                SalesForceContactResponse salesForceContactResponse = null;
                string strTokenResponse = "";

                string restNewContactQuery = token.instance_url + "/services/data/v25.0/sobjects/Contact/" + ID;
                webRequest = (HttpWebRequest)System.Net.WebRequest.Create(restNewContactQuery);
                if (!string.IsNullOrWhiteSpace(ID))
                    webRequest.Method = "PATCH";
                else
                    webRequest.Method = "POST";

                webRequest.Headers.Add("Authorization", "Bearer " + token.access_token);
                webRequest.ContentType = "application/json; charset=utf-8";

                using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        RecordTypeId = "01290000000ewCxAAI",
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        Email = contact.Email,
                        Phone = contact.Phone,
                        MobilePhone = contact.MobilePhone,
                        HomePhone = contact.HomePhone,
                        PreferredWorkType__c = contact.PreferredWorkType__c, // TODO Contract/Temp  Permanent  Both
                        MailingCity = contact.MailingCity,
                        MailingCountry = contact.MailingCountry,
                        MailingPostalCode = contact.MailingPostalCode,
                        MailingState = contact.MailingState,
                        MailingStreet = contact.MailingStreet
                    });

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

                    }


                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    salesForceContactResponse = jss.Deserialize<SalesForceContactResponse>(strTokenResponse);

                    //Literal1.Text = Literal1.Text + "<br><hr>" + strTokenResponse;
                }

                if (salesForceContactResponse != null)
                    return salesForceContactResponse.id;
            }

            return string.Empty;
        }


        #region Save Member

        public bool SaveMember(SalesForceContact salesForceContact, ref int memberid, ref string errormsg)
        {

            MembersService service = new MembersService();
            
            bool blnNewMember = false;
            bool blnValid = true;

            JXTPortal.Entities.Members member = service.GetBySiteIdEmailAddress(SessionData.Site.SiteId, salesForceContact.Email);
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
                member.SiteId = SessionData.Site.SiteId;
                member.FirstName = salesForceContact.FirstName;
                member.Surname = salesForceContact.LastName;
                member.EmailAddress = salesForceContact.Email;
                member.EmailFormat = (int)PortalEnums.Email.EmailFormat.HTML;
                member.Username = salesForceContact.Email; // Username would be the email address


                member.Address1 = salesForceContact.MailingStreet;
                member.Suburb = salesForceContact.MailingCity;
                member.States = salesForceContact.MailingState;
                member.PostCode = salesForceContact.MailingPostalCode;
                
                // Get the country
                // Find if the country name from AICD is found in the sitecountries.
                //int countryid = 1;
                if (!string.IsNullOrWhiteSpace(salesForceContact.MailingCountry))
                {
                    using (SiteCountries siteCountry = SiteCountriesService.GetBySiteId(SessionData.Site.SiteId)
                                                            .Where(s => s.SiteCountryName.ToLower() == salesForceContact.MailingCountry.ToLower()).FirstOrDefault())
                    {
                        if (siteCountry != null)
                        {
                            member.CountryId = siteCountry.CountryId;
                        }
                    }
                }

                // If country id doesn't exists then get the default country from Global settings - As country is compulsory.
                if (member.CountryId < 1)
                {
                    // If not set the Global default country set for the site.
                    using (TList<GlobalSettings> gslist = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
                    {
                        if (gslist.Count > 0)
                        {
                            if (gslist[0].DefaultCountryId.HasValue)
                            {
                                member.CountryId = gslist[0].DefaultCountryId.Value;
                            }
                        }
                    }
                }

                // Get the worktype
                if (!string.IsNullOrWhiteSpace(salesForceContact.Candidate_Types__c))
                {
                    using (TList<JXTPortal.Entities.SiteWorkType> siteWorkTypeList = SiteWorkTypeService.GetBySiteId(SessionData.Site.SiteId))
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
                if (blnNewMember)
                {
                    string newpassword = System.Web.Security.Membership.GeneratePassword(10, 0);
                    member.Password = CommonService.EncryptMD5(newpassword);
                    member.ValidateGuid = Guid.NewGuid();
                }

                member.SearchField = String.Format("{0} {1}",
                                                       member.FirstName,
                                                       member.Surname);
                member.Valid = true;
                member.Validated = false;
                member.LastModifiedDate = DateTime.Now; // Last Updated
                member.RequiredPasswordChange = false; // Don't change the password when you login.

                // Save the user
                if (blnNewMember)
                    service.Insert(member);
                else
                    service.Update(member);

                memberid = member.MemberId;

            }
            catch (Exception ex)
            {
                // Todo - Save to exception
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
            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
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


    }

    #region Sales Force Contact Class

    public class Attributes
    {
        public string type { get; set; }
        public string url { get; set; }
    }

    public class SalesForceContact
    {
        public Attributes attributes { get; set; }
        public string ID { get; set; }
        public string RecordTypeId { get; set; }
        public string LastModifiedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string PreferredWorkType__c { get; set; }
        public string Candidate_Types__c { get; set; }
        public string MailingCity { get; set; }
        public string MailingCountry { get; set; }
        public string MailingPostalCode { get; set; }
        public string MailingState { get; set; }
        public string MailingStreet { get; set; }
    }

    public class SalesForceContactObject
    {
        public int totalSize { get; set; }
        public bool done { get; set; }
        public List<SalesForceContact> records { get; set; }
    }

    #endregion

    #region Sales force contact response

    public class SalesForceContactResponse
    {
        public string id { get; set; }
        public bool success { get; set; }
        public List<object> errors { get; set; }
    }
    
    #endregion


    public class TokenResponse
    {

        public string id { get; set; }
        public string issued_at { get; set; }
        public string refresh_token { get; set; }
        public string instance_url { get; set; }
        public string signature { get; set; }
        public string access_token { get; set; }

    }

    public class SalesforceException : Exception
    {
        public SalesforceException(string message, Exception innerException)
            : base(message, innerException) { }
    }


}



/*
 - Get last modified - Get a List of Updated Records Within a Given Timeframe -  http://www.salesforce.com/us/developer/docs/api_rest/index_Left.htm#StartTopic=Content/dome_get_updated.htm 
 
 
 
 */