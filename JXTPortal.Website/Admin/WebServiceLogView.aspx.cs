using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using JXTPortal.Web.UI;
using JXTPortal;
using JXTPortal.Entities;
using JXTPortal.Common;
namespace JXTPortal.Website.Admin
{
    public partial class WebServiceLogView : System.Web.UI.Page
    {
        public int WebServiceLogID
        {
            get
            {
                int webservicelogid = 0;

                int.TryParse(Request.Params["WebServiceLogID"], out webservicelogid);

                return webservicelogid;
            }
        }

        public string RequestType
        {
            get
            {
                return Request.Params["type"];
            }
        }


        private WebServiceLogService _webservicelogservice;
        private WebServiceLogService WebServiceLogService
        {
            get
            {
                if (_webservicelogservice == null)
                {
                    _webservicelogservice = new WebServiceLogService();
                }
                return _webservicelogservice;
            }
        }

        private AdvertisersService _advertisservice;
        public AdvertisersService AdvertisersService
        {
            get
            {
                if (_advertisservice == null)
                {
                    _advertisservice = new JXTPortal.AdvertisersService();
                }
                return _advertisservice;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionData.AdminUser == null)
            {
                return;
            }

            if (WebServiceLogID > 0 && RequestType != string.Empty)
            {

                // Check if the login is not Admin - if XML is part of this site
                if (!SessionData.AdminUser.isAdminUser)
                {
                    Entities.WebServiceLog webservicelog = WebServiceLogService.CustomGetWebServiceLogByID(WebServiceLogID).FirstOrDefault();

                    Entities.Advertisers advertisers = AdvertisersService.GetByAdvertiserId(webservicelog.AdvertiserId);
                    if (!(advertisers != null && SessionData.Site.SiteId == advertisers.SiteId))
                        return;
                }

                if (RequestType == "request")
                {
                    DataSet ds = WebServiceLogService.CustomGetInputXML(WebServiceLogID);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        string inputxml = ds.Tables[0].Rows[0][0].ToString();
                        if (!string.IsNullOrWhiteSpace(inputxml))
                        {
                            Response.Charset = "";
                            Response.ContentType = "text/xml";

                            if (!SessionData.AdminUser.isAdminUser)
                            {
                                XmlDocument xmldoc = new XmlDocument();
                                xmldoc.LoadXml(inputxml);

                                XmlNode usernamenode = xmldoc.SelectSingleNode("/JobPostRequest/UserName");
                                usernamenode.ParentNode.RemoveChild(usernamenode);
                                XmlNode passwordnode = xmldoc.SelectSingleNode("/JobPostRequest/Password");
                                passwordnode.ParentNode.RemoveChild(passwordnode);

                                Response.Write(xmldoc.InnerXml);
                            }
                            else
                            {
                                Response.Write(inputxml);
                            }
                        }
                    }
                }
                else if (RequestType == "response")
                {
                    DataSet ds = WebServiceLogService.CustomGetOutputResponse(WebServiceLogID);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        string inputxml = ds.Tables[0].Rows[0][0].ToString();
                        if (!string.IsNullOrWhiteSpace(inputxml))
                        {
                            Response.Charset = "";
                            Response.ContentType = "text/xml";

                            Response.Write(inputxml);
                        }
                    }
                }
                else
                {
                    Response.Redirect("WebServiceLog.aspx");
                }
            }
            else
            {
                Response.Redirect("WebServiceLog.aspx");
            }
        }
    }
}