
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

#endregion

namespace JXTPortal
{		
	
	///<summary>
	/// An component type implementation of the 'ViewJobsArchive' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class ViewJobsArchiveService : JXTPortal.ViewJobsArchiveServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the ViewJobsArchiveService class.
		/// </summary>
		public ViewJobsArchiveService() : base()
		{
		}

        public VList<ViewJobsArchive> GetByID(int? jobId, int languageId, int? siteId)
        {
            VList<ViewJobsArchive> jobs = base.GetByID(jobId, siteId);

            /* Naveen TODO!!
            if (languageId != PortalConstants.DEFAULT_LANGUAGE_ID)
            {
                foreach (ViewJobsArchive job in jobs)
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
                }
            }
             */

            return jobs;
        }
	}//End Class


} // end namespace
