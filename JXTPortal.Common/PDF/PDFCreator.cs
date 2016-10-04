using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EvoPdf;

namespace JXTPortal.Common
{
    public class PDFCreator
    {
        //settings
        private string licenseKey = "pCo5Kzg4Kz84PCs/JTsrODolOjklMjIyMg=="; //B4mYiJubiJiInIaYiJuZhpmahpGRkZE=

        private PdfCompressionLevel pdfCompLevel = PdfCompressionLevel.Normal;
        private bool jpegCompression = true;

        public byte[] ConvertHTMLToPDF(string html)
        {
            //create a PDF document
            Document document = new Document();

            // set the license key
            document.LicenseKey = licenseKey;

            //optional settings for the PDF document like margins, compression level,
            //security options, viewer preferences, document information, etc
            document.CompressionLevel = pdfCompLevel;
            document.Margins = new Margins(10, 10, 0, 0);
            //document.Security.CanPrint = true;
            //document.Security.UserPassword = "";
            document.ViewerPreferences.HideToolbar = false;

            // set if the images are compressed in PDF with JPEG to reduce the PDF document size
            document.JpegCompressionEnabled = jpegCompression;

            //Add a first page to the document. The next pages will inherit the settings from this page 
            PdfPage page = document.Pages.AddNewPage(PdfPageSize.A4, new Margins(0, 0, 30, 30), PdfPageOrientation.Portrait);

            // the code below can be used to create a page with default settings A4, document margins inherited, portrait orientation
            //PdfPage page = document.Pages.AddNewPage();

            // add a font to the document that can be used for the texts elements 
            PdfFont font = document.Fonts.Add(new System.Drawing.Font(new System.Drawing.FontFamily("Times New Roman"), 10,
                        System.Drawing.GraphicsUnit.Point));

            // add header and footer before renderng the content
            //if (cbAddHeader.Checked)
            //    AddHtmlHeader(document);
            //if (cbAddFooter.Checked)
            //    AddHtmlFooter(document, font);

            // the result of adding an element to a PDF page
            AddElementResult addResult;

            // Get the specified location and size of the rendered content
            // A negative value for width and height means to auto determine
            // The auto determined width is the available width in the PDF page
            // and the auto determined height is the height necessary to render all the content
            float xLocation = 0; //0 = auto determine
            float yLocation = 0; //0 = auto determine
            float width = 0; //0 = auto determine
            float height = 0; //0 = auto determine

            //convert to PDF with searchable text
            // convert HTML to PDF
            HtmlToPdfElement htmlToPdfElement;

            // convert a HTML string to PDF
            string htmlStringToConvert = html;

            htmlToPdfElement = new HtmlToPdfElement(xLocation, yLocation, width, height, htmlStringToConvert, null);

            //optional settings for the HTML to PDF converter
            htmlToPdfElement.FitWidth = true;
            htmlToPdfElement.EmbedFonts = true;
            htmlToPdfElement.LiveUrlsEnabled = true;
            htmlToPdfElement.JavaScriptEnabled = true;
            htmlToPdfElement.PdfBookmarkOptions.HtmlElementSelectors = null;

            // add theHTML to PDF converter element to page
            addResult = page.AddElement(htmlToPdfElement);

            byte[] pdfBytes;
            try
            {
                // get the PDF document bytes
                pdfBytes = document.Save();    
            }
            finally
            {
                // close the PDF document to release the resources
                document.Close();
            }
            return pdfBytes;
        }

        public byte[] ConvertURLToPDF(string urlToConvert)
        {
            // Create the PDF converter. Optionally the HTML viewer width can be specified as parameter
            // The default HTML viewer width is 1024 pixels.
            PdfConverter pdfConverter = new PdfConverter();

            // set the license key - required
            pdfConverter.LicenseKey = licenseKey;

            // set the converter options - optional
            pdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.A4;
            pdfConverter.PdfDocumentOptions.PdfCompressionLevel = PdfCompressionLevel.Normal;
            pdfConverter.PdfDocumentOptions.PdfPageOrientation = PdfPageOrientation.Portrait;

            //pdfConverter.PdfDocumentOptions.AvoidTextBreak = false;

            // set if header and footer are shown in the PDF - optional - default is false 
            pdfConverter.PdfDocumentOptions.ShowHeader = false; // cbAddHeader.Checked;
            pdfConverter.PdfDocumentOptions.ShowFooter = false; // cbAddFooter.Checked;
            // set if the HTML content is resized if necessary to fit the PDF page width - default is true
            pdfConverter.PdfDocumentOptions.FitWidth = true; // cbFitWidth.Checked;

            // set the embedded fonts option - optional - default is false
            pdfConverter.PdfDocumentOptions.EmbedFonts = true; // cbEmbedFonts.Checked;
            // set the live HTTP links option - optional - default is true
            pdfConverter.PdfDocumentOptions.LiveUrlsEnabled = true; //cbLiveLinks.Checked;

            // set if the JavaScript is enabled during conversion to a PDF - default is true
            pdfConverter.JavaScriptEnabled = true; //cbClientScripts.Checked;

            // set if the images in PDF are compressed with JPEG to reduce the PDF document size - default is true
            pdfConverter.PdfDocumentOptions.JpegCompressionEnabled = true; //cbJpegCompression.Checked;

            // enable auto-generated bookmarks for a specified list of HTML selectors (e.g. H1 and H2)
            //if (cbBookmarks.Checked)
            {
                pdfConverter.PdfBookmarkOptions.HtmlElementSelectors = new string[] { "H1", "H2" };
            }

            // add HTML header
            /*if (cbAddHeader.Checked)
                AddHeader(pdfConverter);
            // add HTML footer
            if (cbAddFooter.Checked)
                AddFooter(pdfConverter);*/

            // Performs the conversion and get the pdf document bytes that can 
            // be saved to a file or sent as a browser response
            byte[] pdfBytes = pdfConverter.GetPdfBytesFromUrl(urlToConvert);

            return pdfBytes;
            /*
            // send the generated PDF document to client browser

            // get the object representing the HTTP response to browser
            HttpResponse httpResponse = HttpContext.Current.Response;

            // add the Content-Type and Content-Disposition HTTP headers
            httpResponse.AddHeader("Content-Type", "application/pdf");
            if (radioAttachment.Checked)
                httpResponse.AddHeader("Content-Disposition", String.Format("attachment; filename=GettingStarted.pdf; size={0}",
                            pdfBytes.Length.ToString()));
            else
                httpResponse.AddHeader("Content-Disposition", String.Format("inline; filename=GettingStarted.pdf; size={0}",
                            pdfBytes.Length.ToString()));

            // write the PDF document bytes as attachment to HTTP response 
            httpResponse.BinaryWrite(pdfBytes);

            // Note: it is important to end the response, otherwise the ASP.NET
            // web page will render its content to PDF document stream
            httpResponse.End();*/
        }

        //private void AddHtmlHeader(Document document)
        //{
        //    string thisPageURL = HttpContext.Current.Request.Url.AbsoluteUri;
        //    string headerAndFooterHtmlUrl = thisPageURL.Substring(0, thisPageURL.LastIndexOf('/')) +
        //                "/HeaderFooter/HeaderAndFooterHtml.htm";

        //    //create a template to be added in the header and footer
        //    document.Header = document.AddTemplate(document.Pages[0].ClientRectangle.Width, 60);
        //    // create a HTML to PDF converter element to be added to the header template
        //    HtmlToPdfElement headerHtmlToPdf = new HtmlToPdfElement(0, 0, document.Header.ClientRectangle.Width,
        //            document.Header.ClientRectangle.Height, headerAndFooterHtmlUrl);
        //    headerHtmlToPdf.FitHeight = true;
        //    document.Header.AddElement(headerHtmlToPdf);
        //}

        //private void AddHtmlFooter(Document document, PdfFont footerPageNumberFont)
        //{
        //    string thisPageURL = HttpContext.Current.Request.Url.AbsoluteUri;
        //    string headerAndFooterHtmlUrl = thisPageURL.Substring(0, thisPageURL.LastIndexOf('/')) +
        //                "/HeaderFooter/HeaderAndFooterHtml.htm";

        //    //create a template to be added in the header and footer
        //    document.Footer = document.AddTemplate(document.Pages[0].ClientRectangle.Width, 60);
        //    // create a HTML to PDF converter element to be added to the header template
        //    HtmlToPdfElement footerHtmlToPdf = new HtmlToPdfElement(0, 0, document.Footer.ClientRectangle.Width,
        //            document.Footer.ClientRectangle.Height, headerAndFooterHtmlUrl);
        //    footerHtmlToPdf.FitHeight = true;
        //    document.Footer.AddElement(footerHtmlToPdf);

        //    // add page number to the footer
        //    TextElement pageNumberText = new TextElement(document.Footer.ClientRectangle.Width - 100, 30,
        //                        "This is page &p; of &P; pages", footerPageNumberFont);
        //    document.Footer.AddElement(pageNumberText);
        //}

    }
}