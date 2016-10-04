using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using JXTPortal;
using System.Text.RegularExpressions;

namespace JXTPortal.Common
{
    public class JobClientTracking
    {
        private string _clientname = "None";
        private string _jobapplicationemail = string.Empty;
        private const string BROADBEAN = "Broadbean";

        public string ClientName
        {
            get
            {
                return _clientname;
            }
        }

        public string JobApplicationEmail
        {
            get
            {
                return _jobapplicationemail;
            }
        }

        public JobClientTracking(string jobapplicationemail)
        {
            _jobapplicationemail = jobapplicationemail;

            if (_jobapplicationemail.EndsWith(".aplitrak.com"))
            {
                _clientname = BROADBEAN;
            }
        }

        public string RetrieveEmail(string aggregatorsdomain)
        {
            string email = _jobapplicationemail;
            try
            {
                if (_clientname == BROADBEAN)
                {
                    // look for client id from xml according to the domain
                    XmlDocument broadbeanxml = new XmlDocument();
                    broadbeanxml.Load(HttpContext.Current.Server.MapPath("/xml/BroadbeanAggregators.xml"));

                    foreach (XmlNode node in broadbeanxml.GetElementsByTagName("aggregator"))
                    {
                        string id = node["id"].InnerText;
                        string domain = node["domain"].InnerText;

                        if (aggregatorsdomain == node["domain"].InnerText)
                        {
                            // replacing broadid
                            string[] splits = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
                            splits = splits[0].Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

                            // example - dalec.pba.81614.1527@pbgroup.aplitrak.com - getting .1527@ and replace with the id
                            email = email.Replace(string.Format(".{0}@", splits[splits.Length - 1]), string.Format(".{0}@", id));
                                                        
                            /*
                            if (splits.Length == 3)
                            {
                                string orginalid = splits[2];
                                email = email.Replace(string.Format(".{0}@", orginalid), string.Format(".{0}@", id));
                            }*/

                            break;
                        }
                    }
                }
            }
            catch (Exception ex) { }

            return email;
        }
    }
}
