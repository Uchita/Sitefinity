using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Data.Dapper.Entities.Core
{
    public class AdvertisersEntity : BaseEntity
    {
        public int AdvertiserID { get; set; }
        public int SiteID { get; set; }
        public int AdvertiserAccountTypeID { get; set; }
        public int AdvertiserBusinessTypeID { get; set; }
        public int AdvertiserAccountStatusID { get; set; }
        public string CompanyName { get; set; }
        public string BusinessNumber { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string PostalAddress1 { get; set; }
        public string PostalAddress2 { get; set; }
        public string WebAddress { get; set; }
        public string NoOfEmployees { get; set; }
        public DateTime? FirstApprovedDate { get; set; }
        public string Profile { get; set; }
        public string CharityNumber { get; set; }
        public string SearchField { get; set; }
        public DateTime? FreeTrialStartDate { get; set; }
        public DateTime? FreeTrialEndDate { get; set; }
        public string AccountsPayableEmail { get; set; }
        public bool RequireLogonForExternalApplication { get; set; }
        public byte[] AdvertiserLogo { get; set; }
        public string LinkedInLogo { get; set; }
        public string LinkedInCompanyId { get; set; }
        public string LinkedInEmail { get; set; }
        public DateTime? RegisterDate { get; set; }
        public string ExternalAdvertiserID { get; set; }
        public string VideoLink { get; set; }
        public string Industry { get; set; }
        public string NominatedCompanyRole { get; set; }
        public string NominatedCompanyFirstName { get; set; }
        public string NominatedCompanyLastName { get; set; }
        public string NominatedCompanyEmailAddress { get; set; }
        public string NominatedCompanyPhone { get; set; }
        public int? PreferredContactMethod { get; set; }
        public string AdvertiserLogoURL { get; set; }
    }
}
