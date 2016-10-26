using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace JXTPortal.Entities.Models
{
    public class AdminIntegrations
    {
        public class Integrations
        {
            public Facebook Facebook { get; set; }
            //public Twitter Twitter { get; set; }
            public Google Google { get; set; }
            public GoogleMap GoogleMap {get;set;}
            public Indeed Indeed { get; set; }
            public Dropbox Dropbox { get; set; }
            public GoogleDrive GoogleDrive { get; set; }
            public Seek Seek { get; set; }
            public Salesforce Salesforce { get; set; }
            public Bullhorn Bullhorn { get; set; }
            public BullhornOnBoardingSSO BullhornOnBoardingSSO { get; set; }
            public Invenias Invenias { get; set; }
        }

        [Description("Facebook Settings")]
        public class Facebook
        {
            [Description("FB Application ID")]
            public string ApplicationID { get; set; }
            [Description("FB Application Secret")]
            public string ApplicationSecret { get; set; }
            [ScriptIgnore]
            public bool Valid { get; set; }
        }

        [Description("Twitter Settings")]
        public class Twitter
        {
            [Description("Twitter Consumer Key")]
            public string ConsumerKey { get; set; }
            [Description("Twitter Consumer Secret")]
            public string ConsumerSecret { get; set; }
            [ScriptIgnore]
            public bool Valid { get; set; }
        }

        [Description("Google Settings")]
        public class Google
        {
            [Description("Google Client ID")]
            public string ClientID { get; set; }
            [Description("Google Client Secret")]
            public string ClientSecret { get; set; }
            [Description("Google API Key")]
            public string APIKey { get; set; }
            [ScriptIgnore]
            public bool Valid { get; set; }
        }

        [Description("Google Maps API Settings")]
        public class GoogleMap
        {
            [Description("Google API ID")]
            public string ServerKey { get; set; }
            [ScriptIgnore]
            public bool Valid { get; set; }
        }


        [Description("Indeed Settings")]
        public class Indeed
        {
            [Description("Indeed API Token")]
            public string APIToken { get; set; }
            [Description("Indeed API Secret")]
            public string APISecret { get; set; }
            [ScriptIgnore]
            public bool Valid { get; set; }
        }

        [Description("Dropbox Settings")]
        public class Dropbox
        {
            [Description("Dropbox Application ID")]
            public string ApplicationID { get; set; }
            [Description("Dropbox Application Secret")]
            public string ApplicationSecret { get; set; }
            [ScriptIgnore]
            public bool Valid { get; set; }
        }

        [Description("Google Drive Settings")]
        public class GoogleDrive
        {
            [Description("Google Drive Client ID")]
            public string ApplicationID { get; set; }
            [Description("Google Drive API Key")]
            public string ApplicationSecret { get; set; }
            [ScriptIgnore]
            public bool Valid { get; set; }
        }

        [Description("Seek Settings")]
        public class Seek
        {
            [Description("Seek Client ID")]
            public string ClientID { get; set; }
            [Description("Seek Client Secret")]
            public string ClientSecret{ get; set; }
            [Description("Advertiser ID")]
            public string AdvertiserID { get; set; }
            [ScriptIgnore]
            public bool Valid { get; set; }
        }

        [Description("Salesforce Settings")]
        public class Salesforce
        {
            [Description("Salesforce Client Key")]
            public string ClientID { get; set; }
            [Description("Salesforce Client Secret")]
            public string ClientSecret { get; set; }
            [Description("Salesforce Login Username")]
            public string ClientUsername { get; set; }
            [Description("Salesforce Login Password")]
            public string ClientPassword { get; set; }
            [Description("Salesforce OAuth Token Request Path")]
            public string TokenURL { get; set; }
            [Description("Candidate RecordTypeID")]
            public string RecordTypeID { get; set; }
            [Description("Candidate AccountID")]
            public string AccountID { get; set; }
            [ScriptIgnore]
            public bool Valid { get; set; }
        }

        [Description("Bullhorn Settings")]
        public class Bullhorn
        {
            [Description("Bullhorn REST Client Key")]
            public string ClientKey { get; set; }
            [Description("Bullhorn REST Client Secret")]
            public string ClientSecret { get; set; }

            [Description("Bullhorn REST Auth Token")]
            [ReadOnly(true)]
            public string RESTAuthToken { get; set; }
            [Description("Bullhorn REST Auth Refresh Token")]
            [ReadOnly(true)]
            [IncludeButton("btn btn-primary", "Reset REST Tokens", "BullhornTokenReset(this);")]
            public string RESTAuthRefreshToken { get; set; }

            [Description("Bullhorn Login Username")]
            public string ClientUsername { get; set; }
            [Description("Bullhorn Login Password")]
            public string ClientPassword { get; set; }

            [Description("Bullhorn SOAP API Key")]
            public string ClientSoapKey { get; set; }
            [Description("Bullhorn SOAP API Secret")]
            public string ClientSoapSecret { get; set; }

            [Description("Default Advertiser User ID")]
            public int DefaultAdvertiserUserID { get; set; }

            [Description("Is Live")]
            public bool isLive { get; set; }

            [ScriptIgnore]
            public bool Valid { get; set; }

            [Description("Enable Candidate Sync **")]
            public bool EnableCandidateSync { get; set; }

            [Description("Enable Advertiser Sync **")]
            public bool EnableAdvertiserSync { get; set; }

            public bool HasFilledAllCredentials()
            {
                if (string.IsNullOrEmpty(ClientKey)
                    || string.IsNullOrEmpty(ClientSecret)
                    || string.IsNullOrEmpty(RESTAuthToken)
                    || string.IsNullOrEmpty(RESTAuthRefreshToken)
                    || string.IsNullOrEmpty(ClientUsername)
                    || string.IsNullOrEmpty(ClientPassword)
                    || string.IsNullOrEmpty(ClientSoapKey)
                    || string.IsNullOrEmpty(ClientSoapSecret)
                    || DefaultAdvertiserUserID == 0)
                    return false;
                return true;
            }
        }


        [Description("Bullhorn OnBoarding SSO (enable candidate sync)")]
        public class BullhornOnBoardingSSO
        {
            [Description("On Boarding API URL")]
            public string OnBoardingAPIURL { get; set; }
            [Description("REST API Integration Key")]
            public string APIIntegrationKey { get; set; }
            [Description("On Boarding Redirect URL")]
            public string OnBoardingRedirectURL { get; set; }
            [ScriptIgnore]
            public bool Valid { get; set; }
        }


        [Description("Invenias Settings")]
        public class Invenias
        {
            [Description("Invenias ClientID")]
            public string ClientID { get; set; }
            [Description("Invenias Username")]
            public string Username { get; set; }
            [Description("Invenias Password")]
            public string Password { get; set; }
            [Description("Invenias REST Token")]
            [ReadOnly(true)]
            public string RESTAuthToken { get; set; }
            [Description("Invenias REST Refresh Token")]
            [ReadOnly(true)]
            public string RESTAuthRefreshToken { get; set; }
            [Description("Enable")]
            public bool Valid { get; set; }
        }

    }

    #region Facebook Models

    public class FacebookToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; } //seconds
    }

    public class FacebookUserDetails
    {
        public string id { get; set; }
        public string birthday { get; set; }
        public List<FBEducation> education { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public FacebookIDNameObj location { get; set; }
        public string name { get; set; }
        public bool verified { get; set; }
        public List<FBWorkPlace> work { get; set; }

    }

    public class FacebookIDNameObj
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class FBEducation
    {
        public FacebookIDNameObj school { get; set; }
        public FacebookIDNameObj year { get; set; }
        public string type { get; set; }
    }

    public class FBWorkPlace
    {
        public FacebookIDNameObj employer { get; set; }
        public FacebookIDNameObj location { get; set; }
        public FacebookIDNameObj position { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
    }

    #endregion

    #region Google Models

    public class GoogleToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string id_token { get; set; }
    }

    public class GoogleUser
    {
        public string id { get; set; }
        public string email { get; set; }
        public bool verified_email { get; set; }
        public string name { get; set; }
        public string given_name { get; set; }
        public string family_name { get; set; }
        public string link { get; set; }
        public string gender { get; set; }
        public string hd { get; set; }
    }

    #endregion

    #region LinkedIn Models

    [XmlRoot("person")]
    public class LinkedInProfile
    {
        public string id { get; set; }

        [XmlElement(ElementName = "first-name")]
        public string firstName { get; set; }
        [XmlElement(ElementName = "last-name")]
        public string lastName { get; set; }

        //[XmlElement(ElementName = "picture-url")]
        //public string pictureURL { get; set; }

        [XmlElement(ElementName = "picture-urls")]
        public pictureURLs pictureURLs { get; set; }

        public string headline { get; set; }

        public string summary { get; set; }

        public List<education> educations { get; set; }

        public string industry { get; set; }

        public string interests { get; set; }

        public List<language> languages { get; set; }

        public List<position> positions { get; set; }

        public List<skill> skills { get; set; }

        public List<certification> certifications { get; set; }

        [XmlArray("three-current-positions")]
        public List<position> threeCurrentPositions { get; set; }

        [XmlArray("three-past-positions")]
        public List<position> threePastPositions { get; set; }

        [XmlElement("date-of-birth")]
        public DateField dateOfBirth { get; set; }

    }

    public class pictureURLs
    {
        [XmlElement("picture-url")]
        public List<string> pictureURL { get; set; }
    }

    public class position
    {
        public int id { get; set; }
        public string title { get; set; }
        [XmlElement("start-date")]
        public DateField startDate { get; set; }

        [XmlElement("end-date")]
        public DateField endDate { get; set; }

        [XmlElement("is-current")]
        public bool isCurrent { get; set; }

        public company company { get; set; }
    }

    public class company
    {
        public int id { get; set; }
        public string name { get; set; }
        public string size { get; set; }
        public string type { get; set; }
        public string industry { get; set; }

    }

    public class education
    {
        public int id { get; set; }
        [XmlElement("school-name")]
        public string schoolName { get; set; }
        public string degree { get; set; }
        [XmlElement("field-of-study")]
        public string studyField { get; set; }
        [XmlElement("start-date")]
        public DateField startDate { get; set; }
        [XmlElement("end-date")]
        public DateField finishDate { get; set; }

        public string activities { get; set; }
        public string notes { get; set; }
    }

    public class DateField
    {
        public int? year { get; set; }
        public int? month { get; set; }
        public int? day { get; set; }
    }

    public class skill
    {
        public int id { get; set; }
        public string name { get; set; }
        [XmlElement("skill")]
        public skill skillName { get; set; }
    }


    public class language
    {
        public int id { get; set; }
        public string name { get; set; }
        [XmlElement("language")]
        public language languageName { get; set; }
        public proficiency proficiency { get; set; }

    }

    //for language
    public class proficiency
    {
        public string level { get; set; }
        public string name { get; set; }
    }

    public class certification
    {
        public int id { get; set; }
        public string name { get; set; }
        public authority authority { get; set; }
        public string number { get; set; }
        [XmlElement("start-date")]
        public DateField startDate { get; set; }
        [XmlElement("end-date")]
        public DateField finishDate { get; set; }
    }

    //for certification
    public class authority
    {
        public string name { get; set; }
    }

#endregion

}
