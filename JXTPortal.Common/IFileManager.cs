using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using JXTPortal.Common.Models;

namespace JXTPortal.Common
{
    public interface IFileManager
    {
        List<FileManagerFile> ListFiles(string directoryName, string folder, out string errorMessage);
        void CreateFolder(string directoryName, string folder, out string errorMessage);
        void UploadFile(string directoryName, string folder, string fileName, Stream inputStream, out string errorMessage);
        void DeleteFile(string directoryName, string folder, string fileName, out string errorMessage);
        Stream DownloadFile(string directoryName, string folder, string fileName, out string errorMessage);
        void CopyObject(string directoryName, string sourceFolder, string sourceName, string destinationFolder, string destinationName, out string errorMessage);
        void MoveObject(string directoryName, string sourceFolder, string sourceName, string destinationFolder, string destinationName, out string errorMessage);
        void RenameFolder(string bucketName, string sourceFolder, string destinationFolder, out string errorMessage);
        void DeleteFolder(string bucketName, string sourceFolder, out string errorMessage);
    }
}
