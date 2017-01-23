using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Data.Dapper.Entities.ScreeningQuestions;

namespace JXTPortal.Service.Dapper
{
    public interface IScreeningQuestionsService
    {
        int Insert(ScreeningQuestionsEntity entity);
        void Update(ScreeningQuestionsEntity entity);
        void Delete(int id);
        ScreeningQuestionsEntity Select(int id);
        ScreeningQuestionsEntity SelectByScreeningQuestionId(int screeningQuestionId);
        List<ScreeningQuestionsEntity> SelectByScreeningQuestionsTemplateId(int templateId);
        List<ScreeningQuestionsEntity> SelectByScreeningQuestionsTemplateIdLanguageId(int templateId, int languageId);
        List<ScreeningQuestionsEntity> SelectByIds(List<int> screeningQuestionIds);
        List<ScreeningQuestionsEntity> SelectByJobId(int jobId);
    }

    public class ScreeningQuestionsService : IScreeningQuestionsService
    {
        IScreeningQuestionsRepository screeningQuestionsRepository;
        IJobScreeningQuestionsRepository jobScreeningQuestionsRepository;

        public ScreeningQuestionsService(IScreeningQuestionsRepository screeningQuestionsRepository, IJobScreeningQuestionsRepository jobScreeningQuestionsRepository)
        {
            this.screeningQuestionsRepository = screeningQuestionsRepository;
            this.jobScreeningQuestionsRepository = jobScreeningQuestionsRepository;
        }

        public int Insert(ScreeningQuestionsEntity entity)
        {
            return screeningQuestionsRepository.Insert(entity);
        }

        public void Update(ScreeningQuestionsEntity entity)
        {
            screeningQuestionsRepository.Update(entity);
        }

        public void Delete(int id)
        {
            screeningQuestionsRepository.Delete(id);
        }

        public ScreeningQuestionsEntity Select(int id)
        {
            return screeningQuestionsRepository.Select(id);
        }

        public List<ScreeningQuestionsEntity> SelectAll()
        {
            return screeningQuestionsRepository.SelectAll();
        }

        public ScreeningQuestionsEntity SelectByScreeningQuestionId(int screeningQuestionId)
        {
            return screeningQuestionsRepository.SelectByScreeningQuestionId(screeningQuestionId);
        }

        public List<ScreeningQuestionsEntity> SelectByScreeningQuestionsTemplateId(int templateId)
        {
            return screeningQuestionsRepository.SelectByScreeningQuestionsTemplateId(templateId);
        }

        public List<ScreeningQuestionsEntity> SelectByScreeningQuestionsTemplateIdLanguageId(int templateId, int languageId)
        {
            return screeningQuestionsRepository.SelectByScreeningQuestionsTemplateIdLanguageId(templateId, languageId);
        }

        public List<ScreeningQuestionsEntity> SelectByIds(List<int> screeningQuestionIds)
        {
            return screeningQuestionsRepository.SelectByIds(screeningQuestionIds);
        }

        public List<ScreeningQuestionsEntity> SelectByJobId(int jobId)
        {
            List<JobScreeningQuestionsEntity> jobScreeningQuestions = jobScreeningQuestionsRepository.SelectByJobID(jobId);
            var screeningQuestionIds = jobScreeningQuestions.Select(q => q.ScreeningQuestionId);

            return screeningQuestionsRepository.SelectByIds(screeningQuestionIds.ToList());
        }
    }
}
