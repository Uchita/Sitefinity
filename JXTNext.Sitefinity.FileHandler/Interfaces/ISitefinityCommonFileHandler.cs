using JXTNext.Sitefinity.FileHandler.Enums;
using JXTNext.Sitefinity.FileHandler.Models.Base;

namespace JXTNext.Sitefinity.FileHandler.Interfaces
{
    public interface ISitefinityFileHandler
    {
        /// <summary>
        /// Helps select the type of file
        /// </summary>
        SitefinityCommonFileHandlerServiceType sitefinityCommonFileHandlerServiceType { get; }

        TReturnType ProcessFileUpload<TReturnType, TParameterType>(TParameterType uploadFileParameters)
            where TReturnType : SitefinityCommonFileHandlerResponseModelBase
            where TParameterType : SitefinityCommonFileHandlerRequestModelBase;

        TReturnType ProcessFileDownload<TReturnType, TParameterType>(TParameterType downloadFileParameters)
            where TReturnType : SitefinityCommonFileHandlerResponseModelBase
            where TParameterType : SitefinityCommonFileHandlerRequestModelBase;

    }
}
