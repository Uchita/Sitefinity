using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using JXTNext.Sitefinity.Services.Intefaces.Models.JobApplication;

namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Models
{
    public class CreateJobApplicationResponse
    {
        public IMemberApplicationResponse MemberApplicationResponse { get; set; }
        public JobApplicationStatus Status { get; set; }
        public string Message { get; set; }
        public bool FilesUploaded { get; set; }
    }
}
