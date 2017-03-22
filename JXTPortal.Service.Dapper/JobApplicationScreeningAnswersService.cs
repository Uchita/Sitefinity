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
          
            List<JobApplicationScreeningAnswersEntity> answers = jobApplicationScreeningAnswersRepository.SelectByJobApplicationID(jobApplicationId);

            var screeningQuestionIds = answers.Select(i => i.ScreeningQuestionId).ToList();

            var screeningQuestions = screeningQuestionsRepository.SelectByIds(screeningQuestionIds);

            var answersToAdd = answers.Join(screeningQuestions, a => a.ScreeningQuestionId, q => q.ScreeningQuestionId, (a, q) => new JobApplicationScreeningAnswer
                    {
                        ScreeningQuestionId = q.ScreeningQuestionId,
                        ScreeningQuestionIndex = q.ScreeningQuestionIndex,
                        QuestionTitle = q.QuestionTitle,
                        Answer = a.Answer
                    }).OrderBy(a => a.ScreeningQuestionIndex);

            jobApplicationScreeningAnswerDetail.JobApplicationScreeningAnswers = answersToAdd.ToList();

            return jobApplicationScreeningAnswerDetail;
        }
    }
}
