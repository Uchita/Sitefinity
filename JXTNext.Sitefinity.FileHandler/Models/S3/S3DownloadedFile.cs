using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.Libraries.Model;

namespace JXTNext.Sitefinity.FileHandler.Models.S3
{
    public class S3DownloadedFile
    {
        public MediaContent Document { get; set; }
        public MemoryStream FileStream { get; set; }
    }
}
