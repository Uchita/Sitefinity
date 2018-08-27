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
        private List<string> _ccEmails;
        private List<string> _bccEmails;
        private string _htmlContent;

        public string From { get { return _from; } }
        public List<string> CcEmail { get { return _ccEmails; } }
        public List<string> BccEmail { get { return _bccEmails; } }
        public string HtmlContent { get { return _htmlContent; } }

        public EmailNotificationSettings(string fromName, List<string> ccEmails, List<string> bccEmails, string htmlContent)
        {
            _from = fromName;
            _ccEmails = ccEmails;
            _bccEmails = bccEmails;
            _htmlContent = htmlContent;
        }

    }
}
