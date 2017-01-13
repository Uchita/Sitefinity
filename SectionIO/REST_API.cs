using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;
using System.Web;
using log4net;

namespace SectionIO
{
    public class SectionIO_API : ICacheFlusher
    {
        private const string API_END_POINT = "https://aperture.section.io/api/v1/account/{0}/application/{1}/environment/{2}";
        
        private long _accountID;
        private long _applicationID;
        private Environment _environmentName;
        private ILog _logger;

        public SectionIO_API(long accountID, long appID, Environment environment = Environment.Production)
        {
            _accountID = accountID;
            _applicationID = appID;
            _environmentName = environment;

            _logger = LogManager.GetLogger(typeof(SectionIO_API));
        }


        /// <summary>
        /// Clear the Section cache for the desired url
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="banExpression"></param>
        internal void API_Proxy_State_Post(Proxy proxy, string banExpression)
        {
            _logger.Info("API_Proxy_State_Post Started!");

            string request_end_point = string.Format(API_END_POINT, _accountID, _applicationID, _environmentName.ToString());
            _logger.DebugFormat("Request End Point [Before BanExpression]: {0}", request_end_point);

            //varnish and state call
            request_end_point += "/proxy/" + proxy.ToString().ToLower() + "/state?banExpression=" + Uri.EscapeDataString(banExpression);
            _logger.DebugFormat("Final Request End point that passes into Web Request: {0}",request_end_point);

            WebRequest req = WebRequest.Create(request_end_point);
            req.ContentType = "application/json";
            req.Method = "POST";

            // Add authorization
            byte[] auth = System.Text.Encoding.UTF8.GetBytes("himmy@jxt.com.au:jxt888888");
            string base64Auth = Convert.ToBase64String(auth);
            req.Headers.Add("Authorization", "Basic " + base64Auth);

            try
            {
                //Perform Asynchronously to ensure main thread isn't blocked. 
                IAsyncResult result = (IAsyncResult)req.BeginGetResponse(new AsyncCallback(ProcessResponse), req);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        private void ProcessResponse(IAsyncResult result)
        {
            try
            {
                WebRequest request = (WebRequest)result.AsyncState;
                //Finish the request
                WebResponse response = request.EndGetResponse(result);

                //Ensure resource is disposed
                response.Close();
            }
            catch (WebException ex)
            {
                string msg = string.Format("{0}: {1}", ex.Status, ex.Message);

                _logger.Error(msg, ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        #region Enums

        internal enum Proxy
        {
            Varnish = 1
        }

        public enum Environment
        {
            Development = 1,
            Production = 2
        }

        #endregion

        private class RequestState
        {
            public RequestState(WebRequest req)
            {
                Request = req;
            }
            public WebRequest Request { get; private set; }
            public WebResponse Response { get; set; }
        }


        public void FlushByUrl(string pageUrl)
        {
           API_Proxy_State_Post(SectionIO_API.Proxy.Varnish, "req.url == " + pageUrl);
        }

        /// <summary>
        /// This method builds the banexpression that needs to be passed into "API_Proxy_State_Post()"
        /// </summary>
        /// <param name="asset">Asset type that was passed into the method from SitesEdit.aspx button click</param>
        /// <param name="site">The format of the uri <example>"https://www.example.com/http_imagesjxtnetau/jxt-solutions"</example></param>
        /// <param name="folderName">Passes global FTP folder name</param>
        public void FlushAssetType(AssetClass asset, string site, string siteFtpFolderName)
        {
            _logger.Info("Flush Asset Type Started");
            //build ban expression
            string folderToFlush = string.Format("{0}{1}", siteFtpFolderName, asset == AssetClass.all ? string.Empty : "/" + asset.ToString());
            string sectionIOFolder = "http_imagesjxtnetau";

            _logger.DebugFormat("folderToFlush: {0}", folderToFlush);

            #region commented Stuff
            // According to sectionIO documentation we dont need to use '/' at end of the URI
            
            // Example of a Valid working Ban Expression: req.http.host == "www.diversecitycareers.com" && req.url ~ "/http_imagesjxtnetau/diversecitycareers/css"

            /*string hostPath = string.Format(@"https://{0}",site);
            _logger.DebugFormat("hostPath URL: {0}", hostPath);*/

            // Using '==' matches request directly for varnish entries where "~" conducts a regExp match
            //string banExpression = string.Format("req.http.host == \"{0}\" &&  req.url ~ \"/{1}/{2}\"", hostPath,sectionIOFolder,folderToFlush);
            #endregion

            string banExpression = buildBanExpression(sectionIOFolder, site, folderToFlush);

            _logger.DebugFormat("Banexpression: {0}", banExpression);

            API_Proxy_State_Post(SectionIO_API.Proxy.Varnish, banExpression);
        }

        /// <summary>
        /// This Method builds the banexpression that needs to be passed into "API_Proxy_State_Post()" inorder to clear cached Images
        /// </summary>
        /// <param name="siteUrl">This parameter contains first bit of the URL (before /media)<example>"http(s)://wwww.example.com"</example></param>
        /// <param name="imagepath">This parameter contains folderpath that comes after "/media"</param>
        /// <param name="imageName">This parameter passes name of the image that needs to be cleared from SEctionIO cache</param>
        public void FlushImage(string siteUrl, string imagePath, string imageName) 
        {
            _logger.Info("FlushImage Method");
            string jxtJobtemplateLogoImagePath = string.Format(@"media/{0}",imagePath);
            _logger.DebugFormat("JXT Media Image Path: {0}", jxtJobtemplateLogoImagePath);
           
            //string banExpression = string.Format("{0}/{1}/{2}", siteUrl, jxtJobtemplateLogoImagePath, imageName);
            string banExpression = buildBanExpression(jxtJobtemplateLogoImagePath, siteUrl, imageName);
            _logger.DebugFormat("Ban expression: {0}", banExpression);

            API_Proxy_State_Post(SectionIO_API.Proxy.Varnish, banExpression);
        }

        public string buildBanExpression(string assetPath, string siteURI, string assetToFush)
        {

            string hostPath = string.Format(@"https://{0}",siteURI);
            _logger.DebugFormat("Site URI: {0}", hostPath);
            // Using '==' matches request directly for varnish entries where "~" conducts a regExp match
            string banExpression = string.Format("req.http.host == \"{0}\" &&  req.url ~ \"/{1}/{2}\"", siteURI, assetPath, assetToFush);
            _logger.DebugFormat("Returning banExpression: {0}", banExpression);

            return banExpression;
        }
    }
}
