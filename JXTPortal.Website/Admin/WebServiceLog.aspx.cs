using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

using JXTPortal.Web.UI;
using JXTPortal;
using JXTPortal.Entities;
using JXTPortal.Common;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace JXTPortal.Website.Admin
{
    public partial class WebServiceLog : System.Web.UI.Page
    {
        #region Declarations

        private SitesService _siteservice;
        private AdvertisersService _advertisersservice;
        private WebServiceLogService _webservicelogservice;
        private JobTemplatesService _jobtemplatesservice;
        private AdvertiserJobTemplateLogoService _advertiserjobtemplatelogoservice;
        private ProfessionService _professionservice;
        private RolesService _rolesservice;
        private SiteProfessionService _siteprofessionservice;
        private SiteRolesService _siterolesservice;
        private SiteWorkTypeService _siteworktypeservice;
        private CountriesService _countriesservice;
        private LocationService _locationservice;
        private AreaService _areaservice;
        private SiteCountriesService _sitecountriesservice;
        private SiteLocationService _sitelocationservice;
        private SiteAreaService _siteareaservice;

        private const string xmlprefix = "{0}{2}_{1}_{3}.xml";

        #endregion

        #region Properties

        private SitesService SitesService
        {
            get
            {
                if (_siteservice == null)
                {
                    _siteservice = new SitesService();
                }
                return _siteservice;
            }
        }

        private AdvertisersService AdvertisersService
        {
            get
            {
                if (_advertisersservice == null)
                {
                    _advertisersservice = new AdvertisersService();
                }
                return _advertisersservice;
            }
        }

        private WebServiceLogService WebServiceLogService
        {
            get
            {
                if (_webservicelogservice == null)
                {
                    _webservicelogservice = new WebServiceLogService();
                }
                return _webservicelogservice;
            }
        }

        private JobTemplatesService JobTemplatesService
        {
            get
            {
                if (_jobtemplatesservice == null)
                {
                    _jobtemplatesservice = new JobTemplatesService();
                }
                return _jobtemplatesservice;
            }
        }

        private AdvertiserJobTemplateLogoService AdvertiserJobTemplateLogoService
        {
            get
            {
                if (_advertiserjobtemplatelogoservice == null)
                {
                    _advertiserjobtemplatelogoservice = new AdvertiserJobTemplateLogoService();
                }
                return _advertiserjobtemplatelogoservice;
            }
        }

        private ProfessionService ProfessionService
        {
            get
            {
                if (_professionservice == null)
                {
                    _professionservice = new ProfessionService();
                }
                return _professionservice;
            }
        }

        private RolesService RolesService
        {
            get
            {
                if (_rolesservice == null)
                {
                    _rolesservice = new RolesService();
                }
                return _rolesservice;
            }
        }

        private SiteProfessionService SiteProfessionService
        {
            get
            {
                if (_siteprofessionservice == null)
                {
                    _siteprofessionservice = new SiteProfessionService();
                }
                return _siteprofessionservice;
            }
        }

        private SiteRolesService SiteRolesService
        {
            get
            {
                if (_siterolesservice == null)
                {
                    _siterolesservice = new SiteRolesService();
                }
                return _siterolesservice;
            }
        }

        private SiteWorkTypeService SiteWorkTypeService
        {
            get
            {
                if (_siteworktypeservice == null)
                {
                    _siteworktypeservice = new SiteWorkTypeService();
                }
                return _siteworktypeservice;
            }
        }

        private CountriesService CountriesService
        {
            get
            {
                if (_countriesservice == null)
                {
                    _countriesservice = new CountriesService();
                }
                return _countriesservice;
            }
        }

        private LocationService LocationService
        {
            get
            {
                if (_locationservice == null)
                {
                    _locationservice = new LocationService();
                }
                return _locationservice;
            }
        }
        private AreaService AreaService
        {
            get
            {
                if (_areaservice == null)
                {
                    _areaservice = new AreaService();
                }
                return _areaservice;
            }
        }

        private SiteCountriesService SiteCountriesService
        {
            get
            {
                if (_sitecountriesservice == null)
                {
                    _sitecountriesservice = new SiteCountriesService();
                }
                return _sitecountriesservice;
            }
        }

        private SiteLocationService SiteLocationService
        {
            get
            {
                if (_sitelocationservice == null)
                {
                    _sitelocationservice = new SiteLocationService();
                }
                return _sitelocationservice;
            }
        }

        private SiteAreaService SiteAreaService
        {
            get
            {
                if (_siteareaservice == null)
                {
                    _siteareaservice = new SiteAreaService();
                }
                return _siteareaservice;
            }
        }


        public int CurrentPage
        {

            get
            {
                if (this.ViewState["CurrentPage"] == null)
                    return 0;
                else
                    return Convert.ToInt16(this.ViewState["CurrentPage"].ToString());
            }

            set
            {
                this.ViewState["CurrentPage"] = value;
            }

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            cal_DateFrom.Format = SessionData.Site.DateFormat;
            cal_DateTo.Format = SessionData.Site.DateFormat;


            if (SessionData.AdminUser != null)
            {
                phSite.Visible = (SessionData.AdminUser.isAdminUser);

                ScriptManager scriptMan = AjaxControlToolkit.ToolkitScriptManager.GetCurrent(this);
                UpdatePanel up = scriptMan.FindControl("updatePanel") as UpdatePanel;
                scriptMan.RegisterPostBackControl(btnDownloadExcel);

                if (!Page.IsPostBack)
                {
                    //load filters
                    LoadFilterOptions();

                    //perform search
                    if (SessionData.AdminUser != null && SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Administrator)
                        SearchWebServiceLog();
                }
            }

        }

        private void LoadFilterOptions()
        {
            LoadSites();

            LoadMethodInvokedFilter();

            CurrentPage = SessionData.WebServiceSearch.PageIndex;
            if (SessionData.WebServiceSearch.SiteID > 0)
                ddlSite.SelectedValue = SessionData.WebServiceSearch.SiteID.ToString();

            LoadAdvertisers();

            if (SessionData.WebServiceSearch.SiteID > 0)
            {
                ddlAdvertiser.SelectedValue = SessionData.WebServiceSearch.AdvertiserID.ToString();
                tbDateFrom.Text = SessionData.WebServiceSearch.DateFrom;
                tbDateTo.Text = SessionData.WebServiceSearch.DateTo;
                cbShowOnlyFailed.Checked = SessionData.WebServiceSearch.ShowOnlyFails;
            }

        }

        private void LoadSites()
        {
            ddlSite.Items.Clear();

            DataSet sites = SitesService.Get_List();
            //SitesService.GetBySiteId(SessionData.Site.SiteId)
            DataRow[] siterows = sites.Tables[0].Select("", "SiteName");

            ddlSite.DataSource = siterows.Select(c=> new SiteDDLItems { SiteID = c["SiteID"].ToString(), SiteName = c["SiteName"].ToString()}).ToList(); // sites.Where(s => s.Live == true);
            ddlSite.DataBind();

            ddlSite.Items.Insert(0, new ListItem("All", "0"));

            //if (SessionData.AdminUser != null && !SessionData.AdminUser.isAdminUser)
            //{
                ddlSite.SelectedValue = SessionData.Site.SiteId.ToString();
            //}
        }

        private void LoadMethodInvokedFilter()
        {
            ddlMethodInvoked.Items.Clear();

            ddlMethodInvoked.Items.Insert(0, new ListItem("All", "0"));
            ddlMethodInvoked.Items.Insert(1, new ListItem("POST", "1"));
            ddlMethodInvoked.Items.Insert(2, new ListItem("ARCHIVE", "2"));
        }

        private void SearchWebServiceLog()
        {
            lblErrorMsg.Visible = false;
            lblErrorMsg.Text = string.Empty;

            int totalCount = 0;
            int pageCount = 0;
            int sitePageCount = 15;

            using (DataSet ds = WebServiceLogService.CustomGetWebServiceLogPaged(Convert.ToInt32(ddlSite.SelectedValue), Convert.ToInt32(ddlAdvertiser.SelectedValue), (string.IsNullOrWhiteSpace(tbDateFrom.Text)) ? new DateTime(2013, 1, 1) : DateTime.ParseExact(tbDateFrom.Text, SessionData.Site.DateFormat, null), (string.IsNullOrWhiteSpace(tbDateTo.Text)) ? DateTime.Now : DateTime.ParseExact(tbDateTo.Text, SessionData.Site.DateFormat, null), cbShowOnlyFailed.Checked, sitePageCount, CurrentPage))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // lblErrorMsg.Visible = false;
                    ArrayList pagelist = new ArrayList();
                    totalCount = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalCount"]);

                    if (totalCount % sitePageCount == 0)
                        pageCount = totalCount / sitePageCount;
                    else
                        pageCount = (totalCount / sitePageCount) + 1;

                    if (CurrentPage >= 10)
                    {
                        pagelist.Add("previous");
                    }

                    int index = (CurrentPage == 0) ? 0 : (CurrentPage) / 10 * 10;
                    for (int i = index; i < pageCount; i++)
                    {
                        pagelist.Add(i.ToString());

                        if ((i % 10) == 9 && (i < pageCount - 1))
                        {
                            pagelist.Add("next");
                            break;
                        }

                    }

                    if (pagelist.Count > 1)
                    {
                        rptPage.DataSource = pagelist;
                        rptPage.DataBind();
                        rptPage.Visible = true;
                    }
                    else
                    {
                        rptPage.Visible = false;
                    }

                    rptWebServiceLog.DataSource = ds.Tables[0];
                    rptWebServiceLog.DataBind();
                }
                else
                {
                    lblErrorMsg.Visible = true;
                    lblErrorMsg.Text = "No results found";
                    rptWebServiceLog.DataSource = null;
                    rptWebServiceLog.DataBind();
                    rptPage.DataSource = null;
                    rptPage.DataBind();
                }

                SessionData.WebServiceSearch.ClearAllValues();
                SessionData.WebServiceSearch.PageIndex = CurrentPage;
                SessionData.WebServiceSearch.SiteID = Convert.ToInt32(ddlSite.SelectedValue);
                SessionData.WebServiceSearch.AdvertiserID = Convert.ToInt32(ddlAdvertiser.SelectedValue);
                SessionData.WebServiceSearch.DateFrom = tbDateFrom.Text;
                SessionData.WebServiceSearch.DateTo = tbDateTo.Text;
                SessionData.WebServiceSearch.ShowOnlyFails = cbShowOnlyFailed.Checked;

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                CurrentPage = 0;
                SearchWebServiceLog();
            }
        }

        protected void rptWebServiceLog_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hfWebServiceLogID = e.Item.FindControl("hfWebServiceLogID") as HiddenField;
                Literal ltSiteName = e.Item.FindControl("ltSiteName") as Literal;
                System.Web.UI.WebControls.HyperLink hlAdvertiser = e.Item.FindControl("hlAdvertiser") as System.Web.UI.WebControls.HyperLink;
                Literal ltCreatedDate = e.Item.FindControl("ltCreatedDate") as Literal;
                Literal ltMethodInvoked = e.Item.FindControl("ltMethodInvoked") as Literal;
                LinkButton lbInputXML = e.Item.FindControl("lbInputXML") as LinkButton;
                LinkButton lbOutputResponse = e.Item.FindControl("lbOutputResponse") as LinkButton;
                Literal ltTotalSent = e.Item.FindControl("ltTotalSent") as Literal;
                Literal ltTotalInserted = e.Item.FindControl("ltTotalInserted") as Literal;
                Literal ltTotalUpdated = e.Item.FindControl("ltTotalUpdated") as Literal;
                Literal ltTotalArchived = e.Item.FindControl("ltTotalArchived") as Literal;
                Literal ltTotalFailed = e.Item.FindControl("ltTotalFailed") as Literal;
                LinkButton lbDetail = e.Item.FindControl("lbDetail") as LinkButton;
                System.Web.UI.WebControls.HyperLink hlViewRequest = e.Item.FindControl("hlViewRequest") as System.Web.UI.WebControls.HyperLink;
                System.Web.UI.WebControls.HyperLink hlViewResponse = e.Item.FindControl("hlViewResponse") as System.Web.UI.WebControls.HyperLink;

                DataRowView drv = e.Item.DataItem as DataRowView;

                hfWebServiceLogID.Value = drv["WebServiceLogID"].ToString();
                ltSiteName.Text = drv["SiteName"].ToString();
                hlAdvertiser.Text = drv["CompanyName"].ToString();
                hlAdvertiser.NavigateUrl =  "/admin/advertisersedit.aspx?advertiserid=" + drv["AdvertiserId"].ToString();
                ltCreatedDate.Text = Convert.ToDateTime(drv["CreatedDate"]).ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                ltMethodInvoked.Text = drv["MethodInvoked"].ToString();
                ltTotalSent.Text = drv["TotalSent"].ToString();
                ltTotalInserted.Text = drv["TotalInserted"].ToString();
                ltTotalUpdated.Text = drv["TotalUpdated"].ToString();
                ltTotalArchived.Text = drv["TotalArchived"].ToString();
                ltTotalFailed.Text = drv["TotalFailed"].ToString();

                hlViewRequest.NavigateUrl = string.Format("/admin/webservicelogview.aspx?type=request&webservicelogid={0}", hfWebServiceLogID.Value);
                hlViewResponse.NavigateUrl = string.Format("/admin/webservicelogview.aspx?type=response&webservicelogid={0}", hfWebServiceLogID.Value);

                lbDetail.CommandName = "View";
                lbDetail.CommandArgument = hfWebServiceLogID.Value;

                lbInputXML.CommandArgument = drv["WebServiceLogID"].ToString();
                lbOutputResponse.CommandArgument = drv["WebServiceLogID"].ToString();

                ScriptManager scriptMan = AjaxControlToolkit.ToolkitScriptManager.GetCurrent(this);
                UpdatePanel up = scriptMan.FindControl("updatePanel") as UpdatePanel;

                scriptMan.RegisterPostBackControl(lbInputXML);
                scriptMan.RegisterPostBackControl(lbOutputResponse);
            }
        }

        protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                if (e.CommandArgument.ToString() == "prev")
                {
                    CurrentPage = ((CurrentPage + 1) / 10 * 10 - 1);
                }
                else if (e.CommandArgument.ToString() == "next")
                {
                    CurrentPage = ((CurrentPage + 10) / 10 * 10);
                }
                else
                {
                    CurrentPage = Convert.ToInt32(e.CommandArgument);
                }

                SearchWebServiceLog();
            }
        }

        protected void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbPageNo = e.Item.FindControl("lbPageNo") as LinkButton;

                if (e.Item.DataItem.ToString() == "previous")
                {
                    lbPageNo.Text = "...";
                    lbPageNo.CommandArgument = "prev";
                }
                else if (e.Item.DataItem.ToString() == "next")
                {
                    lbPageNo.Text = "...";
                    lbPageNo.CommandArgument = "next";
                }
                else
                {
                    lbPageNo.CommandArgument = e.Item.DataItem.ToString();
                    lbPageNo.Text = (Convert.ToInt32(e.Item.DataItem) + 1).ToString();
                }

                if (lbPageNo.CommandArgument == CurrentPage.ToString())
                {
                    lbPageNo.Enabled = false;
                    lbPageNo.Font.Underline = false;
                    lbPageNo.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        protected void rptWebServiceLog_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int targetLogID = Convert.ToInt32(e.CommandArgument);

            //reference check
            Entities.WebServiceLog thisServiceLog = WebServiceLogService.CustomGetWebServiceLogByID(targetLogID).FirstOrDefault();
            if (thisServiceLog == null || thisServiceLog.SiteId != SessionData.Site.SiteId)
                return;

            if (e.CommandName == "DownloadInputXML")
            {
                DataSet ds = WebServiceLogService.CustomGetInputXML(targetLogID);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    string inputxml = ds.Tables[0].Rows[0][0].ToString();
                    if (!string.IsNullOrWhiteSpace(inputxml))
                    {
                        Response.Clear();
                        Response.AddHeader("content-disposition", string.Format("attachment;filename=InputXML_{0}.xml", Convert.ToInt32(e.CommandArgument)));
                        Response.Charset = "";
                        Response.ContentType = "text/xml";

                        if (!SessionData.AdminUser.isAdminUser)
                        {
                            XmlDocument xmldoc = new XmlDocument();
                            xmldoc.LoadXml(inputxml);

                            XmlNode usernamenode = xmldoc.SelectSingleNode("/JobPostRequest/UserName");
                            usernamenode.ParentNode.RemoveChild(usernamenode);
                            XmlNode passwordnode = xmldoc.SelectSingleNode("/JobPostRequest/Password");
                            passwordnode.ParentNode.RemoveChild(passwordnode);

                            Response.Write(xmldoc.InnerXml);
                        }
                        else
                        {
                            Response.Write(inputxml);
                        }

                        Response.End();
                    }
                }

            }
            else if (e.CommandName == "DownloadResponse")
            {
                DataSet ds = WebServiceLogService.CustomGetOutputResponse(targetLogID);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    string outputresponse = ds.Tables[0].Rows[0][0].ToString();
                    if (!string.IsNullOrWhiteSpace(outputresponse))
                    {
                        Response.Clear();
                        Response.AddHeader("content-disposition", string.Format("attachment;filename=OutputResponse_{0}.xml", Convert.ToInt32(e.CommandArgument)));
                        Response.Charset = "";
                        Response.ContentType = "text/xml";

                        Response.Write(outputresponse);

                        Response.End();
                    }
                }
            }
            else if (e.CommandName == "View")
            {
                Response.Redirect("/admin/webservicelogdetail.aspx?webservicelogid=" + e.CommandArgument);
            }
        }

        protected void btnDownloadExcel_Click(object sender, EventArgs e)
        {
            try
            {
                lblErrorMsg.Text = string.Empty;

                int siteid = Convert.ToInt32(ddlSite.SelectedValue);
                if (siteid > 0)
                {
                    WebServiceLogService service = new WebServiceLogService();
                    DataSet ds = service.CustomGetExportList(Convert.ToInt32(ddlSite.SelectedValue), Convert.ToInt32(ddlAdvertiser.SelectedValue));

                    DataTable dtJobTemplates = ds.Tables[0];
                    DataTable dtAdvertiserJobTemplateLogo = ds.Tables[1];
                    DataTable dtProfessionRoles = ds.Tables[2];
                    DataTable dtSiteWorkType = ds.Tables[3];
                    DataTable dtCountryLocationArea = ds.Tables[4];
                    DataTable dtScreeningQuestionsTemplate = ds.Tables[5];

                    // Create Excel for downlaod
                    string filepath = string.Format("{0}uploads\\files\\Webservice_{1}.xlsx", Server.MapPath("~/"), siteid);
                    // Create a spreadsheet document by supplying the filepath.
                    // By default, AutoSave = true, Editable = true, and Type = xlsx.
                    SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(filepath, SpreadsheetDocumentType.Workbook);

                    // Add a WorkbookPart to the document.
                    WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
                    workbookpart.Workbook = new Workbook();

                    // Add a WorksheetPart to the WorkbookPart.
                    WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
                    WorksheetPart worksheetPart2 = workbookpart.AddNewPart<WorksheetPart>();
                    WorksheetPart worksheetPart3 = workbookpart.AddNewPart<WorksheetPart>();
                    WorksheetPart worksheetPart4 = workbookpart.AddNewPart<WorksheetPart>();
                    WorksheetPart worksheetPart5 = workbookpart.AddNewPart<WorksheetPart>();
                    WorksheetPart worksheetPart6 = workbookpart.AddNewPart<WorksheetPart>();


                    worksheetPart.Worksheet = new Worksheet(new SheetData());
                    worksheetPart2.Worksheet = new Worksheet(new SheetData());
                    worksheetPart3.Worksheet = new Worksheet(new SheetData());
                    worksheetPart4.Worksheet = new Worksheet(new SheetData());
                    worksheetPart5.Worksheet = new Worksheet(new SheetData());
                    worksheetPart6.Worksheet = new Worksheet(new SheetData());

                    Row row;
                    Cell newCell;
                    InlineString inlineString;
                    Text t;

                    // Add Sheets to the Workbook.
                    Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.
                        AppendChild<Sheets>(new Sheets());

                    // Append a new worksheet and associate it with the workbook.
                    Sheet jobtemplatesheet = new Sheet()
                    {
                        Id = spreadsheetDocument.WorkbookPart.
                            GetIdOfPart(worksheetPart),
                        SheetId = 1,
                        Name = "Job Template"
                    };

                    sheets.Append(jobtemplatesheet);

                    SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
                    row = new Row() { RowIndex = 1 };
                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "A1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "JobTemplateID";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "B1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "JobTemplateDescription";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    sheetData.AppendChild(row);

                    for (int i = 0; i < dtJobTemplates.Rows.Count; i++)
                    {
                        // JobTemplateID, JobTemplateDescription

                        UInt32Value excelindex = Convert.ToUInt32(i + 2);
                        DataRow jobtemplatesrow = dtJobTemplates.Rows[i];

                        row = new Row() { RowIndex = DocumentFormat.OpenXml.UInt32Value.ToUInt32(excelindex) };
                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "A" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = jobtemplatesrow["JobTemplateID"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "B" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = jobtemplatesrow["JobTemplateDescription"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        sheetData.AppendChild(row);
                    }

                    Sheet advtemplatelogosheet = new Sheet()
                    {
                        Id = spreadsheetDocument.WorkbookPart.
                            GetIdOfPart(worksheetPart2),
                        SheetId = 2,
                        Name = "Advertiser Template Logo"
                    };

                    sheets.Append(advtemplatelogosheet);

                    sheetData = worksheetPart2.Worksheet.GetFirstChild<SheetData>();

                    row = new Row() { RowIndex = 1 };
                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "A1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "AdvertiserJobTemplateLogoID";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "B1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "JobLogoName";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    sheetData.AppendChild(row);

                    for (int i = 0; i < dtAdvertiserJobTemplateLogo.Rows.Count; i++)
                    {
                        // AdvertiserJobTemplateLogoID, JobLogoName

                        UInt32Value excelindex = Convert.ToUInt32(i + 2);
                        DataRow advertiserJobTemplaterow = dtAdvertiserJobTemplateLogo.Rows[i];

                        row = new Row() { RowIndex = DocumentFormat.OpenXml.UInt32Value.ToUInt32(excelindex) };
                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "A" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = advertiserJobTemplaterow["AdvertiserJobTemplateLogoID"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "B" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = advertiserJobTemplaterow["JobLogoName"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        sheetData.AppendChild(row);
                    }

                    Sheet professionrolessheet = new Sheet()
                    {
                        Id = spreadsheetDocument.WorkbookPart.
                            GetIdOfPart(worksheetPart3),
                        SheetId = 3,
                        Name = "Profession & Roles"
                    };
                    sheets.Append(professionrolessheet);

                    sheetData = worksheetPart3.Worksheet.GetFirstChild<SheetData>();
                    row = new Row() { RowIndex = 1 };
                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "A1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "ProfessionID";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "B1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "ProfessionName";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "C1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "RoleID";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "D1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "RoleName";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    sheetData.AppendChild(row);
                    for (int i = 0; i < dtProfessionRoles.Rows.Count; i++)
                    {
                        // ProfessionID, SiteProfessionName, RoleID, SiteRoleName

                        UInt32Value excelindex = Convert.ToUInt32(i + 2);
                        DataRow professionrolesrow = dtProfessionRoles.Rows[i];

                        row = new Row() { RowIndex = DocumentFormat.OpenXml.UInt32Value.ToUInt32(excelindex) };
                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "A" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = professionrolesrow["ProfessionID"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "B" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = professionrolesrow["SiteProfessionName"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "C" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = professionrolesrow["RoleID"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "D" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = professionrolesrow["SiteRoleName"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        sheetData.AppendChild(row);
                    }

                    Sheet worktypesheet = new Sheet()
                    {
                        Id = spreadsheetDocument.WorkbookPart.
                            GetIdOfPart(worksheetPart4),
                        SheetId = 4,
                        Name = "Work Type"
                    };
                    sheets.Append(worktypesheet);

                    sheetData = worksheetPart4.Worksheet.GetFirstChild<SheetData>();
                    row = new Row() { RowIndex = 1 };
                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "A1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "WorkTypeID";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "B1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "WorkTypeName";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);
                    sheetData.AppendChild(row);
                    for (int i = 0; i < dtSiteWorkType.Rows.Count; i++)
                    {
                        // WorkTypeID, SiteWorkTypeName

                        UInt32Value excelindex = Convert.ToUInt32(i + 2);
                        DataRow worktyperow = dtSiteWorkType.Rows[i];

                        row = new Row() { RowIndex = DocumentFormat.OpenXml.UInt32Value.ToUInt32(excelindex) };
                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "A" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = worktyperow["WorkTypeID"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "B" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = worktyperow["SiteWorkTypeName"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        sheetData.AppendChild(row);
                    }

                    Sheet countrylocationarea = new Sheet()
                    {
                        Id = spreadsheetDocument.WorkbookPart.
                            GetIdOfPart(worksheetPart5),
                        SheetId = 5,
                        Name = "Country, Location & Area"
                    };
                    sheets.Append(countrylocationarea);

                    sheetData = worksheetPart5.Worksheet.GetFirstChild<SheetData>();
                    row = new Row() { RowIndex = 1 };
                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "A1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "CountryID";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "B1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "CountryName";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);
                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "C1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "LocationID";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "D1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "LocationName";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "E1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "AreaID";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "F1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "AreaName";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);
                    sheetData.AppendChild(row);
                    for (int i = 0; i < dtCountryLocationArea.Rows.Count; i++)
                    {
                        // CountryID, SiteCountryName, LocationID, SiteLocationName, AreaID, SiteAreaName

                        UInt32Value excelindex = Convert.ToUInt32(i + 2);
                        DataRow countrylocationarearow = dtCountryLocationArea.Rows[i];

                        row = new Row() { RowIndex = DocumentFormat.OpenXml.UInt32Value.ToUInt32(excelindex) };
                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "A" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = countrylocationarearow["CountryID"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "B" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = countrylocationarearow["SiteCountryName"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "C" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = countrylocationarearow["LocationID"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "D" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = countrylocationarearow["SiteLocationName"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "E" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = countrylocationarearow["AreaID"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "F" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = countrylocationarearow["SiteAreaName"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        sheetData.AppendChild(row);
                    }

                    Sheet screeningquestionstemplate = new Sheet()
                    {
                        Id = spreadsheetDocument.WorkbookPart.
                            GetIdOfPart(worksheetPart6),
                        SheetId = 6,
                        Name = "Screening Questions Template"
                    };
                    sheets.Append(screeningquestionstemplate);

                    sheetData = worksheetPart6.Worksheet.GetFirstChild<SheetData>();

                    row = new Row() { RowIndex = 1 };
                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "A1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "ScreeningQuestionsTemplateID";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "B1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "TemplateName";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    sheetData.AppendChild(row);

                    for (int i = 0; i < dtScreeningQuestionsTemplate.Rows.Count; i++)
                    {
                        // ScreeningQuestionsTemplateID, TemplateName

                        UInt32Value excelindex = Convert.ToUInt32(i + 2);
                        DataRow screeningQuestionsTemplateRow = dtScreeningQuestionsTemplate.Rows[i];

                        row = new Row() { RowIndex = DocumentFormat.OpenXml.UInt32Value.ToUInt32(excelindex) };
                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "A" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = screeningQuestionsTemplateRow["ScreeningQuestionsTemplateID"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "B" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = screeningQuestionsTemplateRow["TemplateName"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        sheetData.AppendChild(row);
                    }

                    workbookpart.Workbook.Save();

                    // Close the document.
                    spreadsheetDocument.Close();

                    Response.Clear();
                    Response.AddHeader("content-disposition", string.Format("attachment;filename=WebService_{0}.xlsx", siteid));
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";

                    Response.WriteFile(filepath);

                    Response.End();
                }

            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
            }

        }

        protected void cvDateFrom_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(tbDateFrom.Text))
            {
                DateTime dt;

                if (DateTime.TryParseExact(tbDateFrom.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    if (dt < System.Data.SqlTypes.SqlDateTime.MinValue.Value || dt > new DateTime(DateTime.Now.Year + 100, 12, 31))
                    {
                        cvDateFrom.ErrorMessage = "Date out of range.";

                        args.IsValid = false;
                    }
                }
                else
                {
                    cvDateFrom.ErrorMessage = "Invalid Date.";

                    args.IsValid = false;
                }
            }
        }

        protected void cvDateTo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(tbDateTo.Text))
            {
                DateTime dt;

                if (DateTime.TryParseExact(tbDateTo.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    if (dt < System.Data.SqlTypes.SqlDateTime.MinValue.Value || dt > new DateTime(DateTime.Now.Year + 100, 12, 31))
                    {
                        cvDateTo.ErrorMessage = "Date out of range.";

                        args.IsValid = false;
                    }
                }
                else
                {
                    cvDateTo.ErrorMessage = "Invalid Date.";

                    args.IsValid = false;
                }
            }
        }

        private void LoadAdvertisers(int advertiserid = 0)
        {
            ddlAdvertiser.Items.Clear();
            int siteid = Convert.ToInt32(ddlSite.SelectedValue);

            if (siteid > 0)
            {
                TList<Entities.Advertisers> advertisers = AdvertisersService.GetBySiteId(siteid);
                advertisers.Sort("CompanyName");

                foreach (Entities.Advertisers advertiser in advertisers)
                {
                    // Only approved advertisers
                    if (advertiser.AdvertiserAccountStatusId == (int)PortalEnums.Advertiser.AccountStatus.Approved) 
                        ddlAdvertiser.Items.Add(new ListItem(advertiser.CompanyName, advertiser.AdvertiserId.ToString()));
                }
                ddlAdvertiser.Items.Insert(0, new ListItem("Select an Advertiser", "0"));
            }
            else
            {
                ddlAdvertiser.Items.Insert(0, new ListItem("Please choose a Site", "0"));
            }

            ddlAdvertiser.SelectedValue = advertiserid.ToString();
        }

        protected void ddlSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAdvertisers();
        }

        internal class ProfessionRolesExcel
        {
            public JXTPortal.Entities.SiteProfession SiteProfession { get; set; }
            public TList<JXTPortal.Entities.SiteRoles> SiteRoles { get; set; }

            public ProfessionRolesExcel()
            {
                SiteRoles = new TList<JXTPortal.Entities.SiteRoles>();
            }
        }

        internal class CountryLocationExcel
        {
            public JXTPortal.Entities.SiteCountries SiteCountries { get; set; }
            public List<LocationAreaExcel> LocationAreaExcel { get; set; }

            public CountryLocationExcel()
            {
                LocationAreaExcel = new List<LocationAreaExcel>();
            }
        }

        internal class LocationAreaExcel
        {
            public JXTPortal.Entities.SiteLocation SiteLocation { get; set; }
            public TList<JXTPortal.Entities.SiteArea> SiteArea { get; set; }

            public LocationAreaExcel()
            {
                SiteArea = new TList<JXTPortal.Entities.SiteArea>();
            }
        }

        private class SiteDDLItems
        {
            public string SiteID { get; set; }
            public string SiteName { get; set; }
        }

    }
}
