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
        static ILog logger = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            bool isLive = false;

            ContainerBuilder builder = new ContainerBuilder();
            IContainer container = IoCHelper.CreateContainer();
            logger.Info("Configured IoC");

            using (var scope = container.BeginLifetimeScope())
            {
                IEnumerable<string> requestedProcessors = new List<string>();
                List<IProcessor> processors = scope.Resolve<IEnumerable<IProcessor>>().OrderBy(p => p.Priority).ToList();

                if (args == null || args.Count() < 1)
                {
                    Console.WriteLine("Application will run in Debug by default");
                    Console.WriteLine("Use argument the 'Live', to run in production mode");

                    Console.WriteLine("------ Processors to apply -------");

                    processors.ForEach(p => Console.WriteLine(p.Type));
                    return;
                }

                isLive = args.Any(a => string.Equals(a, "Live", StringComparison.InvariantCultureIgnoreCase));
                requestedProcessors = args.Where(a => !string.Equals(a, "Live", StringComparison.InvariantCultureIgnoreCase)).Select(p => p.ToLower());

                logger.Info(string.Format("Running in {0} mode", isLive ? "LIVE" : "DEBUG"));

                IFtpClient ftpClient = isLive ? (IFtpClient)new FtpClient() : (IFtpClient)new MockFTPClient();
                ftpClient.Host = ConfigurationManager.AppSettings["FTPHost"];
                ftpClient.Username = ConfigurationManager.AppSettings["FTPUsername"];
                ftpClient.Password = ConfigurationManager.AppSettings["FTPPassword"];

                var processorsToRun = processors.Where(p => requestedProcessors.Contains(p.Type.ToLower())).ToList();

                logger.Info(string.Format("Found {0} processors", processorsToRun.Count()));

                processorsToRun.ForEach(p => p.Begin(ftpClient));
            }
        }
    }

    internal class MockFTPClient : IFtpClient
    {
        ILog _logger;
        public MockFTPClient()
        {
            _logger = LogManager.GetLogger(typeof(MockFTPClient));
            _logger.Info("Creating a new MockFTPClient");
        }
        #region IFtpClient Members
        
        public void ChangeDirectory(string directory, out string errormessage)
        {
            _logger.Info(string.Format("Changed directory to {0}",directory));
            errormessage = string.Empty;
        }

        public void CreateDirectory(string directory, out string errormessage)
        {
            _logger.Info(string.Format("Creating directory to {0}", directory));
            errormessage = string.Empty;
        }

        public void DeleteDirectory(string directory, out string errormessage)
        {
            throw new NotImplementedException();
        }

        public void DeleteFiles(out string errormessage, params string[] files)
        {
            throw new NotImplementedException();
        }

        public bool DirectoryExists(string directory, out string errormessage)
        {
            _logger.Info(string.Format("Checking if directory {0} exists", directory));
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
            _logger.Info(string.Format("Uploading file to {0}", strHostWithFilename));
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
