using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPostDataToFTP
{
    public class Program
    {
        static void Main(string[] args)
        {

            new MemberXMLGenerator().GenerateMemberXML();

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
        public string folderPath;
        public string LastModifiedDate;
        public string ExceptionID;

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
