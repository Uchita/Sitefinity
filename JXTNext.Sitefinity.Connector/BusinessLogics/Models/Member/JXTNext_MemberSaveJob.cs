using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Common;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member
{
    public class JXTNext_MemberSaveJobRequest : ConnectorBaseRequest, IMemberSaveJob
    {
        public int JobId { get; set; }
    }

    public class JXTNext_MemberSaveJobResponse: ConnectorBaseResponse, IMemberSaveJobResponse
    {
        public int? SavedJobId { get; set; }
    }

}
