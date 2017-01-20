using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Common;
using System.Configuration;
using JXTPortal.Data.Dapper.Entities.Core;
using System.IO;
using System.Drawing;

namespace JXTMoveImageToFTP.Proccessors
{
    public class ConsultantProcessor: ImageProcessor<ConsultantsEntity>
    {
        IConsultantsRepository _repository;
        public ConsultantProcessor(IConsultantsRepository repository)
        {
            _repository = repository;
        }
        public override string Type { get { return "Consultant"; } }

        public override int Priority
        {
            get { return 40; }
        }

        public override string Folder
        {
            get
            {
                return string.Format(@"{0}\{1}", ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["ConsultantsFolder"]);
            }
        }

        public override IEnumerable<ConsultantsEntity> GetEntitiesToUpdate(int? batchSize)
        {
            var consultants = _repository.SelectAll()
                                         .Where(c => c.ImageURL != null && c.ImageURL.Length > 0 && string.IsNullOrEmpty(c.ConsultantImageUrl));

            if (batchSize.HasValue)
            {
                consultants = consultants.Take(batchSize.Value);
            }
            return consultants;
        }

        public override byte[] GetBinaryData(ConsultantsEntity entity)
        {
            return entity.ImageURL;
        }

        public override int GetId(ConsultantsEntity entity)
        {
            return entity.ConsultantID;
        }

        public override void UpdateEntity(ConsultantsEntity entity, string filename)
        {
            entity.ConsultantImageUrl = filename;
            _repository.Update(entity);
        }
    }
}