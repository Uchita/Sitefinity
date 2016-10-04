using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace JXTPosterTransform.Library.Common
{
    public class PTCommonEnums
    {
        public class Client
        {
            public enum Valid : int
            {
                [Description("Invalid")]
                Invalid = 0,
                [Description("Valid")]
                Valid = 1,
                [Description("Archieved")]
                Archieved = 2
            }
        }


        public class PosterTransform
        {
            public enum Valid : int
            {
                [Description("Invalid")]
                Invalid = 0,
                [Description("Valid")]
                Valid = 1,
                [Description("Archieved")]
                Archieved = 2
            }
        }


        public class ClientSetup
        {
            public enum ClientSetupType : int
            {
                [Description("Pull XML from URL")]
                PullXmlFromUrl = 0,
                [Description("Pull XML from URL with Authentication")]
                PullXmlFromUrlWithAuth = 1,
                [Description("Pull XML from FTP")]
                PullXmlFromFTP = 2,
                [Description("Pull XML from SFTP")]
                PullXmlFromSFTP = 3,
                [Description("Pull XML from Salesforce (RGF)")]
                PullXmlFromRGF = 4,
            }

            public enum Valid : int
            {
                [Description("Not Valid")]
                Invalid = 0,
                [Description("Valid")]
                Valid = 1,
                [Description("Archieved")]
                Archieved = 2
            }

        }

        public enum LogStatus
        { 
            [Description("Succeed")]
            Succeed = 0,
            [Description("Failed")]
            Failed = 1,

        }

    }
}
