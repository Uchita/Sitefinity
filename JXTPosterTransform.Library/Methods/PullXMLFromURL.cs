using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using JXTPosterTransform.Library.Common;
using System.Configuration;
using log4net;

namespace JXTPosterTransform.Library.Methods
{
    public class PullXMLFromURL
    {
        static ILog _logger;
        public static ResponseClass ProcessXML(string source, string fileName)
        {
            _logger = LogManager.GetLogger(typeof(PullXMLFromFTP));

            _logger.DebugFormat("Attempting to data from source:");
            _logger.DebugFormat("\t- Source => " + source + ", Filename " +  fileName);
            
            ResponseClass responseClass = new ResponseClass();
            Console.WriteLine("Loading the XML - " + source);

            try
            {
                responseClass.ResponseXML = Utils.GetXMLFromUrl(source);
              
                // Save the Raw XML
                System.IO.File.WriteAllText(ConfigurationManager.AppSettings["FTPTempStorage"] + fileName + "_Raw.xml", responseClass.ResponseXML);

                // Success to get the XML.
                responseClass.blnSuccess = true;
            }
            catch
            {
                responseClass.strMessage = "Can't find the downloaded file from URL - " + source;
                Console.WriteLine(responseClass.strMessage);
            }

            _logger.DebugFormat("Source responded: " + responseClass.blnSuccess + " - " + responseClass.strMessage);
            
            return responseClass;



            //XDocument xDocument = XDocument.Load(XmlReader.Create(source));

            //return xDocument.ToString();
            //get the root namespace
            //var ns = xDocument.Root.Name.Namespace;

            //Filter active jobs
            //var activeJobs = xDocument.Descendants(ns + "JobRecord");
        }


    }
}
