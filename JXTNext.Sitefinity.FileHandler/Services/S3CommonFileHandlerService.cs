using JXTNext.Sitefinity.FileHandler.Enums;
using JXTNext.Sitefinity.FileHandler.Interfaces;
using JXTNext.Sitefinity.FileHandler.Models.Base;
using JXTNext.Sitefinity.FileHandler.Models.S3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telerik.Sitefinity.Libraries.Model;
using Telerik.Sitefinity.Modules.Libraries;
using Telerik.Sitefinity.Workflow;

namespace JXTNext.Sitefinity.FileHandler.Services
{
    public class S3CommonFileHandlerService : ISitefinityFileHandler
    {
        public SitefinityCommonFileHandlerServiceType sitefinityCommonFileHandlerServiceType { get { return SitefinityCommonFileHandlerServiceType.S3; } }

        public TReturnType ProcessFileDownload<TReturnType, TParameterType>(TParameterType downloadFileParameters)
            where TReturnType : SitefinityCommonFileHandlerResponseModelBase
            where TParameterType : SitefinityCommonFileHandlerRequestModelBase
        {
            if (typeof(TReturnType) != typeof(S3SitefinityCommonFileHandlerResponse) && typeof(TParameterType) != typeof(S3SitefinityCommonFilehandlerRequest))
                throw new ArgumentException();

            S3SitefinityCommonFilehandlerRequest fileDownloadRequest = downloadFileParameters as S3SitefinityCommonFilehandlerRequest;

            S3DownloadedFile file = DownloadFileFromS3(fileDownloadRequest.ProviderName, fileDownloadRequest.LibraryName, fileDownloadRequest.FileName);

            return new S3SitefinityCommonFileHandlerResponse { FileStream = file.FileStream, FileHandlerServiceType = SitefinityCommonFileHandlerServiceType.S3 } as TReturnType;
        }

        #region ProcessFileDownload - Private Methods

        private S3DownloadedFile DownloadFileFromS3(string providerName, string libraryName, string fileName)
        {
            LibrariesManager librariesManager = LibrariesManager.GetManager(providerName);
            var docLibs = librariesManager.GetDocumentLibraries();

            MediaContent document = null;
            Stream tempStream = null;
            MemoryStream fileStream = new MemoryStream();

            foreach (var lib in docLibs)
            {
                if (lib.Title.ToLower() == libraryName)
                {
                    document = lib.Items().Where(item => item.Title == fileName).FirstOrDefault();
                    tempStream = librariesManager.Download(document);
                }
            }

            if (tempStream != null)
            {
                tempStream.CopyTo(fileStream);
                fileStream.Position = 0;
            }

            return new S3DownloadedFile { Document = document, FileStream = fileStream };
        }

        #endregion

        public TReturnType ProcessFileUpload<TReturnType, TParameterType>(TParameterType uploadFileParameters)
            where TReturnType : SitefinityCommonFileHandlerResponseModelBase
            where TParameterType : SitefinityCommonFileHandlerRequestModelBase
        {
            if (typeof(TReturnType) != typeof(S3SitefinityCommonFileHandlerResponse) && typeof(TParameterType) != typeof(S3SitefinityCommonFilehandlerRequest))
                throw new ArgumentException();

            S3SitefinityCommonFilehandlerRequest filehandlerRequest = uploadFileParameters as S3SitefinityCommonFilehandlerRequest;

            bool success;

            success = UploadFileToS3(filehandlerRequest.MasterDocumentId, filehandlerRequest.ProviderName, filehandlerRequest.LibraryName, filehandlerRequest.FileName, filehandlerRequest.FileStream);

            return new S3SitefinityCommonFileHandlerResponse { FileHandlerServiceType = SitefinityCommonFileHandlerServiceType.S3, FileSuccessStatus = success  } as TReturnType;
        }

        #region ProcessFileUpload - Private Methods
               
        private bool UploadFileToS3(Guid masterDocumentId, string providerName, string libraryName, string fileName, MemoryStream fileStream)
        {
            LibrariesManager librariesManager = LibrariesManager.GetManager(providerName);
            Document document = librariesManager.GetDocuments().Where(i => i.Id == masterDocumentId).FirstOrDefault();

            if (document == null)
            {
                //The document is created as master. The masterDocumentId is assigned to the master version.
                document = librariesManager.CreateDocument(masterDocumentId);

                //Set the parent document library.
                DocumentLibrary documentLibrary = librariesManager.GetDocumentLibraries().Where(d => d.Title == libraryName).SingleOrDefault();
                document.Parent = documentLibrary;

                //Set the properties of the document.
                string documentTitle = masterDocumentId.ToString() + "_" + fileName;
                document.Title = documentTitle;
                document.DateCreated = DateTime.UtcNow;
                document.PublicationDate = DateTime.UtcNow;
                document.LastModified = DateTime.UtcNow;
                document.UrlName = Regex.Replace(documentTitle.ToLower(), @"[^\w\-\!\$\'\(\)\=\@\d_]+", "-");
                document.MediaFileUrlName = Regex.Replace(documentTitle.ToLower(), @"[^\w\-\!\$\'\(\)\=\@\d_]+", "-");
                document.ApprovalWorkflowState = "Published";

                //Upload the document file.
                string fileExtension = fileName.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                librariesManager.Upload(document, fileStream, fileExtension ?? string.Empty);

                //Recompiles and validates the url of the document.
                librariesManager.RecompileAndValidateUrls(document);

                //Save the changes.
                librariesManager.SaveChanges();

                //Publish the DocumentLibraries item. The live version acquires new ID.
                var bag = new Dictionary<string, string>();
                bag.Add("ContentType", typeof(Document).FullName);
                WorkflowManager.MessageWorkflow(masterDocumentId, typeof(Document), null, "Publish", false, bag);

                return true;
            }
            else
            {
                return false;
            }
        }
        
        #endregion
    }
}
