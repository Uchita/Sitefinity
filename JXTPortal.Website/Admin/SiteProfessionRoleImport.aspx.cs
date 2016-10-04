using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using JXTPortal;
using JXTPortal.Entities;
using System.Text;
using System.Xml;
using System.Configuration;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace JXTPortal.Website.Admin
{
    public partial class SiteProfessionRoleImport : System.Web.UI.Page
    {
        internal class ProfessionRoles
        {
            public string ProfessionName { get; set; }
            public string RoleName { get; set; }

            public ProfessionRoles()
            {
            }
        }

        public class ProfessionAction
        {
            public int ProfessionID { get; set; }
            public string ProfessionName { get; set; }
            public string MulitLingualName { get; set; }
            public string Action { get; set; }
            public List<RoleAction> RolesAction { get; set; }

            public ProfessionAction()
            {
                RolesAction = new List<RoleAction>();
            }
        }

        public class RoleAction
        {
            public int RoleID { get; set; }
            public string RoleName { get; set; }
            public string MulitLingualName { get; set; }
            public int ProfessionID { get; set; }
            public string ProfessionName { get; set; }
            public string ProfessionMultiLingualName { get; set; }
            public string Action { get; set; }

            public RoleAction()
            {
            }
        }

        public class LanguageItem
        {
            public int LanguageIndex { get; set; }
            public string ProfessionValue { get; set; }
            public string RoleValue { get; set; }
        }

        public class ProfessionActionComparer : IComparer<ProfessionAction>
        {
            public int Compare(ProfessionAction a, ProfessionAction b)
            {
                if (b.ProfessionID > 0 && a.ProfessionID == 0)
                {
                    return 1;
                }
                else if (b.ProfessionID == 0 && a.ProfessionID > 0)
                {
                    return -1;
                }
                else
                {
                    return string.Compare(a.ProfessionName, b.ProfessionName, true);
                }
            }
        }

        public class RoleActionComparer : IComparer<RoleAction>
        {
            public int Compare(RoleAction a, RoleAction b)
            {
                if (b.RoleID > 0 && a.RoleID == 0)
                {
                    return 1;
                }
                else if (b.RoleID == 0 && a.RoleID > 0)
                {
                    return -1;
                }
                else
                {
                    return string.Compare(a.RoleName, b.RoleName, true);
                }
            }
        }

        private SiteLanguagesService _siteLanguagesService;

        private SiteLanguagesService SiteLanguagesService
        {
            get
            {
                if (_siteLanguagesService == null) _siteLanguagesService = new SiteLanguagesService();
                return _siteLanguagesService;
            }
        }

        private ProfessionService _professionService;

        private ProfessionService ProfessionService
        {
            get
            {
                if (_professionService == null) _professionService = new ProfessionService();
                return _professionService;
            }
        }

        private RolesService _rolesService;

        private RolesService RolesService
        {
            get
            {
                if (_rolesService == null) _rolesService = new RolesService();
                return _rolesService;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["Confirmed"] = false;
            }

            // Check if the Custom mapping then redirect.
            if (JXTPortal.Entities.SessionData.Site.UseCustomProfessionRole)
            {
                SiteCustomMappingService _service = new SiteCustomMappingService();
                SiteCustomMapping siteMapping = _service.GetAll().Find(s => s.SiteId == SessionData.Site.SiteId);

                // Check if there is custom mapping then redirect it.
                if (siteMapping != null)
                    Response.Redirect("SiteProfession.aspx");
            }

            if (!SessionData.Site.UseCustomProfessionRole)
            {
                Response.Redirect("SiteProfession.aspx");
            }

            ScriptManager.GetCurrent(this).RegisterPostBackControl(btnSubmit);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnDownloadSample);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnConfirm);
        }


        private void LoadExcel()
        {
            ltlMessage.Text = string.Empty;
            phConfirm.Visible = false;
            cbConfirm.Checked = false;
            btnConfirm.Visible = false;

            rptList.DataSource = null;
            rptList.DataBind();

            TList<Entities.SiteLanguages> lsl = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId);
            ArrayList fullList = new ArrayList(lsl.Count);
            ArrayList fullActionList = new ArrayList(lsl.Count);
            foreach (Entities.SiteLanguages sl in lsl)
            {
                fullList.Add(new List<ProfessionRoles>());
                fullActionList.Add(new List<ProfessionAction>());
            }

            if (docInput.PostedFile == null || docInput.HasFile == false || docInput.PostedFile.ContentLength == 0)
            {
                if ((bool)ViewState["Confirmed"] == false)
                {
                    ltlMessage.Text = "Invalid Excel file";
                    return;
                }
            }

            if (docInput.PostedFile != null && docInput.HasFile && docInput.PostedFile.ContentLength > 0)
            {
                if (docInput.PostedFile.FileName.ToLower().EndsWith(".xls") == false && docInput.PostedFile.FileName.ToLower().EndsWith(".xlsx") == false)
                {
                    ltlMessage.Text = "Invalid Excel format. Only .xls or xlsx are accepted";
                    return;
                }
            }


            try
            {
                if (docInput.PostedFile != null && docInput.HasFile && docInput.PostedFile.ContentLength > 0)
                {

                    string fileExtension = Path.GetExtension(docInput.PostedFile.FileName);
                    string fileLocation = Server.MapPath("~") + "uploads\\files\\" + Guid.NewGuid().ToString() + fileExtension;
                    docInput.PostedFile.SaveAs(fileLocation);
                    string sheetName = "Sheet1";

                    string value = string.Empty;
                    DataSet ds = new DataSet();
                    Row r = null;

                    DataTable dt = null;

                    string connectingString = string.Empty;
                    if (fileExtension == ".xls")
                    {
                        connectingString =
                            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                            fileLocation + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=2\"";

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

                            string getExcelSheetName = "Sheet1";
                            cmd.CommandText = "Select * FROM [" + getExcelSheetName + "$]";
                            dAdapter.SelectCommand = cmd;
                            //dAdapter.Fill(dtExcelRecords);
                            dAdapter.Fill(ds);
                        }
                    }
                    else
                    {
                        dt = ds.Tables.Add("Sheet1");

                        using (SpreadsheetDocument myDoc = SpreadsheetDocument.Open(fileLocation, false))
                        {
                            WorkbookPart workbookPart = myDoc.WorkbookPart;
                            IEnumerable<Sheet> Sheets = workbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>().Where(s => s.Name == sheetName);

                            WorksheetPart worksheetPart = (WorksheetPart)myDoc.WorkbookPart.GetPartById(Sheets.First().Id.Value);
                            SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                            SharedStringTablePart sharedstringtablepart = myDoc.WorkbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
                            SharedStringTable sharedStringTable = null;
                            if (sharedstringtablepart != null)
                            {
                                sharedStringTable = sharedstringtablepart.SharedStringTable;
                            }


                            for (int i = 0; i < sheetData.Elements<Row>().Count(); i++)
                            {
                                r = sheetData.Elements<Row>().ToArray()[i];

                                if (i == 0)
                                {
                                    if (r.Elements<Cell>().Count() % 2 == 1)
                                    {
                                        ltlMessage.Text = "Invalid Excel file";
                                        return;
                                    }

                                    if ((r.Elements<Cell>().Count() / 2) < lsl.Count)
                                    {
                                        ltlMessage.Text = "Please include all data associated with site languages";
                                        return;
                                    }

                                    foreach (Cell c in r.Elements<Cell>())
                                    {
                                        if (c.DataType == CellValues.String)
                                        {
                                            value = c.CellValue.InnerText;
                                        }
                                        else if (c.DataType == CellValues.SharedString)
                                        {
                                            value = sharedStringTable.ElementAt(int.Parse(c.InnerText)).InnerText;
                                        }

                                        dt.Columns.Add(value);
                                    }
                                }
                                else
                                {
                                    DataRow dr = dt.NewRow();

                                    for (int j = 0; j < r.Elements<Cell>().Count(); j++)
                                    {
                                        Cell c = r.Elements<Cell>().ToArray()[j];

                                        if (c.DataType == CellValues.String)
                                        {
                                            value = c.CellValue.InnerText;
                                        }
                                        else if (c.DataType == CellValues.SharedString)
                                        {
                                            value = sharedStringTable.ElementAt(int.Parse(c.InnerText)).InnerText;
                                        }

                                        dr[j] = value;
                                    }

                                    dt.Rows.Add(dr);
                                }
                            }
                        }
                    }

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        for (int i = 0; i < (ds.Tables[0].Columns.Count / 2) && i < lsl.Count; i++)
                        {
                            List<ProfessionRoles> lp = fullList[i] as List<ProfessionRoles>;
                            ProfessionRoles pr = new ProfessionRoles();
                            pr.ProfessionName = dr[i * 2].ToString();
                            pr.RoleName = dr[i * 2 + 1].ToString();

                            lp.Add(pr);
                        }
                    }


                }

                TList<Entities.Profession> currentpl = ProfessionService.GetByReferredSiteId(SessionData.Site.SiteId);

                for (int i = 0; i < lsl.Count; i++)
                {
                    List<ProfessionAction> lpa = fullActionList[i] as List<ProfessionAction>;
                    foreach (Entities.Profession p in currentpl)
                    {
                        ProfessionAction pa = new ProfessionAction();
                        pa.Action = "Existing";
                        pa.ProfessionID = p.ProfessionId;
                        pa.ProfessionName = p.ProfessionName;
                        pa.MulitLingualName = ProfessionService.GetTranslatedProfession(p.ProfessionId, lsl[i].LanguageId, true).ProfessionName;

                        lpa.Add(pa);
                    }
                }

                if (fullList.Count > 0)
                {
                    for (int index = 0; index < ((List<ProfessionRoles>)fullList[0]).Count; index++)
                    {
                        ProfessionRoles pr = ((List<ProfessionRoles>)fullList[0])[index];

                        bool found = false;

                        foreach (Entities.Profession p in currentpl)
                        {
                            if (p.ProfessionName == pr.ProfessionName)
                            {
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            for (int i = 0; i < lsl.Count; i++)
                            {
                                List<ProfessionAction> lpa = fullActionList[i] as List<ProfessionAction>;
                                ProfessionRoles mpr = ((List<ProfessionRoles>)fullList[i])[index];

                                ProfessionAction pa = new ProfessionAction();
                                pa.Action = "New";
                                pa.ProfessionName = pr.ProfessionName;
                                pa.MulitLingualName = mpr.ProfessionName;

                                bool pfound = false;
                                foreach (ProfessionAction epa in lpa)
                                {
                                    if (epa.ProfessionName == pa.ProfessionName)
                                    {
                                        pfound = true;
                                        break;
                                    }
                                }

                                if (!pfound)
                                {
                                    lpa.Add(pa);
                                }

                                phConfirm.Visible = true;
                            }
                        }
                    }

                    for (int index = 0; index < ((List<ProfessionAction>)fullActionList[0]).Count; index++)
                    {
                        ProfessionAction pa = ((List<ProfessionAction>)fullActionList[0])[index];

                        if (pa.ProfessionID > 0)
                        {
                            TList<Entities.Roles> lr = RolesService.GetByProfessionId(pa.ProfessionID);
                            foreach (Entities.Roles r in lr)
                            {
                                for (int i = 0; i < lsl.Count; i++)
                                {
                                    RoleAction ra = new RoleAction();
                                    ra.Action = "Existing";
                                    ra.ProfessionID = pa.ProfessionID;
                                    ra.ProfessionName = pa.ProfessionName;
                                    ra.ProfessionMultiLingualName = ((List<ProfessionAction>)fullActionList[i])[index].MulitLingualName;

                                    ra.RoleID = r.RoleId;
                                    ra.RoleName = r.RoleName;
                                    ra.MulitLingualName = RolesService.GetTranslatedRole(r.RoleId, lsl[i].LanguageId, true).RoleName;
                                    ((List<ProfessionAction>)fullActionList[i])[index].RolesAction.Add(ra);
                                }
                            }
                        }
                    }



                    for (int index = 0; index < ((List<ProfessionRoles>)fullList[0]).Count; index++)
                    {
                        ProfessionRoles pr = ((List<ProfessionRoles>)fullList[0])[index];

                        for (int i = 0; i < ((List<ProfessionAction>)fullActionList[0]).Count; i++)
                        {
                            ProfessionAction pa = ((List<ProfessionAction>)fullActionList[0])[i];

                            if (pr.ProfessionName == pa.ProfessionName)
                            {
                                bool found = false;
                                foreach (RoleAction ra in pa.RolesAction)
                                {
                                    if (ra.RoleName == pr.RoleName)
                                    {
                                        found = true;
                                        break;
                                    }
                                }

                                if (!found)
                                {
                                    for (int j = 0; j < lsl.Count; j++)
                                    {
                                        RoleAction ra = new RoleAction();
                                        ra.Action = "New";
                                        ra.ProfessionID = pa.ProfessionID;
                                        ra.ProfessionName = pa.ProfessionName;
                                        ra.ProfessionMultiLingualName = ((List<ProfessionAction>)fullActionList[j])[i].MulitLingualName;

                                        ra.RoleName = ((List<ProfessionRoles>)fullList[0])[index].RoleName;

                                        ra.MulitLingualName = ((List<ProfessionRoles>)fullList[j])[index].RoleName;

                                        ((List<ProfessionAction>)fullActionList[j])[i].RolesAction.Add(ra);

                                        phConfirm.Visible = true;
                                    }
                                }

                                break;
                            }
                        }
                    }

                    rptList.DataSource = lsl;
                    rptList.DataBind();

                    for (int i = 0; i < rptList.Items.Count; i++)
                    {
                        RepeaterItem ri = rptList.Items[i];
                        if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                        {
                            Repeater rptProfession = ri.FindControl("rptProfession") as Repeater;
                            Repeater rptRoles = ri.FindControl("rptRoles") as Repeater;

                            rptProfession.DataSource = fullActionList[i];
                            rptProfession.DataBind();

                            List<RoleAction> lra = new List<RoleAction>();
                            foreach (ProfessionAction pa in (List<ProfessionAction>)fullActionList[i])
                            {
                                foreach (RoleAction ra in pa.RolesAction)
                                {
                                    lra.Add(ra);
                                }
                            }

                            rptRoles.DataSource = lra;
                            rptRoles.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ltlMessage.Text = ex.Message;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ltlMessage.Text = string.Empty;
            ViewState["Confirmed"] = false;

            LoadExcel();
        }

        protected void rptProfession_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltName = e.Item.FindControl("ltName") as Literal;
                Literal ltAction = e.Item.FindControl("ltAction") as Literal;
                Literal ltFriendlyName = e.Item.FindControl("ltFriendlyName") as Literal;
                HiddenField hfProfessionID = e.Item.FindControl("hfProfessionID") as HiddenField;
                HiddenField hfProfessionName = e.Item.FindControl("hfProfessionName") as HiddenField;
                ProfessionAction pa = e.Item.DataItem as ProfessionAction;
                Literal ltRow = e.Item.FindControl("ltRow") as Literal;

                ltRow.Text = (pa.Action == "New") ? "<tr style=\"background-color: #E6E6E6;\">" : "<tr>";

                ltName.Text = HttpUtility.HtmlEncode(pa.MulitLingualName);
                ltAction.Text = pa.Action;


                hfProfessionID.Value = pa.ProfessionID.ToString();
                hfProfessionName.Value = pa.ProfessionName.ToString();
                ltFriendlyName.Text = JXTPortal.Common.Utils.UrlFriendlyName(hfProfessionName.Value);
                ltFriendlyName.Visible = (pa.Action == "Existing");
            }

            if (e.Item.ItemType == ListItemType.Footer)
            {
                Repeater rptProfession = e.Item.Parent as Repeater;

                int totalcount = 0;
                int existcount = 0;
                int newcount = 0;

                foreach (RepeaterItem ri in rptProfession.Items)
                {
                    if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                    {
                        Literal ltAction = ri.FindControl("ltAction") as Literal;

                        totalcount++;
                        if (ltAction.Text == "New")
                        {
                            newcount++;
                        }
                        if (ltAction.Text == "Existing")
                        {
                            existcount++;
                        }
                    }
                }

                Literal ltTotal = e.Item.FindControl("ltTotal") as Literal;
                Literal ltExist = e.Item.FindControl("ltExist") as Literal;
                Literal ltNew = e.Item.FindControl("ltNew") as Literal;

                ltTotal.Text = totalcount.ToString();
                ltExist.Text = existcount.ToString();
                ltNew.Text = newcount.ToString();
            }
        }

        protected void rptRoles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltProfessionName = e.Item.FindControl("ltProfessionName") as Literal;
                Literal ltName = e.Item.FindControl("ltName") as Literal;
                Literal ltAction = e.Item.FindControl("ltAction") as Literal;
                Literal ltFriendlyName = e.Item.FindControl("ltFriendlyName") as Literal;
                HiddenField hfRoleID = e.Item.FindControl("hfRoleID") as HiddenField;
                HiddenField hfRoleName = e.Item.FindControl("hfRoleName") as HiddenField;
                HiddenField hfProfessionID = e.Item.FindControl("hfProfessionID") as HiddenField;
                HiddenField hfProfessionName = e.Item.FindControl("hfProfessionName") as HiddenField;
                RoleAction ra = e.Item.DataItem as RoleAction;
                Literal ltRow = e.Item.FindControl("ltRow") as Literal;

                ltRow.Text = (ra.Action == "New") ? "<tr style=\"background-color: #E6E6E6;\">" : "<tr>";
                ltProfessionName.Text = HttpUtility.HtmlEncode(ra.ProfessionMultiLingualName);
                ltName.Text = HttpUtility.HtmlEncode(ra.MulitLingualName);
                ltAction.Text = ra.Action;

                hfRoleID.Value = ra.RoleID.ToString();
                hfRoleName.Value = ra.RoleName;
                hfProfessionID.Value = ra.ProfessionID.ToString();
                hfProfessionName.Value = ra.ProfessionName.ToString();

                ltFriendlyName.Text = JXTPortal.Common.Utils.UrlFriendlyName(hfRoleName.Value);
                ltFriendlyName.Visible = (ra.Action == "Existing");
            }

            if (e.Item.ItemType == ListItemType.Footer)
            {
                int totalcount = 0;
                int existcount = 0;
                int newcount = 0;

                Repeater rptRoles = e.Item.Parent as Repeater;

                foreach (RepeaterItem ri in rptRoles.Items)
                {
                    if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                    {
                        Literal ltAction = ri.FindControl("ltAction") as Literal;

                        totalcount++;
                        if (ltAction.Text == "New")
                        {
                            newcount++;
                        }
                        if (ltAction.Text == "Existing")
                        {
                            existcount++;
                        }
                    }
                }

                Literal ltTotal = e.Item.FindControl("ltTotal") as Literal;
                Literal ltExist = e.Item.FindControl("ltExist") as Literal;
                Literal ltNew = e.Item.FindControl("ltNew") as Literal;

                ltTotal.Text = totalcount.ToString();
                ltExist.Text = existcount.ToString();
                ltNew.Text = newcount.ToString();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("SiteProfession.aspx");
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            // Create XML for Profession

            StringBuilder sbProfession = new StringBuilder();
            StringBuilder sbRoles = new StringBuilder();
            ltlMessage.Text = string.Empty;
            try
            {
                if (rptList.Items.Count > 0)
                {
                    RepeaterItem lri = rptList.Items[0];

                    if (lri.ItemType == ListItemType.Item || lri.ItemType == ListItemType.AlternatingItem)
                    {
                        HiddenField hfLanguageID = lri.FindControl("hfLanguageID") as HiddenField;
                        Repeater rptProfession = lri.FindControl("rptProfession") as Repeater;
                        Repeater rptRoles = lri.FindControl("rptRoles") as Repeater;

                        foreach (RepeaterItem ri in rptProfession.Items)
                        {
                            if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                            {
                                HiddenField hfProfessionID = ri.FindControl("hfProfessionID") as HiddenField;
                                HiddenField hfProfessionName = ri.FindControl("hfProfessionName") as HiddenField;
                                Literal ltAction = ri.FindControl("ltAction") as Literal;

                                if (ltAction.Text == "New")
                                {
                                    sbProfession.AppendFormat("<profession id=\"{0}\" name=\"{1}\" friendlyurl=\"{2}\" action=\"{3}\" />\n", hfProfessionID.Value, HttpUtility.HtmlEncode(hfProfessionName.Value), Common.Utils.UrlFriendlyName(hfProfessionName.Value), ltAction.Text);
                                }
                            }
                        }

                        if (sbProfession.Length > 0)
                        {
                            ProfessionService.CustomBulkInsert(SessionData.Site.SiteId, string.Format("<ROOT>{0}</ROOT>", sbProfession.ToString()));
                        }

                        // Create XML for Roles
                        TList<Entities.Profession> professionlist = ProfessionService.GetByReferredSiteId(SessionData.Site.SiteId);
                        foreach (RepeaterItem ri in rptRoles.Items)
                        {
                            if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                            {
                                Literal ltAction = ri.FindControl("ltAction") as Literal;
                                HiddenField hfRoleID = ri.FindControl("hfRoleID") as HiddenField;
                                HiddenField hfRoleName = ri.FindControl("hfRoleName") as HiddenField;
                                HiddenField hfProfessionID = ri.FindControl("hfProfessionID") as HiddenField;
                                HiddenField hfProfessionName = ri.FindControl("hfProfessionName") as HiddenField;

                                if (ltAction.Text == "New")
                                {
                                    foreach (Entities.Profession profession in professionlist)
                                    {
                                        if (hfProfessionName.Value == profession.ProfessionName)
                                        {
                                            sbRoles.AppendFormat("<role id=\"{0}\" name=\"{1}\" friendlyurl=\"{2}\" professionid=\"{3}\" action=\"{4}\" />\n", hfRoleID.Value, HttpUtility.HtmlEncode(hfRoleName.Value), Common.Utils.UrlFriendlyName(hfRoleName.Value), profession.ProfessionId, ltAction.Text);
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        if (sbRoles.Length > 0)
                        {
                            RolesService.CustomBulkInsert(SessionData.Site.SiteId, string.Format("<ROOT>{0}</ROOT>", sbRoles.ToString()));
                        }
                        ViewState["Confirmed"] = true;
                    }
                }

                // Assgin All IDs
                TList<Entities.Profession> lp = ProfessionService.GetByReferredSiteId(SessionData.Site.SiteId);
                foreach (RepeaterItem ri in rptList.Items)
                {
                    Repeater rptProfession = ri.FindControl("rptProfession") as Repeater;
                    Repeater rptRoles = ri.FindControl("rptRoles") as Repeater;

                    foreach (Entities.Profession p in lp)
                    {
                        foreach (RepeaterItem pri in rptProfession.Items)
                        {
                            HiddenField hfProfessionID = pri.FindControl("hfProfessionID") as HiddenField;
                            HiddenField hfProfessionName = pri.FindControl("hfProfessionName") as HiddenField;
                            if (hfProfessionName.Value == p.ProfessionName)
                            {
                                hfProfessionID.Value = p.ProfessionId.ToString();
                            }
                        }

                        int currentprofessionid = 0;

                        TList<Entities.Roles> lr = new TList<Entities.Roles>();

                        foreach (RepeaterItem rri in rptRoles.Items)
                        {
                            HiddenField hfProfessionID = rri.FindControl("hfProfessionID") as HiddenField;
                            HiddenField hfProfessionName = rri.FindControl("hfProfessionName") as HiddenField;
                            HiddenField hfRoleID = rri.FindControl("hfRoleID") as HiddenField;
                            HiddenField hfRoleName = rri.FindControl("hfRoleName") as HiddenField;

                            if (hfProfessionName.Value == p.ProfessionName)
                            {
                                hfProfessionID.Value = p.ProfessionId.ToString();

                                if (currentprofessionid != p.ProfessionId)
                                {
                                    currentprofessionid = p.ProfessionId;
                                    lr = RolesService.GetByProfessionId(currentprofessionid);
                                }

                                foreach (Entities.Roles role in lr)
                                {
                                    if (hfRoleName.Value == role.RoleName)
                                    {
                                        hfRoleID.Value = role.RoleId.ToString();
                                    }
                                }
                            }
                        }


                    }
                }

                WriteProfessionXML();
                LoadExcel();

                ltlMessage.Text = "You have successfully uploaded your criteria";
            }
            catch (Exception ex)
            {
                ltlMessage.Text = ex.Message;
            }
        }


        private void WriteProfessionXML()
        {
            string xmlprefix = "{0}{2}_{3}_{1}.xml";

            for (int i = 1; i < rptList.Items.Count; i++)
            {
                RepeaterItem ri = rptList.Items[i];
                HiddenField hfLanguageID = ri.FindControl("hfLanguageID") as HiddenField;
                Repeater rptProfession = ri.FindControl("rptProfession") as Repeater;

                string url = string.Format(xmlprefix,
                                        System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]),
                                        Convert.ToInt32(hfLanguageID.Value),
                                        PortalConstants.XMLTranslationFiles.XML_CUSTOMPROFESSION_FILENAME, SessionData.Site.SiteId);
                XmlTextWriter writer = new XmlTextWriter(url, null);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("items");
                foreach (RepeaterItem repeateritem in rptProfession.Items)
                {
                    if (repeateritem.ItemType == ListItemType.Item || repeateritem.ItemType == ListItemType.AlternatingItem)
                    {
                        HiddenField hfProfessionId = repeateritem.FindControl("hfProfessionId") as HiddenField;
                        Literal ltName = repeateritem.FindControl("ltName") as Literal;
                        string multilingualtext = ltName.Text;

                        writer.WriteStartElement("item");
                        writer.WriteElementString("id", hfProfessionId.Value.ToString());
                        writer.WriteElementString("name", HttpUtility.HtmlDecode(multilingualtext));
                        writer.WriteEndElement();

                        WriteRolesXML(Convert.ToInt32(hfProfessionId.Value), i);
                    }

                }
                writer.WriteEndElement();
                writer.Close();

            }
        }

        private void WriteRolesXML(int professionID, int index)
        {
            string xmlprefix = "{0}{2}_{4}_{1}_{3}.xml";

            RepeaterItem ri = rptList.Items[index];
            HiddenField hfLanguageID = ri.FindControl("hfLanguageID") as HiddenField;
            Repeater rptRoles = ri.FindControl("rptRoles") as Repeater;

            string url = string.Format(xmlprefix,
                                    System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]),
                                     Convert.ToInt32(hfLanguageID.Value),
                                    PortalConstants.XMLTranslationFiles.XML_CUSTOMROLE_FILENAME, professionID, SessionData.Site.SiteId);

            XmlTextWriter writer = new XmlTextWriter(url, null);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("items");
            foreach (RepeaterItem repeateritem in rptRoles.Items)
            {

                HiddenField hfRoleId = repeateritem.FindControl("hfRoleId") as HiddenField;
                HiddenField hfProfessionId = repeateritem.FindControl("hfProfessionId") as HiddenField;
                Literal ltName = repeateritem.FindControl("ltName") as Literal;
                string multilingualtext = ltName.Text;

                if (hfProfessionId.Value == professionID.ToString())
                {
                    writer.WriteStartElement("item");
                    writer.WriteElementString("id", hfRoleId.Value.ToString());
                    writer.WriteElementString("name", HttpUtility.HtmlDecode(multilingualtext));
                    writer.WriteEndElement();
                }

            }
            writer.WriteEndElement();
            writer.Close();
        }

        protected void cbConfirm_CheckedChanged(object sender, EventArgs e)
        {
            btnConfirm.Visible = cbConfirm.Checked;
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Entities.SiteLanguages sl = e.Item.DataItem as Entities.SiteLanguages;
                Literal ltLanguage = e.Item.FindControl("ltLanguage") as Literal;
                HiddenField hfLanguageID = e.Item.FindControl("hfLanguageID") as HiddenField;

                ltLanguage.Text = sl.SiteLanguageName;
                hfLanguageID.Value = sl.LanguageId.ToString();
            }
        }

        protected void btnDownloadSample_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Sample for Custom Import.xlsx");
            Response.Charset = "utf-8";

            Response.ContentType = "application/vnd.ms-excel";

            TList<Entities.SiteLanguages> sitelanguages = SiteLanguagesService.GetBySiteId(SessionData.Site.SiteId);
            string filepath = Server.MapPath("~") + "App_GlobalResources\\CustomProfessionRoles.xlsx";
            if (sitelanguages.Count > 1)
            {
                filepath = Server.MapPath("~") + "App_GlobalResources\\CustomProfessionRoles_1.xlsx";
            }

            Response.WriteFile(filepath);

            Response.End();
        }
    }
}