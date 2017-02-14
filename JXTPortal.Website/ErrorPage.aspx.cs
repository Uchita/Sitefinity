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

namespace JXTPortal.Website
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        private int exceptionid = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
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


            if (!string.IsNullOrEmpty(Request.QueryString["ExceptionId"]))
            {
                int.TryParse(Request.QueryString["ExceptionId"], out exceptionid);
            }

            ltlException.Text = "Exception ID: " + exceptionid.ToString();

            //CommonPage.SetBrowserPageTitle(Page, "Error Page");


        }
    }
}
