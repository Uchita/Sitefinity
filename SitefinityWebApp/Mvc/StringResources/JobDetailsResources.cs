using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace JXTNext.Sitefinity.Frontend.Mvc.StringResources
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