using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using JXTPortal.Common;

namespace JXTPortal.Website.Admin
{
    public partial class SendTestEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ltlMessage.Text = string.Empty;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                MailService.SendTestEmail(tbEmailAddress.Text, tbSubject.Text, tbBody.Text, tbBounceBackEmail.Text, cbHTML.Checked);
                ltlMessage.Text = "Email has been sent successfully.";
                ClearForm();
            }
        }

        protected void CusVal_EmailAddress_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = CommonFunction.VerifyEmail(tbEmailAddress.Text);
        }
        
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = CommonFunction.VerifyEmail(tbBounceBackEmail.Text);
        }


        private void ClearForm()
        {
            tbEmailAddress.Text = string.Empty;
            tbSubject.Text = string.Empty;
            tbBody.Text = string.Empty;
            cbHTML.Checked = true;
            tbBounceBackEmail.Text = string.Empty;
        }
    }
}
