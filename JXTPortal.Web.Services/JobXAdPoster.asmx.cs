using JXTPortal.Web.Services.Helpers;
using log4net;
using System;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;

namespace JXTPortal.Web.Services
{
    /// <summary>
    /// Web Service responsible to post Jobs
    /// </summary>
    [WebService(Namespace = "http://www.jobx.com.au/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    public class jobxadposter : WebService
    {
        /// <summary>
        ///	Responsible to post the xml JOB in the server.
        /// </summary>
        /// <param name="username"><c>System.String</c> request user name.</param>
        /// <param name="password"><c>System.String</c> request password.</param>
        /// <param name="jobads"><c>System.Xml.XmlDocument</c> job xml document.</param>
        /// <param name="archiveMissingJobs"><c>System.Boolean</c></param>
        /// <remark>check permission to consuming the resource and post the xml job file.</remark>
        /// <return>It returns the result of post xml file process.</return>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public System.Xml.XmlDocument PostAds(string username, string password, System.Xml.XmlDocument jobads, bool archiveMissingJobs)
        {
            //Loggly resource
            ILog _logger = LogManager.GetLogger("PostAdsWebService");

            try
            {
                _logger.InfoFormat("Request by username {0} and password {1} at {2} initiated.", username, password, DateTime.Now.ToString());

                //Username and password must be informed.
                if (string.IsNullOrWhiteSpace(username) == true || string.IsNullOrWhiteSpace(password) == true)
                    throw new Exception(string.Format("Username: {0} Password: {1} are invalids.", username, password));

                //Get all client nodes available in the xml document
                XmlNodeList clientNodeList = jobads.SelectNodes("JOBXPOSTINGS/CLIENT", null);

                foreach (XmlNode clientNode in clientNodeList)
                {
                    string fileName = string.Format("clientid{0}_{1}.xml", clientNode.Attributes["ID"].Value, DateTime.Now.ToString("yyyyMMddHHmmssfff"));

                    //Save file in output folder
                    Utils.SendXmlDocumentToFTP(Utils.CreateXmlDocumentPerClient(jobads, clientNode), fileName);

                    _logger.InfoFormat("Finished Uploading {0} at ", fileName, DateTime.Now.ToString());
                }

                //Return default response
                return Utils.GenerateResponse(string.Empty);
            }
            catch (Exception ex)
            {
                _logger.Error("An error has occurred.", ex);
                return Utils.GenerateResponse(ex.Message);
            }
        }
    }
}