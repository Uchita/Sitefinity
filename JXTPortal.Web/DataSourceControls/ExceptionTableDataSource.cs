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
	/// Represents the DataRepository.ExceptionTableProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ExceptionTableDataSourceDesigner))]
	public class ExceptionTableDataSource : ProviderDataSource<ExceptionTable, ExceptionTableKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ExceptionTableDataSource class.
		/// </summary>
		public ExceptionTableDataSource() : base(new ExceptionTableService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ExceptionTableDataSourceView used by the ExceptionTableDataSource.
		/// </summary>
		protected ExceptionTableDataSourceView ExceptionTableView
		{
			get { return ( View as ExceptionTableDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ExceptionTableDataSource control invokes to retrieve data.
		/// </summary>
		public ExceptionTableSelectMethod SelectMethod
		{
			get
			{
				ExceptionTableSelectMethod selectMethod = ExceptionTableSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ExceptionTableSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ExceptionTableDataSourceView class that is to be
		/// used by the ExceptionTableDataSource.
		/// </summary>
		/// <returns>An instance of the ExceptionTableDataSourceView class.</returns>
		protected override BaseDataSourceView<ExceptionTable, ExceptionTableKey> GetNewDataSourceView()
		{
			return new ExceptionTableDataSourceView(this, DefaultViewName);
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
	/// Supports the ExceptionTableDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ExceptionTableDataSourceView : ProviderDataSourceView<ExceptionTable, ExceptionTableKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ExceptionTableDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ExceptionTableDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ExceptionTableDataSourceView(ExceptionTableDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ExceptionTableDataSource ExceptionTableOwner
		{
			get { return Owner as ExceptionTableDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ExceptionTableSelectMethod SelectMethod
		{
			get { return ExceptionTableOwner.SelectMethod; }
			set { ExceptionTableOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ExceptionTableService ExceptionTableProvider
		{
			get { return Provider as ExceptionTableService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ExceptionTable> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ExceptionTable> results = null;
			ExceptionTable item;
			count = 0;
			
			System.Int32 _exceptionId;

			switch ( SelectMethod )
			{
				case ExceptionTableSelectMethod.Get:
					ExceptionTableKey entityKey  = new ExceptionTableKey();
					entityKey.Load(values);
					item = ExceptionTableProvider.Get(entityKey);
					results = new TList<ExceptionTable>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ExceptionTableSelectMethod.GetAll:
                    results = ExceptionTableProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ExceptionTableSelectMethod.GetPaged:
					results = ExceptionTableProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ExceptionTableSelectMethod.Find:
					if ( FilterParameters != null )
						results = ExceptionTableProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ExceptionTableProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ExceptionTableSelectMethod.GetByExceptionId:
					_exceptionId = ( values["ExceptionId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ExceptionId"], typeof(System.Int32)) : (int)0;
					item = ExceptionTableProvider.GetByExceptionId(_exceptionId);
					results = new TList<ExceptionTable>();
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
			if ( SelectMethod == ExceptionTableSelectMethod.Get || SelectMethod == ExceptionTableSelectMethod.GetByExceptionId )
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
				ExceptionTable entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ExceptionTableProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ExceptionTable> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ExceptionTableProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ExceptionTableDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ExceptionTableDataSource class.
	/// </summary>
	public class ExceptionTableDataSourceDesigner : ProviderDataSourceDesigner<ExceptionTable, ExceptionTableKey>
	{
		/// <summary>
		/// Initializes a new instance of the ExceptionTableDataSourceDesigner class.
		/// </summary>
		public ExceptionTableDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ExceptionTableSelectMethod SelectMethod
		{
			get { return ((ExceptionTableDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ExceptionTableDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ExceptionTableDataSourceActionList

	/// <summary>
	/// Supports the ExceptionTableDataSourceDesigner class.
	/// </summary>
	internal class ExceptionTableDataSourceActionList : DesignerActionList
	{
		private ExceptionTableDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ExceptionTableDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ExceptionTableDataSourceActionList(ExceptionTableDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ExceptionTableSelectMethod SelectMethod
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

	#endregion ExceptionTableDataSourceActionList
	
	#endregion ExceptionTableDataSourceDesigner
	
	#region ExceptionTableSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ExceptionTableDataSource.SelectMethod property.
	/// </summary>
	public enum ExceptionTableSelectMethod
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
		/// Represents the GetByExceptionId method.
		/// </summary>
		GetByExceptionId
	}
	
	#endregion ExceptionTableSelectMethod

	#region ExceptionTableFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ExceptionTable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ExceptionTableFilter : SqlFilter<ExceptionTableColumn>
	{
	}
	
	#endregion ExceptionTableFilter

	#region ExceptionTableExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ExceptionTable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ExceptionTableExpressionBuilder : SqlExpressionBuilder<ExceptionTableColumn>
	{
	}
	
	#endregion ExceptionTableExpressionBuilder	

	#region ExceptionTableProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ExceptionTableChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ExceptionTable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ExceptionTableProperty : ChildEntityProperty<ExceptionTableChildEntityTypes>
	{
	}
	
	#endregion ExceptionTableProperty
}

