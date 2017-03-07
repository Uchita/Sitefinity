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
                    LoadMemberInfo(member);

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

        public void LoadMemberInfo(Entities.Members member)
        {
            ltTitle.Text = HttpUtility.HtmlEncode(member.Title);
            ltFirstName.Text = HttpUtility.HtmlEncode(member.FirstName);
            ltLastName.Text = HttpUtility.HtmlEncode(member.Surname);
            ltHeadline.Text = HttpUtility.HtmlEncode(member.PreferredJobTitle);
            ltlLastModifiedDate.Text = HttpUtility.HtmlEncode(member.LastModifiedDate);

            // Availability Status
            if (member.AvailabilityId.HasValue && member.AvailabilityId > 0)
            {
                ltCurrentSeeking.Text = string.Format(@"<div class='col-sm-6'><h5>{0}:</h5><span class='fa fa-eye highlight'></span><span id='current-status'> {1}</span></div>",
                                                        CommonFunction.GetResourceValue("LabelSeekingStatus"),
                                                        HttpUtility.HtmlEncode(CommonFunction.GetResourceValue(CommonFunction.GetEnumDescription((PortalEnums.Members.CurrentlySeeking)member.AvailabilityId))));
            }
            else
            {
                ltCurrentSeeking.Text = string.Format(@"<div class='col-sm-6'><h5>{0}:</h5><span class='fa fa-eye highlight'></span><span id='current-status missing'> {1}</span></div>",
                                                CommonFunction.GetResourceValue("LabelSeekingStatus"),
                                                HttpUtility.HtmlEncode(CommonFunction.GetResourceValue(CommonFunction.GetEnumDescription(PortalEnums.Members.CurrentlySeeking.NotSeeking))));
            }

            // Availability Date
            if (member.AvailabilityFromDate.HasValue)
            {
                ltAvailableDayFrom.Text = string.Format(@"<div class='col-sm-6'><h5>{0}:</h5><span class='fa fa-clock-o highlight'></span><span id='availability-date'> {1}</span></div>",
                                                CommonFunction.GetResourceValue("LabelAvailabilityDateFrom"), member.AvailabilityFromDate.Value.ToString(SessionData.Site.DateFormat));
            }

            loadSummary(member);
        }

        public void loadSummary(Entities.Members member)
        {
            bool summary = checkSummary(member);

            if (summary)
            {
                ltSummary.Text = HttpUtility.HtmlEncode(member.ShortBio);
            }
            else
            {
                phSectionSummary.Visible = false;
            }
        }

        public bool checkSummary(Entities.Members member)
        {
            string summary = member.ShortBio;

            if (!string.IsNullOrWhiteSpace(summary))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}