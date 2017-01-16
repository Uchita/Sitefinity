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

    public class JXTCLAModel
    {
        public string CountryName { get; set; }
        public string LocationName { get; set; }
        public string AreaName { get; set; }
    }

    public class JXTPRModel
    {
        public string ProfessionName { get; set; }
        public string RoleName { get; set; }
    }

    public class InveniasValueRoot<T>
    {
        public List<T> value { get; set; }
    }

    #region Advertisement
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
        public bool IsPrimaryEmailVisible { get; set; }
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
        public bool UseGenericEmail { get; set; }
        public string WebPage { get; set; }
        public string XING { get; set; }
    }

    public class InveniasAdvertisementsRoot
    {
        public List<InveniasAdvertisementsValue> value { get; set; }
    }
    #endregion

    #region Assignment

    public class InveniasAssignmentValue
    {
        public string AssignmentBriefFieldId { get; set; }
        public string AssignmentNumber { get; set; }
        public string AssignmentValue { get; set; }
        public string AssignmentValueCurrency { get; set; }
        public string AssignmentValueManualMode { get; set; }
        public string AverageMargin { get; set; }
        public string AverageMarginCurrency { get; set; }
        public string AverageMarginPeriod { get; set; }
        public string Benefits { get; set; }
        public string BillablePackage { get; set; }
        public string BillablePackageCurrency { get; set; }
        public string BillingCurrency { get; set; }
        public string BodyFieldId { get; set; }
        public bool CandidateExpensesPaid { get; set; }
        public string CandidateNoticePeriod { get; set; }
        public string ClientNoticePeriod { get; set; }
        public string CreatorId { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string Duration { get; set; }
        public string EngagementType { get; set; }
        public string ExternalAssignmentBriefFieldId { get; set; }
        public string ExternalId1 { get; set; }
        public string ExternalId2 { get; set; }
        public string ExternalId3 { get; set; }
        public string ExternalRef { get; set; }
        public string FeePercentage { get; set; }
        public string FeeType { get; set; }
        public string ForecastDate { get; set; }
        public string Id { get; set; }
        public string InternalComments { get; set; }
        public string InternalRef { get; set; }
        public bool IsContract { get; set; }
        public bool IsContractSessionBased { get; set; }
        public bool IsNonExec { get; set; }
        public bool IsPermanent { get; set; }
        public string ModifierId { get; set; }
        public string Name { get; set; }
        public string NumberOfSessions { get; set; }
        public string OwnerId { get; set; }
        public string PaymentTerms { get; set; }
        public string PositionsCount { get; set; }
        public string PurchaseOrder { get; set; }
        public string Status { get; set; }
        public string TotalFee { get; set; }
        public string TotalFeeCurrency { get; set; }
        public string Weighting { get; set; }
    }

    public class InveniasAssignmentsRoot
    {
        public List<InveniasAssignmentValue> value { get; set; }
    }

    #endregion

    #region Company

    public class InveniasCompanyValue
    {
       //public string AccountsPhone { get; set; }
       //public string BoardEx { get; set; }
       //public string BodyFieldId { get; set; }
       //public string BusinessPhone2 { get; set; }
       //public string ClientReference { get; set; }
       //public string ClientStatus { get; set; }
       //public string CompanyNumber { get; set; }
       //public string CompanyProfileFieldId { get; set; }
       //public string CreatorId { get; set; }
       //public string DateCreated { get; set; }
       //public string DateModified { get; set; }
       //public string Email2 { get; set; }
       //public string Email3 { get; set; }
       //public string ExternalCompanyProfileFieldId { get; set; }
       //public string ExternalId1 { get; set; }
       //public string ExternalId2 { get; set; }
       //public string ExternalId3 { get; set; }
       //public string Facebook { get; set; }
       //public string Id { get; set; }
       //public string InternalComments { get; set; }
       //public string IsClient { get; set; }
       //public string ISDN { get; set; }
       //public string IsDoNotContactChecked { get; set; }
       //public string IsDoNotMailshotChecked { get; set; }
       //public string IsPartner { get; set; }
       //public string IsPlaceOfStudy { get; set; }
       //public string IsSupplier { get; set; }
       //public string LinkedIn { get; set; }
       //public string ModifierId { get; set; }
       public string Name { get; set; }
       //public string OffMarketEndDate { get; set; }
       //public string OffMarketOwnerId { get; set; }
       //public string OffMarketReason { get; set; }
       //public string OffMarketStatus { get; set; }
       //public string OwnerId { get; set; }
       //public string PaymentTerms { get; set; }
       //public string PrimaryContactIndex { get; set; }
       //public string RecordPicture { get; set; }
       //public string RegistrationNumber { get; set; }
       //public string SalesPhone { get; set; }
       //public string Skype { get; set; }
       //public string SupportPhone { get; set; }
       //public string Synonyms { get; set; }
       //public string Twitter { get; set; }
       //public string VATNumber { get; set; }
       //public string WebPage { get; set; }
       //public string XING { get; set; }
    }

    #endregion

    #region Loactions

    public class InveniasLocationValue
    {
        public string BusinessCity { get; set; }
        public string BusinessCountry { get; set; }
        public string BusinessFax { get; set; }
        public string BusinessPhone { get; set; }
        public string BusinessPostalCode { get; set; }
        public string BusinessState { get; set; }
        public string BusinessStreet { get; set; }
        public string CreatorId { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string Email1Address { get; set; }
        public string ExternalId1 { get; set; }
        public string ExternalId2 { get; set; }
        public string ExternalId3 { get; set; }
        public string Id { get; set; }
        public string ModifierId { get; set; }
        public string Name { get; set; }
    }

    public class InveniasLocationRoot
    {
        public List<InveniasLocationValue> value { get; set; }
    }

    #endregion

    #region Interim Rates
    public class InveniaInterimRatesValue
    {
        public double? BillAmountFrom { get; set; }
        public double? BillAmountTo { get; set; }
        public string BillCurrency { get; set; }
        public string CreatorId { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string Id { get; set; }
        public string InterimRateFieldId { get; set; }
        public string MarginAmount { get; set; }
        public string MarginCurrency { get; set; }
        public string MarginPercentage { get; set; }
        public string ModifierId { get; set; }
        public string Notes { get; set; }
        public string OrderIndex { get; set; }
        public double PayAmountFrom { get; set; }
        public double PayAmountTo { get; set; }
        public string PayCurrency { get; set; }
        public string Period { get; set; }
    }

    public class InveniaInterimRatesRoot
    {
        public List<InveniaInterimRatesValue> value { get; set; }
    }
    #endregion

    #region Non-Exec Package
    public class InveniaNonExecPackageValue
    {
        public double? AmountFrom { get; set; }
        public double? AmountTo { get; set; }
        public string CreatorId { get; set; }
        public string Currency { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string Id { get; set; }
        public string ModifierId { get; set; }
        public string NonExecPackageFieldId { get; set; }
        public string Notes { get; set; }
        public string OrderIndex { get; set; }
        public string Period { get; set; }
    }

    public class InveniaNonExecPackageRoot
    {
        public List<InveniaNonExecPackageValue> value { get; set; }
    }
    #endregion

    #region Permanent Packages
    public class InveniaPermanentPackageValue
    {
        public double? AmountFrom { get; set; }
        public double? AmountTo { get; set; }
        public string CreatorId { get; set; }
        public string Currency { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string Id { get; set; }
        public string ModifierId { get; set; }
        public string Notes { get; set; }
        public string OrderIndex { get; set; }
        public string Period { get; set; }
        public string PermanentPackageFieldId { get; set; }
    }

    public class InveniaPermanentPackageRoot
    {
        public List<InveniaPermanentPackageValue> value { get; set; }
    }

    #endregion

    #region Category List Entry

    public class InveniaCategoryListEntryValue
    {
        public string CategoryListId { get; set; }
        public string CreatorId { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string Id { get; set; }
        public string ModifierId { get; set; }
        public string Name { get; set; }
        public string ParentEntryId { get; set; }
    }

    public class InveniaCategoryListEntryRoot
    {
        public List<InveniaCategoryListEntryValue> value { get; set; }
    }

    #endregion

    #region Category List

    public class InveniaCategoryListValue
    {
        public string CreatorId { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string Id { get; set; }
        public string ModifierId { get; set; }
        public string Name { get; set; }
        public string OrderIndex { get; set; }
        public string ShowDataColumns { get; set; }
    }

    public class InveniaCategoryListRoot
    {
        public List<InveniaCategoryListValue> value { get; set; }
    }

    #endregion

    #region NoteField

    public class InveniaNoteFieldValue
    {
        public string CreatorId { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string Id { get; set; }
        public string ModifierId { get; set; }
        public string NoteFieldType { get; set; }
        public string TextBody { get; set; }
    }

    #endregion

    public class InveniasPTModel
    {
        public InveniasAdvertisementsValue advertisement { get; set; }
        public string advertisementDescription { get; set; }
        public InveniasAssignmentValue assignment { get; set; }
        public InveniasCompanyValue company { get; set; }
        public JXTCLAModel location { get; set; }
        public List<JXTPRModel> profRole { get; set; }

        public double? SalaryBaseOnPackage_Min { get; set; }
        public double? SalaryBaseOnPackage_Max { get; set; } 

        //reference only if needed for manipulations
        public InveniaInterimRatesValue interim_rate { get; set; }
        public InveniaNonExecPackageValue non_exec_package { get; set; }
        public InveniaPermanentPackageValue perm_package { get; set; }

        //GETTERS
        public string GET_Application
        {
            get
            {
                if (advertisement.UseGenericEmail)
                    return advertisement.ApplicationsEmail;
                else
                    return advertisement.PrimaryEmail;
            }
        }
    }


}
