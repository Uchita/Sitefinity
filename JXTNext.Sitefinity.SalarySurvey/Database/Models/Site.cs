using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JXTNext.Sitefinity.SalarySurvey.Database.Models
{
    [Table("Site")]
    public class Site
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(255)]
        [Index("IX_Domain", IsUnique = true)]
        public string Domain { get; set; }

        [MaxLength(255)]
        public string Url{ get; set; }

        public long? AliasOfId { get; set; }

        [DefaultValue("true")]
        public bool Active { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        public virtual Site AliasOf { get; set; }
    }
}
