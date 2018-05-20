using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.Options.Models.Job
{
    public class JXTNext_GetJobFiltersRequest : IGetJobFiltersRequest
    {
    }

    public class JXTNext_GetJobFiltersResponse : IGetJobFiltersResponse
    {
        public JobFiltersData Filters { get; set; }
    }
}
