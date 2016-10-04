
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

            if (languageId != PortalConstants.DEFAULT_LANGUAGE_ID)
            {
                foreach (ViewJobSearch viewJobSearch in viewJobSearchList)
                {
                    AreaService areaService = new AreaService();
                    string translatedAreaName = areaService.GetTranslatedStringArea(viewJobSearch.AreaId, SessionData.Language.LanguageId);
                    viewJobSearch.AreaName =  string.IsNullOrEmpty(translatedAreaName) ? viewJobSearch.AreaName : translatedAreaName;
                    areaService = null;

                    ProfessionService professionService = new ProfessionService();
                    string translatedProfessionName = professionService.GetTranslatedStringProfession(viewJobSearch.ProfessionId, SessionData.Language.LanguageId, SessionData.Site.UseCustomProfessionRole);
                    viewJobSearch.SiteProfessionName = string.IsNullOrEmpty(translatedProfessionName) ? viewJobSearch.SiteProfessionName : translatedProfessionName;
                    professionService = null;

                    LocationService locationService = new LocationService();
                    string translatedLocationName = locationService.GetTranslatedStringLocation(viewJobSearch.LocationId, SessionData.Language.LanguageId);
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
                                                          string areaId, DateTime? dateFrom, int languageId)
        {
            DataSet dsSearch = base.GetBySearchFilterRedefine(keyword, siteId,
                                                                advertiserId, currencyId, salaryTypeId,
                                                                salaryLowerBand, salaryUpperBand,
                                                                workTypeId, professionId,
                                                                roleId, countryId, locationId, areaId, dateFrom, null);
            //We don't translate english - TODO: please put the default languageid to constant
            if (languageId != PortalConstants.DEFAULT_LANGUAGE_ID)
            {
                int lid = languageId;
                if (System.Web.HttpContext.Current != null)
                {
                    lid = SessionData.Language.LanguageId;
                }

                if (dsSearch.Tables.Count > 0 && dsSearch.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in dsSearch.Tables[0].Rows)
                    {
                        int RefineTypeID = Convert.ToInt32(row["RefineTypeID"]);
                        int RefineID = Convert.ToInt32(row["RefineID"]);
                        string TranslatedLabel = string.Empty;

                        if (RefineTypeID == (int)PortalEnums.Search.Redefine.Area)
                        {
                            AreaService areaService = new AreaService();
                            TranslatedLabel = areaService.GetTranslatedStringArea(RefineID, lid);
                            areaService = null;
                        }
                        else if (RefineTypeID == (int)PortalEnums.Search.Redefine.Classification)
                        {
                            ProfessionService professionService = new ProfessionService();
                            TranslatedLabel = professionService.GetTranslatedStringProfession(RefineID, lid, SessionData.Site.UseCustomProfessionRole);
                            professionService = null;
                        }
                        else if (RefineTypeID == (int)PortalEnums.Search.Redefine.Company)
                        {
                            //We don't translate company :)
                        }
                        else if (RefineTypeID == (int)PortalEnums.Search.Redefine.Location)
                        {
                            LocationService locationService = new LocationService();
                            TranslatedLabel = locationService.GetTranslatedStringLocation(RefineID, lid);
                            locationService = null;
                        }
                        else if (RefineTypeID == (int)PortalEnums.Search.Redefine.SubClassification)
                        {
                            RolesService rolesService = new RolesService();
                            TranslatedLabel = rolesService.GetTranslatedStringRole(RefineID, lid, SessionData.Site.UseCustomProfessionRole);
                            rolesService = null;
                        }
                        else if (RefineTypeID == (int)PortalEnums.Search.Redefine.WorkType)
                        {
                            WorkTypeService workTypeService = new WorkTypeService();
                            TranslatedLabel = workTypeService.GetTranslatedStringWorkType(RefineID, lid);
                            workTypeService = null;
                        }

                        if (TranslatedLabel.Trim().Length > 0)
                        {
                            row["RefineLabel"] = TranslatedLabel;
                        }
                    }
                }
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
