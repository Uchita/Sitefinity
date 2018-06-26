using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;
using System;
using System.Collections.Generic;
using System.Text;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers
{
    public interface IGetJobListingRequest
    {
        int JobID { get; set; }        
    }

    public interface IGetJobListingResponse
    {
        JobDetailsFullModel Job { get; set; }
    }
}
