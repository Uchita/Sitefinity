using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Widgets.User.Mvc.Models.MemberSavedJob
{
    public class MemberSavedJobDisplayItem
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string DisplayTitle { get; set; }
        public DateTime DateAdded { get; set; }
    }

    public enum MemberSavedJobStatus
    {
        AVAILABLE = 0,
        SUCCESS = 1,
        CREATE_FAILED = 2,
        UPATED_FAILED = 3,
        DELETE_FAILED = 4
    }
}
