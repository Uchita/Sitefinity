using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Data.OleDb;
using System.Net.Mail;
using System.Threading;

using JXTPortal;
using JXTPortal.Common;
using JXTPortal.Data;
using JXTPortal.Entities;


using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

using System.Security.Cryptography;
using System.Collections.Specialized;

using EmailSender = JXTPortal.EmailSender;

namespace JXTMemberTransfer
{
    public partial class Form1 : Form
    {
        public delegate void ThrowExceptionDelegate(Exception ex);
        public delegate void ErrorThrowingDelegate(string type, string text);
        public delegate void LoadExcelMemberDelegate(int SiteID);
        public delegate void LoadSiteMemberCompletedDelegate(ArrayList WhiteLabelMemberList);

        public delegate void UpdateProgressDelegate(int index, int max);
        public delegate void MemberImportCompletedDelegate();
        public delegate void MemberImportBeginsDelegate();
        private string TemplateText = string.Empty;

        private SitesService _sitesService;

        private SitesService SitesService
        {
            get
            {
                if (_sitesService == null)
                    _sitesService = new SitesService();
                return _sitesService;
            }
        }

        public Form1()
        {
            InitializeComponent();

            try
            {
                TextReader reader = File.OpenText(ConfigurationManager.AppSettings["EmailTemplatePath"]);
                TemplateText = reader.ReadToEnd();
                reader.Close();
                if (MessageBox.Show(string.Format("Email From Name: {1}\nThis is the email template going to be used:\n\n{0}\nDo you wish to continue the process?", TemplateText, ConfigurationManager.AppSettings["FromEmailName"]), "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}\r\n{1}", "Failed to load Email Template.", ex.StackTrace), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadDropDowns();
        }

        private void LoadDropDowns()
        {
            SitesService service = new SitesService();
            cbTo.ValueMember = "SiteID";
            cbTo.DisplayMember = "SiteName";

            cbTo.DataSource = service.GetAll().OrderBy(s => s.SiteName).ToList();


        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                this.Invoke(new MemberImportBeginsDelegate(StatusText));
                LoadExcelMemberDelegate lsmd = LoadExcelMember;
                lsmd.BeginInvoke(Convert.ToInt32(cbTo.SelectedValue), null, null);
            }
            catch (Exception ex)
            {
                lbStatus.Text = ex.Message;
                cbTo.Enabled = true;
                btnStart.Enabled = true;
            }
        }

        private void StatusText()
        {
            if (lbStatus.InvokeRequired)
            {
                MemberImportBeginsDelegate d = new MemberImportBeginsDelegate(StatusText);
                this.Invoke(d);
            }
            else
            {
                pbTransfer.Value = 0;
                tbError.Text = string.Empty;
                tbComplete.Text = string.Empty;
                cbTo.Enabled = false;
                btnStart.Enabled = false;
                lbStatus.Text = "Importing Members...";
            }
        }

        delegate void LoadExcelMemberCallback(int SiteId);

        private int GetColumnIndex(string columnName)
        {
            int index = -1;

            for (int i = 0; i < dgvColumnBound.Rows.Count; i++)
            {
                DataGridViewRow row = dgvColumnBound.Rows[i];

                if (row.Cells[1].Value.ToString() == columnName)
                {
                    return i;
                }
            }

            return index;
        }

        private JXTPortal.Entities.Members AssignMemberValue(ListViewItem lvi)
        {
            JXTPortal.Entities.Members member = new JXTPortal.Entities.Members();

            member.SiteId = Convert.ToInt32(cbTo.SelectedValue);
            member.EmailFormat = (int)EmailSender.Format.Html;
            member.CountryId = 1;
            member.Valid = false;
            member.Validated = false;
            member.ValidateGuid = Guid.NewGuid();
            member.RegisteredDate = DateTime.Now;
            member.RequiredPasswordChange = true;

            for (int i = 0; i < dgvColumnBound.Rows.Count; i++)
            {
                DataGridViewRow row = dgvColumnBound.Rows[i];
                string columnText = row.Cells[1].Value.ToString();
                string data = string.Empty;

                if (columnText != "(none)")
                {
                    data = (i == 0) ? lvi.Text : lvi.SubItems[i].Text;

                    if (columnText == "Username") { member.Username = data; }
                    if (columnText == "Password") { member.Password = Utils.GetMD5Password(data); }
                    if (columnText == "Title") { member.Title = data; }
                    if (columnText == "FirstName") { member.FirstName = data; }
                    if (columnText == "Surname") { member.Surname = data; }
                    if (columnText == "EmailAddress")
                    {
                        member.EmailAddress = data;
                        if (string.IsNullOrEmpty(member.Username)) { member.Username = member.EmailAddress; }
                    }
                    if (columnText == "Company") { member.Company = data; }
                    if (columnText == "Position") { member.Position = data; }
                    if (columnText == "HomePhone") { member.HomePhone = data; }
                    if (columnText == "WorkPhone") { member.WorkPhone = data; }
                    if (columnText == "MobilePhone") { member.MobilePhone = data; }
                    if (columnText == "Fax") { member.Fax = data; }
                    if (columnText == "Address1") { member.Address1 = data; }
                    if (columnText == "Address2") { member.Address2 = data; }
                    if (columnText == "LocationId") { member.LocationId = data; }
                    if (columnText == "AreaId") { member.AreaId = data; }
                    if (columnText == "CountryId") { member.CountryId = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToInt32(data) : 1; }
                    if (columnText == "PreferredCategoryId") { member.PreferredCategoryId = data; }
                    if (columnText == "PreferredSubCategoryId") { member.PreferredSubCategoryId = data; }
                    if (columnText == "PreferredSalaryId") { member.PreferredSalaryId = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToInt32(data) : (int?)null; }
                    if (columnText == "Subscribed") { member.Subscribed = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToBoolean(data) : false; }
                    if (columnText == "MonthlyUpdate") { member.MonthlyUpdate = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToBoolean(data) : false; }
                    if (columnText == "ReferringMemberId") { member.ReferringMemberId = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToInt32(data) : (int?)null; }
                    if (columnText == "LastModifiedDate") { member.LastModifiedDate = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToDateTime(data) : (DateTime?)null; }
                    if (columnText == "Valid") { member.Valid = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToBoolean(data) : false; }
                    if (columnText == "EmailFormat") { member.EmailFormat = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToInt32(data) : (int)EmailSender.Format.Html; }
                    if (columnText == "LastLogon") { member.LastLogon = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToDateTime(data) : (DateTime?)null; }
                    if (columnText == "DateOfBirth") { member.DateOfBirth = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToDateTime(data) : (DateTime?)null; }
                    if (columnText == "Gender") { member.Gender = data; }
                    if (columnText == "Tags") { member.Tags = data; }
                    if (columnText == "Validated") { member.Validated = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToBoolean(data) : false; }
                    if (columnText == "WebsiteUrl") { member.WebsiteUrl = data; }
                    if (columnText == "AvailabilityId") { member.AvailabilityId = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToInt32(data) : (int?)null; }
                    if (columnText == "AvailabilityFromDate") { member.AvailabilityFromDate = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToDateTime(data) : (DateTime?)null; }
                    if (columnText == "MySpaceHeading") { member.MySpaceHeading = data; }
                    if (columnText == "MySpaceContent") { member.MySpaceContent = data; }
                    if (columnText == "UrlReferrer") { member.UrlReferrer = data; }
                    if (columnText == "PreferredJobTitle") { member.PreferredJobTitle = data; }
                    if (columnText == "PreferredAvailability") { member.PreferredAvailability = data; }
                    if (columnText == "PreferredAvailabilityType") { member.PreferredAvailabilityType = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToInt32(data) : (int?)null; }
                    if (columnText == "PreferredSalaryFrom") { member.PreferredSalaryFrom = data; }
                    if (columnText == "PreferredSalaryTo") { member.PreferredSalaryTo = data; }
                    if (columnText == "CurrentSalaryFrom") { member.CurrentSalaryFrom = data; }
                    if (columnText == "CurrentSalaryTo") { member.CurrentSalaryTo = data; }
                    if (columnText == "LookingFor") { member.LookingFor = data; }
                    if (columnText == "Experience") { member.Experience = data; }
                    if (columnText == "Skills") { member.Skills = data; }
                    if (columnText == "Comments") { member.Comments = data; }
                    if (columnText == "ProfileType") { member.ProfileType = data; }
                    if (columnText == "EducationId") { member.EducationId = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToInt32(data) : (int?)null; }
                    if (columnText == "RegisteredDate") { member.RegisteredDate = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToDateTime(data) : DateTime.Now; }
                    if (columnText == "States") { member.States = data; }
                    if (columnText == "Suburb") { member.Suburb = data; }
                    if (columnText == "PostCode") { member.PostCode = data; }
                    if (columnText == "ProfilePicture") { member.ProfilePicture = data; }
                    if (columnText == "ShortBio") { member.ShortBio = data; }
                    if (columnText == "WorkTypeId") { member.WorkTypeId = data; }
                    if (columnText == "Memberships") { member.Memberships = data; }
                    if (columnText == "MemberStatusId") { member.MemberStatusId = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToInt32(data) : (int?)null; }
                    if (columnText == "LinkedInAccessToken") { member.LinkedInAccessToken = data; }
                    if (columnText == "ExternalMemberId") { member.ExternalMemberId = data; }
                    if (columnText == "PassportNo") { member.PassportNo = data; }
                    if (columnText == "MailingAddress1") { member.MailingAddress1 = data; }
                    if (columnText == "MailingAddress2") { member.MailingAddress2 = data; }
                    if (columnText == "MailingStates") { member.MailingStates = data; }
                    if (columnText == "MailingSuburb") { member.MailingSuburb = data; }
                    if (columnText == "MailingPostCode") { member.MailingPostCode = data; }
                    if (columnText == "MailingCountryId") { member.MailingCountryId = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToInt32(data) : (int?)null; }
                    if (columnText == "CountryName") { member.CountryName = data; }
                    if (columnText == "MailingCountryName") { member.MailingCountryName = data; }
                    if (columnText == "LoginAttempts") { member.LoginAttempts = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToInt32(data) : 0; }
                    if (columnText == "LastAttemptDate") { member.LastAttemptDate = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToDateTime(data) : (DateTime?)null; }
                    if (columnText == "Status") { member.Status = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToInt32(data) : (int?)null; }
                    if (columnText == "LastTermsAndConditionsDate") { member.LastTermsAndConditionsDate = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToDateTime(data) : (DateTime?)null; }
                    if (columnText == "DefaultLanguageId") { member.DefaultLanguageId = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToInt32(data) : (int?)null; }
                    if (columnText == "ReferringSiteId") { member.ReferringSiteId = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToInt32(data) : (int?)null; }
                    if (columnText == "MultiLingualFirstName") { member.MultiLingualFirstName = data; }
                    if (columnText == "MultiLingualSurame") { member.MultiLingualSurame = data; }
                    if (columnText == "SecondaryEmail") { member.SecondaryEmail = data; }
                    if (columnText == "CandidateData") { member.CandidateData = data; }
                    if (columnText == "EligibleToWorkIn") { member.EligibleToWorkIn = data; }
                    if (columnText == "ReferenceUponRequest") { member.ReferenceUponRequest = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToBoolean(data) : (bool?)null; ; }
                    if (columnText == "PreferredLine") { member.PreferredLine = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToInt32(data) : 1; }
                    if (columnText == "VideoUrl") { member.VideoUrl = data; }
                    if (columnText == "ProfileDataXml") { member.ProfileDataXml = data; }
                    if (columnText == "LastProfileSubmittedDate") { member.LastProfileSubmittedDate = (!string.IsNullOrWhiteSpace(data)) ? Convert.ToDateTime(data) : (DateTime?)null; }
                }
            }

            return member;
        }

        private void LoadExcelMember(int SiteId)
        {

            if (this.InvokeRequired)
            {
                LoadExcelMemberCallback d = new LoadExcelMemberCallback(LoadExcelMember);
                this.Invoke(d, new object[] { SiteId });
            }
            else
            {
                MembersService memberservice = new MembersService();
                TList<JXTPortal.Entities.Members> memberdt = memberservice.GetBySiteId(SiteId);

                TList<JXTPortal.Entities.Members> sitemembers = new TList<JXTPortal.Entities.Members>();
                JXTPortal.Entities.Members member = null;


                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    try
                    {
                        ListViewItem lvi = listView1.Items[i];

                        int emailIndex = GetColumnIndex("EmailAddress");
                        string email = (emailIndex >= 0) ? lvi.SubItems[emailIndex].Text : string.Empty;

                        bool exists = false;


                        foreach (JXTPortal.Entities.Members sitemember in memberdt)
                        {
                            if (sitemember.EmailAddress == email)
                            {
                                exists = true;
                                if (sitemember.Valid == false || sitemember.Validated == false)
                                {
                                    sitemember.ValidateGuid = Guid.NewGuid();
                                    memberservice.Update(sitemember);

                                    SendEmail(sitemember);
                                    this.Invoke(new ErrorThrowingDelegate(ErrorThrowing), "Complete", string.Format("Member with email {0} has been notified", email));
                                }
                                else
                                {
                                    this.Invoke(new ErrorThrowingDelegate(ErrorThrowing), "Complete", string.Format("Member with email {0} is already valid", email));
                                }

                                break;
                            }
                        }

                        if (!exists)
                        {
                            if (!Utils.VerifyEmail(email))
                            {
                                this.Invoke(new ErrorThrowingDelegate(ErrorThrowing), "Error", string.Format("{0} is not a valid email", email));
                            }
                            else
                            {
                                member = memberservice.GetBySiteIdEmailAddressOrUserName(Convert.ToInt32(cbTo.SelectedValue), email);
                                if (member == null)
                                {
                                    try
                                    {
                                        member = AssignMemberValue(lvi);

                                        memberservice.Insert(member);
                                        member.MemberUrlExtension = member.MemberId.ToString();
                                        memberservice.Update(member);

                                        SendEmail(member);

                                        this.Invoke(new ErrorThrowingDelegate(ErrorThrowing), "Complete", string.Format("Member with email {0} has been notified", email));
                                    }
                                    catch (Exception ex)
                                    {
                                        this.Invoke(new ErrorThrowingDelegate(ErrorThrowing), "Error", string.Format("Row {0}: {1}", i + 1, ex.Message));
                                    }
                                }
                                else
                                {
                                    this.Invoke(new ErrorThrowingDelegate(ErrorThrowing), "Error", string.Format("Row {0}: Member with email {1} already exist", i + 1, email));
                                }
                            }
                        }

                        this.Invoke(new UpdateProgressDelegate(UpdateProgress), i + 1, listView1.Items.Count);
                    }
                    catch (Exception ex)
                    {
                        this.Invoke(new ThrowExceptionDelegate(HandleExpcetion), ex);
                    }
                }

            }

            this.Invoke(new MemberImportCompletedDelegate(MemberImportCompleted));
        }

        private void UpdateProgress(int index, int max)
        {
            pbTransfer.Maximum = max;
            pbTransfer.Value = index;
        }

        private void HandleExpcetion(Exception ex)
        {
            lbStatus.Text = "Error";
            tbError.Text += string.Format("{0}\n{1}", ex.Message, ex.StackTrace) + "\n";
            tbError.SelectionStart = tbError.Text.Length;
            tbError.ScrollToCaret();
            cbTo.Enabled = true;
            btnStart.Enabled = true;
        }

        private void ErrorThrowing(string type, string text)
        {
            if (type == "Error")
            {
                tbError.Text += text + "\r\n";
                tbError.SelectionStart = tbError.Text.Length;
                tbError.ScrollToCaret();
            }

            if (type == "Complete")
            {
                tbComplete.Text += text + "\r\n";
                tbComplete.SelectionStart = tbComplete.Text.Length;
                tbComplete.ScrollToCaret();
            }
        }

        private void MemberImportCompleted()
        {
            lbStatus.Text = "Done";
            cbTo.Enabled = true;
            btnStart.Enabled = true;
        }


        private void PreviewExcel()
        {
            string fileLocation = openFileDialog1.FileName;
            string fileExtension = Path.GetExtension(fileLocation);
            string sheetName = "Sheet1";

            string value = string.Empty;
            DataSet ds = new DataSet();
            Row r = null;
            int columnCount = 0;

            DataTable dt = null;
            lbStatus.Text = string.Empty;
            listView1.Items.Clear();
            listView1.Columns.Clear();

            dgvColumnBound.Rows.Clear();

            try
            {
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

                        columnCount = ds.Tables[0].Columns.Count;
                        for (int i = 0; i < columnCount; i++)
                        {
                            listView1.Columns.Add(new ColumnHeader
                            {
                                Text = "Column " + (i + 1).ToString(),
                                Name = "Column" + (i + 1).ToString(),
                                TextAlign = HorizontalAlignment.Left,
                                Width = 80
                            });

                            dgvColumnBound.Rows.Add("Column " + (i + 1).ToString(), "(none)");
                        }
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

                        Row row = sheetData.Elements<Row>().FirstOrDefault();
                        if (row != null)
                        {
                            columnCount = row.Elements<Cell>().Count();
                            for (int i = 0; i < columnCount; i++)
                            {
                                listView1.Columns.Add(new ColumnHeader
                                {
                                    Text = "Column " + (i + 1).ToString(),
                                    Name = "Column" + (i + 1).ToString(),
                                    TextAlign = HorizontalAlignment.Left,
                                    Width = 80
                                });

                                dgvColumnBound.Rows.Add("Column " + (i + 1).ToString(), "(none)");
                            }

                        }

                        for (int i = 0; i < sheetData.Elements<Row>().Count(); i++)
                        {
                            r = sheetData.Elements<Row>().ToArray()[i];

                            if (i == 0)
                            {

                                foreach (Cell c in r.Elements<Cell>())
                                {
                                    value = string.Empty;

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
                                    value = string.Empty;

                                    if (c.DataType == null || c.DataType == CellValues.String)
                                    {
                                        try
                                        {
                                            value = c.CellValue.InnerText;
                                        }
                                        catch (Exception ex)
                                        {
                                            lbStatus.Text = "Error: " + ex.Message;
                                        }
                                    }
                                    else if (c.DataType == CellValues.SharedString)
                                    {
                                        if (c.InnerText != null)
                                        {
                                            value = sharedStringTable.ElementAt(int.Parse(c.InnerText)).InnerText;
                                        }
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
                    if (columnCount > 0)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = dr[0].ToString();
                        for (int i = 1; i < columnCount; i++)
                        {
                            lvi.SubItems.Add(dr[i].ToString());
                        }
                        lvi.Tag = dr;

                        listView1.Items.Add(lvi);
                    }
                }
            }
            catch (Exception ex)
            {
                lbStatus.Text = "Error: " + ex.Message;
            }

            if (listView1.Items.Count > 0 && tbSubject.Text.Length > 0 && (Utils.VerifyEmail(tbFromEmail.Text) || cbSendEmail.Checked == false))
            {
                btnStart.Enabled = true;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            lbFilePath.Text = openFileDialog1.FileName;
            btnStart.Enabled = false;
            PreviewExcel();
        }

        public static string EncryptMD5(string input)
        {
            string strEncrypted = string.Empty;

            using (MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider())
            {
                UTF8Encoding encoder = new UTF8Encoding();
                Byte[] hashedDataBytes = md5Hasher.ComputeHash(encoder.GetBytes(ConfigurationManager.AppSettings["SaltKey"] + input));
                strEncrypted = Convert.ToBase64String(hashedDataBytes);
            }

            return strEncrypted;
        }

        private void SendEmail(JXTPortal.Entities.Members member)
        {
            if (cbSendEmail.Checked)
            {
                string fromemail = tbFromEmail.Text;

                JXTPortal.Entities.Sites site = SitesService.GetBySiteId(Convert.ToInt32(cbTo.SelectedValue));

                EmailSender.Message message = new EmailSender.Message();
                HybridDictionary colemailfields = new HybridDictionary();

                message.From = new MailAddress(fromemail, ConfigurationManager.AppSettings["FromEmailName"]);
                message.To = new MailAddress(member.EmailAddress);
                colemailfields["USERNAME"] = member.Username;
                colemailfields["FIRSTNAME"] = member.FirstName;
                colemailfields["LASTNAME"] = member.Surname;
                colemailfields["LINK"] = string.Format("http://www.{0}/member/ConfirmResetPassword.aspx?memberid={1}&key={2}", site.SiteUrl, member.MemberId, member.ValidateGuid.ToString().ToLower());
                colemailfields["SITENAME"] = site.SiteName;
                message.Format = EmailSender.Format.Html;
                message.Body = TemplateText;
                message.Fields = colemailfields;
                message.Subject = tbSubject.Text.Replace("{FIRSTNAME}", member.FirstName).Replace("{LASTNAME}", member.Surname);

                MailService.EmailSender().Send(message);
            }
        }

        private void tbSubject_TextChanged(object sender, EventArgs e)
        {
            btnStart.Enabled = false;

            if (listView1.Items.Count > 0  && tbSubject.Text.Length > 0 && (Utils.VerifyEmail(tbFromEmail.Text) || cbSendEmail.Checked == false))
            {
                btnStart.Enabled = true;
            }
        }
    }
}
