namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Models
{
    public class JobEmailWidgetModel
    {
        public string JobLabel { get; set; }
        public string JobHelp { get; set; }

        public string NameLabel { get; set; }
        public string NameHelp { get; set; }

        public string EmailLabel { get; set; }
        public string EmailHelp { get; set; }

        public string EmailFriendLabel { get; set; }
        public string EmailFriendHelp { get; set; }

        public string FriendNameLabel { get; set; }
        public string FriendNameHelp { get; set; }

        public string FriendEmailLabel { get; set; }
        public string FriendEmailHelp { get; set; }

        public string FriendMessageLabel { get; set; }
        public string FriendMessageHelp { get; set; }

        public string AddFriendButtonLabel { get; set; }
        public string RemoveFriendButtonLabel { get; set; }
        public string SubmitButtonLabel { get; set; }

        public int MaxFriends { get; set; }

        public string JobNotFoundMessage { get; set; }
        public string EmailSentMessage { get; set; }
    }
}
