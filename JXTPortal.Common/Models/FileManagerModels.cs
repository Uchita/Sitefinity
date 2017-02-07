using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Common.Models
{
    public class FileManagerFile
    {
        public string BucketName { get; set; }
        public string ETag { get; set; }
        public IEnumerable<string> Folders
        {
            get
            {
                string[] folders = FileName.Split(new char[] { '/' });

                return folders.Take(folders.Length - 1);
            }
        }
        public string FolderName { get; set; }
        public bool IsFolder { get; set; }
        public string FileName { get; set; }
        public string ShortFileName
        {
            get
            {
                if (IsFolder == false)
                {

                    string[] folders = FileName.Split(new char[] { '/' });

                    return folders.Last();
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public DateTime LastModified { get; set; }
        public long Size { get; set; }
    }
}
