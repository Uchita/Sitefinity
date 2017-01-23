using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Data.Dapper.Entities.ScreeningQuestions;

namespace JXTPortal.Service.Dapper
{
    public interface IJobScreeningQuestionsService
    {
        List<JobScreeningQuestionsEntity> SelectByJobID(int jobId);
        int Insert(JobScreeningQuestionsEntity entity);
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

        public List<JobScreeningQuestionsEntity> SelectByJobID(int jobId)
        {
            return jobScreeningQuestionsRepository.SelectByJobID(jobId);
        }
    }
}
