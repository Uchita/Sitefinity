using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.User.Mvc.Models.MemberAppliedJob
{
    public class MemberAppliedJobItem
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string DisplayTitle { get; set; }
        public DateTime DateAdded { get; set; }
        public string ClassificationURL { get; set; }
        public string Culture { get; set; }
    }
}
