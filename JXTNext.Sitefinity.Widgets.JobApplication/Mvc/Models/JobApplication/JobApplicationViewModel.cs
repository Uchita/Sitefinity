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
    }
}
