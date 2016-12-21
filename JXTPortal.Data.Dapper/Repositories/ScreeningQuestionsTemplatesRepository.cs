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
    }

    public class ScreeningQuestionsTemplatesRepository : BaseEntityOperation<ScreeningQuestionsTemplatesEntity>, IScreeningQuestionsTemplatesRepository
    {
        public ScreeningQuestionsTemplatesRepository(IConnectionFactory connectionFactory, string connectionStringName)
            : base(connectionFactory, connectionStringName)
        {
            TableName = "ScreeningQuestionsTemplates";
            ColumnNames = new List<string> { "TemplateName", "SiteId", "Visible" };
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
    }
}
