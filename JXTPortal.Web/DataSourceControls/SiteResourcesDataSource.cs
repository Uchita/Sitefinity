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
	/// Represents the DataRepository.SiteResourcesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SiteResourcesDataSourceDesigner))]
	public class SiteResourcesDataSource : ProviderDataSource<SiteResources, SiteResourcesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteResourcesDataSource class.
		/// </summary>
		public SiteResourcesDataSource() : base(new SiteResourcesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SiteResourcesDataSourceView used by the SiteResourcesDataSource.
		/// </summary>
		protected SiteResourcesDataSourceView SiteResourcesView
		{
			get { return ( View as SiteResourcesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SiteResourcesDataSource control invokes to retrieve data.
		/// </summary>
		public SiteResourcesSelectMethod SelectMethod
		{
			get
			{
				SiteResourcesSelectMethod selectMethod = SiteResourcesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SiteResourcesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SiteResourcesDataSourceView class that is to be
		/// used by the SiteResourcesDataSource.
		/// </summary>
		/// <returns>An instance of the SiteResourcesDataSourceView class.</returns>
		protected override BaseDataSourceView<SiteResources, SiteResourcesKey> GetNewDataSourceView()
		{
			return new SiteResourcesDataSourceView(this, DefaultViewName);
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
	/// Supports the SiteResourcesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SiteResourcesDataSourceView : ProviderDataSourceView<SiteResources, SiteResourcesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteResourcesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SiteResourcesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SiteResourcesDataSourceView(SiteResourcesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SiteResourcesDataSource SiteResourcesOwner
		{
			get { return Owner as SiteResourcesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SiteResourcesSelectMethod SelectMethod
		{
			get { return SiteResourcesOwner.SelectMethod; }
			set { SiteResourcesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SiteResourcesService SiteResourcesProvider
		{
			get { return Provider as SiteResourcesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SiteResources> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SiteResources> results = null;
			SiteResources item;
			count = 0;
			
			System.Int32 _siteId;
			System.Int32 _languageId;
			System.String _resourceCode;
			System.Int32 _siteResourceId;
			System.Int32 _lastModifiedBy;
			System.Int32? _resourceFileId_nullable;

			switch ( SelectMethod )
			{
				case SiteResourcesSelectMethod.Get:
					SiteResourcesKey entityKey  = new SiteResourcesKey();
					entityKey.Load(values);
					item = SiteResourcesProvider.Get(entityKey);
					results = new TList<SiteResources>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SiteResourcesSelectMethod.GetAll:
                    results = SiteResourcesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SiteResourcesSelectMethod.GetPaged:
					results = SiteResourcesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SiteResourcesSelectMethod.Find:
					if ( FilterParameters != null )
						results = SiteResourcesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SiteResourcesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SiteResourcesSelectMethod.GetBySiteResourceId:
					_siteResourceId = ( values["SiteResourceId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteResourceId"], typeof(System.Int32)) : (int)0;
					item = SiteResourcesProvider.GetBySiteResourceId(_siteResourceId);
					results = new TList<SiteResources>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case SiteResourcesSelectMethod.GetBySiteIdLanguageIdResourceCode:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					_languageId = ( values["LanguageId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LanguageId"], typeof(System.Int32)) : (int)0;
					_resourceCode = ( values["ResourceCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["ResourceCode"], typeof(System.String)) : string.Empty;
					item = SiteResourcesProvider.GetBySiteIdLanguageIdResourceCode(_siteId, _languageId, _resourceCode);
					results = new TList<SiteResources>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case SiteResourcesSelectMethod.GetByLanguageId:
					_languageId = ( values["LanguageId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LanguageId"], typeof(System.Int32)) : (int)0;
					results = SiteResourcesProvider.GetByLanguageId(_languageId, this.StartIndex, this.PageSize, out count);
					break;
				case SiteResourcesSelectMethod.GetByLastModifiedBy:
					_lastModifiedBy = ( values["LastModifiedBy"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LastModifiedBy"], typeof(System.Int32)) : (int)0;
					results = SiteResourcesProvider.GetByLastModifiedBy(_lastModifiedBy, this.StartIndex, this.PageSize, out count);
					break;
				case SiteResourcesSelectMethod.GetByResourceCode:
					_resourceCode = ( values["ResourceCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["ResourceCode"], typeof(System.String)) : string.Empty;
					results = SiteResourcesProvider.GetByResourceCode(_resourceCode, this.StartIndex, this.PageSize, out count);
					break;
				case SiteResourcesSelectMethod.GetByResourceFileId:
					_resourceFileId_nullable = (System.Int32?) EntityUtil.ChangeType(values["ResourceFileId"], typeof(System.Int32?));
					results = SiteResourcesProvider.GetByResourceFileId(_resourceFileId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case SiteResourcesSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = SiteResourcesProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == SiteResourcesSelectMethod.Get || SelectMethod == SiteResourcesSelectMethod.GetBySiteResourceId )
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
				SiteResources entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SiteResourcesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SiteResources> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SiteResourcesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SiteResourcesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SiteResourcesDataSource class.
	/// </summary>
	public class SiteResourcesDataSourceDesigner : ProviderDataSourceDesigner<SiteResources, SiteResourcesKey>
	{
		/// <summary>
		/// Initializes a new instance of the SiteResourcesDataSourceDesigner class.
		/// </summary>
		public SiteResourcesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SiteResourcesSelectMethod SelectMethod
		{
			get { return ((SiteResourcesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SiteResourcesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SiteResourcesDataSourceActionList

	/// <summary>
	/// Supports the SiteResourcesDataSourceDesigner class.
	/// </summary>
	internal class SiteResourcesDataSourceActionList : DesignerActionList
	{
		private SiteResourcesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SiteResourcesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SiteResourcesDataSourceActionList(SiteResourcesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SiteResourcesSelectMethod SelectMethod
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

	#endregion SiteResourcesDataSourceActionList
	
	#endregion SiteResourcesDataSourceDesigner
	
	#region SiteResourcesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SiteResourcesDataSource.SelectMethod property.
	/// </summary>
	public enum SiteResourcesSelectMethod
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
		/// Represents the GetBySiteIdLanguageIdResourceCode method.
		/// </summary>
		GetBySiteIdLanguageIdResourceCode,
		/// <summary>
		/// Represents the GetBySiteResourceId method.
		/// </summary>
		GetBySiteResourceId,
		/// <summary>
		/// Represents the GetByLanguageId method.
		/// </summary>
		GetByLanguageId,
		/// <summary>
		/// Represents the GetByLastModifiedBy method.
		/// </summary>
		GetByLastModifiedBy,
		/// <summary>
		/// Represents the GetByResourceCode method.
		/// </summary>
		GetByResourceCode,
		/// <summary>
		/// Represents the GetByResourceFileId method.
		/// </summary>
		GetByResourceFileId,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId
	}
	
	#endregion SiteResourcesSelectMethod

	#region SiteResourcesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteResources"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteResourcesFilter : SqlFilter<SiteResourcesColumn>
	{
	}
	
	#endregion SiteResourcesFilter

	#region SiteResourcesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteResources"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteResourcesExpressionBuilder : SqlExpressionBuilder<SiteResourcesColumn>
	{
	}
	
	#endregion SiteResourcesExpressionBuilder	

	#region SiteResourcesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SiteResourcesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SiteResources"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteResourcesProperty : ChildEntityProperty<SiteResourcesChildEntityTypes>
	{
	}
	
	#endregion SiteResourcesProperty
}

