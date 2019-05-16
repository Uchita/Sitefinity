using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace JXTNext.Sitefinity.Widgets.Authentication.Mvc.StringResources
{
    [ObjectInfo(typeof(JXTNextResumeResources), ResourceClassId = "JXTNextResumeResources", Title = "JXTNextResumeResourcesTitle", Description = "JXTNextResumeResourcesDescription")]
    public class JXTNextResumeResources : Resource
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="JXTNextProfileResources"/> class. 
        /// Initializes new instance of <see cref="JXTNextProfileResources"/> class with the default <see cref="ResourceDataProvider"/>.
        /// </summary>
        public JXTNextResumeResources()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JXTNextProfileResources"/> class.
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public JXTNextResumeResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        {
        }
        #endregion

        /// <summary>
        /// Gets phrase: Add New Resume
        /// </summary>
        [ResourceEntry("AttachResumeLink",
            Value = "My Resumes",
            Description = "phrase : Attach Resume",
            LastModified = "2018/11/05")]
        public string AttachResumeLink
        {
            get
            {
                return this["AttachResumeLink"];
            }
        }

        /// <summary>
        /// Gets phrase: Add New Resume
        /// </summary>
        [ResourceEntry("UploadFileLink",
            Value = "Upload File",
            Description = "phrase : Upload File",
            LastModified = "2018/11/05")]
        public string UploadFileLink
        {
            get
            {
                return this["UploadFileLink"];
            }
        }

        /// <summary>
        /// Gets phrase: Add New Resume
        /// </summary>
        [ResourceEntry("FileNameLink",
            Value = "File Name",
            Description = "phrase : File Name",
            LastModified = "2018/11/05")]
        public string FileNameLink
        {
            get
            {
                return this["FileNameLink"];
            }
        }

        /// <summary>
        /// Gets phrase: Add New Resume
        /// </summary>
        [ResourceEntry("AttachFileConditionsLink",
            Value = "Please upload your file as Microsoft Word (.doc or .docx), Microsoft Excel (.xls or .xlsx), Adobe Acrobat (.pdf) or text file (.txt or .rtf)",
            Description = "phrase : Please upload your file as Microsoft Word (.doc or .docx), Microsoft Excel (.xls or .xlsx), Adobe Acrobat (.pdf) or text file (.txt or .rtf)",
            LastModified = "2018/11/05")]
        public string AttachFileConditionsLink
        {
            get
            {
                return this["AttachFileConditionsLink"];
            }
        }

        /// <summary>
        /// Gets phrase: Add New Resume
        /// </summary>
        [ResourceEntry("SaveFileAttachmentLink",
            Value = "SAVE",
            Description = "phrase : Saves the attached resume.",
            LastModified = "2018/11/05")]
        public string SaveFileAttachmentLink
        {
            get
            {
                return this["SaveFileAttachmentLink"];
            }
        }

        /// <summary>
        /// Gets phrase: Add New Resume
        /// </summary>
        [ResourceEntry("CancelFileAttachmentLink",
            Value = "CANCEL",
            Description = "phrase : Cancel the saving attached resume.",
            LastModified = "2018/11/05")]
        public string CancelFileAttachmentLink
        {
            get
            {
                return this["CancelFileAttachmentLink"];
            }
        }

        [ResourceEntry("ViewResume",
            Value = "VIEW",
            Description = "phrase : View resume.",
            LastModified = "2018/11/05")]
        public string ViewResume
        {
            get
            {
                return this["ViewResume"];
            }
        }

        [ResourceEntry("DeleteResume",
            Value = "DELETE",
            Description = "phrase : Delete resume.",
            LastModified = "2018/11/05")]
        public string DeleteResume
        {
            get
            {
                return this["DeleteResume"];
            }
        }

        /// <summary>
        /// Gets phrase: File Name
        /// </summary>
        [ResourceEntry("FileName",
            Value = "File name",
            Description = "word : File name title",
            LastModified = "2019/05/16")]
        public string FileName
        {
            get
            {
                return this["FileName"];
            }
        }

        /// <summary>
        /// Gets phrase: Upload Date Title
        /// </summary>
        [ResourceEntry("UploadDate",
            Value = "Upload date",
            Description = "word : Upload Date title",
            LastModified = "2019/05/16")]
        public string UploadDate
        {
            get
            {
                return this["UploadDate"];
            }
        }

        /// <summary>
        /// Gets phrase: Action Title
        /// </summary>
        [ResourceEntry("Action",
            Value = "Action",
            Description = "word : Action title",
            LastModified = "2019/05/16")]
        public string Action
        {
            get
            {
                return this["Action"];
            }
        }

        /// <summary>
        /// Gets phrase: Remove confirmation message
        /// </summary>
        [ResourceEntry("RemoveConfirm",
            Value = "Are you sure you want to delete this resume?",
            Description = "word : Remove confirmation message",
            LastModified = "2019/05/16")]
        public string RemoveConfirm
        {
            get
            {
                return this["RemoveConfirm"];
            }
        }
    }
}
