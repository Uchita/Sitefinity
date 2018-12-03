using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.Authentication.Mvc.Models.JXTNextResume
{
    public class ProfileResumeJsonModel
    {
        public Guid Id { get; set; }
        public DateTime UploadDate { get; set; }
        public string FileName { get; set; }
        public string UploadPathToAttachment { get; set; }
        public string FileExtension { get; set; }
        public string FileUrl { get; set; }

        public string UploadDateStr { get { return UploadDate.ToString(); } }

        public string FileFullName { get { return FileName + "." + FileExtension; } }
    }
}
