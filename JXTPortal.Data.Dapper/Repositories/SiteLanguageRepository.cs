using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Factories;
using System.Data;
using Dapper;
using JXTPortal.Data.Dapper.Entities.Site;

namespace JXTPortal.Data.Dapper.Repositories
{
    public interface ISiteLanguageRepository : IBaseEntityOperation<SiteLanguageEntity>
    {
        List<SiteLanguageEntity> SelectBySiteID(int siteID);
    }

    public class SiteLanguageRepository : BaseEntityOperation<SiteLanguageEntity>, ISiteLanguageRepository
    {
        public SiteLanguageRepository(IConnectionFactory connectionFactory, string connectionStringName)
            :base(connectionFactory, connectionStringName)
        {
            TableName = "SiteLanguages";
            ColumnNames = new List<string> { "SiteID", "LanguageID", "SiteLanguageName", "ResourceFileName" };
            IdColumnName = "SiteLanguageID";
        }

        public List<SiteLanguageEntity> SelectBySiteID(int siteID)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string columns = IdColumnName + ", " + string.Join(", ", ColumnNames);
                string whereClause = string.Format("SiteID = {0}", siteID);
                var query = string.Format("SELECT {0} FROM dbo.{1} WHERE {2}", columns, TableName, whereClause);
                var entity = dbConnection.Query<SiteLanguageEntity>(query, new { SiteID = siteID }).ToList();
                return entity as List<SiteLanguageEntity>;
            }
        }
    }
}
