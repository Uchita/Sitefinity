using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;

using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;

namespace JXT.Integration.AWS
{
    public class AwsS3
    {
        private IAmazonS3 _client;
        
        public AwsS3()
        {
                AWSCredentials credentials = new Amazon.Runtime.StoredProfileAWSCredentials("JXT_FileManager_Dev");
                _client = new AmazonS3Client(credentials, Amazon.RegionEndpoint.APSoutheast2);
        }

        public void ListBucket(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
               ListBucketsResponse response = _client.ListBuckets();
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                     (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") ||
                     amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    errorMessage = "Please check the provided AWS Credentials.";
                }
                else
                {
                    errorMessage = string.Format("An Error, number {0}, occurred when listing buckets with the message '{1}", amazonS3Exception.ErrorCode, amazonS3Exception.Message);
                }
            }
        }
    }
}