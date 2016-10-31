using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Common;
using System.Configuration;
using JXTPortal.Data.Dapper.Repositories;

namespace JXTMoveImageToFTP
{
    public class Client
    {
        FtpClient ftpClient;
        IKnowledgeBaseCategoryRepository KbRepository { get; set; }

        public Client(IKnowledgeBaseCategoryRepository kbRepository, IKnowledgeBaseRepository kbpository)
        {
            Console.WriteLine("{0} Setting up FTP...", DateTime.Now);
            ftpClient = new FtpClient();
            ftpClient.Host = ConfigurationManager.AppSettings["FTPHost"];
            ftpClient.Username = ConfigurationManager.AppSettings["FTPUsername"];
            ftpClient.Password = ConfigurationManager.AppSettings["FTPPassword"];

            KbRepository = kbRepository;
        }

        public void ProcessSites()
        {
            Console.WriteLine("{0} Start moving Sites Binary Data to FTP...", DateTime.Now);

            string errormsg = string.Empty;
            string path = string.Format("/{0}/{1}", ConfigurationManager.AppSettings["RootFolder"], ConfigurationManager.AppSettings["SitesFolder"]);
            // Check if directory exists
            if (!ftpClient.DirectoryExists(path, out errormsg))
            {
                // Create Directory
                ftpClient.CreateDirectory(path, out errormsg);
            }

            if (string.IsNullOrWhiteSpace(errormsg))
            {
                //iterate each site
                // Retrieve list of files from Site

                // Upload Files to FTP

                // Update Site Logo and URL

            }
            else
            {
                Console.WriteLine("{0} Error: {1}", DateTime.Now, errormsg);
            }
        }
    }
}
