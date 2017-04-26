using System;
using System.Configuration;
using System.Web.UI;
using System.Xml;
using System.Xml.Linq;

namespace JXTPortal.Web.Services
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LocalWs.jobxadposterSoapClient client = new LocalWs.jobxadposterSoapClient();

            XDocument xml1 = XDocument.Load("c:\\temp\\xmlExamples\\jobsad.xml");
            XElement xml = xml1.Element("JOBXPOSTINGS");

            for (int i = 0; i < 10; i++)
            {
                XElement response = client.PostAds("1", "1", xml, (i % 2 == 0));

                Response.Write(response);
            }
        }
    }
}