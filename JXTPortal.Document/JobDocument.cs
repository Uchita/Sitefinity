using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Document
{
    public class JobDocument
    {
        public int Id { get; set; }

        public string Keyword { get; set; }

        public int WhitelabelId { get; set; }

        public int AdvertiserId { get; set; }

        public int Profession { get; set; }

        public List<int> Roles { get; set; }

        public int Location { get; set; }

        public List<int> Areas { get; set; }

        public int WorktypeId { get; set; }

        public int SalarytypeId { get; set; }

        public decimal SalaryLowerBand { get; set; }

        public decimal SalaryUpperBand { get; set; }

        public bool IsArchived { get; set; }
    }
}
