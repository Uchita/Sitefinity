using JXTNext.FileHandler.FileHandlerServices.Dropbox;
using JXTNext.FileHandler.FileHandlerServices.Google_Drive;
using JXTNext.FileHandler.Interfaces;
using JXTNext.Sitefinity.FileHandler.Interfaces;
using JXTNext.Sitefinity.FileHandler.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace JXTNext.Sitefinity.FileHandler
{
    public class JXTNextSitefinityFileHandler : NinjectModule
    {
        public override void Load()
        {
            // JXTNext.FileHandler Registry
            Bind<IFileHandler>().To<GoogleDriveFileHandlerService>();
            Bind<IFileHandler>().To<DropboxFileHandlerService>();

            // JXTNext.Sitefinity.FileHandler Registry
            Bind<ISitefinityFileHandler>().To<GoogleDriveCommonFileHandlerService>();
            Bind<ISitefinityFileHandler>().To<DropboxCommonFileHandlerService>();
            Bind<ISitefinityFileHandler>().To<S3CommonFileHandlerService>();
        }
    }
}
