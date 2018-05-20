using JXTNext.Sitefinity.Connector.Options.Models.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.Options
{
    public interface IOptionsConnector
    {
        IntegrationConnectorType ConnectorType { get; }
        TRes JobFilters<TReq, TRes>(TReq request) where TReq : class,IGetJobFiltersRequest where TRes : class, IGetJobFiltersResponse;
    }
}
