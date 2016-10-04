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
	/// Represents the DataRepository.SiteWorkTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SiteWorkTypeDataSourceDesigner))]
	public class SiteWorkTypeDataSource : ProviderDataSource<SiteWorkType, SiteWorkTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteWorkTypeDataSource class.
		/// </summary>
		public SiteWorkTypeDataSource() : base(new SiteWorkTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SiteWorkTypeDataSourceView used by the SiteWorkTypeDataSource.
		/// </summary>
		protected SiteWorkTypeDataSourceView SiteWorkTypeView
		{
			get { return ( View as SiteWorkTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SiteWorkTypeDataSource control invokes to retrieve data.
		/// </summary>
		public SiteWorkTypeSelectMethod SelectMethod
		{
			get
			{
				SiteWorkTypeSelectMethod selectMethod = SiteWorkTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SiteWorkTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SiteWorkTypeDataSourceView class that is to be
		/// used by the SiteWorkTypeDataSource.
		/// </summary>
		/// <returns>An instance of the SiteWorkTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<SiteWorkType, SiteWorkTypeKey> GetNewDataSourceView()
		{
			return new SiteWorkTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the SiteWorkTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SiteWorkTypeDataSourceView : ProviderDataSourceView<SiteWorkType, SiteWorkTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteWorkTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SiteWorkTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SiteWorkTypeDataSourceView(SiteWorkTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SiteWorkTypeDataSource SiteWorkTypeOwner
		{
			get { return Owner as SiteWorkTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SiteWorkTypeSelectMethod SelectMethod
		{
			get { return SiteWorkTypeOwner.SelectMethod; }
			set { SiteWorkTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SiteWorkTypeService SiteWorkTypeProvider
		{
			get { return Provider as SiteWorkTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SiteWorkType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SiteWorkType> results = null;
			SiteWorkType item;
			count = 0;
			
			System.Int32 _siteWorkTypeId;
			System.Int32 _siteId;
			System.Int32 _workTypeId;
			System.Int32? sp647_WorkTypeId;
			System.Int32? sp645_SiteId;
			System.String sp645_FriendlyUrl;
			System.Int32? sp644_SiteId;
			System.Int32? sp646_SiteWorkTypeId;
			System.Boolean? sp642_SearchUsingOr;
			System.Int32? sp642_SiteWorkTypeId;
			System.Int32? sp642_SiteId;
			System.Int32? sp642_WorkTypeId;
			System.String sp642_SiteWorkTypeName;
			System.Boolean? sp642_Valid;
			System.Int32? sp642_Sequence;
			System.String sp642_SiteWorkTypeFriendlyUrl;

			switch ( SelectMethod )
			{
				case SiteWorkTypeSelectMethod.Get:
					SiteWorkTypeKey entityKey  = new SiteWorkTypeKey();
					entityKey.Load(values);
					item = SiteWorkTypeProvider.Get(entityKey);
					results = new TList<SiteWorkType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SiteWorkTypeSelectMethod.GetAll:
                    results = SiteWorkTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SiteWorkTypeSelectMethod.GetPaged:
					results = SiteWorkTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SiteWorkTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = SiteWorkTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SiteWorkTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SiteWorkTypeSelectMethod.GetBySiteWorkTypeId:
					_siteWorkTypeId = ( values["SiteWorkTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteWorkTypeId"], typeof(System.Int32)) : (int)0;
					item = SiteWorkTypeProvider.GetBySiteWorkTypeId(_siteWorkTypeId);
					results = new TList<SiteWorkType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case SiteWorkTypeSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = SiteWorkTypeProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
					break;
				case SiteWorkTypeSelectMethod.GetByWorkTypeId:
					_workTypeId = ( values["WorkTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["WorkTypeId"], typeof(System.Int32)) : (int)0;
					results = SiteWorkTypeProvider.GetByWorkTypeId(_workTypeId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
				
				case SiteWorkTypeSelectMethod.Get_List:
					results = SiteWorkTypeProvider.Get_List(StartIndex, PageSize);
					break;
				case SiteWorkTypeSelectMethod.GetBySiteIdFriendlyUrl:
					sp645_SiteId = (System.Int32?) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32?));
					sp645_FriendlyUrl = (System.String) EntityUtil.ChangeType(values["FriendlyUrl"], typeof(System.String));
					results = SiteWorkTypeProvider.GetBySiteIdFriendlyUrl(sp645_SiteId, sp645_FriendlyUrl, StartIndex, PageSize);
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
			if ( SelectMethod == SiteWorkTypeSelectMethod.Get || SelectMethod == SiteWorkTypeSelectMethod.GetBySiteWorkTypeId )
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
				SiteWorkType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SiteWorkTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SiteWorkType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SiteWorkTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SiteWorkTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SiteWorkTypeDataSource class.
	/// </summary>
	public class SiteWorkTypeDataSourceDesigner : ProviderDataSourceDesigner<SiteWorkType, SiteWorkTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the SiteWorkTypeDataSourceDesigner class.
		/// </summary>
		public SiteWorkTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SiteWorkTypeSelectMethod SelectMethod
		{
			get { return ((SiteWorkTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SiteWorkTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SiteWorkTypeDataSourceActionList

	/// <summary>
	/// Supports the SiteWorkTypeDataSourceDesigner class.
	/// </summary>
	internal class SiteWorkTypeDataSourceActionList : DesignerActionList
	{
		private SiteWorkTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SiteWorkTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SiteWorkTypeDataSourceActionList(SiteWorkTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SiteWorkTypeSelectMethod SelectMethod
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

	#endregion SiteWorkTypeDataSourceActionList
	
	#endregion SiteWorkTypeDataSourceDesigner
	
	#region SiteWorkTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SiteWorkTypeDataSource.SelectMethod property.
	/// </summary>
	public enum SiteWorkTypeSelectMethod
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
		/// Represents the GetBySiteWorkTypeId method.
		/// </summary>
		GetBySiteWorkTypeId,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId,
		/// <summary>
		/// Represents the GetByWorkTypeId method.
		/// </summary>
		GetByWorkTypeId,
		/// <summary>
		/// Represents the Get_List method.
		/// </summary>
		Get_List,
		/// <summary>
		/// Represents the GetBySiteIdFriendlyUrl method.
		/// </summary>
		GetBySiteIdFriendlyUrl
	}
	
	#endregion SiteWorkTypeSelectMethod

	#region SiteWorkTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteWorkType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteWorkTypeFilter : SqlFilter<SiteWorkTypeColumn>
	{
	}
	
	#endregion SiteWorkTypeFilter

	#region SiteWorkTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteWorkType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteWorkTypeExpressionBuilder : SqlExpressionBuilder<SiteWorkTypeColumn>
	{
	}
	
	#endregion SiteWorkTypeExpressionBuilder	

	#region SiteWorkTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SiteWorkTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SiteWorkType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteWorkTypeProperty : ChildEntityProperty<SiteWorkTypeChildEntityTypes>
	{
	}
	
	#endregion SiteWorkTypeProperty
}

