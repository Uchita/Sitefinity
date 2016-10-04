	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using JXTPortal.Entities;
using JXTPortal.Entities.Validation;

using JXTPortal.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using JXTPortal.Common;

#endregion

namespace JXTPortal
{		
	/// <summary>
	/// An component type implementation of the 'News' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class NewsService : JXTPortal.NewsServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the NewsService class.
		/// </summary>
		public NewsService() : base()
		{
		}
		#endregion Constructors

        public override bool Insert(News entity)
        {
            return base.Insert(SearchIndex(entity));
        }

        public override bool Update(News entity)
        {
            return base.Update(SearchIndex(entity));
        }

        private News SearchIndex(News entity)
        {
            try
            {
                NewsCategoriesService newsCategoryService = new NewsCategoriesService();
                using (NewsCategories newsCategory = newsCategoryService.GetByNewsCategoryId(entity.NewsCategoryId))
                {
                    if (newsCategory != null)
                    {
                        // Strip HTML and Remove multiple Spaces
                        entity.SearchField = String.Format("{0} {1} {2}",
                                                            Utils.SpecialCharsSearchField(entity.Subject),
                                                            Utils.SpecialCharsSearchField(newsCategory.NewsCategoryName),
                                                            Utils.CleanStringSpaces(Utils.StripHTML(Utils.SpecialCharsSearchField(entity.Content))));

                        // Decode the &amp; &lt; etc
                        entity.SearchField = System.Web.HttpUtility.HtmlDecode(entity.SearchField);
                    }
                    else
                        entity.SearchField = string.Empty;
                }
            }
            catch
            {
                entity.SearchField = string.Empty;
            }
            
            return entity;
        }
		
	}//End Class

} // end namespace
