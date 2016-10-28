using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JXTPortal.Entities;
using JXTPortal;
using JXTPortal.Common;
using System.Configuration;
using JXTPortal.EmailSender;
using System.Collections.Specialized;
using System.Web;
using System.Net.Mail;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Xml;

namespace JXTJobAlerts
{
    class MultiThreadJobAlert
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


        public void SendEmail(Sites site, GlobalSettings gs, TList<EmailTemplates> emailTemplateList, int defaultlangid)
        {

            Stopwatch sw1 = Stopwatch.StartNew();
            if (emailTemplateList == null || emailTemplateList.Count == 0)
                return;

            // 1. Get all site jobs and Save the jobs in the list..
            viewJobSearchList = GetAllWhitelabelJobs(site.SiteId, gs.DefaultLanguageId);

            // 2. If no jobs then skip

            // 3. If the jobs have {JobResults}

            // 4. Then just the count.


            int emailsent = 0;
            int totalJobAlertCount = 0;
            int totalWithNoJobs = 0;
            int totalErrors = 0;

            // If the whitelabel has jobs 
            if (viewJobSearchList.Count > 0)
            {


                //EasyFts fts = new EasyFts();
                //kw = fts.ToFtsQuery(SearchKeywords);

                // Get All Job Alerts needed to be run today
                DataSet jads = JobAlertsService.GetAllAlertsToRunToday(site.SiteId);

                Stopwatch sw2 = Stopwatch.StartNew();

                Console.WriteLine("**** Total Job Alerts Count FROM SP: {0}", jads.Tables[0].Rows.Count);
                EmailTemplates emailTemplate = null;
                Parallel.ForEach(jads.Tables[0].AsEnumerable(), new ParallelOptions { MaxDegreeOfParallelism = 16 }, dr =>

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
                    int ReferringSiteID = site.SiteId;

                    string JobName = string.Empty;
                    string Description = string.Empty;

                    XmlDocument xmldoc = null;

                    XmlNode langnode = null;

                    XmlNode enablednode = null;
                    XmlNode jobnamenode = null;
                    XmlNode shortdescription = null;
                    totalJobAlertCount++;
                    try
                    {
                        // Getting emailtemplate for child site
                        if (dr["ReferringSiteID"] != DBNull.Value)
                        {
                            ReferringSiteID = Convert.ToInt32(dr["ReferringSiteID"]);
                        }


                        // Getting Email template which matches the language
                        if (dr["DefaultLanguageId"] != DBNull.Value)
                        {
                            defaultlangid = Convert.ToInt32(dr["DefaultLanguageId"]);
                        }

                        foreach (JXTPortal.Entities.EmailTemplates et in emailTemplateList)
                        {
                            if (et.LanguageId == defaultlangid && et.SiteId == ReferringSiteID)
                            {
                                emailTemplate = et;
                                break;
                            }
                        }

                        // Use the first found site email template if the languaage email template does not exists

                        if (emailTemplate == null)
                        {
                            foreach (JXTPortal.Entities.EmailTemplates et in emailTemplateList)
                            {
                                if (et.SiteId == ReferringSiteID)
                                {
                                    emailTemplate = et;
                                    break;
                                }
                            }
                        }


                        // Cancel it if there's still no template
                        if (emailTemplate == null)
                        {
                            return;
                        }


                        JobAlertID = Convert.ToInt32(dr["JobAlertID"]);

                        currentJobAlertID = JobAlertID;
                        JobAlertName = dr["JobAlertName"].ToString();
                        SearchKeywords = dr["SearchKeywords"].ToString();
                        kw = string.Empty;

                        RecurrenceType = (dr["RecurrenceType"] == DBNull.Value) ? null : (int?)dr["RecurrenceType"];
                        DateNextRun = (dr["DateNextRun"] == DBNull.Value) ? null : (DateTime?)dr["DateNextRun"];
                        DateLastRun = (dr["DateLastRun"] == DBNull.Value) ? null : (DateTime?)dr["DateLastRun"];
                        MemberID = Convert.ToInt32(dr["MemberID"]);
                        AlertActive = (dr["AlertActive"] == DBNull.Value) ? null : (bool?)dr["AlertActive"];
                        EmailFormat = (dr["EmailFormat"] == DBNull.Value) ? null : (int?)dr["EmailFormat"];

                        SiteID = Convert.ToInt32(dr["SiteID"]);

                        CountryIDs = dr["CountryID"].ToString();
                        LocationID = dr["LocationID"].ToString();
                        AreaIDs = dr["AreaIDs"].ToString();
                        ProfessionID = dr["ProfessionID"].ToString();
                        SearchRoleIDs = dr["SearchRoleIDs"].ToString();
                        WorkTypeIDs = dr["WorkTypeIDs"].ToString();
                        CurrencyID = (dr["CurrencyID"] == DBNull.Value) ? null : (int?)dr["CurrencyID"];
                        SalaryTypeID = (dr["SalaryTypeID"] == DBNull.Value) ? null : (int?)dr["SalaryTypeID"];
                        SalaryLowerBand = (dr["SalaryLowerBand"] == DBNull.Value) ? null : (decimal?)dr["SalaryLowerBand"];
                        SalaryUpperBand = (dr["SalaryUpperBand"] == DBNull.Value) ? null : (decimal?)dr["SalaryUpperBand"];

                        FirstName = dr["FirstName"].ToString();
                        Surname = dr["Surname"].ToString();
                        EmailAddress = dr["EmailAddress"].ToString();//m.EmailAddress
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

                        // TODO - UNCOMMENT Update the Date Next Run.
                        using (JXTPortal.Entities.JobAlerts ja = JobAlertsService.GetByJobAlertId(JobAlertID))
                        {
                            ja.DateNextRun = nextdaydt;
                            JobAlertsService.Update(ja);
                        }


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

                            //// Job Search according to Job Alerts criteria
                            //if (!string.IsNullOrWhiteSpace(SearchKeywords))
                            //{
                            //    // Keyword Search

                            //    kw = fts.ToFtsQuery(SearchKeywords);

                            //    //TODO
                            //    //kw = kw.Replace(" OR ", " AND ");
                            //    /*
                            //    viewJobSearch = GetKeywordJobSearchResults(kw,
                            //                                        site.SiteId, null, CurrencyID,
                            //                                        SalaryLowerBand, SalaryUpperBand, SalaryTypeID,
                            //                                        WorkTypeIDs,
                            //                                        ProfessionID, SearchRoleIDs,
                            //                                        LocationID,
                            //                                        AreaIDs, DateLastRun, gs.DefaultLanguageId, out count);
                            //    */
                            //    viewJobSearch = GetKeywordJobSearchResultsNew(kw, site.SiteId, ProfessionID, SearchRoleIDs, CountryIDs,
                            //            LocationID, AreaIDs, SalaryTypeID, SalaryLowerBand, SalaryUpperBand, WorkTypeIDs, DateLastRun, gs.DefaultLanguageId, out count);

                            //}
                            //else
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

                                            JobName = vjs.JobName;
                                            Description = vjs.Description;


                                            if (!string.IsNullOrWhiteSpace(vjs.CustomXml))
                                            {
                                                // Get MultiLingual Job name & Description
                                                xmldoc = new XmlDocument();
                                                xmldoc.LoadXml(vjs.CustomXml);

                                                foreach (XmlNode xmlnode in xmldoc.GetElementsByTagName("JobDetail"))
                                                {
                                                    langnode = xmldoc.GetElementsByTagName("LanguageID")[0];

                                                    if (langnode.InnerText == defaultlangid.ToString())
                                                    {
                                                        enablednode = xmldoc.GetElementsByTagName("Enabled")[0];
                                                        jobnamenode = xmldoc.GetElementsByTagName("JobName")[0];
                                                        shortdescription = xmldoc.GetElementsByTagName("ShortDescription")[0];

                                                        if (Convert.ToBoolean(enablednode.InnerText))
                                                        {
                                                            JobName = jobnamenode.InnerText;
                                                            Description = shortdescription.InnerText;
                                                        }
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
																	</tr><
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
                                                 HttpUtility.HtmlEncode(JobName),
                                                HttpUtility.HtmlEncode(vjs.CompanyName),
                                                 HttpUtility.HtmlEncode(Description),
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
                                    ja.DateLastRun = dt; // TODO - UNCOMMENT.



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

                                //message.Bcc = emailTemplate.EmailAddressBcc;
                                message.Format = (Format)EmailFormat;
                                message.Body = (message.Format == Format.Html) ? emailTemplate.EmailBodyHtml : emailTemplate.EmailBodyText;
                                //message.Cc = emailTemplate.EmailAddressCc;
                                message.Fields = colemailfields;
                                message.From = new MailAddress(emailTemplate.EmailAddressFrom, emailTemplate.EmailAddressName);
                                message.Subject = emailTemplate.EmailSubject;
                                message.To = new MailAddress(EmailAddress, FirstName + " " + Surname);
                                Console.WriteLine(
                                    string.Format(
                                        "Job Alert ID {2} - Sending email to {0} - SiteID = {1} {3}",
                                        message.To.Address, site.SiteId, currentJobAlertID, string.IsNullOrWhiteSpace(kw) ? string.Empty : "- Has Keywords"));

                                SmtpSender newSender = Utils.EmailSender();
                                newSender.Send(message);
                                emailsent++;


                            }
                            else
                            {
                                totalWithNoJobs++;
                                Console.WriteLine(
                                    string.Format("Job Alert ID {2} {3} - No jobs for {0} - SiteID = {1} {4}",
                                        EmailAddress, site.SiteId, currentJobAlertID, JobAlertName, string.IsNullOrWhiteSpace(kw) ? string.Empty : "- Has Keywords"));
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        totalErrors++;
                        Console.WriteLine("Job Alert ID {0} failed. \n{4} \n{1}\n{2} {3}", currentJobAlertID, ex.Message, ex.StackTrace, string.IsNullOrWhiteSpace(kw) ? string.Empty : "- Has Keywords (" + kw + ")", ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                    }
                }
                );
                sw2.Stop();
                sw1.Stop();

                Console.WriteLine("Foreach Runtime " + site.SiteId + ": " + sw2.ElapsedMilliseconds + "ms");

                Console.WriteLine("Total Job Alert Counts: {0}", totalJobAlertCount);
                Console.WriteLine("No Jobs Count: {0}", totalWithNoJobs);
                Console.WriteLine("Email Sent: {0}", emailsent);
                Console.WriteLine("Total Failed: {0}", totalErrors);

                Console.WriteLine("Finished: " + DateTime.Now.ToString());
                Console.WriteLine("Entire MultiThreadJobAlert.cs Program Runtime: " + sw1.ElapsedMilliseconds + "ms");
            }

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

        /*
        private VList<ViewJobSearch> GetKeywordJobSearchResults(string kw, int? siteId, int? advertiserId,
                                                          int? currencyId, decimal? salaryLowerBand, decimal? salaryUpperBand,
                                                          int? salaryTypeId, string workTypeId, string professionId,
                                                          string roleId, string locationId,
                                                          string areaId, DateTime? dateFrom, int languageId, out int count)
        {
            int _workTypeID = 0;
            if (!string.IsNullOrEmpty(workTypeId) && int.TryParse(workTypeId, out _workTypeID))
                ;

            int _professionId = 0;
            if (!string.IsNullOrEmpty(professionId) && int.TryParse(professionId, out _professionId))
                ;

            int _locationId = 0;
            if (!string.IsNullOrEmpty(professionId) && int.TryParse(locationId, out _locationId))
                ;


            VList<ViewJobSearch> viewJobSearch = new VList<ViewJobSearch>();

            using (DataSet dsJobSearch = ViewJobSearchService.GetBySearchFilterRedefine(kw,
                                                                        siteId, advertiserId, currencyId,
                                                                        salaryLowerBand, salaryUpperBand, salaryTypeId,
                                                                        (_workTypeID > 0) ? _workTypeID : (int?)null,
                                                                        _professionId, roleId,
                                                                        null, _locationId,
                                                                        areaId, dateFrom, languageId))
            {
                count = 0;

                DataTable dtJobSearch = dsJobSearch.Tables[0];
                if (dtJobSearch.Rows.Count > 0)
                {
                    // Getting Total Job Count
                    count = int.Parse(dtJobSearch.Compute("Sum(RefineCount)", String.Format("RefineTypeID = {0}", (int)PortalEnums.Search.Redefine.SubClassification)).ToString());

                    if (count > 0)
                    {
                        viewJobSearch = ViewJobSearchService.GetBySearchFilter(
                                    kw,
                                    siteId, advertiserId, currencyId,
                                    salaryLowerBand, salaryUpperBand, salaryTypeId,
                                    (_workTypeID > 0) ? _workTypeID : (int?)null,
                                    _professionId, roleId,
                                    null, _locationId, areaId, dateFrom,
                                    languageId,
                                    0, jobalertresult, string.Empty, null);

                    }
                }
            }


            return viewJobSearch;

        }


        private IEnumerable<ViewJobSearch> GetKeywordJobSearchResultsNew(string kw, int? siteId, string professionIDs, string roleIDs,
                                                string countryIDs, string locationIDs, string areaIDs,
                                                int? SalaryTypeID, decimal? SalaryLowerBand, decimal? SalaryUpperBand,
                                                string worktypeIDs,
                                                DateTime? DateLastRun, int languageId, out int count)
        {

            VList<ViewJobSearch> viewJobSearchTemp = new VList<ViewJobSearch>();

            using (viewJobSearchTemp = ViewJobSearchService.GetBySearchFilter(
                                                kw,
                                                siteId, null,
                                                null, null, null, null,
                                                null,
                                                null, null,
                                                null, null, null, null,
                                                languageId,
                                                0, TOTAL_JOB_COUNT, string.Empty, null))
            {


            }

            IEnumerable<ViewJobSearch> _viewJobSearchTemp = viewJobSearchTemp.Where(s =>
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

            count = _viewJobSearchTemp.Count();

            return _viewJobSearchTemp;

        }*/


    }

}


/*
private string RemoveStopWordsAndSpecialCharacters(string strKeywords)
{
    if (!string.IsNullOrWhiteSpace(strKeywords))
    {
        //string str = "this is some text just some dummy text Just text";
        List<string> stopwordsList = new List<string>() { "I", "a", "about", "an", "and", "are", "as", "at", "be", "by", "com", "for", "from", "how", "in", "is", "it", "of", 
                                                            "on", "or", "that", "the", "this", "to", "was", "what", "when", "where", "who", "will", "with", "the", "www" };
        strKeywords = string.Join(" ", strKeywords.Split().Where(w => !stopwordsList.Contains(w, StringComparer.InvariantCultureIgnoreCase)));
    }

    strKeywords = JXTPortal.Common.Utils.RemoveMetaSpecialCharacters(strKeywords);
    // Todo - try catch ?
    return strKeywords;
}
*/


// Remove stop words and Special characters
/*strKeywords = RemoveStopWordsAndSpecialCharacters(strKeywords);
            
// Do Keyword search
if (_viewJobSearchTemp.Count() > 0 && !string.IsNullOrWhiteSpace(strKeywords))
{

    _viewJobSearchTemp = _viewJobSearchTemp.Where(s => strKeywords.Split(' ').Contains(s.JobId.ToString()) ||
                                    strKeywords.Split(' ').Contains(s.JobName) ||
                                    strKeywords.Split(' ').Contains(s.FullDescription) ||
                                    strKeywords.Split(' ').Contains(s.CompanyName) ||
                                    strKeywords.Split(' ').Contains(s.RefNo) ||
                                    strKeywords.Split(' ').Contains(s.SalaryText) ||
                                    strKeywords.Split(' ').Contains(s.ContactDetails) ||
                                    strKeywords.Split(' ').Contains(s.BulletPoint1) ||
                                    strKeywords.Split(' ').Contains(s.BulletPoint2) ||
                                    strKeywords.Split(' ').Contains(s.BulletPoint3) ||
                                    strKeywords.Split(' ').Contains(s.Description));

    // IMPORTANT - the keywords which are not filtered.
    //strKeywords.Split(' ').Contains(s.PublicTransport) || 
    //strKeywords.Split(' ').Contains(s.Address) || 
    //strKeywords.Split(' ').Contains(s.Tags) ||
}*/
