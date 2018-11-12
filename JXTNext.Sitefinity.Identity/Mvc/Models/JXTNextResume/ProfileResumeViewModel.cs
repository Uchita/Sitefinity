using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.Authentication.Mvc.Models.JXTNextResume
{
    public class ProfileResumeViewModel
    {
        public List<ProfileResumeJsonModel> ResumeList { get; set; } 
        public bool UploadError { get; set; }
        public bool FetchError { get; set; }
        public bool DeleteError { get; set; }
    }
}
