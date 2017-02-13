using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using JXTPortal;
using JXTPortal.Entities;

namespace JXTPortal.Website.Admin
{
    public partial class SiteEmailTemplatesEdit : System.Web.UI.Page
    {
        #region Declarations

        private int _parentemailtemplateid = 0;
        private EmailTemplatesService _emailtemplatesservice;
        private SiteLanguagesService _sitelanguagesservice;
        private AdminUsersService _adminusersservice;

        #endregion

        #region Properties

        private int ParentEmailTemplateID
        {
            get
            {
                if ((Request.QueryString["ParentEmailTemplateID"] != null))
                {
                    if (int.TryParse((Request.QueryString["ParentEmailTemplateID"].Trim()), out _parentemailtemplateid))
                    {
                        _parentemailtemplateid = Convert.ToInt32(Request.QueryString["ParentEmailTemplateID"]);
                    }
                    return _parentemailtemplateid;
                }

                return _parentemailtemplateid;
            }
        }

        private EmailTemplatesService EmailTemplatesService
        {
            get
            {
                if (_emailtemplatesservice == null)
                {
                    _emailtemplatesservice = new EmailTemplatesService();
                }
                return _emailtemplatesservice;
            }
        }

        private SiteLanguagesService SiteLanguagesService
        {
            get
            {
                if (_sitelanguagesservice == null)
                {
                    _sitelanguagesservice = new SiteLanguagesService();
                }
                return _sitelanguagesservice;
            }
        }


        private int SiteEmailTemplateID
        {
            get
            {
                TList<JXTPortal.Entities.EmailTemplates> emailtemplates = EmailTemplatesService.Find(string.Format("SiteID={0} AND EmailTemplateParentID={1} AND LanguageID={2}", SessionData.Site.SiteId, ParentEmailTemplateID, ddlSelectLanguage.SelectedValue));

                if (emailtemplates.Count > 0)
                    return emailtemplates[0].EmailTemplateId;
                else
                    return 0;
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
            get { return GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId)[0].FtpFolderLocation; }
        }
        #endregion

        #region Page

        protected void Page_Load(object sender, EventArgs e)
        {
            if (FTPFolderLocation.StartsWith("s3://"))
            {
                dataNewEmailBodyHTML.CustomConfig = "s3custom_config.js";
            }

            if (!Page.IsPostBack)
            {
                if (ParentEmailTemplateID > 0)
                {
                    LoadLanguages();
                    LoadDefaultEmailTemplate();
                    LoadSiteEmailTempalte();
                }
                else
                {
                    Response.Redirect("siteemailtemplates.aspx");
                }
            }

            btnUseDefault.Attributes.Add("onclick", "return confirm('Are you sure you wish to discard your changes?');");
        }

        protected void cvEmailAddressBCC_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(dataNewEmailAddressBCC.Text))
            {
                args.IsValid = Common.Utils.VerifyEmail(dataNewEmailAddressBCC.Text);
            }
        }

        protected void cvEmailAddressCC_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(dataNewEmailAddressCC.Text))
            {
                args.IsValid = Common.Utils.VerifyEmail(dataNewEmailAddressCC.Text);
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
            if (!string.IsNullOrEmpty(dataNewEmailAddressFrom.Text))
            {
                args.IsValid = Common.Utils.VerifyEmail(dataNewEmailAddressFrom.Text);
            }
        }

        #endregion


        #region Methods
        private void LoadLanguages()
        {
            using (TList<SiteLanguages> sitelangs = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId))
            {
                if (sitelangs.Count > 1)
                {
                    phLanguage.Visible = true;
                    phUpdateVersion.Visible = true;
                    phMultiLingual.Visible = true;

                    foreach (SiteLanguages sitelang in sitelangs)
                    {
                        ddlSelectLanguage.Items.Add(new ListItem(sitelang.SiteLanguageName, sitelang.LanguageId.ToString()));

                    }

                    foreach (ListItem item in ddlSelectLanguage.Items)
                    {
                        if (item.Value == SessionData.Site.DefaultLanguageId.ToString())
                        {
                            item.Selected = true;
                        }
                    }

                    LoadCurrentVersions();
                }
                else
                {
                    foreach (SiteLanguages sitelang in sitelangs)
                    {
                        ddlSelectLanguage.Items.Add(new ListItem(sitelang.SiteLanguageName, sitelang.LanguageId.ToString()));

                    }

                    foreach (ListItem item in ddlSelectLanguage.Items)
                    {
                        if (item.Value == SessionData.Site.DefaultLanguageId.ToString())
                        {
                            item.Selected = true;
                        }
                    }
                }
            }
        }

        private void LoadCurrentVersions()
        {
            rptCurrentVersion.DataSource = null;

            using (TList<JXTPortal.Entities.EmailTemplates> emailTemplates = EmailTemplatesService.GetBySiteId(SessionData.Site.SiteId))
            {
                emailTemplates.Filter = "EmailTemplateParentID = " + ParentEmailTemplateID.ToString() + " AND LanguageID <> " + SessionData.Site.DefaultLanguageId.ToString();

                if (emailTemplates.Count > 0)
                {
                    phCurrentVersion.Visible = true;

                    rptCurrentVersion.DataSource = emailTemplates;

                }
                else
                {
                    phCurrentVersion.Visible = false;
                }
                rptCurrentVersion.DataBind();

            }
        }

        private void SaveEmailTemplate()
        {
            using (JXTPortal.Entities.EmailTemplates emailtemplate = new JXTPortal.Entities.EmailTemplates())
            {
                emailtemplate.EmailTemplateId = SiteEmailTemplateID;
                emailtemplate.SiteId = SessionData.Site.SiteId;

                emailtemplate.EmailTemplateParentId = ParentEmailTemplateID;
                emailtemplate.EmailCode = lbDefaultEmailCode.Text;
                emailtemplate.EmailDescription = dataNewEmailDescription.Text;
                emailtemplate.EmailSubject = dataNewEmailSubject.Text;
                emailtemplate.EmailFields = EmailTemplatesService.GetByEmailTemplateId(ParentEmailTemplateID).EmailFields;
                emailtemplate.EmailBodyText = dataNewEmailBodyText.Text;
                emailtemplate.EmailBodyHtml = dataNewEmailBodyHTML.Text;
                emailtemplate.EmailAddressName = dataNewEmailAddressName.Text;
                emailtemplate.EmailAddressFrom = dataNewEmailAddressFrom.Text;
                emailtemplate.EmailAddressTo = tbEmailTo.Text;
                emailtemplate.EmailAddressToName = tbEmailAddressToName.Text;
                emailtemplate.EmailAddressCc = dataNewEmailAddressCC.Text;
                emailtemplate.EmailAddressBcc = dataNewEmailAddressBCC.Text;
                emailtemplate.GlobalTemplate = false;
                emailtemplate.LanguageId = Convert.ToInt32(ddlSelectLanguage.SelectedValue);

                if (SiteEmailTemplateID > 0)
                    EmailTemplatesService.Update(emailtemplate);
                else
                    EmailTemplatesService.Insert(emailtemplate);
            }

            LoadCurrentVersions();

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "TemplateSaved", "function fade_out() { $(\".msg.done\").fadeOut().empty();}\n$('#divEmailSubject').before('<div class=\"form-elements-group\"><div class=\"form-element-holder\"><p class=\"msg done\">Your version has been successfully updated</p></div></div></div>');\n setTimeout(fade_out, 3000);", true);
        }

        protected void lbUpdateVersion_Click(object sender, EventArgs e)
        {
            SaveEmailTemplate();
        }

        protected void ddlSelectLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (TList<JXTPortal.Entities.EmailTemplates> emailTemplates = EmailTemplatesService.GetBySiteId(SessionData.Site.SiteId))
            {
                emailTemplates.Filter = "EmailTemplateParentID = " + ParentEmailTemplateID.ToString() + " AND LanguageID = " + ddlSelectLanguage.SelectedValue.ToString();

                btnUseDefault.Visible = (emailTemplates.Count > 0);

                if (emailTemplates.Count > 0)
                {
                    JXTPortal.Entities.EmailTemplates emailTemplate = emailTemplates[0];

                    lbCurrentLastModified.Text = emailTemplate.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                    AdminUsersService aus = new AdminUsersService();
                    using (JXTPortal.Entities.AdminUsers adminuser = aus.GetByAdminUserId(emailTemplate.LastModifiedBy))
                    {
                        lbCurrentModifiedBy.Text = adminuser.UserName;
                    }

                    dataNewEmailSubject.Text = emailTemplate.EmailSubject;
                    dataNewEmailDescription.Text = emailTemplate.EmailDescription;
                    dataNewEmailBodyText.Text = emailTemplate.EmailBodyText;
                    dataNewEmailBodyHTML.Text = emailTemplate.EmailBodyHtml;
                    dataNewEmailAddressName.Text = emailTemplate.EmailAddressName;
                    dataNewEmailAddressFrom.Text = emailTemplate.EmailAddressFrom;
                    tbEmailTo.Text = emailTemplate.EmailAddressTo;
                    tbEmailAddressToName.Text = emailTemplate.EmailAddressToName;
                    dataNewEmailAddressCC.Text = emailTemplate.EmailAddressCc;
                    dataNewEmailAddressBCC.Text = emailTemplate.EmailAddressBcc;
                    lbUpdateVersion.Text = "Update Version";

                }
                else
                {
                    using (JXTPortal.Entities.EmailTemplates emailTemplate = EmailTemplatesService.GetByEmailTemplateId(ParentEmailTemplateID))
                    {

                        lbCurrentLastModified.Text = emailTemplate.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                        AdminUsersService aus = new AdminUsersService();
                        using (JXTPortal.Entities.AdminUsers adminuser = aus.GetByAdminUserId(emailTemplate.LastModifiedBy))
                        {
                            lbCurrentModifiedBy.Text = adminuser.UserName;
                        }

                        dataNewEmailSubject.Text = emailTemplate.EmailSubject;
                        dataNewEmailDescription.Text = emailTemplate.EmailDescription;
                        dataNewEmailBodyText.Text = emailTemplate.EmailBodyText;
                        dataNewEmailBodyHTML.Text = emailTemplate.EmailBodyHtml;
                        dataNewEmailAddressName.Text = emailTemplate.EmailAddressName;
                        dataNewEmailAddressFrom.Text = emailTemplate.EmailAddressFrom;
                        tbEmailTo.Text = emailTemplate.EmailAddressTo;
                        tbEmailAddressToName.Text = emailTemplate.EmailAddressToName;
                        dataNewEmailAddressCC.Text = emailTemplate.EmailAddressCc;
                        dataNewEmailAddressBCC.Text = emailTemplate.EmailAddressBcc;

                        lbUpdateVersion.Text = "Create Version";
                    }
                }
            }
        }

        private void LoadDefaultEmailTemplate()
        {
            using (JXTPortal.Entities.EmailTemplates emailTemplate = EmailTemplatesService.GetByEmailTemplateId(ParentEmailTemplateID))
            {
                if (emailTemplate != null)
                {
                    if (!emailTemplate.GlobalTemplate && emailTemplate.SiteId != SessionData.Site.SiteId)
                    {
                        Response.Redirect("siteemailtemplates.aspx");
                    }

                    // Email To Place holder when the email template's Email Address To Mandatory is true
                    phEmailTo.Visible = (emailTemplate.EmailAddressToMandatory.HasValue) ? emailTemplate.EmailAddressToMandatory.Value : false;
                    phDefaultTo.Visible = (emailTemplate.EmailAddressToMandatory.HasValue) ? emailTemplate.EmailAddressToMandatory.Value : false;
                    lbDefaultEmailCode.Text = emailTemplate.EmailCode;
                    lbDefaultEmailSubject.Text = emailTemplate.EmailSubject;
                    lbDefaultEmailDescription.Text = emailTemplate.EmailDescription;
                    //lbDefaultEmailBodyText.Text = emailTemplate.EmailBodyText.Replace("\n", "<br />");
                    lbDefaultEmailBodyHTML.Text = emailTemplate.EmailBodyHtml;
                    lbDefaultEmailFields.Text = emailTemplate.EmailFields.Replace("\n", "<br />");
                    lbDefaultEmailAddressName.Text = emailTemplate.EmailAddressName;
                    lbDefaultEmailAddressFrom.Text = emailTemplate.EmailAddressFrom;
                    lbDefaultEmailAddressToName.Text = emailTemplate.EmailAddressToName;
                    lbDefaultEmailAddressTo.Text = emailTemplate.EmailAddressTo;
                    lbDefaultEmailAddressCC.Text = emailTemplate.EmailAddressCc;
                    lbDefaultEmailAddressBCC.Text = emailTemplate.EmailAddressBcc;

                    ltDefaultEmailBodyText.Text = emailTemplate.EmailBodyText.Replace("\n", "<br />");

                    StringBuilder sb = new StringBuilder();

                    foreach (string field in emailTemplate.EmailFields.Split(new char[] { '\n' }))
                    {
                        sb.Append(field);
                        sb.Append(" ");
                    }

                    //ltNewEmailSubject.Text = sb.ToString();
                    ltNewEmailField.Text = sb.ToString();
                    //ltNewEmailFieldsHTML.Text = sb.ToString();

                    //foreach (string field in emailTemplate.EmailFields.Split(new char[] { '\n' }))
                    //{
                    //    dataNewEmailFieldsSubject.Items.Add(new ListItem(field));
                    //    dataNewEmailFieldsText.Items.Add(new ListItem(field));
                    //    dataNewEmailFieldsHTML.Items.Add(new ListItem(field));
                    //}
                }
                else
                {
                    Response.Redirect("siteemailtemplates.aspx");
                }
            }
        }

        private void LoadSiteEmailTempalte()
        {
            using (TList<JXTPortal.Entities.EmailTemplates> emailTemplates = EmailTemplatesService.GetBySiteId(SessionData.Site.SiteId))
            {
                emailTemplates.Filter = "EmailTemplateParentID = " + ParentEmailTemplateID.ToString() + " AND LanguageID = " + ddlSelectLanguage.SelectedValue.ToString();
                btnUseDefault.Visible = (emailTemplates.Count > 0);
                if (emailTemplates.Count > 0)
                {
                    if (emailTemplates[0].SiteId != SessionData.Site.SiteId)
                    {
                        Response.Redirect("siteemailtemplates.aspx");
                    }

                    JXTPortal.Entities.EmailTemplates emailTemplate = null;
                    foreach (JXTPortal.Entities.EmailTemplates et in emailTemplates)
                    {
                        if (et.SiteId == SessionData.Site.SiteId && (et.LanguageId.HasValue && et.LanguageId.Value == SessionData.Site.DefaultLanguageId))
                        {
                            emailTemplate = et;
                            break;
                        }
                    }

                    if (emailTemplate == null)
                    {
                        emailTemplate = emailTemplates[0];
                    }

                    lbCurrentLastModified.Text = emailTemplate.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                    AdminUsersService aus = new AdminUsersService();
                    using (JXTPortal.Entities.AdminUsers adminuser = aus.GetByAdminUserId(emailTemplate.LastModifiedBy))
                    {
                        lbCurrentModifiedBy.Text = adminuser.UserName;
                    }

                    dataNewEmailSubject.Text = emailTemplate.EmailSubject;
                    dataNewEmailDescription.Text = emailTemplate.EmailDescription;
                    dataNewEmailBodyText.Text = emailTemplate.EmailBodyText;
                    dataNewEmailBodyHTML.Text = emailTemplate.EmailBodyHtml;
                    dataNewEmailAddressName.Text = emailTemplate.EmailAddressName;
                    dataNewEmailAddressFrom.Text = emailTemplate.EmailAddressFrom;
                    tbEmailTo.Text = emailTemplate.EmailAddressTo;
                    tbEmailAddressToName.Text = emailTemplate.EmailAddressToName;
                    dataNewEmailAddressCC.Text = emailTemplate.EmailAddressCc;
                    dataNewEmailAddressBCC.Text = emailTemplate.EmailAddressBcc;

                    lbUpdateVersion.Text = "Update Version";
                }
                else
                {
                    // Not allocated yet
                    using (JXTPortal.Entities.EmailTemplates emailTemplate = EmailTemplatesService.GetByEmailTemplateId(ParentEmailTemplateID))
                    {

                        lbCurrentLastModified.Text = emailTemplate.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                        AdminUsersService aus = new AdminUsersService();
                        using (JXTPortal.Entities.AdminUsers adminuser = aus.GetByAdminUserId(emailTemplate.LastModifiedBy))
                        {
                            lbCurrentModifiedBy.Text = adminuser.UserName;
                        }

                        dataNewEmailSubject.Text = emailTemplate.EmailSubject;
                        dataNewEmailDescription.Text = emailTemplate.EmailDescription;
                        dataNewEmailBodyText.Text = emailTemplate.EmailBodyText;
                        dataNewEmailBodyHTML.Text = emailTemplate.EmailBodyHtml;
                        dataNewEmailAddressName.Text = emailTemplate.EmailAddressName;
                        dataNewEmailAddressFrom.Text = emailTemplate.EmailAddressFrom;
                        tbEmailTo.Text = emailTemplate.EmailAddressTo;
                        tbEmailAddressToName.Text = emailTemplate.EmailAddressToName;
                        dataNewEmailAddressCC.Text = emailTemplate.EmailAddressCc;
                        dataNewEmailAddressBCC.Text = emailTemplate.EmailAddressBcc;

                        lbUpdateVersion.Text = "Create Version";
                    }
                }

            }
        }

        protected void rptCurrentVersion_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltLanguage = e.Item.FindControl("ltLanguage") as Literal;
                Literal ltAuthor = e.Item.FindControl("ltAuthor") as Literal;
                Literal ltLastModified = e.Item.FindControl("ltLastModified") as Literal;
                LinkButton lbEdit = e.Item.FindControl("lbEdit") as LinkButton;
                LinkButton lbDelete = e.Item.FindControl("lbDelete") as LinkButton;

                JXTPortal.Entities.EmailTemplates emailtemplate = e.Item.DataItem as JXTPortal.Entities.EmailTemplates;

                using (TList<SiteLanguages> sitelanguages = SiteLanguagesService.GetBySiteIdLanguageId(SessionData.Site.SiteId, emailtemplate.LanguageId))
                {
                    if (sitelanguages.Count > 0)
                    {
                        ltLanguage.Text = sitelanguages[0].SiteLanguageName;
                    }
                }

                AdminUsersService aus = new AdminUsersService();
                using (JXTPortal.Entities.AdminUsers adminuser = aus.GetByAdminUserId(emailtemplate.LastModifiedBy))
                {
                    ltAuthor.Text = adminuser.UserName;
                }

                ltLastModified.Text = emailtemplate.LastModified.ToString();
                lbEdit.CommandArgument = emailtemplate.LanguageId.ToString();
                lbDelete.CommandArgument = emailtemplate.EmailTemplateId.ToString();
            }
        }

        protected void rptCurrentVersion_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                ddlSelectLanguage.SelectedValue = e.CommandArgument.ToString();
                LoadSiteEmailTempalte();
            }

            if (e.CommandName == "Delete")
            {
                JXTPortal.Entities.EmailTemplates emailtemplate = EmailTemplatesService.GetByEmailTemplateId(Convert.ToInt32(e.CommandArgument));
                if (emailtemplate != null)
                {
                    if (EmailTemplatesService.Delete(emailtemplate))
                    {
                        //ltlMessage.Text = "You are now using the default email template";
                        LoadSiteEmailTempalte();
                        LoadCurrentVersions();
                    }
                }
            }
        }

        #endregion

        #region Events

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("siteemailtemplates.aspx");
        }

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                SaveEmailTemplate();

                Response.Redirect("siteemailtemplates.aspx");
            }
        }

        protected void btnUseDefault_Click(object sender, EventArgs e)
        {
            if (SiteEmailTemplateID > 0)
            {
                JXTPortal.Entities.EmailTemplates emailtemplate = EmailTemplatesService.GetByEmailTemplateId(SiteEmailTemplateID);
                if (emailtemplate != null)
                {
                    EmailTemplatesService.Delete(emailtemplate);
                    //ltlMessage.Text = "You are now using the default email template";
                    LoadSiteEmailTempalte();
                }
            }
        }

        #endregion

    }
}
