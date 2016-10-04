using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.Admin.UserControls
{
    public partial class EmailTemplatesFields : System.Web.UI.UserControl
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

        #endregion

        #region Page
        /// <summary>
        /// Method to load data required by email templates
        /// </summary>
        /// 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateList();
                LoadEmailTemplate();
            }
        }
        #endregion

        #region Click Events

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (JXTPortal.Entities.EmailTemplates emailTemplate = new JXTPortal.Entities.EmailTemplates())
                {
                    emailTemplate.EmailTemplateId = EmailTemplateID;
                    emailTemplate.EmailTemplateParentId = Convert.ToInt32(ddlParentEmailTemplate.SelectedValue);
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
        }

        #endregion

        #region Methods

        private void PopulateList()
        {
            ddlParentEmailTemplate.AppendDataBoundItems = true;
            ddlParentEmailTemplate.Items.Add(new ListItem("-No Parent-", "0"));
            ddlParentEmailTemplate.DataSource = EmailTemplatesService.GetAll();
            ddlParentEmailTemplate.DataTextField = "EmailSubject";
            ddlParentEmailTemplate.DataValueField = "EmailTemplateID";
            ddlParentEmailTemplate.DataBind();
        }

        private void LoadEmailTemplate()
        {
            if (EmailTemplateID > 0)
            {
                using (JXTPortal.Entities.EmailTemplates emailTemplate = EmailTemplatesService.GetByEmailTemplateId(EmailTemplateID))
                {
                    if (emailTemplate.SiteId == SessionData.Site.SiteId)
                    {
                        //load
                        ddlParentEmailTemplate.SelectedValue = emailTemplate.EmailTemplateParentId.ToString();
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
                        //throw exception
                    }
                }
            }

        }

        #endregion
    }
}