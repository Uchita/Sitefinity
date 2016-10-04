using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JXTPosterTransform.Website.Logics;
using JXTPosterTransform.Website.Models;
using System.Web.Script.Serialization;
using JXTPosterTransform.Library.Models;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.IO;

namespace JXTPosterTransform.Website.Controllers
{
    public class MappingsController : Controller
    {
        //
        // GET: /Mappings/

        public ActionResult JobTemplate(int id, int setupID)
        {
            int clientID = id;
            int clientSetupID = setupID;

            MappingsLogic ml = new MappingsLogic();

            //get existing xml
            string errorMsgGet;
            MappingsXMLModel mapXML = ml.ClientMappingsGet(null, clientSetupID, out errorMsgGet);

            string errorMsgAvailableGet;
            JobTemplateMappingModel mapModel = new JobTemplateMappingModel
            {
                availableJobTemplates = new JobParamLogics().JobTemplateAvailableMappingGetByClientID(clientID, out errorMsgAvailableGet),
                Mappings = mapXML == null ? new List<JobTemplateMap>() : mapXML.JobTemplateMaps.OrderBy(c => c.ClientJobTemplateID).ToList()
            };

            ViewBag.Message = errorMsgAvailableGet == null ? null : FrontEndHelper.MessageDisplayWrapper(errorMsgAvailableGet, FrontEndHelper.BootstrapAlertType.Warning);
            ViewBag.MappingTargetID = clientID;
            ViewBag.MappingTargetSetupID = clientSetupID;
            return View(mapModel);
        }

        [HttpPost]
        public ActionResult JobTemplate(int id, int setupID, JobTemplateMap[] submit)
        {
            int clientID = id;
            int clientSetupID = setupID;

            if (ModelState.IsValid)
            {
                //check for duplicates
                bool hasDuplicates = false;
                List<JobTemplateMap> duplicateList = submit.GroupBy(x => x.MapToStringGet())
                                              .Where(g => g.Count() > 1)
                                              .SelectMany(y => y)
                                              .Distinct()
                                              .ToList();

                for (int i = 0; i < submit.Count(); i++)
                {
                    if (duplicateList.Where(c => !string.IsNullOrEmpty(c.MapToStringGet()) && c.MapToStringGet() == submit[i].MapToStringGet()).Any())
                    {
                        //add to model error
                        ModelState.AddModelError("submit[" + i + "].ClientJobTemplateID", "Duplicate data row detected");
                        hasDuplicates = true;
                    }
                }

                if (!hasDuplicates)
                {
                    MappingsLogic ml = new MappingsLogic();
                    //get existing xml
                    string errorMsgGet;
                    MappingsXMLModel mapXML = ml.ClientMappingsGet(null, clientSetupID, out errorMsgGet);

                    List<JobTemplateMap> validMaps = (from m in submit where m.isValidRow() select m).ToList();

                    if (mapXML == null)
                        mapXML = new MappingsXMLModel();

                    mapXML.JobTemplateMaps = validMaps;

                    //put back xml
                    string errorMsgPut;
                    ml.ClientMappingsStore(null, clientSetupID, mapXML, out errorMsgPut);

                    if (string.IsNullOrEmpty(errorMsgPut))
                        TempData["Message"] = FrontEndHelper.MessageDisplayWrapper("Job Template mappings updated successfully", FrontEndHelper.BootstrapAlertType.Success);
                    else
                        TempData["Message"] = FrontEndHelper.MessageDisplayWrapper(errorMsgPut, FrontEndHelper.BootstrapAlertType.Danger);

                    return Redirect("/mappings/jobtemplate/" + clientID + "/" + setupID);
                }
            }
            //error, reconstruct
            string errorMsgAvailableGet;
            JobTemplateMappingModel mapModel = new JobTemplateMappingModel
            {
                availableJobTemplates = new JobParamLogics().JobTemplateAvailableMappingGetByClientID(clientID, out errorMsgAvailableGet),
                Mappings = submit.ToList()
            };

            ViewBag.Message = FrontEndHelper.MessageDisplayWrapper(errorMsgAvailableGet, FrontEndHelper.BootstrapAlertType.Warning);
            ViewBag.MappingTargetID = clientID;
            ViewBag.MappingTargetSetupID = clientSetupID;
            return View(mapModel);
        }

        public ActionResult TemplateLogo(int id, int setupID)
        {
            int clientID = id;
            int clientSetupID = setupID;

            MappingsLogic ml = new MappingsLogic();
            //get existing xml
            string errorMsgGet;
            MappingsXMLModel mapXML = ml.ClientMappingsGet(null, clientSetupID, out errorMsgGet);

            string errorMsgAvailableGet;
            JobTemplateLogoMappingModel jtlMapModel = new JobTemplateLogoMappingModel
            {
                availableJobTemplateLogos = new JobParamLogics().JobTemplateLogosAvailableMappingGetByClientID(clientID, out errorMsgAvailableGet),
                Mappings = mapXML == null ? new List<JobTemplateLogoMap>() : mapXML.JobTemplateLogoMaps.OrderBy(c=>c.ClientJobTemplateLogoID).ToList()
            };

            ViewBag.Message = errorMsgAvailableGet == null ? null : FrontEndHelper.MessageDisplayWrapper(errorMsgAvailableGet, FrontEndHelper.BootstrapAlertType.Warning);
            ViewBag.MappingTargetID = clientID;
            ViewBag.MappingTargetSetupID = clientSetupID;
            return View(jtlMapModel);
        }

        [HttpPost]
        public ActionResult TemplateLogo(int id, int setupID, JobTemplateLogoMap[] submit)
        {
            int clientID = id;
            int clientSetupID = setupID;

            if (ModelState.IsValid)
            {
 //check for duplicates
                bool hasDuplicates = false;
                List<JobTemplateLogoMap> duplicateList = submit.GroupBy(x => x.MapToStringGet())
                                              .Where(g => g.Count() > 1)
                                              .SelectMany(y => y)
                                              .Distinct()
                                              .ToList();

                for (int i = 0; i < submit.Count(); i++)
                {
                    if (duplicateList.Where(c => !string.IsNullOrEmpty(c.MapToStringGet()) && c.MapToStringGet() == submit[i].MapToStringGet()).Any())
                    {
                        //add to model error
                        ModelState.AddModelError("submit[" + i + "].ClientJobTemplateID", "Duplicate data row detected");
                        hasDuplicates = true;
                    }
                }

                if (!hasDuplicates)
                {
                    MappingsLogic ml = new MappingsLogic();
                    //get existing xml
                    string errorMsgGet;
                    MappingsXMLModel mapXML = ml.ClientMappingsGet(null, clientSetupID, out errorMsgGet);

                    List<JobTemplateLogoMap> validMaps = (from m in submit where m.isValidRow() select m).ToList();

                    if (mapXML == null)
                        mapXML = new MappingsXMLModel();

                    mapXML.JobTemplateLogoMaps = validMaps;

                    //put back xml
                    string errorMsgPut;
                    ml.ClientMappingsStore(null, clientSetupID, mapXML, out errorMsgPut);

                    if (string.IsNullOrEmpty(errorMsgPut))
                        TempData["Message"] = FrontEndHelper.MessageDisplayWrapper("Job Template Logo mappings updated successfully", FrontEndHelper.BootstrapAlertType.Success);
                    else
                        TempData["Message"] = FrontEndHelper.MessageDisplayWrapper(errorMsgPut, FrontEndHelper.BootstrapAlertType.Danger);

                    return Redirect("/mappings/templatelogo/" + clientID + "/" + clientSetupID);
                }
            }
            //error, reconstruct
            string errorMsgAvailableGet;
            JobTemplateLogoMappingModel jtlMapModel = new JobTemplateLogoMappingModel
            {
                availableJobTemplateLogos = new JobParamLogics().JobTemplateLogosAvailableMappingGetByClientID(clientID, out errorMsgAvailableGet),
                Mappings = submit.ToList()
            };

            ViewBag.Message = FrontEndHelper.MessageDisplayWrapper("Failed to save mapping details. Please try again.", FrontEndHelper.BootstrapAlertType.Warning);
            ViewBag.MappingTargetID = clientID;
            ViewBag.MappingTargetSetupID = clientSetupID;
            return View(jtlMapModel);
        }

        public ActionResult ProfessionRole(int id)
        {
            int clientID = id;

            MappingsLogic ml = new MappingsLogic();
            //get existing xml
            string errorMsgGet;
            MappingsXMLModel mapXML = ml.ClientMappingsGet(clientID, null, out errorMsgGet);

            string errorMsgAvailableGet;
            ProfessionRoleMappingModel prMapModel = new ProfessionRoleMappingModel
            {
                availableProfessions = new JobParamLogics().PRAvailableMappingGetByClientID(clientID, out errorMsgAvailableGet),
                Mappings = mapXML == null ? new List<ProfessionRoleMap>() : mapXML.ProfRoleMaps.OrderBy(c=>c.ClientProfessionID).ThenBy(c=>c.ClientRoleID).ToList()
            };

            ViewBag.Message = errorMsgAvailableGet == null ? null : FrontEndHelper.MessageDisplayWrapper(errorMsgAvailableGet, FrontEndHelper.BootstrapAlertType.Warning);
            ViewBag.MappingTargetID = clientID;
            return View(prMapModel);
        }

        [HttpPost]
        public ActionResult ProfessionRole(int id, ProfessionRoleMap[] submit)
        {
            int clientID = id;

            if (ModelState.IsValid)
            {
                //check for duplicates
                bool hasDuplicates = false;
                List<ProfessionRoleMap> duplicateList = submit.GroupBy(x => x.MapToStringGet())
                                              .Where(g => g.Count() > 1)
                                              .SelectMany(y => y)
                                              .Distinct()
                                              .ToList();

                for (int i = 0; i < submit.Count(); i++)
                {
                    if (duplicateList.Where(c => !string.IsNullOrEmpty(c.MapToStringGet()) && c.MapToStringGet() == submit[i].MapToStringGet()).Any())
                    {
                        //add to model error
                        ModelState.AddModelError("submit[" + i + "].ClientProfessionID", "Duplicate data row detected");
                        hasDuplicates = true;
                    }
                }

                if (!hasDuplicates)
                {
                    MappingsLogic ml = new MappingsLogic();
                    //get existing xml
                    string errorMsgGet;
                    MappingsXMLModel mapXML = ml.ClientMappingsGet(clientID, null, out errorMsgGet);

                    List<ProfessionRoleMap> validMaps = (from m in submit where m.isValidRow() select m).ToList();

                    if (mapXML == null)
                        mapXML = new MappingsXMLModel();

                    mapXML.ProfRoleMaps = validMaps;

                    //put back xml
                    string errorMsgPut;
                    ml.ClientMappingsStore(clientID, null, mapXML, out errorMsgPut);

                    if (string.IsNullOrEmpty(errorMsgPut))
                        TempData["Message"] = FrontEndHelper.MessageDisplayWrapper("Profession Role mappings updated successfully", FrontEndHelper.BootstrapAlertType.Success);
                    else
                        TempData["Message"] = FrontEndHelper.MessageDisplayWrapper(errorMsgPut, FrontEndHelper.BootstrapAlertType.Danger);

                    return Redirect("/mappings/professionrole/" + clientID);
                }
            }
            //error, reconstruct
            string errorMsgAvailableGet;
            ProfessionRoleMappingModel prMapModel = new ProfessionRoleMappingModel
            {
                availableProfessions = new JobParamLogics().PRAvailableMappingGetByClientID(clientID, out errorMsgAvailableGet),
                Mappings = submit.ToList()
            };

            ViewBag.Message = FrontEndHelper.MessageDisplayWrapper("Failed to save mapping details. Please try again.", FrontEndHelper.BootstrapAlertType.Warning);
            ViewBag.MappingTargetID = clientID; 
            return View(prMapModel);
        }

        public ActionResult WorkType(int id)
        {
            int clientID = id;

            MappingsLogic ml = new MappingsLogic();
            //get existing xml
            string errorMsgGet;
            MappingsXMLModel mapXML = ml.ClientMappingsGet(clientID, null, out errorMsgGet);

            string errorMsgAvailableGet;
            WorkTypeMappingModel wtMapModel = new WorkTypeMappingModel
            {
                availableWorkTypes = new JobParamLogics().WorkTypesAvailableMappingGetByClientID(clientID, out errorMsgAvailableGet),
                Mappings = mapXML == null ? new List<WorkTypeMap>() : mapXML.WorkTypeMaps.OrderBy(c=>c.ClientWorkTypeID).ToList()

            };

            ViewBag.Message = errorMsgAvailableGet == null ? null : FrontEndHelper.MessageDisplayWrapper(errorMsgAvailableGet, FrontEndHelper.BootstrapAlertType.Warning);
            ViewBag.MappingTargetID = clientID;
            return View(wtMapModel);
        }

        [HttpPost]
        public ActionResult WorkType(int id, WorkTypeMap[] submit)
        {
            int clientID = id;

            if (ModelState.IsValid)
            {
                                //check for duplicates
                bool hasDuplicates = false;
                List<WorkTypeMap> duplicateList = submit.GroupBy(x => x.MapToStringGet())
                                              .Where(g => g.Count() > 1)
                                              .SelectMany(y => y)
                                              .Distinct()
                                              .ToList();

                for (int i = 0; i < submit.Count(); i++)
                {
                    if (duplicateList.Where(c => !string.IsNullOrEmpty(c.MapToStringGet()) && c.MapToStringGet() == submit[i].MapToStringGet()).Any())
                    {
                        //add to model error
                        ModelState.AddModelError("submit[" + i + "].ClientWorkTypeID", "Duplicate data row detected");
                        hasDuplicates = true;
                    }
                }

                if (!hasDuplicates)
                {
                    MappingsLogic ml = new MappingsLogic();
                    //get existing xml
                    string errorMsgGet;
                    MappingsXMLModel mapXML = ml.ClientMappingsGet(clientID, null, out errorMsgGet);

                    List<WorkTypeMap> validMaps = (from m in submit where m.isValidRow() select m).ToList();

                    if (mapXML == null)
                        mapXML = new MappingsXMLModel();

                    mapXML.WorkTypeMaps = validMaps;

                    //put back xml
                    string errorMsgPut;
                    ml.ClientMappingsStore(clientID, null, mapXML, out errorMsgPut);

                    if (string.IsNullOrEmpty(errorMsgPut))
                        TempData["Message"] = FrontEndHelper.MessageDisplayWrapper("Work Type mappings updated successfully", FrontEndHelper.BootstrapAlertType.Success);
                    else
                        TempData["Message"] = FrontEndHelper.MessageDisplayWrapper(errorMsgPut, FrontEndHelper.BootstrapAlertType.Danger);

                    return Redirect("/mappings/worktype/" + clientID);
                }
            }

            //error, reconstruct
            string errorMsgAvailableGet;
            WorkTypeMappingModel wtMapModel = new WorkTypeMappingModel
            {
                availableWorkTypes = new JobParamLogics().WorkTypesAvailableMappingGetByClientID(clientID, out errorMsgAvailableGet),
                Mappings = submit.ToList()
            };

            ViewBag.Message = FrontEndHelper.MessageDisplayWrapper("Failed to save mapping details. Please try again.", FrontEndHelper.BootstrapAlertType.Warning);
            ViewBag.MappingTargetID = clientID;
            return View(wtMapModel);
        }


        public ActionResult CountryLocArea(int id)
        {
            int clientID = id;

            MappingsLogic ml = new MappingsLogic();
            //get existing xml
            string errorMsgGet;
            MappingsXMLModel mapXML = ml.ClientMappingsGet(clientID, null, out errorMsgGet);

            //if (mapXML != null)
            //{
            //    JavaScriptSerializer jss = new JavaScriptSerializer();
            //    string jsonData = jss.Serialize(CLA_Data);

            //    ViewBag.CLAJsonData = jsonData;
            //}

            string errorMsgAvailableGet;
            CLAMappingModel claMapModel = new CLAMappingModel
            {
                availableCLA = new JobParamLogics().CLAAvailableMappingGetByClientID(clientID, out errorMsgAvailableGet),
                Mappings = mapXML == null ? new List<CLAMap>() : mapXML.CLAMaps.OrderBy(c=>c.ClientCountryID).ThenBy(c=>c.ClientLocationID).ThenBy(c=>c.ClientAreaID).ToList()
            };


            ViewBag.Message = errorMsgAvailableGet == null ? null : FrontEndHelper.MessageDisplayWrapper(errorMsgAvailableGet, FrontEndHelper.BootstrapAlertType.Warning);
            ViewBag.MappingTargetID = clientID;
            return View(claMapModel);
        }

        [HttpPost]
        public ActionResult CountryLocArea(int id, CLAMap[] submit)
        {
            int clientID = id;

            if (ModelState.IsValid)
            {
                //check for duplicates
                bool hasDuplicates = false;
                List<CLAMap> duplicateList = submit.GroupBy(x => x.MapToStringGet())
                                              .Where(g => g.Count() > 1)
                                              .SelectMany(y => y)
                                              .Distinct()
                                              .ToList();
                
                for(int i=0; i<submit.Count();i++)
                {
                    if( duplicateList.Where(c=> !string.IsNullOrEmpty(c.MapToStringGet()) && c.MapToStringGet() == submit[i].MapToStringGet()).Any() )
                    {
                        //add to model error
                        ModelState.AddModelError("submit[" + i + "].ClientCountryID", "Duplicate data row detected");
                        hasDuplicates = true;
                    }
                }

                if (!hasDuplicates)
                {
                    MappingsLogic ml = new MappingsLogic();
                    //get existing xml
                    string errorMsgGet;
                    MappingsXMLModel mapXML = ml.ClientMappingsGet(clientID, null, out errorMsgGet);

                    //TODO: replace CLA to mapXML
                    List<CLAMap> validMaps = (from m in submit where m.isValidRow() select m).ToList();

                    if (mapXML == null)
                        mapXML = new MappingsXMLModel();

                    mapXML.CLAMaps = validMaps;

                    //put back xml
                    string errorMsgPut;
                    ml.ClientMappingsStore(clientID, null, mapXML, out errorMsgPut);

                    if (string.IsNullOrEmpty(errorMsgPut))
                        TempData["Message"] = FrontEndHelper.MessageDisplayWrapper("Country/Location/Area mappings updated successfully", FrontEndHelper.BootstrapAlertType.Success);
                    else
                        TempData["Message"] = FrontEndHelper.MessageDisplayWrapper(errorMsgPut, FrontEndHelper.BootstrapAlertType.Danger);

                    return Redirect("/mappings/countrylocarea/" + clientID);
                }
            }

            //error, reconstruct
            string errorMsgAvailableGet;
            CLAMappingModel claMapModel = new CLAMappingModel
            {
                availableCLA = new JobParamLogics().CLAAvailableMappingGetByClientID(clientID, out errorMsgAvailableGet),
                Mappings = submit.ToList()
            };

            ViewBag.Message = FrontEndHelper.MessageDisplayWrapper("Failed to save mapping details. Please try again.", FrontEndHelper.BootstrapAlertType.Warning);
            ViewBag.MappingTargetID = clientID;
            return View(claMapModel);
        }


        //public ActionResult SalaryType(int id)
        //{
        //    int clientID = id;

        //    MappingsLogic ml = new MappingsLogic();
        //    //get existing xml
        //    string errorMsgGet;
        //    MappingsXMLModel mapXML = ml.ClientMappingsGet(clientID, null, out errorMsgGet);

        //    string errorMsgAvailableGet;
        //    SalaryTypeMappingModel sample = new SalaryTypeMappingModel
        //    {
        //        availableSalaryTypes = new JobParamLogics().SalaryTypesAvailableMappingGetByClientID(clientID, out errorMsgAvailableGet),
        //        Mappings = mapXML == null ? new List<SalaryTypeMap>() : mapXML.SalaryTypeMaps

        //    };

        //    ViewBag.Message = errorMsgAvailableGet == null ? null : FrontEndHelper.MessageDisplayWrapper(errorMsgAvailableGet, FrontEndHelper.BootstrapAlertType.Warning);
        //    ViewBag.MappingTargetID = clientID;
        //    return View(sample);
        //}

        //[HttpPost]
        //public ActionResult SalaryType(int id, WorkTypeMap[] submit)
        //{
        //    int clientID = id;

        //    if (ModelState.IsValid)
        //    {
        //        MappingsLogic ml = new MappingsLogic();
        //        //get existing xml
        //        string errorMsgGet;
        //        MappingsXMLModel mapXML = ml.ClientMappingsGet(clientID, null, out errorMsgGet);

        //        List<WorkTypeMap> validMaps = (from m in submit where m.isValidRow() select m).ToList();

        //        if (mapXML == null)
        //            mapXML = new MappingsXMLModel();

        //        mapXML.WorkTypeMaps = validMaps;

        //        //put back xml
        //        string errorMsgPut;
        //        ml.ClientMappingsStore(clientID, null, mapXML, out errorMsgPut);

        //        if (string.IsNullOrEmpty(errorMsgPut))
        //            TempData["Message"] = FrontEndHelper.MessageDisplayWrapper("Work Type mappings updated successfully", FrontEndHelper.BootstrapAlertType.Success);
        //        else
        //            TempData["Message"] = FrontEndHelper.MessageDisplayWrapper(errorMsgPut, FrontEndHelper.BootstrapAlertType.Danger);


        //        return Redirect("/mappings/worktype/" + clientID);
        //    }

        //    //error, reconstruct
        //    return View();
        //}

        [HttpPost]
        public ActionResult ExcelUploadProcessor()
        {
            RowReturn result = new RowReturn();

            string imgGUID = Guid.NewGuid().ToString();

            string thisCellValue1 = string.Empty;
            string thisCellValue2 = string.Empty;
            string thisCellValue3 = string.Empty;
            DataRow thisRow = null;
            List<RowReturn> rows = new List<RowReturn>();

            foreach (string k in Request.Files.Keys)
            {
                HttpPostedFileBase thisFile = Request.Files.Get(k);

                if (thisFile.ContentLength > 0 && (thisFile.FileName.ToUpper().Contains(".XLS") || thisFile.FileName.ToUpper().Contains(".XLSX")))
                {
                    //save to temp location
                    string fileLocation = SaveUploadedFileToTempLocation(thisFile);

                    //process file @ temp location
                    DataSet ds;

                    //specifically checks for the incorrect excel sheet name
                    try
                    {
                        ds = ProcessDataSet(fileLocation);

                        rows = new List<RowReturn>();

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            thisRow = ds.Tables[0].Rows[i];

                            thisCellValue1 = (thisRow.ItemArray.Count() > 0 && thisRow[0] != null) ? thisRow[0].ToString().Trim() : string.Empty;
                            thisCellValue2 = (thisRow.ItemArray.Count() > 1 && thisRow[1] != null) ? thisRow[1].ToString().Trim() : string.Empty;
                            thisCellValue3 = (thisRow.ItemArray.Count() > 2 && thisRow[1] != null) ? thisRow[2].ToString().Trim() : string.Empty;

                            RowReturn newRow = new RowReturn
                            {
                                str1 = thisCellValue1,
                                str2 = thisCellValue2,
                                str3 = thisCellValue3
                            };
                            rows.Add(newRow);
                        }

                        RemoveUploadedFileFromTempLocation(fileLocation);
                        return Json(new { Success = true, rowData = rows }, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception ex)
                    {
                        RemoveUploadedFileFromTempLocation(fileLocation);
                        return Json(new { Success = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { Success = false, Message = "Invalid file. Only Microsoft Excel files are accepted (xls, xlsx)." }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
        }

        private string SaveUploadedFileToTempLocation(HttpPostedFileBase postedFile)
        {
            if (!System.IO.Directory.Exists(Server.MapPath("~") + ConfigurationManager.AppSettings["TempFolderRelativePath"]))
            {
                Directory.CreateDirectory(Server.MapPath("~") + ConfigurationManager.AppSettings["TempFolderRelativePath"]);
            }

            string fileExtension = Path.GetExtension(postedFile.FileName);
            string fileLocation = Server.MapPath("~") + ConfigurationManager.AppSettings["TempFolderRelativePath"] + Guid.NewGuid().ToString() + fileExtension;
            postedFile.SaveAs(fileLocation);

            return fileLocation;
        }

        private void RemoveUploadedFileFromTempLocation(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }

        private DataSet ProcessDataSet(string fileLocation)
        {
            DataSet ds = new DataSet();

            string connectingString = string.Empty;
            //if (fileExtension == ".xls")
            //    connectingString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=2\"";
            //else
            connectingString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";" + "Extended Properties='Excel 12.0 Xml;HDR=NO;IMEX=1'";

            // Create OleDb Connection and OleD Command
            using (OleDbConnection con = new OleDbConnection(connectingString))
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(cmd);
                //DataTable dtExcelRecords = new DataTable();
                con.Open();
                DataTable dtExcelSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string firstSheetName = dtExcelSheetName.Rows[0]["TABLE_NAME"].ToString();
                cmd.CommandText = "Select * FROM [" + firstSheetName + "]";
                dAdapter.SelectCommand = cmd;
                //dAdapter.Fill(dtExcelRecords);
                dAdapter.Fill(ds);
            }
            return ds;
        }

        public class RowReturn
        {
            public string str1 { get; set; }
            public string str2 { get; set; }
            public string str3 { get; set; }
        }
    }

}
