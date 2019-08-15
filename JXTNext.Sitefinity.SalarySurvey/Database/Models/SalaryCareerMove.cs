using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JXTNext.Sitefinity.SalarySurvey.Database.Models
{
    [Table("SalaryCareerMove")]
    public class SalaryCareerMove
    {
        [Key]
        [Column(Order = 1)]
        public long SalaryId { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid CareerMoveId { get; set; }
    }
}
