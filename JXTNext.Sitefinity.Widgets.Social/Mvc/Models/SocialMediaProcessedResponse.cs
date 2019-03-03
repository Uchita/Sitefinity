using JXTNext.Sitefinity.Services.Intefaces.Models.JobApplication;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Models
{
    public class SocialMediaProcessedResponse
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string FileName { get; set; }
        public Stream FileStream { get; set; }
        public int? JobId { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public string LoginUserEmail { get; set; }
        public bool ResumeLinkNotExists { get; set; } = false;
        public string JobSource { get; set; }
    }

    public class SocialMediaJobViewModel
    {
        public JobApplicationStatus Status { get; set; }
        public string Message { get; set; }
    }
}
