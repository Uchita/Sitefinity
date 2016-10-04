using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using JXTPortal.Common;

namespace JXTPortal.Website.member
{
    public partial class EmailMe : System.Web.UI.Page
    {
        #region Declaration

        private JobsService _jobsService;
        private JobAreaService _jobAreaService;
        private JobRolesService _jobRolesService;
        private AreaService _areaService;
        private SiteLocationService _siteLocationService;
        private int _jobid;
        private string _professionProfessionFriendlyName;

        #endregion

        #region Properties

        private JobsService JobsService
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

        private JobAreaService JobAreaService
        {
            get
            {
                if (_jobAreaService == null)
                {
                    _jobAreaService = new JobAreaService();
                }
                return _jobAreaService;
            }
        }

        private JobRolesService JobRolesService
        {
            get
            {
                if (_jobRolesService == null)
                {
                    _jobRolesService = new JobRolesService();
                }
                return _jobRolesService;
            }
        }

        private AreaService AreaService
        {
            get
            {
                if (_areaService == null)
                {
                    _areaService = new AreaService();
                }
                return _areaService;
            }
        }

        private SiteLocationService SiteLocationService
        {
            get
            {
                if (_siteLocationService == null)
                {
                    _siteLocationService = new SiteLocationService();
                }
                return _siteLocationService;
            }
        }

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

        protected string ProfessionFriendlyName
        {
            get
            {
                if (Request.QueryString["profession"] != null)
                {
                    _professionProfessionFriendlyName = Request.QueryString["profession"];
                }
                return _professionProfessionFriendlyName;
            }
        }

        #endregion


        #region Page

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Email Me");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Form.Action = Request.RawUrl;
            string returnurl = Server.UrlEncode(Request.RawUrl);

            if (Entities.SessionData.Member != null)
            {
                MembersService service = new MembersService();
                Entities.Members member = service.GetByMemberId(Entities.SessionData.Member.MemberId);

                if (member.RequiredPasswordChange.HasValue && ((bool)member.RequiredPasswordChange))
                {
                    Response.Redirect("~/member/changepassword.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                }
            }
            else
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                return;
            }

            if (Request.UrlReferrer != null)
            {
                hfBackUrl.Value = Request.UrlReferrer.OriginalString;
            }
            
            if (!Page.IsPostBack)
            {
                if (JobID > 0)
                {
                    SendMemberEmail();
                }
                else
                {
                    Response.Redirect("~/advancedsearch.aspx");
                }
            }
            SetFormValues();
        }


        public void SetFormValues()
        {
            btnBack.Text = CommonFunction.GetResourceValue("ButtonBack");
        }

        #endregion

        #region Methods

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hfBackUrl.Value) && Request.UrlReferrer.OriginalString != hfBackUrl.Value)
            {
                Response.Redirect(hfBackUrl.Value);
            }
            else
            {
                Response.Redirect("~/advancedsearch.aspx");
            }
        }

        private void SendMemberEmail()
        {
            string JobUrl = "";
            Entities.Jobs job = JobsService.GetByJobId(JobID);
            if (job != null)
            {
                Entities.JobArea jobarea = JobAreaService.GetByJobId(job.JobId)[0];
                Entities.Area area = AreaService.GetByAreaId(jobarea.AreaId);
                TList<Entities.SiteLocation> locations = SiteLocationService.GetBySiteId(SessionData.Site.SiteId);
                locations.Filter = "LocationID = " + area.LocationId.ToString();
                JobUrl = Utils.GetJobUrl(job.JobId, job.JobFriendlyName, Request.Params["profession"]);

                int languageid = SessionData.Site.DefaultEmailLanguageId;

                MembersService memberservice = new MembersService();
                Entities.Members member = memberservice.GetByMemberId(SessionData.Member.MemberId);
                if (member != null && member.DefaultLanguageId.HasValue)
                {
                    languageid = member.DefaultLanguageId.Value;
                }

                MailService.SendMemberJobEmail(SessionData.Member.FirstName, SessionData.Member.EmailAddress, job.JobName, JobUrl, SessionData.Member.EmailFormat, languageid);
                litMessage.Text = string.Format(CommonFunction.GetResourceValue("LabelEmailSuccess"), job.JobName);
            }
            else
            {
                Response.Redirect("~/advancedsearch.aspx");
            }
        }

        #endregion
    }
}
