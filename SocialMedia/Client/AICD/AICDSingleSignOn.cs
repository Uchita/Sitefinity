using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Web;
using System.Web.Script.Serialization;

using JXTPortal.Data;
using JXTPortal.Data.SqlClient;
using JXTPortal;
using JXTPortal.Entities;
using log4net;

namespace SocialMedia.Client.AICD
{
    public class AICDSingleSignOn : System.Web.SessionState.IReadOnlySessionState
    {
        public ILog logger;
        public enum Method { GET, POST, PUT, DELETE };

        private string CLIENT_ID = "diropp";
        private string CLIENT_SECRET = "qzxb6c7pd7ujtriyqhPROD"; //"qzxb6c7pd7ujtriyqhQA";
        // ******** Remove all qa when going live.
        private string AuthorizeURL = "https://auth.companydirectors.com.au/auth/authorize/?client_id={0}&redirect_uri={1}&response_type=code&scope=https%3A%2F%2Fprofile.companydirectors.com.au%2Fapi%2Fcontact";
        //private string TokenURL = "https://auth.companydirectors.com.au/auth/token/?client_id={0}&client_secret={1}&redirect_uri={2}&grant_type=authorization_code&scope=https%3A%2F%2Fprofile.companydirectors.com.au%2Fapi%2Fcontact";

        // Tokens
        private string TokenURL = "https://auth.companydirectors.com.au/auth/token";
        private string TokenPostData = "client_id={0}&client_secret={1}&redirect_uri={2}&grant_type=authorization_code&scope=https%3A%2F%2Fprofile.companydirectors.com.au%2Fapi%2Fcontact&code={3}";

        private string ProfileURL = "https://profile.companydirectors.com.au/api/contact";

        private string RedirectURI = string.Empty;

        //private string CookieValue = "AICDAUTH";
        //private string AICD_COOKIE_DOMAIN = ".auth.companydirectors.com.au";

        public string LogoffURI = string.Empty;

        public string AicdSubscriptionURL = "http://www.companydirectors.com.au/Member-Services/Directorship-Opportunities"; //"http://websiteqa.companydirectors.com.au/Member-Services/Directorship-Opportunities"; 
        SessionSite SessionDataSite = null;

        public AICDSingleSignOn(bool isLive, SessionSite _SessionDataSite)
        {
            logger = LogManager.GetLogger(typeof(AICDSingleSignOn));

            SessionDataSite = _SessionDataSite;
            
            LogoffURI = string.Format("https://auth.companydirectors.com.au/user/logoff?returnurl=http://{0}{1}/member/login.aspx",
                                                    _SessionDataSite.WWWRedirect ? "www." : string.Empty, _SessionDataSite.SiteUrl);
            RedirectURI = string.Format("http://{0}{1}/member/aicd/login.aspx",
                                                        _SessionDataSite.WWWRedirect ? "www." : string.Empty, _SessionDataSite.SiteUrl);


            // Sandbox environment
            if (!isLive)
            {
                CLIENT_ID = "testdiropp";
                CLIENT_SECRET = "qzxb6c7pd7ujtriyqhQA";
                AuthorizeURL = "https://authqa.companydirectors.com.au/auth/authorize/?client_id={0}&redirect_uri={1}&response_type=code&scope=https%3A%2F%2Fprofileqa.companydirectors.com.au%2Fapi%2Fcontact";
                TokenURL = "https://authqa.companydirectors.com.au/auth/token";
                ProfileURL = "https://profileqa.companydirectors.com.au/api/contact";
                AicdSubscriptionURL = "http://websiteqa.companydirectors.com.au/Member-Services/Directorship-Opportunities";
                LogoffURI = string.Format("https://authqa.companydirectors.com.au/user/logoff?returnurl={0}://{1}/member/login.aspx",
                                                    HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Host);

                if (HttpContext.Current.Request.IsLocal)
                    RedirectURI = "http://localhost:49188/member/aicd/login.aspx";
                else
                    RedirectURI = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + "/member/aicd/login.aspx";
            }
        }

        /*
        public void Login(string code)
        {
            
            if (!string.IsNullOrWhiteSpace(CheckCookie()))
                GetTokenUrl(code);
            else
                GetAuthorizeUrl();
        }*/

        public string GetAuthorizeUrl()
        {
            string strResponse = string.Format(AuthorizeURL, CLIENT_ID, RedirectURI); //WebRequest

            return strResponse;
        }

        public bool GetTokenUrlAndSaveMember(string code, ref string strMessage, ref string strRedirectUrl)
        {
            string postData = string.Format(TokenPostData,
                                                CLIENT_ID, CLIENT_SECRET, RedirectURI, code);

            HttpWebRequest webRequest = null;
            StreamWriter requestWriter = null;
            StreamReader responseStreamReader = null;
            string strTokenResponse = "";
            bool blnValid = true;

            // 1. Get the Access Token
            webRequest = System.Net.WebRequest.Create(TokenURL) as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.ContentType = "application/x-www-form-urlencoded";

            requestWriter = new StreamWriter(webRequest.GetRequestStream());
            try
            {
                requestWriter.Write(postData);
            }
            catch (Exception ex)
            {
                // Save as exception 
                logger.Error(ex);

                blnValid = false;
                strMessage = ex.Message;
            }
            finally
            {
                requestWriter.Close();
                requestWriter = null;
            }

            if (blnValid)
            {
                try
                {
                    // 2. Get the response of the Access Token
                    responseStreamReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                    strTokenResponse = responseStreamReader.ReadToEnd();
                }
                catch (Exception ex)
                {
                    // Save as exception 
                    logger.Error(ex);

                    blnValid = false;
                    strMessage = ex.Message;
                }
                finally
                {
                    responseStreamReader = null;
                    webRequest = null;
                }
            }



            if (blnValid)
            {
                // 3. Get the access token from the Response
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Dictionary<string, string> oAuthResult = jss.Deserialize<Dictionary<string, string>>(strTokenResponse);
                string accessToken = oAuthResult["access_token"];   // Get the access token

                AICDMemberObject aicdMemberObject = null;
                try
                {
                    // 4. Use the access token to Request for the Member profile 
                    webRequest = (HttpWebRequest)System.Net.WebRequest.Create(ProfileURL);
                    webRequest.Method = "GET";
                    webRequest.Headers.Add("Authorization", "Bearer " + accessToken);
                    var response = (HttpWebResponse)webRequest.GetResponse();

                    // If the response is OK
                    if (response.StatusCode.ToString() == "OK")
                    {
                        // Get the response of the Member Profile.
                        Stream postStream = response.GetResponseStream();
                        responseStreamReader = new StreamReader(postStream);

                        strTokenResponse = responseStreamReader.ReadToEnd();

                        // Get Member details
                        jss = new JavaScriptSerializer();
                        aicdMemberObject = jss.Deserialize<AICDMemberObject>(strTokenResponse);

                        // Save the Member details
                        int memberid = 0;
                        if (aicdMemberObject != null)
                        {
                            // Validate if the Subscriber is a DO Subscriber 
                            if (aicdMemberObject.IsDOSubscriber || aicdMemberObject.IsStaff)
                            {
                                blnValid = SaveMember(SessionData.Site.SiteId, aicdMemberObject.Id, aicdMemberObject.Salutation, aicdMemberObject.FirstName, aicdMemberObject.LastName,
                                                aicdMemberObject.Email, aicdMemberObject.Addresses, aicdMemberObject.PhoneDetails, aicdMemberObject.Gender, aicdMemberObject.DOTransactionDate,
                                                ref memberid, ref strMessage);

                                if (blnValid) // Todo remove
                                    strMessage = strTokenResponse;
                            }
                            else
                            {
                                // Todo - redirect to subscription page.
                                strRedirectUrl = AicdSubscriptionURL;
                            }
                        }
                        else
                        {
                            // Todo
                        }

                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex);

                    blnValid = false;
                    strMessage = ex.Message;
                }
                finally
                {
                    responseStreamReader = null;
                    webRequest = null;
                }
            }


            return blnValid;
        }

        /*
        public string CheckCookie()
        {
            HttpCookie oCookie = new HttpCookie("AICDAUTH"); // HttpContext.Current.Request.Cookies.Get("AICDAUTH");
            oCookie.Domain = AICD_COOKIE_DOMAIN;
            oCookie.Path = "/";


            return oCookie.Value;
        }*/

        #region Common Functions

        /// <summary>
        /// Web Request Wrapper
        /// </summary>
        /// <param name="method">Http Method</param>
        /// <param name="url">Full url to the web resource</param>
        /// <param name="postData">Data to post in querystring format</param>
        /// <returns>The web server response.</returns>
        public string WebRequest(string url)
        {
            HttpWebRequest webRequest = null;
            string responseData = "";

            webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = "GET";
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.ContentType = "application/json";

            responseData = WebResponseGet(webRequest);

            webRequest = null;

            return responseData;

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

        #endregion

        #region Save Member

        public bool SaveMember(int siteid, string externalMemberId, string title, string firstname, string surname, string emailaddress,
                                Addresses addresses, PhoneDetails phoneDetails, string gender, string DOTransactionDate,
                                    ref int memberid, ref string errormsg)
        {
            MembersService service = new MembersService();
            SiteCountriesService siteCountriesService = new SiteCountriesService();

            // Set the hardcoded titles which we accept.
            List<string> titleList = new List<string>();
            titleList.Add("Mr");
            titleList.Add("Mrs");
            titleList.Add("Ms");
            titleList.Add("Miss");
            titleList.Add("Dr");
            titleList.Add("Professor");
            titleList.Add("Other");

            bool blnNewMember = false;
            bool blnValid = true;

            JXTPortal.Entities.Members member = service.GetBySiteIdEmailAddress(siteid, emailaddress);
            try
            {
                // Update the Member
                if (member != null)
                {

                    /*
                    // Login Orgin is missing
                    member.Valid = true;
                    member.RequiredPasswordChange = false;
                    member.FirstName = firstname;
                    member.Surname = surname;
                    service.Update(member);

                    SessionService.RemoveAdvertiserUser();
                    SessionService.SetMember(member);

                    return true;*/
                }
                else
                {
                    // Create a new Member
                    blnNewMember = true;

                    member = new Members();
                    member.RegisteredDate = DateTime.Now;
                }


                member.ExternalMemberId = externalMemberId; // Save the external memberid
                member.SiteId = siteid;
                member.FirstName = firstname;
                member.Surname = surname;
                member.EmailAddress = emailaddress;
                member.EmailFormat = (int)PortalEnums.Email.EmailFormat.HTML;
                member.Username = emailaddress; // Username would be the email address
                //member.CountryId = countryid;

                // Assign the title
                if (titleList.Contains(title))
                    member.Title = title;
                else
                    member.Title = "Other"; // If the salutation is not found then default it to Other.

                // According to the API - The API  provides numeric value, map 1= Male,   2= female
                if (gender == "2" || gender == "Female")
                    member.Gender = "F";
                else
                    member.Gender = "M";

                string countryName = string.Empty;
                if (addresses.Residential != null && addresses.Residential.IsPreferredAddress)
                {
                    member.Address1 = addresses.Residential.AddressLine1;
                    member.Address2 = addresses.Residential.AddressLine2;
                    member.Suburb = addresses.Residential.City;
                    member.States = addresses.Residential.State;
                    member.PostCode = addresses.Residential.PostalCode;
                    countryName = addresses.Residential.Country;
                }
                else if (addresses.Business != null && addresses.Business.IsPreferredAddress)
                {
                    member.Address1 = addresses.Business.AddressLine1;
                    member.Address2 = addresses.Business.AddressLine2;
                    member.Suburb = addresses.Business.City;
                    member.States = addresses.Business.State;
                    member.PostCode = addresses.Business.PostalCode;
                    countryName = addresses.Business.Country;
                }

                // Set the last Terms and conditions date.
                DateTime dt = new DateTime();
                // Only if we don't have the T&C Date
                if (!member.LastTermsAndConditionsDate.HasValue && DateTime.TryParse(DOTransactionDate, out dt) && dt > System.Data.SqlTypes.SqlDateTime.MinValue.Value)
                    member.LastTermsAndConditionsDate = dt;
                
                // Get the country
                // Find if the country name from AICD is found in the sitecountries.
                int countryid = 1;
                if (!string.IsNullOrWhiteSpace(countryName))
                {
                    using (SiteCountries siteCountry = siteCountriesService.GetBySiteId(siteid).Where(s => s.SiteCountryName.ToLower() == countryName.ToLower()).FirstOrDefault())
                    {
                        if (siteCountry != null)
                        {
                            countryid = siteCountry.CountryId;
                        }
                        else
                        {
                            // If not set the Global default country set for the site.
                            GlobalSettingsService gservice = new GlobalSettingsService();
                            using (TList<GlobalSettings> gslist = gservice.GetBySiteId(siteid))
                            {
                                if (gslist.Count > 0)
                                {
                                    if (gslist[0].DefaultCountryId.HasValue)
                                    {
                                        countryid = gslist[0].DefaultCountryId.Value;
                                    }
                                }
                            }
                        }
                    }
                }

                member.CountryId = countryid;

                /*
                PersonalMobile - map to Mobile
                BusinessMobile - Map to Mobile
                PersonalLandline  - map to phone (H)
                BusinessLandline - map to Work (H)
                None - map to all phones
                 */
                if (phoneDetails != null && phoneDetails.PreferredPhone != null && phoneDetails.PreferredPhone.PhoneType != null)
                {
                    switch (phoneDetails.PreferredPhone.PhoneType)
                    {
                        case "PersonalMobile":
                            member.MobilePhone = phoneDetails.PreferredPhone.PhoneNumber;
                            break;
                        case "BusinessMobile":
                            member.MobilePhone = phoneDetails.PreferredPhone.PhoneNumber;
                            break;
                        case "PersonalLandline":
                            member.HomePhone = phoneDetails.PreferredPhone.PhoneNumber;
                            break;
                        case "BusinessLandline":
                            member.WorkPhone = phoneDetails.PreferredPhone.PhoneNumber;
                            break;
                        case "None": // Todo - None - map to all phones
                            member.MobilePhone = phoneDetails.PreferredPhone.PhoneNumber;
                            break;
                        default:
                            break;
                    }
                }

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
                member.Validated = true;
                member.LastLogon = DateTime.Now; // When loggin in User - set the last login
                member.LastModifiedDate = DateTime.Now; // Last Updated
                member.RequiredPasswordChange = false; // Don't change the password when you login.

                // Save the user
                if (blnNewMember)
                    service.Insert(member);
                else
                    service.Update(member);

                // Logout the advertiser and login the member
                SessionService.RemoveAdvertiserUser();
                SessionService.SetMember(member);

            }
            catch (Exception ex)
            {
                logger.Error(ex);

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

    }

    #region JSON Class format

    public class AICDMemberObject
    {
        public string Email { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        public string Gender { get; set; }
        public string ContactType { get; set; }
        public bool IsDOSubscriber { get; set; }
        public string DOTransactionDate { get; set; }
        public bool IsStaff { get; set; }
        public Addresses Addresses { get; set; }
        public Phones Phones { get; set; }
        public string PreferredPhoneType { get; set; }
        public string PhoneType { get; set; }
        public PhoneDetails PhoneDetails { get; set; }
        public string Id { get; set; }
    }

    public class Residential
    {
        public string AddressType { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public bool IsPreferredAddress { get; set; }
        public bool IsBillToAddress { get; set; }
    }

    public class Business
    {
        public string AddressType { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public bool IsPreferredAddress { get; set; }
        public bool IsBillToAddress { get; set; }
    }

    public class Addresses
    {
        public Residential Residential { get; set; }
        public Business Business { get; set; }
    }

    public class Phones
    {
    }

    public class PreferredPhone
    {
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneTypeAsInt { get; set; }
    }

    public class PhoneDetails
    {
        public PreferredPhone PreferredPhone { get; set; }
    }

    public class MostRelevantRole
    {
        public bool IsMostRelavant { get; set; }
        public bool IsChairman { get; set; }
        public bool IsCompanySecretary { get; set; }
        public bool IsSoleOwnerDirector { get; set; }
        public bool IsNonEexecutiveDirectorMainProfession { get; set; }
        public string RoleCategory { get; set; }
        public string RoleType { get; set; }
        public string MostRelevantOrganisationType { get; set; }
        public string MostRelevantRoleType { get; set; }
        public string Industry { get; set; }
        public string OrganisationName { get; set; }
        public string BoardCommitteeType { get; set; }
        public string RemunerationType { get; set; }
        public string Id { get; set; }
    }

    #endregion

}


/*
 
 {
   "Email":"E2346760@CDQAcompanydirectors.com.au",
   "Salutation":"Mrs",
   "FirstName":"Jane",
   "LastName":"Thornton",
   "PreferredName":"Jane",
   "Gender":"Female",
   "Division":"NSW",
   "DateOfBirth":"1959-07-23T23:00:00+10:00",
   "ContactType":"Member",
   "IsDOSubscriber":true,
   "IsStaff":false,
   "Addresses":{
      "Residential":{
         "AddressType":"Residential",
         "AddressLine1":"3 Maitland Street",
         "City":"KILLARA",
         "State":"NSW",
         "Country":"AUSTRALIA",
         "PostalCode":"2071",
         "IsPreferredAddress":true,
         "IsBillToAddress":true
      },
      "Business":{  
         "AddressType":"Business",
         "AddressLine1":"PO Box 678",
         "City":"VICTORIA PARK",
         "State":"WA",
         "Country":"AUSTRALIA",
         "PostalCode":"6979",
         "IsPreferredAddress":true,
         "IsBillToAddress":true,
         "JobTitle":"Managing Director",
         "CompanyName":"Intlang Corporate Consulting Pty Ltd"
      }
   },
   "Phones":{

   },
   "PreferredPhoneType":"PersonalMobile",
   "PhoneType":"PersonalMobile",
   "PursuingProfessionalCareer":"No",
   "CurrentlySeekingDirectorships":"Yes, actively looking now",
   "Membership":{
      "Id":"c8b1f954be1ee4119cee00155d027efb",
      "MembershipGrade":"Member",
      "MembershipType":"Standard",
      "MembershipStatus":"Financial",
      "MembershipApprovalStatus":"Approved",
      "Domicile":"Australia",
      "CustomerId":"2346760",
      "DateOfBirth":"1959-07-23T23:00:00+10:00",
      "MembershipFeePaidByCompany":false,
      "ModifiedOn":"0001-01-01T00:00:00+11:00",
      "PaidThru":"2015-08-31T00:00:00+10:00",
      "CharacterQuestions":{

      }
   },
   "PhoneDetails":{
      "PreferredPhone":{
         "PhoneType":"PersonalMobile",
         "PhoneNumber":"0417 449 353",
         "PhoneTypeAsInt":0
      }
   },
   "DirectorshipRoles":[
      {
         "IsMostRelavant":false,
         "IsChairman":true,
         "IsCompanySecretary":false,
         "IsSoleOwnerDirector":false,
         "IsNonEexecutiveDirectorMainProfession":false,
         "RoleCategory":"Directorships",
         "RoleType":"Non-executive director",
         "MostRelevantOrganisationType":"Not-for-profit",
         "Industry":"",
         "OrganisationName":"War Memorial Hospital",
         "Id":"e2f6f740bd1ee4119cee00155d027efb"
      },
      {
         "IsMostRelavant":true,
         "IsChairman":false,
         "IsCompanySecretary":false,
         "IsSoleOwnerDirector":false,
         "IsNonEexecutiveDirectorMainProfession":true,
         "RoleCategory":"Directorships",
         "RoleType":"Non-executive director",
         "MostRelevantOrganisationType":"Not-for-profit",
         "MostRelevantRoleType":"Being a non-executive director is my main profession",
         "Industry":"",
         "OrganisationName":"UnitingCare NSW-ACT",
         "BoardCommitteeType":"Audit",
         "RemunerationType":"Paid director fees",
         "Id":"e0f6f740bd1ee4119cee00155d027efb"
      },
      {
         "IsMostRelavant":false,
         "IsChairman":false,
         "IsCompanySecretary":false,
         "IsSoleOwnerDirector":false,
         "IsNonEexecutiveDirectorMainProfession":false,
         "RoleCategory":"Directorships",
         "RoleType":"Non-executive director",
         "MostRelevantOrganisationType":"Small (1-9 employees)",
         "Industry":"",
         "OrganisationName":"Barrington Group",
         "RemunerationType":"Paid director fees",
         "Id":"e3f6f740bd1ee4119cee00155d027efb"
      }
   ],
   "NonDirectorRoles":[

   ],
   "MostRelevantRole":{
      "IsMostRelavant":true,
      "IsChairman":false,
      "IsCompanySecretary":false,
      "IsSoleOwnerDirector":false,
      "IsNonEexecutiveDirectorMainProfession":true,
      "RoleCategory":"Directorships",
      "RoleType":"Non-executive director",
      "MostRelevantOrganisationType":"Not-for-profit",
      "MostRelevantRoleType":"Being a non-executive director is my main profession",
      "Industry":"",
      "OrganisationName":"UnitingCare NSW-ACT",
      "BoardCommitteeType":"Audit",
      "RemunerationType":"Paid director fees",
      "Id":"e0f6f740bd1ee4119cee00155d027efb"
   },
   "AssessmentTaskRegistrations":[

   ],
   "Interests":{
      "AssessingCompanyPerformance":false,
      "AuditCommittees":true,
      "BoardDiversity":true,
      "Compliance":true,
      "CorporateSocialResponsibility":false,
      "DirectorAndExecutiveRemuneration":false,
      "DirectorCompetencyAndSkills":true,
      "DutiesAndResponsibilitiesOfDirectors":false,
      "FindingBoardPositions":true,
      "IdentificationManagementAndTolerance":true,
      "ImprovingBoardPerformance":true,
      "IndigeneousGovernance":false,
      "InformationTechnology":true,
      "InterpretingFinancialReports":false,
      "LawsEffectingDirectors":false,
      "ListedCompanyGovernance":false,
      "MergersAndAcquisition":false,
      "NotForProfitGovernance":false,
      "PublicSectorGovernance":false,
      "RaisingCapital":false,
      "SmallBusinessGovernance":false,
      "Strategy":true,
      "Taxation":false
   },
   "DpdInfo":{
      "DpdParticipation":true,
      "DpdStartDate":"2014-08-08T00:00:00+10:00"
   },
   "ProfessionalOrganisationsAssociations":{
      "CPA":false,
      "CSA":false,
      "EA":false,
      "ICAA":false,
      "MSLS":false,
      "POOF":false,
      "IDPF":false
   },
   "CareerHistory":{
      "FirstBecameDirectorYear":2006,
      "FirstReportedToBoardYear":1999
   },
   "Subscriptions":{
      "CDMagzineByPost":false,
      "BoardroomReportNewsletterByEmail":false,
      "CDAmExCardInfo":false,
      "AnnualReportByPost":false
   },
   "CommunicationDetails":{
      "AllowInformationEmail":false,
      "AllowPromotionEmail":false,
      "AllowToContact":false
   },
   "Notes":[

   ],
   "PAEADetails":{
      "AllowToContact":false
   },
   "AllowMemberContentAccess":false,
   "CreatedDate":"0001-01-01T00:00:00+11:00",
   "LastActivityDate":"0001-01-01T00:00:00+11:00",
   "LastLockoutDate":"0001-01-01T00:00:00+11:00",
   "LastLoginDate":"0001-01-01T00:00:00+11:00",
   "Id":"2346760"
}
 */