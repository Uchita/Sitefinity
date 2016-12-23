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
    }

    public class ScreeningQuestionsService : IScreeningQuestionsService
    {
        IScreeningQuestionsRepository screeningQuestionsRepository;
        public ScreeningQuestionsService(IScreeningQuestionsRepository screeningQuestionsRepository)
        {
            this.screeningQuestionsRepository = screeningQuestionsRepository;
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
    }
}
