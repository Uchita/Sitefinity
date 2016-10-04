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
	/// Represents the DataRepository.NewsCategoriesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(NewsCategoriesDataSourceDesigner))]
	public class NewsCategoriesDataSource : ProviderDataSource<NewsCategories, NewsCategoriesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsCategoriesDataSource class.
		/// </summary>
		public NewsCategoriesDataSource() : base(new NewsCategoriesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the NewsCategoriesDataSourceView used by the NewsCategoriesDataSource.
		/// </summary>
		protected NewsCategoriesDataSourceView NewsCategoriesView
		{
			get { return ( View as NewsCategoriesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the NewsCategoriesDataSource control invokes to retrieve data.
		/// </summary>
		public NewsCategoriesSelectMethod SelectMethod
		{
			get
			{
				NewsCategoriesSelectMethod selectMethod = NewsCategoriesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (NewsCategoriesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the NewsCategoriesDataSourceView class that is to be
		/// used by the NewsCategoriesDataSource.
		/// </summary>
		/// <returns>An instance of the NewsCategoriesDataSourceView class.</returns>
		protected override BaseDataSourceView<NewsCategories, NewsCategoriesKey> GetNewDataSourceView()
		{
			return new NewsCategoriesDataSourceView(this, DefaultViewName);
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
	/// Supports the NewsCategoriesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class NewsCategoriesDataSourceView : ProviderDataSourceView<NewsCategories, NewsCategoriesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsCategoriesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the NewsCategoriesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public NewsCategoriesDataSourceView(NewsCategoriesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal NewsCategoriesDataSource NewsCategoriesOwner
		{
			get { return Owner as NewsCategoriesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal NewsCategoriesSelectMethod SelectMethod
		{
			get { return NewsCategoriesOwner.SelectMethod; }
			set { NewsCategoriesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal NewsCategoriesService NewsCategoriesProvider
		{
			get { return Provider as NewsCategoriesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<NewsCategories> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<NewsCategories> results = null;
			NewsCategories item;
			count = 0;
			
			System.Int32 _newsCategoryId;
			System.Int32 _lastModifiedBy;
			System.Int32 _siteId;

			switch ( SelectMethod )
			{
				case NewsCategoriesSelectMethod.Get:
					NewsCategoriesKey entityKey  = new NewsCategoriesKey();
					entityKey.Load(values);
					item = NewsCategoriesProvider.Get(entityKey);
					results = new TList<NewsCategories>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case NewsCategoriesSelectMethod.GetAll:
                    results = NewsCategoriesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case NewsCategoriesSelectMethod.GetPaged:
					results = NewsCategoriesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case NewsCategoriesSelectMethod.Find:
					if ( FilterParameters != null )
						results = NewsCategoriesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = NewsCategoriesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case NewsCategoriesSelectMethod.GetByNewsCategoryId:
					_newsCategoryId = ( values["NewsCategoryId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["NewsCategoryId"], typeof(System.Int32)) : (int)0;
					item = NewsCategoriesProvider.GetByNewsCategoryId(_newsCategoryId);
					results = new TList<NewsCategories>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case NewsCategoriesSelectMethod.GetByLastModifiedBy:
					_lastModifiedBy = ( values["LastModifiedBy"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LastModifiedBy"], typeof(System.Int32)) : (int)0;
					results = NewsCategoriesProvider.GetByLastModifiedBy(_lastModifiedBy, this.StartIndex, this.PageSize, out count);
					break;
				case NewsCategoriesSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = NewsCategoriesProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
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
			if ( SelectMethod == NewsCategoriesSelectMethod.Get || SelectMethod == NewsCategoriesSelectMethod.GetByNewsCategoryId )
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
				NewsCategories entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					NewsCategoriesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<NewsCategories> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			NewsCategoriesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region NewsCategoriesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the NewsCategoriesDataSource class.
	/// </summary>
	public class NewsCategoriesDataSourceDesigner : ProviderDataSourceDesigner<NewsCategories, NewsCategoriesKey>
	{
		/// <summary>
		/// Initializes a new instance of the NewsCategoriesDataSourceDesigner class.
		/// </summary>
		public NewsCategoriesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public NewsCategoriesSelectMethod SelectMethod
		{
			get { return ((NewsCategoriesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new NewsCategoriesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region NewsCategoriesDataSourceActionList

	/// <summary>
	/// Supports the NewsCategoriesDataSourceDesigner class.
	/// </summary>
	internal class NewsCategoriesDataSourceActionList : DesignerActionList
	{
		private NewsCategoriesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the NewsCategoriesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public NewsCategoriesDataSourceActionList(NewsCategoriesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public NewsCategoriesSelectMethod SelectMethod
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

	#endregion NewsCategoriesDataSourceActionList
	
	#endregion NewsCategoriesDataSourceDesigner
	
	#region NewsCategoriesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the NewsCategoriesDataSource.SelectMethod property.
	/// </summary>
	public enum NewsCategoriesSelectMethod
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
		/// Represents the GetByNewsCategoryId method.
		/// </summary>
		GetByNewsCategoryId,
		/// <summary>
		/// Represents the GetByLastModifiedBy method.
		/// </summary>
		GetByLastModifiedBy,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId
	}
	
	#endregion NewsCategoriesSelectMethod

	#region NewsCategoriesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NewsCategories"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NewsCategoriesFilter : SqlFilter<NewsCategoriesColumn>
	{
	}
	
	#endregion NewsCategoriesFilter

	#region NewsCategoriesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NewsCategories"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NewsCategoriesExpressionBuilder : SqlExpressionBuilder<NewsCategoriesColumn>
	{
	}
	
	#endregion NewsCategoriesExpressionBuilder	

	#region NewsCategoriesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;NewsCategoriesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="NewsCategories"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NewsCategoriesProperty : ChildEntityProperty<NewsCategoriesChildEntityTypes>
	{
	}
	
	#endregion NewsCategoriesProperty
}

