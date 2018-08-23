using System;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace JXTNext.Sitefinity.Common.Constants
{
    public class DynamicTypeConstants
    {

        #region Article

        /// <summary>
        /// Contains constants (fields and type info) for the Articles type.
        /// </summary>
        public class Article
        {

            /// <summary>
            /// Fully qualified type name for the Articles type.
            /// </summary>
            public const string FullTypeName = "Telerik.Sitefinity.DynamicTypes.Model.Articles.Article";

            /// <summary>
            /// Resolved System.Type for the Articles type.
            /// </summary>
            public static readonly Type ResolvedType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.Articles.Article");

            /// <summary>
            /// Contains the fields for the Articles type.
            /// </summary>
            public class Fields
            {

                /// <summary>
                /// Name of the Title field (Title) of type ShortText 
                /// Required
                /// </summary>
                public const string Title = "Title";

                /// <summary>
                /// Name of the Content field (Content) of type LongText 
                /// </summary>
                public const string Content = "Content";

                /// <summary>
                /// Name of the Summary field (Summary) of type ShortText 
                /// </summary>
                public const string Summary = "Summary";

                /// <summary>
                /// Name of the Categories field (Category) of type Classification 
                /// </summary>
                public const string Category = "Category";

                /// <summary>
                /// Name of the Header image field (HeaderImage) of type RelatedMedia  - Telerik.Sitefinity.Libraries.Model.Image
                /// </summary>
                public const string HeaderImage = "HeaderImage";

            }
        }

        #endregion

        #region Pressrelease

        /// <summary>
        /// Contains constants (fields and type info) for the PressReleases type.
        /// </summary>
        public class Pressrelease
        {

            /// <summary>
            /// Fully qualified type name for the PressReleases type.
            /// </summary>
            public const string FullTypeName = "Telerik.Sitefinity.DynamicTypes.Model.PressReleases.Pressrelease";

            /// <summary>
            /// Resolved System.Type for the PressReleases type.
            /// </summary>
            public static readonly Type ResolvedType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.PressReleases.Pressrelease");

            /// <summary>
            /// Contains the fields for the PressReleases type.
            /// </summary>
            public class Fields
            {

                /// <summary>
                /// Name of the Title field (Title) of type ShortText 
                /// Required
                /// </summary>
                public const string Title = "Title";

                /// <summary>
                /// Name of the Issue date field (IssueDate) of type DateTime 
                /// Required
                /// </summary>
                public const string IssueDate = "IssueDate";

            }
        }

        #endregion
    }
}