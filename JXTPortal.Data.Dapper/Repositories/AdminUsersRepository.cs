using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Factories;
using System.Data;
using Dapper;
using JXTPortal.Data.Dapper.Entities.Core;

namespace JXTPortal.Data.Dapper.Repositories
{
    public interface IAdminUsersRepository : IBaseEntityOperation<AdminUsersEntity>
    {
        List<AdminUsersEntity> SelectBySiteID(int siteID);
        List<AdminUsersEntity> SelectByAdminUserIDs(List<int> adminUserIds);
    }

    public class AdminUsersRepository : BaseEntityOperation<AdminUsersEntity>, IAdminUsersRepository
    {
        public AdminUsersRepository(IConnectionFactory connectionFactory, string connectionStringName)
            : base(connectionFactory, connectionStringName)
        {
            TableName = "AdminUsers";
            ColumnNames = new List<string> { "AdminRoleID", "SiteID", "UserName", "UserPassword", "FirstName", "Surname", "Email", "LoginAttempts", "LastAttemptDate", "Status" };
            IdColumnName = "AdminUserID";
        }

        public List<AdminUsersEntity> SelectBySiteID(int siteID)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string columns = IdColumnName + ", " + string.Join(", ", ColumnNames);
                string whereClause = string.Format("SiteID = {0}", siteID);
                var query = string.Format("SELECT {0} FROM dbo.{1} WHERE {2}", columns, TableName, whereClause);
                var entity = dbConnection.Query<AdminUsersEntity>(query, new { SiteID = siteID }).ToList();
                return entity as List<AdminUsersEntity>;
            }
        }

        public List<AdminUsersEntity> SelectByAdminUserIDs(List<int> adminUserIds)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string columns = IdColumnName + ", " + string.Join(", ", ColumnNames);
                string whereClause = string.Format("SiteID IN ({0})", string.Join(", ", adminUserIds));
                var query = string.Format("SELECT {0} FROM dbo.{1} WHERE {2}", columns, TableName, whereClause);
                var entity = dbConnection.Query<AdminUsersEntity>(query, null).ToList();
                return entity as List<AdminUsersEntity>;
            }
        }
    }
}
