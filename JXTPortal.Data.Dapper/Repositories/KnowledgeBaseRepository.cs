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

    public class KnowledgeBaseRepository : BaseEntityOperation<KnowledgeBaseEntity>, IKnowledgeBaseRepository
    {
        public KnowledgeBaseRepository(IConnectionFactory connectionFactory, string connectionStringName)
            :base(connectionFactory, connectionStringName)
        {
            TableName = "KnowledgeBase";
            IdColumnName = "Id"; 
            ColumnNames = new List<string>{"KnowledgeBaseCategoryID", "Subject", "Content", "Valid", "Sequence", "LastModified", "LastModifiedBy", "SearchField", "Tags"};
        }
    }
}
