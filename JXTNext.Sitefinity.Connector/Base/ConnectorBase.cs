using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector
{
    public abstract class ConnectorBase : IConnector
    {
        public string CONFIG_DataAccessTarget => _accessTargetPath;
        public int HTTP_Requests_MaxWaitTime => _maxWaitTime;

        string _accessTargetPath;
        int _maxWaitTime;

        public ConnectorBase()
        {
            _accessTargetPath = ConfigurationManager.AppSettings["JXTNextAPI_Path"]; ;

            bool parseWaitTimeSuccess = int.TryParse(ConfigurationManager.AppSettings["JXTNextAPI_WaitTimeMs"], out _maxWaitTime);
            if (!parseWaitTimeSuccess)
                _maxWaitTime = 10000; //set default
        }


    }
}
