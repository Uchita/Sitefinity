using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Reflection;
using System.Runtime.Serialization;

namespace JXTPortal.Client.Bullhorn
{
    public class JXTPlatformMappingModel : BullhornRESTModels.Candidate
    {

    }

    public class BullhornRESTModels
    {
        public class BullhornCandidateGetResponse
        {
            public Candidate data { get; set; }
        }

        public class Candidate
        {
            public string id { get; set; }
            public Address address { get; set; }
            public JXTPortal.Client.Bullhorn.BullhornRESTAPI.category category { get; set; }
            public string certifications { get; set; }
            public string comments { get; set; }
            public string companyName { get; set; }
            public string companyURL { get; set; }
            public string customDate1 { get; set; }
            public string customDate2 { get; set; }
            public string customDate3 { get; set; }
            public string customFloat1 { get; set; }
            public string customFloat2 { get; set; }
            public string customFloat3 { get; set; }
            public string customInt1 { get; set; }
            public string customInt2 { get; set; }
            public string customInt3 { get; set; }
            public string customText1 { get; set; }
            public string customText10 { get; set; }
            public string customText11 { get; set; }
            public string customText12 { get; set; }
            public string customText13 { get; set; }
            public string customText14 { get; set; }
            public string customText15 { get; set; }
            public string customText16 { get; set; }
            public string customText17 { get; set; }
            public string customText18 { get; set; }
            public string customText19 { get; set; }
            public string customText2 { get; set; }
            public string customText20 { get; set; }
            public string customText3 { get; set; }
            public string customText4 { get; set; }
            public string customText5 { get; set; }
            public string customText6 { get; set; }
            public string customText7 { get; set; }
            public string customText8 { get; set; }
            public string customText9 { get; set; }
            public string customTextBlock1 { get; set; }
            public string customTextBlock2 { get; set; }
            public string customTextBlock3 { get; set; }
            public string customTextBlock4 { get; set; }
            public string customTextBlock5 { get; set; }
            public string dateAdded { get; set; }
            public string dateAvailable { get; set; }
            public string dateAvailableEnd { get; set; }
            public string dateI9Expiration { get; set; }
            public string dateLastComment { get; set; }
            public string dateNextCall { get; set; }
            public string dateOfBirth { get; set; }
            public string dayRate { get; set; }
            public string dayRateLow { get; set; }
            public string degreeList { get; set; }
            public string description { get; set; }
            public string desiredLocations { get; set; }
            public string disability { get; set; }
            public string educationDegree { get; set; }
            public string email { get; set; }
            public string email2 { get; set; }
            public string email3 { get; set; }
            public string employeeType { get; set; }
            public string employmentPreference { get; set; }
            public string ethnicity { get; set; }
            public string experience { get; set; }
            public string externalID { get; set; }
            public string fax { get; set; }
            public string fax2 { get; set; }
            public string fax3 { get; set; }
            public string federalAddtionalWitholdingsAmount { get; set; }
            public string federalExemptions { get; set; }
            public string federalFilingStatus { get; set; }
            public string firstName { get; set; }
            public string gender { get; set; }
            public string hourlyRate { get; set; }
            public string hourlyRateLow { get; set; }
            public string i9OnFile { get; set; }
            private bool _isDayLightSavings = false;
            public bool isDayLightSavings { get { return _isDayLightSavings; } set { _isDayLightSavings = value; } }
            public string isDeleted { get; set; }
            public string isEditable { get; set; }
            public string isLockedOut { get; set; }
            public string lastName { get; set; }
            public string linkedPerson { get; set; }
            public string localAddtionalWitholdingsAmount { get; set; }
            public string localExemptions { get; set; }
            public string localFilingStatus { get; set; }
            public string localTaxCode { get; set; }
            private bool _massMailOptOut = true;
            public bool massMailOptOut { get { return _massMailOptOut; } set { _massMailOptOut = value; } }
            public string middleName { get; set; }
            public string migrateGUID { get; set; }
            public string mobile { get; set; }
            public string name { get { return firstName + " " + lastName; } set { } }
            public string namePrefix { get; set; }
            public string nameSuffix { get; set; }
            public string nickName { get; set; }
            public string numCategories { get; set; }
            public string numOwners { get; set; }
            public string occupation { get; set; }
            public string owner { get; set; }
            public string pager { get; set; }
            public string paperWorkOnFile { get; set; }
            public string password { get; set; }
            public string phone { get; set; }
            public string phone2 { get; set; }
            public string phone3 { get; set; }
            public string preferredContact { get; set; }
            public string recentClientList { get; set; }
            public string referredBy { get; set; }
            public string referredByPerson { get; set; }
            public string salary { get; set; }
            public string salaryLow { get; set; }
            public string skillSet { get; set; }
            public string smsOptIn { get; set; }
            public string source { get; set; }
            public string ssn { get; set; }
            public string stateAddtionalWitholdingsAmount { get; set; }
            public string stateExemptions { get; set; }
            public string stateFilingStatus { get; set; }
            public string status { get; set; }
            public string taxID { get; set; }
            public string taxState { get; set; }
            private int _timeZoneOffsetEST = 0;
            public int timeZoneOffsetEST { get { return _timeZoneOffsetEST; } set { _timeZoneOffsetEST = value; } }
            public string travelLimit { get; set; }
            public string type { get; set; }
            public string username { get; set; }
            public string veteran { get; set; }
            public string willRelocate { get; set; }
            public string workAuthorized { get; set; }
            public string workPhone { get; set; }

            public Candidate()
            {
                address = new Address();
            }

            /* One To Many Fields Below */
            public string businessSectors { get; set; }
            public string categories { get; set; }
            public string certificationList { get; set; }
            public string clientCorporationBlackList { get; set; }
            public string clientCorporationWhiteList { get; set; }
            public string educations { get; set; }
            public string fileAttachments { get; set; }
            public string interviews { get; set; }
            public string notes { get; set; }
            public string placements { get; set; }
            public string primarySkills { get; set; }
            public string references { get; set; }
            public string secondaryAddress { get; set; }
            public string secondaryOwners { get; set; }
            public string secondarySkills { get; set; }
            public string sendouts { get; set; }
            public string specialties { get; set; }
            public string submissions { get; set; }
            public string tasks { get; set; }
            public string webResponses { get; set; }
            public string workHistories { get; set; }

            public string GenerateJson()
            {
                //Generate and return json string for fields that are NOT null

                Dictionary<string, object> dict = new Dictionary<string,object>();                

                foreach (PropertyInfo pInfo in this.GetType().GetProperties())
                {
                    object thisfieldObject = pInfo.GetValue(this, null);

                    if (thisfieldObject != null)
                    {
                        dict.Add(pInfo.Name, thisfieldObject);
                    }
                }

                JavaScriptSerializer ser = new JavaScriptSerializer();
                string json = ser.Serialize(dict);

                return json;
            }


        }

        public class Education
        {
            public string id { get; set; }
            public string candidate { get; set; }
            public string certification { get; set; }
            public string city { get; set; }
            public string comments { get; set; }
            public long customDate1 { get; set; }
            public long customDate2 { get; set; }
            public long customDate3 { get; set; }
            public long customDate4 { get; set; }
            public long customDate5 { get; set; }
            public string customFloat1 { get; set; }
            public string customFloat2 { get; set; }
            public string customFloat3 { get; set; }
            public string customFloat4 { get; set; }
            public string customFloat5 { get; set; }
            public string customInt1 { get; set; }
            public string customInt2 { get; set; }
            public string customInt3 { get; set; }
            public string customInt4 { get; set; }
            public string customInt5 { get; set; }
            public string customText1 { get; set; }
            public string customText2 { get; set; }
            public string customText3 { get; set; }
            public string customText4 { get; set; }
            public string customText5 { get; set; }
            public string customTextBlock1 { get; set; }
            public string customTextBlock2 { get; set; }
            public string customTextBlock3 { get; set; }
            public string dateAdded { get; set; }
            public string degree { get; set; }
            public long endDate { get; set; }
            public string expirationDate { get; set; }
            private string _gpa;
            public string gpa { get { return _gpa == "NaN" ? null : _gpa; } set { _gpa = value; } }
            public long graduationDate { get; set; }
            public string isDeleted { get; set; }
            public string major { get; set; }
            public string migrateGUID { get; set; }
            public string school { get; set; }
            public long startDate { get; set; }
            public string state { get; set; }

            public string GenerateJson(int BHcandidateID)
            {
                //Generate and return json string for fields that are NOT null

                Dictionary<string, object> dict = new Dictionary<string, object>();

                //set candidate ID ref
                dict.Add("candidate", new { id = BHcandidateID });

                foreach (PropertyInfo pInfo in this.GetType().GetProperties())
                {
                    object thisfieldObject = pInfo.GetValue(this, null);

                    if (thisfieldObject != null)
                    {
                        dict.Add(pInfo.Name, thisfieldObject);
                    }
                }

                JavaScriptSerializer ser = new JavaScriptSerializer();
                string json = ser.Serialize(dict);

                return json;
            }
        }

        //public class Reference
        //{
        //    public string id { get; set; }
        //    public string candidate { get; set; }
        //    public string candidateTitle { get; set; }
        //    public string clientCorporation { get; set; }
        //    public string companyName { get; set; }
        //    public string customDate1 { get; set; }
        //    public string customDate2 { get; set; }
        //    public string customDate3 { get; set; }
        //    public string customDate4 { get; set; }
        //    public string customDate5 { get; set; }
        //    public string customFloat1 { get; set; }
        //    public string customFloat2 { get; set; }
        //    public string customFloat3 { get; set; }
        //    public string customFloat4 { get; set; }
        //    public string customFloat5 { get; set; }
        //    public string customInt1 { get; set; }
        //    public string customInt2 { get; set; }
        //    public string customInt3 { get; set; }
        //    public string customInt4 { get; set; }
        //    public string customInt5 { get; set; }
        //    public string customMigrateGUID { get; set; }
        //    public string customText1 { get; set; }
        //    public string customText2 { get; set; }
        //    public string customText3 { get; set; }
        //    public string customText4 { get; set; }
        //    public string customText5 { get; set; }
        //    public string customTextBlock1 { get; set; }
        //    public string customTextBlock2 { get; set; }
        //    public string customTextBlock3 { get; set; }
        //    public string dateAdded { get; set; }
        //    public string employmentEnd { get; set; }
        //    public string employmentStart { get; set; }
        //    public string isDeleted { get; set; }
        //    public string jobOrder { get; set; }
        //    public string migrateGUID { get; set; }
        //    public string referenceClientContact { get; set; }
        //    public string referenceEmail { get; set; }
        //    public string referenceFirstName { get; set; }
        //    public string referenceLastName { get; set; }
        //    public string referencePhone { get; set; }
        //    public string referenceTitle { get; set; }
        //    public string responses { get; set; }
        //    public string status { get; set; }
        //    public string yearsKnown { get; set; }
        //}

        public class WorkHistory
        {
            public string id { get; set; }
            public string bonus { get; set; }
            public string candidate { get; set; }
            public string clientCorporation { get; set; }
            public string comments { get; set; }
            public string commission { get; set; }
            public string companyName { get; set; }
            public long customDate1 { get; set; }
            public long customDate2 { get; set; }
            public long customDate3 { get; set; }
            public long customDate4 { get; set; }
            public long customDate5 { get; set; }
            public string customFloat1 { get; set; }
            public string customFloat2 { get; set; }
            public string customFloat3 { get; set; }
            public string customFloat4 { get; set; }
            public string customFloat5 { get; set; }
            public string customInt1 { get; set; }
            public string customInt2 { get; set; }
            public string customInt3 { get; set; }
            public string customInt4 { get; set; }
            public string customInt5 { get; set; }
            public string customText1 { get; set; }
            public string customText2 { get; set; }
            public string customText3 { get; set; }
            public string customText4 { get; set; }
            public string customText5 { get; set; }
            public string customTextBlock1 { get; set; }
            public string customTextBlock2 { get; set; }
            public string customTextBlock3 { get; set; }
            public string dateAdded { get; set; }
            public long endDate { get; set; }
            public string isDeleted { get; set; }
            public string isLastJob { get; set; }
            public string jobOrder { get; set; }
            public string migrateGUID { get; set; }
            public string placement { get; set; }
            public string salary1 { get; set; }
            public string salary2 { get; set; }
            public string salaryType { get; set; }
            public long startDate { get; set; }
            public string terminationReason { get; set; }
            public string title { get; set; }

            public string GenerateJson(int BHcandidateID)
            {
                //Generate and return json string for fields that are NOT null

                Dictionary<string, object> dict = new Dictionary<string, object>();

                //set candidate ID ref
                dict.Add("candidate", new { id = BHcandidateID });

                foreach (PropertyInfo pInfo in this.GetType().GetProperties())
                {
                    object thisfieldObject = pInfo.GetValue(this, null);

                    if (thisfieldObject != null)
                    {
                        dict.Add(pInfo.Name, thisfieldObject);
                    }
                }

                JavaScriptSerializer ser = new JavaScriptSerializer();
                string json = ser.Serialize(dict);

                return json;
            }
        }

        public class Address
        {
            public string address1 { get; set; }
            public string address2 { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string zip { get; set; }
            public int? countryID { get; set; }
        }

        public class Category
        {
            public int id { get; set; }
            public float dateAdded { get; set; }
            public string description { get; set; }
            public bool enabled { get; set; }
            public string externalID { get; set; }
            public string name { get; set; }
            public string occupation { get; set; }

            //public List<Skills> skills { get; set; }
            //public List<Specialty> specialties { get; set; }

            //public class Skills
            //{
            //    public int id { get; set; }
            //    public string name { get; set; }
            //    public bool enabled { get; set; }
            //}

        }

        public class Specialty
        {
            public int id { get; set; }
            public long dateAdded { get; set; }
            public bool enabled { get; set; }
            public string name { get; set; }
            public ParentCategory parentCategory { get; set; }

            public class ParentCategory
            {
                public int id { get; set; }
                public string name { get; set; }
            }
        }

        public class ParseToCandidateResult
        {
            public Candidate candidate { get; set; }
            public List<Education> candidateEducation { get; set; }
            //public List<Reference> candidateReference { get; set; }
            public List<WorkHistory> candidateWorkHistory { get; set; }

            public List<string> skillList { get; set; }
        }

        public class PutResponse
        {
            public int changedEntityId { get; set; }
            public string changeType { get; set; }

            public string errorMsg { get; set; }
        }

        public class PostResponse
        {
            public int changedEntityId { get; set; }
            public string changeType { get; set; }
        }

        public class FileResponse
        {
            public int fileId { get; set; }
            public string changeType { get; set; }
        }

        public class ValueLabelItem
        {
            public int value { get; set; }
            public string label { get; set; }
        }

        public class CategoryQueryGetResponse : QueryGetResponseBase
        {
            public List<Category> data { get; set; }
        }

        public class SpecialtyQueryGetResponse : QueryGetResponseBase
        {
            public List<Specialty> data { get; set; }
        }

        public class QueryGetResponseBase
        {
            public int start { get; set; }
            public int count { get; set; }
        }

        public class OptionsGetResponse
        {
            public List<ValueLabelItem> data { get; set; }
        }


        public class OperationStack
        {
            public string Operation { get; set; }
            public string Status { get; set; }
            public string Data { get; set; }

            public OperationStack(string opName, string opStatus, string opData)
            {
                Operation = opName;
                Status = opStatus;
                Data = opData;
            }
        }

    }

}
