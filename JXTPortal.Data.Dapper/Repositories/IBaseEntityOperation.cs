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
    public interface IBaseEntityOperation<T> where T : BaseEntity
    {
        int Insert(T entity);
        void Update(T entity);
        void Delete(int Id);
        T Select(int Id);
        List<T> SelectAll();
    }
}
