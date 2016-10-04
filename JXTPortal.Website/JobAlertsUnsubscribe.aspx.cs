using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using JXTPortal.Entities;

namespace JXTPortal.Website
{
    public partial class JobAlertsUnsubscribe : System.Web.UI.Page
    {
        #region Properties
        public int JobAlertID
        {
            get
            {
                int _id = -1;

                if (Request.QueryString["searchid"] != null &&
                    !string.IsNullOrEmpty(Request.QueryString["searchid"]) &&
                    Int32.TryParse(Request.QueryString["searchid"], out _id))
                {
                    _id = Convert.ToInt32(Request.QueryString["searchid"]);
                }

                return _id;

            }
        }

        private DynamicPagesService _dynamicPagesService = null;
        private DynamicPagesService DynamicPagesService
        {
            get
            {
                if (_dynamicPagesService == null)
                {
                    _dynamicPagesService = new DynamicPagesService();
                }
                return _dynamicPagesService;
            }
        }

        private JobAlertsService _jobAlertsService = null;

        public JobAlertsService JobAlertsService
        {
            get
            {
                if (_jobAlertsService == null)
                {
                    _jobAlertsService = new JobAlertsService();
                }
                return _jobAlertsService;
            }
        }

        private MembersService _membersService = null;

        public MembersService MembersService
        {
            get
            {
                if (_membersService == null)
                {
                    _membersService = new MembersService();
                }
                return _membersService;
            }
        }

        public Guid UnsubscribeValidateID
        {
            get
            {
                Guid _unsubscribeValidateID = Guid.Empty;

                if (Request.QueryString["UnsubscribeValidateID"] != null)
                {
                    try
                    {
                        _unsubscribeValidateID = new Guid(Request.QueryString["UnsubscribeValidateID"].ToString());
                    }
                    catch
                    {
                        Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.JOBALERT_UNSUBSCRIBE_FAIL, "", "", ""));
                    }
                }

                return _unsubscribeValidateID;

            }
        }

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (JobAlertID <= 0)
            {
                Response.Redirect("");
                return;
            }

            Entities.JobAlerts ja = JobAlertsService.GetByJobAlertId(JobAlertID);
            if (ja != null)
            {
                if (UnsubscribeValidateID != Guid.Empty && ja.UnsubscribeValidateId == UnsubscribeValidateID && ja.SiteId == SessionData.Site.MasterSiteId)
                {
                    int memberid = ja.MemberId;
                    if (SessionData.Member != null)
                    {
                        memberid = SessionData.Member.MemberId;
                    }

                    Entities.Members member = MembersService.GetByMemberId(memberid);

                    if (member.RequiredPasswordChange.HasValue && ((bool)member.RequiredPasswordChange))
                    {
                        // Response.Redirect("~/member/default.aspx?tab=4&ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
                    }

                    SessionService.RemoveAdvertiserUser();
                    SessionService.SetMember(member);

                    ja.AlertActive = false;
                    JobAlertsService.Update(ja);

                    Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.JOBALERT_UNSUBSCRIBE_SUCCESS, "", "", ""));
                }
                else
                {
                    // Show Error Message
                    Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.JOBALERT_UNSUBSCRIBE_FAIL, "", "", ""));
                    return;
                }
            }
            else
            {
                // Show Error Message
                Response.Redirect(DynamicPagesService.GetDynamicPageUrl(JXTPortal.SystemPages.JOBALERT_UNSUBSCRIBE_FAIL, "", "", ""));
                return;
            }
        }
        
    }
}
