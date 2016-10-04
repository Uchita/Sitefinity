using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Website.usercontrols.common;
using System.Text;
using System.Data;
using JXTPortal.Entities;
using System.Configuration;

using SocialMedia;

namespace JXTPortal.Website.members
{
    public partial class _default : System.Web.UI.Page
    {
        #region Declare Variables

        private int memberID = 0;

        #endregion

        #region "Properties"

        MembersService _membersService;
        MembersService MembersService
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

        private int selectedtabindex = 1;
        public int SelectedTabIndex
        {
            get { return selectedtabindex; }
            set { selectedtabindex = value; }
        }

        #endregion

        #region Methods

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Member Default");
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadForm();

                //toolkitScriptManager.RegisterPostBackControl(ucMemberFiles1.FindControl("btnSubmit"));
            }

            /**/
        }

        protected void loadForm()
        {
            if (Entities.SessionData.Member != null)
            {
                MembersService service = new MembersService();
                bool blnRequiredPasswordChange = false;

                using (Entities.Members member = service.GetByMemberId(Entities.SessionData.Member.MemberId))
                {
                    if (member != null)
                    {
                        if (member.RequiredPasswordChange.HasValue)
                        {
                            blnRequiredPasswordChange = member.RequiredPasswordChange.Value;
                        }

                        // Update the First name on the front end.
                        //ltHomeMemberName.Text = member.FirstName;                    
                        if (!string.IsNullOrEmpty(Request.Params["tab"]))
                        {
                            Int32.TryParse(Request.Params["tab"], out selectedtabindex);
                        }

                        if (!blnRequiredPasswordChange)
                            SetDynamicPageWithWidgets(member);
                    }
                }

                if (blnRequiredPasswordChange)
                {
                    Response.Redirect("~/member/changepassword.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                }

            }
            else
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                return;
            }


            //if (!string.IsNullOrEmpty(Request.Params["tab"]))
            //{
            //    Int32.TryParse(Request.Params["tab"], out selectedtabindex);
            //}
            /*
            if (Entities.SessionData.Member != null && Entities.SessionData.Member.MemberId > 0)
            {
                memberID = Entities.SessionData.Member.MemberId;

                using (Entities.Members objMembers = MembersService.GetByMemberId(memberID))
                {
                    ltHomeMemberName.Text = objMembers.FirstName;
                }

                if (!string.IsNullOrEmpty(Request.Params["tab"]))
                {
                    Int32.TryParse(Request.Params["tab"], out selectedtabindex);
                }
            }*/
        }

        protected void SetDynamicPageWithWidgets(Entities.Members member)
        {
            ucSystemDynamicPage ucSystemDynamicPage = new ucSystemDynamicPage();
            string strContent = ucSystemDynamicPage.GetContent("SystemPage_MemberDefaultWelcome");

            // Widgets
            if (strContent.Contains(PortalConstants.DynamicNavigation.MEMBER_DASHBOARD_SAVEDJOBS))
                strContent = strContent.Replace(PortalConstants.DynamicNavigation.MEMBER_DASHBOARD_SAVEDJOBS, MemberSavedJobs());
            if (strContent.Contains(PortalConstants.DynamicNavigation.MEMBER_DASHBOARD_JOBALERTS))
                strContent = strContent.Replace(PortalConstants.DynamicNavigation.MEMBER_DASHBOARD_JOBALERTS, MemberJobAlerts());
            if (strContent.Contains(PortalConstants.DynamicNavigation.MEMBER_DASHBOARD_APPLICATIONTRACKER))
                strContent = strContent.Replace(PortalConstants.DynamicNavigation.MEMBER_DASHBOARD_APPLICATIONTRACKER, MemberApplicationTracker());

            // Todo
            if (strContent.Contains(PortalConstants.DynamicNavigation.MEMBER_DASHBOARD_FAVOURITESEARCHES))
                strContent = strContent.Replace(PortalConstants.DynamicNavigation.MEMBER_DASHBOARD_FAVOURITESEARCHES, string.Empty);
            
            // Profile details
            if (strContent.Contains(PortalConstants.DynamicNavigation.MEMBER_DASHBOARD_FIRSTNAME))
                strContent = strContent.Replace(PortalConstants.DynamicNavigation.MEMBER_DASHBOARD_FIRSTNAME, member.FirstName);
            if (strContent.Contains(PortalConstants.DynamicNavigation.MEMBER_DASHBOARD_LASTNAME))
                strContent = strContent.Replace(PortalConstants.DynamicNavigation.MEMBER_DASHBOARD_LASTNAME, member.Surname);
            if (strContent.Contains(PortalConstants.DynamicNavigation.MEMBER_DASHBOARD_LASTMODIFIED))
            {
                strContent = strContent.Replace(PortalConstants.DynamicNavigation.MEMBER_DASHBOARD_LASTMODIFIED,
                                                                            member.LastModifiedDate.HasValue ? member.LastModifiedDate.Value.ToString("dd/MM/yyyy") : "-");
            }

            if (strContent.Contains(PortalConstants.DynamicNavigation.MEMBER_DASHBOARD_PROFILEPICTURE))
            {
                if (!string.IsNullOrWhiteSpace(member.ProfilePicture))
                    strContent = strContent.Replace(PortalConstants.DynamicNavigation.MEMBER_DASHBOARD_PROFILEPICTURE, 
                                                                                string.Format("<img class='thumbnail profilePic' src='{0}' style='border-width:0px;' />", ConfigurationManager.AppSettings["MemberUploadPicturePaths"] + member.ProfilePicture));
                else
                    strContent = strContent.Replace(PortalConstants.DynamicNavigation.MEMBER_DASHBOARD_PROFILEPICTURE, "<img class='thumbnail profilePic' src='//images.jxt.net.au/placeholder.png' style='border-width:0px;' />");
            }


            // *****************CLIENT Specific Shortcodes

            // BULLHORN ONBOARDING SSO
            if (strContent.Contains(PortalConstants.DynamicNavigation.MEMBER_BULLHORN_ONBOARDING_SSO_LINK))
            {
                string strUrl = string.Empty;

                JXTPortal.Client.Bullhorn.BullhornRESTAPI bullhornRestAPI = new JXTPortal.Client.Bullhorn.BullhornRESTAPI(SessionData.Site.SiteId);

                if (bullhornRestAPI.integrations != null && bullhornRestAPI.integrations.BullhornOnBoardingSSO != null)
                {
                    // Get the OnBoarding SSO Url
                    bullhornRestAPI.GetOnBoardingSSO(member, out strUrl);                    
                }

                // Set the Onboarding URL
                if (!string.IsNullOrWhiteSpace(strUrl))
                {
                    strContent = strContent.Replace(PortalConstants.DynamicNavigation.MEMBER_BULLHORN_ONBOARDING_SSO_LINK, string.Format(@"<a href='{0}' target='_blank' class='memberBroadcast-onboarding'>Onboarding Documents</a>", strUrl));
                }
                else
                {
                    strContent = strContent.Replace(PortalConstants.DynamicNavigation.MEMBER_BULLHORN_ONBOARDING_SSO_LINK, string.Empty);                    
                }
            }

            /*
            if (strContent.Contains(PortalConstants.DynamicNavigation.MEMBER_WEVIDEO_VIDEO_PROFILE))
            {
                // Call WeVideo Function
                string Domain = "http://awstest.wevideo.com";
                bool iswevideolive = (ConfigurationManager.AppSettings["IsWeVideoLive"] == "1");
                if (iswevideolive)
                {
                    Domain = "http://www.wevideo.com";
                }

                WeVideo wevideo = new WeVideo(iswevideolive, SessionData.Member.EmailAddress, "mywebcv", "wvssoc-qbtsKAnVviI4O", "iNU482slIeMXXpgQov6xhEdLh7dHpLYkoqo9jiNF");
                bool hasError = true;
                string token = string.Empty;

                if (wevideo.CheckUserExists())
                {
                    token = wevideo.Login();
                }
                else
                {
                    string userdetail = wevideo.CreateUser(SessionData.Member.FirstName, SessionData.Member.Surname, SessionData.Member.EmailAddress, SessionData.Member.MemberId.ToString());
                    if (!string.IsNullOrEmpty(userdetail))
                    {
                        token = wevideo.Login();
                    }
                }

                if (!string.IsNullOrEmpty(token))
                {
                    hasError = false;
                    

                    strContent = strContent.Replace(PortalConstants.DynamicNavigation.MEMBER_WEVIDEO_VIDEO_PROFILE, @"
                        <script type=""text/javascript"">
                         $(document).ready(function(){
                         $.ajax({
                            url : """ + Domain + "/api/3/sso/login/" + token + @""",
                            dataType:""jsonp"",
                         success : function () {  
                            $(""iframe#ifRecordVideo"").attr(""src"",""" + Domain + "/c/" + "mywebcv" + @""");  
                            $(""iframe#ifViewGallery"").attr(""src"",""" + Domain + "/hub/#gallery/" + "mywebcv" + @""");

                            $(""a#btnRecordVideo"").click(function() {
                                $(""iframe#ifRecordVideo"").show();
                                $(""iframe#ifViewGallery"").hide();            
                            });

                            $(""a#btnViewGallery"").click(function() {
                                $(""iframe#ifViewGallery"").show();
                                $(""iframe#ifRecordVideo"").hide();
                            });
                         },
                         error : function () {
                            $(""a#btnRecordVideo"").hide();
                            $(""a#btnViewGallery"").hide();
                            $(""input#hfWeVideo"").val(""WeVideo Login Failed"");
                         },
                         xhrFields: { withCredentials:true }
                         }
                         );
                        });
                        </script>

                        <input id=""hfWeVideo"" type=""hidden"" />
                        <iframe id=""ifRecordVideo"" style=""width: 100%; height: 768px; display: none;"" >
                        </iframe>
                        <iframe id=""ifViewGallery"" style=""width: 100%; height: 768px; display: none;"" >
                        </iframe>");
                }

                if (hasError)
                {
                    strContent = strContent.Replace(PortalConstants.DynamicNavigation.MEMBER_WEVIDEO_VIDEO_PROFILE, string.Empty);
                }
            }
            */

            ltlSystemDynamicPage.Text = strContent;
        }

        #endregion

        #region Widgets

        /// <summary>
        /// Member saved jobs.
        /// </summary>
        /// <returns></returns>
        protected string MemberSavedJobs()
        {
            int totalCount = 0;

            StringBuilder strBuilder = new StringBuilder();
            JobsSavedService JobsSavedService = new JobsSavedService();
            int sitePageCount = Common.Utils.GetAppSettingsInt("MemberSavedJobsPaging");
            using (DataSet dataSetJobSaved = JobsSavedService.GetJobNameByMemberID(SessionData.Member.MemberId, sitePageCount, 1))
            {
                strBuilder.AppendFormat(@"
                <table id='box-table-saved' class='box-table table table-hover'>
				    <thead>
					    <tr>
						    <th>{0}</th>
						    <th>{1}</th>
						    <th>{2}</th>
						    <th>{3}</th>
						    <th>{4}</th>
						    <th>{5}</th>
					    </tr>
				    </thead>
				    <tbody>
			    ", CommonFunction.GetResourceValue("LabelReferenceNumber"), CommonFunction.GetResourceValue("LabelJobTitle"),
             CommonFunction.GetResourceValue("LabelDatePosted"), CommonFunction.GetResourceValue("LabelExpiryDate"), 
             CommonFunction.GetResourceValue("LabelSavedDate"), CommonFunction.GetResourceValue("LabelAction"));

                if (dataSetJobSaved.Tables[0].Rows.Count > 0)
                {
                    totalCount = Convert.ToInt32(dataSetJobSaved.Tables[0].Rows[0]["TotalCount"]);


                    for (int i = 0; i < dataSetJobSaved.Tables[0].Rows.Count; i++)
                    {
                        //ltSavedJobsName.Text = Convert.ToString();
                        //ltRefNo.Text = item["RefNo"].ToString();
                        //ltSavedJobsDate.Text = string.Format("{0:dd/MM/yyy}", item["LastModified"]);
                        strBuilder.AppendFormat(@"				
					                <tr>
						                <td>{2}</td>
                                        <td>{3}</td>
						                <td>{4}</td>
						                <td>{5}</td>
						                <td>{6}</td>
						                <td><a href='{0}' class='boardy-dashboard-action-view' title='{1}'>{1}</a></td>
					                </tr>
				                ", JXTPortal.Common.Utils.GetJobUrl(Convert.ToInt32(dataSetJobSaved.Tables[0].Rows[i]["JobID"]),
                                                                                            dataSetJobSaved.Tables[0].Rows[i]["JobFriendlyName"].ToString()),
                                    CommonFunction.GetResourceValue("LinkButtonView"),
                                    dataSetJobSaved.Tables[0].Rows[i]["RefNo"].ToString(),
                                    dataSetJobSaved.Tables[0].Rows[i]["JobName"].ToString(),
                                    string.Format("{0:dd/MM/yyy}", dataSetJobSaved.Tables[0].Rows[i]["DatePosted"]),
                                    string.Format("{0:dd/MM/yyy}", dataSetJobSaved.Tables[0].Rows[i]["ExpiryDate"]),
                                    string.Format("{0:dd/MM/yyy}", dataSetJobSaved.Tables[0].Rows[i]["LastModified"])
                                    );

                    }


                }
                else
                {
                    strBuilder.AppendFormat(@"<tr><td colspan='6' class='Member-nosave-jobs'>{0}</td></tr>", CommonFunction.GetResourceValue("LabelNoSavedJob"));
                }

                strBuilder.Append(@"</tbody></table>");


                if (totalCount > 5)
                {
                    strBuilder.AppendFormat(@"<!-- Link to page of more than 5 items  -->
			                        <div class='linkMemberBroadcastViewMore'><p><a href='/member/mysavedjobs.aspx'>{0}</a></p></div>", CommonFunction.GetResourceValue("LabelViewMore"));
                }

            }


            return string.Format(@"<!-- SavedJobs -->
<div id='memberBroadcast-SavedJobs' class='memberBroadcast-widget form-all'>
    {0}
</div>", strBuilder.ToString()); //CommonFunction.GetResourceValue("LabelMySavedJobs"), 

        }

        /// <summary>
        /// Member job alerts
        /// </summary>
        /// <returns></returns>
        protected string MemberJobAlerts()
        {
            int totalCount = 0;

            StringBuilder strBuilder = new StringBuilder();
            JobAlertsService aus = new JobAlertsService();
            int sitePageCount = Common.Utils.GetAppSettingsInt("MemberJobAlertPaging");
            using (TList<Entities.JobAlerts> jobalerts = aus.GetByMemberId(SessionData.Member.MemberId, 0, sitePageCount, out totalCount))
            {
                strBuilder.AppendFormat(@"
            <table id='box-table-alerts' class='box-table table table-hover'>
				<thead>
					<tr>
						<!--<th style='width: 10%'>&nbsp; </th>-->
						<th>{0}</th>
						<th>{1}</th>
                        <th>{2}</th>
						<th>{3}</th>
					</tr>
				</thead>
                <tbody>
			", CommonFunction.GetResourceValue("LabelName"), CommonFunction.GetResourceValue("LabelSendEmailAlerts"), 
                CommonFunction.GetResourceValue("LabelDateEntered"), CommonFunction.GetResourceValue("LabelAction"));


                if (jobalerts.Count > 0)
                {

                    foreach (var item in jobalerts)
                    {
                        strBuilder.AppendFormat(@"				
					                <tr>
						                <!--<td></td>-->
						                <td>{1}</td>
                                        <td>{5}</td>
						                <td>{2}</td>
						                <td><a href='/member/createjobalert.aspx?id={0}' class='boardy-dashboard-action-edit' title='{3}'>{3}</a> | <a href='/advancedsearch.aspx?search=1&amp;searchid={0}' class='boardy-dashboard-action-view' title='{4}'>{4}</a></td>
					                </tr>
				                ", item.JobAlertId, item.JobAlertName, string.Format("{0:dd/MM/yyy}", item.LastModified),
                                    CommonFunction.GetResourceValue("LinkButtonEdit"),
                                    CommonFunction.GetResourceValue("LinkButtonView"),
                                    item.AlertActive.HasValue && item.AlertActive.Value ? CommonFunction.GetResourceValue("LabelYes") : CommonFunction.GetResourceValue("LabelNo"));

                    }
                }
                else
                {
                    strBuilder.AppendFormat(@"<tr><td colspan='6' class='Member-nosave-jobs'>{0}</td></tr>", CommonFunction.GetResourceValue("LabelNoJobAlerts"));
                }


                strBuilder.Append(@"</tbody></table>");

                if (totalCount > 5)
                {
                    strBuilder.AppendFormat(@"<!-- Link to page of more than 5 items  -->
			                        <div class='linkMemberBroadcastViewMore'><p><a href='/member/myjobalerts.aspx'>{0}</a></p></div>", CommonFunction.GetResourceValue("LabelViewMore"));
                }


            }


            return string.Format(@"<!-- JobAlert -->
<div id='memberBroadcast-JobAlert' class='memberBroadcast-widget form-all'>
    {0}	
</div>", strBuilder.ToString()); //CommonFunction.GetResourceValue("LabelMyJobAlerts"), 

        }

        /// <summary>
        /// Member saved jobs.
        /// </summary>
        /// <returns></returns>
        protected string MemberApplicationTracker()
        {
            int totalCount = 0;

            StringBuilder strBuilder = new StringBuilder();
            JobApplicationService JobApplicationService = new JobApplicationService();
            int sitePageCount = Common.Utils.GetAppSettingsInt("MemberSavedJobsPaging");
            using (DataSet datasetJobApp = JobApplicationService.GetJobsNameByMemberId(Entities.SessionData.Member.MemberId, sitePageCount, 1))
            {
                strBuilder.AppendFormat(@"
            <table id='box-table-tracker' class='box-table table table-hover'>
				<thead>
					<tr>
						<th>{0}</th>
						<th>{1}</th>
						<th>{2}</th>
						<th>{3}</th>
					</tr>
                </thead>
                <tbody>
			", CommonFunction.GetResourceValue("LabelReferenceNumber"), CommonFunction.GetResourceValue("LabelJobTitle"),
            CommonFunction.GetResourceValue("LabelAdvertiser"), CommonFunction.GetResourceValue("LabelApplicationDate"));

                if (datasetJobApp.Tables[0].Rows.Count > 0)
                {
                    totalCount = Convert.ToInt32(datasetJobApp.Tables[0].Rows[0]["TotalCount"]);


                    for (int i = 0; i < datasetJobApp.Tables[0].Rows.Count; i++)
                    {
                        strBuilder.AppendFormat(@"				
					                <tr>
                                        <td>{1}</td>
						                <td><a href='{0}'>{2}</a></td>
						                <td>{3}</td>
						                <td>{4}</td>
					                </tr>
				                ", JXTPortal.Common.Utils.GetJobUrl(Convert.ToInt32(datasetJobApp.Tables[0].Rows[i]["JobId"].ToString()), datasetJobApp.Tables[0].Rows[i]["JobFriendlyName"].ToString()),
                                    datasetJobApp.Tables[0].Rows[i]["RefNo"].ToString(),
                                    datasetJobApp.Tables[0].Rows[i]["JobName"].ToString(),
                                    datasetJobApp.Tables[0].Rows[i]["CompanyName"].ToString(),
                                    string.Format("{0:dd/MM/yyy}", datasetJobApp.Tables[0].Rows[i]["ApplicationDate"])
                                    );

                    }
                }
                else
                {
                    strBuilder.AppendFormat(@"<tr><td colspan='6' class='Member-nosave-jobs'>{0}</td></tr>", CommonFunction.GetResourceValue("LabelNoJobTracked"));
                }


                strBuilder.Append(@"</tbody></table>");

                if (totalCount > 5)
                {
                    strBuilder.AppendFormat(@"<!-- Link to page of more than 5 items  -->
			                        <div class='linkMemberBroadcastViewMore'><p><a href='/member/applicationtracker.aspx'>{0}</a></p></div>", CommonFunction.GetResourceValue("LabelViewMore"));
                }


            }


            return string.Format(@"<!-- Application Tracker -->
<div id='memberBroadcast-ApplicationTracker' class='memberBroadcast-widget form-all'>	
	{0}	
</div>", strBuilder.ToString()); //CommonFunction.GetResourceValue("LabelMyApplicationTracker"), 

        }

        #endregion

    }
}
