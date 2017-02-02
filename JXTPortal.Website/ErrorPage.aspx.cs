using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using NotesFor.HtmlToOpenXml;
using System.IO;

using JXTPortal.Common;
using JXTPortal.Common.Models;

namespace JXTPortal.Website
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        private int exceptionid = -1;

        public IFileManager FileManger { get; set; }
        static string bucketName = "jxtco01-01-dev-images";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadFiles();
            }

            //string s = Common.Utils.UrlFriendlyName("ASSISTANT PROPERTY MANAGER - nicest team you'll ever work for!");
            //string filename = Server.MapPath("/uploads/sample.docx");
            //System.Net.WebClient client = new System.Net.WebClient();
            ////string html = client.DownloadString("http://scholarships.companydirectors.com.au.jxt1.com/job/application/doc/aicd_scholarship_doc.aspx?appid=59485");
            //string html = File.ReadAllText("C:\\Users\\daniel.ng\\Desktop\\dandan.html");

            //if (File.Exists(filename)) File.Delete(filename);

            //using (MemoryStream generatedDocument = new MemoryStream())
            //{
            //    using (WordprocessingDocument package = WordprocessingDocument.Create(generatedDocument, WordprocessingDocumentType.Document))
            //    {
            //        MainDocumentPart mainPart = package.MainDocumentPart;
            //        if (mainPart == null)
            //        {
            //            mainPart = package.AddMainDocumentPart();
            //            new Document(new Body()).Save(mainPart);
            //        }

            //        HtmlConverter converter = new HtmlConverter(mainPart);
            //        Body body = mainPart.Document.Body;

            //        var paragraphs = converter.Parse(html);
            //        for (int i = 0; i < paragraphs.Count; i++)
            //        {
            //            body.Append(paragraphs[i]);
            //        }

            //        mainPart.Document.Save();
            //    }

            //    // File.WriteAllBytes(filename, generatedDocument.ToArray());
            //    Response.ContentType = "application/zip";
            //    Response.AppendHeader("Content-Disposition", "attachment;filename=sample.docx");
            //    // Response.TransmitFile(Server.MapPath("/uploads/sample.docx"));
            //    Response.BinaryWrite(generatedDocument.ToArray());
            //    Response.End();
            //}
            //PaymentGateway.Paypal.PayflowPaymentGateway gateway = new PaymentGateway.Paypal.PayflowPaymentGateway();
            //gateway.DoPayment(false, "JXTPTY1", "JXTPTY1", "VSA", "Merchant001", "4446283280247004", 11, 18, "", new decimal(13.2));


            //if (!string.IsNullOrEmpty(Request.QueryString["ExceptionId"]))
            //{
            //    int.TryParse(Request.QueryString["ExceptionId"], out exceptionid);
            //}

            //ltlException.Text = "Exception ID: " + exceptionid.ToString();

            //CommonPage.SetBrowserPageTitle(Page, "Error Page");


        }

        private void LoadFiles()
        {
            string errorMessage = string.Empty;

            List<FileManagerFile> files = FileManger.ListFiles(bucketName, out errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ltlException.Text = HttpUtility.HtmlEncode(errorMessage);
                return;
            }

            rptFile.DataSource = files;
            rptFile.DataBind();

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string errorMessage = string.Empty;

            if (fuFile.HasFile && fuFile.FileContent.Length > 0)
            {
                FileManger.UploadFile(bucketName, "", fuFile.FileName, fuFile.FileContent, out errorMessage);
                LoadFiles();
            }
        }

        protected void rptFile_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            string errorMessage = string.Empty;

            if (e.CommandName == "Delete")
            {
                FileManger.DeleteFile(bucketName, "", e.CommandArgument.ToString(), out errorMessage);
                LoadFiles();
            }

            if (e.CommandName == "Download")
            {
                Stream response = FileManger.DownloadFile(bucketName, "", e.CommandArgument.ToString(), out errorMessage);
                using (MemoryStream memory = new MemoryStream())
                {
                    response.CopyTo(memory);
                    byte[] bytes = memory.ToArray();
                    Response.ContentType = "application/" + Path.GetExtension(e.CommandArgument.ToString()).Substring(1);
                    Response.OutputStream.Write(bytes, 0, bytes.Length);
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + e.CommandArgument);

                }

            }
        }

        protected void rptFile_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbDelete = e.Item.FindControl("lbDelete") as LinkButton;
                LinkButton lbDownload = e.Item.FindControl("lbDownload") as LinkButton;
                Literal ltFileName = e.Item.FindControl("ltFileName") as Literal;

                FileManagerFile file = e.Item.DataItem as FileManagerFile;
                lbDelete.CommandArgument = file.FileName;
                lbDownload.CommandArgument = file.FileName;
                ltFileName.Text = HttpUtility.HtmlEncode(file.FileName);
            }
        }
    }
}
