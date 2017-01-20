using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Factories;
using System.Data;
using Dapper;
using JXTPortal.Data.Dapper.Entities.KnowledgeBase;
using JXTPortal.Data.Dapper.Entities;

namespace JXTPortal.Data.Dapper.Repositories
{
    public abstract class BaseEntityOperation<T> : IBaseEntityOperation<T> where T : BaseEntity
    {
        protected readonly IConnectionFactory _connectionFactory;
        protected readonly string _connectionStringName;

        protected string TableName { get; set; }
        protected List<string> ColumnNames { get; set; }
        protected string IdColumnName { get; set; }

        public BaseEntityOperation(IConnectionFactory connectionFactory, string connectionStringName)
        {
            IdColumnName = "Id";
            _connectionFactory = connectionFactory;
            _connectionStringName = connectionStringName;
        }

        public virtual int Insert(T entity)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                string columns = string.Join(", ", ColumnNames);
                string values = "@" + string.Join(", @", ColumnNames);
                string query = string.Format("INSERT INTO dbo.{0}({1}) VALUES({2}) SELECT CAST(SCOPE_IDENTITY() as int)", TableName, columns, values);

                var Id = dbConnection.Query<int>(query, entity).Single();
                return Id;
            }
        }

        public virtual void Delete(int id)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string whereClause = string.Format("{0} = @Id", IdColumnName);
                var query = string.Format("DELETE FROM dbo.{0} WHERE {1}", TableName, whereClause);
                dbConnection.Execute(query, new { Id = id });
            }
        }

        public virtual void Update(T entity)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                List<string> values = new List<string>();

                foreach (string col in ColumnNames)
                {
                    values.Add(string.Format("{0} = @{0}", col));
                }

                string valueString = string.Join(", ", values);
                string whereClause = string.Format("{0} = @{0}", IdColumnName);
                var query = string.Format("UPDATE dbo.{0} SET {1} WHERE {2}", TableName, valueString, whereClause);

                dbConnection.Execute(query, entity);
            }
        }

        public virtual T Select(int id)
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string columns = IdColumnName + ", " + string.Join(", ", ColumnNames);
                string whereClause = string.Format("{0} = @Id", IdColumnName);
                var query = string.Format("SELECT {0} FROM dbo.{1} WHERE {2}", columns, TableName, whereClause);
                var entity = dbConnection.Query<T>(query, new { Id = id }).SingleOrDefault();
                return entity as T;
            }
        }

        public virtual List<T> SelectAll()
        {
            using (IDbConnection dbConnection = _connectionFactory.Create(_connectionStringName))
            {
                dbConnection.Open();
                string columns = string.Join(", ", ColumnNames);
                var query = string.Format("SELECT {0} FROM dbo.{1}", columns, TableName);
                var entities = dbConnection.Query<T>(query).Cast<T>().ToList();
                return entities;
            }
        }
    }
}
