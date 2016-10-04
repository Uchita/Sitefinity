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
	/// Represents the DataRepository.SiteAdvertiserFilterProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SiteAdvertiserFilterDataSourceDesigner))]
	public class SiteAdvertiserFilterDataSource : ProviderDataSource<SiteAdvertiserFilter, SiteAdvertiserFilterKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteAdvertiserFilterDataSource class.
		/// </summary>
		public SiteAdvertiserFilterDataSource() : base(new SiteAdvertiserFilterService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SiteAdvertiserFilterDataSourceView used by the SiteAdvertiserFilterDataSource.
		/// </summary>
		protected SiteAdvertiserFilterDataSourceView SiteAdvertiserFilterView
		{
			get { return ( View as SiteAdvertiserFilterDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SiteAdvertiserFilterDataSource control invokes to retrieve data.
		/// </summary>
		public SiteAdvertiserFilterSelectMethod SelectMethod
		{
			get
			{
				SiteAdvertiserFilterSelectMethod selectMethod = SiteAdvertiserFilterSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SiteAdvertiserFilterSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SiteAdvertiserFilterDataSourceView class that is to be
		/// used by the SiteAdvertiserFilterDataSource.
		/// </summary>
		/// <returns>An instance of the SiteAdvertiserFilterDataSourceView class.</returns>
		protected override BaseDataSourceView<SiteAdvertiserFilter, SiteAdvertiserFilterKey> GetNewDataSourceView()
		{
			return new SiteAdvertiserFilterDataSourceView(this, DefaultViewName);
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
	/// Supports the SiteAdvertiserFilterDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SiteAdvertiserFilterDataSourceView : ProviderDataSourceView<SiteAdvertiserFilter, SiteAdvertiserFilterKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteAdvertiserFilterDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SiteAdvertiserFilterDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SiteAdvertiserFilterDataSourceView(SiteAdvertiserFilterDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SiteAdvertiserFilterDataSource SiteAdvertiserFilterOwner
		{
			get { return Owner as SiteAdvertiserFilterDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SiteAdvertiserFilterSelectMethod SelectMethod
		{
			get { return SiteAdvertiserFilterOwner.SelectMethod; }
			set { SiteAdvertiserFilterOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SiteAdvertiserFilterService SiteAdvertiserFilterProvider
		{
			get { return Provider as SiteAdvertiserFilterService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SiteAdvertiserFilter> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SiteAdvertiserFilter> results = null;
			SiteAdvertiserFilter item;
			count = 0;
			
			System.Int32 _siteId;
			System.Int32 _advertiserId;
			System.Int32 _siteAdvertiserFilterId;

			switch ( SelectMethod )
			{
				case SiteAdvertiserFilterSelectMethod.Get:
					SiteAdvertiserFilterKey entityKey  = new SiteAdvertiserFilterKey();
					entityKey.Load(values);
					item = SiteAdvertiserFilterProvider.Get(entityKey);
					results = new TList<SiteAdvertiserFilter>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SiteAdvertiserFilterSelectMethod.GetAll:
                    results = SiteAdvertiserFilterProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SiteAdvertiserFilterSelectMethod.GetPaged:
					results = SiteAdvertiserFilterProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SiteAdvertiserFilterSelectMethod.Find:
					if ( FilterParameters != null )
						results = SiteAdvertiserFilterProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SiteAdvertiserFilterProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SiteAdvertiserFilterSelectMethod.GetBySiteAdvertiserFilterId:
					_siteAdvertiserFilterId = ( values["SiteAdvertiserFilterId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteAdvertiserFilterId"], typeof(System.Int32)) : (int)0;
					item = SiteAdvertiserFilterProvider.GetBySiteAdvertiserFilterId(_siteAdvertiserFilterId);
					results = new TList<SiteAdvertiserFilter>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case SiteAdvertiserFilterSelectMethod.GetBySiteIdAdvertiserId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					_advertiserId = ( values["AdvertiserId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AdvertiserId"], typeof(System.Int32)) : (int)0;
					item = SiteAdvertiserFilterProvider.GetBySiteIdAdvertiserId(_siteId, _advertiserId);
					results = new TList<SiteAdvertiserFilter>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case SiteAdvertiserFilterSelectMethod.GetByAdvertiserId:
					_advertiserId = ( values["AdvertiserId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AdvertiserId"], typeof(System.Int32)) : (int)0;
					results = SiteAdvertiserFilterProvider.GetByAdvertiserId(_advertiserId, this.StartIndex, this.PageSize, out count);
					break;
				case SiteAdvertiserFilterSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = SiteAdvertiserFilterProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == SiteAdvertiserFilterSelectMethod.Get || SelectMethod == SiteAdvertiserFilterSelectMethod.GetBySiteAdvertiserFilterId )
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
				SiteAdvertiserFilter entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SiteAdvertiserFilterProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SiteAdvertiserFilter> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SiteAdvertiserFilterProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SiteAdvertiserFilterDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SiteAdvertiserFilterDataSource class.
	/// </summary>
	public class SiteAdvertiserFilterDataSourceDesigner : ProviderDataSourceDesigner<SiteAdvertiserFilter, SiteAdvertiserFilterKey>
	{
		/// <summary>
		/// Initializes a new instance of the SiteAdvertiserFilterDataSourceDesigner class.
		/// </summary>
		public SiteAdvertiserFilterDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SiteAdvertiserFilterSelectMethod SelectMethod
		{
			get { return ((SiteAdvertiserFilterDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SiteAdvertiserFilterDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SiteAdvertiserFilterDataSourceActionList

	/// <summary>
	/// Supports the SiteAdvertiserFilterDataSourceDesigner class.
	/// </summary>
	internal class SiteAdvertiserFilterDataSourceActionList : DesignerActionList
	{
		private SiteAdvertiserFilterDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SiteAdvertiserFilterDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SiteAdvertiserFilterDataSourceActionList(SiteAdvertiserFilterDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SiteAdvertiserFilterSelectMethod SelectMethod
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

	#endregion SiteAdvertiserFilterDataSourceActionList
	
	#endregion SiteAdvertiserFilterDataSourceDesigner
	
	#region SiteAdvertiserFilterSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SiteAdvertiserFilterDataSource.SelectMethod property.
	/// </summary>
	public enum SiteAdvertiserFilterSelectMethod
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
		/// Represents the GetBySiteIdAdvertiserId method.
		/// </summary>
		GetBySiteIdAdvertiserId,
		/// <summary>
		/// Represents the GetBySiteAdvertiserFilterId method.
		/// </summary>
		GetBySiteAdvertiserFilterId,
		/// <summary>
		/// Represents the GetByAdvertiserId method.
		/// </summary>
		GetByAdvertiserId,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId
	}
	
	#endregion SiteAdvertiserFilterSelectMethod

	#region SiteAdvertiserFilterFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteAdvertiserFilter"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteAdvertiserFilterFilter : SqlFilter<SiteAdvertiserFilterColumn>
	{
	}
	
	#endregion SiteAdvertiserFilterFilter

	#region SiteAdvertiserFilterExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteAdvertiserFilter"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteAdvertiserFilterExpressionBuilder : SqlExpressionBuilder<SiteAdvertiserFilterColumn>
	{
	}
	
	#endregion SiteAdvertiserFilterExpressionBuilder	

	#region SiteAdvertiserFilterProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SiteAdvertiserFilterChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SiteAdvertiserFilter"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteAdvertiserFilterProperty : ChildEntityProperty<SiteAdvertiserFilterChildEntityTypes>
	{
	}
	
	#endregion SiteAdvertiserFilterProperty
}

