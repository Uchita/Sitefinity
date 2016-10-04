using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Configuration;
using JXTPortal.JobApplications.PeopleProfile;

namespace JXTPortal.Website.MasterPages
{
    public partial class _default : PageBase
    {
        #region Properties

        private GlobalSettingsService _globalSettingsService = null;

        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_globalSettingsService == null)
                {
                    _globalSettingsService = new GlobalSettingsService();
                }
                return _globalSettingsService;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            ltJquery.Text = "<script type=\"text/javascript\" src=\"//images.jxt.net.au/COMMON/js/jquery.js\"></script>";
            using (Entities.GlobalSettings globalSettings = GlobalSettingsService.GetGlobalSettingBySiteID(SessionData.Site.SiteId))
            {
                if (globalSettings != null)
                {
                    if (String.IsNullOrEmpty(globalSettings.SiteDocType) && String.IsNullOrEmpty(ltlDocType.Text))
                        ltlDocType.Text = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">";
                    else
                        ltlDocType.Text = globalSettings.SiteDocType;

                    if (!string.IsNullOrWhiteSpace(globalSettings.GoogleWebMaster))
                    {
                        ltGoogleWebMaster.Text = string.Format("<meta name=\"google-site-verification\" content=\"{0}\" />", globalSettings.GoogleWebMaster);
                    }

                    if (!string.IsNullOrWhiteSpace(globalSettings.GoogleTagManager))
                    {
                        ltGoogleTagManager.Text = @"<!-- Google Tag Manager -->
                                                    <noscript><iframe src=""//www.googletagmanager.com/ns.html?id=" + globalSettings.GoogleTagManager + @"""
                                                    height=""0"" width=""0"" style=""display:none;visibility:hidden""></iframe></noscript>
                                                    <script>(function(w,d,s,l,i){w[l]=w[l]||[];w[l].push(
                                                    {'gtm.start': new Date().getTime(),event:'gtm.js'}
                                                    );var f=d.getElementsByTagName(s)[0],
                                                    j=d.createElement(s),dl=l!='dataLayer'?'&l='+l:'';j.async=true;j.src=
                                                    '//www.googletagmanager.com/gtm.js?id='+i+dl;f.parentNode.insertBefore(j,f);
                                                    })(window,document,'script','dataLayer','" + globalSettings.GoogleTagManager + @"');</script>
                                                    <!-- End Google Tag Manager -->";
                    }

                    if (!string.IsNullOrWhiteSpace(globalSettings.GoogleAnalytics))
                    {
                        ltGoogleAnalytics.Text = @"<script>
                                                    (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function()
                                                    { (i[r].q=i[r].q||[]).push(arguments)}
                                                    ,i[r].l=1*new Date();a=s.createElement(o),
                                                    m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
                                                    })(window,document,'script','https://www.google-analytics.com/analytics.js','ga');
                                                    ga('create', '" + globalSettings.GoogleAnalytics + @"', 'auto');
                                                    ga('send', 'pageview');
                                                    </script>";
                    }
                }
            }
            litContentType.Text = SessionData.Language.CharSetMetaTag;
            form1.Action = Request.RawUrl;
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            base.Page_Init(sender, e);
            //check whether this site is live or not
            this.SitesLiveCheck();

            // Check if the site is private - you should be logged in as an advertiser or member
            //this.PrivateSiteCheck();



            // Add tags if the Member or Advertiser is logged in.
            if (SessionData.Member != null)
            {
                if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["ServiceDottIntegrationIDs"]) &&
                            ConfigurationManager.AppSettings["ServiceDottIntegrationIDs"].Contains(" " + SessionData.Site.SiteId + " "))
                {
                    ltlLoggedIn.Text = "<span id='miniMemberLoggedIn' data-ee='" + HttpUtility.UrlEncode(ServiceDottIntegration.Encrypt(SessionData.Member.EmailAddress)) + "'></span>";
                }
                else
                    ltlLoggedIn.Text = "<span id='miniMemberLoggedIn'></span>";

            }
            if (SessionData.AdvertiserUser != null)
                ltlLoggedIn.Text = "<span id='miniAdvertiserLoggedIn'></span>";
        }

    }
}
