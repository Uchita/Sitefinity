using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Common;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member
{
    public class JXTNext_MemberApplicationRequest : ConnectorBaseRequest, IMemberApplication
    {
        public int MemberID { get; set; }
        public int ApplyResourceID { get; set; }

        public string ResumePath { get; set; }
        public string CoverletterPath { get; set; }
        public List<string> DocumentsPath { get; set; }
        public string AdvertiserName { get; set; }
        public string CompanyName { get; set; }
        public EmailNotificationSettings EmailNotification { get; set; }
        public EmailNotificationSettings AdvertiserEmailNotification { get; set; }
        public EmailNotificationSettings RegistrationEmailNotification { get; set; }
    }



    public class JXTNext_MemberApplicationResponse : ConnectorBaseResponse, IMemberApplicationResponse
    {
        public int? ApplicationID { get; set; }
    }

}
