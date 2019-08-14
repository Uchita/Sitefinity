using JXTNext.FileHandler.Enums;
using JXTNext.Sitefinity.FileHandler.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JXTNext.Sitefinity.FileHandler.Models.Base
{
    public class SitefinityCommonFileHandlerResponseModelBase
    {
        public bool FileSuccessStatus { get; set; }
        public MemoryStream FileStream { get; set; }
        public List<string> Errors { get; set; }
        public SitefinityCommonFileHandlerServiceType FileHandlerServiceType { get; set; }
    }
}
