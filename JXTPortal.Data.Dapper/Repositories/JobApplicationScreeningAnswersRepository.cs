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
    public interface IJobApplicationScreeningAnswersRepository : IBaseEntityOperation<JobApplicationScreeningAnswersEntity>
    {
        List<JobApplicationScreeningAnswersEntity> SelectByJobApplicationID(int jobApplicationId);
    }

    public class JobApplicationScreeningAnswersRepository : BaseEntityOperation<JobApplicationScreeningAnswersEntity>, IJobApplicationScreeningAnswersRepository
    {
        public JobApplicationScreeningAnswersRepository(IConnectionFactory connectionFactory, string connectionStringName)
            : base(connectionFactory, connectionStringName)
        {
            TableName = "JobApplicationScreeningAnswers";
            ColumnNames = new List<string> { "ScreeningQuestionId", "Answer", "JobApplicationId" };
            IdColumnName = "JobApplicationScreeningAnswerId";
        }

        public List<JobApplicationScreeningAnswersEntity> SelectByJobApplicationID(int jobApplicationId)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string columns = IdColumnName + ", " + string.Join(", ", ColumnNames);
                string whereClause = "JobApplicationId = @JobApplicationId";
                var query = string.Format("SELECT {0} FROM dbo.{1} WHERE {2}", columns, TableName, whereClause);
                var entity = dbConnection.Query<JobApplicationScreeningAnswersEntity>(query, new { JobApplicationId = jobApplicationId }).ToList();
                return entity as List<JobApplicationScreeningAnswersEntity>;
            }
        }
    }
}
