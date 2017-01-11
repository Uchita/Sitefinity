
#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using JXTPortal.Entities;
using JXTPortal.Entities.Validation;

using JXTPortal.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Collections.Generic;
using System.Xml;


#endregion

namespace JXTPortal
{

    ///<summary>
    /// An component type implementation of the 'ViewJobSearch' table.
    ///</summary>
    /// <remarks>
    /// All custom implementations should be done here.
    /// </remarks>
    [CLSCompliant(true)]
    public partial class ViewJobSearchService : JXTPortal.ViewJobSearchServiceBase
    {
        /// <summary>
        /// Initializes a new instance of the ViewJobSearchService class.
        /// </summary>
        public ViewJobSearchService()
            : base()
        {
        }

        public VList<ViewJobSearch> GetBySearchFilter(string keyword, int? siteId, int? advertiserId, int? currencyId, decimal? salaryLowerBand, decimal? salaryUpperBand,
                                                        int? salaryTypeId, int? workTypeId, int? professionId, string roleId,
                                                        int? countryId,
                                                        int? locationId, string areaId, DateTime? dateFrom, int languageId, int? pageIndex, int? pageSize, string orderBy, string jobTypeIds)
        {
            VList<ViewJobSearch> viewJobSearchList = base.GetBySearchFilter(keyword, siteId, advertiserId, currencyId, salaryLowerBand, salaryUpperBand, salaryTypeId, workTypeId, professionId,
                                            roleId, countryId, locationId, areaId, dateFrom, pageIndex, pageSize, orderBy, jobTypeIds);

            if (languageId != SessionData.Site.DefaultLanguageId)
            {
                foreach (ViewJobSearch viewJobSearch in viewJobSearchList)
                {
                    SiteAreaService siteAreaService = new SiteAreaService();
                    string translatedAreaName = siteAreaService.GetTranslatedArea(viewJobSearch.AreaId, viewJobSearch.LocationId, SessionData.Language.LanguageId, SessionData.Site.SiteId).SiteAreaName;
                    viewJobSearch.AreaName = string.IsNullOrEmpty(translatedAreaName) ? viewJobSearch.AreaName : translatedAreaName;
                    siteAreaService = null;

                    ProfessionService professionService = new ProfessionService();
                    string translatedProfessionName = professionService.GetTranslatedStringProfession(viewJobSearch.ProfessionId, SessionData.Language.LanguageId, SessionData.Site.UseCustomProfessionRole);
                    viewJobSearch.SiteProfessionName = string.IsNullOrEmpty(translatedProfessionName) ? viewJobSearch.SiteProfessionName : translatedProfessionName;
                    professionService = null;

                    SiteLocationService locationService = new SiteLocationService();
                    string translatedLocationName = locationService.GetTranslatedLocation(viewJobSearch.LocationId, viewJobSearch.CountryId, SessionData.Language.LanguageId).SiteLocationName;
                    viewJobSearch.LocationName = string.IsNullOrEmpty(translatedLocationName) ? viewJobSearch.LocationName : translatedLocationName;
                    locationService = null;

                    //TODO: Naveen to confirm
                    /*
                    SalaryService salaryService = new SalaryService();
                    viewJobSearch.SalaryName = salaryService.GetTranslatedStringSalary(viewJobSearch.SalaryId, SessionData.Language.LanguageId);
                    salaryService = null;
                    */
                    RolesService rolesService = new RolesService();
                    string translatedRoleName = rolesService.GetTranslatedStringRole(viewJobSearch.RoleId, SessionData.Language.LanguageId, SessionData.Site.UseCustomProfessionRole);
                    viewJobSearch.SiteRoleName = string.IsNullOrEmpty(translatedRoleName) ? viewJobSearch.SiteRoleName : translatedRoleName;
                    rolesService = null;

                    WorkTypeService workTypeService = new WorkTypeService();
                    string translatedWTName = workTypeService.GetTranslatedStringWorkType(viewJobSearch.WorkTypeId, SessionData.Language.LanguageId);
                    viewJobSearch.WorkTypeName = string.IsNullOrEmpty(translatedWTName) ? viewJobSearch.WorkTypeName : translatedWTName;
                    workTypeService = null;

                }
            }

            return viewJobSearchList;
        }

        public DataSet GetBySearchFilterRedefine(string keyword, int? siteId, int? advertiserId,
                                                          int? currencyId, decimal? salaryLowerBand, decimal? salaryUpperBand,
                                                          int? salaryTypeId, int? workTypeId, int? professionId,
                                                          string roleId, int? countryId, int? locationId,
                                                          string areaId, DateTime? dateFrom, int targetedTranslatedLanguageID)
        {
            DataSet dsSearch = base.GetBySearchFilterRedefine(keyword, siteId,
                                                                advertiserId, currencyId, salaryTypeId,
                                                                salaryLowerBand, salaryUpperBand,
                                                                workTypeId, professionId,
                                                                roleId, countryId, locationId, areaId, dateFrom, null);
            int lid = targetedTranslatedLanguageID;
            if (System.Web.HttpContext.Current != null)
            {
                lid = SessionData.Language.LanguageId;
            }

            if (dsSearch.Tables.Count > 0 && dsSearch.Tables[0].Rows.Count > 0)
            {
                #region Services Initialize
                AreaService aService = new AreaService();
                SiteAreaService areaService = new SiteAreaService();
                SiteProfessionService professionService = new SiteProfessionService();
                LocationService lService = new LocationService();
                SiteLocationService locationService = new SiteLocationService();
                RolesService rService = new RolesService();
                SiteRolesService rolesService = new SiteRolesService();
                WorkTypeService workTypeService = new WorkTypeService();
                #endregion

                foreach (DataRow row in dsSearch.Tables[0].Rows)
                {
                    int RefineTypeID = Convert.ToInt32(row["RefineTypeID"]);
                    int RefineID = Convert.ToInt32(row["RefineID"]);
                    string TranslatedLabel = string.Empty;

                    switch ((PortalEnums.Search.Redefine)RefineTypeID)
                    {
                        case PortalEnums.Search.Redefine.Area:
                        case PortalEnums.Search.Redefine.Location:
                            //We translate only if the requested language is NOT the site's default language
                            //The idea of this is because the SP above grabs the site's default values already and does not require translation
                            if (targetedTranslatedLanguageID != SessionData.Site.DefaultLanguageId)
                            {
                                if (RefineTypeID == (int)PortalEnums.Search.Redefine.Area)
                                {
                                    TranslatedLabel = areaService.GetTranslatedArea(RefineID, aService.GetByAreaId(RefineID).LocationId, targetedTranslatedLanguageID, SessionData.Site.SiteId).SiteAreaName;
                                }
                                else if (RefineTypeID == (int)PortalEnums.Search.Redefine.Location)
                                {
                                    TranslatedLabel = locationService.GetTranslatedLocation(RefineID, lService.GetByLocationId(RefineID).CountryId, targetedTranslatedLanguageID).SiteLocationName;
                                }
                            }
                            break;
                        case PortalEnums.Search.Redefine.Classification:
                        case PortalEnums.Search.Redefine.SubClassification:
                        case PortalEnums.Search.Redefine.WorkType:
                            //We don't translate english - TODO: please put the default languageid to constant
                            if (targetedTranslatedLanguageID != PortalConstants.DEFAULT_LANGUAGE_ID)
                            {
                                if (RefineTypeID == (int)PortalEnums.Search.Redefine.Classification)
                                {
                                    TranslatedLabel = professionService.GetTranslatedProfessionById(RefineID, true, SessionData.Site.UseCustomProfessionRole).SiteProfessionName;
                                }
                                else if (RefineTypeID == (int)PortalEnums.Search.Redefine.SubClassification)
                                {
                                    TranslatedLabel = rolesService.GetTranslatedRolesById(RefineID, rService.GetByRoleId(RefineID).ProfessionId, SessionData.Site.UseCustomProfessionRole).SiteRoleName;
                                }
                                else if (RefineTypeID == (int)PortalEnums.Search.Redefine.WorkType)
                                {
                                    TranslatedLabel = workTypeService.GetTranslatedStringWorkType(RefineID, lid);
                                }
                            }
                            break;

                        case PortalEnums.Search.Redefine.Company:
                            //We don't translate company :)
                            break;

                    }

                    if (TranslatedLabel.Trim().Length > 0)
                    {
                        row["RefineLabel"] = TranslatedLabel;
                    }
                }

                #region Close all services
                areaService = null;
                professionService = null;
                locationService = null;
                lService = null;
                rolesService = null;
                workTypeService = null;
                #endregion
            }


            return dsSearch;
        }

        public string GetJobFullUrl(string siteurl, ViewJobSearch job, bool blnWWWRedirect, bool blnSSL)
        {
            string str = string.Empty;
            str = string.Format((blnSSL ? "https" : "http") + "://{0}{1}/{2}", (blnWWWRedirect ? "www." : string.Empty) + siteurl, job.JobFriendlyName, job.JobId);
            return str;
        }

        public void SetJobLanguage(VList<ViewJobSearch> viewJobSearchList, int defaultLanguageId, int languageId)
        {
            if (languageId != defaultLanguageId)
            {
                foreach (ViewJobSearch job in viewJobSearchList)
                {
                    if (!string.IsNullOrEmpty(job.CustomXml))
                    {
                        XmlSerializer deserializer = new XmlSerializer(typeof(JobDetails));
                        System.IO.TextReader sr = new System.IO.StringReader(job.CustomXml);

                        JobDetails jobdetaillist = deserializer.Deserialize(sr) as JobDetails;
                        if (jobdetaillist != null)
                        {
                            foreach (JobDetail jobdetail in jobdetaillist.JobDetail)
                            {
                                if (jobdetail.LanguageID == languageId && jobdetail.Enabled == "True")
                                {
                                    job.JobName = jobdetail.JobName;
                                    job.BulletPoint1 = jobdetail.BulletPoint1;
                                    job.BulletPoint2 = jobdetail.BulletPoint2;
                                    job.BulletPoint3 = jobdetail.BulletPoint3;
                                    job.Description = jobdetail.ShortDescription;
                                    job.FullDescription = jobdetail.FullDescription;
                                }
                            }
                        }
                    }
                }
            }
        }

        [Serializable, XmlRoot("JobDetails"), XmlType("JobDetails")]
        public class JobDetails
        {
            public JobDetails()
            {
                JobDetail = new List<JobDetail>();
            }

            [XmlElement("JobDetail")]
            public List<JobDetail> JobDetail { get; set; }
        }

        [XmlType("JobDetail")]
        public class JobDetail
        {
            [XmlElement("LanguageID")]
            public int LanguageID { get; set; }
            [XmlElement("Enabled")]
            public string Enabled { get; set; }
            [XmlElement("JobName")]
            public string JobName { get; set; }
            [XmlElement("BulletPoint1")]
            public string BulletPoint1 { get; set; }
            [XmlElement("BulletPoint2")]
            public string BulletPoint2 { get; set; }
            [XmlElement("BulletPoint3")]
            public string BulletPoint3 { get; set; }
            [XmlElement("ShortDescription")]
            public string ShortDescription { get; set; }
            [XmlElement("FullDescription")]
            public string FullDescription { get; set; }
        }

    }//End Class


} // end namespace
