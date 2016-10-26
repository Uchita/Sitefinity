using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;
using System.Web;

namespace SectionIO
{
    public class SectionIO_API
    {
        private const string API_END_POINT = "https://aperture.section.io/api/v1/account/{0}/application/{1}/environment/{2}";
        
        private long _accountID;
        private long _applicationID;
        private Environment _environmentName;

        public SectionIO_API(long accountID, long appID, Environment environment)
        {
            _accountID = accountID;
            _applicationID = appID;
            _environmentName = environment;
        }

        public void API_Proxy_State_Post(Proxy proxy, string banExpression)
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
            // Do the post and get the response.
            System.Net.WebResponse response = null;
            try
            {
                response = req.GetResponse();
            }
            catch (WebException ex)
            {
                string msg = "";

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    //throw ex;
                    response = ex.Response;
                    msg = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd().Trim();
                }
            }
        }

        #region Enums

        public enum Proxy
        {
            Varnish = 1
        }

        public enum Environment
        {
            Development = 1,
            Production = 2
        }

        #endregion

    }
}
