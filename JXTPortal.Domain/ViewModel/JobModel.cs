using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Domain.ViewModel
{
    public class JobModel
    {
        public class Search
        {
            public Search()
            {
                Professions = new Dictionary<string, string>();
                SalaryTypes = new Dictionary<string, string>();
                SalaryFrom = new Dictionary<string, string>();
                SalaryTo = new Dictionary<string, string>();
                Locations = new Dictionary<string, string>();
                WorkTypes = new Dictionary<string, string>();
            }

            public string Keyword { get; set; }
            public int ProfessionId { get; set; }
            public IEnumerable<string> RoleId { get; set; }
            public int SalaryTypeId { get; set; }
            public string SalaryFromId { get; set; }
            public string SalaryToId { get; set; }
            public int LocationId { get; set; }
            public IEnumerable<string> AreaId { get; set; }
            public int WorkTypeId { get; set; }

            public Dictionary<string, string> Professions { get; set; }

            public Dictionary<string, string> SalaryTypes { get; set; }

            public Dictionary<string, string> SalaryFrom { get; set; }
            public Dictionary<string, string> SalaryTo { get; set; }

            public Dictionary<string, string> Locations { get; set; }

            public Dictionary<string, string> WorkTypes { get; set; }

        }

        public class Result
        {
            public Result()
            {
                JobSearchModel = new Search();
                JobSearchResults = new List<Job>();
            }

            public int PageNo { get; set; }

            public int TotalPage { get; set; }

            public int TotalRecord { get; set; }

            public Search JobSearchModel { get; set; }

            public List<Job> JobSearchResults { get; set; }

        }

        public class Job
        {
            public int JobId { get; set; }
            public int SiteId { get; set; }
            public string JobName { get; set; }
            public string Description { get; set; }
            public DateTime DatePosted { get; set; }
            
            public string DatePostedDisplay
            {
                get {
                    return DatePosted.ToString("dd MMMM yyyy");
                }
            }

            public bool Visible { get; set; }
            public bool Expired { get; set; }
            public bool ShowSalaryDetails { get; set; }
            public bool ShowSalaryRange { get; set; }
            public int AdvertiserID { get; set; }
            public int ApplicationMethod { get; set; }
            public string ApplicationURL { get; set; }
            public int AdvertiserJobTemplateLogoID { get; set; }
            public string CompanyName { get; set; }
            public bool ShowLocationDetails { get; set; }
            public string BulletPoint1 { get; set; }
            public string BulletPoint2 { get; set; }
            public string BulletPoint3 { get; set; }
            public bool HotJob { get; set; }
            public string RefNo { get; set; }
            public string AdvertiserName { get; set; }
            public string CurrencySymbol { get; set; }
            public decimal SalaryUpperBand { get; set; }
            public decimal SalaryLowerBand { get; set; }
            public int SalaryTypeID { get; set; }
            public string SalaryTypeName { get; set; }
            public string WorkTypeName { get; set; }
            public int LocationID { get; set; }
            public int AreaID { get; set; }
            public string LocationName { get; set; }
            public string AreaName { get; set; }
            public int ProfessionID { get; set; }
            public int RoleID { get; set; }
            public string SiteProfessionName { get; set; }
            public string SiteRoleName { get; set; }
            public string BreadCrumbNavigation { get; set; }
            public int WorkTypeID { get; set; }
            public string JobFriendlyName { get; set; }
            public string SalaryDisplay { get; set; }

            #region "Custom Member for Knockout JS Binding"

            public string UrlAction { get; set; }
            
            #endregion

        }

        public class JobDetail
        {
            public int JobID { get; set; }
            public int SiteID { get; set; }
            public int WorkTypeID { get; set; }
            public string JobName { get; set; }
            public string Description { get; set; }
            public string FullDescription { get; set; }
            public bool WebServiceProcessed { get; set; }
            public string ApplicationEmailAddress { get; set; }
            public string RefNo { get; set; }
            public bool Visible { get; set; }
            public DateTime DatePosted { get; set; }
            public DateTime ExpiryDate { get; set; }
            public bool Expired { get; set; }
            public decimal JobItemPrice { get; set; }
            public bool Billed { get; set; }
            public DateTime LastModified { get; set; }
            public bool ShowSalaryDetails { get; set; }
            public bool ShowSalaryRange { get; set; }
            public string SalaryText { get; set; }
            public int AdvertiserID { get; set; }
            public int LastModifiedByAdvertiserUserId { get; set; }
            public int LastModifiedByAdminUserId { get; set; }
            public int JobItemTypeID { get; set; }
            public int ApplicationMethod { get; set; }
            public string ApplicationURL { get; set; }
            public int UploadMethod { get; set; }
            public string Tags { get; set; }
            public int JobTemplateID { get; set; }
            public string SearchField { get; set; }
            public int AdvertiserJobTemplateLogoID { get; set; }
            public string CompanyName { get; set; }
            public bool RequireLogonForExternalApplications { get; set; }
            public bool ShowLocationDetails { get; set; }
            public string PublicTransport { get; set; }
            public string Address { get; set; }
            public string ContactDetails { get; set; }
            public string JobContactPhone { get; set; }
            public string JobContactName { get; set; }
            public bool QualificationsRecognised { get; set; }
            public bool ResidentOnly { get; set; }
            public string DocumentLink { get; set; }
            public string BulletPoint1 { get; set; }
            public string BulletPoint2 { get; set; }
            public string BulletPoint3 { get; set; }
            public bool HotJob { get; set; }
            public string AdvertiserCompanyName { get; set; }
            public string BusinessNumber { get; set; }
            public string StreetAddress1 { get; set; }
            public string StreetAddress2 { get; set; }
            public string WebAddress { get; set; }
            public string Profile { get; set; }
            public bool RequireLogonForExternalApplication { get; set; }
            public string SiteWorkTypeName { get; set; }
            public string CurrencySymbol { get; set; }
            public decimal SalaryUpperBand { get; set; }
            public decimal SalaryLowerBand { get; set; }
            public int SalaryTypeId { get; set; }
            public string JobTemplateHTML { get; set; }
            public string SalaryTypeName { get; set; }
            public string SiteAreaName { get; set; }
            public string SiteLocationName { get; set; }
            public string SiteRoleName { get; set; }
            public string SiteProfessionName { get; set; }
            public string JobFriendlyName { get; set; }
            public int ProfessionID { get; set; }
            public int RoleID { get; set; }
            public string SalaryDisplay { get; set; }

            #region "Additional Properties"
            public bool IsJobSaved { get; set; }
            public bool IsJobApplied { get; set; }
            public string LinkedInAPI { get; set; }
            public string LinkedInSecret { get; set; }
            public string LinkedInLogo { get; set; }
            public int LinkedInCompanyID { get; set; }
            public string LinkedInEmail { get; set; }
            public string LinkedInJobName { get; set; }
            public string LinkedInApplicationLink { get; set; }
            
            #endregion
        }

        public class Apply
        {

        }

        public class JobAlert
        {
            public List<JobAlertDetail> JobAlerts { get; set; }
        }

        public class JobAlertDetail
        {
            public JobAlertDetail()
            {
                JobAlertId = 0;
                JobAlertName = string.Empty;
                SearchKeywords = string.Empty;
                ProfessionId = 0;
                SearchRoleIds = string.Empty;
                LocationId = 0;
                AreaIds = string.Empty;
                Professions = new Dictionary<string, string>();
                SalaryFrom = new Dictionary<string, string>();
                SalaryTo = new Dictionary<string, string>();
                Locations = new Dictionary<string, string>();
            }

            #region "Search"
            
            public string Keyword { get; set; }
            public Dictionary<string, string> Professions { get; set; }
            public Dictionary<string, string> SalaryFrom { get; set; }
            public Dictionary<string, string> SalaryTo { get; set; }
            public Dictionary<string, string> Locations { get; set; }
            
            #endregion

            public Int32 JobAlertId { get; set; }
            
            /// <summary>
            /// JobAlertName : 
            /// </summary>
            public String JobAlertName { get; set; }

            /// <summary>
            /// LastModified : 
            /// </summary>
            public DateTime LastModified { get; set; }

            /// <summary>
            /// SearchKeywords : 
            /// </summary>
            public String SearchKeywords { get; set; }

            /// <summary>
            /// RecurrenceType : 
            /// </summary>
            public Int32? RecurrenceType { get; set; }

            /// <summary>
            /// DailyFrequency : 
            /// </summary>
            public Int32? DailyFrequency { get; set; }

            /// <summary>
            /// WeeklyFrequency : 
            /// </summary>
            public Int32? WeeklyFrequency { get; set; }

            /// <summary>
            /// WeeklyDayOccurence : 
            /// </summary>
            public Int32? WeeklyDayOccurence { get; set; }

            /// <summary>
            /// DateLastRun : 
            /// </summary>
            public DateTime? DateLastRun { get; set; }

            /// <summary>
            /// DateNextRun : 
            /// </summary>
            public DateTime? DateNextRun { get; set; }

            /// <summary>
            /// MemberID : 
            /// </summary>
            public Int32 MemberId { get; set; }

            /// <summary>
            /// AlertActive : 
            /// </summary>
            public Boolean? AlertActive { get; set; }

            /// <summary>
            /// EmailFormat : 
            /// </summary>
            public Int32? EmailFormat { get; set; }

            /// <summary>
            /// CustomRecurrenceType : 
            /// </summary>
            public Int32? CustomRecurrenceType { get; set; }

            /// <summary>
            /// LastResultCount : 
            /// </summary>
            public Int32? LastResultCount { get; set; }

            /// <summary>
            /// PrimaryAlert : 
            /// </summary>
            public Boolean? PrimaryAlert { get; set; }

            /// <summary>
            /// UnsubscribeValidateID : 
            /// </summary>
            public Guid? UnsubscribeValidateId { get; set; }

            /// <summary>
            /// EditValidateID : 
            /// </summary>
            public Guid? EditValidateId { get; set; }

            /// <summary>
            /// ViewValidateID : 
            /// </summary>
            public Guid? ViewValidateId { get; set; }

            /// <summary>
            /// SiteID : 
            /// </summary>
            public Int32 SiteId { get; set; }

            /// <summary>
            /// LocationID : 
            /// </summary>
            public Int32? LocationId { get; set; }

            /// <summary>
            /// AreaIDs : 
            /// </summary>
            public String AreaIds { get; set; }

            /// <summary>
            /// ProfessionID : 
            /// </summary>
            public Int32? ProfessionId { get; set; }

            /// <summary>
            /// SearchRoleIDs : 
            /// </summary>
            public String SearchRoleIds { get; set; }

            /// <summary>
            /// WorkTypeIDs : 
            /// </summary>
            public String WorkTypeIds { get; set; }

            /// <summary>
            /// SalaryIDs : 
            /// </summary>
            public String SalaryIds { get; set; }

            /// <summary>
            /// DaysPosted : 
            /// </summary>
            public Int32? DaysPosted { get; set; }

            /// <summary>
            /// GeneratedSQL : 
            /// </summary>
            public String GeneratedSql { get; set; }

            /// <summary>
            /// SalaryLowerBand : 
            /// </summary>
            public Decimal? SalaryLowerBand { get; set; }

            /// <summary>
            /// SalaryUpperBand : 
            /// </summary>
            public Decimal? SalaryUpperBand { get; set; }

            /// <summary>
            /// CurrencyID : 
            /// </summary>
            public Int32? CurrencyId { get; set; }

            /// <summary>
            /// SalaryTypeID : 
            /// </summary>
            public Int32? SalaryTypeId { get; set; }
        }
    }
}
