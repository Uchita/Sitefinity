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
    public interface IJobScreeningQuestionsRepository : IBaseEntityOperation<JobScreeningQuestionsEntity>
    {
        List<JobScreeningQuestionsEntity> SelectByJobID(int jobId);
    }

    public class JobScreeningQuestionsRepository : BaseEntityOperation<JobScreeningQuestionsEntity>, IJobScreeningQuestionsRepository
    {
        public JobScreeningQuestionsRepository(IConnectionFactory connectionFactory, string connectionStringName)
            : base(connectionFactory, connectionStringName)
        {
            TableName = "JobScreeningQuestions";
            ColumnNames = new List<string> { "JobId", "JobArchiveId", "ScreeningQuestionId", };
            IdColumnName = "JobScreeningQuestionId";
        }

        public List<JobScreeningQuestionsEntity> SelectByJobID(int jobId)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string columns = IdColumnName + ", " + string.Join(", ", ColumnNames);
                string whereClause = string.Format("JobID = {0} OR JobArchiveId = {0}", jobId);
                var query = string.Format("SELECT {0} FROM dbo.{1} WHERE {2}", columns, TableName, whereClause);
                var entity = dbConnection.Query<JobScreeningQuestionsEntity>(query, new { jobId = jobId }).ToList();
                return entity as List<JobScreeningQuestionsEntity>;
            }
        }
    }
}
