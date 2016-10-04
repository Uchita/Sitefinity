	

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
using System.Linq;
using System.Text;
using System.Collections.Generic;
#endregion

namespace JXTPortal
{		
	/// <summary>
	/// An component type implementation of the 'JobsSaved' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class JobsSavedService : JXTPortal.JobsSavedServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the JobsSavedService class.
		/// </summary>
		public JobsSavedService() : base()
		{
		}
		#endregion Constructors

        public bool SavedJobForMember(int jobID, bool blnDeleteIfExists, ref string strMessage )
        {
            bool isValid = false;

            if (SessionData.Member != null)
            {
                using (TList<JXTPortal.Entities.JobsSaved> jobsaved = GetByMemberId(SessionData.Member.MemberId))
                {
                    List<Entities.JobsSaved> _jobsaved = jobsaved.Where(js => js.JobId == jobID).ToList();
                    if (_jobsaved != null && _jobsaved.Count() > 0)
                    {
                        isValid = true;
                        if (blnDeleteIfExists)
                        {
                            Delete(_jobsaved[0].JobSaveId);
                            strMessage = "Deleted";
                        }
                        else
                            strMessage = "Saved";
                            //strMessage = "You saved this job on " + ((DateTime)jobsaved[0].LastModified).ToString("dd MMM yyy");
                        
                    }
                    else
                    {
                        if (Insert(new JobsSaved() { JobId = jobID, MemberId = SessionData.Member.MemberId }))
                        {
                            isValid = true;

                            strMessage = "Saved";
                        }
                    }

                }
            }
            else
                strMessage = "Login";

            return isValid;
        }

        public string GetMemberSavedJobs()
        {
            string strJobIds = string.Empty;
            StringBuilder strBuilder = new StringBuilder();
            if (SessionData.Member != null)
            {
                using (TList<JXTPortal.Entities.JobsSaved> jobsaved = GetByMemberId(SessionData.Member.MemberId))
                {
                    if (jobsaved != null && jobsaved.Count > 0)
                    {
                        foreach (Entities.JobsSaved item in jobsaved)
                        {
                            strBuilder.Append(string.Format(" {0} ", item.JobId));
                        }

                        strJobIds = strBuilder.ToString();
                    }
                }
            }

            
            return strJobIds;
        }
	}

} 
