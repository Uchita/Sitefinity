using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPosterTransform.Library.APIs.Invenias
{

    public class InveniasSettings
    {
        public string ClientID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RESTAuthToken { get; set; }
    }


    public class InveniaTokenRequest
    {
        public InveniaTokenRequest(string Grant_Type, string Username, string Password, string Client_ID)
        {
            grant_type = Grant_Type;
            username = Username;
            password = Password;
            Client_ID = client_id;
        }

        public string grant_type { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string client_id { get; set; }
    }

    public class InveniaTokenResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
    }


    public class InveniasAdvertisementsValue
    {
        public string ApplicationsEmail { get; set; }
        public string AutoUnpublishDate { get; set; }
        public string Benefits { get; set; }
        public string BoardEx { get; set; }
        public string Broadbean { get; set; }
        public string CompanyProfileFieldId { get; set; }
        public string CreatorId { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string DatePromoted { get; set; }
        public string DatePublished { get; set; }
        public string DateUnpublished { get; set; }
        public string DescriptionFieldId { get; set; }
        public string EmploymentType { get; set; }
        public string ExternalId1 { get; set; }
        public string ExternalId2 { get; set; }
        public string ExternalId3 { get; set; }
        public string Facebook { get; set; }
        public string Id { get; set; }
        public string IsBenefitsVisible { get; set; }
        public string IsCompanyLogoVisible { get; set; }
        public string IsCompanyProfileVisible { get; set; }
        public string IsPackagesRatesVisible { get; set; }
        public string IsPrimaryBusinessPhoneVisible { get; set; }
        public string IsPrimaryEmailVisible { get; set; }
        public string IsPrimaryJobTitleVisible { get; set; }
        public string IsPrimaryMobilePhoneVisible { get; set; }
        public string IsSecondaryBusinessPhoneVisible { get; set; }
        public string IsSecondaryEmailVisible { get; set; }
        public string IsSecondaryJobTitleVisible { get; set; }
        public string IsSecondaryMobilePhoneVisible { get; set; }
        public string LinkedIn { get; set; }
        public string ModifierId { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }
        public string PrimaryBusinessPhone { get; set; }
        public string PrimaryEmail { get; set; }
        public string PrimaryJobTitle { get; set; }
        public string PrimaryMobilePhone { get; set; }
        public string PromotedBy { get; set; }
        public string PublishedBy { get; set; }
        public string ReferenceNumber { get; set; }
        public string SecondaryBusinessPhone { get; set; }
        public string SecondaryEmail { get; set; }
        public string SecondaryJobTitle { get; set; }
        public string SecondaryMobilePhone { get; set; }
        public string Status { get; set; }
        public string Summary { get; set; }
        public string Twitter { get; set; }
        public string UnpublishedBy { get; set; }
        public string UseGenericEmail { get; set; }
        public string WebPage { get; set; }
        public string XING { get; set; }
    }

    public class InveniasAdvertisementsRoot
    {
        public List<InveniasAdvertisementsValue> value { get; set; }
    }

}
