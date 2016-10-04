using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmailSender;
using System.Configuration;
using System.Net.Configuration;
using System.Security.Cryptography;

namespace JXTJobAlerts
{
    public class Utils
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

        const string ACart_SALT = "esPOir";
        public static string EncryptString(string strString)
        {
            SHA1CryptoServiceProvider objSHA = default(SHA1CryptoServiceProvider);
            byte[] bytPassword = null;
            byte[] bytHashed = null;

            UTF8Encoding utf8 = new UTF8Encoding();
            bytPassword = utf8.GetBytes(strString + ACart_SALT);

            objSHA = new SHA1CryptoServiceProvider();
            bytHashed = objSHA.ComputeHash(bytPassword);

            return Convert.ToBase64String(bytHashed);
        }
    }
}
