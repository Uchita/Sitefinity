using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Data.Dapper.Entities.Core;

namespace JXTPortal.Service.Dapper
{
    public interface ISitesService : ISitesRepository
    {
    }

    public class SitesService : ISitesService
    {
        ISitesRepository sitesRepository;
        public SitesService(ISitesRepository sitesRepository)
        {
            this.sitesRepository = sitesRepository;
        }

        public int Insert(SitesEntity entity)
        {
            return sitesRepository.Insert(entity);
        }

        public void Update(SitesEntity entity)
        {
            sitesRepository.Update(entity);
        }

        public void Delete(int id)
        {
            sitesRepository.Delete(id);
        }

        public SitesEntity Select(int id)
        {
            return sitesRepository.Select(id);
        }

        public List<SitesEntity> SelectAll()
        {
            return sitesRepository.SelectAll();
        }
    }
}
