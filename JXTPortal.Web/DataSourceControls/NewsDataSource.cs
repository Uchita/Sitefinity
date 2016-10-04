#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using JXTPortal.Entities;
using JXTPortal.Data;
using JXTPortal.Data.Bases;
using JXTPortal;
#endregion

namespace JXTPortal.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.NewsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(NewsDataSourceDesigner))]
	public class NewsDataSource : ProviderDataSource<News, NewsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsDataSource class.
		/// </summary>
		public NewsDataSource() : base(new NewsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the NewsDataSourceView used by the NewsDataSource.
		/// </summary>
		protected NewsDataSourceView NewsView
		{
			get { return ( View as NewsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the NewsDataSource control invokes to retrieve data.
		/// </summary>
		public NewsSelectMethod SelectMethod
		{
			get
			{
				NewsSelectMethod selectMethod = NewsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (NewsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the NewsDataSourceView class that is to be
		/// used by the NewsDataSource.
		/// </summary>
		/// <returns>An instance of the NewsDataSourceView class.</returns>
		protected override BaseDataSourceView<News, NewsKey> GetNewDataSourceView()
		{
			return new NewsDataSourceView(this, DefaultViewName);
		}
		
		/// <summary>
        /// Creates a cache hashing key based on the startIndex, pageSize and the SelectMethod being used.
        /// </summary>
        /// <param name="startIndex">The current start row index.</param>
        /// <param name="pageSize">The current page size.</param>
        /// <returns>A string that can be used as a key for caching purposes.</returns>
		protected override string CacheHashKey(int startIndex, int pageSize)
        {
			return String.Format("{0}:{1}:{2}", SelectMethod, startIndex, pageSize);
        }
		
		#endregion Methods
	}
	
	/// <summary>
	/// Supports the NewsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class NewsDataSourceView : ProviderDataSourceView<News, NewsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the NewsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public NewsDataSourceView(NewsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal NewsDataSource NewsOwner
		{
			get { return Owner as NewsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal NewsSelectMethod SelectMethod
		{
			get { return NewsOwner.SelectMethod; }
			set { NewsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal NewsService NewsProvider
		{
			get { return Provider as NewsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<News> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<News> results = null;
			News item;
			count = 0;
			
			System.Int32 _newsId;
			System.Int32 _lastModifiedBy;
			System.Int32 _newsCategoryId;
			System.Int32 _siteId;
			System.Int32? sp748_SiteId;
			System.Int32? sp748_NewsCategoryId;
			System.String sp748_Keyword;
			System.String sp748_OrderBy;

			switch ( SelectMethod )
			{
				case NewsSelectMethod.Get:
					NewsKey entityKey  = new NewsKey();
					entityKey.Load(values);
					item = NewsProvider.Get(entityKey);
					results = new TList<News>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case NewsSelectMethod.GetAll:
                    results = NewsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case NewsSelectMethod.GetPaged:
					results = NewsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case NewsSelectMethod.Find:
					if ( FilterParameters != null )
						results = NewsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = NewsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case NewsSelectMethod.GetByNewsId:
					_newsId = ( values["NewsId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["NewsId"], typeof(System.Int32)) : (int)0;
					item = NewsProvider.GetByNewsId(_newsId);
					results = new TList<News>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case NewsSelectMethod.GetByLastModifiedBy:
					_lastModifiedBy = ( values["LastModifiedBy"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LastModifiedBy"], typeof(System.Int32)) : (int)0;
					results = NewsProvider.GetByLastModifiedBy(_lastModifiedBy, this.StartIndex, this.PageSize, out count);
					break;
				case NewsSelectMethod.GetByNewsCategoryId:
					_newsCategoryId = ( values["NewsCategoryId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["NewsCategoryId"], typeof(System.Int32)) : (int)0;
					results = NewsProvider.GetByNewsCategoryId(_newsCategoryId, this.StartIndex, this.PageSize, out count);
					break;
				case NewsSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = NewsProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
				case NewsSelectMethod.CustomGetNews:
					sp748_SiteId = (System.Int32?) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32?));
					sp748_NewsCategoryId = (System.Int32?) EntityUtil.ChangeType(values["NewsCategoryId"], typeof(System.Int32?));
					sp748_Keyword = (System.String) EntityUtil.ChangeType(values["Keyword"], typeof(System.String));
					sp748_OrderBy = (System.String) EntityUtil.ChangeType(values["OrderBy"], typeof(System.String));
					results = NewsProvider.CustomGetNews(sp748_SiteId, sp748_NewsCategoryId, sp748_Keyword, sp748_OrderBy, StartIndex, PageSize);
					break;
				default:
					break;
			}

			if ( results != null && count < 1 )
			{
				count = results.Count;

				if ( !String.IsNullOrEmpty(CustomMethodRecordCountParamName) )
				{
					object objCustomCount = EntityUtil.ChangeType(customOutput[CustomMethodRecordCountParamName], typeof(Int32));
					
					if ( objCustomCount != null )
					{
						count = (int) objCustomCount;
					}
				}
			}
			
			return results;
		}
		
		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		protected override void GetSelectParameters(IDictionary values)
		{
			if ( SelectMethod == NewsSelectMethod.Get || SelectMethod == NewsSelectMethod.GetByNewsId )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				News entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					NewsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
					// set loaded flag
					IsDeepLoaded = true;
				}
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation on the specified entity collection.
		/// </summary>
		/// <param name="entityList"></param>
		/// <param name="properties"></param>
		internal override void DeepLoad(TList<News> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			NewsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region NewsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the NewsDataSource class.
	/// </summary>
	public class NewsDataSourceDesigner : ProviderDataSourceDesigner<News, NewsKey>
	{
		/// <summary>
		/// Initializes a new instance of the NewsDataSourceDesigner class.
		/// </summary>
		public NewsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public NewsSelectMethod SelectMethod
		{
			get { return ((NewsDataSource) DataSource).SelectMethod; }
			set { SetPropertyValue("SelectMethod", value); }
		}

		/// <summary>Gets the designer action list collection for this designer.</summary>
		/// <returns>The <see cref="T:System.ComponentModel.Design.DesignerActionListCollection"/>
		/// associated with this designer.</returns>
		public override DesignerActionListCollection ActionLists
		{
			get
			{
				DesignerActionListCollection actions = new DesignerActionListCollection();
				actions.Add(new NewsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region NewsDataSourceActionList

	/// <summary>
	/// Supports the NewsDataSourceDesigner class.
	/// </summary>
	internal class NewsDataSourceActionList : DesignerActionList
	{
		private NewsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the NewsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public NewsDataSourceActionList(NewsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public NewsSelectMethod SelectMethod
		{
			get { return _designer.SelectMethod; }
			set { _designer.SelectMethod = value; }
		}

		/// <summary>
		/// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// objects contained in the list.
		/// </summary>
		/// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// array that contains the items in this list.</returns>
		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection items = new DesignerActionItemCollection();
			items.Add(new DesignerActionPropertyItem("SelectMethod", "Select Method", "Methods"));
			return items;
		}
	}

	#endregion NewsDataSourceActionList
	
	#endregion NewsDataSourceDesigner
	
	#region NewsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the NewsDataSource.SelectMethod property.
	/// </summary>
	public enum NewsSelectMethod
	{
		/// <summary>
		/// Represents the Get method.
		/// </summary>
		Get,
		/// <summary>
		/// Represents the GetAll method.
		/// </summary>
		GetAll,
		/// <summary>
		/// Represents the GetPaged method.
		/// </summary>
		GetPaged,
		/// <summary>
		/// Represents the Find method.
		/// </summary>
		Find,
		/// <summary>
		/// Represents the GetByNewsId method.
		/// </summary>
		GetByNewsId,
		/// <summary>
		/// Represents the GetByLastModifiedBy method.
		/// </summary>
		GetByLastModifiedBy,
		/// <summary>
		/// Represents the GetByNewsCategoryId method.
		/// </summary>
		GetByNewsCategoryId,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId,
		/// <summary>
		/// Represents the CustomGetNews method.
		/// </summary>
		CustomGetNews
	}
	
	#endregion NewsSelectMethod

	#region NewsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="News"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NewsFilter : SqlFilter<NewsColumn>
	{
	}
	
	#endregion NewsFilter

	#region NewsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="News"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NewsExpressionBuilder : SqlExpressionBuilder<NewsColumn>
	{
	}
	
	#endregion NewsExpressionBuilder	

	#region NewsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;NewsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="News"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NewsProperty : ChildEntityProperty<NewsChildEntityTypes>
	{
	}
	
	#endregion NewsProperty
}

