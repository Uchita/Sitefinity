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
	/// Represents the DataRepository.AdvertiserAccountStatusProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AdvertiserAccountStatusDataSourceDesigner))]
	public class AdvertiserAccountStatusDataSource : ProviderDataSource<AdvertiserAccountStatus, AdvertiserAccountStatusKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountStatusDataSource class.
		/// </summary>
		public AdvertiserAccountStatusDataSource() : base(new AdvertiserAccountStatusService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AdvertiserAccountStatusDataSourceView used by the AdvertiserAccountStatusDataSource.
		/// </summary>
		protected AdvertiserAccountStatusDataSourceView AdvertiserAccountStatusView
		{
			get { return ( View as AdvertiserAccountStatusDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AdvertiserAccountStatusDataSource control invokes to retrieve data.
		/// </summary>
		public AdvertiserAccountStatusSelectMethod SelectMethod
		{
			get
			{
				AdvertiserAccountStatusSelectMethod selectMethod = AdvertiserAccountStatusSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AdvertiserAccountStatusSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AdvertiserAccountStatusDataSourceView class that is to be
		/// used by the AdvertiserAccountStatusDataSource.
		/// </summary>
		/// <returns>An instance of the AdvertiserAccountStatusDataSourceView class.</returns>
		protected override BaseDataSourceView<AdvertiserAccountStatus, AdvertiserAccountStatusKey> GetNewDataSourceView()
		{
			return new AdvertiserAccountStatusDataSourceView(this, DefaultViewName);
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
	/// Supports the AdvertiserAccountStatusDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AdvertiserAccountStatusDataSourceView : ProviderDataSourceView<AdvertiserAccountStatus, AdvertiserAccountStatusKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountStatusDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AdvertiserAccountStatusDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AdvertiserAccountStatusDataSourceView(AdvertiserAccountStatusDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AdvertiserAccountStatusDataSource AdvertiserAccountStatusOwner
		{
			get { return Owner as AdvertiserAccountStatusDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AdvertiserAccountStatusSelectMethod SelectMethod
		{
			get { return AdvertiserAccountStatusOwner.SelectMethod; }
			set { AdvertiserAccountStatusOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AdvertiserAccountStatusService AdvertiserAccountStatusProvider
		{
			get { return Provider as AdvertiserAccountStatusService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AdvertiserAccountStatus> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AdvertiserAccountStatus> results = null;
			AdvertiserAccountStatus item;
			count = 0;
			
			System.Int32 _advertiserAccountStatusId;

			switch ( SelectMethod )
			{
				case AdvertiserAccountStatusSelectMethod.Get:
					AdvertiserAccountStatusKey entityKey  = new AdvertiserAccountStatusKey();
					entityKey.Load(values);
					item = AdvertiserAccountStatusProvider.Get(entityKey);
					results = new TList<AdvertiserAccountStatus>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AdvertiserAccountStatusSelectMethod.GetAll:
                    results = AdvertiserAccountStatusProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AdvertiserAccountStatusSelectMethod.GetPaged:
					results = AdvertiserAccountStatusProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AdvertiserAccountStatusSelectMethod.Find:
					if ( FilterParameters != null )
						results = AdvertiserAccountStatusProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AdvertiserAccountStatusProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AdvertiserAccountStatusSelectMethod.GetByAdvertiserAccountStatusId:
					_advertiserAccountStatusId = ( values["AdvertiserAccountStatusId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AdvertiserAccountStatusId"], typeof(System.Int32)) : (int)0;
					item = AdvertiserAccountStatusProvider.GetByAdvertiserAccountStatusId(_advertiserAccountStatusId);
					results = new TList<AdvertiserAccountStatus>();
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
			if ( SelectMethod == AdvertiserAccountStatusSelectMethod.Get || SelectMethod == AdvertiserAccountStatusSelectMethod.GetByAdvertiserAccountStatusId )
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
				AdvertiserAccountStatus entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AdvertiserAccountStatusProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AdvertiserAccountStatus> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AdvertiserAccountStatusProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AdvertiserAccountStatusDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AdvertiserAccountStatusDataSource class.
	/// </summary>
	public class AdvertiserAccountStatusDataSourceDesigner : ProviderDataSourceDesigner<AdvertiserAccountStatus, AdvertiserAccountStatusKey>
	{
		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountStatusDataSourceDesigner class.
		/// </summary>
		public AdvertiserAccountStatusDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdvertiserAccountStatusSelectMethod SelectMethod
		{
			get { return ((AdvertiserAccountStatusDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AdvertiserAccountStatusDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AdvertiserAccountStatusDataSourceActionList

	/// <summary>
	/// Supports the AdvertiserAccountStatusDataSourceDesigner class.
	/// </summary>
	internal class AdvertiserAccountStatusDataSourceActionList : DesignerActionList
	{
		private AdvertiserAccountStatusDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountStatusDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AdvertiserAccountStatusDataSourceActionList(AdvertiserAccountStatusDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdvertiserAccountStatusSelectMethod SelectMethod
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

	#endregion AdvertiserAccountStatusDataSourceActionList
	
	#endregion AdvertiserAccountStatusDataSourceDesigner
	
	#region AdvertiserAccountStatusSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AdvertiserAccountStatusDataSource.SelectMethod property.
	/// </summary>
	public enum AdvertiserAccountStatusSelectMethod
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
		/// Represents the GetByAdvertiserAccountStatusId method.
		/// </summary>
		GetByAdvertiserAccountStatusId
	}
	
	#endregion AdvertiserAccountStatusSelectMethod

	#region AdvertiserAccountStatusFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserAccountStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserAccountStatusFilter : SqlFilter<AdvertiserAccountStatusColumn>
	{
	}
	
	#endregion AdvertiserAccountStatusFilter

	#region AdvertiserAccountStatusExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserAccountStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserAccountStatusExpressionBuilder : SqlExpressionBuilder<AdvertiserAccountStatusColumn>
	{
	}
	
	#endregion AdvertiserAccountStatusExpressionBuilder	

	#region AdvertiserAccountStatusProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AdvertiserAccountStatusChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserAccountStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserAccountStatusProperty : ChildEntityProperty<AdvertiserAccountStatusChildEntityTypes>
	{
	}
	
	#endregion AdvertiserAccountStatusProperty
}

