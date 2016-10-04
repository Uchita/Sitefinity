using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Client.Salesforce
{
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
        public string OtherCity { get; set; }
        public string OtherCountry { get; set; }
        public string OtherPostalCode { get; set; }
        public string OtherState { get; set; }
        public string OtherStreet { get; set; }

    }

    public class SalesForceContactObject
    {
        public int totalSize { get; set; }
        public bool done { get; set; }
        public List<SalesForceContact> records { get; set; }
    }

    #endregion

    #region Sales force response

    public class SalesForceTransactionResponse
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
