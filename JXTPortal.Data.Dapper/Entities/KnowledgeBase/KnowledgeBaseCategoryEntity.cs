using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Data.Dapper.Entities.KnowledgeBase
{
    public class KnowledgeBaseCategoryEntity : BaseEntity
    {
        public int ParentId { get; set; }
        public string KnowledgeBaseCategoryName { get; set; }
        public bool Valid { get; set; }
        public int Sequence { get; set; }
    }
}
