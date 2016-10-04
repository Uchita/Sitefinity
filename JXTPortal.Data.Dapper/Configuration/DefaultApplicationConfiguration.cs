using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace JXTPortal.Data.Dapper.Configuration
{
    public class DefaultApplicationConfiguration : IApplicationConfiguration
    {
        #region IApplicationConfiguration Members

        public string GetConnectionString(string connectionStringName)
        {
            return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }

        public string GetApplicationSetting(string settingName)
        {
            return ConfigurationManager.AppSettings[settingName];
        }

        #endregion
    }
}
