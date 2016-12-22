using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.IO;

namespace JXTPostDataToFTP
{
    public class Program
    {
        static void Main(string[] args)
        {
            ILog _logger = LogManager.GetLogger("PostDataToFTP");

            if (args == null)
            {
                _logger.Warn("Cannot run application without config files passed in as a parameter");
                return;
            }

            foreach (string configFile in args)
            {
                if (!File.Exists(configFile))
                {
                    _logger.Error(string.Format("Cannot find config file. {0}", configFile));
                    continue;
                }

                new MemberXMLGenerator().GenerateMemberXML(configFile);
            }
        }
    }


    #region Classes

    public class SitesXML
    {
        public int SiteId;
        public string host;
        public string username;
        public string password;
        public bool sftp;
        public int port;
        public string mode;
        public string folderPath;
        public string LastModifiedDate;
    }

    public class FileNames
    {
        public string Id;
        public string fromFilename;
        public string toFilename;

        public FileNames(string _id, string _fromFilenames, string _toFilename)
        {
            Id = _id;
            fromFilename = _fromFilenames;
            toFilename = _toFilename;
        }
    }

    #endregion
}
