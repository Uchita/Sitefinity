using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member
{
    
    public class JXTNext_MemberGetByIdRequest : ConnectorBaseRequest, IMemberGetByIdRequest
    {
        public MemberModel Member { get; set; }
    }

    public class JXTNext_MemberGetByIdResponse : ConnectorBaseResponse, IMemberGetByIdResponse
    {
        public MemberModel Member { get; set; }
    }

}
