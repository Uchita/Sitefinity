using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using JXTPortal.Data.Dapper.Configuration;
using System.Data.SqlClient;

namespace JXTPortal.Data.Dapper.Factories
{
    public class SqlServerConnectionFactory : IConnectionFactory
    {
        private readonly IApplicationConfiguration _applicationConfiguration;

        public SqlServerConnectionFactory(IApplicationConfiguration configuration)
        {
            _applicationConfiguration = configuration;
        }

        public DbConnection Create(string connectionStringName)
        {
            return new SqlConnection(_applicationConfiguration.GetConnectionString(connectionStringName));
        }
    }
}
