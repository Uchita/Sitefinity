using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using JXTPortal.Entities;
using JXTPortal;

namespace JXTPortal.Website.Admin
{
    public partial class WebServiceLogDetail : System.Web.UI.Page
    {
        #region Properties
        private WebServiceLogService _webservicelogservice;
        private AdvertisersService _advertisservice;
        #endregion

        #region Properties
        public int WebServiceLogID
        {
            get
            {
                int webservicelogid = 0;

                int.TryParse(Request.Params["WebServiceLogID"], out webservicelogid);

                return webservicelogid;
            }
        }

        public WebServiceLogService WebServiceLogService
        {
            get
            {
                if (_webservicelogservice == null)
                {
                    _webservicelogservice = new JXTPortal.WebServiceLogService();
                }
                return _webservicelogservice;
            }
        }

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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Web Service Log Detail";

            if (SessionData.AdminUser == null)
            {
                return;
            }

            if (WebServiceLogID <= 0)
            {
                Response.Redirect("WebServiceLog.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    LoadWebServiceLogDetail();
                }

                ScriptManager scriptMan = AjaxControlToolkit.ToolkitScriptManager.GetCurrent(this);
                UpdatePanel up = scriptMan.FindControl("updatePanel") as UpdatePanel;

                scriptMan.RegisterPostBackControl(lbDownloadRequest);
                scriptMan.RegisterPostBackControl(lbDownloadResponse);

                hlViewRequest.NavigateUrl = string.Format("WebServiceLogView.aspx?type=request&webservicelogid={0}", WebServiceLogID);
                hlViewResponse.NavigateUrl = string.Format("WebServiceLogView.aspx?type=response&webservicelogid={0}", WebServiceLogID);
            }
        }

        private void LoadWebServiceLogDetail()
        {
            TList<JXTPortal.Entities.WebServiceLog> webservicelogs = WebServiceLogService.CustomGetWebServiceLogByID(WebServiceLogID);
            if (webservicelogs.Count == 0)
            {
                Response.Redirect("WebServiceLog.aspx");
            }
            else
            {
                JXTPortal.Entities.WebServiceLog webservicelog = webservicelogs[0];

                // Check if the login is not Admin - if XML is part of this site
                if (!SessionData.AdminUser.isAdminUser) 
                {
                    Entities.Advertisers advertisers = AdvertisersService.GetByAdvertiserId(webservicelog.AdvertiserId);
                    if (!(advertisers != null && SessionData.Site.SiteId == advertisers.SiteId))
                        Response.Redirect("WebServiceLog.aspx");
                }

                ltDateStart.Text = webservicelog.CreatedDate.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                ltDateEnd.Text = webservicelog.FinishedDate.Value.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");

                ltAllCount.Text = webservicelog.TotalSent.ToString();
                ltAddedCount.Text = webservicelog.TotalInserted.ToString();
                ltUpdatedCount.Text = webservicelog.TotalUpdated.ToString();
                ltArchivedCount.Text = webservicelog.TotalArchived.ToString();
                ltFailedCount.Text = webservicelog.TotalFailed.ToString();

                try
                {
                    string outputresponse = webservicelog.OutputResponse;

                    XmlDocument outputdoc = new XmlDocument();
                    outputdoc.LoadXml(outputresponse);

                    JXTPortal.Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(webservicelog.AdvertiserId);
                    if (advertiser != null)
                    {
                        ltAdvertiserName.Text = advertiser.CompanyName;
                    }

                    ltSiteName.Text = SessionData.Site.SiteName;

                    List<JobPostingJob> jobpostingjobs = new List<JobPostingJob>();

                    XmlNodeList actionlists = outputdoc.GetElementsByTagName("JOB");
                    foreach (XmlNode xmlnode in actionlists)
                    {
                        JobPostingJob jobpostingjob = new JobPostingJob();
                        jobpostingjob.Action = xmlnode.ChildNodes[0].InnerText;
                        jobpostingjob.RefNo = xmlnode.ChildNodes[1].InnerText;
                        jobpostingjob.Url = xmlnode.ChildNodes[2].InnerText;
                        jobpostingjob.Title = xmlnode.ChildNodes[3].InnerText;
                        jobpostingjob.Message = xmlnode.ChildNodes[4].InnerText;

                        jobpostingjobs.Add(jobpostingjob);
                    }

                    if (jobpostingjobs.Count > 0)
                    {
                        ltErrorMessage.Text = string.Empty;
                    }
                    else
                    {
                        XmlNodeList errorresultlists = outputdoc.GetElementsByTagName("ERRORRESULT");
                        if (errorresultlists.Count > 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            XmlNodeList errorlists = outputdoc.GetElementsByTagName("ERROR");
                            foreach (XmlNode xmlnode in errorlists)
                            {
                                sb.AppendLine(xmlnode.InnerText);
                            }

                            ltErrorMessage.Text = string.Format("<p>{0}</p>", sb.ToString());
                        }
                    }

                    rptJobs.DataSource = (jobpostingjobs.Count > 0) ? jobpostingjobs : null;
                    rptJobs.DataBind();
                }
                catch (Exception ex)
                {
                }
            }
        }

        protected void rptJobs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                JobPostingJob jobpostingjob = e.Item.DataItem as JobPostingJob;

                Literal ltListHeader = e.Item.FindControl("ltListHeader") as Literal;
                Literal ltRefNo = e.Item.FindControl("ltRefNo") as Literal;
                Literal ltTitle = e.Item.FindControl("ltTitle") as Literal;
                Literal ltAction = e.Item.FindControl("ltAction") as Literal;
                Literal ltAdditionalInfo = e.Item.FindControl("ltAdditionalInfo") as Literal;
                Literal ltUrl = e.Item.FindControl("ltUrl") as Literal;


                ltListHeader.Text = string.Format("<li class=\"mix {0}\" data-posting=\"{1}\" data-name=\"{2}\" data-ref=\"{3}\">", jobpostingjob.Action.ToLower(), (int)((eActionType)Enum.Parse(typeof(eActionType), jobpostingjob.Action)), jobpostingjob.RefNo.Replace("\"", "'"), jobpostingjob.RefNo.Replace("\"", "'"));

                ltRefNo.Text = HttpUtility.HtmlEncode(jobpostingjob.RefNo);
                ltTitle.Text = HttpUtility.HtmlEncode(jobpostingjob.Title);
                ltAction.Text = jobpostingjob.Action;
                ltAdditionalInfo.Text = GetWarningText(jobpostingjob.Message);
                ltUrl.Text = string.Format("<a href=\"{0}\" target=\"_blank\">", jobpostingjob.Url);
            }
        }

        private string GetWarningText(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                string[] splits = text.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                if (splits.Length > 1)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<ul>");

                    foreach (string s in splits)
                    {
                        if (!string.IsNullOrWhiteSpace(s))
                        {
                            sb.Append("<li>" + HttpUtility.HtmlEncode(s) + "</li>");
                        }
                    }

                    sb.Append("</ul>");

                    text = sb.ToString();
                }
            }

            return text;
        }

        private enum eActionType
        {
            ERROR = 1,
            ARCHIVE = 2,
            INSERT = 3,
            UPDATE = 4
        }

        internal class JobPostingJob
        {
            public string Action { get; set; }
            public string RefNo { get; set; }
            public string Url { get; set; }
            public string Title { get; set; }
            public string Message { get; set; }

            public JobPostingJob() { }
        }

        protected void lbDownloadRequest_Click(object sender, EventArgs e)
        {
                DataSet ds = WebServiceLogService.CustomGetInputXML(WebServiceLogID);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    string inputxml = ds.Tables[0].Rows[0][0].ToString();
                    if (!string.IsNullOrWhiteSpace(inputxml))
                    {
                        Response.Clear();
                        Response.AddHeader("content-disposition", string.Format("attachment;filename=InputXML_{0}.xml", WebServiceLogID));
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

                        Response.End();
                    }
                }

        }

        protected void lbDownloadResponse_Click(object sender, EventArgs e)
        {
            DataSet ds = WebServiceLogService.CustomGetOutputResponse(WebServiceLogID);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                string outputresponse = ds.Tables[0].Rows[0][0].ToString();
                if (!string.IsNullOrWhiteSpace(outputresponse))
                {
                    Response.Clear();
                    Response.AddHeader("content-disposition", string.Format("attachment;filename=OutputResponse_{0}.xml", WebServiceLogID));
                    Response.Charset = "";
                    Response.ContentType = "text/xml";

                    Response.Write(outputresponse);

                    Response.End();
                }
            }
        }
    }
}