using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace JXTNext.Sitefinity.Frontend.Mvc.StringResources
{
    [ObjectInfo(typeof(SocialLinkResources), ResourceClassId = "SocialLinkResources", Title = "SocialLinkResourcesTitle", Description = "SocialLinkResourcesDescription")]
    public class SocialLinkResources : Resource
    {
        #region Constructions

        /// <summary>
        /// Initializes a new instance of the <see cref="SocialLinkResources" /> class.
        /// </summary>
        public SocialLinkResources()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SocialLinkResources" /> class.
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public SocialLinkResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        {
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets phrase: Which sharing options you want to use?
        /// </summary>
        [ResourceEntry("SocialLinkOptions",
            Value = "Which social link options you want to use?",
            Description = "phrase : Which social link options you want to use?")]
        public string SocialLinkOptions
        {
            get
            {
                return this["SocialLinkOptions"];
            }
        }

        /// <summary>
        /// Gets phrase: Which sharing options you want to use?
        /// </summary>
        [ResourceEntry("SocialLinkSelectCheckbox",
            Value = "Please select the checkbox and enter full path in corresponding text box",
            Description = "phrase : Please select the checkbox and enter full path in corresponding text box")]
        public string SocialLinkSelectCheckbox
        {
            get
            {
                return this["SocialLinkSelectCheckbox"];
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