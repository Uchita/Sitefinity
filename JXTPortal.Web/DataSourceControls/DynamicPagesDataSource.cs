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
	/// Represents the DataRepository.DynamicPagesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DynamicPagesDataSourceDesigner))]
	public class DynamicPagesDataSource : ProviderDataSource<DynamicPages, DynamicPagesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPagesDataSource class.
		/// </summary>
		public DynamicPagesDataSource() : base(new DynamicPagesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DynamicPagesDataSourceView used by the DynamicPagesDataSource.
		/// </summary>
		protected DynamicPagesDataSourceView DynamicPagesView
		{
			get { return ( View as DynamicPagesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DynamicPagesDataSource control invokes to retrieve data.
		/// </summary>
		public DynamicPagesSelectMethod SelectMethod
		{
			get
			{
				DynamicPagesSelectMethod selectMethod = DynamicPagesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DynamicPagesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DynamicPagesDataSourceView class that is to be
		/// used by the DynamicPagesDataSource.
		/// </summary>
		/// <returns>An instance of the DynamicPagesDataSourceView class.</returns>
		protected override BaseDataSourceView<DynamicPages, DynamicPagesKey> GetNewDataSourceView()
		{
			return new DynamicPagesDataSourceView(this, DefaultViewName);
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
	/// Supports the DynamicPagesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DynamicPagesDataSourceView : ProviderDataSourceView<DynamicPages, DynamicPagesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPagesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DynamicPagesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DynamicPagesDataSourceView(DynamicPagesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DynamicPagesDataSource DynamicPagesOwner
		{
			get { return Owner as DynamicPagesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DynamicPagesSelectMethod SelectMethod
		{
			get { return DynamicPagesOwner.SelectMethod; }
			set { DynamicPagesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DynamicPagesService DynamicPagesProvider
		{
			get { return Provider as DynamicPagesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<DynamicPages> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<DynamicPages> results = null;
			DynamicPages item;
			count = 0;
			
			System.Int32 _siteId;
			System.String _pageName;
			System.Int32 _languageId;
			System.String _pageFriendlyName;
			System.Int32 _dynamicPageId;
			System.Int32? _dynamicPageWebPartTemplateId_nullable;
			System.Int32 _lastModifiedBy;
			System.Int32 _relatedDynamicPageId;
			System.Int32? sp234_SiteId;
			System.Int32? sp234_LanguageId;
			System.Boolean? sp234_OnMainNavigation;
			System.Boolean? sp234_OnDynamicPageNavigation;
			System.Boolean? sp234_OnFooterNav;

			switch ( SelectMethod )
			{
				case DynamicPagesSelectMethod.Get:
					DynamicPagesKey entityKey  = new DynamicPagesKey();
					entityKey.Load(values);
					item = DynamicPagesProvider.Get(entityKey);
					results = new TList<DynamicPages>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DynamicPagesSelectMethod.GetAll:
                    results = DynamicPagesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case DynamicPagesSelectMethod.GetPaged:
					results = DynamicPagesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DynamicPagesSelectMethod.Find:
					if ( FilterParameters != null )
						results = DynamicPagesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DynamicPagesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DynamicPagesSelectMethod.GetByDynamicPageId:
					_dynamicPageId = ( values["DynamicPageId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DynamicPageId"], typeof(System.Int32)) : (int)0;
					item = DynamicPagesProvider.GetByDynamicPageId(_dynamicPageId);
					results = new TList<DynamicPages>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case DynamicPagesSelectMethod.GetBySiteIdPageNameLanguageId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					_pageName = ( values["PageName"] != null ) ? (System.String) EntityUtil.ChangeType(values["PageName"], typeof(System.String)) : string.Empty;
					_languageId = ( values["LanguageId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LanguageId"], typeof(System.Int32)) : (int)0;
					item = DynamicPagesProvider.GetBySiteIdPageNameLanguageId(_siteId, _pageName, _languageId);
					results = new TList<DynamicPages>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DynamicPagesSelectMethod.GetBySiteIdLanguageIdPageFriendlyName:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					_languageId = ( values["LanguageId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LanguageId"], typeof(System.Int32)) : (int)0;
					_pageFriendlyName = ( values["PageFriendlyName"] != null ) ? (System.String) EntityUtil.ChangeType(values["PageFriendlyName"], typeof(System.String)) : string.Empty;
					item = DynamicPagesProvider.GetBySiteIdLanguageIdPageFriendlyName(_siteId, _languageId, _pageFriendlyName);
					results = new TList<DynamicPages>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case DynamicPagesSelectMethod.GetByDynamicPageWebPartTemplateId:
					_dynamicPageWebPartTemplateId_nullable = (System.Int32?) EntityUtil.ChangeType(values["DynamicPageWebPartTemplateId"], typeof(System.Int32?));
					results = DynamicPagesProvider.GetByDynamicPageWebPartTemplateId(_dynamicPageWebPartTemplateId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case DynamicPagesSelectMethod.GetByLanguageId:
					_languageId = ( values["LanguageId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LanguageId"], typeof(System.Int32)) : (int)0;
					results = DynamicPagesProvider.GetByLanguageId(_languageId, this.StartIndex, this.PageSize, out count);
					break;
				case DynamicPagesSelectMethod.GetByLastModifiedBy:
					_lastModifiedBy = ( values["LastModifiedBy"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LastModifiedBy"], typeof(System.Int32)) : (int)0;
					results = DynamicPagesProvider.GetByLastModifiedBy(_lastModifiedBy, this.StartIndex, this.PageSize, out count);
					break;
				case DynamicPagesSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = DynamicPagesProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				case DynamicPagesSelectMethod.GetByRelatedDynamicPageIdFromRelatedDynamicPages:
					_relatedDynamicPageId = ( values["RelatedDynamicPageId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["RelatedDynamicPageId"], typeof(System.Int32)) : (int)0;
					results = DynamicPagesProvider.GetByRelatedDynamicPageIdFromRelatedDynamicPages(_relatedDynamicPageId, this.StartIndex, this.PageSize, out count);
					break;
				case DynamicPagesSelectMethod.GetByDynamicPageIdFromRelatedDynamicPages:
					_dynamicPageId = ( values["DynamicPageId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DynamicPageId"], typeof(System.Int32)) : (int)0;
					results = DynamicPagesProvider.GetByDynamicPageIdFromRelatedDynamicPages(_dynamicPageId, this.StartIndex, this.PageSize, out count);
					break;
				// Custom
				case DynamicPagesSelectMethod.GetNavigation:
					sp234_SiteId = (System.Int32?) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32?));
					sp234_LanguageId = (System.Int32?) EntityUtil.ChangeType(values["LanguageId"], typeof(System.Int32?));
					sp234_OnMainNavigation = (System.Boolean?) EntityUtil.ChangeType(values["OnMainNavigation"], typeof(System.Boolean?));
					sp234_OnDynamicPageNavigation = (System.Boolean?) EntityUtil.ChangeType(values["OnDynamicPageNavigation"], typeof(System.Boolean?));
					sp234_OnFooterNav = (System.Boolean?) EntityUtil.ChangeType(values["OnFooterNav"], typeof(System.Boolean?));
					results = DynamicPagesProvider.GetNavigation(sp234_SiteId, sp234_LanguageId, sp234_OnMainNavigation, sp234_OnDynamicPageNavigation, sp234_OnFooterNav, StartIndex, PageSize);
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
			if ( SelectMethod == DynamicPagesSelectMethod.Get || SelectMethod == DynamicPagesSelectMethod.GetByDynamicPageId )
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
				DynamicPages entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					DynamicPagesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<DynamicPages> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			DynamicPagesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DynamicPagesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DynamicPagesDataSource class.
	/// </summary>
	public class DynamicPagesDataSourceDesigner : ProviderDataSourceDesigner<DynamicPages, DynamicPagesKey>
	{
		/// <summary>
		/// Initializes a new instance of the DynamicPagesDataSourceDesigner class.
		/// </summary>
		public DynamicPagesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DynamicPagesSelectMethod SelectMethod
		{
			get { return ((DynamicPagesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DynamicPagesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DynamicPagesDataSourceActionList

	/// <summary>
	/// Supports the DynamicPagesDataSourceDesigner class.
	/// </summary>
	internal class DynamicPagesDataSourceActionList : DesignerActionList
	{
		private DynamicPagesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DynamicPagesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DynamicPagesDataSourceActionList(DynamicPagesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DynamicPagesSelectMethod SelectMethod
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

	#endregion DynamicPagesDataSourceActionList
	
	#endregion DynamicPagesDataSourceDesigner
	
	#region DynamicPagesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DynamicPagesDataSource.SelectMethod property.
	/// </summary>
	public enum DynamicPagesSelectMethod
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
		/// Represents the GetBySiteIdPageNameLanguageId method.
		/// </summary>
		GetBySiteIdPageNameLanguageId,
		/// <summary>
		/// Represents the GetBySiteIdLanguageIdPageFriendlyName method.
		/// </summary>
		GetBySiteIdLanguageIdPageFriendlyName,
		/// <summary>
		/// Represents the GetByDynamicPageId method.
		/// </summary>
		GetByDynamicPageId,
		/// <summary>
		/// Represents the GetByDynamicPageWebPartTemplateId method.
		/// </summary>
		GetByDynamicPageWebPartTemplateId,
		/// <summary>
		/// Represents the GetByLanguageId method.
		/// </summary>
		GetByLanguageId,
		/// <summary>
		/// Represents the GetByLastModifiedBy method.
		/// </summary>
		GetByLastModifiedBy,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId,
		/// <summary>
		/// Represents the GetByRelatedDynamicPageIdFromRelatedDynamicPages method.
		/// </summary>
		GetByRelatedDynamicPageIdFromRelatedDynamicPages,
		/// <summary>
		/// Represents the GetByDynamicPageIdFromRelatedDynamicPages method.
		/// </summary>
		GetByDynamicPageIdFromRelatedDynamicPages,
		/// <summary>
		/// Represents the GetNavigation method.
		/// </summary>
		GetNavigation
	}
	
	#endregion DynamicPagesSelectMethod

	#region DynamicPagesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPagesFilter : SqlFilter<DynamicPagesColumn>
	{
	}
	
	#endregion DynamicPagesFilter

	#region DynamicPagesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPagesExpressionBuilder : SqlExpressionBuilder<DynamicPagesColumn>
	{
	}
	
	#endregion DynamicPagesExpressionBuilder	

	#region DynamicPagesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DynamicPagesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPagesProperty : ChildEntityProperty<DynamicPagesChildEntityTypes>
	{
	}
	
	#endregion DynamicPagesProperty
}

