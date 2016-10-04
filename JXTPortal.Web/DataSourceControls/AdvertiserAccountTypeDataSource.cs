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
	/// Represents the DataRepository.AdvertiserAccountTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AdvertiserAccountTypeDataSourceDesigner))]
	public class AdvertiserAccountTypeDataSource : ProviderDataSource<AdvertiserAccountType, AdvertiserAccountTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountTypeDataSource class.
		/// </summary>
		public AdvertiserAccountTypeDataSource() : base(new AdvertiserAccountTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AdvertiserAccountTypeDataSourceView used by the AdvertiserAccountTypeDataSource.
		/// </summary>
		protected AdvertiserAccountTypeDataSourceView AdvertiserAccountTypeView
		{
			get { return ( View as AdvertiserAccountTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AdvertiserAccountTypeDataSource control invokes to retrieve data.
		/// </summary>
		public AdvertiserAccountTypeSelectMethod SelectMethod
		{
			get
			{
				AdvertiserAccountTypeSelectMethod selectMethod = AdvertiserAccountTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AdvertiserAccountTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AdvertiserAccountTypeDataSourceView class that is to be
		/// used by the AdvertiserAccountTypeDataSource.
		/// </summary>
		/// <returns>An instance of the AdvertiserAccountTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<AdvertiserAccountType, AdvertiserAccountTypeKey> GetNewDataSourceView()
		{
			return new AdvertiserAccountTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the AdvertiserAccountTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AdvertiserAccountTypeDataSourceView : ProviderDataSourceView<AdvertiserAccountType, AdvertiserAccountTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AdvertiserAccountTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AdvertiserAccountTypeDataSourceView(AdvertiserAccountTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AdvertiserAccountTypeDataSource AdvertiserAccountTypeOwner
		{
			get { return Owner as AdvertiserAccountTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AdvertiserAccountTypeSelectMethod SelectMethod
		{
			get { return AdvertiserAccountTypeOwner.SelectMethod; }
			set { AdvertiserAccountTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AdvertiserAccountTypeService AdvertiserAccountTypeProvider
		{
			get { return Provider as AdvertiserAccountTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AdvertiserAccountType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AdvertiserAccountType> results = null;
			AdvertiserAccountType item;
			count = 0;
			
			System.Int32 _advertiserAccountTypeId;

			switch ( SelectMethod )
			{
				case AdvertiserAccountTypeSelectMethod.Get:
					AdvertiserAccountTypeKey entityKey  = new AdvertiserAccountTypeKey();
					entityKey.Load(values);
					item = AdvertiserAccountTypeProvider.Get(entityKey);
					results = new TList<AdvertiserAccountType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AdvertiserAccountTypeSelectMethod.GetAll:
                    results = AdvertiserAccountTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AdvertiserAccountTypeSelectMethod.GetPaged:
					results = AdvertiserAccountTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AdvertiserAccountTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = AdvertiserAccountTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AdvertiserAccountTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AdvertiserAccountTypeSelectMethod.GetByAdvertiserAccountTypeId:
					_advertiserAccountTypeId = ( values["AdvertiserAccountTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AdvertiserAccountTypeId"], typeof(System.Int32)) : (int)0;
					item = AdvertiserAccountTypeProvider.GetByAdvertiserAccountTypeId(_advertiserAccountTypeId);
					results = new TList<AdvertiserAccountType>();
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
			if ( SelectMethod == AdvertiserAccountTypeSelectMethod.Get || SelectMethod == AdvertiserAccountTypeSelectMethod.GetByAdvertiserAccountTypeId )
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
				AdvertiserAccountType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AdvertiserAccountTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AdvertiserAccountType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AdvertiserAccountTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AdvertiserAccountTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AdvertiserAccountTypeDataSource class.
	/// </summary>
	public class AdvertiserAccountTypeDataSourceDesigner : ProviderDataSourceDesigner<AdvertiserAccountType, AdvertiserAccountTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountTypeDataSourceDesigner class.
		/// </summary>
		public AdvertiserAccountTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdvertiserAccountTypeSelectMethod SelectMethod
		{
			get { return ((AdvertiserAccountTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AdvertiserAccountTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AdvertiserAccountTypeDataSourceActionList

	/// <summary>
	/// Supports the AdvertiserAccountTypeDataSourceDesigner class.
	/// </summary>
	internal class AdvertiserAccountTypeDataSourceActionList : DesignerActionList
	{
		private AdvertiserAccountTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AdvertiserAccountTypeDataSourceActionList(AdvertiserAccountTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdvertiserAccountTypeSelectMethod SelectMethod
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

	#endregion AdvertiserAccountTypeDataSourceActionList
	
	#endregion AdvertiserAccountTypeDataSourceDesigner
	
	#region AdvertiserAccountTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AdvertiserAccountTypeDataSource.SelectMethod property.
	/// </summary>
	public enum AdvertiserAccountTypeSelectMethod
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
		/// Represents the GetByAdvertiserAccountTypeId method.
		/// </summary>
		GetByAdvertiserAccountTypeId
	}
	
	#endregion AdvertiserAccountTypeSelectMethod

	#region AdvertiserAccountTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserAccountType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserAccountTypeFilter : SqlFilter<AdvertiserAccountTypeColumn>
	{
	}
	
	#endregion AdvertiserAccountTypeFilter

	#region AdvertiserAccountTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserAccountType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserAccountTypeExpressionBuilder : SqlExpressionBuilder<AdvertiserAccountTypeColumn>
	{
	}
	
	#endregion AdvertiserAccountTypeExpressionBuilder	

	#region AdvertiserAccountTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AdvertiserAccountTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserAccountType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserAccountTypeProperty : ChildEntityProperty<AdvertiserAccountTypeChildEntityTypes>
	{
	}
	
	#endregion AdvertiserAccountTypeProperty
}

