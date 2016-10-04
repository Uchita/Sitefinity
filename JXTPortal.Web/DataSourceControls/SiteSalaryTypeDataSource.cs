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
	/// Represents the DataRepository.SiteSalaryTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SiteSalaryTypeDataSourceDesigner))]
	public class SiteSalaryTypeDataSource : ProviderDataSource<SiteSalaryType, SiteSalaryTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteSalaryTypeDataSource class.
		/// </summary>
		public SiteSalaryTypeDataSource() : base(new SiteSalaryTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SiteSalaryTypeDataSourceView used by the SiteSalaryTypeDataSource.
		/// </summary>
		protected SiteSalaryTypeDataSourceView SiteSalaryTypeView
		{
			get { return ( View as SiteSalaryTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SiteSalaryTypeDataSource control invokes to retrieve data.
		/// </summary>
		public SiteSalaryTypeSelectMethod SelectMethod
		{
			get
			{
				SiteSalaryTypeSelectMethod selectMethod = SiteSalaryTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SiteSalaryTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SiteSalaryTypeDataSourceView class that is to be
		/// used by the SiteSalaryTypeDataSource.
		/// </summary>
		/// <returns>An instance of the SiteSalaryTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<SiteSalaryType, SiteSalaryTypeKey> GetNewDataSourceView()
		{
			return new SiteSalaryTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the SiteSalaryTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SiteSalaryTypeDataSourceView : ProviderDataSourceView<SiteSalaryType, SiteSalaryTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteSalaryTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SiteSalaryTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SiteSalaryTypeDataSourceView(SiteSalaryTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SiteSalaryTypeDataSource SiteSalaryTypeOwner
		{
			get { return Owner as SiteSalaryTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SiteSalaryTypeSelectMethod SelectMethod
		{
			get { return SiteSalaryTypeOwner.SelectMethod; }
			set { SiteSalaryTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SiteSalaryTypeService SiteSalaryTypeProvider
		{
			get { return Provider as SiteSalaryTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SiteSalaryType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SiteSalaryType> results = null;
			SiteSalaryType item;
			count = 0;
			
			System.Int32 _siteSalaryTypeId;
			System.Int32 _salaryTypeId;
			System.Int32 _siteId;

			switch ( SelectMethod )
			{
				case SiteSalaryTypeSelectMethod.Get:
					SiteSalaryTypeKey entityKey  = new SiteSalaryTypeKey();
					entityKey.Load(values);
					item = SiteSalaryTypeProvider.Get(entityKey);
					results = new TList<SiteSalaryType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SiteSalaryTypeSelectMethod.GetAll:
                    results = SiteSalaryTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SiteSalaryTypeSelectMethod.GetPaged:
					results = SiteSalaryTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SiteSalaryTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = SiteSalaryTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SiteSalaryTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SiteSalaryTypeSelectMethod.GetBySiteSalaryTypeId:
					_siteSalaryTypeId = ( values["SiteSalaryTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteSalaryTypeId"], typeof(System.Int32)) : (int)0;
					item = SiteSalaryTypeProvider.GetBySiteSalaryTypeId(_siteSalaryTypeId);
					results = new TList<SiteSalaryType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case SiteSalaryTypeSelectMethod.GetBySalaryTypeId:
					_salaryTypeId = ( values["SalaryTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalaryTypeId"], typeof(System.Int32)) : (int)0;
					results = SiteSalaryTypeProvider.GetBySalaryTypeId(_salaryTypeId, this.StartIndex, this.PageSize, out count);
					break;
				case SiteSalaryTypeSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = SiteSalaryTypeProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == SiteSalaryTypeSelectMethod.Get || SelectMethod == SiteSalaryTypeSelectMethod.GetBySiteSalaryTypeId )
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
				SiteSalaryType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SiteSalaryTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SiteSalaryType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SiteSalaryTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SiteSalaryTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SiteSalaryTypeDataSource class.
	/// </summary>
	public class SiteSalaryTypeDataSourceDesigner : ProviderDataSourceDesigner<SiteSalaryType, SiteSalaryTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the SiteSalaryTypeDataSourceDesigner class.
		/// </summary>
		public SiteSalaryTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SiteSalaryTypeSelectMethod SelectMethod
		{
			get { return ((SiteSalaryTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SiteSalaryTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SiteSalaryTypeDataSourceActionList

	/// <summary>
	/// Supports the SiteSalaryTypeDataSourceDesigner class.
	/// </summary>
	internal class SiteSalaryTypeDataSourceActionList : DesignerActionList
	{
		private SiteSalaryTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SiteSalaryTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SiteSalaryTypeDataSourceActionList(SiteSalaryTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SiteSalaryTypeSelectMethod SelectMethod
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

	#endregion SiteSalaryTypeDataSourceActionList
	
	#endregion SiteSalaryTypeDataSourceDesigner
	
	#region SiteSalaryTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SiteSalaryTypeDataSource.SelectMethod property.
	/// </summary>
	public enum SiteSalaryTypeSelectMethod
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
		/// Represents the GetBySiteSalaryTypeId method.
		/// </summary>
		GetBySiteSalaryTypeId,
		/// <summary>
		/// Represents the GetBySalaryTypeId method.
		/// </summary>
		GetBySalaryTypeId,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId
	}
	
	#endregion SiteSalaryTypeSelectMethod

	#region SiteSalaryTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteSalaryType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteSalaryTypeFilter : SqlFilter<SiteSalaryTypeColumn>
	{
	}
	
	#endregion SiteSalaryTypeFilter

	#region SiteSalaryTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteSalaryType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteSalaryTypeExpressionBuilder : SqlExpressionBuilder<SiteSalaryTypeColumn>
	{
	}
	
	#endregion SiteSalaryTypeExpressionBuilder	

	#region SiteSalaryTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SiteSalaryTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SiteSalaryType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteSalaryTypeProperty : ChildEntityProperty<SiteSalaryTypeChildEntityTypes>
	{
	}
	
	#endregion SiteSalaryTypeProperty
}

