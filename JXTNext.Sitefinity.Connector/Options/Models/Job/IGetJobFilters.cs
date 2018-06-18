using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.Options.Models.Job
{
    public interface IGetJobFiltersRequest : IConnectorBaseRequest
    {
    }

    public interface IGetJobFiltersResponse : IConnectorBaseResponse
    {
        JobFiltersData Filters { get; set; }
    }

}
