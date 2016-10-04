using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace JXTPosterTransform.Website.Models
{
    public class ClientSetupModels
    {
        [Description("Pull XML From URL")]
        public class PullXmlFromUrl
        {
            [Description("URL Target")]
            public string URL { get; set; }            
        }

        [Description("Pull XML From URL With Auth")]
        public class PullXmlFromUrlWithAuth
        {
            [Description("Full file name")]
            public string Filename { get; set; }
            [Description("File starts with")]
            public string FileStartsWith { get; set; }

            [Description("Host")]
            public string Host { get; set; }
            [Description("Username")]
            public string Username { get; set; }
            [Description("Password")]
            public string Password { get; set; }
        }

        [Description("Pull XML From FTP")]
        public class PullXmlFromFTP
        {
            [Description("Full file name")]
            public string Filename { get; set; }
            [Description("File starts with")]
            public string FileStartsWith { get; set; }

            [Description("FTP Host")]
            public string Host { get; set; }
            [Description("FTP Username")]
            public string Username { get; set; }
            [Description("FTP Password")]
            public string Password { get; set; }
        }

        [Description("Pull XML From URL SFTP")]
        public class PullXmlFromSFTP
        {
            [Description("Full file name")]
            public string Filename { get; set; }
            [Description("File starts with")]
            public string FileStartsWith { get; set; }

            [Description("FTP Host")]
            public string Host { get; set; }
            [Description("FTP Username")]
            public string Username { get; set; }
            [Description("FTP Password")]
            public string Password { get; set; }
        }


    }



}