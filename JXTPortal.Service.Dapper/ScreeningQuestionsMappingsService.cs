using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Data.Dapper.Entities.ScreeningQuestions;

namespace JXTPortal.Service.Dapper
{
    public interface IScreeningQuestionsMappingsService
    {
        int Insert(ScreeningQuestionsMappingsEntity entity);
        void Delete(int templateId, int questionId);
    }

    public class ScreeningQuestionsMappingsService : IScreeningQuestionsMappingsService
    {
        IScreeningQuestionsMappingsRepository screeningQuestionsMappingsRepository;
        public ScreeningQuestionsMappingsService(IScreeningQuestionsMappingsRepository screeningQuestionsMappingsRepository)
        {
            this.screeningQuestionsMappingsRepository = screeningQuestionsMappingsRepository;
        }

        public int Insert(ScreeningQuestionsMappingsEntity entity)
        {
            return screeningQuestionsMappingsRepository.Insert(entity);
        }

        public void Update(ScreeningQuestionsMappingsEntity entity)
        {
            screeningQuestionsMappingsRepository.Update(entity);
        }

        public void Delete(int templateId, int questionId)
        {
            screeningQuestionsMappingsRepository.Delete(templateId, questionId);
        }

        public ScreeningQuestionsMappingsEntity Select(int id)
        {
            return screeningQuestionsMappingsRepository.Select(id);
        }

        public List<ScreeningQuestionsMappingsEntity> SelectAll()
        {
            return screeningQuestionsMappingsRepository.SelectAll();
        }

        public List<ScreeningQuestionsMappingsEntity> SelectByScreeningQuestionsTemplateId(int screeningQuestionsTemplateId)
        {
            return screeningQuestionsMappingsRepository.SelectByScreeningQuestionsTemplateId(screeningQuestionsTemplateId);
        }
    }
}
