using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.StringResources
{
    [ObjectInfo(typeof(JobSearchResultsResources), ResourceClassId = "JobSearchResultsResources", Title = "JobSearchResultsResourcesTitle", Description = "JobSearchResultsResourcesDescription")]
    public class JobSearchResultsResources : Resource
    {
        #region Constructions

        /// <summary>
        /// Initializes a new instance of the <see cref="JobSearchResources" /> class.
        /// </summary>
        public JobSearchResultsResources()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobSearchResources" /> class.
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public JobSearchResultsResources(ResourceDataProvider dataProvider)
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
        /// Gets phrase: Where to display job details?s
        /// </summary>
        [ResourceEntry("DisplayJobDetails",
            Value = "Where to display job details?",
            Description = "phrase : Where to display job details?")]
        public string DisplayJobDetails
        {
            get
            {
                return this["DisplayJobDetails"];
            }
        }

        /// <summary>
        /// Gets phrase: This is the page where you have dropped job details widget
        /// </summary>
        [ResourceEntry("DropJobDetails",
            Value = "This is the page where you have dropped job details widget",
            Description = "phrase : This is the page where you have dropped job details widget")]
        public string DropJobDetails
        {
            get
            {
                return this["DropJobDetails"];
            }
        }

        /// <summary>
        /// Gets phrase: Where to display email job?
        /// </summary>
        [ResourceEntry("DisplayAdvancedSearchPage",
            Value = "Where to display advanced search page?",
            Description = "phrase : Where to display advanced search page?")]
        public string DisplayAdvancedSearchPage
        {
            get
            {
                return this["DisplayAdvancedSearchPage"];
            }
        }

        /// <summary>
        /// Gets phrase: This is the page where you have dropped email job widget
        /// </summary>
        [ResourceEntry("DropAdvancedSearchPage",
            Value = "This is the page where you have dropped advanced search page widget",
            Description = "phrase : This is the page where you have dropped advanced search page widget")]
        public string DropAdvancedSearchPage
        {
            get
            {
                return this["DropAdvancedSearchPage"];
            }
        }

        /// <summary>
        /// Gets phrase: Where to display email job?
        /// </summary>
        [ResourceEntry("DisplayEmailJob",
            Value = "Where to display email job?",
            Description = "phrase : Where to display email job?")]
        public string DisplayEmailJob
        {
            get
            {
                return this["DisplayEmailJob"];
            }
        }

        /// <summary>
        /// Gets phrase: This is the page where you have dropped email job widget
        /// </summary>
        [ResourceEntry("DropEmailJob",
            Value = "This is the page where you have dropped email job widget",
            Description = "phrase : This is the page where you have dropped email job widget")]
        public string DropEmailJob
        {
            get
            {
                return this["DropEmailJob"];
            }
        }

        /// <summary>
        /// Gets phrase: Page Size for the job search results
        /// </summary>
        [ResourceEntry("PageSize",
            Value = "Page Size",
            Description = "phrase : Page Size for the job search results")]
        public string PageSize
        {
            get
            {
                return this["PageSize"];
            }
        }

        /// <summary>
        /// Gets phrase: Page Size for the job search results
        /// </summary>
        [ResourceEntry("SortOrder",
            Value = "Sort Order",
            Description = "phrase : Sort Order for the job search results")]
        public string SortOrder
        {
            get
            {
                return this["SortOrder"];
            }
        }

        /// <summary>
        /// Gets phrase: Sort By Relevance for the job search results
        /// </summary>
        [ResourceEntry("SortByRelevance",
            Value = "Sort by – Relevance",
            Description = "phrase : Sort job search results by relevance")]
        public string SortByRelevance
        {
            get
            {
                return this["SortByRelevance"];
            }
        }


        /// <summary>
        /// Gets phrase: Page Size for the job search results
        /// </summary>
        [ResourceEntry("SortByRecent",
            Value = "Sort by – Recent Posts",
            Description = "phrase : Sort job search results by recent posts")]
        public string SortByRecent
        {
            get
            {
                return this["SortByRecent"];
            }
        }

        /// <summary>
        /// Gets phrase: Page Size for the job search results
        /// </summary>
        [ResourceEntry("SortByOldest",
            Value = "Sort by – Oldest Posts",
            Description = "phrase : Sort job search results by older posts")]
        public string SortByOldest
        {
            get
            {
                return this["SortByOldest"];
            }
        }

        /// <summary>
        /// Gets phrase: Page Size for the job search results
        /// </summary>
        [ResourceEntry("SortByAlphaAZ",
            Value = "Sort by – Alphabetical A-Z",
            Description = "phrase : Sort job search results by Alphabetical A-Z")]
        public string SortByAlphaAZ
        {
            get
            {
                return this["SortByAlphaAZ"];
            }
        }

        /// <summary>
        /// Gets phrase: Page Size for the job search results
        /// </summary>
        [ResourceEntry("SortByAlphaZA",
            Value = "Sort by – Alphabetical Z-A",
            Description = "phrase : Sort job search results by Alphabetical Z-A")]
        public string SortByAlphaZA
        {
            get
            {
                return this["SortByAlphaZA"];
            }
        }

        /// <summary>
        /// Gets phrase: Page Size for the job search results
        /// </summary>
        [ResourceEntry("SortBySalHighToLow",
            Value = "Sort by – Salary high to low",
            Description = "phrase : Sort job search results by Salary high to low")]
        public string SortBySalHighToLow
        {
            get
            {
                return this["SortBySalHighToLow"];
            }
        }

        /// <summary>
        /// Gets phrase: Page Size for the job search results
        /// </summary>
        [ResourceEntry("SortBySalLowToHigh",
            Value = "Sort by – Salary low to high",
            Description = "phrase : Sort job search results by Salary low to high")]
        public string SortBySalLowToHigh
        {
            get
            {
                return this["SortBySalLowToHigh"];
            }
        }

        /// <summary>
        /// Gets phrase: Please select jobs display type
        /// </summary>
        [ResourceEntry("JobsDisplayType",
            Value = "Please select jobs display type",
            Description = "phrase : This Please select jobs display type")]
        public string JobsDisplayType
        {
            get
            {
                return this["JobsDisplayType"];
            }
        }

        /// <summary>
        /// Gets phrase: All Jobs
        /// </summary>
        [ResourceEntry("AllJobs",
            Value = "All Jobs ",
            Description = "phrase : Display all jobs results")]
        public string AllJobs
        {
            get
            {
                return this["AllJobs"];
            }
        }

        /// <summary>
        /// Gets phrase: Please select jobs display type
        /// </summary>
        [ResourceEntry("OR",
            Value = "OR",
            Description = "phrase : OR")]
        public string OR
        {
            get
            {
                return this["OR"];
            }
        }

        /// <summary>
        /// word: Template
        /// </summary>
        /// <value>Template</value>
        [ResourceEntry("Template",
            Value = "Template",
            Description = " word: Template")]
        public string Template
        {
            get
            {
                return this["Template"];
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

        /// <summary>
        /// Gets phrase : HideUrl
        /// </summary>
        [ResourceEntry("HideUrl",
            Value = "Hide Push State Url",
            Description = "phrase : Hide Push State Url")]
        public string HideUrl
        {
            get
            {
                return this["HideUrl"];
            }
        }

        /// <summary>
        /// Gets phrase : GeneralTab
        /// </summary>
        [ResourceEntry("GeneralTab",
            Value = "General",
            Description = "phrase : General Tab")]
        public string GeneralTab
        {
            get
            {
                return this["GeneralTab"];
            }
        }

        /// <summary>
        /// Gets phrase : FiltersTab
        /// </summary>
        [ResourceEntry("FiltersTab",
            Value = "Select Filters",
            Description = "phrase : Select Filters Tab")]
        public string FiltersTab
        {
            get
            {
                return this["FiltersTab"];
            }
        }

        /// <summary>
        /// Gets phrase : UseTheseFilters
        /// </summary>
        [ResourceEntry("UseTheseFilters",
            Value = "Use these filters",
            Description = "phrase : Use these filters")]
        public string UseTheseFilters
        {
            get
            {
                return this["UseTheseFilters"];
            }
        }

        #endregion
    }
}