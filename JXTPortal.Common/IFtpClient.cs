using System;
namespace JXTPortal.Common
{
    public interface IFtpClient
    {
        void ChangeDirectory(string directory, out string errormessage);
        void CreateDirectory(string directory, out string errormessage);
        void DeleteDirectory(string directory, out string errormessage);
        void DeleteFiles(out string errormessage, params string[] files);
        bool DirectoryExists(string directory, out string errormessage);
        void DownloadFiles(string path, out string errormessage, params string[] files);
        void DownloadFileToClient(string filepath, ref System.IO.Stream downloadedfile, out string errormessage);
        DateTime? GetDateTimestamp(string filename, out string errormessage);
        long GetFileSize(string filename);
        string Host { get; set; }
        bool IsRootDirectory { get; }
        System.Collections.Generic.List<FtpDirectoryEntry> ListDirectory(out string errormessage);
        void MoveFile(string oldname, string newname, out string errormessage);
        string Password { get; set; }
        void RenameFile(string oldname, ref string newname, out string errormessage);
        void RenameFolder(string oldname, ref string newname, out string errormessage);
        void UploadFileFromStream(System.IO.Stream streamFileToUpload, string strHostWithFilename, out string errormessage);
        void UploadFiles(out string errormessage, params string[] paths);
        string Username { get; set; }
    }
}
