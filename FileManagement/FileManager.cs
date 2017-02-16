using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXT.Integration.AWS;
using JXTPortal.Common;
using JXTPortal.Common.Models;
using System.IO;
using log4net;

namespace JXTPortal.Core.FileManagement
{
    public class FileManager : IFileManager
    {
        IAwsS3 _s3 = null;
        
        public FileManager(IAwsS3 s3)
        {
            _s3 = s3;
        }

        public void CreateFolder(string directoryName, string folder, out string errorMessage)
        {
            _s3.CreateFolder(directoryName, folder, out errorMessage);
        }

        public IEnumerable<FileManagerFile> ListFiles(string directoryName, string folder, out string errorMessage)
        {
            return _s3.ListingFiles(directoryName, folder, out errorMessage);
        }

        public void UploadFile(string directoryName, string folder, string fileName, Stream inputStream, out string errorMessage)
        {
            _s3.PutObject(directoryName, folder, fileName, inputStream, out errorMessage);
        }

        public void DeleteFile(string directoryName, string folder, string fileName, out string errorMessage)
        {
            _s3.DeleteObject(directoryName, folder, fileName, out errorMessage);
        }

        public Stream DownloadFile(string directoryName, string folder, string fileName, out string errorMessage)
        {
            return _s3.GetObject(directoryName, folder, fileName, out errorMessage);
        }

        public void CopyObject(string directoryName, string sourceFolder, string sourceName, string destinationFolder, string destinationName, out string errorMessage)
        {
            _s3.CopyObject(directoryName, sourceFolder, sourceName, destinationFolder, destinationName, out errorMessage);
        }

        public void MoveObject(string directoryName, string sourceFolder, string sourceName, string destinationFolder, string destinationName, out string errorMessage)
        {
            _s3.MoveObject(directoryName, sourceFolder, sourceName, destinationFolder, destinationName, out errorMessage);
        }

        public void RenameFolder(string directoryName, string sourceFolder, string destinationFolder, out string errorMessage)
        {
            _s3.RenameFolder(directoryName, sourceFolder, destinationFolder, out errorMessage);
        }

        public void DeleteFolder(string directoryName, string sourceFolder, out string errorMessage)
        {
            _s3.DeleteFolder(directoryName, sourceFolder, out errorMessage);
        }

    }
}
