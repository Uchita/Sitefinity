using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Factories;
using System.Data;
using Dapper;
using JXTPortal.Data.Dapper.Entities.Core;


namespace JXTPortal.Data.Dapper.Repositories
{
    public interface IAdvertiserJobTemplateLogoRepository : IBaseEntityOperation<AdvertiserJobTemplateLogoEntity>
    {
    }

    public class AdvertiserJobTemplateLogoRepository : IAdvertiserJobTemplateLogoRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        private readonly string _connectionStringName;

        public AdvertiserJobTemplateLogoRepository(IConnectionFactory connectionFactory, string connectionStringName)
        {
            this._connectionFactory = connectionFactory;
            _connectionStringName = connectionStringName;
        }

        #region IBaseEntityOperation<AdvertiserJobTemplateLogoRepository> Members

        public int Insert(AdvertiserJobTemplateLogoEntity entity)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                var sbQuery = new StringBuilder();
                sbQuery.Append("INSERT INTO dbo.AdvertiserJobTemplateLogo (AdvertiserID, JobLogoName, JobTemplateLogo, JobTemplateLogoUrl)");
                sbQuery.Append(" VALUES(@AdvertiserJobTemplateLogoID, @AdvertiserID, @JobLogoName, @JobTemplateLogo, @JobTemplateLogoUrl)");
                sbQuery.Append("SELECT CAST(SCOPE_IDENTITY() as int)");
                var Id = dbConnection.Query<int>(sbQuery.ToString(), entity).Single();
                return Id;
            }
        }

        public void Update(AdvertiserJobTemplateLogoEntity entity)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "UPDATE dbo.AdvertiserJobTemplateLogo SET AdvertiserID = @AdvertiserID, JobLogoName = @JobLogoName, JobTemplateLogo = @JobTemplateLogo, JobTemplateLogoUrl = @JobTemplateLogoUrl WHERE AdvertiserJobTemplateLogoID = @AdvertiserJobTemplateLogoID";
                dbConnection.Execute(query, entity);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "DELETE FROM dbo.AdvertiserJobTemplateLogo WHERE AdvertiserJobTemplateLogoID = @AdvertiserJobTemplateLogoID";
                dbConnection.Execute(query, new { AdvertiserJobTemplateLogoID = id });
            }
        }

        public AdvertiserJobTemplateLogoEntity Select(int id)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "SELECT AdvertiserJobTemplateLogoID, AdvertiserID, JobLogoName, JobTemplateLogo, JobTemplateLogoUrl FROM dbo.AdvertiserJobTemplateLogo NOLOCK WHERE AdvertiserJobTemplateLogoID = @AdvertiserJobTemplateLogoID";
                var entity = dbConnection.Query<AdvertiserJobTemplateLogoEntity>(query, new { AdvertiserJobTemplateLogoID = id }).SingleOrDefault();
                return entity;
            }
        }

        public List<AdvertiserJobTemplateLogoEntity> SelectAll()
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "SELECT AdvertiserJobTemplateLogoID, AdvertiserID, JobLogoName, JobTemplateLogo, JobTemplateLogoUrl FROM dbo.AdvertiserJobTemplateLogo NOLOCK";
                var entities = dbConnection.Query<AdvertiserJobTemplateLogoEntity>(query).ToList();
                return entities;
            }
        }

        #endregion
    }
}
