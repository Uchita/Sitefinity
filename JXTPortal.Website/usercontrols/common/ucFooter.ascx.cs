using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Configuration;
using JXTPortal.JobApplications.PeopleProfile;

namespace JXTPortal.Website.usercontrols.common
{
    public partial class ucFooter : System.Web.UI.UserControl
    {
        public String SetContent
        {
            set
            {
                // Add tags if the Member or Advertiser is logged in.
                if (SessionData.Member != null)
                {
                    if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["ServiceDottIntegrationIDs"]) &&
                                ConfigurationManager.AppSettings["ServiceDottIntegrationIDs"].Contains(" " + SessionData.Site.SiteId + " "))
                    {
                        ltlContent.Text = "<span id='miniMemberLoggedIn' data-ee='" + HttpUtility.UrlEncode(ServiceDottIntegration.Encrypt(SessionData.Member.EmailAddress)) + "'></span>";
                    }
                    else
                        ltlContent.Text = "<span id='miniMemberLoggedIn'></span>";

                }
                
                if (SessionData.AdvertiserUser != null)
                    ltlContent.Text = "<span id='miniAdvertiserLoggedIn'></span>";
                
                if (!String.IsNullOrEmpty(value.Trim()))
                    ltlContent.Text = ltlContent.Text + String.Format("<div id='footer'>{0}</div><!--end of footer-->", value);
            }
        }
    }
}