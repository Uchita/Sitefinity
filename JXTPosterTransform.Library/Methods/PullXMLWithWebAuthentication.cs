using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Configuration;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using JXTPosterTransform.Library.Common;
using JXTPosterTransform.Library.Models;
using log4net;

namespace JXTPosterTransform.Library.Methods
{
    public class PullXMLWithWebAuthentication
    {
        static ILog _logger;

        /// <summary>
        /// Parsing the directory listing
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ResponseClass ProcessXML(ClientSetupModels.PullXmlFromUrlWithAuth XMLwithAuth, string fileName)
        {
            _logger = LogManager.GetLogger(typeof(PullXMLFromFTP));

            _logger.DebugFormat("Attempting to retreive XML data with authentication:");
            _logger.DebugFormat("\t- Host => " + XMLwithAuth.Host + ", Username => " + XMLwithAuth.Username);
            _logger.DebugFormat("\t- Params => Filename(" + XMLwithAuth.Filename + "), FileStartsWith(" + XMLwithAuth.FileStartsWith + ")");

            ResponseClass responseClass = new ResponseClass();

            string strFileName = string.Empty;

            // Get the filename and download.
            if (!string.IsNullOrWhiteSpace(XMLwithAuth.Filename))
            {
                strFileName = XMLwithAuth.Filename;
            }
            else if (!string.IsNullOrWhiteSpace(XMLwithAuth.FileStartsWith))
            {
                _logger.DebugFormat("Creating web request...");

                WebRequest request = WebRequest.Create(XMLwithAuth.Host);
                request.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;
                request.Credentials = new NetworkCredential(XMLwithAuth.Username, XMLwithAuth.Password);

                _logger.DebugFormat("Awaiting response from request...");
                WebResponse response = request.GetResponse();


                _logger.DebugFormat("Processing response...");
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string result = reader.ReadToEnd();
                    Dictionary<string, DateTime> datasourcefiles = new Dictionary<string, DateTime>();

                    string standardPattern = "<a.*?href=[\"'](?<url>.*?)[\"'].*?>(?<name>.*?)</a>";
                    Regex regex = new Regex(standardPattern);

                    MatchCollection matches = regex.Matches(result);
                    if (matches.Count == 0)
                    {
                        responseClass.strMessage = "Parse failed." + XMLwithAuth.Host;
                        _logger.DebugFormat("Processing FAILED: " + responseClass.strMessage);
                        Console.WriteLine(responseClass.strMessage);
                        return responseClass;
                    }

                    foreach (Match match in matches)
                    {
                        if (!match.Success) { continue; }
                        if (match.Groups["url"].ToString().StartsWith(XMLwithAuth.FileStartsWith))
                        {
                            string url = match.Groups["url"].ToString();
                            string rawDate = url.Replace(XMLwithAuth.FileStartsWith, string.Empty);

                            try
                            {
                                //Get the timestamp
                                DateTime fileDateTime = new DateTime(Convert.ToInt32(rawDate.Substring(0, 4)),
                                    Convert.ToInt32(rawDate.Substring(4, 2)), Convert.ToInt32(rawDate.Substring(6, 2)),
                                    Convert.ToInt32(rawDate.Substring(8, 2)), Convert.ToInt32(rawDate.Substring(10, 2)), 0);
                                datasourcefiles.Add(url, fileDateTime);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(String.Format("Invalid Format {0}", match.Groups["url"].ToString()));
                            }
                        }
                    }

                    //Pick the latest file based on its timestamp
                    strFileName = datasourcefiles.OrderByDescending(f => f.Value).FirstOrDefault().Key;
                }
                _logger.DebugFormat("Response processed.");
            }
            

            if (!string.IsNullOrWhiteSpace(strFileName))
            {
                // Get the latest file from Authentication
                XmlUrlResolver xmlResolver = new XmlUrlResolver(); // { Credentials = _jobAdder.CurrentNetworkCredential };
                xmlResolver.Credentials = new NetworkCredential(XMLwithAuth.Username, XMLwithAuth.Password);

                // Get the file
                XmlReaderSettings xmlReaderSettings = new XmlReaderSettings() { XmlResolver = xmlResolver };
                XDocument xDocument = XDocument.Load(XmlReader.Create(XMLwithAuth.Host + strFileName, xmlReaderSettings));

                responseClass.ResponseXML = xDocument.ToString();

                // Save the Raw XML
                System.IO.File.WriteAllText(ConfigurationManager.AppSettings["FTPTempStorage"] + fileName + "_Raw.xml", responseClass.ResponseXML);

                // Success to get the XML.
                responseClass.blnSuccess = true;

            }
            else
            {
                responseClass.strMessage = "Can't find the file from URL - " + XMLwithAuth.Host;
                Console.WriteLine(responseClass.strMessage);
            }

            _logger.DebugFormat("Request responded: " + responseClass.blnSuccess + " - " + responseClass.strMessage);

            return responseClass;
        }
    }
}


/*
        public NetworkCredential CurrentNetworkCredential
        {
            get
            {
                return new NetworkCredential(Username, Password);
            }
        }

        //private string _clientPrefixFileName;

public string _Username;
public string _Password;
/// <summary>
/// JobAdder Username
/// <add key="JobAdderUserName" value="test" />
/// </summary>
public virtual string Username
{
    get { return _Username; }
    set { _Username = value; }
}

/// <summary>
/// JobAdder Password
/// <add key="JobAdderPassword" value="test" />
/// </summary>
public virtual string Password
{
    get { return _Password; }
    set { _Password = value; }
}*/