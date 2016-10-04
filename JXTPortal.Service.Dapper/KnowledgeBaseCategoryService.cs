using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Entities.KnowledgeBase;
using JXTPortal.Data.Dapper.Repositories;

namespace JXTPortal.Service.Dapper
{
    public interface IKnowledgeBaseCategoryService : IKnowledgeBaseCategoryRepository
    {
        List<KnowledgeBaseCategoryEntity> GetCategoryByParentCategoryId(int parentId);
    }

    public class KnowledgeBaseCategoryService : IKnowledgeBaseCategoryService
    {
        IKnowledgeBaseCategoryRepository knowledgeBaseCategoryRepository;

        public KnowledgeBaseCategoryService(IKnowledgeBaseCategoryRepository knowledgeBaseCategoryRepository)
        {
            this.knowledgeBaseCategoryRepository = knowledgeBaseCategoryRepository;
        }
        
        #region IKnowledgeBaseCategoryService Members

        public int Insert(KnowledgeBaseCategoryEntity entity)
        {
            return knowledgeBaseCategoryRepository.Insert(entity);
        }

        public void Update(KnowledgeBaseCategoryEntity entity)
        {
            knowledgeBaseCategoryRepository.Update(entity);
        }

        public void Delete(int id)
        {
            knowledgeBaseCategoryRepository.Delete(id);
        }

        public KnowledgeBaseCategoryEntity Select(int id)
        {
            return knowledgeBaseCategoryRepository.Select(id);
        }

        public List<KnowledgeBaseCategoryEntity> SelectAll()
        {
            return knowledgeBaseCategoryRepository.SelectAll();
        }

        public List<KnowledgeBaseCategoryEntity> GetCategoryByParentCategoryId(int parentId)
        {
            return knowledgeBaseCategoryRepository.GetCategoryByParentCategoryId(parentId);
        }

        #endregion
    }
}