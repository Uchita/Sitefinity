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
	/// Represents the DataRepository.DynamicpagesCustomWidgetProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DynamicpagesCustomWidgetDataSourceDesigner))]
	public class DynamicpagesCustomWidgetDataSource : ProviderDataSource<DynamicpagesCustomWidget, DynamicpagesCustomWidgetKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicpagesCustomWidgetDataSource class.
		/// </summary>
		public DynamicpagesCustomWidgetDataSource() : base(new DynamicpagesCustomWidgetService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DynamicpagesCustomWidgetDataSourceView used by the DynamicpagesCustomWidgetDataSource.
		/// </summary>
		protected DynamicpagesCustomWidgetDataSourceView DynamicpagesCustomWidgetView
		{
			get { return ( View as DynamicpagesCustomWidgetDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DynamicpagesCustomWidgetDataSource control invokes to retrieve data.
		/// </summary>
		public DynamicpagesCustomWidgetSelectMethod SelectMethod
		{
			get
			{
				DynamicpagesCustomWidgetSelectMethod selectMethod = DynamicpagesCustomWidgetSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DynamicpagesCustomWidgetSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DynamicpagesCustomWidgetDataSourceView class that is to be
		/// used by the DynamicpagesCustomWidgetDataSource.
		/// </summary>
		/// <returns>An instance of the DynamicpagesCustomWidgetDataSourceView class.</returns>
		protected override BaseDataSourceView<DynamicpagesCustomWidget, DynamicpagesCustomWidgetKey> GetNewDataSourceView()
		{
			return new DynamicpagesCustomWidgetDataSourceView(this, DefaultViewName);
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
	/// Supports the DynamicpagesCustomWidgetDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DynamicpagesCustomWidgetDataSourceView : ProviderDataSourceView<DynamicpagesCustomWidget, DynamicpagesCustomWidgetKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicpagesCustomWidgetDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DynamicpagesCustomWidgetDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DynamicpagesCustomWidgetDataSourceView(DynamicpagesCustomWidgetDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DynamicpagesCustomWidgetDataSource DynamicpagesCustomWidgetOwner
		{
			get { return Owner as DynamicpagesCustomWidgetDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DynamicpagesCustomWidgetSelectMethod SelectMethod
		{
			get { return DynamicpagesCustomWidgetOwner.SelectMethod; }
			set { DynamicpagesCustomWidgetOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DynamicpagesCustomWidgetService DynamicpagesCustomWidgetProvider
		{
			get { return Provider as DynamicpagesCustomWidgetService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<DynamicpagesCustomWidget> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<DynamicpagesCustomWidget> results = null;
			DynamicpagesCustomWidget item;
			count = 0;
			
			System.Int32 _dynamicPageId;
			System.Int32 _customWidgetId;
			System.Int32 _position;
			System.Int32? sp209_DynamicPageId;
			System.Int32? sp209_CustomWidgetId;
			System.Int32? sp209_Position;

			switch ( SelectMethod )
			{
				case DynamicpagesCustomWidgetSelectMethod.Get:
					DynamicpagesCustomWidgetKey entityKey  = new DynamicpagesCustomWidgetKey();
					entityKey.Load(values);
					item = DynamicpagesCustomWidgetProvider.Get(entityKey);
					results = new TList<DynamicpagesCustomWidget>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DynamicpagesCustomWidgetSelectMethod.GetAll:
                    results = DynamicpagesCustomWidgetProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case DynamicpagesCustomWidgetSelectMethod.GetPaged:
					results = DynamicpagesCustomWidgetProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DynamicpagesCustomWidgetSelectMethod.Find:
					if ( FilterParameters != null )
						results = DynamicpagesCustomWidgetProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DynamicpagesCustomWidgetProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DynamicpagesCustomWidgetSelectMethod.GetByDynamicPageIdCustomWidgetIdPosition:
					_dynamicPageId = ( values["DynamicPageId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DynamicPageId"], typeof(System.Int32)) : (int)0;
					_customWidgetId = ( values["CustomWidgetId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomWidgetId"], typeof(System.Int32)) : (int)0;
					_position = ( values["Position"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Position"], typeof(System.Int32)) : (int)0;
					item = DynamicpagesCustomWidgetProvider.GetByDynamicPageIdCustomWidgetIdPosition(_dynamicPageId, _customWidgetId, _position);
					results = new TList<DynamicpagesCustomWidget>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case DynamicpagesCustomWidgetSelectMethod.GetByCustomWidgetId:
					_customWidgetId = ( values["CustomWidgetId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomWidgetId"], typeof(System.Int32)) : (int)0;
					results = DynamicpagesCustomWidgetProvider.GetByCustomWidgetId(_customWidgetId, this.StartIndex, this.PageSize, out count);
					break;
				case DynamicpagesCustomWidgetSelectMethod.GetByDynamicPageId:
					_dynamicPageId = ( values["DynamicPageId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DynamicPageId"], typeof(System.Int32)) : (int)0;
					results = DynamicpagesCustomWidgetProvider.GetByDynamicPageId(_dynamicPageId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
				case DynamicpagesCustomWidgetSelectMethod.CustomSelect:
					sp209_DynamicPageId = (System.Int32?) EntityUtil.ChangeType(values["DynamicPageId"], typeof(System.Int32?));
					sp209_CustomWidgetId = (System.Int32?) EntityUtil.ChangeType(values["CustomWidgetId"], typeof(System.Int32?));
					sp209_Position = (System.Int32?) EntityUtil.ChangeType(values["Position"], typeof(System.Int32?));
					results = DynamicpagesCustomWidgetProvider.CustomSelect(sp209_DynamicPageId, sp209_CustomWidgetId, sp209_Position, StartIndex, PageSize);
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
			if ( SelectMethod == DynamicpagesCustomWidgetSelectMethod.Get || SelectMethod == DynamicpagesCustomWidgetSelectMethod.GetByDynamicPageIdCustomWidgetIdPosition )
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
				DynamicpagesCustomWidget entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					DynamicpagesCustomWidgetProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<DynamicpagesCustomWidget> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			DynamicpagesCustomWidgetProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DynamicpagesCustomWidgetDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DynamicpagesCustomWidgetDataSource class.
	/// </summary>
	public class DynamicpagesCustomWidgetDataSourceDesigner : ProviderDataSourceDesigner<DynamicpagesCustomWidget, DynamicpagesCustomWidgetKey>
	{
		/// <summary>
		/// Initializes a new instance of the DynamicpagesCustomWidgetDataSourceDesigner class.
		/// </summary>
		public DynamicpagesCustomWidgetDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DynamicpagesCustomWidgetSelectMethod SelectMethod
		{
			get { return ((DynamicpagesCustomWidgetDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DynamicpagesCustomWidgetDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DynamicpagesCustomWidgetDataSourceActionList

	/// <summary>
	/// Supports the DynamicpagesCustomWidgetDataSourceDesigner class.
	/// </summary>
	internal class DynamicpagesCustomWidgetDataSourceActionList : DesignerActionList
	{
		private DynamicpagesCustomWidgetDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DynamicpagesCustomWidgetDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DynamicpagesCustomWidgetDataSourceActionList(DynamicpagesCustomWidgetDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DynamicpagesCustomWidgetSelectMethod SelectMethod
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

	#endregion DynamicpagesCustomWidgetDataSourceActionList
	
	#endregion DynamicpagesCustomWidgetDataSourceDesigner
	
	#region DynamicpagesCustomWidgetSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DynamicpagesCustomWidgetDataSource.SelectMethod property.
	/// </summary>
	public enum DynamicpagesCustomWidgetSelectMethod
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
		/// Represents the GetByDynamicPageIdCustomWidgetIdPosition method.
		/// </summary>
		GetByDynamicPageIdCustomWidgetIdPosition,
		/// <summary>
		/// Represents the GetByCustomWidgetId method.
		/// </summary>
		GetByCustomWidgetId,
		/// <summary>
		/// Represents the GetByDynamicPageId method.
		/// </summary>
		GetByDynamicPageId,
		/// <summary>
		/// Represents the CustomSelect method.
		/// </summary>
		CustomSelect
	}
	
	#endregion DynamicpagesCustomWidgetSelectMethod

	#region DynamicpagesCustomWidgetFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicpagesCustomWidget"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicpagesCustomWidgetFilter : SqlFilter<DynamicpagesCustomWidgetColumn>
	{
	}
	
	#endregion DynamicpagesCustomWidgetFilter

	#region DynamicpagesCustomWidgetExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicpagesCustomWidget"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicpagesCustomWidgetExpressionBuilder : SqlExpressionBuilder<DynamicpagesCustomWidgetColumn>
	{
	}
	
	#endregion DynamicpagesCustomWidgetExpressionBuilder	

	#region DynamicpagesCustomWidgetProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DynamicpagesCustomWidgetChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicpagesCustomWidget"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicpagesCustomWidgetProperty : ChildEntityProperty<DynamicpagesCustomWidgetChildEntityTypes>
	{
	}
	
	#endregion DynamicpagesCustomWidgetProperty
}

