using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Data.Dapper.Entities.ScreeningQuestions;

namespace JXTPortal.Service.Dapper
{
    public interface IScreeningQuestionsTemplatesService : IScreeningQuestionsTemplatesRepository
    {
    }

    public class ScreeningQuestionsTemplatesService : IScreeningQuestionsTemplatesService
    {
        IScreeningQuestionsTemplatesRepository screeningQuestionsTemplatesRepository;
        public ScreeningQuestionsTemplatesService(IScreeningQuestionsTemplatesRepository screeningQuestionsTemplatesRepository)
        {
            this.screeningQuestionsTemplatesRepository = screeningQuestionsTemplatesRepository;
        }

        public int Insert(ScreeningQuestionsTemplatesEntity entity)
        {
            return screeningQuestionsTemplatesRepository.Insert(entity);
        }

        public void Update(ScreeningQuestionsTemplatesEntity entity)
        {
            screeningQuestionsTemplatesRepository.Update(entity);
        }

        public void Delete(int id)
        {
            screeningQuestionsTemplatesRepository.Delete(id);
        }

        public ScreeningQuestionsTemplatesEntity Select(int id)
        {
            return screeningQuestionsTemplatesRepository.Select(id);
        }

        public List<ScreeningQuestionsTemplatesEntity> SelectAll()
        {
            return screeningQuestionsTemplatesRepository.SelectAll();
        }

        public List<ScreeningQuestionsTemplatesEntity> SelectBySiteId(int siteId)
        {
            return screeningQuestionsTemplatesRepository.SelectBySiteId(siteId);
        }
    }
}
