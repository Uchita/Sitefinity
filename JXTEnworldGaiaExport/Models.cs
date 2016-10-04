using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTEnworldGaiaExport
{
    public class Resume
    {
        public string Title { get; set; }
        public string FileName { get; set; }
        public string FileContent { get; set; }
        public String UploadedDate { get; set; }
    }

    public class GaiaExportFormat : JXTPortal.Client.Salesforce.SalesforceIntegration.SObjRecord
    {
        public int JXTMemberID { get; set; }
        public String Domain { get; set; }
        public String LastModifiedDate { get; set; }
        public String CreatedDate { get; set; }
        public bool Validated { get; set; }
        public List<Resume> Resumes { get; set; }
    }

    public class Application
    {
        //public int JXTMemberID { get; set; }
        public string refno { get; set; }
        public string applicationid { get; set; }
        public string date { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public List<Resume> resume { get; set; }
    }

}
