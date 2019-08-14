using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;
using System;
using System.Collections.Generic;
using System.Text;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers
{

    public class JXTNext_DeleteJobListingRequest : ConnectorBaseRequest, IDeleteJobListingRequest
    {
        public int JobID { get; set; }
    }

    public class JXTNext_DeleteJobListingResponse : ConnectorBaseResponse, IDeleteJobListingResponse
    {
    }

}
