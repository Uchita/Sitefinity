using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
//using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace JXTPosterTransform.Library.Models
{
    public class ClientSetupModels
    {

        [Description("Pull JSON From URL")]
        public class PullJsonFromUrl
        {
            [Description("URL Target")]
            public string URL { get; set; }
        }

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
            [Description("Remote Path")]
            public string RemotePath { get; set; }
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
            [Description("Remote Path")]
            public string RemotePath { get; set; }
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


        [Description("Pull XML From Salesforce (RGF)")]
        public class PullXmlFromSalesforceRGF
        {
            public string JobBoardName { get; set; }
            [Description("Host")]
            public string Host { get; set; }
            [Description("Username")]
            public string Username { get; set; }
            [Description("Password")]
            public string Password { get; set; }

            public string ApplicationURL { get; set; }
            public string SFTokenReqURL { get; set; }
            public string SFClientID { get; set; }
            public string SFClientSecret { get; set; }
            public long? Timestamp { get; set; }
            public bool StripJobTitle { get; set; }

        }

        [Description("Pull From Invenias")]
        public class PullFromInvenias
        {
            [Description("Client ID")]
            public string ClientID { get; set; }
            [Description("Username")]
            public string Username { get; set; }
            [Description("Password")]
            public string Password { get; set; }

            [Description("Class/SubClass CategoryListID")]
            public string ProfRoleCategoryListID { get; set; }
            [Description("Locations CategoryListID")]
            public string LocationCategoryListID { get; set; }

        }

    }



}