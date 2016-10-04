// -----------------------------------------------------------------------
// <copyright file="DirectPost.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace PaymentGateway.SecurePay
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.IO;
    using System.Security.Cryptography;

    /// <summary>
    /// SecurePay - Direct Post
    /// </summary>
    public class DirectPost
    {
        public string CalculateSHA1(string text, Encoding enc)
        {
            byte[] buffer = enc.GetBytes(text);
            SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
            return BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");
        }


        public string Compute(string text)
        {
            byte[] input = Encoding.UTF8.GetBytes(text);

            // Initialize the engine
            SHA1 engine = new SHA1CryptoServiceProvider();

            // Compute the hash
            byte[] hash = engine.ComputeHash(input);

            // Return the result
            return Convert.ToBase64String(hash);
        }

        protected String EncryptPassword(String Email, String Password)
        {
            SHA1CryptoServiceProvider objSHA;
            Byte[] bytPassword;
            Byte[] bytHashed;

            UTF8Encoding utf8 = new UTF8Encoding();
            bytPassword = utf8.GetBytes(Email + Password); //+ ACart_SALT

            objSHA = new SHA1CryptoServiceProvider();
            bytHashed = objSHA.ComputeHash(bytPassword);

            return Convert.ToBase64String(bytHashed);
        }

        public void Pay(bool blnTestPayment)
        {

            string sha = Compute("ABC0010|txnpassword|0|Test Reference|1.00|20110616221931");


                // By default, this sample code is designed to post to our test server for
                // developer accounts: https://test.authorize.net/gateway/transact.dll
                // for real accounts (even in test mode), please make sure that you are
                // posting to: https://secure.authorize.net/gateway/transact.dll
                String post_url = "https://api.securepay.com.au/live/directpost/authorise";

                Dictionary<string, string> post_values = new Dictionary<string, string>();
                //the API Login ID and Transaction Key must be replaced with valid values
                post_values.Add("EPS_MERCHANT", "ABC0010");
                post_values.Add("EPS_TXNTYPE", "0");
                post_values.Add("EPS_REFERENCEID", "Test Reference");                           //Your Company wants to include its invoice numbers with every payment. 
                post_values.Add("EPS_AMOUNT", "1.00");
                post_values.Add("EPS_TIMESTAMP", DateTime.Now.ToString("yyyyMMddHHmmss"));      //"201106141010"
                post_values.Add("EPS_FINGERPRINT", "01a1edbb159aa01b99740508d79620251c2f871d");

                post_values.Add("EPS_CARDNUMBER", "AUTH_CAPTURE");
                post_values.Add("EPS_EXPIRYMONTH", "CC");
                post_values.Add("EPS_EXPIRYYEAR", "4111111111111111");
                post_values.Add("EPS_CCV", "0115");

                //https://www.resulturl.com.au?refid=Test Reference&rescode=08&restext=Honour with ID&txnid=100036&authid=151678&settdate=20110617&sig=MC0CFQCQnNRvziCb1o3q2XPWPljH8qbqpQIUQm9TpDX1NHutXYuxkbUk9AfV+/M=

                String post_string = "";

                foreach (KeyValuePair<string, string> post_value in post_values)
                {
                    post_string += post_value.Key + "=" + System.Web.HttpUtility.UrlEncode(post_value.Value) + "&";
                }
                post_string = post_string.TrimEnd('&');


                // create an HttpWebRequest object to communicate with Authorize.net
                HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(post_url);
                objRequest.Method = "POST";
                objRequest.ContentLength = post_string.Length;
                objRequest.ContentType = "application/x-www-form-urlencoded";

                // post data is sent as a stream
                StreamWriter myWriter = null;
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(post_string);
                myWriter.Close();

                // returned values are returned as a stream, then read into a string
                String post_response;
                HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
                using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
                {
                    post_response = responseStream.ReadToEnd();
                    responseStream.Close();
                }

                // the response string is broken into an array
                // The split character specified here must match the delimiting character specified above
                Array response_array = post_response.Split('|');

                // the results are output to the screen in the form of an html numbered list.
                string resultSpan = string.Empty;
                resultSpan += "<OL> \n";
                foreach (string value in response_array)
                {
                    resultSpan += "<LI>" + value + "&nbsp;</LI> \n";
                }
                resultSpan += "</OL> \n";
                // individual elements of the array could be accessed to read certain response
                // fields.  For example, response_array[0] would return the Response Code,
                // response_array[2] would return the Response Reason Code.
                // for a list of response fields, please review the AIM Implementation Guide
            
        }
    }
}
