using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Client.Bullhorn;
using System.Net;
using System.IO;

namespace JXTPortal.Website.member.bullhorn
{
    public partial class OnBoarding : System.Web.UI.Page
    {

        /*
https://jobwire.bbo.bullhornstaffing.com/employee/?authenticationKey=04bd9625a1c0a297ec116bf9c2aadc83
Onboarding REST API Integration Key: a623c3d6ad6788761bdf86913ba7a3d1
 
Username: philpsie@hotmail.com
Password: historystretch

Onboarding API Key for the RXT portal: 
1bcf2f2e066d48577c1d910469999a1e

For Jobwire, this will be https://jobwire.bbo.bullhornstaffing.com/api/SingleSignon

For RxT development environemnt, this will be https://rxt.bbo.bullhornstaffing.com/api/SingleSignon
        https://rxt.bbo.bullhornstaffing.com/employee/?authenticationKey=ad3ef513ec70d3c2d391486cca7ec392

Please see below your username and password for RXT onboarding portal. 
URL:  https://rxt.bbo.bullhornstaffing.com
Username: RXTadminuser.ats
Password: harboraddition

         
         */
        protected void Page_Load(object sender, EventArgs e)
        {

            // If already logged in - then redirect to advanced search page.
            //if (SessionData.Member != null)
            //    Response.Redirect("~/member/login.aspx");



            BullhornRESTAPI bullhornRestAPI = new BullhornRESTAPI(SessionData.Site.SiteId);

            if (bullhornRestAPI.integrations != null && bullhornRestAPI.integrations.BullhornOnBoardingSSO != null)
            {
                //bullhornRestAPI.integrations.BullhornOnBoardingSSO

                //"{ apikey: \"1bcf2f2e066d48577c1d910469999a1e\", PartnerID: \"\", xml : \"&lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt;&lt;root&gt;&lt;username&gt;&lt;/username&gt;&lt;integrationID&gt;31943&lt;/integrationID &gt;&lt;role&gt;employee&lt;/role&gt;&lt;keyType&gt;PERMANENT&lt;/keyType&gt;&lt;/root&gt;\""
                string temp = postXMLData(bullhornRestAPI.integrations.BullhornOnBoardingSSO.OnBoardingAPIURL, // + "?apiKey=1bcf2f2e066d48577c1d910469999a1e",
                    @"apiKey=1bcf2f2e066d48577c1d910469999a1e&xml=<?xml version='1.0' encoding='UTF-8'?><root><username></username><integrationID>11</integrationID><role>employee</role><keyType>PERMANENT</keyType></root>
");

                //https://jobwire.bbo.bullhornstaffing.com/?authenticationKey=04bd9625a1c0a297ec116bf9c2aadc83
            }
            else
            {
                Response.Redirect("~/member/default.aspx");
            }
            //bullhornRestAPI.SyncCandidate(member, out errorMsg);
        }

        public string postXMLData(string destinationUrl, string requestXml)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(destinationUrl);
            byte[] bytes;
            bytes = System.Text.Encoding.ASCII.GetBytes(requestXml);
            request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentLength = bytes.Length;
            request.Method = "POST";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                string responseStr = new StreamReader(responseStream).ReadToEnd();
                return responseStr;
            }
            return null;
        }
    }
}