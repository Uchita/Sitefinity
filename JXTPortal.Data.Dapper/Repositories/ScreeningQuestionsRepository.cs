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
        List<ScreeningQuestionsEntity> SelectByScreeningQuestionsTemplateIdLanguageId(int templateId, int languageId);
        List<ScreeningQuestionsEntity> SelectByScreeningQuestionsTemplateId(int templateId);
        List<ScreeningQuestionsEntity> SelectByIds(List<int> screeningQuestionIds);
    }

    public class ScreeningQuestionsRepository : BaseEntityOperation<ScreeningQuestionsEntity>, IScreeningQuestionsRepository
    {
        public ScreeningQuestionsRepository(IConnectionFactory connectionFactory, string connectionStringName)
            : base(connectionFactory, connectionStringName)
        {
            TableName = "ScreeningQuestions";
            ColumnNames = new List<string> { "ScreeningQuestionIndex", "QuestionTitle", "QuestionType", "Mandatory", "LanguageId", "KnockoutValue", "Options", "Visible", "LastModified", "LastModifiedBy", "LastModifiedByAdvertiserUserId" };
            IdColumnName = "ScreeningQuestionId";
        }

        public ScreeningQuestionsEntity SelectByScreeningQuestionId(int screeningQuestionId)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string columns = IdColumnName + ", " + string.Join(", ", ColumnNames);
                string whereClause = "ScreeningQuestionsId = @Id";
                var query = string.Format("SELECT {0} FROM dbo.{1} WHERE {2}", columns, TableName, whereClause);
                var entity = dbConnection.Query<ScreeningQuestionsEntity>(query, new { Id = screeningQuestionId });
                return entity as ScreeningQuestionsEntity;
            }
        }

        public List<ScreeningQuestionsEntity> SelectByScreeningQuestionsTemplateId(int templateId)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();

                string columns = "sq.ScreeningQuestionId as ScreeningQuestionId, " + string.Join(", ", ColumnNames);
                string whereClause = "ScreeningQuestionsTemplateId = @TemplateId";
                var query = string.Format(@"SELECT {0} FROM ScreeningQuestionsMappings sqm WITH (NOLOCK)
                                            INNER JOIN ScreeningQuestions sq WITH (NOLOCK)
                                            ON sqm.ScreeningQuestionId = sq.ScreeningQuestionId WHERE {1} ORDER BY ScreeningQuestionIndex", columns, whereClause);
                var entity = dbConnection.Query<ScreeningQuestionsEntity>(query, new { TemplateId = templateId}).ToList();
                return entity;
            }
        }

        public List<ScreeningQuestionsEntity> SelectByScreeningQuestionsTemplateIdLanguageId(int templateId, int languageId)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();

                string columns = "sq.ScreeningQuestionId as ScreeningQuestionId, " + string.Join(", ", ColumnNames);
                string whereClause = "ScreeningQuestionsTemplateId = @TemplateId AND LanguageID = @LanguageId";
                var query = string.Format(@"SELECT {0} FROM ScreeningQuestionsMappings sqm WITH (NOLOCK)
                                            INNER JOIN ScreeningQuestions sq WITH (NOLOCK)
                                            ON sqm.ScreeningQuestionId = sq.ScreeningQuestionId WHERE {1} ORDER BY ScreeningQuestionIndex", columns, whereClause);
                var entity = dbConnection.Query<ScreeningQuestionsEntity>(query, new { TemplateId = templateId, LanguageId = languageId}).ToList();
                return entity;
            }
        }

        public List<ScreeningQuestionsEntity> SelectByIds(List<int> screeningQuestionIds)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string columns = IdColumnName + ", " + string.Join(", ", ColumnNames);
                string whereClause = "ScreeningQuestionId IN (@Ids)";
                var query = string.Format("SELECT {0} FROM dbo.{1} WHERE {2}", columns, TableName, whereClause);
                var entity = dbConnection.Query<ScreeningQuestionsEntity>(query, new { Ids = string.Join(",", screeningQuestionIds)});
                return entity as List<ScreeningQuestionsEntity>;
            }
        }
    }
}
