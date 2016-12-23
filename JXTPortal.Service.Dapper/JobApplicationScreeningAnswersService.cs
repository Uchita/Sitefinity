using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Data.Dapper.Entities.ScreeningQuestions;

namespace JXTPortal.Service.Dapper
{
    public interface IJobApplicationScreeningAnswersService
    {
    }

    public class JobApplicationScreeningAnswersService : IJobApplicationScreeningAnswersService
    {
        IJobApplicationScreeningAnswersRepository jobApplicationScreeningAnswersRepository;
        public JobApplicationScreeningAnswersService(IJobApplicationScreeningAnswersRepository jobApplicationScreeningAnswersRepository)
        {
            this.jobApplicationScreeningAnswersRepository = jobApplicationScreeningAnswersRepository;
        }

        public int Insert(JobApplicationScreeningAnswersEntity entity)
        {
            return jobApplicationScreeningAnswersRepository.Insert(entity);
        }

        public void Update(JobApplicationScreeningAnswersEntity entity)
        {
            jobApplicationScreeningAnswersRepository.Update(entity);
        }

        public void Delete(int id)
        {
            jobApplicationScreeningAnswersRepository.Delete(id);
        }

        public JobApplicationScreeningAnswersEntity Select(int id)
        {
            return jobApplicationScreeningAnswersRepository.Select(id);
        }

        public List<JobApplicationScreeningAnswersEntity> SelectAll()
        {
            return jobApplicationScreeningAnswersRepository.SelectAll();
        }

        public List<JobApplicationScreeningAnswersEntity> SelectByJobApplicationID(int jobApplicationId)
        {
            return jobApplicationScreeningAnswersRepository.SelectByJobApplicationID(jobApplicationId);
        }
    }
}
