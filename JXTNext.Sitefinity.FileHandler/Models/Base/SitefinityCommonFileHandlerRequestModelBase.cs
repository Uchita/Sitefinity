using System;
using System.Collections.Generic;
using System.Text;

namespace JXTNext.Sitefinity.FileHandler.Models.Base
{
    public class SitefinityCommonFileHandlerRequestModelBase
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string OAuthToken { get; set; }
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
    }
}
