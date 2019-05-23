using System.Collections.Generic;

namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Models
{
    public class LinkedInApplyResponse
    {
        public bool Success { get; set; }
        public string RedirectUrl { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public List<string> Messages { get; set; } = new List<string>();
    }
}
