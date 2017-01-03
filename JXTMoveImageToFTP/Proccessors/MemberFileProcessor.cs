using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Configuration;
using System.IO;
using JXTPortal.Data.Dapper.Entities.Core;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Common;

namespace JXTMoveImageToFTP.Proccessors
{
    public class MemberFileProcessor: Processor<MemberFilesEntity>
    {
        IMemberFilesRepository _repository;
        public MemberFileProcessor(IMemberFilesRepository repository)
        {
            _repository = repository;
        }

        public override string Type { get { return "MemberFiles"; } }

        public override int Priority
        {
            get { return 60; }
        }

        public override string Folder
        {
            get { return string.Format("/{0}/{1}", ConfigurationManager.AppSettings["MemberRootFolder"], ConfigurationManager.AppSettings["MemberFilesFolder"]); }
        }
        
        public override IEnumerable<MemberFilesEntity> GetEntitiesToUpdate(int? batchSize)
        {
            IEnumerable<MemberFilesEntity> memberFiles = _repository.SelectAllNonBinary()
                                                       .Where(m => string.IsNullOrWhiteSpace(m.MemberFileUrl));

            if (batchSize.HasValue)
            {
                memberFiles = memberFiles.Take(batchSize.Value);
            }

            return memberFiles;
        }

        public override byte[] GetBinaryData(MemberFilesEntity entity)
        {
            MemberFilesEntity memberFile = _repository.Select(entity.MemberFileID);
            return memberFile.MemberFileContent;
        }

        public override int GetId(MemberFilesEntity entity)
        {
            return entity.MemberFileID;
        }

        public override void UpdateEntity(MemberFilesEntity entity, string filename)
        {
            entity.MemberFileUrl = filename;
            _repository.Update(entity);
        }

        public override bool PerformFileSave(MemberFilesEntity entity, string path, out string filename)
        {
            int id = GetId(entity);
            Logger.InfoFormat("Saving MemberFile: MemberFileID: {0} MemberFileName: {1}", id, entity.MemberFileName);

            byte[] buffer = GetBinaryData(entity);

            if (buffer == null || buffer.Length <= 0)
            {
                Logger.Warn("Nothing to save");
                filename = null;
                return false;
            }

            string extension = Path.GetExtension(entity.MemberFileName);
            filename = string.Format("{0}_{1}.{2}", Type, id, extension);
            string newPath = string.Format(@"{0}\{1}", path, filename);

            try
            {
                using (FileStream fs = new FileStream(newPath, FileMode.Create))
                {
                    fs.Write(buffer, 0, buffer.Count());
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
                filename = null;
                return false;
            }

            Logger.InfoFormat("Saved File {0}", filename);
            return true;
        }
    }
}
