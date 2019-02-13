using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.JobApplication.Mvc.Models.JobApplication
{
    public class JobApplicationViewModel
    {
        public string ApplicationTitle { get; set; }
        public List<JobApplicationAttachmentItem> ApplicationAttachments { get; set; }

        public JobApplicationStatus ApplicationStatus { get; set; }
        public string ApplicationMessage { get; set; }
        public JobApplicationUploadFilesModel UploadFiles { get; set; }
        public int JobId { get; set; }
        public string ApplicationEmail { get; set; }
        public string ContactDetails { get; set; }
        public string UrlReferral { get; set; }
        public List<ApplyWithSocialMedia> ApplyWithSocialMediaInfo { get; set; }
    }

    public class JobApplicationUploadFilesModel
    {
        public bool IsDropBoxResume { get; set; }
        public bool IsDropBoxCoverLetter { get; set; }
        public bool IsGoogleDriveResume { get; set; }
        public bool IsGoogleDriveCoverLetter { get; set; }
    }

    public class ApplyJobModel
    {
        public int JobId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UploadFilesResume { get; set; }
        public string UploadFilesCoverLetter { get; set; }
        public string UploadFilesDocuments { get; set; }
        public string ResumeSelectedType { get; set; }
        public string CoverLetterSelectedType { get; set; }
        public string DocumentsSelectedType { get; set; }
        public string ApplicationEmail { get; set; }
        public string ContactDetails { get; set; }
        public string CompanyName { get; set; }
        public string UrlReferral { get; set; }
    }

    public class UploadFilesFormPostModel
    {
        public string UrlPath { get; set; }
        public string FileName { get; set; }
        public string Field { get; set; }
        public string AuthToken { get; set; }
        public string MIMEType { get; set; }
    }

    public class ApplyWithSocialMedia
    {
        public bool Selected { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }

        public static string SerializedSocialMediaInit()
        {
            var socialLinks = new List<ApplyWithSocialMedia>();
            socialLinks.Add(new ApplyWithSocialMedia() { Id = 1, Selected = false, Title = "Seek" });
            socialLinks.Add(new ApplyWithSocialMedia() { Id = 2, Selected = false, Title = "Indeed" });
            socialLinks.Add(new ApplyWithSocialMedia() { Id = 3, Selected = false, Title = "LinkedIn" });

            return JsonConvert.SerializeObject(socialLinks);
        }
    }

}
