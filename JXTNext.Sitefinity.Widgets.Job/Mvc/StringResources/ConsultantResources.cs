﻿using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace JXTNext.Sitefinity.Widgets.Job.Mvc.StringResources
{
    [ObjectInfo(typeof(ConsultantResources), ResourceClassId = "ConsultantResources", Title = "ConsultantResourcesTitle", Description = "ConsultantResourcesDescription")]
    public class ConsultantResources : Resource
    {
        #region Constructions

        /// <summary>
        /// Initializes a new instance of the <see cref="JobSearchResources" /> class.
        /// </summary>
        public ConsultantResources()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobSearchResources" /> class.
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public ConsultantResources(ResourceDataProvider dataProvider)
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
        /// Gets phrase: Sort By Relevance for the job search results
        /// </summary>
        [ResourceEntry("SortByRelevance",
            Value = "Sort by – Relevance",
            Description = "phrase : Sort job search results by Relevance posts")]
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

       #endregion
    }
}