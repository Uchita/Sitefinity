using JXTNext.Common.Communications.Helpers.Utility;
using JXTNext.Common.Communications.Models.AWS_SES;
using JXTNext.Common.Communications.Services;
using JXTNext.Sitefinity.Common.Models.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Services.Notifications;
using Telerik.Sitefinity.Services.Notifications.Configuration;

namespace JXTNext.Sitefinity.Common.Helpers
{
    public class SitefinityEmailSender
    {
        /// <summary>
        /// This is the main method that provide capability to send an email
        /// </summary>
        /// <param name="emailRequest">EmailRequest Type containing parameters required to send an email</param>
        /// <param name="emailContent">Model Containing Data that requires to be present within the emailbody</param>
        /// <returns>Boolean based on email send success</returns>
        public bool SendEmail(EmailRequest emailRequest, object emailContent)
        {
            var smtpSettings = GetSMTPSettings();

            if (smtpSettings == null)
                throw new NullReferenceException();

            emailRequest.EmailBody = GenerateEmailBody(emailRequest.EmailBody, emailContent);

            return SendEmail(emailRequest, smtpSettings);
        }

        /// <summary>
        /// This Method send the email using AWS SES
        /// </summary>
        /// <param name="emailRequest">EmailRequest Type containing Fields Required to send an email</param>
        /// <param name="smtpSettings">Configured SMTP Settings</param>
        /// <returns>Boolean based on email send success status</returns>
        private bool SendEmail(EmailRequest emailRequest, SmtpElement smtpSettings)
        {
            EmailService emailService = new EmailService();

            SESClientRequest sesRequest = new SESClientRequest()
            {
                To = emailRequest.To,
                ReceiverToBcc = emailRequest.Bcc,
                ReceiverToCc = emailRequest.Cc,
                From = emailRequest.From,
                EmailBody = emailRequest.EmailBody,
                EmailSubject = emailRequest.EmailBody,
                Host = smtpSettings.Host,
                Port = smtpSettings.Port,
                SMTP_Password = smtpSettings.Password,
                SMTP_Username = smtpSettings.UserName
            };

            SESClientResponse emailSendStatus = emailService.SendEmail<SESClientResponse, SESClientRequest>(sesRequest);

            return emailSendStatus.EmailActionSuccess;
        }

        /// <summary>
        /// This Method Generates a complete emailbody by replacing Shortcode Tokens using the provided object
        /// </summary>
        /// <param name="emailBody">HTML Email Template</param>
        /// <param name="emailContent">Model Containing Parameters that needs to be replaced in the email body</param>
        /// <returns>Complete Email Template</returns>
        private string GenerateEmailBody(string emailBody, object emailContent)
        {
            Utils tokenResolver = new Utils();

            return tokenResolver.HTMLShortCodeResolver(emailBody, emailContent);
        }

        /// <summary>
        /// This method gets SMTP settings from the site configuration
        /// </summary>
        /// <returns>SmtpElement containing SMTP Settings</returns>
        private SmtpElement GetSMTPSettings()
        {
            SmtpElement smtpSettings = Config.Get<SystemConfig>().SmtpSettings;

            return smtpSettings;
        }
    }
}
