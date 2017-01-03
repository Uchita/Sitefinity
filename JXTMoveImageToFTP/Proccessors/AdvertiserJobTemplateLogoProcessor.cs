using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using JXTPortal.Common;
using System.Configuration;
using System.IO;
using System.Drawing;
using JXTPortal.Data.Dapper.Entities.Core;
using JXTPortal.Data.Dapper.Repositories;

namespace JXTMoveImageToFTP.Proccessors
{
    public class AdvertiserJobTemplateLogoProcessor : ImageProcessor<AdvertiserJobTemplateLogoEntity>
    {
        IAdvertiserJobTemplateLogoRepository _repository;
        public AdvertiserJobTemplateLogoProcessor(IAdvertiserJobTemplateLogoRepository repository)
        {
            _repository = repository;
        }

        public override string Type { get { return "AdvertiserJobTemplateLogo"; } }

        public override int Priority
        {
            get { return 30; }
        }

        public override string Folder
        {
            get { return ConfigurationManager.AppSettings["AdvertiserJobTemplateLogoFolder"]; }
        }

        public override IEnumerable<AdvertiserJobTemplateLogoEntity> GetEntitiesToUpdate(int? batchSize)
        {
            var logos = _repository.SelectAll()
                                  .Where(a => a.JobTemplateLogo != null && a.JobTemplateLogo.Length > 0 && string.IsNullOrEmpty(a.JobTemplateLogoUrl));

            if (batchSize.HasValue)
            {
                logos = logos.Take(batchSize.Value);
            }

            return logos;
        }

        public override byte[] GetBinaryData(AdvertiserJobTemplateLogoEntity entity)
        {
            return entity.JobTemplateLogo;
        }

        public override int GetId(AdvertiserJobTemplateLogoEntity entity)
        {
            return entity.AdvertiserJobTemplateLogoID;
        }

        public override void UpdateEntity(AdvertiserJobTemplateLogoEntity entity, string filename)
        {
            entity.JobTemplateLogoUrl = filename;

            _repository.Update(entity);
            
        }
    }
}