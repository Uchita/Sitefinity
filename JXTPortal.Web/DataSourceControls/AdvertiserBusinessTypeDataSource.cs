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
	/// Represents the DataRepository.AdvertiserBusinessTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AdvertiserBusinessTypeDataSourceDesigner))]
	public class AdvertiserBusinessTypeDataSource : ProviderDataSource<AdvertiserBusinessType, AdvertiserBusinessTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserBusinessTypeDataSource class.
		/// </summary>
		public AdvertiserBusinessTypeDataSource() : base(new AdvertiserBusinessTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AdvertiserBusinessTypeDataSourceView used by the AdvertiserBusinessTypeDataSource.
		/// </summary>
		protected AdvertiserBusinessTypeDataSourceView AdvertiserBusinessTypeView
		{
			get { return ( View as AdvertiserBusinessTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AdvertiserBusinessTypeDataSource control invokes to retrieve data.
		/// </summary>
		public AdvertiserBusinessTypeSelectMethod SelectMethod
		{
			get
			{
				AdvertiserBusinessTypeSelectMethod selectMethod = AdvertiserBusinessTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AdvertiserBusinessTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AdvertiserBusinessTypeDataSourceView class that is to be
		/// used by the AdvertiserBusinessTypeDataSource.
		/// </summary>
		/// <returns>An instance of the AdvertiserBusinessTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<AdvertiserBusinessType, AdvertiserBusinessTypeKey> GetNewDataSourceView()
		{
			return new AdvertiserBusinessTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the AdvertiserBusinessTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AdvertiserBusinessTypeDataSourceView : ProviderDataSourceView<AdvertiserBusinessType, AdvertiserBusinessTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserBusinessTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AdvertiserBusinessTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AdvertiserBusinessTypeDataSourceView(AdvertiserBusinessTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AdvertiserBusinessTypeDataSource AdvertiserBusinessTypeOwner
		{
			get { return Owner as AdvertiserBusinessTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AdvertiserBusinessTypeSelectMethod SelectMethod
		{
			get { return AdvertiserBusinessTypeOwner.SelectMethod; }
			set { AdvertiserBusinessTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AdvertiserBusinessTypeService AdvertiserBusinessTypeProvider
		{
			get { return Provider as AdvertiserBusinessTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AdvertiserBusinessType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AdvertiserBusinessType> results = null;
			AdvertiserBusinessType item;
			count = 0;
			
			System.Int32 _advertiserBusinessTypeId;

			switch ( SelectMethod )
			{
				case AdvertiserBusinessTypeSelectMethod.Get:
					AdvertiserBusinessTypeKey entityKey  = new AdvertiserBusinessTypeKey();
					entityKey.Load(values);
					item = AdvertiserBusinessTypeProvider.Get(entityKey);
					results = new TList<AdvertiserBusinessType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AdvertiserBusinessTypeSelectMethod.GetAll:
                    results = AdvertiserBusinessTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AdvertiserBusinessTypeSelectMethod.GetPaged:
					results = AdvertiserBusinessTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AdvertiserBusinessTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = AdvertiserBusinessTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AdvertiserBusinessTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AdvertiserBusinessTypeSelectMethod.GetByAdvertiserBusinessTypeId:
					_advertiserBusinessTypeId = ( values["AdvertiserBusinessTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AdvertiserBusinessTypeId"], typeof(System.Int32)) : (int)0;
					item = AdvertiserBusinessTypeProvider.GetByAdvertiserBusinessTypeId(_advertiserBusinessTypeId);
					results = new TList<AdvertiserBusinessType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
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
			if ( SelectMethod == AdvertiserBusinessTypeSelectMethod.Get || SelectMethod == AdvertiserBusinessTypeSelectMethod.GetByAdvertiserBusinessTypeId )
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
				AdvertiserBusinessType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AdvertiserBusinessTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AdvertiserBusinessType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AdvertiserBusinessTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AdvertiserBusinessTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AdvertiserBusinessTypeDataSource class.
	/// </summary>
	public class AdvertiserBusinessTypeDataSourceDesigner : ProviderDataSourceDesigner<AdvertiserBusinessType, AdvertiserBusinessTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the AdvertiserBusinessTypeDataSourceDesigner class.
		/// </summary>
		public AdvertiserBusinessTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdvertiserBusinessTypeSelectMethod SelectMethod
		{
			get { return ((AdvertiserBusinessTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AdvertiserBusinessTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AdvertiserBusinessTypeDataSourceActionList

	/// <summary>
	/// Supports the AdvertiserBusinessTypeDataSourceDesigner class.
	/// </summary>
	internal class AdvertiserBusinessTypeDataSourceActionList : DesignerActionList
	{
		private AdvertiserBusinessTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AdvertiserBusinessTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AdvertiserBusinessTypeDataSourceActionList(AdvertiserBusinessTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdvertiserBusinessTypeSelectMethod SelectMethod
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

	#endregion AdvertiserBusinessTypeDataSourceActionList
	
	#endregion AdvertiserBusinessTypeDataSourceDesigner
	
	#region AdvertiserBusinessTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AdvertiserBusinessTypeDataSource.SelectMethod property.
	/// </summary>
	public enum AdvertiserBusinessTypeSelectMethod
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
		/// Represents the GetByAdvertiserBusinessTypeId method.
		/// </summary>
		GetByAdvertiserBusinessTypeId
	}
	
	#endregion AdvertiserBusinessTypeSelectMethod

	#region AdvertiserBusinessTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserBusinessType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserBusinessTypeFilter : SqlFilter<AdvertiserBusinessTypeColumn>
	{
	}
	
	#endregion AdvertiserBusinessTypeFilter

	#region AdvertiserBusinessTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserBusinessType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserBusinessTypeExpressionBuilder : SqlExpressionBuilder<AdvertiserBusinessTypeColumn>
	{
	}
	
	#endregion AdvertiserBusinessTypeExpressionBuilder	

	#region AdvertiserBusinessTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AdvertiserBusinessTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserBusinessType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserBusinessTypeProperty : ChildEntityProperty<AdvertiserBusinessTypeChildEntityTypes>
	{
	}
	
	#endregion AdvertiserBusinessTypeProperty
}

