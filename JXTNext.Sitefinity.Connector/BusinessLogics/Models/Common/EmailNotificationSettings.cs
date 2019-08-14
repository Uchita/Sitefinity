using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Common
{
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
        public List<EmailAttachment> EmailAttachments { get; set; } = new List<EmailAttachment>();

        [JsonConverter(typeof(MemoryStreamJsonConverter))]
        public MemoryStream fileStream { get; set; } 

        

        public EmailNotificationSettings(EmailTarget fromSender, EmailTarget toSender, string subject, string htmlContent, List<dynamic> attachments)
        {
            _to = toSender.Email;
            _from = fromSender.Email;
            _senderName = fromSender.Name;
            _subject = subject;
            _ccEmails = new List<EmailTarget>();
            _bccEmails = new List<EmailTarget>();
            _htmlContent = htmlContent;

            if(attachments != null)
            { 
                foreach (var item in attachments)
                {
                    EmailAttachment attachment = new EmailAttachment();
                    fileStream = new MemoryStream();
                    item.FileStream.CopyTo(fileStream);
                    attachment.FileName = item.FileName;
                    attachment.FileStreamJson = JsonConvert.SerializeObject(fileStream, Formatting.Indented, new MemoryStreamJsonConverter());
                    EmailAttachments.Add(attachment);
                }
            }
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

    public class EmailAttachment
    {
        public string FileName { get; set; }
        
        public string FileStreamJson { get; set; }
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
