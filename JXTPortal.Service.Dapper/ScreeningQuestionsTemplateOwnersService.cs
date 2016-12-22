using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Data.Dapper.Entities.ScreeningQuestions;

namespace JXTPortal.Service.Dapper
{
    public interface IScreeningQuestionsTemplateOwnersService : IScreeningQuestionsTemplateOwnersRepository
    {
    }

    public class ScreeningQuestionsTemplateOwnersService : IScreeningQuestionsTemplateOwnersService
    {
        IScreeningQuestionsTemplateOwnersRepository screeningQuestionsTemplateOwnersRepository;
        public ScreeningQuestionsTemplateOwnersService(IScreeningQuestionsTemplateOwnersRepository screeningQuestionsTemplateOwnersRepository)
        {
            this.screeningQuestionsTemplateOwnersRepository = screeningQuestionsTemplateOwnersRepository;
        }

        public int Insert(ScreeningQuestionsTemplateOwnersEntity entity)
        {
            return screeningQuestionsTemplateOwnersRepository.Insert(entity);
        }

        public void Update(ScreeningQuestionsTemplateOwnersEntity entity)
        {
            screeningQuestionsTemplateOwnersRepository.Update(entity);
        }

        public void Delete(int id)
        {
            screeningQuestionsTemplateOwnersRepository.Delete(id);
        }

        public ScreeningQuestionsTemplateOwnersEntity Select(int id)
        {
            return screeningQuestionsTemplateOwnersRepository.Select(id);
        }

        public List<ScreeningQuestionsTemplateOwnersEntity> SelectAll()
        {
            return screeningQuestionsTemplateOwnersRepository.SelectAll();
        }

        public List<ScreeningQuestionsTemplateOwnersEntity> SelectByAdvertiserId(int advertiserId)
        {
            return screeningQuestionsTemplateOwnersRepository.SelectByAdvertiserId(advertiserId);
        }
    }
}
