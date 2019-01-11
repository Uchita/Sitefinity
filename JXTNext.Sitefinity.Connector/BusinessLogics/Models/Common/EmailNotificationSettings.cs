using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Common
{
    public class EmailAttachment
    {
        public Stream fileStream { set; get; }
        public string fileName { set; get; }
    }

    public class MemoryStreamJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(MemoryStream).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var bytes = serializer.Deserialize<byte[]>(reader);
            return bytes != null ? new MemoryStream(bytes) : new MemoryStream();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var bytes = ((MemoryStream)value).ToArray();
            serializer.Serialize(writer, bytes);
        }
    }

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

        [JsonConverter(typeof(MemoryStreamJsonConverter))]
        public MemoryStream ResumeFileStream { get; set; } = new MemoryStream();
        public string ResumeFileName { get; set; }
        [JsonConverter(typeof(MemoryStreamJsonConverter))]
        public MemoryStream CoverLeterFileStream { get; set; } = new MemoryStream();
        public string CoverLeterFileName { get; set; }

        public string ResumeFileStreamJson { get; set; }
        public string CoverLeterFileStreamJson { get; set; }

        public EmailNotificationSettings(EmailTarget fromSender, EmailTarget toSender, string subject, string htmlContent, Stream resumeFileStream, string resumeFileName,Stream coverLetterFileStream,string coverLetterFileName)
        {
            _to = toSender.Email;
            _from = fromSender.Email;
            _senderName = fromSender.Name;
            _subject = subject;
            _ccEmails = new List<EmailTarget>();
            _bccEmails = new List<EmailTarget>();
            _htmlContent = htmlContent;
            if(resumeFileStream != null)
                resumeFileStream.CopyTo(ResumeFileStream);

            ResumeFileName = resumeFileName;
            if(coverLetterFileStream != null)
                coverLetterFileStream.CopyTo(CoverLeterFileStream);

            CoverLeterFileName = coverLetterFileName;

            ResumeFileStreamJson = JsonConvert.SerializeObject(ResumeFileStream, Formatting.Indented, new MemoryStreamJsonConverter());
            CoverLeterFileStreamJson = JsonConvert.SerializeObject(CoverLeterFileStream, Formatting.Indented, new MemoryStreamJsonConverter());
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
