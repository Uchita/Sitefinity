using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using JXTPortal.Entities;
using JXTPortal;
using JXTPortal.Web.UI;


namespace JXTPortal.Website.Admin
{
    public partial class SiteEmailTemplates : System.Web.UI.Page
    {
        #region Declarations
        private EmailTemplatesService _emailtemplatesservice;
        #endregion

        #region Properties

        public int CurrentPage
        {

            get
            {
                if (this.ViewState["CurrentPage"] == null)
                    return 0;
                else
                    return Convert.ToInt16(this.ViewState["CurrentPage"].ToString());
            }

            set
            {
                this.ViewState["CurrentPage"] = value;
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

        #endregion

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadSiteEmailTemplates();
            }
        }
        #endregion

        #region Events

        protected void rptSiteEmailTemplates_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Overwrite")
            {
                Response.Redirect("siteemailtemplatesedit.aspx?ParentEmailTemplateID=" + e.CommandArgument);
            }
        }

        protected void rptSiteEmailTemplates_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal litEmailCode = e.Item.FindControl("litEmailCode") as Literal;
                Literal litEmailSubject = e.Item.FindControl("litEmailSubject") as Literal;
                Literal litEmailDescription = e.Item.FindControl("litEmailDescription") as Literal;
                HiddenField hfEmailTemplateID = e.Item.FindControl("hfEmailTemplateID") as HiddenField;

                Entities.EmailTemplates et = e.Item.DataItem as Entities.EmailTemplates;
                litEmailCode.Text = et.EmailCode;
                litEmailSubject.Text = et.EmailSubject;
                litEmailDescription.Text = et.EmailDescription;
                hfEmailTemplateID.Value = et.EmailTemplateId.ToString();
            }
        }

        protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                CurrentPage = Convert.ToInt32(e.CommandArgument);
                LoadSiteEmailTemplates();
            }
        }

        protected void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbPageNo = e.Item.FindControl("lbPageNo") as LinkButton;
                lbPageNo.CommandArgument = e.Item.DataItem.ToString();
                lbPageNo.Text = (Convert.ToInt32(e.Item.DataItem) + 1).ToString();

                if (lbPageNo.CommandArgument == CurrentPage.ToString())
                {
                    lbPageNo.Enabled = false;
                    lbPageNo.Font.Underline = false;
                    lbPageNo.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        protected void btnBulkUpdate_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                foreach (RepeaterItem ri in rptSiteEmailTemplates.Items)
                {
                    if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                    {
                        CheckBox chkSelect = ri.FindControl("chkSelect") as CheckBox;
                        HiddenField hfEmailTemplateID = ri.FindControl("hfEmailTemplateID") as HiddenField;

                        if (chkSelect.Checked)
                        {
                            using (TList<JXTPortal.Entities.EmailTemplates> emailTemplates = EmailTemplatesService.GetBySiteId(SessionData.Site.SiteId))
                            {
                                emailTemplates.Filter = "EmailTemplateParentID = " + hfEmailTemplateID.Value;
                                if (emailTemplates.Count > 0)
                                {
                                    JXTPortal.Entities.EmailTemplates emailTemplate = emailTemplates[0];
                                    emailTemplate.EmailAddressName = tbBulkEmailName.Text;
                                    emailTemplate.EmailAddressFrom = tbBulkEmail.Text;
                                    EmailTemplatesService.Update(emailTemplate);
                                }
                                else
                                {
                                    try
                                    {
                                        using (Entities.EmailTemplates template = EmailTemplatesService.GetByEmailTemplateId(Convert.ToInt32(hfEmailTemplateID.Value)))
                                        {
                                            if (!template.GlobalTemplate)
                                            {
                                                lblErrorMsg.Text = "Error Occured";
                                                return;
                                            }
                                        }
                                    }
                                    catch
                                    {
                                        lblErrorMsg.Text = "Error Occured";
                                        return;
                                    }

                                    JXTPortal.Entities.EmailTemplates emailTemplate = EmailTemplatesService.GetByEmailTemplateId(Convert.ToInt32(hfEmailTemplateID.Value));
                                    emailTemplate.SiteId = SessionData.Site.SiteId;
                                    emailTemplate.EmailAddressName = tbBulkEmailName.Text;
                                    emailTemplate.EmailAddressFrom = tbBulkEmail.Text;
                                    emailTemplate.EmailTemplateParentId = Convert.ToInt32(hfEmailTemplateID.Value);
                                    emailTemplate.GlobalTemplate = false;

                                    EmailTemplatesService.Insert(emailTemplate);
                                }
                            }
                        }
                    }
                }

                lblErrorMsg.Text = "Email Tempalte bulk update completed";
            }
        }

        protected void cvBulkEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = CommonFunction.VerifyEmail(tbBulkEmail.Text);
            cvBulkEmail.ErrorMessage = "Invalid Email Address";
        }

        #endregion

        #region Method

        private void LoadSiteEmailTemplates()
        {
            int totalCount = 0;
            int pageCount = 0;
            int sitePageCount = JXTPortal.Common.Utils.GetAppSettingsInt("SitePaging");

            using (TList<Entities.EmailTemplates> ets = EmailTemplatesService.GetPaged("SiteID = 1 AND GlobalTemplate = 1", "", CurrentPage, Int32.MaxValue, out totalCount))
            {
                if (totalCount > 0)
                {
                    rptPage.Visible = false;

                    rptSiteEmailTemplates.DataSource = ets;
                    rptSiteEmailTemplates.DataBind();
                }
                else
                {
                    rptSiteEmailTemplates.DataSource = ets;
                    rptSiteEmailTemplates.DataBind();
                    rptPage.DataSource = null;
                    rptPage.DataBind();
                }
            }
        }

        #endregion
    }
}
