using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using JXTPortal.Common;
using System.Configuration;
using JXTPortal.Data.Dapper.Entities.Core;
using System.IO;
using System.Drawing;
using JXTPortal.Data.Dapper.Repositories;

namespace JXTMoveImageToFTP.Proccessors
{
    public class JobTemplateProcessor: ImageProcessor<JobTemplatesEntity>
    {
        IJobTemplatesRepository _repository;
        public JobTemplateProcessor(IJobTemplatesRepository repository)
        {
            _repository = repository;
        }

        public override string Type { get { return "JobTemplate"; } }

        public override int Priority
        {
            get { return 50; }
        }

        public override string Folder
        {
            get
            { return string.Format(@"{0}\{1}", ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["JobTemplatesFolder"]); }
        }

        public override IEnumerable<JobTemplatesEntity> GetEntitiesToUpdate(int? batchSize)
        {
              var jobTemplates = _repository.SelectAll()
                                          .Where(j => j.JobTemplateLogo != null && j.JobTemplateLogo.Length > 0 && string.IsNullOrEmpty(j.JobTemplateLogoUrl));

            if (batchSize.HasValue)
            {
                jobTemplates = jobTemplates.Take(batchSize.Value);
            }
            return jobTemplates;
        }

        public override byte[] GetBinaryData(JobTemplatesEntity entity)
        {
            return entity.JobTemplateLogo;
        }

        public override int GetId(JobTemplatesEntity entity)
        {
            return entity.JobTemplateID;
        }

        public override void UpdateEntity(JobTemplatesEntity entity, string filename)
        {
            entity.JobTemplateLogoUrl = filename;
            _repository.Update(entity);            
        }
    }
}