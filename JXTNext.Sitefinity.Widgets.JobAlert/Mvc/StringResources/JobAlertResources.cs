using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace JXTNext.Sitefinity.Widgets.JobAlert.Mvc.StringResources
{
    [ObjectInfo(typeof(JobAlertResources), ResourceClassId = "JobAlertResources", Title = "JobAlertResourcesTitle", Description = "JobAlertResourcesDescription")]
    public class JobAlertResources : Resource
    {
        #region Constructions

        /// <summary>
        /// Initializes a new instance of the <see cref="JobAlertResources" /> class.
        /// </summary>
        public JobAlertResources()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobAlertResources" /> class.
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public JobAlertResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        {
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets phrase: Where to display search results?
        /// </summary>
        [ResourceEntry("DisplayJobSearchResults",
            Value = "Where to display search results?",
            Description = "phrase : Where to display search results?")]
        public string DisplayJobSearchResults
        {
            get
            {
                return this["DisplayJobSearchResults"];
            }
        }

        /// <summary>
        /// Gets phrase: This is the page where you have dropped search results widget
        /// </summary>
        [ResourceEntry("DropJobSearchResults",
            Value = "This is the page where you have dropped search results widget",
            Description = "phrase : This is the page where you have dropped search results widget")]
        public string DropJobSearchResults
        {
            get
            {
                return this["DropJobSearchResults"];
            }
        }

        /// <summary>
        /// Gets phrase: More options
        /// </summary>
        [ResourceEntry("MoreOptions",
            Value = "More options",
            Description = "phrase : More options")]
        public string MoreOptions
        {
            get
            {
                return this["MoreOptions"];
            }
        }

        /// <summary>
        /// Gets phrase: More options
        /// </summary>
        [ResourceEntry("WidgetSettings",
            Value = "Widget Settings",
            Description = "phrase : Widget Settings")]
        public string WidgetSettings
        {
            get
            {
                return this["WidgetSettings"];
            }
        }

        /// <summary>
        /// Gets phrase: Select user dashboard page
        /// </summary>
        [ResourceEntry("SelectUserDashboardPage",
            Value = "Select user dashboard page",
            Description = "phrase : Select user dashboard page")]
        public string SelectUserDashboardPage
        {
            get
            {
                return this["SelectUserDashboardPage"];
            }
        }

        /// <summary>
        /// Gets phrase : CSS classes
        /// </summary>
        [ResourceEntry("CssClasses",
            Value = "CSS classes",
            Description = "phrase : CSS classes")]
        public string CssClasses
        {
            get
            {
                return this["CssClasses"];
            }
        }

        /// <summary>
        /// Gets phrase: This is the page where you have dropped search results widget
        /// </summary>
        [ResourceEntry("EmailCC",
            Value = "Enter CC E-mail list separated by semicolon:",
            Description = "phrase : Enter CC E-mail list separated by semicolon")]
        public string EmailCC
        {
            get
            {
                return this["EmailCC"];
            }
        }

        /// <summary>
        /// Gets phrase: Where to display search results?
        /// </summary>
        [ResourceEntry("EmailBCC",
            Value = "Enter BCC E-mail list separated by semicolon:",
            Description = "phrase : Enter BCC E-mail list separated by semicolon")]
        public string EmailBCC
        {
            get
            {
                return this["EmailBCC"];
            }
        }

        /// <summary>
        /// Gets phrase: This is the page where you have dropped search results widget
        /// </summary>
        [ResourceEntry("SenderName",
            Value = "Enter sender name:",
            Description = "phrase : Enter from sender name")]
        public string SenderName
        {
            get
            {
                return this["SenderName"];
            }
        }

        /// <summary>
        /// Gets phrase: This is the page where you have dropped search results widget
        /// </summary>
        [ResourceEntry("SenderEmailAddress",
            Value = "Enter sender E-mail address:",
            Description = "phrase : Enter sender email address")]
        public string SenderEmailAddress
        {
            get
            {
                return this["SenderEmailAddress"];
            }
        }

        /// <summary>
        /// Gets phrase: This is the page where you have dropped search results widget
        /// </summary>
        [ResourceEntry("SelectEmailTemplate",
            Value = "Select E-mail template",
            Description = "phrase : Select E-mail template")]
        public string SelectEmailTemplate
        {
            get
            {
                return this["SelectEmailTemplate"];
            }
        }

        /// <summary>
        /// Gets phrase: This is the page where you have dropped search results widget
        /// </summary>
        [ResourceEntry("EmailSubject",
            Value = "Enter E-mail subject:",
            Description = "phrase : Enter email subject")]
        public string EmailSubject
        {
            get
            {
                return this["EmailSubject"];
            }
        }

        /// <summary>
        /// Gets phrase: Job Alerts title
        /// </summary>
        [ResourceEntry("JobAlerts",
            Value = "Job alerts",
            Description = "word : Job Alerts title")]
        public string JobAlerts
        {
            get
            {
                return this["JobAlerts"];
            }
        }

        /// <summary>
        /// Gets phrase: Action title
        /// </summary>
        [ResourceEntry("Action",
            Value = "Action",
            Description = "word : Action title")]
        public string Action
        {
            get
            {
                return this["Action"];
            }
        }

        /// <summary>
        /// Gets phrase: Name title
        /// </summary>
        [ResourceEntry("Name",
            Value = "Name",
            Description = "word : Name title")]
        public string Name
        {
            get
            {
                return this["Name"];
            }
        }

        /// <summary>
        /// Gets phrase: New search button's label
        /// </summary>
        [ResourceEntry("NewSearch",
            Value = "New search",
            Description = "word : New search button's label",
            LastModified = "2019/05/16")]
        public string NewSearch
        {
            get
            {
                return this["NewSearch"];
            }
        }

        /// <summary>
        /// Gets phrase: No job alerts message
        /// </summary>
        [ResourceEntry("NoJobAlerts",
            Value = "You currently don't have any job alerts.",
            Description = "word : No job alerts message",
            LastModified = "2019/05/16")]
        public string NoJobAlerts
        {
            get
            {
                return this["NoJobAlerts"];
            }
        }

        /// <summary>
        /// Gets phrase: Remove confirmation message
        /// </summary>
        [ResourceEntry("RemoveConfirm",
            Value = "Are you sure you want to delete this Job Alert?",
            Description = "word : Remove confirmation message",
            LastModified = "2019/05/16")]
        public string RemoveConfirm
        {
            get
            {
                return this["RemoveConfirm"];
            }
        }

        /// <summary>
        /// Gets phrase: Create a job alert button's label
        /// </summary>
        [ResourceEntry("CreateJobAlert",
            Value = "Create job alert",
            Description = "word : Create a job alert button's label",
            LastModified = "2019/05/16")]
        public string CreateJobAlert
        {
            get
            {
                return this["CreateJobAlert"];
            }
        }

        /// <summary>
        /// Gets phrase: Alert Details' label
        /// </summary>
        [ResourceEntry("AlertDetails",
            Value = "Alert details",
            Description = "word : Alert Details' label",
            LastModified = "2019/05/16")]
        public string AlertDetails
        {
            get
            {
                return this["AlertDetails"];
            }
        }

        /// <summary>
        /// Gets phrase: Alert Name's label
        /// </summary>
        [ResourceEntry("AlertName",
            Value = "Job alert name*",
            Description = "word : Alert Name's label",
            LastModified = "2019/05/16")]
        public string AlertName
        {
            get
            {
                return this["AlertName"];
            }
        }

        /// <summary>
        /// Gets phrase: Keywords's label
        /// </summary>
        [ResourceEntry("Keywords",
            Value = "Keywords",
            Description = "word : Keywords's label",
            LastModified = "2019/05/16")]
        public string Keywords
        {
            get
            {
                return this["Keywords"];
            }
        }

        /// <summary>
        /// Gets phrase: Choose Salary's label
        /// </summary>
        [ResourceEntry("ChooseSalary",
            Value = "Choose Salary",
            Description = "word : Choose Salary's label",
            LastModified = "2019/05/16")]
        public string ChooseSalary
        {
            get
            {
                return this["ChooseSalary"];
            }
        }

        /// <summary>
        /// Gets phrase: Cancel button's label
        /// </summary>
        [ResourceEntry("Cancel",
            Value = "Cancel",
            Description = "word : Cancel button's label",
            LastModified = "2019/05/16")]
        public string Cancel
        {
            get
            {
                return this["Cancel"];
            }
        }

        /// <summary>
        /// Gets phrase: Save button's label
        /// </summary>
        [ResourceEntry("Save",
            Value = "SAVE",
            Description = "word : Save button's label",
            LastModified = "2019/05/16")]
        public string Save
        {
            get
            {
                return this["Save"];
            }
        }

        #endregion
    }
}