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
	/// Represents the DataRepository.AreaProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AreaDataSourceDesigner))]
	public class AreaDataSource : ProviderDataSource<Area, AreaKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AreaDataSource class.
		/// </summary>
		public AreaDataSource() : base(new AreaService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AreaDataSourceView used by the AreaDataSource.
		/// </summary>
		protected AreaDataSourceView AreaView
		{
			get { return ( View as AreaDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AreaDataSource control invokes to retrieve data.
		/// </summary>
		public AreaSelectMethod SelectMethod
		{
			get
			{
				AreaSelectMethod selectMethod = AreaSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AreaSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AreaDataSourceView class that is to be
		/// used by the AreaDataSource.
		/// </summary>
		/// <returns>An instance of the AreaDataSourceView class.</returns>
		protected override BaseDataSourceView<Area, AreaKey> GetNewDataSourceView()
		{
			return new AreaDataSourceView(this, DefaultViewName);
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
	/// Supports the AreaDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AreaDataSourceView : ProviderDataSourceView<Area, AreaKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AreaDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AreaDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AreaDataSourceView(AreaDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AreaDataSource AreaOwner
		{
			get { return Owner as AreaDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AreaSelectMethod SelectMethod
		{
			get { return AreaOwner.SelectMethod; }
			set { AreaOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AreaService AreaProvider
		{
			get { return Provider as AreaService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Area> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Area> results = null;
			Area item;
			count = 0;
			
			System.Int32 _areaId;
			System.Int32 _locationId;
			System.Int32? sp85_LocationId;
			System.Boolean? sp82_SearchUsingOr;
			System.Int32? sp82_AreaId;
			System.String sp82_AreaName;
			System.Int32? sp82_LocationId;
			System.Boolean? sp82_Valid;
			System.Int32? sp84_AreaId;

			switch ( SelectMethod )
			{
				case AreaSelectMethod.Get:
					AreaKey entityKey  = new AreaKey();
					entityKey.Load(values);
					item = AreaProvider.Get(entityKey);
					results = new TList<Area>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AreaSelectMethod.GetAll:
                    results = AreaProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AreaSelectMethod.GetPaged:
					results = AreaProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AreaSelectMethod.Find:
					if ( FilterParameters != null )
						results = AreaProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AreaProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AreaSelectMethod.GetByAreaId:
					_areaId = ( values["AreaId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AreaId"], typeof(System.Int32)) : (int)0;
					item = AreaProvider.GetByAreaId(_areaId);
					results = new TList<Area>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case AreaSelectMethod.GetByLocationId:
					_locationId = ( values["LocationId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LocationId"], typeof(System.Int32)) : (int)0;
					results = AreaProvider.GetByLocationId(_locationId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
				
				case AreaSelectMethod.Get_List:
					results = AreaProvider.Get_List(StartIndex, PageSize);
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
			if ( SelectMethod == AreaSelectMethod.Get || SelectMethod == AreaSelectMethod.GetByAreaId )
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
				Area entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AreaProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Area> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AreaProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AreaDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AreaDataSource class.
	/// </summary>
	public class AreaDataSourceDesigner : ProviderDataSourceDesigner<Area, AreaKey>
	{
		/// <summary>
		/// Initializes a new instance of the AreaDataSourceDesigner class.
		/// </summary>
		public AreaDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AreaSelectMethod SelectMethod
		{
			get { return ((AreaDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AreaDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AreaDataSourceActionList

	/// <summary>
	/// Supports the AreaDataSourceDesigner class.
	/// </summary>
	internal class AreaDataSourceActionList : DesignerActionList
	{
		private AreaDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AreaDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AreaDataSourceActionList(AreaDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AreaSelectMethod SelectMethod
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

	#endregion AreaDataSourceActionList
	
	#endregion AreaDataSourceDesigner
	
	#region AreaSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AreaDataSource.SelectMethod property.
	/// </summary>
	public enum AreaSelectMethod
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
		/// Represents the GetByAreaId method.
		/// </summary>
		GetByAreaId,
		/// <summary>
		/// Represents the GetByLocationId method.
		/// </summary>
		GetByLocationId,
		/// <summary>
		/// Represents the Get_List method.
		/// </summary>
		Get_List
	}
	
	#endregion AreaSelectMethod

	#region AreaFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Area"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AreaFilter : SqlFilter<AreaColumn>
	{
	}
	
	#endregion AreaFilter

	#region AreaExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Area"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AreaExpressionBuilder : SqlExpressionBuilder<AreaColumn>
	{
	}
	
	#endregion AreaExpressionBuilder	

	#region AreaProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AreaChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Area"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AreaProperty : ChildEntityProperty<AreaChildEntityTypes>
	{
	}
	
	#endregion AreaProperty
}

