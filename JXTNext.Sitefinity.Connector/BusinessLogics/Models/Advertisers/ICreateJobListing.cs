using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;
using System;
using System.Collections.Generic;
using System.Text;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers
{
    public interface ICreateJobListingRequest
    {
        JobDetailsFullModel JobData { get; set; }
    }

    public interface ICreateJobListingResponse
    {
        int? JobId { get; }
    }
}
