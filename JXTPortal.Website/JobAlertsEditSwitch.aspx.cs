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
using System.Security.AccessControl;
using System.Security.Principal;
using System.Security.Cryptography;
using System.Text;

namespace JXTPortal.Website
{
    public partial class JobAlertsEditSwitch : System.Web.UI.Page
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

        public string EditValidateID
        {
            get
            {
                string _editValidateID = string.Empty;

                if (Request.QueryString["editValidateID"] != null && !string.IsNullOrEmpty(Request.QueryString["editValidateID"]))
                {
                    _editValidateID = Request.QueryString["editValidateID"];
                }

                return _editValidateID;
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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (JobAlertID <= 0)
            {
                // throw new Exception("Invalid Job Alert ID");
                return;
            }

            Entities.JobAlerts ja = JobAlertsService.GetByJobAlertId(JobAlertID);
            if (ja != null)
            {
                string strJobAlertEditURL = Page.ResolveUrl("~/member/CreateJobAlert.aspx") + "?id=" + ja.JobAlertId.ToString();

                if (!string.IsNullOrEmpty(EditValidateID) && ja.SiteId == SessionData.Site.MasterSiteId &&
                    EncryptString(ja.JobAlertId.ToString()).ToLower() == EditValidateID.ToLower())
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

                    ja.EditValidateId = Guid.Empty;
                    JobAlertsService.Update(ja);

                    Response.Redirect(strJobAlertEditURL);
                }
                else
                {
                    //Show Error Message
                    ltlMessage.SetLanguageCode = "LabelJobAlertEditGUIDFailed";
                    return;
                }

                
            }
            else
            {
                // Show Error Message
                ltlMessage.SetLanguageCode = "LabelInvalidJobAlert";
                return;
            }
        }

        const string ACart_SALT = "esPOir";

        private static string EncryptString(string strString)
        {
            SHA1CryptoServiceProvider objSHA = default(SHA1CryptoServiceProvider);
            byte[] bytPassword = null;
            byte[] bytHashed = null;

            UTF8Encoding utf8 = new UTF8Encoding();
            bytPassword = utf8.GetBytes(strString + ACart_SALT);

            objSHA = new SHA1CryptoServiceProvider();
            bytHashed = objSHA.ComputeHash(bytPassword);

            return Convert.ToBase64String(bytHashed);
        }
    }
}
