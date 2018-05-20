using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.Options.Models
{
    public class ConnectorBaseRequest
    {
        public string AuthenticationToken { get; set; }
    }

    public class ConnectorBaseResponse
    {
        public bool Success { get; set; }
        public List<string> Messages { get; set; }
    }
}
