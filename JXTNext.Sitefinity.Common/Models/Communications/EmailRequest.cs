using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Common.Models.Communications
{
    public class EmailRequest
    {
        public MailAddress To { get; set; }
        public MailAddress From { get; set; }
        public MailAddress ReplyTo { get; set; }
        public MailAddressCollection Cc { get; set; }
        public MailAddressCollection Bcc { get; set; }
        public string EmailBody { get; set; }
        public string Subject { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
}
