using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector
{
    public interface IConnector
    {
        string CONFIG_DataAccessTarget { get; }
        int HTTP_Requests_MaxWaitTime { get; }
    }
}
