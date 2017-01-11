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

    public class KnowledgeBaseCategoryRepository : BaseEntityOperation<KnowledgeBaseCategoryEntity>, IKnowledgeBaseCategoryRepository
    {
        public KnowledgeBaseCategoryRepository(IConnectionFactory connectionFactory, string connectionStringName)
            : base(connectionFactory, connectionStringName)
        {
            TableName = "KnowledgeBaseCategories";
            IdColumnName = "Id";
            ColumnNames = new List<string> { "KnowledgeBaseCategoryName", "ParentId", "Valid", "Sequence", "LastModified", "LastModifiedBy" };
        }

        
        #region IKnowledgeBaseCategoryRepository Members

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
