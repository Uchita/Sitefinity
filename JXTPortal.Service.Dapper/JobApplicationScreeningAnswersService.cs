using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Data.Dapper.Entities.ScreeningQuestions;
using JXTPortal.Service.Dapper.Models;

namespace JXTPortal.Service.Dapper
{
    public interface IJobApplicationScreeningAnswersService
    {
        int Insert(JobApplicationScreeningAnswersEntity entity);
        JobApplicationScreeningAnswerDetail SelectByJobApplicationId(int jobApplicationId);
    }

    public class JobApplicationScreeningAnswersService : IJobApplicationScreeningAnswersService
    {
        IJobApplicationScreeningAnswersRepository jobApplicationScreeningAnswersRepository;
        IScreeningQuestionsRepository screeningQuestionsRepository;

        public JobApplicationScreeningAnswersService(IJobApplicationScreeningAnswersRepository jobApplicationScreeningAnswersRepository, IScreeningQuestionsRepository screeningQuestionsRepository)
        {
            this.jobApplicationScreeningAnswersRepository = jobApplicationScreeningAnswersRepository;
            this.screeningQuestionsRepository = screeningQuestionsRepository;
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

        public JobApplicationScreeningAnswerDetail SelectByJobApplicationId(int jobApplicationId)
        {
            JobApplicationScreeningAnswerDetail jobApplicationScreeningAnswerDetail = new JobApplicationScreeningAnswerDetail();

            jobApplicationScreeningAnswerDetail.JobApplicationId = jobApplicationId;
            jobApplicationScreeningAnswerDetail.JobApplicationScreeningAnswers = new List<JobApplicationScreeningAnswer>();

            List<JobApplicationScreeningAnswersEntity> jobApplicationScreeningAnswers = jobApplicationScreeningAnswersRepository.SelectByJobApplicationID(jobApplicationId);
            List<int> screeningQuestionIds = new List<int>();

            foreach (JobApplicationScreeningAnswersEntity jobApplicationScreeningAnswer in jobApplicationScreeningAnswers)
            {
                screeningQuestionIds.Add(jobApplicationScreeningAnswer.ScreeningQuestionId);
            }

            List<ScreeningQuestionsEntity> screeningQuestions = screeningQuestionsRepository.SelectByIds(screeningQuestionIds);

            foreach (JobApplicationScreeningAnswersEntity jobApplicationScreeningAnswer in jobApplicationScreeningAnswers)
            {
                foreach (ScreeningQuestionsEntity screeningQuestion in screeningQuestions)
                {
                    jobApplicationScreeningAnswerDetail.JobApplicationScreeningAnswers.Add(new JobApplicationScreeningAnswer { 
                                                                                                ScreeningQuestionId = screeningQuestion.ScreeningQuestionId, 
                                                                                                QuestionTitle = screeningQuestion.QuestionTitle, 
                                                                                                Answer = jobApplicationScreeningAnswer.Answer });
                    break;
                }
            }


            return jobApplicationScreeningAnswerDetail;
        }
    }
}
