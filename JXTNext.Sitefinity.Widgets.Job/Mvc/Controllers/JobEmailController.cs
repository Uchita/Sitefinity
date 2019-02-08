using JXTNext.Sitefinity.Common.Helpers;
using JXTNext.Sitefinity.Common.Models.Communications;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Advertisers;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Job;
using JXTNext.Sitefinity.Connector.Options;
using JXTNext.Sitefinity.Widgets.Job.Mvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Multisite;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Utilities.TypeConverters;
using Telerik.Sitefinity.Web;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Controllers
{
    // The ControllerToolboxItem attribute registers the widget in Sitefinity backend
    [ControllerToolboxItem(Name = "JXTNext.JobEmailWidget", Title = "Email Job", SectionName = "JXTNext.Job")]
    public class JobEmailController : Controller
    {
        #region Private fields

        private string _itemType = "Telerik.Sitefinity.DynamicTypes.Model.StandardEmailTemplate.EmailTemplate";
        private string _emailTemplateProvider = "OpenAccessProvider";

        private IBusinessLogicsConnector _BLConnector;
        private IOptionsConnector _OConnector;

        #endregion

        #region Widget designer properties

        public string JobLabel { get; set; }
        public string JobHelp { get; set; }

        public string NameLabel { get; set; }
        public string NameHelp { get; set; }

        public string EmailLabel { get; set; }
        public string EmailHelp { get; set; }

        public string EmailFriendLabel { get; set; }
        public string EmailFriendHelp { get; set; }

        public string FriendNameLabel { get; set; }
        public string FriendNameHelp { get; set; }

        public string FriendEmailLabel { get; set; }
        public string FriendEmailHelp { get; set; }

        public string FriendMessageLabel { get; set; }
        public string FriendMessageHelp { get; set; }

        public string AddFriendButtonLabel { get; set; }
        public string RemoveFriendButtonLabel { get; set; }
        public string SubmitButtonLabel { get; set; }

        public int MaxFriends { get; set; }

        public string JobNotFoundMessage { get; set; }
        public string EmailSentMessage { get; set; }

        public string EmailTemplateId { get; set; }
        public string EmailSubject { get; set; }
        public string EmailFromName { get; set; }
        public string EmailFromEmail { get; set; }

        public string JobDetailsPageId { get; set; }

        public string ItemType
        {
            get { return this._itemType; }
            set { this._itemType = value; }
        }

        public string EmailTemplateProviderName
        {
            get { return _emailTemplateProvider; }
            set { this._emailTemplateProvider = value; }
        }

        #endregion

        #region Constants

        private const string GenericErrorKey = "";
        private const string GenericErrorMessage = "There are a few input errors. Please refer to the red highlighted areas and amend your input.";
        private const string Length255ErrorMessage = "The field value must be a string with a maximum length of 255";

        #endregion        

        #region Constructors

        public JobEmailController(IEnumerable<IBusinessLogicsConnector> _bConnectors, IEnumerable<IOptionsConnector> _oConnectors)
        {
            _BLConnector = _bConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
            _OConnector = _oConnectors.Where(c => c.ConnectorType == JXTNext.Sitefinity.Connector.IntegrationConnectorType.JXTNext).FirstOrDefault();
        }

        #endregion

        #region Actions

        public ActionResult Index(JobEmailFormModel form)
        {
            var templateName = "Default";

            var viewModel = _GetViewModel(templateName, form);

            // get the requested job
            viewModel.Job = _GetRequestedJob(form.JobId);
            if (viewModel.Job == null)
            {
                return View(templateName, viewModel);
            }

            // make sure we are processing the correct form
            if (form.JobEmailFriendAction != "submit")
            {
                ModelState.Clear();

                // set at least one friend in the list
                if (viewModel.Form.Friend.Count == 0)
                {
                    viewModel.Form.Friend.Add(new JobEmailFriendModel());
                }

                return View(templateName, viewModel);
            }

            // validate fields which are required for friend list
            if (form.EmailFriend)
            {
                var fieldKey = "Friend";
                if (ModelState.IsValidField(fieldKey))
                {
                    if (form.Friend == null || form.Friend.Count < 1)
                    {
                        ModelState.AddModelError(fieldKey, JobEmailFormModel.RequiredFieldMessage);
                    }
                    else if (form.Friend.Count > _GetMaxFriends())
                    {
                        ModelState.AddModelError(fieldKey, "Maximum allowed friends is " + this.MaxFriends);
                    }
                    else
                    {
                        var friendValid = true;

                        var emailAttribute = new EmailAddressAttribute();

                        foreach (var item in form.Friend)
                        {
                            // validate name
                            // required, max length 255
                            fieldKey = "Friend.Name";
                            if (string.IsNullOrWhiteSpace(item.Name))
                            {
                                ModelState.AddModelError(fieldKey, "Friend's name is required");

                                friendValid = false;
                            }
                            else if (item.Name.Length > 255)
                            {
                                ModelState.AddModelError(fieldKey, Length255ErrorMessage);

                                friendValid = false;
                            }

                            // validate email
                            // required, max length 255
                            fieldKey = "Friend.Email";
                            if (string.IsNullOrWhiteSpace(item.Email))
                            {
                                ModelState.AddModelError(fieldKey, "Friend's email is required");

                                friendValid = false;
                            }
                            else if (item.Email.Length > 255)
                            {
                                ModelState.AddModelError(fieldKey, Length255ErrorMessage);

                                friendValid = false;
                            }
                            else if (!emailAttribute.IsValid(item.Email))
                            {
                                ModelState.AddModelError(fieldKey, "Friend's email is invalid");

                                friendValid = false;
                            }

                            if (!friendValid)
                            {
                                break;
                            }
                        }
                    }
                }

            }

            // do not proceed if we have errors
            if (!ModelState.IsValid)
            {
                if (!ModelState.Keys.Contains(GenericErrorKey))
                {
                    ModelState.AddModelError(GenericErrorKey, GenericErrorMessage);
                }

                return View(templateName, viewModel);
            }

            try
            {
                if (_SendEmail(form, viewModel.Job))
                {
                    var manager = PageManager.GetManager();
                    var node = SiteMapBase.GetActualCurrentNode();

                    return new RedirectResult(node.Url + "?JobId=" + Url.Encode(form.JobId.ToString()) + "&Sent=1");
                }

                ModelState.AddModelError(GenericErrorKey, "Unable to send email. Please try again.");
            }
            catch (Exception err)
            {
                ModelState.AddModelError(GenericErrorKey, err.Message);

                while (err.InnerException != null)
                {
                    err = err.InnerException;

                    ModelState.AddModelError(GenericErrorKey, err.Message);
                }
            }

            return View(templateName, viewModel);
        }

        #endregion

        #region Private methods

        private JobDetailsFullModel _GetRequestedJob(int jobId)
        {
            try
            {
                var jobListingRequest = new JXTNext_GetJobListingRequest { JobID = jobId };

                var jobListingResponse = _BLConnector.GuestGetJob(jobListingRequest);

                return jobListingResponse.Job;
            }
            catch
            {

            }

            return null;
        }

        private bool _SendEmail(JobEmailFormModel form, JobDetailsFullModel job)
        {
            var subject = string.IsNullOrWhiteSpace(this.EmailSubject) ? "Job for you" : this.EmailSubject;

            var content = _GetHtmlEmailContent();

            var emailSender = new SitefinityEmailSender();

            // ideally there should be a common method to get a job's url
            // doing this due to lack of such method
            var jobUrl = Request.Url.Scheme + "://" + Request.Url.Authority;
            if (!string.IsNullOrWhiteSpace(JobDetailsPageId))
            {
                jobUrl += SitefinityHelper.GetPageUrl(JobDetailsPageId);

                if (job.ClassificationURL != null)
                {
                    jobUrl += "/" + job.ClassificationURL;
                }

                jobUrl += "/" + job.JobID;
            }

            dynamic templateData = new ExpandoObject();

            templateData.Job = new ExpandoObject();
            templateData.Job.Id = job.JobID;
            templateData.Job.Title = job.Title;
            templateData.Job.Url = jobUrl;

            var result = false;

            // if the email is not set then create one using current site's domain name
            var fromEmail = this.EmailFromEmail;
            if (string.IsNullOrEmpty(fromEmail))
            {
                fromEmail = "noreply@" + Request.Url.Host;
            }

            if (form.EmailFriend)
            {
                var from = new MailAddress(fromEmail, form.Name);

                var replyToCollection = new MailAddressCollection();
                replyToCollection.Add(new MailAddress(form.Email, form.Name));

                templateData.Sender = from;
                if( form.FriendMessage != null )
                {
                    templateData.Message = Regex.Replace(form.FriendMessage, "<.*?>", String.Empty).Replace("\n", "<br />");
                }
                

                foreach (var item in form.Friend)
                {
                    var emailRequest = new EmailRequest
                    {
                        To = new MailAddress(item.Email, item.Name),
                        ReplyTo = replyToCollection,
                        From = from,
                        Subject = subject,
                        EmailBody = content
                    };

                    templateData.Recipient = emailRequest.To;

                    if (emailSender.SendEmail(emailRequest, templateData))
                    {
                        result = true;
                    }
                }
            }
            else
            {
                // if the name is not set then use current site's name
                var fromName = this.EmailFromName;
                if (string.IsNullOrEmpty(fromName))
                {
                    fromName = new MultisiteContext().CurrentSite.Name;
                }

                var emailRequest = new EmailRequest
                {
                    To = new MailAddress(form.Email, form.Name),
                    From = new MailAddress(fromEmail, fromName),
                    Subject = subject,
                    EmailBody = content
                };

                templateData.Recipient = emailRequest.To;
                templateData.Sender = emailRequest.From;
                templateData.Message = string.Empty;

                result = emailSender.SendEmail(emailRequest, templateData);
            }

            return result;
        }

        private string _GetHtmlEmailContent()
        {
            string htmlEmailContent;

            if (string.IsNullOrEmpty(this.EmailTemplateId))
            {
                htmlEmailContent = _GetDefaultHtmlEmailContent();
            }
            else
            {
                var dynamicModuleManager = DynamicModuleManager.GetManager(_emailTemplateProvider);

                var emailTemplateType = TypeResolutionService.ResolveType(_itemType);

                var emailTemplateItem = dynamicModuleManager.GetDataItem(emailTemplateType, new Guid(this.EmailTemplateId.ToUpper()));

                if (emailTemplateItem == null)
                {
                    htmlEmailContent = _GetDefaultHtmlEmailContent();
                }
                else
                {
                    htmlEmailContent = emailTemplateItem.GetValue("htmlEmailContent").ToString();
                }
            }

            return htmlEmailContent;
        }

        private string _GetDefaultHtmlEmailContent()
        {
            return @"
                <p>Hi {Recipient.DisplayName},</p>

                <p>Have a look at this job:<br />
                Job: {Job.Title}<br />
                URL: {Job.Url}</p>

                <p>{Message}</p>

                <p>Cheers<br />
                {Sender.DisplayName}</p>
            ";
        }

        private int _GetMaxFriends()
        {
            return (this.MaxFriends > 0 && this.MaxFriends < 26) ? this.MaxFriends : 10;
        }

        private JobEmailViewModel _GetViewModel(string templateName, JobEmailFormModel form)
        {
            var model = new JobEmailViewModel();

            model.Sent = Request.QueryString.Get("Sent") == "1";

            // populate widget properties
            model.Widget = new JobEmailWidgetModel
            {
                JobLabel = string.IsNullOrEmpty(this.JobLabel) ? "Job Title" : this.JobLabel,
                JobHelp = this.JobHelp,

                NameLabel = string.IsNullOrEmpty(this.NameLabel) ? "Your Name" : this.NameLabel,
                NameHelp = this.NameHelp,

                EmailLabel = string.IsNullOrEmpty(this.EmailLabel) ? "Your Email" : this.EmailLabel,
                EmailHelp = this.EmailHelp,

                EmailFriendLabel = string.IsNullOrEmpty(this.EmailFriendLabel) ? "Click here to email this job to a friend" : this.EmailFriendLabel,
                EmailFriendHelp = this.EmailFriendHelp,

                FriendNameLabel = string.IsNullOrEmpty(this.FriendNameLabel) ? "Friend's Name" : this.FriendNameLabel,
                FriendNameHelp = this.EmailFriendHelp,

                FriendEmailLabel = string.IsNullOrEmpty(this.FriendEmailLabel) ? "Friend's Email" : this.FriendEmailLabel,
                FriendEmailHelp = this.EmailFriendHelp,

                FriendMessageLabel = string.IsNullOrEmpty(this.FriendMessageLabel) ? "Message For Your Friend" : this.FriendMessageLabel,
                FriendMessageHelp = this.FriendMessageHelp,

                AddFriendButtonLabel = string.IsNullOrEmpty(this.AddFriendButtonLabel) ? "Add" : this.AddFriendButtonLabel,
                RemoveFriendButtonLabel = string.IsNullOrEmpty(this.RemoveFriendButtonLabel) ? "<i class=\"fa fa-times\"></i>" : this.RemoveFriendButtonLabel,
                SubmitButtonLabel = string.IsNullOrEmpty(this.SubmitButtonLabel) ? "Send" : this.SubmitButtonLabel,

                MaxFriends = _GetMaxFriends(),

                JobNotFoundMessage = string.IsNullOrEmpty(this.JobNotFoundMessage) ? "The job you are looking for does not exist or has expired." : this.JobNotFoundMessage,
                EmailSentMessage = string.IsNullOrEmpty(this.EmailSentMessage) ? "Email has been sent successfully." : this.EmailSentMessage,
            };

            model.Form = form ?? new JobEmailFormModel();

            return model;
        }

        #endregion

        #region Overridden methods

        protected override void HandleUnknownAction(string actionName)
        {
            ActionInvoker.InvokeAction(ControllerContext, "Index");
        }

        #endregion
    }
}
