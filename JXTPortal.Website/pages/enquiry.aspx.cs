using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web .UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Net;
using System.Configuration;

namespace JXTPortal.Website.pages
{
    public partial class enquiry : System.Web.UI.Page
    {
        #region "Properties"

        private EnquiriesService _enquiryService = null;

        private EnquiriesService EnquiriesService
        {
            get
            {
                if (_enquiryService == null)
                {
                    _enquiryService = new EnquiriesService();
                }
                return _enquiryService;
            }
        }

        private DynamicPagesService _dynamicPagesService = null;
        private DynamicPagesService DynamicPagesService
        {
            get
            {
                if (_dynamicPagesService == null)
                {
                    _dynamicPagesService = new DynamicPagesService();
                }
                return _dynamicPagesService;
            }
        }


        private JXTPortal.Entities.Enquiries objEnquiry = null;

        #endregion

        #region Page Events

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Enquiry");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            revEnquiryEmailAddress.ValidationExpression = ConfigurationManager.AppSettings["EmailValidationRegex"];

            SetFormValues();
        }

        #endregion

        #region Methods

        public void SetFormValues()
        {
            rfvEnquiryName.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            rfvEmailAddress.ErrorMessage = CommonFunction.GetResourceValue("LabelValidEmailRequired");
            rfvEmailAddress.ErrorMessage = CommonFunction.GetResourceValue("LabelValidEmailRequired");
            rfvEnquiryContent.ErrorMessage = CommonFunction.GetResourceValue("ErrorEmptyContent");
            btnSubmit.Text = CommonFunction.GetResourceValue("ButtonSubmit");
        }

        #endregion

        #region Click Event handlers

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (JXTPortal.Entities.Enquiries objEnquiry = new JXTPortal.Entities.Enquiries())
            {
                objEnquiry.Name = txtName.Text;
                objEnquiry.Email = txtEmail.Text;
                objEnquiry.ContactPhone = txtPhone.Text;
                objEnquiry.Content = Server.HtmlEncode(txtContent.Text).Replace("\n", "<br />");
                objEnquiry.Date = DateTime.Now;
                objEnquiry.IpAddress = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] == null) ? 
                    HttpContext.Current.Request.UserHostAddress :HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                EnquiriesService.Insert(objEnquiry);
                MailService.SendEnquiryEmail(objEnquiry, SessionData.Site.DefaultEmailLanguageId);
                Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.ENQUIRY_SUBMIT_SUCCESS, "", "", ""));
            }

        }

        #endregion
    }
}
