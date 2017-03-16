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
        List<ScreeningQuestionsTemplatesEntity> SelectByCreatedByAdvertiserId(int advertiserId);
    }

    public class ScreeningQuestionsTemplatesRepository : BaseEntityOperation<ScreeningQuestionsTemplatesEntity>, IScreeningQuestionsTemplatesRepository
    {
        public ScreeningQuestionsTemplatesRepository(IConnectionFactory connectionFactory, string connectionStringName)
            : base(connectionFactory, connectionStringName)
        {
            TableName = "ScreeningQuestionsTemplates";
            ColumnNames = new List<string> { "TemplateName", "SiteId", "Visible", "LastModified", "LastModifiedBy", "CreatedByAdvertiserId" };
            IdColumnName = "ScreeningQuestionsTemplateId";
        }

        public List<ScreeningQuestionsTemplatesEntity> SelectBySiteId(int siteId)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string columns = IdColumnName + ", " + string.Join(", ", ColumnNames);
                string whereClause = "SiteId = @Id";
                var query = string.Format("SELECT {0} FROM dbo.{1} WHERE {2}", columns, TableName, whereClause);
                var entity = dbConnection.Query<ScreeningQuestionsTemplatesEntity>(query, new { Id = siteId }).ToList();
                return entity as List<ScreeningQuestionsTemplatesEntity>;
            }
        }

        public List<ScreeningQuestionsTemplatesEntity> SelectByAdvertiserId(int advertiserId)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string columns = "sqt.ScreeningQuestionsTemplateId, " + string.Join(", sqt.", ColumnNames);
                string whereClause = "AdvertiserId = @AdvertiserId";
                var query = string.Format(@"SELECT DISTINCT {0} FROM ScreeningQuestionsTemplateOwners sqto WITH (NOLOCK)
                                            INNER JOIN ScreeningQuestionsTemplates sqt WITH (NOLOCK)
                                            ON sqto.ScreeningQuestionsTemplateId = sqt.ScreeningQuestionsTemplateId 
                                            INNER JOIN ScreeningQuestionsMappings sqm WITH (NOLOCK)
                                            ON sqm.ScreeningQuestionsTemplateId = sqt.ScreeningQuestionsTemplateId 
                                            INNER JOIN ScreeningQuestions sq WITH (NOLOCK)
                                            ON sq.ScreeningQuestionId = sqm.ScreeningQuestionId
                                            WHERE {1} AND sq.Visible = 1", columns, whereClause);
                var entity = dbConnection.Query<ScreeningQuestionsTemplatesEntity>(query, new { AdvertiserId = advertiserId}).ToList();
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
                string whereClause = "SiteId = @SiteId AND RowNum >= @RowFrom AND RowNum < @RowTo";
                var query = string.Format(@"SELECT {0}
                                            FROM    ( SELECT    RowNum = ROW_NUMBER() OVER ( ORDER BY {4} ), {0}
                                                      FROM      {2} WITH (NOLOCK)
                                                      WHERE     SiteId = {1}
                                                    ) AS RowConstrainedResult
                                            WHERE   {3}
                                            ORDER BY RowNum", columns, siteId, TableName, whereClause, orderBy);

                var entity = dbConnection.Query<ScreeningQuestionsTemplatesEntity>(query, new { SiteId = siteId, RowFrom = rowFrom, RowTo = rowTo }).ToList();
                return entity as List<ScreeningQuestionsTemplatesEntity>;
            }
        }

        public int GetSiteCount(int siteId)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string whereClause = "SiteId = @SiteId";
                var query = string.Format(@"SELECT COUNT(*) FROM ScreeningQuestionsTemplates WITH (NOLOCK) WHERE {0}", whereClause);

                var count = dbConnection.ExecuteScalar(query, new { SiteId = siteId });

                return (int)count;
            }
        }

        public List<ScreeningQuestionsTemplatesEntity> SelectByCreatedByAdvertiserId(int advertiserId)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string columns = IdColumnName + ", " + string.Join(", ", ColumnNames);
                string whereClause = "CreatedByAdvertiserId = @AdvertiserId";
                var query = string.Format("SELECT {0} FROM dbo.{1} WHERE {2}", columns, TableName, whereClause);
                var entity = dbConnection.Query<ScreeningQuestionsTemplatesEntity>(query, new { AdvertiserId = advertiserId }).ToList();
                return entity as List<ScreeningQuestionsTemplatesEntity>;
            }
        }
    }
}
