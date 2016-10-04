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
    public partial class SiteCustomCountryLocationAreaImport : System.Web.UI.Page
    {
        internal class CountryLocationArea
        {
            public string CountryName { get; set; }
            public string LocationName { get; set; }
            public string AreaName { get; set; }

            public CountryLocationArea()
            {
            }
        }

        internal class CountryLocationAreaContainer
        {
            public int LanguageID { get; set; }
            public string LanguageName { get; set; }
            public List<CountryContainer> CountryContainer { get; set; }
            public List<LocationContainer> LocationContainer { get; set; }
            public List<AreaContainer> AreaContainer { get; set; }

            public CountryLocationAreaContainer()
            {
                CountryContainer = new List<CountryContainer>();
                LocationContainer = new List<LocationContainer>();
                AreaContainer = new List<AreaContainer>();
            }
        }

        internal class CountryContainer
        {
            public string CountryName { get; set; }
            public int CountryId { get; set; }
        }

        internal class LocationContainer
        {
            public int CountryId { get; set; }
            public string CountryName { get; set; }
            public string LocationName { get; set; }
            public int LocationId { get; set; }

            public LocationContainer()
            {
            }
        }

        internal class AreaContainer
        {
            public string CountryName { get; set; }
            public int LocationId { get; set; }
            public string LocationName { get; set; }
            public string AreaName { get; set; }
            public int AreaId { get; set; }

            public AreaContainer()
            {
            }
        }

        internal class CountryIDContainer
        {
            public int CountryID { get; set; }
            public List<LocationIDContainer> LocationId { get; set; }

            public CountryIDContainer()
            {
                LocationId = new List<LocationIDContainer>();
            }
        }

        internal class LocationIDContainer
        {
            public int LocationID { get; set; }
            public List<int> AreaId { get; set; }

            public LocationIDContainer()
            {
                AreaId = new List<int>();
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

        private CountriesService _countriesService;

        private CountriesService CountriesService
        {
            get
            {
                if (_countriesService == null) _countriesService = new CountriesService();
                return _countriesService;
            }
        }

        private LocationService _locationService;

        private LocationService LocationService
        {
            get
            {
                if (_locationService == null) _locationService = new LocationService();
                return _locationService;
            }
        }

        private AreaService _areaService;

        private AreaService AreaService
        {
            get
            {
                if (_areaService == null) _areaService = new AreaService();
                return _areaService;
            }
        }

        private SiteCountriesService _sitecountriesService;

        private SiteCountriesService SiteCountriesService
        {
            get
            {
                if (_sitecountriesService == null) _sitecountriesService = new SiteCountriesService();
                return _sitecountriesService;
            }
        }

        private SiteLocationService _sitelocationService;

        private SiteLocationService SiteLocationService
        {
            get
            {
                if (_sitelocationService == null) _sitelocationService = new SiteLocationService();
                return _sitelocationService;
            }
        }

        private SiteAreaService _siteareaService;

        private SiteAreaService SiteAreaService
        {
            get
            {
                if (_siteareaService == null) _siteareaService = new SiteAreaService();
                return _siteareaService;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["Confirmed"] = false;
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
                fullList.Add(new List<CountryLocationArea>());
                fullActionList.Add(new List<CountryLocationAreaContainer>());
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
                                    if (r.Elements<Cell>().Count() % 3 != 0)
                                    {
                                        ltlMessage.Text = "Invalid Excel file";
                                        return;
                                    }

                                    if ((r.Elements<Cell>().Count() / 3) < lsl.Count)
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
                        for (int i = 0; i < (ds.Tables[0].Columns.Count / 3) && i < lsl.Count; i++)
                        {
                            List<CountryLocationArea> lcla = fullList[i] as List<CountryLocationArea>;
                            CountryLocationArea cla = new CountryLocationArea();
                            cla.CountryName = dr[i * 3].ToString();
                            cla.LocationName = dr[i * 3 + 1].ToString();
                            cla.AreaName = dr[i * 3 + 2].ToString();

                            lcla.Add(cla);
                        }
                    }

                    // Construct the list

                    string currentcountry = string.Empty;
                    string currentlocation = string.Empty;

                    int currentcountryindex = 0;
                    int currentlocationindex = 0;
                    int currentareaindex = 0;

                    rptList.DataSource = lsl;
                    rptList.DataBind();

                    // Load Up the Site CLA to get the ID allocations

                    TList<Entities.Countries> countries = CountriesService.GetAll();
                    countries.Filter = "Valid = true AND Abbr = 'CC'";

                    List<CountryIDContainer> lcountryidcontainer = new List<CountryIDContainer>();
                    foreach (Entities.Countries c in countries)
                    {
                        CountryIDContainer countryidcontainer = new CountryIDContainer();
                        countryidcontainer.CountryID = c.CountryId;

                        TList<Entities.Location> locations = LocationService.GetByCountryId(c.CountryId);
                        foreach (Entities.Location l in locations)
                        {
                            LocationIDContainer locationidcontainer = new LocationIDContainer();
                            locationidcontainer.LocationID = l.LocationId;

                            TList<Entities.Area> areas = AreaService.GetByLocationId(l.LocationId);
                            foreach (Entities.Area a in areas)
                            {
                                locationidcontainer.AreaId.Add(a.AreaId);

                            }

                            countryidcontainer.LocationId.Add(locationidcontainer);

                        }

                        lcountryidcontainer.Add(countryidcontainer);

                    }


                    try
                    {
                        for (int i = 0; i < rptList.Items.Count; i++)
                        {
                            RepeaterItem ri = rptList.Items[i];
                            if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                            {
                                Repeater rptCountry = ri.FindControl("rptCountry") as Repeater;
                                Repeater rptLocation = ri.FindControl("rptLocation") as Repeater;
                                Repeater rptArea = ri.FindControl("rptArea") as Repeater;

                                // Construct List of Countries
                                List<CountryContainer> countrylist = new List<CountryContainer>();
                                List<LocationContainer> locationlist = new List<LocationContainer>();
                                List<AreaContainer> arealist = new List<AreaContainer>();

                                List<CountryLocationArea> lcla = fullList[i] as List<CountryLocationArea>;
                                foreach (CountryLocationArea cla in lcla)
                                {
                                    if (cla.CountryName != currentcountry)
                                    {
                                        CountryContainer cc = new CountryContainer();
                                        cc.CountryName = cla.CountryName;
                                        cc.CountryId = lcountryidcontainer[currentcountryindex].CountryID;

                                        countrylist.Add(cc);

                                        currentcountry = cla.CountryName;

                                        currentcountryindex++;
                                        currentlocationindex = 0;
                                        currentareaindex = 0;
                                    }

                                    if (cla.LocationName != currentlocation)
                                    {
                                        LocationContainer lc = new LocationContainer();
                                        lc.CountryId = lcountryidcontainer[currentcountryindex - 1].CountryID;
                                        lc.CountryName = cla.CountryName;
                                        lc.LocationName = cla.LocationName;
                                        lc.LocationId = lcountryidcontainer[currentcountryindex - 1].LocationId[currentlocationindex].LocationID;

                                        locationlist.Add(lc);

                                        currentlocation = cla.LocationName;


                                        currentlocationindex++;
                                        currentareaindex = 0;
                                    }

                                    AreaContainer ac = new AreaContainer();
                                    ac.CountryName = cla.CountryName;
                                    ac.LocationId = lcountryidcontainer[currentcountryindex - 1].LocationId[currentlocationindex - 1].LocationID;
                                    ac.LocationName = cla.LocationName;
                                    ac.AreaName = cla.AreaName;
                                    ac.AreaId = lcountryidcontainer[currentcountryindex - 1].LocationId[currentlocationindex - 1].AreaId[currentareaindex];

                                    arealist.Add(ac);


                                    currentareaindex++;
                                }

                                rptCountry.DataSource = countrylist;
                                rptCountry.DataBind();

                                rptLocation.DataSource = locationlist;
                                rptLocation.DataBind();

                                rptArea.DataSource = arealist;
                                rptArea.DataBind();

                                phConfirm.Visible = true;
                            }

                            currentcountryindex=0;
                            currentlocationindex = 0;
                            currentareaindex = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        ltlMessage.Text = "Not enough slot";
                        return;
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

        protected void rptCountry_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltName = e.Item.FindControl("ltName") as Literal;
                HiddenField hfCountryID = e.Item.FindControl("hfCountryID") as HiddenField;
                HiddenField hfCountryName = e.Item.FindControl("hfCountryName") as HiddenField;
                CountryContainer cc = e.Item.DataItem as CountryContainer;

                ltName.Text = HttpUtility.HtmlEncode(cc.CountryName);
                hfCountryName.Value = cc.CountryName;
                hfCountryID.Value = cc.CountryId.ToString();
            }

            if (e.Item.ItemType == ListItemType.Footer)
            {
                Repeater rptCountry = e.Item.Parent as Repeater;

                int totalcount = 0; ;

                foreach (RepeaterItem ri in rptCountry.Items)
                {
                    if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                    {
                        Literal ltAction = ri.FindControl("ltAction") as Literal;

                        totalcount++;
                    }
                }

                Literal ltTotal = e.Item.FindControl("ltTotal") as Literal;

                ltTotal.Text = totalcount.ToString();
            }
        }

        protected void rptLocation_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltName = e.Item.FindControl("ltName") as Literal;
                Literal ltCountryName = e.Item.FindControl("ltCountryName") as Literal;

                HiddenField hfCountryID = e.Item.FindControl("hfCountryID") as HiddenField;
                HiddenField hfCountryName = e.Item.FindControl("hfCountryName") as HiddenField;
                HiddenField hfLocationID = e.Item.FindControl("hfLocationID") as HiddenField;
                HiddenField hfLocationName = e.Item.FindControl("hfLocationName") as HiddenField;
                LocationContainer lc = e.Item.DataItem as LocationContainer;

                ltName.Text = HttpUtility.HtmlEncode(lc.LocationName);
                ltCountryName.Text = HttpUtility.HtmlEncode(lc.CountryName);
                hfLocationName.Value = lc.LocationName;
                hfLocationID.Value = lc.LocationId.ToString();
                hfCountryID.Value = lc.CountryId.ToString();
            }

            if (e.Item.ItemType == ListItemType.Footer)
            {
                Repeater rptCountry = e.Item.Parent as Repeater;

                int totalcount = 0; ;

                foreach (RepeaterItem ri in rptCountry.Items)
                {
                    if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                    {
                        Literal ltAction = ri.FindControl("ltAction") as Literal;

                        totalcount++;
                    }
                }

                Literal ltTotal = e.Item.FindControl("ltTotal") as Literal;

                ltTotal.Text = totalcount.ToString();
            }
        }

        protected void rptArea_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltName = e.Item.FindControl("ltName") as Literal;
                Literal ltCountryName = e.Item.FindControl("ltCountryName") as Literal;
                Literal ltLocationName = e.Item.FindControl("ltLocationName") as Literal;

                HiddenField hfCountryID = e.Item.FindControl("hfCountryID") as HiddenField;
                HiddenField hfCountryName = e.Item.FindControl("hfCountryName") as HiddenField;
                HiddenField hfLocationID = e.Item.FindControl("hfLocationID") as HiddenField;
                HiddenField hfLocationName = e.Item.FindControl("hfLocationName") as HiddenField;
                HiddenField hfAreaID = e.Item.FindControl("hfAreaID") as HiddenField;
                HiddenField hfAreaName = e.Item.FindControl("hfAreaName") as HiddenField;

                AreaContainer ac = e.Item.DataItem as AreaContainer;

                ltName.Text = HttpUtility.HtmlEncode(ac.AreaName);
                hfLocationID.Value = HttpUtility.HtmlEncode(ac.LocationId);
                ltLocationName.Text = HttpUtility.HtmlEncode(ac.LocationName);
                ltCountryName.Text = HttpUtility.HtmlEncode(ac.CountryName);
                hfAreaName.Value = ac.LocationName;
                hfAreaID.Value = ac.AreaId.ToString();
            }

            if (e.Item.ItemType == ListItemType.Footer)
            {
                Repeater rptCountry = e.Item.Parent as Repeater;

                int totalcount = 0; ;

                foreach (RepeaterItem ri in rptCountry.Items)
                {
                    if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                    {
                        Literal ltAction = ri.FindControl("ltAction") as Literal;

                        totalcount++;
                    }
                }

                Literal ltTotal = e.Item.FindControl("ltTotal") as Literal;

                ltTotal.Text = totalcount.ToString();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("SiteProfession.aspx");
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            // Delete all Site CLA

            TList<Entities.SiteArea> siteareas = SiteAreaService.GetBySiteId(SessionData.Site.SiteId);
            TList<Entities.SiteLocation> sitelocations = SiteLocationService.GetBySiteId(SessionData.Site.SiteId);
            TList<Entities.SiteCountries> sitecountries = SiteCountriesService.GetBySiteId(SessionData.Site.SiteId);

            SiteAreaService.Delete(siteareas);
            SiteLocationService.Delete(sitelocations);
            SiteCountriesService.Delete(sitecountries);
            
            //// Create XML for Profession

            StringBuilder sbCountry = new StringBuilder();
            StringBuilder sbLocation = new StringBuilder();
            StringBuilder sbArea = new StringBuilder();

            ltlMessage.Text = string.Empty;
            try
            {
                if (rptList.Items.Count > 0)
                {
                    RepeaterItem lri = rptList.Items[0];

                    if (lri.ItemType == ListItemType.Item || lri.ItemType == ListItemType.AlternatingItem)
                    {
                        HiddenField hfLanguageID = lri.FindControl("hfLanguageID") as HiddenField;
                        Repeater rptCountry = lri.FindControl("rptCountry") as Repeater;
                        Repeater rptLocation = lri.FindControl("rptLocation") as Repeater;
                        Repeater rptArea = lri.FindControl("rptArea") as Repeater;


                        // Insert Site Countries

                        foreach (RepeaterItem ri in rptCountry.Items)
                        {
                            if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                            {
                               HiddenField hfCountryID = ri.FindControl("hfCountryID") as HiddenField;
                               HiddenField hfCountryName = ri.FindControl("hfCountryName") as HiddenField;
                               Literal ltName = ri.FindControl("ltName") as Literal;

                                Entities.SiteCountries sitecountry = new Entities.SiteCountries();
                                sitecountry.CountryId = Convert.ToInt32(hfCountryID.Value);
                                sitecountry.SiteId = SessionData.Site.SiteId;
                                sitecountry.SiteCountryName = HttpUtility.HtmlDecode(ltName.Text);
                                sitecountry.SiteCountryFriendlyUrl = Common.Utils.UrlFriendlyName(HttpUtility.HtmlDecode(ltName.Text));

                                SiteCountriesService.Insert(sitecountry);
                            }
                        }

                        // Insert Site Location 

                        foreach (RepeaterItem ri in rptLocation.Items)
                        {
                            if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                            {
                                HiddenField hfLocationID = ri.FindControl("hfLocationID") as HiddenField;
                                HiddenField hfLocationName = ri.FindControl("hfLocationName") as HiddenField;
                                Literal ltName = ri.FindControl("ltName") as Literal;

                                Entities.SiteLocation sitelocation = new Entities.SiteLocation();
                                sitelocation.LocationId = Convert.ToInt32(hfLocationID.Value);
                                sitelocation.SiteId = SessionData.Site.SiteId;
                                sitelocation.SiteLocationName = HttpUtility.HtmlDecode(ltName.Text);
                                sitelocation.SiteLocationFriendlyUrl = Common.Utils.UrlFriendlyName(HttpUtility.HtmlDecode(ltName.Text));
                                sitelocation.Valid = true;

                                SiteLocationService.Insert(sitelocation);
                            }
                        }

                        // Insert Site Area

                        foreach (RepeaterItem ri in rptArea.Items)
                        {
                            if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                            {
                                HiddenField hfAreaID = ri.FindControl("hfAreaID") as HiddenField;
                                HiddenField hfAreaName = ri.FindControl("hfAreaName") as HiddenField;
                                Literal ltName = ri.FindControl("ltName") as Literal;

                                Entities.SiteArea sitearea = new Entities.SiteArea();
                                sitearea.AreaId = Convert.ToInt32(hfAreaID.Value);
                                sitearea.SiteId = SessionData.Site.SiteId;
                                sitearea.SiteAreaName = HttpUtility.HtmlDecode(ltName.Text);
                                sitearea.Valid = true;

                                SiteAreaService.Insert(sitearea);
                            }
                        }

                        ViewState["Confirmed"] = true;
                    }
                }

                WriteCountryXML();
                WriteLocationXML();
                WriteAreaXML();

                ltlMessage.Text = "You have successfully uploaded your criteria";
            }
            catch (Exception ex)
            {
                ltlMessage.Text = ex.Message;
            }
        }

        private void WriteCountryXML()
        {
            string xmlprefix = "{0}{2}_{3}_{1}.xml";

            for (int i = 1; i < rptList.Items.Count; i++)
            {
                RepeaterItem riLanguage = rptList.Items[i];

                HiddenField hfLanguageID = riLanguage.FindControl("hfLanguageID") as HiddenField;
                Repeater rptCountry = riLanguage.FindControl("rptCountry") as Repeater;
                Repeater rptLocation = riLanguage.FindControl("rptLocation") as Repeater;
                Repeater rptArea = riLanguage.FindControl("rptArea") as Repeater;

                string url = string.Format(xmlprefix, Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]), hfLanguageID.Value,
                                                PortalConstants.XMLTranslationFiles.XML_SITECOUNTRY_FILENAME, SessionData.Site.SiteId);
                XmlTextWriter writer = new XmlTextWriter(url, null);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("items");
                foreach (RepeaterItem repeateritem in rptCountry.Items)
                {
                    Literal ltName = repeateritem.FindControl("ltName") as Literal;
                    HiddenField hfCountryId = repeateritem.FindControl("hfCountryId") as HiddenField;

                    writer.WriteStartElement("item");
                    writer.WriteElementString("id", hfCountryId.Value.ToString());
                    writer.WriteElementString("name", ltName.Text);
                    writer.WriteEndElement();

                }
                writer.WriteEndElement();
                writer.Close();
            }
        }

        private void WriteLocationXML()
        {
            string xmlprefix = "{0}{2}_{4}_{1}_{3}.xml";


            for (int i = 1; i < rptList.Items.Count; i++)
            {
                RepeaterItem riLanguage = rptList.Items[i];

                HiddenField hfLanguageID = riLanguage.FindControl("hfLanguageID") as HiddenField;
                Repeater rptCountry = riLanguage.FindControl("rptCountry") as Repeater;
                Repeater rptLocation = riLanguage.FindControl("rptLocation") as Repeater;
                Repeater rptArea = riLanguage.FindControl("rptArea") as Repeater;

                
                foreach (RepeaterItem countryitem in rptCountry.Items)
                {
                    HiddenField hfCountryId = countryitem.FindControl("hfCountryId") as HiddenField;

                    string url = string.Format(xmlprefix, Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]), hfLanguageID.Value,
                                                PortalConstants.XMLTranslationFiles.XML_SITELOCATION_FILENAME, hfCountryId.Value, SessionData.Site.SiteId);

                    XmlTextWriter writer = new XmlTextWriter(url, null);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("items");

                    foreach (RepeaterItem locationitem in rptLocation.Items)
                    {
                        HiddenField lochfCountryId = locationitem.FindControl("hfCountryId") as HiddenField;
                        HiddenField hfLocationId = locationitem.FindControl("hfLocationId") as HiddenField;
                        Literal ltName = locationitem.FindControl("ltName") as Literal;

                        if (lochfCountryId.Value == hfCountryId.Value)
                        {
                            writer.WriteStartElement("item");
                            writer.WriteElementString("id", hfLocationId.Value.ToString());
                            writer.WriteElementString("name", ltName.Text);
                            writer.WriteEndElement();
                        }

                    }

                    writer.WriteEndElement();
                    writer.Close();

                }
            }
        }

        private void WriteAreaXML()
        {
            string xmlprefix = "{0}{2}_{4}_{1}_{3}.xml";


            for (int i = 1; i < rptList.Items.Count; i++)
            {
                RepeaterItem riLanguage = rptList.Items[i];

                HiddenField hfLanguageID = riLanguage.FindControl("hfLanguageID") as HiddenField;
                Repeater rptCountry = riLanguage.FindControl("rptCountry") as Repeater;
                Repeater rptLocation = riLanguage.FindControl("rptLocation") as Repeater;
                Repeater rptArea = riLanguage.FindControl("rptArea") as Repeater;


                foreach (RepeaterItem location in rptLocation.Items)
                {
                    HiddenField hfLocationId = location.FindControl("hfLocationId") as HiddenField;

                    string url = string.Format(xmlprefix,
                                        System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["XMLFilesPath"]),
                                        hfLanguageID.Value,
                                        PortalConstants.XMLTranslationFiles.XML_SITEAREA_FILENAME, hfLocationId.Value, SessionData.Site.SiteId);

                    XmlTextWriter writer = new XmlTextWriter(url, null);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("items");

                    foreach (RepeaterItem areaitem in rptArea.Items)
                    {
                        HiddenField ahfLocationId = areaitem.FindControl("hfLocationId") as HiddenField;
                        HiddenField hfAreaId = areaitem.FindControl("hfAreaId") as HiddenField;
                        Literal ltName = areaitem.FindControl("ltName") as Literal;

                        if (ahfLocationId.Value == hfLocationId.Value)
                        {
                            writer.WriteStartElement("item");
                            writer.WriteElementString("id", hfAreaId.Value.ToString());
                            writer.WriteElementString("name", ltName.Text);
                            writer.WriteEndElement();
                        }

                    }

                    writer.WriteEndElement();
                    writer.Close();

                }
            }
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
            string filepath = Server.MapPath("~") + "App_GlobalResources\\CustomLocationArea.xlsx";
            if (sitelanguages.Count > 1)
            {
                filepath = Server.MapPath("~") + "App_GlobalResources\\CustomLocationArea_1.xlsx";
            }

            Response.WriteFile(filepath);

            Response.End();
        }
    }
}