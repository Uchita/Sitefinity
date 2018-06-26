using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models
{
    public class ConnectorBaseRequest
    {
        public string SiteDomain { get; set; }
        public string UserEmail { get; set; }
    }

    public class ConnectorBaseResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
