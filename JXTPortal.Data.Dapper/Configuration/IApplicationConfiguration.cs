using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Data.Dapper.Configuration
{
    public interface IApplicationConfiguration
    {
        string GetConnectionString(string connectionStringName);
        string GetApplicationSetting(string settingName);
    }
}
