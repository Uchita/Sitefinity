
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
	/// An component type implementation of the 'ViewJobs' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class ViewJobsService : JXTPortal.ViewJobsServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the ViewJobsService class.
		/// </summary>
		public ViewJobsService() : base()
		{
		}

        public VList<ViewJobs> GetByID(int? jobId, int languageId, int? siteId)
        {
            VList<ViewJobs> jobs = base.GetByID(jobId, siteId);

            // Naveen TODO!!
            if (languageId != PortalConstants.DEFAULT_LANGUAGE_ID)
            {/*
                foreach (ViewJobs job in jobs)
                {
                    AreaService areaService = new AreaService();
                    job.SiteAreaName = areaService.GetTranslatedStringArea(job.AreaId, SessionData.Language.LanguageId);
                    areaService = null;

                    ProfessionService professionService = new ProfessionService();
                    job.SiteProfessionName = professionService.GetTranslatedStringProfession(job.ProfessionId, SessionData.Language.LanguageId);
                    professionService = null;

                    LocationService locationService = new LocationService();
                    job.SiteLocationName = locationService.GetTranslatedStringLocation(job.LocationId, SessionData.Language.LanguageId);
                    locationService = null;

                    //TODO: Naveen to confirm
                    SalaryService salaryService = new SalaryService();
                    job.SalaryName = salaryService.GetTranslatedStringSalary(viewJobSearch.SalaryId, SessionData.Language.LanguageId);
                    salaryService = null;

                    RolesService rolesService = new RolesService();
                    job.SiteRoleName = rolesService.GetTranslatedStringRole(job.RoleId, SessionData.Language.LanguageId);
                    rolesService = null;

                    WorkTypeService workTypeService = new WorkTypeService();
                    job.SiteWorkTypeName = workTypeService.GetTranslatedStringWorkType(job.WorkTypeId, SessionData.Language.LanguageId);
                    workTypeService = null;
                }*/
            }
             
            return jobs;
        }


        public void SetJobLanguage(ref JXTPortal.Entities.ViewJobs job, int defaultLanguageId, int languageId)
        {
            if (languageId != defaultLanguageId)
            {
                using (TList<JobCustomXml> jobcustomxmllist = JobCustomXmlService.CustomGetBySiteIDJobIDCustomType(SessionData.Site.SiteId, job.JobId, (int)PortalEnums.Jobs.CustomType.Job))
                {
                    if (jobcustomxmllist.Count > 0)
                    {
                        JobCustomXml jobcustomxml = jobcustomxmllist[0];

                        XmlSerializer deserializer = new XmlSerializer(typeof(JobDetails));

                        if (!string.IsNullOrEmpty(jobcustomxml.CustomXml))
                        {
                            System.IO.TextReader sr = new System.IO.StringReader(jobcustomxml.CustomXml);

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

        #region Properties
        private JobCustomXmlService _jobCustomXmlService;

        private JobCustomXmlService JobCustomXmlService
        {
            get
            {
                if (_jobCustomXmlService == null)
                    _jobCustomXmlService = new JobCustomXmlService();

                return _jobCustomXmlService;
            }
        }
        #endregion

    }//End Class


} // end namespace
