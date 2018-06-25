using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;
using System;
using System.Collections.Generic;
using System.Text;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers
{

    public class Test_GetJobListingRequest : ConnectorBaseRequest, IGetJobListingRequest
    {
        public int JobID { get; set; }
    }

    public class Test_GetJobListingResponse : ConnectorBaseResponse, IGetJobListingResponse
    {
        public JobDetailsFullModel Job { get; set; }
    }

}
