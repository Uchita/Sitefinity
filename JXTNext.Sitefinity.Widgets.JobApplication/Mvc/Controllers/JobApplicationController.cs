﻿using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using JXTNext.Sitefinity.Widgets.JobApplication.Mvc.Models.JobApplication;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using Telerik.Sitefinity.Libraries.Model;
using Telerik.Sitefinity.Modules.Libraries;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Workflow;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Controllers
{
    [EnhanceViewEngines]
    [ControllerToolboxItem(Name = "JobApplication_MVC", Title = "Job Application", SectionName = "JXTNext.JobApplication", CssClass = JobApplicationController.WidgetIconCssClass)]
    public class JobApplicationController : Controller
    {
        IBusinessLogicsConnector _blConnector;

        /// <summary>
        /// Gets or sets the name of the template that widget will be displayed.
        /// </summary>
        /// <value></value>
        public string TemplateName
        {
            get
            {
                return this.templateName;
            }

            set
            {
                this.templateName = value;
            }
        }

        public JobApplicationController(IBusinessLogicsConnector blConnector)
        {
            _blConnector = blConnector;
        }

        // GET: JobApplication
        [HttpGet]
        public ActionResult Index()
        {
            JobApplicationViewModel jobApplicationViewModel = GetJobApplicationConfigurations(JobApplicationStatus.Available, "Upload your files to Apply");

            return View("JobApplication.Simple", jobApplicationViewModel);
        }

        [HttpPost]
        public ActionResult ApplyJob()
        {
            int applicationResultID = 1;
            int memberID = 2;

            JobApplicationViewModel jobApplicationViewModel;
            List<JobApplicationAttachmentUploadItem> attachments = GatherAttachments();

            string resumeAttachmentPath = GetAttachmentPath(attachments, JobApplicationAttachmentType.Resume);
            string coverletterAttachmentPath = GetAttachmentPath(attachments, JobApplicationAttachmentType.Coverletter);

            //Create Application 
            IMemberApplicationResponse response = _blConnector.MemberCreateJobApplication(new JXTNext_MemberApplicationRequest { ApplyResourceID = applicationResultID, MemberID = memberID, ResumePath = resumeAttachmentPath, CoverletterPath = coverletterAttachmentPath });

            if( response.Success && response.ApplicationID.HasValue)
            {
                //FileUploads
                attachments.ForEach(c => ProcessFileUpload(ref c));

                bool hasFailedUpload = attachments.Where(c => c.Status != "Completed").Any();

                if (hasFailedUpload)
                    //prompt error message for contact
                    jobApplicationViewModel = GetJobApplicationConfigurations(JobApplicationStatus.Technical_Issue, "Unable to attach files to application");
                else
                    jobApplicationViewModel = GetJobApplicationConfigurations(JobApplicationStatus.Applied_Successful, "Your application was successfully processed");

            }
            else
            {
                jobApplicationViewModel = GetJobApplicationConfigurations(JobApplicationStatus.NotAvailable, response.Errors.First() );
            }

            var fullTemplateName = this.templateNamePrefix + this.TemplateName;
            return View("JobApplication.Simple", jobApplicationViewModel);
        }

        private void FetchFromAmazonS3(string providerName, string libraryName, string itemTitle)
        {
            LibrariesManager librariesManager = LibrariesManager.GetManager(providerName);
            var docLibs = librariesManager.GetDocumentLibraries();

            foreach (var lib in docLibs)
            {
                if (lib.Title.ToLower() == libraryName)
                {
                    var document = lib.Items().Where(item => item.Title == itemTitle).FirstOrDefault();
                    var stream = librariesManager.Download(document);
                }
            }
        }

        private void UploadToAmazonS3(Guid masterDocumentId, string providerName, string libName, string fileName, Stream fileStream)
        {
            LibrariesManager librariesManager = LibrariesManager.GetManager(providerName);
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
                WorkflowManager.MessageWorkflow(masterDocumentId, typeof(Document), null, "Publish", false, bag);
            }
        }

        private JobApplicationViewModel GetJobApplicationConfigurations(JobApplicationStatus status, string message)
        {
            return new JobApplicationViewModel
            {
                ApplicationTitle = message,
                ApplicationStatus = status,
                ApplicationAttachments = new List<JobApplicationAttachmentItem>
                {
                    //Resume
                    new JobApplicationAttachmentItem
                    {
                        AttachementType = JobApplicationAttachmentType.Resume,
                        Title = "Resume",
                        Enabled = true,
                        AttachementFileUploadKey = JobApplicationAttachmentSettings.APPLICATION_RESUME_UPLOAD_KEY,
                        Integrations = null
                    },
                    //Coverletter
                    new JobApplicationAttachmentItem
                    {
                        AttachementType = JobApplicationAttachmentType.Coverletter,
                        Title = "Cover Letter",
                        Enabled = true,
                        AttachementFileUploadKey = JobApplicationAttachmentSettings.APPLICATION_COVERLETTER_UPLOAD_KEY,
                        Integrations = null
                    }
                },
                ApplicationMessage = null
            };
        }

        private List<JobApplicationAttachmentUploadItem> GatherAttachments()
        {
            List<JobApplicationAttachmentUploadItem> attachmentItems = new List<JobApplicationAttachmentUploadItem>();

            bool hasResumeUpload = Request.Files.AllKeys.Contains(JobApplicationAttachmentSettings.APPLICATION_RESUME_UPLOAD_KEY);
            if (hasResumeUpload)
            {
                JobApplicationAttachmentUploadItem item = GatherAttachmentDetails(JobApplicationAttachmentType.Resume, Request.Files[JobApplicationAttachmentSettings.APPLICATION_RESUME_UPLOAD_KEY]);
                if (item != null)
                    attachmentItems.Add(item);
            }

            bool hasCoverletterUpload = Request.Files.AllKeys.Contains(JobApplicationAttachmentSettings.APPLICATION_COVERLETTER_UPLOAD_KEY);
            if (hasCoverletterUpload)
            {
                JobApplicationAttachmentUploadItem item = GatherAttachmentDetails(JobApplicationAttachmentType.Coverletter, Request.Files[JobApplicationAttachmentSettings.APPLICATION_COVERLETTER_UPLOAD_KEY]);
                if (item != null)
                    attachmentItems.Add(item);
            }

            return attachmentItems;
        }

        private string GetAttachmentPath(List<JobApplicationAttachmentUploadItem> attachmentItems, JobApplicationAttachmentType attachmentType)
        {
            JobApplicationAttachmentUploadItem item = attachmentItems.Where(c => c.AttachmentType == attachmentType).FirstOrDefault();
            if (item == null)
                return null;
            return item.PathToAttachment;
        }

        private JobApplicationAttachmentUploadItem GatherAttachmentDetails(JobApplicationAttachmentType attachmentType, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                Guid identifier = Guid.NewGuid();
                return new JobApplicationAttachmentUploadItem
                {
                    Id = identifier.ToString(),
                    AttachmentType = attachmentType,
                    FileName = file.FileName,
                    FileStream = file.InputStream,
                    PathToAttachment = identifier.ToString() + "_" + file.FileName,
                    Status = "Ready"
                };
            }
            return null;
        }

        private void ProcessFileUpload(ref JobApplicationAttachmentUploadItem uploadItem)
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

        private string FileUploadLibraryGet(JobApplicationAttachmentType attachmentType)
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

        internal const string WidgetIconCssClass = "sfMvcIcn";
        private string templateName = "Simple";
        private string templateNamePrefix = "JobApplication.";
    }
}