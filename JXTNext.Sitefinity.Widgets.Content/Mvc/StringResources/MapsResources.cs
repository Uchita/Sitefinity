using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace JXTNext.Sitefinity.Widgets.Content.Mvc.StringResources
{
    /// <summary>
    /// Localizable strings for the Users list widget
    /// </summary>
    [ObjectInfo(typeof(MapsResources), ResourceClassId = "MapsResourcesResources", Title = "MapsResourcesResourcesTitle", Description = "MapsResourcesResourcesDescription")]
    public class MapsResources : Resource
    {
        #region Constructions
        /// <summary>
        /// Initializes a new instance of the <see cref="MapsResources"/> class.
        /// </summary>
        public MapsResources()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapsResources"/> class.
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public MapsResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        {
        }
        #endregion

        /// <summary>
        /// Gets Title for the Users list widget resources class.
        /// </summary>
        [ResourceEntry("ZoomLevel",
            Value = "Zoom Level",
            Description = "Zoom Level.")]
        public string ZoomLevel
        {
            get
            {
                return this["ZoomLevel"];
            }
        }

        /// <summary>
        /// Gets the display.
        /// </summary>
        /// <value>The display.</value>
        [ResourceEntry("Template",
            Value = "Template",
            Description = "word : Template")]
             public string Template
        {
            get
            {
                return this["Template"];
            }
        }

        /// <summary>
        /// Gets phrase: Adds the front end job search component
        /// </summary>
        [ResourceEntry("AddMarker",
            Value = "Add Marker",
            Description = "phrase : Add Marker")]
        public string AddMarker
        {
            get
            {
                return this["AddMarker"];
            }
        }

        /// <summary>
        /// Gets phrase: Remove the front end job search component
        /// </summary>
        [ResourceEntry("DeleteMarker",
            Value = "Delete",
            Description = "phrase : Remove the Marker")]
        public string DeleteMarker
        {
            get
            {
                return this["DeleteMarker"];
            }
        }

        /// <summary>
        /// Gets phrase : More options
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
    }
}
