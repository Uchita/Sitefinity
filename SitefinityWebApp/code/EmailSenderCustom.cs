using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.Forms.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.Forms;
using Telerik.Sitefinity.Modules.Forms.Events;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace SitefinityWebApp.code
{
    public class EmailSenderCustom
    {

        public void SendEmail(IFormEntryCreatedEvent eventInfo)
        {       
            

            string UserName = "";
            string EmailAddress = "";
            string EmailTemplateName = "";
            FormsManager formsManager = FormsManager.GetManager();
            var form = formsManager.GetFormByName(eventInfo.FormName);
            if (form != null)
            {
                string entryType = String.Format("{0}.{1}", formsManager.Provider.FormsNamespace, form.Name);

                var record = formsManager.GetFormEntry(entryType, eventInfo.EntryId);
                FormEntry data = (FormEntry)record;
                var UserNameField = eventInfo.Controls.Where(x => (string)x.GetType().GetProperty("FieldControlName").GetValue(x) == "Form_UserName").Select(x => x.FieldName).FirstOrDefault();
                var EmailField = eventInfo.Controls.Where(x => (string)x.GetType().GetProperty("FieldControlName").GetValue(x) == "Form_Email").Select(x => x.FieldName).FirstOrDefault();
                if (!string.IsNullOrEmpty(UserNameField))
                {
                    UserName = data.GetValue(UserNameField).ToString();
                }
                if (!string.IsNullOrEmpty(EmailField))
                {
                    EmailAddress = data.GetValue(EmailField).ToString();
                }
                try
                {
                    if (data.GetValue("Form_EmailTemplate") != null)
                    {
                        EmailTemplateName = data.GetValue("Form_EmailTemplate").ToString();
                    }
                }
                catch (Exception ex)
                {
                    EmailTemplateName = string.Empty;
                }
                if (!string.IsNullOrEmpty(EmailAddress) && !string.IsNullOrEmpty(EmailTemplateName))
                {
                    DynamicModuleManager dynamicModuleManager = DynamicModuleManager.GetManager();
                    Type emailTemplateType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.StandardEmailTemplate.EmailTemplate");
                    var emailTemplate = dynamicModuleManager.GetDataItems(emailTemplateType).Where(x => x.UrlName == EmailTemplateName).FirstOrDefault();
                    if (emailTemplate != null)
                    {


                        var smtpSettings = Config.Get<SystemConfig>().SmtpSettings;
                        string content = emailTemplate.GetValue("htmlEmailContent").ToString();
                        var str = content;
                        string MailBody = str;
                        MailBody = MailBody.Replace("{Recipient.DisplayName}", UserName);
                        MailMessage oMM = new MailMessage();
                        oMM.To.Add(EmailAddress);
                        oMM.From = new MailAddress(smtpSettings.DefaultSenderEmailAddress, eventInfo.FormTitle);
                        oMM.Subject = eventInfo.FormTitle;
                        oMM.Body = MailBody;
                        oMM.IsBodyHtml = true;
                        oMM.Priority = MailPriority.Normal;
                        SmtpClient oSC = new SmtpClient(smtpSettings.Host, smtpSettings.Port);
                        oSC.Credentials = new NetworkCredential(smtpSettings.UserName, smtpSettings.Password);
                        oSC.EnableSsl = true;
                        oSC.Send(oMM);
                    }

                }
            }


        }

    }
}