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
        void DeleteByJobID(int jobId);
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
                string whereClause = "JobID = @JobId OR JobArchiveId = @JobArchiveId";
                var query = string.Format("SELECT {0} FROM dbo.{1} WHERE {2}", columns, TableName, whereClause);
                var entity = dbConnection.Query<JobScreeningQuestionsEntity>(query, new { JobId = jobId, JobArchiveId = jobId }).ToList();
                return entity as List<JobScreeningQuestionsEntity>;
            }
        }

        public void DeleteByJobID(int jobId)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string whereClause = "JobID = @JobId OR JobArchiveId = @JobArchiveId";
                var query = string.Format("DELETE FROM dbo.{0} WHERE {1}", TableName, whereClause);
                dbConnection.Execute(query, new { JobId = jobId, JobArchiveId = jobId });
            }
        }
    }
}
