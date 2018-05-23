using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace JXTNext.Sitefinity.Frontend.Mvc.StringResources
{
    [ObjectInfo(typeof(JobSearchResources), ResourceClassId = "JobSearchResources", Title = "JobSearchResourcesTitle", Description = "JobSearchResourcesDescription")]
    public class JobSearchResources : Resource
    {
        #region Constructions

        /// <summary>
        /// Initializes a new instance of the <see cref="JobSearchResources" /> class.
        /// </summary>
        public JobSearchResources()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobSearchResources" /> class.
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public JobSearchResources(ResourceDataProvider dataProvider)
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
        /// Gets phrase: Adds the front end job search component
        /// </summary>
        [ResourceEntry("JobParamAdd",
            Value = "Add",
            Description = "phrase : Adds the front end job search component")]
        public string JobParamAdd
        {
            get
            {
                return this["JobParamAdd"];
            }
        }

        /// <summary>
        /// Gets phrase: Remove the front end job search component
        /// </summary>
        [ResourceEntry("JobParamDelete",
            Value = "Delete",
            Description = "phrase : Remove the front end job search component")]
        public string JobParamDelete
        {
            get
            {
                return this["JobParamDelete"];
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