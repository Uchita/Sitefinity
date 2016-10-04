using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace JXTPosterTransform.Library.Common
{
    public static class Utils
    {
        /// <summary>
        /// Transform XML using XSLT
        /// </summary>
        /// <param name="strXSLT"></param>
        /// <param name="strXML"></param>
        /// <returns></returns>
        public static string TransformXML(string strXSLT, string strXML)
        {
            try
            {
                //--- Load the XSLT
                XslCompiledTransform objXSLT = new XslCompiledTransform();
                objXSLT.Load(new XmlTextReader(new StringReader(strXSLT)), null, null);

                //--- Get the input xml read
                StringReader objInput = new StringReader(strXML);
                XmlReader objXMLReader = XmlReader.Create(objInput);

                //--- Get the output xml writer
                StringWriter objOutput = new StringWriter();
                XmlWriter objXMLWriter = XmlWriter.Create(objOutput);

                //--- Transform the 
                objXSLT.Transform(objXMLReader, objXMLWriter);

                return objOutput.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when tranforming to XSL - {0}", ex.Message);
            }

            return string.Empty;
        }

        /// <summary>
        /// Transform XML using XSLT
        /// </summary>
        /// <param name="strXSLT"></param>
        /// <param name="objXML"></param>
        /// <returns></returns>
        public static XmlDocument TransformXML(string strXSLT, XmlDocument objXML)
        {

            //--- Load the XSLT
            XslCompiledTransform objXSLT = new XslCompiledTransform();
            objXSLT.Load(new XmlTextReader(new StringReader(strXSLT)), null, null);

            //--- Get the output xml writer
            StringWriter objOutput = new StringWriter();
            XmlWriter objXMLWriter = XmlWriter.Create(objOutput, objXSLT.OutputSettings);

            //--- Transform the 
            objXSLT.Transform(objXML, objXMLWriter);

            XmlDocument objXMLOutput = new XmlDocument();
            objXMLOutput.PreserveWhitespace = false;
            objXMLWriter.Flush();
            objOutput.Flush();
            objXMLOutput.LoadXml(objOutput.ToString());
            return objXMLOutput;

        }


        /// <summary>
        /// Retrieve XML as string from url
        /// </summary>
        /// <param name="strURL"></param>
        /// <returns></returns>
        public static string GetXMLFromUrl(string strURL)
        {
            //--- Create the web request
            HttpWebRequest objWebRequest = (HttpWebRequest)WebRequest.Create(strURL);
            //--- Set the proxy and credentials
            //objWebRequest.Proxy = GetProxy();
            //objWebRequest.Timeout = GetRequestTimeOut();

            //--- Get the response
            HttpWebResponse objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();
            Stream objStream = objWebResponse.GetResponseStream();
            StreamReader objTextStream = new StreamReader(objStream);

            //--- return the xml
            return objTextStream.ReadToEnd();
        }

        public static string GetXMLFromFileSystem(string strXML)
        {
            XDocument xDocument = XDocument.Load(XmlReader.Create(strXML));

            return xDocument.ToString();
        }

        public static bool RenameFile(string strFrom, string strTo)
        {
            if (File.Exists(strTo))
            {
                System.IO.File.Delete(strTo);
            }

            System.IO.File.Move(strFrom, strTo);


            return true;
        }

        public static string StripHTML(string inputString)
        {
            if (!String.IsNullOrEmpty(inputString))
            {
                return Regex.Replace(inputString, "<.*?>", "");
            }
            else
                return string.Empty;
        }

        #region Post/Get Methods

        public static string HttpPost(string URI, string Parameters)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";

            // Add parameters to post
            byte[] data = System.Text.Encoding.ASCII.GetBytes(Parameters);
            req.ContentLength = data.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(data, 0, data.Length);
            os.Close();

            System.Net.WebResponse resp;
            try
            {
                // Do the post and get the response.
                resp = req.GetResponse();
                if (resp == null) return null;
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                return sr.ReadToEnd().Trim();
            }
            catch (WebException ex)
            {
                string msg = "";

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    //throw ex;
                    resp = ex.Response;
                    msg = new System.IO.StreamReader(resp.GetResponseStream()).ReadToEnd().Trim();
                    resp.Close();
                }
                return null;
            }
        }

        public static string HttpGet(string URI, string Parameters, string access_token)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            req.Method = "GET";
            req.Headers.Add("Authorization: OAuth " + access_token);

            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }

        #endregion
    }
}

/*
public string GetPosterTransform(string requestXML, string requestXsl)
{
    string output = String.Empty;
    using (StringReader srt = new StringReader(requestXsl))
    using (StringReader sri = new StringReader(requestXML))
    {
        using (XmlReader xrt = XmlReader.Create(srt))
        using (XmlReader xri = XmlReader.Create(sri))
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xrt);
            using (StringWriter sw = new StringWriter())
            using (XmlWriter xwo = XmlWriter.Create(sw, xslt.OutputSettings)) // use OutputSettings of xsl, so it can be output as HTML
            {
                xslt.Transform(xri, xwo);
                output = sw.ToString();
            }
        }
    }

    return output;
}


*/