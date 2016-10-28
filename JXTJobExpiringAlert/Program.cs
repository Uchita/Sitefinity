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

namespace JXTJobExpiringAlert
{
    class Program
    {
        private class TempClass
        {
            public int SiteID { get; set; }
            public int AdvertiserID { get; set; }
            public string AdvertiserEmail { get; set; }
            public string AdvertiserFirstName { get; set; }
            public string AdvertiserLastName { get; set; }
        }

        static void Main(string[] args)
        {
            EmailTemplatesService ets = new EmailTemplatesService();

            //int emailsent = 0;
            string strAdvertiserLogo = string.Empty;
            try
            {
                GlobalSettingsService gss = new GlobalSettingsService();
                SitesService ss = new SitesService();
                AdvertisersService service = new AdvertisersService();
                using (DataSet ds = service.CustomGetExpiringJobAdvertiser(0, int.Parse(ConfigurationManager.AppSettings["ExpiryDays"])))
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable sitetable = ds.Tables[1];
                        DataView siteview = sitetable.DefaultView;

                        DataTable table = ds.Tables[2];
                        DataView view = table.DefaultView;

                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            try
                            {
                                int siteid = Convert.ToInt32(row["siteid"]);

                                siteview.RowFilter = "SiteID = " + siteid.ToString();
                                DataView filteredSiteView = siteview.ToTable().AsDataView();

                                string siteurl = filteredSiteView[0]["SiteURL"].ToString();
                                string sitename = filteredSiteView[0]["SiteName"].ToString();
                                int advertiseruserid = Convert.ToInt32(row["AdvertiserUserID"]);
                                int advertiserid = Convert.ToInt32(row["AdvertiserID"]);
                                string firstname = row["firstname"].ToString();
                                string surname = row["surname"].ToString();
                                string email = row["email"].ToString();
                                bool primaryaccount = Convert.ToBoolean(row["PrimaryAccount"]);
                                int count = 0;

                                

                                if (primaryaccount)
                                {
                                    view.RowFilter = "AdvertiserID = " + advertiserid.ToString();
                                }
                                else
                                {
                                    view.RowFilter = "AdvertiserUserID = " + advertiseruserid.ToString();
                                }

                                DataView filteredView = view.ToTable().AsDataView();

                                if (filteredView.ToTable().Rows.Count > 0)
                                {

                                    StringBuilder tablehtml = new StringBuilder();
                                    tablehtml.AppendLine("<table class=\"templatetable\" style=\"width:100%; border-collapse: collapse; \">");
                                    tablehtml.AppendLine("<thead>");
                                    tablehtml.AppendLine("<tr style=\"border: 1px solid #999;padding: 5px 10px;border-collapse: collapse;\">");
                                    tablehtml.AppendLine("<th style=\"border: 1px solid rgb(153, 153, 153); padding: 5px 10px; font-weight: bold; font-size: 14px; color: rgb(51, 51, 51); font-family: helvetica, arial, verdana; border-collapse: collapse; text-align: left;\">Job title</th>");
                                    tablehtml.AppendLine("<th style=\"border: 1px solid rgb(153, 153, 153); padding: 5px 10px; font-weight: bold; font-size: 14px; color: rgb(51, 51, 51); font-family: helvetica, arial, verdana; border-collapse: collapse; text-align: left;\">Expiry date</th>");
                                    tablehtml.AppendLine("<th style=\"border: 1px solid rgb(153, 153, 153); padding: 5px 10px; font-weight: bold; font-size: 14px; color: rgb(51, 51, 51); font-family: helvetica, arial, verdana; border-collapse: collapse; text-align: left;\">Action</th>");
                                    tablehtml.AppendLine("</tr>");
                                    tablehtml.AppendLine("</thead>");
                                    tablehtml.AppendLine("<tbody>");

                                    foreach (DataRow jobrow in filteredView.ToTable().Rows)
                                    {
                                        int jobid = Convert.ToInt32(jobrow["jobid"]);
                                        string joburl = string.Format("http://{0}{1}/{2}", jobrow["siteurl"], jobrow["JobFriendlyName"], jobid);
                                        string jobname = jobrow["JobName"].ToString();
                                        string jobediturl = string.Format("http://{0}/advertiser/jobcreate.aspx?jobid={1}", siteurl, jobid);

                                        DateTime expirydate = Convert.ToDateTime(jobrow["ExpiryDate"]);

                                        tablehtml.AppendLine("<tr style=\"border: 1px solid #999;padding: 5px 10px;border-collapse: collapse;\">");
                                        tablehtml.AppendLine(string.Format("<td style=\"border: 1px solid #999;padding: 5px 10px;font-weight: normal;font-size: 14px;color: #333;font-family: helvetica, arial, verdana;border-collapse: collapse;\">{0}</td>", jobname));
                                        tablehtml.AppendLine(string.Format("<td style=\"border: 1px solid #999;padding: 5px 10px;font-weight: normal;font-size: 14px;color: #333;font-family: helvetica, arial, verdana;border-collapse: collapse;\">{0}</td>", expirydate.ToString("dd/MM/yyyy")));
                                        tablehtml.AppendLine(string.Format("<td style=\"border: 1px solid #999;padding: 5px 10px;font-weight: normal;font-size: 14px;color: #333;font-family: helvetica, arial, verdana;border-collapse: collapse;\"><a href=\"{0}\">Edit</a> | <a href=\"{1}\">View</a></td>", jobediturl, joburl));
                                        tablehtml.AppendLine("</tr>");
                                        count++;
                                    }
                                    tablehtml.AppendLine("</tbody>");
                                    tablehtml.AppendLine("</table>");


                                    JXTPortal.EmailSender.Message message = new JXTPortal.EmailSender.Message();
                                    HybridDictionary colemailfields = new HybridDictionary();

                                    message.From = new MailAddress(filteredSiteView[0]["EmailAddressFrom"].ToString(), filteredSiteView[0]["EmailAddressName"].ToString());
                                    message.To = new MailAddress(email, firstname + " " + surname);

                                    colemailfields["JOBSLIST"] = tablehtml;
                                    colemailfields["FIRSTNAME"] = firstname;
                                    colemailfields["LASTNAME"] = surname;
                                    colemailfields["SURNAME"] = surname;
                                    colemailfields["URLSUFFIX"] = siteurl;
                                    colemailfields["SiteID"] = siteid;
                                    colemailfields["SiteName"] = sitename;
                                    colemailfields["COUNT"] = count;
                                    message.Format = Format.Html;
                                    message.Body = filteredSiteView[0]["EmailBodyHtml"].ToString(); // (message.Format == Format.Html) ? etl.EmailBodyHtml : etl.EmailBodyText;
                                    message.Fields = colemailfields;
                                    message.Subject = filteredSiteView[0]["EmailSubject"].ToString();
                                    Console.WriteLine(string.Format("Sending Email to : {0}, AdvertiserUserID {1}\n", email, advertiseruserid));
                                    Utils.EmailSender().Send(message);
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(string.Format("Error: {0}\n{1}", ex.Message, ex.StackTrace));
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Error: {0}\n{1}", ex.Message, ex.StackTrace));
            }
        }

    }
}
