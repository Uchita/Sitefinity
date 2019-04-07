using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Common.Models.JobApplication
{
    public class JobApplicationEmailTemplateModel
    {
        public string ToFullName { get { return (this.ToLastName != null) ? this.ToFirstName + " " + this.ToLastName : this.ToFirstName; } }

        public string ToFirstName { get; set; }

        public string ToLastName { get; set; }

        public string FromFullName { get { return (this.FromLastName != null) ? this.FromFirstName + " " + this.FromLastName: this.FromFirstName; } }

        public string FromFirstName { get; set; }

        public string FromLastName { get; set; }

        public string ToEmail { get; set; }

        public string FromEmail { get; set; }

        public string Subject { get; set; }

        public string HtmlContent { get; set; }

        public List<dynamic> Attachments { get; set; }

    }
}
