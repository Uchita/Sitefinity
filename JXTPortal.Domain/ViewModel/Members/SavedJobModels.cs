using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Domain.ViewModel
{
    public class SavedJobModels
    {
        public SavedJobModels()
        {
            SavedJobs = new List<SavedJobModel>();
        }

        public List<SavedJobModel> SavedJobs { get; set; }
    }
    
    public class SavedJobModel
    {
        public int JobSaveID { get; set; }
        public int JobID { get; set; }
        public int MemberID { get; set; }
        public DateTime LastModified { get; set; }
        public string JobName { get; set; }
        public string JobFriendlyName { get; set; }
        public string SiteProfessionName { get; set; }
    }
}
