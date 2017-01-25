using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Data.Dapper.Entities.Core;

namespace JXTPortal.Service.Dapper
{
    public interface IJobTemplatesService
    {
    }

    public class JobTemplatesService : IJobTemplatesService
    {
        IJobTemplatesRepository jobtemplatesRepository;
        public JobTemplatesService(IJobTemplatesRepository jobtemplatesRepository)
        {
            this.jobtemplatesRepository = jobtemplatesRepository;
        }

        public int Insert(JobTemplatesEntity entity)
        {
            return jobtemplatesRepository.Insert(entity);
        }

        public void Update(JobTemplatesEntity entity)
        {
            jobtemplatesRepository.Update(entity);
        }

        public void Delete(int id)
        {
            jobtemplatesRepository.Delete(id);
        }

        public JobTemplatesEntity Select(int id)
        {
            return jobtemplatesRepository.Select(id);
        }

        public List<JobTemplatesEntity> SelectAll()
        {
            return jobtemplatesRepository.SelectAll();
        }
    }
}
