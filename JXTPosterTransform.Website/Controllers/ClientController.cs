using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JXTPosterTransform.Website.Models;
using JXTPosterTransform.Website.Logics;
using System.Configuration;

namespace JXTPosterTransform.Website.Controllers
{
    public class ClientController : Controller
    {

        public ActionResult Index(int? page)
        {
            ClientLogics _logic = new ClientLogics();
            int pagingCount = 0, recordPerPage = int.Parse(ConfigurationManager.AppSettings["AdminListingPageCount"]);

            List<ClientDisplayModel> clientListing = _logic.ClientListingGet(null, recordPerPage, page ?? 1, out pagingCount);

            ViewBag.Pager = Pager.Items(pagingCount).PerPage(recordPerPage).Move(page ?? 1).Segment(10).Center();

            return View(clientListing);
        }


        public ActionResult Edit(int? id)
        {
            ClientDisplayModel clientListing;

            if (id.HasValue)
            {
                ClientLogics _logic = new ClientLogics();
                clientListing = _logic.ClientProfileGet(id.Value);
            }
            else
                clientListing = new ClientDisplayModel();
            return View(clientListing);
        }

        [HttpPost]
        public ActionResult Edit(ClientDisplayModel client)
        {
            ClientLogics _logic = new ClientLogics();
            if (ModelState.IsValid)
            {
                string errorMsg;
                bool updateClient = _logic.ClientProfileDetailsUpdate(client, out errorMsg);

                if (updateClient)
                {
                    ViewBag.Message = FrontEndHelper.MessageDisplayWrapper("Client details updated successfully", FrontEndHelper.BootstrapAlertType.Success);

                    //if is create, redirect to index when success
                    if (client.clientID == 0)
                        return Redirect("/clientsetup");
                }
                else
                {
                    ViewBag.Message = FrontEndHelper.MessageDisplayWrapper(errorMsg, FrontEndHelper.BootstrapAlertType.Danger);
                }
            }

            //reconstruct
            ClientDisplayModel clientListing = _logic.ClientProfileGet(client.clientID);
            client.lastModifiedBy = clientListing.lastModifiedBy;
            client.lastModifiedDate = clientListing.lastModifiedDate;
            return View(client);
        }

    }
}
