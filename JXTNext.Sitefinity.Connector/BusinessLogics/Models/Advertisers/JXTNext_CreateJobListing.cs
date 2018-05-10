﻿using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;
using System;
using System.Collections.Generic;
using System.Text;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers
{

    public class JXTNext_CreateJobListing : ConnectorBaseRequest, ICreateJobListing
    {
        public JobDetailsModel JobData { get; set; }
    }

    public class JXTNext_CreateJobListingResponse : ConnectorBaseResponse, ICreateJobListingResponse
    {
        public string JobId { get; set; }
    }

}
