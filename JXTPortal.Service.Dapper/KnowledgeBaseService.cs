using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Data.Dapper.Entities.KnowledgeBase;

namespace JXTPortal.Service.Dapper
{
    public interface IKnowledgeBaseService : IKnowledgeBaseRepository
    {        
    }

    public class KnowledgeBaseService : IKnowledgeBaseService
    {
        IKnowledgeBaseRepository knowledgeBaseRepository;
        public KnowledgeBaseService(IKnowledgeBaseRepository knowledgeBaseRepository)
        {
            this.knowledgeBaseRepository = knowledgeBaseRepository;
        }

        public int Insert(KnowledgeBaseEntity entity)
        {
            return knowledgeBaseRepository.Insert(entity);
        }

        public void Update(KnowledgeBaseEntity entity)
        {
            knowledgeBaseRepository.Update(entity);
        }

        public void Delete(int id)
        {
            knowledgeBaseRepository.Delete(id);
        }

        public KnowledgeBaseEntity Select(int id)
        {
            return knowledgeBaseRepository.Select(id);
        }

        public List<KnowledgeBaseEntity> SelectAll()
        {
            return knowledgeBaseRepository.SelectAll();
        }
    }
}