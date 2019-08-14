using JXTNext.Sitefinity.FileHandler.Models.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.FileHandler.Models.S3
{
    public class S3SitefinityCommonFilehandlerRequest : SitefinityCommonFileHandlerRequestModelBase
    {
        public Guid MasterDocumentId { get; set; }
        public string ProviderName { get; set; }
        public string LibraryName { get; set; }
        public MemoryStream FileStream { get; set; }
    }
}
