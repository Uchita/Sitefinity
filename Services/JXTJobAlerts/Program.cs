using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net.Configuration;
using JXTPortal.Common;
using JXTPortal.Entities;
using JXTPortal;
using System.Text;
using System.Configuration;
using JXTPortal.EmailSender;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Diagnostics;

namespace JXTJobAlerts
{
    class Program
    {

        static void Main(string[] args)
        {
            Stopwatch sw1 = Stopwatch.StartNew();

            // Set previous date
            DateTime dtTodaysDate = DateTime.Now.AddDays(-7);
            dtTodaysDate = new DateTime(dtTodaysDate.Year, dtTodaysDate.Month, dtTodaysDate.Day, 0, 0, 0);

            Console.WriteLine(dtTodaysDate);
            Console.WriteLine("StartTime : " + DateTime.Now.ToString());

            SitesService ss = new SitesService();
            EmailTemplatesService ets = new EmailTemplatesService();
            JobAlertsService jas = new JobAlertsService();
            GlobalSettingsService gss = new GlobalSettingsService();
            ViewJobSearchService vjss = new ViewJobSearchService();
            AdvertisersService AdvertisersService = new JXTPortal.AdvertisersService();

            int currentJobAlertID = 0;
            int emailsent = 0;
            int totalJobAlertCount = 0;
            int totalWithNoJobs = 0;
            int totalErrors = 0;
            string strAdvertiserLogo = string.Empty;
            // Retrieve all sites
            using (DataSet sites = ss.Get_List())
            {
                DataRow[] siterows = sites.Tables[0].Select("Live = 1"); // only live sites. // Todo  Remove SiteID

                if (siterows.Length > 0)
                {
                    TList<JXTPortal.Entities.EmailTemplates> etl = ets.CustomGetByEmailCode("JOBALERT");

                    foreach (DataRow siterow in siterows)
                    {
                        JXTPortal.Entities.Sites site = new JXTPortal.Entities.Sites();
                        site.SiteId = (int)siterow["SiteID"];
                        site.SiteName = siterow["SiteName"].ToString();
                        site.SiteUrl = siterow["SiteURL"].ToString();
                        site.SiteDescription = siterow["SiteDescription"].ToString();
                        site.SiteAdminLogo = (byte[])siterow["SiteAdminLogo"];
                        site.LastModified = (DateTime)siterow["LastModified"];
                        site.LastModifiedBy = (int)siterow["LastModifiedBy"];
                        site.Live = (bool)siterow["Live"];
                        site.MobileEnabled = (bool)siterow["MobileEnabled"];
                        site.MobileUrl = siterow["MobileUrl"].ToString();
                        site.SiteAdminLogoUrl = siterow["SiteAdminLogoUrl"].ToString();

                        Console.WriteLine(site.SiteId.ToString() + ". " + site.SiteName);

                        // Get Job Alert Email Template & Global Settings

                        JXTPortal.Entities.GlobalSettings gs = gss.GetGlobalSettingBySiteID(site.SiteId);
                        
                        if (etl.Count > 0)
                        {
                          
                            // If the site is Multi job alert 
                            //if (string.Format(" {0} ", site.SiteId.ToString()).Contains(ConfigurationManager.AppSettings["MultiSiteIDs"]))
                            /*
                            if (ConfigurationManager.AppSettings["MultiSiteIDs"].Contains(string.Format(" {0} ", site.SiteId.ToString())))
                            {
                                Console.WriteLine("MultiJobAlert Initiated");

                                MultiJobAlert multi = new MultiJobAlert();

                                multi.SendEmail(site, gs, et);
                            }
                            */
                            //if (ConfigurationManager.AppSettings["MultiThreadSiteIDs"].Contains(string.Format(" {0} ", site.SiteId.ToString())))
                            {
                                Console.WriteLine("MultiThreadJobAlert Initiated");

                                MultiThreadJobAlert multi = new MultiThreadJobAlert();

                                try
                                {
                                    multi.SendEmail(site, gs, etl, (gs.DefaultEmailLanguageId.HasValue)?gs.DefaultEmailLanguageId.Value : 0);
                                }           
                                catch (Exception ex)
                                {
                                    Console.WriteLine("ERROR Site . \n{0} - {1} \n{2}\n{3} {4}", site.SiteId, site.SiteName, ex.Message, ex.StackTrace, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                                }
                            }

//                            else
//                            {
//                                //TODO Remove
//                                if( !string.IsNullOrEmpty( ConfigurationManager.AppSettings["MultiThreadSiteIDs"]) ) 
//                                    goto EndOfThis;

//                                // Get All Job Alerts needed to be run today
//                                DataSet jads = jas.GetAllAlertsToRunToday(site.SiteId);
//                                Stopwatch sw2 = Stopwatch.StartNew();
//                                //Parallel.ForEach(jads.Tables[0].AsEnumerable(), dr =>
//                                foreach (var dr in jads.Tables[0].AsEnumerable())
//                                {
//                                    totalJobAlertCount++;
//                                    try
//                                    {
//                                        int JobAlertID = Convert.ToInt32(dr["JobAlertID"]);

//                                        currentJobAlertID = JobAlertID;
//                                        string JobAlertName = dr["JobAlertName"].ToString();
//                                        string SearchKeywords = dr["SearchKeywords"].ToString();
//                                        string kw = string.Empty;

//                                        EasyFts fts = new EasyFts();
//                                        kw = fts.ToFtsQuery(SearchKeywords);

//                                        int? RecurrenceType = (dr["RecurrenceType"] == DBNull.Value) ? null : (int?)dr["RecurrenceType"];
//                                        DateTime? DateNextRun = (dr["DateNextRun"] == DBNull.Value) ? null : (DateTime?)dr["DateNextRun"];
//                                        DateTime? DateLastRun = (dr["DateLastRun"] == DBNull.Value) ? null : (DateTime?)dr["DateLastRun"];
//                                        int MemberID = Convert.ToInt32(dr["MemberID"]);
//                                        bool? AlertActive = (dr["AlertActive"] == DBNull.Value) ? null : (bool?)dr["AlertActive"];
//                                        int? EmailFormat = (dr["EmailFormat"] == DBNull.Value) ? null : (int?)dr["EmailFormat"];

//                                        int SiteID = Convert.ToInt32(dr["SiteID"]);
//                                        int? LocationID = null;
//                                        if (dr["LocationID"] != DBNull.Value)
//                                            LocationID = int.Parse(dr["LocationID"].ToString());

//                                        string AreaIDs = dr["AreaIDs"].ToString();
//                                        int? ProfessionID = null;
//                                        if (dr["ProfessionID"] != DBNull.Value)
//                                            ProfessionID = int.Parse(dr["ProfessionID"].ToString());
//                                        string SearchRoleIDs = dr["SearchRoleIDs"].ToString();
//                                        string WorkTypeIDs = dr["WorkTypeIDs"].ToString();
//                                        int? CurrecnyID = (dr["CurrencyID"] == DBNull.Value) ? null : (int?)dr["CurrencyID"];
//                                        int? SalaryTypeID = (dr["SalaryTypeID"] == DBNull.Value) ? null : (int?)dr["SalaryTypeID"];
//                                        decimal? SalaryLowerBand = (dr["SalaryLowerBand"] == DBNull.Value) ? null : (decimal?)dr["SalaryLowerBand"];
//                                        decimal? SalaryUpperBand = (dr["SalaryUpperBand"] == DBNull.Value) ? null : (decimal?)dr["SalaryUpperBand"];
//                                        //string GeneratedSQL = dr["GeneratedSQL"].ToString();
//                                        string FirstName = dr["FirstName"].ToString();
//                                        string Surname = dr["Surname"].ToString();
//                                        string EmailAddress = dr["EmailAddress"].ToString();//m.EmailAddress
//                                        //int salaryid = 0;

//                                        int worktypeid = 0;
//                                        int.TryParse(WorkTypeIDs, out worktypeid);

//                                        Guid EditValidateID = Guid.Empty;
//                                        Guid ViewValidateID = Guid.Empty;
//                                        Guid UnsubscribeValidateID = Guid.Empty;

//                                        string strViewResultsUrl = string.Empty;
//                                        string strEditUrl = string.Empty;
//                                        string strUnSubscribeURL = string.Empty;

//                                        int jobalertresult = Convert.ToInt32(ConfigurationManager.AppSettings["JobAlertResults"]);

//                                        DateTime dt = DateTime.Now;
//                                        DateTime nextdaydt = DateTime.Now.AddDays(1);

//                                        Message message = null;
//                                        HybridDictionary colemailfields = null;
//                                        string siteurl = (gs.WwwRedirect) ? "www." + site.SiteUrl : site.SiteUrl;
//                                        string sitename = site.SiteName;
//                                        /*string jobresults = "<table width=\"600\" align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"templetcontainer\" bgcolor=\"#f2f2f2\" style=\"background-color: #f2f2f2; border-bottom:1px solid #c7c7c7; border-left:1px solid #c7c7c7; border-right:1px solid #c7c7c7;\">" +
//                                                                "     <tbody>" +
//                                                                "         <tr>" +
//                                                                "           <td valign=\"top\"><!-- start templetcontainer width 560px -->" +
//                                                                "               <table width=\"560\" align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"job_alert_full_width\" bgcolor=\"#f2f2f2\" style=\"background-color:#f2f2f2;\">" +
//                                                                "                   <!-- Job Item -->" +
//                                                                "                   <tbody>{0}</tbody></table></td></tr><tr><td height=\"20\"></td></tr></tbody></table>";
//                                        */
//                                        string jobresults = @"<table width='600'  align='center' border='0' cellspacing='0' cellpadding='0' class='templetcontainer' bgcolor='#f2f2f2' style='background-color: #f2f2f2; border-bottom:1px solid #c7c7c7; border-left:1px solid #c7c7c7; border-right:1px solid #c7c7c7;'>					<tr>
//						                                <td valign='top'><!-- start templetcontainer width 560px -->
//							                                <table width='560'  align='center' border='0' cellspacing='0' cellpadding='0' class='job_alert_full_width' bgcolor='#f2f2f2' style='background-color:#f2f2f2;'>
//								                                <!-- Job Item -->
//                                                                {0}
//                                                            </table>
//							                                <!-- end  templetcontainer width 560px -->
//						                                </td>
//					                                </tr>
//					                                <tr>
//						                                <td height='20'></td>
//					                                </tr>
//				                                </table>";

//                                        string results = string.Empty;

//                                        // Update the Date Next Run.
//                                        using (JXTPortal.Entities.JobAlerts ja = jas.GetByJobAlertId(JobAlertID))
//                                        {
//                                            ja.DateNextRun = nextdaydt;
//                                            jas.Update(ja);
//                                        }


//                                        // Job Search according to Job Alerts criteria
//                                        using (DataSet dsJobSearch = vjss.GetBySearchFilterRedefine(kw,
//                                                                                                        site.SiteId, null, CurrecnyID,
//                                                                                                        SalaryLowerBand, SalaryUpperBand, SalaryTypeID,
//                                                                                                        (worktypeid > 0) ? worktypeid : (int?)null,
//                                                                                                        ProfessionID, SearchRoleIDs,
//                                                                                                        null, LocationID,
//                                                                                                        AreaIDs, DateLastRun, gs.DefaultLanguageId))
//                                        {
//                                            int count = 0;

//                                            DataTable dtJobSearch = dsJobSearch.Tables[0];
//                                            if (dtJobSearch.Rows.Count > 0)
//                                            {
//                                                // Getting Total Job Count
//                                                count = int.Parse(dtJobSearch.Compute("Sum(RefineCount)", String.Format("RefineTypeID = {0}", (int)PortalEnums.Search.Redefine.SubClassification)).ToString());

//                                                results = string.Empty;

//                                                // Send Email only when there is more than one job posted today.
//                                                if (count > 0)
//                                                {
//                                                    // Get Job Results Format only when its an HTML format and the JobResults tag is under and get results only when they are 
//                                                    if ((Format)EmailFormat == Format.Html && et.EmailBodyHtml.Contains("{JOBRESULTS}"))
//                                                    {
//                                                        using (VList<ViewJobSearch> viewJobSearch = vjss.GetBySearchFilter(
//                                                                kw,
//                                                                site.SiteId, null,
//                                                                CurrecnyID, SalaryLowerBand, SalaryUpperBand, SalaryTypeID,
//                                                                (worktypeid > 0) ? worktypeid : (int?)null,
//                                                                ProfessionID, SearchRoleIDs,
//                                                                null, LocationID, AreaIDs, DateLastRun,
//                                                                gs.DefaultLanguageId,
//                                                                0, jobalertresult, string.Empty, null))
//                                                        {
//                                                            // Contrust Job Result for Email
//                                                            foreach (ViewJobSearch vjs in viewJobSearch)
//                                                            {
//                                                                strAdvertiserLogo = string.Empty;
//                                                                if (vjs.AdvertiserId.HasValue && vjs.AdvertiserId.Value > 0) //AdvertiserJobTemplateLogoId
//                                                                {
//                                                                    using (JXTPortal.Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(vjs.AdvertiserId.Value))
//                                                                    {
//                                                                        if (advertiser.AdvertiserLogo != null)
//                                                                        {
//                                                                            strAdvertiserLogo = String.Format(@"<a href='#'><img src='http://{0}/getfile.aspx?advertiserid={1}' border='0' hspace='0' vspace='0' alt='{2}' /></a>",
//                                                                                                                siteurl,
//                                                                                                                vjs.AdvertiserId.Value,
//                                                                                                                vjs.CompanyName);
//                                                                        }
//                                                                    }
//                                                                }

//                                                                results += string.Format(@"
//                                <tr>
//									<td valign='top' width='100%'>
//										<table width='100%' border='0' cellspacing='0' cellpadding='0' align='left' style='background-color: #FFFFFF; border:1px solid #c7c7c7;' >
//											<tr>
//												<td height='20' colspan='3'></td>
//											</tr>
//											<tr>
//												<td width='20'></td>
//												<td valign='top' align='left' >
//													<table border='0' cellspacing='0' cellpadding='0' align='left'>
//														<tr>
//															<td valign='top'>
//																<table  width='100%' border='0' cellspacing='0' cellpadding='0' align='left' >
//																	<tr>
//																		<td style='font-size: 18px; line-height: 22px; font-family: Arial,Tahoma, Helvetica, sans-serif; color:#49C1EE; font-weight:400; text-align:left;'>
//																			<a href='{0}' style='text-decoration: none; color:#49C1EE;'>{1}</a>
//																		</td>
//																	</tr>
//																	<tr>
//																		<td style='font-size: 12px; line-height: 18px; font-family: Arial,Tahoma, Helvetica, sans-serif; color:#999999; font-weight:400; text-align:left;'>
//																			<a href='#' style='text-decoration: none; color:#999999;'>{2}</a>
//																		</td>
//																	</tr>
//																	<tr>
//																		<td height='10'></td>
//																	</tr>
//																	<tr>
//																		<td style='font-size: 13px; line-height: 18px; font-family:Arial,Tahoma, Helvetica, sans-serif; color:#333; font-weight:400; text-align:left;'> 
//																			{3}  ... <a href='{0}' style='text-decoration: none; color:#49C1EE;'>more details</a>
//																		</td>
//																	</tr>
//																</table>
//															</td>
//															<td valign='top' align='left' style='padding-left:20px;' class='client_img'>{4}
//															</td>
//														</tr>
//													</table>
//												</td>
//												<td width='20'></td>
//											</tr>
//											<tr>
//												<td height='20' colspan='3'></td>
//											</tr>
//										</table>
//										<table width='100%' height='10'></table>
//									</td>
//								</tr>",
//                                                                    string.Format("http://{0}{1}", siteurl, JXTPortal.Common.Utils.GetJobUrl(vjs.JobId, vjs.JobFriendlyName)),
//                                                                    HttpUtility.HtmlEncode(vjs.JobName),
//                                                                    HttpUtility.HtmlEncode(vjs.CompanyName),
//                                                                    HttpUtility.HtmlEncode(vjs.Description),
//                                                                    (!string.IsNullOrWhiteSpace(strAdvertiserLogo)) ? strAdvertiserLogo : string.Empty);
//                                                                //http://{0}/advertisers/{1} - advertiser url
//                                                            }

//                                                        }
//                                                    }



//                                                    message = new Message();
//                                                    colemailfields = new HybridDictionary();

//                                                    using (JXTPortal.Entities.JobAlerts ja = jas.GetByJobAlertId(JobAlertID))
//                                                    {
//                                                        ja.DateLastRun = dt;



//                                                        if (ja.UnsubscribeValidateId == Guid.Empty ||
//                                                            ja.UnsubscribeValidateId == null)
//                                                        {
//                                                            UnsubscribeValidateID = Guid.NewGuid();
//                                                            ja.UnsubscribeValidateId = UnsubscribeValidateID;
//                                                        }
//                                                        else
//                                                        {
//                                                            UnsubscribeValidateID = (Guid)ja.UnsubscribeValidateId;
//                                                        }

//                                                        EditValidateID = Guid.NewGuid();
//                                                        ViewValidateID = Guid.NewGuid();

//                                                        ja.EditValidateId = EditValidateID;
//                                                        ja.ViewValidateId = ViewValidateID;
//                                                        jas.Update(ja);
//                                                    }


//                                                    strViewResultsUrl =
//                                                        string.Format(
//                                                            "http://{0}/JobAlertsSwitch.aspx?searchid={1}&viewValidateID={2}",
//                                                            siteurl, JobAlertID.ToString(),
//                                                            HttpUtility.UrlEncode(Utils.EncryptString(JobAlertID.ToString())));
//                                                    strEditUrl =
//                                                        string.Format(
//                                                            "http://{0}/JobAlertsEditSwitch.aspx?searchid={1}&editValidateID={2}",
//                                                            siteurl, JobAlertID.ToString(),
//                                                            HttpUtility.UrlEncode(Utils.EncryptString(JobAlertID.ToString())));
//                                                    strUnSubscribeURL =
//                                                        string.Format(
//                                                            "http://{0}/JobAlertsUnsubscribe.aspx?searchid={1}&unsubscribeValidateID={2}",
//                                                            siteurl, JobAlertID.ToString(), UnsubscribeValidateID.ToString());

//                                                    //jobresults = string.Format(jobresults, results);
//                                                    colemailfields["FIRSTNAME"] = FirstName;
//                                                    colemailfields["LASTNAME"] = Surname;
//                                                    colemailfields["ALERTNAME"] = JobAlertName;
//                                                    colemailfields["EMAIL"] = EmailAddress;

//                                                    /*if (count > jobalertresult)
//                                                            colemailfields["ALERTRESULTCOUNT"] = "more than " + count.ToString();
//                                                        else*/
//                                                    colemailfields["ALERTRESULTCOUNT"] = count.ToString();

//                                                    colemailfields["VIEWRESULTSLINK"] = strViewResultsUrl;
//                                                    colemailfields["UNSUBSCRIBELINK"] = strUnSubscribeURL;
//                                                    colemailfields["ALERTEDITLINK"] = strEditUrl;
//                                                    colemailfields["JOBRESULTS"] = string.Format(jobresults, results);
//                                                    colemailfields["URLSUFFIX"] = siteurl;
//                                                    colemailfields["SITENAME"] = sitename;
//                                                    colemailfields["SITEID"] = SiteID.ToString();
//                                                    colemailfields["DATE"] = DateTime.Now.ToString("dd/MM/yyyy");

//                                                    message.Format = (Format)EmailFormat;
//                                                    message.Body = (message.Format == Format.Html)
//                                                        ? et.EmailBodyHtml
//                                                        : et.EmailBodyText;
//                                                    message.Cc = et.EmailAddressCc;
//                                                    message.Fields = colemailfields;
//                                                    message.From = new MailAddress(et.EmailAddressFrom, et.EmailAddressName);
//                                                    message.Subject = et.EmailSubject;
//                                                    message.To = new MailAddress(EmailAddress, FirstName + " " + Surname);
//                                                    Console.WriteLine(
//                                                        string.Format(
//                                                            "Job Alert ID {2} - Sending email to {0} - SiteID = {1}",
//                                                            message.To.Address, site.SiteId, currentJobAlertID));
//                                                    Utils.EmailSender().Send(message);
//                                                    emailsent++;
//                                                }
//                                                else
//                                                    Console.WriteLine(
//                                                        string.Format(
//                                                            "Job Alert ID {2} - No jobs from yesterday {0} - SiteID = {1}",
//                                                            message.To.Address, site.SiteId, currentJobAlertID));


//                                            }
//                                            else
//                                            {
//                                                totalWithNoJobs++;
//                                                Console.WriteLine(
//                                                    string.Format("Job Alert ID {2} - No jobs for {0} - SiteID = {1}",
//                                                        EmailAddress, site.SiteId, currentJobAlertID));
//                                            }
//                                        }
//                                    }
//                                    catch (Exception ex)
//                                    {
//                                        totalErrors++;
//                                        Console.WriteLine("Job Alert ID {0} failed. \n{1}\n{2}", currentJobAlertID, ex.Message, ex.StackTrace);
//                                    }
//                                }
//                                //);
//                                sw2.Stop();
//                                Console.WriteLine("Foreach Runtime " + site.SiteId + ": " + sw2.ElapsedMilliseconds + "ms");

//                            }
                        }
                        //TODO remove
                        EndOfThis:
                            continue;
                    }

                }
            }
            sw1.Stop();

            //Console.WriteLine("Total Job Alert Counts: {0}", totalJobAlertCount);
            //Console.WriteLine("No Jobs Count: {0}", totalWithNoJobs);
            //Console.WriteLine("Email Sent: {0}", emailsent);
            //Console.WriteLine("Total Failed: {0}", totalErrors);

            //Console.WriteLine("Finished: " + DateTime.Now.ToString());
            Console.WriteLine("Entire Program Runtime: " + sw1.ElapsedMilliseconds + "ms");


            //Console.ReadKey(); // REMOVE THIS
        }


    }
}

