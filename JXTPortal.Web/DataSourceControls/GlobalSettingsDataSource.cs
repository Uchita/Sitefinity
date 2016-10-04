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
	/// Represents the DataRepository.GlobalSettingsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(GlobalSettingsDataSourceDesigner))]
	public class GlobalSettingsDataSource : ProviderDataSource<GlobalSettings, GlobalSettingsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GlobalSettingsDataSource class.
		/// </summary>
		public GlobalSettingsDataSource() : base(new GlobalSettingsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the GlobalSettingsDataSourceView used by the GlobalSettingsDataSource.
		/// </summary>
		protected GlobalSettingsDataSourceView GlobalSettingsView
		{
			get { return ( View as GlobalSettingsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the GlobalSettingsDataSource control invokes to retrieve data.
		/// </summary>
		public GlobalSettingsSelectMethod SelectMethod
		{
			get
			{
				GlobalSettingsSelectMethod selectMethod = GlobalSettingsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (GlobalSettingsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the GlobalSettingsDataSourceView class that is to be
		/// used by the GlobalSettingsDataSource.
		/// </summary>
		/// <returns>An instance of the GlobalSettingsDataSourceView class.</returns>
		protected override BaseDataSourceView<GlobalSettings, GlobalSettingsKey> GetNewDataSourceView()
		{
			return new GlobalSettingsDataSourceView(this, DefaultViewName);
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
	/// Supports the GlobalSettingsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class GlobalSettingsDataSourceView : ProviderDataSourceView<GlobalSettings, GlobalSettingsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GlobalSettingsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the GlobalSettingsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public GlobalSettingsDataSourceView(GlobalSettingsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal GlobalSettingsDataSource GlobalSettingsOwner
		{
			get { return Owner as GlobalSettingsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal GlobalSettingsSelectMethod SelectMethod
		{
			get { return GlobalSettingsOwner.SelectMethod; }
			set { GlobalSettingsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal GlobalSettingsService GlobalSettingsProvider
		{
			get { return Provider as GlobalSettingsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<GlobalSettings> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<GlobalSettings> results = null;
			GlobalSettings item;
			count = 0;
			
			System.Int32 _siteId;
			System.Int32 _globalSettingId;
			System.Boolean _publicJobsSearch;
			System.Int32 _useAdvertiserFilter;
			System.Boolean _privateJobs;
			System.Int32? _defaultCountryId_nullable;
			System.Int32 _defaultLanguageId;
			System.Int32? _defaultDynamicPageId_nullable;
			System.Int32 _lastModifiedBy;
			System.Int32? _siteFavIconId_nullable;

			switch ( SelectMethod )
			{
				case GlobalSettingsSelectMethod.Get:
					GlobalSettingsKey entityKey  = new GlobalSettingsKey();
					entityKey.Load(values);
					item = GlobalSettingsProvider.Get(entityKey);
					results = new TList<GlobalSettings>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case GlobalSettingsSelectMethod.GetAll:
                    results = GlobalSettingsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case GlobalSettingsSelectMethod.GetPaged:
					results = GlobalSettingsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case GlobalSettingsSelectMethod.Find:
					if ( FilterParameters != null )
						results = GlobalSettingsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = GlobalSettingsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case GlobalSettingsSelectMethod.GetByGlobalSettingId:
					_globalSettingId = ( values["GlobalSettingId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["GlobalSettingId"], typeof(System.Int32)) : (int)0;
					item = GlobalSettingsProvider.GetByGlobalSettingId(_globalSettingId);
					results = new TList<GlobalSettings>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case GlobalSettingsSelectMethod.GetBySiteIdGlobalSettingId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					_globalSettingId = ( values["GlobalSettingId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["GlobalSettingId"], typeof(System.Int32)) : (int)0;
					results = GlobalSettingsProvider.GetBySiteIdGlobalSettingId(_siteId, _globalSettingId, this.StartIndex, this.PageSize, out count);
					break;
				case GlobalSettingsSelectMethod.GetBySiteIdPublicJobsSearch:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					_publicJobsSearch = ( values["PublicJobsSearch"] != null ) ? (System.Boolean) EntityUtil.ChangeType(values["PublicJobsSearch"], typeof(System.Boolean)) : false;
					results = GlobalSettingsProvider.GetBySiteIdPublicJobsSearch(_siteId, _publicJobsSearch, this.StartIndex, this.PageSize, out count);
					break;
				case GlobalSettingsSelectMethod.GetBySiteIdUseAdvertiserFilter:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					_useAdvertiserFilter = ( values["UseAdvertiserFilter"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["UseAdvertiserFilter"], typeof(System.Int32)) : (int)0;
					results = GlobalSettingsProvider.GetBySiteIdUseAdvertiserFilter(_siteId, _useAdvertiserFilter, this.StartIndex, this.PageSize, out count);
					break;
				case GlobalSettingsSelectMethod.GetByPublicJobsSearchPrivateJobsSiteId:
					_publicJobsSearch = ( values["PublicJobsSearch"] != null ) ? (System.Boolean) EntityUtil.ChangeType(values["PublicJobsSearch"], typeof(System.Boolean)) : false;
					_privateJobs = ( values["PrivateJobs"] != null ) ? (System.Boolean) EntityUtil.ChangeType(values["PrivateJobs"], typeof(System.Boolean)) : false;
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = GlobalSettingsProvider.GetByPublicJobsSearchPrivateJobsSiteId(_publicJobsSearch, _privateJobs, _siteId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case GlobalSettingsSelectMethod.GetByDefaultCountryId:
					_defaultCountryId_nullable = (System.Int32?) EntityUtil.ChangeType(values["DefaultCountryId"], typeof(System.Int32?));
					results = GlobalSettingsProvider.GetByDefaultCountryId(_defaultCountryId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case GlobalSettingsSelectMethod.GetByDefaultLanguageId:
					_defaultLanguageId = ( values["DefaultLanguageId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DefaultLanguageId"], typeof(System.Int32)) : (int)0;
					results = GlobalSettingsProvider.GetByDefaultLanguageId(_defaultLanguageId, this.StartIndex, this.PageSize, out count);
					break;
				case GlobalSettingsSelectMethod.GetByDefaultDynamicPageId:
					_defaultDynamicPageId_nullable = (System.Int32?) EntityUtil.ChangeType(values["DefaultDynamicPageId"], typeof(System.Int32?));
					results = GlobalSettingsProvider.GetByDefaultDynamicPageId(_defaultDynamicPageId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case GlobalSettingsSelectMethod.GetByLastModifiedBy:
					_lastModifiedBy = ( values["LastModifiedBy"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LastModifiedBy"], typeof(System.Int32)) : (int)0;
					results = GlobalSettingsProvider.GetByLastModifiedBy(_lastModifiedBy, this.StartIndex, this.PageSize, out count);
					break;
				case GlobalSettingsSelectMethod.GetBySiteFavIconId:
					_siteFavIconId_nullable = (System.Int32?) EntityUtil.ChangeType(values["SiteFavIconId"], typeof(System.Int32?));
					results = GlobalSettingsProvider.GetBySiteFavIconId(_siteFavIconId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case GlobalSettingsSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = GlobalSettingsProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == GlobalSettingsSelectMethod.Get || SelectMethod == GlobalSettingsSelectMethod.GetByGlobalSettingId )
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
				GlobalSettings entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					GlobalSettingsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<GlobalSettings> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			GlobalSettingsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region GlobalSettingsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the GlobalSettingsDataSource class.
	/// </summary>
	public class GlobalSettingsDataSourceDesigner : ProviderDataSourceDesigner<GlobalSettings, GlobalSettingsKey>
	{
		/// <summary>
		/// Initializes a new instance of the GlobalSettingsDataSourceDesigner class.
		/// </summary>
		public GlobalSettingsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public GlobalSettingsSelectMethod SelectMethod
		{
			get { return ((GlobalSettingsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new GlobalSettingsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region GlobalSettingsDataSourceActionList

	/// <summary>
	/// Supports the GlobalSettingsDataSourceDesigner class.
	/// </summary>
	internal class GlobalSettingsDataSourceActionList : DesignerActionList
	{
		private GlobalSettingsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the GlobalSettingsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public GlobalSettingsDataSourceActionList(GlobalSettingsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public GlobalSettingsSelectMethod SelectMethod
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

	#endregion GlobalSettingsDataSourceActionList
	
	#endregion GlobalSettingsDataSourceDesigner
	
	#region GlobalSettingsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the GlobalSettingsDataSource.SelectMethod property.
	/// </summary>
	public enum GlobalSettingsSelectMethod
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
		/// Represents the GetBySiteIdGlobalSettingId method.
		/// </summary>
		GetBySiteIdGlobalSettingId,
		/// <summary>
		/// Represents the GetBySiteIdPublicJobsSearch method.
		/// </summary>
		GetBySiteIdPublicJobsSearch,
		/// <summary>
		/// Represents the GetBySiteIdUseAdvertiserFilter method.
		/// </summary>
		GetBySiteIdUseAdvertiserFilter,
		/// <summary>
		/// Represents the GetByPublicJobsSearchPrivateJobsSiteId method.
		/// </summary>
		GetByPublicJobsSearchPrivateJobsSiteId,
		/// <summary>
		/// Represents the GetByGlobalSettingId method.
		/// </summary>
		GetByGlobalSettingId,
		/// <summary>
		/// Represents the GetByDefaultCountryId method.
		/// </summary>
		GetByDefaultCountryId,
		/// <summary>
		/// Represents the GetByDefaultLanguageId method.
		/// </summary>
		GetByDefaultLanguageId,
		/// <summary>
		/// Represents the GetByDefaultDynamicPageId method.
		/// </summary>
		GetByDefaultDynamicPageId,
		/// <summary>
		/// Represents the GetByLastModifiedBy method.
		/// </summary>
		GetByLastModifiedBy,
		/// <summary>
		/// Represents the GetBySiteFavIconId method.
		/// </summary>
		GetBySiteFavIconId,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId
	}
	
	#endregion GlobalSettingsSelectMethod

	#region GlobalSettingsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="GlobalSettings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GlobalSettingsFilter : SqlFilter<GlobalSettingsColumn>
	{
	}
	
	#endregion GlobalSettingsFilter

	#region GlobalSettingsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="GlobalSettings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GlobalSettingsExpressionBuilder : SqlExpressionBuilder<GlobalSettingsColumn>
	{
	}
	
	#endregion GlobalSettingsExpressionBuilder	

	#region GlobalSettingsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;GlobalSettingsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="GlobalSettings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GlobalSettingsProperty : ChildEntityProperty<GlobalSettingsChildEntityTypes>
	{
	}
	
	#endregion GlobalSettingsProperty
}

