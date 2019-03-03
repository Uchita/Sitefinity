using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Models
{
    public class JobEmailFormModel
    {
        public const string RequiredFieldMessage = "This field is required";
        public const string InvalidValueMessage = "The field value is invalid";

        [Required(AllowEmptyStrings = false, ErrorMessage = RequiredFieldMessage)]
        public int JobId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = RequiredFieldMessage)]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = RequiredFieldMessage)]
        [StringLength(255)]
        [EmailAddress(ErrorMessage = InvalidValueMessage)]
        public string Email { get; set; }

        public bool EmailFriend { get; set; }

        public List<JobEmailFriendModel> Friend { get; set; } = new List<JobEmailFriendModel>();        

        [StringLength(1000)]
        public string FriendMessage { get; set; }

        public string JobEmailFriendAction { get; set; }
    }
}
