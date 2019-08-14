using JXTNext.FileHandler.Enums;
using JXTNext.FileHandler.Interfaces;
using JXTNext.FileHandler.Models.Base;
using JXTNext.FileHandler.Models.Google_Drive;
using JXTNext.Sitefinity.FileHandler.Enums;
using JXTNext.Sitefinity.FileHandler.Interfaces;
using JXTNext.Sitefinity.FileHandler.Models.Base;
using JXTNext.Sitefinity.FileHandler.Models.Google_Drive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.FileHandler.Services
{
    public class GoogleDriveCommonFileHandlerService : ISitefinityFileHandler
    {
        IFileHandler _googleDriveFileHandler { get; set; }

        public GoogleDriveCommonFileHandlerService(IEnumerable<IFileHandler> fileHandlers)
        {
            _googleDriveFileHandler = fileHandlers.FirstOrDefault(handler => handler.fileHandlerServiceType == FileHandlerServiceType.Google_Drive);
        }

        public SitefinityCommonFileHandlerServiceType sitefinityCommonFileHandlerServiceType { get { return SitefinityCommonFileHandlerServiceType.Google_Drive; } }

        public TReturnType ProcessFileDownload<TReturnType, TParameterType>(TParameterType downloadFileParameters)
            where TReturnType : SitefinityCommonFileHandlerResponseModelBase
            where TParameterType : SitefinityCommonFileHandlerRequestModelBase
        {
            try
            {
                if (typeof(TReturnType) != typeof(SitefinityCommonGoogleDriveFilehandlerResponse) && typeof(TParameterType) != typeof(SitefinityCommonGoogleDriveFilehandlerRequest))
                {
                    throw new ArgumentException();
                }

                SitefinityCommonGoogleDriveFilehandlerRequest sitefinityCommonGoogleDriveFilehandlerRequest = downloadFileParameters as SitefinityCommonGoogleDriveFilehandlerRequest;

                GoogleDriveFileHandlerRequestModel googleDriveFileHandlerRequestModel = new GoogleDriveFileHandlerRequestModel()
                {
                    FileId = sitefinityCommonGoogleDriveFilehandlerRequest.FileId,
                    FileUrl = sitefinityCommonGoogleDriveFilehandlerRequest.FileUrl,
                    FileName = sitefinityCommonGoogleDriveFilehandlerRequest.FileName,
                    MimeType = sitefinityCommonGoogleDriveFilehandlerRequest.MimeType,
                    OAuthToken = sitefinityCommonGoogleDriveFilehandlerRequest.OAuthToken
                };

                var fileDownloadResponse = _googleDriveFileHandler.ProcessFileDownload<GoogleDriveFileHandlerResponseModel, GoogleDriveFileHandlerRequestModel>(googleDriveFileHandlerRequestModel);

                return new SitefinityCommonGoogleDriveFilehandlerResponse { FileSuccessStatus = fileDownloadResponse.FileSuccessStatus, FileHandlerServiceType = SitefinityCommonFileHandlerServiceType.Google_Drive, Errors = fileDownloadResponse.Errors, FileStream = fileDownloadResponse.FileStream } as TReturnType;
            }
            catch (Exception ex)
            {
                return new SitefinityCommonGoogleDriveFilehandlerResponse { FileSuccessStatus = false, FileHandlerServiceType = SitefinityCommonFileHandlerServiceType.Google_Drive, Errors = new List<string> { ex.Message }, FileStream = null } as TReturnType;
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
