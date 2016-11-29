using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Data.Dapper.Entities.Core;

namespace JXTPortal.Service.Dapper
{
    public interface IConsultantsService : IConsultantsRepository
    {
    }

    public class ConsultantsService : IConsultantsService
    {
        IConsultantsRepository consultantsRepository;
        public ConsultantsService(IConsultantsRepository consultantsRepository)
        {
            this.consultantsRepository = consultantsRepository;
        }

        public int Insert(ConsultantsEntity entity)
        {
            return consultantsRepository.Insert(entity);
        }

        public void Update(ConsultantsEntity entity)
        {
            consultantsRepository.Update(entity);
        }

        public void Delete(int id)
        {
            consultantsRepository.Delete(id);
        }

        public ConsultantsEntity Select(int id)
        {
            return consultantsRepository.Select(id);
        }

        public List<ConsultantsEntity> SelectAll()
        {
            return consultantsRepository.SelectAll();
        }
    }
}
