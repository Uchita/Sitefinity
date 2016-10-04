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
	/// Represents the DataRepository.DynamicPageFilesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DynamicPageFilesDataSourceDesigner))]
	public class DynamicPageFilesDataSource : ProviderDataSource<DynamicPageFiles, DynamicPageFilesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageFilesDataSource class.
		/// </summary>
		public DynamicPageFilesDataSource() : base(new DynamicPageFilesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DynamicPageFilesDataSourceView used by the DynamicPageFilesDataSource.
		/// </summary>
		protected DynamicPageFilesDataSourceView DynamicPageFilesView
		{
			get { return ( View as DynamicPageFilesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DynamicPageFilesDataSource control invokes to retrieve data.
		/// </summary>
		public DynamicPageFilesSelectMethod SelectMethod
		{
			get
			{
				DynamicPageFilesSelectMethod selectMethod = DynamicPageFilesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DynamicPageFilesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DynamicPageFilesDataSourceView class that is to be
		/// used by the DynamicPageFilesDataSource.
		/// </summary>
		/// <returns>An instance of the DynamicPageFilesDataSourceView class.</returns>
		protected override BaseDataSourceView<DynamicPageFiles, DynamicPageFilesKey> GetNewDataSourceView()
		{
			return new DynamicPageFilesDataSourceView(this, DefaultViewName);
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
	/// Supports the DynamicPageFilesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DynamicPageFilesDataSourceView : ProviderDataSourceView<DynamicPageFiles, DynamicPageFilesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageFilesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DynamicPageFilesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DynamicPageFilesDataSourceView(DynamicPageFilesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DynamicPageFilesDataSource DynamicPageFilesOwner
		{
			get { return Owner as DynamicPageFilesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DynamicPageFilesSelectMethod SelectMethod
		{
			get { return DynamicPageFilesOwner.SelectMethod; }
			set { DynamicPageFilesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DynamicPageFilesService DynamicPageFilesProvider
		{
			get { return Provider as DynamicPageFilesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<DynamicPageFiles> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<DynamicPageFiles> results = null;
			DynamicPageFiles item;
			count = 0;
			
			System.Int32 _siteId;
			System.String _pageName;
			System.Int32 _fileId;
			System.Int32 _dynamicPageFileId;

			switch ( SelectMethod )
			{
				case DynamicPageFilesSelectMethod.Get:
					DynamicPageFilesKey entityKey  = new DynamicPageFilesKey();
					entityKey.Load(values);
					item = DynamicPageFilesProvider.Get(entityKey);
					results = new TList<DynamicPageFiles>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DynamicPageFilesSelectMethod.GetAll:
                    results = DynamicPageFilesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case DynamicPageFilesSelectMethod.GetPaged:
					results = DynamicPageFilesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DynamicPageFilesSelectMethod.Find:
					if ( FilterParameters != null )
						results = DynamicPageFilesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DynamicPageFilesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DynamicPageFilesSelectMethod.GetByDynamicPageFileId:
					_dynamicPageFileId = ( values["DynamicPageFileId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DynamicPageFileId"], typeof(System.Int32)) : (int)0;
					item = DynamicPageFilesProvider.GetByDynamicPageFileId(_dynamicPageFileId);
					results = new TList<DynamicPageFiles>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case DynamicPageFilesSelectMethod.GetBySiteIdPageNameFileId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					_pageName = ( values["PageName"] != null ) ? (System.String) EntityUtil.ChangeType(values["PageName"], typeof(System.String)) : string.Empty;
					_fileId = ( values["FileId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FileId"], typeof(System.Int32)) : (int)0;
					results = DynamicPageFilesProvider.GetBySiteIdPageNameFileId(_siteId, _pageName, _fileId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case DynamicPageFilesSelectMethod.GetByFileId:
					_fileId = ( values["FileId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FileId"], typeof(System.Int32)) : (int)0;
					results = DynamicPageFilesProvider.GetByFileId(_fileId, this.StartIndex, this.PageSize, out count);
					break;
				case DynamicPageFilesSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = DynamicPageFilesProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == DynamicPageFilesSelectMethod.Get || SelectMethod == DynamicPageFilesSelectMethod.GetByDynamicPageFileId )
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
				DynamicPageFiles entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					DynamicPageFilesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<DynamicPageFiles> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			DynamicPageFilesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DynamicPageFilesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DynamicPageFilesDataSource class.
	/// </summary>
	public class DynamicPageFilesDataSourceDesigner : ProviderDataSourceDesigner<DynamicPageFiles, DynamicPageFilesKey>
	{
		/// <summary>
		/// Initializes a new instance of the DynamicPageFilesDataSourceDesigner class.
		/// </summary>
		public DynamicPageFilesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DynamicPageFilesSelectMethod SelectMethod
		{
			get { return ((DynamicPageFilesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DynamicPageFilesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DynamicPageFilesDataSourceActionList

	/// <summary>
	/// Supports the DynamicPageFilesDataSourceDesigner class.
	/// </summary>
	internal class DynamicPageFilesDataSourceActionList : DesignerActionList
	{
		private DynamicPageFilesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DynamicPageFilesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DynamicPageFilesDataSourceActionList(DynamicPageFilesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DynamicPageFilesSelectMethod SelectMethod
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

	#endregion DynamicPageFilesDataSourceActionList
	
	#endregion DynamicPageFilesDataSourceDesigner
	
	#region DynamicPageFilesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DynamicPageFilesDataSource.SelectMethod property.
	/// </summary>
	public enum DynamicPageFilesSelectMethod
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
		/// Represents the GetBySiteIdPageNameFileId method.
		/// </summary>
		GetBySiteIdPageNameFileId,
		/// <summary>
		/// Represents the GetByDynamicPageFileId method.
		/// </summary>
		GetByDynamicPageFileId,
		/// <summary>
		/// Represents the GetByFileId method.
		/// </summary>
		GetByFileId,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId
	}
	
	#endregion DynamicPageFilesSelectMethod

	#region DynamicPageFilesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageFiles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageFilesFilter : SqlFilter<DynamicPageFilesColumn>
	{
	}
	
	#endregion DynamicPageFilesFilter

	#region DynamicPageFilesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageFiles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageFilesExpressionBuilder : SqlExpressionBuilder<DynamicPageFilesColumn>
	{
	}
	
	#endregion DynamicPageFilesExpressionBuilder	

	#region DynamicPageFilesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DynamicPageFilesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageFiles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageFilesProperty : ChildEntityProperty<DynamicPageFilesChildEntityTypes>
	{
	}
	
	#endregion DynamicPageFilesProperty
}

