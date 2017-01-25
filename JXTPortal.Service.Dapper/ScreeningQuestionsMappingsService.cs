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

        public void Delete(int templateId, int questionId)
        {
            screeningQuestionsMappingsRepository.Delete(templateId, questionId);
        }
    }
}
