using JXTNext.FileHandler.Enums;
using JXTNext.FileHandler.Interfaces;
using JXTNext.FileHandler.Models.Dropbox;
using JXTNext.Sitefinity.FileHandler.Enums;
using JXTNext.Sitefinity.FileHandler.Interfaces;
using JXTNext.Sitefinity.FileHandler.Models.Base;
using JXTNext.Sitefinity.FileHandler.Models.Dropbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.FileHandler.Services
{
    public class DropboxCommonFileHandlerService : ISitefinityFileHandler
    {
        IFileHandler _dropboxFileHandler { get; set; }

        public DropboxCommonFileHandlerService(IEnumerable<IFileHandler> fileHandlers)
        {
            _dropboxFileHandler = fileHandlers.FirstOrDefault(handler => handler.fileHandlerServiceType == FileHandlerServiceType.Dropbox);
        }

        public SitefinityCommonFileHandlerServiceType sitefinityCommonFileHandlerServiceType { get { return SitefinityCommonFileHandlerServiceType.Dropbox; } }

        public TReturnType ProcessFileDownload<TReturnType, TParameterType>(TParameterType downloadFileParameters)
            where TReturnType : SitefinityCommonFileHandlerResponseModelBase
            where TParameterType : SitefinityCommonFileHandlerRequestModelBase
        {
            try
            {
                if (typeof(TReturnType) != typeof(DropboxSitefinityCommonFileHandlerResponse) && typeof(TParameterType) != typeof(DropboxSitefinityCommonFileHandlerRequest))
                {
                    throw new ArgumentException();
                }

                DropboxSitefinityCommonFileHandlerRequest sitefinityCommonDropboxFilehandlerRequest = downloadFileParameters as DropboxSitefinityCommonFileHandlerRequest;

                DropboxFileHandlerRequestModel dropboxFileHandlerRequestModel = new DropboxFileHandlerRequestModel()
                {
                     FileUrl = sitefinityCommonDropboxFilehandlerRequest.FileUrl,
                     FileName = sitefinityCommonDropboxFilehandlerRequest.FileName
                };

                var fileDownloadResponse = _dropboxFileHandler.ProcessFileDownload<DropboxFileHandlerResponseModel, DropboxFileHandlerRequestModel>(dropboxFileHandlerRequestModel);

                return new DropboxSitefinityCommonFileHandlerResponse { FileSuccessStatus = fileDownloadResponse.FileSuccessStatus, FileHandlerServiceType = SitefinityCommonFileHandlerServiceType.Dropbox, Errors = fileDownloadResponse.Errors, FileStream = fileDownloadResponse.FileStream } as TReturnType;
            }
            catch (Exception ex)
            {
                return new DropboxSitefinityCommonFileHandlerResponse { FileSuccessStatus = false, FileHandlerServiceType = SitefinityCommonFileHandlerServiceType.Dropbox, Errors = new List<string> { ex.Message }, FileStream = null } as TReturnType;
            }
        }

        public TReturnType ProcessFileUpload<TReturnType, TParameterType>(TParameterType uploadFileParameters)
            where TReturnType : SitefinityCommonFileHandlerResponseModelBase
            where TParameterType : SitefinityCommonFileHandlerRequestModelBase
        {
            throw new NotImplementedException();
        }
    }
}
