using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member
{
    public class JXTNext_MemberApplicationRequest : ConnectorBaseRequest, IMemberApplication
    {
        public int MemberID { get; set; }
        public int ApplyResourceID { get; set; }

        public string ResumePath { get; set; }
        public string CoverletterPath { get; set; }
    }

    public class JXTNext_MemberApplicationResponse : ConnectorBaseResponse, IMemberApplicationResponse
    {
        public int? ApplicationID { get; set; }
    }

}
