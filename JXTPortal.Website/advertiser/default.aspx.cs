using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Website.usercontrols.common;
using System.Text;
using JXTPortal.Entities;
using System.Data;
using System.Configuration;
using JXTPortal.Website.usercontrols.navigation;
using System.IO;

namespace JXTPortal.Website.advertiser
{
    public partial class _default : System.Web.UI.Page
    {
        #region Declarations

        private int AdvertiserUserId = 0;
        private int AdvertiserId = 0;
        private int MAX_EXPIRY_DATE = -90;

        private DateTime? AdvUserLastModifiedDate;

        #endregion

        #region Properties

        AdvertiserUsersService _AdvertiserUsersService;
        AdvertiserUsersService AdvUserService
        {
            get
            {
                if (_AdvertiserUsersService == null)
                {
                    _AdvertiserUsersService = new AdvertiserUsersService();
                }

                return _AdvertiserUsersService;
            }
        }

        AdvertisersService _AdvertiserService;
        AdvertisersService AdvService
        {
            get
            {
                if (_AdvertiserService == null)
                {
                    _AdvertiserService = new AdvertisersService();
                }

                return _AdvertiserService;
            }
        }

        InvoiceService _InvoiceService;
        InvoiceService InvService
        {
            get
            {
                if (_InvoiceService == null)
                {
                    _InvoiceService = new InvoiceService();
                }

                return _InvoiceService;
            }
        }

        private GlobalSettingsService _GlobalSettingsService;
        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_GlobalSettingsService == null)
                    _GlobalSettingsService = new GlobalSettingsService();
                return _GlobalSettingsService;
            }
        }

        #endregion

        #region Methods

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Advertiser Default");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadForm();
            }
        }

        protected void loadForm()
        {
            if (Entities.SessionData.AdvertiserUser == null)
            {
                Response.Redirect("~/advertiser/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                return;
            }

            if (Entities.SessionData.AdvertiserUser != null && Entities.SessionData.AdvertiserUser.AdvertiserId > 0)
            {
                AdvertiserUserId = Entities.SessionData.AdvertiserUser.AdvertiserUserId;

                using (Entities.AdvertiserUsers advu = AdvUserService.GetByAdvertiserUserId(AdvertiserUserId))
                {
                    if (advu != null)
                    {
                        //ltHomeAdvertiserName.Text = advu.FirstName;

                        AdvUserLastModifiedDate = advu.LastModified;
                    }
                }
            }

            SetDynamicPageWithWidgets(SessionData.AdvertiserUser);

        }

        protected void SetDynamicPageWithWidgets(SessionAdvertiserUser advertiser)
        {
            ucSystemDynamicPage ucSystemDynamicPage = new ucSystemDynamicPage();
            string strContent = ucSystemDynamicPage.GetContent("SystemPage_AdvertiserDefaultWelcome");

            // Widgets

            //Dropdown links
            if (strContent.Contains(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_DROPDOWN_LINKS))
                strContent = strContent.Replace(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_DROPDOWN_LINKS, AdvertiserDropdownLinks(advertiser.Username));

            //Available Credits
            if (strContent.Contains(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_AVAILABLE_CREDITS))
                strContent = strContent.Replace(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_AVAILABLE_CREDITS, AdvertiserAvailCredits());

            //Current jobs
            if (strContent.Contains(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_CURRENT_JOBS))
                strContent = strContent.Replace(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_CURRENT_JOBS, AdvertiserCurrentJobs());

            //application trackers
            if (strContent.Contains(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_JOB_TRACKER))
                strContent = strContent.Replace(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_JOB_TRACKER, AdvertiserApplicationTracker());

            //draft jobs
            if (strContent.Contains(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_DRAFT_JOBS))
                strContent = strContent.Replace(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_DRAFT_JOBS, AdvertiserDraftJobs());

            //archived jobs
            if (strContent.Contains(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_ARCHIVED))
                strContent = strContent.Replace(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_ARCHIVED, AdvertiserArchivedJobs());

            // Statistics
            if (strContent.Contains(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_STATISTICS))
                strContent = strContent.Replace(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_STATISTICS, AdvertiserStatistics());

            // Suspended Jobs
            if (strContent.Contains(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_SUSPENDED_JOBS))
                strContent = strContent.Replace(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_SUSPENDED_JOBS, AdvertiserSuspendedJobs());

            // Profile details
            if (strContent.Contains(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_FIRSTNAME))
                strContent = strContent.Replace(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_FIRSTNAME, advertiser.FirstName);
            if (strContent.Contains(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_LASTNAME))
                strContent = strContent.Replace(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_LASTNAME, advertiser.LastName);

            if (strContent.Contains(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_LASTMODIFIED))
                strContent = strContent.Replace(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_LASTMODIFIED, AdvUserLastModifiedDate.HasValue ? AdvUserLastModifiedDate.Value.ToString(SessionData.Site.DateFormat) : string.Empty);

            if (strContent.Contains(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_PROFILEPICTURE))
                strContent = strContent.Replace(PortalConstants.DynamicNavigation.ADVERTISER_DASHBOARD_PROFILEPICTURE,
                                   string.Format("<img class='thumbnail profilePic' src='/getfile.aspx?advertiserid={0}' style='border-width:0px;' />", advertiser.AdvertiserId));

            ltlSystemDynamicPage.Text = strContent;
        }

        #endregion

        #region Widgets

        /// <summary>
        /// Dropdown links for members
        /// </summary>
        /// <returns></returns>
        protected string AdvertiserDropdownLinks(string advertiserUsername)
        {
            //define full virtual path
            var fullPath = "~/usercontrols/navigation/ucAdvertiserAccountNavigation.ascx";

            //initialize a new page to host the control
            Page page = new Page();
            //disable event validation (this is a workaround to handle the "RegisterForEventValidation can only be called during Render()" exception)
            page.EnableEventValidation = false;

            //load the control and add it to the page's form
            ucAdvertiserAccountNavigation control = (ucAdvertiserAccountNavigation)page.LoadControl(fullPath);
            control.Setup();
            page.Controls.Add(control);

            //call RenderControl method to get the generated HTML
            string html = RenderControl(page);
            return html;

            //            ucSystemDynamicPage ucSystemDynamicPage = new ucSystemDynamicPage();
            //            string strContent = ucSystemDynamicPage.GetContent("SystemPage_AdvertiserDefaultWelcome");


            //            StringBuilder sb = new StringBuilder();

            //            sb.AppendFormat(@"
            //                <ul id='advertiserDropdownLinks' class='pull-right nav navbar-right'>
            //                    <li><a href='#' id='advertiserDropdown' role='button' class='dropdown-toggle btn btn-default' data-toggle='dropdown'> Advertiser menu <b class='caret'></b></a>
            //                        <ul class='dropdown-menu' role='menu' aria-labelledby='advertiserDropdown'>
            //                            <li class='advertiserLoggedas'>You are currently logged in as <strong>{0}</strong></li>
            //                            <li class='divider'></li>
            //                            <li id='advertiserDashHome'><a href='/advertiser/default.aspx'>Manage Jobs</a>
            //                                <ul class='dropdown-menu-sub'>
            //                                    <li id='advertiserDashNewJob'><a href='/advertiser/jobcreate.aspx'>Create a New Job Ad</a></li>
            //                                    <li id='advertiserDashCurrentJob'><a href='/advertiser/jobscurrent.aspx'>Current Job Ads</a></li>
            //                                    <li id='advertiserDashDraft'><a href='/advertiser/jobsdraft.aspx'>Draft Job Ads</a></li>
            //                                    <li id='advertiserDashArchived'><a href='/advertiser/jobsarchived.aspx'>Archived Job Ads</a></li>
            //                                </ul>
            //                            </li>
            //	                <li class='divider'></li>
            //	                <li id='advertiserDashDetails'><a href='/advertiser/edit.aspx'> Account Details</a>
            //                                <ul class='dropdown-menu-sub'>
            //                                    <li id='advertiserDashSubaccount'><a href='/advertiser/edit.aspx?tab=1'>Sub accounts</a></li>
            //                                    <li id='advertiserDashAdvlogo'><a href='/advertiser/logoedit.aspx'>Advertiser logo</a></li>
            //                                    <li id='advertiserDashPassword'><a href='/advertiser/edit.aspx?tab=2'>Change Password</a></li>
            //                                </ul>
            //	                </li>
            //	                <li class='divider'></li>
            //	                <li id='advertiserDashTemplatelogo'><a href='/advertiser/advertiserjobtemplatelogo.aspx'>Job template artwork/logo</a></li>
            //	                <li class='divider'></li>
            //	                <li id='advertiserDashTracker'> <a href='/advertiser/jobtracker.aspx'>Job Tracker</a> </li>
            //	                <li class='divider'></li>
            //	                <li id='advertiserDashStatistics'> <a href='/advertiser/statistics.aspx'>Statistics</a> </li>
            //	                <li class='divider'></li>
            //	                <li id='advertiserDashLogout'><a href='/logout.aspx'>Logout</a></li>
            //                        </ul>
            //                    </li>
            //                </ul>", advertiserUsername);

            //return sb.ToString();
        }

        protected string AdvertiserAvailCredits()
        {
            if (!SessionData.Site.IsJobBoard)
                return string.Empty;

            StringBuilder sb = new StringBuilder();

            int normalCount = 0;
            int standoutCount = 0;
            int premiumCount = 0;

            // When the site is Job board and the advertiser is of Credit Card type.
            if (SessionData.AdvertiserUser != null && SessionData.AdvertiserUser.AccountType == PortalEnums.Advertiser.AccountType.Credit_Card)
            {
                using (DataSet creditsDS = InvService.CustomJobCreditList(SessionData.AdvertiserUser.AdvertiserUserId))
                {
                    if (creditsDS.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < creditsDS.Tables[0].Rows.Count && i < 3; i++)
                        {
                            DataRow dr = creditsDS.Tables[0].Rows[i];

                            PortalEnums.Jobs.JobItemType thisJobType = (PortalEnums.Jobs.JobItemType)int.Parse(dr["JobItemTypeID"].ToString());
                            switch (thisJobType)
                            {
                                case PortalEnums.Jobs.JobItemType.Normal:
                                    normalCount = int.Parse(dr["Remaining"].ToString());
                                    break;
                                case PortalEnums.Jobs.JobItemType.StandOut:
                                    standoutCount = int.Parse(dr["Remaining"].ToString());
                                    break;
                                case PortalEnums.Jobs.JobItemType.Premium:
                                    premiumCount = int.Parse(dr["Remaining"].ToString());
                                    break;
                            }

                        }
                    }
                }


                sb.Append(@"<div class=""availCredits"">
		                <h4 class=""creditsTitle"">Credits Available</h4>");

                if (normalCount > 0 || standoutCount > 0 || premiumCount > 0)
                {
                    if (normalCount > 0)
                    {
                        sb.Append(@"<div class=""standard""><label for=""standard"" class=""credit-label"">Standard Job Post</label><span class=""credit-count"">" + normalCount + @"</span></div>");
                    }

                    if (standoutCount > 0)
                    {
                        sb.Append(@"<div class=""standout""><label for=""stand out"" class=""credit-label"">Stand out Job Post</label><span class=""credit-count"">" + standoutCount + @"</span></div>");
                    }

                    if (premiumCount > 0)
                    {
                        sb.Append(@"<div class=""premium""><label for=""premium"" class=""credit-label"">Premium Job Post</label><span class=""credit-count"">" + premiumCount + @"</span></div>");
                    }
                }
                else
                {
                    sb.Append(@"<div class=""no-credits""><label for=""no-credits-available"" class=""credit-label"">You currently have no credits. <a href=""/advertiser/productselect.aspx"">Purchase here</a></label></div>");
                }

                sb.Append(@"</div>");
            }
            else
                return string.Empty;

            return sb.ToString();
        }

        /// <summary>
        /// Member Current Jobs
        /// </summary>
        /// <returns></returns>
        protected string AdvertiserCurrentJobs()
        {
            StringBuilder sb = new StringBuilder();

            using (DataSet jobsDS = new JobsService().GetAdvertiserJobs(
                SessionData.Site.SiteId, SessionData.AdvertiserUser.AdvertiserId, SessionData.AdvertiserUser.AdvertiserUserId, "Current", string.Empty, 0, 6))
            {
                //JobID, JobName, JobFriendlyName, SiteProfessionFriendlyUrl, RefNo, Views, Applications, DatePosted, ShowSalaryRange, ExpiryDate, Expired

                sb.Append(@"<div id='advBroadcast-currentjobs' class='advBroadcast-widget'>");

                sb.Append(@"<table id='box-table-current' class='box-table table table-hover'>
			        <thead>
				        <tr>
					        <th>Ref. No</th>
					        <th>Job Title</th>
					        <th>Views</th>
					        <th>Applications</th>
					        <th>Posted</th>
					        <th>Expiry</th>
					        <th>Actions</th>
				        </tr>
			        </thead>
			        <tbody>");

                if (jobsDS.Tables[0].Rows.Count > 0)
                {
                    bool isJobScreeningProcess = false;

                    using (TList<Entities.GlobalSettings> globalsettings = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId))
                    {
                        if (globalsettings.Count > 0)
                        {
                            Entities.GlobalSettings globalsetting = globalsettings[0];

                            if (globalsetting.JobScreeningProcess.HasValue)
                            {
                                if (globalsetting.JobScreeningProcess.Value)
                                {
                                    isJobScreeningProcess = globalsetting.JobScreeningProcess.Value;
                                }
                            }
                        }
                    }

                    for (int i = 0; i < jobsDS.Tables[0].Rows.Count && i < 3; i++)
                    {
                        DataRow dr = jobsDS.Tables[0].Rows[i];

                        sb.AppendFormat(@"
				        <tr>
					        <td>{0}</td>
					        <td><a href='{1}'>{2}</a></td>
					        <td>{3}</td>
					        <td><a href='{4}'>{5}</a></td>
					        <td>{6}</td>
					        <td>{7}</td>
					        <td><a href='{8}'>View</a>{9}</td>
				        </tr>
                        ",
                         dr["RefNo"], // {0}
                         JXTPortal.Common.Utils.GetJobUrl(Convert.ToInt32(dr["JobID"]), dr["JobFriendlyName"].ToString(), dr["SiteProfessionFriendlyUrl"].ToString()), // {1}
                         dr["JobName"],  // {2}
                         string.IsNullOrEmpty(dr["Views"].ToString()) ? "0" : dr["Views"], //{3}
                         "/advertiser/jobtrackerapplications.aspx?JobID=" + dr["JobID"], //{4}
                         dr["Applications"], //{5}
                         ((DateTime)dr["DatePosted"]).ToString(SessionData.Site.DateFormat), //{6}
                         ((DateTime)dr["ExpiryDate"]).ToString(SessionData.Site.DateFormat), //{7}
                         JXTPortal.Common.Utils.GetJobUrl(Convert.ToInt32(dr["JobID"]), dr["JobFriendlyName"].ToString(), dr["SiteProfessionFriendlyUrl"].ToString()), //{8}
                         (isJobScreeningProcess) ? string.Empty : " | <a href='/advertiser/jobcreate.aspx?jobid=" + dr["JobID"] + "'>Edit</a>" //{9}
                         );
                    }
                }
                else
                {
                    sb.Append(@"<tr><td colspan=""7"" class=""advertiser-nosave-data"">No results found</td></tr>");
                }

                sb.Append(@"</tbody>
		            </table>");

                if (jobsDS.Tables[0].Rows.Count > 0)
                {
                    sb.Append(@"
		                <!-- Link to page of more than 3 items  -->
		                <p class='linkAdvertiserBroadcastViewMore'>
			                <a href='/advertiser/jobscurrent.aspx' class='mini-new-buttons'>View All</a>
		                </p>");
                }

                sb.Append(@"</div>");

            }
            return sb.ToString();
        }

        protected string AdvertiserApplicationTracker()
        {
            //JobApplicationID, ApplicationDate, FirstName, Surname, EmailAddress, MobilePhone, MemberResumeFile, 
            //MemberCoverLetterFile, ApplicationStatus, Abbr, RefNo, JobID, Draft, JobApplicationTypeID, ExternalXMLFilename , ExternalPDFFilename, URL_Referral, AppliedWith  

            StringBuilder sb = new StringBuilder();

            sb.Append(@"<div id='advBroadcast-jobtracker' class='advBroadcast-widget'>");

            JobApplicationService JobApplicationService = new JobApplicationService();
            using (DataSet jobsDS = JobApplicationService.CustomGetNewJobApplications(SessionData.Site.SiteId, null, SessionData.AdvertiserUser.AdvertiserUserId))
            {

                sb.Append(@"
		                <table id='box-table-jobtracker' class='box-table table table-hover'>
			                <thead>
				                <tr>
					                <th>First Name</th>
					                <th>Last Name</th>
					                <th>Email Address</th>
					                <th>Status</th>
					                <th>Date</th>
					                <th>Action</th>
				                </tr>
			                </thead>
			                <tbody>
                        ");
                if (jobsDS.Tables[0].Rows.Count > 0)
                {
                    // Retrieve the top 3 record in reverse order
                    for (int i = jobsDS.Tables[0].Rows.Count - 1; i >= 0 && i > jobsDS.Tables[0].Rows.Count - 4; i--)
                    {
                        DataRow dr = jobsDS.Tables[0].Rows[i];

                        sb.AppendFormat(@"
				        <tr>
					        <td>{0}</td>
					        <td>{1}</td>
					        <td>{2}</td>
					        <td>{3}</td>
					        <td>{4}</td>
                            <td><a href='{5}'>View</a></td>
				        </tr>
                        ",
                         dr["FirstName"], // {0}
                         dr["Surname"], // {1}
                         dr["EmailAddress"], // {2}
                         ((PortalEnums.JobApplications.ApplicationStatus)dr["ApplicationStatus"]).ToString(), // {3}
                         DateTime.Parse(dr["ApplicationDate"].ToString()).ToString(SessionData.Site.DateFormat), // {4}
                         "/advertiser/jobapplicationedit.aspx?jobapplicationid=" + dr["JobApplicationID"] // {5}
                         );
                    }

                }
                else
                {
                    sb.Append(@"<tr><td colspan=""6"" class=""advertiser-nosave-data"">No results found</td></tr>");
                }

                sb.Append(@"
			            </tbody>
		            </table>");

                if (jobsDS.Tables[0].Rows.Count > 0)
                {
                    sb.Append(@"                
		                <!-- Link to page of more than 3 items  -->
		                <p class='linkAdvertiserBroadcastViewMore'>
			                <a href='/advertiser/jobtracker.aspx' class='mini-new-buttons'>View All</a>
		                </p>");
                }

            }

            sb.Append(@"</div>");

            return sb.ToString();
        }

        /// <summary>
        /// Advertiser Draft Jobs
        /// </summary>
        /// <returns></returns>
        protected string AdvertiserDraftJobs()
        {
            StringBuilder sb = new StringBuilder();

            using (DataSet jobsDS = new JobsService().GetAdvertiserJobs(
                SessionData.Site.SiteId, SessionData.AdvertiserUser.AdvertiserId, SessionData.AdvertiserUser.AdvertiserUserId, "Draft", string.Empty, 0, 6))
            {
                //JobID, JobName, JobFriendlyName, SiteProfessionFriendlyUrl, RefNo, Views, Applications, DatePosted, ShowSalaryRange, ExpiryDate, Expired

                sb.Append(@"<div id='advBroadcast-draft' class='advBroadcast-widget'>");


                sb.Append(@"<table id='box-table-draft' class='box-table table table-hover'>
			        <thead>
				        <tr>
					        <th>Ref. No</th>
					        <th>Job Name</th>
					        <th>Date Saved</th>
					        <th>Action</th>
				        </tr>
			        </thead>
			        <tbody>");
                if (jobsDS.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < jobsDS.Tables[0].Rows.Count && i < 3; i++)
                    {
                        DataRow dr = jobsDS.Tables[0].Rows[i];

                        sb.AppendFormat(@"
				        <tr>
					        <td>{0}</td>
					        <td>{1}</td>
					        <td>{2}</td>
					        <td><a href='{3}'>Edit</a></td>
				        </tr>
                        ",
                         dr["RefNo"], // {0}
                         dr["JobName"],  // {1}
                         ((DateTime)dr["DatePosted"]).ToString(SessionData.Site.DateFormat), //{2}
                         "/advertiser/jobcreate.aspx?JobId=" + dr["JobID"] //{3}
                         );
                    }
                }
                else
                {
                    sb.Append(@"<tr><td colspan=""4"" class=""advertiser-nosave-data"">No results found</td></tr>");
                }

                sb.Append(@"</tbody>
		            </table>");

                if (jobsDS.Tables[0].Rows.Count > 0)
                {
                    sb.Append(@"  
                        <!-- Link to page of more than 3 items  -->
		                <p class='linkAdvertiserBroadcastViewMore'>
			                <a href='/advertiser/jobsdraft.aspx' class='mini-new-buttons'>View All</a>
		                </p>");
                }

                sb.Append(@"</div>");

            }
            return sb.ToString();
        }

        /// <summary>
        /// Advertiser Draft Jobs
        /// </summary>
        /// <returns></returns>
        protected string AdvertiserArchivedJobs()
        {
            StringBuilder sb = new StringBuilder();

            //using (DataSet jobsDS = new JobsService().GetArchivedJobs(
            //    SessionData.Site.SiteId, SessionData.AdvertiserUser.AdvertiserId, string.Empty, 0, 6))
            using (DataSet jobsDS = new JobsService().GetHistoricalJobStatistics(SessionData.Site.SiteId, SessionData.AdvertiserUser.AdvertiserId, SessionData.AdvertiserUser.AdvertiserUserId,
                    DateTime.Now.AddDays(MAX_EXPIRY_DATE), DateTime.Now, "JobID", false))
            {
                sb.Append(@"<div id='advBroadcast-archived' class='advBroadcast-widget'>");

                sb.Append(@"<table id='box-table-archived' class='box-table table table-hover'>
			        <thead>
				        <tr>
					        <th>Ref. No</th>
					        <th>Job Title</th>
					        <th>Views</th>
					        <th>Applications</th>
					        <th>Posted</th>
					        <th>Expiry</th>
					        <th>Actions</th>
				        </tr>
			        </thead>
			        <tbody>");

                if (jobsDS.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < jobsDS.Tables[0].Rows.Count && i < 3; i++)
                    {
                        DataRow dr = jobsDS.Tables[0].Rows[i];

                        sb.AppendFormat(@"
				        <tr>
					        <td>{0}</td>
					        <td><a href='{1}'>{2}</a></td>
					        <td>{3}</td>
					        <td><a href='{4}'>{5}</a></td>
					        <td>{6}</td>
					        <td>{7}</td>
					        <td><a href='{8}'>View</a></td>
				        </tr>
                        ",
                         dr["RefNo"], // {0}
                         dr["JobFriendlyName"] + "/" + dr["JobID"].ToString(), // {1}
                         dr["JobName"],  // {2}
                         string.IsNullOrEmpty(dr["Views"].ToString()) ? "0" : dr["Views"], //{3}
                         "/advertiser/jobtrackerapplications.aspx?JobArchiveID=" + dr["JobID"], //{4}
                         dr["Applications"], //{5}
                         ((DateTime)dr["DatePosted"]).ToString(SessionData.Site.DateFormat), //{6}
                         ((DateTime)dr["ExpiryDate"]).ToString(SessionData.Site.DateFormat), //{7}
                         dr["JobFriendlyName"] + "/" + dr["JobID"].ToString() //{8}
                         );
                    }
                }
                else
                {
                    sb.Append(@"<tr><td colspan=""7"" class=""advertiser-nosave-data"">No results found</td></tr>");
                }

                sb.Append(@"</tbody>
		            </table>");

                if (jobsDS.Tables[0].Rows.Count > 0)
                {
                    sb.Append(@"
		                <!-- Link to page of more than 3 items  -->
		                <p class='linkAdvertiserBroadcastViewMore'>
			                <a href='/advertiser/jobsarchived.aspx' class='mini-new-buttons'>View All</a>
		                </p>");
                }

                sb.Append(@"</div>");

            }
            return sb.ToString();
        }


        /// <summary>
        /// Advertiser Draft Jobs
        /// </summary>
        /// <returns></returns>
        protected string AdvertiserStatistics()
        {
            StringBuilder sb = new StringBuilder();

            using (DataSet ds = new JobsService().GetStatistics(SessionData.Site.SiteId, SessionData.AdvertiserUser.AdvertiserId, SessionData.AdvertiserUser.AdvertiserUserId))
            {
                //ReportName, ReportURL, Number, Applications, Viewed

                sb.Append(@"
            <div id='advBroadcast-statistics' class='advBroadcast-widget'>
		        <table id='box-table-statistics' class='box-table table table-hover'>
			        <thead>
				        <tr>
					        <th>Criteria</th>
					        <th>Total</th>
					        <th>Applications</th>
					        <th>Views</th>
				        </tr>
			        </thead>
			        <tbody>
                ");

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];

                    sb.AppendFormat(@"
				        <tr>
					        <td>{0}</td>
					        <td>{1}</td>
					        <td>{2}</td>
					        <td>{3}</td>
				        </tr>
                        ",
                     CommonFunction.GetResourceValue(dr["ReportName"].ToString()), // {0}
                     string.IsNullOrEmpty(dr["Number"].ToString()) ? "0" : dr["Number"],  // {1}
                     dr["Applications"], //{2}
                     dr["Viewed"] //{3}
                     );
                }

                sb.Append(@"
			            </tbody>
		            </table>
                </div>");

            }
            return sb.ToString();
        }

        /// <summary>
        /// Advertiser Draft Jobs
        /// </summary>
        /// <returns></returns>
        protected string AdvertiserSuspendedJobs()
        {
            StringBuilder sb = new StringBuilder();

            using (DataSet jobsDS = new JobsService().GetAdvertiserJobs(
                SessionData.Site.SiteId, SessionData.AdvertiserUser.AdvertiserId, SessionData.AdvertiserUser.AdvertiserUserId, "Suspended", string.Empty, 0, 5))
            {
                //JobID, JobName, JobFriendlyName, SiteProfessionFriendlyUrl, RefNo, Views, Applications, DatePosted, ShowSalaryRange, ExpiryDate, Expired

                sb.Append(@"<div id='advBroadcast-suspended' class='advBroadcast-widget'>");


                sb.Append(@"<table id='box-table-suspended' class='box-table table table-hover'>
			        <thead>
				        <tr>
					        <th>Ref. No</th>
					        <th>Job Name</th>
					        <th>Date Suspended</th>
				        </tr>
			        </thead>
			        <tbody>
                    ");
                if (jobsDS.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < jobsDS.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = jobsDS.Tables[0].Rows[i];

                        sb.AppendFormat(@"
				        <tr>
					        <td>{0}</td>
					        <td>{1}</td>
					        <td>{2}</td>
				        </tr>
                        ",
                         dr["RefNo"], // {0}
                         dr["JobName"],  // {1}
                         ((DateTime)dr["DatePosted"]).ToString(SessionData.Site.DateFormat) //{2}
                         );
                    }
                }
                else
                {
                    sb.Append(@"<tr><td colspan=""3"" class=""advertiser-nosave-data"">No results found</td></tr>");
                }
                sb.Append(@"</tbody></table>");

                if (jobsDS.Tables[0].Rows.Count > 0)
                {
                    sb.Append(@"  
                        <!-- Link to page of more than 3 items  -->
		                <p class='linkAdvertiserBroadcastViewMore'>
			                <a href='/advertiser/jobssuspended.aspx' class='mini-new-buttons'>View All</a>
		                </p>
                        ");
                }

                sb.Append(@"</div>");

            }
            return sb.ToString();
        }

        #endregion


        private string RenderControl(Control control)
        {
            StringBuilder sb = new StringBuilder();
            System.IO.StringWriter sw = new System.IO.StringWriter(sb);
            HtmlTextWriter writer = new HtmlTextWriter(sw);

            control.RenderControl(writer);
            return sb.ToString();
        }
    }
}
