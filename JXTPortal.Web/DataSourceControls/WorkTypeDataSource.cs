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
	/// Represents the DataRepository.WorkTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(WorkTypeDataSourceDesigner))]
	public class WorkTypeDataSource : ProviderDataSource<WorkType, WorkTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WorkTypeDataSource class.
		/// </summary>
		public WorkTypeDataSource() : base(new WorkTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the WorkTypeDataSourceView used by the WorkTypeDataSource.
		/// </summary>
		protected WorkTypeDataSourceView WorkTypeView
		{
			get { return ( View as WorkTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the WorkTypeDataSource control invokes to retrieve data.
		/// </summary>
		public WorkTypeSelectMethod SelectMethod
		{
			get
			{
				WorkTypeSelectMethod selectMethod = WorkTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (WorkTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the WorkTypeDataSourceView class that is to be
		/// used by the WorkTypeDataSource.
		/// </summary>
		/// <returns>An instance of the WorkTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<WorkType, WorkTypeKey> GetNewDataSourceView()
		{
			return new WorkTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the WorkTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class WorkTypeDataSourceView : ProviderDataSourceView<WorkType, WorkTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WorkTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the WorkTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public WorkTypeDataSourceView(WorkTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal WorkTypeDataSource WorkTypeOwner
		{
			get { return Owner as WorkTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal WorkTypeSelectMethod SelectMethod
		{
			get { return WorkTypeOwner.SelectMethod; }
			set { WorkTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal WorkTypeService WorkTypeProvider
		{
			get { return Provider as WorkTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<WorkType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<WorkType> results = null;
			WorkType item;
			count = 0;
			
			System.Int32 _workTypeId;

			switch ( SelectMethod )
			{
				case WorkTypeSelectMethod.Get:
					WorkTypeKey entityKey  = new WorkTypeKey();
					entityKey.Load(values);
					item = WorkTypeProvider.Get(entityKey);
					results = new TList<WorkType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case WorkTypeSelectMethod.GetAll:
                    results = WorkTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case WorkTypeSelectMethod.GetPaged:
					results = WorkTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case WorkTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = WorkTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = WorkTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case WorkTypeSelectMethod.GetByWorkTypeId:
					_workTypeId = ( values["WorkTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["WorkTypeId"], typeof(System.Int32)) : (int)0;
					item = WorkTypeProvider.GetByWorkTypeId(_workTypeId);
					results = new TList<WorkType>();
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
			if ( SelectMethod == WorkTypeSelectMethod.Get || SelectMethod == WorkTypeSelectMethod.GetByWorkTypeId )
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
				WorkType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					WorkTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<WorkType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			WorkTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region WorkTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the WorkTypeDataSource class.
	/// </summary>
	public class WorkTypeDataSourceDesigner : ProviderDataSourceDesigner<WorkType, WorkTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the WorkTypeDataSourceDesigner class.
		/// </summary>
		public WorkTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public WorkTypeSelectMethod SelectMethod
		{
			get { return ((WorkTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new WorkTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region WorkTypeDataSourceActionList

	/// <summary>
	/// Supports the WorkTypeDataSourceDesigner class.
	/// </summary>
	internal class WorkTypeDataSourceActionList : DesignerActionList
	{
		private WorkTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the WorkTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public WorkTypeDataSourceActionList(WorkTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public WorkTypeSelectMethod SelectMethod
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

	#endregion WorkTypeDataSourceActionList
	
	#endregion WorkTypeDataSourceDesigner
	
	#region WorkTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the WorkTypeDataSource.SelectMethod property.
	/// </summary>
	public enum WorkTypeSelectMethod
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
		/// Represents the GetByWorkTypeId method.
		/// </summary>
		GetByWorkTypeId
	}
	
	#endregion WorkTypeSelectMethod

	#region WorkTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WorkType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WorkTypeFilter : SqlFilter<WorkTypeColumn>
	{
	}
	
	#endregion WorkTypeFilter

	#region WorkTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WorkType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WorkTypeExpressionBuilder : SqlExpressionBuilder<WorkTypeColumn>
	{
	}
	
	#endregion WorkTypeExpressionBuilder	

	#region WorkTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;WorkTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="WorkType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WorkTypeProperty : ChildEntityProperty<WorkTypeChildEntityTypes>
	{
	}
	
	#endregion WorkTypeProperty
}

