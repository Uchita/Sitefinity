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
    public interface ISitesRepository : IBaseEntityOperation<SitesEntity>
    {
    }

    public class SitesRepository : ISitesRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        private readonly string _connectionStringName;

        public SitesRepository(IConnectionFactory connectionFactory, string connectionStringName)
        {
            this._connectionFactory = connectionFactory;
            _connectionStringName = connectionStringName;
        }

        #region IBaseEntityOperation<SitesRepository> Members

        public int Insert(SitesEntity entity)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                var sbQuery = new StringBuilder();
                sbQuery.Append("INSERT INTO dbo.Sites (SiteName, SiteUrl, SiteDescription, SiteAdminLogo, LastModified, LastModifiedBy, Live, MobileEnabled, MobileUrl, SiteAdminLogoUrl)");
                sbQuery.Append(" VALUES(@SiteName, @SiteUrl, @SiteDescription, @SiteAdminLogo, @LastModified, @LastModifiedBy, @Live, @MobileEnabled, @MobileUrl, @SiteAdminLogoUrl)");
                sbQuery.Append("SELECT CAST(SCOPE_IDENTITY() as int)");
                var Id = dbConnection.Query<int>(sbQuery.ToString(), entity).Single();
                return Id;
            }
        }

        public void Update(SitesEntity entity)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "UPDATE dbo.Sites SET SiteName = @SiteName, SiteUrl = @SiteUrl, SiteDescription = @SiteDescription, SiteAdminLogo = @SiteAdminLogo, LastModified = @LastModified, LastModifiedBy = @LastModifiedBy, Live = @Live, MobileEnabled = @MobileEnabled, MobileUrl = @MobileUrl, SiteAdminLogoUrl = @SiteAdminLogoUrl WHERE SiteID = @SiteID";
                dbConnection.Execute(query, entity);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "DELETE FROM dbo.Sites WHERE SiteID = @SiteID";
                dbConnection.Execute(query, new { SiteID = id });
            }
        }

        public SitesEntity Select(int id)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "SELECT SiteID, SiteName, SiteUrl, SiteDescription, SiteAdminLogo, LastModified, LastModifiedBy, Live, MobileEnabled, MobileUrl, SiteAdminLogoUrl FROM dbo.Sites WHERE SiteID = @SiteID";
                var entity = dbConnection.Query<SitesEntity>(query, new { SiteID = id }).SingleOrDefault();
                return entity;
            }
        }

        public List<SitesEntity> SelectAll()
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "SELECT SiteID, SiteName, SiteUrl, SiteDescription, SiteAdminLogo, LastModified, LastModifiedBy, Live, MobileEnabled, MobileUrl, SiteAdminLogoUrl FROM dbo.Sites";
                var entities = dbConnection.Query<SitesEntity>(query).ToList();
                return entities;
            }
        }

        #endregion
    }
}
