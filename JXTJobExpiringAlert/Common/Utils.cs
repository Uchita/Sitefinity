using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmailSender;
using System.Configuration;
using System.Net.Configuration;
using System.Security.Cryptography;

namespace JXTJobExpiringAlert
{
    static class Utils
    {
        public static SmtpSender EmailSender()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            MailSettingsSectionGroup mailConfiguration = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

            SmtpSender mailObject = new SmtpSender(mailConfiguration.Smtp.Network.Host);

            mailObject.Port = mailConfiguration.Smtp.Network.Port;
            if (!mailConfiguration.Smtp.Network.DefaultCredentials)
            {
                mailObject.UserName = mailConfiguration.Smtp.Network.UserName;
                mailObject.Password = mailConfiguration.Smtp.Network.Password;
            }

            return mailObject;
        }
    }
}
