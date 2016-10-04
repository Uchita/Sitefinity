using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JXTPosterTransform.Website.Logics;
using JXTPosterTransform.Website.Models;
using System.Configuration;
using JXTPosterTransform.Library.Common;

namespace JXTPosterTransform.Website.Controllers
{
    public class ClientSetupController : Controller
    {
        public ActionResult Index(PTCommonEnums.Client.Valid? status, int? page)
        {
            ClientLogics _logic = new ClientLogics();
            int pagingCount = 0, recordPerPage = int.Parse(ConfigurationManager.AppSettings["AdminListingPageCount"]);

            List<ClientDisplayModel> clientListing = _logic.ClientListingGet(status, recordPerPage, page ?? 1, out pagingCount);

            ViewBag.StatusList = new List<PTCommonEnums.Client.Valid> { PTCommonEnums.Client.Valid.Archieved, PTCommonEnums.Client.Valid.Invalid, PTCommonEnums.Client.Valid.Valid };
            ViewBag.Pager = Pager.Items(pagingCount).PerPage(recordPerPage).Move(page ?? 1).Segment(10).Center();

            return View(clientListing);
        }

        public ActionResult Active()
        {
            ClientLogics _logic = new ClientLogics();

            List<ClientSetupDisplayModel> clientListing = _logic.ClientSetupsAllActiveGet();

            return View(clientListing);

        }

        public ActionResult Edit(int? id, int? clientID)
        {
            ClientLogics _logic = new ClientLogics();
            ClientSetupDisplayModel setup = _logic.ClientSetupGetByID(id, clientID); 
            return View(setup);
        }

        [HttpPost]
        public ActionResult Edit(ClientSetupDisplayModel setup)
        {
            ClientLogics _logic = new ClientLogics();

            if (ModelState.IsValid)
            {
                bool updateStatus = _logic.ClientSetupUpdateByID(setup);

                if (updateStatus)
                {
                    //redirect if it was a create
                    if (setup.setupID == null)
                    {
                        return Redirect("/clientsetup?clientid=" + setup.clientID);
                    }

                    ViewBag.Message = FrontEndHelper.MessageDisplayWrapper("Client setup details successfully updated", FrontEndHelper.BootstrapAlertType.Success);
                    return Edit(setup.setupID, null);
                }
                else
                    ViewBag.Message = FrontEndHelper.MessageDisplayWrapper("Failed to update client setup details. ClientSetup and PT consistency check required.", FrontEndHelper.BootstrapAlertType.Danger);
            }

            //error, reconstruct
            ClientSetupDisplayModel setupFromDB = _logic.ClientSetupGetByID(setup.setupID, setup.clientID);

            setup.available_PT = setupFromDB.available_PT;
            setup.clientName = setupFromDB.clientName;

            return View(setup);
        }

        public ActionResult ClientSetupsGet(int clientID)
        {
            ClientLogics _logic = new ClientLogics();

            List<ClientSetupDisplayModel> setups = _logic.ClientSetupsGet(clientID);

            return Json(setups, JsonRequestBehavior.AllowGet);
        }

    }
}
