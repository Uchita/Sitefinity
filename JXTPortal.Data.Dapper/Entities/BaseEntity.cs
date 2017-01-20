using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Data.Dapper.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime LastModified { get; set; }
        public int? LastModifiedBy { get; set; }
    }
}
