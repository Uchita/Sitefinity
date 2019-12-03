namespace JXTNext.Sitefinity.Widgets.JobAlert.Mvc.StringResources
{
    using Telerik.Sitefinity.Localization;
    using Telerik.Sitefinity.Localization.Data;

    /// <summary>
    /// Defines the <see cref="JobAlertResources" />
    /// </summary>
    [ObjectInfo(typeof(JobAlertResources), ResourceClassId = "JobAlertResources", Title = "JobAlertResourcesTitle", Description = "JobAlertResourcesDescription")]
    public class JobAlertResources : Resource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobAlertResources"/> class.
        /// </summary>
        public JobAlertResources()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobAlertResources"/> class.
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public JobAlertResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        {
        }

        /// <summary>
        /// Gets the DisplayJobSearchResults
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
        /// Gets the DropJobSearchResults
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
        /// Gets the MoreOptions
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
        /// Gets the CssClasses
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
        /// Gets the EmailCC
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
        /// Gets the EmailBCC
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
        /// Gets the SenderName
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
        /// Gets the SenderEmailAddress
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
        /// Gets the SelectEmailTemplate
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
        /// Gets the EmailSubject
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
    }
}
