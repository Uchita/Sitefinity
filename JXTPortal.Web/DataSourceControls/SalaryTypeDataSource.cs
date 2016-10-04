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
	/// Represents the DataRepository.SalaryTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SalaryTypeDataSourceDesigner))]
	public class SalaryTypeDataSource : ProviderDataSource<SalaryType, SalaryTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalaryTypeDataSource class.
		/// </summary>
		public SalaryTypeDataSource() : base(new SalaryTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SalaryTypeDataSourceView used by the SalaryTypeDataSource.
		/// </summary>
		protected SalaryTypeDataSourceView SalaryTypeView
		{
			get { return ( View as SalaryTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SalaryTypeDataSource control invokes to retrieve data.
		/// </summary>
		public SalaryTypeSelectMethod SelectMethod
		{
			get
			{
				SalaryTypeSelectMethod selectMethod = SalaryTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SalaryTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SalaryTypeDataSourceView class that is to be
		/// used by the SalaryTypeDataSource.
		/// </summary>
		/// <returns>An instance of the SalaryTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<SalaryType, SalaryTypeKey> GetNewDataSourceView()
		{
			return new SalaryTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the SalaryTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SalaryTypeDataSourceView : ProviderDataSourceView<SalaryType, SalaryTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalaryTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SalaryTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SalaryTypeDataSourceView(SalaryTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SalaryTypeDataSource SalaryTypeOwner
		{
			get { return Owner as SalaryTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SalaryTypeSelectMethod SelectMethod
		{
			get { return SalaryTypeOwner.SelectMethod; }
			set { SalaryTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SalaryTypeService SalaryTypeProvider
		{
			get { return Provider as SalaryTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SalaryType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SalaryType> results = null;
			SalaryType item;
			count = 0;
			
			System.Int32 _salaryTypeId;

			switch ( SelectMethod )
			{
				case SalaryTypeSelectMethod.Get:
					SalaryTypeKey entityKey  = new SalaryTypeKey();
					entityKey.Load(values);
					item = SalaryTypeProvider.Get(entityKey);
					results = new TList<SalaryType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SalaryTypeSelectMethod.GetAll:
                    results = SalaryTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SalaryTypeSelectMethod.GetPaged:
					results = SalaryTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SalaryTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = SalaryTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SalaryTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SalaryTypeSelectMethod.GetBySalaryTypeId:
					_salaryTypeId = ( values["SalaryTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalaryTypeId"], typeof(System.Int32)) : (int)0;
					item = SalaryTypeProvider.GetBySalaryTypeId(_salaryTypeId);
					results = new TList<SalaryType>();
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
			if ( SelectMethod == SalaryTypeSelectMethod.Get || SelectMethod == SalaryTypeSelectMethod.GetBySalaryTypeId )
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
				SalaryType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SalaryTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SalaryType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SalaryTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SalaryTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SalaryTypeDataSource class.
	/// </summary>
	public class SalaryTypeDataSourceDesigner : ProviderDataSourceDesigner<SalaryType, SalaryTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the SalaryTypeDataSourceDesigner class.
		/// </summary>
		public SalaryTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SalaryTypeSelectMethod SelectMethod
		{
			get { return ((SalaryTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SalaryTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SalaryTypeDataSourceActionList

	/// <summary>
	/// Supports the SalaryTypeDataSourceDesigner class.
	/// </summary>
	internal class SalaryTypeDataSourceActionList : DesignerActionList
	{
		private SalaryTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SalaryTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SalaryTypeDataSourceActionList(SalaryTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SalaryTypeSelectMethod SelectMethod
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

	#endregion SalaryTypeDataSourceActionList
	
	#endregion SalaryTypeDataSourceDesigner
	
	#region SalaryTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SalaryTypeDataSource.SelectMethod property.
	/// </summary>
	public enum SalaryTypeSelectMethod
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
		/// Represents the GetBySalaryTypeId method.
		/// </summary>
		GetBySalaryTypeId
	}
	
	#endregion SalaryTypeSelectMethod

	#region SalaryTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalaryType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalaryTypeFilter : SqlFilter<SalaryTypeColumn>
	{
	}
	
	#endregion SalaryTypeFilter

	#region SalaryTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalaryType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalaryTypeExpressionBuilder : SqlExpressionBuilder<SalaryTypeColumn>
	{
	}
	
	#endregion SalaryTypeExpressionBuilder	

	#region SalaryTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SalaryTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SalaryType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalaryTypeProperty : ChildEntityProperty<SalaryTypeChildEntityTypes>
	{
	}
	
	#endregion SalaryTypeProperty
}

