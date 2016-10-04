using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Entities;
using System.Net.Mail;
using EmailSender;
using System.Web;
using System.Collections.Specialized;
using System.Configuration;
using JXTPortal.Common;
using System.Data;
using System.Net.Configuration;
using System.Security.Cryptography;

namespace JXTPortal.Custom
{
    public class JobAlertEmailService
    {
        #region Properties

        private ViewJobSearchService _viewJobSearchService;
        private ViewJobSearchService ViewJobSearchService
        {
            get
            {
                if (_viewJobSearchService == null)
                {
                    _viewJobSearchService = new ViewJobSearchService();
                }
                return _viewJobSearchService;
            }
        }
        private JobAlertsService _jobAlertsService;
        private JobAlertsService JobAlertsService
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
        private AdvertisersService _advertisersService;
        private AdvertisersService AdvertisersService
        {
            get
            {
                if (_advertisersService == null)
                {
                    _advertisersService = new AdvertisersService();
                }
                return _advertisersService;
            }
        }

        #endregion

        #region Declarations

        VList<ViewJobSearch> viewJobSearchList = new VList<ViewJobSearch>();

        //int jobalertresult = Convert.ToInt32(ConfigurationManager.AppSettings["JobAlertResults"]);      //total job results for keyword search 

        int TOTAL_JOB_COUNT = 10000; // By Default Get all the jobs of the site // TODO - Convert.ToInt32(ConfigurationManager.AppSettings["JobAlertResults"])

        int TOTAL_KEYWORD_JOB_COUNT = 100;

        #endregion


        public bool SendJobAlertEmail(int siteId, int jobAlertId)
        {
            //Sites site
            SitesService ss = new SitesService();
            EmailTemplatesService ets = new EmailTemplatesService();
            GlobalSettingsService gss = new GlobalSettingsService();
            JobAlertsService jas = new JobAlertsService();
            MembersService ms = new MembersService();
            
            Sites site = new Sites();
            GlobalSettings gs = new GlobalSettings();
            JobAlerts jobalert = new JobAlerts();
            Members member = new Members();
            JXTPortal.Entities.EmailTemplates emailTemplate = null;
            TList<Entities.EmailTemplates> etl = new TList<EmailTemplates>();

            using (site = ss.GetBySiteId(siteId))
            {
            }
            using (etl = ets.GetBySiteIdEmailCode(site.SiteId, "JOBALERT"))
            {
            }
            if (etl.Count > 0)
            {
                emailTemplate = etl[0];
            }


            using(gs = gss.GetGlobalSettingBySiteID(site.SiteId))
            {
            }
            using (jobalert = jas.GetByJobAlertId(jobAlertId))
            {
            }
            if (emailTemplate != null && jobalert != null)
            {
                // 1. Get all site jobs and Save the jobs in the list..
                viewJobSearchList = GetAllWhitelabelJobs(site.SiteId, gs.DefaultLanguageId);

                using (member = ms.GetByMemberId(jobalert.MemberId))
                {
                }
            

                // If the whitelabel has jobs 
                if (viewJobSearchList.Count > 0)
                {
                    // Get All Job Alerts needed to be run today
                    //DataSet jads = JobAlertsService.GetAllAlertsToRunToday(site.SiteId);

                    
                    //Parallel.ForEach(jads.Tables[0].AsEnumerable(), dr =>

                    //foreach (DataRow dr in jads.Tables[0].Rows)
                    {
                        EasyFts fts = new EasyFts();
                        string JobAlertName = string.Empty;
                        string SearchKeywords = string.Empty;
                        string kw = string.Empty;

                        int currentJobAlertID = 0;

                        int JobAlertID = 0;
                        string strAdvertiserLogo = string.Empty;
                        int? RecurrenceType = null;
                        DateTime? DateNextRun = null;
                        DateTime? DateLastRun = null;
                        int MemberID = 0;
                        bool? AlertActive = null;
                        int? EmailFormat = null;

                        int SiteID = 0;

                        string CountryIDs = string.Empty;
                        string LocationID = string.Empty;
                        string AreaIDs = string.Empty;
                        string ProfessionID = string.Empty;
                        string SearchRoleIDs = string.Empty;
                        string WorkTypeIDs = string.Empty;
                        int? CurrencyID = null;
                        int? SalaryTypeID = null;
                        decimal? SalaryLowerBand = null;
                        decimal? SalaryUpperBand = null;
                        //string GeneratedSQL = dr["GeneratedSQL"].ToString();
                        string FirstName = string.Empty;
                        string Surname = string.Empty;
                        string EmailAddress = string.Empty;


                        Guid EditValidateID = Guid.Empty;
                        Guid ViewValidateID = Guid.Empty;
                        Guid UnsubscribeValidateID = Guid.Empty;

                        string strViewResultsUrl = string.Empty;
                        string strEditUrl = string.Empty;
                        string strUnSubscribeURL = string.Empty;

                        DateTime dt = DateTime.Now;
                        DateTime nextdaydt = DateTime.Now.AddDays(1);

                        Message message = null;
                        HybridDictionary colemailfields = null;
                        string siteurl = string.Empty;
                        string sitename = string.Empty;

                        string jobresults = string.Empty;

                        string results = string.Empty;


                        try
                        {
                            JobAlertID = Convert.ToInt32(jobalert.JobAlertId);

                            currentJobAlertID = JobAlertID;
                            JobAlertName = jobalert.JobAlertName;
                            SearchKeywords = jobalert.SearchKeywords;
                            kw = string.Empty;

                            RecurrenceType = (!jobalert.RecurrenceType.HasValue) ? null : (int?)jobalert.RecurrenceType;
                            DateNextRun = null; //(!jobalert.DateNextRun.HasValue) ? null : (DateTime?)jobalert.DateNextRun;
                            DateLastRun = null; // (!jobalert.DateLastRun.HasValue) ? null : (DateTime?)jobalert.DateLastRun;
                            MemberID = jobalert.MemberId;
                            AlertActive = (!jobalert.AlertActive.HasValue) ? null : (bool?)jobalert.AlertActive;
                            EmailFormat = (!jobalert.EmailFormat.HasValue) ? null : (int?)jobalert.EmailFormat;

                            SiteID = jobalert.SiteId;

                            CountryIDs = jobalert.CountryId;
                            LocationID = jobalert.LocationId;
                            AreaIDs = jobalert.AreaIds;
                            ProfessionID = jobalert.ProfessionId;
                            SearchRoleIDs = jobalert.SearchRoleIds;
                            WorkTypeIDs = jobalert.WorkTypeIds;
                            CurrencyID = (!jobalert.CurrencyId.HasValue) ? null : (int?)jobalert.CurrencyId;
                            SalaryTypeID = (!jobalert.SalaryTypeId.HasValue) ? null : (int?)jobalert.SalaryTypeId;
                            SalaryLowerBand = (!jobalert.SalaryLowerBand.HasValue) ? null : (decimal?)jobalert.SalaryLowerBand;
                            SalaryUpperBand = (!jobalert.SalaryUpperBand.HasValue) ? null : (decimal?)jobalert.SalaryUpperBand;

                            FirstName = member.FirstName;
                            Surname = member.Surname;
                            EmailAddress = member.EmailAddress;//m.EmailAddress
                            //int salaryid = 0;

                            //int worktypeid = 0;
                            //int.TryParse(WorkTypeIDs, out worktypeid);

                            EditValidateID = Guid.Empty;
                            ViewValidateID = Guid.Empty;
                            UnsubscribeValidateID = Guid.Empty;

                            strViewResultsUrl = string.Empty;
                            strEditUrl = string.Empty;
                            strUnSubscribeURL = string.Empty;

                            dt = DateTime.Now;
                            nextdaydt = DateTime.Now.AddDays(1);

                            message = null;
                            colemailfields = null;
                            siteurl = (gs.WwwRedirect) ? "www." + site.SiteUrl : site.SiteUrl;
                            sitename = site.SiteName;
                            /*string jobresults = "<table width=\"600\" align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"templetcontainer\" bgcolor=\"#f2f2f2\" style=\"background-color: #f2f2f2; border-bottom:1px solid #c7c7c7; border-left:1px solid #c7c7c7; border-right:1px solid #c7c7c7;\">" +
                                                    "     <tbody>" +
                                                    "         <tr>" +
                                                    "           <td valign=\"top\"><!-- start templetcontainer width 560px -->" +
                                                    "               <table width=\"560\" align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"job_alert_full_width\" bgcolor=\"#f2f2f2\" style=\"background-color:#f2f2f2;\">" +
                                                    "                   <!-- Job Item -->" +
                                                    "                   <tbody>{0}</tbody></table></td></tr><tr><td height=\"20\"></td></tr></tbody></table>";
                            */
                            jobresults = @"<table width='600'  align='center' border='0' cellspacing='0' cellpadding='0' class='templetcontainer' bgcolor='#f2f2f2' style='background-color: #f2f2f2; border-bottom:1px solid #c7c7c7; border-left:1px solid #c7c7c7; border-right:1px solid #c7c7c7;'>					<tr>
						                                <td valign='top'><!-- start templetcontainer width 560px -->
							                                <table width='560'  align='center' border='0' cellspacing='0' cellpadding='0' class='job_alert_full_width' bgcolor='#f2f2f2' style='background-color:#f2f2f2;'>
								                                <!-- Job Item -->
                                                                {0}
                                                            </table>
							                                <!-- end  templetcontainer width 560px -->
						                                </td>
					                                </tr>
					                                <tr>
						                                <td height='20'></td>
					                                </tr>
				                                </table>";

                            results = string.Empty;

                            /*
                            // TODO - UNCOMMENT Update the Date Next Run.
                            using (JXTPortal.Entities.JobAlerts ja = JobAlertsService.GetByJobAlertId(JobAlertID))
                            {
                                ja.DateNextRun = nextdaydt;
                                JobAlertsService.Update(ja);
                            }
                            */

                            /*using (DataSet dsJobSearch = ViewJobSearchService.GetBySearchFilterRedefine(kw,
                                                                                            site.SiteId, null, CurrencyID,
                                                                                            SalaryLowerBand, SalaryUpperBand, SalaryTypeID,
                                                                                            (worktypeid > 0) ? worktypeid : (int?)null,
                                                                                            ProfessionID, SearchRoleIDs,
                                                                                            LocationID,
                                                                                            AreaIDs, DateLastRun, gs.DefaultLanguageId))*/
                            //if (dr["MemberID"].ToString().Equals("199451")) // Remove
                            {
                                int count = 0;

                                IEnumerable<ViewJobSearch> viewJobSearch = null;

                                {
                                    // Multi Search
                                    // Keyword Search
                                    if (!string.IsNullOrWhiteSpace(SearchKeywords))
                                        kw = fts.ToFtsQuery(SearchKeywords);
                                    else
                                        kw = string.Empty;

                                    viewJobSearch = GetAllMemberJobAlertJobs(viewJobSearchList, site.SiteId, gs.DefaultLanguageId, kw, ProfessionID, SearchRoleIDs, CountryIDs,
                                            LocationID, AreaIDs, SalaryTypeID, SalaryLowerBand, SalaryUpperBand, WorkTypeIDs, DateLastRun);

                                    count = viewJobSearch.Count();


                                    if (viewJobSearch.Count() > 0)
                                    {
                                        // If Multi Job alert then display 50 jobs else default 10 jobs.
                                        if (ConfigurationManager.AppSettings["MultiSiteIDs"].Contains(string.Format(" {0} ", site.SiteId.ToString())))
                                            viewJobSearch = viewJobSearch.Take(Convert.ToInt32(ConfigurationManager.AppSettings["MultiMaxJobsPerEmail"]));
                                        else
                                            viewJobSearch = viewJobSearch.Take(Convert.ToInt32(ConfigurationManager.AppSettings["JobAlertResults"]));

                                    }
                                }

                                if (count > 0)
                                {
                                    results = string.Empty;

                                    // Get Job Results Format only when its an HTML format and the JobResults tag is under and get results only when they are 
                                    // TODO - sends only HTML email, how about TEXT or PLAIN
                                    if ((Format)EmailFormat == Format.Html && emailTemplate.EmailBodyHtml.Contains("{JOBRESULTS}"))
                                    {
                                        /*using (VList<ViewJobSearch> viewJobSearch = ViewJobSearchService.GetBySearchFilter(
                                                kw,
                                                site.SiteId, null,
                                                CurrencyID, SalaryLowerBand, SalaryUpperBand, SalaryTypeID,
                                                (worktypeid > 0) ? worktypeid : (int?)null,
                                                ProfessionID, SearchRoleIDs,
                                                LocationID, AreaIDs, DateLastRun,
                                                gs.DefaultLanguageId,
                                                0, jobalertresult, string.Empty))*/
                                        {

                                            // Contrust Job Result for Email
                                            foreach (ViewJobSearch vjs in viewJobSearch)
                                            {
                                                strAdvertiserLogo = string.Empty;
                                                if (vjs.AdvertiserId.HasValue && vjs.AdvertiserId.Value > 0) //AdvertiserJobTemplateLogoId
                                                {
                                                    using (JXTPortal.Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(vjs.AdvertiserId.Value))
                                                    {
                                                        if (advertiser.AdvertiserLogo != null)
                                                        {
                                                            strAdvertiserLogo = String.Format(@"<a href='#'><img src='http://{0}/getfile.aspx?advertiserid={1}' border='0' hspace='0' vspace='0' alt='{2}' /></a>",
                                                                                                siteurl,
                                                                                                vjs.AdvertiserId.Value,
                                                                                                vjs.CompanyName);
                                                        }
                                                    }
                                                }

                                                results += string.Format(@"
                                <tr>
									<td valign='top' width='100%'>
										<table width='100%' border='0' cellspacing='0' cellpadding='0' align='left' style='background-color: #FFFFFF; border:1px solid #c7c7c7;' >
											<tr>
												<td height='20' colspan='3'></td>
											</tr>
											<tr>
												<td width='20'></td>
												<td valign='top' align='left' >
													<table border='0' cellspacing='0' cellpadding='0' align='left'>
														<tr>
															<td valign='top'>
																<table  width='100%' border='0' cellspacing='0' cellpadding='0' align='left' >
																	<tr>
																		<td style='font-size: 18px; line-height: 22px; font-family: Arial,Tahoma, Helvetica, sans-serif; color:#49C1EE; font-weight:400; text-align:left;'>
																			<a href='{0}' style='text-decoration: none; color:#49C1EE;'>{1}</a>
																		</td>
																	</tr>
																	<tr>
																		<td style='font-size: 12px; line-height: 18px; font-family: Arial,Tahoma, Helvetica, sans-serif; color:#999999; font-weight:400; text-align:left;'>
																			<a href='#' style='text-decoration: none; color:#999999;'>{2}</a>
																		</td>
																	</tr>
																	<tr>
																		<td height='10'></td>
																	</tr>
																	<tr>
																		<td style='font-size: 13px; line-height: 18px; font-family:Arial,Tahoma, Helvetica, sans-serif; color:#333; font-weight:400; text-align:left;'> 
																			{3}  ... <a href='{0}' style='text-decoration: none; color:#49C1EE;'>more details</a>
																		</td>
																	</tr>
																</table>
															</td>
															<td valign='top' align='left' style='padding-left:20px;' class='client_img'>{4}
															</td>
														</tr>
													</table>
												</td>
												<td width='20'></td>
											</tr>
											<tr>
												<td height='20' colspan='3'></td>
											</tr>
										</table>
										<table width='100%' height='10'></table>
									</td>
								</tr>",
                                                    string.Format("http://{0}{1}", siteurl, JXTPortal.Common.Utils.GetJobUrl(vjs.JobId, vjs.JobFriendlyName)),
                                                    HttpUtility.HtmlEncode(vjs.JobName),
                                                    HttpUtility.HtmlEncode(vjs.CompanyName),
                                                    HttpUtility.HtmlEncode(vjs.Description),
                                                    (!string.IsNullOrWhiteSpace(strAdvertiserLogo)) ? strAdvertiserLogo : string.Empty);
                                                //http://{0}/advertisers/{1} - advertiser url
                                            }

                                        }
                                    }



                                    message = new Message();
                                    colemailfields = new HybridDictionary();
                                    
                                    using (JXTPortal.Entities.JobAlerts ja = JobAlertsService.GetByJobAlertId(JobAlertID))
                                    {
                                        // Update the Date Last Run - so that the job alert runs from this date.
                                        //ja.DateLastRun = dt; // TODO - UNCOMMENT.



                                        if (ja.UnsubscribeValidateId == Guid.Empty ||
                                            ja.UnsubscribeValidateId == null)
                                        {
                                            UnsubscribeValidateID = Guid.NewGuid();
                                            ja.UnsubscribeValidateId = UnsubscribeValidateID;
                                        }
                                        else
                                        {
                                            UnsubscribeValidateID = (Guid)ja.UnsubscribeValidateId;
                                        }

                                        EditValidateID = Guid.NewGuid();
                                        ViewValidateID = Guid.NewGuid();

                                        ja.EditValidateId = EditValidateID;
                                        ja.ViewValidateId = ViewValidateID;
                                        JobAlertsService.Update(ja);
                                    }


                                    strViewResultsUrl =
                                        string.Format(
                                            "http://{0}/JobAlertsSwitch.aspx?searchid={1}&viewValidateID={2}",
                                            siteurl, JobAlertID.ToString(),
                                            HttpUtility.UrlEncode(Utils.EncryptString(JobAlertID.ToString())));
                                    strEditUrl =
                                        string.Format(
                                            "http://{0}/JobAlertsEditSwitch.aspx?searchid={1}&editValidateID={2}",
                                            siteurl, JobAlertID.ToString(),
                                            HttpUtility.UrlEncode(Utils.EncryptString(JobAlertID.ToString())));
                                    strUnSubscribeURL =
                                        string.Format(
                                            "http://{0}/JobAlertsUnsubscribe.aspx?searchid={1}&unsubscribeValidateID={2}",
                                            siteurl, JobAlertID.ToString(), UnsubscribeValidateID.ToString());

                                    //jobresults = string.Format(jobresults, results);
                                    colemailfields["FIRSTNAME"] = FirstName;
                                    colemailfields["LASTNAME"] = Surname;
                                    colemailfields["ALERTNAME"] = JobAlertName;
                                    colemailfields["EMAIL"] = EmailAddress;

                                    /*if (count > jobalertresult)
                                            colemailfields["ALERTRESULTCOUNT"] = "more than " + count.ToString();
                                        else*/
                                    colemailfields["ALERTRESULTCOUNT"] = count.ToString();

                                    colemailfields["VIEWRESULTSLINK"] = strViewResultsUrl;
                                    colemailfields["UNSUBSCRIBELINK"] = strUnSubscribeURL;
                                    colemailfields["ALERTEDITLINK"] = strEditUrl;
                                    colemailfields["JOBRESULTS"] = string.Format(jobresults, results);
                                    colemailfields["URLSUFFIX"] = siteurl;
                                    colemailfields["SITENAME"] = sitename;
                                    colemailfields["SITEID"] = SiteID.ToString();
                                    colemailfields["DATE"] = DateTime.Now.ToString("dd/MM/yyyy");

                                    message.Bcc = emailTemplate.EmailAddressBcc;
                                    message.Format = (Format)EmailFormat;
                                    message.Body = (message.Format == Format.Html) ? emailTemplate.EmailBodyHtml : emailTemplate.EmailBodyText;
                                    message.Cc = emailTemplate.EmailAddressCc;
                                    message.Fields = colemailfields;
                                    message.From = new MailAddress(emailTemplate.EmailAddressFrom, emailTemplate.EmailAddressName);
                                    message.Subject = emailTemplate.EmailSubject;
                                    message.To = new MailAddress(EmailAddress, FirstName + " " + Surname);
                                    
                                    SmtpSender newSender = Utils.EmailSender();
                                    newSender.Send(message);

                                    return true;
                                }
                                else
                                {

                                }
                            }
                        }

                        catch (Exception ex)
                        {

                        }
                    }

                }
            }


            return false;
        }

        /// <summary>
        /// Per site get the Whitelabel jobs
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="DefaultLanguageId"></param>
        private VList<ViewJobSearch> GetAllWhitelabelJobs(int siteId, int DefaultLanguageId)
        {
            viewJobSearchList = new VList<ViewJobSearch>();
            using (viewJobSearchList = ViewJobSearchService.GetBySearchFilter(
                                                string.Empty,
                                                siteId, null,
                                                null, null, null, null,
                                                null,
                                                null, null,
                                                null, null, null, null,
                                                DefaultLanguageId,
                                                0, TOTAL_JOB_COUNT, string.Empty, null))
            {


            }

            return viewJobSearchList;
        }

        /// <summary>
        /// Filter the Member Job alert search
        /// </summary>
        /// <param name="_viewJobSearch"></param>
        /// <param name="strKeywords"></param>
        /// <param name="professionIDs"></param>
        /// <param name="roleIDs"></param>
        /// <param name="countryIDs"></param>
        /// <param name="locationIDs"></param>
        /// <param name="areaIDs"></param>
        /// <param name="SalaryTypeID"></param>
        /// <param name="SalaryLowerBand"></param>
        /// <param name="SalaryUpperBand"></param>
        /// <param name="worktypeIDs"></param>
        /// <param name="DateLastRun"></param>
        /// <returns></returns>
        private IEnumerable<ViewJobSearch> GetAllMemberJobAlertJobs(VList<ViewJobSearch> _viewJobSearch,
                                                int siteId,
                                                int languageId,
                                                string strKeywords,
                                                string professionIDs, string roleIDs,
                                                string countryIDs, string locationIDs, string areaIDs,
                                                int? SalaryTypeID, decimal? SalaryLowerBand, decimal? SalaryUpperBand,
                                                string worktypeIDs,
                                                DateTime? DateLastRun)
        {
            // Filter by keywords, SalaryLowerBand, SalaryUpperBand, SalaryTypeID, worktypeid, ProfessionID, SearchRoleIDs, LocationID,AreaIDs, DateLastRun

            // If there are any keywords then do search all jobs with Keywords.
            if (!string.IsNullOrWhiteSpace(strKeywords))
            {
                using (_viewJobSearch = ViewJobSearchService.GetBySearchFilter(
                                                    strKeywords,
                                                    siteId, null,
                                                    null, null, null, null,
                                                    null,
                                                    null, null,
                                                    null, null, null, null,
                                                    languageId,
                                                    0, TOTAL_KEYWORD_JOB_COUNT, string.Empty, null))
                {


                }
            }


            // Filter byProfessionID, SearchRoleIDs, country,LocationID,AreaIDs, worktypeid
            IEnumerable<ViewJobSearch> _viewJobSearchTemp = _viewJobSearch.Where(s =>
                                        (string.IsNullOrWhiteSpace(professionIDs) || professionIDs.Split(',').Contains(s.ProfessionId.ToString())) &&
                                        (string.IsNullOrWhiteSpace(roleIDs) || roleIDs.Split(',').Contains(s.RoleId.ToString())) &&
                                        (string.IsNullOrWhiteSpace(countryIDs) || countryIDs.Split(',').Contains(s.CountryId.ToString())) &&
                                        (string.IsNullOrWhiteSpace(locationIDs) || locationIDs.Split(',').Contains(s.LocationId.ToString())) &&
                                        (string.IsNullOrWhiteSpace(areaIDs) || areaIDs.Split(',').Contains(s.AreaId.ToString())) &&
                                        (string.IsNullOrWhiteSpace(worktypeIDs) || worktypeIDs.Split(',').Contains(s.WorkTypeId.ToString()))
                                        );

            // Salary Filter
            if (_viewJobSearchTemp.Count() > 0 && SalaryTypeID.HasValue && (SalaryLowerBand.HasValue || SalaryUpperBand.HasValue))
            {
                _viewJobSearchTemp = _viewJobSearchTemp.Where(s => s.SalaryTypeId == SalaryTypeID.Value);

                if (_viewJobSearchTemp.Count() > 0 && SalaryLowerBand.HasValue)
                    _viewJobSearchTemp = _viewJobSearchTemp.Where(s => s.SalaryLowerBand >= SalaryLowerBand.Value);

                if (_viewJobSearchTemp.Count() > 0 && SalaryUpperBand.HasValue)
                    _viewJobSearchTemp = _viewJobSearchTemp.Where(s => s.SalaryUpperBand <= SalaryUpperBand.Value);
            }

            // Filter by Date Last Run
            if (_viewJobSearchTemp.Count() > 0 && DateLastRun.HasValue)
            {
                _viewJobSearchTemp = _viewJobSearchTemp.Where(s => s.DatePosted >= DateLastRun.Value);
            }

            return _viewJobSearchTemp;

        }

    }

    public class Utils
    {

        public static SmtpSender EmailSender()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            MailSettingsSectionGroup mailConfiguration = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

            SmtpSender mailObject = new SmtpSender(mailConfiguration.Smtp.Network.Host);

            mailObject.Port = mailConfiguration.Smtp.Network.Port;
            if (!mailConfiguration.Smtp.Network.DefaultCredentials)
            {
                mailObject.UserName = mailConfiguration.Smtp.Network.UserName;
                mailObject.Password = mailConfiguration.Smtp.Network.Password;
            }

            return mailObject;
        }

        const string ACart_SALT = "esPOir";
        public static string EncryptString(string strString)
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
