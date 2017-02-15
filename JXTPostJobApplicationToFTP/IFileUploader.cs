using System;
namespace JXTPostJobApplicationToFTP
{
    public interface IFileUploader
    {
        bool UploadFiles(SitesXML siteXML, System.Collections.Generic.List<FileNames> filesToUpload);
    }
}
