using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Factories;
using System.Data;
using Dapper;
using JXTPortal.Data.Dapper.Entities.ScreeningQuestions;

namespace JXTPortal.Data.Dapper.Repositories
{
    public interface IScreeningQuestionsTemplatesRepository : IBaseEntityOperation<ScreeningQuestionsTemplatesEntity>
    {
        List<ScreeningQuestionsTemplatesEntity> SelectBySiteId(int advertiserId);
        List<ScreeningQuestionsTemplatesEntity> GetPaged(int siteId, int rowFrom, int rowTo, string orderBy);
        int GetSiteCount(int siteId);
        List<ScreeningQuestionsTemplatesEntity> SelectByAdvertiserId(int advertiserId);
    }

    public class ScreeningQuestionsTemplatesRepository : BaseEntityOperation<ScreeningQuestionsTemplatesEntity>, IScreeningQuestionsTemplatesRepository
    {
        public ScreeningQuestionsTemplatesRepository(IConnectionFactory connectionFactory, string connectionStringName)
            : base(connectionFactory, connectionStringName)
        {
            TableName = "ScreeningQuestionsTemplates";
            ColumnNames = new List<string> { "TemplateName", "SiteId", "Visible", "LastModified", "LastModifiedBy" };
            IdColumnName = "ScreeningQuestionsTemplateId";
        }

        public List<ScreeningQuestionsTemplatesEntity> SelectBySiteId(int siteId)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string columns = IdColumnName + ", " + string.Join(", ", ColumnNames);
                string whereClause = string.Format("SiteId = {0}", siteId);
                var query = string.Format("SELECT {0} FROM dbo.{1} WHERE {2}", columns, TableName, whereClause);
                var entity = dbConnection.Query<ScreeningQuestionsTemplatesEntity>(query, new { SiteId = siteId }).ToList();
                return entity as List<ScreeningQuestionsTemplatesEntity>;
            }
        }

        public List<ScreeningQuestionsTemplatesEntity> SelectByAdvertiserId(int advertiserId)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string columns = "sqt.ScreeningQuestionsTemplateId, " + string.Join(", ", ColumnNames);
                string whereClause = string.Format("AdvertiserId = {0}", advertiserId);
                var query = string.Format(@"SELECT {0} FROM ScreeningQuestionsTemplateOwners sqto WITH (NOLOCK)
                                            INNER JOIN ScreeningQuestionsTemplates sqt WITH (NOLOCK)
                                            ON sqto.ScreeningQuestionsTemplateId = sqt.ScreeningQuestionsTemplateId WHERE {1}", columns, whereClause);
                var entity = dbConnection.Query<ScreeningQuestionsTemplatesEntity>(query, null).ToList();
                return entity as List<ScreeningQuestionsTemplatesEntity>;
            }
        }

        public List<ScreeningQuestionsTemplatesEntity> GetPaged(int siteId, int rowFrom, int rowTo, string orderBy = "")
        {
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = IdColumnName;
            }

            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string columns = IdColumnName + ", " + string.Join(", ", ColumnNames);
                string whereClause = string.Format("SiteId = {0} AND RowNum >= {1} AND RowNum < {2}", siteId, rowFrom, rowTo);
                var query = string.Format(@"SELECT {0}
                                            FROM    ( SELECT    RowNum = ROW_NUMBER() OVER ( ORDER BY {4} ), {0}
                                                      FROM      {2} WITH (NOLOCK)
                                                      WHERE     SiteId = {1}
                                                    ) AS RowConstrainedResult
                                            WHERE   {3}
                                            ORDER BY RowNum", columns, siteId, TableName, whereClause, orderBy);

                var entity = dbConnection.Query<ScreeningQuestionsTemplatesEntity>(query, null).ToList();
                return entity as List<ScreeningQuestionsTemplatesEntity>;
            }
        }

        public int GetSiteCount(int siteId)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string whereClause = string.Format("SiteId = {0}", siteId);
                var query = string.Format(@"SELECT COUNT(*) FROM ScreeningQuestionsTemplates WITH (NOLOCK) WHERE {0}", whereClause);

                var count = dbConnection.ExecuteScalar(query);

                return (int)count;
            }
        }
    }
}
