using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.MasterPages
{
    public partial class Main : PageBase
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

        #region Page Events

        protected void Page_Init(object sender, EventArgs e)
        {
            base.Page_Init(sender, e);

            if ( SessionData.Language != null )
                litContentType.Text = SessionData.Language.CharSetMetaTag;

            // Get the Header, Footer, Meta Content, CSS/ Scripts, and Set Page Title            
            LoadPageContent(ucHeader1, ucFooter1, ltlLeftNavigation,ltlRightNavigation, ltlAboveHeader, ltlBelowFooter, 
                            ltlMetaContent, ltlDocType, ltlCSSAndScripts, this.Page, "{0}"); 
         
            //check whether the whitelabel is live or not
            this.SitesLiveCheck();

            // Check if the site is private - you should be logged in as an advertiser or member
            this.PrivateSiteCheck();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            using (Entities.GlobalSettings globalSettings = GlobalSettingsService.GetGlobalSettingBySiteID(SessionData.Site.SiteId))
            {
                if (globalSettings != null)
                {
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

            if (Request.RawUrl.ToLower().Contains("/advertiser/jobcreate.aspx") ||
                Request.RawUrl.ToLower().Contains("/advertiser/edit.aspx"))
            {
                ltCompatible.Text = "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\" />";
            }
            else
            {
                ltCompatible.Text = string.Empty;
            }
            ltJquery.Text = "<script type=\"text/javascript\" src=\"//images.jxt.net.au/COMMON/js/jquery.js\"></script>";

            string url = Request.Url.LocalPath.ToLower();

            if (url.StartsWith("/advertiser/") || url.StartsWith("/member/"))
            {
                // Exempt pages
                if (url.Contains("/register.aspx") == false && url.Contains("/login.aspx") == false && url.Contains("/forgetpassword.aspx") == false
                        && url.Contains("/createjobalert.aspx") == false && url.Contains("/jobalert.aspx") == false && url.Contains("/validate.aspx") == false
                        && url.Contains("/terms/") == false && url.Contains("/memberterms.aspx") == false && url.Contains("/advertiserterms.aspx") == false)
                {
                    if (url.StartsWith("/advertiser/"))
                    {
                        if (SessionData.AdvertiserUser != null)
                        {
                            DynamicContentService dcservice = new DynamicContentService();
                            using (TList<Entities.DynamicContent> dynamiccontents = dcservice.GetBySiteId(SessionData.Site.SiteId))
                            {
                                foreach (Entities.DynamicContent dynamiccontent in dynamiccontents)
                                {
                                    if (dynamiccontent.DynamicContentType == ((int) PortalEnums.DynamicContent.DynamicContentType.AdvertiserTermsAndConditions) && dynamiccontent.Active)
                                    {
                                        if (SessionData.AdvertiserUser.LastTermsAndConditionsDate.HasValue == false || SessionData.AdvertiserUser.LastTermsAndConditionsDate < dynamiccontent.LastModifiedDate)
                                        {
                                            Response.Redirect("/advertiser/terms/?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (SessionData.Member != null)
                        {
                            DynamicContentService dcservice = new DynamicContentService();
                            using (TList<Entities.DynamicContent> dynamiccontents = dcservice.GetBySiteId(SessionData.Site.SiteId))
                            {
                                foreach (Entities.DynamicContent dynamiccontent in dynamiccontents)
                                {
                                    if (dynamiccontent.DynamicContentType == ((int)PortalEnums.DynamicContent.DynamicContentType.MemberTermsAndConditions) && dynamiccontent.Active)
                                    {
                                        if (SessionData.Member.LastTermsAndConditionsDate.HasValue == false || SessionData.Member.LastTermsAndConditionsDate < dynamiccontent.LastModifiedDate)
                                        {
                                            Response.Redirect("/member/terms/?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        #endregion

    }
}
