using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Common;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member
{
    public class JXTNext_MemberAppliedJobResponse : ConnectorBaseResponse, IMemberAppliedJobResponse
    {
        public dynamic MemberAppliedJobs { get; set; }
    }

    public class MemberAppliedJob
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string JobName { get; set; }
        public int MemberId { get; set; }
        public string CoverLetterUrl { get; set; }
        public string ResumeUrl { get; set; }
        public int Status { get; set; }
        public long DateCreated { get; set; }
    }


}
