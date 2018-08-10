using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.StringResources
{
    [ObjectInfo(typeof(JobDetailsResources), ResourceClassId = "JobDetailsResources", Title = "JobDetailsResourcesTitle", Description = "JobDetailsResourcesDescription")]
    public class JobDetailsResources : Resource
    {
        #region Constructions

        /// <summary>
        /// Initializes a new instance of the <see cref="JobDetailsResources" /> class.
        /// </summary>
        public JobDetailsResources()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobDetailsResources" /> class.
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public JobDetailsResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        {
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets phrase: Where to display search results?
        /// </summary>
        [ResourceEntry("SelectJobApplication",
            Value = "Please select Job Application Page",
            Description = "phrase : Please select Job Application Page")]
        public string SelectJobApplication
        {
            get
            {
                return this["SelectJobApplication"];
            }
        }

        /// <summary>
        /// Gets phrase: This is the page where you have dropped search results widget
        /// </summary>
        [ResourceEntry("DropJobApplication",
            Value = "This is the page where you have dropped job application widget",
            Description = "phrase : This is the page where you have dropped job application widget")]
        public string DropJobApplication
        {
            get
            {
                return this["DropJobApplication"];
            }
        }

        /// <summary>
        /// Gets phrase: Where to display search results?
        /// </summary>
        [ResourceEntry("SelectJobSearchResults",
            Value = "Please select Job Search Results Page",
            Description = "phrase : Please select Job Search Results Page")]
        public string SelectJobSearchResults
        {
            get
            {
                return this["SelectJobSearchResults"];
            }
        }

        /// <summary>
        /// Gets phrase: This is the page where you have dropped search results widget
        /// </summary>
        [ResourceEntry("DropJobSearchResults",
            Value = "This is the page where you have dropped job search results widget",
            Description = "phrase : This is the page where you have dropped job search results widget")]
        public string DropJobSearchResults
        {
            get
            {
                return this["DropJobSearchResults"];
            }
        }

        /// <summary>
        /// Gets phrase: This is the page where you have dropped search results widget
        /// </summary>
        [ResourceEntry("ApplyButtonShow",
            Value = "Please select users type to display Apply button",
            Description = "phrase : Please select users type to display Apply button")]
        public string ApplyButtonShow
        {
            get
            {
                return this["ApplyButtonShow"];
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