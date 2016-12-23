using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Data.Dapper.Entities.Core;

namespace JXTPortal.Service.Dapper
{
    public interface IAdvertisersService
    {
    }

    public class AdvertisersService : IAdvertisersService
    {
        IAdvertisersRepository advertisersRepository;
        public AdvertisersService(IAdvertisersRepository advertisersRepository)
        {
            this.advertisersRepository = advertisersRepository;
        }

        public int Insert(AdvertisersEntity entity)
        {
            return advertisersRepository.Insert(entity);
        }

        public void Update(AdvertisersEntity entity)
        {
            advertisersRepository.Update(entity);
        }

        public void Delete(int id)
        {
            advertisersRepository.Delete(id);
        }

        public AdvertisersEntity Select(int id)
        {
            return advertisersRepository.Select(id);
        }

        public List<AdvertisersEntity> SelectAll()
        {
            return advertisersRepository.SelectAll();
        }
    }
}
