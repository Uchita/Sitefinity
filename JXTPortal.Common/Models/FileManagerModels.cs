using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Common.Models
{
    public class FileManagerFile
    {
        public string FolderName { get; set; }
        public string ETag { get; set; }
        public string FileName { get; set; }
        public DateTime LastModified { get; set; }
        public long Size { get; set; }
    }
}
