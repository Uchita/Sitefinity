using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Common;
using JXTPortal.Entities;

using JXTPortal.Service.Dapper;
using JXTPortal.Service.Dapper.Models;
using JXTPortal.Data.Dapper.Entities.ScreeningQuestions;

namespace JXTPortal.Website.advertiser
{
    public partial class JobApplicationEdit : Page
    {
        #region Declaration

        private int _jobappid = 0;
        private JobApplicationService _jobApplicationService;
        private SitesService _sitesservice;
        private JobsService _jobsService;
        private JobsArchiveService _jobsArchiveService;
        private string bucketName = ConfigurationManager.AppSettings["AWSS3BucketName"];
        private string customFolder;
        #endregion

        #region Properties

        public IFileManager FileManagerService { get; set; }

        private MembersService _membersservice = null;

        private MembersService MembersService
        {
            get
            {
                if (_membersservice == null)
                {
                    _membersservice = new MembersService();
                }
                return _membersservice;
            }
        }

        protected int JobApplicationID
        {
            get
            {
                if ((Request.QueryString["JobApplicationID"] != null))
                {
                    if (int.TryParse((Request.QueryString["JobApplicationID"].Trim()), out _jobappid))
                    {
                        _jobappid = Convert.ToInt32(Request.QueryString["JobApplicationID"]);
                    }
                    return _jobappid;
                }

                return _jobappid;
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

        private SitesService SitesService
        {
            get
            {
                if (_sitesservice == null)
                    _sitesservice = new SitesService();
                return _sitesservice;
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
                if (_jobsArchiveService == null)
                    _jobsArchiveService = new JobsArchiveService();
                return _jobsArchiveService;
            }
        }

        public IJobApplicationScreeningAnswersService JobApplicationScreeningAnswersService { get; set; }

        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Edit Job Application");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SessionData.Site.IsUsingS3)
            {
                customFolder = ConfigurationManager.AppSettings["FTPCustomJobApplications"];

                string ftphosturl = ConfigurationManager.AppSettings["FTPHost"];
                string ftpusername = ConfigurationManager.AppSettings["FTPJobApplyUsername"];
                string ftppassword = ConfigurationManager.AppSettings["FTPJobApplyPassword"];
                FileManagerService = new FTPClientFileManager(ftphosturl, ftpusername, ftppassword);
            }
            else
            {
                customFolder = ConfigurationManager.AppSettings["AWSS3CustomJobApplicationsPath"];
            }

            if (SessionData.AdvertiserUser == null)
            {
                Response.Redirect("~/advertiser/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
            }

            if (JobApplicationID == 0)
            {
                Response.Redirect("~/advertiser/jobtracker.aspx");
            }

            if (!Page.IsPostBack)
            {
                LoadApplicationStatus();
                LoadApplicantGrade();
                LoadJobApplication();
                LoadScreeningQuestions();
            }

            SetFormValues();
        }

        public void SetFormValues()
        {
            btnBack.Text = CommonFunction.GetResourceValue("ButtonBack");
            btnUpdate.Text = CommonFunction.GetResourceValue("ButtonUpdate");
            dataResume.Text = CommonFunction.GetResourceValue("LabelDownload");
            dataCoverLetter.Text = CommonFunction.GetResourceValue("LabelDownload");
            dataPDF.Text = CommonFunction.GetResourceValue("LabelDownload");
        }

        private void LoadScreeningQuestions()
        {
            JobApplicationScreeningAnswerDetail jobApplicationScreeningAnswerDetail = JobApplicationScreeningAnswersService.SelectByJobApplicationId(JobApplicationID);
            if (jobApplicationScreeningAnswerDetail.JobApplicationScreeningAnswers.Count > 0)
            {
                phScreeningQuestions.Visible = true;

                rptScreeningQuestions.DataSource = jobApplicationScreeningAnswerDetail.JobApplicationScreeningAnswers;
                rptScreeningQuestions.DataBind();
            }
            else
            {
                phScreeningQuestions.Visible = false;
            }
        }

        protected void rptScreeningQuestions_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltQuestion = e.Item.FindControl("ltQuestion") as Literal;
                Literal ltAnswer = e.Item.FindControl("ltAnswer") as Literal;

                JobApplicationScreeningAnswer answer = e.Item.DataItem as JobApplicationScreeningAnswer;

                ltQuestion.Text = HttpUtility.HtmlEncode(answer.QuestionTitle);
                ltAnswer.Text = HttpUtility.HtmlEncode(answer.Answer);
            }
        }

        private void LoadApplicationStatus()
        {
            ddlApplicationStatus.DataSource = CommonFunction.GetEnumFormattedNames<PortalEnums.JobApplications.ApplicationStatus>();

            ddlApplicationStatus.DataTextField = "Key";
            ddlApplicationStatus.DataValueField = "Value";

            ddlApplicationStatus.DataBind();
        }

        private void LoadApplicantGrade()
        {
            ddlApplicantGrade.Items.Add(new ListItem(CommonFunction.GetResourceValue("LabelSelectGrade"), "0"));

            for (int i = 1; i <= 5; i++)
            {
                ddlApplicantGrade.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        private void LoadJobApplication()
        {
            if (JobApplicationID > 0)
            {
                using (JobApplication jobapp = JobApplicationService.GetByJobApplicationId(JobApplicationID))
                {

                    if (jobapp.SiteIdReferral != SessionData.Site.SiteId)
                    {
                        Entities.Sites site = SitesService.GetBySiteId((int)jobapp.SiteIdReferral);
                        dataSite.Text = site.SiteName;

                        pnlSite.Visible = true;
                    }

                    if (jobapp != null)
                    {
                        if (!JobsService.isAdvertiserJob(jobapp.JobId, jobapp.JobArchiveId))
                        {
                            Response.Redirect("~/advertiser/jobtracker.aspx");
                        }

                        if (jobapp.JobArchiveId.HasValue)
                        {
                            using (Entities.JobsArchive job = JobsArchiveService.GetByJobId((int)jobapp.JobArchiveId))
                            {
                                dataJobTitle.Text = job.JobName;
                            }
                        }
                        else
                        {
                            using (Entities.Jobs job = JobsService.GetByJobId((int)jobapp.JobId))
                            {
                                dataJobTitle.Text = job.JobName;
                            }
                        }

                        if (jobapp.ApplicationDate != null)
                        {
                            dataApplicationDate.Text = jobapp.ApplicationDate.Value.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                        }

                        if (jobapp.MemberResumeFile != null)
                        {
                            dataResume.NavigateUrl = "~/getapplicationfile.aspx?id=" + jobapp.JobApplicationId.ToString() + "&doctype=" + ((int)PortalEnums.JobApplications.DocumentType.Resume).ToString(); ;
                        }
                        else
                        {
                            dataResume.Visible = false;
                            litResume.Text = CommonFunction.GetResourceValue("LabelNA");
                        }

                        if (jobapp.MemberCoverLetterFile != null)
                        {
                            dataCoverLetter.NavigateUrl = "~/getapplicationfile.aspx?id=" + jobapp.JobApplicationId.ToString() + "&doctype=" + ((int)PortalEnums.JobApplications.DocumentType.CoverLetter).ToString(); ;
                        }
                        else
                        {
                            dataCoverLetter.Visible = false;
                            litCoverLetter.Text = CommonFunction.GetResourceValue("LabelNA"); ;
                        }

                        if (!string.IsNullOrWhiteSpace(jobapp.ExternalPdfFilename))
                        {
                            phPDF.Visible = true;
                            dataPDF.CommandArgument = jobapp.ExternalPdfFilename;
                        }
                        else
                        {
                            phPDF.Visible = false;
                        }

                        //if (jobapp.ApplicationStatus != null)
                        //{
                        //    dataApplicationStatus.Text = ((PortalEnums.JobApplications.ApplicationStatus)((int)jobapp.ApplicationStatus)).ToString();
                        //}

                        //if (jobapp.ApplicantGrade != null)
                        //{
                        //    dataApplicantGrade.Text = jobapp.ApplicantGrade.ToString();
                        //}

                        //if (jobapp.LastViewedDate != null)
                        //{
                        //    dataLastViewedDate.Text = jobapp.LastViewedDate.ToString();
                        //}

                        if (jobapp.MemberId.HasValue)
                        {
                            Entities.Members member = MembersService.GetByMemberId(jobapp.MemberId.Value);
                            if (member != null)
                            {
                                dataFirstName.Text = member.FirstName;
                                dataSurname.Text = member.Surname;
                                if (member.EmailAddress != null)
                                {
                                    dataEmailAddress.Text = member.EmailAddress;
                                    dataEmailAddress.NavigateUrl = "mailto:" + member.EmailAddress;
                                }


                                if (!string.IsNullOrEmpty(member.MobilePhone))
                                {
                                    dataMobilePhone.Text = member.MobilePhone;
                                }
                                else
                                {
                                    dataMobilePhone.Text = CommonFunction.GetResourceValue("LabelNA");
                                }
                            }
                        }


                        if (!string.IsNullOrEmpty(jobapp.AdvertiserNote))
                        {
                            dataNote.Text = Server.HtmlEncode(jobapp.AdvertiserNote).Replace("\n", "<br />");
                        }
                        else
                        {
                            dataNote.Text = CommonFunction.GetResourceValue("LabelNA");
                        }

                        if (jobapp.ApplicationStatus != null)
                        {
                            ddlApplicationStatus.SelectedValue = jobapp.ApplicationStatus.ToString();
                        }

                        if (jobapp.ApplicantGrade != null)
                        {
                            ddlApplicantGrade.SelectedValue = jobapp.ApplicantGrade.ToString();
                        }

                        if (!string.IsNullOrEmpty(jobapp.UrlReferral))
                        {
                            dataReferral.Text = jobapp.UrlReferral;
                        }
                        else
                        {
                            dataReferral.Text = CommonFunction.GetResourceValue("LabelNA");
                        }
                    }
                    else
                    {
                        Response.Redirect("~/advertiser/jobtrackerapplications.aspx" + GetReturnParam(jobapp));
                    }
                }
            }
        }

        protected void dataPDF_Click(object sender, EventArgs e)
        {
            string errormessage = string.Empty;
            Stream downloadedfile = null;

            downloadedfile = FileManagerService.DownloadFile(bucketName, customFolder, dataPDF.CommandArgument, out errormessage);


            if (string.IsNullOrEmpty(errormessage) && downloadedfile.Length > 0)
            {
                downloadedfile.Position = 0;
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment;filename=" + dataPDF.CommandArgument);
                Response.BinaryWrite(((MemoryStream)downloadedfile).ToArray());
                Response.End();
            }
        }

        private string GetReturnParam(JobApplication jobapp)
        {

            if (jobapp.JobArchiveId.HasValue && jobapp.JobArchiveId > 0)
            {
                return "?jobarchiveid=" + jobapp.JobArchiveId.ToString();
            }
            else
            {
                return "?jobid=" + jobapp.JobId.ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (JobApplication jobapp = JobApplicationService.GetByJobApplicationId(JobApplicationID))
            {
                if (jobapp != null)
                {

                    jobapp.ApplicationStatus = Convert.ToInt32(ddlApplicationStatus.SelectedValue);
                    if (ddlApplicantGrade.SelectedValue != "0")
                    {
                        jobapp.ApplicantGrade = Convert.ToInt32(ddlApplicantGrade.SelectedValue);
                    }
                    jobapp.LastViewedDate = DateTime.Now;
                    JobApplicationService.Save(jobapp);
                    Response.Redirect("~/advertiser/jobtrackerapplications.aspx" + GetReturnParam(jobapp));
                }
                else
                {
                    Response.Redirect("~/advertiser/jobtrackerapplications.aspx" + GetReturnParam(jobapp));
                }
            }
        }

        //protected void btnBack_Click(object sender, EventArgs e)
        //{
        //    using (JobApplication jobapp = JobApplicationService.GetByJobApplicationId(JobApplicationID))
        //    {
        //        if (jobapp != null)
        //        {
        //            Response.Redirect("~/advertiser/jobtrackerapplications.aspx" + GetReturnParam(jobapp));
        //        }
        //    }
        //}

        protected void btnManage_Click(object sender, EventArgs e)
        {
            using (JobApplication jobapp = JobApplicationService.GetByJobApplicationId(JobApplicationID))
            {
                if (jobapp != null)
                {
                    Response.Redirect("~/advertiser/jobtrackerapplications.aspx" + GetReturnParam(jobapp));
                }
            }
        }
    }
}
