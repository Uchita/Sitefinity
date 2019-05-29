using JXTNext.Common.FileManager;
using JXTNext.Common.FileManager.Models.S3;
using JXTNext.FileHandler.FileHandlerServices.Dropbox;
using JXTNext.FileHandler.Models.Dropbox;
using JXTNext.Sitefinity.Common.Constants;
using JXTNext.Sitefinity.Common.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Libraries.Model;
using Telerik.Sitefinity.Modules.Libraries;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Workflow;

namespace JXTNext.Sitefinity.Services.Intefaces.Models.JobApplication
{
    public class JobApplicationAttachmentSettings
    {
        public static string APPLICATION_RESUME_UPLOAD_KEY = "application-resume";
        public static string APPLICATION_RESUME_UPLOAD_LIBRARY = "application-resume";

        public static string APPLICATION_COVERLETTER_UPLOAD_KEY = "application-coverletter";
        public static string APPLICATION_COVERLETTER_UPLOAD_LIBRARY = "application-coverletter";

        public static string PROFILE_RESUME_UPLOAD_KEY = "profile-resume";
        public static string PROFILE_RESUME_UPLOAD_LIBRARY = "profile-resume";

        public static string PROFILE_COVERLETTER_UPLOAD_KEY = "profile-coverletter";
        public static string PROFILE_COVERLETTER_UPLOAD_LIBRARY = "profile-coverletter";
    }

    public class JobApplicationAttachmentItem
    {
        public bool Enabled { get; set; }
        public JobApplicationAttachmentType AttachementType { get; set; }
        public string Title { get; set; }
        public string AttachementFileUploadKey { get; set; }

        public List<JobApplicationAttachmentIntegration> Integrations { get; set; }

    }

    public class JobApplicationAttachmentIntegration
    {
        public string IntegrationType { get; set; }
        public bool Enabled { get; set; }
    }

    public class JobApplicationAttachmentUploadItem
    {
        private static readonly SiteSettingsHelper _siteSettingsHelper = new SiteSettingsHelper();
        
        public string Id { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public JobApplicationAttachmentType AttachmentType { get; set; }
        public Stream FileStream { get; set; }
        public string FileName { get; set; }
        public string PathToAttachment { get; set; }
        public string FileUrl { get; set; }

        public static void ProcessFileUpload(ref JobApplicationAttachmentUploadItem uploadItem)
        {
            var libName = FileUploadLibraryGet(uploadItem.AttachmentType);

            try
            {
                var response = UploadToAmazonS3(Guid.Parse(uploadItem.Id), _siteSettingsHelper.GetAmazonS3ProviderName(), libName, uploadItem.PathToAttachment, uploadItem.FileStream);
                if (response != null && response.Success)
                {
                    uploadItem.FileUrl = null;
                    uploadItem.Status = "Completed";
                }
                else 
                {
                    uploadItem.Status = "Failed";
                    uploadItem.Message = response?.Errors.FirstOrDefault();
                }
                
            }
            catch (Exception ex)
            {
                uploadItem.Status = "Failed";
                uploadItem.Message = ex.Message;
                Log.Write($"Unable to upload document to the Bucket folder {libName}. " + ex.Message, ConfigurationPolicy.ErrorLog);
            }
        }

        public static string FileUploadLibraryGet(JobApplicationAttachmentType attachmentType)
        {
            switch (attachmentType)
            {
                case JobApplicationAttachmentType.Resume:
                    return JobApplicationAttachmentSettings.APPLICATION_RESUME_UPLOAD_LIBRARY;
                case JobApplicationAttachmentType.Coverletter:
                    return JobApplicationAttachmentSettings.APPLICATION_COVERLETTER_UPLOAD_LIBRARY;
                case JobApplicationAttachmentType.ProfileResume:
                    return JobApplicationAttachmentSettings.PROFILE_RESUME_UPLOAD_LIBRARY;
                case JobApplicationAttachmentType.ProfileCoverletter:
                    return JobApplicationAttachmentSettings.PROFILE_COVERLETTER_UPLOAD_LIBRARY;
                default:
                    return null;
            }
        }

        public static bool DeleteFromAmazonS3(string providerName, JobApplicationAttachmentType attachmentType, string itemTitle)
        {
            SiteSettingsHelper siteSettingsHelper = new SiteSettingsHelper();
            
            S3FilemanagerService fileManagerService = new S3FilemanagerService(_siteSettingsHelper.GetAmazonS3RegionEndpoint(), _siteSettingsHelper.GetAmazonS3AccessKeyId(), _siteSettingsHelper.GetAmazonS3SecretKey());
            var response = fileManagerService.DeleteObjectFromProvider<S3FileManagerResponse, S3FileManagerRequest>(
                    new S3FileManagerRequest
                    {
                        FileName = itemTitle,
                        Directory = _siteSettingsHelper.GetAmazonS3UrlName() + "/" + JobApplicationAttachmentSettings.PROFILE_RESUME_UPLOAD_LIBRARY,
                        S3BucketName = _siteSettingsHelper.GetAmazonS3BucketName()
                    });
            return response != null ? response.Success : false;
        }

        public static bool ValidateFileExistsInTheBlobStorage(string srcLibName, int attachmentType, string fileTitle)
        {
            SiteSettingsHelper siteSettingsHelper = new SiteSettingsHelper();
            fileTitle = fileTitle.Split('_').First() + "_" + fileTitle;

            S3FilemanagerService fileManagerService = new S3FilemanagerService(siteSettingsHelper.GetAmazonS3RegionEndpoint(), siteSettingsHelper.GetAmazonS3AccessKeyId(), siteSettingsHelper.GetAmazonS3SecretKey());
            var response = fileManagerService.ValidateFileExistsInTheBlobStorageRequest<S3FileManagerResponse, S3FileManagerRequest>(
                    new S3FileManagerRequest
                    {
                        FileName = fileTitle,
                        Directory = siteSettingsHelper.GetAmazonS3UrlName() + "/" + JobApplicationAttachmentSettings.PROFILE_RESUME_UPLOAD_LIBRARY,
                        S3BucketName = siteSettingsHelper.GetAmazonS3BucketName()
                    });
            return response.Success;
        }



        public static Stream GetFileStreamFromAmazonS3(string srcLibName,int attachmentType,string fileTitle)
        {
            SiteSettingsHelper siteSettingsHelper = new SiteSettingsHelper();
            fileTitle = fileTitle.Split('_').First();
            
            S3FilemanagerService fileManagerService = new S3FilemanagerService(siteSettingsHelper.GetAmazonS3RegionEndpoint(), siteSettingsHelper.GetAmazonS3AccessKeyId(), siteSettingsHelper.GetAmazonS3SecretKey());
            var response = fileManagerService.GetObjectFromProviderByGuid<S3FileManagerResponse, S3FileManagerRequest>(
                    new S3FileManagerRequest
                    {
                        FileName = fileTitle,
                        Directory = siteSettingsHelper.GetAmazonS3UrlName() + "/" + JobApplicationAttachmentSettings.PROFILE_RESUME_UPLOAD_LIBRARY,
                        S3BucketName = siteSettingsHelper.GetAmazonS3BucketName()
                    });
            return response.FileStream;
        }

        

        public static string GetAttachmentPath(List<JobApplicationAttachmentUploadItem> attachmentItems, JobApplicationAttachmentType attachmentType)
        {
            JobApplicationAttachmentUploadItem item = attachmentItems.Where(c => c.AttachmentType == attachmentType).FirstOrDefault();
            Log.Write("In GetAttachmentPath method item", ConfigurationPolicy.ErrorLog);
            if (item == null)
                return null;
            return item.PathToAttachment;
        }

        public static S3FileManagerResponse UploadToAmazonS3(Guid masterDocumentId, string providerName, string libName, string fileName, Stream fileStream)
        {
            try
            {
                SiteSettingsHelper siteSettingsHelper = new SiteSettingsHelper();
                
                S3FilemanagerService fileManagerService = new S3FilemanagerService(_siteSettingsHelper.GetAmazonS3RegionEndpoint(), _siteSettingsHelper.GetAmazonS3AccessKeyId(), _siteSettingsHelper.GetAmazonS3SecretKey());
                var response = fileManagerService.PostObjectToProvider<S3FileManagerResponse, S3FileManagerRequest>(
                        new S3FileManagerRequest
                        {
                            FileName = masterDocumentId.ToString() + "_" + fileName,
                            Directory = _siteSettingsHelper.GetAmazonS3UrlName() + "/" + libName,
                            FileStream = fileStream,
                            S3BucketName = _siteSettingsHelper.GetAmazonS3BucketName(),
                            ContentType = AmazonS3Constants.DocumentContentType
                        });
                return response;
            }
            catch (Exception)
            {
                return null;
            }
            
        }


        
    }

    public enum JobApplicationAttachmentType
    {
        Resume = 1,
        Coverletter = 2,
        ProfileResume = 3,
        ProfileCoverletter = 4
    }

    public enum JobApplicationAttachmentSource
    {
        Local = 1,
        GoogleDrive = 2,
        Dropbox = 3
    }

    public enum JobApplicationStatus
    {
        Available = 1,
        NotAvailable = 2,
        Applied_Successful = 3,
        Already_Applied = 4,
        Technical_Issue = 5,
        NotAbleToCreateUser = 6,
        NotAbleToLoginCreatedUser = 7
    }


    public class ApplicantInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsNewUser { get; set; }
    }
}
