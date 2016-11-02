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
    public interface IJobTemplatesRepository : IBaseEntityOperation<JobTemplatesEntity>
    {
    }

    public class JobTemplatesRepository : IJobTemplatesRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        private readonly string _connectionStringName;

        public JobTemplatesRepository(IConnectionFactory connectionFactory, string connectionStringName)
        {
            this._connectionFactory = connectionFactory;
            _connectionStringName = connectionStringName;
        }

        #region IBaseEntityOperation<JobTemplatesRepository> Members

        public int Insert(JobTemplatesEntity entity)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                var sbQuery = new StringBuilder();
                sbQuery.Append("INSERT INTO dbo.JobTemplates (SiteID, JobTemplateDescription, JobTemplateHTML, GlobalTemplate, LastModifiedBy, LastModified, JobTemplateLogo, AdvertiserID, JobTemplateLogoURL)");
                sbQuery.Append(" VALUES(@SiteID, @JobTemplateDescription, @JobTemplateHTML, @GlobalTemplate, @LastModifiedBy, @LastModified, @JobTemplateLogo, @AdvertiserID, @JobTemplateLogoURL)");
                sbQuery.Append("SELECT CAST(SCOPE_IDENTITY() as int)");
                var Id = dbConnection.Query<int>(sbQuery.ToString(), entity).Single();
                return Id;
            }
        }

        public void Update(JobTemplatesEntity entity)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "UPDATE dbo.JobTemplates SET SiteID = @SiteID, JobTemplateDescription = @JobTemplateDescription, JobTemplateHTML = @JobTemplateHTML, GlobalTemplate = @GlobalTemplate, LastModifiedBy = @LastModifiedBy, LastModified = @LastModified, JobTemplateLogo= @JobTemplateLogo, AdvertiserID = @AdvertiserID, JobTemplateLogoURL = @JobTemplateLogoURL WHERE JobTemplateID = @JobTemplateID";
                dbConnection.Execute(query, entity);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "DELETE FROM dbo.JobTemplates WHERE JobTemplateID = @JobTemplateID";
                dbConnection.Execute(query, new { JobTemplateID = id });
            }
        }

        public JobTemplatesEntity Select(int id)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "SELECT JobTemplateID, SiteID, JobTemplateDescription, JobTemplateHTML, GlobalTemplate, LastModifiedBy, LastModified, JobTemplateLogo, AdvertiserID, JobTemplateLogoURL FROM dbo.JobTemplates WHERE JobTemplateID = @JobTemplateID";
                var entity = dbConnection.Query<JobTemplatesEntity>(query, new { SiteID = id }).SingleOrDefault();
                return entity;
            }
        }

        public List<JobTemplatesEntity> SelectAll()
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "SELECT JobTemplateID, SiteID, JobTemplateDescription, JobTemplateHTML, GlobalTemplate, LastModifiedBy, LastModified, JobTemplateLogo, AdvertiserID, JobTemplateLogoURL FROM dbo.JobTemplates";
                var entities = dbConnection.Query<JobTemplatesEntity>(query).ToList();
                return entities;
            }
        }

        #endregion
    }
}
