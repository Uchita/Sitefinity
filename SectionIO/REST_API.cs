﻿using System;
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
            string request_end_point = string.Format(API_END_POINT, _accountID, _applicationID, _environmentName.ToString());

            //varnish and state call
            request_end_point += "/proxy/" + proxy.ToString().ToLower() + "/state?banExpression=" + Uri.EscapeDataString(banExpression);

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
            //build ban expression
            string folderToFlush = string.Format("{0}{1}", siteFtpFolderName, asset == AssetClass.all ? string.Empty : "/" + asset.ToString());
            string sectionIOFolder = "http_imagesjxtnetau";

            // According to sectionIO documentation we dont need to use '/' at end of the URI
            string _banExpression = string.Format(@"https://{0}/{1}/{2}", site, sectionIOFolder, folderToFlush); ;
           
            API_Proxy_State_Post(SectionIO_API.Proxy.Varnish, _banExpression);
        }
    }
}
