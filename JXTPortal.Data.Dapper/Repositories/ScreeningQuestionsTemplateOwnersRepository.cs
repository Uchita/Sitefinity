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
    public interface IScreeningQuestionsTemplateOwnersRepository : IBaseEntityOperation<ScreeningQuestionsTemplateOwnersEntity>
    {
        List<ScreeningQuestionsTemplateOwnersEntity> SelectByAdvertiserId(int advertiserId);
    }

    public class ScreeningQuestionsTemplateOwnersRepository : BaseEntityOperation<ScreeningQuestionsTemplateOwnersEntity>, IScreeningQuestionsTemplateOwnersRepository
    {
        public ScreeningQuestionsTemplateOwnersRepository(IConnectionFactory connectionFactory, string connectionStringName)
            : base(connectionFactory, connectionStringName)
        {
            TableName = "ScreeningQuestionsTemplateOwners";
            ColumnNames = new List<string> { "ScreeningQuestionsTemplateId", "AdvertiserId" };
            IdColumnName = "ScreeningQuestionsTemplatesOwnerId";
        }

        public List<ScreeningQuestionsTemplateOwnersEntity> SelectByAdvertiserId(int advertiserId)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string columns = IdColumnName + ", " + string.Join(", ", ColumnNames);
                string whereClause = string.Format("AdvertiserId = {0}", advertiserId);
                var query = string.Format("SELECT {0} FROM dbo.{1} WHERE {2}", columns, TableName, whereClause);
                var entity = dbConnection.Query<ScreeningQuestionsTemplateOwnersEntity>(query, new { AdvertiserId = advertiserId }).ToList();
                return entity as List<ScreeningQuestionsTemplateOwnersEntity>;
            }
        }
    }
}
