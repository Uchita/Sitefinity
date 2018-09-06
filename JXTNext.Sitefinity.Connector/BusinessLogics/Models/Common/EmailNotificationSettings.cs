using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Common
{
    public class EmailNotificationSettings
    {
        private string _from;
        private List<EmailTarget> _ccEmails;
        private List<EmailTarget> _bccEmails;
        private string _htmlContent;
        private string _to;
        private string _senderName;
        private string _subject;

        public string From { get { return _from; } }
        public string Subject => _subject;
        public string To { get { return _to; } }
        public string SenderName { get { return _senderName; } }
        public List<EmailTarget> CcEmail { get { return _ccEmails; } }
        public List<EmailTarget> BccEmail { get { return _bccEmails; } }
        public string HtmlContent { get { return _htmlContent; } }

        public EmailNotificationSettings(EmailTarget fromSender, EmailTarget toSender, string subject, string htmlContent)
        {
            _to = toSender.Email;
            _from = fromSender.Email;
            _senderName = fromSender.Name;
            _subject = subject;
            _ccEmails = new List<EmailTarget>();
            _bccEmails = new List<EmailTarget>();
            _htmlContent = htmlContent;
        }

        public void AddCC(string name, string email)
        {
            _ccEmails.Add(new EmailTarget(name, email));
        }

        public void AddBCC(string name, string email)
        {
            _bccEmails.Add(new EmailTarget(name, email));
        }

    }

    public class EmailTarget
    {
        string _name;
        string _email;

        public string Email => _email;
        public string Name => _name;

        /// <summary>
        /// EmailTarget
        /// </summary>
        /// <param name="name">Email Recipient Name</param>
        /// <param name="email">Email Address</param>
        public EmailTarget(string name, string email)
        {
            _name = name;
            _email = email;
        }
    }
}
