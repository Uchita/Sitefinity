using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.Options.Models.Job
{
    public class Test_GetJobFiltersRequest : ConnectorBaseRequest, IGetJobFiltersRequest
    {
    }

    public class Test_GetJobFiltersResponse : ConnectorBaseResponse, IGetJobFiltersResponse
    {
        public JobFiltersData Filters { get; set; }
    }
}
