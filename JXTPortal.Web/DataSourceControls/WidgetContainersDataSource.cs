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
	/// Represents the DataRepository.WidgetContainersProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(WidgetContainersDataSourceDesigner))]
	public class WidgetContainersDataSource : ProviderDataSource<WidgetContainers, WidgetContainersKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WidgetContainersDataSource class.
		/// </summary>
		public WidgetContainersDataSource() : base(new WidgetContainersService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the WidgetContainersDataSourceView used by the WidgetContainersDataSource.
		/// </summary>
		protected WidgetContainersDataSourceView WidgetContainersView
		{
			get { return ( View as WidgetContainersDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the WidgetContainersDataSource control invokes to retrieve data.
		/// </summary>
		public WidgetContainersSelectMethod SelectMethod
		{
			get
			{
				WidgetContainersSelectMethod selectMethod = WidgetContainersSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (WidgetContainersSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the WidgetContainersDataSourceView class that is to be
		/// used by the WidgetContainersDataSource.
		/// </summary>
		/// <returns>An instance of the WidgetContainersDataSourceView class.</returns>
		protected override BaseDataSourceView<WidgetContainers, WidgetContainersKey> GetNewDataSourceView()
		{
			return new WidgetContainersDataSourceView(this, DefaultViewName);
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
	/// Supports the WidgetContainersDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class WidgetContainersDataSourceView : ProviderDataSourceView<WidgetContainers, WidgetContainersKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WidgetContainersDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the WidgetContainersDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public WidgetContainersDataSourceView(WidgetContainersDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal WidgetContainersDataSource WidgetContainersOwner
		{
			get { return Owner as WidgetContainersDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal WidgetContainersSelectMethod SelectMethod
		{
			get { return WidgetContainersOwner.SelectMethod; }
			set { WidgetContainersOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal WidgetContainersService WidgetContainersProvider
		{
			get { return Provider as WidgetContainersService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<WidgetContainers> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<WidgetContainers> results = null;
			WidgetContainers item;
			count = 0;
			
			System.Int32 _widgetId;
			System.Int32? _defaultProfessionId_nullable;
			System.Int32? _defaultCountryId_nullable;
			System.Int32? _defaultLocationId_nullable;
			System.Int32 _languageId;
			System.Int32 _siteId;

			switch ( SelectMethod )
			{
				case WidgetContainersSelectMethod.Get:
					WidgetContainersKey entityKey  = new WidgetContainersKey();
					entityKey.Load(values);
					item = WidgetContainersProvider.Get(entityKey);
					results = new TList<WidgetContainers>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case WidgetContainersSelectMethod.GetAll:
                    results = WidgetContainersProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case WidgetContainersSelectMethod.GetPaged:
					results = WidgetContainersProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case WidgetContainersSelectMethod.Find:
					if ( FilterParameters != null )
						results = WidgetContainersProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = WidgetContainersProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case WidgetContainersSelectMethod.GetByWidgetId:
					_widgetId = ( values["WidgetId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["WidgetId"], typeof(System.Int32)) : (int)0;
					item = WidgetContainersProvider.GetByWidgetId(_widgetId);
					results = new TList<WidgetContainers>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case WidgetContainersSelectMethod.GetByDefaultProfessionId:
					_defaultProfessionId_nullable = (System.Int32?) EntityUtil.ChangeType(values["DefaultProfessionId"], typeof(System.Int32?));
					results = WidgetContainersProvider.GetByDefaultProfessionId(_defaultProfessionId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case WidgetContainersSelectMethod.GetByDefaultCountryId:
					_defaultCountryId_nullable = (System.Int32?) EntityUtil.ChangeType(values["DefaultCountryId"], typeof(System.Int32?));
					results = WidgetContainersProvider.GetByDefaultCountryId(_defaultCountryId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case WidgetContainersSelectMethod.GetByDefaultLocationId:
					_defaultLocationId_nullable = (System.Int32?) EntityUtil.ChangeType(values["DefaultLocationId"], typeof(System.Int32?));
					results = WidgetContainersProvider.GetByDefaultLocationId(_defaultLocationId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case WidgetContainersSelectMethod.GetByLanguageId:
					_languageId = ( values["LanguageId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LanguageId"], typeof(System.Int32)) : (int)0;
					results = WidgetContainersProvider.GetByLanguageId(_languageId, this.StartIndex, this.PageSize, out count);
					break;
				case WidgetContainersSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = WidgetContainersProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == WidgetContainersSelectMethod.Get || SelectMethod == WidgetContainersSelectMethod.GetByWidgetId )
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
				WidgetContainers entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					WidgetContainersProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<WidgetContainers> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			WidgetContainersProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region WidgetContainersDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the WidgetContainersDataSource class.
	/// </summary>
	public class WidgetContainersDataSourceDesigner : ProviderDataSourceDesigner<WidgetContainers, WidgetContainersKey>
	{
		/// <summary>
		/// Initializes a new instance of the WidgetContainersDataSourceDesigner class.
		/// </summary>
		public WidgetContainersDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public WidgetContainersSelectMethod SelectMethod
		{
			get { return ((WidgetContainersDataSource) DataSource).SelectMethod; }
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
				actions.Add(new WidgetContainersDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region WidgetContainersDataSourceActionList

	/// <summary>
	/// Supports the WidgetContainersDataSourceDesigner class.
	/// </summary>
	internal class WidgetContainersDataSourceActionList : DesignerActionList
	{
		private WidgetContainersDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the WidgetContainersDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public WidgetContainersDataSourceActionList(WidgetContainersDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public WidgetContainersSelectMethod SelectMethod
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

	#endregion WidgetContainersDataSourceActionList
	
	#endregion WidgetContainersDataSourceDesigner
	
	#region WidgetContainersSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the WidgetContainersDataSource.SelectMethod property.
	/// </summary>
	public enum WidgetContainersSelectMethod
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
		/// Represents the GetByWidgetId method.
		/// </summary>
		GetByWidgetId,
		/// <summary>
		/// Represents the GetByDefaultProfessionId method.
		/// </summary>
		GetByDefaultProfessionId,
		/// <summary>
		/// Represents the GetByDefaultCountryId method.
		/// </summary>
		GetByDefaultCountryId,
		/// <summary>
		/// Represents the GetByDefaultLocationId method.
		/// </summary>
		GetByDefaultLocationId,
		/// <summary>
		/// Represents the GetByLanguageId method.
		/// </summary>
		GetByLanguageId,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId
	}
	
	#endregion WidgetContainersSelectMethod

	#region WidgetContainersFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WidgetContainers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WidgetContainersFilter : SqlFilter<WidgetContainersColumn>
	{
	}
	
	#endregion WidgetContainersFilter

	#region WidgetContainersExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WidgetContainers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WidgetContainersExpressionBuilder : SqlExpressionBuilder<WidgetContainersColumn>
	{
	}
	
	#endregion WidgetContainersExpressionBuilder	

	#region WidgetContainersProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;WidgetContainersChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="WidgetContainers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WidgetContainersProperty : ChildEntityProperty<WidgetContainersChildEntityTypes>
	{
	}
	
	#endregion WidgetContainersProperty
}

