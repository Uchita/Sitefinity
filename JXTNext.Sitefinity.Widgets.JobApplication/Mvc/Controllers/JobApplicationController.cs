using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using Telerik.Sitefinity.Libraries.Model;
using Telerik.Sitefinity.Modules.Libraries;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Workflow;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Controllers
{
    [EnhanceViewEngines]
    [ControllerToolboxItem(Name = "JobApplication_MVC", Title = "Job Application", SectionName = "JXTNext.JobApplication", CssClass = JobApplicationController.WidgetIconCssClass)]
    public class JobApplicationController : Controller
    {
        /// <summary>
        /// Gets or sets the name of the template that widget will be displayed.
        /// </summary>
        /// <value></value>
        public string TemplateName
        {
            get
            {
                return this.templateName;
            }

            set
            {
                this.templateName = value;
            }
        }

        // GET: JobApplication
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.ShowFilesUploadMessage = null;
            return View("Simple");
        }

        [HttpPost]
        public ActionResult ApplyJob()
        {
            Dictionary<string, byte[]> fileStreamKeyValue = new Dictionary<string, byte[]>();
            foreach (string key in Request.Files)
            {
                HttpPostedFileBase fileContent = Request.Files[key];

                if (fileContent != null && fileContent.ContentLength > 0)
                {
                    string fullFileName = fileContent.FileName;
                    var fileExtIndex = fileContent.FileName.LastIndexOf(".");
                    var fileName = fileContent.FileName.Substring(0, fileExtIndex);
                    var fileExtension = fileContent.FileName.Substring(fileExtIndex);
                    var libName = "applications-resume";
                    if (key.ToLower() == "coverletter")
                        libName = "applications-coverletters";

                    UploadToAmazonS3(Guid.NewGuid(), "private-amazon-s3-provider", libName, fileName, fileContent.InputStream, fileExtension);
                    ViewBag.ShowFilesUploadMessage = "File(s) Uploaded successfully";
                }
            }
            var fullTemplateName = this.templateNamePrefix + this.TemplateName;
            return View(fullTemplateName);
        }

        private void FetchFromAmazonS3(string providerName, string libraryName, string itemTitle)
        {
            LibrariesManager librariesManager = LibrariesManager.GetManager(providerName);
            var docLibs = librariesManager.GetDocumentLibraries();

            foreach (var lib in docLibs)
            {
                if (lib.Title.ToLower() == libraryName)
                {
                    var document = lib.Items().Where(item => item.Title == itemTitle).FirstOrDefault();
                    var stream = librariesManager.Download(document);
                }
            }
        }

     
        private void UploadToAmazonS3(Guid masterDocumentId, string providerName, string parentAlbumTitle, string documentTitle, Stream documentStream, string documentExtension)
        {
            LibrariesManager librariesManager = LibrariesManager.GetManager(providerName);
            Document document = librariesManager.GetDocuments().Where(i => i.Id == masterDocumentId).FirstOrDefault();

            if (document == null)
            {
                //The document is created as master. The masterDocumentId is assigned to the master version.
                document = librariesManager.CreateDocument(masterDocumentId);

                //Set the parent document library.
                DocumentLibrary documentLibrary = librariesManager.GetDocumentLibraries().Where(d => d.Title == parentAlbumTitle).SingleOrDefault();
                document.Parent = documentLibrary;

                //Set the properties of the document.
                document.Title = documentTitle;
                document.DateCreated = DateTime.UtcNow;
                document.PublicationDate = DateTime.UtcNow;
                document.LastModified = DateTime.UtcNow;
                document.UrlName = Regex.Replace(documentTitle.ToLower(), @"[^\w\-\!\$\'\(\)\=\@\d_]+", "-");
                document.MediaFileUrlName = Regex.Replace(documentTitle.ToLower(), @"[^\w\-\!\$\'\(\)\=\@\d_]+", "-");
                document.ApprovalWorkflowState = "Published";

                //Upload the document file.
                librariesManager.Upload(document, documentStream, documentExtension);

                //Recompiles and validates the url of the document.
                librariesManager.RecompileAndValidateUrls(document);

                //Save the changes.
                librariesManager.SaveChanges();

                //Publish the DocumentLibraries item. The live version acquires new ID.
                var bag = new Dictionary<string, string>();
                bag.Add("ContentType", typeof(Document).FullName);
                WorkflowManager.MessageWorkflow(masterDocumentId, typeof(Document), null, "Publish", false, bag);
            }
        }

        internal const string WidgetIconCssClass = "sfMvcIcn";
        private string templateName = "Simple";
        private string templateNamePrefix = "JobApplication.";
    }
}