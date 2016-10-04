using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace JXTPortal.Data.Dapper.Factories
{
    public interface IConnectionFactory
    {
        DbConnection Create(string connectionStringName);
    }
}
