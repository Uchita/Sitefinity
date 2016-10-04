using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JXTPortal.Entities;

namespace JXTPortal.Website.usercontrols.peoplesearch
{
    public partial class ucPublicProfile : System.Web.UI.UserControl
    {
        #region Declaration

        private string _memberurlextension = "";
        private MembersService _membersservice;
        private AvailableStatusService _availableStatusService;

        #endregion

        #region Properties

        protected string MemberUrlExtension
        {
            get
            {
                if ((Request.QueryString["memberurlextension"] != null))
                {
                    _memberurlextension = Request.QueryString["memberurlextension"].ToString();
                }

                return _memberurlextension;
            }
        }

        AvailableStatusService AvailableStatusService
        {
            get
            {
                if (_availableStatusService == null)
                {
                    _availableStatusService = new AvailableStatusService();
                }
                return _availableStatusService;
            }
        }

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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MemberUrlExtension))
            {
                JXTPortal.Entities.Members member = MembersService.GetByMemberId(Convert.ToInt32(MemberUrlExtension));
                if (member != null)
                {
                    litMemberName.Text = string.Format("{0} {1}", member.FirstName, member.Surname);
                    litName.Text = string.Format("{0} {1}", member.FirstName, member.Surname);
                    litEmail.Text = member.EmailAddress.ToString();

                    string availability = "";

                    if (member.AvailabilityId != null && member.AvailabilityId != 0)
                    {
                        JXTPortal.Entities.AvailableStatus avs = AvailableStatusService.GetByAvailableStatusId((int)member.AvailabilityId);
                        if (avs != null)
                            availability = avs.AvailableStatusName;
                    }

                    litStatus.Text = availability;
                    litPublicProfile.Text = string.Format("http://{0}/members/{1}/", SessionData.Site.SiteUrl, MemberUrlExtension);

                }
                else
                {
                    Response.Redirect("~/PeopleSearch.aspx");
                }
            }
            else
            {
                Response.Redirect("~/PeopleSearch.aspx");
            }
        }
    }
}