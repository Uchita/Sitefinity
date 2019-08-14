using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;
using System;
using System.Collections.Generic;
using System.Text;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers
{

    public class Test_CreateJobListing : ConnectorBaseRequest, ICreateJobListingRequest
    {
        public JobDetailsFullModel JobData { get; set; }
    }

    public class Test_CreateJobListingResponse : ConnectorBaseResponse, ICreateJobListingResponse
    {
        public int? JobId { get; set; }
    }

}
