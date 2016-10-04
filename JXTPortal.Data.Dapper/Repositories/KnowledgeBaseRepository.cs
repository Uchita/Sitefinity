using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Factories;
using System.Data;
using Dapper;
using JXTPortal.Data.Dapper.Entities.KnowledgeBase;

namespace JXTPortal.Data.Dapper.Repositories
{
    public interface IKnowledgeBaseRepository : IBaseEntityOperation<KnowledgeBaseEntity>
    {
    }

    public class KnowledgeBaseRepository : IKnowledgeBaseRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        private readonly string _connectionStringName;

        public KnowledgeBaseRepository(IConnectionFactory connectionFactory, string connectionStringName)
        {
            this._connectionFactory = connectionFactory;
            _connectionStringName = connectionStringName;
        }

        #region IBaseEntityOperation<KnowledgeBaseRepository> Members

        public int Insert(KnowledgeBaseEntity entity)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                var sbQuery = new StringBuilder();
                sbQuery.Append("INSERT INTO dbo.KnowledgeBase(KnowledgeBaseCategoryID, Subject, Content, Valid, Sequence, LastModified, LastModifiedBy, SearchField, Tags)");
                sbQuery.Append(" VALUES(@KnowledgeBaseCategoryID, @Subject, @Content, @Valid, @Sequence, @LastModified, @LastModifiedBy, @SearchField, @Tags)");
                sbQuery.Append("SELECT CAST(SCOPE_IDENTITY() as int)");
                var Id = dbConnection.Query<int>(sbQuery.ToString(), entity).Single();
                return Id;
            }
        }

        public void Update(KnowledgeBaseEntity entity)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "UPDATE dbo.KnowledgeBase SET KnowledgeBaseCategoryID = @KnowledgeBaseCategoryID, Subject = @Subject, Content = @Content, Valid = @Valid, Sequence = @Sequence, LastModified = @LastModified, LastModifiedBy = @LastModifiedBy, SearchField = @SearchField, Tags = @Tags WHERE Id = @Id";
                dbConnection.Execute(query, entity);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "DELETE FROM dbo.KnowledgeBase WHERE Id = @Id";
                dbConnection.Execute(query, new { Id = id });
            }
        }

        public KnowledgeBaseEntity Select(int id)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "SELECT Id, KnowledgeBaseCategoryID, Subject, Content, Valid, Sequence,LastModified, LastModifiedBy, SearchField, Tags FROM dbo.KnowledgeBase WHERE Id = @Id";
                var entity = dbConnection.Query<KnowledgeBaseEntity>(query, new { Id = id }).SingleOrDefault();
                return entity;
            }
        }

        public List<KnowledgeBaseEntity> SelectAll()
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "SELECT Id, KnowledgeBaseCategoryID, Subject, Content, Valid, Sequence,LastModified, LastModifiedBy, SearchField, Tags FROM dbo.KnowledgeBase";
                var entities = dbConnection.Query<KnowledgeBaseEntity>(query).ToList();
                return entities;
            }
        }

        #endregion
    }
}
