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
    }

    public class MemberFilesRepository : IMemberFilesRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        private readonly string _connectionStringName;

        public MemberFilesRepository(IConnectionFactory connectionFactory, string connectionStringName)
        {
            this._connectionFactory = connectionFactory;
            _connectionStringName = connectionStringName;
        }

        #region IBaseEntityOperation<MemberFilesRepository> Members

        public int Insert(MemberFilesEntity entity)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                var sbQuery = new StringBuilder();
                sbQuery.Append("INSERT INTO dbo.MemberFiles (MemberID, MemberFileTypeID, MemberFileName, MemberFileSearchExtension, MemberFileContent, MemberFileTitle, LastModifiedDate, DocumentTypeID, MemberFileUrl)");
                sbQuery.Append(" VALUES(@MemberID, @MemberFileTypeID, @MemberFileName, @MemberFileSearchExtension, @MemberFileContent, @MemberFileTitle, @LastModifiedDate, @DocumentTypeID, @MemberFileUrl)");
                sbQuery.Append("SELECT CAST(SCOPE_IDENTITY() as int)");
                var Id = dbConnection.Query<int>(sbQuery.ToString(), entity).Single();
                return Id;
            }
        }

        public void Update(MemberFilesEntity entity)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "UPDATE dbo.MemberFiles SET MemberID = @MemberID, MemberFileTypeID = @MemberFileTypeID, MemberFileName = @MemberFileName, MemberFileSearchExtension = @MemberFileSearchExtension, MemberFileContent = @MemberFileContent, MemberFileTitle = @MemberFileTitle, LastModifiedDate = @LastModifiedDate, DocumentTypeID = @DocumentTypeID, MemberFileUrl = @MemberFileUrl WHERE MemberFileID = @MemberFileID";
                dbConnection.Execute(query, entity);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "DELETE FROM dbo.MemberFiles WHERE MemberFileID = @MemberFileID";
                dbConnection.Execute(query, new { MemberFileID = id });
            }
        }

        public MemberFilesEntity Select(int id)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "SELECT MemberFileID, MemberID, MemberFileTypeID, MemberFileName, MemberFileSearchExtension, MemberFileContent, MemberFileTitle, LastModifiedDate, DocumentTypeID, MemberFileUrl FROM dbo.MemberFiles NOLOCK WHERE MemberFileID = @MemberFileID";
                var entity = dbConnection.Query<MemberFilesEntity>(query, new { MemberFileID = id }).SingleOrDefault();
                return entity;
            }
        }

        public List<MemberFilesEntity> SelectAll()
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                var query = "SELECT MemberFileID, MemberID, MemberFileTypeID, MemberFileName, MemberFileSearchExtension, MemberFileContent, MemberFileTitle, LastModifiedDate, DocumentTypeID, MemberFileUrl FROM dbo.MemberFiles NOLOCK";
                var entities = dbConnection.Query<MemberFilesEntity>(query).ToList();
                return entities;
            }
        }

        #endregion
    }
}
