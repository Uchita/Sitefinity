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
    public interface IScreeningQuestionsMappingsRepository : IBaseEntityOperation<ScreeningQuestionsMappingsEntity>
    {
        List<ScreeningQuestionsMappingsEntity> SelectByScreeningQuestionsTemplateId(int jobId);
        void Delete(int templateId, int questionId);
    }

    public class ScreeningQuestionsMappingsRepository : BaseEntityOperation<ScreeningQuestionsMappingsEntity>, IScreeningQuestionsMappingsRepository
    {
        public ScreeningQuestionsMappingsRepository(IConnectionFactory connectionFactory, string connectionStringName)
            : base(connectionFactory, connectionStringName)
        {
            TableName = "ScreeningQuestionsMappings";
            ColumnNames = new List<string> { "ScreeningQuestionsTemplateId", "ScreeningQuestionId" };
            IdColumnName = "ScreeningQuestionsMappingId";
        }

        public List<ScreeningQuestionsMappingsEntity> SelectByScreeningQuestionsTemplateId(int screeningQuestionsTemplateId)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string columns = IdColumnName + ", " + string.Join(", ", ColumnNames);
                string whereClause = "ScreeningQuestionsTemplateId = @Id";
                var query = string.Format("SELECT {0} FROM dbo.{1} WHERE {2}", columns, TableName, whereClause);
                var entity = dbConnection.Query<ScreeningQuestionsMappingsEntity>(query, new { Id = screeningQuestionsTemplateId }).ToList();
                return entity as List<ScreeningQuestionsMappingsEntity>;
            }
        }

        public void Delete(int templateId, int questionId)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string whereClause = "ScreeningQuestionsTemplateId = @TemplateId AND ScreeningQuestionId = @QuestionId";
                var query = string.Format("DELETE FROM {0} dbo.{1} WHERE {1}", TableName, whereClause);
                dbConnection.Execute(query, new { TemplateId = templateId, QuestionId = questionId});
            }
        }
    }
}
