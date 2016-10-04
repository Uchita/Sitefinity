	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using JXTPortal.Entities;
using JXTPortal.Entities.Validation;

using JXTPortal.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace JXTPortal
{		
	/// <summary>
	/// An component type implementation of the 'Files' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class FilesService : JXTPortal.FilesServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the FilesService class.
		/// </summary>
		public FilesService() : base()
		{
		}
		#endregion Constructors


        public bool UploadFile(int intFileID, int intFolderID, System.Web.UI.WebControls.FileUpload txtUploadFile, String strFilePath, ref String strMessage)
        {
            string strUploadedFileName = System.IO.Path.GetFileNameWithoutExtension(txtUploadFile.PostedFile.FileName);
            string strUploadedFileExtension = System.IO.Path.GetExtension(txtUploadFile.PostedFile.FileName);
            string strNewFileName = String.Format("{0}_{1}", SessionData.Site.SiteId, Guid.NewGuid().ToString());
            int intFileType = GetFileType(strUploadedFileExtension);

            if (txtUploadFile.PostedFile != null)
            {
                if (intFileType > 0)
                {
                    try
                    {
                        txtUploadFile.PostedFile.SaveAs(strFilePath + strNewFileName + strUploadedFileExtension);
                        strMessage = "File <b>" +
                                txtUploadFile.PostedFile.FileName + "</b> uploaded successfully";

                        // Update File
                        if (intFileID > 0)
                        {
                            using (Files files = GetByFileId(intFileID))
                            {

                                // Delete Physical File
                                DeletePhysicalFile(strFilePath + files.FileSystemName);

                                // Update
                                files.FileName = System.Web.HttpUtility.HtmlEncode(strUploadedFileName) + strUploadedFileExtension;
                                files.FileSystemName = strNewFileName + strUploadedFileExtension;
                                files.FileTypeId = intFileType;
                                Update(files);
                            }
                        }
                        else
                        {
                            using (Files files = new Files())
                            {
                                // Insert
                                files.FileName = System.Web.HttpUtility.HtmlEncode(strUploadedFileName) + strUploadedFileExtension;
                                files.FileSystemName = strNewFileName + strUploadedFileExtension;
                                files.FileTypeId = intFileType;
                                files.FolderId = intFolderID;
                                Insert(files);
                            }
                        }


                        return true;
                    }
                    catch (Exception ex)
                    {
                        strMessage = "Error saving <b>" +
                                txtUploadFile.PostedFile.FileName + "</b>: " + ex.Message;
                        return false;
                    }
                }
                else
                {
                    strMessage = "Not a valid File Type uploaded.";
                    return false;
                }
            }

            strMessage = "You did not specify a file to upload.";

            return false;
        }

        /*
        public bool DeleteFile(int intFileID, String strFilePath, ref String strMessage)
        {
            try
            {
                using (Files files = GetByFileId(intFileID))
                {
                    //String strFilePath = System.IO.Path.GetFullPath(System.Configuration.ConfigurationManager.AppSettings["FileAndImagePaths"]);

                    // Delete the physical file
                    System.IO.File.Delete(strFilePath + files.FileSystemName);

                    // Delete from Database
                    this.Delete(files);

                    return true;
                }
            }
            catch (Exception ex)
            {
                strMessage = ex.Message;
            }

            return false;
        }*/

        public bool DeletePhysicalFile(string filename)
        {
            try
            {
                System.IO.File.Delete(filename);
                return true;
            }
            catch { }
            return false;
        }

        public int GetFileType(string strUploadedFileExtension)
        {
            FileTypesService fileTypeService = new FileTypesService();

            int intOtherId = (int) PortalEnums.Files.FileTypes.Other;

            using (TList<FileTypes> objFileTypes = fileTypeService.GetAll())
            {

                strUploadedFileExtension = strUploadedFileExtension.Trim().ToLower();


                foreach (FileTypes fileType in objFileTypes)
                {
                    if (strUploadedFileExtension.Equals(fileType.FileTypeExtension.ToLower()))
                    {
                        return fileType.FileTypeId;
                    }

                    if (fileType.FileTypeName.ToLower().Equals("other"))
                        intOtherId = fileType.FileTypeId;
                }
            }

            return intOtherId;
        }

	}//End Class

} // end namespace
