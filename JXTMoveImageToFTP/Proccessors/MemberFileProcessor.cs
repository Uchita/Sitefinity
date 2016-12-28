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
    public class MemberFileProcessor: IProcessor
    {
        ILog _logger;
        IMemberFilesRepository _repository;
        public MemberFileProcessor(IMemberFilesRepository repository)
        {
            _logger = LogManager.GetLogger(typeof(MemberFileProcessor));
            _repository = repository;
        }

        public int Priority
        {
            get { return 60; }
        }

        public void Begin(IFtpClient ftpClient)
        {
            _logger.Info("Start moving Member Files Binary Data to FTP");

            string errorMsg = string.Empty;
            string path = string.Format("/{0}/{1}", ConfigurationManager.AppSettings["MemberRootFolder"], ConfigurationManager.AppSettings["MemberFilesFolder"]);
            
            // Check if directory exists
            if (!ftpClient.DirectoryExists(path, out errorMsg))
            {
                _logger.Debug(string.Format("Creating ftp directory: {0}", path));

                // Create Directory
                ftpClient.CreateDirectory(path, out errorMsg);
            }

            if (!string.IsNullOrWhiteSpace(errorMsg))
            { 
                _logger.Warn(string.Format("Create Directory Error: {0}", errorMsg));
                return;
            }

            // Change to the Sites Directory to make sure the directory exists.
            ftpClient.ChangeDirectory(path, out errorMsg);

            if (!string.IsNullOrWhiteSpace(errorMsg))
            {
                _logger.Warn(string.Format("Change Directory Error: {0}", errorMsg));
                return;
            }

            IEnumerable<int> memberFiles = _repository.SelectAllNonBinary().Select(m => m.MemberFileID).ToList();

            _logger.Info(string.Format("Found {0} member Files to migrate", memberFiles.Count()));
            
            foreach (int memberFileId in memberFiles)
            {
                MemberFilesEntity memberFile = _repository.Select(memberFileId);

                string memberPath = string.Format("/{0}/{1}/{2}", ConfigurationManager.AppSettings["MemberRootFolder"], ConfigurationManager.AppSettings["MemberFilesFolder"], memberFile.MemberID);
                    
                // Check if directory exists
                if (!ftpClient.DirectoryExists(memberPath, out errorMsg))
                {
                    _logger.Debug(string.Format("Creating ftp directory for member: {0}", memberPath));
                    // Create Directory
                    ftpClient.CreateDirectory(memberPath, out errorMsg);
                }

                if (!string.IsNullOrWhiteSpace(errorMsg))
                { 
                    _logger.Warn(string.Format("Create Directory Error: {0}", errorMsg));
                    continue;
                }
               
                // Change to the Sites Directory to make sure the directory exists.
                ftpClient.ChangeDirectory(path, out errorMsg);

                if (!string.IsNullOrWhiteSpace(errorMsg))
                {
                    _logger.Warn(string.Format("Change Directory Error: {0}", errorMsg));
                    continue;
                }

                if (memberFile.MemberFileContent != null && memberFile.MemberFileContent.Length > 0 && string.IsNullOrEmpty(memberFile.MemberFileUrl))
                {
                    _logger.Info(string.Format("Start uploading Member Files for MemberFileID: {0} MemberFileName: {1}", memberFile.MemberFileID, memberFile.MemberFileName));

                    MemoryStream ms = new MemoryStream(memberFile.MemberFileContent);

                    string extension = Path.GetExtension(memberFile.MemberFileName);
                    string newFileName = string.Format("MemberFiles_{0}{1}", memberFile.MemberFileID, extension);
                    string newpath = string.Format("{0}{1}/{2}/{3}/{4}", ConfigurationManager.AppSettings["FTPHost"], ConfigurationManager.AppSettings["MemberRootFolder"], ConfigurationManager.AppSettings["MemberFilesFolder"], memberFile.MemberID, newFileName);

                    // Upload to FTP
                    _logger.Info(string.Format("Uploading file to {0}", newpath));

                    ftpClient.UploadFileFromStream(ms, newpath, out errorMsg);

                    if (string.IsNullOrWhiteSpace(errorMsg))
                    {
                        memberFile.MemberFileUrl = newFileName;

                        _repository.Update(memberFile);
                        _logger.Info(string.Format("Successfully uploaded file to {0}", newFileName));
                    }
                    else
                    {
                        _logger.Warn(string.Format("Upload Error: {0}", errorMsg));
                    }
                }
            }
        }
    }
}
