using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Data.Dapper.Entities.ScreeningQuestions;

namespace JXTPortal.Service.Dapper
{
    public interface IJobScreeningQuestionsService : IJobScreeningQuestionsRepository
    {
    }

    public class JobScreeningQuestionsService : IJobScreeningQuestionsService
    {
        IJobScreeningQuestionsRepository jobScreeningQuestionsRepository;
        public JobScreeningQuestionsService(IJobScreeningQuestionsRepository jobScreeningQuestionsRepository)
        {
            this.jobScreeningQuestionsRepository = jobScreeningQuestionsRepository;
        }

        public int Insert(JobScreeningQuestionsEntity entity)
        {
            return jobScreeningQuestionsRepository.Insert(entity);
        }

        public void Update(JobScreeningQuestionsEntity entity)
        {
            jobScreeningQuestionsRepository.Update(entity);
        }

        public void Delete(int id)
        {
            jobScreeningQuestionsRepository.Delete(id);
        }

        public JobScreeningQuestionsEntity Select(int id)
        {
            return jobScreeningQuestionsRepository.Select(id);
        }

        public List<JobScreeningQuestionsEntity> SelectAll()
        {
            return jobScreeningQuestionsRepository.SelectAll();
        }

        public List<JobScreeningQuestionsEntity> SelectByJobID(int jobId)
        {
            return jobScreeningQuestionsRepository.SelectByJobID(jobId);
        }
    }
}
