using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using JXTPortal.Common;
using Autofac;
using JXTPortal.Data.Dapper.Entities.KnowledgeBase;
using System.Reflection;
using log4net;

namespace JXTMoveImageToFTP
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isLive = false;

            if (args != null && args.Count() > 0)
            {
                if (args.Any(a =>a == "?"))
                {
                    Console.WriteLine("Application will run in Debug by default");
                    Console.WriteLine("Use argument the 'Live', to run in production mode");
                }

                isLive = args.Any(a => string.Equals(a, "Live", StringComparison.InvariantCultureIgnoreCase));
            }

            Console.WriteLine(string.Format("Running in {0} mode", isLive ? "LIVE" : "DEBUG"));

            //1: Configure Container
            ContainerBuilder builder = new ContainerBuilder();
       
            //2: Build Container
            IContainer container = IoCHelper.CreateContainer();

            ILog logger = LogManager.GetLogger(typeof(Program));
           
            //3: Build Dependencies
            using (var scope = container.BeginLifetimeScope())
            {
                IFtpClient ftpClient = isLive ? (IFtpClient)new FtpClient() : (IFtpClient)new MockFTPClient();
                ftpClient.Host = ConfigurationManager.AppSettings["FTPHost"];
                ftpClient.Username = ConfigurationManager.AppSettings["FTPUsername"];
                ftpClient.Password = ConfigurationManager.AppSettings["FTPPassword"];

                IEnumerable<IProcessor> processors = scope.Resolve<IEnumerable<IProcessor>>().OrderBy(p => p.Priority);

                logger.Info(string.Format("Found {0} processors", processors.Count()));
                foreach(var processor in processors)
                {
                    processor.Begin(ftpClient);
                }
            }
        }
    }

    internal class MockFTPClient : IFtpClient
    {
        #region IFtpClient Members

        public void ChangeDirectory(string directory, out string errormessage)
        {
            errormessage = string.Empty;
        }

        public void CreateDirectory(string directory, out string errormessage)
        {
            errormessage = string.Empty;
        }

        public void DeleteDirectory(string directory, out string errormessage)
        {
            errormessage = string.Empty;
        }

        public void DeleteFiles(out string errormessage, params string[] files)
        {
            errormessage = string.Empty;
        }

        public bool DirectoryExists(string directory, out string errormessage)
        {
            errormessage = string.Empty;
            return false;
        }

        public void DownloadFiles(string path, out string errormessage, params string[] files)
        {
            throw new NotImplementedException();
        }

        public void DownloadFileToClient(string filepath, ref System.IO.Stream downloadedfile, out string errormessage)
        {
            throw new NotImplementedException();
        }

        public DateTime? GetDateTimestamp(string filename, out string errormessage)
        {
            throw new NotImplementedException();
        }

        public long GetFileSize(string filename)
        {
            throw new NotImplementedException();
        }

        public string Host {get;set;}

        public bool IsRootDirectory {get;set;}

        public List<FtpDirectoryEntry> ListDirectory(out string errormessage)
        {
            throw new NotImplementedException();
        }

        public void MoveFile(string oldname, string newname, out string errormessage)
        {
            throw new NotImplementedException();
        }

        public string Password { get; set; }

        public void RenameFile(string oldname, ref string newname, out string errormessage)
        {
            throw new NotImplementedException();
        }

        public void RenameFolder(string oldname, ref string newname, out string errormessage)
        {
            throw new NotImplementedException();
        }

        public void UploadFileFromStream(System.IO.Stream streamFileToUpload, string strHostWithFilename, out string errormessage)
        {
            errormessage = string.Empty;
        }

        public void UploadFiles(out string errormessage, params string[] paths)
        {
            throw new NotImplementedException();
        }

        public string Username {get;set;}

        #endregion
    }
}
