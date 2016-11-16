using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Data;
using System.Configuration;

namespace JXTPortal.Website.advertiser
{
    public partial class ResendEmailValidation : System.Web.UI.Page
    {
        private AdvertiserUsersService _advertiserusersService = null;
        private AdvertiserUsersService AdvertiserUsersService
        {
            get
            {
                if (_advertiserusersService == null)
                {
                    _advertiserusersService = new AdvertiserUsersService();
                }
                return _advertiserusersService;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            // Is SSL.
            // CommonPage.IsSSL();

            // CommonPage.SetBrowserPageTitle(Page, "Resend Email Validation");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            revEmailAddress.ValidationExpression = ConfigurationManager.AppSettings["EmailValidationRegex"];
        }


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string emailAddress = tbEmailAddress.Text;

            int thisAdvUserID = 0;

            using (DataSet thisUserDS = AdvertiserUsersService.AdminGetPaged(SessionData.Site.SiteId, null, null, null, null, null, emailAddress, 1, 1))
            {
                if (thisUserDS.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = thisUserDS.Tables[0].Rows[0];

                    thisAdvUserID = int.Parse(dr["AdvertiserUserID"].ToString());
                }
            }

            if (thisAdvUserID != 0)
            {
                using (Entities.AdvertiserUsers thisUser = AdvertiserUsersService.GetByAdvertiserUserId(thisAdvUserID))
                {
                    //User has not been validated
                    if (thisUser.Validated == null || !thisUser.Validated.Value)
                    {
                        // Send Advertiser registration email.
                        MailService.SendAdvertiserRegistration(thisUser);

                        ltlMessage.Text = "Validation email has been sent to " + emailAddress;
                    }
                    else
                    {
                        ltlMessage.Text = "Email address already validated";
                    }
                }
            }
            else
            {
                ltlMessage.Text = "Email address could not be found";
            }

        }


    }
}