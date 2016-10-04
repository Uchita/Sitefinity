using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using JXTPosterTransform.Library.Common;
using System.Configuration;

namespace JXTPosterTransform.Library.Methods
{
    public class PullXMLFromURL
    {
        public static ResponseClass ProcessXML(string source, string fileName)
        {
            ResponseClass responseClass = new ResponseClass();

            Console.WriteLine("Loading the XML - " + source);

            try
            {
                responseClass.ResponseXML = Utils.GetXMLFromUrl(source);

                //responseClass.ResponseXML = System.IO.File.ReadAllText(@"C:\Users\naveen\Desktop\JXT\Projects\JIP\Stellar.xml");
                
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
