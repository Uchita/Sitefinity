using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.Options.Models
{
    public interface IConnectorBaseRequest
    {
        string AuthenticationToken { get; set; }
    }

    public interface IConnectorBaseResponse
    {
        bool Success { get; set; }
        List<string> Messages { get; set; }
    }
}
