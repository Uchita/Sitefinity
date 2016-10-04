using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Collections;
using System.Data;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using System.IO;

namespace JXTPortal.Website.advertiser
{
    public partial class JobTrackerApplications : System.Web.UI.Page
    {
        #region Declaration

        private JobApplicationService _jobApplicationService;
        private JobsService _jobsService;
        private JobsArchiveService _jobsarchiveservice;
        private MembersService _memebrsService;
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
        
        private MembersService MembersService
        {
            get
            {
                if (_memebrsService == null)
                    _memebrsService = new MembersService();
                return _memebrsService;
            }
        }


        #endregion

        #region Page

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Job Tracker Applications");
            LoadApplicationStatus();

            plhSuccess.Visible = false;
            plhFailed.Visible = false;
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            if (SessionData.AdvertiserUser == null)
            {
                Response.Redirect("~/advertiser/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
            }

            if (!Page.IsPostBack)
            {
                if (JobID != 0 || JobArchiveID != 0)
                {
                    LoadJobApplications();
                }
                else
                    Response.Redirect("~/advertiser/jobtracker.aspx");

            }

            hypLinkDownload.Text = CommonFunction.GetResourceValue("LabelDownloadApplicantsInExcel");
        }

        #endregion



        private DataSet LoadJobApplications()
        {
            int sitePageCount = Common.Utils.GetAppSettingsInt("SitePaging");
            int totalCount = 0;

            DataSet jobapps = null;
            string jobname = string.Empty;

            if (JobID > 0)
            {
                hypLinkDownload.NavigateUrl = "jobtrackerexcel.aspx?jobid=" + JobID;

                Entities.Jobs job = JobsService.GetByJobId(JobID);
                if (job != null && job.SiteId == SessionData.Site.SiteId && job.AdvertiserId == SessionData.AdvertiserUser.AdvertiserId)
                {
                    litJobName.Text = job.JobName;
                }

                jobapps = JobApplicationService.GetByAdvertiserIdJobId(SessionData.AdvertiserUser.AdvertiserId, JobID, CurrentPage, 500); // 500 is hardcoded
            }
            else if (JobArchiveID > 0)
            {
                hypLinkDownload.NavigateUrl = "jobtrackerexcel.aspx?jobarchiveid=" + JobArchiveID;

                Entities.JobsArchive job = JobsArchiveService.GetByJobId(JobArchiveID);
                if (job != null && job.SiteId == SessionData.Site.SiteId && job.AdvertiserId == SessionData.AdvertiserUser.AdvertiserId)
                {
                    litJobName.Text = job.JobName;
                }
                jobapps = JobApplicationService.GetByAdvertiserIdJobArchiveId(SessionData.AdvertiserUser.AdvertiserId, JobArchiveID, CurrentPage, 500); // 500 is hardcoded
            }

            if (jobapps.Tables[0].Rows.Count > 0)
            {
                hypLinkDownload.Visible = true;

                totalCount = Convert.ToInt32(jobapps.Tables[0].Rows[0]["TotalCount"]);

                rptJobApplication.DataSource = jobapps;
                rptJobApplication.DataBind();

                /*
                if (totalCount > 0)
                {
                    ArrayList pagelist = new ArrayList();
                    int noofpages = totalCount / page_size;
                    if ((totalCount % page_size) != 0)
                        noofpages += 1;

                    for (int i = 0; i < noofpages; i++)
                    {
                        pagelist.Add(i);
                    }

                    if (pagelist.Count > 1)
                    {
                        rptPage.DataSource = pagelist;
                        rptPage.DataBind();
                        rptPage.Visible = true;
                    }
                    else
                    {
                        rptPage.Visible = false;
                    }
                }*/
            }
            else
            {
                ltNoResult.Visible = true;
                phlApplications.Visible = false;
                hypLinkDownload.Visible = false;
            }


            return jobapps;

        }


        #region Events

        protected void rptJobApplication_ItemCommand(object source, RepeaterCommandEventArgs e)
        {/*
            if (e.CommandName == "Select")
            {
                Response.Redirect("~/advertiser/jobapplicationedit.aspx?JobApplicationID=" + e.CommandArgument.ToString());
            }
            else if (e.CommandName == "Note")
            {
                Response.Redirect("advertiserapplicationnote.aspx?jobappid=" + e.CommandArgument.ToString());
            }*/
        }

        protected void rptJobApplication_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView jobapp = (DataRowView)e.Item.DataItem;

                Literal litApplicationDate = e.Item.FindControl("litApplicationDate") as Literal;
                Literal litApplicationDateYYY = e.Item.FindControl("litApplicationDateYYY") as Literal;
                Literal litApplicationStatus = e.Item.FindControl("litApplicationStatus") as Literal;
                Literal litFirstName = e.Item.FindControl("litFirstName") as Literal;
                Literal litSurname = e.Item.FindControl("litSurname") as Literal;
                Literal litState = e.Item.FindControl("litState") as Literal;
                Literal litPostcode = e.Item.FindControl("litPostcode") as Literal;
                Literal litFileDownloaded = e.Item.FindControl("litFileDownloaded") as Literal;
                HyperLink hlEmailAddress = e.Item.FindControl("hlEmailAddress") as HyperLink;
                CheckBox chkApplicationID = e.Item.FindControl("chkApplicationID") as CheckBox;
                //LinkButton lbNote = e.Item.FindControl("lbNote") as LinkButton;
                string strStatus = string.Empty;
                litApplicationDate.Text = (jobapp["ApplicationDate"] == DBNull.Value) ? "" : (Convert.ToDateTime(jobapp["ApplicationDate"])).ToString(SessionData.Site.DateFormat);
                litApplicationDateYYY.Text = (jobapp["ApplicationDate"] == DBNull.Value) ? "" : (Convert.ToDateTime(jobapp["ApplicationDate"])).ToString(SessionData.Site.DateFormat);
                if (jobapp["ApplicationStatus"] != DBNull.Value)
                {
                    strStatus = ((PortalEnums.JobApplications.ApplicationStatus)Convert.ToInt32(jobapp["ApplicationStatus"])).ToString();

                    litApplicationStatus.Text = string.Format("<span class='status-metro status-{0}' title='{1}'>{1}</span>", strStatus.ToLower(), strStatus);
                }
                litFirstName.Text = jobapp["FirstName"].ToString();
                litSurname.Text = jobapp["Surname"].ToString();
                litState.Text = jobapp["States"].ToString();
                litPostcode.Text = jobapp["PostCode"].ToString();
                litFileDownloaded.Text = (jobapp["FileDownloaded"] == DBNull.Value) ? "" : jobapp["FileDownloaded"].ToString().ToLower().Equals("true") ? "<i class='fa fa-check-circle'></i>" : string.Empty;

                hlEmailAddress.Text = jobapp["EmailAddress"].ToString(); // CommonFunction.GetResourceValue("ButtonSend");
                hlEmailAddress.NavigateUrl = "mailto:" + jobapp["EmailAddress"].ToString();

                //chkApplicationID.InputAttributes["class"] = "chkApplicationClass";                
                /*
                if (jobapp["AdvertiserNote"] != null)
                {
                    //lbNote.Text = "Edit";
                    lbNote.Text = CommonFunction.GetResourceValue("LinkButtonEdit");
                    lbNote.CommandName = "EditNote";
                    lbNote.CommandArgument = jobapp["JobApplicationId"].ToString();
                }
                else
                {
                    lbNote.CommandArgument = jobapp["JobApplicationId"].ToString();
                }*/
            }
        }

        #endregion

        /*
        protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                CurrentPage = Convert.ToInt32(e.CommandArgument);
                LoadJobApplications();
            }
        }

        protected void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbPageNo = e.Item.FindControl("lbPageNo") as LinkButton;
                lbPageNo.CommandArgument = (Convert.ToInt32(e.Item.DataItem) + 1).ToString();
                lbPageNo.Text = (Convert.ToInt32(e.Item.DataItem) + 1).ToString();

                if (lbPageNo.CommandArgument == CurrentPage.ToString())
                {
                    lbPageNo.CssClass = "active_tnt_link";
                }
            }
        }*/

        private void LoadApplicationStatus()
        {
            ddlApplicationStatus.DataSource = CommonFunction.GetEnumFormattedNames<PortalEnums.JobApplications.ApplicationStatus>();

            ddlApplicationStatus.DataTextField = "Key";
            //ddlApplicationStatus.DataValueField = "Key";

            ddlApplicationStatus.DataBind();

            ddlApplicationStatus.Items.Insert(0, new ListItem("- Select -", ""));
        }

        protected void lnkDownloadSelected_Click(object sender, EventArgs e)
        {
            plhFailed.Visible = false;
            plhSuccess.Visible = false;

            string jobapplicationIDs = string.Empty;
            HiddenField hiddenApplicationIDs = null;
            CheckBox chkApplicationIDs = null;
            for (int i = 0; i < rptJobApplication.Items.Count; i++)
            {
                chkApplicationIDs = (CheckBox)rptJobApplication.Items[i].FindControl("chkApplicationID");
                hiddenApplicationIDs = (HiddenField)rptJobApplication.Items[i].FindControl("hiddenApplicationID");
                if (chkApplicationIDs.Checked)
                {
                    if (string.IsNullOrWhiteSpace(jobapplicationIDs))
                        jobapplicationIDs = hiddenApplicationIDs.Value;
                    else
                        jobapplicationIDs += "," + hiddenApplicationIDs.Value;
                }
            }

            if (!string.IsNullOrWhiteSpace(jobapplicationIDs))
                DownloadZipVersion(jobapplicationIDs);
            else
            {
                ltNoResult.SetLanguageCode = "LabelSelectOneApplicationToEmail";
                plhFailed.Visible = true;
            }
        }

        protected void lnkEmailSelected_Click(object sender, EventArgs e)
        {
            plhFailed.Visible = false;
            plhSuccess.Visible = false;

            string jobapplicationIDs = string.Empty;
            HiddenField hiddenApplicationIDs = null;
            CheckBox chkApplicationIDs = null;
            for (int i = 0; i < rptJobApplication.Items.Count; i++)
            {
                chkApplicationIDs = (CheckBox)rptJobApplication.Items[i].FindControl("chkApplicationID");
                hiddenApplicationIDs = (HiddenField)rptJobApplication.Items[i].FindControl("hiddenApplicationID");
                if (chkApplicationIDs.Checked)
                {
                    jobapplicationIDs = hiddenApplicationIDs.Value;
                }
            }

            if (!string.IsNullOrWhiteSpace(jobapplicationIDs))
            {
                using (JXTPortal.Entities.JobApplication jobapp = JobApplicationService.GetByJobApplicationId(int.Parse(jobapplicationIDs)))
                {
                    if (jobapp != null && jobapp.MemberId.HasValue && jobapp.MemberId > 0)
                    {
                        using (JXTPortal.Entities.Members member = MembersService.GetByMemberId(jobapp.MemberId.Value))
                        {
                            if (member != null)
                            {
                                int siteid = SessionData.Site.SiteId;
                                using (Entities.Jobs job = JobsService.GetByJobId(Convert.ToInt32(JobID)))
                                {
                                    if (job != null)
                                    {
                                        siteid = job.SiteId;
                                    }
                                }

                                MailService.SendAdvertiserJobApplicationEmail(member, jobapp, new HybridDictionary(), siteid);
                                plhSuccess.Visible = true;
                            }
                        }
                    }
                }
            }
            else
            {
                ltNoResult.SetLanguageCode = "LabelSelectAnApplicationToEmail";
                plhFailed.Visible = true;
            }
        }

        protected void DownloadZipVersion(string jobapplicationIDs)
        {
            if (!string.IsNullOrWhiteSpace(jobapplicationIDs))
            {
                if (JobID > 0)
                {
                    hypLinkDownload.NavigateUrl = "jobtrackerexcel.aspx?jobid=" + JobID;

                    Entities.Jobs job = JobsService.GetByJobId(JobID);
                    if (job != null && job.SiteId == SessionData.Site.SiteId && job.AdvertiserId == SessionData.AdvertiserUser.AdvertiserId)
                    {

                    }
                    else
                    {
                        Response.Redirect("/advertier/default.aspx");
                    }

                }
                else if (JobArchiveID > 0)
                {
                    hypLinkDownload.NavigateUrl = "jobtrackerexcel.aspx?jobarchiveid=" + JobArchiveID;

                    Entities.JobsArchive job = JobsArchiveService.GetByJobId(JobArchiveID);
                    if (job != null && job.SiteId == SessionData.Site.SiteId && job.AdvertiserId == SessionData.AdvertiserUser.AdvertiserId)
                    {

                    }
                    else
                    {
                        Response.Redirect("/advertier/default.aspx");
                    }

                }


                // Retrieve selected Job App Id
                string[] jobappids = (jobapplicationIDs).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                //"50400,52284,51389,51129"

                JobApplicationService jobappservice = new JobApplicationService();
                Entities.JobApplication jobapp = null;
                FilesPath filespath = null;
                List<FilesPath> filespathlist = new List<FilesPath>();

                string ftpclpath = System.Configuration.ConfigurationManager.AppSettings["LocalCoverLetterPath"];
                string ftpresumepath = System.Configuration.ConfigurationManager.AppSettings["LocalResumePath"];
                string ftppdfpath = System.Configuration.ConfigurationManager.AppSettings["LocalPDFPath"];

                jobappservice.CustomUpdateDownloadedFileStatus(jobapplicationIDs);
                LoadJobApplications();

                //ClientScript.RegisterStartupScript(this.GetType(), "ConfirmSubmit", "UpdateStatus('" + jobapplicationIDs + "')",true); // Todo

                foreach (string jobappid in jobappids)
                {
                    // Retrieve all files
                    jobapp = jobappservice.GetByJobApplicationId(Convert.ToInt32(jobappid));
                    if (jobapp != null && (jobapp.JobId == JobID || jobapp.JobArchiveId == JobArchiveID))
                    {
                        filespath = new FilesPath();
                        filespath.CoverLetterPath = (string.IsNullOrWhiteSpace(jobapp.MemberCoverLetterFile)) ? string.Empty : ftpclpath + jobapp.MemberCoverLetterFile;
                        filespath.ResumePath = (string.IsNullOrWhiteSpace(jobapp.MemberResumeFile)) ? string.Empty : ftpresumepath + jobapp.MemberResumeFile;
                        filespath.PDFPath = (string.IsNullOrWhiteSpace(jobapp.ExternalPdfFilename)) ? string.Empty : ftppdfpath + jobapp.ExternalPdfFilename;

                        filespathlist.Add(filespath);
                    }
                }
                string zipfilename = string.Format("/uploads/jobapplications_{0}.zip", DateTime.Now.ToString("yyyyMMddhhmmss"));
                using (ZipOutputStream s = new ZipOutputStream(File.Create(Server.MapPath(zipfilename))))
                {
                    string errormessage = string.Empty;

                    s.SetLevel(9);

                    byte[] buffer = new byte[4096];

                    foreach (FilesPath fp in filespathlist)
                    {
                        if (!string.IsNullOrWhiteSpace(fp.CoverLetterPath) && File.Exists(fp.CoverLetterPath))
                        {
                            ZipEntry entry = new ZipEntry(Path.GetFileName(fp.CoverLetterPath));
                            entry.DateTime = DateTime.Now;
                            s.PutNextEntry(entry);

                            WriteFileToZip(fp.CoverLetterPath, buffer, s);
                        }

                        if (!string.IsNullOrWhiteSpace(fp.ResumePath) && File.Exists(fp.ResumePath))
                        {
                            // Download Cover Resume Doc

                            ZipEntry entry = new ZipEntry(Path.GetFileName(fp.ResumePath));
                            entry.DateTime = DateTime.Now;
                            s.PutNextEntry(entry);

                            WriteFileToZip(fp.ResumePath, buffer, s);

                        }

                        if (!string.IsNullOrWhiteSpace(fp.PDFPath) && File.Exists(fp.PDFPath))
                        {
                            ZipEntry entry = new ZipEntry(Path.GetFileName(fp.PDFPath));
                            entry.DateTime = DateTime.Now;
                            s.PutNextEntry(entry);

                            WriteFileToZip(fp.PDFPath, buffer, s);
                        }
                    }
                }

                if (filespathlist.Count > 0)
                {
                    jobappservice.CustomUpdateDownloadedFileStatus(jobapplicationIDs);

                    this.Response.ContentType = "application/zip";
                    this.Response.AppendHeader("Content-Disposition", "attachment;filename=" + Path.GetFileName(zipfilename));
                    this.Response.TransmitFile(zipfilename);
                    this.Response.End();
                }
            }

        }

        private void WriteFileToZip(string filepath, byte[] buffer, ZipOutputStream s)
        {
            // Zip the file in buffered chunks
            // the "using" will close the stream even if an exception occurs

            using (FileStream streamReader = File.OpenRead(filepath))
            {
                StreamUtils.Copy(streamReader, s, buffer);
            }
            s.CloseEntry();
        }

    }

    internal class FilesPath
    {
        public string CoverLetterPath { get; set; }
        public string ResumePath { get; set; }
        public string PDFPath { get; set; }

        public FilesPath() { }
    }
}