	

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
	/// <summary>
	/// An component type implementation of the 'JobAlerts' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class JobAlertsService : JXTPortal.JobAlertsServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the JobAlertsService class.
		/// </summary>
		public JobAlertsService() : base()
		{
		}
		#endregion Constructors

        public override bool Insert(JobAlerts entity)
        {
            //entity.AlertActive = true;
            entity.EmailFormat = 1;
            return base.Insert(entity);
        }


        public int SaveMemberJobAlert(int JobID, int SiteId, int memberId, int EmailFormat, string Profession)
        {
            int jobAlertId = 0;

            JobsService JobsService = new JobsService();
            JobAreaService JobAreaService = new JobAreaService();
            SiteProfessionService SiteProfessionService = new SiteProfessionService();
            JobRolesService JobRolesService = new JobRolesService();
            AreaService AreaService = new AreaService();
            LocationService LocationService = new LocationService();

            using (Entities.JobAlerts jobAlert = new Entities.JobAlerts())
            using (JXTPortal.Entities.Jobs job = JobsService.GetByJobId(JobID))
            using (TList<JXTPortal.Entities.JobArea> jobareas = JobAreaService.GetByJobId(JobID))
            {
                if (!string.IsNullOrEmpty(Profession))
                {
                    System.Data.DataSet ds = SiteProfessionService.GetBySiteIdFriendlyUrl(SiteId, Profession);
                    int professionid = Convert.ToInt32(ds.Tables[0].Rows[0]["ProfessionID"]);
                    TList<JXTPortal.Entities.JobRoles> jobroles = JobRolesService.GetByJobIdProfessionId(JobID, professionid);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        JXTPortal.Entities.JobArea ja = jobareas[0];

                        Entities.Area area = AreaService.GetByAreaId(ja.AreaId);
                        Entities.Location location = LocationService.GetByLocationId(area.LocationId);
                        string roles = string.Empty;
                        foreach (Entities.JobRoles jr in jobroles)
                        {
                            roles += jr.RoleId.ToString() + ",";
                        }
                        roles = roles.TrimEnd(new char[] { ',' });

                        jobAlert.SearchKeywords = string.Empty;
                        jobAlert.ProfessionId = professionid.ToString();
                        jobAlert.SearchRoleIds = roles;

                        jobAlert.LocationId = area.LocationId.ToString();
                        jobAlert.AreaIds = area.AreaId.ToString();
                        jobAlert.WorkTypeIds = job.WorkTypeId.ToString();
                        //jobAlert.SalaryIds = job.SalaryId.ToString();

                        jobAlert.MemberId = memberId;
                        jobAlert.EmailFormat = EmailFormat;

                        jobAlert.JobAlertName = string.Format("{0} Jobs", ds.Tables[0].Rows[0]["SiteProfessionName"]);
                        jobAlert.PrimaryAlert = false;
                        jobAlert.AlertActive = true;

                        jobAlert.UnsubscribeValidateId = Guid.NewGuid();
                        jobAlert.EditValidateId = Guid.NewGuid();
                        jobAlert.ViewValidateId = Guid.NewGuid();

                        Insert(jobAlert);

                        jobAlertId = jobAlert.JobAlertId;
                    }
                }
            }

            return jobAlertId;

        }
	}//End Class

} // end namespace
