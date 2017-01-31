using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXT.Integration.AWS;
using JXTPortal.Common;

namespace FileManagement
{
    public class FileManager : IFileManager
    {
        public void ListBuckets()
        {
            string errorMessage = string.Empty;

            AwsS3 s3 = new AwsS3();
            s3.ListBucket(out errorMessage);
        }
    }
}
