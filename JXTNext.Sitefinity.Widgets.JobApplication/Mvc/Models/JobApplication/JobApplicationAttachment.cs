using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.JobApplication.Mvc.Models.JobApplication
{
    public class JobApplicationAttachmentSettings
    {
        public static string APPLICATION_RESUME_UPLOAD_KEY = "application-resume";
        public static string APPLICATION_RESUME_UPLOAD_LIBRARY = "application-resume";       

        public static string APPLICATION_COVERLETTER_UPLOAD_KEY = "application-coverletter";
        public static string APPLICATION_COVERLETTER_UPLOAD_LIBRARY = "application-coverletter";

        public static string APPLICATION_DOCUMENTS_UPLOAD_KEY = "application-documents";
        public static string APPLICATION_DOCUMENTS_UPLOAD_LIBRARY = "application-documents";

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
        public string Id { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public JobApplicationAttachmentType AttachmentType { get; set; }
        public Stream FileStream { get; set; }
        public string FileName { get; set; }
        public string PathToAttachment { get; set; }
        public string FileUrl { get; set; }
        public string ContentType { get; set; }
    }

    public enum JobApplicationAttachmentType
    {
        Resume = 1,
        Coverletter = 2,
        Documents = 3
    }

    public enum JobApplicationAttachmentSource
    {
        Local = 1,
        GoogleDrive = 2,
        Dropbox = 3,
        Saved = 4
    }

}
