using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using JXTPortal;
using JXTPortal.Common;
using JXTPortal.Entities;
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

            cbTo.DataSource = service.Get_List().OrderBy(s => s.SiteName).ToList();

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
                        string firstname = lvi.SubItems[0].Text;
                        string lastname = lvi.SubItems[1].Text;
                        string email = lvi.SubItems[2].Text;
                        string phone = lvi.SubItems[3].Text;
                        string state = lvi.SubItems[4].Text;

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
                                    member = new JXTPortal.Entities.Members();
                                    member.SiteId = Convert.ToInt32(cbTo.SelectedValue);
                                    member.Username = email;
                                    member.FirstName = firstname;
                                    member.Surname = lastname;
                                    member.EmailAddress = email;
                                    member.HomePhone = phone;
                                    member.EmailFormat = (int)EmailSender.Format.Html;
                                    member.CountryId = 1;
                                    member.States = state;
                                    member.Valid = false;
                                    member.Validated = false;
                                    member.ValidateGuid = Guid.NewGuid();
                                    member.RegisteredDate = DateTime.Now;

                                    memberservice.Insert(member);
                                    member.MemberUrlExtension = member.MemberId.ToString();
                                    memberservice.Update(member);

                                    SendEmail(member);

                                    this.Invoke(new ErrorThrowingDelegate(ErrorThrowing), "Complete", string.Format("Member with email {0} has been notified", email));
                                }
                                else
                                {
                                    this.Invoke(new ErrorThrowingDelegate(ErrorThrowing), "Error", string.Format("Member with email {0} already exist", email));
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

            DataTable dt = null;
            lbStatus.Text = string.Empty;
            listView1.Items.Clear();

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

                        if (ds.Tables[0].Columns.Count != 5)
                        {
                            lbStatus.Text = "Error: Invalid Excel file";
                            return;
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


                        for (int i = 0; i < sheetData.Elements<Row>().Count(); i++)
                        {
                            r = sheetData.Elements<Row>().ToArray()[i];

                            if (i == 0)
                            {
                                if (r.Elements<Cell>().Count() != 5)
                                {
                                    lbStatus.Text = "Error: Invalid Excel file";
                                    return;
                                }

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
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = dr[0].ToString();
                    lvi.SubItems.Add(dr[1].ToString());
                    lvi.SubItems.Add(dr[2].ToString());
                    lvi.SubItems.Add(dr[3].ToString());
                    lvi.SubItems.Add(dr[4].ToString());

                    lvi.Tag = dr;

                    listView1.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                lbStatus.Text = "Error: " + ex.Message;
            }

            if (listView1.Items.Count > 0 && tbFromEmail.Text.Length > 0 && tbSubject.Text.Length > 0 && Utils.VerifyEmail(tbFromEmail.Text))
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

        private void tbSubject_TextChanged(object sender, EventArgs e)
        {
            btnStart.Enabled = false;

            if (listView1.Items.Count > 0 && tbFromEmail.Text.Length > 0 && tbSubject.Text.Length > 0 && Utils.VerifyEmail(tbFromEmail.Text))
            {
                btnStart.Enabled = true;
            }
        }
    }
}
