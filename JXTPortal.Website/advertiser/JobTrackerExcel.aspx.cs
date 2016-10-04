using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Xml;
using System.Data;
using System.IO;
using JXTPortal.Common;

namespace JXTPortal.Website.advertiser
{
    public partial class JobTrackerExcel : System.Web.UI.Page
    {
        #region Declaration

        private JobApplicationService _jobApplicationService;
        private JobsService _jobsService;
        private JobsArchiveService _jobsarchiveservice;
        private const int page_size = 10;
        private int _jobid = 0;
        private int _jobarchvieid = 0;

        #endregion

        #region Properties

        protected int JobID
        {
            get
            {
                if ((Request.QueryString["JobID"] != null))
                {
                    if (int.TryParse((Request.QueryString["JobID"].Trim()), out _jobid))
                    {
                        _jobid = Convert.ToInt32(Request.QueryString["JobID"]);
                    }
                    return _jobid;
                }

                return _jobid;
            }
        }


        protected int JobArchiveID
        {
            get
            {
                if ((Request.QueryString["JobArchiveID"] != null))
                {
                    if (int.TryParse((Request.QueryString["JobArchiveID"].Trim()), out _jobarchvieid))
                    {
                        _jobarchvieid = Convert.ToInt32(Request.QueryString["JobArchiveID"]);
                    }
                    return _jobarchvieid;
                }

                return _jobarchvieid;
            }
        }

        public int CurrentPage
        {

            get
            {
                if (this.ViewState["CurrentPage"] == null)
                    return 0;
                else
                    return Convert.ToInt16(this.ViewState["CurrentPage"].ToString());
            }

            set
            {
                this.ViewState["CurrentPage"] = value;
            }

        }

        private JobApplicationService JobApplicationService
        {
            get
            {
                if (_jobApplicationService == null)
                    _jobApplicationService = new JobApplicationService();
                return _jobApplicationService;
            }
        }

        private JobsService JobsService
        {
            get
            {
                if (_jobsService == null)
                    _jobsService = new JobsService();
                return _jobsService;
            }
        }

        private JobsArchiveService JobsArchiveService
        {
            get
            {
                if (_jobsarchiveservice == null)
                    _jobsarchiveservice = new JobsArchiveService();
                return _jobsarchiveservice;
            }
        }


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionData.AdvertiserUser == null)
            {
                Response.Redirect("~/advertiser/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
            }

            if (JobID < 1 && JobArchiveID < 1)
                Response.Redirect("~/");

            Download();
        }


        private DataSet LoadJobApplications(bool blnDownload = false)
        {
            //int sitePageCount = Common.Utils.GetAppSettingsInt("SitePaging");
            

            DataSet jobapps = null;
            string jobname = string.Empty;

            if (JobID > 0)
            {
                Entities.Jobs job = JobsService.GetByJobId(JobID);

                jobapps = JobApplicationService.GetByAdvertiserIdJobId(SessionData.AdvertiserUser.AdvertiserId, JobID, CurrentPage, 500); // 500 is hardcoded
            }
            else if (JobArchiveID > 0)
            {
                Entities.JobsArchive job = JobsArchiveService.GetByJobId(JobArchiveID);
                jobapps = JobApplicationService.GetByAdvertiserIdJobArchiveId(SessionData.AdvertiserUser.AdvertiserId, JobArchiveID, CurrentPage, 500); // 500 is hardcoded
            }

            
            return jobapps;

        }

        protected void Download()
        {
            XmlDocument xmlDoc = new XmlDocument();
            JXTPortal.JobApplications.FormGenerator formGenerator = new JobApplications.FormGenerator();

            // Todo - In future when we add new custom forms then get the XML from the database.
            GlobalSettingsService GlobalSettingsService = new GlobalSettingsService();
            using (TList<JXTPortal.Entities.GlobalSettings> globalSetting = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
            {
                if (globalSetting.Count > 0)
                {
                    if (globalSetting[0].JobApplicationTypeId.HasValue)
                    {
                        xmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath(formGenerator.FORM_XML_PATH));
                    }
                }
            }

            JXTPortal.JobApplications.JobApplicationExcelModel jobb = new JobApplications.JobApplicationExcelModel();

            DataSet dsApplications = LoadJobApplications(true);

            List<JXTPortal.JobApplications.JobAppCustomValues> applications = new List<JXTPortal.JobApplications.JobAppCustomValues>();

            DataTable dtExport = new DataTable();

            if (dsApplications != null && dsApplications.Tables[0].Rows.Count > 0)
            {
                JXTPortal.JobApplications.Models.AicdSponsorshipModel currentFormModel = new JXTPortal.JobApplications.Models.AicdSponsorshipModel();
                foreach (DataRow item in dsApplications.Tables[0].Rows)
                {
                    //try
                    {
                        currentFormModel.tab8 = JXTPortal.Common.Utils.ProcessXMLFromXmlString(currentFormModel.tab8, item["CustomQuestionnaireXml"].ToString());
                        applications.Add(new JobApplications.JobAppCustomValues(item["JobApplicationID"].ToString(),
                                                                                item["ApplicationDate"].ToString(),
                                                                                ((PortalEnums.JobApplications.ApplicationStatus)(int.Parse(item["ApplicationStatus"].ToString()))).ToString(),
                                                                                item["FirstName"].ToString(),
                                                                                item["Surname"].ToString(),
                                                                                item["EmailAddress"].ToString(),
                                                                                item["MobilePhone"].ToString(),
                                                                                item["PostCode"].ToString(),
                                                                                item["States"].ToString(),
                                                                                currentFormModel.tab8 != null ? currentFormModel.tab8.tab1Values : null));
                    }
                    //catch { }
                }
            }

            jobb = jobb.GenerateExcelModel(xmlDoc, applications);


            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();

            foreach (int item in jobb.headers.Keys)
            {
                dt.Columns.Add(jobb.headers[item], typeof(string));

            }

            foreach (JXTPortal.JobApplications.ExcelDisplayRow item in jobb.rows)
            {

                DataRow NewRow = dt.NewRow();
                int i = 0;
                foreach (int item1 in item.rowValues.Keys)
                {
                    NewRow[i++] = item.rowValues[item1];
                }
                /*
                for (int i = 0; i < item.rowValues.Keys.Count; i++)
                {
                    NewRow[i] = item.rowValues[i];
                }*/
                dt.Rows.Add(NewRow);
            }

            /*
            Response.Clear();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "JobApplications.xls"));
            Response.Charset = "";
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            GridView1.AllowPaging = false;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            if (dtExport.Rows.Count > 0)
            {

                GridView1.RenderControl(htw);
                Response.Write(sw.ToString());
                Response.End();
            }
            */

            //GridView1.DataSource = dt;
            //GridView1.DataBind();
            Utils.ExportAsExcel(ref GridView1, dt);

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
    }
}