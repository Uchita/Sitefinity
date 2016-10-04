using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JXTPosterTransform.Website.Logics;
using JXTPosterTransform.Website.Models;
using System.Configuration;

namespace JXTPosterTransform.Website.Controllers
{
    public class LogsController : Controller
    {
        /// <summary>
        /// View list of Logs for client setup
        /// </summary>
        /// <param name="id">Client Setup ID</param>
        /// <returns></returns>
        public ActionResult Listing(int? clientID, int? setupID, int? page)
        {
            ClientLogics cl = new ClientLogics();
            List<ClientSetupLogDisplayModel> setupLogs;
            List<ClientDisplayModel> clients = cl.ClientListingGet();
            int pagingCount = 0, recordPerPage = int.Parse(ConfigurationManager.AppSettings["AdminListingPageCount"]);

            ViewBag.ClientListing = clients;

            if (setupID != null)
            {
                setupLogs = cl.ClientSetupLogsGetBySetupID(setupID.Value, recordPerPage, page ?? 1, out pagingCount);

                ClientSetupDisplayModel setup = cl.ClientSetupGetByID(setupID.Value, null);
                ViewBag.ClientSetupListing = cl.ClientSetupsGet(setup.clientID);
                ViewBag.Pager = Pager.Items(pagingCount).PerPage(recordPerPage).Move(page ?? 1).Segment(10).Center();
                return View(setupLogs);
            }

            if (clientID != null)
            {
                setupLogs = cl.ClientSetupLogsGetByClientID(clientID.Value, recordPerPage, page ?? 1, out pagingCount);
                ViewBag.ClientSetupListing = cl.ClientSetupsGet(clientID.Value);
                ViewBag.Pager = Pager.Items(pagingCount).PerPage(recordPerPage).Move(page ?? 1).Segment(10).Center();
                return View(setupLogs);
            }

            ViewData["Path"] = ConfigurationManager.AppSettings["ClientSetupLogsFolderPath"];

            setupLogs = cl.ClientSetupLogsAllGet(recordPerPage, page ?? 1, out pagingCount);

            ViewBag.Pager = Pager.Items(pagingCount).PerPage(recordPerPage).Move(page ?? 1).Segment(10).Center(); 
            
            return View(setupLogs);

        }


        public ActionResult ViewDetails(int id)
        {
            ClientSetupLogDisplayModel thisLog = new ClientLogics().ClientSetupLogDetailsGetByID(id);

            return View(thisLog);
        }
    }
}
