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
	/// Represents the DataRepository.DefaultResourcesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DefaultResourcesDataSourceDesigner))]
	public class DefaultResourcesDataSource : ProviderDataSource<DefaultResources, DefaultResourcesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DefaultResourcesDataSource class.
		/// </summary>
		public DefaultResourcesDataSource() : base(new DefaultResourcesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DefaultResourcesDataSourceView used by the DefaultResourcesDataSource.
		/// </summary>
		protected DefaultResourcesDataSourceView DefaultResourcesView
		{
			get { return ( View as DefaultResourcesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DefaultResourcesDataSource control invokes to retrieve data.
		/// </summary>
		public DefaultResourcesSelectMethod SelectMethod
		{
			get
			{
				DefaultResourcesSelectMethod selectMethod = DefaultResourcesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DefaultResourcesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DefaultResourcesDataSourceView class that is to be
		/// used by the DefaultResourcesDataSource.
		/// </summary>
		/// <returns>An instance of the DefaultResourcesDataSourceView class.</returns>
		protected override BaseDataSourceView<DefaultResources, DefaultResourcesKey> GetNewDataSourceView()
		{
			return new DefaultResourcesDataSourceView(this, DefaultViewName);
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
	/// Supports the DefaultResourcesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DefaultResourcesDataSourceView : ProviderDataSourceView<DefaultResources, DefaultResourcesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DefaultResourcesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DefaultResourcesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DefaultResourcesDataSourceView(DefaultResourcesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DefaultResourcesDataSource DefaultResourcesOwner
		{
			get { return Owner as DefaultResourcesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DefaultResourcesSelectMethod SelectMethod
		{
			get { return DefaultResourcesOwner.SelectMethod; }
			set { DefaultResourcesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DefaultResourcesService DefaultResourcesProvider
		{
			get { return Provider as DefaultResourcesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<DefaultResources> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<DefaultResources> results = null;
			DefaultResources item;
			count = 0;
			
			System.String _resourceCode;
			System.Int32 _defaultResourceId;
			System.Int32 _lastModifiedBy;
			System.Int32? _resourceFileId_nullable;

			switch ( SelectMethod )
			{
				case DefaultResourcesSelectMethod.Get:
					DefaultResourcesKey entityKey  = new DefaultResourcesKey();
					entityKey.Load(values);
					item = DefaultResourcesProvider.Get(entityKey);
					results = new TList<DefaultResources>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DefaultResourcesSelectMethod.GetAll:
                    results = DefaultResourcesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case DefaultResourcesSelectMethod.GetPaged:
					results = DefaultResourcesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DefaultResourcesSelectMethod.Find:
					if ( FilterParameters != null )
						results = DefaultResourcesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DefaultResourcesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DefaultResourcesSelectMethod.GetByDefaultResourceId:
					_defaultResourceId = ( values["DefaultResourceId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DefaultResourceId"], typeof(System.Int32)) : (int)0;
					item = DefaultResourcesProvider.GetByDefaultResourceId(_defaultResourceId);
					results = new TList<DefaultResources>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case DefaultResourcesSelectMethod.GetByResourceCode:
					_resourceCode = ( values["ResourceCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["ResourceCode"], typeof(System.String)) : string.Empty;
					item = DefaultResourcesProvider.GetByResourceCode(_resourceCode);
					results = new TList<DefaultResources>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case DefaultResourcesSelectMethod.GetByLastModifiedBy:
					_lastModifiedBy = ( values["LastModifiedBy"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LastModifiedBy"], typeof(System.Int32)) : (int)0;
					results = DefaultResourcesProvider.GetByLastModifiedBy(_lastModifiedBy, this.StartIndex, this.PageSize, out count);
					break;
				case DefaultResourcesSelectMethod.GetByResourceFileId:
					_resourceFileId_nullable = (System.Int32?) EntityUtil.ChangeType(values["ResourceFileId"], typeof(System.Int32?));
					results = DefaultResourcesProvider.GetByResourceFileId(_resourceFileId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == DefaultResourcesSelectMethod.Get || SelectMethod == DefaultResourcesSelectMethod.GetByDefaultResourceId )
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
				DefaultResources entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					DefaultResourcesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<DefaultResources> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			DefaultResourcesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DefaultResourcesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DefaultResourcesDataSource class.
	/// </summary>
	public class DefaultResourcesDataSourceDesigner : ProviderDataSourceDesigner<DefaultResources, DefaultResourcesKey>
	{
		/// <summary>
		/// Initializes a new instance of the DefaultResourcesDataSourceDesigner class.
		/// </summary>
		public DefaultResourcesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DefaultResourcesSelectMethod SelectMethod
		{
			get { return ((DefaultResourcesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DefaultResourcesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DefaultResourcesDataSourceActionList

	/// <summary>
	/// Supports the DefaultResourcesDataSourceDesigner class.
	/// </summary>
	internal class DefaultResourcesDataSourceActionList : DesignerActionList
	{
		private DefaultResourcesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DefaultResourcesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DefaultResourcesDataSourceActionList(DefaultResourcesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DefaultResourcesSelectMethod SelectMethod
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

	#endregion DefaultResourcesDataSourceActionList
	
	#endregion DefaultResourcesDataSourceDesigner
	
	#region DefaultResourcesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DefaultResourcesDataSource.SelectMethod property.
	/// </summary>
	public enum DefaultResourcesSelectMethod
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
		/// Represents the GetByResourceCode method.
		/// </summary>
		GetByResourceCode,
		/// <summary>
		/// Represents the GetByDefaultResourceId method.
		/// </summary>
		GetByDefaultResourceId,
		/// <summary>
		/// Represents the GetByLastModifiedBy method.
		/// </summary>
		GetByLastModifiedBy,
		/// <summary>
		/// Represents the GetByResourceFileId method.
		/// </summary>
		GetByResourceFileId
	}
	
	#endregion DefaultResourcesSelectMethod

	#region DefaultResourcesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DefaultResources"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DefaultResourcesFilter : SqlFilter<DefaultResourcesColumn>
	{
	}
	
	#endregion DefaultResourcesFilter

	#region DefaultResourcesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DefaultResources"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DefaultResourcesExpressionBuilder : SqlExpressionBuilder<DefaultResourcesColumn>
	{
	}
	
	#endregion DefaultResourcesExpressionBuilder	

	#region DefaultResourcesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DefaultResourcesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="DefaultResources"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DefaultResourcesProperty : ChildEntityProperty<DefaultResourcesChildEntityTypes>
	{
	}
	
	#endregion DefaultResourcesProperty
}

