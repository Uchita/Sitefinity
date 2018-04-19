using System;
using System.Collections.Generic;
using System.Text;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers
{

    public class JXTNext_GetJobListing : ConnectorBaseRequest, IGetJobListing
    {
        public string JobID { get; set; }
    }

    public class JXTNext_GetJobListingResponse : ConnectorBaseResponse, IGetJobListingResponse
    {

    }

}
