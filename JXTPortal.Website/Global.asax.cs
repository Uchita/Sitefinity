using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using JXTPortal.Entities;
using JXTPortal.Data;
using JXTPortal;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using Autofac.Integration.Web;
using JXTPortal.Website.App_Codes;
using Autofac;
using JXTPortal.Custom;
using log4net;

namespace JXTPortal.Website
{
    public class Global : System.Web.HttpApplication, IContainerProviderAccessor
    {
        int languageIDToBeSet = -1; // when -1, there is no language specifier in the URL

        // Provider that holds the application container.
        static IContainerProvider _containerProvider;

        // Instance property that will be used by Autofac HttpModules
        // to resolve and inject dependencies.
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        private ILog _logger = LogManager.GetLogger(typeof(Global));

        protected void Application_Start(object sender, EventArgs e)
        {
            _containerProvider = new ContainerProvider(IoCHelper.CreateContainer());

            SessionService.InnerService = ContainerProvider.ApplicationContainer.Resolve<ISessionService>();

            //Add 3072 (TLS1.2) for this application
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | (SecurityProtocolType)3072;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            SessionService.SessionSetup();

            // SECURITY - secure the ASP.NET Session ID only if using SSL
            // if you don't check for the issecureconnection, it will not work.
            if (Request.IsSecureConnection == true)
                Response.Cookies["ASP.NET_SessionId"].Secure = true;
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            // Ignore the below files
            if (Request.Path.Contains(".asmx") || Request.Path.Contains(".axd")
                 || Request.Path.Contains(".ashx") || Request.Path.Contains(".js")
                 || Request.Path.Contains(".css") || Request.Path.Contains(".jpeg")
                 || Request.Path.Contains(".bmp") || Request.Path.Contains(".png")
                 || Request.Path.Contains(".gif") || Request.Path.Contains(".jpg")
                 || Request.Path.Contains("oauthcallback.aspx") || Request.Path.Contains("paymentconfirmation.aspx") || Request.Path.Contains("bullhornintegration.aspx")
                )
            {
                return;
            }

            // 301 redirects
            {
                CacheObject cacheObject = new CacheObject();
                string rawURL = string.Format("{0}://{1}{2}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Host, HttpContext.Current.Request.RawUrl);
                //HttpContext.Current.Request.Url.OriginalString
                string redirectUrl = cacheObject.FindCacheRedirect(rawURL);

                if (!string.IsNullOrWhiteSpace(redirectUrl))
                {
                    Response.StatusCode = 301;
                    Response.AddHeader("Location", redirectUrl);

                    Response.End();
                }
            }

            //Language URL
            ProcessLanguageURLValue();



            if (Request.Path.Contains(".aspx") || Request.Path.Contains(".asmx"))
            {
                //AuthToken Check for logged in users
                if (SessionData.Site != null)
                {
                    //has session, check auth token
                    if (!SessionService.IsAuthTokenValid())
                    {
                        //HACKER?
                        //give this request a new session
                        SessionService.RemoveAdvertiserUser();
                        SessionService.RemoveMemberAndAdvertiser();

                        SessionService.SessionAbandon();

                        Response.Redirect("/?");
                    }
                }
            }

            string strRawUrlLower = HttpContext.Current.Request.RawUrl.ToString().ToLower();


            bool requireRedirect = false;
            if (HttpContext.Current.Session != null && SessionData.Site != null)
            {
                requireRedirect = SessionData.Site.WWWRedirect;

            }
            else
            {
                // Todo - Get from the Session for wwwredirect instead of the database - SessionSetup Maybe .. when does it hit the else ?

                SitesService service = new SitesService();
                // check it www. is missing
                if (!HttpContext.Current.Request.Url.Host.StartsWith("www."))
                {
                    System.Data.DataSet dsSiteList = service.FindSite(null, GetCurrentWhitelabelUrl());

                    if (dsSiteList != null && dsSiteList.Tables[0].Rows.Count > 0)
                    {
                        // Check if site is using WWWRedirect
                        int siteid = Convert.ToInt32(dsSiteList.Tables[0].Rows[0]["SiteID"]);
                        GlobalSettingsService gsservice = new GlobalSettingsService();
                        using (TList<Entities.GlobalSettings> gs = gsservice.GetBySiteId(siteid))
                        {
                            if (gs[0].WwwRedirect)
                            {
                                requireRedirect = true;
                            }
                        }

                        dsSiteList.Dispose();
                    }

                }
            }

            if (HttpContext.Current.Session != null)
            {
                try
                {
                    if (SessionData.Member == null && SessionData.AdvertiserUser == null)
                    {
                        //remember me cookie
                        HttpCookie rememberAdvertiserCookie = Request.Cookies[PortalConstants.SiteCookie.AdvertiserUserCookie];
                        HttpCookie rememberMemberCookie = Request.Cookies[PortalConstants.SiteCookie.MemberCookie];
                        if (rememberAdvertiserCookie != null)
                        {
                            int advertiserUserId = 0;
                            if (!RememberMeFunctionIsAuthentic(rememberAdvertiserCookie, out advertiserUserId))
                            {
                                SessionService.RemoveAdvertiserUser();
                                SessionService.RemoveMemberAndAdvertiser();

                                SessionService.SessionAbandon();

                                Response.Redirect("/?");
                            }

                            //Process advertiser details
                            AdvertiserUsersService service = new AdvertiserUsersService();
                            using (Entities.AdvertiserUsers advuser = service.GetByAdvertiserUserId(advertiserUserId))
                            {
                                if (advuser != null)
                                {
                                    SessionService.SetAdvertiserUser(advuser);
                                }
                            }
                        }
                        else if (rememberMemberCookie != null)
                        {
                            int memberId = 0;
                            if (!RememberMeFunctionIsAuthentic(rememberMemberCookie, out memberId))
                            {
                                SessionService.RemoveAdvertiserUser();
                                SessionService.RemoveMemberAndAdvertiser();

                                SessionService.SessionAbandon();

                                Response.Redirect("/?");
                            }

                            //Process member details
                            MembersService service = new MembersService();
                            using (Entities.Members member = service.GetByMemberId(memberId))
                            {
                                if (member != null)
                                {
                                    SessionService.SetMember(member);
                                }
                            }
                        }

                    }
                }
                catch { }
            }


            if (HttpContext.Current.Session != null && JXTPortal.Entities.SessionData.Site != null)
            {
                // If SSL is enabled for the site but the url is not Secured.
                if (SessionData.Site.EnableSsl && !HttpContext.Current.Request.IsSecureConnection) // && !HttpContext.Current.Request.IsLocal
                {

                    string strWWW = SessionData.Site.WWWRedirect ? "www." : string.Empty;
                    string redirectUrl = "https://" + strWWW + HttpContext.Current.Request.Url.Host.Replace("www.", "") + HttpContext.Current.Request.RawUrl;

                    if (!(
                            strRawUrlLower.Contains("/admin/") || strRawUrlLower.Contains("login.aspx") ||
                            strRawUrlLower.Contains("validate.aspx") || strRawUrlLower.Contains("gclid="))
                         ) //gclid= Google adwords
                        redirectUrl = redirectUrl.ToLower();

                    Response.StatusCode = 301;
                    Response.AddHeader("Location", redirectUrl);

                    Response.End();
                }


                // MONASH SAML SSO for Intranet net - ignore the admin
                if (ConfigurationManager.AppSettings["MonashSAMLSSOSiteId"] != null
                        && ConfigurationManager.AppSettings["MonashSAMLSSOSiteId"].Contains(string.Format(" {0} ", JXTPortal.Entities.SessionData.Site.SiteId))
                        && !strRawUrlLower.Contains("/admin"))
                {
                    // Redirect only if the member is logged in AND ignore the error page.
                    if (SessionData.Member == null && !strRawUrlLower.Contains("/member/sso/monash/login.aspx") && !strRawUrlLower.Contains("errorpage.aspx"))
                        Response.Redirect("~/member/sso/monash/login.aspx");
                }
            }



            // Code that runs on every request
            if (strRawUrlLower != HttpContext.Current.Request.RawUrl.ToString() || HttpContext.Current.Request.Url.Host.StartsWith("www.") == false)
            {
                // Check if it is using SSL
                string strHTTP = (HttpContext.Current.Request.IsSecureConnection) ? "https://" : "http://";

                string strWWW = string.Empty;


                if (HttpContext.Current.Request.Url.Host.StartsWith("localhost") && strRawUrlLower == HttpContext.Current.Request.RawUrl.ToString())
                {
                    return;
                }

                // Ignore all the admin pages all when on the login.aspx page.
                // login.aspx - so that for the AICD api encrypt code which has capital letter not to be converted to lower case.
                if (strRawUrlLower.Contains("/admin/") || strRawUrlLower.Contains("login.aspx") || strRawUrlLower.Contains("validate.aspx") || strRawUrlLower.Contains("gclid="))
                {
                    return;
                }

                if (requireRedirect)
                {
                    if (!HttpContext.Current.Request.Url.Host.StartsWith("www.") && HttpContext.Current.Request.Url.Host.StartsWith("localhost") == false)
                    {
                        strWWW = "www.";
                    }
                }

                if (requireRedirect || strRawUrlLower != HttpContext.Current.Request.RawUrl.ToString())
                {
                    // redirect to lowered cased url

                    Response.StatusCode = 301;

                    // Ignore all the admin pages all when on the login.aspx page.
                    // login.aspx - so that for the AICD api encrypt code which has capital letter not to be converted to lower case.
                    if (strRawUrlLower.Contains("/admin/") || strRawUrlLower.Contains("login.aspx") || strRawUrlLower.Contains("validate.aspx") || strRawUrlLower.Contains("gclid="))
                        Response.AddHeader("Location", (strHTTP + strWWW + HttpContext.Current.Request.Url.Host + ((HttpContext.Current.Request.Url.Host == "localhost") ? ":" + HttpContext.Current.Request.Url.Port : string.Empty) + HttpContext.Current.Request.RawUrl.ToString()));
                    else
                        Response.AddHeader("Location", (strHTTP + strWWW + HttpContext.Current.Request.Url.Host + ((HttpContext.Current.Request.Url.Host == "localhost") ? ":" + HttpContext.Current.Request.Url.Port : string.Empty) + HttpContext.Current.Request.RawUrl.ToString()).ToLower());

                    Response.End();

                }


            }
        }

        private bool RememberMeFunctionIsAuthentic(HttpCookie cookie, out int userID)
        {
            userID = 0;
            try
            {
                // Decrypt the cookie
                string decryptedValue = Common.Utils.Decrypt(cookie.Value, true);

                string[] rememberCookieValues = decryptedValue.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

                //validation                
                if (rememberCookieValues.Count() != 2
                    || !rememberCookieValues[1].Equals(SessionData.Site.AuthToken) //Auth Token Check From Cookies
                    || !SessionData.Site.AuthToken.Equals(SessionService.GenerateAuthToken()) //Auth Token Check From Session
                    || !int.TryParse(rememberCookieValues[0], out userID)
                    )
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {

            // SECURITY - Doesn't work on local computer, Only on IIS level it removes from the Header.
            try
            {
                Response.Headers.Remove("Server");
                Response.Headers.Remove("X-AspNet-Version");
                Response.Headers.Remove("X-AspNetMvc-Version");
                Response.Headers.Add("X-Content-Type-Options", "nosniff");
                Response.Headers.Add("X-XSS-Protection", "1; mode=block");

                // HTTP Strict Transport Security policy - defines a timeframe where a browser must connect to the web server via HTTPS
                if (Request.IsSecureConnection == true)
                    Response.Headers.Add("Strict-Transport-Security", "max-age=31536000");
            }
            catch { }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //Language URL
            ExtractAndRewriteLanguageURL();

            /*
            if (Request.Path.Contains(".aspx") || Request.Path.Contains(".asmx"))
            {
                //Check If it is a new session or not , if not then do the further checks
                if (Request.Cookies["ASP.NET_SessionId"] != null && Request.Cookies["ASP.NET_SessionId"].Value != null)
                {
                    string newSessionID = Request.Cookies["ASP.NET_SessionID"].Value;

                    if (string.IsNullOrWhiteSpace(newSessionID))
                    {

                    }
                    else 
                    {
                        //Check the valid length of your Generated Session ID
                        if (newSessionID.Length <= 24)
                        {
                            Response.Cookies.Remove("ASP.NET_SessionId");

                            //Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;

                            //Log the attack details here
                            //Response.Cookies["TriedTohack"].Value = "True";
                            //throw new HttpException("Invalid Request");
                        }

                        //Genrate Hash key for this User,Browser and machine and match with the Entered NewSessionID
                        else if (GenerateHashKey() != newSessionID.Substring(24))
                        {
                            Response.Cookies.Remove("ASP.NET_SessionId");
                            //Log the attack details here
                            //Response.Cookies["TriedTohack"].Value = "True";
                            //throw new HttpException("Invalid Request");
                        }

                        //Use the default one so application will work as usual//ASP.NET_SessionId
                        Request.Cookies["ASP.NET_SessionId"].Value = Request.Cookies["ASP.NET_SessionId"].Value.Substring(0, 24);
                    }
                }

            }
            */

            // For Web service to work for Jquery Ajax

            if (Request.Path.IndexOf(".asmx") != -1)
            {
                HandleAjax(HttpContext.Current);
                return;
            }
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            languageIDToBeSet = -1; //reset

            /*
            if (Request.Path.Contains(".aspx") || Request.Path.Contains(".asmx"))
            {

                //Pass the custom Session ID to the browser.
                if (Response.Cookies["ASP.NET_SessionId"] != null)
                {
                    if (!string.IsNullOrWhiteSpace(Request.Cookies["ASP.NET_SessionId"].Value))
                        Response.Cookies["ASP.NET_SessionId"].Value = Request.Cookies["ASP.NET_SessionId"].Value + GenerateHashKey();
                }
            }*/
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = HttpContext.Current.Server.GetLastError();
            bool isRewrite = false;
            if (ex != null)
            {
                if (ex.GetType() == typeof(HttpException))
                {
                    HttpException httpException = (HttpException)ex;

                    if (httpException.GetHttpCode() == 400 || httpException.GetHttpCode() == 404 || ex.Message.Contains("File does not exist"))
                    {
                        //bool custompath = true;

                        //if (custompath)
                        //{
                        //    HttpContext.Current.ClearError();
                        //    if (HttpContext.Current.Session == null)
                        //    {
                        //        Session_Start(null, null);
                        //    }
                        //    Server.Transfer("~/default.aspx", false);

                        //    isRewrite = true;
                        //    return;
                        //}
                        //else
                        {
                            HttpContext.Current.ClearError();
                            HttpContext.Current.Response.Redirect("/404.aspx");

                            return;
                        }
                    }
                }
                if (!isRewrite)
                {
                    _logger.Error(ex.GetBaseException());

                    if (Convert.ToBoolean(System.Configuration.ConfigurationSettings.AppSettings["DisplayErrorMessage"]))
                    {
                        string strUrl = "~/errorpage.aspx";

                        int intExceptionID = -1;
                        
                        strUrl += "?exceptionID=" + Convert.ToString(intExceptionID);

                        //--- Redirect to clean error page
                        HttpContext.Current.ClearError();

                        if (!HttpContext.Current.Request.RawUrl.Contains("errorpage.aspx"))
                            HttpContext.Current.Response.Redirect(strUrl);
                    }
                }
            }

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        #region Language URL Related Methods

        private List<string> LanguageURLReqPathExclusions = new List<string> { "rss.aspx", "newsrss.aspx", "/admin/" };

        private void ExtractAndRewriteLanguageURL() //Application_BeginRequest
        {
            int languageID = 0;
            //Language url (/en/blahblahblah.aspx)
            string reqPath = Request.Path.ToLower();
            //language does not apply to rss and newsrss
            if (reqPath.Contains(".aspx") && !LanguageURLReqPathExclusions.Where(u => reqPath.Contains(u)).Any())
            {
                if (RequestURLHasLanguageSpecifier(out languageID))
                {
                    //Only set the language ID if it is not from the language drop down
                    bool isLanguageDropDownPostBack = Request["__EVENTTARGET"] != null && Request["__EVENTTARGET"].Contains("$ddlLanguages");

                    if (!isLanguageDropDownPostBack)
                    {
                        //because session is not available at the current stage, we assign a flag to update the session languages later
                        languageIDToBeSet = languageID;
                    }

                    string newRoute = ReconstructURLForLanguageRoutes();
                    Request.RequestContext.HttpContext.RewritePath(newRoute);
                }
            }
        }

        private void ProcessLanguageURLValue() //Application_AcquireRequestState
        {
            //language does not apply to rss and newsrss
            string reqPath = Request.Path.ToLower();
            if (reqPath.Contains(".aspx") && !LanguageURLReqPathExclusions.Where(u => reqPath.Contains(u)).Any())
            {
                bool isLanguageDropDownPostBack = Request["__EVENTTARGET"] != null && Request["__EVENTTARGET"].Contains("$ddlLanguages");

                //Only do the following if it is not from the language drop down
                if (!isLanguageDropDownPostBack)
                {
                    // URL has language specifier
                    if (languageIDToBeSet != -1) //NOTE: aspx check is at the languageIDToBeSet assign (in Application_BeginRequest)
                    {
                        PortalEnums.Languages.URLLanguage targetLanguage = (PortalEnums.Languages.URLLanguage)languageIDToBeSet;
                        bool validLanguageForSite = SessionData.Site.SiteAvailableLanguage.Contains(targetLanguage);

                        if (validLanguageForSite)
                        {
                            //set language selected to user session
                            UserLanguageSessionSet(languageIDToBeSet);

                            //check if the targeted language url is the site's default url
                            bool siteDefaultLangEqualsTargetedLang = SessionData.Site.DefaultLanguageId == languageIDToBeSet;
                            if (siteDefaultLangEqualsTargetedLang)
                            {
                                //redirect to the same URL with the language specifier removed if there is any (which is the same as the site's default lang)
                                //otherwise let it through and load the page
                                if (RequestRawURLHasLanguageSpecifier())
                                {
                                    string nonLangTargetedURL = Request.Url.GetLeftPart(UriPartial.Scheme) + Request.Url.Host + ReconstructURLForLanguageRawURL();

                                    #if DEBUG
                                    nonLangTargetedURL = Request.Url.GetLeftPart(UriPartial.Scheme) + Request.Url.Authority + ReconstructURLForLanguageRawURL();
                                    #endif
                                    Response.Redirect(nonLangTargetedURL, false);
                                }
                                else
                                {
                                    //note that at this point the Request URL has had the language URL removed by the function ExtractAndRewriteLanguageURL

                                    // When redirecting to a dynamic page with default language, need to reset the url properly
                                    if (reqPath.ToLower().Contains("page.aspx"))
                                    {
                                        // for dynamic page using customurl
                                        if (Request.Params["customurl"] == "1")
                                        {
                                            Response.Redirect("~/" + Request.Params["code"], false);
                                        }
                                        else
                                        {
                                            // page without customurl

                                            Response.Redirect("~/page/" + Request.Params["code"], false);
                                        }
                                    }
                                    else
                                    {
                                        Response.Redirect(Request.RawUrl, false);
                                    }
                                }

                                //Jumps directly to the ASP.NET end request call
                                HttpContext.Current.ApplicationInstance.CompleteRequest();
                            }
                        }
                        else
                        {
                            Response.Redirect("/404.aspx", false);
                            //Jumps directly to the ASP.NET end request call
                            HttpContext.Current.ApplicationInstance.CompleteRequest();
                            //redirect to the same URL with the language specifier removed if there is any (which is the same as the site's default lang)
                            //otherwise let it through and load the page
                            //if (RequestURLHasLanguageSpecifier())
                            //{
                            //    string nonLangTargetedURL = ReconstructURLForLanguageRoutes();
                            //    Response.Redirect(nonLangTargetedURL, true);
                            //}
                        }
                    }
                    else // languageIDToBeSet == -1 means there is no language specifier in the URL
                    {
                        if (SessionData.Site != null && SessionData.Language != null)
                        {
                            Entities.Languages targetLang = SessionData.Language;

                            bool siteDefaultLangEqualsTargetedLang = SessionData.Site.DefaultLanguageId == targetLang.LanguageId;
                            if (!siteDefaultLangEqualsTargetedLang)
                            {
                                PortalEnums.Languages.URLLanguage targetURLLang = (PortalEnums.Languages.URLLanguage)targetLang.LanguageId;

                                //redirect to the same URL with the targeted language specifier
                                string langTargetedURL = Request.Url.GetLeftPart(UriPartial.Scheme) + Request.Url.Host + "/" + CommonFunction.GetEnumDescriptionWithoutGetResourceValue(targetURLLang) + Request.RawUrl;

#if DEBUG
                                langTargetedURL = Request.Url.GetLeftPart(UriPartial.Scheme) + Request.Url.Authority + "/" + CommonFunction.GetEnumDescriptionWithoutGetResourceValue(targetURLLang) + Request.RawUrl;
#endif
                                Response.Redirect(langTargetedURL, false);
                                //Jumps directly to the ASP.NET end request call
                                HttpContext.Current.ApplicationInstance.CompleteRequest();
                            }
                        }
                    }
                }
            }
        }

        private bool RequestURLHasLanguageSpecifier()
        {
            int _NotUsed;
            return RequestURLHasLanguageSpecifier(out _NotUsed);
        }

        private bool RequestURLHasLanguageSpecifier(out int languageID)
        {
            languageID = 0;
            bool hasLanguageSpecifier = false;
            foreach (PortalEnums.Languages.URLLanguage lang in Enum.GetValues(typeof(PortalEnums.Languages.URLLanguage)))
            {
                //cater for _ like en_us
                string thisLang = CommonFunction.GetEnumDescriptionWithoutGetResourceValue(lang);

                if (Request.Url.Segments.Select(c => c.ToUpper()).Contains(thisLang.ToUpper() + "/"))
                {
                    hasLanguageSpecifier = true;
                    languageID = (int)lang;
                    break;
                }
            }
            return hasLanguageSpecifier;
        }

        private bool RequestRawURLHasLanguageSpecifier()
        {
            bool hasLanguageSpecifier = false;
            foreach (PortalEnums.Languages.URLLanguage lang in Enum.GetValues(typeof(PortalEnums.Languages.URLLanguage)))
            {
                //cater for _ like en_us
                string thisLang = CommonFunction.GetEnumDescriptionWithoutGetResourceValue(lang);

                if (Request.RawUrl.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries).Select(c => c.ToUpper()).Contains(thisLang.ToUpper()))
                {
                    hasLanguageSpecifier = true;
                    break;
                }
            }
            return hasLanguageSpecifier;
        }

        private void UserLanguageSessionSet(int languageID)
        {
            Entities.Languages lang = new LanguagesService().GetByLanguageId(languageID);
            if (lang != null)
            {
                SessionData.Language = lang;
            }
        }

        private string ReconstructURLForLanguageRoutes()
        {
            //reconstruct the destination request
            List<string> newRoutesList = Request.Url.Segments.ToList();
            newRoutesList.RemoveAt(0); //remove domain
            newRoutesList.RemoveAt(0); //remove "EN/"

            string newRoute = "/" + String.Join("", newRoutesList);
            return newRoute;
        }

        private string ReconstructURLForLanguageRawURL()
        {
            //reconstruct the destination request
            List<string> newRoutesList = Request.RawUrl.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            newRoutesList.RemoveAt(0); //remove "EN/"

            string newRoute = "/" + String.Join("/", newRoutesList);
            return newRoute;
        }

        #endregion

        private void HandleAjax(HttpContext context)
        {
            int dotasmx = context.Request.Path.IndexOf(".asmx");
            string path = context.Request.Path.Substring(0, dotasmx + 5);
            string pathInfo = context.Request.Path.Substring(dotasmx + 5);
            context.RewritePath(path, pathInfo, context.Request.Url.Query);
        }

        /// <summary>
        /// get current whitelabel url - replace the staging fix
        /// </summary>
        /// <returns></returns>
        public string GetCurrentWhitelabelUrl()
        {
            string siteURL = HttpContext.Current.Request.Url.Host.ToString();
            return siteURL.Replace("dev.", "").Replace("www.", "").Replace(System.Configuration.ConfigurationManager.AppSettings[PortalConstants.WebConfigurationKeys.WEBSITEURLPOSTFIX], string.Empty);
        }
    }
}