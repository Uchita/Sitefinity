using JXTNext.Sitefinity.Services.Intefaces.Models.JobApplication;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Services.Intefaces
{
    public interface IJobApplicationService
    {
        string GetOverrideEmail(ref JobApplicationStatus status, ref ApplicantInfo applicantInfo, bool isSocialMedia = false);
        bool UploadFiles(List<JobApplicationAttachmentUploadItem> attachments);
        string GetHtmlEmailContent(string emailTemplateId, string emailTemplateProviderName, string itemType);
        bool DeleteFile(JobApplicationAttachmentUploadItem deletefile);
        Stream GetFileStreamFromAmazonS3(string srcLibName, int attachmentType, string id);
        string GetHtmlEmailSubject(string emailTemplateId, string emailTemplateProviderName, string itemType);
        bool ValidateFileExistsInTheBlobStoreage(string srcLibName, int attachmentType, string id);
    }
}
