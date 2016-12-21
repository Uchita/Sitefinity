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
    public interface IScreeningQuestionsRepository : IBaseEntityOperation<ScreeningQuestionsEntity>
    {
        ScreeningQuestionsEntity SelectByScreeningQuestionId(int screeningQuestionId);
    }

    public class ScreeningQuestionsRepository : BaseEntityOperation<ScreeningQuestionsEntity>, IScreeningQuestionsRepository
    {
        public ScreeningQuestionsRepository(IConnectionFactory connectionFactory, string connectionStringName)
            : base(connectionFactory, connectionStringName)
        {
            TableName = "ScreeningQuestions";
            ColumnNames = new List<string> { "ScreeningQuestionIndex", "QuestionTitle", "LanguageId", "KnockoutValue", "Options", "LastModified", "LastModifiedBy", "LastModifiedByAdvertiserUserId" };
            IdColumnName = "ScreeningQuestionId";
        }

        public ScreeningQuestionsEntity SelectByScreeningQuestionId(int screeningQuestionId)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string columns = IdColumnName + ", " + string.Join(", ", ColumnNames);
                string whereClause = string.Format("ScreeningQuestionsId = {0}", screeningQuestionId);
                var query = string.Format("SELECT {0} FROM dbo.{1} WHERE {2}", columns, TableName, whereClause);
                var entity = dbConnection.Query<ScreeningQuestionsEntity>(query, new { ScreeningQuestionsId = screeningQuestionId });
                return entity as ScreeningQuestionsEntity;
            }
        }
    }
}
