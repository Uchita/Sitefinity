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
	/// Represents the DataRepository.AvailableStatusProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AvailableStatusDataSourceDesigner))]
	public class AvailableStatusDataSource : ProviderDataSource<AvailableStatus, AvailableStatusKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AvailableStatusDataSource class.
		/// </summary>
		public AvailableStatusDataSource() : base(new AvailableStatusService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AvailableStatusDataSourceView used by the AvailableStatusDataSource.
		/// </summary>
		protected AvailableStatusDataSourceView AvailableStatusView
		{
			get { return ( View as AvailableStatusDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AvailableStatusDataSource control invokes to retrieve data.
		/// </summary>
		public AvailableStatusSelectMethod SelectMethod
		{
			get
			{
				AvailableStatusSelectMethod selectMethod = AvailableStatusSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AvailableStatusSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AvailableStatusDataSourceView class that is to be
		/// used by the AvailableStatusDataSource.
		/// </summary>
		/// <returns>An instance of the AvailableStatusDataSourceView class.</returns>
		protected override BaseDataSourceView<AvailableStatus, AvailableStatusKey> GetNewDataSourceView()
		{
			return new AvailableStatusDataSourceView(this, DefaultViewName);
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
	/// Supports the AvailableStatusDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AvailableStatusDataSourceView : ProviderDataSourceView<AvailableStatus, AvailableStatusKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AvailableStatusDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AvailableStatusDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AvailableStatusDataSourceView(AvailableStatusDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AvailableStatusDataSource AvailableStatusOwner
		{
			get { return Owner as AvailableStatusDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AvailableStatusSelectMethod SelectMethod
		{
			get { return AvailableStatusOwner.SelectMethod; }
			set { AvailableStatusOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AvailableStatusService AvailableStatusProvider
		{
			get { return Provider as AvailableStatusService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AvailableStatus> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AvailableStatus> results = null;
			AvailableStatus item;
			count = 0;
			
			System.Int32 _availableStatusId;
			System.Int32 _lastModifiedBy;
			System.Int32? _siteId_nullable;

			switch ( SelectMethod )
			{
				case AvailableStatusSelectMethod.Get:
					AvailableStatusKey entityKey  = new AvailableStatusKey();
					entityKey.Load(values);
					item = AvailableStatusProvider.Get(entityKey);
					results = new TList<AvailableStatus>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AvailableStatusSelectMethod.GetAll:
                    results = AvailableStatusProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AvailableStatusSelectMethod.GetPaged:
					results = AvailableStatusProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AvailableStatusSelectMethod.Find:
					if ( FilterParameters != null )
						results = AvailableStatusProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AvailableStatusProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AvailableStatusSelectMethod.GetByAvailableStatusId:
					_availableStatusId = ( values["AvailableStatusId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AvailableStatusId"], typeof(System.Int32)) : (int)0;
					item = AvailableStatusProvider.GetByAvailableStatusId(_availableStatusId);
					results = new TList<AvailableStatus>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case AvailableStatusSelectMethod.GetByLastModifiedBy:
					_lastModifiedBy = ( values["LastModifiedBy"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LastModifiedBy"], typeof(System.Int32)) : (int)0;
					results = AvailableStatusProvider.GetByLastModifiedBy(_lastModifiedBy, this.StartIndex, this.PageSize, out count);
					break;
				case AvailableStatusSelectMethod.GetBySiteId:
					_siteId_nullable = (System.Int32?) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32?));
					results = AvailableStatusProvider.GetBySiteId(_siteId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == AvailableStatusSelectMethod.Get || SelectMethod == AvailableStatusSelectMethod.GetByAvailableStatusId )
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
				AvailableStatus entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AvailableStatusProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AvailableStatus> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AvailableStatusProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AvailableStatusDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AvailableStatusDataSource class.
	/// </summary>
	public class AvailableStatusDataSourceDesigner : ProviderDataSourceDesigner<AvailableStatus, AvailableStatusKey>
	{
		/// <summary>
		/// Initializes a new instance of the AvailableStatusDataSourceDesigner class.
		/// </summary>
		public AvailableStatusDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AvailableStatusSelectMethod SelectMethod
		{
			get { return ((AvailableStatusDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AvailableStatusDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AvailableStatusDataSourceActionList

	/// <summary>
	/// Supports the AvailableStatusDataSourceDesigner class.
	/// </summary>
	internal class AvailableStatusDataSourceActionList : DesignerActionList
	{
		private AvailableStatusDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AvailableStatusDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AvailableStatusDataSourceActionList(AvailableStatusDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AvailableStatusSelectMethod SelectMethod
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

	#endregion AvailableStatusDataSourceActionList
	
	#endregion AvailableStatusDataSourceDesigner
	
	#region AvailableStatusSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AvailableStatusDataSource.SelectMethod property.
	/// </summary>
	public enum AvailableStatusSelectMethod
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
		/// Represents the GetByAvailableStatusId method.
		/// </summary>
		GetByAvailableStatusId,
		/// <summary>
		/// Represents the GetByLastModifiedBy method.
		/// </summary>
		GetByLastModifiedBy,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId
	}
	
	#endregion AvailableStatusSelectMethod

	#region AvailableStatusFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AvailableStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AvailableStatusFilter : SqlFilter<AvailableStatusColumn>
	{
	}
	
	#endregion AvailableStatusFilter

	#region AvailableStatusExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AvailableStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AvailableStatusExpressionBuilder : SqlExpressionBuilder<AvailableStatusColumn>
	{
	}
	
	#endregion AvailableStatusExpressionBuilder	

	#region AvailableStatusProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AvailableStatusChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AvailableStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AvailableStatusProperty : ChildEntityProperty<AvailableStatusChildEntityTypes>
	{
	}
	
	#endregion AvailableStatusProperty
}

