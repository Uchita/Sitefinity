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
using log4net;

namespace JXT.Integration.AWS
{
    public interface IAwsS3
    {
        void CopyObject(string bucketName, string sourceFolder, string sourceName, string destinationFolder, string destinationName, out string errorMessage);
        void CreateFolder(string bucketName, string folder, out string errorMessage);
        void DeleteFolder(string bucketName, string sourceFolder, out string errorMessage);
        void DeleteObject(string bucketName, string folder, string fileName, out string errorMessage);
        Stream GetObject(string bucketName, string folder, string fileName, out string errorMessage);
        void ListBucket(out string errorMessage);
        List<S3Object> ListingObjects(string bucketName, string folder, out string errorMessage);
        List<JXTPortal.Common.Models.FileManagerFile> ListingFiles(string bucketName, out string errorMessage);
        List<JXTPortal.Common.Models.FileManagerFile> ListingFiles(string bucketName, string folder, out string errorMessage);
        void MoveObject(string bucketName, string sourceFolder, string sourceName, string destinationFolder, string destinationName, out string errorMessage);
        void PutObject(string bucketName, string folder, string fileName, System.IO.Stream inputSream, out string errorMessage);
        void RenameFolder(string bucketName, string sourceFolder, string destinationFolder, out string errorMessage);
    }

    public class AwsS3 : IAwsS3
    {
        private IAmazonS3 _client;
        private ILog _logger;
        private static string DummyFileName = ConfigurationManager.AppSettings["AWSS3NullFileName"];
        private static string Region = ConfigurationManager.AppSettings["AWSS3Region"];

        public AwsS3()
        {
            string profile = ConfigurationManager.AppSettings["AWSProfileName"];
            AWSCredentials credentials = new Amazon.Runtime.StoredProfileAWSCredentials(profile);
            _client = new AmazonS3Client(credentials, RegionEndpoint.GetBySystemName(Region));
            _logger = LogManager.GetLogger(typeof(AwsS3));
        }

        private string errorHandling(AmazonS3Exception exception, string action, List<ParamInfo> paramInfos)
        {
            string errorMessage = string.Empty;

            if (exception.ErrorCode != null && (exception.ErrorCode.Equals("InvalidAccessKeyId") || exception.ErrorCode.Equals("InvalidSecurity")))
            {
                errorMessage = "Please check the provided AWS Credentials.";
            }
            else
            {
                errorMessage = string.Format("{0}: An error occurred with the message '{1}'", action, exception.Message);
            }

            string loggerError = string.Format("{0}. {1}", string.Join(", ", paramInfos.Select(x => x.Name + ": " + x.Value)));
            _logger.Error(loggerError, exception);

            return errorMessage;
        }

        public void CreateFolder(string bucketName, string folder, out string errorMessage)
        {
            errorMessage = string.Empty;

            PutObject(bucketName, folder, DummyFileName, new MemoryStream(), out errorMessage);
        }

        public List<S3Object> ListingObjects(string bucketName, string folder, out string errorMessage)
        {
            errorMessage = string.Empty;
            List<S3Object> s3Objects = new List<S3Object>();
            List<ParamInfo> paramInfos = new List<ParamInfo>();

            try
            {
                ListObjectsRequest request = new ListObjectsRequest();
                request.BucketName = bucketName;
                request.Prefix = (string.IsNullOrEmpty(folder)) ? string.Empty : folder + "/";
                ListObjectsResponse response = _client.ListObjects(request);

                s3Objects = response.S3Objects;
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                paramInfos.Add(new ParamInfo { Name = "bucketName", Value = bucketName });
                paramInfos.Add(new ParamInfo { Name = "folder", Value = folder });

                errorMessage = errorHandling(amazonS3Exception, MethodBase.GetCurrentMethod().Name, paramInfos);
            }

            return s3Objects;
        }

        public List<FileManagerFile> ListingFiles(string bucketName, out string errorMessage)
        {
            return ListingFiles(bucketName, string.Empty, out errorMessage);
        }

        public List<FileManagerFile> ListingFiles(string bucketName, string folder, out string errorMessage)
        {
            List<FileManagerFile> files = null;
            errorMessage = string.Empty;

            List<S3Object> s3Objects = ListingObjects(bucketName, folder, out errorMessage);
            if (string.IsNullOrEmpty(errorMessage))
            {
                files = s3Objects.Select(x => new FileManagerFile
                                              {
                                                  IsFolder = false,
                                                  BucketName = x.BucketName,
                                                  ETag = x.ETag,
                                                  FileName = x.Key,
                                                  LastModified = x.LastModified,
                                                  Size = x.Size
                                              }).ToList();
            }

            return files;
        }

        public Stream GetObject(string bucketName, string folder, string fileName, out string errorMessage)
        {
            errorMessage = string.Empty;
            Stream responseStream = null;
            List<ParamInfo> paramInfos = new List<ParamInfo>();

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
                paramInfos.Add(new ParamInfo { Name = "bucketName", Value = bucketName });
                paramInfos.Add(new ParamInfo { Name = "folder", Value = folder });
                paramInfos.Add(new ParamInfo { Name = "fileName", Value = fileName });

                errorMessage = errorHandling(amazonS3Exception, MethodBase.GetCurrentMethod().Name, paramInfos);
            }

            return responseStream;
        }

        public void DeleteObject(string bucketName, string folder, string fileName, out string errorMessage)
        {
            errorMessage = string.Empty;
            List<ParamInfo> paramInfos = new List<ParamInfo>();

            try
            {
                DeleteObjectRequest request = new DeleteObjectRequest();
                request.BucketName = bucketName;
                request.Key = string.Format("{0}{1}", (string.IsNullOrEmpty(folder)) ? string.Empty : folder + "/", fileName);

                DeleteObjectResponse response = _client.DeleteObject(request);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                paramInfos.Add(new ParamInfo { Name = "bucketName", Value = bucketName });
                paramInfos.Add(new ParamInfo { Name = "folder", Value = folder });
                paramInfos.Add(new ParamInfo { Name = "fileName", Value = fileName });

                errorMessage = errorHandling(amazonS3Exception, MethodBase.GetCurrentMethod().Name, paramInfos);
            }
        }

        public void PutObject(string bucketName, string folder, string fileName, Stream inputSream, out string errorMessage)
        {
            errorMessage = string.Empty;
            List<ParamInfo> paramInfos = new List<ParamInfo>();

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
                paramInfos.Add(new ParamInfo { Name = "bucketName", Value = bucketName });
                paramInfos.Add(new ParamInfo { Name = "folder", Value = folder });
                paramInfos.Add(new ParamInfo { Name = "fileName", Value = fileName });

                errorMessage = errorHandling(amazonS3Exception, MethodBase.GetCurrentMethod().Name, paramInfos);
            }
        }

        public void CopyObject(string bucketName, string sourceFolder, string sourceName, string destinationFolder, string destinationName, out string errorMessage)
        {
            errorMessage = string.Empty;
            List<ParamInfo> paramInfos = new List<ParamInfo>();

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
                paramInfos.Add(new ParamInfo { Name = "bucketName", Value = bucketName });
                paramInfos.Add(new ParamInfo { Name = "sourceFolder", Value = sourceFolder });
                paramInfos.Add(new ParamInfo { Name = "sourceName", Value = sourceName });
                paramInfos.Add(new ParamInfo { Name = "destinationFolder", Value = destinationFolder });
                paramInfos.Add(new ParamInfo { Name = "destinationName", Value = destinationName });

                errorMessage = errorHandling(amazonS3Exception, MethodBase.GetCurrentMethod().Name, paramInfos);
            }
        }

        public void MoveObject(string bucketName, string sourceFolder, string sourceName, string destinationFolder, string destinationName, out string errorMessage)
        {
            errorMessage = string.Empty;

            CopyObject(bucketName, sourceFolder, sourceName, destinationFolder, destinationName, out errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return;
            }

            DeleteObject(bucketName, sourceFolder, sourceName, out errorMessage);
        }

        public void RenameFolder(string bucketName, string sourceFolder, string destinationFolder, out string errorMessage)
        {
            errorMessage = string.Empty;

            List<S3Object> s3Objects = ListingObjects(bucketName, sourceFolder, out errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
                return;

            foreach (S3Object s3Object in s3Objects)
            {
                string fileName = s3Object.Key.Split(new char[] { '/' }).Last();
                CopyObject(bucketName, sourceFolder, fileName, destinationFolder, fileName, out errorMessage);

                if (!string.IsNullOrEmpty(errorMessage))
                    return;

                DeleteObject(bucketName, sourceFolder, fileName, out errorMessage);
            }
        }

        public void DeleteFolder(string bucketName, string sourceFolder, out string errorMessage)
        {
            errorMessage = string.Empty;
            List<ParamInfo> paramInfos = new List<ParamInfo>();

            try
            {
                List<S3Object> s3Objects = ListingObjects(bucketName, sourceFolder, out errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                    return;

                foreach (S3Object s3Object in s3Objects)
                {
                    string fileName = s3Object.Key.Split(new char[] { '/' }).Last();
                    DeleteObject(bucketName, sourceFolder, fileName, out errorMessage);

                    if (!string.IsNullOrEmpty(errorMessage))
                        return;
                }
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                paramInfos.Add(new ParamInfo { Name = "bucketName", Value = bucketName });
                paramInfos.Add(new ParamInfo { Name = "sourceFolder", Value = sourceFolder });

                errorMessage = errorHandling(amazonS3Exception, MethodBase.GetCurrentMethod().Name, paramInfos);
            }
        }

        public void ListBucket(out string errorMessage)
        {
            errorMessage = string.Empty;
            List<ParamInfo> paramInfos = new List<ParamInfo>();

            try
            {
                ListBucketsResponse response = _client.ListBuckets();
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                errorMessage = errorHandling(amazonS3Exception, MethodBase.GetCurrentMethod().Name, paramInfos);
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

        internal class ParamInfo
        {
            public string Name { get; set; }
            public string Value { get; set; }

            public ParamInfo() { }
        }
    }
}