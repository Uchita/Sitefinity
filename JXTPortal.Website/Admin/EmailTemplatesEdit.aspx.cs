using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Web.UI;
using JXTPortal.Website.ckeditor.Extensions;

namespace JXTPortal.Website.Admin
{
    public partial class EmailTemplatesEdit : System.Web.UI.Page
    {
        #region Declaration

        private EmailTemplatesService _emailTemplatesService;

        #endregion

        #region Properties

        public EmailTemplatesService EmailTemplatesService
        {
            get
            {
                if (_emailTemplatesService == null)
                {
                    _emailTemplatesService = new EmailTemplatesService();
                }
                return _emailTemplatesService;
            }
        }

        private int EmailTemplateID
        {
            get
            {
                int _emailTemplateID = 0;

                if (Request.QueryString["EmailTemplateID"] != null && Int32.TryParse(Request.QueryString["EmailTemplateID"], out _emailTemplateID))
                {
                    _emailTemplateID = Convert.ToInt32(Request.QueryString["EmailTemplateID"]);
                }

                return _emailTemplateID;
            }
        }

        private GlobalSettingsService _globalsettingsservice;
        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_globalsettingsservice == null)
                {
                    _globalsettingsservice = new GlobalSettingsService();
                }
                return _globalsettingsservice;
            }
        }

        private string FTPFolderLocation
        {
            get { return SessionData.Site.FileFolderLocation; }
        }

        #endregion

        #region Page
        /// <summary>
        /// Method to load data required by email templates
        /// </summary>
        /// 
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmailBodyHTML.SetConfigForFTPFolder(SessionData.Site.IsUsingS3);
        
            if (!Page.IsPostBack)
            {
                LoadEmailTemplate();
            }
        }
        #endregion

        protected void cvEmailAddressBCC_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(txtEmailAddressBCC.Text))
            {
                args.IsValid = Common.Utils.VerifyEmail(txtEmailAddressBCC.Text);
            }
        }

        protected void cvEmailAddressCC_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(txtEmailAddressCC.Text))
            {
                args.IsValid = Common.Utils.VerifyEmail(txtEmailAddressCC.Text);
            }
        }

        protected void cvEmailAddressTo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(tbEmailTo.Text))
            {
                args.IsValid = Common.Utils.VerifyEmail(tbEmailTo.Text);
            }
        }

        protected void cvEmailAddressFrom_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(txtEmailAddressFrom.Text))
            {
                args.IsValid = Common.Utils.VerifyEmail(txtEmailAddressFrom.Text);
            }
        }

        #region Click Events

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                JXTPortal.Entities.EmailTemplates emailTemplate;
                if (EmailTemplateID > 0)
                {
                    emailTemplate = EmailTemplatesService.GetByEmailTemplateId(EmailTemplateID);
                }
                else
                {
                    emailTemplate = new JXTPortal.Entities.EmailTemplates();
                }

                emailTemplate.EmailTemplateId = EmailTemplateID;
                emailTemplate.EmailTemplateParentId = 0;
                emailTemplate.EmailCode = txtEmailCode.Text;
                emailTemplate.EmailDescription = txtEmailDescription.Text;
                emailTemplate.EmailSubject = txtEmailSubject.Text;
                emailTemplate.EmailBodyText = txtEmailBodyText.Text;
                emailTemplate.EmailBodyHtml = txtEmailBodyHTML.Text;
                emailTemplate.EmailFields = txtEmailFields.Text;
                emailTemplate.EmailAddressName = txtEmailAddressName.Text;
                emailTemplate.EmailAddressFrom = txtEmailAddressFrom.Text;
                emailTemplate.EmailAddressCc = txtEmailAddressCC.Text;
                emailTemplate.EmailAddressBcc = txtEmailAddressBCC.Text;
                emailTemplate.GlobalTemplate = rbGlobalTemplate.Checked;

                if (EmailTemplateID > 0)
                {
                    EmailTemplatesService.Update(emailTemplate);
                }
                else
                {
                    EmailTemplatesService.Insert(emailTemplate);
                }

                Response.Redirect("emailtemplates.aspx");
            }

        }

        #endregion

        #region Methods

        private void LoadEmailTemplate()
        {
            if (EmailTemplateID > 0)
            {
                using (JXTPortal.Entities.EmailTemplates emailTemplate = EmailTemplatesService.GetByEmailTemplateId(EmailTemplateID))
                {
                    phEmailTo.Visible = (emailTemplate.EmailAddressToMandatory.HasValue) ? emailTemplate.EmailAddressToMandatory.Value : false;

                    if (emailTemplate != null)
                    {
                        if (emailTemplate.SiteId == SessionData.Site.SiteId)
                        {
                            //load
                            txtEmailCode.Text = emailTemplate.EmailCode;
                            txtEmailDescription.Text = emailTemplate.EmailDescription;
                            txtEmailSubject.Text = emailTemplate.EmailSubject;
                            txtEmailBodyText.Text = emailTemplate.EmailBodyText;
                            txtEmailBodyHTML.Text = emailTemplate.EmailBodyHtml;
                            txtEmailFields.Text = emailTemplate.EmailFields;
                            txtEmailAddressName.Text = emailTemplate.EmailAddressName;
                            txtEmailAddressFrom.Text = emailTemplate.EmailAddressFrom;
                            txtEmailAddressCC.Text = emailTemplate.EmailAddressCc;
                            txtEmailAddressBCC.Text = emailTemplate.EmailAddressBcc;
                            rbGlobalTemplate.Checked = emailTemplate.GlobalTemplate;
                            lblLastModified.Text = emailTemplate.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");

                            AdminUsersService aus = new AdminUsersService();
                            using (Entities.AdminUsers adminuser = aus.GetByAdminUserId(emailTemplate.LastModifiedBy))
                            {
                                lblLastModifiedBy.Text = adminuser.UserName;
                            }
                        }
                        else
                        {
                            Response.Redirect("emailtemplatesedit.aspx");
                        }
                    }
                    else
                        Response.Redirect("emailtemplatesedit.aspx");
                }
            }

        }

        #endregion

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("emailtemplates.aspx");
        }

        protected void cvEmailCode_ServerValidate(object source, ServerValidateEventArgs args)
        {
            TList<Entities.EmailTemplates> emailtemplates = EmailTemplatesService.GetBySiteId(SessionData.Site.SiteId);
            emailtemplates.Filter = string.Format("EmailCode = {0} AND GlobalTemplate = {1} AND EmailTemplateID <> {2}", txtEmailCode.Text, rbGlobalTemplate.Checked, EmailTemplateID);

            args.IsValid = (emailtemplates.Count == 0);
        }
    }
}
