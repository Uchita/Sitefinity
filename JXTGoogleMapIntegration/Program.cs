using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using JXTPortal;
using JXTPortal.Entities;
using System.Data;
using System.Web.Script.Serialization;


/*-- AddressStatus field - Valid, Refresh, Invalid
-- Webservice address change.
-- Archive move
 
 */
namespace JXTGoogleMapIntegration
{
    class Program
    {
        private static JobsService _jobsService = null;
        public static JobsService JobsService
        {

            get
            {
                if (_jobsService == null)
                {
                    _jobsService = new JobsService();
                }
                return _jobsService;
            }
        }

        //https://maps.googleapis.com/maps/api/geocode/json?address=50%20York%20street,%20Sydney+NSW,+Australia&sensor=false&key=AIzaSyBPUNy8Yc-hHd-gJg7C4mFfft4ek3PYBYU
        static string baseUri = "https://maps.googleapis.com/maps/api/geocode/xml?address={0}&key={1}&sensor=false";

        static void Main(string[] args)
        {
            //RetrieveFormatedAddress("50 York Street Sydney NSW", "AIzaSyBPUNy8Yc-hHd-gJg7C4mFfft4ek3PYBYU");
            //RetrieveFormatedAddress("asdfasdfsdff", "AIzaSyBPUNy8Yc-hHd-gJg7C4mFfft4ek3PYBYU");

            Console.WriteLine("\n*************** Started at " + DateTime.Now);
            string strGeoXMLToUpdate = RetrieveFormatedAddress();

            if (!string.IsNullOrWhiteSpace(strGeoXMLToUpdate))
            {
                Console.WriteLine("Geo XML to Update - \n" + strGeoXMLToUpdate);

                // Update the GEO location in the database
                DataSet ds = JobsService.CustomUpdateGeoLocations(strGeoXMLToUpdate);

                Console.WriteLine("Records updated - " + ds.Tables[0].Rows[0][0]);
            }
            else
            {
                Console.WriteLine("No GEO to Update.");
            }

            Console.WriteLine("\n*************** Finished at " + DateTime.Now);
            //Console.ReadLine();
        }

        /*public static void GetIntegrations()
        {
            IntegrationsService integrationsservice = new IntegrationsService();

            List<Integrations> integrations = integrationsservice.GetAll().Where(s => s.Valid == true).ToList();

        }*/

        public static string RetrieveFormatedAddress()
        {

            JavaScriptSerializer ser = new JavaScriptSerializer();
            JXTPortal.Entities.Models.AdminIntegrations.GoogleMap googleMapIntegration = null;
            string requestUri = string.Empty;
            string strGeoXML = string.Empty;
            StringBuilder strBuilder = new StringBuilder();

            // Get All the Address to Update - SP also updates if it finds existing address geo locations 
            DataSet dsAddressList = JobsService.CustomGetGeoAddressToUpdate();
            using (WebClient wc = new WebClient())
            {
                // For each address get the coordinates.
                foreach (DataRow dr in dsAddressList.Tables[0].Rows)
                {
                    try
                    {
                        // Check if there is an address
                        if (!string.IsNullOrWhiteSpace(dr["Address"].ToString()))
                        {
                            googleMapIntegration = ser.Deserialize<JXTPortal.Entities.Models.AdminIntegrations.GoogleMap>(dr["JsonText"].ToString());

                            requestUri = string.Format(baseUri, dr["Address"], googleMapIntegration.ServerKey);

                            strGeoXML = wc.DownloadString(requestUri);

                            var doc = new XmlDocument();
                            doc.LoadXml(strGeoXML);

                            var xmlElm = XElement.Parse(strGeoXML);


                            // Check status
                            XmlNode status = doc.SelectSingleNode("/GeocodeResponse/status");
                            if (status != null && status.InnerText == "OK")           //ZERO_RESULTS - address not found
                            {
                                // Get location details
                                XmlNodeList GeoResponseList = doc.SelectNodes("/GeocodeResponse/result");

                                if (GeoResponseList != null && GeoResponseList.Count > 0)
                                {
                                    strBuilder.AppendFormat(@"
<Job>
	<Address><![CDATA[{0}]]></Address>
	<JobLatitude>{1}</JobLatitude>
	<JobLongitude>{2}</JobLongitude>
    <AddressStatus>{3}</AddressStatus>
</Job>", 
       dr["Address"], 
       GeoResponseList[0].SelectSingleNode("geometry/location/lat").InnerText, 
       GeoResponseList[0].SelectSingleNode("geometry/location/lng").InnerText, 
       (int)JXTPortal.Entities.PortalEnums.Jobs.JobGeocodeStatus.Valid);

                                    Console.WriteLine("{0} - {1} {2} - {3} ({4})\n",
                                                            dr["Address"],
                                                            GeoResponseList[0].SelectSingleNode("geometry/location/lat").InnerText,
                                                            GeoResponseList[0].SelectSingleNode("geometry/location/lng").InnerText,
                                                            GeoResponseList[0].SelectSingleNode("geometry/location_type").InnerText,
                                                            GetLocationScore(GeoResponseList[0].SelectSingleNode("geometry/location_type").InnerText));
                                    /*
                                    foreach (XmlNode Node in GeoResponseList)
                                    {
                                        Console.WriteLine("{0} - {1} {2} - {3} ({4})\n",
                                                                Node.SelectSingleNode("formatted_address").InnerText,
                                                                Node.SelectSingleNode("geometry/location/lat").InnerText,
                                                                Node.SelectSingleNode("geometry/location/lng").InnerText,
                                                                Node.SelectSingleNode("geometry/location_type").InnerText,
                                                                GetLocationScore(Node.SelectSingleNode("geometry/location_type").InnerText));
                                    }*/
                                }

                            }
                            else
                            {
                                // NOT VALID
                                Console.WriteLine("**** ERROR Address NOT valid :" + dr["Address"] + " - Status = " + status.InnerText);

                                if (status.InnerText.Equals("ZERO_RESULTS"))
                                {
                                    // Send the address is invalid.
                                    strBuilder.AppendFormat(@"
<Job>
	<Address><![CDATA[{0}]]></Address>
	<JobLatitude></JobLatitude>
	<JobLongitude></JobLongitude>
    <AddressStatus>{1}</AddressStatus>
</Job>",
           dr["Address"],
           (int)JXTPortal.Entities.PortalEnums.Jobs.JobGeocodeStatus.Invalid);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("**** ERROR Exception for Address :" + dr["Address"]  + " - " + ex.Message);
                        
                        // TODO didn't say its invalid as there is an exception in the Address.
                    }
                }
            }

            if (strBuilder.Length > 0)
            {
                return string.Format(@"<AddressList>{0}</AddressList>", strBuilder.ToString());
            }

            return string.Empty;
        }

        
        private static int GetLocationScore(string location_type)
        {
            switch (location_type)
            {
                case "ROOFTOP":
                    return 9;
                case "RANGE_INTERPOLATED":
                    return 7;

                case "GEOMETRIC_CENTER":
                    return 6;

                case "APPROXIMATE":
                    return 4;

                default:
                    return 0;

            }
        }
    }
}

/*
public static void RetrieveFormatedAddress(string address, string googleSecret)
{
    string requestUri = string.Format(baseUri, address, googleSecret);

    using (WebClient wc = new WebClient())
    {
        string strGeoXML = wc.DownloadString(requestUri);
                
        var doc = new XmlDocument();
        doc.LoadXml(strGeoXML);

        var xmlElm = XElement.Parse(strGeoXML);


        // Check status
        XmlNode status = doc.SelectSingleNode("/GeocodeResponse/status");
        if (status != null && status.InnerText == "OK")           //ZERO_RESULTS - address not found
        {
            // Get location details
            XmlNodeList names = doc.SelectNodes("/GeocodeResponse/result");

            StringBuilder strBuilder = new StringBuilder();

            foreach (XmlNode Node in names)
            {
                strBuilder.AppendFormat(@"
<Job>
<Address>{0}</Address>
<JobLatitude>{1}</JobLatitude>
<JobLongitude>{2}</JobLongitude>
</Job>", Node.SelectSingleNode("formatted_address").InnerText, Node.SelectSingleNode("geometry/location/lat").InnerText, Node.SelectSingleNode("geometry/location/lng").InnerText);

                Console.WriteLine("{0} - {1} {2} - {3} ({4})\n",
                                        Node.SelectSingleNode("formatted_address").InnerText,
                                        Node.SelectSingleNode("geometry/location/lat").InnerText,
                                        Node.SelectSingleNode("geometry/location/lng").InnerText,
                                        Node.SelectSingleNode("geometry/location_type").InnerText,
                                        GetLocationScore(Node.SelectSingleNode("geometry/location_type").InnerText));
            }

            if (strBuilder.Length > 0)
            {
                string.Format(@"<AddressList>{0}</AddressList>", strBuilder.ToString());
            }

        }
        else
        {
            // NOT VALID
            Console.WriteLine("Not valid :" + address);
        }
    }
}*/