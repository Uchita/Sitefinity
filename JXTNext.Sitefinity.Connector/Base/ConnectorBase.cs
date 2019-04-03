using JXTNext.Sitefinity.Common.Models;
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
        const string API_HTTP_HEADER_DOMAIN_KEY = "jauth-site";
        const string API_HTTP_HEADER_USER_KEY = "jauth-email";

        public string CONFIG_DataAccessTarget => _accessTargetPath;
        public int HTTP_Requests_MaxWaitTime => _maxWaitTime;
        public Dictionary<string, string> HTTP_Request_HeaderValues => _headerValues;

        internal bool Settings_LegacyJobSource = true;

        string _accessTargetPath;
        int _maxWaitTime;
        Dictionary<string, string> _headerValues;

        public ConnectorBase(IRequestSession session)
        {
            _accessTargetPath = ConfigurationManager.AppSettings["JXTNextAPI_Path"]; ;

            bool parseWaitTimeSuccess = int.TryParse(ConfigurationManager.AppSettings["JXTNextAPI_WaitTimeMs"], out _maxWaitTime);
            if (!parseWaitTimeSuccess)
                _maxWaitTime = 10000; //set default

            if (session != null)
                ProcessHeaderValuesForSession(session);

        }

        public void ProcessHeaderValuesForSessionOverride(string email)
        {
            if( _headerValues != null )
            {
                if (_headerValues.Keys.Contains(API_HTTP_HEADER_USER_KEY))
                    _headerValues[API_HTTP_HEADER_USER_KEY] = email;
                else
                    _headerValues.Add(API_HTTP_HEADER_USER_KEY, email);
            }
        }

        private void ProcessHeaderValuesForSession(IRequestSession session)
        {
            _headerValues = new Dictionary<string, string>();
           // _headerValues.Add(API_HTTP_HEADER_DOMAIN_KEY, session.Domain);
            _headerValues.Add(API_HTTP_HEADER_DOMAIN_KEY, "winstonfox.jxtnext.net");
            if ( session.UserEmail != null)
                _headerValues.Add(API_HTTP_HEADER_USER_KEY, session.UserEmail);
        }

    }
}
