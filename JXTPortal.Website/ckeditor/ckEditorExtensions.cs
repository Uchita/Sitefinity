using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JXTPortal.Website.ckeditor.Extensions
{
    public static class ckEditorExtensions
    {
        /// <summary>
        /// Sets the custom config(if required) based on the desired ftp folder 
        /// </summary>
        /// <param name="control">The host CKEditorControl</param>
        /// <param name="ftpFolder">The ftp folder where the files are located</param>
        /// <remarks>
        /// If the ftpFolder starts with s3:// then we use the s3custom_config.js config
        /// </remarks>
        public static void SetConfigForFTPFolder(this CKEditor.NET.CKEditorControl control, bool isUsingS3)
        {
            if (isUsingS3)
            {
                control.CustomConfig = "s3custom_config.js";
            }
        }
    }
}