using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Configuration;

namespace JXTPortal.Website
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            bool isMemberLoggedIn = false;

            if (SessionData.Member != null)
            {
                isMemberLoggedIn = true;
            }
            SessionService.RemoveMemberAndAdvertiser();

            SessionService.SessionAbandon();

            // Monash Member Sign out.
            if (isMemberLoggedIn)
            {
                SocialMedia.Client.Monash.MonashSamlSSO.AuthnRequest.Logout();                
            }

            Response.Redirect("~/");
        }
    }
}