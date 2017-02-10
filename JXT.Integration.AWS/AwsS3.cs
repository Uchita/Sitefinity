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
        private static string DummyFileName = ConfigurationManager.AppSettings["AWSS3NullFileName"];

        public AwsS3()
        {
            string profile = ConfigurationManager.AppSettings["AWSProfileName"];
            AWSCredentials credentials = new Amazon.Runtime.StoredProfileAWSCredentials(profile);
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

        public void CreateFolder(string bucketName, string folder, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                PutObjectRequest request = new PutObjectRequest();
                request.BucketName = bucketName;
                request.Key = string.Format("{0}{1}", (string.IsNullOrEmpty(folder)) ? string.Empty : folder + "/", DummyFileName);
                request.ContentBody = "";

                PutObjectResponse response = _client.PutObject(request);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                errorMessage = errorHandling(amazonS3Exception.ErrorCode, amazonS3Exception.Message, MethodBase.GetCurrentMethod().Name);
            }
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
                request.Prefix = (string.IsNullOrEmpty(folder)) ? string.Empty : folder + "/";
                ListObjectsResponse response = _client.ListObjects(request);

                s3Objects = response.S3Objects.Select(x => new FileManagerFile
                                              {
                                                  IsFolder = false,
                                                  BucketName = x.BucketName,
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
                request.Key = string.Format("{0}{1}", (string.IsNullOrEmpty(folder)) ? string.Empty : folder + "/", fileName);

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
                request.Key = string.Format("{0}{1}", (string.IsNullOrEmpty(folder)) ? string.Empty : folder + "/", fileName);

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
                request.Key = string.Format("{0}{1}", (string.IsNullOrEmpty(folder)) ? string.Empty : folder + "/", fileName);
                request.InputStream = inputSream;

                PutObjectResponse response = _client.PutObject(request);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                errorMessage = errorHandling(amazonS3Exception.ErrorCode, amazonS3Exception.Message, MethodBase.GetCurrentMethod().Name);
            }
        }

        public void CopyObject(string bucketName, string sourceFolder, string sourceName, string destinationFolder, string destinationName, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                CopyObjectRequest request = new CopyObjectRequest
                {
                    SourceBucket = bucketName,
                    SourceKey = string.Format("{0}{1}", (string.IsNullOrEmpty(sourceFolder)) ? string.Empty : sourceFolder + "/", sourceName),
                    DestinationBucket = bucketName,
                    DestinationKey = string.Format("{0}{1}", (string.IsNullOrEmpty(destinationFolder)) ? string.Empty : destinationFolder + "/", destinationName)
                };

                _client.CopyObject(request);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                errorMessage = errorHandling(amazonS3Exception.ErrorCode, amazonS3Exception.Message, MethodBase.GetCurrentMethod().Name);
            }
        }

        public void MoveObject(string bucketName, string sourceFolder, string sourceName, string destinationFolder, string destinationName, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                CopyObjectRequest request = new CopyObjectRequest
                {
                    SourceBucket = bucketName,
                    SourceKey = string.Format("{0}{1}", (string.IsNullOrEmpty(sourceFolder)) ? string.Empty : sourceFolder + "/", sourceName),
                    DestinationBucket = bucketName,
                    DestinationKey = string.Format("{0}{1}", (string.IsNullOrEmpty(destinationFolder)) ? string.Empty : destinationFolder + "/", destinationName)
                };

                _client.CopyObject(request);

                DeleteObjectRequest deleteRequest = new DeleteObjectRequest();
                deleteRequest.BucketName = bucketName;
                deleteRequest.Key = string.Format("{0}{1}", (string.IsNullOrEmpty(sourceFolder)) ? string.Empty : sourceFolder + "/", sourceName);

                DeleteObjectResponse response = _client.DeleteObject(deleteRequest);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                errorMessage = errorHandling(amazonS3Exception.ErrorCode, amazonS3Exception.Message, MethodBase.GetCurrentMethod().Name);
            }
        }

        public void RenameFolder(string bucketName, string sourceFolder, string destinationFolder, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                ListObjectsRequest request = new ListObjectsRequest();
                request.BucketName = bucketName;
                request.Prefix = (string.IsNullOrEmpty(sourceFolder)) ? string.Empty : sourceFolder + "/";
                ListObjectsResponse response = _client.ListObjects(request);

                foreach (S3Object s3Object in response.S3Objects)
                {
                    CopyObjectRequest copyRequest = new CopyObjectRequest
                    {
                        SourceBucket = bucketName,
                        SourceKey = s3Object.Key,
                        DestinationBucket = bucketName,
                        DestinationKey = ReplaceFirst(s3Object.Key, sourceFolder + "/", destinationFolder + "/")
                    };

                    _client.CopyObject(copyRequest);

                    DeleteObjectRequest deleteRequest = new DeleteObjectRequest();
                    deleteRequest.BucketName = bucketName;
                    deleteRequest.Key = s3Object.Key;

                    DeleteObjectResponse deleteResponse = _client.DeleteObject(deleteRequest);
                }
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                errorMessage = errorHandling(amazonS3Exception.ErrorCode, amazonS3Exception.Message, MethodBase.GetCurrentMethod().Name);
            }
        }

        public void DeleteFolder(string bucketName, string sourceFolder, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                ListObjectsRequest request = new ListObjectsRequest();
                request.BucketName = bucketName;
                request.Prefix = (string.IsNullOrEmpty(sourceFolder)) ? string.Empty : sourceFolder + "/";
                ListObjectsResponse response = _client.ListObjects(request);

                foreach (S3Object s3Object in response.S3Objects)
                {
                    DeleteObjectRequest deleteRequest = new DeleteObjectRequest();
                    deleteRequest.BucketName = bucketName;
                    deleteRequest.Key = s3Object.Key;

                    DeleteObjectResponse deleteResponse = _client.DeleteObject(deleteRequest);
                }
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


        private string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
    }
}