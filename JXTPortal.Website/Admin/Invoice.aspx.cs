using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using JXTPortal.Entities;
using JXTPortal.Common;
using JXTPortal.Web.UI;
using JXTPortal;

using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

public partial class Invoice : System.Web.UI.Page
{
    protected string DateFormat
    {
        get { return SessionData.Site.DateFormat.ToLower(); }
    }

    private JobItemsTypeService _jobitemstypeService = null;

    private JobItemsTypeService JobItemsTypeService
    {
        get
        {
            if (_jobitemstypeService == null)
            {
                _jobitemstypeService = new JobItemsTypeService();
            }
            return _jobitemstypeService;
        }
    }

    private InvoiceOrderService _invoiceOrderService = null;

    private InvoiceOrderService InvoiceOrderService
    {
        get
        {
            if (_invoiceOrderService == null)
            {
                _invoiceOrderService = new InvoiceOrderService();
            }
            return _invoiceOrderService;
        }
    }

    private GlobalSettingsService _globalSettingsService = null;

    private GlobalSettingsService GlobalSettingsService
    {
        get
        {
            if (_globalSettingsService == null)
            {
                _globalSettingsService = new GlobalSettingsService();
            }
            return _globalSettingsService;
        }
    }


    private AdvertiserUsersService _advertiserUsersService = null;

    private AdvertiserUsersService AdvertiserUsersService
    {
        get
        {
            if (_advertiserUsersService == null)
            {
                _advertiserUsersService = new AdvertiserUsersService();
            }
            return _advertiserUsersService;
        }
    }

    private AdvertisersService _advertisersService = null;

    private AdvertisersService AdvertisersService
    {
        get
        {
            if (_advertisersService == null)
            {
                _advertisersService = new AdvertisersService();
            }
            return _advertisersService;
        }
    }

    private InvoiceService _invoiceService = null;

    private InvoiceService InvoiceService
    {
        get
        {
            if (_invoiceService == null)
            {
                _invoiceService = new InvoiceService();
            }
            return _invoiceService;
        }
    }

    private SitesService _siteService = null;

    private SitesService SitesService
    {
        get
        {
            if (_siteService == null)
            {
                _siteService = new SitesService();
            }
            return _siteService;
        }
    }

    private int CurrentPage
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

    string CurrencySymbol = "$";

    protected void Page_Load(object sender, EventArgs e)
    {
        using (GlobalSettings gs = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId).FirstOrDefault())
        {
            if (gs != null)
            {
                if (gs.SiteType == (int)PortalEnums.Admin.SiteType.Recruiter)
                {
                    Response.Redirect("/admin/default.aspx");
                }
            }
        }

        if (!Page.IsPostBack)
        {
            tbFrom.Text = DateTime.Now.AddDays(-30).ToString(SessionData.Site.DateFormat);
            tbTo.Text = DateTime.Now.ToString(SessionData.Site.DateFormat);

            LoadCurrencySymbol();
            LoadAdvertiser();
            LoadJobItemType();
            LoadInvoiceOrder();
        }
    }

    private void LoadCurrencySymbol()
    {
        using (GlobalSettings gs = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId).FirstOrDefault())
        {
            if (gs != null)
            {
                int currencyID = gs.CurrencyId;

                //set currency symbol
                PortalEnums.Jobs.CurrencySymbol thisSymbol = (PortalEnums.Jobs.CurrencySymbol)currencyID;
                CurrencySymbol = JXTPortal.Website.CommonFunction.GetEnumDescription(thisSymbol);
            }
        }
    }

    private void LoadInvoiceOrder()
    {
        int noofrecords = Convert.ToInt32(ddlShowRecords.SelectedValue);

        DateTime fromDate = DateTime.Now.AddDays(-30);
        DateTime.TryParseExact(tbFrom.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out fromDate);


        DateTime toDate = DateTime.Now;
        DateTime.TryParseExact(tbTo.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out toDate);


        DataSet dsInvoice = InvoiceService.CustomGetAdvertiserInvoiceReport(SessionData.Site.SiteId, (ddlAdvertiser.SelectedValue == "0") ? (int?)null : Convert.ToInt32(ddlAdvertiser.SelectedValue), null, (ddlAdvertiserType.SelectedValue == "0") ? (int?)null : Convert.ToInt32(ddlAdvertiserType.SelectedValue),
            (ddlItemType.SelectedValue == "0" || ddlItemType.SelectedValue == "4") ? (int?)null : Convert.ToInt32(ddlItemType.SelectedValue), (string.IsNullOrWhiteSpace(tbInvoiceNo.Text)) ? string.Empty : tbInvoiceNo.Text.Trim(), fromDate, toDate, CurrentPage, noofrecords, string.Empty, string.Empty);
        rptInvoice.DataSource = dsInvoice.Tables[0];
        rptInvoice.DataBind();

        int totalCount = Convert.ToInt32(dsInvoice.Tables[1].Rows[0]["TotalRowCount"]);
        if (totalCount > 0)
        {
            int pageCount = 0;
            rptInvoice.Visible = true;
            lblErrorMsg.Visible = false;
            phDownload.Visible = true;
            ibDownloadAll.Visible = true;
            ArrayList pagelist = new ArrayList();
            if (totalCount % noofrecords == 0)
            {
                pageCount = totalCount / noofrecords;
            }
            else
            {
                pageCount = (totalCount / noofrecords) + 1;
            }

            int index = 0;
            for (int i = index; i < pageCount; i++)
            {
                pagelist.Add((i + 1).ToString());

                if (i == pageCount - 1)
                {
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

            if (pagelist.Count > 1)
            {
                rptPage.DataSource = pagelist;
                rptPage.DataBind();
                rptPage.Visible = true;

                LinkButton lbPrevious = rptPage.Controls[0].Controls[0].FindControl("lbPrevious") as LinkButton;
                LinkButton lbNext = rptPage.Controls[rptPage.Controls.Count - 1].Controls[0].FindControl("lbNext") as LinkButton;


                lbPrevious.CssClass = (CurrentPage != 0) ? "" : "disabled";
                lbPrevious.Enabled = (CurrentPage != 0);
                lbNext.CssClass = (noofrecords != pagelist.Count - 1) ? "" : "disabled";
                lbNext.Enabled = (CurrentPage != pagelist.Count - 1);
            }
            else
            {
                rptPage.Visible = false;
            }
        }
        else
        {
            rptInvoice.Visible = false;
            rptPage.Visible = false;
            lblErrorMsg.Visible = true;
            phDownload.Visible = false;
            ibDownloadAll.Visible = false;
        }
    }

    private void LoadJobItemType()
    {
        ddlItemType.Items.Clear();
        using (TList<JXTPortal.Entities.JobItemsType> jobitemtypes = JobItemsTypeService.GetBySiteId(SessionData.Site.SiteId))
        {
            foreach (JXTPortal.Entities.JobItemsType jobitemtype in jobitemtypes)
            {
                if (jobitemtype.TotalNumberOfJobs == 1)
                {
                    ddlItemType.Items.Add(new ListItem(jobitemtype.JobItemTypeDescription, jobitemtype.JobItemTypeParentId.ToString()));
                }

            }

            ddlItemType.Items.Insert(0, new ListItem("Please select Item Type", "0"));
        }
    }

    private void LoadAdvertiser()
    {
        using (TList<JXTPortal.Entities.Advertisers> advertisers = AdvertisersService.GetBySiteId(SessionData.Site.SiteId))
        {
            advertisers.Sort("CompanyName");

            ddlAdvertiser.Items.Clear();

            foreach (JXTPortal.Entities.Advertisers advertiser in advertisers)
            {
                ddlAdvertiser.Items.Add(new ListItem(advertiser.CompanyName, advertiser.AdvertiserId.ToString()));
            }

            ddlAdvertiser.Items.Insert(0, new ListItem("Please select advertiser", "0"));
        }
    }

    protected void rptInvoice_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView order = e.Item.DataItem as DataRowView;

            HyperLink hlInvoiceDetail = e.Item.FindControl("hlInvoiceDetail") as HyperLink;
            HyperLink hlAdvertiserName = e.Item.FindControl("hlAdvertiserName") as HyperLink;
            Literal ltAdvertiserType = e.Item.FindControl("ltAdvertiserType") as Literal;
            HiddenField hfOrderID = e.Item.FindControl("hfOrderID") as HiddenField;
            Literal ltItems = e.Item.FindControl("ltItems") as Literal;
            Literal ltDate = e.Item.FindControl("ltDate") as Literal;
            Literal ltTotal = e.Item.FindControl("ltTotal") as Literal;
            Literal ltIsPaid = e.Item.FindControl("ltIsPaid") as Literal;
            Literal ltTransactionID = e.Item.FindControl("ltTransactionID") as Literal;

            hlInvoiceDetail.Text = order["OrderID"].ToString();
            hfOrderID.Value = order["OrderID"].ToString();
            hlInvoiceDetail.NavigateUrl = "invoicedetail.aspx?orderid=" + order["OrderID"].ToString();
            hlAdvertiserName.Text = order["CompanyName"].ToString();
            hlAdvertiserName.NavigateUrl = "/admin/advertisersedit.aspx?advertiserid=" + order["AdvertiserID"].ToString();
            ltItems.Text = order["InvoiceItems"].ToString();
            ltDate.Text = Convert.ToDateTime(order["CreatedDate"]).ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
            ltTotal.Text = CurrencySymbol + order["Total"].ToString();
            ltTransactionID.Text = order["bankTransactionID"].ToString();
            ltIsPaid.Text = (Convert.ToBoolean(order["isPaid"])) ? "Yes" : "No";
            ltAdvertiserType.Text = Enum.GetName(typeof(PortalEnums.Advertiser.AccountType), Convert.ToInt32(order["AdvertiserAccountTypeID"]));

            //CreatedDate, PaymentTypeID, IsPayable, IsPaid, DatePaid,   
            //     TotalAmount, GST, Total, Success,   
            //     AdvertiserAccountTypeID, FirstName, Surname, CompanyName,  
            //     InvoiceItems
        }
    }

    protected void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lbPage = e.Item.FindControl("lbPage") as LinkButton;
            lbPage.Text = e.Item.DataItem.ToString();

            lbPage.CommandArgument = (Convert.ToInt32(e.Item.DataItem) - 1).ToString();
            if (CurrentPage + 1 == Convert.ToInt32(e.Item.DataItem))
            {
                lbPage.CssClass = "active";
                lbPage.Enabled = false;
            }
        }
    }

    protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Page")
        {
            CurrentPage = Convert.ToInt32(e.CommandArgument);
        }

        if (e.CommandName == "Previous")
        {
            CurrentPage--;
        }

        if (e.CommandName == "Next")
        {
            CurrentPage++;
        }

        LoadInvoiceOrder();
    }

    private byte[] GeneratePDF(int OrderID, string siteinfo, string footer, string taxlabel, string CurrencySymbol = "$")
    {
        string text = System.IO.File.ReadAllText(Server.MapPath("~") + "App_GlobalResources\\InvoiceDetail.txt");
        string advertisername = string.Empty;
        string siteslogo = string.Empty;
        string clientname = string.Empty;
        string clientaddress = string.Empty;
        string clientemail = string.Empty;
        string dateofinvoice = string.Empty;
        string invoicebody = string.Empty;
        string subtotal = string.Empty;
        string tax = string.Empty;
        string grandtotal = string.Empty;

        using (InvoiceOrder order = InvoiceOrderService.GetByOrderId(OrderID))
        {
            if (order != null)
            {
                int advuserid = order.AdvertiserUserId;

                using (JXTPortal.Entities.AdvertiserUsers advuser = AdvertiserUsersService.GetByAdvertiserUserId(advuserid))
                {
                    if (advuser != null)
                    {
                        using (JXTPortal.Entities.Advertisers adv = AdvertisersService.GetByAdvertiserId(advuser.AdvertiserId))
                        {
                            if (adv != null && adv.SiteId == SessionData.Site.SiteId)
                            {
                                advertisername = HttpUtility.HtmlEncode(adv.CompanyName);

                                using (JXTPortal.Entities.Sites site = SitesService.GetBySiteId(SessionData.Site.SiteId))
                                {
                                    if (!string.IsNullOrWhiteSpace(site.SiteAdminLogoUrl))
                                    {
                                        siteslogo = string.Format("<img src='http://jxt1.com.jxt1.com/media/{0}/{1}' alt='{2}' />", ConfigurationManager.AppSettings["SitesFolder"], site.SiteAdminLogoUrl, SessionData.Site.SiteName.Replace("'", ""));
                                    }
                                    else
                                    {
                                        if (site.SiteAdminLogo != null)
                                        {
                                            siteslogo = string.Format("<img src='http://jxt1.com.jxt1.com/admin/getadminlogo.aspx?siteid={0}' alt='{1}' />", SessionData.Site.SiteId, SessionData.Site.SiteName.Replace("'", ""));
                                        }
                                    }

                                }
                                
                                clientname = adv.CompanyName;
                                clientaddress = HttpUtility.HtmlEncode(string.Format("{0} {1}", adv.StreetAddress1, adv.StreetAddress2));
                                clientemail = adv.AccountsPayableEmail;
                                dateofinvoice = order.CreatedDate.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                                invoicebody = string.Empty;
                                subtotal = CurrencySymbol + order.TotalAmount.ToString("0.00");
                                tax = CurrencySymbol + order.Gst.ToString("0.00");
                                grandtotal = CurrencySymbol + (order.TotalAmount + order.Gst).ToString("0.00");


                                using (TList<JXTPortal.Entities.Invoice> invoices = InvoiceService.GetByOrderId(order.OrderId))
                                {
                                    int i = 0;
                                    foreach (JXTPortal.Entities.Invoice invoice in invoices)
                                    {
                                        i++;
                                        string packname = string.Empty;
                                        string packdesc = string.Empty;

                                        if ((invoice.TotalNumberOfJobs / invoice.Quantity) == 1)
                                        {
                                            packname = invoice.Description;
                                        }
                                        else
                                        {
                                            packname = invoice.Description;
                                            using (TList<JXTPortal.Entities.JobItemsType> itemtypes = JobItemsTypeService.CustomGetBySiteID(SessionData.Site.SiteId))
                                            {
                                                foreach (JXTPortal.Entities.JobItemsType itemtype in itemtypes)
                                                {
                                                    if (itemtype.JobItemTypeParentId == invoice.JobItemTypeId && itemtype.TotalNumberOfJobs == 1 && itemtype.Valid)
                                                    {
                                                        packdesc = itemtype.JobItemTypeDescription;
                                                        break;
                                                    }
                                                }
                                            }
                                        }

                                        invoicebody += string.Format(@"
                                        <tr>
                                            <td class=""no"">{0}</td>
                                            <td class=""desc""><h3>{1}</h3>
                                              {2}</td>
                                            <td class=""unit"">{3}</td>
                                            <td class=""qty"">{4}</td>
                                            <td class=""total"">{5}</td>
                                        </tr>", i, packname, packdesc, CurrencySymbol + (invoice.TotalAmount / invoice.Quantity).ToString("0.00"), invoice.Quantity.ToString(), CurrencySymbol + (invoice.TotalAmount).ToString("0.00"));
                                    }
                                }

                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
        }

        string html = string.Format(text, advertisername, OrderID, siteslogo, siteinfo, clientname, clientaddress, clientemail, dateofinvoice, invoicebody, subtotal, taxlabel, tax, grandtotal, footer);

        byte[] file = new PDFCreator().ConvertHTMLToPDF(html);

        return file;

    }

    private void WriteFileToZip(byte[] file, byte[] buffer, ZipOutputStream s)
    {

        StreamUtils.Copy(new MemoryStream(file), s, buffer);

        s.CloseEntry();
    }

    protected void ibDownloadAll_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                DateTime fromDate = DateTime.Now.AddDays(-30);
                DateTime.TryParseExact(tbFrom.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out fromDate);


                DateTime toDate = DateTime.Now;
                DateTime.TryParseExact(tbTo.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out toDate);

                DataSet dsInvoice = InvoiceService.CustomGetAdvertiserInvoiceReport(SessionData.Site.SiteId, (ddlAdvertiser.SelectedValue == "0") ? (int?)null : Convert.ToInt32(ddlAdvertiser.SelectedValue), null, (ddlAdvertiserType.SelectedValue == "0") ? (int?)null : Convert.ToInt32(ddlAdvertiserType.SelectedValue),
                    (ddlItemType.SelectedValue == "0" || ddlItemType.SelectedValue == "4") ? (int?)null : Convert.ToInt32(ddlItemType.SelectedValue), (string.IsNullOrWhiteSpace(tbInvoiceNo.Text)) ? string.Empty : tbInvoiceNo.Text.Trim(), fromDate, toDate, CurrentPage, Int16.MaxValue, string.Empty, string.Empty);
                if (dsInvoice.Tables[0].Rows.Count > 0)
                {
                    // Create Excel for downlaod
                    string filepath = string.Format("{0}uploads\\files\\Invoice_{1}.xlsx", Server.MapPath("~/"), SessionData.Site.SiteId);
                    // Create a spreadsheet document by supplying the filepath.
                    // By default, AutoSave = true, Editable = true, and Type = xlsx.
                    SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(filepath, SpreadsheetDocumentType.Workbook);

                    // Add a WorkbookPart to the document.
                    WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
                    workbookpart.Workbook = new Workbook();

                    // Add a WorksheetPart to the WorkbookPart.
                    WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();

                    worksheetPart.Worksheet = new Worksheet(new SheetData());

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
                        Name = "Invoices"
                    };

                    sheets.Append(jobtemplatesheet);

                    SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
                    row = new Row() { RowIndex = 1 };
                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "A1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "Invoice No.";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "B1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "Advertiser name";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "C1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "Advertiser type";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "D1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "Items";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "E1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "Date";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "F1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "Total";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "G1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "Is Paid";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "H1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "Bank Transaction ID";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "I1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "Credit Card Name";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    newCell = new Cell();
                    newCell.DataType = CellValues.InlineString;
                    newCell.CellReference = "J1";
                    inlineString = new InlineString();
                    t = new Text();
                    t.Text = "Invoice Code";
                    inlineString.Append(t);
                    newCell.AppendChild(inlineString);
                    row.AppendChild(newCell);

                    sheetData.AppendChild(row);


                    for (int i = 0; i < dsInvoice.Tables[0].Rows.Count; i++)
                    {
                        UInt32Value excelindex = Convert.ToUInt32(i + 2);
                        DataRow order = dsInvoice.Tables[0].Rows[i];

                        //hlInvoiceDetail.Text = order["OrderID"].ToString();
                        //hfOrderID.Value = order["OrderID"].ToString();
                        //hlInvoiceDetail.NavigateUrl = "invoicedetail.aspx?orderid=" + order["OrderID"].ToString();
                        //ltAdvertiserName.Text = order["CompanyName"].ToString();
                        //ltItems.Text = order["InvoiceItems"].ToString();
                        //ltDate.Text = order["CreatedDate"].ToString();
                        //ltTotal.Text = order["Total"].ToString();

                        row = new Row() { RowIndex = DocumentFormat.OpenXml.UInt32Value.ToUInt32(excelindex) };
                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "A" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = order["OrderID"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "B" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = order["CompanyName"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "C" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = Enum.GetName(typeof(PortalEnums.Advertiser.AccountType), Convert.ToInt32(order["AdvertiserAccountTypeID"]));
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "D" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = order["InvoiceItems"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "E" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = ((DateTime)order["CreatedDate"]).ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "F" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = CurrencySymbol + order["Total"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "G" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = (Convert.ToBoolean(order["isPaid"])) ? "Yes" : "No";
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);


                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "H" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = order["bankTransactionID"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "I" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = order["CardName"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "J" + excelindex.ToString();
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = order["InvoiceCode"].ToString();
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        sheetData.AppendChild(row);
                    }

                    workbookpart.Workbook.Save();

                    // Close the document.
                    spreadsheetDocument.Close();

                    Response.Clear();
                    Response.AddHeader("content-disposition", string.Format("attachment;filename=Invoice_{0}.xlsx", SessionData.Site.SiteId));
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
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        tbFrom.Text = DateTime.Now.AddDays(-30).ToString(SessionData.Site.DateFormat);
        tbTo.Text = DateTime.Now.ToString(SessionData.Site.DateFormat);
        ddlAdvertiser.SelectedIndex = 0;
        tbInvoiceNo.Text = string.Empty;
        ddlItemType.SelectedIndex = 0;
        ddlAdvertiserType.SelectedIndex = 0;
        ddlAdvertiser.SelectedIndex = 0;

        CurrentPage = 0;
        LoadInvoiceOrder();
    }

    protected void ibDownloadSelected_Click(object sender, EventArgs e)
    {
        int orderid = 0;

        foreach (RepeaterItem item in rptInvoice.Items)
        {
            CheckBox ckSelect = item.FindControl("ckSelect") as CheckBox;
            HiddenField hfOrderID = item.FindControl("hfOrderID") as HiddenField;

            if (ckSelect.Checked)
            {
                int.TryParse(hfOrderID.Value, out orderid);
                break;
            }
        }

        if (orderid > 0)
        {
            using (GlobalSettings gs = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId).FirstOrDefault())
            {
                if (gs != null)
                {
                    int currencyID = gs.CurrencyId;


                    string pdffilename = string.Format("invoices_{0}.pdf", orderid);

                    byte[] file = GeneratePDF(orderid, gs.InvoiceSiteInfo, gs.InvoiceSiteFooter, gs.GstLabel, CurrencySymbol);
                    if (file != null)
                    {
                        // Email Testing: has to be removed
                        //InvoiceOrder order = InvoiceOrderService.GetByOrderId(orderid);
                        //JXTPortal.Entities.AdvertiserUsers user = AdvertiserUsersService.GetByAdvertiserUserId(order.AdvertiserUserId);
                        //MailService.SendPaymentConfirmationEmail(user, orderid, file);

                        this.Response.ContentType = "application/pdf";
                        this.Response.AppendHeader("Content-Disposition", "attachment;filename=" + Path.GetFileName(pdffilename));
                        this.Response.BinaryWrite(file);
                        this.Response.End();

                    }
                }

            }
        }
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            CurrentPage = 0;
            LoadInvoiceOrder();
        }
    }

    protected void cvDate_ServerValidate(object source, ServerValidateEventArgs args)
    {
        DateTime dtFrom = DateTime.Now;
        DateTime dtTo = DateTime.Now;

        if (tbFrom.Text != string.Empty)
        {
            if (!DateTime.TryParseExact(tbFrom.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out dtFrom))
            {
                args.IsValid = false;
                cvDate.ErrorMessage = "Invalid Date From format";
                return;
            }
        }
        else
        {
            args.IsValid = false;
            cvDate.ErrorMessage = "Date From & Date To cannot be empty";
            return;
        }

        if (tbTo.Text != string.Empty)
        {
            if (!DateTime.TryParseExact(tbTo.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out dtTo))
            {
                args.IsValid = false;
                cvDate.ErrorMessage = "Invalid Date to format";
                return;
            }
        }
        else
        {
            args.IsValid = false;
            cvDate.ErrorMessage = "Date From & Date To cannot be empty";
            return;
        }


        if (dtFrom.CompareTo(dtTo) == 1)
        {
            args.IsValid = false;
            cvDate.ErrorMessage = "Date To is earlier than Date From";
            return;
        }

        int daysDiff = ((TimeSpan)(dtTo - dtFrom)).Days;

        if (daysDiff > 183)
        {
            args.IsValid = false;
            cvDate.ErrorMessage = "Maximum Date Range is 6 months";
            return;
        }

    }

    protected void rptInvoice_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Advertiser")
        {
            Response.Redirect("/admin/advertisersedit.aspx?AdvertiserID=" + e.CommandArgument);
        }
    }
}