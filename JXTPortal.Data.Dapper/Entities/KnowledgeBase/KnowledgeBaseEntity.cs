using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Data.Dapper.Entities.KnowledgeBase
{
    public class KnowledgeBaseEntity : BaseEntity
    {
        public int KnowledgeBaseCategoryID { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public bool Valid { get; set; }
        public int Sequence { get; set; }
        public string SearchField { get; set; }
        public string Tags { get; set; }
    }
}
