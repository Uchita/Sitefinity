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

        #endregion
    }
}