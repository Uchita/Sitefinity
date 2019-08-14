using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Common;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member
{
    public class JXTNext_MemberGetSavedJobResponse: ConnectorBaseResponse, IMemberGetSavedJobsResponse
    {
        public List<MemberSavedJob> SavedJobs { get; set; }
    }

    public class MemberSavedJob
    {
        public int SavedJobId { get; set; }
        public string Title { get; set; }
        public int JobId { get; set; }
        public long DateAdded { get; set; }
    }

}
