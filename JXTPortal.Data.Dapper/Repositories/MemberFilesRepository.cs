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
    public interface IMemberFilesRepository : IBaseEntityOperation<MemberFilesEntity>
    {
        List<MemberFilesEntity> SelectAllNonBinary();
    }

    public class MemberFilesRepository : BaseEntityOperation<MemberFilesEntity>, IMemberFilesRepository
    {
        public MemberFilesRepository(IConnectionFactory connectionFactory, string connectionStringName)
            : base(connectionFactory, connectionStringName)
        {
            TableName = "MemberFiles";
            ColumnNames = new List<string> { "MemberID", "MemberFileTypeID", "MemberFileName", "MemberFileSearchExtension", "MemberFileContent", "MemberFileTitle", "LastModifiedDate", "DocumentTypeID", "MemberFileUrl" };
            IdColumnName = "MemberFileID";
        }

        public List<MemberFilesEntity> SelectAllNonBinary()
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "SELECT MemberFileID, MemberID, MemberFileTypeID, MemberFileName, MemberFileSearchExtension, NULL, MemberFileTitle, LastModifiedDate, DocumentTypeID, MemberFileUrl FROM dbo.MemberFiles NOLOCK";
                var entities = dbConnection.Query<MemberFilesEntity>(query).ToList();
                return entities;
            }
        }
    }
}
