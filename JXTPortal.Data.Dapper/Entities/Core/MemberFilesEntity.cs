using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JXTPortal.Data.Dapper.Entities.Core
{
    public class MemberFilesEntity : BaseEntity
    {
        public int MemberFileID { get; set; }
        public int MemberID { get; set; }
        public int MemberFileTypeID { get; set; }
        public string MemberFileName { get; set; }
        public string MemberFileSearchExtension { get; set; }
        public byte[] MemberFileContent { get; set; }
        public string MemberFileTitle { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int DocumentTypeID { get; set; }
        public string MemberFileURL { get; set; }
    }
}
