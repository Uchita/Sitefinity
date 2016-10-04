using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using JXTPortal.Client.Salesforce;
using JXTPortal;
using System.Data;
using JXTPortal.Entities;


namespace JXTSalesforceIntegration
{
    class Program
    {
        static void Main(string[] args)
        {
            int intErrorCounter = 0;
            int allSitesSavedCounter = 0;
            // Get all the Sales force integrations 
            IntegrationsService iService = new IntegrationsService();
            List<int> SFIntegrationsSiteIDs = iService.AdminAllSalesForceIntegrationsSiteIDGet(); //Tuple<SiteID, Integration Details>
            // For loop per site.

            Console.WriteLine("Total of " + SFIntegrationsSiteIDs.Count() + " site(s) detected with valid SF Integrations");
            Console.WriteLine("=================================");

            foreach (int siteID in SFIntegrationsSiteIDs)
            {
                int siteCandCounter = 0;
                Console.WriteLine("Processing SiteID: " + siteID);
                try
                {
                    //SessionSetup();
                    SalesforceMemberSync memberSync = new SalesforceMemberSync(siteID);

                    // Get all the contacts from Salesfoce OR only modified/created in Salesforce for the past one day.
                    SalesForceContactObject salesForceContactObject = memberSync.GetContactList(false);

                    int memberid = 0;
                    string errormsg = string.Empty;
                    bool blnResult = false;

                    if (salesForceContactObject != null && salesForceContactObject.records != null && salesForceContactObject.records.Count > 0)
                    {
                        foreach (var item in salesForceContactObject.records)
                        {
                            try
                            {
                                blnResult = memberSync.SaveMember(item, true, siteID, ref memberid, ref errormsg);
                                //blnResult = false;
                                if (!blnResult)
                                {
                                    Console.WriteLine("{4}. Insert Failed - {2} ({0}, {1}) - {3}", item.FirstName, item.LastName, item.Email, errormsg, siteCandCounter);
                                    intErrorCounter++;
                                }
                                else
                                    Console.WriteLine("{3}. Saved - {2} ({0}, {1})", item.FirstName, item.LastName, item.Email, siteCandCounter);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("{4}. Exception - {2} ({0}, {1}) - {3}", item.FirstName, item.LastName, item.Email, ex.Message, siteCandCounter);
                                intErrorCounter++;
                            }
                            siteCandCounter++;
                            allSitesSavedCounter++;
                        }
                    }

                }
                catch (WebException ex)
                {
                    string msg = "";

                    if (ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        System.Net.WebResponse response = ex.Response;
                        msg = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd().Trim();

                        Console.WriteLine("Web Exception Error: " + msg);
                    }
                    else
                        Console.WriteLine("Web Exception Error: " + ex.Message);                        
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Exception Error: " + ex.Message);
                }
                Console.WriteLine("\nTotal Saved For Site - {0}", siteCandCounter);                
            }
            Console.WriteLine("---------------------------");
            Console.WriteLine("\nTotal Saved For All Sites - {0}", allSitesSavedCounter);
            Console.WriteLine("\nTotal Errors For All Sites - {0}", intErrorCounter);
        }

    }
}
