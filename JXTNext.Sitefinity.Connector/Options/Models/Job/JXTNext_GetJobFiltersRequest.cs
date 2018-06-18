using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.Options.Models.Job
{
    public class JXTNext_GetJobFiltersRequest : ConnectorBaseRequest, IGetJobFiltersRequest
    {
        public int SiteId { get; set; }
    }

    public class JXTNext_GetJobFiltersResponse : ConnectorBaseResponse, IGetJobFiltersResponse
    {
        public JobFiltersData Filters { get; set; }
    }
}
