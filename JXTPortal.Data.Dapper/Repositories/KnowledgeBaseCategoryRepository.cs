using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Entities.KnowledgeBase;
using JXTPortal.Data.Dapper.Factories;
using System.Data;
using Dapper;

namespace JXTPortal.Data.Dapper.Repositories
{
    public interface IKnowledgeBaseCategoryRepository : IBaseEntityOperation<KnowledgeBaseCategoryEntity>
    {
       List<KnowledgeBaseCategoryEntity> GetCategoryByParentCategoryId(int parentId);
    }

    public class KnowledgeBaseCategoryRepository : IKnowledgeBaseCategoryRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly string _connectionStringName;

        public KnowledgeBaseCategoryRepository(IConnectionFactory connectionFactory, string connectionStringName)
        {
            this._connectionFactory = connectionFactory;
            this._connectionStringName = connectionStringName;
        }

        #region IKnowledgeBaseCategoryRepository Members

        public int Insert(KnowledgeBaseCategoryEntity entity)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                StringBuilder sbQuery = new StringBuilder();
                sbQuery.Append("INSERT INTO dbo.KnowledgeBaseCategories(KnowledgeBaseCategoryName, ParentId, Valid, Sequence, LastModified, LastModifiedBy) ");
                sbQuery.Append("VALUES(@KnowledgeBaseCategoryName, @ParentId, @Valid, @Sequence, @LastModified, @LastModifiedBy); ");
                sbQuery.Append("SELECT CAST(SCOPE_IDENTITY() as int)");
                var Id = dbConnection.Query<int>(sbQuery.ToString(), entity).Single();
                return Id;
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "DELETE FROM dbo.KnowledgeBaseCategories WHERE Id = @Id";
                dbConnection.Execute(query, new { Id = id });
            }
        }

        public void Update(KnowledgeBaseCategoryEntity entity)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "UPDATE dbo.KnowledgeBaseCategories SET KnowledgeBaseCategoryName = @KnowledgeBaseCategoryName, ParentId = @ParentId, Valid = @Valid ,Sequence = @Sequence ,LastModified = @LastModified, LastModifiedBy = @LastModifiedBy WHERE Id = @Id";
                dbConnection.Execute(query, entity);
            }
        }

        public KnowledgeBaseCategoryEntity Select(int id)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "SELECT Id, ParentId, KnowledgeBaseCategoryName, ParentId, Valid, Sequence, LastModified, LastModifiedBy FROM dbo.KnowledgeBaseCategories WHERE Id = @Id";
                var entity = dbConnection.Query<KnowledgeBaseCategoryEntity>(query, new { Id = id }).SingleOrDefault();
                return entity;
            }
        }

        public List<KnowledgeBaseCategoryEntity> SelectAll()
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "SELECT Id, ParentId, KnowledgeBaseCategoryName, Valid, Sequence, LastModified, LastModifiedBy FROM dbo.KnowledgeBaseCategories";
                var entities = dbConnection.Query<KnowledgeBaseCategoryEntity>(query).ToList();
                return entities;
            }
        }

        public List<KnowledgeBaseCategoryEntity> GetCategoryByParentCategoryId(int parentId)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "SELECT Id, KnowledgeBaseCategoryName, Valid, Sequence, LastModified, LastModifiedBy FROM dbo.KnowledgeBaseCategories WHERE ParentId = @ParentId";
                var entities = dbConnection.Query<KnowledgeBaseCategoryEntity>(query, new { ParentId = parentId }).ToList();
                return entities;
            }
        }

        #endregion
    }
}
