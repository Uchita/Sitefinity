using JXTNext.FileHandler.FileHandlerServices.Dropbox;
using JXTNext.FileHandler.Models.Dropbox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telerik.Sitefinity.Libraries.Model;
using Telerik.Sitefinity.Modules.Libraries;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Workflow;

namespace JXTNext.Sitefinity.Widgets.JobApplication.Mvc.Models.JobApplication
{
    public class JobApplicationAttachmentSettings
    {
        public static string APPLICATION_RESUME_UPLOAD_KEY = "application-resume";
        public static string APPLICATION_RESUME_UPLOAD_LIBRARY = "application-resume";

        public static string APPLICATION_COVERLETTER_UPLOAD_KEY = "application-coverletter";
        public static string APPLICATION_COVERLETTER_UPLOAD_LIBRARY = "application-coverletter";
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
        public string Id { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public JobApplicationAttachmentType AttachmentType { get; set; }
        public Stream FileStream { get; set; }
        public string FileName { get; set; }
        public string PathToAttachment { get; set; }

        public static void ProcessFileUpload(ref JobApplicationAttachmentUploadItem uploadItem)
        {
            var libName = FileUploadLibraryGet(uploadItem.AttachmentType);

            try
            {
                UploadToAmazonS3(Guid.Parse(uploadItem.Id), "private-amazon-s3-provider", libName, uploadItem.PathToAttachment, uploadItem.FileStream);
                uploadItem.Status = "Completed";
            }
            catch (Exception ex)
            {
                uploadItem.Status = "Failed";
                uploadItem.Message = ex.Message;
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
                default:
                    return null;
            }
        }

        public static string GetAttachmentPath(List<JobApplicationAttachmentUploadItem> attachmentItems, JobApplicationAttachmentType attachmentType)
        {
            JobApplicationAttachmentUploadItem item = attachmentItems.Where(c => c.AttachmentType == attachmentType).FirstOrDefault();
            if (item == null)
                return null;
            return item.PathToAttachment;
        }

        public static void UploadToAmazonS3(Guid masterDocumentId, string providerName, string libName, string fileName, Stream fileStream)
        {
            LibrariesManager librariesManager = LibrariesManager.GetManager(providerName);
            var libManagerSecurityCheckStatus = librariesManager.Provider.SuppressSecurityChecks;

            try
            {
                // Make sure that supress the security checks so that everyone can upload the files
                librariesManager.Provider.SuppressSecurityChecks = true;
                Document document = librariesManager.GetDocuments().Where(i => i.Id == masterDocumentId).FirstOrDefault();

                if (document == null)
                {
                    //The document is created as master. The masterDocumentId is assigned to the master version.
                    document = librariesManager.CreateDocument(masterDocumentId);

                    //Set the parent document library.
                    DocumentLibrary documentLibrary = librariesManager.GetDocumentLibraries().Where(d => d.Title == libName).SingleOrDefault();
                    document.Parent = documentLibrary;

                    //Set the properties of the document.
                    string documentTitle = masterDocumentId.ToString() + "_" + fileName;
                    document.Title = documentTitle;
                    document.DateCreated = DateTime.UtcNow;
                    document.PublicationDate = DateTime.UtcNow;
                    document.LastModified = DateTime.UtcNow;
                    document.UrlName = Regex.Replace(documentTitle.ToLower(), @"[^\w\-\!\$\'\(\)\=\@\d_]+", "-");
                    document.MediaFileUrlName = Regex.Replace(documentTitle.ToLower(), @"[^\w\-\!\$\'\(\)\=\@\d_]+", "-");
                    document.ApprovalWorkflowState = "Published";

                    //Upload the document file.
                    string fileExtension = fileName.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                    librariesManager.Upload(document, fileStream, fileExtension ?? string.Empty);

                    //Recompiles and validates the url of the document.
                    librariesManager.RecompileAndValidateUrls(document);

                    //Save the changes.
                    librariesManager.SaveChanges();

                    //Publish the DocumentLibraries item. The live version acquires new ID.
                    var bag = new Dictionary<string, string>();
                    bag.Add("ContentType", typeof(Document).FullName);

                    // Run with elevatede privilages so that everybody can upload files
                    SystemManager.RunWithElevatedPrivilege(d => WorkflowManager.MessageWorkflow(masterDocumentId, typeof(Document), null, "Publish", false, bag));
                }
            }

            finally
            {
                // Reset the suppress security checks
                librariesManager.Provider.SuppressSecurityChecks = libManagerSecurityCheckStatus;
            }
        }
    }

    public enum JobApplicationAttachmentType
    {
        Resume = 1,
        Coverletter = 2
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
    }
}
