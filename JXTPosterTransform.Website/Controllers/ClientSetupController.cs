using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JXTPosterTransform.Website.Logics;
using JXTPosterTransform.Website.Models;
using System.Configuration;
using JXTPosterTransform.Library.Common;
using JXTPosterTransform.Library.Models;
using JXTPosterTransform.Library.Services;
using Newtonsoft.Json;

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


        #region Invenias

        public ActionResult GenerateJXTLocationsForInveniasImport(int setupID)
        {            
            ClientLogics _logic = new ClientLogics();
            ClientSetupDisplayModel setup = _logic.ClientSetupGetByID(setupID, null);

            if (setup != null && setup.advertiserID != null && !string.IsNullOrEmpty(setup.advertiserUsername) && !string.IsNullOrEmpty(setup.advertiserPassword))
            {
                DefaultResponse JXTResponses = new TransformationService().AvailableDataJXTPlatformGet(setup.advertiserUsername, setup.advertiserPassword, setup.advertiserID.ToString());

                //root
                InveniasCategory root = new InveniasCategory { FileAs = "JXT Country / Location / Area" };

                //Get Unique Countries
                List<int> countryIDs = JXTResponses.DefaultList.CountryLocationAreas.Select(c => int.Parse(c.CountryID)).Distinct().ToList();

                foreach (int cID in countryIDs)
                {
                    DefaultList.CountryLocationArea thisCountryNode = JXTResponses.DefaultList.CountryLocationAreas.Where(c => int.Parse(c.CountryID) == cID).FirstOrDefault();

                    InveniasCategory thisCountryCategory = new InveniasCategory { FileAs = thisCountryNode.CountryName, Children = new List<InveniasCategory>() };

                    //all locations
                    List<int> locationIDsUnderCountry = JXTResponses.DefaultList.CountryLocationAreas.Where(c => int.Parse(c.CountryID) == cID).Select(c => int.Parse(c.LocationID)).Distinct().ToList();

                    foreach (int locID in locationIDsUnderCountry)
                    {
                        DefaultList.CountryLocationArea thisLocationNode = JXTResponses.DefaultList.CountryLocationAreas.Where(c => int.Parse(c.CountryID) == cID && int.Parse(c.LocationID) == locID).FirstOrDefault();

                        InveniasCategory thisLocationCategory = new InveniasCategory { FileAs = thisLocationNode.LocationName, Children = new List<InveniasCategory>() };

                        //find all areas under this location
                        List<DefaultList.CountryLocationArea> areas = JXTResponses.DefaultList.CountryLocationAreas.Where(c => int.Parse(c.CountryID) == cID && int.Parse(c.LocationID) == locID).ToList();

                        foreach (DefaultList.CountryLocationArea area in areas)
                        {
                            InveniasCategory thisAreaCategory = new InveniasCategory { FileAs = area.AreaName };
                            thisLocationCategory.Children.Add(thisAreaCategory);
                        }

                        thisCountryCategory.Children.Add(thisLocationCategory);
                    }

                    root.Children.Add(thisCountryCategory);
                }

                string jsonOutput = JsonConvert.SerializeObject(root);

                return Json(new { Success = true, Message = jsonOutput }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Success = false, Message = "Invalid setup details" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GenerateJXTPRsForInveniasImport(int setupID)
        {
            ClientLogics _logic = new ClientLogics();
            ClientSetupDisplayModel setup = _logic.ClientSetupGetByID(setupID, null);

            if (setup != null && setup.advertiserID != null && !string.IsNullOrEmpty(setup.advertiserUsername) && !string.IsNullOrEmpty(setup.advertiserPassword))
            {
                DefaultResponse JXTResponses = new TransformationService().AvailableDataJXTPlatformGet(setup.advertiserUsername, setup.advertiserPassword, setup.advertiserID.ToString());

                //root
                InveniasCategory root = new InveniasCategory { FileAs = "JXT Classifications / SubClassifications" };

                //Get Unique Countries
                List<int> ProfIDs = JXTResponses.DefaultList.ProfessionRoles.Select(c => int.Parse(c.ProfessionID)).Distinct().ToList();

                foreach (int pID in ProfIDs)
                {
                    DefaultList.ProfessionRole thisProfNode = JXTResponses.DefaultList.ProfessionRoles.Where(c => int.Parse(c.ProfessionID) == pID).FirstOrDefault();

                    InveniasCategory thisProfCategory = new InveniasCategory { FileAs = thisProfNode.ProfessionName, Children = new List<InveniasCategory>() };

                    //all locations
                    List<int> RoleIDsUnderProf = JXTResponses.DefaultList.ProfessionRoles.Where(c => int.Parse(c.ProfessionID) == pID).Select(c => int.Parse(c.RoleID)).Distinct().ToList();

                    foreach (int rID in RoleIDsUnderProf)
                    {
                        DefaultList.ProfessionRole thisRoleNode = JXTResponses.DefaultList.ProfessionRoles.Where(c => int.Parse(c.ProfessionID) == pID && int.Parse(c.RoleID) == rID).FirstOrDefault();

                        InveniasCategory thisRoleCategory = new InveniasCategory { FileAs = thisRoleNode.RoleID, Children = new List<InveniasCategory>() };

                        thisProfCategory.Children.Add(thisRoleCategory);
                    }

                    root.Children.Add(thisProfCategory);
                }

                string jsonOutput = JsonConvert.SerializeObject(root);

                return Json(new { Success = true, Message = jsonOutput }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Success = false, Message = "Invalid setup details" }, JsonRequestBehavior.AllowGet);
            }
        }

        public class InveniasCategory
        {
            public string FileAs { get; set; }
            public string SovrenCode { get; set; }
            public List<InveniasCategory> Children { get; set; }

            public InveniasCategory()
            {
                SovrenCode = null;
                Children = new List<InveniasCategory>();
            }
        }


        #endregion

    }
}
