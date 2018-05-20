using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXTNext.Sitefinity.Connector.Options.Models.Job;

namespace JXTNext.Sitefinity.Connector.Options
{
    public class JXTNextOptionsConnector : IOptionsConnector
    {
        public IntegrationConnectorType ConnectorType => IntegrationConnectorType.JXTNext;

        public TRes JobFilters<TReq, TRes>(TReq request) where TReq : class, IGetJobFiltersRequest where TRes : class, IGetJobFiltersResponse
        {
            throw new NotImplementedException();
        }
    }
}
