using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using JXTPortal.Data.Dapper.Repositories;
using System.Configuration;
using JXTPortal.Common;
using JXTPortal.Data.Dapper.Entities.Core;
using System.IO;
using System.Drawing;

namespace JXTMoveImageToFTP.Proccessors
{
    public class AdvertiserProcessor : ImageProcessor<AdvertisersEntity>
    {
        IAdvertisersRepository _advertiserRepository;
        public AdvertiserProcessor(IAdvertisersRepository advertiserRepository)
        {
            _advertiserRepository = advertiserRepository;
        }

        public override string Type { get { return "Advertiser"; } }

        public override int Priority
        {
            get { return 20; }
        }

        public override string Folder
        {
            get { return string.Format(@"{0}\{1}", ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["AdvertisersFolder"]); }
        }

        public override IEnumerable<AdvertisersEntity> GetEntitiesToUpdate(int? batchSize)
        {
            var advertisers = _advertiserRepository.SelectAll()
                                               .Where(advertiser => advertiser.AdvertiserLogo != null && advertiser.AdvertiserLogo.Length > 0 && string.IsNullOrEmpty(advertiser.AdvertiserLogoUrl));

            if (batchSize.HasValue)
            {
                advertisers = advertisers.Take(batchSize.Value);
            }

            return advertisers;
        }

        public override byte[] GetBinaryData(AdvertisersEntity entity)
        {
            return entity.AdvertiserLogo;
        }

        public override int GetId(AdvertisersEntity entity)
        {
            return entity.AdvertiserID;
        }

        public override void UpdateEntity(AdvertisersEntity entity, string filename)
        {
            entity.AdvertiserLogoUrl = filename;
            _advertiserRepository.Update(entity);           
        }
    }
}