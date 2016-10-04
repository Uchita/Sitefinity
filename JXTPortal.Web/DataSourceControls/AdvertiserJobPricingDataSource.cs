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
	/// Represents the DataRepository.AdvertiserJobPricingProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AdvertiserJobPricingDataSourceDesigner))]
	public class AdvertiserJobPricingDataSource : ProviderDataSource<AdvertiserJobPricing, AdvertiserJobPricingKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobPricingDataSource class.
		/// </summary>
		public AdvertiserJobPricingDataSource() : base(new AdvertiserJobPricingService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AdvertiserJobPricingDataSourceView used by the AdvertiserJobPricingDataSource.
		/// </summary>
		protected AdvertiserJobPricingDataSourceView AdvertiserJobPricingView
		{
			get { return ( View as AdvertiserJobPricingDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AdvertiserJobPricingDataSource control invokes to retrieve data.
		/// </summary>
		public AdvertiserJobPricingSelectMethod SelectMethod
		{
			get
			{
				AdvertiserJobPricingSelectMethod selectMethod = AdvertiserJobPricingSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AdvertiserJobPricingSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AdvertiserJobPricingDataSourceView class that is to be
		/// used by the AdvertiserJobPricingDataSource.
		/// </summary>
		/// <returns>An instance of the AdvertiserJobPricingDataSourceView class.</returns>
		protected override BaseDataSourceView<AdvertiserJobPricing, AdvertiserJobPricingKey> GetNewDataSourceView()
		{
			return new AdvertiserJobPricingDataSourceView(this, DefaultViewName);
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
	/// Supports the AdvertiserJobPricingDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AdvertiserJobPricingDataSourceView : ProviderDataSourceView<AdvertiserJobPricing, AdvertiserJobPricingKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobPricingDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AdvertiserJobPricingDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AdvertiserJobPricingDataSourceView(AdvertiserJobPricingDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AdvertiserJobPricingDataSource AdvertiserJobPricingOwner
		{
			get { return Owner as AdvertiserJobPricingDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AdvertiserJobPricingSelectMethod SelectMethod
		{
			get { return AdvertiserJobPricingOwner.SelectMethod; }
			set { AdvertiserJobPricingOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AdvertiserJobPricingService AdvertiserJobPricingProvider
		{
			get { return Provider as AdvertiserJobPricingService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AdvertiserJobPricing> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AdvertiserJobPricing> results = null;
			AdvertiserJobPricing item;
			count = 0;
			
			System.Int32 _advertiserId;
			System.Int32 _jobItemsTypeId;

			switch ( SelectMethod )
			{
				case AdvertiserJobPricingSelectMethod.Get:
					AdvertiserJobPricingKey entityKey  = new AdvertiserJobPricingKey();
					entityKey.Load(values);
					item = AdvertiserJobPricingProvider.Get(entityKey);
					results = new TList<AdvertiserJobPricing>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AdvertiserJobPricingSelectMethod.GetAll:
                    results = AdvertiserJobPricingProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AdvertiserJobPricingSelectMethod.GetPaged:
					results = AdvertiserJobPricingProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AdvertiserJobPricingSelectMethod.Find:
					if ( FilterParameters != null )
						results = AdvertiserJobPricingProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AdvertiserJobPricingProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AdvertiserJobPricingSelectMethod.GetByAdvertiserIdJobItemsTypeId:
					_advertiserId = ( values["AdvertiserId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AdvertiserId"], typeof(System.Int32)) : (int)0;
					_jobItemsTypeId = ( values["JobItemsTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["JobItemsTypeId"], typeof(System.Int32)) : (int)0;
					item = AdvertiserJobPricingProvider.GetByAdvertiserIdJobItemsTypeId(_advertiserId, _jobItemsTypeId);
					results = new TList<AdvertiserJobPricing>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case AdvertiserJobPricingSelectMethod.GetByAdvertiserId:
					_advertiserId = ( values["AdvertiserId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AdvertiserId"], typeof(System.Int32)) : (int)0;
					results = AdvertiserJobPricingProvider.GetByAdvertiserId(_advertiserId, this.StartIndex, this.PageSize, out count);
					break;
				case AdvertiserJobPricingSelectMethod.GetByJobItemsTypeId:
					_jobItemsTypeId = ( values["JobItemsTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["JobItemsTypeId"], typeof(System.Int32)) : (int)0;
					results = AdvertiserJobPricingProvider.GetByJobItemsTypeId(_jobItemsTypeId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == AdvertiserJobPricingSelectMethod.Get || SelectMethod == AdvertiserJobPricingSelectMethod.GetByAdvertiserIdJobItemsTypeId )
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
				AdvertiserJobPricing entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AdvertiserJobPricingProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AdvertiserJobPricing> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AdvertiserJobPricingProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AdvertiserJobPricingDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AdvertiserJobPricingDataSource class.
	/// </summary>
	public class AdvertiserJobPricingDataSourceDesigner : ProviderDataSourceDesigner<AdvertiserJobPricing, AdvertiserJobPricingKey>
	{
		/// <summary>
		/// Initializes a new instance of the AdvertiserJobPricingDataSourceDesigner class.
		/// </summary>
		public AdvertiserJobPricingDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdvertiserJobPricingSelectMethod SelectMethod
		{
			get { return ((AdvertiserJobPricingDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AdvertiserJobPricingDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AdvertiserJobPricingDataSourceActionList

	/// <summary>
	/// Supports the AdvertiserJobPricingDataSourceDesigner class.
	/// </summary>
	internal class AdvertiserJobPricingDataSourceActionList : DesignerActionList
	{
		private AdvertiserJobPricingDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobPricingDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AdvertiserJobPricingDataSourceActionList(AdvertiserJobPricingDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdvertiserJobPricingSelectMethod SelectMethod
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

	#endregion AdvertiserJobPricingDataSourceActionList
	
	#endregion AdvertiserJobPricingDataSourceDesigner
	
	#region AdvertiserJobPricingSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AdvertiserJobPricingDataSource.SelectMethod property.
	/// </summary>
	public enum AdvertiserJobPricingSelectMethod
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
		/// Represents the GetByAdvertiserIdJobItemsTypeId method.
		/// </summary>
		GetByAdvertiserIdJobItemsTypeId,
		/// <summary>
		/// Represents the GetByAdvertiserId method.
		/// </summary>
		GetByAdvertiserId,
		/// <summary>
		/// Represents the GetByJobItemsTypeId method.
		/// </summary>
		GetByJobItemsTypeId
	}
	
	#endregion AdvertiserJobPricingSelectMethod

	#region AdvertiserJobPricingFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserJobPricing"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserJobPricingFilter : SqlFilter<AdvertiserJobPricingColumn>
	{
	}
	
	#endregion AdvertiserJobPricingFilter

	#region AdvertiserJobPricingExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserJobPricing"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserJobPricingExpressionBuilder : SqlExpressionBuilder<AdvertiserJobPricingColumn>
	{
	}
	
	#endregion AdvertiserJobPricingExpressionBuilder	

	#region AdvertiserJobPricingProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AdvertiserJobPricingChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserJobPricing"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserJobPricingProperty : ChildEntityProperty<AdvertiserJobPricingChildEntityTypes>
	{
	}
	
	#endregion AdvertiserJobPricingProperty
}

