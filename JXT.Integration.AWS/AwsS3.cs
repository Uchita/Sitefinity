using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;

using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;

using JXTPortal.Common.Models;

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

        private string errorHandling(string errorCode, string message, string action)
        {
            string errorMessage = string.Empty;

            if (errorCode != null && (errorCode.Equals("InvalidAccessKeyId") || errorCode.Equals("InvalidSecurity")))
            {
                errorMessage = "Please check the provided AWS Credentials.";
            }
            else
            {
                errorMessage = string.Format("{0}: An error occurred with the message '{1}'", message, action, message);
            }

            return errorMessage;
        }

        public List<FileManagerFile> ListingObjects(string bucketName, out string errorMessage)
        {
            return ListingObjects(bucketName, string.Empty, out errorMessage);
        }

        public List<FileManagerFile> ListingObjects(string bucketName, string folder, out string errorMessage)
        {
            List<FileManagerFile> s3Objects = null;
            errorMessage = string.Empty;
            
            try
            {
                ListObjectsRequest request = new ListObjectsRequest();
                request.BucketName = bucketName;
                ListObjectsResponse response = _client.ListObjects(request);

                s3Objects = response.S3Objects.Select(x => new FileManagerFile { 
                                                            FolderName = x.BucketName, 
                                                            ETag = x.ETag, 
                                                            FileName = x.Key, 
                                                            LastModified = x.LastModified,
                                                            Size = x.Size
                }).ToList();
                
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                errorMessage = errorHandling(amazonS3Exception.ErrorCode, amazonS3Exception.Message, MethodBase.GetCurrentMethod().Name);
            }

            return s3Objects;
        }

        public Stream GetObject(string bucketName, string folder, string fileName, out string errorMessage)
        {
            errorMessage = string.Empty;
            Stream responseStream = null;
            try
            {
                GetObjectRequest request = new GetObjectRequest();
                request.BucketName = bucketName;
                request.Key = folder + fileName;

                GetObjectResponse response = _client.GetObject(request);
                responseStream = response.ResponseStream;
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                errorMessage = errorHandling(amazonS3Exception.ErrorCode, amazonS3Exception.Message, MethodBase.GetCurrentMethod().Name);
            }

            return responseStream;
        }

        public void DeleteObject(string bucketName, string folder, string fileName, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                DeleteObjectRequest request = new DeleteObjectRequest();
                request.BucketName = bucketName;
                request.Key = folder + fileName;

                DeleteObjectResponse response = _client.DeleteObject(request);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                errorMessage = errorHandling(amazonS3Exception.ErrorCode, amazonS3Exception.Message, MethodBase.GetCurrentMethod().Name);
            }
        }

        public void PutObject(string bucketName, string folder, string fileName, Stream inputSream, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                PutObjectRequest request = new PutObjectRequest();
                request.BucketName = bucketName;
                request.Key = folder + fileName;
                request.InputStream = inputSream;

                PutObjectResponse response = _client.PutObject(request);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                errorMessage = errorHandling(amazonS3Exception.ErrorCode, amazonS3Exception.Message, MethodBase.GetCurrentMethod().Name);
            }
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
                errorMessage = errorHandling(amazonS3Exception.ErrorCode, amazonS3Exception.Message, MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}