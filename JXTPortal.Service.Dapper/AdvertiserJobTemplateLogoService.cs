using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Data.Dapper.Entities.Core;

namespace JXTPortal.Service.Dapper
{
    public interface IAdvertiserJobTemplateLogoService
    {
    }

    public class AdvertiserJobTemplateLogoService : IAdvertiserJobTemplateLogoService
    {
        IAdvertiserJobTemplateLogoRepository advertiserjobtemplatelogoRepository;
        public AdvertiserJobTemplateLogoService(IAdvertiserJobTemplateLogoRepository advertiserjobtemplatelogoRepository)
        {
            this.advertiserjobtemplatelogoRepository = advertiserjobtemplatelogoRepository;
        }

        public int Insert(AdvertiserJobTemplateLogoEntity entity)
        {
            return advertiserjobtemplatelogoRepository.Insert(entity);
        }

        public void Update(AdvertiserJobTemplateLogoEntity entity)
        {
            advertiserjobtemplatelogoRepository.Update(entity);
        }

        public void Delete(int id)
        {
            advertiserjobtemplatelogoRepository.Delete(id);
        }

        public AdvertiserJobTemplateLogoEntity Select(int id)
        {
            return advertiserjobtemplatelogoRepository.Select(id);
        }

        public List<AdvertiserJobTemplateLogoEntity> SelectAll()
        {
            return advertiserjobtemplatelogoRepository.SelectAll();
        }
    }
}
