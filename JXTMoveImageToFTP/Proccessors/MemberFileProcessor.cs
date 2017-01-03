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
            get { return string.Format(@"{0}\{1}", ConfigurationManager.AppSettings["MemberRootFolder"], ConfigurationManager.AppSettings["MemberFilesFolder"]); }
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
            string memberPath = string.Format(@"{0}\{1}", path, entity.MemberID);
            Logger.InfoFormat("Saving MemberFile. MemberFileID: {0}; MemberId: {1}; MemberFileName: {2}; Path: {3}", id,entity.MemberID, entity.MemberFileName, memberPath);

            byte[] buffer = null;

            try
            {
                buffer = GetBinaryData(entity);
            }
            catch (Exception e)
            {
                Logger.Error("Error fetching the binary data", e);
                filename = string.Empty;
                return false;
            }

            if (buffer == null || buffer.Length <= 0)
            {
                Logger.Warn("Nothing to save");
                filename = null;
                return false;
            }

            // Check if directory exists
            if (!Directory.Exists(memberPath))
            {
                Logger.InfoFormat("Directory doesn't exist, creating directory {0}", memberPath);

                try
                {
                    Directory.CreateDirectory(memberPath);
                }
                catch (Exception e)
                {
                    string message = string.Format("Could not create directory: {0}", memberPath);

                    Logger.Error(message, e);
                    filename = string.Empty;
                    return false;
                }
            }

            try
            {

                string extension = Path.GetExtension(entity.MemberFileName).TrimStart('.');
                filename = string.Format("{0}_{1}.{2}", Type, id, extension);
            }
            catch (Exception e)
            {
                string message =string.Format("Could not retrieve the file extension for {0}", entity.MemberFileName);

                Logger.Error(message, e);
                filename = string.Empty;
                return false;
            }

            string newPath = string.Format(@"{0}\{1}", memberPath, filename);

            try
            {
                using (FileStream fs = new FileStream(newPath, FileMode.Create))
                {
                    fs.Write(buffer, 0, buffer.Count());
                }
            }
            catch (Exception e)
            {
                string message = string.Format("Could not Save file: {0}", newPath);

                Logger.Error(message, e);
                filename = null;
                return false;
            }

            Logger.InfoFormat("Saved File {0}", filename);
            return true;
        }
    }
}
