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
	/// Represents the DataRepository.AdvertisersProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AdvertisersDataSourceDesigner))]
	public class AdvertisersDataSource : ProviderDataSource<Advertisers, AdvertisersKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertisersDataSource class.
		/// </summary>
		public AdvertisersDataSource() : base(new AdvertisersService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AdvertisersDataSourceView used by the AdvertisersDataSource.
		/// </summary>
		protected AdvertisersDataSourceView AdvertisersView
		{
			get { return ( View as AdvertisersDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AdvertisersDataSource control invokes to retrieve data.
		/// </summary>
		public AdvertisersSelectMethod SelectMethod
		{
			get
			{
				AdvertisersSelectMethod selectMethod = AdvertisersSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AdvertisersSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AdvertisersDataSourceView class that is to be
		/// used by the AdvertisersDataSource.
		/// </summary>
		/// <returns>An instance of the AdvertisersDataSourceView class.</returns>
		protected override BaseDataSourceView<Advertisers, AdvertisersKey> GetNewDataSourceView()
		{
			return new AdvertisersDataSourceView(this, DefaultViewName);
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
	/// Supports the AdvertisersDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AdvertisersDataSourceView : ProviderDataSourceView<Advertisers, AdvertisersKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertisersDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AdvertisersDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AdvertisersDataSourceView(AdvertisersDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AdvertisersDataSource AdvertisersOwner
		{
			get { return Owner as AdvertisersDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AdvertisersSelectMethod SelectMethod
		{
			get { return AdvertisersOwner.SelectMethod; }
			set { AdvertisersOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AdvertisersService AdvertisersProvider
		{
			get { return Provider as AdvertisersService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Advertisers> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Advertisers> results = null;
			Advertisers item;
			count = 0;
			
			System.Int32 _advertiserId;
			System.Int32 _advertiserAccountStatusId;
			System.Int32 _advertiserBusinessTypeId;
			System.Int32 _advertiserAccountTypeId;
			System.Int32 _lastModifiedBy;
			System.Int32? _siteId_nullable;
			System.Int32 _jobItemsTypeId;

			switch ( SelectMethod )
			{
				case AdvertisersSelectMethod.Get:
					AdvertisersKey entityKey  = new AdvertisersKey();
					entityKey.Load(values);
					item = AdvertisersProvider.Get(entityKey);
					results = new TList<Advertisers>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AdvertisersSelectMethod.GetAll:
                    results = AdvertisersProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AdvertisersSelectMethod.GetPaged:
					results = AdvertisersProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AdvertisersSelectMethod.Find:
					if ( FilterParameters != null )
						results = AdvertisersProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AdvertisersProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AdvertisersSelectMethod.GetByAdvertiserId:
					_advertiserId = ( values["AdvertiserId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AdvertiserId"], typeof(System.Int32)) : (int)0;
					item = AdvertisersProvider.GetByAdvertiserId(_advertiserId);
					results = new TList<Advertisers>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case AdvertisersSelectMethod.GetByAdvertiserAccountStatusId:
					_advertiserAccountStatusId = ( values["AdvertiserAccountStatusId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AdvertiserAccountStatusId"], typeof(System.Int32)) : (int)0;
					results = AdvertisersProvider.GetByAdvertiserAccountStatusId(_advertiserAccountStatusId, this.StartIndex, this.PageSize, out count);
					break;
				case AdvertisersSelectMethod.GetByAdvertiserBusinessTypeId:
					_advertiserBusinessTypeId = ( values["AdvertiserBusinessTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AdvertiserBusinessTypeId"], typeof(System.Int32)) : (int)0;
					results = AdvertisersProvider.GetByAdvertiserBusinessTypeId(_advertiserBusinessTypeId, this.StartIndex, this.PageSize, out count);
					break;
				case AdvertisersSelectMethod.GetByAdvertiserAccountTypeId:
					_advertiserAccountTypeId = ( values["AdvertiserAccountTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AdvertiserAccountTypeId"], typeof(System.Int32)) : (int)0;
					results = AdvertisersProvider.GetByAdvertiserAccountTypeId(_advertiserAccountTypeId, this.StartIndex, this.PageSize, out count);
					break;
				case AdvertisersSelectMethod.GetByLastModifiedBy:
					_lastModifiedBy = ( values["LastModifiedBy"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LastModifiedBy"], typeof(System.Int32)) : (int)0;
					results = AdvertisersProvider.GetByLastModifiedBy(_lastModifiedBy, this.StartIndex, this.PageSize, out count);
					break;
				case AdvertisersSelectMethod.GetBySiteId:
					_siteId_nullable = (System.Int32?) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32?));
					results = AdvertisersProvider.GetBySiteId(_siteId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				case AdvertisersSelectMethod.GetByJobItemsTypeIdFromAdvertiserJobPricing:
					_jobItemsTypeId = ( values["JobItemsTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["JobItemsTypeId"], typeof(System.Int32)) : (int)0;
					results = AdvertisersProvider.GetByJobItemsTypeIdFromAdvertiserJobPricing(_jobItemsTypeId, this.StartIndex, this.PageSize, out count);
					break;
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
			if ( SelectMethod == AdvertisersSelectMethod.Get || SelectMethod == AdvertisersSelectMethod.GetByAdvertiserId )
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
				Advertisers entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AdvertisersProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Advertisers> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AdvertisersProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AdvertisersDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AdvertisersDataSource class.
	/// </summary>
	public class AdvertisersDataSourceDesigner : ProviderDataSourceDesigner<Advertisers, AdvertisersKey>
	{
		/// <summary>
		/// Initializes a new instance of the AdvertisersDataSourceDesigner class.
		/// </summary>
		public AdvertisersDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdvertisersSelectMethod SelectMethod
		{
			get { return ((AdvertisersDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AdvertisersDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AdvertisersDataSourceActionList

	/// <summary>
	/// Supports the AdvertisersDataSourceDesigner class.
	/// </summary>
	internal class AdvertisersDataSourceActionList : DesignerActionList
	{
		private AdvertisersDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AdvertisersDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AdvertisersDataSourceActionList(AdvertisersDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdvertisersSelectMethod SelectMethod
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

	#endregion AdvertisersDataSourceActionList
	
	#endregion AdvertisersDataSourceDesigner
	
	#region AdvertisersSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AdvertisersDataSource.SelectMethod property.
	/// </summary>
	public enum AdvertisersSelectMethod
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
		/// Represents the GetByAdvertiserId method.
		/// </summary>
		GetByAdvertiserId,
		/// <summary>
		/// Represents the GetByAdvertiserAccountStatusId method.
		/// </summary>
		GetByAdvertiserAccountStatusId,
		/// <summary>
		/// Represents the GetByAdvertiserBusinessTypeId method.
		/// </summary>
		GetByAdvertiserBusinessTypeId,
		/// <summary>
		/// Represents the GetByAdvertiserAccountTypeId method.
		/// </summary>
		GetByAdvertiserAccountTypeId,
		/// <summary>
		/// Represents the GetByLastModifiedBy method.
		/// </summary>
		GetByLastModifiedBy,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId,
		/// <summary>
		/// Represents the GetByJobItemsTypeIdFromAdvertiserJobPricing method.
		/// </summary>
		GetByJobItemsTypeIdFromAdvertiserJobPricing
	}
	
	#endregion AdvertisersSelectMethod

	#region AdvertisersFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Advertisers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertisersFilter : SqlFilter<AdvertisersColumn>
	{
	}
	
	#endregion AdvertisersFilter

	#region AdvertisersExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Advertisers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertisersExpressionBuilder : SqlExpressionBuilder<AdvertisersColumn>
	{
	}
	
	#endregion AdvertisersExpressionBuilder	

	#region AdvertisersProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AdvertisersChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Advertisers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertisersProperty : ChildEntityProperty<AdvertisersChildEntityTypes>
	{
	}
	
	#endregion AdvertisersProperty
}

