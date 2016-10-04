using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SocialMedia.Client.AICD;
using System.Configuration;

namespace JXTPortal.Website.member.aicd
{
    public partial class login : System.Web.UI.Page
    {

        AICDSingleSignOn aicdSingleSignOn = null; 

        public string code
        {
            get { return Request.Params["code"]; }
        }

        public string logoff
        {
            get { return Request.Params["logoff"]; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            aicdSingleSignOn = new AICDSingleSignOn(bool.Parse(ConfigurationManager.AppSettings["IsPlatformLive"]), JXTPortal.Entities.SessionData.Site);

            if (!string.IsNullOrWhiteSpace(logoff))
                Logoff();

            // If the code doesnt exists it goes to the AICD login page
            if (string.IsNullOrWhiteSpace(code))
                Response.Redirect(aicdSingleSignOn.GetAuthorizeUrl());


            // If cookie exists then get the token and save the member
            // else get the authorize code
            /*if (!string.IsNullOrWhiteSpace(aicdSingleSignOn.CheckCookie()))
                Response.Redirect(aicdSingleSignOn.GetTokenUrl(code));
            else
                Authorize();*/

            string strResult = string.Empty;
            string strReturnURL = string.Empty;
            // Get Token and save the member if valid
            bool blnResult = aicdSingleSignOn.GetTokenUrlAndSaveMember(code, ref strResult, ref strReturnURL);

            // When they is an error
            if (!blnResult)
                Response.Redirect("/member/login.aspx?error=" + strResult);

            //Response.Write(blnResult);
            //Response.Write(strResult);
            //Response.End();

            // Redirect
            if (!string.IsNullOrWhiteSpace(strReturnURL))
            {
                Response.Redirect(strReturnURL);
                return;
            }

            // After saving member and login - redirect to default page.
            Response.Redirect("/member/default.aspx");

        }

        private void Logoff()
        {
            SessionService.RemoveMemberAndAdvertiser();

            Response.Redirect(aicdSingleSignOn.LogoffURI);
        }

    }
}