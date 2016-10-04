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
	/// Represents the DataRepository.InvoiceProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(InvoiceDataSourceDesigner))]
	public class InvoiceDataSource : ProviderDataSource<Invoice, InvoiceKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceDataSource class.
		/// </summary>
		public InvoiceDataSource() : base(new InvoiceService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the InvoiceDataSourceView used by the InvoiceDataSource.
		/// </summary>
		protected InvoiceDataSourceView InvoiceView
		{
			get { return ( View as InvoiceDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the InvoiceDataSource control invokes to retrieve data.
		/// </summary>
		public InvoiceSelectMethod SelectMethod
		{
			get
			{
				InvoiceSelectMethod selectMethod = InvoiceSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (InvoiceSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the InvoiceDataSourceView class that is to be
		/// used by the InvoiceDataSource.
		/// </summary>
		/// <returns>An instance of the InvoiceDataSourceView class.</returns>
		protected override BaseDataSourceView<Invoice, InvoiceKey> GetNewDataSourceView()
		{
			return new InvoiceDataSourceView(this, DefaultViewName);
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
	/// Supports the InvoiceDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class InvoiceDataSourceView : ProviderDataSourceView<Invoice, InvoiceKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the InvoiceDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public InvoiceDataSourceView(InvoiceDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal InvoiceDataSource InvoiceOwner
		{
			get { return Owner as InvoiceDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal InvoiceSelectMethod SelectMethod
		{
			get { return InvoiceOwner.SelectMethod; }
			set { InvoiceOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal InvoiceService InvoiceProvider
		{
			get { return Provider as InvoiceService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Invoice> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Invoice> results = null;
			Invoice item;
			count = 0;
			
			System.Int32 _invoiceId;
			System.Int32 _advertiserUserId;
			System.Int32 _orderId;

			switch ( SelectMethod )
			{
				case InvoiceSelectMethod.Get:
					InvoiceKey entityKey  = new InvoiceKey();
					entityKey.Load(values);
					item = InvoiceProvider.Get(entityKey);
					results = new TList<Invoice>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case InvoiceSelectMethod.GetAll:
                    results = InvoiceProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case InvoiceSelectMethod.GetPaged:
					results = InvoiceProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case InvoiceSelectMethod.Find:
					if ( FilterParameters != null )
						results = InvoiceProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = InvoiceProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case InvoiceSelectMethod.GetByInvoiceId:
					_invoiceId = ( values["InvoiceId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["InvoiceId"], typeof(System.Int32)) : (int)0;
					item = InvoiceProvider.GetByInvoiceId(_invoiceId);
					results = new TList<Invoice>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case InvoiceSelectMethod.GetByAdvertiserUserId:
					_advertiserUserId = ( values["AdvertiserUserId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AdvertiserUserId"], typeof(System.Int32)) : (int)0;
					results = InvoiceProvider.GetByAdvertiserUserId(_advertiserUserId, this.StartIndex, this.PageSize, out count);
					break;
				case InvoiceSelectMethod.GetByOrderId:
					_orderId = ( values["OrderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["OrderId"], typeof(System.Int32)) : (int)0;
					results = InvoiceProvider.GetByOrderId(_orderId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == InvoiceSelectMethod.Get || SelectMethod == InvoiceSelectMethod.GetByInvoiceId )
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
				Invoice entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					InvoiceProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Invoice> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			InvoiceProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region InvoiceDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the InvoiceDataSource class.
	/// </summary>
	public class InvoiceDataSourceDesigner : ProviderDataSourceDesigner<Invoice, InvoiceKey>
	{
		/// <summary>
		/// Initializes a new instance of the InvoiceDataSourceDesigner class.
		/// </summary>
		public InvoiceDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public InvoiceSelectMethod SelectMethod
		{
			get { return ((InvoiceDataSource) DataSource).SelectMethod; }
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
				actions.Add(new InvoiceDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region InvoiceDataSourceActionList

	/// <summary>
	/// Supports the InvoiceDataSourceDesigner class.
	/// </summary>
	internal class InvoiceDataSourceActionList : DesignerActionList
	{
		private InvoiceDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the InvoiceDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public InvoiceDataSourceActionList(InvoiceDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public InvoiceSelectMethod SelectMethod
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

	#endregion InvoiceDataSourceActionList
	
	#endregion InvoiceDataSourceDesigner
	
	#region InvoiceSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the InvoiceDataSource.SelectMethod property.
	/// </summary>
	public enum InvoiceSelectMethod
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
		/// Represents the GetByInvoiceId method.
		/// </summary>
		GetByInvoiceId,
		/// <summary>
		/// Represents the GetByAdvertiserUserId method.
		/// </summary>
		GetByAdvertiserUserId,
		/// <summary>
		/// Represents the GetByOrderId method.
		/// </summary>
		GetByOrderId
	}
	
	#endregion InvoiceSelectMethod

	#region InvoiceFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Invoice"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceFilter : SqlFilter<InvoiceColumn>
	{
	}
	
	#endregion InvoiceFilter

	#region InvoiceExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Invoice"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceExpressionBuilder : SqlExpressionBuilder<InvoiceColumn>
	{
	}
	
	#endregion InvoiceExpressionBuilder	

	#region InvoiceProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;InvoiceChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Invoice"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceProperty : ChildEntityProperty<InvoiceChildEntityTypes>
	{
	}
	
	#endregion InvoiceProperty
}

