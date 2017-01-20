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

        public JobApplicationScreeningAnswerDetail SelectByJobApplicationId(int jobApplicationId)
        {
            JobApplicationScreeningAnswerDetail jobApplicationScreeningAnswerDetail = new JobApplicationScreeningAnswerDetail();

            jobApplicationScreeningAnswerDetail.JobApplicationId = jobApplicationId;
            jobApplicationScreeningAnswerDetail.JobApplicationScreeningAnswers = new List<JobApplicationScreeningAnswer>();

            List<JobApplicationScreeningAnswersEntity> jobApplicationScreeningAnswers = jobApplicationScreeningAnswersRepository.SelectByJobApplicationID(jobApplicationId);

            var screeningQuestionIds = jobApplicationScreeningAnswers.Select(i => i.ScreeningQuestionId).ToList();

            var screeningQuestions = screeningQuestionsRepository.SelectByIds(screeningQuestionIds);

            foreach (JobApplicationScreeningAnswersEntity answer in jobApplicationScreeningAnswers)
            {
                var question = screeningQuestions.FirstOrDefault(q => q.ScreeningQuestionId == answer.ScreeningQuestionId);
                
                if (question != null)
                {
                    jobApplicationScreeningAnswerDetail.JobApplicationScreeningAnswers.Add(new JobApplicationScreeningAnswer
                    {
                        ScreeningQuestionId = question.ScreeningQuestionId,
                        QuestionTitle = question.QuestionTitle,
                        Answer = answer.Answer
                    });
                }
            }

            return jobApplicationScreeningAnswerDetail;
        }
    }
}
