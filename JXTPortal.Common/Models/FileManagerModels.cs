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
                if (IsFolder)
                {
                    return null;
                }
                else
                {
                    string[] folders = FileName.Split(new char[] { '/' });

                    return folders.Take(folders.Length - 1);
                }
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

    public class FileManagerFileComparer : IEqualityComparer<FileManagerFile>
    {
        public bool Equals(FileManagerFile x, FileManagerFile y)
        {
            if (x.BucketName == y.BucketName && x.IsFolder == y.IsFolder && x.FolderName == y.FolderName && x.Folders == y.Folders)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(FileManagerFile file)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(file, null)) return 0;

            //Get hash code for the Name field if it is not null.
            int hashProductName = file.FileName == null ? 0 : file.FileName.GetHashCode();

            //Get hash code for the Code field.
            int hashProductCode = file.FileName.GetHashCode();

            //Calculate the hash code for the product.
            return hashProductName ^ hashProductCode;
        }
    }
}
