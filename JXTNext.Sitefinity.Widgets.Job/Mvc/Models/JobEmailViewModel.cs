namespace JXTNext.Sitefinity.Widgets.Job.Mvc.Models
{
    public class JobEmailViewModel
    {
        public dynamic Job { get; set; }
        public bool Sent { get; set; }

        public JobEmailWidgetModel Widget { get; set; }
        public JobEmailFormModel Form { get; set; }
    }
}
