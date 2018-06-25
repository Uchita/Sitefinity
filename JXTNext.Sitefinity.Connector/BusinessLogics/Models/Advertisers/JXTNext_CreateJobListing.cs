using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;
using System;
using System.Collections.Generic;
using System.Text;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers
{

    public class JXTNext_CreateJobListingRequest : ConnectorBaseRequest, ICreateJobListingRequest
    {
        public JobDetailsFullModel JobData { get; set; }
    }

    public class JXTNext_CreateJobListingResponse : ConnectorBaseResponse, ICreateJobListingResponse
    {
        public JXTNext_CreateJobListingResponse(bool success, int? jobId)
        {
            Success = success;
            _jobId = jobId;
        }

        public JXTNext_CreateJobListingResponse(bool success, List<string> errors)
        {
            Success = success;
            Messages = errors;
        }

        int? _jobId;
        public int? JobId { get { return _jobId; } }
    }

}
