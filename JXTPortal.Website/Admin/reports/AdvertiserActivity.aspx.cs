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

namespace JXTPortal.Website.Admin.reports
{
    public partial class AdvertiserActivity : System.Web.UI.Page
    {
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

        protected string DateFormat
        {
            get { return SessionData.Site.DateFormat.ToLower(); }
        }


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
                tbTo.Text = DateTime.Now.ToString(SessionData.Site.DateFormat);
                tbFrom.Text = DateTime.Now.AddMonths(-3).ToString(SessionData.Site.DateFormat);

                LoadAdvertiserActivity();
            }
        }

        private void LoadAdvertiserActivity()
        {
            int noofrecords = Convert.ToInt32(ddlShowRecords.SelectedValue);
            bool fromdateempty = false;
            DateTime fromDate = DateTime.Now.AddYears(-100);
            if (!DateTime.TryParseExact(tbFrom.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out fromDate))
            {
                fromDate = DateTime.Now.AddYears(-100);
                fromdateempty = true;
            }

            bool todateempty = false;
            DateTime toDate = DateTime.Now;
            if (!DateTime.TryParseExact(tbTo.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out toDate))
            {
                toDate = DateTime.Now;
                todateempty = true;
            }

            DataSet dsAdvertiserActivity = AdvertisersService.CustomGetActivityReport(SessionData.Site.SiteId, tbKeyword.Text, (fromdateempty) ? (DateTime?)null : fromDate, (todateempty) ? (DateTime?)null : toDate, CurrentPage, noofrecords, ddlSortByColumn.SelectedValue, Convert.ToBoolean(ddlOrder.SelectedValue));

            rptAdvertiserActivity.DataSource = dsAdvertiserActivity.Tables[0];
            rptAdvertiserActivity.DataBind();

            int totalCount = Convert.ToInt32(dsAdvertiserActivity.Tables[1].Rows[0]["TotalRowCount"]);
            if (totalCount > 0)
            {
                int pageCount = 0;
                rptAdvertiserActivity.Visible = true;
                lblErrorMsg.Visible = false;
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
                rptAdvertiserActivity.Visible = false;
                rptPage.Visible = false;
                lblErrorMsg.Visible = true;
                ibDownloadAll.Visible = false;
            }
        }

        protected void rptAdvertiserActivity_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView activity = e.Item.DataItem as DataRowView;

                Literal ltAdvertiserID = e.Item.FindControl("ltAdvertiserID") as Literal;
                HyperLink hlAdvertiser = e.Item.FindControl("hlAdvertiser") as HyperLink;
                HyperLink hlEmail = e.Item.FindControl("hlEmail") as HyperLink;
                Literal ltAccCreated = e.Item.FindControl("ltAccCreated") as Literal;
                Literal ltLastJobPost = e.Item.FindControl("ltLastJobPost") as Literal;
                Literal ltAccountStatus = e.Item.FindControl("ltAccountStatus") as Literal;
                Literal ltJobsLive = e.Item.FindControl("ltJobsLive") as Literal;
                Literal ltTotalPosted = e.Item.FindControl("ltTotalPosted") as Literal;
                Literal ltLastLoggedIn = e.Item.FindControl("ltLastLoggedIn") as Literal;


                ltAdvertiserID.Text = activity["AdvertiserID"].ToString();
                hlAdvertiser.Text = activity["CompanyName"].ToString();
                hlAdvertiser.NavigateUrl = "/admin/advertisersEdit.aspx?advertiserId=" + activity["AdvertiserID"].ToString();
                hlEmail.Text = activity["Email"].ToString();
                hlEmail.NavigateUrl = "/admin/advertiserUsersEdit.aspx?AdvertiserUserID=" + activity["AdvertiserUserID"].ToString();
                ltAccCreated.Text = (activity["RegisterDate"].ToString() == string.Empty) ? string.Empty : ((DateTime)activity["RegisterDate"]).ToString(SessionData.Site.DateFormat);
                ltLastJobPost.Text = (activity["LastJobPost"].ToString() == string.Empty) ? string.Empty : ((DateTime)activity["LastJobPost"]).ToString(SessionData.Site.DateFormat);
                ltAccountStatus.Text =   ((PortalEnums.AdvertiserUser.AccountStatus)Convert.ToInt32(activity["AdvertiserAccountStatusID"])).ToString();
                ltJobsLive.Text = activity["JobsLive"].ToString();
                ltTotalPosted.Text = activity["TotalJobs"].ToString();
                ltLastLoggedIn.Text = (activity["LastLoginDate"].ToString() == string.Empty) ? string.Empty : ((DateTime)activity["LastLoginDate"]).ToString(SessionData.Site.DateFormat);
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

            LoadAdvertiserActivity();
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
                    bool fromdateempty = false;
                    DateTime fromDate = DateTime.Now.AddYears(-100);
                    if (!DateTime.TryParseExact(tbFrom.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out fromDate))
                    {
                        fromDate = DateTime.Now.AddYears(-100);
                        fromdateempty = true;
                    }

                    bool todateempty = false;
                    DateTime toDate = DateTime.Now;
                    if (!DateTime.TryParseExact(tbTo.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out toDate))
                    {
                        toDate = DateTime.Now;
                        todateempty = true;
                    }

                    DataSet dsAdvertiserActivity = AdvertisersService.CustomGetActivityReport(SessionData.Site.SiteId, tbKeyword.Text, (fromdateempty) ? (DateTime?)null : fromDate, (todateempty) ? (DateTime?)null : toDate, CurrentPage, Int16.MaxValue, ddlSortByColumn.SelectedValue, Convert.ToBoolean(ddlOrder.SelectedValue));
                    if (dsAdvertiserActivity.Tables[0].Rows.Count > 0)
                    {
                        // Create Excel for downlaod
                        string filepath = string.Format("{0}uploads\\files\\AdvertiserActivity_{1}.xlsx", Server.MapPath("~/"), SessionData.Site.SiteId);
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
                        t.Text = "ID";
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "B1";
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = "Advertiser";
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "C1";
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = "Email";
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "D1";
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = "Acc. Created";
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "E1";
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = "Last Job Post";
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "F1";
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = "Account Status";
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "G1";
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = "Jobs Live";
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "H1";
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = "Total Posted";
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        newCell = new Cell();
                        newCell.DataType = CellValues.InlineString;
                        newCell.CellReference = "I1";
                        inlineString = new InlineString();
                        t = new Text();
                        t.Text = "Last Logged In";
                        inlineString.Append(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);

                        sheetData.AppendChild(row);


                        for (int i = 0; i < dsAdvertiserActivity.Tables[0].Rows.Count; i++)
                        {
                            UInt32Value excelindex = Convert.ToUInt32(i + 2);
                            DataRow activity = dsAdvertiserActivity.Tables[0].Rows[i];


                            row = new Row() { RowIndex = DocumentFormat.OpenXml.UInt32Value.ToUInt32(excelindex) };
                            newCell = new Cell();
                            newCell.DataType = CellValues.InlineString;
                            newCell.CellReference = "A" + excelindex.ToString();
                            inlineString = new InlineString();
                            t = new Text();
                            t.Text = activity["AdvertiserID"].ToString();
                            inlineString.Append(t);
                            newCell.AppendChild(inlineString);
                            row.AppendChild(newCell);

                            newCell = new Cell();
                            newCell.DataType = CellValues.InlineString;
                            newCell.CellReference = "B" + excelindex.ToString();
                            inlineString = new InlineString();
                            t = new Text();
                            t.Text = activity["CompanyName"].ToString();
                            inlineString.Append(t);
                            newCell.AppendChild(inlineString);
                            row.AppendChild(newCell);

                            newCell = new Cell();
                            newCell.DataType = CellValues.InlineString;
                            newCell.CellReference = "C" + excelindex.ToString();
                            inlineString = new InlineString();
                            t = new Text();
                            t.Text = activity["Email"].ToString();
                            inlineString.Append(t);
                            newCell.AppendChild(inlineString);
                            row.AppendChild(newCell);

                            newCell = new Cell();
                            newCell.DataType = CellValues.InlineString;
                            newCell.CellReference = "D" + excelindex.ToString();
                            inlineString = new InlineString();
                            t = new Text();
                            t.Text = (activity["RegisterDate"].ToString() == string.Empty) ? string.Empty : ((DateTime)activity["RegisterDate"]).ToString(SessionData.Site.DateFormat);
                            inlineString.Append(t);
                            newCell.AppendChild(inlineString);
                            row.AppendChild(newCell);

                            newCell = new Cell();
                            newCell.DataType = CellValues.InlineString;
                            newCell.CellReference = "E" + excelindex.ToString();
                            inlineString = new InlineString();
                            t = new Text();
                            t.Text = (activity["LastJobPost"].ToString() == string.Empty) ? string.Empty : ((DateTime)activity["LastJobPost"]).ToString("dd/MM/yy");
                            inlineString.Append(t);
                            newCell.AppendChild(inlineString);
                            row.AppendChild(newCell);

                            newCell = new Cell();
                            newCell.DataType = CellValues.InlineString;
                            newCell.CellReference = "F" + excelindex.ToString();
                            inlineString = new InlineString();
                            t = new Text();
                            t.Text = ((PortalEnums.AdvertiserUser.AccountStatus)Convert.ToInt32(activity["AdvertiserAccountStatusID"])).ToString();
                            inlineString.Append(t);
                            newCell.AppendChild(inlineString);
                            row.AppendChild(newCell);

                            newCell = new Cell();
                            newCell.DataType = CellValues.InlineString;
                            newCell.CellReference = "G" + excelindex.ToString();
                            inlineString = new InlineString();
                            t = new Text();
                            t.Text = activity["JobsLive"].ToString();
                            inlineString.Append(t);
                            newCell.AppendChild(inlineString);
                            row.AppendChild(newCell);

                            newCell = new Cell();
                            newCell.DataType = CellValues.InlineString;
                            newCell.CellReference = "H" + excelindex.ToString();
                            inlineString = new InlineString();
                            t = new Text();
                            t.Text = activity["TotalJobs"].ToString();
                            inlineString.Append(t);
                            newCell.AppendChild(inlineString);
                            row.AppendChild(newCell);

                            newCell = new Cell();
                            newCell.DataType = CellValues.InlineString;
                            newCell.CellReference = "I" + excelindex.ToString();
                            inlineString = new InlineString();
                            t = new Text();
                            t.Text = (activity["LastLoginDate"].ToString() == string.Empty) ? string.Empty : ((DateTime)activity["LastLoginDate"]).ToString(SessionData.Site.DateFormat);
                            inlineString.Append(t);
                            newCell.AppendChild(inlineString);
                            row.AppendChild(newCell);

                            sheetData.AppendChild(row);
                        }

                        workbookpart.Workbook.Save();

                        // Close the document.
                        spreadsheetDocument.Close();

                        Response.Clear();
                        Response.AddHeader("content-disposition", string.Format("attachment;filename=AdvertiserActivity_{0}.xlsx", SessionData.Site.SiteId));
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
            tbKeyword.Text = string.Empty;
            tbFrom.Text = string.Empty;
            tbTo.Text = string.Empty;
            ddlSortByColumn.SelectedIndex = 0;
            ddlOrder.SelectedIndex = 0;
            ddlShowRecords.SelectedIndex = 0;

            CurrentPage = 0;
            LoadAdvertiserActivity();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                CurrentPage = 0;
                LoadAdvertiserActivity();
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

            if (tbTo.Text != string.Empty)
            {
                if (!DateTime.TryParseExact(tbTo.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out dtTo))
                {
                    args.IsValid = false;
                    cvDate.ErrorMessage = "Invalid Date to format";
                    return;
                }
            }

            if (tbFrom.Text != string.Empty && tbTo.Text != string.Empty)
            {
                if (dtFrom.CompareTo(dtTo) == 1)
                {
                    args.IsValid = false;
                    cvDate.ErrorMessage = "Date To is earlier than Date From";
                    return;
                }
            }
        }
    }
}